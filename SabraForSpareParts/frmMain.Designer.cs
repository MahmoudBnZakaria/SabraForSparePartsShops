namespace SabraForSpareParts
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ucTopBar1 = new ucTopBar();
            ucBottomBar1 = new ucBottomBar();
            ucMenue1 = new ucMenue();
            pnlContent = new Panel();
            SuspendLayout();


            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 93);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(0);
            pnlContent.Size = new Size(1493, 912);
            pnlContent.TabIndex = 3;


            // 
            // ucTopBar1
            // 
            ucTopBar1.AutoScroll = true;
            ucTopBar1.BackColor = Color.White;
            ucTopBar1.BorderColor = Color.Transparent;
            ucTopBar1.BorderRadius = 15;
            ucTopBar1.BorderStyle = BorderStyle.FixedSingle;
            ucTopBar1.Dock = DockStyle.Top;
            ucTopBar1.Font = new Font("Cairo", 10F);
            ucTopBar1.ForeColor = Color.FromArgb(40, 40, 40);
            ucTopBar1.Location = new Point(0, 0);
            ucTopBar1.Margin = new Padding(0);
            ucTopBar1.MinimumSize = new Size(900, 83);
            ucTopBar1.Name = "ucTopBar1";
            ucTopBar1.Padding = new Padding(10);
            ucTopBar1.RightToLeft = RightToLeft.Yes;
            ucTopBar1.SearchText = "";
            ucTopBar1.Size = new Size(1804, 93);
            ucTopBar1.TabIndex = 0;

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
            ucMenue1.Location = new Point(1493, 93);
            ucMenue1.Margin = new Padding(0);
            ucMenue1.Name = "ucMenue1";
            ucMenue1.RightToLeft = RightToLeft.Yes;
            ucMenue1.Size = new Size(311, 912);
            ucMenue1.TabIndex = 2;

            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1804, 1055);
            Controls.Add(pnlContent);
            Controls.Add(ucBottomBar1);
            Controls.Add(ucTopBar1);
            Controls.Add(ucMenue1); 
            MinimumSize = new Size(1200, 700);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sabra For Spare Parts";

            ResumeLayout(false);
        }

        #endregion

        private ucTopBar ucTopBar1;
        private ucBottomBar ucBottomBar1;
        private ucMenue ucMenue1;
        private Panel pnlContent;
    }
}