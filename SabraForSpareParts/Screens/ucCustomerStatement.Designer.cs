namespace SabraForSpareParts.Screens
{
    partial class ucCustomerStatement
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            sabraPanel1 = new SabraPanel();
            sbtnAddNewInvoice = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            slblTitleOfTopPanel = new SabraLabel();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            lblCustomerName = new SabraLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlUnpaidInvoices = new SabraPanel();
            lblUnpaidInvoicesDisc = new SabraLabel();
            lblTotalPurchases = new SabraLabel();
            sabraPanel2 = new SabraPanel();
            sabraLabel1 = new SabraLabel();
            lblNumberOfInvoices = new SabraLabel();
            pnlLowStock = new SabraPanel();
            lblLowStockPartsDisc = new SabraLabel();
            lblTotalPaid = new SabraLabel();
            pnlNetProfit = new SabraPanel();
            sabraLabel2 = new SabraLabel();
            lblDebitBalance = new SabraLabel();
            dgvCustomerStatement = new SabraDataGridView();
            stbxSearchForCustomer = new SabraTextBox();
            sbtnSearch = new SabraButton();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            pnlUnpaidInvoices.SuspendLayout();
            sabraPanel2.SuspendLayout();
            pnlLowStock.SuspendLayout();
            pnlNetProfit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerStatement).BeginInit();
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
            sabraPanel1.Controls.Add(sbtnAddNewInvoice);
            sabraPanel1.Controls.Add(sbtnPrint);
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(lblCustomerName);
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
            // sbtnAddNewInvoice
            // 
            sbtnAddNewInvoice.BackColor = Color.RoyalBlue;
            sbtnAddNewInvoice.BorderColor = Color.DodgerBlue;
            sbtnAddNewInvoice.BorderRadius = 20;
            sbtnAddNewInvoice.BorderSize = 0;
            sbtnAddNewInvoice.FlatAppearance.BorderSize = 0;
            sbtnAddNewInvoice.FlatStyle = FlatStyle.Flat;
            sbtnAddNewInvoice.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnAddNewInvoice.ForeColor = Color.White;
            sbtnAddNewInvoice.HoverColor = Color.CornflowerBlue;
            sbtnAddNewInvoice.IconChar = FontAwesome.Sharp.IconChar.Add;
            sbtnAddNewInvoice.IconColor = Color.White;
            sbtnAddNewInvoice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnAddNewInvoice.IconSize = 30;
            sbtnAddNewInvoice.ImageAlign = ContentAlignment.MiddleRight;
            sbtnAddNewInvoice.Location = new Point(47, 20);
            sbtnAddNewInvoice.Name = "sbtnAddNewInvoice";
            sbtnAddNewInvoice.NormalColor = Color.RoyalBlue;
            sbtnAddNewInvoice.Size = new Size(151, 62);
            sbtnAddNewInvoice.TabIndex = 19;
            sbtnAddNewInvoice.Text = "فاتورة جديدة";
            sbtnAddNewInvoice.TextAlign = ContentAlignment.MiddleLeft;
            sbtnAddNewInvoice.UseVisualStyleBackColor = false;
            sbtnAddNewInvoice.Click += sbtnAddNewInvoice_Click;
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
            slblTitleOfTopPanel.Location = new Point(1130, 5);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(271, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "كشف حساب عميل";
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
            // lblCustomerName
            // 
            lblCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCustomerName.BackColor = Color.Transparent;
            lblCustomerName.Font = new Font("Cairo", 12F);
            lblCustomerName.ForeColor = SystemColors.WindowFrame;
            lblCustomerName.Location = new Point(1168, 48);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.RightToLeft = RightToLeft.Yes;
            lblCustomerName.Size = new Size(233, 37);
            lblCustomerName.TabIndex = 16;
            lblCustomerName.Text = "ورشة النيل";
            lblCustomerName.TextAlign = ContentAlignment.MiddleRight;
            lblCustomerName.Click += lblCustomerName_Click;
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
            sabraPanel2.Controls.Add(lblNumberOfInvoices);
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
            sabraLabel1.Size = new Size(109, 32);
            sabraLabel1.TabIndex = 2;
            sabraLabel1.Text = "عدد الفواتير";
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNumberOfInvoices
            // 
            lblNumberOfInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNumberOfInvoices.BackColor = Color.Transparent;
            lblNumberOfInvoices.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblNumberOfInvoices.ForeColor = Color.Black;
            lblNumberOfInvoices.IsTitle = true;
            lblNumberOfInvoices.Location = new Point(0, 1);
            lblNumberOfInvoices.Margin = new Padding(0);
            lblNumberOfInvoices.Name = "lblNumberOfInvoices";
            lblNumberOfInvoices.RightToLeft = RightToLeft.Yes;
            lblNumberOfInvoices.Size = new Size(278, 54);
            lblNumberOfInvoices.TabIndex = 2;
            lblNumberOfInvoices.Text = "22";
            lblNumberOfInvoices.TextAlign = ContentAlignment.MiddleRight;
            lblNumberOfInvoices.Click += lblNumberOfInvoices_Click;
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
            sabraLabel2.Size = new Size(150, 32);
            sabraLabel2.TabIndex = 5;
            sabraLabel2.Text = "الرصيد المدين (ج)";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDebitBalance
            // 
            lblDebitBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDebitBalance.BackColor = Color.Transparent;
            lblDebitBalance.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblDebitBalance.ForeColor = Color.DimGray;
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
            // dgvCustomerStatement
            // 
            dgvCustomerStatement.AllowUserToAddRows = false;
            dgvCustomerStatement.AllowUserToDeleteRows = false;
            dgvCustomerStatement.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dgvCustomerStatement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvCustomerStatement.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomerStatement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerStatement.BackgroundColor = Color.White;
            dgvCustomerStatement.BorderStyle = BorderStyle.None;
            dgvCustomerStatement.ButtonBackColor = Color.FromArgb(241, 245, 249);
            dgvCustomerStatement.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvCustomerStatement.ButtonHoverColor = Color.FromArgb(226, 232, 240);
            dgvCustomerStatement.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvCustomerStatement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle6.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle6.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvCustomerStatement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvCustomerStatement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle7.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvCustomerStatement.DefaultCellStyle = dataGridViewCellStyle7;
            dgvCustomerStatement.EditableCellBackColor = Color.White;
            dgvCustomerStatement.EditableCellBorderColor = Color.FromArgb(203, 213, 225);
            dgvCustomerStatement.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvCustomerStatement.EnableHeadersVisualStyles = false;
            dgvCustomerStatement.Font = new Font("Cairo", 10F);
            dgvCustomerStatement.GridColor = Color.FromArgb(226, 232, 240);
            dgvCustomerStatement.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvCustomerStatement.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvCustomerStatement.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvCustomerStatement.HeaderHeight = 4;
            dgvCustomerStatement.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvCustomerStatement.Location = new Point(17, 320);
            dgvCustomerStatement.MultiSelect = false;
            dgvCustomerStatement.Name = "dgvCustomerStatement";
            dgvCustomerStatement.RightToLeft = RightToLeft.Yes;
            dgvCustomerStatement.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvCustomerStatement.RowBackColor = Color.White;
            dgvCustomerStatement.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvCustomerStatement.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvCustomerStatement.RowHeadersVisible = false;
            dgvCustomerStatement.RowHeadersWidth = 51;
            dgvCustomerStatement.RowTemplate.Height = 42;
            dgvCustomerStatement.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvCustomerStatement.SelectionForeColor = Color.White;
            dgvCustomerStatement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerStatement.Size = new Size(1472, 649);
            dgvCustomerStatement.TabIndex = 6;
            dgvCustomerStatement.CellContentClick += dgvCustomerStatement_CellContentClick;
            // 
            // stbxSearchForCustomer
            // 
            stbxSearchForCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            stbxSearchForCustomer.AutoSize = true;
            stbxSearchForCustomer.BackColor = Color.White;
            stbxSearchForCustomer.Font = new Font("Cairo", 15F);
            stbxSearchForCustomer.ForeColor = Color.FromArgb(64, 64, 64);
            stbxSearchForCustomer.Location = new Point(624, 23);
            stbxSearchForCustomer.Name = "stbxSearchForCustomer";
            stbxSearchForCustomer.Padding = new Padding(10, 7, 25, 7);
            stbxSearchForCustomer.PlaceholderText = "بحث عن المرود ";
            stbxSearchForCustomer.Required = true;
            stbxSearchForCustomer.RightToLeft = RightToLeft.Yes;
            stbxSearchForCustomer.SelectedText = "";
            stbxSearchForCustomer.SelectionLength = 0;
            stbxSearchForCustomer.SelectionStart = 0;
            stbxSearchForCustomer.Size = new Size(444, 62);
            stbxSearchForCustomer.TabIndex = 7;
            stbxSearchForCustomer.Texts = "بحث عن عميل..";
            stbxSearchForCustomer.Load += stbxSearchForSupplier_Load;
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
            sbtnSearch.Location = new Point(553, 24);
            sbtnSearch.Name = "sbtnSearch";
            sbtnSearch.NormalColor = Color.RoyalBlue;
            sbtnSearch.Padding = new Padding(10, 0, 10, 0);
            sbtnSearch.Size = new Size(65, 61);
            sbtnSearch.TabIndex = 20;
            sbtnSearch.TextAlign = ContentAlignment.MiddleLeft;
            sbtnSearch.UseVisualStyleBackColor = false;
            sbtnSearch.Click += sbtnSearch_Click;
            // 
            // ucCustomerStatement
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvCustomerStatement);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(sabraPanel1);
            Name = "ucCustomerStatement";
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
            ((System.ComponentModel.ISupportInitialize)dgvCustomerStatement).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraButton sbtnAddNewInvoice;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblCustomerName;
        private TableLayoutPanel tableLayoutPanel1;
        private SabraPanel pnlUnpaidInvoices;
        private SabraLabel lblUnpaidInvoicesDisc;
        private SabraLabel lblTotalPurchases;
        private SabraPanel sabraPanel2;
        private SabraLabel sabraLabel1;
        private SabraLabel lblNumberOfInvoices;
        private SabraPanel pnlLowStock;
        private SabraLabel lblLowStockPartsDisc;
        private SabraLabel lblTotalPaid;
        private SabraPanel pnlNetProfit;
        private SabraLabel sabraLabel2;
        private SabraLabel lblDebitBalance;
        private SabraDataGridView dgvCustomerStatement;
        private SabraButton sbtnSearch;
        private SabraTextBox stbxSearchForCustomer;
    }
}
