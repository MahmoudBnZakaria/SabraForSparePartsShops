using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        // =========================================================
        // GET ALL
        // =========================================================

        public OperationResult<List<InventoryItem>> GetAll()
        {
            try
            {
                return OperationResult<List<InventoryItem>>
                    .Ok(_inventoryDAL.GetAll());
            }
            catch (Exception ex)
            {
                return HandleException<List<InventoryItem>>(
                    ex,
                    "حدث خطأ أثناء تحميل قائمة المخزون.");
            }
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public OperationResult<InventoryItem> GetByID(int partID)
        {
            try
            {
                if (partID <= 0)
                    return OperationResult<InventoryItem>
                        .Fail("رقم القطعة غير صحيح.");

                var item = _inventoryDAL.GetByID(partID);

                if (item == null)
                    return OperationResult<InventoryItem>
                        .Fail("القطعة غير موجودة.");

                return OperationResult<InventoryItem>.Ok(item);
            }
            catch (Exception ex)
            {
                return HandleException<InventoryItem>(
                    ex,
                    "حدث خطأ أثناء تحميل بيانات القطعة.");
            }
        }

        // =========================================================
        // GET BY BARCODE
        // =========================================================

        public OperationResult<InventoryItem> GetByBarcode(string barcode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(barcode))
                {
                    return OperationResult<InventoryItem>
                        .Fail("الباركود فارغ.");
                }

                barcode = barcode.Trim();

                var item = _inventoryDAL.GetByBarcode(barcode);

                if (item == null)
                {
                    return OperationResult<InventoryItem>
                        .Fail("لا توجد قطعة بهذا الباركود.");
                }

                return OperationResult<InventoryItem>.Ok(item);
            }
            catch (Exception ex)
            {
                return HandleException<InventoryItem>(
                    ex,
                    "حدث خطأ أثناء البحث بالباركود.");
            }
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public OperationResult<List<InventoryItem>> Search(
            string keyword,
            int? categoryID = null,
            int? brandID = null,
            string stockFilter = null)
        {
            try
            {
                return OperationResult<List<InventoryItem>>
                    .Ok(
                        _inventoryDAL.Search(
                            keyword,
                            categoryID,
                            brandID,
                            stockFilter));
            }
            catch (Exception ex)
            {
                return HandleException<List<InventoryItem>>(
                    ex,
                    "حدث خطأ أثناء البحث في المخزون.");
            }
        }

        // =========================================================
        // ADD PART
        // =========================================================

        public OperationResult AddPart(InventoryItem item)
        {
            try
            {
                // -------------------------------------------------
                // 1. التأكد من وجود object
                // -------------------------------------------------

                if (item == null)
                    return OperationResult.Fail("بيانات القطعة غير موجودة.");

                // -------------------------------------------------
                // 2. التحقق من البيانات الأساسية
                // -------------------------------------------------

                if (string.IsNullOrWhiteSpace(item.PartName))
                    return OperationResult.Fail("اسم القطعة مطلوب.");

                // -------------------------------------------------
                // 3. التحقق من الأسعار
                // -------------------------------------------------

                if (item.PurchasePrice < 0)
                    return OperationResult.Fail(
                        "سعر الشراء لا يمكن أن يكون سالباً.");

                if (item.SellingPrice < 0)
                    return OperationResult.Fail(
                        "سعر البيع لا يمكن أن يكون سالباً.");

                if (item.SellingPrice > 0 &&
                    item.SellingPrice < item.PurchasePrice)
                {
                    return OperationResult.Fail(
                        "سعر البيع لا يجب أن يكون أقل من سعر الشراء.");
                }

                // -------------------------------------------------
                // 4. التحقق من الكميات
                // -------------------------------------------------

                if (item.CurrentStock < 0)
                    return OperationResult.Fail(
                        "الكمية الحالية لا يمكن أن تكون سالبة.");

                if (item.MinLimit < 0)
                    return OperationResult.Fail(
                        "الحد الأدنى لا يمكن أن يكون سالباً.");

                // -------------------------------------------------
                // 5. تنظيف البيانات النصية
                // -------------------------------------------------

                item.PartName = item.PartName.Trim();

                if (!string.IsNullOrWhiteSpace(item.Barcode))
                    item.Barcode = item.Barcode.Trim();

                if (!string.IsNullOrWhiteSpace(item.TechnicalNumber))
                    item.TechnicalNumber = item.TechnicalNumber.Trim();

                // -------------------------------------------------
                // 6. التأكد من عدم تكرار الباركود
                // -------------------------------------------------

                if (!string.IsNullOrWhiteSpace(item.Barcode))
                {
                    if (_inventoryDAL.BarcodeExists(item.Barcode))
                    {
                        return OperationResult.Fail(
                            "الباركود موجود مسبقاً لقطعة أخرى.");
                    }
                }

                // -------------------------------------------------
                // 7. حساب سعر البيع إذا لم يتم إدخاله
                // -------------------------------------------------

                if (item.SellingPrice == 0 &&
                    item.MarkupPercent > 0)
                {
                    item.SellingPrice =
                        CalcSellingPrice(
                            item.PurchasePrice,
                            item.MarkupPercent);
                }

                // بعد الحساب نتأكد مرة أخرى
                if (item.SellingPrice < item.PurchasePrice)
                {
                    return OperationResult.Fail(
                        "سعر البيع لا يجب أن يكون أقل من سعر الشراء.");
                }

                // -------------------------------------------------
                // 8. إضافة القطعة
                // -------------------------------------------------

                int newID = _inventoryDAL.Add(item);

                if (newID <= 0)
                {
                    return OperationResult.Fail(
                        "فشل الحصول على رقم القطعة الجديدة.");
                }

                // -------------------------------------------------
                // 9. تسجيل الرصيد الأولي في سجل الحركة
                // -------------------------------------------------

                if (item.CurrentStock > 0 &&
                    clsAppSession.IsLoggedIn)
                {
                    var movTypes =
                        _lookupDAL.GetAllMovementTypes();

                    var purchaseType =
                        movTypes.FirstOrDefault(
                            m => m.TypeName == PurchaseMovement);

                    if (purchaseType != null)
                    {
                        _auditDAL.Add(new AuditLog
                        {
                            PartID = newID,
                            MovementTypeID =
                                purchaseType.MovementTypeID,

                            QuantityChange =
                                item.CurrentStock,

                            UserID =
                                clsAppSession.CurrentUser.UserID,

                            ActionDate = DateTime.Now,

                            Remarks =
                                "رصيد أولي عن إضافة القطعة"
                        });
                    }
                }

                return OperationResult.Ok(
                    "تمت إضافة القطعة بنجاح.",
                    newID);
            }
            catch (Exception ex)
            {
                return HandleException(
                    ex,
                    "حدث خطأ أثناء إضافة القطعة.");
            }
        }

        // =========================================================
        // UPDATE PART
        // =========================================================

        public OperationResult UpdatePart(InventoryItem item)
        {
            try
            {
                // -------------------------------------------------
                // 1. التحقق من object
                // -------------------------------------------------

                if (item == null)
                    return OperationResult.Fail(
                        "بيانات القطعة غير موجودة.");

                // -------------------------------------------------
                // 2. التحقق من ID
                // -------------------------------------------------

                if (item.PartID <= 0)
                    return OperationResult.Fail(
                        "رقم القطعة غير صحيح.");

                // -------------------------------------------------
                // 3. البيانات الأساسية
                // -------------------------------------------------

                if (string.IsNullOrWhiteSpace(item.PartName))
                    return OperationResult.Fail(
                        "اسم القطعة مطلوب.");

                item.PartName = item.PartName.Trim();

                // -------------------------------------------------
                // 4. الأسعار
                // -------------------------------------------------

                if (item.PurchasePrice < 0 ||
                    item.SellingPrice < 0)
                {
                    return OperationResult.Fail(
                        "الأسعار لا يمكن أن تكون سالبة.");
                }

                if (item.SellingPrice > 0 &&
                    item.SellingPrice < item.PurchasePrice)
                {
                    return OperationResult.Fail(
                        "سعر البيع لا يجب أن يكون أقل من سعر الشراء.");
                }

                // -------------------------------------------------
                // 5. الكمية
                // -------------------------------------------------

                if (item.CurrentStock < 0)
                    return OperationResult.Fail(
                        "الكمية الحالية لا يمكن أن تكون سالبة.");

                if (item.MinLimit < 0)
                    return OperationResult.Fail(
                        "الحد الأدنى لا يمكن أن يكون سالباً.");

                // -------------------------------------------------
                // 6. تنظيف الباركود
                // -------------------------------------------------

                if (!string.IsNullOrWhiteSpace(item.Barcode))
                    item.Barcode = item.Barcode.Trim();

                // -------------------------------------------------
                // 7. التأكد من عدم تكرار الباركود
                // -------------------------------------------------

                if (!string.IsNullOrWhiteSpace(item.Barcode))
                {
                    if (_inventoryDAL.BarcodeExists(
                            item.Barcode,
                            item.PartID))
                    {
                        return OperationResult.Fail(
                            "الباركود موجود مسبقاً لقطعة أخرى.");
                    }
                }

                // -------------------------------------------------
                // 8. التأكد أن القطعة موجودة
                // -------------------------------------------------

                var existing =
                    _inventoryDAL.GetByID(item.PartID);

                if (existing == null)
                {
                    return OperationResult.Fail(
                        "القطعة غير موجودة.");
                }

                // -------------------------------------------------
                // 9. تنفيذ التعديل
                // -------------------------------------------------

                _inventoryDAL.Update(item);

                return OperationResult.Ok(
                    "تم تحديث بيانات القطعة.");
            }
            catch (Exception ex)
            {
                return HandleException(
                    ex,
                    "حدث خطأ أثناء تحديث بيانات القطعة.");
            }
        }

        // =========================================================
        // UPDATE PRICE
        // =========================================================

        public OperationResult UpdatePrice(
            int partID,
            decimal newPrice)
        {
            try
            {
                if (partID <= 0)
                    return OperationResult.Fail(
                        "رقم القطعة غير صحيح.");

                if (newPrice <= 0)
                    return OperationResult.Fail(
                        "سعر البيع يجب أن يكون أكبر من الصفر.");

                var item =
                    _inventoryDAL.GetByID(partID);

                if (item == null)
                    return OperationResult.Fail(
                        "القطعة غير موجودة.");

                if (newPrice < item.PurchasePrice)
                {
                    return OperationResult.Fail(
                        "سعر البيع لا يجب أن يكون أقل من سعر الشراء.");
                }

                _inventoryDAL.UpdatePrice(
                    partID,
                    newPrice);

                return OperationResult.Ok(
                    "تم تحديث سعر البيع بنجاح.");
            }
            catch (Exception ex)
            {
                return HandleException(
                    ex,
                    "حدث خطأ أثناء تحديث سعر البيع.");
            }
        }

        // =========================================================
        // ADJUST STOCK
        // =========================================================

        public OperationResult AdjustStock(
            int partID,
            int newStock,
            string reason)
        {
            try
            {
                // -------------------------------------------------
                // 1. التحقق من الكمية
                // -------------------------------------------------

                if (partID <= 0)
                    return OperationResult.Fail(
                        "رقم القطعة غير صحيح.");

                if (newStock < 0)
                    return OperationResult.Fail(
                        "الكمية لا يمكن أن تكون سالبة.");

                // -------------------------------------------------
                // 2. السبب
                // -------------------------------------------------

                if (string.IsNullOrWhiteSpace(reason))
                    return OperationResult.Fail(
                        "سبب التعديل مطلوب.");

                reason = reason.Trim();

                // -------------------------------------------------
                // 3. الجلسة
                // -------------------------------------------------

                if (!clsAppSession.IsLoggedIn ||
                    clsAppSession.CurrentUser == null)
                {
                    return OperationResult.Fail(
                        "يجب تسجيل الدخول أولاً.");
                }

                // -------------------------------------------------
                // 4. التأكد من وجود القطعة
                // -------------------------------------------------

                var item =
                    _inventoryDAL.GetByID(partID);

                if (item == null)
                    return OperationResult.Fail(
                        "القطعة غير موجودة.");

                // -------------------------------------------------
                // 5. حساب الفرق
                // -------------------------------------------------

                int diff =
                    newStock - item.CurrentStock;

                if (diff == 0)
                {
                    return OperationResult.Ok(
                        "لا يوجد تغيير في الكمية.");
                }

                // -------------------------------------------------
                // 6. الحصول على نوع الحركة
                // -------------------------------------------------

                var movTypes =
                    _lookupDAL.GetAllMovementTypes();

                var adjType =
                    movTypes.FirstOrDefault(
                        m => m.TypeName == ManualAdjustMovement);

                if (adjType == null)
                {
                    return OperationResult.Fail(
                        $"نوع الحركة ({ManualAdjustMovement}) " +
                        "غير معرّف في النظام.");
                }

                // -------------------------------------------------
                // 7. تعديل المخزون
                // -------------------------------------------------

                bool updated =
                    _inventoryDAL.AdjustStock(
                        partID,
                        diff,
                        adjType.MovementTypeID,
                        clsAppSession.CurrentUser.UserID,
                        reason);

                if (!updated)
                {
                    return OperationResult.Fail(
                        "فشل تعديل الكمية.");
                }

                // -------------------------------------------------
                // 8. تسجيل الحركة في Audit
                // -------------------------------------------------

                _auditDAL.Add(new AuditLog
                {
                    PartID = partID,

                    MovementTypeID =
                        adjType.MovementTypeID,

                    QuantityChange = diff,

                    UserID =
                        clsAppSession.CurrentUser.UserID,

                    ActionDate = DateTime.Now,

                    Remarks = reason
                });

                return OperationResult.Ok(
                    "تم تعديل الكمية بنجاح.");
            }
            catch (Exception ex)
            {
                return HandleException(
                    ex,
                    "حدث خطأ أثناء تعديل كمية المخزون.");
            }
        }

        // =========================================================
        // SOFT DELETE
        // =========================================================

        public OperationResult SoftDelete(int partID)
        {
            try
            {
                if (partID <= 0)
                    return OperationResult.Fail(
                        "رقم القطعة غير صحيح.");

                var item =
                    _inventoryDAL.GetByID(partID);

                if (item == null)
                    return OperationResult.Fail(
                        "القطعة غير موجودة.");

                _inventoryDAL.SoftDelete(partID);

                return OperationResult.Ok(
                    "تم حذف القطعة من النظام.");
            }
            catch (Exception ex)
            {
                return HandleException(
                    ex,
                    "حدث خطأ أثناء حذف القطعة.");
            }
        }

        // =========================================================
        // PRICE HISTORY
        // =========================================================

        public OperationResult<List<PriceHistory>> GetPriceHistory(
            int partID)
        {
            try
            {
                if (partID <= 0)
                {
                    return OperationResult<List<PriceHistory>>
                        .Fail("رقم القطعة غير صحيح.");
                }

                return OperationResult<List<PriceHistory>>
                    .Ok(
                        _priceHistDAL.GetByPart(partID));
            }
            catch (Exception ex)
            {
                return HandleException<List<PriceHistory>>(
                    ex,
                    "حدث خطأ أثناء تحميل سجل الأسعار.");
            }
        }

        // =========================================================
        // CATEGORIES
        // =========================================================

        public OperationResult<List<Category>> GetCategories()
        {
            try
            {
                return OperationResult<List<Category>>
                    .Ok(_lookupDAL.GetAllCategories());
            }
            catch (Exception ex)
            {
                return HandleException<List<Category>>(
                    ex,
                    "حدث خطأ أثناء تحميل التصنيفات.");
            }
        }

        public OperationResult AddCategory(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return OperationResult.Fail(
                        "الاسم مطلوب.");

                _lookupDAL.AddCategory(name.Trim());

                return OperationResult.Ok(
                    "تمت إضافة التصنيف.");
            }
            catch (Exception ex)
            {
                return HandleException(
                    ex,
                    "حدث خطأ أثناء إضافة التصنيف.");
            }
        }

        // =========================================================
        // BRANDS
        // =========================================================

        public OperationResult<List<Brand>> GetBrands()
        {
            try
            {
                return OperationResult<List<Brand>>
                    .Ok(_lookupDAL.GetAllBrands());
            }
            catch (Exception ex)
            {
                return HandleException<List<Brand>>(
                    ex,
                    "حدث خطأ أثناء تحميل الماركات.");
            }
        }

        public OperationResult AddBrand(
            string name,
            string country = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return OperationResult.Fail(
                        "الاسم مطلوب.");

                name = name.Trim();

                if (!string.IsNullOrWhiteSpace(country))
                    country = country.Trim();

                _lookupDAL.AddBrand(
                    name,
                    country);

                return OperationResult.Ok(
                    "تمت إضافة الماركة.");
            }
            catch (Exception ex)
            {
                return HandleException(
                    ex,
                    "حدث خطأ أثناء إضافة الماركة.");
            }
        }

        // =========================================================
        // UNITS
        // =========================================================

        public OperationResult<List<Unit>> GetUnits()
        {
            try
            {
                return OperationResult<List<Unit>>
                    .Ok(_lookupDAL.GetAllUnits());
            }
            catch (Exception ex)
            {
                return HandleException<List<Unit>>(
                    ex,
                    "حدث خطأ أثناء تحميل وحدات البيع.");
            }
        }

        public OperationResult AddUnit(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return OperationResult.Fail(
                        "الاسم مطلوب.");

                _lookupDAL.AddUnit(name.Trim());

                return OperationResult.Ok(
                    "تمت إضافة وحدة البيع.");
            }
            catch (Exception ex)
            {
                return HandleException(
                    ex,
                    "حدث خطأ أثناء إضافة وحدة البيع.");
            }
        }

        // =========================================================
        // PRICE CALCULATIONS
        // =========================================================

        public decimal CalcSellingPrice(
            decimal purchasePrice,
            decimal markupPercent)
        {
            if (purchasePrice <= 0)
                return 0;

            return Math.Round(
                purchasePrice *
                (1 + markupPercent / 100),
                2);
        }

        public decimal CalcMarkupPercent(
            decimal purchasePrice,
            decimal sellingPrice)
        {
            if (purchasePrice <= 0)
                return 0;

            return Math.Round(
                (sellingPrice - purchasePrice)
                / purchasePrice * 100,
                2);
        }

        // =========================================================
        // EXCEPTION HANDLING
        // =========================================================

        private OperationResult HandleException(
            Exception ex,
            string userMessage)
        {
            LogException(ex);

            return OperationResult.Fail(
                userMessage);
        }

        private OperationResult<T> HandleException<T>(
            Exception ex,
            string userMessage)
        {
            LogException(ex);

            return OperationResult<T>.Fail(
                userMessage);
        }

        // =========================================================
        // LOGGING
        // =========================================================

        private void LogException(Exception ex)
        {
            // مؤقتاً أثناء التطوير:
            System.Diagnostics.Debug.WriteLine(
                "Inventory Business Error:");

            System.Diagnostics.Debug.WriteLine(
                ex.ToString());

            // لاحقاً الأفضل استبدال هذا
            // بـ Logger حقيقي يكتب إلى ملف أو Database.
        }
    }
}