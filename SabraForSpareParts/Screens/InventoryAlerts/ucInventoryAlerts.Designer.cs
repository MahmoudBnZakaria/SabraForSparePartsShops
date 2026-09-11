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
            sabraFlowLayoutPanel1 = new SabraFlowLayoutPanel();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
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
            icnDecreasedParts.Location = new Point(1488, 18);
            icnDecreasedParts.Name = "icnDecreasedParts";
            icnDecreasedParts.Size = new Size(72, 65);
            icnDecreasedParts.SizeMode = PictureBoxSizeMode.Zoom;
            icnDecreasedParts.TabIndex = 14;
            icnDecreasedParts.TabStop = false;
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(sbtnPrint);
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(lblAlertsCount);
            sabraPanel1.Dock = DockStyle.Top;
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
            sabraPanel1.Size = new Size(1583, 100);
            sabraPanel1.TabIndex = 0;
            // 
            // slblTitleOfTopPanel
            // 
            slblTitleOfTopPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblTitleOfTopPanel.AutoSize = true;
            slblTitleOfTopPanel.BackColor = Color.Transparent;
            slblTitleOfTopPanel.Font = new Font("Cairo", 18F, FontStyle.Bold);
            slblTitleOfTopPanel.ForeColor = Color.FromArgb(40, 40, 40);
            slblTitleOfTopPanel.Location = new Point(1260, 19);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
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
            lblAlertsCount.Font = new Font("Cairo", 12F);
            lblAlertsCount.ForeColor = Color.IndianRed;
            lblAlertsCount.Location = new Point(1140, 32);
            lblAlertsCount.Name = "lblAlertsCount";
            lblAlertsCount.RightToLeft = RightToLeft.Yes;
            lblAlertsCount.Size = new Size(96, 37);
            lblAlertsCount.TabIndex = 16;
            lblAlertsCount.Text = "(0 أصناف)";
            lblAlertsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraFlowLayoutPanel1
            // 
            sabraFlowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sabraFlowLayoutPanel1.AutoScroll = true;
            sabraFlowLayoutPanel1.BackColor = SystemColors.Control;
            sabraFlowLayoutPanel1.BorderColor = Color.DimGray;
            sabraFlowLayoutPanel1.BorderRadius = 15;
            sabraFlowLayoutPanel1.BorderSize = 0;
            sabraFlowLayoutPanel1.Location = new Point(30, 160);
            sabraFlowLayoutPanel1.Name = "sabraFlowLayoutPanel1";
            sabraFlowLayoutPanel1.Size = new Size(1580, 635);
            sabraFlowLayoutPanel1.TabIndex = 1;
            sabraFlowLayoutPanel1.SizeChanged += sabraFlowLayoutPanel1_SizeChanged;
            // 
            // sbtnPrint
            // 
            sbtnPrint.BackColor = Color.DimGray;
            sbtnPrint.BorderColor = Color.DodgerBlue;
            sbtnPrint.BorderRadius = 20;
            sbtnPrint.BorderSize = 0;
            sbtnPrint.FlatAppearance.BorderSize = 0;
            sbtnPrint.FlatStyle = FlatStyle.Flat;
            sbtnPrint.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnPrint.ForeColor = Color.White;
            sbtnPrint.HoverColor = Color.CornflowerBlue;
            sbtnPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            sbtnPrint.IconColor = Color.Beige;
            sbtnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnPrint.IconSize = 30;
            sbtnPrint.ImageAlign = ContentAlignment.MiddleRight;
            sbtnPrint.Location = new Point(204, 32);
            sbtnPrint.Name = "sbtnPrint";
            sbtnPrint.NormalColor = Color.DimGray;
            sbtnPrint.Padding = new Padding(10, 0, 10, 0);
            sbtnPrint.Size = new Size(127, 41);
            sbtnPrint.TabIndex = 19;
            sbtnPrint.Text = "طباعة";
            sbtnPrint.TextAlign = ContentAlignment.MiddleLeft;
            sbtnPrint.UseVisualStyleBackColor = false;
            sbtnPrint.Click += sbtnPrint_Click;
            // 
            // sbtnExportAsExcel
            // 
            sbtnExportAsExcel.BackColor = Color.Green;
            sbtnExportAsExcel.BorderColor = Color.DodgerBlue;
            sbtnExportAsExcel.BorderRadius = 20;
            sbtnExportAsExcel.BorderSize = 0;
            sbtnExportAsExcel.FlatAppearance.BorderSize = 0;
            sbtnExportAsExcel.FlatStyle = FlatStyle.Flat;
            sbtnExportAsExcel.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnExportAsExcel.ForeColor = Color.White;
            sbtnExportAsExcel.HoverColor = Color.CornflowerBlue;
            sbtnExportAsExcel.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            sbtnExportAsExcel.IconColor = Color.Beige;
            sbtnExportAsExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnExportAsExcel.IconSize = 30;
            sbtnExportAsExcel.ImageAlign = ContentAlignment.MiddleRight;
            sbtnExportAsExcel.Location = new Point(21, 32);
            sbtnExportAsExcel.Name = "sbtnExportAsExcel";
            sbtnExportAsExcel.NormalColor = Color.Green;
            sbtnExportAsExcel.Padding = new Padding(10, 0, 10, 0);
            sbtnExportAsExcel.Size = new Size(157, 41);
            sbtnExportAsExcel.TabIndex = 20;
            sbtnExportAsExcel.Text = "تصدير Excel";
            sbtnExportAsExcel.TextAlign = ContentAlignment.MiddleLeft;
            sbtnExportAsExcel.UseVisualStyleBackColor = false;
            sbtnExportAsExcel.Click += sbtnExportAsExcel_Click;
            // 
            // ucInventoryAlerts
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sabraFlowLayoutPanel1);
            Controls.Add(sabraPanel1);
            Name = "ucInventoryAlerts";
            Padding = new Padding(30);
            Size = new Size(1643, 828);
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
        private SabraFlowLayoutPanel flowLayoutPanel1;
        private SabraFlowLayoutPanel sabraFlowLayoutPanel1;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
    }
}