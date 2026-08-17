using System;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucInvoiceRow : UserControl
    {
        public ucInvoiceRow()
        {
            InitializeComponent();
        }

        public void SetData(int invoiceId, string customerName, decimal amount, string status)
        {
            lblInvoiceID.Text = invoiceId.ToString();
            lblCustomerName.Text = customerName;
            lblAmount.Text = $"{amount:N0} ج";
            lblStatus.Text = status;

            switch (status)
            {
                case "مسدد":
                    lblStatus.BackColor = Color.FromArgb(236, 253, 245);   // أخضر فاتح
                    lblStatus.ForeColor = Color.FromArgb(5, 150, 105);   // أخضر غامق
                    break;

                case "جزئي":
                    lblStatus.BackColor = Color.FromArgb(255, 251, 235);   // أصفر فاتح
                    lblStatus.ForeColor = Color.FromArgb(217, 119, 6);    // برتقالي/ذهبي
                    break;

                case "آجل":
                    lblStatus.BackColor = Color.FromArgb(254, 242, 242);   // أحمر فاتح
                    lblStatus.ForeColor = Color.FromArgb(220, 38, 38);    // أحمر غامق
                    break;

                default:
                    lblStatus.BackColor = Color.FromArgb(241, 245, 249);
                    lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
                    break;
            }
        }
    }
}