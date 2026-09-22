using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsInventoryDAL
    {
        private InventoryItem MapItem(SqlDataReader r) => new InventoryItem
        {
            PartID = r.GetInt("Part_ID"),
            Barcode = r.GetStr("Barcode"),
            TechnicalNumber = r.GetStr("Technical_Number"),
            PartName = r.GetStr("Part_Name"),
            CategoryID = r.GetIntOrNull("Category_ID"),
            CategoryName = r.GetStr("Category_Name"),
            BrandID = r.GetIntOrNull("Brand_ID"),
            BrandName = r.GetStr("Brand_Name"),
            UnitID = r.GetIntOrNull("Unit_ID"),
            UnitName = r.GetStr("Unit_Name"),
            PurchasePrice = r.GetDec("Purchase_Price"),
            MarkupPercent = r.GetDec("Markup_Percent"),
            SellingPrice = r.GetDec("Selling_Price"),
            CurrentStock = r.GetInt("Current_Stock"),
            MinLimit = r.GetInt("Min_Limit"),
            CrossRefID = r.GetIntOrNull("Cross_Ref_ID"),
            SupplierID = r.GetIntOrNull("Supplier_ID"),
            SupplierName = r.GetStr("Supplier_Name"),
            IsDeleted = r.GetBool("Is_Deleted"),
            CreatedAt = r.GetDate("Created_At"),
            UpdatedAt = r.GetDate("Updated_At"),
            Notes = r.GetStr("Notes")
        };

        public List<InventoryItem> GetAll()
        {
            var list = new List<InventoryItem>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Inventory_GetAll))
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
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Inventory_GetByID))
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
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Inventory_GetByBarcode))
            {
                clsDBHelper.AddParam(cmd, "@Barcode", barcode);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? MapItem(r) : null;
            }
        }

        /// <summary>stockFilter: "low" أو "zero" أو null.</summary>
        public List<InventoryItem> Search(string keyword = null, int? categoryID = null,
                                          int? brandID = null, string stockFilter = null)
        {
            var list = new List<InventoryItem>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Inventory_Search))
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

        /// <summary>بترجع الـ Part_ID الجديد.</summary>
        public int Add(InventoryItem item)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Inventory_Add))
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
                return clsDBHelper.GetInt(outId);
            }
        }

        /// <summary>ملاحظة: الـ SP مش بتعدّل الرصيد (Current_Stock) — استخدم AdjustStock.</summary>
        public bool Update(InventoryItem item)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Inventory_Update))
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
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        public bool SoftDelete(int partID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Inventory_SoftDelete))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>delta موجب = إضافة للمخزون، سالب = خصم. بيتسجل في Audit_Log تلقائيًا.</summary>
        public bool AdjustStock(int partID, int delta, int movementTypeID, int userID, string remarks = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Inventory_AdjustStock))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                clsDBHelper.AddParam(cmd, "@Delta", delta);
                clsDBHelper.AddParam(cmd, "@MovementTypeID", movementTypeID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Remarks", remarks);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>بتغيّر سعر البيع وبتقفل سجل السعر القديم في Price_History. @UserID مطلوب.</summary>
        public bool UpdatePrice(int partID, decimal newSellingPrice, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Inventory_UpdatePrice))
            {
                clsDBHelper.AddParam(cmd, "@PartID", partID);
                clsDBHelper.AddParam(cmd, "@NewSellingPrice", newSellingPrice);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        public bool BarcodeExists(string barcode, int? excludePartID = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Inventory_BarcodeExists))
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
            using (var cmd = clsDBHelper.CreateTextCommand(conn, SP.Fn_CalculateSellingPrice))
            {
                clsDBHelper.AddParam(cmd, "@PurchasePrice", purchasePrice);
                clsDBHelper.AddParam(cmd, "@MarkupPercent", markupPercent);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? 0m : Convert.ToDecimal(result);
            }
        }
    }

}