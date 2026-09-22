using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sabra.LogicLayer
{

    public class clsExpenseBusiness : clsBusinessBase
    {
        private readonly clsExpenseDAL _expenseDAL = new clsExpenseDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();

        public OperationResult<List<Expense>> GetAll(DateTime? from = null, DateTime? to = null,
                                                     int? categoryID = null, bool includeVoided = true) => Execute(() =>
                                                     {
                                                         if (from.HasValue && to.HasValue && from.Value.Date > to.Value.Date)
                                                             return OperationResult<List<Expense>>.Fail("تاريخ البداية لا يمكن أن يكون بعد تاريخ النهاية.");

                                                         var list = _expenseDAL.GetAll(from, to, categoryID);
                                                         if (!includeVoided) list = list.Where(e => !e.IsVoided).ToList();

                                                         return OperationResult<List<Expense>>.Ok(list);
                                                     });

        public OperationResult<Expense> GetByID(int expenseID) => Execute(() =>
        {
            if (expenseID <= 0) return OperationResult<Expense>.Fail("رقم المصروف غير صحيح.");

            var expense = _expenseDAL.GetByID(expenseID);
            return expense == null
                ? OperationResult<Expense>.Fail("المصروف غير موجود.")
                : OperationResult<Expense>.Ok(expense);
        });

        public OperationResult<List<ExpenseCategory>> GetCategories() => Execute(()
            => OperationResult<List<ExpenseCategory>>.Ok(_lookupDAL.GetAllExpenseCategories()));

        public OperationResult<List<PaymentMethod>> GetPaymentMethods() => Execute(()
            => OperationResult<List<PaymentMethod>>.Ok(clsLookupCache.PaymentMethods));

        /// <summary>
        /// تسجيل مصروف. الـ SP بتخصم المبلغ من الخزنة وتربط المصروف بحركة الخزنة
        /// وتسجّل في التدقيق المالي — كله في Transaction واحدة.
        /// </summary>
        public OperationResult Add(Expense expense, int paymentMethodID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Treasury, "تسجيل المصروفات");
            if (guard != null) return guard;

            if (expense == null) return OperationResult.Fail("بيانات المصروف غير صحيحة.");
            if (expense.CategoryID <= 0) return OperationResult.Fail("يجب اختيار تصنيف المصروف.");
            if (expense.Amount <= 0) return OperationResult.Fail("المبلغ يجب أن يكون أكبر من صفر.");
            if (!clsLookupCache.PaymentMethodExists(paymentMethodID))
                return OperationResult.Fail("يجب اختيار طريقة دفع صحيحة.");

            if (expense.ExpenseDate == default) expense.ExpenseDate = DateTime.Today;
            if (expense.ExpenseDate.Date > DateTime.Today)
                return OperationResult.Fail("تاريخ المصروف لا يمكن أن يكون في المستقبل.");

            if (!_lookupDAL.GetAllExpenseCategories().Any(c => c.CategoryID == expense.CategoryID))
                return OperationResult.Fail("تصنيف المصروف غير موجود.");

            decimal balance = _treasuryDAL.GetCurrentBalance();
            if (expense.Amount > balance)
                return OperationResult.Fail($"رصيد الخزنة ({balance:N2} جنيه) لا يكفي لتسجيل المصروف.");

            expense.Notes = string.IsNullOrWhiteSpace(expense.Notes) ? null : expense.Notes.Trim();

            int expenseID = _expenseDAL.Add(
                expense,
                paymentMethodID,
                clsLookupCache.TransactionTypeID(clsSystemNames.TxExpense),
                clsAppSession.UserID);

            return OperationResult.Ok("تم تسجيل المصروف بنجاح.", expenseID);
        });

        /// <summary>
        /// تعديل بيانات المصروف الوصفية فقط (التصنيف / التاريخ / مين دفع / الملاحظات).
        /// المبلغ مش بيتعدّل لأنه اترحّل في الخزنة — لو غلط استخدم Void وسجّله من جديد.
        /// </summary>
        public OperationResult Update(Expense expense) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Treasury, "تعديل المصروفات");
            if (guard != null) return guard;

            if (expense == null) return OperationResult.Fail("بيانات المصروف غير صحيحة.");
            if (expense.ExpenseID <= 0) return OperationResult.Fail("رقم المصروف غير صحيح.");
            if (expense.CategoryID <= 0) return OperationResult.Fail("يجب اختيار تصنيف المصروف.");
            if (expense.ExpenseDate == default) return OperationResult.Fail("تاريخ المصروف مطلوب.");
            if (expense.ExpenseDate.Date > DateTime.Today)
                return OperationResult.Fail("تاريخ المصروف لا يمكن أن يكون في المستقبل.");

            var existing = _expenseDAL.GetByID(expense.ExpenseID);
            if (existing == null) return OperationResult.Fail("المصروف غير موجود.");
            if (existing.IsVoided) return OperationResult.Fail("المصروف ده ملغي، مش ممكن تعديله.");

            if (expense.Amount > 0 && expense.Amount != existing.Amount)
                return OperationResult.Fail(
                    "مش ممكن تغيير مبلغ مصروف اترحّل في الخزنة. ألغِ المصروف (Void) وسجّله من جديد بالمبلغ الصحيح.");

            expense.Notes = string.IsNullOrWhiteSpace(expense.Notes) ? null : expense.Notes.Trim();

            bool ok = _expenseDAL.Update(expense, clsAppSession.UserID);
            return ok ? OperationResult.Ok("تم تحديث بيانات المصروف.")
                      : OperationResult.Fail("لم يتم تحديث المصروف.");
        });

        /// <summary>إلغاء مصروف (الطريقة الصحيحة): بيرجّع المبلغ للخزنة بحركة عكسية.</summary>
        public OperationResult Void(int expenseID, string reason) => Execute(() =>
        {
            var guard = RequirePermission(Permission.VoidAndReverse, "إلغاء المصروفات");
            if (guard != null) return guard;

            if (expenseID <= 0) return OperationResult.Fail("رقم المصروف غير صحيح.");
            if (string.IsNullOrWhiteSpace(reason)) return OperationResult.Fail("سبب الإلغاء مطلوب.");

            bool ok = _expenseDAL.Void(expenseID, clsAppSession.UserID, reason.Trim());
            return ok ? OperationResult.Ok("تم إلغاء المصروف وإرجاع المبلغ للخزنة.")
                      : OperationResult.Fail("لم يتم إلغاء المصروف.");
        });

        /// <summary>عكس مصروف (تسجيل حركة وارد مقابلة من غير تعليم المصروف كملغي).</summary>
        public OperationResult Reverse(int expenseID, string reason) => Execute(() =>
        {
            var guard = RequirePermission(Permission.VoidAndReverse, "عكس المصروفات");
            if (guard != null) return guard;

            if (expenseID <= 0) return OperationResult.Fail("رقم المصروف غير صحيح.");
            if (string.IsNullOrWhiteSpace(reason)) return OperationResult.Fail("سبب العكس مطلوب.");

            bool ok = _expenseDAL.Reverse(expenseID,
                                          clsLookupCache.TransactionTypeID(clsSystemNames.TxExpenseReversal),
                                          clsAppSession.UserID, reason.Trim());

            return ok ? OperationResult.Ok("تم عكس المصروف في الخزنة.")
                      : OperationResult.Fail("لم يتم عكس المصروف.");
        });

        /// <summary>
        /// حذف نهائي للمصروف مع حركته في الخزنة. مش مفضّل إطلاقًا لأنه بيكسر تسلسل
        /// Balance_After في الحركات اللي بعده — استخدم Void بدلًا منه.
        /// </summary>
        public OperationResult Delete(int expenseID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.VoidAndReverse, "حذف المصروفات");
            if (guard != null) return guard;

            if (expenseID <= 0) return OperationResult.Fail("رقم المصروف غير صحيح.");

            var existing = _expenseDAL.GetByID(expenseID);
            if (existing == null) return OperationResult.Fail("المصروف غير موجود.");

            bool ok = _expenseDAL.Delete(expenseID);
            return ok ? OperationResult.Ok("تم حذف المصروف نهائيًا.")
                      : OperationResult.Fail("لم يتم حذف المصروف.");
        });

        public OperationResult AddCategory(string name) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(name)) return OperationResult.Fail("اسم التصنيف مطلوب.");
            name = name.Trim();

            if (_lookupDAL.GetAllExpenseCategories().Any(c => string.Equals(c.CategoryName, name, StringComparison.OrdinalIgnoreCase)))
                return OperationResult.Fail("التصنيف ده موجود بالفعل.");

            _lookupDAL.AddExpenseCategory(name);
            return OperationResult.Ok("تمت إضافة التصنيف بنجاح.");
        });
    }

}
