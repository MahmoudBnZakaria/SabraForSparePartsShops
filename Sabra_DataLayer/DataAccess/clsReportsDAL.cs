using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;

namespace Sabra.DataLayer
{
    public class clsReportsDAL
    {
        public List<InvoiceProfitView> GetInvoiceProfits(DateTime? from = null, DateTime? to = null)
        {
            var list = new List<InvoiceProfitView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Report_InvoiceProfits"))
            {
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new InvoiceProfitView
                        {
                            InvoiceID = (int)r["Invoice_ID"],
                            DateTime = (DateTime)r["Date_Time"],
                            CustomerName = r["Customer_Name"].ToString(),
                            EmployeeName = r["Employee_Name"].ToString(),
                            FinalAmount = (decimal)r["Final_Amount"],
                            TotalCost = (decimal)r["Total_Cost"],
                            NetProfit = (decimal)r["Net_Profit"],
                            ProfitPercent = (decimal)r["Profit_Percent"],
                            PaymentStatus = r["Payment_Status"].ToString()
                        });
            }
            return list;
        }

        public List<DailyProfitView> GetDailyProfits(DateTime? from = null, DateTime? to = null)
        {
            var list = new List<DailyProfitView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Report_DailyProfits"))
            {
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new DailyProfitView
                        {
                            SaleDate = (DateTime)r["Sale_Date"],
                            InvoiceCount = (int)r["Invoice_Count"],
                            TotalRevenue = (decimal)r["Total_Revenue"],
                            TotalCost = (decimal)r["Total_Cost"],
                            NetProfit = (decimal)r["Net_Profit"],
                            TotalCollected = (decimal)r["Total_Collected"],
                            TotalRemaining = (decimal)r["Total_Remaining"]
                        });
            }
            return list;
        }

        public List<MonthlyProfitView> GetMonthlyProfits(int? year = null)
        {
            var list = new List<MonthlyProfitView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Report_MonthlyProfits"))
            {
                clsDBHelper.AddParam(cmd, "@Year", year);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new MonthlyProfitView
                        {
                            MonthYear = r["Month_Year"].ToString(),
                            InvoiceCount = (int)r["Invoice_Count"],
                            TotalRevenue = (decimal)r["Total_Revenue"],
                            TotalCost = (decimal)r["Total_Cost"],
                            NetProfit = (decimal)r["Net_Profit"],
                            TotalExpenses = (decimal)r["Total_Expenses"],
                            TotalPayroll = (decimal)r["Total_Payroll"],
                            NetProfitAfterExpenses = (decimal)r["Net_Profit_After_Expenses"]
                        });
            }
            return list;
        }

        public List<LowStockView> GetLowStockSuggestions()
        {
            var list = new List<LowStockView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Report_LowStockSuggestions"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new LowStockView
                        {
                            PartID = (int)r["Part_ID"],
                            PartName = r["Part_Name"].ToString(),
                            CategoryName = r["Category_Name"].ToString(),
                            SupplierName = r["Supplier_Name"] == DBNull.Value ? null : r["Supplier_Name"].ToString(),
                            SupplierPhone = r["Supplier_Phone"] == DBNull.Value ? null : r["Supplier_Phone"].ToString(),
                            CurrentStock = (int)r["Current_Stock"],
                            MinLimit = (int)r["Min_Limit"],
                            Shortage = (int)r["Shortage"],
                            AvgMonthlyUsage = (decimal)r["Avg_Monthly_Usage"],
                            SuggestedOrderQty = Convert.ToInt32(r["Suggested_Order_Qty"]),
                            EstimatedOrderCost = (decimal)r["Estimated_Order_Cost"]
                        });
            }
            return list;
        }

        public List<TopSellingPartView> GetTopSellingParts(int top = 10)
        {
            var list = new List<TopSellingPartView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Report_TopSellingParts"))
            {
                clsDBHelper.AddParam(cmd, "@Top", top);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new TopSellingPartView
                        {
                            PartID = r["Part_ID"] == DBNull.Value ? 0 : (int)r["Part_ID"],
                            PartName = r["Part_Name"] == DBNull.Value ? null : r["Part_Name"].ToString(),
                            CategoryName = r["Category_Name"] == DBNull.Value ? null : r["Category_Name"].ToString(),
                            BrandName = r["Brand_Name"] == DBNull.Value ? null : r["Brand_Name"].ToString(),
                            TotalQtySold = r["Total_Qty_Sold"] == DBNull.Value ? 0 : (int)r["Total_Qty_Sold"],
                            TotalRevenue = r["Total_Revenue"] == DBNull.Value ? 0m : (decimal)r["Total_Revenue"],
                            TotalProfit = r["Total_Profit"] == DBNull.Value ? 0m : (decimal)r["Total_Profit"],
                            InvoiceCount = r["Invoice_Count"] == DBNull.Value ? 0 : (int)r["Invoice_Count"],
                            CurrentStock = r["Current_Stock"] == DBNull.Value ? 0 : (int)r["Current_Stock"],
                            LastSaleDate = r["Last_Sale_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)r["Last_Sale_Date"]
                        });
            }
            return list;
        }

        public List<InventoryValuationView> GetInventoryValuation()
        {
            var list = new List<InventoryValuationView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Report_InventoryValuation"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new InventoryValuationView
                        {
                            PartID = (int)r["Part_ID"],
                            PartName = r["Part_Name"].ToString(),
                            CategoryName = r["Category_Name"] == DBNull.Value ? null : r["Category_Name"].ToString(),
                            BrandName = r["Brand_Name"] == DBNull.Value ? null : r["Brand_Name"].ToString(),
                            CurrentStock = (int)r["Current_Stock"],
                            PurchasePrice = (decimal)r["Purchase_Price"],
                            SellingPrice = (decimal)r["Selling_Price"],
                            ValueAtCost = (decimal)r["Value_At_Cost"],
                            ValueAtSelling = (decimal)r["Value_At_Selling"],
                            PotentialProfit = (decimal)r["Potential_Profit"],
                            IsLowStock = r["Is_Low_Stock"].ToString() == "نعم"
                        });
            }
            return list;
        }

        public List<TopCustomerView> GetTopCustomers(int top = 20)
        {
            var list = new List<TopCustomerView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Report_TopCustomers"))
            {
                clsDBHelper.AddParam(cmd, "@Top", top);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new TopCustomerView
                        {
                            CustomerID = (int)r["Customer_ID"],
                            CustomerName = r["Customer_Name"].ToString(),
                            PhoneNumber = r["Phone_Number"] == DBNull.Value ? null : r["Phone_Number"].ToString(),
                            CustomerType = r["Customer_Type"] == DBNull.Value ? null : r["Customer_Type"].ToString(),
                            TotalInvoices = (int)r["Total_Invoices"],
                            TotalPurchases = (decimal)r["Total_Purchases"],
                            TotalPaid = (decimal)r["Total_Paid"],
                            TotalDebt = (decimal)r["Total_Debt"],
                            AvgInvoiceValue = (decimal)r["Avg_Invoice_Value"],
                            LastPurchase = r["Last_Purchase"] == DBNull.Value ? (DateTime?)null : (DateTime)r["Last_Purchase"]
                        });
            }
            return list;
        }

        public List<EmployeePerformanceView> GetEmployeePerformance()
        {
            var list = new List<EmployeePerformanceView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Report_EmployeePerformance"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new EmployeePerformanceView
                        {
                            EmployeeID = (int)r["Employee_ID"],
                            FullName = r["Full_Name"].ToString(),
                            PositionName = r["Position_Name"].ToString(),
                            TotalInvoices = (int)r["Total_Invoices"],
                            TotalSales = r["Total_Sales"] == DBNull.Value ? 0 : (decimal)r["Total_Sales"],
                            AvgInvoiceValue = r["Avg_Invoice_Value"] == DBNull.Value ? 0 : (decimal)r["Avg_Invoice_Value"],
                            TotalDiscountsGiven = r["Total_Discounts_Given"] == DBNull.Value ? 0 : (decimal)r["Total_Discounts_Given"],
                            UniqueCustomersServed = (int)r["Unique_Customers_Served"],
                            LastInvoiceDate = r["Last_Invoice_Date"] == DBNull.Value ? (DateTime?)null : (DateTime)r["Last_Invoice_Date"],
                            ThisMonthSales = r["This_Month_Sales"] == DBNull.Value ? 0 : (decimal)r["This_Month_Sales"],
                            TotalPaidSalary = (decimal)r["Total_Paid_Salary"],
                            TotalBonuses = (decimal)r["Total_Bonuses"]
                        });
            }
            return list;
        }

        public TreasuryBalanceView GetCurrentTreasuryBalance()
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Report_CurrentTreasuryBalance"))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                        return new TreasuryBalanceView
                        {
                            CurrentBalance = (decimal)r["Current_Balance"],
                            AsOf = (DateTime)r["As_Of"],
                            LastTransactionType = r["Last_Transaction_Type"].ToString(),
                            LastTransactionAmount = (decimal)r["Last_Transaction_Amount"],
                            LastPaymentMethod = r["Last_Payment_Method"].ToString()
                        };
                    return null;
                }
            }
        }

        public List<DailyCashFlowView> GetDailyCashFlow(DateTime? from = null, DateTime? to = null)
        {
            var list = new List<DailyCashFlowView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_Report_DailyCashFlow"))
            {
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new DailyCashFlowView
                        {
                            FlowDate = (DateTime)r["Flow_Date"],
                            TotalIn = (decimal)r["Total_In"],
                            TotalOut = (decimal)r["Total_Out"],
                            NetFlow = (decimal)r["Net_Flow"],
                            SalesIn = (decimal)r["Sales_In"],
                            ExpensesOut = (decimal)r["Expenses_Out"],
                            PayrollOut = (decimal)r["Payroll_Out"],
                            PurchasesOut = (decimal)r["Purchases_Out"],
                            AdvancesOut = (decimal)r["Advances_Out"],
                            ClosingBalance = (decimal)r["Closing_Balance"]
                        });
            }
            return list;
        }
    }
}