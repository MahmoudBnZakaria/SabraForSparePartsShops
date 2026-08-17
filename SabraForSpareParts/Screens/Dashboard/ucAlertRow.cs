using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucAlertRow : UserControl
    {
        public ucAlertRow()
        {
            InitializeComponent();
        }

        public void SetData(string productName, int stockQty)
        {
            lblProductName.Text = productName;
            lblStock.Text = $"المخزون: {stockQty}";

            if (stockQty == 0)
            {
                lblStock.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else if (stockQty <= 2)
            {
                lblStock.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else
            {
                lblStock.ForeColor = Color.FromArgb(217, 119, 6);
            }
        }
    }
}
