using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

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

        public List<Customer> GetAll()
        {
            var list = new List<Customer>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Customer_GetAll"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapCustomer(r));
            }
            return list;
        }

        public Customer GetByID(int id)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Customer_GetByID"))
            {
                clsDBHelper.AddParam(cmd, "@CustomerID", id);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapCustomer(r) : null;
            }
        }

        public List<Customer> Search(string keyword = null, int? typeID = null, string debtFilter = null)
        {
            var list = new List<Customer>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Customer_Search"))
            {
                clsDBHelper.AddParam(cmd, "@Keyword", keyword);
                clsDBHelper.AddParam(cmd, "@TypeID", typeID);
                clsDBHelper.AddParam(cmd, "@DebtFilter", debtFilter);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapCustomer(r));
            }
            return list;
        }

        public int Add(Customer cust)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Customer_Add"))
            {
                clsDBHelper.AddParam(cmd, "@CustomerName", cust.CustomerName);
                clsDBHelper.AddParam(cmd, "@PhoneNumber", cust.PhoneNumber);
                clsDBHelper.AddParam(cmd, "@CustomerTypeID", cust.CustomerTypeID);
                clsDBHelper.AddParam(cmd, "@CreditLimit", cust.CreditLimit);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewCustomerID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }

        public bool Update(Customer cust)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Customer_Update"))
            {
                clsDBHelper.AddParam(cmd, "@CustomerID", cust.CustomerID);
                clsDBHelper.AddParam(cmd, "@CustomerName", cust.CustomerName);
                clsDBHelper.AddParam(cmd, "@PhoneNumber", cust.PhoneNumber);
                clsDBHelper.AddParam(cmd, "@CustomerTypeID", cust.CustomerTypeID);
                clsDBHelper.AddParam(cmd, "@CreditLimit", cust.CreditLimit);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool AdjustBalance(int customerID, decimal delta, bool isPayment = false, bool enforceCreditLimit = true)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Customer_AdjustBalance"))
            {
                clsDBHelper.AddParam(cmd, "@CustomerID", customerID);
                clsDBHelper.AddParam(cmd, "@Delta", delta);
                clsDBHelper.AddParam(cmd, "@IsPayment", isPayment);
                clsDBHelper.AddParam(cmd, "@EnforceCreditLimit", enforceCreditLimit);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}