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
            var sql = @"
                SELECT p.*, e.Full_Name FROM PAYROLL p
                JOIN EMPLOYEES e ON p.Employee_ID = e.Employee_ID WHERE 1=1";
            if (!string.IsNullOrWhiteSpace(monthYear)) sql += " AND p.Month_Year = @MonthYear";
            if (employeeID.HasValue) sql += " AND p.Employee_ID = @EmpID";
            sql += " ORDER BY p.Payment_Date DESC";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (!string.IsNullOrWhiteSpace(monthYear)) cmd.Parameters.AddWithValue("@MonthYear", monthYear);
                if (employeeID.HasValue) cmd.Parameters.AddWithValue("@EmpID", employeeID.Value);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(MapPayroll(r));
            }
            return list;
        }

        public bool MonthYearExists(int employeeID, string monthYear)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand("SELECT COUNT(1) FROM PAYROLL WHERE Employee_ID = @EmpID AND Month_Year = @MY", conn))
            {
                cmd.Parameters.AddWithValue("@EmpID", employeeID);
                cmd.Parameters.AddWithValue("@MY", monthYear);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }


        public int Add(Payroll payroll)
        {
            const string sql = @"
                INSERT INTO PAYROLL (Employee_ID, Amount_Paid, Deductions, Bonuses, Payment_Date, Month_Year, Notes)
                VALUES (@EmpID, @AmtPaid, @Deductions, @Bonuses, @PayDate, @MonthYear, @Notes);
                SELECT SCOPE_IDENTITY();";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@EmpID", payroll.EmployeeID);
                cmd.Parameters.AddWithValue("@AmtPaid", payroll.AmountPaid);
                cmd.Parameters.AddWithValue("@Deductions", payroll.Deductions);
                cmd.Parameters.AddWithValue("@Bonuses", payroll.Bonuses);
                cmd.Parameters.AddWithValue("@PayDate", payroll.PaymentDate);
                cmd.Parameters.AddWithValue("@MonthYear", payroll.MonthYear);
                cmd.Parameters.AddWithValue("@Notes", (object)payroll.Notes ?? DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}

