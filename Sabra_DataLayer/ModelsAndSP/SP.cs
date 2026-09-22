using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.DataLayer.ModelsAndSP
{ 


    internal static class SP
    {
        // Advances
        public const string Advance_Add = "sp_Advance_Add";
        public const string Advance_GetAll = "sp_Advance_GetAll";
        public const string Advance_Pay = "sp_Advance_Pay";
        public const string Advance_UpdateStatus = "sp_Advance_UpdateStatus";

        // Audit Log
        public const string AuditLog_Add = "sp_AuditLog_Add";
        public const string AuditLog_GetAll = "sp_AuditLog_GetAll";

        // Financial Audit Log
        public const string FinancialAuditLog_Add = "sp_FinancialAuditLog_Add";
        public const string FinancialAuditLog_GetAll = "sp_FinancialAuditLog_GetAll";
        public const string FinancialAuditLog_GetByEntity = "sp_FinancialAuditLog_GetByEntity";

        // Car Compatibility
        public const string CarCompatibility_Add = "sp_CarCompatibility_Add";
        public const string CarCompatibility_Delete = "sp_CarCompatibility_Delete";
        public const string CarCompatibility_GetByPart = "sp_CarCompatibility_GetByPart";
        public const string CarCompatibility_SearchByCar = "sp_CarCompatibility_SearchByCar";

        // Customers
        public const string Customer_Add = "sp_Customer_Add";
        public const string Customer_AdjustBalance = "sp_Customer_AdjustBalance";
        public const string Customer_GetAll = "sp_Customer_GetAll";
        public const string Customer_GetByID = "sp_Customer_GetByID";
        public const string Customer_Search = "sp_Customer_Search";
        public const string Customer_Update = "sp_Customer_Update";

        // Employees
        public const string Employee_Activate = "sp_Employee_Activate";
        public const string Employee_Add = "sp_Employee_Add";
        public const string Employee_Deactivate = "sp_Employee_Deactivate";
        public const string Employee_GetAll = "sp_Employee_GetAll";
        public const string Employee_GetByID = "sp_Employee_GetByID";
        public const string Employee_Search = "sp_Employee_Search";
        public const string Employee_Update = "sp_Employee_Update";

        // Expenses
        public const string Expense_Add = "sp_Expense_Add";
        public const string Expense_Delete = "sp_Expense_Delete";
        public const string Expense_GetAll = "sp_Expense_GetAll";
        public const string Expense_GetByID = "sp_Expense_GetByID";
        public const string Expense_Reverse = "sp_Expense_Reverse";
        public const string Expense_Update = "sp_Expense_Update";
        public const string Expense_Void = "sp_Expense_Void";

        // Inventory
        public const string Inventory_Add = "sp_Inventory_Add";
        public const string Inventory_AdjustStock = "sp_Inventory_AdjustStock";
        public const string Inventory_BarcodeExists = "sp_Inventory_BarcodeExists";
        public const string Inventory_GetAll = "sp_Inventory_GetAll";
        public const string Inventory_GetByBarcode = "sp_Inventory_GetByBarcode";
        public const string Inventory_GetByID = "sp_Inventory_GetByID";
        public const string Inventory_Search = "sp_Inventory_Search";
        public const string Inventory_SoftDelete = "sp_Inventory_SoftDelete";
        public const string Inventory_Update = "sp_Inventory_Update";
        public const string Inventory_UpdatePrice = "sp_Inventory_UpdatePrice";

        // Lookups
        public const string Lookup_AddBrand = "sp_Lookup_AddBrand";
        public const string Lookup_AddCategory = "sp_Lookup_AddCategory";
        public const string Lookup_AddExpenseCategory = "sp_Lookup_AddExpenseCategory";
        public const string Lookup_AddPosition = "sp_Lookup_AddPosition";
        public const string Lookup_AddUnit = "sp_Lookup_AddUnit";
        public const string Lookup_GetAllAdvanceStatuses = "sp_Lookup_GetAllAdvanceStatuses";
        public const string Lookup_GetAllBrands = "sp_Lookup_GetAllBrands";
        public const string Lookup_GetAllCategories = "sp_Lookup_GetAllCategories";
        public const string Lookup_GetAllCustomerTypes = "sp_Lookup_GetAllCustomerTypes";
        public const string Lookup_GetAllExpenseCategories = "sp_Lookup_GetAllExpenseCategories";
        public const string Lookup_GetAllItemStatuses = "sp_Lookup_GetAllItemStatuses";
        public const string Lookup_GetAllMovementTypes = "sp_Lookup_GetAllMovementTypes";
        public const string Lookup_GetAllPaymentMethods = "sp_Lookup_GetAllPaymentMethods";
        public const string Lookup_GetAllPaymentStatuses = "sp_Lookup_GetAllPaymentStatuses";
        public const string Lookup_GetAllPositions = "sp_Lookup_GetAllPositions";
        public const string Lookup_GetAllPOStatuses = "sp_Lookup_GetAllPOStatuses";
        public const string Lookup_GetAllTransactionTypes = "sp_Lookup_GetAllTransactionTypes";
        public const string Lookup_GetAllUnits = "sp_Lookup_GetAllUnits";

        // Payroll
        public const string Payroll_Add = "sp_Payroll_Add";
        public const string Payroll_GetAll = "sp_Payroll_GetAll";
        public const string Payroll_MonthYearExists = "sp_Payroll_MonthYearExists";

        // Price History
        public const string PriceHistory_AddRecord = "sp_PriceHistory_AddRecord";
        public const string PriceHistory_CloseCurrent = "sp_PriceHistory_CloseCurrent";
        public const string PriceHistory_GetByPart = "sp_PriceHistory_GetByPart";

        // Purchase Orders
        public const string PurchaseOrder_Add = "sp_PurchaseOrder_Add";
        public const string PurchaseOrder_GetAll = "sp_PurchaseOrder_GetAll";
        public const string PurchaseOrder_GetByID = "sp_PurchaseOrder_GetByID";
        public const string PurchaseOrder_Receive = "sp_PurchaseOrder_Receive";
        public const string PurchaseOrder_UpdatePayment = "sp_PurchaseOrder_UpdatePayment";
        public const string PurchaseOrder_UpdateStatus = "sp_PurchaseOrder_UpdateStatus";

        // Reports
        public const string Report_CurrentTreasuryBalance = "sp_Report_CurrentTreasuryBalance";
        public const string Report_DailyCashFlow = "sp_Report_DailyCashFlow";
        public const string Report_DailyProfits = "sp_Report_DailyProfits";
        public const string Report_EmployeePerformance = "sp_Report_EmployeePerformance";
        public const string Report_InventoryValuation = "sp_Report_InventoryValuation";
        public const string Report_InvoiceProfits = "sp_Report_InvoiceProfits";
        public const string Report_LowStockSuggestions = "sp_Report_LowStockSuggestions";
        public const string Report_MonthlyProfits = "sp_Report_MonthlyProfits";
        public const string Report_TopCustomers = "sp_Report_TopCustomers";
        public const string Report_TopSellingParts = "sp_Report_TopSellingParts";
        public const string Report_DeadStock = "sp_Report_DeadStock";
        public const string Report_FastMovingStock = "sp_Report_FastMovingStock";
        public const string Report_CustomersWithDebt = "sp_Report_CustomersWithDebt";
        public const string Report_CustomerStatement = "sp_Report_CustomerStatement";
        public const string Report_SupplierStatement = "sp_Report_SupplierStatement";
        public const string Report_SupplierPerformance = "sp_Report_SupplierPerformance";
        public const string Report_ProfitLoss = "sp_Report_ProfitLoss";
        public const string Report_EmployeeFinancialSummary = "sp_Report_EmployeeFinancialSummary";

        // Returns
        public const string Returns_Add = "sp_Returns_Add";
        public const string Returns_GetAll = "sp_Returns_GetAll";

        // Sales Invoices
        public const string SalesInvoice_Add = "sp_SalesInvoice_Add";
        public const string SalesInvoice_GetAll = "sp_SalesInvoice_GetAll";
        public const string SalesInvoice_GetByID = "sp_SalesInvoice_GetByID";
        public const string SalesInvoice_UpdatePayment = "sp_SalesInvoice_UpdatePayment";

        // Staff Wallet
        public const string StaffWallet_AdjustBalance = "sp_StaffWallet_AdjustBalance";
        public const string StaffWallet_Create = "sp_StaffWallet_Create";
        public const string StaffWallet_GetByEmployee = "sp_StaffWallet_GetByEmployee";

        // Suppliers
        public const string Supplier_Add = "sp_Supplier_Add";
        public const string Supplier_AdjustBalance = "sp_Supplier_AdjustBalance";
        public const string Supplier_GetAll = "sp_Supplier_GetAll";
        public const string Supplier_GetByID = "sp_Supplier_GetByID";
        public const string Supplier_Search = "sp_Supplier_Search";
        public const string Supplier_Update = "sp_Supplier_Update";

        // Treasury
        public const string Treasury_Add = "sp_Treasury_Add";
        public const string Treasury_GetAll = "sp_Treasury_GetAll";

        // Users
        public const string User_Add = "sp_User_Add";
        public const string User_GetAll = "sp_User_GetAll";
        public const string User_GetByEmployeeID = "sp_User_GetByEmployeeID";
        public const string User_GetByID = "sp_User_GetByID";
        public const string User_GetByUsername = "sp_User_GetByUsername";
        public const string User_SetActive = "sp_User_SetActive";
        public const string User_UpdatePassword = "sp_User_UpdatePassword";
        public const string User_UpdatePermissions = "sp_User_UpdatePermissions";
        public const string User_UsernameExists = "sp_User_UsernameExists";

        // Scalar Functions
        public const string Fn_CalculateSellingPrice = "SELECT dbo.fn_CalculateSellingPrice(@PurchasePrice, @MarkupPercent)";
        public const string Fn_FormatMonthYear = "SELECT dbo.fn_FormatMonthYear(@Date)";
        public const string Fn_TreasuryBalance = "SELECT dbo.fn_Treasury_GetCurrentBalance()";

        // Table Valued Parameter types
        public const string Type_InvoiceDetail = "dbo.InvoiceDetailTableType";
        public const string Type_PODetail = "dbo.PODetailTableType";
    }
}
