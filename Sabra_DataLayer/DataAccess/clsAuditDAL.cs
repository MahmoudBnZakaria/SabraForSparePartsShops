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
    public class clsAuditDAL
    {
        public List<AuditLog> GetAll(int? partID = null, int? movTypeID = null, DateTime? from = null, DateTime? to = null, int? userID = null)
        {
            var list = new List<AuditLog>();
            var sql = @"
                SELECT al.*, i.Part_Name, mt.Type_Name AS Movement_Type_Name, u.Username
                FROM AUDIT_LOG al
                JOIN INVENTORY      i  ON al.Part_ID          = i.Part_ID
                JOIN MOVEMENT_TYPES mt ON al.Movement_Type_ID = mt.Movement_Type_ID
                JOIN USERS          u  ON al.User_ID          = u.User_ID
                WHERE 1=1";
            if (partID.HasValue) sql += " AND al.Part_ID          = @PartID";
            if (movTypeID.HasValue) sql += " AND al.Movement_Type_ID = @MovTypeID";
            if (from.HasValue) sql += " AND al.Action_Date      >= @From";
            if (to.HasValue) sql += " AND al.Action_Date      <= @To";
            if (userID.HasValue) sql += " AND al.User_ID          = @UserID";
            sql += " ORDER BY al.Action_Date DESC";

            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (partID.HasValue) cmd.Parameters.AddWithValue("@PartID", partID.Value);
                if (movTypeID.HasValue) cmd.Parameters.AddWithValue("@MovTypeID", movTypeID.Value);
                if (from.HasValue) cmd.Parameters.AddWithValue("@From", from.Value);
                if (to.HasValue) cmd.Parameters.AddWithValue("@To", to.Value);
                if (userID.HasValue) cmd.Parameters.AddWithValue("@UserID", userID.Value);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new AuditLog
                        {
                            LogID = (int)r["Log_ID"],
                            PartID = (int)r["Part_ID"],
                            PartName = r["Part_Name"].ToString(),
                            MovementTypeID = (int)r["Movement_Type_ID"],
                            MovementType = r["Movement_Type_Name"].ToString(),
                            QuantityChange = (int)r["Quantity_Change"],
                            UserID = (int)r["User_ID"],
                            Username = r["Username"].ToString(),
                            ActionDate = (DateTime)r["Action_Date"],
                            Remarks = r["Remarks"] == DBNull.Value ? null : r["Remarks"].ToString()
                        });
            }
            return list;
        }


        public int Add(AuditLog log)
        {
            const string sql = @"
                INSERT INTO AUDIT_LOG (Part_ID, Movement_Type_ID, Quantity_Change, User_ID, Action_Date, Remarks)
                VALUES (@PartID, @MovTypeID, @QtyChange, @UserID, @Date, @Remarks);
                SELECT SCOPE_IDENTITY();";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PartID", log.PartID);
                cmd.Parameters.AddWithValue("@MovTypeID", log.MovementTypeID);
                cmd.Parameters.AddWithValue("@QtyChange", log.QuantityChange);
                cmd.Parameters.AddWithValue("@UserID", log.UserID);
                cmd.Parameters.AddWithValue("@Date", log.ActionDate);
                cmd.Parameters.AddWithValue("@Remarks", (object)log.Remarks ?? DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
