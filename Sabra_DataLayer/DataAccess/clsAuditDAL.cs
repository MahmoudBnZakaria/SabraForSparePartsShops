using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsAuditDAL
    {
        private AuditLog MapLog(SqlDataReader r) => new AuditLog
        {
            LogID = r.GetInt("Log_ID"),
            PartID = r.GetInt("Part_ID"),
            PartName = r.GetStr("Part_Name"),
            MovementTypeID = r.GetInt("Movement_Type_ID"),
            MovementType = r.GetStr("Movement_Type_Name", "Type_Name"),
            QuantityChange = r.GetInt("Quantity_Change"),
            UserID = r.GetInt("User_ID"),
            Username = r.GetStr("Username"),
            ActionDate = r.GetDate("Action_Date"),
            Remarks = r.GetStr("Remarks")
        };

        public List<AuditLog> GetAll(int? partID = null, int? movTypeID = null,
                                     DateTime? from = null, DateTime? to = null, int? userID = null)
        {
            var list = new List<AuditLog>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.AuditLog_GetAll))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                clsDBHelper.AddParam(cmd, "@MovTypeID", movTypeID);
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                clsDBHelper.AddParam(cmd, "@UserID", userID);

                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapLog(r));
            }
            return list;
        }

        /// <summary>بترجع الـ Log_ID الجديد.</summary>
        public int Add(AuditLog log)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.AuditLog_Add))
            {
                clsDBHelper.AddParam(cmd, "@PartID", log.PartID);
                clsDBHelper.AddParam(cmd, "@MovementTypeID", log.MovementTypeID);
                clsDBHelper.AddParam(cmd, "@QuantityChange", log.QuantityChange);
                clsDBHelper.AddParam(cmd, "@UserID", log.UserID);
                clsDBHelper.AddParam(cmd, "@Remarks", log.Remarks);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewLogID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetInt(outId);
            }
        }
    }

}