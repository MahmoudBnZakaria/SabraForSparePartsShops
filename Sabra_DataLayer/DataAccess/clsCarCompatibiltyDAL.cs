using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsCarCompatibilityDAL
    {
        private CarCompatibility MapItem(SqlDataReader r) => new CarCompatibility
        {
            CompatibilityID = r.GetInt("Compatibility_ID"),
            PartID = r.GetInt("Part_ID"),
            PartName = r.GetStr("Part_Name"),
            CarMake = r.GetStr("Car_Make"),
            CarModel = r.GetStr("Car_Model"),
            YearRange = r.GetStr("Year_Range")
        };

        public List<CarCompatibility> GetByPart(int partID)
        {
            var list = new List<CarCompatibility>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.CarCompatibility_GetByPart))
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
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.CarCompatibility_SearchByCar))
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
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.CarCompatibility_Add))
            {
                clsDBHelper.AddParam(cmd, "@PartID", cc.PartID);
                clsDBHelper.AddParam(cmd, "@CarMake", cc.CarMake);
                clsDBHelper.AddParam(cmd, "@CarModel", cc.CarModel);
                clsDBHelper.AddParam(cmd, "@YearRange", cc.YearRange);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        public bool Delete(int compatibilityID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.CarCompatibility_Delete))
            {
                clsDBHelper.AddParam(cmd, "@CompatibilityID", compatibilityID);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }
    }

}