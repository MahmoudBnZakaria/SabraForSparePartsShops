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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            ucBottomBar1 = new ucBottomBar();
            ucMenue1 = new ucMenue();
            pnlContent = new SabraPanel();
            pnlBody = new Panel();
            ucTopBar1 = new ucTopBar();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // ucBottomBar1
            // 
            ucBottomBar1.BackColor = Color.FromArgb(15, 23, 42);
            ucBottomBar1.Dock = DockStyle.Bottom;
            ucBottomBar1.Location = new Point(0, 1005);
            ucBottomBar1.Margin = new Padding(0);
            ucBottomBar1.Name = "ucBottomBar1";
            ucBottomBar1.Size = new Size(1804, 50);
            ucBottomBar1.TabIndex = 1;
            // 
            // ucMenue1
            // 
            ucMenue1.AutoScroll = true;
            ucMenue1.AutoScrollMinSize = new Size(280, 3015);
            ucMenue1.BackColor = Color.FromArgb(15, 23, 42);
            ucMenue1.BorderColor = Color.Transparent;
            ucMenue1.Dock = DockStyle.Right;
            ucMenue1.Font = new Font("Cairo", 10F);
            ucMenue1.ForeColor = Color.FromArgb(40, 40, 40);
            ucMenue1.Location = new Point(1493, 0);
            ucMenue1.Margin = new Padding(0);
            ucMenue1.Name = "ucMenue1";
            ucMenue1.Padding = new Padding(0, 0, 10, 0);
            ucMenue1.RightToLeft = RightToLeft.No;
            ucMenue1.Size = new Size(311, 922);
            ucMenue1.TabIndex = 0;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.BorderColor = Color.LightGray;
            pnlContent.BorderRadius = 15;
            pnlContent.BorderSize = 0;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.EnableHover = true;
            pnlContent.ForeColor = Color.Black;
            pnlContent.GradientAngle = 90F;
            pnlContent.GradientBottomColor = Color.White;
            pnlContent.GradientTopColor = Color.White;
            pnlContent.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlContent.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlContent.HoverBorderSize = 2;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1493, 922);
            pnlContent.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.BackColor = Color.WhiteSmoke;
            pnlBody.Controls.Add(pnlContent);
            pnlBody.Controls.Add(ucMenue1);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 83);
            pnlBody.Margin = new Padding(0);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(1804, 922);
            pnlBody.TabIndex = 2;
            // 
            // ucTopBar1
            // 
            ucTopBar1.AutoScroll = true;
            ucTopBar1.BackColor = Color.White;
            ucTopBar1.BorderColor = Color.Gray;
            ucTopBar1.BorderSize = 4;
            ucTopBar1.BorderRadius = 0;
            ucTopBar1.Dock = DockStyle.Top;
            ucTopBar1.Font = new Font("Cairo", 10F);
            ucTopBar1.ForeColor = Color.FromArgb(40, 40, 40);
            ucTopBar1.Location = new Point(0, 0);
            ucTopBar1.Margin = new Padding(0);
            ucTopBar1.MinimumSize = new Size(1493, 83);
            ucTopBar1.Name = "ucTopBar1";
            ucTopBar1.RightToLeft = RightToLeft.Yes;
            ucTopBar1.Size = new Size(1804, 83);
            ucTopBar1.TabIndex = 0;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1804, 1055);
            Controls.Add(pnlBody);
            Controls.Add(ucTopBar1);
            Controls.Add(ucBottomBar1);
            MinimumSize = new Size(1200, 700);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sabra Auto Spare Parts";
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBody;
        private ucBottomBar ucBottomBar1;
        private ucMenue ucMenue1;
        private SabraPanel pnlContent;
        private ucTopBar ucTopBar1;
    }
}