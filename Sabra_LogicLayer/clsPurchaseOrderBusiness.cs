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
    public class clsPurchaseOrderBusiness
    {

        private readonly clsPurshaseOrderDAL _poDal = new clsPurshaseOrderDAL();
        private readonly clsInventoryDAL _inventoryDAL = new clsInventoryDAL();
        private readonly clsSupplierDAL _supplierDAL = new clsSupplierDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();
        private readonly clsAuditDAL _auditDAL = new clsAuditDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();
        private readonly clsPriceHistoryDAL _priceHistDAL = new clsPriceHistoryDAL();

        public OperationResult<List<PurchaseOrder>> GetAll(int? supplierID = null, int? statusID = null)
            => OperationResult<List<PurchaseOrder>>.Ok(_poDal.GetAll(supplierID, statusID));

        public OperationResult<PurchaseOrder> GetByID(int poID)
        {
            var po = _poDal.GetByID(poID);
            if (po == null) return OperationResult<PurchaseOrder>.Fail("أمر الشراء غير موجود.");
            po.Details = _poDal.GetDetails(poID);
            return OperationResult<PurchaseOrder>.Ok(po);
        }

        public OperationResult CreatePO(PurchaseOrder po)
        {
            if (!clsAppSession.IsLoggedIn)
                return OperationResult.Fail("يجب تسجيل الدخول أولاً.");

            if (po.SupplierID <= 0)
                return OperationResult.Fail("يجب اختيار المورد.");

            if (po.Details == null || po.Details.Count == 0)
                return OperationResult.Fail("أمر الشراء لا يحتوي على قطع.");

            foreach (var detail in po.Details)
            {
                if (detail.Quantity <= 0)
                    return OperationResult.Fail("الكمية يجب أن تكون أكبر من صفر.");
                if (detail.UnitPrice < 0)
                    return OperationResult.Fail("سعر الوحدة لا يمكن أن يكون سالباً.");
            }

            po.EmployeeID = clsAppSession.CurrentEmployee.EmployeeID;
            po.OrderDate = po.OrderDate == default ? DateTime.Today : po.OrderDate;
            po.TotalAmount = po.Details.Sum(d => d.Quantity * d.UnitPrice);
            po.PaidAmount = 0;

            // حالة "مفتوح"
            var statuses = _lookupDAL.GetAllPOStatuses();
            po.StatusID = statuses.First(s => s.StatusName == "مفتوح").StatusID;

            int newID = _poDal.Add(po);
            return OperationResult.Ok("تم إنشاء أمر الشراء بنجاح.", newID);
        }

        /// <summary>
        /// تسجيل استلام بضاعة وتحديث المخزون
        /// </summary>
        public OperationResult ReceiveGoods(int poID, List<(int PartID, int ReceivedQty, decimal? NewUnitPrice)> received)
        {
            if (!clsAppSession.IsLoggedIn)
                return OperationResult.Fail("يجب تسجيل الدخول أولاً.");

            var po = _poDal.GetByID(poID);
            if (po == null) return OperationResult.Fail("أمر الشراء غير موجود.");

            var details = _poDal.GetDetails(poID);

            var movTypes = _lookupDAL.GetAllMovementTypes();
            var purchaseType = movTypes.FirstOrDefault(m => m.TypeName == "شراء");

            foreach (var (partID, receivedQty, newUnitPrice) in received)
            {
                if (receivedQty <= 0) continue;

                var part = _inventoryDAL.GetByID(partID);
                if (part == null) continue;

                // تحديث المخزون
                _inventoryDAL.UpdateStock(partID, part.CurrentStock + receivedQty);

                // تحديث سعر الشراء لو تغير
                if (newUnitPrice.HasValue && newUnitPrice.Value != part.PurchasePrice)
                {
                    _inventoryDAL.Update(new InventoryItem
                    {
                        PartID = part.PartID,
                        Barcode = part.Barcode,
                        TechnicalNumber = part.TechnicalNumber,
                        PartName = part.PartName,
                        CategoryID = part.CategoryID,
                        BrandID = part.BrandID,
                        UnitID = part.UnitID,
                        PurchasePrice = newUnitPrice.Value,
                        MarkupPercent = part.MarkupPercent,
                        SellingPrice = part.SellingPrice,
                        MinLimit = part.MinLimit,
                        CrossRefID = part.CrossRefID,
                        SupplierID = part.SupplierID
                    });
                }

                // تسجيل في سجل الحركة
                if (purchaseType != null)
                    _auditDAL.Add(new AuditLog
                    {
                        PartID = partID,
                        MovementTypeID = purchaseType.MovementTypeID,
                        QuantityChange = receivedQty,
                        UserID = clsAppSession.CurrentUser.UserID,
                        ActionDate = DateTime.Now,
                        Remarks = $"استلام من أمر الشراء PO-{poID}"
                    });
            }

            // تحديث حالة أمر الشراء
            var poStatuses = _lookupDAL.GetAllPOStatuses();
            bool allReceived = details.All(d =>
                received.Any(r => r.PartID == d.PartID && r.ReceivedQty >= d.Quantity));

            var newStatus = allReceived
                ? poStatuses.First(s => s.StatusName == "مستلم بالكامل")
                : poStatuses.First(s => s.StatusName == "مستلم جزئياً");

            _poDal.UpdateStatus(poID, newStatus.StatusID);

            return OperationResult.Ok("تم تسجيل الاستلام وتحديث المخزون بنجاح.");
        }

        /// <summary>
        /// تسجيل دفعة لمورد على أمر شراء
        /// </summary>
        public OperationResult PaySupplier(int poID, decimal amount, int paymentMethodID, string notes = null)
        {
            if (amount <= 0)
                return OperationResult.Fail("المبلغ يجب أن يكون أكبر من صفر.");

            var po = _poDal.GetByID(poID);
            if (po == null) return OperationResult.Fail("أمر الشراء غير موجود.");

            if (amount > po.Remaining)
                return OperationResult.Fail($"المبلغ أكبر من المتبقي ({po.Remaining:N2} جنيه).");

            // تحديث المدفوع في أمر الشراء
            _poDal.UpdatePayment(poID, amount);

            // تحديث رصيد المورد
            var supplier = _supplierDAL.GetByID(po.SupplierID);
            if (supplier != null)
                _supplierDAL.UpdateBalance(po.SupplierID,
                    Math.Max(0, supplier.SupplierBalance - amount));

            // تسجيل في الخزنة
            var txTypes = _lookupDAL.GetAllTransactionTypes();
            var outType = txTypes.First(t => t.TypeName == "صادر");
            decimal bal = _treasuryDAL.GetCurrentBalance();

            _treasuryDAL.Add(new TreasuryLog
            {
                TransactionTypeID = outType.TransactionTypeID,
                PaymentMethodID = paymentMethodID,
                Amount = amount,
                POID = poID,
                ActionDate = DateTime.Now,
                BalanceAfter = bal - amount,
                Notes = notes ?? $"دفع لمورد على أمر الشراء PO-{poID}"
            });

            return OperationResult.Ok("تم تسجيل الدفعة بنجاح.");
        }
    }
}
