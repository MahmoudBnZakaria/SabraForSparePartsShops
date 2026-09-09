using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer.DataAccess
{
    public class clsEmployeeDAL
    {
        private Employee MapEmployee(SqlDataReader r) => new Employee
        {
            EmployeeID = (int)r["Employee_ID"],
            PositionID = (int)r["Position_ID"],
            PositionName = r["Position_Name"].ToString(),
            FullName = r["Full_Name"].ToString(),
            BasicSalary = (decimal)r["Basic_Salary"],
            HireDate = (DateTime)r["Hire_Date"],
            PhoneNumber = r["Phone_Number"] == DBNull.Value ? null : r["Phone_Number"].ToString(),
            NationalID = r["National_ID"] == DBNull.Value ? null : r["National_ID"].ToString(),
            IsActive = (bool)r["Is_Active"],
            CreatedAt = (DateTime)r["Created_At"],
            UpdatedAt = (DateTime)r["Updated_At"]
        };

        public List<Employee> GetAll(bool activeOnly = false)
        {
            var list = new List<Employee>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Employee_GetAll"))
            {
                clsDBHelper.AddParam(cmd, "@ActiveOnly", activeOnly);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapEmployee(r));
            }
            return list;
        }

        public Employee GetByID(int employeeID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Employee_GetByID"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapEmployee(r) : null;
            }
        }

        public List<Employee> Search(string keyword)
        {
            var list = new List<Employee>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Employee_Search"))
            {
                clsDBHelper.AddParam(cmd, "@Keyword", keyword);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapEmployee(r));
            }
            return list;
        }

        public int Add(Employee emp)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Employee_Add"))
            {
                clsDBHelper.AddParam(cmd, "@PositionID", emp.PositionID);
                clsDBHelper.AddParam(cmd, "@FullName", emp.FullName);
                clsDBHelper.AddParam(cmd, "@BasicSalary", emp.BasicSalary);
                clsDBHelper.AddParam(cmd, "@HireDate", emp.HireDate);
                clsDBHelper.AddParam(cmd, "@PhoneNumber", emp.PhoneNumber);
                clsDBHelper.AddParam(cmd, "@NationalID", emp.NationalID);
                clsDBHelper.AddParam(cmd, "@IsActive", emp.IsActive);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewEmployeeID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }

        public bool Update(Employee emp)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Employee_Update"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", emp.EmployeeID);
                clsDBHelper.AddParam(cmd, "@PositionID", emp.PositionID);
                clsDBHelper.AddParam(cmd, "@FullName", emp.FullName);
                clsDBHelper.AddParam(cmd, "@BasicSalary", emp.BasicSalary);
                clsDBHelper.AddParam(cmd, "@HireDate", emp.HireDate);
                clsDBHelper.AddParam(cmd, "@PhoneNumber", emp.PhoneNumber);
                clsDBHelper.AddParam(cmd, "@NationalID", emp.NationalID);
                clsDBHelper.AddParam(cmd, "@IsActive", emp.IsActive);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Deactivate(int employeeID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Employee_Deactivate"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}