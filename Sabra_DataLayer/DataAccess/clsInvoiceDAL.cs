using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsInvoiceDAL
    {
        private SalesInvoice MapInvoice(SqlDataReader r) => new SalesInvoice
        {
            InvoiceID = (int)r["Invoice_ID"],
            CustomerID = r["Customer_ID"] == DBNull.Value ? (int?)null : (int)r["Customer_ID"],
            CustomerName = r["Customer_Name"] == DBNull.Value ? "عميل نقدي" : r["Customer_Name"].ToString(),
            EmployeeID = (int)r["Employee_ID"],
            EmployeeName = r["Employee_Name"].ToString(),
            DateTime = (DateTime)r["Date_Time"],
            TotalAmount = (decimal)r["Total_Amount"],
            Discount = (decimal)r["Discount"],
            FinalAmount = (decimal)r["Final_Amount"],
            PaidAmount = (decimal)r["Paid_Amount"],
            RemainingBalance = (decimal)r["Remaining_Balance"],
            PaymentStatusID = (int)r["Payment_Status_ID"],
            PaymentStatus = r["Status_Name"].ToString(),
            CreatedAt = (DateTime)r["Created_At"]
        };

        public List<SalesInvoice> GetAll(DateTime? from = null, DateTime? to = null, int? customerID = null, int? employeeID = null, int? statusID = null)
        {
            var list = new List<SalesInvoice>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_SalesInvoice_GetAll"))
            {
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to?.Date.AddDays(1).AddSeconds(-1));
                clsDBHelper.AddParam(cmd, "@CustomerID", customerID);
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                clsDBHelper.AddParam(cmd, "@StatusID", statusID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapInvoice(r));
            }
            return list;
        }

        public SalesInvoice GetByID(int invoiceID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_SalesInvoice_GetByID"))
            {
                clsDBHelper.AddParam(cmd, "@InvoiceID", invoiceID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapInvoice(r) : null;
            }
        }


        public List<InvoiceDetail> GetDetails(int invoiceID)
        {
            var list = new List<InvoiceDetail>();

            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand("sp_SalesInvoice_GetDetails", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                clsDBHelper.AddParam(cmd, "@InvoiceID", invoiceID);

                conn.Open();

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new InvoiceDetail
                        {
                            DetailID = (int)r["Detail_ID"],
                            InvoiceID = (int)r["Invoice_ID"],
                            PartID = (int)r["Part_ID"],
                            PartName = r["Part_Name"].ToString(),
                            Quantity = (int)r["Quantity"],
                            UnitPrice = (decimal)r["Unit_Price"],
                            LineTotal = (decimal)r["Line_Total"]
                        });
                    }
                }
            }

            return list;
        }



        public int Add(SalesInvoice invoice, int saleMovementTypeID, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_SalesInvoice_Add"))
            {
                clsDBHelper.AddParam(cmd, "@CustomerID", invoice.CustomerID);
                clsDBHelper.AddParam(cmd, "@EmployeeID", invoice.EmployeeID);
                clsDBHelper.AddParam(cmd, "@DateTime", invoice.DateTime);
                clsDBHelper.AddParam(cmd, "@Discount", invoice.Discount);
                clsDBHelper.AddParam(cmd, "@PaidAmount", invoice.PaidAmount);
                clsDBHelper.AddParam(cmd, "@PaymentStatusID", invoice.PaymentStatusID);
                clsDBHelper.AddParam(cmd, "@SaleMovementTypeID", saleMovementTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);

                var detailsTable = clsDBHelper.BuildInvoiceDetailTable(invoice.Details);
                clsDBHelper.AddTableValuedParam(cmd, "@Details", "dbo.InvoiceDetailTableType", detailsTable);

                var outId = clsDBHelper.AddOutputParam(cmd, "@NewInvoiceID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }

        public bool UpdatePayment(int invoiceID, decimal additionalPaid, int newStatusID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_SalesInvoice_UpdatePayment"))
            {
                clsDBHelper.AddParam(cmd, "@InvoiceID", invoiceID);
                clsDBHelper.AddParam(cmd, "@AdditionalPaid", additionalPaid);
                clsDBHelper.AddParam(cmd, "@NewStatusID", newStatusID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}