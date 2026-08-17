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
        private readonly clsAuditDAL _auditDAL = new clsAuditDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        public OperationResult<List<SalesInvoice>> GetAll(
                DateTime? from = null, DateTime? to = null,
                int? customerID = null, int? employeeID = null, int? statusID = null)
            => OperationResult<List<SalesInvoice>>.Ok(
                   _invoiceDAL.GetAll(from, to, customerID, employeeID, statusID)
                );

        public OperationResult<SalesInvoice> GetByID(int invoiceID) { 
            var inv = _invoiceDAL.GetByID(invoiceID);
            if (inv == null) return OperationResult<SalesInvoice>.Fail("الفاتورة غير موجودة");
            inv.Details = _invoiceDAL.GetDetails(invoiceID);
            return OperationResult<SalesInvoice>.Ok(inv);
        }

        public OperationResult<List<InvoiceDetail>> GetDetails(int invoiceID)
            => OperationResult<List<InvoiceDetail>>.Ok(_invoiceDAL.GetDetails(invoiceID));

        public OperationResult CreateInvoice(SalesInvoice invoice, int paymentMethod)
        {
            // --- 1. التحقق من صلاحية الجلسة والبيانات الأساسية ---

            // التأكد أن المستخدم مسجل دخول قبل البدء
            if (!clsAppSession.IsLoggedIn)
                return OperationResult.Fail("يجب تسجيل الدخول أولا");

            // التأكد أن الفاتورة تحتوي على أصناف (مستحيل نبيع فاتورة فاضية)
            if (invoice.Details == null || invoice.Details.Count == 0)
                return OperationResult.Fail("الفاتورة لا تحتوى على أي قطع");

            // إذا لم يتم تحديد موظف، نقوم بتعيين الموظف الحالي الذي سجل الفاتورة
            if (invoice.EmployeeID <= 0)
                invoice.EmployeeID = clsAppSession.CurrentEmployee.EmployeeID;

            // --- 2. فحص المخزن (Inventory Check) ---

            foreach (var detail in invoice.Details)
            {
                // التأكد أن الكمية المطلوبة منطقية (أكبر من صفر)
                if (detail.Quantity <= 0)
                    return OperationResult.Fail("الكمية يجب أن تكون أكبر من صفر لكل قطعة");

                // التأكد من وجود القطعة في قاعدة البيانات
                var part = _inventoryDAL.GetByID(detail.PartID);
                if (part == null)
                    return OperationResult.Fail($"القطعة رقم {detail.PartID} غير موجودة");

                // التأكد أن الكمية الموجودة في المخزن تغطي الكمية المطلوبة
                if (part.CurrentStock < detail.Quantity)
                    return OperationResult.Fail($"الكمية المطلوبة من [{part.PartName}] هي ({detail.Quantity})، لكن المتاح في المخزن ({part.CurrentStock}) فقط.");
            }

            // --- 3. فحص الحد الائتماني للعميل (Credit Limit Check) ---

            if (invoice.CustomerID.HasValue)
            {
                var customer = _customerDAL.GetByID(invoice.CustomerID.Value);

                if (customer != null)
                {
                    // حساب المبلغ المتبقي (دين) من هذه الفاتورة
                    decimal remaining = invoice.TotalAmount - invoice.Discount - invoice.PaidAmount;

                    // إذا كان هناك متبقي، نتحقق هل سيتجاوز العميل "سقف الديون" المسموح له به؟
                    if (remaining > 0 && customer.CreditLimit > 0 &&
                        (customer.TotalBalance + remaining) > customer.CreditLimit)
                    {
                        return OperationResult.Fail(
                                    $"تجاوز العميل الحد الائتماني المسموح به. " +
                                    $"المتبقي من حده: {customer.CreditLimit - customer.TotalBalance:N2} جنيه، " +
                                    $"بينما المطلوب دفعه آجل في هذه الفاتورة: {remaining:N2} جنيه."
                                );
                    }
                }
            }

            // --- 4. الحسابات النهائية وحالة الدفع ---

            // إعادة حساب الإجمالي بناءً على التفاصيل (للأمان ومنع التلاعب من جهة العميل)
            invoice.TotalAmount = invoice.Details.Sum(d => d.Quantity * d.UnitPrice);

            // منع القيم السالبة في الخصم أو المبلغ المدفوع
            if (invoice.Discount < 0) invoice.Discount = 0;
            if (invoice.PaidAmount < 0) invoice.PaidAmount = 0;

            decimal finalAmount = invoice.TotalAmount - invoice.Discount;
            decimal remainingAfterPayment = finalAmount - invoice.PaidAmount;

            // تحديد حالة الفاتورة (مدفوعة بالكامل، جزئي، أو آجل) بناءً على المبلغ المدفوع
            var statuses = _lookupDAL.GetAllPaymentStatuses();
            if (remainingAfterPayment <= 0)
            {
                invoice.PaymentStatusID = statuses.First(s => s.StatusName == "مدفوع بالكامل").StatusID;
            }
            else if (invoice.PaidAmount > 0)
                invoice.PaymentStatusID = statuses.First(s => s.StatusName == "مدفوع جزئياً").StatusID;
            else
                invoice.PaymentStatusID = statuses.First(s => s.StatusName == "آجل").StatusID;

            invoice.DateTime = DateTime.Now;

            // --- 5. حفظ الفاتورة في قاعدة البيانات ---

            int invoiceID = _invoiceDAL.Add(invoice);

            // --- 6. تسجيل حركة المخزون (Inventory Audit) ---
            // تسجيل خروج الأصناف من المخزن لضمان تتبع "من أخذ ماذا ومتى"
            var movTypes = _lookupDAL.GetAllMovementTypes();
            var saleType = movTypes.FirstOrDefault(m => m.TypeName == "بيع");

            if (saleType != null)
            {
                foreach (var detail in invoice.Details)
                    _auditDAL.Add(new AuditLog
                    {
                        PartID = detail.PartID,
                        MovementTypeID = saleType.MovementTypeID,
                        QuantityChange = -detail.Quantity, // إشارة سالبة لأنها عملية بيع (نقص)
                        UserID = clsAppSession.CurrentUser.UserID,
                        ActionDate = DateTime.Now,
                        Remarks = $"فاتورة بيع رقم {invoiceID}"
                    });
            }

            // --- 7. تسجيل حركة الخزينة (Treasury Logging) ---
            // إذا دفع العميل مبلغاً (كاش أو غيره)، نقوم بإضافته لخزينة النظام
            if (invoice.PaidAmount > 0)
            {
                var txTypes = _lookupDAL.GetAllTransactionTypes();
                var inType = txTypes.First(t => t.TypeName == "وارد");

                decimal currentBalance = _treasuryDAL.GetCurrentBalance();
                _treasuryDAL.Add(new TreasuryLog
                {
                    TransactionTypeID = inType.TransactionTypeID,
                    PaymentMethodID = paymentMethod,
                    Amount = invoice.PaidAmount,
                    InvoiceID = invoiceID,
                    ActionDate = DateTime.Now,
                    BalanceAfter = currentBalance + invoice.PaidAmount, // تحديث الرصيد التراكمي للخزينة
                    Notes = $"تحصيل فاتورة بيع رقم {invoiceID}"
                });
            }

            // --- 8. تحديث مديونية العميل (Update Customer Balance) ---
            // إذا كان هناك مبلغ متبقي على العميل، نضيفه إلى حسابه (الدين التراكمي)
            if (invoice.CustomerID.HasValue && remainingAfterPayment > 0)
            {
                var customer = _customerDAL.GetByID(invoice.CustomerID.Value);
                if (customer != null)
                    _customerDAL.UpdateBalance(
                        invoice.CustomerID.Value,
                        customer.TotalBalance + remainingAfterPayment,
                        null
                    );
            }

            // النهاية السعيدة: إرجاع رقم الفاتورة الجديدة
            return OperationResult.Ok("تم حفظ الفاتورة بنجاح.", invoiceID);
        }
        
        public decimal CalcTotal (List<InvoiceDetail> details)
            => details?.Sum(d => d.Quantity * d.UnitPrice) ?? 0;

        public decimal CalcFinal(decimal total, decimal discount)
            => Math.Max(0,total - discount);

        public decimal CalcRemaining(decimal finalAmount, decimal paid)
            => Math.Max(0,finalAmount - paid);
    }
}
