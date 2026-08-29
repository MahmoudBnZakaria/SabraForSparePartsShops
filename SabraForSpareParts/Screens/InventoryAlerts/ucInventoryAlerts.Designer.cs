namespace SabraForSpareParts.Screens.InventoryAlerts
{
    partial class ucInventoryAlerts
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            sabraPanel1 = new SabraPanel();
            slblTitleOfTopPanel = new SabraLabel();
            lblAlertsCount = new SabraLabel();
            sbtnExport = new SabraButton();
            sabraFlowLayoutPanel1 = new SabraFlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            sabraPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // icnDecreasedParts
            // 
            icnDecreasedParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icnDecreasedParts.BackColor = Color.Transparent;
            icnDecreasedParts.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnDecreasedParts.ForeColor = Color.DarkGoldenrod;
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.Warning;
            icnDecreasedParts.IconColor = Color.DarkGoldenrod;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1530, 18);
            icnDecreasedParts.Name = "icnDecreasedParts";
            icnDecreasedParts.Size = new Size(72, 65);
            icnDecreasedParts.SizeMode = PictureBoxSizeMode.Zoom;
            icnDecreasedParts.TabIndex = 14;
            icnDecreasedParts.TabStop = false;
            // 
            // sabraPanel1
            // 
            sabraPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(lblAlertsCount);
            sabraPanel1.Controls.Add(sbtnExport);
            sabraPanel1.EnableHover = true;
            sabraPanel1.ForeColor = Color.Black;
            sabraPanel1.GradientAngle = 90F;
            sabraPanel1.GradientBottomColor = Color.White;
            sabraPanel1.GradientTopColor = Color.White;
            sabraPanel1.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel1.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel1.HoverBorderSize = 2;
            sabraPanel1.Location = new Point(30, 30);
            sabraPanel1.Name = "sabraPanel1";
            sabraPanel1.Size = new Size(1625, 100);
            sabraPanel1.TabIndex = 0;
            // 
            // slblTitleOfTopPanel
            // 
            slblTitleOfTopPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblTitleOfTopPanel.AutoSize = true;
            slblTitleOfTopPanel.BackColor = Color.Transparent;
            slblTitleOfTopPanel.BorderColor = Color.DodgerBlue;
            slblTitleOfTopPanel.BorderRadius = 8;
            slblTitleOfTopPanel.BorderSize = 0;
            slblTitleOfTopPanel.Font = new Font("Cairo", 18F, FontStyle.Bold);
            slblTitleOfTopPanel.ForeColor = Color.FromArgb(40, 40, 40);
            slblTitleOfTopPanel.Location = new Point(1302, 19);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.Size = new Size(222, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "تنبيهات المخزن";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAlertsCount
            // 
            lblAlertsCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAlertsCount.AutoSize = true;
            lblAlertsCount.BackColor = Color.Transparent;
            lblAlertsCount.BorderColor = Color.DodgerBlue;
            lblAlertsCount.BorderRadius = 8;
            lblAlertsCount.BorderSize = 0;
            lblAlertsCount.Font = new Font("Cairo", 12F);
            lblAlertsCount.ForeColor = Color.IndianRed;
            lblAlertsCount.Location = new Point(1182, 32);
            lblAlertsCount.Name = "lblAlertsCount";
            lblAlertsCount.Size = new Size(96, 37);
            lblAlertsCount.TabIndex = 16;
            lblAlertsCount.Text = "(0 أصناف)";
            lblAlertsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sbtnExport
            // 
            sbtnExport.BackColor = Color.RoyalBlue;
            sbtnExport.BorderColor = Color.DodgerBlue;
            sbtnExport.BorderRadius = 20;
            sbtnExport.BorderSize = 0;
            sbtnExport.FlatAppearance.BorderSize = 0;
            sbtnExport.FlatStyle = FlatStyle.Flat;
            sbtnExport.Font = new Font("Cairo", 12F, FontStyle.Bold);
            sbtnExport.ForeColor = Color.White;
            sbtnExport.HoverColor = Color.CornflowerBlue;
            sbtnExport.IconChar = FontAwesome.Sharp.IconChar.None;
            sbtnExport.IconColor = Color.Black;
            sbtnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnExport.Location = new Point(25, 25);
            sbtnExport.Name = "sbtnExport";
            sbtnExport.NormalColor = Color.RoyalBlue;
            sbtnExport.Size = new Size(150, 50);
            sbtnExport.TabIndex = 17;
            sbtnExport.Text = "تصدير";
            sbtnExport.UseVisualStyleBackColor = false;
            // 
            // sabraFlowLayoutPanel1
            // 
            sabraFlowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sabraFlowLayoutPanel1.AutoScroll = true;
            sabraFlowLayoutPanel1.BackColor = SystemColors.Control;
            sabraFlowLayoutPanel1.BorderColor = Color.DimGray;
            sabraFlowLayoutPanel1.BorderRadius = 15;
            sabraFlowLayoutPanel1.BorderSize = 1;
            sabraFlowLayoutPanel1.Location = new Point(30, 160);
            sabraFlowLayoutPanel1.Name = "sabraFlowLayoutPanel1";
            sabraFlowLayoutPanel1.Size = new Size(1622, 635);
            sabraFlowLayoutPanel1.TabIndex = 1;
            sabraFlowLayoutPanel1.SizeChanged += sabraFlowLayoutPanel1_SizeChanged;
            // 
            // ucInventoryAlerts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sabraFlowLayoutPanel1);
            Controls.Add(sabraPanel1);
            Name = "ucInventoryAlerts";
            Padding = new Padding(30);
            Size = new Size(1685, 828);
            Load += ucInventoryAlerts_Load;
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblAlertsCount;
        private SabraButton sbtnExport;
        private SabraFlowLayoutPanel flowLayoutPanel1;
        private SabraFlowLayoutPanel sabraFlowLayoutPanel1;
    }
}