using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private const string _selectSql = @"
            SELECT si.*,
                   ISNULL(cu.Customer_Name, N'عميل نقدي') AS Customer_Name,
                   e.Full_Name  AS Employee_Name,
                   ps.Status_Name
            FROM SALES_INVOICES si
            LEFT JOIN CUSTOMERS      cu ON si.Customer_ID       = cu.Customer_ID
            LEFT JOIN EMPLOYEES      e  ON si.Employee_ID       = e.Employee_ID
            LEFT JOIN PAYMENT_STATUS ps ON si.Payment_Status_ID = ps.Status_ID";

        public List<SalesInvoice> GetAll(DateTime? from = null, DateTime? to = null, int? customerID = null, int? employeeID = null, int? statusID = null)
        {
            var list = new List<SalesInvoice>();
            var sql = new System.Text.StringBuilder(_selectSql + " WHERE 1=1");
            if (from.HasValue) sql.Append(" AND si.Date_Time >= @From");
            if (to.HasValue) sql.Append(" AND si.Date_Time <= @To");
            if (customerID.HasValue) sql.Append(" AND si.Customer_ID = @CustID");
            if (employeeID.HasValue) sql.Append(" AND si.Employee_ID = @EmpID");
            if (statusID.HasValue) sql.Append(" AND si.Payment_Status_ID = @StatusID");
            sql.Append(" ORDER BY si.Date_Time DESC");

            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql.ToString(), conn))
            {
                if (from.HasValue) cmd.Parameters.AddWithValue("@From", from.Value);
                if (to.HasValue) cmd.Parameters.AddWithValue("@To", to.Value.AddDays(1).AddSeconds(-1));
                if (customerID.HasValue) cmd.Parameters.AddWithValue("@CustID", customerID.Value);
                if (employeeID.HasValue) cmd.Parameters.AddWithValue("@EmpID", employeeID.Value);
                if (statusID.HasValue) cmd.Parameters.AddWithValue("@StatusID", statusID.Value);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(MapInvoice(r));
            }
            return list;
        }

        public SalesInvoice GetByID(int invoiceID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(_selectSql + " WHERE si.Invoice_ID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", invoiceID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapInvoice(r) : null;
            }
        }


        public List<InvoiceDetail> GetDetails(int invoiceID)
        {
            var list = new List<InvoiceDetail>();

            const string sql = @"
                SELECT id.*, i.Part_Name
                FROM Invoice_Details id 
                JOIN Inventory i ON id.Part_ID = i.Part_ID
                WHERE id.Invoice_ID = @InID";
            using (var conn = clsConnectionManager.GetConnection())
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@InID", invoiceID);
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                            list.Add(
                                    new InvoiceDetail
                                    {

                                        DetailID = (int)r["Detail_ID"],
                                        InvoiceID = (int)r["Invoice_ID"],
                                        PartID = (int)r["Part_ID"],
                                        PartName = r["Part_Name"].ToString(),
                                        Quantity = (int)r["Quantity"],
                                        UnitPrice = (decimal)r["Unit_Price"],
                                        LineTotal = (decimal)r["Line_Total"]
                                    }
                                );
                    }
                }
            }

            return list;
        }

        public int Add(SalesInvoice invoice) {

            using (var conn = clsConnectionManager.GetConnection()) {

                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Get A new Invoice
                        const string inSql = @"
                                                    INSERT INTO Sales_Invoices 
                                                    (Customer_ID, Employee_ID, Date_Time, Total_Amount, Discount, Paid_Amount, Payment_Status_ID)
                                                    Values(@CustID, @EmpID, @DateTime, @Total, @Discount, @Paid, @StatusID);
                                                    SELECT SCOPE_IDENTITY();
                                                    ";
                        int invoiceID;
                        using (var cmd = new SqlCommand(inSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@CustID", (object)invoice.CustomerID ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@EmpID", invoice.EmployeeID);
                            cmd.Parameters.AddWithValue("@DateTime", invoice.DateTime);
                            cmd.Parameters.AddWithValue("@Total", invoice.TotalAmount);
                            cmd.Parameters.AddWithValue("@Discount", invoice.Discount);
                            cmd.Parameters.AddWithValue("@Paid", invoice.PaidAmount);
                            cmd.Parameters.AddWithValue("@StatusID", invoice.PaymentStatus);

                            invoiceID = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        //Created Table For Details And Link int to The Invoice
                        foreach (var details in invoice.Details)
                        {
                            const string detsql = @"INSERT INTO Invoice_Details (Invoice_ID, Part_ID, Quantity, Unit_Price)
                                                    Values(@InvID, @PartID, @Qty, @Price)";
                            using (var cmd = new SqlCommand(detsql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@InvID", invoiceID);
                                cmd.Parameters.AddWithValue("@PartID", details.PartID);
                                cmd.Parameters.AddWithValue("@Qty", details.Quantity);
                                cmd.Parameters.AddWithValue("@Price", details.UnitPrice);

                                cmd.ExecuteNonQuery();
                            }

                            // Update Stock
                            const string stockSql = @"UPDATE Inventory SET 
                                                    Current_Stock = Current_Stock - @Qty,
                                                    Updated_At = GETDATE() 
                                                    WHERE Part_ID = @PartID";
                            using (var cmd = new SqlCommand(stockSql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@Qty", details.Quantity);
                                cmd.Parameters.AddWithValue("@PartID", details.PartID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    
                    tran.Commit();
                    return invoiceID;
                    }

                    catch { 
                        tran.Rollback();
                        throw;
                    }
                }
            }
        
        }

        public bool UpdatePayment(int invoice, Decimal additionalPaid, int newStatusID) {
            const string sql = @"UPDATE Sales_Invoices SET
                                    Paid_Amount = Paid_Amount - @AddPaid,
                                    Payment_Status_ID = @StatusID
                                WHERE Invoice_ID = @ID";
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@AddPaid", additionalPaid);
                    cmd.Parameters.AddWithValue("@StatusID", newStatusID);
                    cmd.Parameters.AddWithValue("@ID", invoice);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
} 