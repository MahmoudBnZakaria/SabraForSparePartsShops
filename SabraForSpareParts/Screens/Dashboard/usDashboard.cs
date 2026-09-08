using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
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
        public usDashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            LoadWeeklySalesChart();
            LoadSalesDistributionChart();
            LoadRecentInvoicesMock();
            LoadUrgentAlertsMock();
            LoadPendingOrdersMock();
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

            var series = result.Data.Select(part => new PieSeries<double>{ 
                    Name = part.PartName,
                    Values = new[] { 
                        (double)part.TotalQtySold
                    },
                    InnerRadius = 60,

            }).ToArray();

            pieChart1.Series = series;
            pieChart1.LegendPosition = LegendPosition.Right;
        }

        private void LoadRecentInvoicesMock()
        {
            var sampleInvoices = new List<(int Id, string Customer, decimal Amount, string Status)>
            {
                (1084, "ورشة النيل", 3200m, "مسدد"),
                (1083, "محمد علي", 850m, "جزئي"),
                (1082, "عميل نقدي", 1450m, "مسدد"),
                (1081, "ورشة الأمل", 7600m, "آجل")
            };

            PopulateFlowLayoutPanel(flpRecentInvoices, sampleInvoices, inv =>
            {
                var row = new ucInvoiceRow();
                row.SetData(inv.Id, inv.Customer, inv.Amount, inv.Status);
                return row;
            }, 10);
        }

        private void LoadUrgentAlertsMock()
        {
            var alerts = new List<(string Name, int Qty)>
            {
                ("فلتر زيت تويوتا", 2),
                ("بوجية NGK", 0),
                ("تيل فرامل هيونداي", 3)
            };

            PopulateFlowLayoutPanel(flpAlerts, alerts, alert =>
            {
                var row = new ucAlertRow();
                row.SetData(alert.Name, alert.Qty);
                return row;
            }, 5);
        }

        private void LoadPendingOrdersMock()
        {
            var pendingOrders = new List<(string Code, string Supplier, decimal Amount)>
            {
                ("PO-0045", "بوش", 15200m),
                ("PO-0044", "NGK", 8400m)
            };

            PopulateFlowLayoutPanel(flpPendingOrders, pendingOrders, po =>
            {
                var row = new ucPendingPORow();
                row.SetData(po.Code, po.Supplier, po.Amount);
                return row;
            }, 5);
        }

        // ==========================================
        // دوال مساعدة (Helper Methods)
        // ==========================================

        /// <summary>
        /// دالة عامة لتفريغ وإعادة تعبئة أي FlowLayoutPanel بطريقة ديناميكية
        /// </summary>
        private void PopulateFlowLayoutPanel<T>(FlowLayoutPanel panel, IEnumerable<T> data, Func<T, UserControl> controlCreator, int widthMargin)
        {
            panel.SuspendLayout();
            panel.Controls.Clear();

            foreach (var item in data)
            {
                // إنشاء الـ UserControl باستخدام الدالة الممررة
                UserControl ctrl = controlCreator(item);

                // ضبط العرض لملء الحاوية
                ctrl.Width = panel.ClientSize.Width - widthMargin;

                panel.Controls.Add(ctrl);
            }

            panel.ResumeLayout();
        }
    }
}