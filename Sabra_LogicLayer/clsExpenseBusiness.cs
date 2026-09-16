using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sabra.LogicLayer
{
    public class clsExpenseBusiness
    {
        private readonly clsExpenseDAL _expenseDAL;
        private readonly clsTreasuryLogDAL _treasuryDAL;
        private readonly clsLookupDAL _lookupDAL;

       private const string OutTransactionType = "صادر";

        public clsExpenseBusiness()
        {
            _expenseDAL = new clsExpenseDAL();
            _treasuryDAL = new clsTreasuryLogDAL();
            _lookupDAL = new clsLookupDAL();
        }


        // =========================================================
        // Get All Expenses
        // =========================================================

        public OperationResult<List<Expense>> GetAll(
            DateTime? from = null,
            DateTime? to = null,
            int? categoryID = null)
        {
            if (from.HasValue &&
                to.HasValue &&
                from.Value.Date > to.Value.Date)
            {
                return OperationResult<List<Expense>>
                    .Fail("تاريخ البداية لا يمكن أن يكون بعد تاريخ النهاية.");
            }

            var expenses = _expenseDAL.GetAll(
                from,
                to,
                categoryID);

            return OperationResult<List<Expense>>
                .Ok(expenses);
        }


        // =========================================================
        // Get Expense By ID
        // =========================================================

        public OperationResult<Expense> GetByID(
            int expenseID)
        {
            if (expenseID <= 0)
            {
                return OperationResult<Expense>
                    .Fail("رقم المصروف غير صحيح.");
            }

            // clsExpenseDAL الحالي لا يحتوي GetByID.
            // لذلك لا نحاول اختراع method غير موجودة.
            //
            // في حالة احتياج الشاشة لـ GetByID:
            // نضيفها لاحقاً في DAL + Stored Procedure.

            return OperationResult<Expense>
                .Fail("GetByID غير متوفر حالياً في clsExpenseDAL.");
        }


        // =========================================================
        // Get Categories
        // =========================================================

        public OperationResult<List<ExpenseCategory>>
            GetCategories()
        {
            var categories =
                _lookupDAL.GetAllExpenseCategories();

            return OperationResult<List<ExpenseCategory>>
                .Ok(categories);
        }


        // =========================================================
        // Get Payment Methods
        // =========================================================

        public OperationResult<List<PaymentMethod>>
            GetPaymentMethods()
        {
            var paymentMethods =
                _lookupDAL.GetAllPaymentMethods();

            return OperationResult<List<PaymentMethod>>
                .Ok(paymentMethods);
        }


        // =========================================================
        // Add Expense
        // =========================================================

        public OperationResult Add(
            Expense expense,
            int paymentMethodID)
        {
            // -----------------------------------------------------
            // Object validation
            // -----------------------------------------------------

            if (expense == null)
            {
                return OperationResult.Fail(
                    "بيانات المصروف غير صحيحة.");
            }


            // -----------------------------------------------------
            // Category validation
            // -----------------------------------------------------

            if (expense.CategoryID <= 0)
            {
                return OperationResult.Fail(
                    "يجب اختيار تصنيف المصروف.");
            }


            // -----------------------------------------------------
            // Amount validation
            // -----------------------------------------------------

            if (expense.Amount <= 0)
            {
                return OperationResult.Fail(
                    "المبلغ يجب أن يكون أكبر من صفر.");
            }


            // -----------------------------------------------------
            // Payment Method validation
            // -----------------------------------------------------

            if (paymentMethodID <= 0)
            {
                return OperationResult.Fail(
                    "يجب اختيار طريقة الدفع.");
            }


            // -----------------------------------------------------
            // Date validation
            // -----------------------------------------------------

            if (expense.ExpenseDate == default)
            {
                expense.ExpenseDate = DateTime.Today;
            }


            if (expense.ExpenseDate.Date > DateTime.Today)
            {
                return OperationResult.Fail(
                    "تاريخ المصروف لا يمكن أن يكون في المستقبل.");
            }


            // -----------------------------------------------------
            // Check Category exists
            // -----------------------------------------------------

            var category =
                _lookupDAL
                    .GetAllExpenseCategories()
                    .FirstOrDefault(
                        x => x.CategoryID ==
                             expense.CategoryID);

            if (category == null)
            {
                return OperationResult.Fail(
                    "تصنيف المصروف غير موجود.");
            }


            // -----------------------------------------------------
            // Check Payment Method exists
            // -----------------------------------------------------

            var paymentMethod =
                _lookupDAL
                    .GetAllPaymentMethods()
                    .FirstOrDefault(
                        x => x.PaymentMethodID ==
                             paymentMethodID);

            if (paymentMethod == null)
            {
                return OperationResult.Fail(
                    "طريقة الدفع غير موجودة.");
            }


            // -----------------------------------------------------
            // Find "صادر" transaction type
            // -----------------------------------------------------

            var transactionTypes =
                _lookupDAL
                    .GetAllTransactionTypes();

            var outType =
                transactionTypes.FirstOrDefault(
                    x => x.TypeName ==
                         OutTransactionType);

            if (outType == null)
            {
                return OperationResult.Fail(
                    $"نوع الحركة ({OutTransactionType}) غير معرف في النظام.");
            }


            // -----------------------------------------------------
            // Check Treasury Balance
            // -----------------------------------------------------

            decimal currentBalance =
                _treasuryDAL.GetCurrentBalance();

            if (currentBalance < expense.Amount)
            {
                return OperationResult.Fail(
                    "الرصيد الحالي في الخزنة لا يكفي لتسجيل المصروف.");
            }


            // -----------------------------------------------------
            // Add Expense
            // -----------------------------------------------------

            int expenseID =
                _expenseDAL.Add(expense);

            if (expenseID <= 0)
            {
                return OperationResult.Fail(
                    "فشل تسجيل المصروف.");
            }


            // -----------------------------------------------------
            // Add Treasury Log
            // -----------------------------------------------------

            decimal balanceAfter =
                currentBalance -
                expense.Amount;

            var treasuryLog =
                new TreasuryLog
                {
                    TransactionTypeID =
                        outType.TransactionTypeID,

                    PaymentMethodID =
                        paymentMethodID,

                    Amount =
                        expense.Amount,

                    ExpenseID =
                        expenseID,

                    ActionDate =
                        DateTime.Now,

                    BalanceAfter =
                        balanceAfter,

                    Notes =
                        string.IsNullOrWhiteSpace(expense.Notes)
                            ? $"مصروف: {category.CategoryName}"
                            : expense.Notes
                };


            _treasuryDAL.Add(treasuryLog);


            return OperationResult.Ok(
                "تم تسجيل المصروف بنجاح.",
                expenseID);
        }


        // =========================================================
        // Update Expense
        // =========================================================

        public OperationResult Update(
            Expense expense)
        {
            if (expense == null)
            {
                return OperationResult.Fail(
                    "بيانات المصروف غير صحيحة.");
            }


            if (expense.ExpenseID <= 0)
            {
                return OperationResult.Fail(
                    "رقم المصروف غير صحيح.");
            }


            if (expense.CategoryID <= 0)
            {
                return OperationResult.Fail(
                    "يجب اختيار تصنيف المصروف.");
            }


            if (expense.Amount <= 0)
            {
                return OperationResult.Fail(
                    "المبلغ يجب أن يكون أكبر من صفر.");
            }


            if (expense.ExpenseDate == default)
            {
                return OperationResult.Fail(
                    "تاريخ المصروف مطلوب.");
            }


            if (expense.ExpenseDate.Date > DateTime.Today)
            {
                return OperationResult.Fail(
                    "تاريخ المصروف لا يمكن أن يكون في المستقبل.");
            }


            // -----------------------------------------------------
            // Check Category
            // -----------------------------------------------------

            var category =
                _lookupDAL
                    .GetAllExpenseCategories()
                    .FirstOrDefault(
                        x => x.CategoryID ==
                             expense.CategoryID);

            if (category == null)
            {
                return OperationResult.Fail(
                    "تصنيف المصروف غير موجود.");
            }


            // -----------------------------------------------------
            // Update Expense
            // -----------------------------------------------------

            bool updated =
                _expenseDAL.Update(expense);

            if (!updated)
            {
                return OperationResult.Fail(
                    "لم يتم تحديث المصروف.");
            }


            /*
             * ملاحظة:
             *
             * clsExpenseDAL الحالي لا يعطينا:
             *
             * - الـ PaymentMethodID القديم
             * - الـ TreasuryLog المرتبط بالمصروف
             * - method لتعديل TreasuryLog
             *
             * لذلك لا نعدل الخزنة من هنا بشكل افتراضي.
             *
             * بمجرد إرسال clsTreasuryLogDAL نربط:
             *
             * Old Amount
             *      ↓
             * New Amount
             *      ↓
             * Treasury Balance
             *
             * بطريقة صحيحة.
             */


            return OperationResult.Ok(
                "تم تحديث المصروف بنجاح.");
        }


        // =========================================================
        // Delete Expense
        // =========================================================

        public OperationResult Delete(
            int expenseID)
        {
            if (expenseID <= 0)
            {
                return OperationResult.Fail(
                    "رقم المصروف غير صحيح.");
            }


            /*
             * لا يوجد GetByID في clsExpenseDAL الحالي،
             * لذلك لا نحاول قراءة المصروف قبل الحذف.
             *
             * كذلك لا يوجد في clsTreasuryLogDAL هنا
             * method واضحة لعكس حركة المصروف.
             *
             * لذلك عملية الحذف الحالية تعتمد على
             * Stored Procedure sp_Expense_Delete.
             *
             * إذا كانت الـ SP نفسها تحذف/تعالج TreasuryLog
             * المرتبط بالمصروف، فالأمر صحيح.
             */


            bool deleted =
                _expenseDAL.Delete(expenseID);

            if (!deleted)
            {
                return OperationResult.Fail(
                    "لم يتم حذف المصروف.");
            }


            return OperationResult.Ok(
                "تم حذف المصروف بنجاح.");
        }


        // =========================================================
        // Add Expense Category
        // =========================================================

        public OperationResult AddCategory(
            string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return OperationResult.Fail(
                    "اسم التصنيف مطلوب.");
            }


            name = name.Trim();


            var categories =
                _lookupDAL
                    .GetAllExpenseCategories();


            bool exists =
                categories.Any(
                    x => string.Equals(
                        x.CategoryName,
                        name,
                        StringComparison.OrdinalIgnoreCase));


            if (exists)
            {
                return OperationResult.Fail(
                    "هذا التصنيف موجود بالفعل.");
            }


            _lookupDAL.AddExpenseCategory(
                name);


            return OperationResult.Ok(
                "تمت إضافة التصنيف بنجاح.");
        }
    }

}
