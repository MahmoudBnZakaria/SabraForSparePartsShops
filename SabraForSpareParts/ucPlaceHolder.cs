using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class ucPlaceHolder : UserControl
    {
        public ucPlaceHolder()
        {
            InitializeComponent();
        }

        private void ucPlaceHolder_SizeChanged(object sender, EventArgs e)
        {
            lblSize.Text = this.Size.ToString();
        }

        private void ucPlaceHolder_Load(object sender, EventArgs e)
        {

        }
    }
}
