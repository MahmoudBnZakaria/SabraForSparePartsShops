using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsPurchaseOrderDAL
    {
        private PurchaseOrder MapPO(SqlDataReader r) => new PurchaseOrder
        {
            POID = (int)r["PO_ID"],
            SupplierID = (int)r["Supplier_ID"],
            SupplierName = r["Supplier_Name"].ToString(),
            EmployeeID = (int)r["Employee_ID"],
            EmployeeName = r["Employee_Name"].ToString(),
            OrderDate = (DateTime)r["Order_Date"],
            TotalAmount = (decimal)r["Total_Amount"],
            PaidAmount = (decimal)r["Paid_Amount"],
            Remaining = (decimal)r["Remaining"],
            StatusID = (int)r["Status_ID"],
            StatusName = r["Status_Name"].ToString(),
            Notes = r["Notes"] == DBNull.Value ? null : r["Notes"].ToString(),
            CreatedAt = (DateTime)r["Created_At"]
        };

        public List<PurchaseOrder> GetAll(int? supplierID = null, int? statusID = null)
        {
            var list = new List<PurchaseOrder>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_PurchaseOrder_GetAll"))
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

        public PurchaseOrder GetByID(int poID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_PurchaseOrder_GetByID"))
            {
                clsDBHelper.AddParam(cmd, "@POID", poID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapPO(r) : null;
            }
        }

        /// <summary>مفيش SP لجلب التفاصيل في الملف الأصلي، فسبناها Direct Query.</summary>

        public List<PurchaseOrderDetail> GetDetails(int poID)
        {
            var list = new List<PurchaseOrderDetail>();

            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(
                conn, "sp_PurchaseOrder_GetDetails"))
            {
                clsDBHelper.AddParam(cmd, "@POID", poID);

                conn.Open();

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new PurchaseOrderDetail
                        {
                            DetailID = (int)r["Detail_ID"],
                            POID = (int)r["PO_ID"],
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
        /// <summary>
        /// بتنشئ أمر شراء كامل بسطر واحد باستخدام TVP (PODetailTableType) بدل
        /// حلقة INSERTs في C# جوه Transaction محلية.
        /// </summary>
        public int Add(PurchaseOrder po)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_PurchaseOrder_Add"))
            {
                clsDBHelper.AddParam(cmd, "@SupplierID", po.SupplierID);
                clsDBHelper.AddParam(cmd, "@EmployeeID", po.EmployeeID);
                clsDBHelper.AddParam(cmd, "@OrderDate", po.OrderDate);
                clsDBHelper.AddParam(cmd, "@PaidAmount", po.PaidAmount);
                clsDBHelper.AddParam(cmd, "@StatusID", po.StatusID);
                clsDBHelper.AddParam(cmd, "@Notes", po.Notes);

                var detailsTable = clsDBHelper.BuildPODetailTable(po.Details);
                clsDBHelper.AddTableValuedParam(cmd, "@Details", "dbo.PODetailTableType", detailsTable);

                var outId = clsDBHelper.AddOutputParam(cmd, "@NewPOID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }

        public bool Receive(int poID, int receivedStatusID, int purchaseMovementTypeID, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_PurchaseOrder_Receive"))
            {
                clsDBHelper.AddParam(cmd, "@POID", poID);
                clsDBHelper.AddParam(cmd, "@ReceivedStatusID", receivedStatusID);
                clsDBHelper.AddParam(cmd, "@PurchaseMovementTypeID", purchaseMovementTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateStatus(int poID, int newStatusID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_PurchaseOrder_UpdateStatus"))
            {
                clsDBHelper.AddParam(cmd, "@POID", poID);
                clsDBHelper.AddParam(cmd, "@NewStatusID", newStatusID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdatePayment(int poID, decimal additionalPaid)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_PurchaseOrder_UpdatePayment"))
            {
                clsDBHelper.AddParam(cmd, "@POID", poID);
                clsDBHelper.AddParam(cmd, "@AdditionalPaid", additionalPaid);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}