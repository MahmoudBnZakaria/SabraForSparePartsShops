using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsPurchaseOrderDAL
    {
        private PurchaseOrder MapPO(SqlDataReader r)
        {
            var po = new PurchaseOrder
            {
                POID = r.GetInt("PO_ID"),
                SupplierID = r.GetInt("Supplier_ID"),
                SupplierName = r.GetStr("Supplier_Name"),
                EmployeeID = r.GetInt("Employee_ID"),
                EmployeeName = r.GetStr("Employee_Name", "Full_Name"),
                OrderDate = r.GetDate("Order_Date"),
                TotalAmount = r.GetDec("Total_Amount"),
                PaidAmount = r.GetDec("Paid_Amount"),
                StatusID = r.GetInt("Status_ID"),
                StatusName = r.GetStr("Status_Name"),
                Notes = r.GetStr("Notes"),
                CreatedAt = r.GetDate("Created_At"),
                ReceivedAt = r.GetDateOrNull("Received_At")
            };

            if (r.HasColumn("Remaining")) po.Remaining = r.GetDec("Remaining");
            return po;
        }

        private PurchaseOrderDetail MapDetail(SqlDataReader r)
        {
            var d = new PurchaseOrderDetail
            {
                DetailID = r.GetInt("Detail_ID"),
                POID = r.GetInt("PO_ID"),
                PartID = r.GetInt("Part_ID"),
                PartName = r.GetStr("Part_Name"),
                Quantity = r.GetInt("Quantity"),
                UnitPrice = r.GetDec("Unit_Price"),
                ReceivedQuantity = r.GetInt("Received_Quantity")
            };
            if (r.HasColumn("Line_Total")) d.LineTotal = r.GetDec("Line_Total");
            return d;
        }

        public List<PurchaseOrder> GetAll(int? supplierID = null, int? statusID = null)
        {
            var list = new List<PurchaseOrder>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.PurchaseOrder_GetAll))
            {
                clsDBHelper.AddParam(cmd, "@SupplierID", supplierID);
                clsDBHelper.AddParam(cmd, "@StatusID", statusID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapPO(r));
            }
            return list;
        }

        /// <summary>بترجع الأمر بالتفاصيل (لو الـ SP بترجع Result Set تاني).</summary>
        public PurchaseOrder GetByID(int poID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.PurchaseOrder_GetByID))
            {
                clsDBHelper.AddParam(cmd, "@POID", poID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    PurchaseOrder po = null;
                    if (r.Read()) po = MapPO(r);
                    if (po == null) return null;

                    if (r.NextResult())
                        while (r.Read())
                            po.Details.Add(MapDetail(r));

                    return po;
                }
            }
        }

        /// <summary>
        /// مفيش SP اسمها sp_PurchaseOrder_GetDetails في عقد الداتابيز،
        /// فالتفاصيل بتتجاب من نفس sp_PurchaseOrder_GetByID.
        /// </summary>
        public List<PurchaseOrderDetail> GetDetails(int poID)
        {
            var po = GetByID(poID);
            return po == null ? new List<PurchaseOrderDetail>() : po.Details;
        }

        /// <summary>
        /// بتنشئ أمر شراء كامل (هيدر + تفاصيل) بـ TVP جوه Transaction واحدة في الـ SP.
        /// بترجع الـ PO_ID الجديد. ملاحظة: Total_Amount بيتحسب في الـ SP من التفاصيل.
        /// </summary>
        public int Add(PurchaseOrder po, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.PurchaseOrder_Add))
            {
                clsDBHelper.AddParam(cmd, "@SupplierID", po.SupplierID);
                clsDBHelper.AddParam(cmd, "@EmployeeID", po.EmployeeID);
                clsDBHelper.AddParam(cmd, "@OrderDate", po.OrderDate);
                clsDBHelper.AddParam(cmd, "@PaidAmount", po.PaidAmount);
                clsDBHelper.AddParam(cmd, "@StatusID", po.StatusID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Notes", po.Notes);

                var detailsTable = clsDBHelper.BuildPODetailTable(po.Details);
                clsDBHelper.AddTableValuedParam(cmd, "@Details", SP.Type_PODetail, detailsTable);

                var outId = clsDBHelper.AddOutputParam(cmd, "@NewPOID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetInt(outId);
            }
        }

        /// <summary>استلام الأمر: بيزوّد المخزون ويسجل الحركات ويغيّر الحالة.</summary>
        public bool Receive(int poID, int receivedStatusID, int purchaseMovementTypeID, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.PurchaseOrder_Receive))
            {
                clsDBHelper.AddParam(cmd, "@POID", poID);
                clsDBHelper.AddParam(cmd, "@ReceivedStatusID", receivedStatusID);
                clsDBHelper.AddParam(cmd, "@PurchaseMovementTypeID", purchaseMovementTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        public bool UpdateStatus(int poID, int newStatusID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.PurchaseOrder_UpdateStatus))
            {
                clsDBHelper.AddParam(cmd, "@POID", poID);
                clsDBHelper.AddParam(cmd, "@NewStatusID", newStatusID);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>
        /// سداد دفعة لمورد + تسجيلها في الخزنة.
        /// paymentTransactionTypeID = الـ ID بتاع "سداد مورد" في TRANSACTION_TYPES.
        /// </summary>
        public bool UpdatePayment(int poID, decimal additionalPaid, int paymentMethodID,
                                  int paymentTransactionTypeID, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.PurchaseOrder_UpdatePayment))
            {
                clsDBHelper.AddParam(cmd, "@POID", poID);
                clsDBHelper.AddParam(cmd, "@AdditionalPaid", additionalPaid);
                clsDBHelper.AddParam(cmd, "@PaymentMethodID", paymentMethodID);
                clsDBHelper.AddParam(cmd, "@PaymentTransactionTypeID", paymentTransactionTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }
    }

}