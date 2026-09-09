using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

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
            using (var cmd = new SqlCommand("SELECT dbo.fn_Treasury_GetCurrentBalance()", conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? 0m : (decimal)result;
            }
        }

        public List<TreasuryLog> GetAll(DateTime? from = null, DateTime? to = null, int? typeID = null, int? methodID = null)
        {
            var list = new List<TreasuryLog>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Treasury_GetAll"))
            {
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                clsDBHelper.AddParam(cmd, "@TypeID", typeID);
                clsDBHelper.AddParam(cmd, "@MethodID", methodID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapLog(r));
            }
            return list;
        }

        public (int NewTransactionID, decimal NewBalance) Add(TreasuryLog log)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Treasury_Add"))
            {
                clsDBHelper.AddParam(cmd, "@TransactionTypeID", log.TransactionTypeID);
                clsDBHelper.AddParam(cmd, "@PaymentMethodID", log.PaymentMethodID);
                clsDBHelper.AddParam(cmd, "@SignedAmount", log.Amount);
                clsDBHelper.AddParam(cmd, "@InvoiceID", log.InvoiceID);
                clsDBHelper.AddParam(cmd, "@POID", log.POID);
                clsDBHelper.AddParam(cmd, "@ExpenseID", log.ExpenseID);
                clsDBHelper.AddParam(cmd, "@PayrollID", log.PayrollID);
                clsDBHelper.AddParam(cmd, "@AdvanceID", log.AdvanceID);
                clsDBHelper.AddParam(cmd, "@EmployeeID", log.EmployeeID);
                clsDBHelper.AddParam(cmd, "@Notes", log.Notes);
                var outTranId = clsDBHelper.AddOutputParam(cmd, "@NewTransactionID", SqlDbType.Int);
                var outBalance = clsDBHelper.AddDecimalOutputParam(cmd, "@NewBalance", 18, 2);

                conn.Open();
                cmd.ExecuteNonQuery();
                return (Convert.ToInt32(outTranId.Value), Convert.ToDecimal(outBalance.Value));
            }
        }
    }
}