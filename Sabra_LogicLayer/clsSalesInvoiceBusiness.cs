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

    public class clsSalesInvoiceBusiness : clsBusinessBase
    {
        private readonly clsInvoiceDAL _invoiceDAL = new clsInvoiceDAL();
        private readonly clsInventoryDAL _inventoryDAL = new clsInventoryDAL();
        private readonly clsCustomerDAL _customerDAL = new clsCustomerDAL();

        public OperationResult<List<SalesInvoice>> GetAll(DateTime? from = null, DateTime? to = null,
                                                          int? customerID = null, int? employeeID = null,
                                                          int? statusID = null) => Execute(() =>
                                                          {
                                                              if (from.HasValue && to.HasValue && from.Value.Date > to.Value.Date)
                                                                  return OperationResult<List<SalesInvoice>>.Fail("تاريخ البداية بعد تاريخ النهاية.");

                                                              return OperationResult<List<SalesInvoice>>.Ok(
                                                                  _invoiceDAL.GetAll(from, to, customerID, employeeID, statusID));
                                                          });

        /// <summary>بترجع الفاتورة بتفاصيلها (الـ SP بترجع الاتنين مع بعض).</summary>
        public OperationResult<SalesInvoice> GetByID(int invoiceID) => Execute(() =>
        {
            var inv = _invoiceDAL.GetByID(invoiceID);
            return inv == null
                ? OperationResult<SalesInvoice>.Fail("الفاتورة غير موجودة.")
                : OperationResult<SalesInvoice>.Ok(inv);
        });

        public OperationResult<List<InvoiceDetail>> GetDetails(int invoiceID) => Execute(()
            => OperationResult<List<InvoiceDetail>>.Ok(_invoiceDAL.GetDetails(invoiceID)));

        /// <summary>
        /// إنشاء فاتورة بيع. كل حاجة بتحصل جوه Stored Procedure واحدة:
        /// الفاتورة + التفاصيل بتكلفتها + خصم المخزون + حركة المخزون +
        /// مديونية العميل + تحصيل الخزنة. الكود هنا بيتحقق بس ويجهز البيانات.
        /// </summary>
        public OperationResult CreateInvoice(SalesInvoice invoice, int paymentMethodID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Sales, "إصدار فواتير");
            if (guard != null) return guard;

            if (invoice == null) return OperationResult.Fail("بيانات الفاتورة غير صحيحة.");
            if (invoice.Details == null || invoice.Details.Count == 0)
                return OperationResult.Fail("الفاتورة لا تحتوي على أي قطع.");
            if (!clsLookupCache.PaymentMethodExists(paymentMethodID))
                return OperationResult.Fail("يجب اختيار طريقة دفع صحيحة.");

            // دمج الأسطر المكررة لنفس القطعة (الـ TVP مفتاحه Part_ID فبيرفض التكرار)
            invoice.Details = invoice.Details
                .Where(d => d != null)
                .GroupBy(d => d.PartID)
                .Select(g => new InvoiceDetail
                {
                    PartID = g.Key,
                    Quantity = g.Sum(x => x.Quantity),
                    UnitPrice = g.First().UnitPrice,
                    PartName = g.First().PartName
                })
                .ToList();

            foreach (var d in invoice.Details)
            {
                if (d.Quantity <= 0) return OperationResult.Fail("الكمية يجب أن تكون أكبر من صفر لكل قطعة.");
                if (d.UnitPrice < 0) return OperationResult.Fail("سعر البيع لا يمكن أن يكون سالباً.");

                var part = _inventoryDAL.GetByID(d.PartID);
                if (part == null) return OperationResult.Fail($"القطعة رقم {d.PartID} غير موجودة.");
                if (part.CurrentStock < d.Quantity)
                    return OperationResult.Fail(
                        $"الكمية المطلوبة من [{part.PartName}] هي ({d.Quantity}) والمتاح ({part.CurrentStock}) فقط.");

                if (string.IsNullOrWhiteSpace(d.PartName)) d.PartName = part.PartName;
            }

            if (invoice.EmployeeID <= 0) invoice.EmployeeID = clsAppSession.EmployeeID;
            if (invoice.Discount < 0) invoice.Discount = 0;
            if (invoice.PaidAmount < 0) invoice.PaidAmount = 0;

            decimal total = invoice.Details.Sum(d => d.Quantity * d.UnitPrice);
            decimal final = total - invoice.Discount;

            if (invoice.Discount > total) return OperationResult.Fail("قيمة الخصم أكبر من إجمالي الفاتورة.");
            if (invoice.PaidAmount > final) return OperationResult.Fail("المبلغ المدفوع أكبر من صافي الفاتورة.");

            decimal remaining = final - invoice.PaidAmount;

            if (remaining > 0 && !invoice.CustomerID.HasValue)
                return OperationResult.Fail("البيع الآجل لازم يكون على عميل مسجّل.");

            if (invoice.CustomerID.HasValue)
            {
                var customer = _customerDAL.GetByID(invoice.CustomerID.Value);
                if (customer == null) return OperationResult.Fail("العميل غير موجود.");

                if (remaining > 0 && customer.CreditLimit > 0 &&
                    (customer.TotalBalance + remaining) > customer.CreditLimit)
                {
                    return OperationResult.Fail(
                        $"العميل تجاوز الحد الائتماني. المتاح له: {(customer.CreditLimit - customer.TotalBalance):N2} جنيه، " +
                        $"والمطلوب آجلاً: {remaining:N2} جنيه.");
                }
            }

            invoice.TotalAmount = total;
            invoice.DateTime = invoice.DateTime == default ? DateTime.Now : invoice.DateTime;
            invoice.PaymentStatusID = ResolveStatusID(invoice.PaidAmount, remaining);

            int invoiceID = _invoiceDAL.Add(
                invoice,
                clsLookupCache.MovementTypeID(clsSystemNames.MovSale),
                clsAppSession.UserID,
                paymentMethodID,
                clsLookupCache.TransactionTypeID(clsSystemNames.TxInvoiceCollection));

            return OperationResult.Ok("تم حفظ الفاتورة بنجاح.", invoiceID);
        });

        /// <summary>تحصيل دفعة على فاتورة آجلة (بتحدّث الفاتورة + رصيد العميل + الخزنة).</summary>
        public OperationResult CollectPayment(int invoiceID, decimal amount, int paymentMethodID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Sales, "تحصيل الفواتير");
            if (guard != null) return guard;

            if (amount <= 0) return OperationResult.Fail("قيمة الدفعة يجب أن تكون أكبر من صفر.");
            if (!clsLookupCache.PaymentMethodExists(paymentMethodID))
                return OperationResult.Fail("يجب اختيار طريقة دفع صحيحة.");

            var invoice = _invoiceDAL.GetByID(invoiceID);
            if (invoice == null) return OperationResult.Fail("الفاتورة غير موجودة.");

            if (invoice.RemainingBalance <= 0)
                return OperationResult.Fail("الفاتورة دي مسددة بالكامل.");

            if (amount > invoice.RemainingBalance)
                return OperationResult.Fail($"المبلغ أكبر من المتبقي على الفاتورة ({invoice.RemainingBalance:N2} جنيه).");

            decimal newPaid = invoice.PaidAmount + amount;
            decimal newRemaining = invoice.FinalAmount - newPaid;

            bool ok = _invoiceDAL.UpdatePayment(
                invoiceID, amount,
                ResolveStatusID(newPaid, newRemaining),
                paymentMethodID,
                clsLookupCache.TransactionTypeID(clsSystemNames.TxInvoiceCollection),
                clsAppSession.UserID);

            return ok ? OperationResult.Ok($"تم تحصيل {amount:N2} جنيه.")
                      : OperationResult.Fail("لم يتم تسجيل الدفعة.");
        });

        public OperationResult<List<PaymentStatus>> GetPaymentStatuses() => Execute(()
            => OperationResult<List<PaymentStatus>>.Ok(clsLookupCache.PaymentStatuses));

        public decimal CalcTotal(List<InvoiceDetail> details)
            => details?.Sum(d => d.Quantity * d.UnitPrice) ?? 0;

        public decimal CalcFinal(decimal total, decimal discount)
            => Math.Max(0, total - discount);

        public decimal CalcRemaining(decimal finalAmount, decimal paid)
            => Math.Max(0, finalAmount - paid);

        private static int ResolveStatusID(decimal paid, decimal remaining)
        {
            if (remaining <= 0) return clsLookupCache.PaymentStatusID(clsSystemNames.PaidFull);
            return paid > 0
                ? clsLookupCache.PaymentStatusID(clsSystemNames.PaidPartial)
                : clsLookupCache.PaymentStatusID(clsSystemNames.PaidDeferred);
        }
    }
}
