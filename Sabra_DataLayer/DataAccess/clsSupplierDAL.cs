using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;

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

        public List<Supplier> GetAll() { 
            List<Supplier> list = new List<Supplier>();

            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand("SELECT * FROM Suppliers ORDER BY Supplier_Name", conn)) { 
                    conn.Open();
                    using (var r = cmd.ExecuteReader()) {
                        while (r.Read())
                            list.Add(MapSupplier(r));
                    }
                }
            }
            return list;
        }

        public Supplier GetByID(int id) {
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand("SELECT * FROM Suppliers WHERE Supplier_ID = @ID", conn)) {
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    using (var r = cmd.ExecuteReader()) {
                        return r.Read() ? MapSupplier(r) : null;
                    }
                }
            }
        }

        public List<Supplier> Search(String keyword) { 
            var list = new List<Supplier>();

            const string sql = @"SELECT * FROM Suppliers 
                               WHERE Supplier_Name Like @kw OR Phone_Number LIKE @kw OR Contact_Person LIKE @kw
                               ORDER BY Supplier_Name";
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(sql,conn)) {

                    cmd.Parameters.AddWithValue("@kw", "%"+keyword +"%");
                    conn.Open();
                    using (var r = cmd.ExecuteReader()) { 
                        while (r.Read())  list.Add(MapSupplier(r));
                    }
                }
            }

            return list;
        }

        public int Add(Supplier sup) {
            const string sql = @"INSERT INTO Suppliers (Supplier_Name, Contact_Name, Contact_Person, Phone_Number, Supplier_Balance, Address)
                                 Values (@Name, @Contact, @Phone, @Balance, @Address);
                                 SELECT SCOPE_IDENTITY();";
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(sql, conn)) {
                    cmd.Parameters.AddWithValue("@Name", sup.SupplierName);
                    cmd.Parameters.AddWithValue("@Contact", (object)sup.ContactPerson ?? DBNull.Value );
                    cmd.Parameters.AddWithValue("@Phone", (object)sup.PhoneNumber?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Balance", sup.SupplierBalance);
                    cmd.Parameters.AddWithValue("@Address",(object)sup.Address ?? DBNull.Value);

                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool Update(Supplier sup) {

            const string sql = @"
                UPDATE SUPPLIERS SET
                    Supplier_Name    = @Name,
                    Contact_Person   = @Contact,
                    Phone_Number     = @Phone,
                    Address          = @Address
                WHERE Supplier_ID = @ID";

            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(sql, conn)) {

                    cmd.Parameters.AddWithValue("@ID", sup.SupplierID);
                    cmd.Parameters.AddWithValue("@Name", sup.SupplierName);
                    cmd.Parameters.AddWithValue("@Contact", (object)sup.ContactPerson ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", (object)sup.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)sup.Address ?? DBNull.Value);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

        }

        public bool UpdateBalance(int supplierID, decimal newBalance, SqlTransaction transaction = null) { 
            var conn = transaction.Connection?? clsConnectionManager.GetConnection();
            bool ownconn = transaction == null;

            try
            {
                using (var cmd = new SqlCommand("UPDATE Suppliers SET Supplier_Balance = @Balance WHERE Supplier_ID = @ID", conn)) { 
                    
                    if(transaction != null) cmd.Transaction = transaction;

                    cmd.Parameters.AddWithValue("@Balance", newBalance);
                    cmd.Parameters.AddWithValue("@Supplier_ID", supplierID);

                    if (ownconn) conn.Open();
                    return cmd.ExecuteNonQuery() > 0 ;
                }
            }
            finally { 
                if (ownconn)
                    conn.Dispose();
            }
        }
    }
}
