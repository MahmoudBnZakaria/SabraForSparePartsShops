using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var sql = @"
                SELECT ex.*, ec.Category_Name, e.Full_Name AS Paid_By_Name
                FROM EXPENSES ex
                JOIN EXPENSE_CATEGORIES ec ON ex.Category_ID = ec.Category_ID
                LEFT JOIN EMPLOYEES     e  ON ex.Paid_By     = e.Employee_ID
                WHERE 1=1";
            if (from.HasValue) sql += " AND ex.Expense_Date >= @From";
            if (to.HasValue) sql += " AND ex.Expense_Date <= @To";
            if (categoryID.HasValue) sql += " AND ex.Category_ID   = @CatID";
            sql += " ORDER BY ex.Expense_Date DESC";

            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (from.HasValue) cmd.Parameters.AddWithValue("@From", from.Value);
                if (to.HasValue) cmd.Parameters.AddWithValue("@To", to.Value);
                if (categoryID.HasValue) cmd.Parameters.AddWithValue("@CatID", categoryID.Value);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(MapExpense(r));
            }
            return list;
        }

        public int Add(Expense exp)
        {
            const string sql = @"
                INSERT INTO EXPENSES (Category_ID, Amount, Expense_Date, Paid_By, Notes)
                VALUES (@CatID, @Amount, @Date, @PaidBy, @Notes);
                SELECT SCOPE_IDENTITY();";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CatID", exp.CategoryID);
                cmd.Parameters.AddWithValue("@Amount", exp.Amount);
                cmd.Parameters.AddWithValue("@Date", exp.ExpenseDate);
                cmd.Parameters.AddWithValue("@PaidBy", (object)exp.PaidBy ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", (object)exp.Notes ?? DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Update(Expense exp)
        {
            const string sql = @"
                UPDATE EXPENSES SET
                    Category_ID  = @CatID,
                    Amount       = @Amount,
                    Expense_Date = @Date,
                    Paid_By      = @PaidBy,
                    Notes        = @Notes
                WHERE Expense_ID = @ID";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", exp.ExpenseID);
                cmd.Parameters.AddWithValue("@CatID", exp.CategoryID);
                cmd.Parameters.AddWithValue("@Amount", exp.Amount);
                cmd.Parameters.AddWithValue("@Date", exp.ExpenseDate);
                cmd.Parameters.AddWithValue("@PaidBy", (object)exp.PaidBy ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", (object)exp.Notes ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int expenseID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand("DELETE FROM EXPENSES WHERE Expense_ID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", expenseID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
