using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsExpenseDAL
    {
        private Expense MapExpense(SqlDataReader r) => new Expense
        {
            ExpenseID = r.GetInt("Expense_ID"),
            CategoryID = r.GetInt("Category_ID"),
            CategoryName = r.GetStr("Category_Name"),
            Amount = r.GetDec("Amount"),
            ExpenseDate = r.GetDate("Expense_Date"),
            PaidBy = r.GetIntOrNull("Paid_By"),
            PaidByName = r.GetStr("Paid_By_Name", "Full_Name"),
            Notes = r.GetStr("Notes"),
            CreatedAt = r.GetDate("Created_At"),
            UpdatedAt = r.GetDate("Updated_At"),
            IsVoided = r.GetBool("Is_Voided"),
            VoidedAt = r.GetDateOrNull("Voided_At"),
            VoidedBy = r.GetIntOrNull("Voided_By"),
            VoidedByName = r.GetStr("Voided_By_Name"),
            VoidReason = r.GetStr("Void_Reason"),
            TreasuryID = r.GetIntOrNull("Treasury_ID")
        };

        public List<Expense> GetAll(DateTime? from = null, DateTime? to = null, int? categoryID = null)
        {
            var list = new List<Expense>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Expense_GetAll))
            {
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                clsDBHelper.AddParam(cmd, "@CategoryID", categoryID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapExpense(r));
            }
            return list;
        }

        public Expense GetByID(int expenseID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Expense_GetByID))
            {
                clsDBHelper.AddParam(cmd, "@ExpenseID", expenseID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapExpense(r) : null;
            }
        }

        /// <summary>
        /// بتضيف مصروف + بتسجله في الخزنة تلقائيًا، وبترجع الـ Expense_ID الجديد.
        /// لازم تبعت طريقة الدفع ونوع الحركة (ID بتاع "مصروف" في TRANSACTION_TYPES).
        /// </summary>
        public int Add(Expense exp, int paymentMethodID, int expenseTransactionTypeID, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Expense_Add))
            {
                clsDBHelper.AddParam(cmd, "@CategoryID", exp.CategoryID);
                clsDBHelper.AddParam(cmd, "@Amount", exp.Amount);
                clsDBHelper.AddParam(cmd, "@ExpenseDate", exp.ExpenseDate);
                clsDBHelper.AddParam(cmd, "@PaidBy", exp.PaidBy);
                clsDBHelper.AddParam(cmd, "@PaymentMethodID", paymentMethodID);
                clsDBHelper.AddParam(cmd, "@ExpenseTransactionTypeID", expenseTransactionTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Notes", exp.Notes);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewExpenseID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetInt(outId);
            }
        }

        /// <summary>
        /// تعديل بيانات المصروف. ملاحظة مهمة: الـ SP مش بتعدّل المبلغ (Amount)
        /// لأن المبلغ متسجل في الخزنة؛ لو عايز تغيّر المبلغ استخدم Void ثم Add.
        /// </summary>
        public bool Update(Expense exp, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Expense_Update))
            {
                clsDBHelper.AddParam(cmd, "@ExpenseID", exp.ExpenseID);
                clsDBHelper.AddParam(cmd, "@CategoryID", exp.CategoryID);
                clsDBHelper.AddParam(cmd, "@ExpenseDate", exp.ExpenseDate);
                clsDBHelper.AddParam(cmd, "@PaidBy", exp.PaidBy);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Notes", exp.Notes);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>حذف نهائي. اسم البارامتر في الـ SP هو @Expense_ID (مش @ExpenseID).</summary>
        public bool Delete(int expenseID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Expense_Delete))
            {
                clsDBHelper.AddParam(cmd, "@Expense_ID", expenseID);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>إلغاء المصروف (Soft) مع تسجيل السبب — الطريقة المفضلة بدل الحذف.</summary>
        public bool Void(int expenseID, int userID, string reason = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Expense_Void))
            {
                clsDBHelper.AddParam(cmd, "@ExpenseID", expenseID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Reason", reason);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>
        /// عكس المصروف في الخزنة (بيرجّع الفلوس). reversalTransactionTypeID =
        /// الـ ID بتاع "عكس مصروف" في TRANSACTION_TYPES.
        /// </summary>
        public bool Reverse(int expenseID, int reversalTransactionTypeID, int userID, string reason = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Expense_Reverse))
            {
                clsDBHelper.AddParam(cmd, "@ExpenseID", expenseID);
                clsDBHelper.AddParam(cmd, "@ReversalTransactionTypeID", reversalTransactionTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Reason", reason);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }
    }

}