using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{

    public class clsPurchaseOrderBusiness : clsBusinessBase
    {
        private readonly clsPurchaseOrderDAL _poDAL = new clsPurchaseOrderDAL();
        private readonly clsInventoryDAL _inventoryDAL = new clsInventoryDAL();
        private readonly clsSupplierDAL _supplierDAL = new clsSupplierDAL();

        public OperationResult<List<PurchaseOrder>> GetAll(int? supplierID = null, int? statusID = null) => Execute(()
            => OperationResult<List<PurchaseOrder>>.Ok(_poDAL.GetAll(supplierID, statusID)));

        public OperationResult<PurchaseOrder> GetByID(int poID) => Execute(() =>
        {
            var po = _poDAL.GetByID(poID);
            return po == null
                ? OperationResult<PurchaseOrder>.Fail("أمر الشراء غير موجود.")
                : OperationResult<PurchaseOrder>.Ok(po);
        });

        public OperationResult<List<PurchaseOrderStatus>> GetStatuses() => Execute(()
            => OperationResult<List<PurchaseOrderStatus>>.Ok(clsLookupCache.POStatuses));

        public OperationResult CreatePO(PurchaseOrder po) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Purchases, "إنشاء أوامر شراء");
            if (guard != null) return guard;

            if (po == null) return OperationResult.Fail("بيانات أمر الشراء غير صحيحة.");
            if (po.SupplierID <= 0) return OperationResult.Fail("يجب اختيار المورد.");
            if (po.Details == null || po.Details.Count == 0)
                return OperationResult.Fail("أمر الشراء لا يحتوي على قطع.");

            var supplier = _supplierDAL.GetByID(po.SupplierID);
            if (supplier == null) return OperationResult.Fail("المورد غير موجود.");

            // دمج الأسطر المكررة (الـ TVP مفتاحه Part_ID)
            po.Details = po.Details
                .Where(d => d != null)
                .GroupBy(d => d.PartID)
                .Select(g => new PurchaseOrderDetail
                {
                    PartID = g.Key,
                    Quantity = g.Sum(x => x.Quantity),
                    UnitPrice = g.First().UnitPrice,
                    PartName = g.First().PartName
                })
                .ToList();

            foreach (var d in po.Details)
            {
                if (d.Quantity <= 0) return OperationResult.Fail("الكمية يجب أن تكون أكبر من صفر.");
                if (d.UnitPrice < 0) return OperationResult.Fail("سعر الوحدة لا يمكن أن يكون سالباً.");

                var part = _inventoryDAL.GetByID(d.PartID);
                if (part == null) return OperationResult.Fail($"القطعة رقم {d.PartID} غير موجودة.");
                if (string.IsNullOrWhiteSpace(d.PartName)) d.PartName = part.PartName;
            }

            po.EmployeeID = clsAppSession.EmployeeID;
            po.OrderDate = po.OrderDate == default ? DateTime.Today : po.OrderDate;
            po.TotalAmount = po.Details.Sum(d => d.Quantity * d.UnitPrice);
            po.StatusID = clsLookupCache.POStatusID(clsSystemNames.POOpen);

            if (po.PaidAmount < 0) po.PaidAmount = 0;
            if (po.PaidAmount > po.TotalAmount)
                return OperationResult.Fail("المبلغ المدفوع مقدمًا أكبر من إجمالي الأمر.");

            int newID = _poDAL.Add(po, clsAppSession.UserID);
            return OperationResult.Ok("تم إنشاء أمر الشراء بنجاح.", newID);
        });

        /// <summary>
        /// استلام أمر الشراء بالكامل: الـ SP بتزوّد المخزون بالكميات الناقصة،
        /// تسجّل حركة مخزون لكل صنف، وتغيّر الحالة لـ "مستلم بالكامل".
        /// (الاستلام الجزئي محتاج SP مخصصة - مش متاح حاليًا.)
        /// </summary>
        public OperationResult ReceiveGoods(int poID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Purchases, "استلام أوامر الشراء");
            if (guard != null) return guard;

            var po = _poDAL.GetByID(poID);
            if (po == null) return OperationResult.Fail("أمر الشراء غير موجود.");

            int receivedStatusID = clsLookupCache.POStatusID(clsSystemNames.POFullyReceived);
            if (po.StatusID == receivedStatusID)
                return OperationResult.Fail("تم استلام هذا الأمر بالكامل مسبقاً.");

            if (po.StatusID == clsLookupCache.POStatusID(clsSystemNames.POCancelled))
                return OperationResult.Fail("أمر الشراء ده ملغي.");

            bool ok = _poDAL.Receive(poID, receivedStatusID,
                                     clsLookupCache.MovementTypeID(clsSystemNames.MovPurchase),
                                     clsAppSession.UserID);

            return ok ? OperationResult.Ok("تم تسجيل الاستلام وتحديث المخزون بنجاح.")
                      : OperationResult.Fail("لم يتم تسجيل الاستلام.");
        });

        /// <summary>سداد دفعة لمورد (بتحدّث الأمر + رصيد المورد + الخزنة جوه SP واحدة).</summary>
        public OperationResult PaySupplier(int poID, decimal amount, int paymentMethodID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Purchases, "سداد الموردين");
            if (guard != null) return guard;

            if (amount <= 0) return OperationResult.Fail("المبلغ يجب أن يكون أكبر من صفر.");
            if (!clsLookupCache.PaymentMethodExists(paymentMethodID))
                return OperationResult.Fail("يجب اختيار طريقة دفع صحيحة.");

            var po = _poDAL.GetByID(poID);
            if (po == null) return OperationResult.Fail("أمر الشراء غير موجود.");

            if (po.Remaining <= 0) return OperationResult.Fail("أمر الشراء ده مسدّد بالكامل.");
            if (amount > po.Remaining)
                return OperationResult.Fail($"المبلغ أكبر من المتبقي ({po.Remaining:N2} جنيه).");

            bool ok = _poDAL.UpdatePayment(poID, amount, paymentMethodID,
                                           clsLookupCache.TransactionTypeID(clsSystemNames.TxSupplierPayment),
                                           clsAppSession.UserID);

            return ok ? OperationResult.Ok($"تم سداد {amount:N2} جنيه للمورد.")
                      : OperationResult.Fail("لم يتم تسجيل الدفعة.");
        });

        public OperationResult CancelPO(int poID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Purchases, "إلغاء أوامر الشراء");
            if (guard != null) return guard;

            var po = _poDAL.GetByID(poID);
            if (po == null) return OperationResult.Fail("أمر الشراء غير موجود.");

            if (po.StatusID == clsLookupCache.POStatusID(clsSystemNames.POFullyReceived))
                return OperationResult.Fail("لا يمكن إلغاء أمر تم استلامه بالكامل.");
            if (po.PaidAmount > 0)
                return OperationResult.Fail("لا يمكن إلغاء أمر مدفوع جزئيًا أو كليًا.");

            _poDAL.UpdateStatus(poID, clsLookupCache.POStatusID(clsSystemNames.POCancelled));
            return OperationResult.Ok("تم إلغاء أمر الشراء.");
        });
    }

}