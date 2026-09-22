using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsTreasuryLogDAL
    {
        private TreasuryLog MapLog(SqlDataReader r) => new TreasuryLog
        {
            TransactionID = r.GetInt("Transaction_ID", "Transation_ID"),
            TransactionTypeID = r.GetInt("Transaction_Type_ID"),
            TransactionType = r.GetStr("Type_Name", "Transaction_Type"),
            PaymentMethodID = r.GetInt("Payment_Method_ID"),
            PaymentMethod = r.GetStr("Method_Name", "Payment_Method"),
            Amount = r.GetDec("Amount"),
            InvoiceID = r.GetIntOrNull("Invoice_ID"),
            POID = r.GetIntOrNull("PO_ID"),
            ExpenseID = r.GetIntOrNull("Expense_ID"),
            PayrollID = r.GetIntOrNull("Payroll_ID"),
            AdvanceID = r.GetIntOrNull("Advance_ID"),
            EmployeeID = r.GetIntOrNull("Employee_ID"),
            ActionDate = r.GetDate("Action_Date"),
            BalanceAfter = r.GetDec("Balance_After"),
            Notes = r.GetStr("Notes"),
            ReversalOfTransactionID = r.GetIntOrNull("Reversal_Of_Transaction_ID"),
            CreatedBy = r.GetIntOrNull("Created_By"),
            CreatedByName = r.GetStr("Created_By_Name"),
            RelatedCustomer = r.GetStr("Related_Customer", "Customer_Name"),
            RelatedSupplier = r.GetStr("Related_Supplier", "Supplier_Name"),
            RelatedEmployee = r.GetStr("Related_Employee", "Full_Name"),
            TransactionSource = r.GetStr("Transaction_Source")
        };

        /// <summary>رصيد الخزنة الحالي من الـ Scalar Function.</summary>
        public decimal GetCurrentBalance()
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateTextCommand(conn, SP.Fn_TreasuryBalance))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? 0m : Convert.ToDecimal(result);
            }
        }

        public List<TreasuryLog> GetAll(DateTime? from = null, DateTime? to = null,
                                        int? typeID = null, int? methodID = null)
        {
            var list = new List<TreasuryLog>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Treasury_GetAll))
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

        /// <summary>
        /// حركة خزنة يدوية. مهم: log.Amount لازم تكون بالإشارة الصح
        /// (موجب = دخل / سالب = صرف) لأنها بتتبعت لـ @SignedAmount.
        /// بترجع رقم الحركة والرصيد بعدها.
        /// </summary>
        public (int NewTransactionID, decimal NewBalance) Add(TreasuryLog log)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Treasury_Add))
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
                clsDBHelper.AddParam(cmd, "@CreatedBy", log.CreatedBy);
                clsDBHelper.AddParam(cmd, "@Notes", log.Notes);
                clsDBHelper.AddParam(cmd, "@ReversalOfTransactionID", log.ReversalOfTransactionID);
                var outTranId = clsDBHelper.AddOutputParam(cmd, "@NewTransactionID", SqlDbType.Int);
                var outBalance = clsDBHelper.AddDecimalOutputParam(cmd, "@NewBalance", 18, 2);

                conn.Open();
                cmd.ExecuteNonQuery();
                return (clsDBHelper.GetInt(outTranId), clsDBHelper.GetDecimal(outBalance));
            }
        }
    }

}