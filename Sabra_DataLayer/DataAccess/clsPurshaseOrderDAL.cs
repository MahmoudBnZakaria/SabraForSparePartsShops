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
    public class clsPurshaseOrderDAL
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

        private const string _selectSql = @"
            SELECT po.*, s.Supplier_Name, e.Full_Name AS Employee_Name, pos2.Status_Name
            FROM PURCHASE_ORDERS po
            JOIN SUPPLIERS               s    ON po.Supplier_ID = s.Supplier_ID
            JOIN EMPLOYEES               e    ON po.Employee_ID = e.Employee_ID
            JOIN PURCHASE_ORDER_STATUS   pos2 ON po.Status_ID  = pos2.Status_ID";
        public List<PurchaseOrder> GetAll(int? supplierID = null, int? statusID = null)
        {
            var list = new List<PurchaseOrder>();
            var sql = new System.Text.StringBuilder(_selectSql + " WHERE 1=1");
            if (supplierID.HasValue) sql.Append(" AND po.Supplier_ID = @SupID");
            if (statusID.HasValue) sql.Append(" AND po.Status_ID   = @StatusID");
            sql.Append(" ORDER BY po.Order_Date DESC");
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql.ToString(), conn))
            {
                if (supplierID.HasValue) cmd.Parameters.AddWithValue("@SupID", supplierID.Value);
                if (statusID.HasValue) cmd.Parameters.AddWithValue("@StatusID", statusID.Value);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(MapPO(r));
            }
            return list;
        }
        public PurchaseOrder GetByID(int poID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(_selectSql + " WHERE po.PO_ID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", poID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapPO(r) : null;
            }
        }

        public List<PurchaseOrderDetail> GetDetails(int poID)
        {
            var list = new List<PurchaseOrderDetail>();
            const string sql = @"
                SELECT pod.*, i.Part_Name FROM PURCHASE_ORDER_DETAILS pod
                JOIN INVENTORY i ON pod.Part_ID = i.Part_ID
                WHERE pod.PO_ID = @POID";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@POID", poID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
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
            return list;
        }

        public int Add(PurchaseOrder po)
        {
            using (var conn = clsConnectionManager.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        const string poSql = @"
                            INSERT INTO PURCHASE_ORDERS (Supplier_ID, Employee_ID, Order_Date, Total_Amount, Paid_Amount, Status_ID, Notes)
                            VALUES (@SupID, @EmpID, @Date, @Total, @Paid, @StatusID, @Notes);
                            SELECT SCOPE_IDENTITY();";
                        int poID;
                        using (var cmd = new SqlCommand(poSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@SupID", po.SupplierID);
                            cmd.Parameters.AddWithValue("@EmpID", po.EmployeeID);
                            cmd.Parameters.AddWithValue("@Date", po.OrderDate);
                            cmd.Parameters.AddWithValue("@Total", po.TotalAmount);
                            cmd.Parameters.AddWithValue("@Paid", po.PaidAmount);
                            cmd.Parameters.AddWithValue("@StatusID", po.StatusID);
                            cmd.Parameters.AddWithValue("@Notes", (object)po.Notes ?? DBNull.Value);
                            poID = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        foreach (var detail in po.Details)
                        {
                            const string detSql = @"
                                INSERT INTO PURCHASE_ORDER_DETAILS (PO_ID, Part_ID, Quantity, Unit_Price)
                                VALUES (@POID, @PartID, @Qty, @Price)";
                            using (var cmd = new SqlCommand(detSql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@POID", poID);
                                cmd.Parameters.AddWithValue("@PartID", detail.PartID);
                                cmd.Parameters.AddWithValue("@Qty", detail.Quantity);
                                cmd.Parameters.AddWithValue("@Price", detail.UnitPrice);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return poID;
                    }
                    catch { tran.Rollback(); throw; }
                }
            }
        }

        public bool UpdateStatus(int poID, int newStatusID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand("UPDATE PURCHASE_ORDERS SET Status_ID = @StatusID WHERE PO_ID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@StatusID", newStatusID);
                cmd.Parameters.AddWithValue("@ID", poID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdatePayment(int poID, decimal additionalPaid)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand("UPDATE PURCHASE_ORDERS SET Paid_Amount = Paid_Amount + @AddPaid WHERE PO_ID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@AddPaid", additionalPaid);
                cmd.Parameters.AddWithValue("@ID", poID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
