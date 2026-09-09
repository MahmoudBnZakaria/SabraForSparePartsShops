using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsSupplierDAL
    {
        private Supplier MapSupplier(SqlDataReader r) => new Supplier
        {
            SupplierID = (int)r["Supplier_ID"],
            SupplierName = r["Supplier_Name"].ToString(),
            ContactPerson = r["Contact_Person"] == DBNull.Value ? null : r["Contact_Person"].ToString(),
            PhoneNumber = r["Phone_Number"] == DBNull.Value ? null : r["Phone_Number"].ToString(),
            SupplierBalance = (decimal)r["Supplier_Balance"],
            Address = r["Address"] == DBNull.Value ? null : r["Address"].ToString(),
            CreatedAt = (DateTime)r["Created_At"]
        };

        public List<Supplier> GetAll()
        {
            var list = new List<Supplier>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Supplier_GetAll"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapSupplier(r));
            }
            return list;
        }

        public Supplier GetByID(int id)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Supplier_GetByID"))
            {
                clsDBHelper.AddParam(cmd, "@SupplierID", id);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapSupplier(r) : null;
            }
        }

        public List<Supplier> Search(string keyword)
        {
            var list = new List<Supplier>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Supplier_Search"))
            {
                clsDBHelper.AddParam(cmd, "@Keyword", keyword);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapSupplier(r));
            }
            return list;
        }

        public int Add(Supplier sup)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Supplier_Add"))
            {
                clsDBHelper.AddParam(cmd, "@SupplierName", sup.SupplierName);
                clsDBHelper.AddParam(cmd, "@ContactPerson", sup.ContactPerson);
                clsDBHelper.AddParam(cmd, "@PhoneNumber", sup.PhoneNumber);
                clsDBHelper.AddParam(cmd, "@SupplierBalance", sup.SupplierBalance);
                clsDBHelper.AddParam(cmd, "@Address", sup.Address);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewSupplierID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }

        public bool Update(Supplier sup)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Supplier_Update"))
            {
                clsDBHelper.AddParam(cmd, "@SupplierID", sup.SupplierID);
                clsDBHelper.AddParam(cmd, "@SupplierName", sup.SupplierName);
                clsDBHelper.AddParam(cmd, "@ContactPerson", sup.ContactPerson);
                clsDBHelper.AddParam(cmd, "@PhoneNumber", sup.PhoneNumber);
                clsDBHelper.AddParam(cmd, "@Address", sup.Address);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool AdjustBalance(int supplierID, decimal delta)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Supplier_AdjustBalance"))
            {
                clsDBHelper.AddParam(cmd, "@SupplierID", supplierID);
                clsDBHelper.AddParam(cmd, "@Delta", delta);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}