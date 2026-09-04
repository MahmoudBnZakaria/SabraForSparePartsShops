namespace SabraForSpareParts
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            splitContainer2 = new SplitContainer();
            ucMain1 = new SabraForSpareParts.Screens.usDashboard();
            sabraButton1 = new SabraButton();
            ucTopBar1 = new ucTopBar();
            ucBottomBar1 = new ucBottomBar();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer2
            // 
            resources.ApplyResources(splitContainer2, "splitContainer2");
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(splitContainer2.Panel1, "splitContainer2.Panel1");
            splitContainer2.Panel1.BackColor = Color.WhiteSmoke;
            splitContainer2.Panel1.Controls.Add(ucMain1);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(splitContainer2.Panel2, "splitContainer2.Panel2");
            splitContainer2.Panel2.BackColor = Color.FromArgb(15, 23, 42);
            splitContainer2.Panel2.Controls.Add(sabraButton1);
            // 
            // ucMain1
            // 
            resources.ApplyResources(ucMain1, "ucMain1");
            ucMain1.BackColor = Color.WhiteSmoke;
            ucMain1.BorderColor = Color.Transparent;
            ucMain1.ForeColor = Color.FromArgb(40, 40, 40);
            ucMain1.Name = "ucMain1";
            // 
            // sabraButton1
            // 
            resources.ApplyResources(sabraButton1, "sabraButton1");
            sabraButton1.BackColor = Color.FromArgb(30, 41, 59);
            sabraButton1.BorderColor = Color.Transparent;
            sabraButton1.BorderRadius = 12;
            sabraButton1.BorderSize = 0;
            sabraButton1.Cursor = Cursors.Hand;
            sabraButton1.FlatAppearance.BorderSize = 0;
            sabraButton1.ForeColor = Color.White;
            sabraButton1.HoverColor = Color.FromArgb(37, 99, 235);
            sabraButton1.IconChar = FontAwesome.Sharp.IconChar.House;
            sabraButton1.IconColor = Color.White;
            sabraButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sabraButton1.IconSize = 24;
            sabraButton1.Name = "sabraButton1";
            sabraButton1.NormalColor = Color.FromArgb(30, 41, 59);
            sabraButton1.UseVisualStyleBackColor = false;
            sabraButton1.Click += sabraButton1_Click;
            // 
            // ucTopBar1
            // 
            resources.ApplyResources(ucTopBar1, "ucTopBar1");
            ucTopBar1.BackColor = Color.White;
            ucTopBar1.BorderColor = Color.Transparent;
            ucTopBar1.BorderRadius = 15;
            ucTopBar1.BorderStyle = BorderStyle.FixedSingle;
            ucTopBar1.ForeColor = Color.FromArgb(40, 40, 40);
            ucTopBar1.Name = "ucTopBar1";
            ucTopBar1.SearchText = "";
            // 
            // ucBottomBar1
            // 
            resources.ApplyResources(ucBottomBar1, "ucBottomBar1");
            ucBottomBar1.BackColor = Color.FromArgb(15, 23, 42);
            ucBottomBar1.Name = "ucBottomBar1";
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(splitContainer2);
            Controls.Add(ucBottomBar1);
            Controls.Add(ucTopBar1);
            Name = "frmMain";
            ShowIcon = false;
            WindowState = FormWindowState.Maximized;
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        // =========================================================
        // Controls
        // =========================================================

        private SplitContainer splitContainer2;

        private ucTopBar ucTopBar1;

        private ucBottomBar ucBottomBar1;

        private Screens.usDashboard ucMain1;

        private SabraButton sabraButton1;
    }
}