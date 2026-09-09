using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

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

        public List<InventoryItem> GetAll()
        {
            var list = new List<InventoryItem>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_GetAll"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapItem(r));
            }
            return list;
        }

        public InventoryItem GetByID(int partID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_GetByID"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapItem(r) : null;
            }
        }

        public InventoryItem GetByBarcode(string barcode)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_GetByBarcode"))
            {
                clsDBHelper.AddParam(cmd, "@Barcode", barcode);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapItem(r) : null;
            }
        }

        public List<InventoryItem> Search(string keyword = null, int? categoryID = null, int? brandID = null, string stockFilter = null)
        {
            var list = new List<InventoryItem>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_Search"))
            {
                clsDBHelper.AddParam(cmd, "@Keyword", keyword);
                clsDBHelper.AddParam(cmd, "@CategoryID", categoryID);
                clsDBHelper.AddParam(cmd, "@BrandID", brandID);
                clsDBHelper.AddParam(cmd, "@StockFilter", stockFilter);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapItem(r));
            }
            return list;
        }

        public int Add(InventoryItem item)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_Add"))
            {
                clsDBHelper.AddParam(cmd, "@Barcode", item.Barcode);
                clsDBHelper.AddParam(cmd, "@TechnicalNumber", item.TechnicalNumber);
                clsDBHelper.AddParam(cmd, "@PartName", item.PartName);
                clsDBHelper.AddParam(cmd, "@CategoryID", item.CategoryID);
                clsDBHelper.AddParam(cmd, "@BrandID", item.BrandID);
                clsDBHelper.AddParam(cmd, "@UnitID", item.UnitID);
                clsDBHelper.AddParam(cmd, "@PurchasePrice", item.PurchasePrice);
                clsDBHelper.AddParam(cmd, "@MarkupPercent", item.MarkupPercent);
                clsDBHelper.AddParam(cmd, "@SellingPrice", item.SellingPrice);
                clsDBHelper.AddParam(cmd, "@CurrentStock", item.CurrentStock);
                clsDBHelper.AddParam(cmd, "@MinLimit", item.MinLimit);
                clsDBHelper.AddParam(cmd, "@CrossRefID", item.CrossRefID);
                clsDBHelper.AddParam(cmd, "@SupplierID", item.SupplierID);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewPartID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outId.Value);
            }
        }

        public bool Update(InventoryItem item)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_Update"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", item.PartID);
                clsDBHelper.AddParam(cmd, "@Barcode", item.Barcode);
                clsDBHelper.AddParam(cmd, "@TechnicalNumber", item.TechnicalNumber);
                clsDBHelper.AddParam(cmd, "@PartName", item.PartName);
                clsDBHelper.AddParam(cmd, "@CategoryID", item.CategoryID);
                clsDBHelper.AddParam(cmd, "@BrandID", item.BrandID);
                clsDBHelper.AddParam(cmd, "@UnitID", item.UnitID);
                clsDBHelper.AddParam(cmd, "@PurchasePrice", item.PurchasePrice);
                clsDBHelper.AddParam(cmd, "@MarkupPercent", item.MarkupPercent);
                clsDBHelper.AddParam(cmd, "@SellingPrice", item.SellingPrice);
                clsDBHelper.AddParam(cmd, "@MinLimit", item.MinLimit);
                clsDBHelper.AddParam(cmd, "@CrossRefID", item.CrossRefID);
                clsDBHelper.AddParam(cmd, "@SupplierID", item.SupplierID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool SoftDelete(int partID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_SoftDelete"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool AdjustStock(int partID, int delta, int movementTypeID, int userID, string remarks = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_AdjustStock"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                clsDBHelper.AddParam(cmd, "@Delta", delta);
                clsDBHelper.AddParam(cmd, "@MovementTypeID", movementTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Remarks", remarks);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdatePrice(int partID, decimal newSellingPrice)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_UpdatePrice"))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                clsDBHelper.AddParam(cmd, "@NewSellingPrice", newSellingPrice);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool BarcodeExists(string barcode, int? excludePartID = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Inventory_BarcodeExists"))
            {
                clsDBHelper.AddParam(cmd, "@Barcode", barcode);
                clsDBHelper.AddParam(cmd, "@ExcludePartID", excludePartID);
                var outExists = clsDBHelper.AddOutputParam(cmd, "@Exists", SqlDbType.Bit);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetBool(outExists);
            }
        }

        public decimal CalculateSellingPrice(decimal purchasePrice, decimal markupPercent)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand("SELECT dbo.fn_CalculateSellingPrice(@PurchasePrice, @MarkupPercent)", conn))
            {
                clsDBHelper.AddParam(cmd, "@PurchasePrice", purchasePrice);
                clsDBHelper.AddParam(cmd, "@MarkupPercent", markupPercent);
                conn.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }
    }
}