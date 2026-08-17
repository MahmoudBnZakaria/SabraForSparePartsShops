using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sabra.DataLayer.Models;

namespace Sabra.DataLayer.DataAccess
{
    public class clsEmployeeDAL
    {
        private Employee MapEmployee(SqlDataReader r) {

            return new Employee {
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
        }

        private const string _SelectSql = @"
                SELECT 
                    e.*, 
                    p.Position_Name 
                FROM Employees e
                INNER JOIN Positions p ON e.Position_ID = p.Position_ID";

        public List<Employee> GetAll(bool ActiveOnly = false) { 
            var list = new List<Employee>();
            var sql = _SelectSql + (ActiveOnly ? "Where e.Is_Active = 1 " : "") + "Order By e.Full_Name";
            
            using (var conn = clsConnectionManager.GetConnection()) {
              
                using (var cmd = new SqlCommand(sql, conn)) {
                   
                    conn.Open();
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            list.Add(MapEmployee(reader));
                        }
                    }
                }
            }
            return list;

        }

        public Employee GetByID(int ID) {
            using (var conn = clsConnectionManager.GetConnection()) {

                using (var cmd = new SqlCommand(_SelectSql + "where e.Employee_ID = @ID", conn)) {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader()) {
                        return reader.Read() ? MapEmployee(reader) : null;
                    }
                }
            }
        }

        public List<Employee> Search(string Keyword) {
            var list = new List<Employee>();

            var Query = _SelectSql +
                @"Where e.Is_Active = 1 and 
`                       ( e.Full_Name Like @kw or e.Phone_Number like @kw or e.National_ID like @kw) 
                        Order By e.Full_Name";

            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(Query, conn)) {
                    cmd.Parameters.AddWithValue("@kw", "%" + Keyword + "%");
                    conn.Open();
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            list.Add(MapEmployee(reader));
                        }
                    }
                }
            }

            return list;
        }

        public int Add(Employee emp) {
            const string sql = @"
                insert into Employees (Position_ID, Full_Name, Basic_Salary, Hire_Date, Phone_Number, National_ID, Is_Active)
                Values (@PosID, @Name, @Salary, @HireDate, @Phone, @NatID, @Active)
                Select SCOPE_IDENTITY();";

            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(sql, conn)) {
                    cmd.Parameters.AddWithValue("@PosID", emp.PositionID);
                    cmd.Parameters.AddWithValue("@Name",emp.FullName);
                    cmd.Parameters.AddWithValue("@Salary",emp.BasicSalary);
                    cmd.Parameters.AddWithValue("@HireDate",emp.HireDate);
                    cmd.Parameters.AddWithValue("@Phone",(object)emp.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NatID",(object)emp.NationalID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Active",emp.IsActive);

                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool Update(Employee emp) {
            const string sql = @"
                Update Employees Set 
                    Position_ID = @PosID,
                    Full_Name = @Name,
                    Basic_Salary = @Salary,
                    Hire_Date = @HireDate,
                    Phone_Number = @ Phone,
                    National_ID = @NatID,
                    Is_Active = @Active,
                    Updated_At = GETDATE()
                    Where Employee_ID = @ID
                    ";
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(sql,conn)) {
                    cmd.Parameters.AddWithValue("@PosID", emp.PositionID);
                    cmd.Parameters.AddWithValue("@Name", emp.FullName);
                    cmd.Parameters.AddWithValue("@Salary", emp.BasicSalary);
                    cmd.Parameters.AddWithValue("@HireDate", emp.HireDate);
                    cmd.Parameters.AddWithValue("@Phone", (object)emp.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NatID", (object)emp.NationalID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Active", emp.IsActive);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Deactivate(int id) {
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand("UPDATE Employees Set Is_Active = 0 Updated_At = GETDATE() Where Employee_ID = @ID",conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
