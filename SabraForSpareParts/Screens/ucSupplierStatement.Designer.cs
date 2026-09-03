namespace SabraForSpareParts.Screens
{
    partial class ucSupplierStatement
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            sabraPanel1 = new SabraPanel();
            sbtnPurchaseOrder = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            slblTitleOfTopPanel = new SabraLabel();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            lblSupplierName = new SabraLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlUnpaidInvoices = new SabraPanel();
            lblUnpaidInvoicesDisc = new SabraLabel();
            lblTotalPurchases = new SabraLabel();
            sabraPanel2 = new SabraPanel();
            sabraLabel1 = new SabraLabel();
            lblNumberOfOrdars = new SabraLabel();
            pnlLowStock = new SabraPanel();
            lblLowStockPartsDisc = new SabraLabel();
            lblTotalPaid = new SabraLabel();
            pnlNetProfit = new SabraPanel();
            sabraLabel2 = new SabraLabel();
            lblDebitBalance = new SabraLabel();
            dgvSupplierStatement = new SabraDataGridView();
            sbtnSearch = new SabraButton();
            stbxSearchForCustomer = new SabraTextBox();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            pnlUnpaidInvoices.SuspendLayout();
            sabraPanel2.SuspendLayout();
            pnlLowStock.SuspendLayout();
            pnlNetProfit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSupplierStatement).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(sbtnSearch);
            sabraPanel1.Controls.Add(stbxSearchForCustomer);
            sabraPanel1.Controls.Add(sbtnPurchaseOrder);
            sabraPanel1.Controls.Add(sbtnPrint);
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(lblSupplierName);
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
            // sbtnPurchaseOrder
            // 
            sbtnPurchaseOrder.BackColor = Color.RoyalBlue;
            sbtnPurchaseOrder.BorderColor = Color.DodgerBlue;
            sbtnPurchaseOrder.BorderRadius = 20;
            sbtnPurchaseOrder.BorderSize = 0;
            sbtnPurchaseOrder.FlatAppearance.BorderSize = 0;
            sbtnPurchaseOrder.FlatStyle = FlatStyle.Flat;
            sbtnPurchaseOrder.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnPurchaseOrder.ForeColor = Color.White;
            sbtnPurchaseOrder.HoverColor = Color.CornflowerBlue;
            sbtnPurchaseOrder.IconChar = FontAwesome.Sharp.IconChar.Add;
            sbtnPurchaseOrder.IconColor = Color.White;
            sbtnPurchaseOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnPurchaseOrder.IconSize = 30;
            sbtnPurchaseOrder.ImageAlign = ContentAlignment.MiddleRight;
            sbtnPurchaseOrder.Location = new Point(32, 20);
            sbtnPurchaseOrder.Name = "sbtnPurchaseOrder";
            sbtnPurchaseOrder.NormalColor = Color.RoyalBlue;
            sbtnPurchaseOrder.Size = new Size(166, 62);
            sbtnPurchaseOrder.TabIndex = 19;
            sbtnPurchaseOrder.Text = "طلب شراء جديد";
            sbtnPurchaseOrder.TextAlign = ContentAlignment.MiddleLeft;
            sbtnPurchaseOrder.UseVisualStyleBackColor = false;
            sbtnPurchaseOrder.Click += sbtnPurchaseOrder_Click;
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
            sbtnPrint.Location = new Point(389, 35);
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
            sbtnExportAsExcel.Location = new Point(218, 35);
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
            slblTitleOfTopPanel.Location = new Point(1139, 13);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(262, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "كشف حساب مورد";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // icnDecreasedParts
            // 
            icnDecreasedParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icnDecreasedParts.BackColor = Color.Transparent;
            icnDecreasedParts.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnDecreasedParts.ForeColor = Color.RoyalBlue;
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.FileCircleCheck;
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
            // lblSupplierName
            // 
            lblSupplierName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSupplierName.BackColor = Color.Transparent;
            lblSupplierName.Font = new Font("Cairo", 12F);
            lblSupplierName.ForeColor = SystemColors.WindowFrame;
            lblSupplierName.Location = new Point(1168, 58);
            lblSupplierName.Name = "lblSupplierName";
            lblSupplierName.RightToLeft = RightToLeft.Yes;
            lblSupplierName.Size = new Size(233, 37);
            lblSupplierName.TabIndex = 16;
            lblSupplierName.Text = "ورشة النيل";
            lblSupplierName.TextAlign = ContentAlignment.MiddleRight;
            lblSupplierName.Click += lblSupplierName_Click;
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
            pnlUnpaidInvoices.Controls.Add(lblUnpaidInvoicesDisc);
            pnlUnpaidInvoices.Controls.Add(lblTotalPurchases);
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
            lblUnpaidInvoicesDisc.Size = new Size(179, 32);
            lblUnpaidInvoicesDisc.TabIndex = 2;
            lblUnpaidInvoicesDisc.Text = "إجمالي المشتريات (ج)";
            lblUnpaidInvoicesDisc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalPurchases
            // 
            lblTotalPurchases.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalPurchases.BackColor = Color.Transparent;
            lblTotalPurchases.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblTotalPurchases.ForeColor = Color.RoyalBlue;
            lblTotalPurchases.IsTitle = true;
            lblTotalPurchases.Location = new Point(17, 4);
            lblTotalPurchases.Margin = new Padding(0);
            lblTotalPurchases.Name = "lblTotalPurchases";
            lblTotalPurchases.RightToLeft = RightToLeft.Yes;
            lblTotalPurchases.Size = new Size(266, 50);
            lblTotalPurchases.TabIndex = 2;
            lblTotalPurchases.Text = "1";
            lblTotalPurchases.TextAlign = ContentAlignment.MiddleRight;
            lblTotalPurchases.Click += lblTotalPurchases_Click;
            // 
            // sabraPanel2
            // 
            sabraPanel2.BackColor = Color.White;
            sabraPanel2.BorderColor = Color.LightGray;
            sabraPanel2.BorderRadius = 15;
            sabraPanel2.BorderSize = 0;
            sabraPanel2.Controls.Add(sabraLabel1);
            sabraPanel2.Controls.Add(lblNumberOfOrdars);
            sabraPanel2.EnableHover = true;
            sabraPanel2.ForeColor = Color.Black;
            sabraPanel2.GradientAngle = 90F;
            sabraPanel2.GradientBottomColor = Color.White;
            sabraPanel2.GradientTopColor = Color.White;
            sabraPanel2.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel2.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel2.HoverBorderSize = 2;
            sabraPanel2.Location = new Point(60, 15);
            sabraPanel2.Margin = new Padding(15);
            sabraPanel2.Name = "sabraPanel2";
            sabraPanel2.Size = new Size(312, 97);
            sabraPanel2.TabIndex = 18;
            sabraPanel2.Paint += sabraPanel2_Paint;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel1.AutoSize = true;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel1.ForeColor = Color.DimGray;
            sabraLabel1.Location = new Point(175, 55);
            sabraLabel1.Margin = new Padding(0);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.RightToLeft = RightToLeft.Yes;
            sabraLabel1.Size = new Size(116, 32);
            sabraLabel1.TabIndex = 2;
            sabraLabel1.Text = "عدد الطلبيات";
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNumberOfOrdars
            // 
            lblNumberOfOrdars.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNumberOfOrdars.BackColor = Color.Transparent;
            lblNumberOfOrdars.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblNumberOfOrdars.ForeColor = Color.Black;
            lblNumberOfOrdars.IsTitle = true;
            lblNumberOfOrdars.Location = new Point(0, 1);
            lblNumberOfOrdars.Margin = new Padding(0);
            lblNumberOfOrdars.Name = "lblNumberOfOrdars";
            lblNumberOfOrdars.RightToLeft = RightToLeft.Yes;
            lblNumberOfOrdars.Size = new Size(278, 54);
            lblNumberOfOrdars.TabIndex = 2;
            lblNumberOfOrdars.Text = "22";
            lblNumberOfOrdars.TextAlign = ContentAlignment.MiddleRight;
            lblNumberOfOrdars.Click += lblNumberOfOrdars_Click;
            // 
            // pnlLowStock
            // 
            pnlLowStock.BackColor = Color.White;
            pnlLowStock.BorderColor = Color.LightGray;
            pnlLowStock.BorderRadius = 15;
            pnlLowStock.BorderSize = 0;
            pnlLowStock.Controls.Add(lblLowStockPartsDisc);
            pnlLowStock.Controls.Add(lblTotalPaid);
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
            // lblLowStockPartsDisc
            // 
            lblLowStockPartsDisc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLowStockPartsDisc.AutoSize = true;
            lblLowStockPartsDisc.BackColor = Color.Transparent;
            lblLowStockPartsDisc.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLowStockPartsDisc.ForeColor = Color.DimGray;
            lblLowStockPartsDisc.Location = new Point(117, 55);
            lblLowStockPartsDisc.Margin = new Padding(0);
            lblLowStockPartsDisc.Name = "lblLowStockPartsDisc";
            lblLowStockPartsDisc.RightToLeft = RightToLeft.Yes;
            lblLowStockPartsDisc.Size = new Size(163, 32);
            lblLowStockPartsDisc.TabIndex = 2;
            lblLowStockPartsDisc.Text = "إجمالي المدفوع (ح)";
            lblLowStockPartsDisc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalPaid
            // 
            lblTotalPaid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalPaid.BackColor = Color.Transparent;
            lblTotalPaid.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblTotalPaid.ForeColor = Color.Green;
            lblTotalPaid.IsTitle = true;
            lblTotalPaid.Location = new Point(0, 1);
            lblTotalPaid.Margin = new Padding(0);
            lblTotalPaid.Name = "lblTotalPaid";
            lblTotalPaid.RightToLeft = RightToLeft.Yes;
            lblTotalPaid.Size = new Size(280, 54);
            lblTotalPaid.TabIndex = 2;
            lblTotalPaid.Text = "22";
            lblTotalPaid.TextAlign = ContentAlignment.MiddleRight;
            lblTotalPaid.Click += lblTotalPaid_Click;
            // 
            // pnlNetProfit
            // 
            pnlNetProfit.BackColor = Color.White;
            pnlNetProfit.BorderColor = Color.LightGray;
            pnlNetProfit.BorderRadius = 15;
            pnlNetProfit.BorderSize = 0;
            pnlNetProfit.Controls.Add(sabraLabel2);
            pnlNetProfit.Controls.Add(lblDebitBalance);
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
            sabraLabel2.Location = new Point(127, 55);
            sabraLabel2.Margin = new Padding(0);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.RightToLeft = RightToLeft.Yes;
            sabraLabel2.Size = new Size(155, 32);
            sabraLabel2.TabIndex = 5;
            sabraLabel2.Text = "مديونيتنا عنده (ج)";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDebitBalance
            // 
            lblDebitBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDebitBalance.BackColor = Color.Transparent;
            lblDebitBalance.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblDebitBalance.ForeColor = Color.Red;
            lblDebitBalance.IsTitle = true;
            lblDebitBalance.Location = new Point(0, 1);
            lblDebitBalance.Margin = new Padding(0);
            lblDebitBalance.Name = "lblDebitBalance";
            lblDebitBalance.RightToLeft = RightToLeft.Yes;
            lblDebitBalance.Size = new Size(277, 50);
            lblDebitBalance.TabIndex = 4;
            lblDebitBalance.Text = "22";
            lblDebitBalance.TextAlign = ContentAlignment.MiddleRight;
            lblDebitBalance.Click += lblDebitBalance_Click;
            // 
            // dgvSupplierStatement
            // 
            dgvSupplierStatement.AllowUserToAddRows = false;
            dgvSupplierStatement.AllowUserToDeleteRows = false;
            dgvSupplierStatement.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvSupplierStatement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvSupplierStatement.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvSupplierStatement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSupplierStatement.BackgroundColor = Color.White;
            dgvSupplierStatement.BorderStyle = BorderStyle.None;
            dgvSupplierStatement.ButtonBackColor = Color.FromArgb(241, 245, 249);
            dgvSupplierStatement.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvSupplierStatement.ButtonHoverColor = Color.FromArgb(226, 232, 240);
            dgvSupplierStatement.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvSupplierStatement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSupplierStatement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSupplierStatement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSupplierStatement.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSupplierStatement.EditableCellBackColor = Color.White;
            dgvSupplierStatement.EditableCellBorderColor = Color.FromArgb(203, 213, 225);
            dgvSupplierStatement.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvSupplierStatement.EnableHeadersVisualStyles = false;
            dgvSupplierStatement.Font = new Font("Cairo", 10F);
            dgvSupplierStatement.GridColor = Color.FromArgb(226, 232, 240);
            dgvSupplierStatement.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvSupplierStatement.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvSupplierStatement.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvSupplierStatement.HeaderHeight = 4;
            dgvSupplierStatement.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvSupplierStatement.Location = new Point(17, 320);
            dgvSupplierStatement.MultiSelect = false;
            dgvSupplierStatement.Name = "dgvSupplierStatement";
            dgvSupplierStatement.RightToLeft = RightToLeft.Yes;
            dgvSupplierStatement.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvSupplierStatement.RowBackColor = Color.White;
            dgvSupplierStatement.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvSupplierStatement.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvSupplierStatement.RowHeadersVisible = false;
            dgvSupplierStatement.RowHeadersWidth = 51;
            dgvSupplierStatement.RowTemplate.Height = 42;
            dgvSupplierStatement.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvSupplierStatement.SelectionForeColor = Color.White;
            dgvSupplierStatement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSupplierStatement.Size = new Size(1472, 522);
            dgvSupplierStatement.TabIndex = 6;
            dgvSupplierStatement.CellContentClick += dgvSupplierStatement_CellContentClick;
            // 
            // sbtnSearch
            // 
            sbtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sbtnSearch.BackColor = Color.RoyalBlue;
            sbtnSearch.BorderColor = Color.DodgerBlue;
            sbtnSearch.BorderRadius = 10;
            sbtnSearch.BorderSize = 0;
            sbtnSearch.FlatAppearance.BorderSize = 0;
            sbtnSearch.FlatStyle = FlatStyle.Flat;
            sbtnSearch.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnSearch.ForeColor = Color.White;
            sbtnSearch.HoverColor = Color.CornflowerBlue;
            sbtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            sbtnSearch.IconColor = Color.Beige;
            sbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnSearch.IconSize = 30;
            sbtnSearch.ImageAlign = ContentAlignment.MiddleRight;
            sbtnSearch.Location = new Point(564, 24);
            sbtnSearch.Name = "sbtnSearch";
            sbtnSearch.NormalColor = Color.RoyalBlue;
            sbtnSearch.Padding = new Padding(10, 0, 10, 0);
            sbtnSearch.Size = new Size(65, 61);
            sbtnSearch.TabIndex = 22;
            sbtnSearch.TextAlign = ContentAlignment.MiddleLeft;
            sbtnSearch.UseVisualStyleBackColor = false;
            // 
            // stbxSearchForCustomer
            // 
            stbxSearchForCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            stbxSearchForCustomer.AutoSize = true;
            stbxSearchForCustomer.BackColor = Color.White;
            stbxSearchForCustomer.Font = new Font("Cairo", 15F);
            stbxSearchForCustomer.ForeColor = Color.FromArgb(64, 64, 64);
            stbxSearchForCustomer.Location = new Point(635, 23);
            stbxSearchForCustomer.Name = "stbxSearchForCustomer";
            stbxSearchForCustomer.Padding = new Padding(10, 7, 25, 7);
            stbxSearchForCustomer.PlaceholderText = "بحث عن مورد ";
            stbxSearchForCustomer.Required = true;
            stbxSearchForCustomer.RightToLeft = RightToLeft.Yes;
            stbxSearchForCustomer.SelectedText = "";
            stbxSearchForCustomer.SelectionLength = 0;
            stbxSearchForCustomer.SelectionStart = 0;
            stbxSearchForCustomer.Size = new Size(444, 62);
            stbxSearchForCustomer.TabIndex = 21;
            stbxSearchForCustomer.Texts = "بحث عن مرود ...";
            // 
            // ucSupplierStatement
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvSupplierStatement);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(sabraPanel1);
            Name = "ucSupplierStatement";
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
            ((System.ComponentModel.ISupportInitialize)dgvSupplierStatement).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraButton sbtnPurchaseOrder;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblSupplierName;
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
        private SabraLabel lblDebitBalance;
        private SabraDataGridView dgvSupplierStatement;
        private SabraButton sbtnSearch;
        private SabraTextBox stbxSearchForCustomer;
    }
}
