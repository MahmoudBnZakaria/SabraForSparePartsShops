using System;
using System.Collections.Generic;

namespace Sabra.DataLayer.Models
{

    #region Lookup Models

    public class EmployeePosition
    {
        public int PositionID { get; set; }
        public string PositionName { get; set; }
    }

    public class AdvanceStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }

    public class PaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string MethodName { get; set; }
    }

    public class TransactionType
    {
        public int TransactionTypeID { get; set; }
        public string TypeName { get; set; }
    }

    public class PaymentStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }

    public class ItemStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }

    public class MovementType
    {
        public int MovementTypeID { get; set; }
        public string TypeName { get; set; }
    }

    public class ExpenseCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class CustomerType
    {
        public int CustomerTypeID { get; set; }
        public string TypeName { get; set; }
    }

    public class PurchaseOrderStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }

    public class Unit
    {
        public int UnitID { get; set; }
        public string UnitName { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Country { get; set; }
    }

    #endregion Lookup Models

    #region Core Models

    public class Employee
    {
        public int EmployeeID { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }   // من JOIN
        public string FullName { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTime HireDate { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class User
    {
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }  // من JOIN
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Permissions { get; set; }      // Bitwise representation of permissions
    }

    public class StaffWallet
    {
        public int WalletID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }  // من JOIN
        public string WalletNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public class Payroll
    {
        public int PayrollID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }   // من JOIN
        public decimal AmountPaid { get; set; }
        public decimal Deductions { get; set; }
        public decimal Bonuses { get; set; }
        public DateTime PaymentDate { get; set; }
        public string MonthYear { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        /// <summary>صافي المستحق = المدفوع + الحوافز - الخصومات (حساب محلي للعرض).</summary>
        public decimal NetAmount => AmountPaid + Bonuses - Deductions;
    }

    public class Advance
    {
        public int AdvanceID { get; set; }
        public int EmployeeID { get; set; }
        public decimal Amount { get; set; }
        public DateTime AdvanceDate { get; set; }
        public int StatusID { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? TreasuryID { get; set; }       // Nullable: بيتملى وقت الصرف بس

        public string EmployeeName { get; set; }   // من JOIN
        public string ApproverName { get; set; }   // من JOIN
        public string StatusName { get; set; }     // من JOIN
    }

    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public decimal SupplierBalance { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class InventoryItem
    {
        public int PartID { get; set; }
        public string Barcode { get; set; }
        public string TechnicalNumber { get; set; }
        public string PartName { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }   // من JOIN
        public int? BrandID { get; set; }
        public string BrandName { get; set; }      // من JOIN
        public int? UnitID { get; set; }
        public string UnitName { get; set; }       // من JOIN
        public decimal PurchasePrice { get; set; }
        public decimal MarkupPercent { get; set; }
        public decimal SellingPrice { get; set; }
        public int CurrentStock { get; set; }
        public int MinLimit { get; set; }
        public int? CrossRefID { get; set; }
        public int? SupplierID { get; set; }
        public string SupplierName { get; set; }   // من JOIN
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Notes { get; set; }

        public bool IsLowStock => CurrentStock <= MinLimit;
        public bool IsOutOfStock => CurrentStock <= 0;
    }

    public class PriceHistory
    {
        public int PriceID { get; set; }
        public int PartID { get; set; }
        public string PartName { get; set; }   // من JOIN
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsCurrent => EndDate == null;
    }

    public class CarCompatibility
    {
        public int CompatibilityID { get; set; }
        public int PartID { get; set; }
        public string PartName { get; set; }  // من JOIN
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string YearRange { get; set; }
    }

    public class PurchaseOrder
    {
        public int POID { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }   // من JOIN
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }   // من JOIN
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }     // من JOIN
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReceivedAt { get; set; }

        private decimal? _remaining;
        /// <summary>محسوب في الداتابيز؛ لو مارجعش من الـ SP بيتحسب محليًا.</summary>
        public decimal Remaining
        {
            get { return _remaining ?? (TotalAmount - PaidAmount); }
            set { _remaining = value; }
        }

        public List<PurchaseOrderDetail> Details { get; set; } = new List<PurchaseOrderDetail>();
    }

    public class PurchaseOrderDetail
    {
        public int DetailID { get; set; }
        public int POID { get; set; }
        public int PartID { get; set; }
        public string PartName { get; set; }  // من JOIN
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReceivedQuantity { get; set; }

        private decimal? _lineTotal;
        /// <summary>محسوب في الداتابيز؛ لو مارجعش من الـ SP بيتحسب محليًا.</summary>
        public decimal LineTotal
        {
            get { return _lineTotal ?? (Quantity * UnitPrice); }
            set { _lineTotal = value; }
        }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int? CustomerTypeID { get; set; }
        public string CustomerType { get; set; }   // من JOIN
        public decimal CreditLimit { get; set; }
        public decimal TotalBalance { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public decimal AvailableCredit => CreditLimit - TotalBalance;
        public bool IsOverCreditLimit => CreditLimit > 0 && TotalBalance > CreditLimit;
    }

    public class SalesInvoice
    {
        public int InvoiceID { get; set; }
        public int? CustomerID { get; set; }
        public string CustomerName { get; set; }   // من JOIN
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }   // من JOIN
        public DateTime DateTime { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal PaidAmount { get; set; }
        public int PaymentStatusID { get; set; }
        public string PaymentStatus { get; set; }  // من JOIN
        public DateTime CreatedAt { get; set; }

        private decimal? _finalAmount;
        /// <summary>عمود محسوب PERSISTED في الداتابيز = Total_Amount - Discount.</summary>
        public decimal FinalAmount
        {
            get { return _finalAmount ?? (TotalAmount - Discount); }
            set { _finalAmount = value; }
        }

        private decimal? _remainingBalance;
        /// <summary>عمود محسوب PERSISTED في الداتابيز = Final_Amount - Paid_Amount.</summary>
        public decimal RemainingBalance
        {
            get { return _remainingBalance ?? (FinalAmount - PaidAmount); }
            set { _remainingBalance = value; }
        }

        public List<InvoiceDetail> Details { get; set; } = new List<InvoiceDetail>();
    }

    public class InvoiceDetail
    {
        public int DetailID { get; set; }
        public int InvoiceID { get; set; }
        public int PartID { get; set; }
        public string PartName { get; set; }  // من JOIN
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        /// <summary>تكلفة القطعة وقت البيع (بتتسجل من الـ SP).</summary>
        public decimal UnitCost { get; set; }

        private decimal? _lineTotal;
        public decimal LineTotal
        {
            get { return _lineTotal ?? (Quantity * UnitPrice); }
            set { _lineTotal = value; }
        }

        public decimal LineProfit => LineTotal - (Quantity * UnitCost);
    }

    public class Return
    {
        public int ReturnID { get; set; }
        public int InvoiceID { get; set; }
        public int PartID { get; set; }
        public string PartName { get; set; }   // من JOIN
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; } // من JOIN
        public DateTime ReturnDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Expense
    {
        public int ExpenseID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }   // من JOIN
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int? PaidBy { get; set; }
        public string PaidByName { get; set; }     // من JOIN
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool IsVoided { get; set; }
        public DateTime? VoidedAt { get; set; }
        public int? VoidedBy { get; set; }
        public string VoidedByName { get; set; }   // من JOIN (لو متاح)
        public string VoidReason { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? TreasuryID { get; set; }
    }

    public class TreasuryLog
    {
        public int TransactionID { get; set; }
        public int TransactionTypeID { get; set; }
        public string TransactionType { get; set; }   // من JOIN
        public int PaymentMethodID { get; set; }
        public string PaymentMethod { get; set; }     // من JOIN
        /// <summary>
        /// القيمة بالإشارة (موجب = دخل / سالب = صرف) وهي اللي بتتبعت لـ @SignedAmount.
        /// </summary>
        public decimal Amount { get; set; }
        public int? InvoiceID { get; set; }
        public int? POID { get; set; }
        public int? ExpenseID { get; set; }
        public int? PayrollID { get; set; }
        public int? AdvanceID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime ActionDate { get; set; }
        public decimal BalanceAfter { get; set; }
        public string Notes { get; set; }

        public int? ReversalOfTransactionID { get; set; }
        public int? CreatedBy { get; set; }

        // Joined fields للعرض
        public string RelatedCustomer { get; set; }
        public string RelatedSupplier { get; set; }
        public string RelatedEmployee { get; set; }
        public string TransactionSource { get; set; }
        public string CreatedByName { get; set; }

        public bool IsInflow => Amount >= 0;
    }

    public class AuditLog
    {
        public int LogID { get; set; }
        public int PartID { get; set; }
        public string PartName { get; set; }     // من JOIN
        public int MovementTypeID { get; set; }
        public string MovementType { get; set; } // من JOIN
        public int QuantityChange { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }     // من JOIN
        public DateTime ActionDate { get; set; }
        public string Remarks { get; set; }
    }

    /// <summary>موديل جديد: جدول التدقيق المالي (sp_FinancialAuditLog_*).</summary>
    public class FinancialAuditLog
    {
        public int LogID { get; set; }
        public string EntityType { get; set; }
        public int EntityID { get; set; }
        public string ActionType { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }   // من JOIN لو متاح
        public string Remarks { get; set; }
        public DateTime ActionDate { get; set; }
    }

    #endregion Core Models

    #region View / Report Models

    // V_Invoice_Profit / sp_Report_InvoiceProfits
    public class InvoiceProfitView
    {
        public int InvoiceID { get; set; }
        public DateTime DateTime { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingBalance { get; set; }
        public decimal TotalCost { get; set; }
        public decimal NetProfit { get; set; }
        public decimal ProfitPercent { get; set; }
        public string PaymentStatus { get; set; }
    }

    // V_Daily_Profit / sp_Report_DailyProfits
    public class DailyProfitView
    {
        public DateTime SaleDate { get; set; }
        public int InvoiceCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal NetProfit { get; set; }
        public decimal TotalCollected { get; set; }
        public decimal TotalRemaining { get; set; }
    }

    // V_Monthly_Profit / sp_Report_MonthlyProfits
    public class MonthlyProfitView
    {
        public string MonthYear { get; set; }
        public int InvoiceCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal TotalCollected { get; set; }
        public decimal TotalRemaining { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalPayroll { get; set; }
        public decimal NetProfitAfterExpenses { get; set; }
    }

    // V_Daily_Cash_Flow / sp_Report_DailyCashFlow
    public class DailyCashFlowView
    {
        public DateTime FlowDate { get; set; }
        public decimal TotalIn { get; set; }
        public decimal TotalOut { get; set; }
        public decimal NetFlow { get; set; }
        public decimal SalesIn { get; set; }
        public decimal ExpensesOut { get; set; }
        public decimal PayrollOut { get; set; }
        public decimal PurchasesOut { get; set; }
        public decimal AdvancesOut { get; set; }
        public decimal ClosingBalance { get; set; }
    }

    // V_Reorder_Suggestion & V_Low_Stock_Alert / sp_Report_LowStockSuggestions
    public class LowStockView
    {
        public int PartID { get; set; }
        public string Barcode { get; set; }
        public string PartName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
        public int CurrentStock { get; set; }
        public int MinLimit { get; set; }
        public int Shortage { get; set; }
        public decimal AvgMonthlyUsage { get; set; }
        public int SuggestedOrderQty { get; set; }
        public decimal EstimatedOrderCost { get; set; }
    }

    // V_Top_Selling_Parts / sp_Report_TopSellingParts
    public class TopSellingPartView
    {
        public int PartID { get; set; }
        public string Barcode { get; set; }
        public string PartName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public int TotalQtySold { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalProfit { get; set; }
        public int InvoiceCount { get; set; }
        public int CurrentStock { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime? LastSaleDate { get; set; }
    }

    // V_Inventory_Valuation / sp_Report_InventoryValuation
    public class InventoryValuationView
    {
        public int PartID { get; set; }
        public string Barcode { get; set; }
        public string PartName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string SupplierName { get; set; }
        public int CurrentStock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal MarkupPercent { get; set; }
        public decimal ValueAtCost { get; set; }
        public decimal ValueAtSelling { get; set; }
        public decimal PotentialProfit { get; set; }
        public int MinLimit { get; set; }
        public bool IsLowStock { get; set; }
    }

    // V_Customer_Statement
    public class CustomerStatementView
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerType { get; set; }
        public int? InvoiceID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingBalance { get; set; }
        public string PaymentStatus { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal CurrentTotalDebt { get; set; }
        public int TotalInvoices { get; set; }
        public decimal LifetimePurchases { get; set; }
        public decimal LifetimePaid { get; set; }
        public DateTime? LastPaymentDate { get; set; }
    }

    // V_Top_Customers / sp_Report_TopCustomers
    public class TopCustomerView
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerType { get; set; }
        public int TotalInvoices { get; set; }
        public decimal TotalPurchases { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalDebt { get; set; }
        public decimal AvgInvoiceValue { get; set; }
        public DateTime? FirstPurchase { get; set; }
        public DateTime? LastPurchase { get; set; }
        public decimal CreditLimit { get; set; }
    }

    // V_Supplier_Statement
    public class SupplierStatementView
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactPerson { get; set; }
        public int? POID { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Remaining { get; set; }
        public string POStatus { get; set; }
        public decimal CurrentTotalDebt { get; set; }
        public int TotalOrders { get; set; }
        public decimal LifetimePurchases { get; set; }
        public decimal LifetimePaid { get; set; }
    }

    // V_Employee_Financial_Summary
    public class EmployeeFinancialSummaryView
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string PositionName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal WalletBalance { get; set; }
        public decimal TotalSalaryReceived { get; set; }
        public decimal TotalBonuses { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal TotalAdvancesTaken { get; set; }
        public decimal PendingAdvances { get; set; }
        public decimal TotalSalesMade { get; set; }
        public int InvoicesMade { get; set; }
    }

    /// <summary>موديل جديد مطلوب لـ sp_Report_EmployeePerformance.</summary>
    public class EmployeePerformanceView
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string PositionName { get; set; }
        public decimal BasicSalary { get; set; }
        public int TotalInvoices { get; set; }
        public decimal TotalSales { get; set; }
        public decimal AvgInvoiceValue { get; set; }
        public decimal TotalDiscountsGiven { get; set; }
        public decimal TotalCreditCreated { get; set; }
        public int UniqueCustomersServed { get; set; }
        public DateTime? LastInvoiceDate { get; set; }
        public decimal ThisMonthSales { get; set; }
        public decimal TotalPaidSalary { get; set; }
        public decimal TotalBonuses { get; set; }
    }

    // V_Profit_Loss_Summary
    public class ProfitLossSummaryView
    {
        public string Period { get; set; }
        public decimal Revenue { get; set; }
        public decimal COGS { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal OperatingExpenses { get; set; }
        public decimal PayrollCost { get; set; }
        public decimal NetProfit { get; set; }
    }

    // V_Dead_Stock
    public class DeadStockView
    {
        public int PartID { get; set; }
        public string Barcode { get; set; }
        public string PartName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public int CurrentStock { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal StockValue { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime? LastSaleDate { get; set; }
        public int? DaysSinceLastSale { get; set; }
        public string StockStatus { get; set; }
        public string SupplierName { get; set; }
    }

    // V_Fast_Moving_Stock
    public class FastMovingStockView
    {
        public int PartID { get; set; }
        public string PartName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public int CurrentStock { get; set; }
        public int MinLimit { get; set; }
        public int TotalQtySold { get; set; }
        public int ActiveSaleDays { get; set; }
        public decimal AvgDailySales { get; set; }
        public decimal? DaysOfStockLeft { get; set; }
        public string MovementSpeed { get; set; }
    }

    // V_Customers_With_Debt
    public class CustomersWithDebtView
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerType { get; set; }
        public decimal TotalDebt { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal AvailableCredit { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public int? DaysSinceLastPayment { get; set; }
        public string DebtStatus { get; set; }
        public int OpenInvoices { get; set; }
    }

    // V_Supplier_Performance
    public class SupplierPerformanceView
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalPurchased { get; set; }
        public int TotalPartsOrdered { get; set; }
        public int DistinctParts { get; set; }
        public decimal AvgOrderValue { get; set; }
        public decimal AvgUnitPrice { get; set; }
        public decimal CompletionRatePercent { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public decimal CurrentBalance { get; set; }
    }

    // sp_Report_CurrentTreasuryBalance
    public class TreasuryBalanceView
    {
        public decimal CurrentBalance { get; set; }
        public DateTime? AsOf { get; set; }
        public DateTime? LastTransaction { get; set; }
        public string LastTransactionType { get; set; }
        public decimal LastTransactionAmount { get; set; }
        public string LastPaymentMethod { get; set; }
    }

    public class DashboardSummary
    {
        public decimal TodaySales { get; set; }
        public decimal TodayNetProfit { get; set; }
        public int TodayInvoiceCount { get; set; }
        public decimal TodayCashIn { get; set; }
        public decimal TodayCashOut { get; set; }
        public decimal CurrentBalance { get; set; }
        public int LowStockCount { get; set; }
        public int ZeroStockCount { get; set; }
        public List<TopSellingPartView> TopParts { get; set; } = new List<TopSellingPartView>();
    }

    #endregion View / Report Models
}