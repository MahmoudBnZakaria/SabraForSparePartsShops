namespace SabraForSpareParts.Screens
{
    partial class ucExpenses
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
            sbtnAddNewExpense = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            lblNameOfTheMonthAndYear = new SabraLabel();
            spnlDataGridViewOPtions = new SabraPanel();
            cmbClassification = new SabraComboBox();
            sabraLabel4 = new SabraLabel();
            sabraLabel3 = new SabraLabel();
            dtpTo = new SabraDateTimePicker();
            dtpFrom = new SabraDateTimePicker();
            btnSearch = new SabraButton();
            smbxPeriod = new SabraComboBox();
            pnlUnpaidInvoices = new SabraPanel();
            iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            lblUnpaidInvoicesDisc = new SabraLabel();
            lblTotalExpenses = new SabraLabel();
            pnlLowStock = new SabraPanel();
            lblLowStockPartsDisc = new SabraLabel();
            lblReleaseFees = new SabraLabel();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            pnlNetProfit = new SabraPanel();
            sabraLabel2 = new SabraLabel();
            lblElectricity = new SabraLabel();
            iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            sabraPanel2 = new SabraPanel();
            sabraLabel1 = new SabraLabel();
            lblOtherExpenses = new SabraLabel();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvExpenses = new SabraDataGridView();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            spnlDataGridViewOPtions.SuspendLayout();
            pnlUnpaidInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).BeginInit();
            pnlLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            pnlNetProfit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
            sabraPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(sbtnAddNewExpense);
            sabraPanel1.Controls.Add(sbtnPrint);
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(lblNameOfTheMonthAndYear);
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
            sabraPanel1.Size = new Size(1608, 111);
            sabraPanel1.TabIndex = 3;
            sabraPanel1.Paint += sabraPanel1_Paint;
            // 
            // sbtnAddNewExpense
            // 
            sbtnAddNewExpense.BackColor = Color.RoyalBlue;
            sbtnAddNewExpense.BorderColor = Color.DodgerBlue;
            sbtnAddNewExpense.BorderRadius = 20;
            sbtnAddNewExpense.BorderSize = 0;
            sbtnAddNewExpense.FlatAppearance.BorderSize = 0;
            sbtnAddNewExpense.FlatStyle = FlatStyle.Flat;
            sbtnAddNewExpense.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnAddNewExpense.ForeColor = Color.White;
            sbtnAddNewExpense.HoverColor = Color.CornflowerBlue;
            sbtnAddNewExpense.IconChar = FontAwesome.Sharp.IconChar.Add;
            sbtnAddNewExpense.IconColor = Color.White;
            sbtnAddNewExpense.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnAddNewExpense.IconSize = 30;
            sbtnAddNewExpense.ImageAlign = ContentAlignment.MiddleRight;
            sbtnAddNewExpense.Location = new Point(47, 20);
            sbtnAddNewExpense.Name = "sbtnAddNewExpense";
            sbtnAddNewExpense.NormalColor = Color.RoyalBlue;
            sbtnAddNewExpense.Size = new Size(165, 70);
            sbtnAddNewExpense.TabIndex = 19;
            sbtnAddNewExpense.Text = "إضافة مصروف";
            sbtnAddNewExpense.TextAlign = ContentAlignment.MiddleLeft;
            sbtnAddNewExpense.UseVisualStyleBackColor = false;
            sbtnAddNewExpense.Click += sbtnAddNewExpense_Click;
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
            // icnDecreasedParts
            // 
            icnDecreasedParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icnDecreasedParts.BackColor = Color.Transparent;
            icnDecreasedParts.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnDecreasedParts.ForeColor = Color.RoyalBlue;
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            icnDecreasedParts.IconColor = Color.RoyalBlue;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1523, 23);
            icnDecreasedParts.Name = "icnDecreasedParts";
            icnDecreasedParts.Size = new Size(72, 65);
            icnDecreasedParts.SizeMode = PictureBoxSizeMode.Zoom;
            icnDecreasedParts.TabIndex = 14;
            icnDecreasedParts.TabStop = false;
            // 
            // slblTitleOfTopPanel
            // 
            slblTitleOfTopPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblTitleOfTopPanel.AutoSize = true;
            slblTitleOfTopPanel.BackColor = Color.Transparent;
            slblTitleOfTopPanel.Font = new Font("Cairo", 18F, FontStyle.Bold);
            slblTitleOfTopPanel.ForeColor = Color.FromArgb(40, 40, 40);
            slblTitleOfTopPanel.Location = new Point(1325, 8);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(171, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "المصروفات";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNameOfTheMonthAndYear
            // 
            lblNameOfTheMonthAndYear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNameOfTheMonthAndYear.BackColor = Color.Transparent;
            lblNameOfTheMonthAndYear.Font = new Font("Cairo", 12F);
            lblNameOfTheMonthAndYear.ForeColor = SystemColors.WindowFrame;
            lblNameOfTheMonthAndYear.Location = new Point(1227, 64);
            lblNameOfTheMonthAndYear.Name = "lblNameOfTheMonthAndYear";
            lblNameOfTheMonthAndYear.RightToLeft = RightToLeft.Yes;
            lblNameOfTheMonthAndYear.Size = new Size(269, 37);
            lblNameOfTheMonthAndYear.TabIndex = 16;
            lblNameOfTheMonthAndYear.Text = "يناير 2025";
            lblNameOfTheMonthAndYear.TextAlign = ContentAlignment.MiddleRight;
            lblNameOfTheMonthAndYear.Click += lblNameOfTheMonthAndYear_Click;
            // 
            // spnlDataGridViewOPtions
            // 
            spnlDataGridViewOPtions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            spnlDataGridViewOPtions.BackColor = Color.White;
            spnlDataGridViewOPtions.BorderColor = Color.LightGray;
            spnlDataGridViewOPtions.BorderRadius = 15;
            spnlDataGridViewOPtions.BorderSize = 0;
            spnlDataGridViewOPtions.Controls.Add(cmbClassification);
            spnlDataGridViewOPtions.Controls.Add(sabraLabel4);
            spnlDataGridViewOPtions.Controls.Add(sabraLabel3);
            spnlDataGridViewOPtions.Controls.Add(dtpTo);
            spnlDataGridViewOPtions.Controls.Add(dtpFrom);
            spnlDataGridViewOPtions.Controls.Add(btnSearch);
            spnlDataGridViewOPtions.Controls.Add(smbxPeriod);
            spnlDataGridViewOPtions.EnableHover = true;
            spnlDataGridViewOPtions.ForeColor = Color.Black;
            spnlDataGridViewOPtions.GradientAngle = 90F;
            spnlDataGridViewOPtions.GradientBottomColor = Color.White;
            spnlDataGridViewOPtions.GradientTopColor = Color.White;
            spnlDataGridViewOPtions.HoverBackColor = Color.FromArgb(245, 248, 255);
            spnlDataGridViewOPtions.HoverBorderColor = Color.FromArgb(37, 99, 235);
            spnlDataGridViewOPtions.HoverBorderSize = 2;
            spnlDataGridViewOPtions.Location = new Point(10, 271);
            spnlDataGridViewOPtions.Margin = new Padding(20);
            spnlDataGridViewOPtions.Name = "spnlDataGridViewOPtions";
            spnlDataGridViewOPtions.Size = new Size(1608, 130);
            spnlDataGridViewOPtions.TabIndex = 14;
            // 
            // cmbClassification
            // 
            cmbClassification.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cmbClassification.BackColor = Color.WhiteSmoke;
            cmbClassification.DrawMode = DrawMode.OwnerDrawFixed;
            cmbClassification.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassification.FlatStyle = FlatStyle.Flat;
            cmbClassification.Font = new Font("Cairo", 10F);
            cmbClassification.ForeColor = Color.FromArgb(64, 64, 64);
            cmbClassification.FormattingEnabled = true;
            cmbClassification.ItemHeight = 30;
            cmbClassification.Items.AddRange(new object[] { "كل التصنيفات", "الكهرباء", "الماء", "الإيجار", "صيانة" });
            cmbClassification.Location = new Point(379, 46);
            cmbClassification.Name = "cmbClassification";
            cmbClassification.RightToLeft = RightToLeft.Yes;
            cmbClassification.Size = new Size(202, 36);
            cmbClassification.TabIndex = 22;
            cmbClassification.SelectedIndexChanged += cmbClassification_SelectedIndexChanged;
            // 
            // sabraLabel4
            // 
            sabraLabel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel4.AutoSize = true;
            sabraLabel4.BackColor = Color.Transparent;
            sabraLabel4.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel4.ForeColor = Color.DimGray;
            sabraLabel4.Location = new Point(1212, 49);
            sabraLabel4.Margin = new Padding(0);
            sabraLabel4.Name = "sabraLabel4";
            sabraLabel4.RightToLeft = RightToLeft.Yes;
            sabraLabel4.Size = new Size(42, 32);
            sabraLabel4.TabIndex = 21;
            sabraLabel4.Text = "من ";
            sabraLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel3
            // 
            sabraLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel3.AutoSize = true;
            sabraLabel3.BackColor = Color.Transparent;
            sabraLabel3.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel3.ForeColor = Color.DimGray;
            sabraLabel3.Location = new Point(874, 49);
            sabraLabel3.Margin = new Padding(0);
            sabraLabel3.Name = "sabraLabel3";
            sabraLabel3.RightToLeft = RightToLeft.Yes;
            sabraLabel3.Size = new Size(40, 32);
            sabraLabel3.TabIndex = 20;
            sabraLabel3.Text = "إلى";
            sabraLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTo.BackColor = Color.Transparent;
            dtpTo.BorderColor = Color.FromArgb(220, 225, 230);
            dtpTo.BorderRadius = 12;
            dtpTo.BorderSize = 1;
            dtpTo.Checked = true;
            dtpTo.DateFormat = "dddd، dd MMMM yyyy";
            dtpTo.FocusedBorderColor = Color.FromArgb(0, 120, 212);
            dtpTo.Font = new Font("Cairo", 10F);
            dtpTo.Location = new Point(596, 45);
            dtpTo.MinimumSize = new Size(180, 45);
            dtpTo.Name = "dtpTo";
            dtpTo.RightToLeft = RightToLeft.Yes;
            dtpTo.ShowCheckBox = false;
            dtpTo.Size = new Size(275, 45);
            dtpTo.SkinColor = Color.White;
            dtpTo.TabIndex = 19;
            dtpTo.TextColor = Color.FromArgb(45, 45, 45);
            dtpTo.Value = new DateTime(2026, 8, 30, 0, 0, 0, 0);
            dtpTo.Load += dtpTo_Load;
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFrom.BackColor = Color.Transparent;
            dtpFrom.BorderColor = Color.FromArgb(220, 225, 230);
            dtpFrom.BorderRadius = 12;
            dtpFrom.BorderSize = 1;
            dtpFrom.Checked = true;
            dtpFrom.DateFormat = "dddd، dd MMMM yyyy";
            dtpFrom.FocusedBorderColor = Color.FromArgb(0, 120, 212);
            dtpFrom.Font = new Font("Cairo", 10F);
            dtpFrom.Location = new Point(934, 45);
            dtpFrom.MinimumSize = new Size(180, 45);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.RightToLeft = RightToLeft.Yes;
            dtpFrom.ShowCheckBox = false;
            dtpFrom.Size = new Size(275, 45);
            dtpFrom.SkinColor = Color.White;
            dtpFrom.TabIndex = 15;
            dtpFrom.TextColor = Color.FromArgb(45, 45, 45);
            dtpFrom.Value = new DateTime(2026, 8, 30, 0, 0, 0, 0);
            dtpFrom.Load += dtpFrom_Load;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSearch.BackColor = Color.RoyalBlue;
            btnSearch.BorderColor = Color.DodgerBlue;
            btnSearch.BorderRadius = 10;
            btnSearch.BorderSize = 0;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.HoverColor = Color.CornflowerBlue;
            btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnSearch.IconColor = Color.White;
            btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSearch.IconSize = 30;
            btnSearch.ImageAlign = ContentAlignment.MiddleRight;
            btnSearch.Location = new Point(13, 31);
            btnSearch.Name = "btnSearch";
            btnSearch.NormalColor = Color.RoyalBlue;
            btnSearch.Size = new Size(117, 70);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "بحث";
            btnSearch.TextAlign = ContentAlignment.MiddleLeft;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // smbxPeriod
            // 
            smbxPeriod.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            smbxPeriod.BackColor = Color.WhiteSmoke;
            smbxPeriod.DrawMode = DrawMode.OwnerDrawFixed;
            smbxPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            smbxPeriod.FlatStyle = FlatStyle.Flat;
            smbxPeriod.Font = new Font("Cairo", 10F);
            smbxPeriod.ForeColor = Color.FromArgb(64, 64, 64);
            smbxPeriod.FormattingEnabled = true;
            smbxPeriod.ItemHeight = 30;
            smbxPeriod.Items.AddRange(new object[] { "هذا الشهر", "الشهر الماضي", "هذا العام" });
            smbxPeriod.Location = new Point(1314, 46);
            smbxPeriod.Name = "smbxPeriod";
            smbxPeriod.RightToLeft = RightToLeft.Yes;
            smbxPeriod.Size = new Size(278, 36);
            smbxPeriod.TabIndex = 17;
            smbxPeriod.SelectedIndexChanged += smbxPeriod_SelectedIndexChanged;
            // 
            // pnlUnpaidInvoices
            // 
            pnlUnpaidInvoices.BackColor = Color.White;
            pnlUnpaidInvoices.BorderColor = Color.LightGray;
            pnlUnpaidInvoices.BorderRadius = 15;
            pnlUnpaidInvoices.BorderSize = 0;
            pnlUnpaidInvoices.Controls.Add(iconPictureBox4);
            pnlUnpaidInvoices.Controls.Add(lblUnpaidInvoicesDisc);
            pnlUnpaidInvoices.Controls.Add(lblTotalExpenses);
            pnlUnpaidInvoices.EnableHover = true;
            pnlUnpaidInvoices.ForeColor = Color.Black;
            pnlUnpaidInvoices.GradientAngle = 90F;
            pnlUnpaidInvoices.GradientBottomColor = Color.White;
            pnlUnpaidInvoices.GradientTopColor = Color.White;
            pnlUnpaidInvoices.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlUnpaidInvoices.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlUnpaidInvoices.HoverBorderSize = 2;
            pnlUnpaidInvoices.Location = new Point(1280, 16);
            pnlUnpaidInvoices.Margin = new Padding(16);
            pnlUnpaidInvoices.Name = "pnlUnpaidInvoices";
            pnlUnpaidInvoices.Size = new Size(312, 88);
            pnlUnpaidInvoices.TabIndex = 18;
            // 
            // iconPictureBox4
            // 
            iconPictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPictureBox4.BackColor = Color.Transparent;
            iconPictureBox4.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            iconPictureBox4.ForeColor = Color.Brown;
            iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckDollar;
            iconPictureBox4.IconColor = Color.Brown;
            iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox4.IconSize = 65;
            iconPictureBox4.Location = new Point(227, 12);
            iconPictureBox4.Name = "iconPictureBox4";
            iconPictureBox4.Size = new Size(72, 65);
            iconPictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox4.TabIndex = 15;
            iconPictureBox4.TabStop = false;
            // 
            // lblUnpaidInvoicesDisc
            // 
            lblUnpaidInvoicesDisc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUnpaidInvoicesDisc.AutoSize = true;
            lblUnpaidInvoicesDisc.BackColor = Color.Transparent;
            lblUnpaidInvoicesDisc.Font = new Font("Cairo", 10F);
            lblUnpaidInvoicesDisc.ForeColor = Color.DimGray;
            lblUnpaidInvoicesDisc.Location = new Point(65, 46);
            lblUnpaidInvoicesDisc.Margin = new Padding(0);
            lblUnpaidInvoicesDisc.Name = "lblUnpaidInvoicesDisc";
            lblUnpaidInvoicesDisc.RightToLeft = RightToLeft.Yes;
            lblUnpaidInvoicesDisc.Size = new Size(150, 32);
            lblUnpaidInvoicesDisc.TabIndex = 2;
            lblUnpaidInvoicesDisc.Text = "مصروفات الشهر (ج)";
            lblUnpaidInvoicesDisc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalExpenses
            // 
            lblTotalExpenses.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalExpenses.BackColor = Color.Transparent;
            lblTotalExpenses.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblTotalExpenses.ForeColor = Color.Brown;
            lblTotalExpenses.IsTitle = true;
            lblTotalExpenses.Location = new Point(45, 13);
            lblTotalExpenses.Margin = new Padding(0);
            lblTotalExpenses.Name = "lblTotalExpenses";
            lblTotalExpenses.RightToLeft = RightToLeft.Yes;
            lblTotalExpenses.Size = new Size(168, 37);
            lblTotalExpenses.TabIndex = 2;
            lblTotalExpenses.Text = "1";
            lblTotalExpenses.TextAlign = ContentAlignment.MiddleRight;
            lblTotalExpenses.Click += lblTotalExpenses_Click;
            // 
            // pnlLowStock
            // 
            pnlLowStock.BackColor = Color.White;
            pnlLowStock.BorderColor = Color.LightGray;
            pnlLowStock.BorderRadius = 15;
            pnlLowStock.BorderSize = 0;
            pnlLowStock.Controls.Add(lblLowStockPartsDisc);
            pnlLowStock.Controls.Add(lblReleaseFees);
            pnlLowStock.Controls.Add(iconPictureBox1);
            pnlLowStock.EnableHover = true;
            pnlLowStock.ForeColor = Color.Black;
            pnlLowStock.GradientAngle = 90F;
            pnlLowStock.GradientBottomColor = Color.White;
            pnlLowStock.GradientTopColor = Color.White;
            pnlLowStock.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlLowStock.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlLowStock.HoverBorderSize = 2;
            pnlLowStock.Location = new Point(884, 15);
            pnlLowStock.Margin = new Padding(15);
            pnlLowStock.Name = "pnlLowStock";
            pnlLowStock.Size = new Size(312, 90);
            pnlLowStock.TabIndex = 17;
            // 
            // lblLowStockPartsDisc
            // 
            lblLowStockPartsDisc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLowStockPartsDisc.AutoSize = true;
            lblLowStockPartsDisc.BackColor = Color.Transparent;
            lblLowStockPartsDisc.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLowStockPartsDisc.ForeColor = Color.DimGray;
            lblLowStockPartsDisc.Location = new Point(173, 46);
            lblLowStockPartsDisc.Margin = new Padding(0);
            lblLowStockPartsDisc.Name = "lblLowStockPartsDisc";
            lblLowStockPartsDisc.RightToLeft = RightToLeft.Yes;
            lblLowStockPartsDisc.Size = new Size(50, 32);
            lblLowStockPartsDisc.TabIndex = 2;
            lblLowStockPartsDisc.Text = "إيجار";
            lblLowStockPartsDisc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblReleaseFees
            // 
            lblReleaseFees.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblReleaseFees.BackColor = Color.Transparent;
            lblReleaseFees.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblReleaseFees.ForeColor = SystemColors.GrayText;
            lblReleaseFees.IsTitle = true;
            lblReleaseFees.Location = new Point(59, 14);
            lblReleaseFees.Margin = new Padding(0);
            lblReleaseFees.Name = "lblReleaseFees";
            lblReleaseFees.RightToLeft = RightToLeft.Yes;
            lblReleaseFees.Size = new Size(164, 37);
            lblReleaseFees.TabIndex = 2;
            lblReleaseFees.Text = "22";
            lblReleaseFees.TextAlign = ContentAlignment.MiddleRight;
            lblReleaseFees.Click += lblReleaseFees_Click;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPictureBox1.BackColor = Color.Transparent;
            iconPictureBox1.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            iconPictureBox1.ForeColor = SystemColors.GrayText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MoneyBills;
            iconPictureBox1.IconColor = SystemColors.GrayText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 60;
            iconPictureBox1.Location = new Point(237, 7);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(60, 75);
            iconPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox1.TabIndex = 0;
            iconPictureBox1.TabStop = false;
            // 
            // pnlNetProfit
            // 
            pnlNetProfit.BackColor = Color.White;
            pnlNetProfit.BorderColor = Color.LightGray;
            pnlNetProfit.BorderRadius = 15;
            pnlNetProfit.BorderSize = 0;
            pnlNetProfit.Controls.Add(sabraLabel2);
            pnlNetProfit.Controls.Add(lblElectricity);
            pnlNetProfit.Controls.Add(iconPictureBox3);
            pnlNetProfit.EnableHover = true;
            pnlNetProfit.ForeColor = Color.Black;
            pnlNetProfit.GradientAngle = 90F;
            pnlNetProfit.GradientBottomColor = Color.White;
            pnlNetProfit.GradientTopColor = Color.White;
            pnlNetProfit.HoverBackColor = Color.FromArgb(245, 248, 255);
            pnlNetProfit.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlNetProfit.HoverBorderSize = 2;
            pnlNetProfit.Location = new Point(487, 15);
            pnlNetProfit.Margin = new Padding(15);
            pnlNetProfit.Name = "pnlNetProfit";
            pnlNetProfit.Size = new Size(312, 90);
            pnlNetProfit.TabIndex = 16;
            // 
            // sabraLabel2
            // 
            sabraLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel2.AutoSize = true;
            sabraLabel2.BackColor = Color.Transparent;
            sabraLabel2.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel2.ForeColor = Color.DimGray;
            sabraLabel2.Location = new Point(153, 46);
            sabraLabel2.Margin = new Padding(0);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.RightToLeft = RightToLeft.Yes;
            sabraLabel2.Size = new Size(67, 32);
            sabraLabel2.TabIndex = 5;
            sabraLabel2.Text = "كهرباء";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblElectricity
            // 
            lblElectricity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblElectricity.BackColor = Color.Transparent;
            lblElectricity.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblElectricity.ForeColor = Color.DimGray;
            lblElectricity.IsTitle = true;
            lblElectricity.Location = new Point(63, 14);
            lblElectricity.Margin = new Padding(0);
            lblElectricity.Name = "lblElectricity";
            lblElectricity.RightToLeft = RightToLeft.Yes;
            lblElectricity.Size = new Size(157, 37);
            lblElectricity.TabIndex = 4;
            lblElectricity.Text = "22";
            lblElectricity.TextAlign = ContentAlignment.MiddleRight;
            lblElectricity.Click += lblElectricity_Click;
            // 
            // iconPictureBox3
            // 
            iconPictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPictureBox3.BackColor = Color.Transparent;
            iconPictureBox3.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            iconPictureBox3.ForeColor = Color.SlateGray;
            iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.MoneyBill1;
            iconPictureBox3.IconColor = Color.SlateGray;
            iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox3.IconSize = 60;
            iconPictureBox3.Location = new Point(240, 7);
            iconPictureBox3.Name = "iconPictureBox3";
            iconPictureBox3.Size = new Size(60, 75);
            iconPictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox3.TabIndex = 3;
            iconPictureBox3.TabStop = false;
            // 
            // sabraPanel2
            // 
            sabraPanel2.BackColor = Color.White;
            sabraPanel2.BorderColor = Color.LightGray;
            sabraPanel2.BorderRadius = 15;
            sabraPanel2.BorderSize = 0;
            sabraPanel2.Controls.Add(sabraLabel1);
            sabraPanel2.Controls.Add(lblOtherExpenses);
            sabraPanel2.Controls.Add(iconPictureBox2);
            sabraPanel2.EnableHover = true;
            sabraPanel2.ForeColor = Color.Black;
            sabraPanel2.GradientAngle = 90F;
            sabraPanel2.GradientBottomColor = Color.White;
            sabraPanel2.GradientTopColor = Color.White;
            sabraPanel2.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel2.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel2.HoverBorderSize = 2;
            sabraPanel2.Location = new Point(90, 15);
            sabraPanel2.Margin = new Padding(15);
            sabraPanel2.Name = "sabraPanel2";
            sabraPanel2.Size = new Size(312, 90);
            sabraPanel2.TabIndex = 18;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel1.AutoSize = true;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel1.ForeColor = Color.DimGray;
            sabraLabel1.Location = new Point(171, 46);
            sabraLabel1.Margin = new Padding(0);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.RightToLeft = RightToLeft.Yes;
            sabraLabel1.Size = new Size(54, 32);
            sabraLabel1.TabIndex = 2;
            sabraLabel1.Text = "آخرى";
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblOtherExpenses
            // 
            lblOtherExpenses.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOtherExpenses.BackColor = Color.Transparent;
            lblOtherExpenses.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblOtherExpenses.ForeColor = Color.DarkRed;
            lblOtherExpenses.IsTitle = true;
            lblOtherExpenses.Location = new Point(83, 13);
            lblOtherExpenses.Margin = new Padding(0);
            lblOtherExpenses.Name = "lblOtherExpenses";
            lblOtherExpenses.RightToLeft = RightToLeft.Yes;
            lblOtherExpenses.Size = new Size(142, 37);
            lblOtherExpenses.TabIndex = 2;
            lblOtherExpenses.Text = "22";
            lblOtherExpenses.TextAlign = ContentAlignment.MiddleRight;
            lblOtherExpenses.Click += lblOtherExpenses_Click;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPictureBox2.BackColor = Color.Transparent;
            iconPictureBox2.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            iconPictureBox2.ForeColor = Color.Brown;
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.MoneyBillWheat;
            iconPictureBox2.IconColor = Color.Brown;
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 60;
            iconPictureBox2.Location = new Point(240, 7);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(60, 75);
            iconPictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox2.TabIndex = 0;
            iconPictureBox2.TabStop = false;
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
            tableLayoutPanel1.Location = new Point(10, 131);
            tableLayoutPanel1.Margin = new Padding(30);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20, 0, 0, 0);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1608, 128);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvExpenses
            // 
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AllowUserToDeleteRows = false;
            dgvExpenses.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvExpenses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvExpenses.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.BackgroundColor = Color.White;
            dgvExpenses.BorderStyle = BorderStyle.None;
            dgvExpenses.ButtonBackColor = Color.White;
            dgvExpenses.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvExpenses.ButtonHoverColor = Color.FromArgb(238, 242, 255);
            dgvExpenses.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvExpenses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvExpenses.DefaultCellStyle = dataGridViewCellStyle3;
            dgvExpenses.EditableCellBackColor = Color.White;
            dgvExpenses.EditableCellBorderColor = Color.FromArgb(203, 213, 225);
            dgvExpenses.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvExpenses.EnableHeadersVisualStyles = false;
            dgvExpenses.Font = new Font("Cairo", 10F);
            dgvExpenses.GridColor = Color.FromArgb(226, 232, 240);
            dgvExpenses.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvExpenses.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvExpenses.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvExpenses.HeaderHeight = 4;
            dgvExpenses.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvExpenses.Location = new Point(10, 424);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.ReadOnly = true;
            dgvExpenses.RightToLeft = RightToLeft.Yes;
            dgvExpenses.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvExpenses.RowBackColor = Color.White;
            dgvExpenses.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvExpenses.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.RowHeadersWidth = 51;
            dgvExpenses.RowTemplate.Height = 42;
            dgvExpenses.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvExpenses.SelectionForeColor = Color.White;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.Size = new Size(1608, 603);
            dgvExpenses.TabIndex = 15;
            dgvExpenses.CellContentClick += dgvExpenses_CellContentClick;
            // 
            // ucExpenses
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvExpenses);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(spnlDataGridViewOPtions);
            Controls.Add(sabraPanel1);
            Name = "ucExpenses";
            Size = new Size(1628, 1045);
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            spnlDataGridViewOPtions.ResumeLayout(false);
            spnlDataGridViewOPtions.PerformLayout();
            pnlUnpaidInvoices.ResumeLayout(false);
            pnlUnpaidInvoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).EndInit();
            pnlLowStock.ResumeLayout(false);
            pnlLowStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            pnlNetProfit.ResumeLayout(false);
            pnlNetProfit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
            sabraPanel2.ResumeLayout(false);
            sabraPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblNameOfTheMonthAndYear;
        private SabraButton sbtnAddNewExpense;
        private SabraPanel spnlDataGridViewOPtions;
        private SabraDateTimePicker dtpFrom;
        private SabraButton btnSearch;
        private SabraComboBox smbxPeriod;
        private SabraPanel pnlUnpaidInvoices;
        private SabraLabel lblTotalExpenses;
        private SabraPanel pnlLowStock;
        private SabraLabel lblLowStockPartsDisc;
        private SabraLabel lblReleaseFees;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private SabraPanel pnlNetProfit;
        private SabraPanel sabraPanel2;
        private SabraLabel sabraLabel1;
        private SabraLabel lblOtherExpenses;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private SabraLabel lblUnpaidInvoicesDisc;
        private TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private SabraLabel sabraLabel2;
        private SabraLabel lblElectricity;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private SabraDateTimePicker dtpTo;
        private SabraComboBox cmbClassification;
        private SabraLabel sabraLabel4;
        private SabraLabel sabraLabel3;
        private SabraDataGridView dgvExpenses;
    }
}
