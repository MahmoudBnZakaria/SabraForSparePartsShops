using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.DataLayer
{
    public class clsCustomerDAL
    {
        private Customer MapCustomer(SqlDataReader r) => new Customer
        {
            CustomerID = (int)r["Customer_ID"],
            CustomerName = r["Customer_Name"].ToString(),
            PhoneNumber = r["Phone_Number"] == DBNull.Value ? null : r["Phone_Number"].ToString(),
            CustomerTypeID = r["Customer_Type_ID"] == DBNull.Value ? (int?)null : (int)r["Customer_Type_ID"],
            CustomerType = r["Type_Name"] == DBNull.Value ? null : r["Type_Name"].ToString(),
            CreditLimit = (decimal)r["Credit_Limit"],
            TotalBalance = (decimal)r["Total_Balance"],
            LastPaymentDate = r["Last_Payment_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)r["Last_Payment_Date"],
            CreatedAt = (DateTime)r["Created_At"]
        };

        private const string _selectSql = @"SELECT cu.*, ct.Type_Name 
                                            FROM Customers cu 
                                            LEFT JOIN Customer_Types ct ON cu.Customer_Type_ID = ct.Customer_Type_ID";

        public List<Customer> GetAll() { 
            var list = new List<Customer>();

            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(_selectSql, conn)) { 
                    conn.Open();
                    using (var r = cmd.ExecuteReader()) 
                        while (r.Read()) list.Add(MapCustomer(r));
                }
            }
            return list;
        }

        public Customer GetByID(int id) {
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(_selectSql + "WHERE cu.Customer_ID = @ID", conn)) {
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    using (var r = cmd.ExecuteReader()) {
                        return r.Read() ? MapCustomer(r) : null;
                    }
                }
            }
        }
        public List<Customer> Search(string keyword, int? typeID = null,string deptFilter = null ) {

            List<Customer> list = new List<Customer>();
            var sql = new System.Text.StringBuilder(_selectSql + " WHERE 1= 1");
            if (!string.IsNullOrWhiteSpace(keyword)) {
                sql.Append("AND (cu.Custer_Name LIKE @kw OR cu.Phone_Number LIKE @kw)");
            }
            if (typeID.HasValue) {
                sql.Append("AND cu.Customer_Type_ID = @TypeID");
            }
            if (deptFilter == "hasDebt")
            {
                sql.Append("AND cu.Total_Balance > 0");
            }
            else if (deptFilter == "exceeded") {
                sql.Append("AND cu.Total_Balance >= cu.Credit_Limit  AND cu.Credit_Limit > 0");
            }
            sql.Append("ORDER BY cu.Customer_Name");

            using (var conn = clsConnectionManager.GetConnection()) {

                using (var cmd = new SqlCommand(sql.ToString(), conn))
                {
                    if (string.IsNullOrWhiteSpace(keyword))
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    if (typeID.HasValue)
                        cmd.Parameters.AddWithValue("@TypeID", typeID.Value);

                    conn.Open();
                    using (var r = cmd.ExecuteReader()) {
                        list.Add(MapCustomer(r));
                    }
                }
            }

            return list;
        }

        public int Add(Customer cust) {
            const string sql = @"
                INSERT INTO CUSTOMERS (Customer_Name, Phone_Number, Customer_Type_ID, Credit_Limit, Total_Balance)
                VALUES (@Name, @Phone, @TypeID, @CreditLimit, 0);
                SELECT SCOPE_IDENTITY();";

            using (var conn = clsConnectionManager.GetConnection()) {

                using (var cmd = new SqlCommand(sql, conn)) {
                    cmd.Parameters.AddWithValue("@Name", cust.CustomerName);
                    cmd.Parameters.AddWithValue("@Phone", (object)cust.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TypeID", (object)cust.CustomerTypeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreditLimit", cust.CreditLimit);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool Update(Customer cust)
        {
            const string sql = @"
                UPDATE CUSTOMERS SET
                    Customer_Name    = @Name,
                    Phone_Number     = @Phone,
                    Customer_Type_ID = @TypeID,
                    Credit_Limit     = @CreditLimit
                WHERE Customer_ID = @ID";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", cust.CustomerID);
                cmd.Parameters.AddWithValue("@Name", cust.CustomerName);
                cmd.Parameters.AddWithValue("@Phone", (object)cust.PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TypeID", (object)cust.CustomerTypeID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CreditLimit", cust.CreditLimit);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateBalance(int customerID, decimal newBalance, DateTime? lastPaymentDate, SqlTransaction transaction = null)
        {
            var conn = transaction?.Connection ?? clsConnectionManager.GetConnection();
            bool ownConn = transaction == null;
            try
            {
                var sql = "UPDATE CUSTOMERS SET Total_Balance = @Balance";
                if (lastPaymentDate.HasValue) sql += ", Last_Payment_Date = @PayDate";
                sql += " WHERE Customer_ID = @ID";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (transaction != null) cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@Balance", newBalance);
                    cmd.Parameters.AddWithValue("@ID", customerID);
                    if (lastPaymentDate.HasValue)
                        cmd.Parameters.AddWithValue("@PayDate", lastPaymentDate.Value);
                    if (ownConn) conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { if (ownConn) conn.Dispose(); }
        }
    }
}
