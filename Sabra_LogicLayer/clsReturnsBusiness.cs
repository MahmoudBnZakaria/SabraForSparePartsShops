using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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

    public class clsReturnsBusiness : clsBusinessBase
    {
        private readonly clsReturnsDAL _returnsDAL = new clsReturnsDAL();
        private readonly clsInvoiceDAL _invoiceDAL = new clsInvoiceDAL();
        private readonly clsCustomerDAL _customerDAL = new clsCustomerDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();

        public OperationResult<List<Return>> GetAll(DateTime? from = null, DateTime? to = null) => Execute(()
            => OperationResult<List<Return>>.Ok(_returnsDAL.GetAll(from, to)));

        public OperationResult<List<ItemStatus>> GetItemStatuses() => Execute(()
            => OperationResult<List<ItemStatus>>.Ok(clsLookupCache.ItemStatuses));

        /// <summary>
        /// تسجيل مرتجع. الـ SP بتتحقق من الكمية المباعة فعليًا وبترجّع القطعة للمخزون
        /// لو الحالة "سليمة ترجع للمخزون". بعدها بنسوّي أثر المرتجع ماليًا:
        ///   - لو الفاتورة عليها مديونية → بنقلل المديونية بقيمة المرتجع.
        ///   - لو العميل دفع كاش وطلب فلوسه → refundCash = true بتصرف من الخزنة.
        /// </summary>
        public OperationResult ProcessReturn(Return ret, bool refundCash = false, int? paymentMethodID = null) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Sales, "تسجيل المرتجعات");
            if (guard != null) return guard;

            if (ret == null) return OperationResult.Fail("بيانات المرتجع غير صحيحة.");
            if (ret.Quantity <= 0) return OperationResult.Fail("الكمية المرتجعة يجب أن تكون أكبر من صفر.");
            if (string.IsNullOrWhiteSpace(ret.Reason)) return OperationResult.Fail("سبب الإرجاع مطلوب.");
            if (ret.StatusID <= 0) return OperationResult.Fail("يجب تحديد حالة الصنف المرتجع.");

            var invoice = _invoiceDAL.GetByID(ret.InvoiceID);
            if (invoice == null) return OperationResult.Fail("الفاتورة الأصلية غير موجودة.");

            var original = invoice.Details.FirstOrDefault(d => d.PartID == ret.PartID);
            if (original == null) return OperationResult.Fail("القطعة دي مش موجودة في الفاتورة الأصلية.");

            if (ret.Quantity > original.Quantity)
                return OperationResult.Fail(
                    $"الكمية المرتجعة ({ret.Quantity}) أكبر من الكمية في الفاتورة ({original.Quantity}).");

            if (refundCash)
            {
                if (!paymentMethodID.HasValue || !clsLookupCache.PaymentMethodExists(paymentMethodID.Value))
                    return OperationResult.Fail("يجب اختيار طريقة دفع صحيحة لرد المبلغ.");
                if (invoice.PaidAmount <= 0)
                    return OperationResult.Fail("الفاتورة دي مادفعش فيها العميل حاجة كاش.");
            }

            int acceptedStatusID = clsLookupCache.ItemStatusID(clsSystemNames.ItemBackToStock);
            int restockMovementID = clsLookupCache.MovementTypeID(clsSystemNames.MovSaleReturn);

            ret.ReturnDate = ret.ReturnDate == default ? DateTime.Today : ret.ReturnDate;
            ret.Reason = ret.Reason.Trim();

            int returnID = _returnsDAL.Add(
                ret,
                clsAppSession.UserID,
                restockOnAccept: true,
                acceptedStatusID: acceptedStatusID,
                restockMovementTypeID: restockMovementID);

            decimal returnValue = Math.Round(ret.Quantity * original.UnitPrice, 2);
            string note = $"مرتجع رقم {returnID} على فاتورة {ret.InvoiceID}";

            // (1) تخفيض مديونية العميل بقيمة المرتجع (في حدود المديونية الموجودة)
            if (invoice.CustomerID.HasValue)
            {
                var customer = _customerDAL.GetByID(invoice.CustomerID.Value);
                if (customer != null && customer.TotalBalance > 0)
                {
                    decimal delta = -Math.Min(returnValue, customer.TotalBalance);
                    _customerDAL.AdjustBalance(invoice.CustomerID.Value, delta, clsAppSession.UserID,
                                               isPayment: false, enforceCreditLimit: false, reason: note);
                }
            }

            // (2) رد نقدي من الخزنة (اختياري)
            if (refundCash)
            {
                decimal refund = Math.Min(returnValue, invoice.PaidAmount);
                _treasuryDAL.Add(new TreasuryLog
                {
                    TransactionTypeID = clsLookupCache.TransactionTypeID(clsSystemNames.TxOut),
                    PaymentMethodID = paymentMethodID.Value,
                    Amount = -refund,                       // سالب = صرف من الخزنة
                    InvoiceID = ret.InvoiceID,
                    CreatedBy = clsAppSession.UserID,
                    Notes = "رد نقدي - " + note
                });

                return OperationResult.Ok($"تم تسجيل المرتجع ورد {refund:N2} جنيه للعميل.", returnID);
            }

            return OperationResult.Ok("تم تسجيل المرتجع بنجاح.", returnID);
        });
    }
}
