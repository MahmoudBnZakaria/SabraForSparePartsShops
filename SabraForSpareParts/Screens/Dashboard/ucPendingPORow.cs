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
    public partial class ucPendingPORow : UserControl
    {
        public ucPendingPORow()
        {
            InitializeComponent();
        }
        public void SetData(string poCode, string supplierName, decimal amount)
        {
            lblPOInfo.Text = $"{poCode} — {supplierName}";
            lblAmount.Text = $"{amount:N0} ج";
        }
    }
}
