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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            ucTopBar1.Dock = DockStyle.Top;
            ucBottomBar1.Dock = DockStyle.Bottom;
            ucMain1.Dock = DockStyle.Fill;

            this.PerformLayout();

            splitContainer2.Location = new Point(0, ucTopBar1.Bottom);

            splitContainer2.Size = new Size(
                ClientSize.Width,
                ClientSize.Height - ucTopBar1.Height - ucBottomBar1.Height);

            splitContainer2.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;
        }

        private void sabraButton1_Click(object sender, EventArgs e)
        {
            test testForm = new test(); 
            testForm.ShowDialog();
        }
    }
}
