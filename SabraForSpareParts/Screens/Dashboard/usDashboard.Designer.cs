namespace SabraForSpareParts.Screens
{
    partial class usDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usDashboard));
            LiveChartsCore.Drawing.Padding padding1 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding2 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend2 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            LiveChartsCore.Drawing.Padding padding3 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip2 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding4 = new LiveChartsCore.Drawing.Padding();
            spnlTopPanel = new SabraPanel();
            sabraButton2 = new SabraButton();
            sbtnRefresh = new SabraButton();
            lblLastRefresh = new SabraLabel();
            sabraLabel1 = new SabraLabel();
            slblTitleOfTopPanel = new SabraLabel();
            pnlSales = new SabraPanel();
            lblSalesDisc = new SabraLabel();
            lblSales = new SabraLabel();
            icSales = new FontAwesome.Sharp.IconPictureBox();
            pnlNetProfit = new SabraPanel();
            sabraLabel2 = new SabraLabel();
            lblNetProfit = new SabraLabel();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            pnlUnpaidInvoices = new SabraPanel();
            lblUnpaidInvoicesDisc = new SabraLabel();
            lblUnpaidInvoices = new SabraLabel();
            icnUnpaidInvoices = new FontAwesome.Sharp.IconPictureBox();
            pnlLowStock = new SabraPanel();
            lblLowStockPartsDisc = new SabraLabel();
            lblLowStockParts = new SabraLabel();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            sabraPanel5 = new SabraPanel();
            flpPendingOrders = new FlowLayoutPanel();
            lblDependingPO = new SabraLabel();
            sabraPanel4 = new SabraPanel();
            flpAlerts = new FlowLayoutPanel();
            lblAlerts = new SabraLabel();
            sabraPanel1 = new SabraPanel();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            sabraLabel3 = new SabraLabel();
            sabraPanel3 = new SabraPanel();
            flpRecentInvoices = new FlowLayoutPanel();
            lblLastInvoices = new SabraLabel();
            sabraPanel2 = new SabraPanel();
            lblDis = new SabraLabel();
            pieChart1 = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            spnlTopPanel.SuspendLayout();
            pnlSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icSales).BeginInit();
            pnlNetProfit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            pnlUnpaidInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnUnpaidInvoices).BeginInit();
            pnlLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            sabraPanel5.SuspendLayout();
            sabraPanel4.SuspendLayout();
            sabraPanel1.SuspendLayout();
            sabraPanel3.SuspendLayout();
            sabraPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // spnlTopPanel
            // 
            spnlTopPanel.BackColor = Color.White;
            spnlTopPanel.BorderColor = Color.LightGray;
            spnlTopPanel.BorderRadius = 15;
            spnlTopPanel.BorderSize = 0;
            spnlTopPanel.Controls.Add(sabraButton2);
            spnlTopPanel.Controls.Add(sbtnRefresh);
            spnlTopPanel.Controls.Add(lblLastRefresh);
            spnlTopPanel.Controls.Add(sabraLabel1);
            spnlTopPanel.Controls.Add(slblTitleOfTopPanel);
            spnlTopPanel.Dock = DockStyle.Top;
            spnlTopPanel.EnableHover = true;
            spnlTopPanel.ForeColor = Color.Black;
            spnlTopPanel.GradientAngle = 90F;
            spnlTopPanel.GradientBottomColor = Color.White;
            spnlTopPanel.GradientTopColor = Color.White;
            spnlTopPanel.HoverBackColor = Color.FromArgb(245, 248, 255);
            spnlTopPanel.HoverBorderColor = Color.FromArgb(37, 99, 235);
            spnlTopPanel.HoverBorderSize = 2;
            spnlTopPanel.Location = new Point(10, 10);
            spnlTopPanel.Name = "spnlTopPanel";
            spnlTopPanel.Size = new Size(1502, 97);
            spnlTopPanel.TabIndex = 0;
            // 
            // sabraButton2
            // 
            sabraButton2.BackColor = Color.RoyalBlue;
            sabraButton2.BorderColor = Color.DodgerBlue;
            sabraButton2.BorderRadius = 8;
            sabraButton2.BorderSize = 0;
            sabraButton2.FlatAppearance.BorderSize = 0;
            sabraButton2.FlatStyle = FlatStyle.Flat;
            sabraButton2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sabraButton2.ForeColor = Color.White;
            sabraButton2.HoverColor = Color.CornflowerBlue;
            sabraButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            sabraButton2.IconColor = Color.Black;
            sabraButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sabraButton2.Location = new Point(219, 73);
            sabraButton2.Name = "sabraButton2";
            sabraButton2.NormalColor = Color.RoyalBlue;
            sabraButton2.Size = new Size(8, 8);
            sabraButton2.TabIndex = 4;
            sabraButton2.Text = "sabraButton2";
            sabraButton2.UseVisualStyleBackColor = false;
            // 
            // sbtnRefresh
            // 
            sbtnRefresh.BackColor = Color.RoyalBlue;
            sbtnRefresh.BorderColor = Color.DodgerBlue;
            sbtnRefresh.BorderRadius = 20;
            sbtnRefresh.BorderSize = 0;
            sbtnRefresh.FlatAppearance.BorderSize = 0;
            sbtnRefresh.FlatStyle = FlatStyle.Flat;
            sbtnRefresh.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnRefresh.ForeColor = Color.White;
            sbtnRefresh.HoverColor = Color.CornflowerBlue;
            sbtnRefresh.IconChar = FontAwesome.Sharp.IconChar.None;
            sbtnRefresh.IconColor = Color.Black;
            sbtnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnRefresh.Location = new Point(31, 26);
            sbtnRefresh.Name = "sbtnRefresh";
            sbtnRefresh.NormalColor = Color.RoyalBlue;
            sbtnRefresh.Size = new Size(121, 41);
            sbtnRefresh.TabIndex = 3;
            sbtnRefresh.Text = "تحديث";
            sbtnRefresh.UseVisualStyleBackColor = false;
            // 
            // lblLastRefresh
            // 
            lblLastRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLastRefresh.AutoSize = true;
            lblLastRefresh.BackColor = Color.Transparent;
            lblLastRefresh.Font = new Font("Cairo", 10F);
            lblLastRefresh.ForeColor = Color.DimGray;
            lblLastRefresh.Location = new Point(1161, 58);
            lblLastRefresh.Margin = new Padding(0);
            lblLastRefresh.Name = "lblLastRefresh";
            lblLastRefresh.RightToLeft = RightToLeft.Yes;
            lblLastRefresh.Size = new Size(152, 32);
            lblLastRefresh.TabIndex = 2;
            lblLastRefresh.Text = "آخر تحديث 11:23 ص";
            lblLastRefresh.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel1.AutoSize = true;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.BorderColor = Color.Firebrick;
            sabraLabel1.Font = new Font("Cairo", 10F);
            sabraLabel1.ForeColor = Color.DimGray;
            sabraLabel1.Location = new Point(1326, 58);
            sabraLabel1.Margin = new Padding(0);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.RightToLeft = RightToLeft.Yes;
            sabraLabel1.Size = new Size(161, 32);
            sabraLabel1.TabIndex = 1;
            sabraLabel1.Text = "الأربعاء 15 يناير 2025";
            sabraLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // slblTitleOfTopPanel
            // 
            slblTitleOfTopPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblTitleOfTopPanel.AutoSize = true;
            slblTitleOfTopPanel.BackColor = Color.Transparent;
            slblTitleOfTopPanel.BorderColor = Color.Black;
            slblTitleOfTopPanel.Font = new Font("Cairo", 10F, FontStyle.Bold);
            slblTitleOfTopPanel.ForeColor = Color.Black;
            slblTitleOfTopPanel.Location = new Point(1380, 26);
            slblTitleOfTopPanel.Margin = new Padding(0);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(107, 32);
            slblTitleOfTopPanel.TabIndex = 0;
            slblTitleOfTopPanel.Text = "لوحة التحكم";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSales
            // 
            pnlSales.BackColor = Color.White;
            pnlSales.BorderColor = Color.LightGray;
            pnlSales.BorderRadius = 15;
            pnlSales.BorderSize = 0;
            tableLayoutPanel1.SetColumnSpan(pnlSales, 3);
            pnlSales.Controls.Add(lblSalesDisc);
            pnlSales.Controls.Add(lblSales);
            pnlSales.Controls.Add(icSales);
            pnlSales.EnableHover = true;
            pnlSales.ForeColor = Color.Black;
            pnlSales.GradientAngle = 90F;
            pnlSales.GradientBottomColor = Color.White;
            pnlSales.GradientTopColor = Color.White;
            pnlSales.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlSales.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlSales.HoverBorderSize = 2;
            pnlSales.Location = new Point(1158, 33);
            pnlSales.Name = "pnlSales";
            pnlSales.Size = new Size(341, 105);
            pnlSales.TabIndex = 1;
            // 
            // lblSalesDisc
            // 
            lblSalesDisc.AutoSize = true;
            lblSalesDisc.BackColor = Color.Transparent;
            lblSalesDisc.Font = new Font("Cairo", 10F);
            lblSalesDisc.ForeColor = Color.DimGray;
            lblSalesDisc.Location = new Point(87, 53);
            lblSalesDisc.Margin = new Padding(0);
            lblSalesDisc.Name = "lblSalesDisc";
            lblSalesDisc.RightToLeft = RightToLeft.Yes;
            lblSalesDisc.Size = new Size(143, 32);
            lblSalesDisc.TabIndex = 2;
            lblSalesDisc.Text = "مبيعات اليوم(جنية)";
            lblSalesDisc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSales
            // 
            lblSales.AutoSize = true;
            lblSales.BackColor = Color.Transparent;
            lblSales.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblSales.ForeColor = Color.Black;
            lblSales.IsTitle = true;
            lblSales.Location = new Point(122, 16);
            lblSales.Margin = new Padding(0);
            lblSales.Name = "lblSales";
            lblSales.RightToLeft = RightToLeft.Yes;
            lblSales.Size = new Size(72, 37);
            lblSales.TabIndex = 2;
            lblSales.Text = "20000";
            lblSales.TextAlign = ContentAlignment.MiddleRight;
            // 
            // icSales
            // 
            icSales.BackColor = Color.Transparent;
            icSales.ForeColor = Color.RoyalBlue;
            icSales.IconChar = FontAwesome.Sharp.IconChar.MoneyBill1;
            icSales.IconColor = Color.RoyalBlue;
            icSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icSales.IconSize = 70;
            icSales.Location = new Point(259, 3);
            icSales.Name = "icSales";
            icSales.Size = new Size(70, 99);
            icSales.SizeMode = PictureBoxSizeMode.Zoom;
            icSales.TabIndex = 0;
            icSales.TabStop = false;
            // 
            // pnlNetProfit
            // 
            pnlNetProfit.BackColor = Color.White;
            pnlNetProfit.BorderColor = Color.LightGray;
            pnlNetProfit.BorderRadius = 15;
            pnlNetProfit.BorderSize = 0;
            tableLayoutPanel1.SetColumnSpan(pnlNetProfit, 3);
            pnlNetProfit.Controls.Add(sabraLabel2);
            pnlNetProfit.Controls.Add(lblNetProfit);
            pnlNetProfit.Controls.Add(iconPictureBox1);
            pnlNetProfit.EnableHover = true;
            pnlNetProfit.ForeColor = Color.Black;
            pnlNetProfit.GradientAngle = 90F;
            pnlNetProfit.GradientBottomColor = Color.White;
            pnlNetProfit.GradientTopColor = Color.White;
            pnlNetProfit.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlNetProfit.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlNetProfit.HoverBorderSize = 2;
            pnlNetProfit.Location = new Point(783, 33);
            pnlNetProfit.Name = "pnlNetProfit";
            pnlNetProfit.Size = new Size(341, 105);
            pnlNetProfit.TabIndex = 3;
            // 
            // sabraLabel2
            // 
            sabraLabel2.AutoSize = true;
            sabraLabel2.BackColor = Color.Transparent;
            sabraLabel2.Font = new Font("Cairo", 10F);
            sabraLabel2.ForeColor = Color.DimGray;
            sabraLabel2.Location = new Point(92, 53);
            sabraLabel2.Margin = new Padding(0);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.RightToLeft = RightToLeft.Yes;
            sabraLabel2.Size = new Size(117, 32);
            sabraLabel2.TabIndex = 2;
            sabraLabel2.Text = "ربح اليوم (جنية)";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNetProfit
            // 
            lblNetProfit.AutoSize = true;
            lblNetProfit.BackColor = Color.Transparent;
            lblNetProfit.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblNetProfit.ForeColor = Color.Green;
            lblNetProfit.IsTitle = true;
            lblNetProfit.Location = new Point(136, 16);
            lblNetProfit.Margin = new Padding(0);
            lblNetProfit.Name = "lblNetProfit";
            lblNetProfit.RightToLeft = RightToLeft.Yes;
            lblNetProfit.Size = new Size(50, 37);
            lblNetProfit.TabIndex = 2;
            lblNetProfit.Text = "310";
            lblNetProfit.TextAlign = ContentAlignment.MiddleRight;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.Transparent;
            iconPictureBox1.ForeColor = Color.RoyalBlue;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTrendUp;
            iconPictureBox1.IconColor = Color.RoyalBlue;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 74;
            iconPictureBox1.Location = new Point(254, 3);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(74, 99);
            iconPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox1.TabIndex = 0;
            iconPictureBox1.TabStop = false;
            // 
            // pnlUnpaidInvoices
            // 
            pnlUnpaidInvoices.BackColor = Color.White;
            pnlUnpaidInvoices.BorderColor = Color.LightGray;
            pnlUnpaidInvoices.BorderRadius = 15;
            pnlUnpaidInvoices.BorderSize = 0;
            tableLayoutPanel1.SetColumnSpan(pnlUnpaidInvoices, 3);
            pnlUnpaidInvoices.Controls.Add(lblUnpaidInvoicesDisc);
            pnlUnpaidInvoices.Controls.Add(lblUnpaidInvoices);
            pnlUnpaidInvoices.Controls.Add(icnUnpaidInvoices);
            pnlUnpaidInvoices.EnableHover = true;
            pnlUnpaidInvoices.ForeColor = Color.Black;
            pnlUnpaidInvoices.GradientAngle = 90F;
            pnlUnpaidInvoices.GradientBottomColor = Color.White;
            pnlUnpaidInvoices.GradientTopColor = Color.White;
            pnlUnpaidInvoices.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlUnpaidInvoices.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlUnpaidInvoices.HoverBorderSize = 2;
            pnlUnpaidInvoices.Location = new Point(22, 33);
            pnlUnpaidInvoices.Name = "pnlUnpaidInvoices";
            pnlUnpaidInvoices.Size = new Size(356, 105);
            pnlUnpaidInvoices.TabIndex = 5;
            // 
            // lblUnpaidInvoicesDisc
            // 
            lblUnpaidInvoicesDisc.AutoSize = true;
            lblUnpaidInvoicesDisc.BackColor = Color.Transparent;
            lblUnpaidInvoicesDisc.Font = new Font("Cairo", 10F);
            lblUnpaidInvoicesDisc.ForeColor = Color.DimGray;
            lblUnpaidInvoicesDisc.Location = new Point(67, 53);
            lblUnpaidInvoicesDisc.Margin = new Padding(0);
            lblUnpaidInvoicesDisc.Name = "lblUnpaidInvoicesDisc";
            lblUnpaidInvoicesDisc.RightToLeft = RightToLeft.Yes;
            lblUnpaidInvoicesDisc.Size = new Size(135, 32);
            lblUnpaidInvoicesDisc.TabIndex = 2;
            lblUnpaidInvoicesDisc.Text = "فواتير غير مسددة";
            lblUnpaidInvoicesDisc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblUnpaidInvoices
            // 
            lblUnpaidInvoices.AutoSize = true;
            lblUnpaidInvoices.BackColor = Color.Transparent;
            lblUnpaidInvoices.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblUnpaidInvoices.ForeColor = Color.DarkGoldenrod;
            lblUnpaidInvoices.IsTitle = true;
            lblUnpaidInvoices.Location = new Point(125, 16);
            lblUnpaidInvoices.Margin = new Padding(0);
            lblUnpaidInvoices.Name = "lblUnpaidInvoices";
            lblUnpaidInvoices.RightToLeft = RightToLeft.Yes;
            lblUnpaidInvoices.Size = new Size(28, 37);
            lblUnpaidInvoices.TabIndex = 2;
            lblUnpaidInvoices.Text = "1";
            lblUnpaidInvoices.TextAlign = ContentAlignment.MiddleRight;
            // 
            // icnUnpaidInvoices
            // 
            icnUnpaidInvoices.BackColor = Color.Transparent;
            icnUnpaidInvoices.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnUnpaidInvoices.ForeColor = Color.Goldenrod;
            icnUnpaidInvoices.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            icnUnpaidInvoices.IconColor = Color.Goldenrod;
            icnUnpaidInvoices.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnUnpaidInvoices.IconSize = 75;
            icnUnpaidInvoices.Location = new Point(268, 3);
            icnUnpaidInvoices.Name = "icnUnpaidInvoices";
            icnUnpaidInvoices.Size = new Size(75, 99);
            icnUnpaidInvoices.SizeMode = PictureBoxSizeMode.Zoom;
            icnUnpaidInvoices.TabIndex = 0;
            icnUnpaidInvoices.TabStop = false;
            // 
            // pnlLowStock
            // 
            pnlLowStock.BackColor = Color.White;
            pnlLowStock.BorderColor = Color.LightGray;
            pnlLowStock.BorderRadius = 15;
            pnlLowStock.BorderSize = 0;
            tableLayoutPanel1.SetColumnSpan(pnlLowStock, 3);
            pnlLowStock.Controls.Add(lblLowStockPartsDisc);
            pnlLowStock.Controls.Add(lblLowStockParts);
            pnlLowStock.Controls.Add(icnDecreasedParts);
            pnlLowStock.EnableHover = true;
            pnlLowStock.ForeColor = Color.Black;
            pnlLowStock.GradientAngle = 90F;
            pnlLowStock.GradientBottomColor = Color.White;
            pnlLowStock.GradientTopColor = Color.White;
            pnlLowStock.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlLowStock.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlLowStock.HoverBorderSize = 2;
            pnlLowStock.Location = new Point(407, 33);
            pnlLowStock.Name = "pnlLowStock";
            pnlLowStock.Size = new Size(344, 105);
            pnlLowStock.TabIndex = 5;
            // 
            // lblLowStockPartsDisc
            // 
            lblLowStockPartsDisc.AutoSize = true;
            lblLowStockPartsDisc.BackColor = Color.Transparent;
            lblLowStockPartsDisc.Font = new Font("Cairo", 10F);
            lblLowStockPartsDisc.ForeColor = Color.DimGray;
            lblLowStockPartsDisc.Location = new Point(58, 53);
            lblLowStockPartsDisc.Margin = new Padding(0);
            lblLowStockPartsDisc.Name = "lblLowStockPartsDisc";
            lblLowStockPartsDisc.RightToLeft = RightToLeft.Yes;
            lblLowStockPartsDisc.Size = new Size(160, 32);
            lblLowStockPartsDisc.TabIndex = 2;
            lblLowStockPartsDisc.Text = "قطع مخزون منخفض";
            lblLowStockPartsDisc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLowStockParts
            // 
            lblLowStockParts.AutoSize = true;
            lblLowStockParts.BackColor = Color.Transparent;
            lblLowStockParts.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblLowStockParts.ForeColor = Color.DarkRed;
            lblLowStockParts.IsTitle = true;
            lblLowStockParts.Location = new Point(129, 16);
            lblLowStockParts.Margin = new Padding(0);
            lblLowStockParts.Name = "lblLowStockParts";
            lblLowStockParts.RightToLeft = RightToLeft.Yes;
            lblLowStockParts.Size = new Size(39, 37);
            lblLowStockParts.TabIndex = 2;
            lblLowStockParts.Text = "22";
            lblLowStockParts.TextAlign = ContentAlignment.MiddleRight;
            // 
            // icnDecreasedParts
            // 
            icnDecreasedParts.BackColor = Color.Transparent;
            icnDecreasedParts.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnDecreasedParts.ForeColor = Color.Brown;
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.Warning;
            icnDecreasedParts.IconColor = Color.Brown;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 77;
            icnDecreasedParts.Location = new Point(255, 3);
            icnDecreasedParts.Name = "icnDecreasedParts";
            icnDecreasedParts.Size = new Size(77, 99);
            icnDecreasedParts.SizeMode = PictureBoxSizeMode.Zoom;
            icnDecreasedParts.TabIndex = 0;
            icnDecreasedParts.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 12;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.164642F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.434548F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.164642F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.434548F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.Controls.Add(sabraPanel5, 6, 2);
            tableLayoutPanel1.Controls.Add(sabraPanel4, 4, 2);
            tableLayoutPanel1.Controls.Add(pnlSales, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlLowStock, 4, 0);
            tableLayoutPanel1.Controls.Add(pnlUnpaidInvoices, 5, 0);
            tableLayoutPanel1.Controls.Add(pnlNetProfit, 2, 0);
            tableLayoutPanel1.Controls.Add(sabraPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(sabraPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(sabraPanel2, 6, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 107);
            tableLayoutPanel1.Margin = new Padding(30);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(0, 30, 0, 0);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 27.1428566F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 72.85714F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 174F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1502, 928);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // sabraPanel5
            // 
            sabraPanel5.BackColor = Color.White;
            sabraPanel5.BorderColor = Color.LightGray;
            sabraPanel5.BorderRadius = 15;
            sabraPanel5.BorderSize = 0;
            tableLayoutPanel1.SetColumnSpan(sabraPanel5, 4);
            sabraPanel5.Controls.Add(flpPendingOrders);
            sabraPanel5.Controls.Add(lblDependingPO);
            sabraPanel5.Dock = DockStyle.Fill;
            sabraPanel5.EnableHover = true;
            sabraPanel5.ForeColor = Color.Black;
            sabraPanel5.GradientAngle = 90F;
            sabraPanel5.GradientBottomColor = Color.White;
            sabraPanel5.GradientTopColor = Color.White;
            sabraPanel5.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel5.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel5.HoverBorderSize = 2;
            sabraPanel5.Location = new Point(30, 603);
            sabraPanel5.Margin = new Padding(30);
            sabraPanel5.Name = "sabraPanel5";
            tableLayoutPanel1.SetRowSpan(sabraPanel5, 2);
            sabraPanel5.Size = new Size(447, 295);
            sabraPanel5.TabIndex = 10;
            // 
            // flpPendingOrders
            // 
            flpPendingOrders.FlowDirection = FlowDirection.TopDown;
            flpPendingOrders.Location = new Point(16, 69);
            flpPendingOrders.Name = "flpPendingOrders";
            flpPendingOrders.Size = new Size(399, 190);
            flpPendingOrders.TabIndex = 3;
            flpPendingOrders.WrapContents = false;
            // 
            // lblDependingPO
            // 
            lblDependingPO.AutoSize = true;
            lblDependingPO.BackColor = Color.Transparent;
            lblDependingPO.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblDependingPO.ForeColor = Color.FromArgb(64, 64, 64);
            lblDependingPO.IsTitle = true;
            lblDependingPO.Location = new Point(241, 17);
            lblDependingPO.Name = "lblDependingPO";
            lblDependingPO.RightToLeft = RightToLeft.Yes;
            lblDependingPO.Size = new Size(174, 37);
            lblDependingPO.TabIndex = 2;
            lblDependingPO.Text = " أوامر شراء معلقة";
            lblDependingPO.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel4
            // 
            sabraPanel4.BackColor = Color.White;
            sabraPanel4.BorderColor = Color.LightGray;
            sabraPanel4.BorderRadius = 15;
            sabraPanel4.BorderSize = 0;
            tableLayoutPanel1.SetColumnSpan(sabraPanel4, 4);
            sabraPanel4.Controls.Add(flpAlerts);
            sabraPanel4.Controls.Add(lblAlerts);
            sabraPanel4.Dock = DockStyle.Fill;
            sabraPanel4.EnableHover = true;
            sabraPanel4.ForeColor = Color.Black;
            sabraPanel4.GradientAngle = 90F;
            sabraPanel4.GradientBottomColor = Color.White;
            sabraPanel4.GradientTopColor = Color.White;
            sabraPanel4.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel4.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel4.HoverBorderSize = 2;
            sabraPanel4.Location = new Point(537, 603);
            sabraPanel4.Margin = new Padding(30);
            sabraPanel4.Name = "sabraPanel4";
            tableLayoutPanel1.SetRowSpan(sabraPanel4, 2);
            sabraPanel4.Size = new Size(435, 295);
            sabraPanel4.TabIndex = 9;
            // 
            // flpAlerts
            // 
            flpAlerts.FlowDirection = FlowDirection.TopDown;
            flpAlerts.Location = new Point(16, 69);
            flpAlerts.Name = "flpAlerts";
            flpAlerts.Size = new Size(395, 190);
            flpAlerts.TabIndex = 3;
            flpAlerts.WrapContents = false;
            // 
            // lblAlerts
            // 
            lblAlerts.AutoSize = true;
            lblAlerts.BackColor = Color.Transparent;
            lblAlerts.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblAlerts.ForeColor = Color.FromArgb(64, 64, 64);
            lblAlerts.IsTitle = true;
            lblAlerts.Location = new Point(300, 17);
            lblAlerts.Name = "lblAlerts";
            lblAlerts.RightToLeft = RightToLeft.Yes;
            lblAlerts.Size = new Size(111, 37);
            lblAlerts.TabIndex = 2;
            lblAlerts.Text = "آخر الفواتير";
            lblAlerts.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 0;
            tableLayoutPanel1.SetColumnSpan(sabraPanel1, 7);
            sabraPanel1.Controls.Add(cartesianChart1);
            sabraPanel1.Controls.Add(sabraLabel3);
            sabraPanel1.EnableHover = true;
            sabraPanel1.ForeColor = Color.Black;
            sabraPanel1.GradientAngle = 90F;
            sabraPanel1.GradientBottomColor = Color.White;
            sabraPanel1.GradientTopColor = Color.White;
            sabraPanel1.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel1.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel1.HoverBorderSize = 2;
            sabraPanel1.Location = new Point(672, 207);
            sabraPanel1.Margin = new Padding(30);
            sabraPanel1.Name = "sabraPanel1";
            sabraPanel1.Size = new Size(800, 327);
            sabraPanel1.TabIndex = 7;
            // 
            // cartesianChart1
            // 
            cartesianChart1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cartesianChart1.AutoUpdateEnabled = true;
            cartesianChart1.ChartTheme = null;
            cartesianChart1.ForeColor = Color.Black;
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
            cartesianChart1.Location = new Point(16, 59);
            cartesianChart1.Margin = new Padding(30);
            cartesianChart1.MatchAxesScreenDataRatio = false;
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.RightToLeft = RightToLeft.Yes;
            cartesianChart1.Size = new Size(760, 250);
            cartesianChart1.TabIndex = 1;
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
            // 
            // sabraLabel3
            // 
            sabraLabel3.AutoSize = true;
            sabraLabel3.BackColor = Color.Transparent;
            sabraLabel3.Font = new Font("Cairo", 12F, FontStyle.Bold);
            sabraLabel3.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel3.IsTitle = true;
            sabraLabel3.Location = new Point(503, 16);
            sabraLabel3.Name = "sabraLabel3";
            sabraLabel3.RightToLeft = RightToLeft.Yes;
            sabraLabel3.Size = new Size(274, 37);
            sabraLabel3.TabIndex = 0;
            sabraLabel3.Text = "مبيعات الأيام السبعة الماضية";
            sabraLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel3
            // 
            sabraPanel3.BackColor = Color.White;
            sabraPanel3.BorderColor = Color.LightGray;
            sabraPanel3.BorderRadius = 15;
            sabraPanel3.BorderSize = 0;
            tableLayoutPanel1.SetColumnSpan(sabraPanel3, 4);
            sabraPanel3.Controls.Add(flpRecentInvoices);
            sabraPanel3.Controls.Add(lblLastInvoices);
            sabraPanel3.Dock = DockStyle.Fill;
            sabraPanel3.EnableHover = true;
            sabraPanel3.ForeColor = Color.Black;
            sabraPanel3.GradientAngle = 90F;
            sabraPanel3.GradientBottomColor = Color.White;
            sabraPanel3.GradientTopColor = Color.White;
            sabraPanel3.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel3.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel3.HoverBorderSize = 2;
            sabraPanel3.Location = new Point(1032, 603);
            sabraPanel3.Margin = new Padding(30);
            sabraPanel3.Name = "sabraPanel3";
            tableLayoutPanel1.SetRowSpan(sabraPanel3, 2);
            sabraPanel3.Size = new Size(440, 295);
            sabraPanel3.TabIndex = 8;
            // 
            // flpRecentInvoices
            // 
            flpRecentInvoices.AutoScroll = true;
            flpRecentInvoices.FlowDirection = FlowDirection.TopDown;
            flpRecentInvoices.Location = new Point(13, 57);
            flpRecentInvoices.Name = "flpRecentInvoices";
            flpRecentInvoices.Size = new Size(412, 223);
            flpRecentInvoices.TabIndex = 3;
            flpRecentInvoices.WrapContents = false;
            // 
            // lblLastInvoices
            // 
            lblLastInvoices.AutoSize = true;
            lblLastInvoices.BackColor = Color.Transparent;
            lblLastInvoices.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblLastInvoices.ForeColor = Color.FromArgb(64, 64, 64);
            lblLastInvoices.IsTitle = true;
            lblLastInvoices.Location = new Point(308, 17);
            lblLastInvoices.Name = "lblLastInvoices";
            lblLastInvoices.RightToLeft = RightToLeft.Yes;
            lblLastInvoices.Size = new Size(111, 37);
            lblLastInvoices.TabIndex = 2;
            lblLastInvoices.Text = "آخر الفواتير";
            lblLastInvoices.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel2
            // 
            sabraPanel2.BackColor = Color.White;
            sabraPanel2.BorderColor = Color.LightGray;
            sabraPanel2.BorderRadius = 15;
            sabraPanel2.BorderSize = 0;
            tableLayoutPanel1.SetColumnSpan(sabraPanel2, 5);
            sabraPanel2.Controls.Add(lblDis);
            sabraPanel2.Controls.Add(pieChart1);
            sabraPanel2.EnableHover = true;
            sabraPanel2.ForeColor = Color.Black;
            sabraPanel2.GradientAngle = 90F;
            sabraPanel2.GradientBottomColor = Color.White;
            sabraPanel2.GradientTopColor = Color.White;
            sabraPanel2.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel2.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel2.HoverBorderSize = 2;
            sabraPanel2.Location = new Point(38, 207);
            sabraPanel2.Margin = new Padding(30);
            sabraPanel2.Name = "sabraPanel2";
            sabraPanel2.Size = new Size(561, 336);
            sabraPanel2.TabIndex = 2;
            // 
            // lblDis
            // 
            lblDis.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDis.AutoSize = true;
            lblDis.BackColor = Color.Transparent;
            lblDis.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblDis.ForeColor = Color.FromArgb(64, 64, 64);
            lblDis.IsTitle = true;
            lblDis.Location = new Point(403, 16);
            lblDis.Name = "lblDis";
            lblDis.RightToLeft = RightToLeft.Yes;
            lblDis.Size = new Size(146, 37);
            lblDis.TabIndex = 1;
            lblDis.Text = "توزيع المبيعات";
            lblDis.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pieChart1
            // 
            pieChart1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            pieChart1.Location = new Point(27, 59);
            pieChart1.Margin = new Padding(3, 138, 3, 138);
            pieChart1.Name = "pieChart1";
            pieChart1.Size = new Size(400, 250);
            pieChart1.TabIndex = 0;
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
            // 
            // usDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(spnlTopPanel);
            Name = "usDashboard";
            spnlTopPanel.ResumeLayout(false);
            spnlTopPanel.PerformLayout();
            pnlSales.ResumeLayout(false);
            pnlSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icSales).EndInit();
            pnlNetProfit.ResumeLayout(false);
            pnlNetProfit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            pnlUnpaidInvoices.ResumeLayout(false);
            pnlUnpaidInvoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnUnpaidInvoices).EndInit();
            pnlLowStock.ResumeLayout(false);
            pnlLowStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            sabraPanel5.ResumeLayout(false);
            sabraPanel5.PerformLayout();
            sabraPanel4.ResumeLayout(false);
            sabraPanel4.PerformLayout();
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            sabraPanel3.ResumeLayout(false);
            sabraPanel3.PerformLayout();
            sabraPanel2.ResumeLayout(false);
            sabraPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel spnlTopPanel;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel sabraLabel1;
        private SabraButton sabraButton2;
        private SabraButton sbtnRefresh;
        private SabraLabel lblLastRefresh;
        private SabraPanel pnlSales;
        private FontAwesome.Sharp.IconPictureBox icSales;
        private SabraLabel lblSalesDisc;
        private SabraLabel lblSales;
        private SabraPanel pnlNetProfit;
        private SabraLabel sabraLabel2;
        private SabraLabel lblNetProfit;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private SabraPanel pnlUnpaidInvoices;
        private SabraLabel lblUnpaidInvoicesDisc;
        private SabraLabel lblUnpaidInvoices;
        private FontAwesome.Sharp.IconPictureBox icnUnpaidInvoices;
        private SabraPanel pnlLowStock;
        private SabraLabel lblLowStockPartsDisc;
        private SabraLabel lblLowStockParts;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private TableLayoutPanel tableLayoutPanel1;
        private SabraPanel sabraPanel1;
        private SabraLabel sabraLabel3;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private SabraPanel sabraPanel2;
        private SabraLabel lblDis;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChart1;
        private SabraPanel sabraPanel3;
        private FlowLayoutPanel flpRecentInvoices;
        private SabraLabel lblLastInvoices;
        private SabraPanel sabraPanel4;
        private FlowLayoutPanel flpAlerts;
        private SabraLabel lblAlerts;
        private SabraPanel sabraPanel5;
        private FlowLayoutPanel flpPendingOrders;
        private SabraLabel lblDependingPO;
    }
}
