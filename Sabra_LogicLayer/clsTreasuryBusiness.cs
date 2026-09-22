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


    public class clsTreasuryBusiness : clsBusinessBase
    {
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();
        private readonly clsReportsDAL _reportsDAL = new clsReportsDAL();

        public OperationResult<decimal> GetCurrentBalance() => Execute(()
            => OperationResult<decimal>.Ok(_treasuryDAL.GetCurrentBalance()));

        public OperationResult<List<TreasuryLog>> GetAll(DateTime? from = null, DateTime? to = null,
                                                         int? typeID = null, int? methodID = null) => Execute(() =>
                                                         {
                                                             if (from.HasValue && to.HasValue && from.Value.Date > to.Value.Date)
                                                                 return OperationResult<List<TreasuryLog>>.Fail("تاريخ البداية بعد تاريخ النهاية.");

                                                             return OperationResult<List<TreasuryLog>>.Ok(_treasuryDAL.GetAll(from, to, typeID, methodID));
                                                         });

        public OperationResult<List<PaymentMethod>> GetPaymentMethods() => Execute(()
            => OperationResult<List<PaymentMethod>>.Ok(clsLookupCache.PaymentMethods));

        public OperationResult<List<TransactionType>> GetTransactionTypes() => Execute(()
            => OperationResult<List<TransactionType>>.Ok(clsLookupCache.TransactionTypes));

        /// <summary>إيداع يدوي في الخزنة (وارد بدون مستند).</summary>
        public OperationResult ManualDeposit(decimal amount, int paymentMethodID, string notes) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Treasury, "الإيداع اليدوي");
            if (guard != null) return guard;

            if (amount <= 0) return OperationResult.Fail("المبلغ يجب أن يكون أكبر من صفر.");
            if (!clsLookupCache.PaymentMethodExists(paymentMethodID))
                return OperationResult.Fail("يجب اختيار طريقة دفع صحيحة.");
            if (string.IsNullOrWhiteSpace(notes)) return OperationResult.Fail("سبب الإيداع مطلوب.");

            var result = _treasuryDAL.Add(new TreasuryLog
            {
                TransactionTypeID = clsLookupCache.TransactionTypeID(clsSystemNames.TxManualDeposit),
                PaymentMethodID = paymentMethodID,
                Amount = amount,                 // موجب = وارد
                CreatedBy = clsAppSession.UserID,
                EmployeeID = clsAppSession.EmployeeID,
                Notes = notes.Trim()
            });

            return OperationResult.Ok($"تم إيداع {amount:N2} جنيه. الرصيد الحالي: {result.NewBalance:N2}.",
                                      result.NewTransactionID);
        });

        /// <summary>سحب يدوي من الخزنة (صادر بدون مستند).</summary>
        public OperationResult ManualWithdraw(decimal amount, int paymentMethodID, string notes) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Treasury, "السحب اليدوي");
            if (guard != null) return guard;

            if (amount <= 0) return OperationResult.Fail("المبلغ يجب أن يكون أكبر من صفر.");
            if (!clsLookupCache.PaymentMethodExists(paymentMethodID))
                return OperationResult.Fail("يجب اختيار طريقة دفع صحيحة.");
            if (string.IsNullOrWhiteSpace(notes)) return OperationResult.Fail("سبب السحب مطلوب.");

            decimal balance = _treasuryDAL.GetCurrentBalance();
            if (amount > balance)
                return OperationResult.Fail($"المبلغ أكبر من الرصيد الحالي ({balance:N2} جنيه).");

            var result = _treasuryDAL.Add(new TreasuryLog
            {
                TransactionTypeID = clsLookupCache.TransactionTypeID(clsSystemNames.TxManualWithdraw),
                PaymentMethodID = paymentMethodID,
                Amount = -amount,                // سالب = صادر
                CreatedBy = clsAppSession.UserID,
                EmployeeID = clsAppSession.EmployeeID,
                Notes = notes.Trim()
            });

            return OperationResult.Ok($"تم سحب {amount:N2} جنيه. الرصيد الحالي: {result.NewBalance:N2}.",
                                      result.NewTransactionID);
        });

        public OperationResult<TreasuryBalanceView> GetBalanceDetails() => Execute(() =>
        {
            var balance = _reportsDAL.GetCurrentTreasuryBalance();
            return balance == null
                ? OperationResult<TreasuryBalanceView>.Fail("لا توجد حركات في الخزنة بعد.")
                : OperationResult<TreasuryBalanceView>.Ok(balance);
        });

        public OperationResult<List<DailyCashFlowView>> GetCashFlow(DateTime? from = null, DateTime? to = null) => Execute(()
            => OperationResult<List<DailyCashFlowView>>.Ok(_reportsDAL.GetDailyCashFlow(from, to)));
    }

}
