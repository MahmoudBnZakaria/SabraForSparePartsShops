using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsAuditDAL
    {
        public List<AuditLog> GetAll(int? partID = null, int? movTypeID = null, DateTime? from = null, DateTime? to = null, int? userID = null)
        {
            var list = new List<AuditLog>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_AuditLog_GetAll"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                clsDBHelper.AddParam(cmd, "@MovTypeID", movTypeID);
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
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
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_AuditLog_Add"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", log.PartID);
                clsDBHelper.AddParam(cmd, "@MovementTypeID", log.MovementTypeID);
                clsDBHelper.AddParam(cmd, "@QuantityChange", log.QuantityChange);
                clsDBHelper.AddParam(cmd, "@UserID", log.UserID);
                clsDBHelper.AddParam(cmd, "@Remarks", log.Remarks);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewLogID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }
    }
}