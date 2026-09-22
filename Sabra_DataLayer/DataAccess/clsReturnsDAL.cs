using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsReturnsDAL
    {
        private Return MapReturn(SqlDataReader r) => new Return
        {
            ReturnID = r.GetInt("Return_ID"),
            InvoiceID = r.GetInt("Invoice_ID"),
            PartID = r.GetInt("Part_ID"),
            PartName = r.GetStr("Part_Name"),
            Quantity = r.GetInt("Quantity"),
            Reason = r.GetStr("Reason"),
            StatusID = r.GetInt("Status_ID"),
            StatusName = r.GetStr("Status_Name"),
            ReturnDate = r.GetDate("Return_Date"),
            CreatedAt = r.GetDate("Created_At")
        };

        public List<Return> GetAll(DateTime? from = null, DateTime? to = null)
        {
            var list = new List<Return>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Returns_GetAll))
            {
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapReturn(r));
            }
            return list;
        }

        /// <summary>
        /// بترجع الـ Return_ID الجديد. لو restockOnAccept = true و StatusID
        /// يساوي acceptedStatusID، الـ SP بترجّع القطعة للمخزون وتسجل حركة
        /// من نوع restockMovementTypeID تلقائيًا. userID مطلوب (مش اختياري).
        /// </summary>
        public int Add(Return ret, int userID, bool restockOnAccept = false,
                       int? acceptedStatusID = null, int? restockMovementTypeID = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Returns_Add))
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
                return clsDBHelper.GetInt(outId);
            }
        }
    }

}