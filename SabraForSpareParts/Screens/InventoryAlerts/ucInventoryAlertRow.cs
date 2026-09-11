using System;
using System.Drawing;
using FontAwesome.Sharp;

namespace SabraForSpareParts.Screens.InventoryAlerts
{
    public partial class ucInventoryAlertRow : SabraUserControl
    {
        public event EventHandler<EventArgs> PurchaseOrderButtonClicked;

        public enum AlertType
        {
            LowStock,
            OutOfStock,
            DeadStock
        }

        public ucInventoryAlertRow()
        {
            InitializeComponent();
        }

        public void SetAlert(string partName, int currentStock, int minimumStock, AlertType alertType)
        {
            var (title, info, icon, iconColor, backColor) = alertType switch
            {
                AlertType.LowStock => (
                    $"{partName} — مخزون منخفض",
                    $"المخزون الحالي: {currentStock} | الحد الأدنى: {minimumStock}",
                    IconChar.CircleExclamation,
                    Color.FromArgb(245, 158, 11),
                    Color.FromArgb(255, 251, 235)),

                AlertType.OutOfStock => (
                    $"{partName} — مخزون صفر!",
                    $"المخزون الحالي: 0 | الحد الأدنى: {minimumStock}",
                    IconChar.CircleXmark,
                    Color.FromArgb(220, 38, 38),
                    Color.FromArgb(254, 242, 242)),

                AlertType.DeadStock => (
                    $"{partName} — مخزون ميت",
                    $"المخزون الحالي: {currentStock} | لم يتم بيع المنتج منذ فترة طويلة",
                    IconChar.BoxArchive,
                    Color.FromArgb(100, 116, 139),
                    Color.FromArgb(241, 245, 249)),

                _ => throw new ArgumentOutOfRangeException(nameof(alertType), alertType, "نوع التنبيه غير معروف")
            };

            slblAlertRowTiltle.Text = title;
            lblInventoryInfo.Text = info;
            SetIcon(icon, iconColor, backColor);
        }

        private void SetIcon(IconChar icon, Color iconColor, Color backColor)
        {
            icnDecreasedParts.IconChar = icon;
            icnDecreasedParts.IconColor = iconColor;
            icnDecreasedParts.ForeColor = iconColor;
            icnDecreasedParts.BackColor = backColor;
        }

        private void sbtnPurchaseOrder_Click(object sender, EventArgs e)
        {
            PurchaseOrderButtonClicked?.Invoke(this, e);
        }
    }
}