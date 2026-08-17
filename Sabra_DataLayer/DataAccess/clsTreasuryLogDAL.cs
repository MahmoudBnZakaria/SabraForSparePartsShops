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
    public class clsTreasuryLogDAL
    {

        private TreasuryLog MapLog(SqlDataReader r) => new TreasuryLog
        {
            TransactionID = (int)r["Transaction_ID"],
            TransactionTypeID = (int)r["Transaction_Type_ID"],
            TransactionType = r["Type_Name"].ToString(),
            PaymentMethodID = (int)r["Payment_Method_ID"],
            PaymentMethod = r["Method_Name"].ToString(),
            Amount = (decimal)r["Amount"],
            InvoiceID = r["Invoice_ID"] == DBNull.Value ? (int?)null : (int)r["Invoice_ID"],
            POID = r["PO_ID"] == DBNull.Value ? (int?)null : (int)r["PO_ID"],
            ExpenseID = r["Expense_ID"] == DBNull.Value ? (int?)null : (int)r["Expense_ID"],
            PayrollID = r["Payroll_ID"] == DBNull.Value ? (int?)null : (int)r["Payroll_ID"],
            AdvanceID = r["Advance_ID"] == DBNull.Value ? (int?)null : (int)r["Advance_ID"],
            EmployeeID = r["Employee_ID"] == DBNull.Value ? (int?)null : (int)r["Employee_ID"],
            ActionDate = (DateTime)r["Action_Date"],
            BalanceAfter = (decimal)r["Balance_After"],
            Notes = r["Notes"] == DBNull.Value ? null : r["Notes"].ToString()
        };

        public decimal GetCurrentBalance()
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand("SELECT TOP 1 Balance_After FROM TREASURY_LOG ORDER BY Action_Date DESC", conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? 0m : (decimal)result;
            }
        }

        public List<TreasuryLog> GetAll(DateTime? from = null, DateTime? to = null, int? typeID = null, int? methodID = null)
        {
            var list = new List<TreasuryLog>();
            var sql = @"
                SELECT tl.*, tt.Type_Name, pm.Method_Name
                FROM TREASURY_LOG tl
                JOIN TRANSACTION_TYPES tt ON tl.Transaction_Type_ID = tt.Transaction_Type_ID
                JOIN PAYMENT_METHODS   pm ON tl.Payment_Method_ID   = pm.Payment_Method_ID
                WHERE 1=1";
            if (from.HasValue) sql += " AND tl.Action_Date >= @From";
            if (to.HasValue) sql += " AND tl.Action_Date <= @To";
            if (typeID.HasValue) sql += " AND tl.Transaction_Type_ID = @TypeID";
            if (methodID.HasValue) sql += " AND tl.Payment_Method_ID   = @MethodID";
            sql += " ORDER BY tl.Action_Date DESC";


            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (from.HasValue) cmd.Parameters.AddWithValue("@From", from.Value);
                if (to.HasValue) cmd.Parameters.AddWithValue("@To", to.Value);
                if (typeID.HasValue) cmd.Parameters.AddWithValue("@TypeID", typeID.Value);
                if (methodID.HasValue) cmd.Parameters.AddWithValue("@MethodID", methodID.Value);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(MapLog(r));
            }
            return list;
        }


        public int Add(TreasuryLog log)
        {
            const string sql = @"
                INSERT INTO TREASURY_LOG
                    (Transaction_Type_ID, Payment_Method_ID, Amount,
                     Invoice_ID, PO_ID, Expense_ID, Payroll_ID, Advance_ID, Employee_ID,
                     Action_Date, Balance_After, Notes)
                VALUES
                    (@TypeID, @MethodID, @Amount,
                     @InvID, @POID, @ExpID, @PayrollID, @AdvID, @EmpID,
                     @Date, @BalAfter, @Notes);
                SELECT SCOPE_IDENTITY();";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TypeID", log.TransactionTypeID);
                cmd.Parameters.AddWithValue("@MethodID", log.PaymentMethodID);
                cmd.Parameters.AddWithValue("@Amount", log.Amount);
                cmd.Parameters.AddWithValue("@InvID", (object)log.InvoiceID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@POID", (object)log.POID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ExpID", (object)log.ExpenseID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PayrollID", (object)log.PayrollID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AdvID", (object)log.AdvanceID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EmpID", (object)log.EmployeeID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Date", log.ActionDate);
                cmd.Parameters.AddWithValue("@BalAfter", log.BalanceAfter);
                cmd.Parameters.AddWithValue("@Notes", (object)log.Notes ?? DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }

}

