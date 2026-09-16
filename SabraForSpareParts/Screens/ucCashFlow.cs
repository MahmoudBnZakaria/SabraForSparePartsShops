using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.LogicLayer;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucCashFlow : SabraUserControl
    {
        #region Fields

        private readonly clsReportsBusiness _reports =
            new clsReportsBusiness();

        private readonly CultureInfo _arabicCulture =
            new CultureInfo("ar-EG");

        private List<DailyCashFlowView> _cashFlowData =
            new List<DailyCashFlowView>();

        private DateTime? _currentFrom;
        private DateTime? _currentTo;

        #endregion


        #region Constructor

        public ucCashFlow()
        {
            InitializeComponent();

            ConfigurePeriodComboBox();

            LoadSelectedPeriod();

            UpdateReport();
        }

        #endregion


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

        #endregion


        #region Data Loading

        private void LoadSelectedPeriod()
        {
            try
            {
                GetSelectedPeriod(
                    out DateTime from,
                    out DateTime to);

                _currentFrom = from;
                _currentTo = to;

                var result = _reports.GetDailyCashFlow(from, to);

                if (result.Success)
                    _cashFlowData = result.Data;
                else {
                    _cashFlowData?.Clear();

                    MessageBox.Show(
                        $"حدث خطأ أثناء تحميل تقرير التدفقات النقدية:\n\n{result.Message}",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _cashFlowData.Clear();

                MessageBox.Show(
                    $"حدث خطأ أثناء تحميل تقرير التدفقات النقدية:\n\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GetSelectedPeriod(
            out DateTime from,
            out DateTime to)
        {
            DateTime today = DateTime.Today;

            switch (cmbPeriod.SelectedIndex)
            {
                // هذا الشهر
                case 0:

                    from = new DateTime(
                        today.Year,
                        today.Month,
                        1);

                    to = today;

                    break;


                // الشهر الماضي
                case 1:

                    DateTime previousMonth =
                        today.AddMonths(-1);

                    from = new DateTime(
                        previousMonth.Year,
                        previousMonth.Month,
                        1);

                    to = from
                        .AddMonths(1)
                        .AddDays(-1);

                    break;


                // هذا العام
                case 2:

                    from = new DateTime(
                        today.Year,
                        1,
                        1);

                    to = today;

                    break;


                default:

                    from = today;
                    to = today;

                    break;
            }
        }

        #endregion


        #region Main Update

        private void UpdateReport()
        {
            UpdateCards();

            UpdatePeriodLabel();

            LoadCashFlowChart();

            LoadOutflowBreakdown();
        }

        #endregion


        #region Cards

        private void UpdateCards()
        {
            decimal totalInflows =
                _cashFlowData.Sum(x => x.TotalIn);

            decimal totalOutflows =
                _cashFlowData.Sum(x => x.TotalOut);

            decimal netFlow =
                totalInflows - totalOutflows;

            decimal currentBalance = 0m;

            if (_cashFlowData.Count > 0)
            {
                currentBalance =
                    _cashFlowData
                        .OrderBy(x => x.FlowDate)
                        .Last()
                        .ClosingBalance;
            }

            lblTotalInflows.Text =
                $"{totalInflows:N0}";

            lblTotalOutflows.Text =
                $"{totalOutflows:N0}";

            lblMonthlyNet.Text =
                $"{netFlow:N0}";

            lblCurrentBalance.Text =
                $"{currentBalance:N0}";


            lblMonthlyNet.ForeColor =
                netFlow >= 0
                    ? Color.Green
                    : Color.Red;
        }

        #endregion


        #region Period

        private void cmbPeriod_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadSelectedPeriod();

            UpdateReport();
        }

        private void UpdatePeriodLabel()
        {
            switch (cmbPeriod.SelectedIndex)
            {
                case 0:

                    lblMonthAndYear.Text =
                        DateTime.Today.ToString(
                            "MMMM yyyy",
                            _arabicCulture);

                    break;


                case 1:

                    DateTime previousMonth =
                        DateTime.Today.AddMonths(-1);

                    lblMonthAndYear.Text =
                        previousMonth.ToString(
                            "MMMM yyyy",
                            _arabicCulture);

                    break;


                case 2:

                    lblMonthAndYear.Text =
                        $"عام {DateTime.Today.Year}";

                    break;


                default:

                    lblMonthAndYear.Text =
                        DateTime.Today.ToString(
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


            if (_cashFlowData == null ||
                _cashFlowData.Count == 0)
            {
                cartesianChart1.Series =
                    Array.Empty<ISeries>();

                cartesianChart1.XAxes =
                    Array.Empty<Axis>();

                cartesianChart1.YAxes =
                    Array.Empty<Axis>();

                return;
            }


            if (cmbPeriod.SelectedIndex == 2)
            {
                LoadYearCashFlowChart();
                return;
            }


            LoadDailyCashFlowChart();
        }


        private void LoadDailyCashFlowChart()
        {
            var data =
                _cashFlowData
                    .OrderBy(x => x.FlowDate)
                    .ToList();


            string[] labels =
                data
                    .Select(x =>
                        x.FlowDate.ToString(
                            "dd",
                            _arabicCulture))
                    .ToArray();


            var inflows =
                data
                    .Select(x => x.TotalIn)
                    .ToArray();


            var outflows =
                data
                    .Select(x => x.TotalOut)
                    .ToArray();


            cartesianChart1.Series =
                new ISeries[]
                {
                    new ColumnSeries<decimal>
                    {
                        Name = "التدفقات الداخلة",

                        Values = inflows,

                        Fill = new SolidColorPaint(
                            SKColors.ForestGreen)
                    },

                    new ColumnSeries<decimal>
                    {
                        Name = "التدفقات الخارجة",

                        Values = outflows,

                        Fill = new SolidColorPaint(
                            SKColors.IndianRed)
                    }
                };


            cartesianChart1.XAxes =
                new Axis[]
                {
                    new Axis
                    {
                        Labels = labels,

                        LabelsRotation = 0
                    }
                };


            cartesianChart1.YAxes =
                new Axis[]
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


        private void LoadYearCashFlowChart()
        {
            var monthlyData =
                _cashFlowData
                    .GroupBy(x =>
                        new
                        {
                            x.FlowDate.Year,
                            x.FlowDate.Month
                        })
                    .OrderBy(g => g.Key.Year)
                    .ThenBy(g => g.Key.Month)
                    .Select(g => new
                    {
                        Month = new DateTime(
                            g.Key.Year,
                            g.Key.Month,
                            1),

                        TotalIn =
                            g.Sum(x => x.TotalIn),

                        TotalOut =
                            g.Sum(x => x.TotalOut)
                    })
                    .ToList();


            string[] labels =
                monthlyData
                    .Select(x =>
                        x.Month.ToString(
                            "MMM",
                            _arabicCulture))
                    .ToArray();


            decimal[] inflows =
                monthlyData
                    .Select(x => x.TotalIn)
                    .ToArray();


            decimal[] outflows =
                monthlyData
                    .Select(x => x.TotalOut)
                    .ToArray();


            cartesianChart1.Series =
                new ISeries[]
                {
                    new ColumnSeries<decimal>
                    {
                        Name = "التدفقات الداخلة",

                        Values = inflows,

                        Fill = new SolidColorPaint(
                            SKColors.ForestGreen)
                    },

                    new ColumnSeries<decimal>
                    {
                        Name = "التدفقات الخارجة",

                        Values = outflows,

                        Fill = new SolidColorPaint(
                            SKColors.IndianRed)
                    }
                };


            cartesianChart1.XAxes =
                new Axis[]
                {
                    new Axis
                    {
                        Labels = labels,

                        LabelsRotation = 0
                    }
                };


            cartesianChart1.YAxes =
                new Axis[]
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

        #endregion


        #region Outflow Breakdown

        private void LoadOutflowBreakdown()
        {
            if (FlowLayoutPanelOutflowBreakdown == null)
                return;


            FlowLayoutPanelOutflowBreakdown.SuspendLayout();

            try
            {
                FlowLayoutPanelOutflowBreakdown.Controls.Clear();

                FlowLayoutPanelOutflowBreakdown.WrapContents = false;

                FlowLayoutPanelOutflowBreakdown.FlowDirection =
                    FlowDirection.TopDown;

                FlowLayoutPanelOutflowBreakdown.AutoScroll = true;


                if (_cashFlowData == null ||
                    _cashFlowData.Count == 0)
                {
                    return;
                }


                var breakdown =
                    new List<(string Name, decimal Amount)>
                    {
                        (
                            "شراء بضاعة",
                            _cashFlowData.Sum(
                                x => x.PurchasesOut)
                        ),

                        (
                            "رواتب الموظفين",
                            _cashFlowData.Sum(
                                x => x.PayrollOut)
                        ),

                        (
                            "مصاريف تشغيلية",
                            _cashFlowData.Sum(
                                x => x.ExpensesOut)
                        ),

                        (
                            "سلف الموظفين",
                            _cashFlowData.Sum(
                                x => x.AdvancesOut)
                        )
                    };


                // نخفي العناصر التي قيمتها صفر
                breakdown =
                    breakdown
                        .Where(x => x.Amount != 0)
                        .OrderByDescending(x => x.Amount)
                        .ToList();


                foreach (var item in breakdown)
                {
                    var row =
                        new Screens.ucItemsRow();

                    row.Width =
                        Math.Max(
                            FlowLayoutPanelOutflowBreakdown.ClientSize.Width - 5,
                            250);

                    row.Height = 45;


                    row.SetData(
                        item.Name,
                        $"{item.Amount:N0} ج");


                    FlowLayoutPanelOutflowBreakdown.Controls.Add(
                        row);
                }
            }
            finally
            {
                FlowLayoutPanelOutflowBreakdown.ResumeLayout();
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
                using var dgv =
                    CreatePrintDataGridView();

                clsGlobalClass.PrintDataGridView(
                    dgv,
                    "التدفقات النقدية");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء الطباعة:\n\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private DataGridView CreatePrintDataGridView()
        {
            var dgv =
                new DataGridView();


            dgv.Columns.Add(
                "Date",
                "التاريخ");

            dgv.Columns.Add(
                "TotalIn",
                "التدفقات الداخلة");

            dgv.Columns.Add(
                "SalesIn",
                "المبيعات");

            dgv.Columns.Add(
                "TotalOut",
                "التدفقات الخارجة");

            dgv.Columns.Add(
                "PurchasesOut",
                "المشتريات");

            dgv.Columns.Add(
                "PayrollOut",
                "الرواتب");

            dgv.Columns.Add(
                "ExpensesOut",
                "المصروفات");

            dgv.Columns.Add(
                "AdvancesOut",
                "السلف");

            dgv.Columns.Add(
                "NetFlow",
                "صافي التدفق");

            dgv.Columns.Add(
                "ClosingBalance",
                "الرصيد");


            foreach (var item in _cashFlowData
                .OrderBy(x => x.FlowDate))
            {
                dgv.Rows.Add(
                    item.FlowDate.ToString(
                        "dd/MM/yyyy"),

                    $"{item.TotalIn:N0} ج",

                    $"{item.SalesIn:N0} ج",

                    $"{item.TotalOut:N0} ج",

                    $"{item.PurchasesOut:N0} ج",

                    $"{item.PayrollOut:N0} ج",

                    $"{item.ExpensesOut:N0} ج",

                    $"{item.AdvancesOut:N0} ج",

                    $"{item.NetFlow:N0} ج",

                    $"{item.ClosingBalance:N0} ج");
            }


            dgv.RightToLeft =
                RightToLeft.Yes;


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
                using var dgv =
                    CreatePrintDataGridView();

                clsGlobalClass.ExportDataGridViewToExcel(
                    dgv,
                    "التدفقات النقدية",
                    "CashFlow");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء تصدير البيانات:\n\n{ex.Message}",
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
            decimal amount =
                _cashFlowData.Sum(
                    x => x.TotalIn);

            ShowCardMessage(
                "إجمالي التدفقات الداخلة",
                amount);
        }


        private void lblTotalOutflows_Click(
            object sender,
            EventArgs e)
        {
            decimal amount =
                _cashFlowData.Sum(
                    x => x.TotalOut);

            ShowCardMessage(
                "إجمالي التدفقات الخارجة",
                amount);
        }


        private void lblMonthlyNet_Click(
            object sender,
            EventArgs e)
        {
            decimal inflows =
                _cashFlowData.Sum(
                    x => x.TotalIn);

            decimal outflows =
                _cashFlowData.Sum(
                    x => x.TotalOut);

            decimal net =
                inflows - outflows;


            ShowCardMessage(
                "صافي التدفق",
                net);
        }


        private void lblCurrentBalance_Click(
            object sender,
            EventArgs e)
        {
            decimal balance = 0m;


            if (_cashFlowData.Count > 0)
            {
                balance =
                    _cashFlowData
                        .OrderBy(x => x.FlowDate)
                        .Last()
                        .ClosingBalance;
            }


            ShowCardMessage(
                "الرصيد الحالي",
                balance);
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

    }
}
