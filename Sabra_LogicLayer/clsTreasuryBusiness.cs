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
    public class clsTreasuryBusiness
    {

        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        public OperationResult<decimal> GetCurrentBalance()
            => OperationResult<decimal>.Ok(_treasuryDAL.GetCurrentBalance());

        public OperationResult<List<TreasuryLog>> GetAll(
            DateTime? from = null, DateTime? to = null,
            int? typeID = null, int? methodID = null)
            => OperationResult<List<TreasuryLog>>.Ok(
                _treasuryDAL.GetAll(from, to, typeID, methodID));

        /// <summary>
        /// إيداع يدوي في الخزنة (وارد بدون مستند)
        /// </summary>
        public OperationResult ManualDeposit(decimal amount, int paymentMethodID, string notes)
        {
            if (amount <= 0)
                return OperationResult.Fail("المبلغ يجب أن يكون أكبر من صفر.");

            if (string.IsNullOrWhiteSpace(notes))
                return OperationResult.Fail("ملاحظات الإيداع مطلوبة.");

            var txTypes = _lookupDAL.GetAllTransactionTypes();
            var inType = txTypes.First(t => t.TypeName == "وارد");
            decimal bal = _treasuryDAL.GetCurrentBalance();

            _treasuryDAL.Add(new TreasuryLog
            {
                TransactionTypeID = inType.TransactionTypeID,
                PaymentMethodID = paymentMethodID,
                Amount = amount,
                ActionDate = DateTime.Now,
                BalanceAfter = bal + amount,
                Notes = notes
            });

            return OperationResult.Ok($"تم إيداع {amount:N2} جنيه بنجاح.");
        }

        /// <summary>
        /// سحب يدوي من الخزنة (صادر بدون مستند)
        /// </summary>
        public OperationResult ManualWithdraw(decimal amount, int paymentMethodID, string notes)
        {
            if (amount <= 0)
                return OperationResult.Fail("المبلغ يجب أن يكون أكبر من صفر.");

            if (string.IsNullOrWhiteSpace(notes))
                return OperationResult.Fail("ملاحظات السحب مطلوبة.");

            decimal bal = _treasuryDAL.GetCurrentBalance();
            if (amount > bal)
                return OperationResult.Fail($"المبلغ أكبر من الرصيد الحالي ({bal:N2} جنيه).");

            var txTypes = _lookupDAL.GetAllTransactionTypes();
            var outType = txTypes.First(t => t.TypeName == "صادر");

            _treasuryDAL.Add(new TreasuryLog
            {
                TransactionTypeID = outType.TransactionTypeID,
                PaymentMethodID = paymentMethodID,
                Amount = amount,
                ActionDate = DateTime.Now,
                BalanceAfter = bal - amount,
                Notes = notes
            });

            return OperationResult.Ok($"تم سحب {amount:N2} جنيه بنجاح.");
        }

        public OperationResult<List<PaymentMethod>> GetPaymentMethods()
            => OperationResult<List<PaymentMethod>>.Ok(_lookupDAL.GetAllPaymentMethods());

    }
}
