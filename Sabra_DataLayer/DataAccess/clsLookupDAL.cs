using Microsoft.Data.SqlClient;
using Sabra.DataLayer;
using Sabra.DataLayer.Models;


namespace Sabra.DataLayer.DataAccess
{
    public class clsLookupDAL
    {
             // ── Employee Positions ──────────────────────────────────
            public List<EmployeePosition> GetAllPositions()
            {
            
                var list = new List<EmployeePosition>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Position_ID, Position_Name FROM EMPLOYEE_POSITIONS ORDER BY Position_Name", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new EmployeePosition { PositionID = (int)reader["Position_ID"], PositionName = reader["Position_Name"].ToString() });
                }
                return list;
            }

            public bool AddPosition(string name)
            {
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("INSERT INTO EMPLOYEE_POSITIONS (Position_Name) VALUES (@Name)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            // ── Payment Methods ─────────────────────────────────────
            public List<PaymentMethod> GetAllPaymentMethods()
            {
                var list = new List<PaymentMethod>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Payment_Method_ID, Method_Name FROM PAYMENT_METHODS ORDER BY Method_Name", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new PaymentMethod { PaymentMethodID = (int)reader["Payment_Method_ID"], MethodName = reader["Method_Name"].ToString() });
                }
                return list;
            }

            // ── Payment Status ──────────────────────────────────────
            public List<PaymentStatus> GetAllPaymentStatuses()
            {
                var list = new List<PaymentStatus>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Status_ID, Status_Name FROM PAYMENT_STATUS ORDER BY Status_ID", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new PaymentStatus { StatusID = (int)reader["Status_ID"], StatusName = reader["Status_Name"].ToString() });
                }
                return list;
            }

            // ── Transaction Types ───────────────────────────────────
            public List<TransactionType> GetAllTransactionTypes()
            {
                var list = new List<TransactionType>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Transaction_Type_ID, Type_Name FROM TRANSACTION_TYPES", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new TransactionType { TransactionTypeID = (int)reader["Transaction_Type_ID"], TypeName = reader["Type_Name"].ToString() });
                }
                return list;
            }

            // ── Advance Status ──────────────────────────────────────
            public List<AdvanceStatus> GetAllAdvanceStatuses()
            {
                var list = new List<AdvanceStatus>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Status_ID, Status_Name FROM ADVANCE_STATUS ORDER BY Status_ID", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new AdvanceStatus { StatusID = (int)reader["Status_ID"], StatusName = reader["Status_Name"].ToString() });
                }
                return list;
            }

            // ── Item Status ─────────────────────────────────────────
            public List<ItemStatus> GetAllItemStatuses()
            {
                var list = new List<ItemStatus>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Status_ID, Status_Name FROM ITEM_STATUS ORDER BY Status_ID", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new ItemStatus { StatusID = (int)reader["Status_ID"], StatusName = reader["Status_Name"].ToString() });
                }
                return list;
            }

            // ── Movement Types ──────────────────────────────────────
            public List<MovementType> GetAllMovementTypes()
            {
                var list = new List<MovementType>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Movement_Type_ID, Type_Name FROM MOVEMENT_TYPES ORDER BY Movement_Type_ID", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new MovementType { MovementTypeID = (int)reader["Movement_Type_ID"], TypeName = reader["Type_Name"].ToString() });
                }
                return list;
            }

            // ── Expense Categories ──────────────────────────────────
            public List<ExpenseCategory> GetAllExpenseCategories()
            {
                var list = new List<ExpenseCategory>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Category_ID, Category_Name FROM EXPENSE_CATEGORIES ORDER BY Category_Name", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new ExpenseCategory { CategoryID = (int)reader["Category_ID"], CategoryName = reader["Category_Name"].ToString() });
                }
                return list;
            }

            public bool AddExpenseCategory(string name)
            {
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("INSERT INTO EXPENSE_CATEGORIES (Category_Name) VALUES (@Name)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            // ── Customer Types ──────────────────────────────────────
            public List<CustomerType> GetAllCustomerTypes()
            {
                var list = new List<CustomerType>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Customer_Type_ID, Type_Name FROM CUSTOMER_TYPES ORDER BY Type_Name", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new CustomerType { CustomerTypeID = (int)reader["Customer_Type_ID"], TypeName = reader["Type_Name"].ToString() });
                }
                return list;
            }

            // ── Purchase Order Status ───────────────────────────────
            public List<PurchaseOrderStatus> GetAllPOStatuses()
            {
                var list = new List<PurchaseOrderStatus>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Status_ID, Status_Name FROM PURCHASE_ORDER_STATUS ORDER BY Status_ID", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new PurchaseOrderStatus { StatusID = (int)reader["Status_ID"], StatusName = reader["Status_Name"].ToString() });
                }
                return list;
            }

            // ── Units ───────────────────────────────────────────────
            public List<Unit> GetAllUnits()
            {
                var list = new List<Unit>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Unit_ID, Unit_Name FROM UNITS ORDER BY Unit_Name", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new Unit { UnitID = (int)reader["Unit_ID"], UnitName = reader["Unit_Name"].ToString() });
                }
                return list;
            }

            public bool AddUnit(string name)
            {
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("INSERT INTO UNITS (Unit_Name) VALUES (@Name)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            // ── Categories ──────────────────────────────────────────
            public List<Category> GetAllCategories()
            {
                var list = new List<Category>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Category_ID, Category_Name FROM CATEGORIES ORDER BY Category_Name", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new Category { CategoryID = (int)reader["Category_ID"], CategoryName = reader["Category_Name"].ToString() });
                }
                return list;
            }

            public bool AddCategory(string name)
            {
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("INSERT INTO CATEGORIES (Category_Name) VALUES (@Name)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            // ── Brands ──────────────────────────────────────────────
            public List<Brand> GetAllBrands()
            {
                var list = new List<Brand>();
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("SELECT Brand_ID, Brand_Name, Country FROM BRANDS ORDER BY Brand_Name", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(new Brand
                            {
                                BrandID = (int)reader["Brand_ID"],
                                BrandName = reader["Brand_Name"].ToString(),
                                Country = reader["Country"] == DBNull.Value ? null : reader["Country"].ToString()
                            });
                }
                return list;
            }

            public bool AddBrand(string name, string country = null)
            {
                using (var conn = clsConnectionManager.GetConnection())
                using (var cmd = new SqlCommand("INSERT INTO BRANDS (Brand_Name, Country) VALUES (@Name, @Country)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Country", (object)country ?? DBNull.Value);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
    }

}