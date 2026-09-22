using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsInvoiceDAL
    {
        private SalesInvoice MapInvoice(SqlDataReader r)
        {
            var inv = new SalesInvoice
            {
                InvoiceID = r.GetInt("Invoice_ID"),
                CustomerID = r.GetIntOrNull("Customer_ID"),
                CustomerName = r.GetStr("Customer_Name") ?? "عميل نقدي",
                EmployeeID = r.GetInt("Employee_ID"),
                EmployeeName = r.GetStr("Employee_Name", "Full_Name"),
                DateTime = r.GetDate("Date_Time"),
                TotalAmount = r.GetDec("Total_Amount"),
                Discount = r.GetDec("Discount"),
                PaidAmount = r.GetDec("Paid_Amount"),
                PaymentStatusID = r.GetInt("Payment_Status_ID"),
                PaymentStatus = r.GetStr("Status_Name", "Payment_Status"),
                CreatedAt = r.GetDate("Created_At")
            };

            if (r.HasColumn("Final_Amount")) inv.FinalAmount = r.GetDec("Final_Amount");
            if (r.HasColumn("Remaining_Balance")) inv.RemainingBalance = r.GetDec("Remaining_Balance");

            return inv;
        }

        private InvoiceDetail MapDetail(SqlDataReader r)
        {
            var d = new InvoiceDetail
            {
                DetailID = r.GetInt("Detail_ID"),
                InvoiceID = r.GetInt("Invoice_ID"),
                PartID = r.GetInt("Part_ID"),
                PartName = r.GetStr("Part_Name"),
                Quantity = r.GetInt("Quantity"),
                UnitPrice = r.GetDec("Unit_Price"),
                UnitCost = r.GetDec("Unit_Cost")
            };
            if (r.HasColumn("Line_Total")) d.LineTotal = r.GetDec("Line_Total");
            return d;
        }

        public List<SalesInvoice> GetAll(DateTime? from = null, DateTime? to = null,
                                         int? customerID = null, int? employeeID = null, int? statusID = null)
        {
            var list = new List<SalesInvoice>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.SalesInvoice_GetAll))
            {
                clsDBHelper.AddParam(cmd, "@From", from?.Date);
                // لآخر اليوم بالكامل عشان فواتير اليوم نفسه متضيعش
                clsDBHelper.AddParam(cmd, "@To", to?.Date.AddDays(1).AddTicks(-1));
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

        /// <summary>
        /// بترجع الفاتورة بالتفاصيل. لو الـ SP بترجع Result Set تاني للتفاصيل
        /// بيتقرا تلقائيًا، ولو لأ بترجع الهيدر بس و Details تفضل فاضية.
        /// </summary>
        public SalesInvoice GetByID(int invoiceID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.SalesInvoice_GetByID))
            {
                clsDBHelper.AddParam(cmd, "@InvoiceID", invoiceID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    SalesInvoice invoice = null;
                    if (r.Read()) invoice = MapInvoice(r);
                    if (invoice == null) return null;

                    if (r.NextResult())
                        while (r.Read())
                            invoice.Details.Add(MapDetail(r));

                    return invoice;
                }
            }
        }

        /// <summary>
        /// مفيش SP اسمها sp_SalesInvoice_GetDetails في عقد الداتابيز،
        /// فالتفاصيل بتتجاب من نفس sp_SalesInvoice_GetByID.
        /// </summary>
        public List<InvoiceDetail> GetDetails(int invoiceID)
        {
            var invoice = GetByID(invoiceID);
            return invoice == null ? new List<InvoiceDetail>() : invoice.Details;
        }

        /// <summary>
        /// بتنشئ الفاتورة + التفاصيل + خصم المخزون + رصيد العميل + تحصيل الخزنة،
        /// كل ده في Transaction واحدة جوه الـ SP. بترجع الـ Invoice_ID الجديد.
        /// saleTransactionTypeID = الـ ID بتاع "تحصيل فاتورة" في TRANSACTION_TYPES.
        /// </summary>
        public int Add(SalesInvoice invoice, int saleMovementTypeID, int userID,
                       int paymentMethodID, int saleTransactionTypeID, bool enforceCreditLimit = true)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.SalesInvoice_Add))
            {
                clsDBHelper.AddParam(cmd, "@CustomerID", invoice.CustomerID);
                clsDBHelper.AddParam(cmd, "@EmployeeID", invoice.EmployeeID);
                clsDBHelper.AddParam(cmd, "@DateTime", invoice.DateTime);
                clsDBHelper.AddParam(cmd, "@Discount", invoice.Discount);
                clsDBHelper.AddParam(cmd, "@PaidAmount", invoice.PaidAmount);
                clsDBHelper.AddParam(cmd, "@PaymentStatusID", invoice.PaymentStatusID);
                clsDBHelper.AddParam(cmd, "@SaleMovementTypeID", saleMovementTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@PaymentMethodID", paymentMethodID);
                clsDBHelper.AddParam(cmd, "@SaleTransactionTypeID", saleTransactionTypeID);
                clsDBHelper.AddParam(cmd, "@EnforceCreditLimit", enforceCreditLimit);

                var detailsTable = clsDBHelper.BuildInvoiceDetailTable(invoice.Details);
                clsDBHelper.AddTableValuedParam(cmd, "@Details", SP.Type_InvoiceDetail, detailsTable);

                var outId = clsDBHelper.AddOutputParam(cmd, "@NewInvoiceID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetInt(outId);
            }
        }

        /// <summary>
        /// تحصيل دفعة على فاتورة + تسجيلها في الخزنة.
        /// collectionTransactionTypeID = الـ ID بتاع "تحصيل فاتورة" في TRANSACTION_TYPES.
        /// </summary>
        public bool UpdatePayment(int invoiceID, decimal additionalPaid, int newStatusID,
                                  int paymentMethodID, int collectionTransactionTypeID, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.SalesInvoice_UpdatePayment))
            {
                clsDBHelper.AddParam(cmd, "@InvoiceID", invoiceID);
                clsDBHelper.AddParam(cmd, "@AdditionalPaid", additionalPaid);
                clsDBHelper.AddParam(cmd, "@NewStatusID", newStatusID);
                clsDBHelper.AddParam(cmd, "@PaymentMethodID", paymentMethodID);
                clsDBHelper.AddParam(cmd, "@CollectionTransactionTypeID", collectionTransactionTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }
    }

}