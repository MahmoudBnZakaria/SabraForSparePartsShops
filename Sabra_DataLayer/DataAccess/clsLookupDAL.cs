using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System.Collections.Generic;

namespace Sabra.DataLayer.DataAccess
{

    public class clsLookupDAL
    {
        // ── Employee Positions ────────────────────────────────────────
        public List<EmployeePosition> GetAllPositions()
        {
            var list = new List<EmployeePosition>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllPositions))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new EmployeePosition
                        {
                            PositionID = r.GetInt("Position_ID"),
                            PositionName = r.GetStr("Position_Name")
                        });
            }
            return list;
        }

        public bool AddPosition(string name)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_AddPosition))
            {
                clsDBHelper.AddParam(cmd, "@Name", name);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        // ── Payment Methods ───────────────────────────────────────────
        public List<PaymentMethod> GetAllPaymentMethods()
        {
            var list = new List<PaymentMethod>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllPaymentMethods))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new PaymentMethod
                        {
                            PaymentMethodID = r.GetInt("Payment_Method_ID"),
                            MethodName = r.GetStr("Method_Name")
                        });
            }
            return list;
        }

        // ── Payment Statuses ──────────────────────────────────────────
        public List<PaymentStatus> GetAllPaymentStatuses()
        {
            var list = new List<PaymentStatus>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllPaymentStatuses))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new PaymentStatus
                        {
                            StatusID = r.GetInt("Status_ID"),
                            StatusName = r.GetStr("Status_Name")
                        });
            }
            return list;
        }

        // ── Transaction Types ─────────────────────────────────────────
        public List<TransactionType> GetAllTransactionTypes()
        {
            var list = new List<TransactionType>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllTransactionTypes))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new TransactionType
                        {
                            TransactionTypeID = r.GetInt("Transaction_Type_ID"),
                            TypeName = r.GetStr("Type_Name")
                        });
            }
            return list;
        }

        // ── Advance Statuses ──────────────────────────────────────────
        public List<AdvanceStatus> GetAllAdvanceStatuses()
        {
            var list = new List<AdvanceStatus>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllAdvanceStatuses))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new AdvanceStatus
                        {
                            StatusID = r.GetInt("Status_ID"),
                            StatusName = r.GetStr("Status_Name")
                        });
            }
            return list;
        }

        // ── Item Statuses ─────────────────────────────────────────────
        public List<ItemStatus> GetAllItemStatuses()
        {
            var list = new List<ItemStatus>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllItemStatuses))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new ItemStatus
                        {
                            StatusID = r.GetInt("Status_ID"),
                            StatusName = r.GetStr("Status_Name")
                        });
            }
            return list;
        }

        // ── Movement Types ────────────────────────────────────────────
        public List<MovementType> GetAllMovementTypes()
        {
            var list = new List<MovementType>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllMovementTypes))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new MovementType
                        {
                            MovementTypeID = r.GetInt("Movement_Type_ID"),
                            TypeName = r.GetStr("Type_Name", "Movement_Type_Name")
                        });
            }
            return list;
        }

        // ── Expense Categories ────────────────────────────────────────
        public List<ExpenseCategory> GetAllExpenseCategories()
        {
            var list = new List<ExpenseCategory>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllExpenseCategories))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new ExpenseCategory
                        {
                            CategoryID = r.GetInt("Category_ID"),
                            CategoryName = r.GetStr("Category_Name")
                        });
            }
            return list;
        }

        public bool AddExpenseCategory(string name)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_AddExpenseCategory))
            {
                clsDBHelper.AddParam(cmd, "@Name", name);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        // ── Customer Types ────────────────────────────────────────────
        public List<CustomerType> GetAllCustomerTypes()
        {
            var list = new List<CustomerType>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllCustomerTypes))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new CustomerType
                        {
                            CustomerTypeID = r.GetInt("Customer_Type_ID"),
                            TypeName = r.GetStr("Type_Name")
                        });
            }
            return list;
        }

        // ── Purchase Order Statuses ───────────────────────────────────
        public List<PurchaseOrderStatus> GetAllPOStatuses()
        {
            var list = new List<PurchaseOrderStatus>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllPOStatuses))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new PurchaseOrderStatus
                        {
                            StatusID = r.GetInt("Status_ID"),
                            StatusName = r.GetStr("Status_Name")
                        });
            }
            return list;
        }

        // ── Units ─────────────────────────────────────────────────────
        public List<Unit> GetAllUnits()
        {
            var list = new List<Unit>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllUnits))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new Unit
                        {
                            UnitID = r.GetInt("Unit_ID"),
                            UnitName = r.GetStr("Unit_Name")
                        });
            }
            return list;
        }

        public bool AddUnit(string name)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_AddUnit))
            {
                clsDBHelper.AddParam(cmd, "@Name", name);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        // ── Categories ────────────────────────────────────────────────
        public List<Category> GetAllCategories()
        {
            var list = new List<Category>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllCategories))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new Category
                        {
                            CategoryID = r.GetInt("Category_ID"),
                            CategoryName = r.GetStr("Category_Name")
                        });
            }
            return list;
        }

        public bool AddCategory(string name)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_AddCategory))
            {
                clsDBHelper.AddParam(cmd, "@Name", name);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        // ── Brands ────────────────────────────────────────────────────
        public List<Brand> GetAllBrands()
        {
            var list = new List<Brand>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllBrands))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new Brand
                        {
                            BrandID = r.GetInt("Brand_ID"),
                            BrandName = r.GetStr("Brand_Name"),
                            Country = r.GetStr("Country")
                        });
            }
            return list;
        }

        public bool AddBrand(string name, string country = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_AddBrand))
            {
                clsDBHelper.AddParam(cmd, "@Name", name);
                clsDBHelper.AddParam(cmd, "@Country", country);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }
    }

}