using Sabra.DataLayer;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    public class clsReportsBusiness
    {

        private readonly clsReportsDAL _reportsDAL = new clsReportsDAL();

        // ── المالية ─────────────────────────────────────────────
        public OperationResult<List<InvoiceProfitView>> GetInvoiceProfits(DateTime? from = null, DateTime? to = null)
            => OperationResult<List<InvoiceProfitView>>.Ok(_reportsDAL.GetInvoiceProfits(from, to));

        public OperationResult<List<DailyProfitView>> GetDailyProfits(DateTime? from = null, DateTime? to = null)
            => OperationResult<List<DailyProfitView>>.Ok(_reportsDAL.GetDailyProfits(from, to));

        public OperationResult<List<MonthlyProfitView>> GetMonthlyProfits(int? year = null)
            => OperationResult<List<MonthlyProfitView>>.Ok(_reportsDAL.GetMonthlyProfits(year));

        public OperationResult<List<DailyCashFlowView>> GetDailyCashFlow(DateTime? from = null, DateTime? to = null)
            => OperationResult<List<DailyCashFlowView>>.Ok(_reportsDAL.GetDailyCashFlow(from, to));

        public OperationResult<TreasuryBalanceView> GetCurrentTreasuryBalance()
        {
            var bal = _reportsDAL.GetCurrentTreasuryBalance();
            if (bal == null) return OperationResult<TreasuryBalanceView>.Fail("لا توجد حركات في الخزنة بعد.");
            return OperationResult<TreasuryBalanceView>.Ok(bal);
        }

        // ── المخزون ─────────────────────────────────────────────
        public OperationResult<List<LowStockView>> GetLowStockSuggestions()
            => OperationResult<List<LowStockView>>.Ok(_reportsDAL.GetLowStockSuggestions());

        public OperationResult<List<TopSellingPartView>> GetTopSellingParts(int top = 10)
        {
            if (top <= 0) top = 10;
            return OperationResult<List<TopSellingPartView>>.Ok(_reportsDAL.GetTopSellingParts(top));
        }

        public OperationResult<List<InventoryValuationView>> GetInventoryValuation()
            => OperationResult<List<InventoryValuationView>>.Ok(_reportsDAL.GetInventoryValuation());

        // ── العملاء ─────────────────────────────────────────────
        public OperationResult<List<TopCustomerView>> GetTopCustomers(int top = 20)
        {
            if (top <= 0) top = 20;
            return OperationResult<List<TopCustomerView>>.Ok(_reportsDAL.GetTopCustomers(top));
        }

        // ── الموظفين ─────────────────────────────────────────────
        public OperationResult<List<EmployeePerformanceView>> GetEmployeePerformance()
            => OperationResult<List<EmployeePerformanceView>>.Ok(_reportsDAL.GetEmployeePerformance());

        // ── ملخص لوحة التحكم اليومية ────────────────────────────
        public OperationResult<DashboardSummary> GetDashboardSummary()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var dailyProfit = _reportsDAL.GetDailyProfits(today, tomorrow);
            var lowStock = _reportsDAL.GetLowStockSuggestions();
            var treasuryBal = _reportsDAL.GetCurrentTreasuryBalance();
            var topParts = _reportsDAL.GetTopSellingParts(5);
            var cashFlow = _reportsDAL.GetDailyCashFlow(today, tomorrow);

            var todayFlow = cashFlow.FirstOrDefault();
            var todayProfit = dailyProfit.FirstOrDefault();

            var summary = new DashboardSummary
            {
                TodaySales = todayProfit?.TotalRevenue ?? 0,
                TodayNetProfit = todayProfit?.NetProfit ?? 0,
                TodayInvoiceCount = todayProfit?.InvoiceCount ?? 0,
                TodayCashIn = todayFlow?.TotalIn ?? 0,
                TodayCashOut = todayFlow?.TotalOut ?? 0,
                CurrentBalance = treasuryBal?.CurrentBalance ?? 0,
                LowStockCount = lowStock.Count,
                ZeroStockCount = lowStock.Count(l => l.CurrentStock == 0),
                TopParts = topParts
            };

            return OperationResult<DashboardSummary>.Ok(summary);
        }
    }
}
