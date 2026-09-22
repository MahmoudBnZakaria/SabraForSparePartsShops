using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{

    public class clsReportsBusiness : clsBusinessBase
    {
        private readonly clsReportsDAL _reportsDAL = new clsReportsDAL();
        private readonly clsDashboardDAL _dashboardDAL = new clsDashboardDAL();

        // ── الأرباح ─────────────────────────────────────────────
        public OperationResult<List<InvoiceProfitView>> GetInvoiceProfits(DateTime? from = null, DateTime? to = null) => Execute(()
            => OperationResult<List<InvoiceProfitView>>.Ok(_reportsDAL.GetInvoiceProfits(from, to)));

        public OperationResult<List<DailyProfitView>> GetDailyProfits(DateTime? from = null, DateTime? to = null) => Execute(()
            => OperationResult<List<DailyProfitView>>.Ok(_reportsDAL.GetDailyProfits(from, to)));

        public OperationResult<List<MonthlyProfitView>> GetMonthlyProfits(int? year = null) => Execute(()
            => OperationResult<List<MonthlyProfitView>>.Ok(_reportsDAL.GetMonthlyProfits(year)));

        public OperationResult<List<ProfitLossSummaryView>> GetProfitLoss(int? year = null) => Execute(()
            => OperationResult<List<ProfitLossSummaryView>>.Ok(_reportsDAL.GetProfitLoss(year)));

        // ── الخزنة ──────────────────────────────────────────────
        public OperationResult<List<DailyCashFlowView>> GetDailyCashFlow(DateTime? from = null, DateTime? to = null) => Execute(()
            => OperationResult<List<DailyCashFlowView>>.Ok(_reportsDAL.GetDailyCashFlow(from, to)));

        public OperationResult<TreasuryBalanceView> GetCurrentTreasuryBalance() => Execute(() =>
        {
            var balance = _reportsDAL.GetCurrentTreasuryBalance();
            return balance == null
                ? OperationResult<TreasuryBalanceView>.Fail("لا توجد حركات في الخزنة بعد.")
                : OperationResult<TreasuryBalanceView>.Ok(balance);
        });

        // ── المخزون ─────────────────────────────────────────────
        public OperationResult<List<LowStockView>> GetLowStockSuggestions() => Execute(()
            => OperationResult<List<LowStockView>>.Ok(_reportsDAL.GetLowStockSuggestions()));

        public OperationResult<List<TopSellingPartView>> GetTopSellingParts(int top = 10) => Execute(()
            => OperationResult<List<TopSellingPartView>>.Ok(_reportsDAL.GetTopSellingParts(top <= 0 ? 10 : top)));

        public OperationResult<List<InventoryValuationView>> GetInventoryValuation() => Execute(()
            => OperationResult<List<InventoryValuationView>>.Ok(_reportsDAL.GetInventoryValuation()));

        public OperationResult<List<DeadStockView>> GetDeadStock(int minDays = 90) => Execute(()
            => OperationResult<List<DeadStockView>>.Ok(_reportsDAL.GetDeadStock(minDays <= 0 ? 90 : minDays)));

        public OperationResult<List<FastMovingStockView>> GetFastMovingStock() => Execute(()
            => OperationResult<List<FastMovingStockView>>.Ok(_reportsDAL.GetFastMovingStock()));

        // ── العملاء والموردون ───────────────────────────────────
        public OperationResult<List<TopCustomerView>> GetTopCustomers(int top = 20) => Execute(()
            => OperationResult<List<TopCustomerView>>.Ok(_reportsDAL.GetTopCustomers(top <= 0 ? 20 : top)));

        public OperationResult<List<CustomersWithDebtView>> GetCustomersWithDebt() => Execute(()
            => OperationResult<List<CustomersWithDebtView>>.Ok(_reportsDAL.GetCustomersWithDebt()));

        public OperationResult<List<CustomerStatementView>> GetCustomerStatement(int customerID, DateTime? from = null, DateTime? to = null) => Execute(()
            => OperationResult<List<CustomerStatementView>>.Ok(_reportsDAL.GetCustomerStatement(customerID, from, to)));

        public OperationResult<List<SupplierStatementView>> GetSupplierStatement(int supplierID) => Execute(()
            => OperationResult<List<SupplierStatementView>>.Ok(_reportsDAL.GetSupplierStatement(supplierID)));

        public OperationResult<List<SupplierPerformanceView>> GetSupplierPerformance() => Execute(()
            => OperationResult<List<SupplierPerformanceView>>.Ok(_reportsDAL.GetSupplierPerformance()));

        // ── الموظفون ────────────────────────────────────────────
        public OperationResult<List<EmployeePerformanceView>> GetEmployeePerformance() => Execute(()
            => OperationResult<List<EmployeePerformanceView>>.Ok(_reportsDAL.GetEmployeePerformance()));

        public OperationResult<List<EmployeeFinancialSummaryView>> GetEmployeeFinancialSummary(int? employeeID = null) => Execute(()
            => OperationResult<List<EmployeeFinancialSummaryView>>.Ok(_reportsDAL.GetEmployeeFinancialSummary(employeeID)));

        // ── لوحة التحكم ─────────────────────────────────────────
        public OperationResult<DashboardSummary> GetDashboardSummary(int topPartsCount = 5) => Execute(()
            => OperationResult<DashboardSummary>.Ok(_dashboardDAL.GetSummary(topPartsCount <= 0 ? 5 : topPartsCount)));
    }
}
