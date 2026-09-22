using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.DataLayer.DataAccess
{
    public class clsFinancialAuditDAL
    {
        private FinancialAuditLog MapLog(SqlDataReader r) => new FinancialAuditLog
        {
            LogID = r.GetInt("Log_ID", "Financial_Log_ID", "Audit_ID"),
            EntityType = r.GetStr("Entity_Type"),
            EntityID = r.GetInt("Entity_ID"),
            ActionType = r.GetStr("Action_Type"),
            UserID = r.GetInt("User_ID"),
            Username = r.GetStr("Username", "Full_Name"),
            Remarks = r.GetStr("Remarks"),
            ActionDate = r.GetDate("Action_Date", "Created_At")
        };

        public List<FinancialAuditLog> GetAll(string entityType = null, int? entityID = null,
                                              string actionType = null, int? userID = null,
                                              DateTime? from = null, DateTime? to = null)
        {
            var list = new List<FinancialAuditLog>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.FinancialAuditLog_GetAll))
            {
                clsDBHelper.AddParam(cmd, "@EntityType", entityType);
                clsDBHelper.AddParam(cmd, "@EntityID", entityID);
                clsDBHelper.AddParam(cmd, "@ActionType", actionType);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);

                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapLog(r));
            }
            return list;
        }

        public List<FinancialAuditLog> GetByEntity(string entityType, int entityID)
        {
            var list = new List<FinancialAuditLog>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.FinancialAuditLog_GetByEntity))
            {
                clsDBHelper.AddParam(cmd, "@EntityType", entityType);
                clsDBHelper.AddParam(cmd, "@EntityID", entityID);

                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapLog(r));
            }
            return list;
        }

        public int Add(FinancialAuditLog log)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.FinancialAuditLog_Add))
            {
                clsDBHelper.AddParam(cmd, "@EntityType", log.EntityType);
                clsDBHelper.AddParam(cmd, "@EntityID", log.EntityID);
                clsDBHelper.AddParam(cmd, "@ActionType", log.ActionType);
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
