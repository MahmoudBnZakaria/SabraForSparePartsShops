using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsReturnsDAL
    {
        public List<Return> GetAll(DateTime? from = null, DateTime? to = null)
        {
            var list = new List<Return>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Returns_GetAll"))
            {
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new Return
                        {
                            ReturnID = (int)r["Return_ID"],
                            InvoiceID = (int)r["Invoice_ID"],
                            PartID = (int)r["Part_ID"],
                            PartName = r["Part_Name"].ToString(),
                            Quantity = (int)r["Quantity"],
                            Reason = r["Reason"] == DBNull.Value ? null : r["Reason"].ToString(),
                            StatusID = (int)r["Status_ID"],
                            StatusName = r["Status_Name"].ToString(),
                            ReturnDate = (DateTime)r["Return_Date"],
                            CreatedAt = (DateTime)r["Created_At"]
                        });
            }
            return list;
        }

        /// <summary>
        /// بترجع الـ Return_ID الجديد. لو restockOnAccept=true وStatusID اللي بعتها
        /// يطابق acceptedStatusID، الـ SP بترجع القطعة للمخزون وتسجل حركة من نوع
        /// restockMovementTypeID تلقائيًا.
        /// </summary>
        public int Add(
            Return ret,
            bool restockOnAccept = false,
            int? acceptedStatusID = null,
            int? restockMovementTypeID = null,
            int? userID = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Returns_Add"))
            {
                clsDBHelper.AddParam(cmd, "@InvoiceID", ret.InvoiceID);
                clsDBHelper.AddParam(cmd, "@PartID", ret.PartID);
                clsDBHelper.AddParam(cmd, "@Quantity", ret.Quantity);
                clsDBHelper.AddParam(cmd, "@Reason", ret.Reason);
                clsDBHelper.AddParam(cmd, "@StatusID", ret.StatusID);
                clsDBHelper.AddParam(cmd, "@ReturnDate", ret.ReturnDate);
                clsDBHelper.AddParam(cmd, "@RestockOnAccept", restockOnAccept);
                clsDBHelper.AddParam(cmd, "@AcceptedStatusID", acceptedStatusID);
                clsDBHelper.AddParam(cmd, "@RestockMovementTypeID", restockMovementTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewReturnID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }
    }
}