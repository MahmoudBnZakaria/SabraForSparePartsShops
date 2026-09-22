using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsSupplierDAL
    {
        private Supplier MapSupplier(SqlDataReader r) => new Supplier
        {
            SupplierID = r.GetInt("Supplier_ID"),
            SupplierName = r.GetStr("Supplier_Name"),
            ContactPerson = r.GetStr("Contact_Person"),
            PhoneNumber = r.GetStr("Phone_Number"),
            SupplierBalance = r.GetDec("Supplier_Balance"),
            Address = r.GetStr("Address"),
            CreatedAt = r.GetDate("Created_At")
        };

        public List<Supplier> GetAll()
        {
            var list = new List<Supplier>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Supplier_GetAll))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapSupplier(r));
            }
            return list;
        }

        public Supplier GetByID(int supplierID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Supplier_GetByID))
            {
                clsDBHelper.AddParam(cmd, "@SupplierID", supplierID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapSupplier(r) : null;
            }
        }

        public List<Supplier> Search(string keyword)
        {
            var list = new List<Supplier>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Supplier_Search))
            {
                clsDBHelper.AddParam(cmd, "@Keyword", keyword);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapSupplier(r));
            }
            return list;
        }

        /// <summary>بترجع الـ Supplier_ID الجديد.</summary>
        public int Add(Supplier sup)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Supplier_Add))
            {
                clsDBHelper.AddParam(cmd, "@SupplierName", sup.SupplierName);
                clsDBHelper.AddParam(cmd, "@ContactPerson", sup.ContactPerson);
                clsDBHelper.AddParam(cmd, "@PhoneNumber", sup.PhoneNumber);
                clsDBHelper.AddParam(cmd, "@SupplierBalance", sup.SupplierBalance);
                clsDBHelper.AddParam(cmd, "@Address", sup.Address);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewSupplierID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetInt(outId);
            }
        }

        /// <summary>ملاحظة: الرصيد مش بيتعدّل من هنا — استخدم AdjustBalance.</summary>
        public bool Update(Supplier sup)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Supplier_Update))
            {
                clsDBHelper.AddParam(cmd, "@SupplierID", sup.SupplierID);
                clsDBHelper.AddParam(cmd, "@SupplierName", sup.SupplierName);
                clsDBHelper.AddParam(cmd, "@ContactPerson", sup.ContactPerson);
                clsDBHelper.AddParam(cmd, "@PhoneNumber", sup.PhoneNumber);
                clsDBHelper.AddParam(cmd, "@Address", sup.Address);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        public bool AdjustBalance(int supplierID, decimal delta, int userID, string reason = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Supplier_AdjustBalance))
            {
                clsDBHelper.AddParam(cmd, "@SupplierID", supplierID);
                clsDBHelper.AddParam(cmd, "@Delta", delta);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Reason", reason);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }
    }

}