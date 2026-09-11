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
        private readonly clsPurchaseOrderDAL _poDal = new clsPurchaseOrderDAL();
        private readonly clsInventoryDAL _inventoryDAL = new clsInventoryDAL();
        private readonly clsSupplierDAL _supplierDAL = new clsSupplierDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();
        private readonly clsAuditDAL _auditDAL = new clsAuditDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        private const string OpenStatus = "مفتوح";
        private const string FullyReceivedStatus = "مستلم بالكامل";
        private const string PartiallyReceivedStatus = "مستلم جزئياً";
        private const string PurchaseMovement = "شراء";
        private const string OutTransactionType = "صادر";

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

            var supplier = _supplierDAL.GetByID(po.SupplierID);
            if (supplier == null)
                return OperationResult.Fail("المورد غير موجود.");

            if (po.Details == null || po.Details.Count == 0)
                return OperationResult.Fail("أمر الشراء لا يحتوي على قطع.");

            foreach (var detail in po.Details)
            {
                if (detail.Quantity <= 0)
                    return OperationResult.Fail("الكمية يجب أن تكون أكبر من صفر.");
                if (detail.UnitPrice < 0)
                    return OperationResult.Fail("سعر الوحدة لا يمكن أن يكون سالباً.");
            }

            var statuses = _lookupDAL.GetAllPOStatuses();
            var openStatus = statuses.FirstOrDefault(s => s.StatusName == OpenStatus);
            if (openStatus == null)
                return OperationResult.Fail($"حالة ({OpenStatus}) غير معرّفة في النظام.");

            po.EmployeeID = clsAppSession.CurrentEmployee.EmployeeID;
            po.OrderDate = po.OrderDate == default ? DateTime.Today : po.OrderDate;
            po.TotalAmount = po.Details.Sum(d => d.Quantity * d.UnitPrice);
            po.PaidAmount = 0;
            po.StatusID = openStatus.StatusID;

            int newID = _poDal.Add(po);
            return OperationResult.Ok("تم إنشاء أمر الشراء بنجاح.", newID);
        }

        /// <summary>تسجيل استلام بضاعة (كلياً أو جزئياً) وتحديث المخزون.</summary>
        public OperationResult ReceiveGoods(int poID, List<(int PartID, int ReceivedQty, decimal? NewUnitPrice)> received)
        {
            if (!clsAppSession.IsLoggedIn)
                return OperationResult.Fail("يجب تسجيل الدخول أولاً.");

            var po = _poDal.GetByID(poID);
            if (po == null) return OperationResult.Fail("أمر الشراء غير موجود.");

            var statuses = _lookupDAL.GetAllPOStatuses();
            var fullyReceived = statuses.FirstOrDefault(s => s.StatusName == FullyReceivedStatus);
            if (fullyReceived != null && po.StatusID == fullyReceived.StatusID)
                return OperationResult.Fail("تم استلام هذا الأمر بالكامل مسبقاً.");

            if (received == null || received.Count == 0)
                return OperationResult.Fail("لا توجد أصناف مستلمة.");

            var details = _poDal.GetDetails(poID);

            var movTypes = _lookupDAL.GetAllMovementTypes();
            var purchaseType = movTypes.FirstOrDefault(m => m.TypeName == PurchaseMovement);
            if (purchaseType == null)
                return OperationResult.Fail($"نوع الحركة ({PurchaseMovement}) غير معرّف في النظام.");

            foreach (var (partID, receivedQty, newUnitPrice) in received)
            {
                if (receivedQty <= 0) continue;

                var part = _inventoryDAL.GetByID(partID);
                if (part == null) continue;

                string remarks = $"استلام من أمر الشراء PO-{poID}";

                _inventoryDAL.AdjustStock(partID, receivedQty, purchaseType.MovementTypeID,
                    clsAppSession.CurrentUser.UserID, remarks);

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

                _auditDAL.Add(new AuditLog
                {
                    PartID = partID,
                    MovementTypeID = purchaseType.MovementTypeID,
                    QuantityChange = receivedQty,
                    UserID = clsAppSession.CurrentUser.UserID,
                    ActionDate = DateTime.Now,
                    Remarks = remarks
                });
            }

            bool allReceived = details.All(d =>
                received.Any(r => r.PartID == d.PartID && r.ReceivedQty >= d.Quantity));

            var newStatus = allReceived
                ? fullyReceived
                : statuses.FirstOrDefault(s => s.StatusName == PartiallyReceivedStatus);

            if (newStatus != null)
                _poDal.UpdateStatus(poID, newStatus.StatusID);

            return OperationResult.Ok("تم تسجيل الاستلام وتحديث المخزون بنجاح.");
        }

        /// <summary>تسجيل دفعة لمورد على أمر شراء.</summary>
        public OperationResult PaySupplier(int poID, decimal amount, int paymentMethodID, string notes = null)
        {
            if (amount <= 0)
                return OperationResult.Fail("المبلغ يجب أن يكون أكبر من صفر.");
            if (paymentMethodID <= 0)
                return OperationResult.Fail("يجب اختيار طريقة الدفع.");

            var po = _poDal.GetByID(poID);
            if (po == null) return OperationResult.Fail("أمر الشراء غير موجود.");

            if (amount > po.Remaining)
                return OperationResult.Fail($"المبلغ أكبر من المتبقي ({po.Remaining:N2} جنيه).");

            var supplier = _supplierDAL.GetByID(po.SupplierID);
            if (supplier == null)
                return OperationResult.Fail("المورد غير موجود.");

            var txTypes = _lookupDAL.GetAllTransactionTypes();
            var outType = txTypes.FirstOrDefault(t => t.TypeName == OutTransactionType);
            if (outType == null)
                return OperationResult.Fail($"نوع الحركة ({OutTransactionType}) غير معرّف في النظام.");

            _poDal.UpdatePayment(poID, amount);

            // دفع مبلغ للمورد يقلل مديونيتنا له، لذا الدلتا سالبة.
            _supplierDAL.AdjustBalance(po.SupplierID, -amount);

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