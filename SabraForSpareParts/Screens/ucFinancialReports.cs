using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;

using SkiaSharp;

namespace SabraForSpareParts.Screens
{
    public partial class ucFinancialReports : SabraUserControl
    {
        private bool _isLoading;

        public ucFinancialReports()
        {
            InitializeComponent();

            // لا نحمل البيانات داخل Constructor
            // حتى لا يسبب مشاكل مع WinForms Designer
        }

        #region Load

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            if (_isLoading)
                return;

            _isLoading = true;

            try
            {
                InitializeReport();
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void InitializeReport()
        {
            cmbPeriod.SelectedIndexChanged -= cmbPeriod_SelectedIndexChanged;

            if (cmbPeriod.Items.Count == 0)
            {
                cmbPeriod.Items.Add("هذا الشهر");
                cmbPeriod.Items.Add("الشهر الماضي");
                cmbPeriod.Items.Add("هذا العام");
            }

            if (cmbPeriod.SelectedIndex < 0)
                cmbPeriod.SelectedIndex = 0;

            cmbPeriod.SelectedIndexChanged += cmbPeriod_SelectedIndexChanged;

            LoadReportData();
        }

        #endregion

        #region Main Report

        private void LoadReportData()
        {
            if (DesignMode)
                return;

            int period = cmbPeriod.SelectedIndex;

            switch (period)
            {
                case 0:
                    LoadThisMonthReport();
                    break;

                case 1:
                    LoadLastMonthReport();
                    break;

                case 2:
                    LoadYearReport();
                    break;

                default:
                    LoadThisMonthReport();
                    break;
            }
        }

        #endregion

        #region This Month

        private void LoadThisMonthReport()
        {
            lblMonthAndYear.Text = "يناير 2025";

            // Cards
            lblTotalSales.Text = "847,230 ج";
            lblGrossProfit.Text = "186,450 ج";
            lblTotalExpenses.Text = "92,300 ج";
            lblNetProfit.Text = "94,150 ج";

            // Charts
            LoadThisMonthWeeklySales();
            LoadThisMonthSalesDistribution();

            // Best selling
            LoadBestSellingItems(new List<BestSellingItem>
            {
                new BestSellingItem("فلتر زيت تويوتا", 284),
                new BestSellingItem("تيل فرامل أمامي", 215),
                new BestSellingItem("فلتر هواء", 187),
                new BestSellingItem("بوجيه NGK", 164),
                new BestSellingItem("سير دينامو", 142)
            });
        }

        #endregion

        #region Last Month

        private void LoadLastMonthReport()
        {
            lblMonthAndYear.Text = "ديسمبر 2024";

            // Cards
            lblTotalSales.Text = "792,580 ج";
            lblGrossProfit.Text = "171,320 ج";
            lblTotalExpenses.Text = "88,750 ج";
            lblNetProfit.Text = "82,570 ج";

            // Charts
            LoadLastMonthWeeklySales();
            LoadLastMonthSalesDistribution();

            // Best selling
            LoadBestSellingItems(new List<BestSellingItem>
            {
                new BestSellingItem("فلتر هواء", 241),
                new BestSellingItem("فلتر زيت تويوتا", 226),
                new BestSellingItem("تيل فرامل أمامي", 198),
                new BestSellingItem("بوجيه NGK", 176),
                new BestSellingItem("سير دينامو", 131)
            });
        }

        #endregion

        #region This Year

        private void LoadYearReport()
        {
            lblMonthAndYear.Text = "2025";

            // Cards
            lblTotalSales.Text = "9,842,750 ج";
            lblGrossProfit.Text = "2,146,380 ج";
            lblTotalExpenses.Text = "1,083,200 ج";
            lblNetProfit.Text = "1,063,180 ج";

            // Charts
            LoadYearSalesChart();
            LoadYearSalesDistribution();

            // Best selling
            LoadBestSellingItems(new List<BestSellingItem>
            {
                new BestSellingItem("فلتر زيت تويوتا", 3_284),
                new BestSellingItem("تيل فرامل أمامي", 2_915),
                new BestSellingItem("فلتر هواء", 2_687),
                new BestSellingItem("بوجيه NGK", 2_364),
                new BestSellingItem("سير دينامو", 2_142)
            });
        }

        #endregion

        #region Weekly Sales Chart

        private void LoadThisMonthWeeklySales()
        {
            double[] sales =
            {
                42000,
                57000,
                48000,
                73000,
                61000,
                85000,
                69000
            };

            string[] labels =
            {
                "السبت",
                "الأحد",
                "الإثنين",
                "الثلاثاء",
                "الأربعاء",
                "الخميس",
                "الجمعة"
            };

            LoadColumnChart(labels, sales);
        }

        private void LoadLastMonthWeeklySales()
        {
            double[] sales =
            {
                38000,
                52000,
                46000,
                64000,
                59000,
                76000,
                62000
            };

            string[] labels =
            {
                "السبت",
                "الأحد",
                "الإثنين",
                "الثلاثاء",
                "الأربعاء",
                "الخميس",
                "الجمعة"
            };

            LoadColumnChart(labels, sales);
        }

        private void LoadColumnChart(
            string[] labels,
            double[] values)
        {
            cartesianChart1.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Name = "المبيعات",
                    Values = values,

                    Stroke = null,

                    DataLabelsSize = 0
                }
            };

