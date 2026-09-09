using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsPayrollDAL
    {
        private Payroll MapPayroll(SqlDataReader r) => new Payroll
        {
            PayrollID = (int)r["Payroll_ID"],
            EmployeeID = (int)r["Employee_ID"],
            EmployeeName = r["Full_Name"].ToString(),
            AmountPaid = (decimal)r["Amount_Paid"],
            Deductions = (decimal)r["Deductions"],
            Bonuses = (decimal)r["Bonuses"],
            PaymentDate = (DateTime)r["Payment_Date"],
            MonthYear = r["Month_Year"].ToString(),
            Notes = r["Notes"] == DBNull.Value ? null : r["Notes"].ToString(),
            CreatedAt = (DateTime)r["Created_At"]
        };

        public List<Payroll> GetAll(string monthYear = null, int? employeeID = null)
        {
            var list = new List<Payroll>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Payroll_GetAll"))
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
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Payroll_MonthYearExists"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                clsDBHelper.AddParam(cmd, "@MonthYear", monthYear);
                var outExists = clsDBHelper.AddOutputParam(cmd, "@Exists", SqlDbType.Bit);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetBool(outExists);
            }
        }

        public int Add(Payroll payroll)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Payroll_Add"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", payroll.EmployeeID);
                clsDBHelper.AddParam(cmd, "@AmountPaid", payroll.AmountPaid);
                clsDBHelper.AddParam(cmd, "@Deductions", payroll.Deductions);
                clsDBHelper.AddParam(cmd, "@Bonuses", payroll.Bonuses);
                clsDBHelper.AddParam(cmd, "@PaymentDate", payroll.PaymentDate);
                clsDBHelper.AddParam(cmd, "@MonthYear", payroll.MonthYear);
                clsDBHelper.AddParam(cmd, "@Notes", payroll.Notes);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewPayrollID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }

        public string FormatMonthYear(DateTime date)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand("SELECT dbo.fn_FormatMonthYear(@Date)", conn))
            {
                clsDBHelper.AddParam(cmd, "@Date", date.Date);
                conn.Open();
                return cmd.ExecuteScalar().ToString();
            }
        }
    }
}