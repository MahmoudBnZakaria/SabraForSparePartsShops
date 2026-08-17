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
    public partial class ucBottomBar : UserControl
    {
        public ucBottomBar()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void lblScreenName_Click(object sender, EventArgs e)
        {

        }

        private void ucBottomBar_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy     hh:mm:ss:tt");
        }
    }
}
