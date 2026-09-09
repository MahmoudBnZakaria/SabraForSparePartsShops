using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsAdvanceDAL
    {
        private Advance MapAdvance(SqlDataReader r) => new Advance
        {
            AdvanceID = (int)r["Advance_ID"],
            EmployeeID = (int)r["Employee_ID"],
            EmployeeName = r["Full_Name"] == DBNull.Value ? null : r["Full_Name"].ToString(),
            Amount = (decimal)r["Amount"],
            AdvanceDate = (DateTime)r["Advance_Date"],
            StatusID = (int)r["Status_ID"],
            StatusName = r["Status_Name"] == DBNull.Value ? null : r["Status_Name"].ToString(),
            ApprovedBy = r["Approved_By"] == DBNull.Value ? (int?)null : (int)r["Approved_By"],
            CreatedAt = (DateTime)r["Created_At"]
        };

        public List<Advance> GetAll(int? statusID = null, int? employeeID = null)
        {
            var list = new List<Advance>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Advance_GetAll"))
            {
                clsDBHelper.AddParam(cmd, "@StatusID", statusID);
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapAdvance(r));
            }
            return list;
        }

        public int Add(Advance adv)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Advance_Add"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", adv.EmployeeID);
                clsDBHelper.AddParam(cmd, "@Amount", adv.Amount);
                clsDBHelper.AddParam(cmd, "@AdvanceDate", adv.AdvanceDate);
                clsDBHelper.AddParam(cmd, "@StatusID", adv.StatusID);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewAdvanceID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }

        public bool UpdateStatus(int advanceID, int newStatusID, int? approvedBy = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Advance_UpdateStatus"))
            {
                clsDBHelper.AddParam(cmd, "@AdvanceID", advanceID);
                clsDBHelper.AddParam(cmd, "@NewStatusID", newStatusID);
                clsDBHelper.AddParam(cmd, "@ApprovedBy", approvedBy);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}