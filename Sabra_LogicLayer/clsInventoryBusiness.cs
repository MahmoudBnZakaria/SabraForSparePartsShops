using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    public class clsInventoryBusiness
    {
        private readonly clsInventoryDAL _inventoryDAL = new clsInventoryDAL();
        private readonly clsPriceHistoryDAL _priceHistDAL = new clsPriceHistoryDAL();
        private readonly clsAuditDAL _auditDAL = new clsAuditDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        private const string PurchaseMovement = "شراء";
        private const string ManualAdjustMovement = "تعديل يدوي";

        public OperationResult<List<InventoryItem>> GetAll()
            => OperationResult<List<InventoryItem>>.Ok(_inventoryDAL.GetAll());

        public OperationResult<InventoryItem> GetByID(int partID)
        {
            var item = _inventoryDAL.GetByID(partID);
            if (item == null)
                return OperationResult<InventoryItem>.Fail("القطعة غير موجودة");
            return OperationResult<InventoryItem>.Ok(item);
        }

        public OperationResult<InventoryItem> GetByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return OperationResult<InventoryItem>.Fail("الباركود فارغ.");

            var item = _inventoryDAL.GetByBarcode(barcode.Trim());
            if (item == null)
                return OperationResult<InventoryItem>.Fail("لا توجد قطعة بهذا الباركود.");
            return OperationResult<InventoryItem>.Ok(item);
        }

        public OperationResult<List<InventoryItem>> Search(string keyword, int? categoryID = null, int? brandID = null, string stockFilter = null)
            => OperationResult<List<InventoryItem>>.Ok(_inventoryDAL.Search(keyword, categoryID, brandID, stockFilter));

        public OperationResult AddPart(InventoryItem item)
        {
            if (string.IsNullOrWhiteSpace(item.PartName))
                return OperationResult.Fail("اسم القطعة مطلوب");
            if (item.PurchasePrice < 0)
                return OperationResult.Fail("سعر الشراء لا يمكن أن يكون سالباً");
            if (item.SellingPrice < item.PurchasePrice)
                return OperationResult.Fail("سعر البيع لا يجب أن يكون أقل من سعر الشراء");
            if (item.CurrentStock < 0)
                return OperationResult.Fail("الكمية الحالية لا يمكن أن تكون سالبة");
            if (item.MinLimit < 0)
                return OperationResult.Fail("الحد الأدنى لا يمكن أن يكون سالباً.");

            if (!string.IsNullOrWhiteSpace(item.Barcode) && _inventoryDAL.BarcodeExists(item.Barcode))
                return OperationResult.Fail("الباركود موجود مسبقاً لقطعة أخرى.");

            if (item.SellingPrice == 0 && item.MarkupPercent > 0)
                item.SellingPrice = _inventoryDAL.CalculateSellingPrice(item.PurchasePrice, item.MarkupPercent);

            int newID = _inventoryDAL.Add(item);

            if (item.CurrentStock > 0 && clsAppSession.IsLoggedIn)
            {
                var movTypes = _lookupDAL.GetAllMovementTypes();
                var purchaseType = movTypes.FirstOrDefault(m => m.TypeName == PurchaseMovement);

                if (purchaseType != null)
                {
                    _auditDAL.Add(new AuditLog
                    {
                        PartID = newID,
                        MovementTypeID = purchaseType.MovementTypeID,
                        QuantityChange = item.CurrentStock,
                        UserID = clsAppSession.CurrentUser.UserID,
                        ActionDate = DateTime.Now,
                        Remarks = "رصيد أولي عن إضافة القطعة"
                    });
                }
            }

            return OperationResult.Ok("تمت إضافة القطعة بنجاح.", newID);
        }

        public OperationResult UpdatePart(InventoryItem item)
        {
            if (string.IsNullOrWhiteSpace(item.PartName))
                return OperationResult.Fail("اسم القطعة مطلوب");
            if (item.PurchasePrice < 0 || item.SellingPrice < 0)
                return OperationResult.Fail("الأسعار لا يمكن أن تكون سالبة");
            if (!string.IsNullOrWhiteSpace(item.Barcode) && _inventoryDAL.BarcodeExists(item.Barcode, item.PartID))
                return OperationResult.Fail("الباركود موجود مسبقاً لقطعة أخرى");

            var existing = _inventoryDAL.GetByID(item.PartID);
            if (existing == null)
                return OperationResult.Fail("القطعة غير موجودة");

            _inventoryDAL.Update(item);
            return OperationResult.Ok("تم تحديث بيانات القطعة");
        }

        public OperationResult UpdatePrice(int partID, decimal newPrice)
        {
            if (newPrice <= 0)
                return OperationResult.Fail("سعر البيع يجب أن يكون أكبر من الصفر");

            var item = _inventoryDAL.GetByID(partID);
            if (item == null)
                return OperationResult.Fail("القطعة غير موجودة");

            _inventoryDAL.UpdatePrice(partID, newPrice);
            return OperationResult.Ok("تم تحديث سعر البيع بنجاح");
        }

        public OperationResult AdjustStock(int partID, int newStock, string reason)
        {
            if (newStock < 0)
                return OperationResult.Fail("الكمية لا يمكن أن تكون سالبة");
            if (string.IsNullOrWhiteSpace(reason))
                return OperationResult.Fail("سبب التعديل مطلوب");
            if (!clsAppSession.IsLoggedIn)
                return OperationResult.Fail("يجب تسجيل الدخول أولاً");

            var item = _inventoryDAL.GetByID(partID);
            if (item == null)
                return OperationResult.Fail("القطعة غير موجودة");

            int diff = newStock - item.CurrentStock;
            if (diff == 0)
                return OperationResult.Ok("لا يوجد تغيير في الكمية");

            var movTypes = _lookupDAL.GetAllMovementTypes();
            var adjType = movTypes.FirstOrDefault(m => m.TypeName == ManualAdjustMovement);
            if (adjType == null)
                return OperationResult.Fail($"نوع الحركة ({ManualAdjustMovement}) غير معرّف في النظام");

            bool updated = _inventoryDAL.AdjustStock(partID, diff, adjType.MovementTypeID, clsAppSession.CurrentUser.UserID, reason);
            if (!updated)
                return OperationResult.Fail("فشل تعديل الكمية");

            _auditDAL.Add(new AuditLog
            {
                PartID = partID,
                MovementTypeID = adjType.MovementTypeID,
                QuantityChange = diff,
                UserID = clsAppSession.CurrentUser.UserID,
                ActionDate = DateTime.Now,
                Remarks = reason
            });

            return OperationResult.Ok("تم تعديل الكمية بنجاح");
        }

        public OperationResult SoftDelete(int partID)
        {
            var item = _inventoryDAL.GetByID(partID);
            if (item == null)
                return OperationResult.Fail("القطعة غير موجودة");

            _inventoryDAL.SoftDelete(partID);
            return OperationResult.Ok("تم حذف القطعة من النظام");
        }

        public OperationResult<List<PriceHistory>> GetPriceHistory(int partID)
            => OperationResult<List<PriceHistory>>.Ok(_priceHistDAL.GetByPart(partID));

        public OperationResult<List<Category>> GetCategories()
            => OperationResult<List<Category>>.Ok(_lookupDAL.GetAllCategories());

        public OperationResult<List<Brand>> GetBrands()
            => OperationResult<List<Brand>>.Ok(_lookupDAL.GetAllBrands());

        public OperationResult<List<Unit>> GetUnits()
            => OperationResult<List<Unit>>.Ok(_lookupDAL.GetAllUnits());

        public OperationResult AddCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return OperationResult.Fail("الاسم مطلوب");
            _lookupDAL.AddCategory(name.Trim());
            return OperationResult.Ok("تمت إضافة التصنيف");
        }

        public OperationResult AddBrand(string name, string country = null)
        {
            if (string.IsNullOrWhiteSpace(name)) return OperationResult.Fail("الاسم مطلوب.");
            _lookupDAL.AddBrand(name.Trim(), country?.Trim());
            return OperationResult.Ok("تمت إضافة الماركة.");
        }

        public OperationResult AddUnit(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return OperationResult.Fail("الاسم مطلوب.");
            _lookupDAL.AddUnit(name.Trim());
            return OperationResult.Ok("تمت إضافة وحدة البيع.");
        }

        public decimal CalcSellingPrice(decimal purchasePrice, decimal markupPercent)
            => purchasePrice > 0 ? Math.Round(purchasePrice * (1 + markupPercent / 100), 2) : 0;

        public decimal CalcMarkupPercent(decimal purchasePrice, decimal sellingPrice)
            => purchasePrice > 0 ? Math.Round((sellingPrice - purchasePrice) / purchasePrice * 100, 2) : 0;
    }

}