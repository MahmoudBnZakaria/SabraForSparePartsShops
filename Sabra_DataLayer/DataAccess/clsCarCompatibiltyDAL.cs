
using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;

namespace Sabra.DataLayer
{
    public class clsCarCompatibiltyDAL
    {
        public List<CarCompatibility> GetByPart(int partID) { 
            var list = new List<CarCompatibility>();
            const string sql = @"
                SELECT cc.*, i.Part_Name FROM CAR_COMPATIBILITY cc
                JOIN INVENTORY i ON cc.Part_ID = i.Part_ID
                WHERE cc.Part_ID = @PartID ORDER BY cc.Car_Make, cc.Car_Model";

            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(sql,conn)) {

                    cmd.Parameters.AddWithValue("@PartID", partID);
                    conn.Open();
                    using (var r = cmd.ExecuteReader()) {
                        while (r.Read()) {
                            list.Add(new CarCompatibility
                            {
                                CompatibilityID = (int)r["Compatibility_ID"],
                                PartID = (int)r["Part_ID"],
                                PartName = r["Part_Name"].ToString(),
                                CarMake = r["Car_Make"].ToString(),
                                CarModel = r["Car_Model"].ToString(),
                                YearRange = r["Year_Range"] == DBNull.Value ? null : r["Year_Range"].ToString()
                            });
                        }
                    }
                }
            }

            return list;
        }

        public List<CarCompatibility> SearchByCar(string make, string model, string year = null) { 
            
            var list = new List<CarCompatibility>();
            string sql  = @"select cc.*, i.Part_Name from Car_Compatibility cc 
                                    join Inventory i on i.Part_ID = cc.Part_ID
                                    where cc.Car_Make Like @Make AND cc.Car_Mode like @Model";
            if (!string.IsNullOrEmpty(year)) {
                sql += "AND cc.Year_Range Like @Year";
            }
            sql += "ORDER BY i.Part_Name";
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(sql, conn)) {
                    cmd.Parameters.AddWithValue("@Make", "%" + make + "%"); 
                    cmd.Parameters.AddWithValue("@Model", "%" + model + "%"); 
                    if (!string.IsNullOrEmpty(year)) 
                        cmd.Parameters.AddWithValue("@Year", "%" + year + "%"); 
                    conn.Open();
                    using (var r = cmd.ExecuteReader()) {
                        while (r.Read()) {
                            list.Add(
                                    new CarCompatibility {
                                        CompatibilityID = (int)r["Compatibility_ID"],
                                        PartID = (int)r["Part_ID"],
                                        PartName = r["Part_Name"].ToString(),
                                        CarMake = r["Car_Make"].ToString(),
                                        CarModel = r["Car_Model"].ToString(),
                                        YearRange = r["Year_Range"] == DBNull.Value ? null : r["Year_Range"].ToString()
                                    }
                                );
                        }
                    }
                }
            }

            return list;
        }

        public bool Add(CarCompatibility cc) {
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(@"INSERT INTO Car_Compatibility (Part_ID, Car_Make, Car_Model, Year_Range) 
                                                  Values(@PartID, @Make, @Model, @Year)", conn)) {
                    cmd.Parameters.AddWithValue("@PartID", cc.PartID);
                    cmd.Parameters.AddWithValue("@Make", cc.CarMake);
                    cmd.Parameters.AddWithValue("@PartID", cc.CarModel);
                    cmd.Parameters.AddWithValue("@Year", (object)cc.YearRange ?? DBNull.Value);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int CombatibilityID) {
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand("DELETE FROM Car_Compatibility WHERE Compatibility_ID @ID", conn)) {
                    cmd.Parameters.AddWithValue("@ID", CombatibilityID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
