using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System.Collections.Generic;

namespace Sabra.DataLayer.DataAccess
{
    public class clsLookupDAL
    {
        // ── Employee Positions ──────────────────────────────────────
        public List<EmployeePosition> GetAllPositions()
        {
            var list = new List<EmployeePosition>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllPositions"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new EmployeePosition
                        {
                            PositionID = (int)r["Position_ID"],
                            PositionName = r["Position_Name"].ToString()
                        });
            }
            return list;
        }

        public bool AddPosition(string name)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_AddPosition"))
            {
                clsDBHelper.AddParam(cmd, "@Name", name);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ── Payment Methods ──────────────────────────────────────────
        public List<PaymentMethod> GetAllPaymentMethods()
        {
            var list = new List<PaymentMethod>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllPaymentMethods"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new PaymentMethod
                        {
                            PaymentMethodID = (int)r["Payment_Method_ID"],
                            MethodName = r["Method_Name"].ToString()
                        });
            }
            return list;
        }

        // ── Payment Status ───────────────────────────────────────────
        public List<PaymentStatus> GetAllPaymentStatuses()
        {
            var list = new List<PaymentStatus>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllPaymentStatuses"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new PaymentStatus
                        {
                            StatusID = (int)r["Status_ID"],
                            StatusName = r["Status_Name"].ToString()
                        });
            }
            return list;
        }

        // ── Transaction Types ─────────────────────────────────────────
        public List<TransactionType> GetAllTransactionTypes()
        {
            var list = new List<TransactionType>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllTransactionTypes"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new TransactionType
                        {
                            TransactionTypeID = (int)r["Transaction_Type_ID"],
                            TypeName = r["Type_Name"].ToString()
                        });
            }
            return list;
        }

        // ── Advance Status ────────────────────────────────────────────
        public List<AdvanceStatus> GetAllAdvanceStatuses()
        {
            var list = new List<AdvanceStatus>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllAdvanceStatuses"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new AdvanceStatus
                        {
                            StatusID = (int)r["Status_ID"],
                            StatusName = r["Status_Name"].ToString()
                        });
            }
            return list;
        }

        // ── Item Status ───────────────────────────────────────────────
        public List<ItemStatus> GetAllItemStatuses()
        {
            var list = new List<ItemStatus>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllItemStatuses"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new ItemStatus
                        {
                            StatusID = (int)r["Status_ID"],
                            StatusName = r["Status_Name"].ToString()
                        });
            }
            return list;
        }

        // ── Movement Types ────────────────────────────────────────────
        public List<MovementType> GetAllMovementTypes()
        {
            var list = new List<MovementType>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllMovementTypes"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new MovementType
                        {
                            MovementTypeID = (int)r["Movement_Type_ID"],
                            TypeName = r["Type_Name"].ToString()
                        });
            }
            return list;
        }

        // ── Expense Categories ────────────────────────────────────────
        public List<ExpenseCategory> GetAllExpenseCategories()
        {
            var list = new List<ExpenseCategory>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllExpenseCategories"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new ExpenseCategory
                        {
                            CategoryID = (int)r["Category_ID"],
                            CategoryName = r["Category_Name"].ToString()
                        });
            }
            return list;
        }

        public bool AddExpenseCategory(string name)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_AddExpenseCategory"))
            {
                clsDBHelper.AddParam(cmd, "@Name", name);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ── Customer Types ────────────────────────────────────────────
        public List<CustomerType> GetAllCustomerTypes()
        {
            var list = new List<CustomerType>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllCustomerTypes"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new CustomerType
                        {
                            CustomerTypeID = (int)r["Customer_Type_ID"],
                            TypeName = r["Type_Name"].ToString()
                        });
            }
            return list;
        }

        // ── Purchase Order Status ─────────────────────────────────────
        public List<PurchaseOrderStatus> GetAllPOStatuses()
        {
            var list = new List<PurchaseOrderStatus>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllPOStatuses"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new PurchaseOrderStatus
                        {
                            StatusID = (int)r["Status_ID"],
                            StatusName = r["Status_Name"].ToString()
                        });
            }
            return list;
        }

        // ── Units ─────────────────────────────────────────────────────
        public List<Unit> GetAllUnits()
        {
            var list = new List<Unit>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllUnits"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new Unit
                        {
                            UnitID = (int)r["Unit_ID"],
                            UnitName = r["Unit_Name"].ToString()
                        });
            }
            return list;
        }

        public bool AddUnit(string name)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_AddUnit"))
            {
                clsDBHelper.AddParam(cmd, "@Name", name);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ── Categories ────────────────────────────────────────────────
        public List<Category> GetAllCategories()
        {
            var list = new List<Category>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllCategories"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new Category
                        {
                            CategoryID = (int)r["Category_ID"],
                            CategoryName = r["Category_Name"].ToString()
                        });
            }
            return list;
        }

        public bool AddCategory(string name)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_AddCategory"))
            {
                clsDBHelper.AddParam(cmd, "@Name", name);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ── Brands ────────────────────────────────────────────────────
        public List<Brand> GetAllBrands()
        {
            var list = new List<Brand>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_GetAllBrands"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new Brand
                        {
                            BrandID = (int)r["Brand_ID"],
                            BrandName = r["Brand_Name"].ToString(),
                            Country = r["Country"] == System.DBNull.Value ? null : r["Country"].ToString()
                        });
            }
            return list;
        }

        public bool AddBrand(string name, string country = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Lookup_AddBrand"))
            {
                clsDBHelper.AddParam(cmd, "@Name", name);
                clsDBHelper.AddParam(cmd, "@Country", country);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}