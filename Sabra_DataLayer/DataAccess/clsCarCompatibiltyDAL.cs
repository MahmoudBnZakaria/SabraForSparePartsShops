using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsCarCompatibilityDAL
    {
        private CarCompatibility MapItem(SqlDataReader r) => new CarCompatibility
        {
            CompatibilityID = (int)r["Compatibility_ID"],
            PartID = (int)r["Part_ID"],
            PartName = r["Part_Name"].ToString(),
            CarMake = r["Car_Make"].ToString(),
            CarModel = r["Car_Model"].ToString(),
            YearRange = r["Year_Range"] == DBNull.Value ? null : r["Year_Range"].ToString()
        };

        public List<CarCompatibility> GetByPart(int partID)
        {
            var list = new List<CarCompatibility>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_CarCompatibility_GetByPart"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapItem(r));
            }
            return list;
        }

        public List<CarCompatibility> SearchByCar(string make, string model, string year = null)
        {
            var list = new List<CarCompatibility>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_CarCompatibility_SearchByCar"))
            {
                clsDBHelper.AddParam(cmd, "@Make", make);
                clsDBHelper.AddParam(cmd, "@Model", model);
                clsDBHelper.AddParam(cmd, "@Year", year);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapItem(r));
            }
            return list;
        }

        public bool Add(CarCompatibility cc)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_CarCompatibility_Add"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", cc.PartID);
                clsDBHelper.AddParam(cmd, "@CarMake", cc.CarMake);
                clsDBHelper.AddParam(cmd, "@CarModel", cc.CarModel);
                clsDBHelper.AddParam(cmd, "@YearRange", cc.YearRange);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int compatibilityID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_CarCompatibility_Delete"))
            {
                clsDBHelper.AddParam(cmd, "@CompatibilityID", compatibilityID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}