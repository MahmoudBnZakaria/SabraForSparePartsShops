namespace SabraForSpareParts
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            splitContainer2 = new SplitContainer();
            ucTopBar1 = new ucTopBar();
            ucBottomBar1 = new ucBottomBar();
            ucMain1 = new SabraForSpareParts.Screens.usDashboard();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
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
            splitContainer2.Panel1.Controls.Add(ucMain1);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(splitContainer2.Panel2, "splitContainer2.Panel2");
            splitContainer2.Panel2.BackColor = Color.FromArgb(15, 23, 42);
            // 
            // ucTopBar1
            // 
            resources.ApplyResources(ucTopBar1, "ucTopBar1");
            ucTopBar1.BackColor = Color.White;
            ucTopBar1.BorderStyle = BorderStyle.FixedSingle;
            ucTopBar1.Name = "ucTopBar1";
            // 
            // ucBottomBar1
            // 
            resources.ApplyResources(ucBottomBar1, "ucBottomBar1");
            ucBottomBar1.BackColor = Color.FromArgb(15, 23, 42);
            ucBottomBar1.Name = "ucBottomBar1";
            // 
            // ucMain1
            // 
            resources.ApplyResources(ucMain1, "ucMain1");
            ucMain1.BackColor = Color.WhiteSmoke;
            ucMain1.BorderColor = Color.Transparent;
            ucMain1.ForeColor = Color.FromArgb(40, 40, 40);
            ucMain1.Name = "ucMain1";
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucBottomBar1);
            Controls.Add(ucTopBar1);
            Controls.Add(splitContainer2);
            Name = "frmMain";
            ShowIcon = false;
            ShowInTaskbar = false;
            splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private ucTopBar ucTopBar1;
        private ucBottomBar ucBottomBar1;
        private Screens.usDashboard ucMain1;
    }
}