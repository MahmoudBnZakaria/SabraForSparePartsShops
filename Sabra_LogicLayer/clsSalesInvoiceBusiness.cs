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
    public class clsSalesInvoiceBusiness
    {
        private readonly clsInvoiceDAL _invoiceDAL = new clsInvoiceDAL();
        private readonly clsInventoryDAL _inventoryDAL = new clsInventoryDAL();
        private readonly clsCustomerDAL _customerDAL = new clsCustomerDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        private const string SaleMovement = "بيع";
        private const string InTransactionType = "وارد";
        private const string FullyPaidStatus = "مدفوع بالكامل";
        private const string PartiallyPaidStatus = "مدفوع جزئياً";
        private const string DeferredStatus = "آجل";

        public OperationResult<List<SalesInvoice>> GetAll(
                DateTime? from = null, DateTime? to = null,
                int? customerID = null, int? employeeID = null, int? statusID = null)
            => OperationResult<List<SalesInvoice>>.Ok(
                   _invoiceDAL.GetAll(from, to, customerID, employeeID, statusID));

        public OperationResult<SalesInvoice> GetByID(int invoiceID)
        {
            var inv = _invoiceDAL.GetByID(invoiceID);
            if (inv == null) return OperationResult<SalesInvoice>.Fail("الفاتورة غير موجودة");
            inv.Details = _invoiceDAL.GetDetails(invoiceID);
            return OperationResult<SalesInvoice>.Ok(inv);
        }

        public OperationResult<List<InvoiceDetail>> GetDetails(int invoiceID)
            => OperationResult<List<InvoiceDetail>>.Ok(_invoiceDAL.GetDetails(invoiceID));

        public OperationResult CreateInvoice(SalesInvoice invoice, int paymentMethodID)
        {
            // --- 1. التحقق من صلاحية الجلسة والبيانات الأساسية ---
            if (!clsAppSession.IsLoggedIn)
                return OperationResult.Fail("يجب تسجيل الدخول أولاً");

            if (invoice.Details == null || invoice.Details.Count == 0)
                return OperationResult.Fail("الفاتورة لا تحتوي على أي قطع");

            if (invoice.EmployeeID <= 0)
                invoice.EmployeeID = clsAppSession.CurrentEmployee.EmployeeID;

            // --- 2. فحص المخزون ---
            foreach (var detail in invoice.Details)
            {
                if (detail.Quantity <= 0)
                    return OperationResult.Fail("الكمية يجب أن تكون أكبر من صفر لكل قطعة");

                var part = _inventoryDAL.GetByID(detail.PartID);
                if (part == null)
                    return OperationResult.Fail($"القطعة رقم {detail.PartID} غير موجودة");

                if (part.CurrentStock < detail.Quantity)
                    return OperationResult.Fail(
                        $"الكمية المطلوبة من [{part.PartName}] هي ({detail.Quantity})، لكن المتاح في المخزن ({part.CurrentStock}) فقط.");
            }

            // --- 3. فحص الحد الائتماني للعميل ---
            Customer customer = null;
            decimal remainingAfterPayment;

            if (invoice.CustomerID.HasValue)
            {
                customer = _customerDAL.GetByID(invoice.CustomerID.Value);
                if (customer == null)
                    return OperationResult.Fail("العميل غير موجود");
            }

            // --- 4. الحسابات النهائية وحالة الدفع ---
            invoice.TotalAmount = invoice.Details.Sum(d => d.Quantity * d.UnitPrice);

            if (invoice.Discount < 0) invoice.Discount = 0;
            if (invoice.PaidAmount < 0) invoice.PaidAmount = 0;

            decimal finalAmount = invoice.TotalAmount - invoice.Discount;
            remainingAfterPayment = Math.Max(0, finalAmount - invoice.PaidAmount);

            if (customer != null && remainingAfterPayment > 0 &&
                customer.CreditLimit > 0 &&
                (customer.TotalBalance + remainingAfterPayment) > customer.CreditLimit)
            {
                return OperationResult.Fail(
                    $"تجاوز العميل الحد الائتماني المسموح به. " +
                    $"المتبقي من حده: {customer.CreditLimit - customer.TotalBalance:N2} جنيه، " +
                    $"بينما المطلوب دفعه آجلاً في هذه الفاتورة: {remainingAfterPayment:N2} جنيه.");
            }

            var statuses = _lookupDAL.GetAllPaymentStatuses();
            var fullyPaidSt = statuses.FirstOrDefault(s => s.StatusName == FullyPaidStatus);
            var partiallyPaidSt = statuses.FirstOrDefault(s => s.StatusName == PartiallyPaidStatus);
            var deferredSt = statuses.FirstOrDefault(s => s.StatusName == DeferredStatus);

            if (fullyPaidSt == null || partiallyPaidSt == null || deferredSt == null)
                return OperationResult.Fail("حالات الدفع غير معرّفة بالكامل في النظام.");

            if (remainingAfterPayment <= 0)
                invoice.PaymentStatusID = fullyPaidSt.StatusID;
            else if (invoice.PaidAmount > 0)
                invoice.PaymentStatusID = partiallyPaidSt.StatusID;
            else
                invoice.PaymentStatusID = deferredSt.StatusID;

            invoice.DateTime = DateTime.Now;

            // --- 5. تحديد نوع حركة "بيع" (الإجراء المخزن يستخدمه لخصم المخزون وتسجيل الحركة تلقائياً) ---
            var movTypes = _lookupDAL.GetAllMovementTypes();
            var saleType = movTypes.FirstOrDefault(m => m.TypeName == SaleMovement);
            if (saleType == null)
                return OperationResult.Fail($"نوع الحركة ({SaleMovement}) غير معرّف في النظام.");

            // --- 6. حفظ الفاتورة (تتم داخل معاملة واحدة بالخادم: إضافة الفاتورة + التفاصيل
            //         + خصم المخزون + تسجيل حركة المخزون لكل صنف) ---
            int invoiceID = _invoiceDAL.Add(invoice, saleType.MovementTypeID, clsAppSession.CurrentUser.UserID);

            // --- 7. تسجيل حركة الخزينة إذا دفع العميل مبلغاً ---
            if (invoice.PaidAmount > 0)
            {
                var txTypes = _lookupDAL.GetAllTransactionTypes();
                var inType = txTypes.FirstOrDefault(t => t.TypeName == InTransactionType);
                if (inType == null)
                    return OperationResult.Ok(
                        $"تم حفظ الفاتورة بنجاح، لكن نوع الحركة ({InTransactionType}) غير معرّف فلم يتم تسجيل التحصيل بالخزنة.",
                        invoiceID);

                decimal currentBalance = _treasuryDAL.GetCurrentBalance();
                _treasuryDAL.Add(new TreasuryLog
                {
                    TransactionTypeID = inType.TransactionTypeID,
                    PaymentMethodID = paymentMethodID,
                    Amount = invoice.PaidAmount,
                    InvoiceID = invoiceID,
                    ActionDate = DateTime.Now,
                    BalanceAfter = currentBalance + invoice.PaidAmount,
                    Notes = $"تحصيل فاتورة بيع رقم {invoiceID}"
                });
            }

            // --- 8. تحديث مديونية العميل بمقدار المتبقي (delta وليس قيمة مطلقة) ---
            if (invoice.CustomerID.HasValue && remainingAfterPayment > 0)
                _customerDAL.AdjustBalance(invoice.CustomerID.Value, remainingAfterPayment, isPayment: false);

            return OperationResult.Ok("تم حفظ الفاتورة بنجاح.", invoiceID);
        }

        public decimal CalcTotal(List<InvoiceDetail> details)
            => details?.Sum(d => d.Quantity * d.UnitPrice) ?? 0;

        public decimal CalcFinal(decimal total, decimal discount)
            => Math.Max(0, total - discount);

        public decimal CalcRemaining(decimal finalAmount, decimal paid)
            => Math.Max(0, finalAmount - paid);
    }

}
