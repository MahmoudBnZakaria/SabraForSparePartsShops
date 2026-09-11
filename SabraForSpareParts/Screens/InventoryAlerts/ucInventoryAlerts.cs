using Sabra.LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens.InventoryAlerts
{
    public partial class ucInventoryAlerts : SabraUserControl
    {
        private int _alertCount = 0;
        private readonly clsReportsBusiness _Reports = new clsReportsBusiness();
        public event EventHandler CreatePurchaseOrderRequested;

        public ucInventoryAlerts()
        {
            InitializeComponent();
            LoadData();
        }

        private void sabraFlowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in sabraFlowLayoutPanel1.Controls)
            {
                ctrl.Width = sabraFlowLayoutPanel1.ClientSize.Width - ctrl.Margin.Left - ctrl.Margin.Right;
            }
        }

        private void LoadData()
        {
            _alertCount = 0;

            sabraFlowLayoutPanel1.SuspendLayout();

            foreach (Control control in sabraFlowLayoutPanel1.Controls)
            {
                control.Dispose();
            }
            sabraFlowLayoutPanel1.Controls.Clear();

            var lowStockSuggestion = _Reports.GetLowStockSuggestions();

            if (lowStockSuggestion?.Data != null)
            {
                foreach (var alert in lowStockSuggestion.Data)
                {
                    var alertType = alert.CurrentStock == 0
                        ? ucInventoryAlertRow.AlertType.OutOfStock
                        : ucInventoryAlertRow.AlertType.LowStock;

                    AddAlert(
                        alert.PartName,
                        alert.CurrentStock,
                        alert.MinLimit,
                        alertType);
                }
            }

            sabraFlowLayoutPanel1.ResumeLayout();

            lblAlertsCount.Text = $"({_alertCount} أصناف)";
        }

        private void AddAlert(
            string partName,
            int currentStock,
            int minimumStock,
            ucInventoryAlertRow.AlertType alertType)
        {
            ucInventoryAlertRow alertRow = new ucInventoryAlertRow();

            alertRow.Margin = new Padding(20);

            int dynamicWidth = sabraFlowLayoutPanel1.ClientSize.Width - alertRow.Margin.Left - alertRow.Margin.Right;

            alertRow.Size = new Size(dynamicWidth, 97);

            alertRow.SetAlert(
                partName,
                currentStock,
                minimumStock,
                alertType);

            alertRow.PurchaseOrderButtonClicked += AlertRow_PurchaseOrderButtonClicked;

            sabraFlowLayoutPanel1.Controls.Add(alertRow);
            _alertCount++;
        }

        private void AlertRow_PurchaseOrderButtonClicked(object sender, EventArgs e)
        {
            CreatePurchaseOrderRequested?.Invoke(this, EventArgs.Empty);
        }

        #region Print & Export Logic

        /// <summary>
        /// إنشاء DataGridView مؤقت في الذاكرة لتمريره لنظام الطباعة والتصدير
        /// </summary>
        private DataGridView BuildAlertsDataGridView()
        {
            var dgv = new DataGridView();

            // تعريف أعمدة الجدول
            dgv.Columns.Add("PartName", "اسم القطعة");
            dgv.Columns.Add("CurrentStock", "الرصيد الحالي");
            dgv.Columns.Add("MinLimit", "الحد الأدنى");
            dgv.Columns.Add("Status", "حالة المخزون");

            // جلب البيانات من طبقة الأعمال
            var lowStockSuggestion = _Reports.GetLowStockSuggestions();

            if (lowStockSuggestion?.Data != null)
            {
                foreach (var alert in lowStockSuggestion.Data)
                {
                    string status = alert.CurrentStock == 0 ? "نفذت الكمية" : "مخزون منخفض";
                    dgv.Rows.Add(alert.PartName, alert.CurrentStock, alert.MinLimit, status);
                }
            }

            return dgv;
        }

        private void sbtnPrint_Click(object sender, EventArgs e)
        {
            using (var dgv = BuildAlertsDataGridView())
            {
                var options = new PrintDocumentOptions
                {
                    ReportTitle = "تقرير تنبيهات المخزون والنواقص",
                    Notes = "تم استخراج هذا التقرير بناءً على الحد الأدنى للمخزون المعتمد.",
                    ShowDate = true,
                    ShowPageNumbers = true
                };

                options.Tables.Add(new PrintableTable(dgv, "قائمة القطعة المطلوبة"));

                clsGlobalClass.PrintReport(options);
            }
        }

        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            using (var dgv = BuildAlertsDataGridView())
            {
                var tables = new List<PrintableTable>
                {
                    new PrintableTable(dgv, "تنبيهات المخزون")
                };

                clsGlobalClass.ExportToExcel(tables, "Inventory_Alerts", "تقرير تنبيهات المخزون والأصناف المطلوبة");
            }
        }

        #endregion
    }
}