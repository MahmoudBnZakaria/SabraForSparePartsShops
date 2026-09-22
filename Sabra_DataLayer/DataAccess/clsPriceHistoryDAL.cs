using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
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
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.PriceHistory_GetByPart))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new PriceHistory
                        {
                            PriceID = r.GetInt("Price_ID"),
                            PartID = r.GetInt("Part_ID"),
                            PartName = r.GetStr("Part_Name"),
                            Price = r.GetDec("Price"),
                            StartDate = r.GetDate("Start_Date"),
                            EndDate = r.GetDateOrNull("End_Date")
                        });
            }
            return list;
        }

        /// <summary>بتفتح سجل سعر جديد (استخدمها بعد CloseCurrent).</summary>
        public bool AddRecord(int partID, decimal price, DateTime startDate)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.PriceHistory_AddRecord))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                clsDBHelper.AddParam(cmd, "@Price", price);
                clsDBHelper.AddParam(cmd, "@StartDate", startDate);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>بتقفل السجل المفتوح الحالي بتاريخ نهاية.</summary>
        public bool CloseCurrent(int partID, DateTime endDate)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.PriceHistory_CloseCurrent))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                clsDBHelper.AddParam(cmd, "@EndDate", endDate);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>
        /// تغيير السعر الرسمي (بيقفل السجل القديم ويفتح جديد جوه SP واحدة).
        /// موجودة هنا للتسهيل بس، والتنفيذ في clsInventoryDAL.
        /// </summary>
        public bool UpdatePrice(int partID, decimal newPrice, int userID)
            => new clsInventoryDAL().UpdatePrice(partID, newPrice, userID);
    }

}