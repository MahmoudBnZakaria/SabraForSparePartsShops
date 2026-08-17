
using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;

namespace Sabra.DataLayer
{
    public class clsPriceHistoryDAL
    {
        public List<PriceHistory> GetByPart(int partID) { 
            var list = new List<PriceHistory>();
            const string sql = @"
                        SELECT ph.* , i.Part_Name
                        From Price_History ph 
                        join Inventory i on ph.Part_ID = i.Part_ID
                        Where ph.Part_ID =@PartID
                        Order by ph.Start_Date DESC";
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(sql, conn)) {
                    cmd.Parameters.AddWithValue("@PartID",partID);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) {
                            list.Add(new PriceHistory { 
                                PriceID = (int)reader["Price_ID"],
                                PartID = (int)reader["Part_ID"],
                                PartName = reader["Part_Name"].ToString(),
                                Price = (decimal)reader["Price"],
                                StartDate = (DateTime)reader["Start_Date"],
                                EndDate  = reader["End_Date"] == DBNull.Value ? (DateTime?) null : (DateTime)reader["End_Date"]
                            });
                        }
                    }
                }
            }
            return list;
        }
        public bool AddPriceRecord(int partID, decimal price, DateTime startDate) {
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand("INSET INTO Price_History (Part_ID, Price, Start_Date) Value (@PartID, @Price, @StartDate)",conn)) {
                    cmd.Parameters.AddWithValue("@PartID", partID);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool CloseCurrentPrice(int partID, DateTime endDate) {

            using (var conn = clsConnectionManager.GetConnection()) {

                using (var cmd = new SqlCommand("UPDATE Price_History SET End_Date = @EndDate Where Part_ID = @PartID AND End_Date IS NULL",conn)) {
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    cmd.Parameters.AddWithValue("@PartID", partID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
