using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;

namespace Sabra.DataLayer
{
    public class clsPriceHistoryDAL
    {
        public List<PriceHistory> GetByPart(int partID)
        {
            var list = new List<PriceHistory>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_PriceHistory_GetByPart"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new PriceHistory
                        {
                            PriceID = (int)r["Price_ID"],
                            PartID = (int)r["Part_ID"],
                            PartName = r["Part_Name"].ToString(),
                            Price = (decimal)r["Price"],
                            StartDate = (DateTime)r["Start_Date"],
                            EndDate = r["End_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)r["End_Date"]
                        });
            }
            return list;
        }

        public bool UpdatePrice(int partID, decimal newPrice)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_UpdatePrice"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                clsDBHelper.AddParam(cmd, "@NewSellingPrice", newPrice);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}