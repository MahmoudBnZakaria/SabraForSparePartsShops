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
    public class clsInventoryDAL
    {

        private InventoryItem MapItem(SqlDataReader r) => new InventoryItem
        {
            PartID = (int)r["Part_ID"],

            Barcode = r["Barcode"] == DBNull.Value ? null : r["Barcode"].ToString(),

            TechnicalNumber = r["Technical_Number"] == DBNull.Value ? null : r["Technical_Number"].ToString(),

            PartName = r["Part_Name"].ToString(),

            CategoryID = r["Category_ID"] == DBNull.Value ? (int?)null : (int)r["Category_ID"],
            CategoryName = r["Category_Name"] == DBNull.Value ? null : r["Category_Name"].ToString(),

            BrandID = r["Brand_ID"] == DBNull.Value ? (int?)null : (int)r["Brand_ID"],
            BrandName = r["Brand_Name"] == DBNull.Value ? null : r["Brand_Name"].ToString(),

            UnitID = r["Unit_ID"] == DBNull.Value ? (int?)null : (int)r["Unit_ID"],
            UnitName = r["Unit_Name"] == DBNull.Value ? null : r["Unit_Name"].ToString(),

            PurchasePrice = (decimal)r["Purchase_Price"],

            MarkupPercent = (decimal)r["Markup_Percent"],

            SellingPrice = (decimal)r["Selling_Price"],

            CurrentStock = (int)r["Current_Stock"],

            MinLimit = (int)r["Min_Limit"],

            CrossRefID = r["Cross_Ref_ID"] == DBNull.Value ? (int?)null : (int)r["Cross_Ref_ID"],

            SupplierID = r["Supplier_ID"] == DBNull.Value ? (int?)null : (int)r["Supplier_ID"],
            SupplierName = r["Supplier_Name"] == DBNull.Value ? null : r["Supplier_Name"].ToString(),

            IsDeleted = (bool)r["Is_Deleted"],

            CreatedAt = (DateTime)r["Created_At"],

            UpdatedAt = (DateTime)r["Updated_At"]
        };

        private const string _selectSql = @"
            SELECT i.*,
                   c.Category_Name, b.Brand_Name, u.Unit_Name, s.Supplier_Name
            FROM INVENTORY i
            LEFT JOIN CATEGORIES c ON i.Category_ID = c.Category_ID
            LEFT JOIN BRANDS     b ON i.Brand_ID    = b.Brand_ID
            LEFT JOIN UNITS      u ON i.Unit_ID     = u.Unit_ID
            LEFT JOIN SUPPLIERS  s ON i.Supplier_ID = s.Supplier_ID
            WHERE i.Is_Deleted = 0";

        public List<InventoryItem> GetAll() { 
            List <InventoryItem> list = new List <InventoryItem>();

            using (var conn = clsConnectionManager.GetConnection()) {

                using (var cmd = new SqlCommand(_selectSql + " ORDER BY i.Part_Name", conn)) {

                    conn.Open();
                    using ( var r = cmd.ExecuteReader()) {
                        while (r.Read())
                            list.Add(MapItem(r));
                    }
                }
            }

                return list;
        }

        public InventoryItem GetByID(int partID) {
            using (var conn = clsConnectionManager.GetConnection()) { 
                using(var cmd = new SqlCommand(_selectSql + "AND i.Part_ID = @ID",conn )){
                    cmd.Parameters.AddWithValue("@ID", partID);

                    conn.Open();
                    using (var r = cmd.ExecuteReader()) { 
                        return r.Read() ? MapItem(r): null;
                    }
                }
            }
        }
        public InventoryItem GetByBarcode(string barcode)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(_selectSql + " AND i.Barcode = @Barcode", conn))
            {
                cmd.Parameters.AddWithValue("@Barcode", barcode);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapItem(r) : null;
            }
        }

        public List<InventoryItem> Search(string keyword, int?categoryID = null, int? brandID = null, string stockFilter = null) { 
            var list = new List<InventoryItem>();
            var sql = new System.Text.StringBuilder(_selectSql);

            if (!String.IsNullOrWhiteSpace(keyword))
                sql.Append("AND (i.Part_Name LIKE @kw OR i.Barcode LIKE @kw OR i.Technical_Number LIKE @kw");
            if (categoryID.HasValue)
                sql.Append("AND i.Category_ID = @CatID");
            if (brandID.HasValue)
                sql.Append("AND i.Brand_ID = @BrandID");
            if (stockFilter == "low")
                sql.Append("AND i.Current_Stock <= i.Min_Limit AND i.Current_Stock > 0");
            else if (stockFilter == "zero")
                sql.Append("AND i.Current_Stock = 0 ");
            sql.Append("ORDER BY i.Part_Name");

            using (var conn = clsConnectionManager.GetConnection()){
                using (var cmd = new SqlCommand(sql.ToString(),conn)) {
                    if (!string.IsNullOrWhiteSpace(keyword)) 
                        cmd.Parameters.AddWithValue("@kw", keyword);
                    if (categoryID.HasValue)
                        cmd.Parameters.AddWithValue("@CatID", categoryID);
                    if (brandID.HasValue)
                        cmd.Parameters.AddWithValue("@BrandID", brandID);
                    conn.Open();
                    using (var r = cmd.ExecuteReader()) {
                        while (r.Read())
                            list.Add(MapItem(r));
                    }
                } 
            }

            return list;
        }

        public int Add(InventoryItem item)
        {
            const string sql = @"
                INSERT INTO INVENTORY
                    (Barcode, Technical_Number, Part_Name, Category_ID, Brand_ID, Unit_ID,
                     Purchase_Price, Markup_Percent, Selling_Price, Current_Stock, Min_Limit,
                     Cross_Ref_ID, Supplier_ID)
                VALUES
                    (@Barcode, @TechNum, @Name, @CatID, @BrandID, @UnitID,
                     @PurPrice, @Markup, @SellPrice, @Stock, @MinLimit
                    , @CrossRef, @SupplierID);
                SELECT SCOPE_IDENTITY();";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Barcode", (object)item.Barcode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TechNum", (object)item.TechnicalNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Name", item.PartName);
                cmd.Parameters.AddWithValue("@CatID", (object)item.CategoryID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BrandID", (object)item.BrandID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UnitID", (object)item.UnitID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PurPrice", item.PurchasePrice);
                cmd.Parameters.AddWithValue("@Markup", item.MarkupPercent);
                cmd.Parameters.AddWithValue("@SellPrice", item.SellingPrice);
                cmd.Parameters.AddWithValue("@Stock", item.CurrentStock);
                cmd.Parameters.AddWithValue("@MinLimit", item.MinLimit);
                cmd.Parameters.AddWithValue("@CrossRef", (object)item.CrossRefID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SupplierID", (object)item.SupplierID ?? DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Update(InventoryItem item)
        {
            const string sql = @"
                UPDATE INVENTORY SET
                    Barcode          = @Barcode,
                    Technical_Number = @TechNum,
                    Part_Name        = @Name,
                    Category_ID      = @CatID,
                    Brand_ID         = @BrandID,
                    Unit_ID          = @UnitID,
                    Purchase_Price   = @PurPrice,
                    Markup_Percent   = @Markup,
                    Selling_Price    = @SellPrice,
                    Min_Limit        = @MinLimit,
                    Cross_Ref_ID     = @CrossRef,
                    Supplier_ID      = @SupplierID,
                    Updated_At       = GETDATE()
                WHERE Part_ID = @ID";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", item.PartID);
                cmd.Parameters.AddWithValue("@Barcode", (object)item.Barcode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TechNum", (object)item.TechnicalNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Name", item.PartName);
                cmd.Parameters.AddWithValue("@CatID", (object)item.CategoryID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BrandID", (object)item.BrandID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UnitID", (object)item.UnitID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PurPrice", item.PurchasePrice);
                cmd.Parameters.AddWithValue("@Markup", item.MarkupPercent);
                cmd.Parameters.AddWithValue("@SellPrice", item.SellingPrice);
                cmd.Parameters.AddWithValue("@MinLimit", item.MinLimit);
                cmd.Parameters.AddWithValue("@CrossRef", (object)item.CrossRefID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SupplierID", (object)item.SupplierID ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool SoftDelete(int partID) {
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand("Update Inventory Set Is_Deleted = 1 , Updated_At = GETDATE() WHERE Part_ID = @ID", conn)) {
                    cmd.Parameters.AddWithValue("@partID", partID);
                    conn.Open ();
                    return cmd.ExecuteNonQuery () > 0;

                }

            }
        }

        public bool UpdateStock(int partID, int newStock, SqlTransaction transaction = null)
        {
            var conn = transaction?.Connection ?? clsConnectionManager.GetConnection();
            bool ownConn = transaction == null;
            try
            {
                using (var cmd = new SqlCommand("UPDATE INVENTORY SET Current_Stock = @Stock, Updated_At = GETDATE() WHERE Part_ID = @ID", conn))
                {
                    if (transaction != null) cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@Stock", newStock);
                    cmd.Parameters.AddWithValue("@ID", partID);
                    if (ownConn) conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { if (ownConn) conn.Dispose(); }
        }

        public bool UpdatePrice(int partID, decimal newSellingPrice) {
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand("UPDATE Inventory SET Selling_Price = @Price , Updated_At = GETDATE(), WHERE Part_ID = @ID",conn)) {
                    cmd.Parameters.AddWithValue("@Price", newSellingPrice);
                    cmd.Parameters.AddWithValue("@ID", partID);
                    conn.Open ();
                    return cmd.ExecuteNonQuery() > 0 ;
                }
            }
        }

        public bool BarcodeExists(string barcode, int? excludePartID = null) {
            var sql = "SELECT COUNT(1) FROM Inventory WHERE Barcode = @Barcode AND Is_Deleted = 0";
            if (excludePartID.HasValue) sql += "AND Part_ID <> @ExID";
            using (var conn = clsConnectionManager.GetConnection()) {
                using (var cmd = new SqlCommand(sql,conn)) {
                    cmd.Parameters.AddWithValue("@Barcode", barcode);
                    if (excludePartID.HasValue)
                        cmd.Parameters.AddWithValue("@ExID", excludePartID);
                    conn.Open ();
                    return (int)cmd.ExecuteScalar() > 0 ;
                }
            }
        }
    }
}