            cartesianChart1.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = labels,

                    LabelsRotation = 0,

                    TextSize = 13,

                    SeparatorsPaint =
                        new SolidColorPaint(
                            new SKColor(220, 225, 232)
                        )
                }
            };

            cartesianChart1.YAxes = new Axis[]
            {
                new Axis
                {
                    Labeler = value =>
                        $"{value:N0} ج",

                    TextSize = 12,

                    SeparatorsPaint =
                        new SolidColorPaint(
                            new SKColor(220, 225, 232)
                        )
                }
            };

            cartesianChart1.LegendPosition =
                LiveChartsCore.Measure.LegendPosition.Bottom;
        }

        #endregion

        #region Year Sales Chart

        private void LoadYearSalesChart()
        {
            string[] labels =
            {
                "يناير",
                "فبراير",
                "مارس",
                "أبريل",
                "مايو",
                "يونيو",
                "يوليو",
                "أغسطس",
                "سبتمبر",
                "أكتوبر",
                "نوفمبر",
                "ديسمبر"
            };

            double[] sales =
            {
                620000,
                710000,
                680000,
                790000,
                735000,
                820000,
                850000,
                910000,
                870000,
                940000,
                890000,
                1_027_750
            };

            LoadColumnChart(labels, sales);
        }

        #endregion

        #region Sales Distribution

        private void LoadThisMonthSalesDistribution()
        {
            pieChart1.Series = new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "فلاتر",
                    Values = new[] { 35.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "فرامل",
                    Values = new[] { 22.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "بواجي",
                    Values = new[] { 18.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "تعليق",
                    Values = new[] { 15.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "أخرى",
                    Values = new[] { 10.0 },
                    InnerRadius = 60
                }
            };

            pieChart1.LegendPosition =
                LiveChartsCore.Measure.LegendPosition.Right;
        }

        private void LoadLastMonthSalesDistribution()
        {
            pieChart1.Series = new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "فلاتر",
                    Values = new[] { 31.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "فرامل",
                    Values = new[] { 25.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "بواجي",
                    Values = new[] { 20.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "تعليق",
                    Values = new[] { 14.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "أخرى",
                    Values = new[] { 10.0 },
                    InnerRadius = 60
                }
            };

            pieChart1.LegendPosition =
                LiveChartsCore.Measure.LegendPosition.Right;
        }

        private void LoadYearSalesDistribution()
        {
            pieChart1.Series = new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "فلاتر",
                    Values = new[] { 34.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "فرامل",
                    Values = new[] { 24.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "بواجي",
                    Values = new[] { 17.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "تعليق",
                    Values = new[] { 15.0 },
                    InnerRadius = 60
                },

                new PieSeries<double>
                {
                    Name = "أخرى",
                    Values = new[] { 10.0 },
                    InnerRadius = 60
                }
            };

            pieChart1.LegendPosition =
                LiveChartsCore.Measure.LegendPosition.Right;
        }

        #endregion

        #region Best Selling Items

        private class BestSellingItem
        {
            public string Name { get; set; }

            public int Units { get; set; }

            public BestSellingItem(
                string name,
                int units)
            {
                Name = name;
                Units = units;
            }
        }

        private void LoadBestSellingItems(
            List<BestSellingItem> items)
        {
            sabraFlowLayoutPanelBestSellingItems.SuspendLayout();

            try
            {
                sabraFlowLayoutPanelBestSellingItems.Controls.Clear();

                foreach (var item in items)
                {
                    var row =
                        new ucItemsRow();

                    row.ItemName = item.Name;
                    row.SoldUnits = item.Units;

                    row.Width =
                        sabraFlowLayoutPanelBestSellingItems.ClientSize.Width - 5;

                    row.Dock = DockStyle.Top;

                    row.Margin = new Padding(0);

                    row.RowClicked +=
                        BestSellingItem_RowClicked;

                    sabraFlowLayoutPanelBestSellingItems.Controls.Add(row);
                }
            }
            finally
            {
                sabraFlowLayoutPanelBestSellingItems.ResumeLayout();
            }
        }

        private void BestSellingItem_RowClicked(
            object sender,
            EventArgs e)
        {
            if (sender is not ucItemsRow row)
                return;

            MessageBox.Show(
                $"الصنف: {row.ItemName}\n" +
                $"عدد الوحدات المباعة: {row.SoldUnits:N0} وحدة",
                "تفاصيل الصنف",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

        #region Period

        private void cmbPeriod_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (_isLoading)
                return;

            LoadReportData();
        }

        #endregion

        #region Print

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using DataGridView dgv =
                    CreateReportDataGridView();

                clsGlobalClass.PrintDataGridView(
                    dgv,
                    $"Financial Reports - {lblMonthAndYear.Text}"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء الطباعة:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #endregion

        #region Export Excel

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using DataGridView dgv =
                    CreateReportDataGridView();

                clsGlobalClass.ExportDataGridViewToExcel(
                    dgv,
                    "",
                    $"Financial Reports - {lblMonthAndYear.Text}"
                );

                MessageBox.Show(
                    "تم تصدير التقرير إلى Excel بنجاح.",
                    "تم",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء التصدير:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #endregion

        #region Report DataGridView

        private DataGridView CreateReportDataGridView()
        {
            DataGridView dgv = new DataGridView();

            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;

            dgv.Columns.Add(
                "Item",
                "البيان"
            );

            dgv.Columns.Add(
                "Value",
                "القيمة"
            );

            dgv.Rows.Add(
                "إجمالي المبيعات",
                lblTotalSales.Text
            );

            dgv.Rows.Add(
                "إجمالي الأرباح",
                lblGrossProfit.Text
            );

            dgv.Rows.Add(
                "إجمالي المصروفات",
                lblTotalExpenses.Text
            );

            dgv.Rows.Add(
                "صافي الربح",
                lblNetProfit.Text
            );

            dgv.Rows.Add(
                "الفترة",
                lblMonthAndYear.Text
            );

            return dgv;
        }

        #endregion

        #region Existing Events

        private void sabraFlowLayoutPanelBestSellingItems_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void pieChart1_Load(
            object sender,
            EventArgs e)
        {
            // البيانات يتم تحميلها من InitializeReport
        }

        private void cartesianChart1_Load(
            object sender,
            EventArgs e)
        {
            // البيانات يتم تحميلها من InitializeReport
        }

        private void lblTotalSales_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblGrossProfit_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTotalExpenses_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblNetProfit_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblMonthAndYear_Click(
            object sender,
            EventArgs e)
        {
        }

        #endregion
    }
}