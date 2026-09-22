using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sabra.LogicLayer
{

    public class clsInventoryBusiness : clsBusinessBase
    {
        private readonly clsInventoryDAL _inventoryDAL = new clsInventoryDAL();
        private readonly clsPriceHistoryDAL _priceHistDAL = new clsPriceHistoryDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();
        private readonly clsReportsDAL _reportsDAL = new clsReportsDAL();

        public OperationResult<List<InventoryItem>> GetAll() => Execute(()
            => OperationResult<List<InventoryItem>>.Ok(_inventoryDAL.GetAll()));

        public OperationResult<InventoryItem> GetByID(int partID) => Execute(() =>
        {
            if (partID <= 0) return OperationResult<InventoryItem>.Fail("رقم القطعة غير صحيح.");
            var item = _inventoryDAL.GetByID(partID);
            return item == null
                ? OperationResult<InventoryItem>.Fail("القطعة غير موجودة.")
                : OperationResult<InventoryItem>.Ok(item);
        });

        public OperationResult<InventoryItem> GetByBarcode(string barcode) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return OperationResult<InventoryItem>.Fail("الباركود مطلوب.");

            var item = _inventoryDAL.GetByBarcode(barcode.Trim());
            return item == null
                ? OperationResult<InventoryItem>.Fail("مفيش قطعة بالباركود ده.")
                : OperationResult<InventoryItem>.Ok(item);
        });

        /// <summary>stockFilter: "low" أو "zero" أو null.</summary>
        public OperationResult<List<InventoryItem>> Search(string keyword = null, int? categoryID = null,
                                                           int? brandID = null, string stockFilter = null) => Execute(()
            => OperationResult<List<InventoryItem>>.Ok(
                   _inventoryDAL.Search(string.IsNullOrWhiteSpace(keyword) ? null : keyword.Trim(),
                                        categoryID, brandID, stockFilter)));

        public OperationResult AddPart(InventoryItem item) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Inventory, "إضافة أصناف");
            if (guard != null) return guard;

            var invalid = Validate(item, isNew: true);
            if (invalid != null) return invalid;

            Normalize(item);

            if (!string.IsNullOrWhiteSpace(item.Barcode) && _inventoryDAL.BarcodeExists(item.Barcode))
                return OperationResult.Fail("الباركود ده مستخدم بالفعل لقطعة تانية.");

            if (item.SellingPrice <= 0 && item.MarkupPercent > 0)
                item.SellingPrice = CalcSellingPrice(item.PurchasePrice, item.MarkupPercent);

            if (item.MarkupPercent <= 0 && item.PurchasePrice > 0 && item.SellingPrice > 0)
                item.MarkupPercent = CalcMarkupPercent(item.PurchasePrice, item.SellingPrice);

            int newID = _inventoryDAL.Add(item);
            return OperationResult.Ok("تمت إضافة القطعة بنجاح.", newID);
        });

        public OperationResult UpdatePart(InventoryItem item) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Inventory, "تعديل الأصناف");
            if (guard != null) return guard;

            var invalid = Validate(item, isNew: false);
            if (invalid != null) return invalid;

            var existing = _inventoryDAL.GetByID(item.PartID);
            if (existing == null) return OperationResult.Fail("القطعة غير موجودة.");

            Normalize(item);

            if (!string.IsNullOrWhiteSpace(item.Barcode) && _inventoryDAL.BarcodeExists(item.Barcode, item.PartID))
                return OperationResult.Fail("الباركود ده مستخدم بالفعل لقطعة تانية.");

            if (item.CrossRefID.HasValue && item.CrossRefID.Value == item.PartID)
                return OperationResult.Fail("لا يمكن ربط القطعة ببديل هو نفسها.");

            // تغيير سعر البيع بيتم من خلال UpdatePrice عشان يتسجل في تاريخ الأسعار
            bool priceChanged = item.SellingPrice != existing.SellingPrice;
            item.SellingPrice = existing.SellingPrice;

            _inventoryDAL.Update(item);

            if (priceChanged)
                _inventoryDAL.UpdatePrice(item.PartID, item.SellingPrice, clsAppSession.UserID);

            return OperationResult.Ok("تم تحديث بيانات القطعة.");
        });

        /// <summary>تغيير سعر البيع (بيقفل السعر القديم ويفتح سطر جديد في تاريخ الأسعار).</summary>
        public OperationResult UpdatePrice(int partID, decimal newPrice) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Inventory, "تغيير الأسعار");
            if (guard != null) return guard;

            if (partID <= 0) return OperationResult.Fail("رقم القطعة غير صحيح.");
            if (newPrice <= 0) return OperationResult.Fail("سعر البيع يجب أن يكون أكبر من الصفر.");

            var item = _inventoryDAL.GetByID(partID);
            if (item == null) return OperationResult.Fail("القطعة غير موجودة.");
            if (newPrice == item.SellingPrice) return OperationResult.Fail("السعر الجديد هو نفس السعر الحالي.");

            if (newPrice < item.PurchasePrice)
                return OperationResult.Fail(
                    $"سعر البيع ({newPrice:N2}) أقل من سعر الشراء ({item.PurchasePrice:N2}) — بيع بخسارة.");

            _inventoryDAL.UpdatePrice(partID, newPrice, clsAppSession.UserID);
            return OperationResult.Ok("تم تحديث السعر وتسجيله في تاريخ الأسعار.");
        });

        /// <summary>تسوية جرد: بتاخد الكمية الجديدة وتحسب الفرق وتسجله كحركة مخزون.</summary>
        public OperationResult AdjustStock(int partID, int newStock, string reason) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Inventory, "تسوية المخزون");
            if (guard != null) return guard;

            if (partID <= 0) return OperationResult.Fail("رقم القطعة غير صحيح.");
            if (newStock < 0) return OperationResult.Fail("الكمية لا يمكن أن تكون سالبة.");
            if (string.IsNullOrWhiteSpace(reason)) return OperationResult.Fail("سبب التسوية مطلوب.");

            var item = _inventoryDAL.GetByID(partID);
            if (item == null) return OperationResult.Fail("القطعة غير موجودة.");

            int delta = newStock - item.CurrentStock;
            if (delta == 0) return OperationResult.Fail("الكمية الجديدة هي نفس الكمية الحالية.");

            _inventoryDAL.AdjustStock(partID, delta, clsLookupCache.MovementTypeID(clsSystemNames.MovStockCount),
                                      clsAppSession.UserID, reason.Trim());

            return OperationResult.Ok($"تمت التسوية: {(delta > 0 ? "+" : "")}{delta} قطعة.");
        });

        /// <summary>إخراج كمية تالفة من المخزون.</summary>
        public OperationResult WriteOffDamaged(int partID, int quantity, string reason) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Inventory, "إخراج التالف");
            if (guard != null) return guard;

            if (quantity <= 0) return OperationResult.Fail("الكمية يجب أن تكون أكبر من صفر.");
            if (string.IsNullOrWhiteSpace(reason)) return OperationResult.Fail("سبب الإخراج مطلوب.");

            var item = _inventoryDAL.GetByID(partID);
            if (item == null) return OperationResult.Fail("القطعة غير موجودة.");
            if (item.CurrentStock < quantity)
                return OperationResult.Fail($"المتاح في المخزن ({item.CurrentStock}) أقل من الكمية المطلوبة.");

            _inventoryDAL.AdjustStock(partID, -quantity, clsLookupCache.MovementTypeID(clsSystemNames.MovDamaged),
                                      clsAppSession.UserID, reason.Trim());

            return OperationResult.Ok("تم إخراج الكمية التالفة من المخزون.");
        });

        public OperationResult SoftDelete(int partID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Inventory, "حذف الأصناف");
            if (guard != null) return guard;

            var item = _inventoryDAL.GetByID(partID);
            if (item == null) return OperationResult.Fail("القطعة غير موجودة.");

            if (item.CurrentStock > 0)
                return OperationResult.Fail($"لا يمكن حذف قطعة رصيدها ({item.CurrentStock}) — اعمل تسوية للرصيد الأول.");

            _inventoryDAL.SoftDelete(partID);
            return OperationResult.Ok("تم حذف القطعة.");
        });

        public OperationResult<List<PriceHistory>> GetPriceHistory(int partID) => Execute(() =>
        {
            if (partID <= 0) return OperationResult<List<PriceHistory>>.Fail("رقم القطعة غير صحيح.");
            return OperationResult<List<PriceHistory>>.Ok(_priceHistDAL.GetByPart(partID));
        });

        // ── تقارير المخزون ────────────────────────────────────────────────────
        public OperationResult<List<LowStockView>> GetLowStock() => Execute(()
            => OperationResult<List<LowStockView>>.Ok(_reportsDAL.GetLowStockSuggestions()));

        public OperationResult<List<DeadStockView>> GetDeadStock(int minDays = 90) => Execute(()
            => OperationResult<List<DeadStockView>>.Ok(_reportsDAL.GetDeadStock(minDays)));

        public OperationResult<List<FastMovingStockView>> GetFastMoving() => Execute(()
            => OperationResult<List<FastMovingStockView>>.Ok(_reportsDAL.GetFastMovingStock()));

        public OperationResult<List<InventoryValuationView>> GetValuation() => Execute(()
            => OperationResult<List<InventoryValuationView>>.Ok(_reportsDAL.GetInventoryValuation()));

        // ── الجداول المرجعية ──────────────────────────────────────────────────
        public OperationResult<List<Category>> GetCategories() => Execute(()
            => OperationResult<List<Category>>.Ok(_lookupDAL.GetAllCategories()));

        public OperationResult AddCategory(string name) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(name)) return OperationResult.Fail("اسم التصنيف مطلوب.");
            name = name.Trim();

            if (_lookupDAL.GetAllCategories().Any(c => string.Equals(c.CategoryName, name, StringComparison.OrdinalIgnoreCase)))
                return OperationResult.Fail("التصنيف ده موجود بالفعل.");

            _lookupDAL.AddCategory(name);
            return OperationResult.Ok("تمت إضافة التصنيف.");
        });

        public OperationResult<List<Brand>> GetBrands() => Execute(()
            => OperationResult<List<Brand>>.Ok(_lookupDAL.GetAllBrands()));

        public OperationResult AddBrand(string name, string country = null) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(name)) return OperationResult.Fail("اسم الماركة مطلوب.");
            name = name.Trim();

            if (_lookupDAL.GetAllBrands().Any(b => string.Equals(b.BrandName, name, StringComparison.OrdinalIgnoreCase)))
                return OperationResult.Fail("الماركة دي موجودة بالفعل.");

            _lookupDAL.AddBrand(name, string.IsNullOrWhiteSpace(country) ? null : country.Trim());
            return OperationResult.Ok("تمت إضافة الماركة.");
        });

        public OperationResult<List<Unit>> GetUnits() => Execute(()
            => OperationResult<List<Unit>>.Ok(_lookupDAL.GetAllUnits()));

        public OperationResult AddUnit(string name) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(name)) return OperationResult.Fail("اسم الوحدة مطلوب.");
            name = name.Trim();

            if (_lookupDAL.GetAllUnits().Any(u => string.Equals(u.UnitName, name, StringComparison.OrdinalIgnoreCase)))
                return OperationResult.Fail("الوحدة دي موجودة بالفعل.");

            _lookupDAL.AddUnit(name);
            return OperationResult.Ok("تمت إضافة الوحدة.");
        });

        // ── حسابات ────────────────────────────────────────────────────────────
        public decimal CalcSellingPrice(decimal purchasePrice, decimal markupPercent)
            => purchasePrice <= 0 ? 0 : Math.Round(purchasePrice * (1 + markupPercent / 100), 2);

        public decimal CalcMarkupPercent(decimal purchasePrice, decimal sellingPrice)
            => purchasePrice <= 0 ? 0 : Math.Round((sellingPrice - purchasePrice) / purchasePrice * 100, 2);

        private static void Normalize(InventoryItem item)
        {
            item.PartName = item.PartName.Trim();
            item.Barcode = string.IsNullOrWhiteSpace(item.Barcode) ? null : item.Barcode.Trim();
            item.TechnicalNumber = string.IsNullOrWhiteSpace(item.TechnicalNumber) ? null : item.TechnicalNumber.Trim();
        }

        private static OperationResult Validate(InventoryItem item, bool isNew)
        {
            if (item == null) return OperationResult.Fail("بيانات القطعة غير موجودة.");
            if (!isNew && item.PartID <= 0) return OperationResult.Fail("رقم القطعة غير صحيح.");
            if (string.IsNullOrWhiteSpace(item.PartName)) return OperationResult.Fail("اسم القطعة مطلوب.");
            if (item.PartName.Trim().Length > 200) return OperationResult.Fail("اسم القطعة طويل جدًا.");
            if (item.PurchasePrice < 0) return OperationResult.Fail("سعر الشراء لا يمكن أن يكون سالباً.");
            if (item.SellingPrice < 0) return OperationResult.Fail("سعر البيع لا يمكن أن يكون سالباً.");
            if (item.MarkupPercent < 0) return OperationResult.Fail("نسبة الربح لا يمكن أن تكون سالبة.");
            if (item.MarkupPercent > 999.99m) return OperationResult.Fail("نسبة الربح أكبر من المسموح (999.99%).");
            if (item.SellingPrice > 0 && item.SellingPrice < item.PurchasePrice)
                return OperationResult.Fail("سعر البيع لا يجب أن يكون أقل من سعر الشراء.");
            if (item.CurrentStock < 0) return OperationResult.Fail("الكمية الحالية لا يمكن أن تكون سالبة.");
            if (item.MinLimit < 0) return OperationResult.Fail("الحد الأدنى لا يمكن أن يكون سالباً.");
            return null;
        }
    }
}