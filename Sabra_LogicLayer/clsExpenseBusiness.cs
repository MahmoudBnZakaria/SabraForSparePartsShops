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
    public class clsExpenseBusiness
    {
        private readonly clsExpenseDAL _expDAL = new clsExpenseDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        private const string OutTransactionType = "صادر";

        public OperationResult<List<Expense>> GetAll(DateTime? from = null, DateTime? to = null, int? categoryID = null)
            => OperationResult<List<Expense>>.Ok(_expDAL.GetAll(from, to, categoryID));

        public OperationResult<List<ExpenseCategory>> GetCategories()
            => OperationResult<List<ExpenseCategory>>.Ok(_lookupDAL.GetAllExpenseCategories());

        public OperationResult Add(Expense exp, int paymentMethodID)
        {
            if (exp.CategoryID <= 0)
                return OperationResult.Fail("يجب اختيار تصنيف المصروف.");
            if (exp.Amount <= 0)
                return OperationResult.Fail("المبلغ يجب أن يكون أكبر من صفر.");
            if (paymentMethodID <= 0)
                return OperationResult.Fail("يجب اختيار طريقة الدفع.");

            var category = _lookupDAL.GetAllExpenseCategories().FirstOrDefault(c => c.CategoryID == exp.CategoryID);
            if (category == null)
                return OperationResult.Fail("تصنيف المصروف غير موجود.");

            if (exp.ExpenseDate == default) exp.ExpenseDate = DateTime.Today;

            int expID = _expDAL.Add(exp);

            var txTypes = _lookupDAL.GetAllTransactionTypes();
            var outType = txTypes.FirstOrDefault(t => t.TypeName == OutTransactionType);
            if (outType == null)
                return OperationResult.Fail($"نوع الحركة ({OutTransactionType}) غير معرّف في النظام. تم تسجيل المصروف بدون خصمه من الخزنة.");

            decimal bal = _treasuryDAL.GetCurrentBalance();
            _treasuryDAL.Add(new TreasuryLog
            {
                TransactionTypeID = outType.TransactionTypeID,
                PaymentMethodID = paymentMethodID,
                Amount = exp.Amount,
                ExpenseID = expID,
                ActionDate = DateTime.Now,
                BalanceAfter = bal - exp.Amount,
                Notes = exp.Notes ?? $"مصروف: {category.CategoryName}"
            });

            return OperationResult.Ok("تم تسجيل المصروف بنجاح.", expID);
        }

        public OperationResult Update(Expense exp)
        {
            if (exp.CategoryID <= 0)
                return OperationResult.Fail("يجب اختيار تصنيف المصروف.");
            if (exp.Amount <= 0)
                return OperationResult.Fail("المبلغ يجب أن يكون أكبر من صفر.");

            _expDAL.Update(exp);
            return OperationResult.Ok("تم تحديث المصروف.");
        }

        public OperationResult Delete(int expenseID)
        {
            _expDAL.Delete(expenseID);
            return OperationResult.Ok("تم حذف المصروف.");
        }

        public OperationResult AddCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return OperationResult.Fail("الاسم مطلوب.");
            _lookupDAL.AddExpenseCategory(name.Trim());
            return OperationResult.Ok("تمت إضافة التصنيف.");
        }
    }

}
