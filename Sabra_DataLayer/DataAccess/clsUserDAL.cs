using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

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
            CreatedAt = (DateTime)r["Created_At"],
            Permissions = r["Permissions"] != DBNull.Value ? (int)r["Permissions"] : 0
        };

        public User GetByUsername(string username)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_User_GetByUsername"))
            {
                clsDBHelper.AddParam(cmd, "@Username", username);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapUser(r) : null;
            }
        }

        public User GetByID(int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_User_GetByID"))
            {
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapUser(r) : null;
            }
        }

        public User GetByEmployeeID(int employeeID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_User_GetByEmployeeID"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapUser(r) : null;
            }
        }

        public List<User> GetAll()
        {
            var list = new List<User>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_User_GetAll"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapUser(r));
            }
            return list;
        }

        /// <summary>بترجع الـ User_ID الجديد.</summary>
        public int Add(User user)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_User_Add"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", user.EmployeeID);
                clsDBHelper.AddParam(cmd, "@Username", user.Username);
                clsDBHelper.AddParam(cmd, "@PasswordHash", user.PasswordHash);
                clsDBHelper.AddParam(cmd, "@IsActive", user.IsActive);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewUserID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }

        public bool UpdatePassword(int userID, string newHash)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_User_UpdatePassword"))
            {
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@NewHash", newHash);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool SetActive(int userID, bool isActive)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_User_SetActive"))
            {
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@IsActive", isActive);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UsernameExists(string username, int? excludeUserID = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_User_UsernameExists"))
            {
                clsDBHelper.AddParam(cmd, "@Username", username);
                clsDBHelper.AddParam(cmd, "@ExcludeUserID", excludeUserID);
                var outExists = clsDBHelper.AddOutputParam(cmd, "@Exists", SqlDbType.Bit);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetBool(outExists);
            }
        }
    }
}