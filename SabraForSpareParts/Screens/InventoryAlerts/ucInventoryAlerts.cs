using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens.InventoryAlerts
{
    public partial class ucInventoryAlerts : UserControl
    {
        int alertCount = 0;
        private void ucInventoryAlerts_Load(object sender, EventArgs e)
        {
            lblAlertsCount.Text = $"({alertCount} أصناف)";
        }
        public ucInventoryAlerts()
        {
            InitializeComponent();
            LoadMockData();

        }


        private void sabraFlowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in sabraFlowLayoutPanel1.Controls)
            {
                ctrl.Width = sabraFlowLayoutPanel1.ClientSize.Width - ctrl.Margin.Left - ctrl.Margin.Right;
            }
        }

        private void LoadMockData()
        {
            sabraFlowLayoutPanel1.SuspendLayout();

            sabraFlowLayoutPanel1.Controls.Clear();

            AddMockAlert(
                "بوجية NGK",
                0,
                20,
                ucInventoryAlertRow.AlertType.OutOfStock);

            AddMockAlert(
                "فلتر زيت تويوتا",
                2,
                10,
                ucInventoryAlertRow.AlertType.LowStock);

            AddMockAlert(
                "بل فرامل هيونداي",
                3,
                8,
                ucInventoryAlertRow.AlertType.LowStock);

            AddMockAlert(
                "فلتر هواء رينو لوجان",
                4,
                8,
                ucInventoryAlertRow.AlertType.LowStock);

            AddMockAlert(
                "طقم مساعدين قديم",
                15,
                5,
                ucInventoryAlertRow.AlertType.DeadStock);

            sabraFlowLayoutPanel1.ResumeLayout();
        }

        private void AddMockAlert(
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

            sabraFlowLayoutPanel1.Controls.Add(alertRow);
            alertCount += 1;
        }

    }
}
