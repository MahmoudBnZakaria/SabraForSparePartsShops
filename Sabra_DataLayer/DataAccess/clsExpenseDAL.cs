using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsExpenseDAL
    {
        private Expense MapExpense(SqlDataReader r) => new Expense
        {
            ExpenseID = (int)r["Expense_ID"],
            CategoryID = (int)r["Category_ID"],
            CategoryName = r["Category_Name"].ToString(),
            Amount = (decimal)r["Amount"],
            ExpenseDate = (DateTime)r["Expense_Date"],
            PaidBy = r["Paid_By"] == DBNull.Value ? (int?)null : (int)r["Paid_By"],
            PaidByName = r["Paid_By_Name"] == DBNull.Value ? null : r["Paid_By_Name"].ToString(),
            Notes = r["Notes"] == DBNull.Value ? null : r["Notes"].ToString(),
            CreatedAt = (DateTime)r["Created_At"]
        };

        public List<Expense> GetAll(DateTime? from = null, DateTime? to = null, int? categoryID = null)
        {
            var list = new List<Expense>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Expense_GetAll"))
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

        /// <summary>بترجع الـ Expense_ID الجديد.</summary>
        public int Add(Expense exp)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Expense_Add"))
            {
                clsDBHelper.AddParam(cmd, "@CategoryID", exp.CategoryID);
                clsDBHelper.AddParam(cmd, "@Amount", exp.Amount);
                clsDBHelper.AddParam(cmd, "@ExpenseDate", exp.ExpenseDate);
                clsDBHelper.AddParam(cmd, "@PaidBy", exp.PaidBy);
                clsDBHelper.AddParam(cmd, "@Notes", exp.Notes);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewExpenseID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }

        public bool Update(Expense exp)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Expense_Update"))
            {
                clsDBHelper.AddParam(cmd, "@ExpenseID", exp.ExpenseID);
                clsDBHelper.AddParam(cmd, "@CategoryID", exp.CategoryID);
                clsDBHelper.AddParam(cmd, "@Amount", exp.Amount);
                clsDBHelper.AddParam(cmd, "@ExpenseDate", exp.ExpenseDate);
                clsDBHelper.AddParam(cmd, "@PaidBy", exp.PaidBy);
                clsDBHelper.AddParam(cmd, "@Notes", exp.Notes);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int expenseID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Expense_Delete"))
            {
                clsDBHelper.AddParam(cmd, "@ExpenseID", expenseID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}