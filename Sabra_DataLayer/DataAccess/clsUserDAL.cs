using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsUserDAL
    {
        private User MapUser(SqlDataReader r) => new User
        {
            UserID = r.GetInt("User_ID"),
            EmployeeID = r.GetInt("Employee_ID"),
            EmployeeName = r.GetStr("Full_Name", "Employee_Name"),
            Username = r.GetStr("Username"),
            PasswordHash = r.GetStr("Password_Hash"),
            IsActive = r.GetBool("Is_Active"),
            CreatedAt = r.GetDate("Created_At"),
            Permissions = r.GetInt("Permissions")
        };

        public User GetByUsername(string username)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.User_GetByUsername))
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
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.User_GetByID))
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
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.User_GetByEmployeeID))
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
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.User_GetAll))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapUser(r));
            }
            return list;
        }

        /// <summary>بترجع الـ User_ID الجديد. الصلاحيات بتتبعت كـ Bitwise Int.</summary>
        public int Add(User user)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.User_Add))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", user.EmployeeID);
                clsDBHelper.AddParam(cmd, "@Username", user.Username);
                clsDBHelper.AddParam(cmd, "@PasswordHash", user.PasswordHash);
                clsDBHelper.AddParam(cmd, "@IsActive", user.IsActive);
                clsDBHelper.AddParam(cmd, "@Permissions", user.Permissions);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewUserID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetInt(outId);
            }
        }

        public bool UpdatePassword(int userID, string newHash)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.User_UpdatePassword))
            {
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@NewHash", newHash);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>تعديل صلاحيات المستخدم (Bitwise) — كانت ناقصة.</summary>
        public bool UpdatePermissions(int userID, int permissions)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.User_UpdatePermissions))
            {
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Permissions", permissions);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        public bool SetActive(int userID, bool isActive)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.User_SetActive))
            {
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@IsActive", isActive);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        public bool UsernameExists(string username, int? excludeUserID = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.User_UsernameExists))
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