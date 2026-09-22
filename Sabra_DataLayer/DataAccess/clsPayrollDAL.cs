using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsPayrollDAL
    {
        private Payroll MapPayroll(SqlDataReader r) => new Payroll
        {
            PayrollID = r.GetInt("Payroll_ID"),
            EmployeeID = r.GetInt("Employee_ID"),
            EmployeeName = r.GetStr("Full_Name", "Employee_Name"),
            AmountPaid = r.GetDec("Amount_Paid"),
            Deductions = r.GetDec("Deductions"),
            Bonuses = r.GetDec("Bonuses"),
            PaymentDate = r.GetDate("Payment_Date"),
            MonthYear = r.GetStr("Month_Year"),
            Notes = r.GetStr("Notes"),
            CreatedAt = r.GetDate("Created_At")
        };

        public List<Payroll> GetAll(string monthYear = null, int? employeeID = null)
        {
            var list = new List<Payroll>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Payroll_GetAll))
            {
                clsDBHelper.AddParam(cmd, "@MonthYear", monthYear);
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapPayroll(r));
            }
            return list;
        }

        public bool MonthYearExists(int employeeID, string monthYear)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Payroll_MonthYearExists))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                clsDBHelper.AddParam(cmd, "@MonthYear", monthYear);
                var outExists = clsDBHelper.AddOutputParam(cmd, "@Exists", SqlDbType.Bit);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetBool(outExists);
            }
        }

        /// <summary>
        /// صرف مرتب + تسجيله في الخزنة. payrollTransactionTypeID = الـ ID بتاع
        /// "صرف مرتبات" في TRANSACTION_TYPES. بترجع الـ Payroll_ID الجديد.
        /// </summary>
        public int Add(Payroll payroll, int paymentMethodID, int payrollTransactionTypeID, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Payroll_Add))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", payroll.EmployeeID);
                clsDBHelper.AddParam(cmd, "@AmountPaid", payroll.AmountPaid);
                clsDBHelper.AddParam(cmd, "@Deductions", payroll.Deductions);
                clsDBHelper.AddParam(cmd, "@Bonuses", payroll.Bonuses);
                clsDBHelper.AddParam(cmd, "@PaymentDate", payroll.PaymentDate);
                clsDBHelper.AddParam(cmd, "@MonthYear", payroll.MonthYear);
                clsDBHelper.AddParam(cmd, "@PaymentMethodID", paymentMethodID);
                clsDBHelper.AddParam(cmd, "@PayrollTransactionTypeID", payrollTransactionTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Notes", payroll.Notes);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewPayrollID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetInt(outId);
            }
        }

        /// <summary>بتستخدم الـ Scalar Function عشان صيغة الشهر تبقى زي اللي في الداتابيز.</summary>
        public string FormatMonthYear(DateTime date)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateTextCommand(conn, SP.Fn_FormatMonthYear))
            {
                clsDBHelper.AddParam(cmd, "@Date", date.Date);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? null : result.ToString();
            }
        }
    }

}