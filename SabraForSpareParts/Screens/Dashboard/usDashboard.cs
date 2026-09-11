using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using Sabra.DataLayer.DataAccess;
using Sabra.LogicLayer;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class usDashboard : SabraUserControl
    {
        private clsReportsBusiness _reportsBusiness = new clsReportsBusiness();
        private clsSalesInvoiceBusiness _salesInvoiceBusiness = new clsSalesInvoiceBusiness();
        private clsPurchaseOrderBusiness _purchaseOrderBusiness = new clsPurchaseOrderBusiness();
        private clsLookupDAL _lookUpDAL = new clsLookupDAL();
        public usDashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            LoadWeeklySalesChart();
            LoadSalesDistributionChart();
            LoadRecentInvoices();
            LoadUrgentAlerts();
            LoadPendingOrders();
            LoadPanelsNumbers();

            var culture = new System.Globalization.CultureInfo("ar-EG");

            lblDate.Text = DateTime.Now.ToString("dddd d MMMM yyyy", culture);

            lblLastRefresh.Text = "آخر تحديث " + DateTime.Now.ToString("hh:mm tt", culture);
        }


        private void LoadWeeklySalesChart()
        {
            var from = DateTime.Today.AddDays(-6);
            var to = DateTime.Today.AddDays(1);

            var result = _reportsBusiness.GetDailyProfits(from, to);

            if (!result.Success || result.Data == null)
                return;

            var culture = new CultureInfo("ar-EG");

            var dailyData = Enumerable.Range(0, 7)
                .Select(i =>
                {
                    var date = DateTime.Today.AddDays(-6 + i);

                    var day = result.Data.FirstOrDefault(x =>
                        x.SaleDate.Date == date.Date);

                    return new
                    {
                        Date = date,
                        Sales = day?.TotalRevenue ?? 0
                    };
                })
                .ToList();

            var sales = dailyData
                .Select(x => (double)x.Sales)
                .ToArray();

            var labels = dailyData
                .Select(x =>
                    culture.DateTimeFormat.GetDayName(x.Date.DayOfWeek))
                .ToArray();

            cartesianChart1.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Values = sales
                }
            };

            cartesianChart1.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = labels
                }
            };

            cartesianChart1.YAxes = new Axis[]
            {
                new Axis()
            };

            cartesianChart1.LegendPosition = LegendPosition.Bottom;
        }

        private void LoadSalesDistributionChart()
        {
            var result = _reportsBusiness.GetTopSellingParts(5);
            if (!result.Success || result.Data == null || !result.Data.Any())
                return;

            var series = result.Data.Select(part => new PieSeries<double>
            {
                Name = part.PartName,
                Values = new[] {
                        (double)part.TotalQtySold
                    },
                InnerRadius = 60,

            }).ToArray();

            pieChart1.Series = series;
            pieChart1.LegendPosition = LegendPosition.Right;
        }

        private void LoadUrgentAlerts()
        {
            var result = _reportsBusiness.GetLowStockSuggestions();
            if (!result.Success || result.Data == null)
                return;

            PopulateFlowLayoutPanel(flpAlerts, result.Data, alert =>
            {
                var row = new ucAlertRow();
                row.SetData(alert.PartName, alert.CurrentStock);
                return row;
            }, 5);
        }


        private void LoadRecentInvoices()
        {
            flpRecentInvoices.SuspendLayout();

            foreach (Control control in flpRecentInvoices.Controls)
            {
                control.Dispose();
            }
            flpRecentInvoices.Controls.Clear();

            var invoices = _salesInvoiceBusiness.GetAll(DateTime.Now.AddDays(-3), DateTime.Now);
            if (invoices != null)
            {
                PopulateFlowLayoutPanel(flpRecentInvoices, invoices.Data, inv =>
                {
                    var row = new ucInvoiceRow();
                    row.SetData(inv.InvoiceID, inv.CustomerName, inv.FinalAmount, inv.PaymentStatus);
                    return row;
                }, 10);
            }


            flpRecentInvoices.ResumeLayout();
        }

        private void LoadPendingOrders()
        {
            var POStatuses = _lookUpDAL.GetAllPOStatuses();
            var status = POStatuses.FirstOrDefault(s => s.StatusName == "قيد الانتظار");
            var pendingOrders = _purchaseOrderBusiness.GetAll(null, status?.StatusID);

            if (pendingOrders != null)
            {

                PopulateFlowLayoutPanel(flpPendingOrders, pendingOrders.Data, po =>
                {
                    var row = new ucPendingPORow();
                    row.SetData(po.POID, po.SupplierName, po.TotalAmount);
                    return row;
                }, 5);
            }
        }

        private void PopulateFlowLayoutPanel<T>(FlowLayoutPanel panel, IEnumerable<T> data, Func<T, UserControl> controlCreator, int widthMargin)
        {
            panel.SuspendLayout();
            panel.Controls.Clear();

            foreach (var item in data)
            {
                UserControl ctrl = controlCreator(item);

                ctrl.Width = panel.ClientSize.Width - widthMargin;

                panel.Controls.Add(ctrl);
            }

            panel.ResumeLayout();
        }

        private void LoadPanelsNumbers()
        {
            var Info = _reportsBusiness.GetDashboardSummary();
            lblSales.Text = Info.Data.TodaySales.ToString();
            lblNetProfit.Text = Info.Data.TodayNetProfit.ToString();
            lblLowStockCount.Text = Info.Data.LowStockCount.ToString();
            lblUnpaidInvoices.Text = Info.Data.TodayInvoiceCount.ToString();
        }

        private void sbtnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
    }
}