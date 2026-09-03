namespace SabraForSpareParts.Screens
{
    partial class ucSalaries
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


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sabraPanel1 = new SabraPanel();
            sbtnExportAsExcel = new SabraButton();
            slblTitleOfTopPanel = new SabraLabel();
            icnSalary = new FontAwesome.Sharp.IconPictureBox();
            lblMonthAndYear = new SabraLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlUnpaidInvoices = new SabraPanel();
            lblTotalSalaries = new SabraLabel();
            lblUnpaidInvoicesDisc = new SabraLabel();
            sabraPanel2 = new SabraPanel();
            lblNumberOfEmployees = new SabraLabel();
            sabraLabel1 = new SabraLabel();
            pnlLowStock = new SabraPanel();
            lblTotalAdvances = new SabraLabel();
            lblLowStockPartsDisc = new SabraLabel();
            pnlNetProfit = new SabraPanel();
            sabraLabel2 = new SabraLabel();
            lblNetPaid = new SabraLabel();
            sabraFlowLayoutPanelContainerOfCards = new SabraFlowLayoutPanel();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnSalary).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            pnlUnpaidInvoices.SuspendLayout();
            sabraPanel2.SuspendLayout();
            pnlLowStock.SuspendLayout();
            pnlNetProfit.SuspendLayout();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(icnSalary);
            sabraPanel1.Controls.Add(lblMonthAndYear);
            sabraPanel1.Dock = DockStyle.Top;
            sabraPanel1.EnableHover = true;
            sabraPanel1.ForeColor = Color.Black;
            sabraPanel1.GradientAngle = 90F;
            sabraPanel1.GradientBottomColor = Color.White;
            sabraPanel1.GradientTopColor = Color.White;
            sabraPanel1.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel1.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel1.HoverBorderSize = 2;
            sabraPanel1.Location = new Point(10, 10);
            sabraPanel1.Name = "sabraPanel1";
            sabraPanel1.Size = new Size(1502, 111);
            sabraPanel1.TabIndex = 4;
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
            sbtnExportAsExcel.Location = new Point(76, 23);
            sbtnExportAsExcel.Name = "sbtnExportAsExcel";
            sbtnExportAsExcel.NormalColor = Color.Green;
            sbtnExportAsExcel.Padding = new Padding(10, 0, 10, 0);
            sbtnExportAsExcel.Size = new Size(157, 65);
            sbtnExportAsExcel.TabIndex = 19;
            sbtnExportAsExcel.Text = "تصدير Excel";
            sbtnExportAsExcel.TextAlign = ContentAlignment.MiddleLeft;
            sbtnExportAsExcel.UseVisualStyleBackColor = false;
            sbtnExportAsExcel.Click += sbtnExportAsExcel_Click;
            // 
            // slblTitleOfTopPanel
            // 
            slblTitleOfTopPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblTitleOfTopPanel.AutoSize = true;
            slblTitleOfTopPanel.BackColor = Color.Transparent;
            slblTitleOfTopPanel.Font = new Font("Cairo", 18F, FontStyle.Bold);
            slblTitleOfTopPanel.ForeColor = Color.FromArgb(40, 40, 40);
            slblTitleOfTopPanel.Location = new Point(1250, 5);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(117, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "الرواتب";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // icnSalary
            // 
            icnSalary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icnSalary.BackColor = Color.Transparent;
            icnSalary.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnSalary.ForeColor = Color.RoyalBlue;
            icnSalary.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            icnSalary.IconColor = Color.RoyalBlue;
            icnSalary.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnSalary.IconSize = 65;
            icnSalary.Location = new Point(1373, 23);
            icnSalary.Name = "icnSalary";
            icnSalary.Size = new Size(72, 65);
            icnSalary.SizeMode = PictureBoxSizeMode.Zoom;
            icnSalary.TabIndex = 14;
            icnSalary.TabStop = false;
            // 
            // lblMonthAndYear
            // 
            lblMonthAndYear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMonthAndYear.BackColor = Color.Transparent;
            lblMonthAndYear.Font = new Font("Cairo", 12F);
            lblMonthAndYear.ForeColor = SystemColors.WindowFrame;
            lblMonthAndYear.Location = new Point(1134, 61);
            lblMonthAndYear.Name = "lblMonthAndYear";
            lblMonthAndYear.RightToLeft = RightToLeft.Yes;
            lblMonthAndYear.Size = new Size(233, 37);
            lblMonthAndYear.TabIndex = 16;
            lblMonthAndYear.Text = "يناير 2025";
            lblMonthAndYear.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(pnlUnpaidInvoices, 0, 0);
            tableLayoutPanel1.Controls.Add(sabraPanel2, 3, 0);
            tableLayoutPanel1.Controls.Add(pnlLowStock, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlNetProfit, 2, 0);
            tableLayoutPanel1.Location = new Point(10, 159);
            tableLayoutPanel1.Margin = new Padding(30);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20, 0, 0, 0);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1479, 128);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // pnlUnpaidInvoices
            // 
            pnlUnpaidInvoices.BackColor = Color.White;
            pnlUnpaidInvoices.BorderColor = Color.LightGray;
            pnlUnpaidInvoices.BorderRadius = 15;
            pnlUnpaidInvoices.BorderSize = 0;
            pnlUnpaidInvoices.Controls.Add(lblTotalSalaries);
            pnlUnpaidInvoices.Controls.Add(lblUnpaidInvoicesDisc);
            pnlUnpaidInvoices.EnableHover = true;
            pnlUnpaidInvoices.ForeColor = Color.Black;
            pnlUnpaidInvoices.GradientAngle = 90F;
            pnlUnpaidInvoices.GradientBottomColor = Color.White;
            pnlUnpaidInvoices.GradientTopColor = Color.White;
            pnlUnpaidInvoices.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlUnpaidInvoices.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlUnpaidInvoices.HoverBorderSize = 2;
            pnlUnpaidInvoices.Location = new Point(1131, 16);
            pnlUnpaidInvoices.Margin = new Padding(16);
            pnlUnpaidInvoices.Name = "pnlUnpaidInvoices";
            pnlUnpaidInvoices.Size = new Size(332, 96);
            pnlUnpaidInvoices.TabIndex = 18;
            // 
            // lblTotalSalaries
            // 
            lblTotalSalaries.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalSalaries.BackColor = Color.Transparent;
            lblTotalSalaries.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblTotalSalaries.ForeColor = Color.Brown;
            lblTotalSalaries.IsTitle = true;
            lblTotalSalaries.Location = new Point(37, 4);
            lblTotalSalaries.Margin = new Padding(0);
            lblTotalSalaries.Name = "lblTotalSalaries";
            lblTotalSalaries.RightToLeft = RightToLeft.Yes;
            lblTotalSalaries.Size = new Size(277, 50);
            lblTotalSalaries.TabIndex = 5;
            lblTotalSalaries.Text = "22";
            lblTotalSalaries.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblUnpaidInvoicesDisc
            // 
            lblUnpaidInvoicesDisc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUnpaidInvoicesDisc.AutoSize = true;
            lblUnpaidInvoicesDisc.BackColor = Color.Transparent;
            lblUnpaidInvoicesDisc.Font = new Font("Cairo ExtraBold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnpaidInvoicesDisc.ForeColor = Color.DimGray;
            lblUnpaidInvoicesDisc.Location = new Point(94, 44);
            lblUnpaidInvoicesDisc.Margin = new Padding(0);
            lblUnpaidInvoicesDisc.Name = "lblUnpaidInvoicesDisc";
            lblUnpaidInvoicesDisc.RightToLeft = RightToLeft.Yes;
            lblUnpaidInvoicesDisc.Size = new Size(229, 42);
            lblUnpaidInvoicesDisc.TabIndex = 2;
            lblUnpaidInvoicesDisc.Text = "إجمالي المشتريات (ج)";
            lblUnpaidInvoicesDisc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel2
            // 
            sabraPanel2.BackColor = Color.White;
            sabraPanel2.BorderColor = Color.LightGray;
            sabraPanel2.BorderRadius = 15;
            sabraPanel2.BorderSize = 0;
            sabraPanel2.Controls.Add(lblNumberOfEmployees);
            sabraPanel2.Controls.Add(sabraLabel1);
            sabraPanel2.EnableHover = true;
            sabraPanel2.ForeColor = Color.Black;
            sabraPanel2.GradientAngle = 90F;
            sabraPanel2.GradientBottomColor = Color.White;
            sabraPanel2.GradientTopColor = Color.White;
            sabraPanel2.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel2.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel2.HoverBorderSize = 2;
            sabraPanel2.Location = new Point(35, 15);
            sabraPanel2.Margin = new Padding(15);
            sabraPanel2.Name = "sabraPanel2";
            sabraPanel2.Size = new Size(337, 97);
            sabraPanel2.TabIndex = 18;
            // 
            // lblNumberOfEmployees
            // 
            lblNumberOfEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNumberOfEmployees.BackColor = Color.Transparent;
            lblNumberOfEmployees.Font = new Font("Cairo", 14F, FontStyle.Bold);
            lblNumberOfEmployees.ForeColor = Color.DimGray;
            lblNumberOfEmployees.IsTitle = true;
            lblNumberOfEmployees.Location = new Point(51, 5);
            lblNumberOfEmployees.Margin = new Padding(0);
            lblNumberOfEmployees.Name = "lblNumberOfEmployees";
            lblNumberOfEmployees.RightToLeft = RightToLeft.Yes;
            lblNumberOfEmployees.Size = new Size(277, 50);
            lblNumberOfEmployees.TabIndex = 7;
            lblNumberOfEmployees.Text = "22";
            lblNumberOfEmployees.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.Font = new Font("Cairo Black", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel1.ForeColor = Color.DimGray;
            sabraLabel1.Location = new Point(28, 40);
            sabraLabel1.Margin = new Padding(0);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.RightToLeft = RightToLeft.Yes;
            sabraLabel1.Size = new Size(300, 47);
            sabraLabel1.TabIndex = 2;
            sabraLabel1.Text = "عدد الموظفين";
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlLowStock
            // 
            pnlLowStock.BackColor = Color.White;
            pnlLowStock.BorderColor = Color.LightGray;
            pnlLowStock.BorderRadius = 15;
            pnlLowStock.BorderSize = 0;
            pnlLowStock.Controls.Add(lblTotalAdvances);
            pnlLowStock.Controls.Add(lblLowStockPartsDisc);
            pnlLowStock.EnableHover = true;
            pnlLowStock.ForeColor = Color.Black;
            pnlLowStock.GradientAngle = 90F;
            pnlLowStock.GradientBottomColor = Color.White;
            pnlLowStock.GradientTopColor = Color.White;
            pnlLowStock.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlLowStock.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlLowStock.HoverBorderSize = 2;
            pnlLowStock.Location = new Point(766, 15);
            pnlLowStock.Margin = new Padding(15);
            pnlLowStock.Name = "pnlLowStock";
            pnlLowStock.Size = new Size(334, 97);
            pnlLowStock.TabIndex = 17;
            // 
            // lblTotalAdvances
            // 
            lblTotalAdvances.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalAdvances.BackColor = Color.Transparent;
            lblTotalAdvances.Font = new Font("Cairo", 14F, FontStyle.Bold);
            lblTotalAdvances.ForeColor = Color.DarkGoldenrod;
            lblTotalAdvances.IsTitle = true;
            lblTotalAdvances.Location = new Point(44, 5);
            lblTotalAdvances.Margin = new Padding(0);
            lblTotalAdvances.Name = "lblTotalAdvances";
            lblTotalAdvances.RightToLeft = RightToLeft.Yes;
            lblTotalAdvances.Size = new Size(277, 50);
            lblTotalAdvances.TabIndex = 6;
            lblTotalAdvances.Text = "22";
            lblTotalAdvances.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLowStockPartsDisc
            // 
            lblLowStockPartsDisc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLowStockPartsDisc.AutoSize = true;
            lblLowStockPartsDisc.BackColor = Color.Transparent;
            lblLowStockPartsDisc.Font = new Font("Cairo Black", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLowStockPartsDisc.ForeColor = Color.DimGray;
            lblLowStockPartsDisc.Location = new Point(124, 45);
            lblLowStockPartsDisc.Margin = new Padding(0);
            lblLowStockPartsDisc.Name = "lblLowStockPartsDisc";
            lblLowStockPartsDisc.RightToLeft = RightToLeft.Yes;
            lblLowStockPartsDisc.Size = new Size(197, 42);
            lblLowStockPartsDisc.TabIndex = 2;
            lblLowStockPartsDisc.Text = "إجمالي السلف (ج)";
            lblLowStockPartsDisc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlNetProfit
            // 
            pnlNetProfit.BackColor = Color.White;
            pnlNetProfit.BorderColor = Color.LightGray;
            pnlNetProfit.BorderRadius = 15;
            pnlNetProfit.BorderSize = 0;
            pnlNetProfit.Controls.Add(sabraLabel2);
            pnlNetProfit.Controls.Add(lblNetPaid);
            pnlNetProfit.EnableHover = true;
            pnlNetProfit.ForeColor = Color.Black;
            pnlNetProfit.GradientAngle = 90F;
            pnlNetProfit.GradientBottomColor = Color.White;
            pnlNetProfit.GradientTopColor = Color.White;
            pnlNetProfit.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlNetProfit.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlNetProfit.HoverBorderSize = 2;
            pnlNetProfit.Location = new Point(424, 15);
            pnlNetProfit.Margin = new Padding(15);
            pnlNetProfit.Name = "pnlNetProfit";
            pnlNetProfit.Size = new Size(312, 97);
            pnlNetProfit.TabIndex = 16;
            // 
            // sabraLabel2
            // 
            sabraLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel2.AutoSize = true;
            sabraLabel2.BackColor = Color.Transparent;
            sabraLabel2.Font = new Font("Cairo Black", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel2.ForeColor = Color.DimGray;
            sabraLabel2.Location = new Point(86, 48);
            sabraLabel2.Margin = new Padding(0);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.RightToLeft = RightToLeft.Yes;
            sabraLabel2.Size = new Size(215, 42);
            sabraLabel2.TabIndex = 5;
            sabraLabel2.Text = "الصافي المدفوع (ج)";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNetPaid
            // 
            lblNetPaid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNetPaid.BackColor = Color.Transparent;
            lblNetPaid.Font = new Font("Cairo ExtraBold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNetPaid.ForeColor = Color.Red;
            lblNetPaid.IsTitle = true;
            lblNetPaid.Location = new Point(15, 5);
            lblNetPaid.Margin = new Padding(0);
            lblNetPaid.Name = "lblNetPaid";
            lblNetPaid.RightToLeft = RightToLeft.Yes;
            lblNetPaid.Size = new Size(277, 50);
            lblNetPaid.TabIndex = 4;
            lblNetPaid.Text = "22";
            lblNetPaid.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraFlowLayoutPanelContainerOfCards
            // 
            sabraFlowLayoutPanelContainerOfCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraFlowLayoutPanelContainerOfCards.AutoScroll = true;
            sabraFlowLayoutPanelContainerOfCards.BackColor = Color.Gainsboro;
            sabraFlowLayoutPanelContainerOfCards.BorderColor = Color.Transparent;
            sabraFlowLayoutPanelContainerOfCards.BorderRadius = 20;
            sabraFlowLayoutPanelContainerOfCards.BorderSize = 1;
            sabraFlowLayoutPanelContainerOfCards.Location = new Point(62, 338);
            sabraFlowLayoutPanelContainerOfCards.Name = "sabraFlowLayoutPanelContainerOfCards";
            sabraFlowLayoutPanelContainerOfCards.Size = new Size(1411, 571);
            sabraFlowLayoutPanelContainerOfCards.TabIndex = 6;
            // 
            // ucSalaries
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sabraFlowLayoutPanelContainerOfCards);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(sabraPanel1);
            Name = "ucSalaries";
            Load += ucSalaries_Load;
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnSalary).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            pnlUnpaidInvoices.ResumeLayout(false);
            pnlUnpaidInvoices.PerformLayout();
            sabraPanel2.ResumeLayout(false);
            pnlLowStock.ResumeLayout(false);
            pnlLowStock.PerformLayout();
            pnlNetProfit.ResumeLayout(false);
            pnlNetProfit.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraButton sbtnPurchaseOrder;
        private FontAwesome.Sharp.IconPictureBox icnSalary;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblMonthAndYear;
        private TableLayoutPanel tableLayoutPanel1;
        private SabraPanel pnlUnpaidInvoices;
        private SabraLabel lblUnpaidInvoicesDisc;
        private SabraLabel lblTotalPurchases;
        private SabraPanel sabraPanel2;
        private SabraLabel sabraLabel1;
        private SabraLabel lblNumberOfOrdars;
        private SabraPanel pnlLowStock;
        private SabraLabel lblLowStockPartsDisc;
        private SabraLabel lblTotalPaid;
        private SabraPanel pnlNetProfit;
        private SabraLabel sabraLabel2;
        private SabraLabel lblNetPaid;

        #endregion
        private SabraLabel lblTotalSalaries;
        private SabraLabel lblNumberOfEmployees;
        private SabraLabel lblTotalAdvances;
        private SabraFlowLayoutPanel sabraFlowLayoutPanelContainerOfCards;
        private SabraButton sbtnExportAsExcel;
    }
}
