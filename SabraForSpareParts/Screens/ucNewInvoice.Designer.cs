namespace SabraForSpareParts.Screens
{
    partial class ucNewInvoice
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
            scbtnDeleteInvoice = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            lblInvoiceNumber = new SabraLabel();
            spnlCustomer = new SabraPanel();
            sabraLabel3 = new SabraLabel();
            sabraDateTimePicker1 = new SabraDateTimePicker();
            slblCustomerNameAndCreditLimit = new SabraLabel();
            sabraLabel2 = new SabraLabel();
            stxbCustomer = new SabraTextBox();
            sabraLabel1 = new SabraLabel();
            scbxBrand = new SabraComboBox();
            btnAddNewCastomer = new SabraButton();
            sabraPanel2 = new SabraPanel();
            stbnAddToInvoice = new SabraButton();
            sabraNumericUpDownPrice = new SabraNumericUpDown();
            sabraLabel6 = new SabraLabel();
            sabraNumericUpDownAmount = new SabraNumericUpDown();
            sabraLabel5 = new SabraLabel();
            sabraLabel4 = new SabraLabel();
            stxbPartName = new SabraTextBox();
            sabraPanel3 = new SabraPanel();
            panel4 = new Panel();
            btnMixed = new SabraButton();
            btnCredit = new SabraButton();
            btnTransfer = new SabraButton();
            btnCash = new SabraButton();
            slblNetTotal = new SabraLabel();
            lblDiscount = new SabraLabel();
            lblItemsTotal = new SabraLabel();
            sbtnCancelSaving = new SabraButton();
            sbtnSave = new SabraButton();
            sbtnSaveAndAdd = new SabraButton();
            numUpDownGlobalDiscount = new SabraNumericUpDown();
            sabraLabel13 = new SabraLabel();
            lblRemaing = new SabraLabel();
            panel2 = new Panel();
            sabraNumericUpDownِAmountPaid = new SabraNumericUpDown();
            sabraLabel11 = new SabraLabel();
            panel3 = new Panel();
            sabraLabel10 = new SabraLabel();
            sabraLabel9 = new SabraLabel();
            panel1 = new Panel();
            sabraLabel8 = new SabraLabel();
            sabraLabel7 = new SabraLabel();
            dgvInvoice = new SabraDataGridView();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            spnlCustomer.SuspendLayout();
            sabraPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sabraNumericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sabraNumericUpDownAmount).BeginInit();
            sabraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numUpDownGlobalDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sabraNumericUpDownِAmountPaid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(scbtnDeleteInvoice);
            sabraPanel1.Controls.Add(sbtnPrint);
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(lblInvoiceNumber);
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
            sabraPanel1.TabIndex = 3;
            sabraPanel1.Paint += sabraPanel1_Paint;
            // 
            // scbtnDeleteInvoice
            // 
            scbtnDeleteInvoice.BackColor = Color.Firebrick;
            scbtnDeleteInvoice.BorderColor = Color.DodgerBlue;
            scbtnDeleteInvoice.BorderRadius = 20;
            scbtnDeleteInvoice.BorderSize = 0;
            scbtnDeleteInvoice.FlatAppearance.BorderSize = 0;
            scbtnDeleteInvoice.FlatStyle = FlatStyle.Flat;
            scbtnDeleteInvoice.Font = new Font("Cairo", 10F, FontStyle.Bold);
            scbtnDeleteInvoice.ForeColor = Color.White;
            scbtnDeleteInvoice.HoverColor = Color.Crimson;
            scbtnDeleteInvoice.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            scbtnDeleteInvoice.IconColor = Color.Beige;
            scbtnDeleteInvoice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            scbtnDeleteInvoice.IconSize = 30;
            scbtnDeleteInvoice.ImageAlign = ContentAlignment.MiddleRight;
            scbtnDeleteInvoice.Location = new Point(31, 34);
            scbtnDeleteInvoice.Name = "scbtnDeleteInvoice";
            scbtnDeleteInvoice.NormalColor = Color.Firebrick;
            scbtnDeleteInvoice.Padding = new Padding(10, 0, 10, 0);
            scbtnDeleteInvoice.Size = new Size(164, 41);
            scbtnDeleteInvoice.TabIndex = 21;
            scbtnDeleteInvoice.Text = "مسح الكل";
            scbtnDeleteInvoice.TextAlign = ContentAlignment.MiddleLeft;
            scbtnDeleteInvoice.UseVisualStyleBackColor = false;
            scbtnDeleteInvoice.Click += scbtnDeleteInvoice_Click;
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
            sbtnPrint.HoverColor = Color.SlateGray;
            sbtnPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            sbtnPrint.IconColor = Color.Beige;
            sbtnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnPrint.IconSize = 30;
            sbtnPrint.ImageAlign = ContentAlignment.MiddleRight;
            sbtnPrint.Location = new Point(372, 34);
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
            sbtnExportAsExcel.HoverColor = Color.DarkGreen;
            sbtnExportAsExcel.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            sbtnExportAsExcel.IconColor = Color.Beige;
            sbtnExportAsExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnExportAsExcel.IconSize = 30;
            sbtnExportAsExcel.ImageAlign = ContentAlignment.MiddleRight;
            sbtnExportAsExcel.Location = new Point(201, 34);
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
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.MoneyBill1Wave;
            icnDecreasedParts.IconColor = Color.RoyalBlue;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1380, 23);
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
            slblTitleOfTopPanel.BorderColor = Color.DodgerBlue;
            slblTitleOfTopPanel.BorderRadius = 8;
            slblTitleOfTopPanel.BorderSize = 0;
            slblTitleOfTopPanel.Font = new Font("Cairo", 18F, FontStyle.Bold);
            slblTitleOfTopPanel.ForeColor = Color.FromArgb(40, 40, 40);
            slblTitleOfTopPanel.Location = new Point(1125, 8);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.Size = new Size(249, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "فاتورة بيع جديدة";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblInvoiceNumber
            // 
            lblInvoiceNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInvoiceNumber.BackColor = Color.Transparent;
            lblInvoiceNumber.BorderColor = Color.DodgerBlue;
            lblInvoiceNumber.BorderRadius = 8;
            lblInvoiceNumber.BorderSize = 0;
            lblInvoiceNumber.Font = new Font("Cairo", 12F);
            lblInvoiceNumber.ForeColor = SystemColors.WindowFrame;
            lblInvoiceNumber.Location = new Point(1012, 64);
            lblInvoiceNumber.Name = "lblInvoiceNumber";
            lblInvoiceNumber.Size = new Size(353, 37);
            lblInvoiceNumber.TabIndex = 16;
            lblInvoiceNumber.Text = " INV-1085  : رقم الفاتورة";
            lblInvoiceNumber.TextAlign = ContentAlignment.MiddleRight;
            lblInvoiceNumber.Click += lblInvoiceNumber_Click;
            // 
            // spnlCustomer
            // 
            spnlCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            spnlCustomer.BackColor = Color.White;
            spnlCustomer.BorderColor = Color.LightGray;
            spnlCustomer.BorderRadius = 10;
            spnlCustomer.BorderSize = 0;
            spnlCustomer.Controls.Add(sabraLabel3);
            spnlCustomer.Controls.Add(sabraDateTimePicker1);
            spnlCustomer.Controls.Add(slblCustomerNameAndCreditLimit);
            spnlCustomer.Controls.Add(sabraLabel2);
            spnlCustomer.Controls.Add(stxbCustomer);
            spnlCustomer.Controls.Add(sabraLabel1);
            spnlCustomer.Controls.Add(scbxBrand);
            spnlCustomer.Controls.Add(btnAddNewCastomer);
            spnlCustomer.EnableHover = true;
            spnlCustomer.ForeColor = Color.Black;
            spnlCustomer.GradientAngle = 90F;
            spnlCustomer.GradientBottomColor = Color.White;
            spnlCustomer.GradientTopColor = Color.White;
            spnlCustomer.HoverBackColor = Color.FromArgb(245, 248, 255);
            spnlCustomer.HoverBorderColor = Color.FromArgb(37, 99, 235);
            spnlCustomer.HoverBorderSize = 2;
            spnlCustomer.Location = new Point(10, 131);
            spnlCustomer.Margin = new Padding(20);
            spnlCustomer.Name = "spnlCustomer";
            spnlCustomer.Size = new Size(1477, 98);
            spnlCustomer.TabIndex = 13;
            // 
            // sabraLabel3
            // 
            sabraLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel3.AutoSize = true;
            sabraLabel3.BackColor = Color.Transparent;
            sabraLabel3.BorderColor = Color.DodgerBlue;
            sabraLabel3.BorderRadius = 8;
            sabraLabel3.BorderSize = 0;
            sabraLabel3.Font = new Font("Cairo", 12F);
            sabraLabel3.ForeColor = SystemColors.WindowText;
            sabraLabel3.Location = new Point(306, 30);
            sabraLabel3.Name = "sabraLabel3";
            sabraLabel3.Size = new Size(65, 37);
            sabraLabel3.TabIndex = 22;
            sabraLabel3.Text = "التاريخ";
            sabraLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraDateTimePicker1
            // 
            sabraDateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraDateTimePicker1.BackColor = Color.Transparent;
            sabraDateTimePicker1.BorderColor = Color.FromArgb(220, 225, 230);
            sabraDateTimePicker1.BorderRadius = 12;
            sabraDateTimePicker1.BorderSize = 1;
            sabraDateTimePicker1.Checked = true;
            sabraDateTimePicker1.DateFormat = "dddd، dd MMMM yyyy";
            sabraDateTimePicker1.FocusedBorderColor = Color.FromArgb(0, 120, 212);
            sabraDateTimePicker1.Font = new Font("Cairo", 10F);
            sabraDateTimePicker1.Location = new Point(16, 27);
            sabraDateTimePicker1.MinimumSize = new Size(180, 45);
            sabraDateTimePicker1.Name = "sabraDateTimePicker1";
            sabraDateTimePicker1.RightToLeft = RightToLeft.Yes;
            sabraDateTimePicker1.ShowCheckBox = false;
            sabraDateTimePicker1.Size = new Size(275, 45);
            sabraDateTimePicker1.SkinColor = Color.White;
            sabraDateTimePicker1.TabIndex = 21;
            sabraDateTimePicker1.TextColor = Color.FromArgb(45, 45, 45);
            sabraDateTimePicker1.Value = new DateTime(2026, 8, 30, 0, 0, 0, 0);
            sabraDateTimePicker1.Load += sabraDateTimePicker1_Load;
            // 
            // slblCustomerNameAndCreditLimit
            // 
            slblCustomerNameAndCreditLimit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            slblCustomerNameAndCreditLimit.AutoSize = true;
            slblCustomerNameAndCreditLimit.BackColor = Color.FromArgb(240, 253, 244);
            slblCustomerNameAndCreditLimit.BorderColor = Color.Green;
            slblCustomerNameAndCreditLimit.BorderRadius = 20;
            slblCustomerNameAndCreditLimit.BorderSize = 1;
            slblCustomerNameAndCreditLimit.Font = new Font("Cairo", 15F);
            slblCustomerNameAndCreditLimit.ForeColor = Color.Green;
            slblCustomerNameAndCreditLimit.Location = new Point(508, 24);
            slblCustomerNameAndCreditLimit.Name = "slblCustomerNameAndCreditLimit";
            slblCustomerNameAndCreditLimit.Size = new Size(375, 47);
            slblCustomerNameAndCreditLimit.TabIndex = 14;
            slblCustomerNameAndCreditLimit.Text = "ورشة النيل — حد ائتماني: 10,000 ج";
            slblCustomerNameAndCreditLimit.TextAlign = ContentAlignment.MiddleCenter;
            slblCustomerNameAndCreditLimit.Click += slblCustomerNameAndCreditLimit_Click;
            // 
            // sabraLabel2
            // 
            sabraLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel2.AutoSize = true;
            sabraLabel2.BackColor = Color.Transparent;
            sabraLabel2.BorderColor = Color.DodgerBlue;
            sabraLabel2.BorderRadius = 8;
            sabraLabel2.BorderSize = 0;
            sabraLabel2.Font = new Font("Cairo", 12F);
            sabraLabel2.ForeColor = SystemColors.WindowText;
            sabraLabel2.Location = new Point(1362, 30);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.Size = new Size(75, 37);
            sabraLabel2.TabIndex = 20;
            sabraLabel2.Text = "العميل";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // stxbCustomer
            // 
            stxbCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stxbCustomer.BackColor = Color.WhiteSmoke;
            stxbCustomer.BorderRadius = 15;
            stxbCustomer.BorderSize = 3;
            stxbCustomer.BorderStyle = BorderStyle.None;
            stxbCustomer.Font = new Font("Cairo", 15F);
            stxbCustomer.ForeColor = Color.FromArgb(64, 64, 64);
            stxbCustomer.Location = new Point(1047, 25);
            stxbCustomer.Name = "stxbCustomer";
            stxbCustomer.PlaceholderText = "ابحث باسم أو تليفون";
            stxbCustomer.RightToLeft = RightToLeft.Yes;
            stxbCustomer.Size = new Size(312, 47);
            stxbCustomer.TabIndex = 19;
            stxbCustomer.TabStop = false;
            stxbCustomer.TextChanged += stxbCustomer_TextChanged;
            // 
            // sabraLabel1
            // 
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.BorderColor = Color.DodgerBlue;
            sabraLabel1.BorderRadius = 8;
            sabraLabel1.BorderSize = 0;
            sabraLabel1.Location = new Point(0, 0);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.Size = new Size(120, 32);
            sabraLabel1.TabIndex = 23;
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // scbxBrand
            // 
            scbxBrand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            scbxBrand.BackColor = Color.WhiteSmoke;
            scbxBrand.DrawMode = DrawMode.OwnerDrawFixed;
            scbxBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            scbxBrand.FlatStyle = FlatStyle.Flat;
            scbxBrand.Font = new Font("Cairo", 10F);
            scbxBrand.ForeColor = Color.FromArgb(64, 64, 64);
            scbxBrand.FormattingEnabled = true;
            scbxBrand.ItemHeight = 30;
            scbxBrand.Items.AddRange(new object[] { "Toyota", "Kia", "Hyundai" });
            scbxBrand.Location = new Point(1097, 32);
            scbxBrand.Name = "scbxBrand";
            scbxBrand.RightToLeft = RightToLeft.Yes;
            scbxBrand.Size = new Size(182, 36);
            scbxBrand.TabIndex = 13;
            // 
            // btnAddNewCastomer
            // 
            btnAddNewCastomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNewCastomer.BackColor = Color.White;
            btnAddNewCastomer.BorderColor = Color.DimGray;
            btnAddNewCastomer.BorderRadius = 20;
            btnAddNewCastomer.BorderSize = 1;
            btnAddNewCastomer.FlatAppearance.BorderSize = 0;
            btnAddNewCastomer.FlatStyle = FlatStyle.Flat;
            btnAddNewCastomer.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnAddNewCastomer.ForeColor = Color.DimGray;
            btnAddNewCastomer.HoverColor = Color.CornflowerBlue;
            btnAddNewCastomer.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAddNewCastomer.IconColor = Color.Black;
            btnAddNewCastomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddNewCastomer.IconSize = 30;
            btnAddNewCastomer.ImageAlign = ContentAlignment.MiddleRight;
            btnAddNewCastomer.Location = new Point(912, 27);
            btnAddNewCastomer.Name = "btnAddNewCastomer";
            btnAddNewCastomer.NormalColor = Color.White;
            btnAddNewCastomer.Size = new Size(129, 43);
            btnAddNewCastomer.TabIndex = 15;
            btnAddNewCastomer.Text = "عميل جديد";
            btnAddNewCastomer.TextAlign = ContentAlignment.MiddleLeft;
            btnAddNewCastomer.UseVisualStyleBackColor = false;
            btnAddNewCastomer.Click += btnAddNewCastomer_Click;
            // 
            // sabraPanel2
            // 
            sabraPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraPanel2.BackColor = SystemColors.Window;
            sabraPanel2.BorderColor = Color.LightGray;
            sabraPanel2.BorderRadius = 10;
            sabraPanel2.BorderSize = 0;
            sabraPanel2.Controls.Add(stbnAddToInvoice);
            sabraPanel2.Controls.Add(sabraNumericUpDownPrice);
            sabraPanel2.Controls.Add(sabraLabel6);
            sabraPanel2.Controls.Add(sabraNumericUpDownAmount);
            sabraPanel2.Controls.Add(sabraLabel5);
            sabraPanel2.Controls.Add(sabraLabel4);
            sabraPanel2.Controls.Add(stxbPartName);
            sabraPanel2.EnableHover = true;
            sabraPanel2.ForeColor = Color.Black;
            sabraPanel2.GradientAngle = 90F;
            sabraPanel2.GradientBottomColor = Color.White;
            sabraPanel2.GradientTopColor = Color.White;
            sabraPanel2.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel2.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel2.HoverBorderSize = 2;
            sabraPanel2.Location = new Point(10, 246);
            sabraPanel2.Margin = new Padding(20);
            sabraPanel2.Name = "sabraPanel2";
            sabraPanel2.Size = new Size(1477, 98);
            sabraPanel2.TabIndex = 23;
            // 
            // stbnAddToInvoice
            // 
            stbnAddToInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stbnAddToInvoice.BackColor = Color.RoyalBlue;
            stbnAddToInvoice.BorderColor = Color.DimGray;
            stbnAddToInvoice.BorderRadius = 20;
            stbnAddToInvoice.BorderSize = 1;
            stbnAddToInvoice.FlatAppearance.BorderSize = 0;
            stbnAddToInvoice.FlatStyle = FlatStyle.Flat;
            stbnAddToInvoice.Font = new Font("Cairo", 10F, FontStyle.Bold);
            stbnAddToInvoice.ForeColor = Color.White;
            stbnAddToInvoice.HoverColor = Color.CornflowerBlue;
            stbnAddToInvoice.IconChar = FontAwesome.Sharp.IconChar.Add;
            stbnAddToInvoice.IconColor = Color.White;
            stbnAddToInvoice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            stbnAddToInvoice.IconSize = 30;
            stbnAddToInvoice.ImageAlign = ContentAlignment.MiddleRight;
            stbnAddToInvoice.Location = new Point(208, 26);
            stbnAddToInvoice.Name = "stbnAddToInvoice";
            stbnAddToInvoice.NormalColor = Color.RoyalBlue;
            stbnAddToInvoice.Size = new Size(200, 43);
            stbnAddToInvoice.TabIndex = 27;
            stbnAddToInvoice.Text = "إضافة للفاتورة";
            stbnAddToInvoice.TextAlign = ContentAlignment.MiddleLeft;
            stbnAddToInvoice.UseVisualStyleBackColor = false;
            stbnAddToInvoice.Click += stbnAddToInvoice_Click;
            // 
            // sabraNumericUpDownPrice
            // 
            sabraNumericUpDownPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraNumericUpDownPrice.BackColor = Color.White;
            sabraNumericUpDownPrice.BorderColor = Color.FromArgb(218, 222, 225);
            sabraNumericUpDownPrice.BorderFocusColor = Color.FromArgb(52, 152, 219);
            sabraNumericUpDownPrice.Font = new Font("Segoe UI", 13.5F);
            sabraNumericUpDownPrice.ForeColor = Color.FromArgb(64, 64, 64);
            sabraNumericUpDownPrice.Location = new Point(430, 29);
            sabraNumericUpDownPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            sabraNumericUpDownPrice.Name = "sabraNumericUpDownPrice";
            sabraNumericUpDownPrice.Size = new Size(137, 37);
            sabraNumericUpDownPrice.TabIndex = 26;
            sabraNumericUpDownPrice.ValueChanged += sabraNumericUpDownPrice_ValueChanged;
            // 
            // sabraLabel6
            // 
            sabraLabel6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel6.AutoSize = true;
            sabraLabel6.BackColor = Color.Transparent;
            sabraLabel6.BorderColor = Color.DodgerBlue;
            sabraLabel6.BorderRadius = 8;
            sabraLabel6.BorderSize = 0;
            sabraLabel6.Font = new Font("Cairo", 12F);
            sabraLabel6.ForeColor = SystemColors.WindowText;
            sabraLabel6.Location = new Point(573, 29);
            sabraLabel6.Name = "sabraLabel6";
            sabraLabel6.Size = new Size(97, 37);
            sabraLabel6.TabIndex = 25;
            sabraLabel6.Text = "سعر البيع ";
            sabraLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraNumericUpDownAmount
            // 
            sabraNumericUpDownAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraNumericUpDownAmount.BackColor = Color.White;
            sabraNumericUpDownAmount.BorderColor = Color.FromArgb(218, 222, 225);
            sabraNumericUpDownAmount.BorderFocusColor = Color.FromArgb(52, 152, 219);
            sabraNumericUpDownAmount.Font = new Font("Segoe UI", 13.5F);
            sabraNumericUpDownAmount.ForeColor = Color.FromArgb(64, 64, 64);
            sabraNumericUpDownAmount.Location = new Point(698, 29);
            sabraNumericUpDownAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            sabraNumericUpDownAmount.Name = "sabraNumericUpDownAmount";
            sabraNumericUpDownAmount.Size = new Size(137, 37);
            sabraNumericUpDownAmount.TabIndex = 24;
            sabraNumericUpDownAmount.ValueChanged += sabraNumericUpDownAmount_ValueChanged;
            // 
            // sabraLabel5
            // 
            sabraLabel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel5.AutoSize = true;
            sabraLabel5.BackColor = Color.Transparent;
            sabraLabel5.BorderColor = Color.DodgerBlue;
            sabraLabel5.BorderRadius = 8;
            sabraLabel5.BorderSize = 0;
            sabraLabel5.Font = new Font("Cairo", 12F);
            sabraLabel5.ForeColor = SystemColors.WindowText;
            sabraLabel5.Location = new Point(841, 29);
            sabraLabel5.Name = "sabraLabel5";
            sabraLabel5.Size = new Size(85, 37);
            sabraLabel5.TabIndex = 23;
            sabraLabel5.Text = ": الكمية ";
            sabraLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel4
            // 
            sabraLabel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel4.AutoSize = true;
            sabraLabel4.BackColor = Color.Transparent;
            sabraLabel4.BorderColor = Color.DodgerBlue;
            sabraLabel4.BorderRadius = 8;
            sabraLabel4.BorderSize = 0;
            sabraLabel4.Font = new Font("Cairo", 12F);
            sabraLabel4.ForeColor = SystemColors.WindowText;
            sabraLabel4.Location = new Point(1305, 29);
            sabraLabel4.Name = "sabraLabel4";
            sabraLabel4.Size = new Size(132, 37);
            sabraLabel4.TabIndex = 22;
            sabraLabel4.Text = ": إضافة قطعة";
            sabraLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // stxbPartName
            // 
            stxbPartName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stxbPartName.BackColor = Color.WhiteSmoke;
            stxbPartName.BorderRadius = 15;
            stxbPartName.BorderSize = 3;
            stxbPartName.BorderStyle = BorderStyle.None;
            stxbPartName.Font = new Font("Cairo", 15F);
            stxbPartName.ForeColor = Color.FromArgb(64, 64, 64);
            stxbPartName.Location = new Point(987, 22);
            stxbPartName.Name = "stxbPartName";
            stxbPartName.PlaceholderText = "باركود أو سم أو رقم فني";
            stxbPartName.RightToLeft = RightToLeft.Yes;
            stxbPartName.Size = new Size(312, 47);
            stxbPartName.TabIndex = 21;
            stxbPartName.TabStop = false;
            stxbPartName.TextChanged += stxbPartName_TextChanged;
            // 
            // sabraPanel3
            // 
            sabraPanel3.AutoScroll = true;
            sabraPanel3.AutoScrollMargin = new Size(1, 0);
            sabraPanel3.AutoScrollMinSize = new Size(1, 0);
            sabraPanel3.BackColor = Color.White;
            sabraPanel3.BorderColor = Color.LightGray;
            sabraPanel3.BorderRadius = 7;
            sabraPanel3.BorderSize = 0;
            sabraPanel3.Controls.Add(panel4);
            sabraPanel3.Controls.Add(btnMixed);
            sabraPanel3.Controls.Add(btnCredit);
            sabraPanel3.Controls.Add(btnTransfer);
            sabraPanel3.Controls.Add(btnCash);
            sabraPanel3.Controls.Add(slblNetTotal);
            sabraPanel3.Controls.Add(lblDiscount);
            sabraPanel3.Controls.Add(lblItemsTotal);
            sabraPanel3.Controls.Add(sbtnCancelSaving);
            sabraPanel3.Controls.Add(sbtnSave);
            sabraPanel3.Controls.Add(sbtnSaveAndAdd);
            sabraPanel3.Controls.Add(numUpDownGlobalDiscount);
            sabraPanel3.Controls.Add(sabraLabel13);
            sabraPanel3.Controls.Add(lblRemaing);
            sabraPanel3.Controls.Add(panel2);
            sabraPanel3.Controls.Add(sabraNumericUpDownِAmountPaid);
            sabraPanel3.Controls.Add(sabraLabel11);
            sabraPanel3.Controls.Add(panel3);
            sabraPanel3.Controls.Add(sabraLabel10);
            sabraPanel3.Controls.Add(sabraLabel9);
            sabraPanel3.Controls.Add(panel1);
            sabraPanel3.Controls.Add(sabraLabel8);
            sabraPanel3.Controls.Add(sabraLabel7);
            sabraPanel3.EnableHover = true;
            sabraPanel3.ForeColor = Color.Black;
            sabraPanel3.GradientAngle = 90F;
            sabraPanel3.GradientBottomColor = Color.White;
            sabraPanel3.GradientTopColor = Color.White;
            sabraPanel3.HoverBackColor = Color.White;
            sabraPanel3.HoverBorderColor = Color.White;
            sabraPanel3.HoverBorderSize = 0;
            sabraPanel3.Location = new Point(6, 376);
            sabraPanel3.Margin = new Padding(30);
            sabraPanel3.Name = "sabraPanel3";
            sabraPanel3.Padding = new Padding(0, 0, 0, 30);
            sabraPanel3.Size = new Size(440, 799);
            sabraPanel3.TabIndex = 28;
            sabraPanel3.Paint += sabraPanel3_Paint;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.LightGray;
            panel4.Location = new Point(1, 900);
            panel4.Name = "panel4";
            panel4.Size = new Size(415, 1);
            panel4.TabIndex = 50;
            // 
            // btnMixed
            // 
            btnMixed.BackColor = Color.White;
            btnMixed.BorderColor = Color.DimGray;
            btnMixed.BorderRadius = 20;
            btnMixed.BorderSize = 1;
            btnMixed.FlatAppearance.BorderSize = 0;
            btnMixed.FlatStyle = FlatStyle.Flat;
            btnMixed.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnMixed.ForeColor = Color.DimGray;
            btnMixed.HoverColor = Color.CornflowerBlue;
            btnMixed.IconChar = FontAwesome.Sharp.IconChar.None;
            btnMixed.IconColor = Color.Beige;
            btnMixed.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMixed.IconSize = 30;
            btnMixed.ImageAlign = ContentAlignment.MiddleRight;
            btnMixed.Location = new Point(129, 306);
            btnMixed.Name = "btnMixed";
            btnMixed.NormalColor = Color.White;
            btnMixed.Padding = new Padding(10, 0, 10, 0);
            btnMixed.Size = new Size(102, 41);
            btnMixed.TabIndex = 49;
            btnMixed.Text = "مختلط";
            btnMixed.TextAlign = ContentAlignment.TopCenter;
            btnMixed.UseVisualStyleBackColor = false;
            // 
            // btnCredit
            // 
            btnCredit.BackColor = Color.White;
            btnCredit.BorderColor = Color.DimGray;
            btnCredit.BorderRadius = 20;
            btnCredit.BorderSize = 1;
            btnCredit.FlatAppearance.BorderSize = 0;
            btnCredit.FlatStyle = FlatStyle.Flat;
            btnCredit.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnCredit.ForeColor = Color.DimGray;
            btnCredit.HoverColor = Color.CornflowerBlue;
            btnCredit.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCredit.IconColor = Color.Beige;
            btnCredit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCredit.IconSize = 30;
            btnCredit.ImageAlign = ContentAlignment.MiddleRight;
            btnCredit.Location = new Point(21, 247);
            btnCredit.Name = "btnCredit";
            btnCredit.NormalColor = Color.White;
            btnCredit.Padding = new Padding(10, 0, 10, 0);
            btnCredit.Size = new Size(102, 41);
            btnCredit.TabIndex = 48;
            btnCredit.Text = "آجل";
            btnCredit.TextAlign = ContentAlignment.TopCenter;
            btnCredit.UseVisualStyleBackColor = false;
            btnCredit.Click += PaymentMethod_Click;
            // 
            // btnTransfer
            // 
            btnTransfer.BackColor = Color.White;
            btnTransfer.BorderColor = Color.DimGray;
            btnTransfer.BorderRadius = 20;
            btnTransfer.BorderSize = 1;
            btnTransfer.FlatAppearance.BorderSize = 0;
            btnTransfer.FlatStyle = FlatStyle.Flat;
            btnTransfer.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnTransfer.ForeColor = Color.DimGray;
            btnTransfer.HoverColor = Color.CornflowerBlue;
            btnTransfer.IconChar = FontAwesome.Sharp.IconChar.None;
            btnTransfer.IconColor = Color.Beige;
            btnTransfer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTransfer.IconSize = 30;
            btnTransfer.ImageAlign = ContentAlignment.MiddleRight;
            btnTransfer.Location = new Point(129, 247);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.NormalColor = Color.White;
            btnTransfer.Padding = new Padding(10, 0, 10, 0);
            btnTransfer.Size = new Size(102, 41);
            btnTransfer.TabIndex = 47;
            btnTransfer.Text = "تحويل";
            btnTransfer.TextAlign = ContentAlignment.TopCenter;
            btnTransfer.UseVisualStyleBackColor = false;
            btnTransfer.Click += PaymentMethod_Click;
            // 
            // btnCash
            // 
            btnCash.BackColor = Color.White;
            btnCash.BorderColor = Color.DimGray;
            btnCash.BorderRadius = 20;
            btnCash.BorderSize = 1;
            btnCash.FlatAppearance.BorderSize = 0;
            btnCash.FlatStyle = FlatStyle.Flat;
            btnCash.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnCash.ForeColor = Color.DimGray;
            btnCash.HoverColor = Color.CornflowerBlue;
            btnCash.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCash.IconColor = Color.Beige;
            btnCash.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCash.IconSize = 30;
            btnCash.ImageAlign = ContentAlignment.MiddleRight;
            btnCash.Location = new Point(237, 247);
            btnCash.Name = "btnCash";
            btnCash.NormalColor = Color.White;
            btnCash.Padding = new Padding(10, 0, 10, 0);
            btnCash.Size = new Size(102, 41);
            btnCash.TabIndex = 46;
            btnCash.Text = "كاش";
            btnCash.TextAlign = ContentAlignment.TopCenter;
            btnCash.UseVisualStyleBackColor = false;
            btnCash.Click += PaymentMethod_Click;
            // 
            // slblNetTotal
            // 
            slblNetTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblNetTotal.AutoSize = true;
            slblNetTotal.BackColor = Color.Transparent;
            slblNetTotal.BorderColor = Color.DodgerBlue;
            slblNetTotal.BorderRadius = 8;
            slblNetTotal.BorderSize = 0;
            slblNetTotal.Font = new Font("Cairo", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            slblNetTotal.ForeColor = SystemColors.WindowText;
            slblNetTotal.Location = new Point(37, 141);
            slblNetTotal.Name = "slblNetTotal";
            slblNetTotal.Size = new Size(91, 37);
            slblNetTotal.TabIndex = 45;
            slblNetTotal.Text = ": الصافي";
            slblNetTotal.TextAlign = ContentAlignment.MiddleRight;
            slblNetTotal.Click += PaymentMethod_Click;
            // 
            // lblDiscount
            // 
            lblDiscount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDiscount.AutoSize = true;
            lblDiscount.BackColor = Color.Transparent;
            lblDiscount.BorderColor = Color.DodgerBlue;
            lblDiscount.BorderRadius = 8;
            lblDiscount.BorderSize = 0;
            lblDiscount.Font = new Font("Cairo", 12F);
            lblDiscount.ForeColor = Color.Red;
            lblDiscount.Location = new Point(37, 74);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(137, 37);
            lblDiscount.TabIndex = 44;
            lblDiscount.Text = ": إجمالي القطع";
            lblDiscount.TextAlign = ContentAlignment.MiddleRight;
            lblDiscount.Click += lblDiscount_Click;
            // 
            // lblItemsTotal
            // 
            lblItemsTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblItemsTotal.AutoSize = true;
            lblItemsTotal.BackColor = Color.Transparent;
            lblItemsTotal.BorderColor = Color.DodgerBlue;
            lblItemsTotal.BorderRadius = 8;
            lblItemsTotal.BorderSize = 0;
            lblItemsTotal.Font = new Font("Cairo", 12F);
            lblItemsTotal.ForeColor = SystemColors.WindowFrame;
            lblItemsTotal.Location = new Point(37, 26);
            lblItemsTotal.Name = "lblItemsTotal";
            lblItemsTotal.Size = new Size(55, 37);
            lblItemsTotal.TabIndex = 43;
            lblItemsTotal.Text = "ج 50";
            lblItemsTotal.TextAlign = ContentAlignment.MiddleRight;
            lblItemsTotal.Click += lblItemsTotal_Click;
            // 
            // sbtnCancelSaving
            // 
            sbtnCancelSaving.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbtnCancelSaving.BackColor = Color.White;
            sbtnCancelSaving.BorderColor = SystemColors.ControlLight;
            sbtnCancelSaving.BorderRadius = 20;
            sbtnCancelSaving.BorderSize = 3;
            sbtnCancelSaving.FlatAppearance.BorderSize = 0;
            sbtnCancelSaving.FlatStyle = FlatStyle.Flat;
            sbtnCancelSaving.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnCancelSaving.ForeColor = SystemColors.ControlDarkDark;
            sbtnCancelSaving.HoverColor = Color.CornflowerBlue;
            sbtnCancelSaving.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            sbtnCancelSaving.IconColor = SystemColors.ControlDarkDark;
            sbtnCancelSaving.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnCancelSaving.IconSize = 30;
            sbtnCancelSaving.ImageAlign = ContentAlignment.MiddleRight;
            sbtnCancelSaving.Location = new Point(110, 833);
            sbtnCancelSaving.Margin = new Padding(60);
            sbtnCancelSaving.Name = "sbtnCancelSaving";
            sbtnCancelSaving.NormalColor = Color.White;
            sbtnCancelSaving.Padding = new Padding(10, 0, 10, 0);
            sbtnCancelSaving.Size = new Size(164, 41);
            sbtnCancelSaving.TabIndex = 42;
            sbtnCancelSaving.Text = "إلغـــاء";
            sbtnCancelSaving.UseVisualStyleBackColor = false;
            sbtnCancelSaving.Click += sbtnCancelSaving_Click;
            // 
            // sbtnSave
            // 
            sbtnSave.BackColor = Color.Green;
            sbtnSave.BorderColor = Color.DodgerBlue;
            sbtnSave.BorderRadius = 20;
            sbtnSave.BorderSize = 0;
            sbtnSave.FlatAppearance.BorderSize = 0;
            sbtnSave.FlatStyle = FlatStyle.Flat;
            sbtnSave.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnSave.ForeColor = Color.White;
            sbtnSave.HoverColor = Color.CornflowerBlue;
            sbtnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            sbtnSave.IconColor = Color.Beige;
            sbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnSave.IconSize = 30;
            sbtnSave.ImageAlign = ContentAlignment.MiddleRight;
            sbtnSave.Location = new Point(73, 657);
            sbtnSave.Name = "sbtnSave";
            sbtnSave.NormalColor = Color.Green;
            sbtnSave.Padding = new Padding(10, 0, 10, 0);
            sbtnSave.Size = new Size(235, 58);
            sbtnSave.TabIndex = 41;
            sbtnSave.Text = "حفظ الفاتورة";
            sbtnSave.UseVisualStyleBackColor = false;
            sbtnSave.Click += sbtnSave_Click;
            // 
            // sbtnSaveAndAdd
            // 
            sbtnSaveAndAdd.BackColor = Color.RoyalBlue;
            sbtnSaveAndAdd.BorderColor = Color.DodgerBlue;
            sbtnSaveAndAdd.BorderRadius = 14;
            sbtnSaveAndAdd.BorderSize = 0;
            sbtnSaveAndAdd.FlatAppearance.BorderSize = 0;
            sbtnSaveAndAdd.FlatStyle = FlatStyle.Flat;
            sbtnSaveAndAdd.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnSaveAndAdd.ForeColor = Color.White;
            sbtnSaveAndAdd.HoverColor = Color.CornflowerBlue;
            sbtnSaveAndAdd.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateLeft;
            sbtnSaveAndAdd.IconColor = Color.White;
            sbtnSaveAndAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnSaveAndAdd.ImageAlign = ContentAlignment.MiddleRight;
            sbtnSaveAndAdd.Location = new Point(73, 741);
            sbtnSaveAndAdd.Name = "sbtnSaveAndAdd";
            sbtnSaveAndAdd.NormalColor = Color.RoyalBlue;
            sbtnSaveAndAdd.Size = new Size(235, 59);
            sbtnSaveAndAdd.TabIndex = 40;
            sbtnSaveAndAdd.Text = "حفظ و طباعة الفاتورة";
            sbtnSaveAndAdd.TextAlign = ContentAlignment.MiddleLeft;
            sbtnSaveAndAdd.UseVisualStyleBackColor = false;
            sbtnSaveAndAdd.Click += sbtnSaveAndAdd_Click;
            // 
            // numUpDownGlobalDiscount
            // 
            numUpDownGlobalDiscount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numUpDownGlobalDiscount.BackColor = Color.White;
            numUpDownGlobalDiscount.BorderColor = Color.FromArgb(218, 222, 225);
            numUpDownGlobalDiscount.BorderFocusColor = Color.FromArgb(52, 152, 219);
            numUpDownGlobalDiscount.Font = new Font("Segoe UI", 13.5F);
            numUpDownGlobalDiscount.ForeColor = Color.FromArgb(64, 64, 64);
            numUpDownGlobalDiscount.Location = new Point(62, 586);
            numUpDownGlobalDiscount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numUpDownGlobalDiscount.Name = "numUpDownGlobalDiscount";
            numUpDownGlobalDiscount.Size = new Size(285, 37);
            numUpDownGlobalDiscount.TabIndex = 36;
            numUpDownGlobalDiscount.ValueChanged += numUpDownGlobalDiscount_ValueChanged;
            // 
            // sabraLabel13
            // 
            sabraLabel13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel13.AutoSize = true;
            sabraLabel13.BackColor = Color.Transparent;
            sabraLabel13.BorderColor = Color.DodgerBlue;
            sabraLabel13.BorderRadius = 8;
            sabraLabel13.BorderSize = 0;
            sabraLabel13.Font = new Font("Cairo", 10F);
            sabraLabel13.ForeColor = SystemColors.WindowFrame;
            sabraLabel13.Location = new Point(278, 540);
            sabraLabel13.Name = "sabraLabel13";
            sabraLabel13.Size = new Size(107, 32);
            sabraLabel13.TabIndex = 35;
            sabraLabel13.Text = ": خصم إجمالي";
            sabraLabel13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRemaing
            // 
            lblRemaing.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRemaing.BackColor = Color.FromArgb(240, 253, 244);
            lblRemaing.BorderColor = Color.Green;
            lblRemaing.BorderRadius = 20;
            lblRemaing.BorderSize = 1;
            lblRemaing.Font = new Font("Cairo", 15F);
            lblRemaing.ForeColor = Color.Green;
            lblRemaing.Location = new Point(54, 479);
            lblRemaing.Name = "lblRemaing";
            lblRemaing.Size = new Size(285, 48);
            lblRemaing.TabIndex = 34;
            lblRemaing.Text = "المتبقي:   ج";
            lblRemaing.TextAlign = ContentAlignment.MiddleCenter;
            lblRemaing.Click += lblRemaing_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.LightGray;
            panel2.Location = new Point(3, 190);
            panel2.Name = "panel2";
            panel2.Size = new Size(404, 1);
            panel2.TabIndex = 39;
            // 
            // sabraNumericUpDownِAmountPaid
            // 
            sabraNumericUpDownِAmountPaid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraNumericUpDownِAmountPaid.BackColor = Color.White;
            sabraNumericUpDownِAmountPaid.BorderColor = Color.FromArgb(218, 222, 225);
            sabraNumericUpDownِAmountPaid.BorderFocusColor = Color.FromArgb(52, 152, 219);
            sabraNumericUpDownِAmountPaid.Font = new Font("Segoe UI", 13.5F);
            sabraNumericUpDownِAmountPaid.ForeColor = Color.FromArgb(64, 64, 64);
            sabraNumericUpDownِAmountPaid.Location = new Point(54, 427);
            sabraNumericUpDownِAmountPaid.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            sabraNumericUpDownِAmountPaid.Name = "sabraNumericUpDownِAmountPaid";
            sabraNumericUpDownِAmountPaid.Size = new Size(285, 37);
            sabraNumericUpDownِAmountPaid.TabIndex = 33;
            sabraNumericUpDownِAmountPaid.ValueChanged += sabraNumericUpDownِAmountPaid_ValueChanged;
            // 
            // sabraLabel11
            // 
            sabraLabel11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel11.AutoSize = true;
            sabraLabel11.BackColor = Color.Transparent;
            sabraLabel11.BorderColor = Color.DodgerBlue;
            sabraLabel11.BorderRadius = 8;
            sabraLabel11.BorderSize = 0;
            sabraLabel11.Font = new Font("Cairo", 10F);
            sabraLabel11.ForeColor = SystemColors.WindowFrame;
            sabraLabel11.Location = new Point(258, 376);
            sabraLabel11.Name = "sabraLabel11";
            sabraLabel11.Size = new Size(127, 32);
            sabraLabel11.TabIndex = 32;
            sabraLabel11.Text = ": المبلغ المدفوع";
            sabraLabel11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.LightGray;
            panel3.Location = new Point(1, 357);
            panel3.Name = "panel3";
            panel3.Size = new Size(415, 1);
            panel3.TabIndex = 31;
            // 
            // sabraLabel10
            // 
            sabraLabel10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel10.AutoSize = true;
            sabraLabel10.BackColor = Color.Transparent;
            sabraLabel10.BorderColor = Color.DodgerBlue;
            sabraLabel10.BorderRadius = 8;
            sabraLabel10.BorderSize = 0;
            sabraLabel10.Font = new Font("Cairo", 10F);
            sabraLabel10.ForeColor = SystemColors.WindowFrame;
            sabraLabel10.Location = new Point(278, 212);
            sabraLabel10.Name = "sabraLabel10";
            sabraLabel10.Size = new Size(111, 32);
            sabraLabel10.TabIndex = 30;
            sabraLabel10.Text = ": طريقة الدفع";
            sabraLabel10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel9
            // 
            sabraLabel9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel9.AutoSize = true;
            sabraLabel9.BackColor = Color.Transparent;
            sabraLabel9.BorderColor = Color.DodgerBlue;
            sabraLabel9.BorderRadius = 8;
            sabraLabel9.BorderSize = 0;
            sabraLabel9.Font = new Font("Cairo", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel9.ForeColor = SystemColors.WindowText;
            sabraLabel9.Location = new Point(298, 141);
            sabraLabel9.Name = "sabraLabel9";
            sabraLabel9.Size = new Size(91, 37);
            sabraLabel9.TabIndex = 29;
            sabraLabel9.Text = ": الصافي";
            sabraLabel9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.LightGray;
            panel1.Location = new Point(4, 127);
            panel1.Name = "panel1";
            panel1.Size = new Size(415, 1);
            panel1.TabIndex = 28;
            // 
            // sabraLabel8
            // 
            sabraLabel8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel8.AutoSize = true;
            sabraLabel8.BackColor = Color.Transparent;
            sabraLabel8.BorderColor = Color.DodgerBlue;
            sabraLabel8.BorderRadius = 8;
            sabraLabel8.BorderSize = 0;
            sabraLabel8.Font = new Font("Cairo", 12F);
            sabraLabel8.ForeColor = SystemColors.WindowFrame;
            sabraLabel8.Location = new Point(311, 74);
            sabraLabel8.Name = "sabraLabel8";
            sabraLabel8.Size = new Size(78, 37);
            sabraLabel8.TabIndex = 27;
            sabraLabel8.Text = ": الخصم";
            sabraLabel8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel7
            // 
            sabraLabel7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel7.AutoSize = true;
            sabraLabel7.BackColor = Color.Transparent;
            sabraLabel7.BorderColor = Color.DodgerBlue;
            sabraLabel7.BorderRadius = 8;
            sabraLabel7.BorderSize = 0;
            sabraLabel7.Font = new Font("Cairo", 12F);
            sabraLabel7.ForeColor = SystemColors.WindowFrame;
            sabraLabel7.Location = new Point(260, 26);
            sabraLabel7.Name = "sabraLabel7";
            sabraLabel7.Size = new Size(137, 37);
            sabraLabel7.TabIndex = 26;
            sabraLabel7.Text = ": إجمالي القطع";
            sabraLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvInvoice
            // 
            dgvInvoice.AllowUserToAddRows = false;
            dgvInvoice.AllowUserToDeleteRows = false;
            dgvInvoice.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoice.BackgroundColor = Color.White;
            dgvInvoice.BorderStyle = BorderStyle.None;
            dgvInvoice.ButtonBackColor = Color.White;
            dgvInvoice.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvInvoice.ButtonHoverColor = Color.FromArgb(238, 242, 255);
            dgvInvoice.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvInvoice.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvInvoice.DefaultCellStyle = dataGridViewCellStyle3;
            dgvInvoice.EnableHeadersVisualStyles = false;
            dgvInvoice.Font = new Font("Cairo", 10F);
            dgvInvoice.GridColor = Color.FromArgb(226, 232, 240);
            dgvInvoice.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvInvoice.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvInvoice.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvInvoice.HeaderHeight = 4;
            dgvInvoice.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvInvoice.Location = new Point(462, 376);
            dgvInvoice.MultiSelect = false;
            dgvInvoice.Name = "dgvInvoice";
            dgvInvoice.ReadOnly = true;
            dgvInvoice.RightToLeft = RightToLeft.Yes;
            dgvInvoice.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvInvoice.RowBackColor = Color.White;
            dgvInvoice.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvInvoice.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvInvoice.RowHeadersVisible = false;
            dgvInvoice.RowHeadersWidth = 51;
            dgvInvoice.RowTemplate.Height = 42;
            dgvInvoice.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvInvoice.SelectionForeColor = Color.White;
            dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoice.Size = new Size(1025, 1400);
            dgvInvoice.TabIndex = 29;
            dgvInvoice.CellContentClick += dgvInvoice_CellContentClick;
            // 
            // ucNewInvoice
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvInvoice);
            Controls.Add(sabraPanel3);
            Controls.Add(sabraPanel2);
            Controls.Add(spnlCustomer);
            Controls.Add(sabraPanel1);
            Name = "ucNewInvoice";
            Size = new Size(1397, 940);
            Load += ucNewInvoice_Load;
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            spnlCustomer.ResumeLayout(false);
            spnlCustomer.PerformLayout();
            sabraPanel2.ResumeLayout(false);
            sabraPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sabraNumericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)sabraNumericUpDownAmount).EndInit();
            sabraPanel3.ResumeLayout(false);
            sabraPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numUpDownGlobalDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)sabraNumericUpDownِAmountPaid).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblInvoiceNumber;
        private SabraButton scbtnDeleteInvoice;
        private SabraPanel spnlCustomer;
        private SabraLabel sabraLabel2;
        private SabraTextBox stxbCustomer;
        private SabraLabel sabraLabel1;
        private SabraComboBox scbxBrand;
        private SabraButton btnAddNewCastomer;
        private SabraLabel slblCustomerNameAndCreditLimit;
        private SabraLabel sabraLabel3;
        private SabraDateTimePicker sabraDateTimePicker1;
        private SabraPanel sabraPanel2;
        private SabraLabel sabraLabel4;
        private SabraTextBox stxbPartName;
        private SabraLabel sabraLabel5;
        private SabraNumericUpDown sabraNumericUpDownAmount;
        private SabraButton stbnAddToInvoice;
        private SabraNumericUpDown sabraNumericUpDownPrice;
        private SabraLabel sabraLabel6;
        private SabraPanel sabraPanel3;
        private SabraDataGridView dgvInvoice;
        private SabraLabel sabraLabel8;
        private SabraLabel sabraLabel7;
        private Panel panel1;
        private SabraLabel sabraLabel9;
        private SabraNumericUpDown sabraNumericUpDownِAmountPaid;
        private SabraLabel sabraLabel11;
        private Panel panel3;
        private SabraLabel sabraLabel10;
        private SabraNumericUpDown numUpDownGlobalDiscount;
        private SabraLabel sabraLabel13;
        private SabraLabel lblRemaing;
        private Panel panel2;
        private SabraButton sbtnCancelSaving;
        private SabraButton sbtnSave;
        private SabraButton sbtnSaveAndAdd;
        private SabraLabel slblNetTotal;
        private SabraLabel lblDiscount;
        private SabraLabel lblItemsTotal;
        private SabraButton btnCash;
        private SabraButton btnMixed;
        private SabraButton btnCredit;
        private SabraButton btnTransfer;
        private Panel panel4;
    }
}
