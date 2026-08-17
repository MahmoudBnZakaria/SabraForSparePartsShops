using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sabra.DataLayer
{

    public class clsReturnsDAL
    {
        public List<Return> GetAll(DateTime? from = null, DateTime? to = null)
        {
            var list = new List<Return>();
            var sql = @"
                SELECT r.*, i.Part_Name, its.Status_Name
                FROM RETURNS r
                JOIN INVENTORY  i   ON r.Part_ID   = i.Part_ID
                JOIN ITEM_STATUS its ON r.Status_ID = its.Status_ID
                WHERE 1=1";
            if (from.HasValue) sql += " AND r.Return_Date >= @From";
            if (to.HasValue) sql += " AND r.Return_Date <= @To";
            sql += " ORDER BY r.Return_Date DESC";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (from.HasValue) cmd.Parameters.AddWithValue("@From", from.Value);
                if (to.HasValue) cmd.Parameters.AddWithValue("@To", to.Value);
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

        public int Add(Return ret)
        {
            const string sql = @"
                INSERT INTO RETURNS (Invoice_ID, Part_ID, Quantity, Reason, Status_ID, Return_Date)
                VALUES (@InvID, @PartID, @Qty, @Reason, @StatusID, @Date);
                SELECT SCOPE_IDENTITY();";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@InvID", ret.InvoiceID);
                cmd.Parameters.AddWithValue("@PartID", ret.PartID);
                cmd.Parameters.AddWithValue("@Qty", ret.Quantity);
                cmd.Parameters.AddWithValue("@Reason", (object)ret.Reason ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StatusID", ret.StatusID);
                cmd.Parameters.AddWithValue("@Date", ret.ReturnDate);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
