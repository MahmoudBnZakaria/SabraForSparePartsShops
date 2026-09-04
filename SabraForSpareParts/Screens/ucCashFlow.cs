using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens { 
    public partial class ucCashFlow : SabraUserControl
    {
        #region Models

        private class CashFlowData
        {
            public decimal Inflows { get; set; }
            public decimal Outflows { get; set; }
            public decimal CurrentBalance { get; set; }

            public List<decimal> DailyInflows { get; set; } = new();
            public List<decimal> DailyOutflows { get; set; } = new();

            public List<(string Name, decimal Amount)> OutflowBreakdown { get; set; }
                = new();
        }

        #endregion

        #region Fields

        private CashFlowData _currentData;

        private readonly CultureInfo _arabicCulture =
            new CultureInfo("ar-EG");

        #endregion

        public ucCashFlow()
        {
            InitializeComponent();

            ConfigurePeriodComboBox();

            LoadMockData();

            UpdateReport();
        }

        #region Initialization

        private void ConfigurePeriodComboBox()
        {
            if (cmbPeriod.Items.Count == 0)
            {
                cmbPeriod.Items.Add("هذا الشهر");
                cmbPeriod.Items.Add("الشهر الماضي");
                cmbPeriod.Items.Add("هذا العام");
            }

            if (cmbPeriod.SelectedIndex == -1)
                cmbPeriod.SelectedIndex = 0;
        }

        private void LoadMockData()
        {
            _currentData = new CashFlowData
            {
                Inflows = 184750m,
                Outflows = 97320m,
                CurrentBalance = 428500m,

                DailyInflows = new List<decimal>
                {
                    12500,
                    18200,
                    9800,
                    15400,
                    22100,
                    17600,
                    24500
                },

                DailyOutflows = new List<decimal>
                {
                    5200,
                    7300,
                    4100,
                    8500,
                    6200,
                    9100,
                    7400
                },

                OutflowBreakdown = new List<(string Name, decimal Amount)>
                {
                    ("شراء بضاعة", 42500),
                    ("رواتب الموظفين", 21800),
                    ("مصاريف تشغيلية", 12500),
                    ("نقل وشحن", 8200),
                    ("كهرباء ومياه", 5320),
                    ("مصروفات أخرى", 7000)
                }
            };
        }

        #endregion

        #region Main Update

        private void UpdateReport()
        {
            if (_currentData == null)
                return;

            UpdateCards();

            UpdateMonthLabel();

            LoadCashFlowChart();

            LoadOutflowBreakdown();
        }

        #endregion

        #region Cards

        private void UpdateCards()
        {
            decimal netFlow =
                _currentData.Inflows -
                _currentData.Outflows;

            lblTotalInflows.Text =
                $"{_currentData.Inflows:N0}";

            lblTotalOutflows.Text =
                $"{_currentData.Outflows:N0}";

            lblMonthlyNet.Text =
                $"{netFlow:N0}";

            lblCurrentBalance.Text =
                $"{_currentData.CurrentBalance:N0}";

            // لون صافي التدفق
            if (netFlow >= 0)
                lblMonthlyNet.ForeColor = Color.Green;
            else
                lblMonthlyNet.ForeColor = Color.Red;
        }

        #endregion

        #region Period

        private void cmbPeriod_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            switch (cmbPeriod.SelectedIndex)
            {
                case 0:
                    LoadCurrentMonthMockData();
                    break;

                case 1:
                    LoadPreviousMonthMockData();
                    break;

                case 2:
                    LoadYearMockData();
                    break;
            }

            UpdateReport();
        }

        private void LoadCurrentMonthMockData()
        {
            _currentData = new CashFlowData
            {
                Inflows = 184750m,
                Outflows = 97320m,
                CurrentBalance = 428500m,

                DailyInflows = new List<decimal>
                {
                    12500,
                    18200,
                    9800,
                    15400,
                    22100,
                    17600,
                    24500
                },

                DailyOutflows = new List<decimal>
                {
                    5200,
                    7300,
                    4100,
                    8500,
                    6200,
                    9100,
                    7400
                },

                OutflowBreakdown = new List<(string, decimal)>
                {
                    ("شراء بضاعة", 42500),
                    ("رواتب الموظفين", 21800),
                    ("مصاريف تشغيلية", 12500),
                    ("نقل وشحن", 8200),
                    ("كهرباء ومياه", 5320),
                    ("مصروفات أخرى", 7000)
                }
            };
        }

        private void LoadPreviousMonthMockData()
        {
            _currentData = new CashFlowData
            {
                Inflows = 162400m,
                Outflows = 104800m,
                CurrentBalance = 341070m,

                DailyInflows = new List<decimal>
                {
                    9800,
                    14200,
                    11700,
                    18500,
                    16200,
                    20100,
                    17800
                },

                DailyOutflows = new List<decimal>
                {
                    6200,
                    8100,
                    7500,
                    9200,
                    11300,
                    8700,
                    12600
                },

                OutflowBreakdown = new List<(string, decimal)>
                {
                    ("شراء بضاعة", 49200),
                    ("رواتب الموظفين", 24000),
                    ("مصاريف تشغيلية", 11800),
                    ("نقل وشحن", 7600),
                    ("كهرباء ومياه", 5200),
                    ("مصروفات أخرى", 7000)
                }
            };
        }

        private void LoadYearMockData()
        {
            _currentData = new CashFlowData
            {
                Inflows = 2184750m,
                Outflows = 1278320m,
                CurrentBalance = 428500m,

                DailyInflows = new List<decimal>
                {
                    32500,
                    38200,
                    29800,
                    35400,
                    42100,
                    37600,
                    44500
                },

                DailyOutflows = new List<decimal>
                {
                    15200,
                    17300,
                    14100,
                    18500,
                    16200,
                    19100,
                    17400
                },

                OutflowBreakdown = new List<(string, decimal)>
                {
                    ("شراء بضاعة", 625000),
                    ("رواتب الموظفين", 285000),
                    ("مصاريف تشغيلية", 142000),
                    ("نقل وشحن", 98000),
                    ("كهرباء ومياه", 56320),
                    ("مصروفات أخرى", 72000)
                }
            };
        }

        private void UpdateMonthLabel()
        {
            DateTime date;

            switch (cmbPeriod.SelectedIndex)
            {
                case 1:
                    date = DateTime.Today.AddMonths(-1);

                    lblMonthAndYear.Text =
                        date.ToString(
                            "MMMM yyyy",
                            _arabicCulture);
                    break;

                case 2:
                    lblMonthAndYear.Text =
                        $"عام {DateTime.Today.Year}";
                    break;

                default:
                    date = DateTime.Today;

                    lblMonthAndYear.Text =
                        date.ToString(
                            "MMMM yyyy",
                            _arabicCulture);
                    break;
            }
        }

        #endregion

        #region Cash Flow Chart

        private void LoadCashFlowChart()
        {
            if (cartesianChart1 == null)
                return;

            string[] labels;

            if (cmbPeriod.SelectedIndex == 2)
            {
                labels = new[]
                {
                    "يناير",
                    "فبراير",
                    "مارس",
                    "أبريل",
                    "مايو",
                    "يونيو",
                    "يوليو"
                };
            }
            else
            {
                labels = GetLastSevenDaysLabels();
            }

            cartesianChart1.Series = new ISeries[]
            {
                new ColumnSeries<decimal>
                {
                    Name = "التدفقات الداخلة",
                    Values = _currentData.DailyInflows,
                    Fill = new SolidColorPaint(
                        SKColors.ForestGreen)
                },

                new ColumnSeries<decimal>
                {
                    Name = "التدفقات الخارجة",
                    Values = _currentData.DailyOutflows,
                    Fill = new SolidColorPaint(
                        SKColors.IndianRed)
                }
            };

            cartesianChart1.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = labels,

                    LabelsRotation = 0
                }
            };

            cartesianChart1.YAxes = new Axis[]
            {
                new Axis
                {
                    Labeler = value =>
                        $"{value:N0} ج"
                }
            };

            cartesianChart1.LegendPosition =
                LiveChartsCore.Measure.LegendPosition.Bottom;
        }

        private string[] GetLastSevenDaysLabels()
        {
            return Enumerable
                .Range(6, 7)
                .Select(i =>
                    DateTime.Today
                        .AddDays(-i)
                        .ToString("ddd", _arabicCulture))
                .ToArray();
        }

        #endregion

        #region Outflow Breakdown

        private void LoadOutflowBreakdown()
        {
            if (FlowLayoutPanelOutflowBreakdown == null)
                return;

            FlowLayoutPanelOutflowBreakdown.Controls.Clear();

            FlowLayoutPanelOutflowBreakdown.WrapContents = false;
            FlowLayoutPanelOutflowBreakdown.FlowDirection =
                FlowDirection.TopDown;

            FlowLayoutPanelOutflowBreakdown.AutoScroll = true;

            decimal total =
                _currentData.OutflowBreakdown.Sum(x => x.Amount);

            foreach (var item in _currentData.OutflowBreakdown)
            {
                var row = new Screens.ucItemsRow();

                row.Width =
                    Math.Max(
                        FlowLayoutPanelOutflowBreakdown.ClientSize.Width - 5,
                        250);

                row.Height = 45;

                row.SetData(
                    item.Name,
                    $"{item.Amount:N0} ج");

                row.RowClicked += OutflowRowClicked;

                FlowLayoutPanelOutflowBreakdown.Controls.Add(row);
            }
        }

        private void OutflowRowClicked(
            object sender,
            EventArgs e)
        {
            if (sender is Screens.ucItemsRow row)
            {
                // هنا لاحقًا ممكن تفتح تفاصيل المصروف
                // حسب نوع المصروف
            }
        }

        #endregion

        #region Print

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using var dgv = CreatePrintDataGridView();

                clsGlobalClass.PrintDataGridView(
                    dgv,
                    "التدفقات النقدية");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء الطباعة:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private DataGridView CreatePrintDataGridView()
        {
            var dgv = new DataGridView();

            dgv.Columns.Add(
                "Type",
                "نوع العملية");

            dgv.Columns.Add(
                "Amount",
                "المبلغ");

            dgv.Columns.Add(
                "Description",
                "البيان");

            dgv.Columns.Add(
                "Date",
                "التاريخ");

            dgv.Rows.Add(
                "تدفق داخل",
                $"{_currentData.Inflows:N0} ج",
                "إجمالي التدفقات الداخلة",
                DateTime.Today.ToString("dd/MM/yyyy"));

            dgv.Rows.Add(
                "تدفق خارج",
                $"{_currentData.Outflows:N0} ج",
                "إجمالي التدفقات الخارجة",
                DateTime.Today.ToString("dd/MM/yyyy"));

            dgv.Rows.Add(
                "صافي",
                $"{(_currentData.Inflows - _currentData.Outflows):N0} ج",
                "صافي التدفق",
                DateTime.Today.ToString("dd/MM/yyyy"));

            dgv.Rows.Add(
                "الرصيد",
                $"{_currentData.CurrentBalance:N0} ج",
                "الرصيد الحالي",
                DateTime.Today.ToString("dd/MM/yyyy"));

            dgv.RightToLeft = RightToLeft.Yes;

            return dgv;
        }

        #endregion

        #region Excel

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using var dgv = CreatePrintDataGridView();

                clsGlobalClass.ExportDataGridViewToExcel(
                    dgv,
                    "التدفقات النقدية",
                    "CashFlow");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء تصدير البيانات:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Card Events

        private void lblTotalInflows_Click(
            object sender,
            EventArgs e)
        {
            ShowCardMessage(
                "إجمالي التدفقات الداخلة",
                _currentData.Inflows);
        }

        private void lblTotalOutflows_Click(
            object sender,
            EventArgs e)
        {
            ShowCardMessage(
                "إجمالي التدفقات الخارجة",
                _currentData.Outflows);
        }

        private void lblMonthlyNet_Click(
            object sender,
            EventArgs e)
        {
            decimal net =
                _currentData.Inflows -
                _currentData.Outflows;

            ShowCardMessage(
                "صافي التدفق",
                net);
        }

        private void lblCurrentBalance_Click(
            object sender,
            EventArgs e)
        {
            ShowCardMessage(
                "الرصيد الحالي",
                _currentData.CurrentBalance);
        }

        private void ShowCardMessage(
            string title,
            decimal amount)
        {
            MessageBox.Show(
                $"{title}\n\n{amount:N0} ج",
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion

        #region Events

        private void lblMonthAndYear_Click(
            object sender,
            EventArgs e)
        {
            // لا يوجد إجراء حاليًا
        }

        private void pnlNetProfit_Paint(
            object sender,
            PaintEventArgs e)
        {
            // الرسم يتم من SabraPanel
        }

        private void cartesianChart1_Load(
            object sender,
            EventArgs e)
        {
            LoadCashFlowChart();
        }

        private void FlowLayoutPanelOutflowBreakdown_Paint(
            object sender,
            PaintEventArgs e)
        {
            // يتم إنشاء الـ rows في LoadOutflowBreakdown
        }

        private void sabraLabel5_Click(
            object sender,
            EventArgs e)
        {
            // عنوان القسم
        }

        #endregion
    }
}