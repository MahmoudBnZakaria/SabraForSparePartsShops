namespace SabraForSpareParts.Screens
{
    partial class ucFinancialReports
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
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinancialReports));
            LiveChartsCore.Drawing.Padding padding1 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding2 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend2 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            LiveChartsCore.Drawing.Padding padding3 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip2 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding4 = new LiveChartsCore.Drawing.Padding();
            sabraPanel1 = new SabraPanel();
            cmbPeriod = new SabraComboBox();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            slblTitleOfTopPanel = new SabraLabel();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            lblMonthAndYear = new SabraLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlUnpaidInvoices = new SabraPanel();
            lblUnpaidInvoicesDisc = new SabraLabel();
            lblTotalSales = new SabraLabel();
            sabraPanel2 = new SabraPanel();
            sabraLabel1 = new SabraLabel();
            lblNetProfit = new SabraLabel();
            pnlLowStock = new SabraPanel();
            lbl = new SabraLabel();
            lblGrossProfit = new SabraLabel();
            pnlNetProfit = new SabraPanel();
            sabraLabel2 = new SabraLabel();
            lblTotalExpenses = new SabraLabel();
            spnlWeeklySales = new SabraPanel();
            sabraLabel3 = new SabraLabel();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            spnlSaleDistribution = new SabraPanel();
            pieChart1 = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            sabraLabel4 = new SabraLabel();
            pnlBestSellingItems = new SabraPanel();
            sabraFlowLayoutPanelBestSellingItems = new SabraFlowLayoutPanel();
            sabraLabel5 = new SabraLabel();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            pnlUnpaidInvoices.SuspendLayout();
            sabraPanel2.SuspendLayout();
            pnlLowStock.SuspendLayout();
            pnlNetProfit.SuspendLayout();
            spnlWeeklySales.SuspendLayout();
            spnlSaleDistribution.SuspendLayout();
            pnlBestSellingItems.SuspendLayout();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(cmbPeriod);
            sabraPanel1.Controls.Add(sbtnPrint);
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(icnDecreasedParts);
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
            // cmbPeriod
            // 
            cmbPeriod.BackColor = Color.WhiteSmoke;
            cmbPeriod.DrawMode = DrawMode.OwnerDrawFixed;
            cmbPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriod.FlatStyle = FlatStyle.Flat;
            cmbPeriod.Font = new Font("Cairo", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbPeriod.ForeColor = Color.FromArgb(64, 64, 64);
            cmbPeriod.FormattingEnabled = true;
            cmbPeriod.ItemHeight = 50;
            cmbPeriod.Items.AddRange(new object[] { "هذا الشهر", "الشهر الماضي", "هذا العام" });
            cmbPeriod.Location = new Point(383, 27);
            cmbPeriod.Name = "cmbPeriod";
            cmbPeriod.RightToLeft = RightToLeft.Yes;
            cmbPeriod.Size = new Size(254, 56);
            cmbPeriod.TabIndex = 19;
            cmbPeriod.SelectedIndexChanged += cmbPeriod_SelectedIndexChanged;
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
            sbtnPrint.Location = new Point(226, 30);
            sbtnPrint.Name = "sbtnPrint";
            sbtnPrint.NormalColor = Color.DimGray;
            sbtnPrint.Padding = new Padding(10, 0, 10, 0);
            sbtnPrint.Size = new Size(127, 41);
            sbtnPrint.TabIndex = 18;
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
            sbtnExportAsExcel.Location = new Point(55, 30);
            sbtnExportAsExcel.Name = "sbtnExportAsExcel";
            sbtnExportAsExcel.NormalColor = Color.Green;
            sbtnExportAsExcel.Padding = new Padding(10, 0, 10, 0);
            sbtnExportAsExcel.Size = new Size(157, 41);
            sbtnExportAsExcel.TabIndex = 17;
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
            slblTitleOfTopPanel.Location = new Point(1182, 0);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(219, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "التقارير المالية";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // icnDecreasedParts
            // 
            icnDecreasedParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icnDecreasedParts.BackColor = Color.Transparent;
            icnDecreasedParts.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnDecreasedParts.ForeColor = Color.RoyalBlue;
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            icnDecreasedParts.IconColor = Color.RoyalBlue;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1407, 20);
            icnDecreasedParts.Name = "icnDecreasedParts";
            icnDecreasedParts.Size = new Size(72, 65);
            icnDecreasedParts.SizeMode = PictureBoxSizeMode.Zoom;
            icnDecreasedParts.TabIndex = 14;
            icnDecreasedParts.TabStop = false;
            // 
            // lblMonthAndYear
            // 
            lblMonthAndYear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMonthAndYear.BackColor = Color.Transparent;
            lblMonthAndYear.Font = new Font("Cairo", 12F);
            lblMonthAndYear.ForeColor = SystemColors.WindowFrame;
            lblMonthAndYear.Location = new Point(1168, 48);
            lblMonthAndYear.Name = "lblMonthAndYear";
            lblMonthAndYear.RightToLeft = RightToLeft.Yes;
            lblMonthAndYear.Size = new Size(233, 37);
            lblMonthAndYear.TabIndex = 16;
            lblMonthAndYear.Text = "يناير 2025";
            lblMonthAndYear.TextAlign = ContentAlignment.MiddleRight;
            lblMonthAndYear.Click += lblMonthAndYear_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(pnlUnpaidInvoices, 0, 0);
            tableLayoutPanel1.Controls.Add(sabraPanel2, 3, 0);
            tableLayoutPanel1.Controls.Add(pnlLowStock, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlNetProfit, 2, 0);
            tableLayoutPanel1.Controls.Add(spnlWeeklySales, 0, 1);
            tableLayoutPanel1.Controls.Add(spnlSaleDistribution, 2, 1);
            tableLayoutPanel1.Controls.Add(pnlBestSellingItems, 3, 1);
            tableLayoutPanel1.Location = new Point(10, 154);
            tableLayoutPanel1.Margin = new Padding(30);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20, 0, 0, 0);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25.4416962F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 74.5583038F));
            tableLayoutPanel1.Size = new Size(1479, 733);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // pnlUnpaidInvoices
            // 
            pnlUnpaidInvoices.BackColor = Color.White;
            pnlUnpaidInvoices.BorderColor = Color.LightGray;
            pnlUnpaidInvoices.BorderRadius = 15;
            pnlUnpaidInvoices.BorderSize = 0;
            pnlUnpaidInvoices.Controls.Add(lblUnpaidInvoicesDisc);
            pnlUnpaidInvoices.Controls.Add(lblTotalSales);
            pnlUnpaidInvoices.EnableHover = true;
            pnlUnpaidInvoices.ForeColor = Color.Black;
            pnlUnpaidInvoices.GradientAngle = 90F;
            pnlUnpaidInvoices.GradientBottomColor = Color.White;
            pnlUnpaidInvoices.GradientTopColor = Color.White;
            pnlUnpaidInvoices.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlUnpaidInvoices.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlUnpaidInvoices.HoverBorderSize = 2;
            pnlUnpaidInvoices.Location = new Point(1151, 16);
            pnlUnpaidInvoices.Margin = new Padding(16);
            pnlUnpaidInvoices.Name = "pnlUnpaidInvoices";
            pnlUnpaidInvoices.Size = new Size(312, 96);
            pnlUnpaidInvoices.TabIndex = 18;
            // 
            // lblUnpaidInvoicesDisc
            // 
            lblUnpaidInvoicesDisc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUnpaidInvoicesDisc.AutoSize = true;
            lblUnpaidInvoicesDisc.BackColor = Color.Transparent;
            lblUnpaidInvoicesDisc.Font = new Font("Cairo ExtraBold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnpaidInvoicesDisc.ForeColor = Color.DimGray;
            lblUnpaidInvoicesDisc.Location = new Point(104, 54);
            lblUnpaidInvoicesDisc.Margin = new Padding(0);
            lblUnpaidInvoicesDisc.Name = "lblUnpaidInvoicesDisc";
            lblUnpaidInvoicesDisc.RightToLeft = RightToLeft.Yes;
            lblUnpaidInvoicesDisc.Size = new Size(167, 32);
            lblUnpaidInvoicesDisc.TabIndex = 2;
            lblUnpaidInvoicesDisc.Text = "إجمالي المبيعات (ج)";
            lblUnpaidInvoicesDisc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalSales
            // 
            lblTotalSales.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalSales.BackColor = Color.Transparent;
            lblTotalSales.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblTotalSales.ForeColor = Color.Green;
            lblTotalSales.IsTitle = true;
            lblTotalSales.Location = new Point(17, 4);
            lblTotalSales.Margin = new Padding(0);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.RightToLeft = RightToLeft.Yes;
            lblTotalSales.Size = new Size(266, 50);
            lblTotalSales.TabIndex = 2;
            lblTotalSales.Text = "847,230";
            lblTotalSales.TextAlign = ContentAlignment.MiddleRight;
            lblTotalSales.Click += lblTotalSales_Click;
            // 
            // sabraPanel2
            // 
            sabraPanel2.BackColor = Color.White;
            sabraPanel2.BorderColor = Color.LightGray;
            sabraPanel2.BorderRadius = 15;
            sabraPanel2.BorderSize = 0;
            sabraPanel2.Controls.Add(sabraLabel1);
            sabraPanel2.Controls.Add(lblNetProfit);
            sabraPanel2.EnableHover = true;
            sabraPanel2.ForeColor = Color.Black;
            sabraPanel2.GradientAngle = 90F;
            sabraPanel2.GradientBottomColor = Color.White;
            sabraPanel2.GradientTopColor = Color.White;
            sabraPanel2.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel2.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel2.HoverBorderSize = 2;
            sabraPanel2.Location = new Point(38, 15);
            sabraPanel2.Margin = new Padding(15);
            sabraPanel2.Name = "sabraPanel2";
            sabraPanel2.Size = new Size(334, 97);
            sabraPanel2.TabIndex = 18;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel1.AutoSize = true;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel1.ForeColor = Color.DimGray;
            sabraLabel1.Location = new Point(197, 55);
            sabraLabel1.Margin = new Padding(0);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.RightToLeft = RightToLeft.Yes;
            sabraLabel1.Size = new Size(123, 32);
            sabraLabel1.TabIndex = 2;
            sabraLabel1.Text = "صافي الربح (ج)";
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNetProfit
            // 
            lblNetProfit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNetProfit.BackColor = Color.Transparent;
            lblNetProfit.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblNetProfit.ForeColor = Color.Green;
            lblNetProfit.IsTitle = true;
            lblNetProfit.Location = new Point(22, 1);
            lblNetProfit.Margin = new Padding(0);
            lblNetProfit.Name = "lblNetProfit";
            lblNetProfit.RightToLeft = RightToLeft.Yes;
            lblNetProfit.Size = new Size(278, 54);
            lblNetProfit.TabIndex = 2;
            lblNetProfit.Text = "22";
            lblNetProfit.TextAlign = ContentAlignment.MiddleRight;
            lblNetProfit.Click += lblNetProfit_Click;
            // 
            // pnlLowStock
            // 
            pnlLowStock.BackColor = Color.White;
            pnlLowStock.BorderColor = Color.LightGray;
            pnlLowStock.BorderRadius = 15;
            pnlLowStock.BorderSize = 0;
            pnlLowStock.Controls.Add(lbl);
            pnlLowStock.Controls.Add(lblGrossProfit);
            pnlLowStock.EnableHover = true;
            pnlLowStock.ForeColor = Color.Black;
            pnlLowStock.GradientAngle = 90F;
            pnlLowStock.GradientBottomColor = Color.White;
            pnlLowStock.GradientTopColor = Color.White;
            pnlLowStock.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlLowStock.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlLowStock.HoverBorderSize = 2;
            pnlLowStock.Location = new Point(788, 15);
            pnlLowStock.Margin = new Padding(15);
            pnlLowStock.Name = "pnlLowStock";
            pnlLowStock.Size = new Size(312, 97);
            pnlLowStock.TabIndex = 17;
            // 
            // lbl
            // 
            lbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            lbl.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl.ForeColor = Color.DimGray;
            lbl.Location = new Point(145, 55);
            lbl.Margin = new Padding(0);
            lbl.Name = "lbl";
            lbl.RightToLeft = RightToLeft.Yes;
            lbl.Size = new Size(144, 32);
            lbl.TabIndex = 2;
            lbl.Text = "إجمالي الأرباح (ج)";
            lbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGrossProfit
            // 
            lblGrossProfit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGrossProfit.BackColor = Color.Transparent;
            lblGrossProfit.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblGrossProfit.ForeColor = Color.Green;
            lblGrossProfit.IsTitle = true;
            lblGrossProfit.Location = new Point(9, 5);
            lblGrossProfit.Margin = new Padding(0);
            lblGrossProfit.Name = "lblGrossProfit";
            lblGrossProfit.RightToLeft = RightToLeft.Yes;
            lblGrossProfit.Size = new Size(280, 54);
            lblGrossProfit.TabIndex = 2;
            lblGrossProfit.Text = "22";
            lblGrossProfit.TextAlign = ContentAlignment.MiddleRight;
            lblGrossProfit.Click += lblGrossProfit_Click;
            // 
            // pnlNetProfit
            // 
            pnlNetProfit.BackColor = Color.White;
            pnlNetProfit.BorderColor = Color.LightGray;
            pnlNetProfit.BorderRadius = 15;
            pnlNetProfit.BorderSize = 0;
            pnlNetProfit.Controls.Add(sabraLabel2);
            pnlNetProfit.Controls.Add(lblTotalExpenses);
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
            sabraLabel2.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel2.ForeColor = Color.DimGray;
            sabraLabel2.Location = new Point(109, 55);
            sabraLabel2.Margin = new Padding(0);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.RightToLeft = RightToLeft.Yes;
            sabraLabel2.Size = new Size(184, 32);
            sabraLabel2.TabIndex = 5;
            sabraLabel2.Text = "إجمالي المصروفات (ج)";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalExpenses
            // 
            lblTotalExpenses.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalExpenses.BackColor = Color.Transparent;
            lblTotalExpenses.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblTotalExpenses.ForeColor = Color.Red;
            lblTotalExpenses.IsTitle = true;
            lblTotalExpenses.Location = new Point(0, 1);
            lblTotalExpenses.Margin = new Padding(0);
            lblTotalExpenses.Name = "lblTotalExpenses";
            lblTotalExpenses.RightToLeft = RightToLeft.Yes;
            lblTotalExpenses.Size = new Size(277, 50);
            lblTotalExpenses.TabIndex = 4;
            lblTotalExpenses.Text = "22";
            lblTotalExpenses.TextAlign = ContentAlignment.MiddleRight;
            lblTotalExpenses.Click += lblTotalExpenses_Click;
            // 
            // spnlWeeklySales
            // 
            spnlWeeklySales.BackColor = Color.White;
            spnlWeeklySales.BorderColor = Color.LightGray;
            spnlWeeklySales.BorderRadius = 15;
            spnlWeeklySales.BorderSize = 0;
            tableLayoutPanel1.SetColumnSpan(spnlWeeklySales, 2);
            spnlWeeklySales.Controls.Add(sabraLabel3);
            spnlWeeklySales.Controls.Add(cartesianChart1);
            spnlWeeklySales.Dock = DockStyle.Fill;
            spnlWeeklySales.EnableHover = true;
            spnlWeeklySales.ForeColor = Color.Black;
            spnlWeeklySales.GradientAngle = 90F;
            spnlWeeklySales.GradientBottomColor = Color.White;
            spnlWeeklySales.GradientTopColor = Color.White;
            spnlWeeklySales.HoverBackColor = Color.FromArgb(245, 248, 255);
            spnlWeeklySales.HoverBorderColor = Color.FromArgb(37, 99, 235);
            spnlWeeklySales.HoverBorderSize = 2;
            spnlWeeklySales.Location = new Point(781, 216);
            spnlWeeklySales.Margin = new Padding(30);
            spnlWeeklySales.Name = "spnlWeeklySales";
            spnlWeeklySales.Size = new Size(668, 487);
            spnlWeeklySales.TabIndex = 19;
            // 
            // sabraLabel3
            // 
            sabraLabel3.BackColor = Color.Transparent;
            sabraLabel3.Dock = DockStyle.Top;
            sabraLabel3.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel3.ForeColor = Color.DimGray;
            sabraLabel3.Location = new Point(0, 0);
            sabraLabel3.Margin = new Padding(30);
            sabraLabel3.Name = "sabraLabel3";
            sabraLabel3.Padding = new Padding(0, 0, 30, 0);
            sabraLabel3.RightToLeft = RightToLeft.Yes;
            sabraLabel3.Size = new Size(668, 47);
            sabraLabel3.TabIndex = 6;
            sabraLabel3.Text = "مبيعات الأسبوع";
            sabraLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cartesianChart1.AutoUpdateEnabled = true;
            cartesianChart1.ChartTheme = null;
            skDefaultLegend1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultLegend1.Content = null;
            skDefaultLegend1.IsValid = false;
            skDefaultLegend1.Opacity = 1F;
            padding1.Bottom = 0F;
            padding1.Left = 0F;
            padding1.Right = 0F;
            padding1.Top = 0F;
            skDefaultLegend1.Padding = padding1;
            skDefaultLegend1.RemoveOnCompleted = false;
            skDefaultLegend1.RotateTransform = 0F;
            skDefaultLegend1.X = 0F;
            skDefaultLegend1.Y = 0F;
            cartesianChart1.Legend = skDefaultLegend1;
            cartesianChart1.Location = new Point(30, 82);
            cartesianChart1.Margin = new Padding(30);
            cartesianChart1.MatchAxesScreenDataRatio = false;
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Padding = new Padding(30);
            cartesianChart1.Size = new Size(610, 375);
            cartesianChart1.TabIndex = 0;
            skDefaultTooltip1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultTooltip1.Content = null;
            skDefaultTooltip1.IsValid = false;
            skDefaultTooltip1.Opacity = 1F;
            padding2.Bottom = 0F;
            padding2.Left = 0F;
            padding2.Right = 0F;
            padding2.Top = 0F;
            skDefaultTooltip1.Padding = padding2;
            skDefaultTooltip1.RemoveOnCompleted = false;
            skDefaultTooltip1.RotateTransform = 0F;
            skDefaultTooltip1.Wedge = 10;
            skDefaultTooltip1.X = 0F;
            skDefaultTooltip1.Y = 0F;
            cartesianChart1.Tooltip = skDefaultTooltip1;
            cartesianChart1.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.Automatic;
            cartesianChart1.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            cartesianChart1.Load += cartesianChart1_Load;
            // 
            // spnlSaleDistribution
            // 
            spnlSaleDistribution.BackColor = Color.White;
            spnlSaleDistribution.BorderColor = Color.LightGray;
            spnlSaleDistribution.BorderRadius = 15;
            spnlSaleDistribution.BorderSize = 0;
            spnlSaleDistribution.Controls.Add(pieChart1);
            spnlSaleDistribution.Controls.Add(sabraLabel4);
            spnlSaleDistribution.Dock = DockStyle.Fill;
            spnlSaleDistribution.EnableHover = true;
            spnlSaleDistribution.ForeColor = Color.Black;
            spnlSaleDistribution.GradientAngle = 90F;
            spnlSaleDistribution.GradientBottomColor = Color.White;
            spnlSaleDistribution.GradientTopColor = Color.White;
            spnlSaleDistribution.HoverBackColor = Color.FromArgb(245, 248, 255);
            spnlSaleDistribution.HoverBorderColor = Color.FromArgb(37, 99, 235);
            spnlSaleDistribution.HoverBorderSize = 2;
            spnlSaleDistribution.Location = new Point(387, 186);
            spnlSaleDistribution.Margin = new Padding(0);
            spnlSaleDistribution.Name = "spnlSaleDistribution";
            spnlSaleDistribution.Size = new Size(364, 547);
            spnlSaleDistribution.TabIndex = 20;
            // 
            // pieChart1
            // 
            pieChart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pieChart1.AutoUpdateEnabled = true;
            pieChart1.ChartTheme = null;
            skDefaultLegend2.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultLegend2.Content = null;
            skDefaultLegend2.IsValid = false;
            skDefaultLegend2.Opacity = 1F;
            padding3.Bottom = 0F;
            padding3.Left = 0F;
            padding3.Right = 0F;
            padding3.Top = 0F;
            skDefaultLegend2.Padding = padding3;
            skDefaultLegend2.RemoveOnCompleted = false;
            skDefaultLegend2.RotateTransform = 0F;
            skDefaultLegend2.X = 0F;
            skDefaultLegend2.Y = 0F;
            pieChart1.Legend = skDefaultLegend2;
            pieChart1.Location = new Point(14, 77);
            pieChart1.Name = "pieChart1";
            pieChart1.Size = new Size(340, 454);
            pieChart1.TabIndex = 8;
            skDefaultTooltip2.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultTooltip2.Content = null;
            skDefaultTooltip2.IsValid = false;
            skDefaultTooltip2.Opacity = 1F;
            padding4.Bottom = 0F;
            padding4.Left = 0F;
            padding4.Right = 0F;
            padding4.Top = 0F;
            skDefaultTooltip2.Padding = padding4;
            skDefaultTooltip2.RemoveOnCompleted = false;
            skDefaultTooltip2.RotateTransform = 0F;
            skDefaultTooltip2.Wedge = 10;
            skDefaultTooltip2.X = 0F;
            skDefaultTooltip2.Y = 0F;
            pieChart1.Tooltip = skDefaultTooltip2;
            pieChart1.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            pieChart1.Load += pieChart1_Load;
            // 
            // sabraLabel4
            // 
            sabraLabel4.BackColor = Color.Transparent;
            sabraLabel4.Dock = DockStyle.Top;
            sabraLabel4.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel4.ForeColor = Color.DimGray;
            sabraLabel4.Location = new Point(0, 0);
            sabraLabel4.Margin = new Padding(30);
            sabraLabel4.Name = "sabraLabel4";
            sabraLabel4.Padding = new Padding(0, 0, 30, 0);
            sabraLabel4.RightToLeft = RightToLeft.Yes;
            sabraLabel4.Size = new Size(364, 47);
            sabraLabel4.TabIndex = 7;
            sabraLabel4.Text = "توزيع المبيعات";
            sabraLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlBestSellingItems
            // 
            pnlBestSellingItems.BackColor = Color.White;
            pnlBestSellingItems.BorderColor = Color.LightGray;
            pnlBestSellingItems.BorderRadius = 15;
            pnlBestSellingItems.BorderSize = 0;
            pnlBestSellingItems.Controls.Add(sabraFlowLayoutPanelBestSellingItems);
            pnlBestSellingItems.Controls.Add(sabraLabel5);
            pnlBestSellingItems.Dock = DockStyle.Fill;
            pnlBestSellingItems.EnableHover = true;
            pnlBestSellingItems.ForeColor = Color.Black;
            pnlBestSellingItems.GradientAngle = 90F;
            pnlBestSellingItems.GradientBottomColor = Color.White;
            pnlBestSellingItems.GradientTopColor = Color.White;
            pnlBestSellingItems.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlBestSellingItems.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlBestSellingItems.HoverBorderSize = 2;
            pnlBestSellingItems.Location = new Point(50, 216);
            pnlBestSellingItems.Margin = new Padding(30);
            pnlBestSellingItems.Name = "pnlBestSellingItems";
            pnlBestSellingItems.Size = new Size(307, 487);
            pnlBestSellingItems.TabIndex = 21;
            // 
            // sabraFlowLayoutPanelBestSellingItems
            // 
            sabraFlowLayoutPanelBestSellingItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sabraFlowLayoutPanelBestSellingItems.BackColor = Color.White;
            sabraFlowLayoutPanelBestSellingItems.BorderColor = Color.DodgerBlue;
            sabraFlowLayoutPanelBestSellingItems.BorderRadius = 15;
            sabraFlowLayoutPanelBestSellingItems.BorderSize = 0;
            sabraFlowLayoutPanelBestSellingItems.Location = new Point(10, 60);
            sabraFlowLayoutPanelBestSellingItems.Name = "sabraFlowLayoutPanelBestSellingItems";
            sabraFlowLayoutPanelBestSellingItems.Size = new Size(278, 411);
            sabraFlowLayoutPanelBestSellingItems.TabIndex = 8;
            sabraFlowLayoutPanelBestSellingItems.Paint += sabraFlowLayoutPanelBestSellingItems_Paint;
            // 
            // sabraLabel5
            // 
            sabraLabel5.BackColor = Color.Transparent;
            sabraLabel5.Dock = DockStyle.Top;
            sabraLabel5.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel5.ForeColor = Color.DimGray;
            sabraLabel5.Location = new Point(0, 0);
            sabraLabel5.Margin = new Padding(30);
            sabraLabel5.Name = "sabraLabel5";
            sabraLabel5.Padding = new Padding(0, 0, 30, 0);
            sabraLabel5.RightToLeft = RightToLeft.Yes;
            sabraLabel5.Size = new Size(307, 47);
            sabraLabel5.TabIndex = 7;
            sabraLabel5.Text = "أعلى 5 قطع مبيعا";
            sabraLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ucFinancialReports
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(sabraPanel1);
            Name = "ucFinancialReports";
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            pnlUnpaidInvoices.ResumeLayout(false);
            pnlUnpaidInvoices.PerformLayout();
            sabraPanel2.ResumeLayout(false);
            sabraPanel2.PerformLayout();
            pnlLowStock.ResumeLayout(false);
            pnlLowStock.PerformLayout();
            pnlNetProfit.ResumeLayout(false);
            pnlNetProfit.PerformLayout();
            spnlWeeklySales.ResumeLayout(false);
            spnlSaleDistribution.ResumeLayout(false);
            pnlBestSellingItems.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblMonthAndYear;
        private TableLayoutPanel tableLayoutPanel1;
        private SabraPanel pnlUnpaidInvoices;
        private SabraLabel lblUnpaidInvoicesDisc;
        private SabraLabel lblTotalSales;
        private SabraPanel sabraPanel2;
        private SabraLabel sabraLabel1;
        private SabraLabel lblNetProfit;
        private SabraPanel pnlLowStock;
        private SabraLabel lbl;
        private SabraLabel lblGrossProfit;
        private SabraPanel pnlNetProfit;
        private SabraLabel sabraLabel2;
        private SabraLabel lblTotalExpenses;
        private SabraComboBox cmbPeriod;
        private SabraPanel spnlWeeklySales;
        private SabraPanel spnlSaleDistribution;
        private SabraPanel pnlBestSellingItems;
        private SabraLabel sabraLabel3;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private SabraLabel sabraLabel4;
        private SabraLabel sabraLabel5;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChart1;
        private SabraFlowLayoutPanel sabraFlowLayoutPanelBestSellingItems;
    }
}
