using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
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
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_InvoiceProfits))
            {
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new InvoiceProfitView
                        {
                            InvoiceID = r.GetInt("Invoice_ID"),
                            DateTime = r.GetDate("Date_Time"),
                            CustomerName = r.GetStr("Customer_Name"),
                            EmployeeName = r.GetStr("Employee_Name"),
                            TotalAmount = r.GetDec("Total_Amount"),
                            Discount = r.GetDec("Discount"),
                            FinalAmount = r.GetDec("Final_Amount"),
                            PaidAmount = r.GetDec("Paid_Amount"),
                            RemainingBalance = r.GetDec("Remaining_Balance"),
                            TotalCost = r.GetDec("Total_Cost"),
                            NetProfit = r.GetDec("Net_Profit"),
                            ProfitPercent = r.GetDec("Profit_Percent"),
                            PaymentStatus = r.GetStr("Payment_Status", "Status_Name")
                        });
            }
            return list;
        }

        public List<DailyProfitView> GetDailyProfits(DateTime? from = null, DateTime? to = null)
        {
            var list = new List<DailyProfitView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_DailyProfits))
            {
                clsDBHelper.AddParam(cmd, "@From", from?.Date);
                clsDBHelper.AddParam(cmd, "@To", to?.Date);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new DailyProfitView
                        {
                            SaleDate = r.GetDate("Sale_Date"),
                            InvoiceCount = r.GetInt("Invoice_Count"),
                            TotalRevenue = r.GetDec("Total_Revenue"),
                            TotalCost = r.GetDec("Total_Cost"),
                            NetProfit = r.GetDec("Net_Profit"),
                            TotalCollected = r.GetDec("Total_Collected"),
                            TotalRemaining = r.GetDec("Total_Remaining")
                        });
            }
            return list;
        }

        public List<MonthlyProfitView> GetMonthlyProfits(int? year = null)
        {
            var list = new List<MonthlyProfitView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_MonthlyProfits))
            {
                clsDBHelper.AddParam(cmd, "@Year", year);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new MonthlyProfitView
                        {
                            MonthYear = r.GetStr("Month_Year"),
                            InvoiceCount = r.GetInt("Invoice_Count"),
                            TotalRevenue = r.GetDec("Total_Revenue"),
                            TotalCost = r.GetDec("Total_Cost"),
                            GrossProfit = r.GetDec("Gross_Profit", "Net_Profit"),
                            TotalCollected = r.GetDec("Total_Collected"),
                            TotalRemaining = r.GetDec("Total_Remaining"),
                            TotalExpenses = r.GetDec("Total_Expenses"),
                            TotalPayroll = r.GetDec("Total_Payroll"),
                            NetProfitAfterExpenses = r.GetDec("Net_Profit_After_Expenses")
                        });
            }
            return list;
        }

        public List<LowStockView> GetLowStockSuggestions()
        {
            var list = new List<LowStockView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_LowStockSuggestions))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new LowStockView
                        {
                            PartID = r.GetInt("Part_ID"),
                            Barcode = r.GetStr("Barcode"),
                            PartName = r.GetStr("Part_Name"),
                            CategoryName = r.GetStr("Category_Name"),
                            SupplierName = r.GetStr("Supplier_Name"),
                            SupplierPhone = r.GetStr("Supplier_Phone", "Phone_Number"),
                            CurrentStock = r.GetInt("Current_Stock"),
                            MinLimit = r.GetInt("Min_Limit"),
                            Shortage = r.GetInt("Shortage"),
                            AvgMonthlyUsage = r.GetDec("Avg_Monthly_Usage"),
                            SuggestedOrderQty = r.GetInt("Suggested_Order_Qty"),
                            EstimatedOrderCost = r.GetDec("Estimated_Order_Cost")
                        });
            }
            return list;
        }

        public List<TopSellingPartView> GetTopSellingParts(int top = 10)
        {
            var list = new List<TopSellingPartView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_TopSellingParts))
            {
                clsDBHelper.AddParam(cmd, "@Top", top);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new TopSellingPartView
                        {
                            PartID = r.GetInt("Part_ID"),
                            Barcode = r.GetStr("Barcode"),
                            PartName = r.GetStr("Part_Name"),
                            CategoryName = r.GetStr("Category_Name"),
                            BrandName = r.GetStr("Brand_Name"),
                            TotalQtySold = r.GetInt("Total_Qty_Sold"),
                            TotalRevenue = r.GetDec("Total_Revenue"),
                            TotalCost = r.GetDec("Total_Cost"),
                            TotalProfit = r.GetDec("Total_Profit"),
                            InvoiceCount = r.GetInt("Invoice_Count"),
                            CurrentStock = r.GetInt("Current_Stock"),
                            SellingPrice = r.GetDec("Selling_Price"),
                            LastSaleDate = r.GetDateOrNull("Last_Sale_Date")
                        });
            }
            return list;
        }

        public List<InventoryValuationView> GetInventoryValuation()
        {
            var list = new List<InventoryValuationView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_InventoryValuation))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new InventoryValuationView
                        {
                            PartID = r.GetInt("Part_ID"),
                            Barcode = r.GetStr("Barcode"),
                            PartName = r.GetStr("Part_Name"),
                            CategoryName = r.GetStr("Category_Name"),
                            BrandName = r.GetStr("Brand_Name"),
                            SupplierName = r.GetStr("Supplier_Name"),
                            CurrentStock = r.GetInt("Current_Stock"),
                            PurchasePrice = r.GetDec("Purchase_Price"),
                            SellingPrice = r.GetDec("Selling_Price"),
                            MarkupPercent = r.GetDec("Markup_Percent"),
                            ValueAtCost = r.GetDec("Value_At_Cost"),
                            ValueAtSelling = r.GetDec("Value_At_Selling"),
                            PotentialProfit = r.GetDec("Potential_Profit"),
                            MinLimit = r.GetInt("Min_Limit"),
                            IsLowStock = r.GetBool("Is_Low_Stock")   // بتتعامل مع BIT و "نعم"
                        });
            }
            return list;
        }

        public List<TopCustomerView> GetTopCustomers(int top = 20)
        {
            var list = new List<TopCustomerView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_TopCustomers))
            {
                clsDBHelper.AddParam(cmd, "@Top", top);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new TopCustomerView
                        {
                            CustomerID = r.GetInt("Customer_ID"),
                            CustomerName = r.GetStr("Customer_Name"),
                            PhoneNumber = r.GetStr("Phone_Number"),
                            CustomerType = r.GetStr("Customer_Type", "Type_Name"),
                            TotalInvoices = r.GetInt("Total_Invoices"),
                            TotalPurchases = r.GetDec("Total_Purchases"),
                            TotalPaid = r.GetDec("Total_Paid"),
                            TotalDebt = r.GetDec("Total_Debt"),
                            AvgInvoiceValue = r.GetDec("Avg_Invoice_Value"),
                            FirstPurchase = r.GetDateOrNull("First_Purchase"),
                            LastPurchase = r.GetDateOrNull("Last_Purchase"),
                            CreditLimit = r.GetDec("Credit_Limit")
                        });
            }
            return list;
        }

        public List<EmployeePerformanceView> GetEmployeePerformance()
        {
            var list = new List<EmployeePerformanceView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_EmployeePerformance))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new EmployeePerformanceView
                        {
                            EmployeeID = r.GetInt("Employee_ID"),
                            FullName = r.GetStr("Full_Name"),
                            PositionName = r.GetStr("Position_Name"),
                            BasicSalary = r.GetDec("Basic_Salary"),
                            TotalInvoices = r.GetInt("Total_Invoices"),
                            TotalSales = r.GetDec("Total_Sales"),
                            AvgInvoiceValue = r.GetDec("Avg_Invoice_Value"),
                            TotalDiscountsGiven = r.GetDec("Total_Discounts_Given"),
                            TotalCreditCreated = r.GetDec("Total_Credit_Created"),
                            UniqueCustomersServed = r.GetInt("Unique_Customers_Served"),
                            LastInvoiceDate = r.GetDateOrNull("Last_Invoice_Date"),
                            ThisMonthSales = r.GetDec("This_Month_Sales"),
                            TotalPaidSalary = r.GetDec("Total_Paid_Salary"),
                            TotalBonuses = r.GetDec("Total_Bonuses")
                        });
            }
            return list;
        }

        public TreasuryBalanceView GetCurrentTreasuryBalance()
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_CurrentTreasuryBalance))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;

                    return new TreasuryBalanceView
                    {
                        CurrentBalance = r.GetDec("Current_Balance", "Balance"),
                        AsOf = r.GetDateOrNull("As_Of"),
                        LastTransaction = r.GetDateOrNull("Last_Transaction", "Last_Transaction_Date", "Action_Date"),
                        LastTransactionType = r.GetStr("Last_Transaction_Type", "Type_Name"),
                        LastTransactionAmount = r.GetDec("Last_Transaction_Amount", "Amount"),
                        LastPaymentMethod = r.GetStr("Last_Payment_Method", "Method_Name")
                    };
                }
            }
        }

        public List<DailyCashFlowView> GetDailyCashFlow(DateTime? from = null, DateTime? to = null)
        {
            var list = new List<DailyCashFlowView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_DailyCashFlow))
            {
                clsDBHelper.AddParam(cmd, "@From", from?.Date);
                clsDBHelper.AddParam(cmd, "@To", to?.Date);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new DailyCashFlowView
                        {
                            FlowDate = r.GetDate("Flow_Date"),
                            TotalIn = r.GetDec("Total_In"),
                            TotalOut = r.GetDec("Total_Out"),
                            NetFlow = r.GetDec("Net_Flow"),
                            SalesIn = r.GetDec("Sales_In"),
                            ExpensesOut = r.GetDec("Expenses_Out"),
                            PayrollOut = r.GetDec("Payroll_Out"),
                            PurchasesOut = r.GetDec("Purchases_Out"),
                            AdvancesOut = r.GetDec("Advances_Out"),
                            ClosingBalance = r.GetDec("Closing_Balance")
                        });
            }
            return list;
        }

        // ── تقارير جديدة (Views كانت موجودة في الداتابيز من غير SPs) ───────────

        public List<DeadStockView> GetDeadStock(int minDaysSinceLastSale = 90)
        {
            var list = new List<DeadStockView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_DeadStock))
            {
                clsDBHelper.AddParam(cmd, "@MinDaysSinceLastSale", minDaysSinceLastSale);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new DeadStockView
                        {
                            PartID = r.GetInt("Part_ID"),
                            Barcode = r.GetStr("Barcode"),
                            PartName = r.GetStr("Part_Name"),
                            CategoryName = r.GetStr("Category_Name"),
                            BrandName = r.GetStr("Brand_Name"),
                            CurrentStock = r.GetInt("Current_Stock"),
                            SellingPrice = r.GetDec("Selling_Price"),
                            StockValue = r.GetDec("Stock_Value"),
                            PurchasePrice = r.GetDec("Purchase_Price"),
                            LastSaleDate = r.GetDateOrNull("Last_Sale_Date"),
                            DaysSinceLastSale = r.GetIntOrNull("Days_Since_Last_Sale"),
                            StockStatus = r.GetStr("Stock_Status"),
                            SupplierName = r.GetStr("Supplier_Name")
                        });
            }
            return list;
        }

        public List<FastMovingStockView> GetFastMovingStock()
        {
            var list = new List<FastMovingStockView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_FastMovingStock))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new FastMovingStockView
                        {
                            PartID = r.GetInt("Part_ID"),
                            PartName = r.GetStr("Part_Name"),
                            CategoryName = r.GetStr("Category_Name"),
                            BrandName = r.GetStr("Brand_Name"),
                            CurrentStock = r.GetInt("Current_Stock"),
                            MinLimit = r.GetInt("Min_Limit"),
                            TotalQtySold = r.GetInt("Total_Qty_Sold"),
                            ActiveSaleDays = r.GetInt("Active_Sale_Days"),
                            AvgDailySales = r.GetDec("Avg_Daily_Sales"),
                            DaysOfStockLeft = r.GetDecOrNull("Days_Of_Stock_Left"),
                            MovementSpeed = r.GetStr("Movement_Speed")
                        });
            }
            return list;
        }

        public List<CustomersWithDebtView> GetCustomersWithDebt()
        {
            var list = new List<CustomersWithDebtView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_CustomersWithDebt))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new CustomersWithDebtView
                        {
                            CustomerID = r.GetInt("Customer_ID"),
                            CustomerName = r.GetStr("Customer_Name"),
                            PhoneNumber = r.GetStr("Phone_Number"),
                            CustomerType = r.GetStr("Customer_Type"),
                            TotalDebt = r.GetDec("Total_Debt"),
                            CreditLimit = r.GetDec("Credit_Limit"),
                            AvailableCredit = r.GetDec("Available_Credit"),
                            LastPaymentDate = r.GetDateOrNull("Last_Payment_Date"),
                            DaysSinceLastPayment = r.GetIntOrNull("Days_Since_Last_Payment"),
                            DebtStatus = r.GetStr("Debt_Status"),
                            OpenInvoices = r.GetInt("Open_Invoices")
                        });
            }
            return list;
        }

        public List<CustomerStatementView> GetCustomerStatement(int customerID, DateTime? from = null, DateTime? to = null)
        {
            var list = new List<CustomerStatementView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_CustomerStatement))
            {
                clsDBHelper.AddParam(cmd, "@CustomerID", customerID);
                clsDBHelper.AddParam(cmd, "@From", from);
                clsDBHelper.AddParam(cmd, "@To", to);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new CustomerStatementView
                        {
                            CustomerID = r.GetInt("Customer_ID"),
                            CustomerName = r.GetStr("Customer_Name"),
                            PhoneNumber = r.GetStr("Phone_Number"),
                            CustomerType = r.GetStr("Customer_Type"),
                            InvoiceID = r.GetIntOrNull("Invoice_ID"),
                            InvoiceDate = r.GetDateOrNull("Invoice_Date"),
                            FinalAmount = r.GetDec("Final_Amount"),
                            PaidAmount = r.GetDec("Paid_Amount"),
                            RemainingBalance = r.GetDec("Remaining_Balance"),
                            PaymentStatus = r.GetStr("Payment_Status"),
                            CreditLimit = r.GetDec("Credit_Limit"),
                            CurrentTotalDebt = r.GetDec("Current_Total_Debt"),
                            TotalInvoices = r.GetInt("Total_Invoices"),
                            LifetimePurchases = r.GetDec("Lifetime_Purchases"),
                            LifetimePaid = r.GetDec("Lifetime_Paid"),
                            LastPaymentDate = r.GetDateOrNull("Last_Payment_Date")
                        });
            }
            return list;
        }

        public List<SupplierStatementView> GetSupplierStatement(int supplierID)
        {
            var list = new List<SupplierStatementView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_SupplierStatement))
            {
                clsDBHelper.AddParam(cmd, "@SupplierID", supplierID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new SupplierStatementView
                        {
                            SupplierID = r.GetInt("Supplier_ID"),
                            SupplierName = r.GetStr("Supplier_Name"),
                            PhoneNumber = r.GetStr("Phone_Number"),
                            ContactPerson = r.GetStr("Contact_Person"),
                            POID = r.GetIntOrNull("PO_ID"),
                            OrderDate = r.GetDateOrNull("Order_Date"),
                            TotalAmount = r.GetDec("Total_Amount"),
                            PaidAmount = r.GetDec("Paid_Amount"),
                            Remaining = r.GetDec("Remaining"),
                            POStatus = r.GetStr("PO_Status"),
                            CurrentTotalDebt = r.GetDec("Current_Total_Debt"),
                            TotalOrders = r.GetInt("Total_Orders"),
                            LifetimePurchases = r.GetDec("Lifetime_Purchases"),
                            LifetimePaid = r.GetDec("Lifetime_Paid")
                        });
            }
            return list;
        }

        public List<SupplierPerformanceView> GetSupplierPerformance()
        {
            var list = new List<SupplierPerformanceView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_SupplierPerformance))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new SupplierPerformanceView
                        {
                            SupplierID = r.GetInt("Supplier_ID"),
                            SupplierName = r.GetStr("Supplier_Name"),
                            PhoneNumber = r.GetStr("Phone_Number"),
                            TotalOrders = r.GetInt("Total_Orders"),
                            TotalPurchased = r.GetDec("Total_Purchased"),
                            TotalPartsOrdered = r.GetInt("Total_Parts_Ordered"),
                            DistinctParts = r.GetInt("Distinct_Parts"),
                            AvgOrderValue = r.GetDec("Avg_Order_Value"),
                            AvgUnitPrice = r.GetDec("Avg_Unit_Price"),
                            CompletionRatePercent = r.GetDec("Completion_Rate_Percent"),
                            LastOrderDate = r.GetDateOrNull("Last_Order_Date"),
                            CurrentBalance = r.GetDec("Current_Balance")
                        });
            }
            return list;
        }

        public List<ProfitLossSummaryView> GetProfitLoss(int? year = null)
        {
            var list = new List<ProfitLossSummaryView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_ProfitLoss))
            {
                clsDBHelper.AddParam(cmd, "@Year", year);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new ProfitLossSummaryView
                        {
                            Period = r.GetStr("Period"),
                            Revenue = r.GetDec("Revenue"),
                            COGS = r.GetDec("COGS"),
                            GrossProfit = r.GetDec("Gross_Profit"),
                            OperatingExpenses = r.GetDec("Operating_Expenses"),
                            PayrollCost = r.GetDec("Payroll_Cost"),
                            NetProfit = r.GetDec("Net_Profit")
                        });
            }
            return list;
        }

        public List<EmployeeFinancialSummaryView> GetEmployeeFinancialSummary(int? employeeID = null)
        {
            var list = new List<EmployeeFinancialSummaryView>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Report_EmployeeFinancialSummary))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new EmployeeFinancialSummaryView
                        {
                            EmployeeID = r.GetInt("Employee_ID"),
                            FullName = r.GetStr("Full_Name"),
                            PositionName = r.GetStr("Position_Name"),
                            BasicSalary = r.GetDec("Basic_Salary"),
                            WalletBalance = r.GetDec("Wallet_Balance"),
                            TotalSalaryReceived = r.GetDec("Total_Salary_Received"),
                            TotalBonuses = r.GetDec("Total_Bonuses"),
                            TotalDeductions = r.GetDec("Total_Deductions"),
                            TotalAdvancesTaken = r.GetDec("Total_Advances_Taken"),
                            PendingAdvances = r.GetDec("Pending_Advances"),
                            TotalSalesMade = r.GetDec("Total_Sales_Made"),
                            InvoicesMade = r.GetInt("Invoices_Made")
                        });
            }
            return list;
        }
    }

}