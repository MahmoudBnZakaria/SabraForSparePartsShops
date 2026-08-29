using FontAwesome.Sharp;
using System.Drawing;

namespace SabraForSpareParts.Screens.InventoryAlerts
{
    public partial class ucInventoryAlertRow : SabraUserControl
    {
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

        public void SetAlert(
            string partName,
            int currentStock,
            int minimumStock,
            AlertType alertType)
        {
            switch (alertType)
            {
                case AlertType.LowStock:

                    slblAlertRowTiltle.Text =
                        $"{partName} — مخزون منخفض";

                    lblInventoryInfo.Text =
                        $"المخزون الحالي: {currentStock} | الحد الأدنى: {minimumStock}";

                    SetIcon(
                        IconChar.CircleExclamation,
                        Color.FromArgb(245, 158, 11),
                        Color.FromArgb(255, 251, 235));

                    break;


                case AlertType.OutOfStock:

                    slblAlertRowTiltle.Text =
                        $"{partName} — مخزون صفر!";

                    lblInventoryInfo.Text =
                        $"المخزون الحالي: 0 | الحد الأدنى: {minimumStock}";

                    SetIcon(
                        IconChar.CircleXmark,
                        Color.FromArgb(220, 38, 38),
                        Color.FromArgb(254, 242, 242));

                    break;


                case AlertType.DeadStock:

                    slblAlertRowTiltle.Text =
                        $"{partName} — مخزون ميت";

                    lblInventoryInfo.Text =
                        $"المخزون الحالي: {currentStock} | لم يتم بيع المنتج منذ فترة طويلة";

                    SetIcon(
                        IconChar.BoxArchive,
                        Color.FromArgb(100, 116, 139),
                        Color.FromArgb(241, 245, 249));

                    break;
            }
        }

        private void SetIcon(
            IconChar icon,
            Color iconColor,
            Color backColor)
        {
            icnDecreasedParts.IconChar = icon;
            icnDecreasedParts.IconColor = iconColor;
            icnDecreasedParts.ForeColor = iconColor;
            icnDecreasedParts.BackColor = backColor;
        }

    }
}