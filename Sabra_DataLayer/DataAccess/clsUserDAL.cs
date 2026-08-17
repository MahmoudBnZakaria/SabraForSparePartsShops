using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.DataLayer
{
    public class clsUserDAL
    {

        private User MapUser(SqlDataReader r) => new User
        {
            UserID = (int)r["User_ID"],
            EmployeeID = (int)r["Employee_ID"],
            EmployeeName = r["Full_Name"].ToString(),
            Username = r["Username"].ToString(),
            PasswordHash = r["Password_Hash"].ToString(),
            IsActive = (bool)r["Is_Active"],
            CreatedAt = (DateTime)r["Created_At"]
        };
        const string sql = @"
                SELECT u.*, e.Full_Name
                FROM USERS u
                JOIN EMPLOYEES e ON u.Employee_ID = e.Employee_ID";

        public User GetByUsername(string username)
        {

            using (var conn = clsConnectionManager.GetConnection())
            {
                using (var cmd = new SqlCommand(sql + "Where u.Username = @Username And u.Is_Active = 1 ;", conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? MapUser(reader) : null;
                    }
                }
            }
        }

        public User GetByUserID(int userId)
        {
            using (var conn = clsConnectionManager.GetConnection())
            {
                using (var cmd = new SqlCommand(sql + " WHERE u.User_ID = @UserID AND u.Is_Active = 1;", conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? MapUser(reader) : null;
                    }
                }
            }
        }

        public User GetByEmployeeID(int employeeId)
        {
            using (var conn = clsConnectionManager.GetConnection())
            {
                using (var cmd = new SqlCommand(sql + " WHERE u.Employee_ID = @EmployeeID AND u.Is_Active = 1;", conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    { 
                        // الـ MapUser جاهزة وبتشتغل زي الفل مع الـ reader
                        return reader.Read() ? MapUser(reader) : null;
                    }
                }
            }
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();

            using (var conn = clsConnectionManager.GetConnection())
            {
                using (var cmd = new SqlCommand( sql + "Order by u.Username", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            list.Add(MapUser(reader));
                    }
                }
            }

            return list;
        }

        public int Add(User user)
        {
            using (var conn = clsConnectionManager.GetConnection())
            {

                using (var cmd = new SqlCommand(@"Insert Into Users(Employee_ID, Username, Password_Hash, Is_Active)
                                 VALUES(@EmpID, @Username, @Hash, @Active);
                SELECT SCOPE_IDENTITY(); ", conn))
                {
                    cmd.Parameters.AddWithValue("@EmpID", user.EmployeeID);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Hash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Active", user.IsActive);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool UpdatePassword(int userID, string newHash)
        {
            using (var conn = clsConnectionManager.GetConnection())
            {
                using (var cmd = new SqlCommand("Update Users set Password_Hash = @Hash where User_ID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@Hash", newHash);
                    cmd.Parameters.AddWithValue("@ID", userID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public bool SetActive(int userID, bool isActive) {
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand("Update Users SET Is_Active = @Active Where User_ID = @ID", conn)) {

                    cmd.Parameters.AddWithValue("@Active", isActive);
                    cmd.Parameters.AddWithValue("@ID", userID);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0 ;
                }
            }
        }

        public bool UsernameExists(string username, int? excludeUserID = null)
        {
            var sql = @"Select COUNT(1) from Users where Username = @Username";

            if (excludeUserID.HasValue)
            {
                sql += " And User_ID <> @ExID";
            }

            using (var conn = clsConnectionManager.GetConnection())
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    if (excludeUserID.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@ExID", excludeUserID.Value);
                    }

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return (result != null && Convert.ToInt32(result) > 0);
                }
            }
        }
    }
}