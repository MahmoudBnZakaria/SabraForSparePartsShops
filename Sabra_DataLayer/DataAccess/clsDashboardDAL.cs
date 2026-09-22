using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.DataLayer.DataAccess
{
    public class clsDashboardDAL
    {
        public DashboardSummary GetSummary(int topPartsCount = 5)
        {
            var reports = new clsReportsDAL();
            var today = DateTime.Today;
            var summary = new DashboardSummary();

            var daily = reports.GetDailyProfits(today, today);
            if (daily.Count > 0)
            {
                var d = daily[0];
                summary.TodaySales = d.TotalRevenue;
                summary.TodayNetProfit = d.NetProfit;
                summary.TodayInvoiceCount = d.InvoiceCount;
            }

            var flow = reports.GetDailyCashFlow(today, today);
            if (flow.Count > 0)
            {
                var f = flow[0];
                summary.TodayCashIn = f.TotalIn;
                summary.TodayCashOut = f.TotalOut;
                summary.CurrentBalance = f.ClosingBalance;
            }

            var balance = reports.GetCurrentTreasuryBalance();
            if (balance != null) summary.CurrentBalance = balance.CurrentBalance;

            var lowStock = reports.GetLowStockSuggestions();
            summary.LowStockCount = lowStock.Count;
            int zero = 0;
            foreach (var item in lowStock)
                if (item.CurrentStock <= 0) zero++;
            summary.ZeroStockCount = zero;

            summary.TopParts = reports.GetTopSellingParts(topPartsCount);

            return summary;
        }
    }


}

