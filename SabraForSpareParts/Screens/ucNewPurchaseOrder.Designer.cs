namespace SabraForSpareParts.Screens
{
    partial class ucNewPurchaseOrder
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
            sabraLabel3 = new SabraLabel();
            dtpPurchaseOrderDate = new SabraDateTimePicker();
            slblResponsibleEmployee = new SabraLabel();
            lblNewPurchaseOrderNumber2 = new SabraLabel();
            addSupplier = new FontAwesome.Sharp.IconButton();
            scbxSupplier = new SabraComboBox();
            sabraLabel7 = new SabraLabel();
            sabraLabel5 = new SabraLabel();
            sabraLabel1 = new SabraLabel();
            panel1 = new Panel();
            slblBasicInfoTitle = new SabraLabel();
            sabraPanel2 = new SabraPanel();
            scbtnDeleteInvoice = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            lblNewPurchaseOrderNumber = new SabraLabel();
            sabraPanel3 = new SabraPanel();
            sabraLabel6 = new SabraLabel();
            stbxAmount = new SabraTextBox();
            dgvPurchaseOrderDetails = new SabraDataGridView();
            lblTotalPriceOfPurchaseOrders = new SabraLabel();
            btnSearch = new SabraButton();
            stbxAddPart = new SabraTextBox();
            sabraLabel10 = new SabraLabel();
            panel2 = new Panel();
            sabraLabel11 = new SabraLabel();
            spnlLastPanel = new SabraPanel();
            sbtnSaveAndSent = new SabraButton();
            btnCancel = new SabraButton();
            btnSaveAsDraft = new SabraButton();
            pnlNotesPanel = new SabraPanel();
            stbxNotes = new SabraTextBox();
            sabraLabel2 = new SabraLabel();
            sabraPanel1.SuspendLayout();
            sabraPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            sabraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseOrderDetails).BeginInit();
            spnlLastPanel.SuspendLayout();
            pnlNotesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.DimGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(sabraLabel3);
            sabraPanel1.Controls.Add(dtpPurchaseOrderDate);
            sabraPanel1.Controls.Add(slblResponsibleEmployee);
            sabraPanel1.Controls.Add(lblNewPurchaseOrderNumber2);
            sabraPanel1.Controls.Add(addSupplier);
            sabraPanel1.Controls.Add(scbxSupplier);
            sabraPanel1.Controls.Add(sabraLabel7);
            sabraPanel1.Controls.Add(sabraLabel5);
            sabraPanel1.Controls.Add(sabraLabel1);
            sabraPanel1.Controls.Add(panel1);
            sabraPanel1.Controls.Add(slblBasicInfoTitle);
            sabraPanel1.EnableHover = true;
            sabraPanel1.ForeColor = Color.Black;
            sabraPanel1.GradientAngle = 90F;
            sabraPanel1.GradientBottomColor = Color.White;
            sabraPanel1.GradientTopColor = Color.White;
            sabraPanel1.HoverBackColor = Color.White;
            sabraPanel1.HoverBorderColor = Color.DimGray;
            sabraPanel1.HoverBorderSize = 2;
            sabraPanel1.Location = new Point(18, 144);
            sabraPanel1.Margin = new Padding(20);
            sabraPanel1.Name = "sabraPanel1";
            sabraPanel1.Size = new Size(1579, 209);
            sabraPanel1.TabIndex = 4;
            sabraPanel1.Paint += sabraPanel1_Paint;
            // 
            // sabraLabel3
            // 
            sabraLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel3.AutoSize = true;
            sabraLabel3.BackColor = Color.Transparent;
            sabraLabel3.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel3.ForeColor = Color.DimGray;
            sabraLabel3.Location = new Point(859, 96);
            sabraLabel3.Margin = new Padding(0);
            sabraLabel3.Name = "sabraLabel3";
            sabraLabel3.Required = true;
            sabraLabel3.RightToLeft = RightToLeft.Yes;
            sabraLabel3.Size = new Size(105, 32);
            sabraLabel3.TabIndex = 27;
            sabraLabel3.Text = "تاريخ الطلب";
            sabraLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpPurchaseOrderDate
            // 
            dtpPurchaseOrderDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpPurchaseOrderDate.BackColor = Color.Transparent;
            dtpPurchaseOrderDate.BorderColor = Color.FromArgb(64, 64, 64);
            dtpPurchaseOrderDate.BorderRadius = 12;
            dtpPurchaseOrderDate.BorderSize = 1;
            dtpPurchaseOrderDate.Checked = true;
            dtpPurchaseOrderDate.DateFormat = "dddd، dd MMMM yyyy";
            dtpPurchaseOrderDate.FocusedBorderColor = Color.FromArgb(0, 120, 212);
            dtpPurchaseOrderDate.Font = new Font("Cairo", 10F);
            dtpPurchaseOrderDate.Location = new Point(689, 134);
            dtpPurchaseOrderDate.MinimumSize = new Size(180, 45);
            dtpPurchaseOrderDate.Name = "dtpPurchaseOrderDate";
            dtpPurchaseOrderDate.Required = true;
            dtpPurchaseOrderDate.RightToLeft = RightToLeft.Yes;
            dtpPurchaseOrderDate.ShowCheckBox = false;
            dtpPurchaseOrderDate.Size = new Size(275, 45);
            dtpPurchaseOrderDate.SkinColor = Color.White;
            dtpPurchaseOrderDate.TabIndex = 26;
            dtpPurchaseOrderDate.TextColor = Color.FromArgb(45, 45, 45);
            dtpPurchaseOrderDate.Value = new DateTime(2026, 8, 30, 0, 0, 0, 0);
            dtpPurchaseOrderDate.Load += dtpPurchaseOrderDate_Load;
            // 
            // slblResponsibleEmployee
            // 
            slblResponsibleEmployee.BackColor = Color.White;
            slblResponsibleEmployee.BorderColor = Color.DimGray;
            slblResponsibleEmployee.BorderSize = 3;
            slblResponsibleEmployee.Font = new Font("Cairo", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            slblResponsibleEmployee.ForeColor = Color.DimGray;
            slblResponsibleEmployee.Location = new Point(58, 130);
            slblResponsibleEmployee.Name = "slblResponsibleEmployee";
            slblResponsibleEmployee.RightToLeft = RightToLeft.Yes;
            slblResponsibleEmployee.Size = new Size(201, 51);
            slblResponsibleEmployee.TabIndex = 25;
            slblResponsibleEmployee.Text = "أحمد محمد";
            slblResponsibleEmployee.TextAlign = ContentAlignment.MiddleCenter;
            slblResponsibleEmployee.Click += slblResponsibleEmployee_Click;
            // 
            // lblNewPurchaseOrderNumber2
            // 
            lblNewPurchaseOrderNumber2.BackColor = Color.White;
            lblNewPurchaseOrderNumber2.BorderColor = Color.DimGray;
            lblNewPurchaseOrderNumber2.BorderSize = 3;
            lblNewPurchaseOrderNumber2.Font = new Font("Cairo", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNewPurchaseOrderNumber2.ForeColor = Color.DimGray;
            lblNewPurchaseOrderNumber2.Location = new Point(299, 127);
            lblNewPurchaseOrderNumber2.Name = "lblNewPurchaseOrderNumber2";
            lblNewPurchaseOrderNumber2.RightToLeft = RightToLeft.Yes;
            lblNewPurchaseOrderNumber2.Size = new Size(201, 51);
            lblNewPurchaseOrderNumber2.TabIndex = 24;
            lblNewPurchaseOrderNumber2.Text = "PO-0046 ";
            lblNewPurchaseOrderNumber2.TextAlign = ContentAlignment.MiddleCenter;
            lblNewPurchaseOrderNumber2.Click += lblNewPurchaseOrderNumber2_Click;
            // 
            // addSupplier
            // 
            addSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addSupplier.BackColor = Color.WhiteSmoke;
            addSupplier.IconChar = FontAwesome.Sharp.IconChar.Add;
            addSupplier.IconColor = SystemColors.ButtonShadow;
            addSupplier.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addSupplier.IconSize = 20;
            addSupplier.Location = new Point(1000, 138);
            addSupplier.Name = "addSupplier";
            addSupplier.Size = new Size(36, 36);
            addSupplier.TabIndex = 23;
            addSupplier.TextAlign = ContentAlignment.BottomLeft;
            addSupplier.UseVisualStyleBackColor = false;
            addSupplier.Click += addSupplier_Click;
            // 
            // scbxSupplier
            // 
            scbxSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            scbxSupplier.BackColor = Color.WhiteSmoke;
            scbxSupplier.BorderRadius = 15;
            scbxSupplier.BorderSize = 2;
            scbxSupplier.DrawMode = DrawMode.OwnerDrawFixed;
            scbxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            scbxSupplier.FlatStyle = FlatStyle.Flat;
            scbxSupplier.Font = new Font("Cairo", 10F);
            scbxSupplier.ForeColor = Color.FromArgb(64, 64, 64);
            scbxSupplier.FormattingEnabled = true;
            scbxSupplier.ItemHeight = 30;
            scbxSupplier.Items.AddRange(new object[] { "فلاتر", "بواجي", "فرامل", "تعليق", "تيل وسوائل" });
            scbxSupplier.Location = new Point(1042, 138);
            scbxSupplier.Name = "scbxSupplier";
            scbxSupplier.Required = true;
            scbxSupplier.RightToLeft = RightToLeft.Yes;
            scbxSupplier.Size = new Size(510, 36);
            scbxSupplier.TabIndex = 22;
            scbxSupplier.Tag = "";
            scbxSupplier.SelectedIndexChanged += scbxSupplier_SelectedIndexChanged;
            // 
            // sabraLabel7
            // 
            sabraLabel7.AutoSize = true;
            sabraLabel7.BackColor = Color.Transparent;
            sabraLabel7.Font = new Font("Cairo Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel7.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel7.Location = new Point(84, 92);
            sabraLabel7.Name = "sabraLabel7";
            sabraLabel7.RightToLeft = RightToLeft.Yes;
            sabraLabel7.Size = new Size(148, 32);
            sabraLabel7.TabIndex = 19;
            sabraLabel7.Text = "الموظف المسؤول";
            sabraLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel5
            // 
            sabraLabel5.AutoSize = true;
            sabraLabel5.BackColor = Color.Transparent;
            sabraLabel5.Font = new Font("Cairo Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel5.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel5.Location = new Point(345, 92);
            sabraLabel5.Name = "sabraLabel5";
            sabraLabel5.RightToLeft = RightToLeft.Yes;
            sabraLabel5.Size = new Size(113, 32);
            sabraLabel5.TabIndex = 16;
            sabraLabel5.Text = "رقم أمر الشراء";
            sabraLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel1.AutoSize = true;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.Font = new Font("Cairo", 10F);
            sabraLabel1.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel1.Location = new Point(1481, 103);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.Required = true;
            sabraLabel1.RightToLeft = RightToLeft.Yes;
            sabraLabel1.Size = new Size(69, 32);
            sabraLabel1.TabIndex = 12;
            sabraLabel1.Text = "المـــورد";
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.LightGray;
            panel1.Location = new Point(0, 62);
            panel1.Name = "panel1";
            panel1.Size = new Size(2775, 2);
            panel1.TabIndex = 5;
            // 
            // slblBasicInfoTitle
            // 
            slblBasicInfoTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblBasicInfoTitle.AutoSize = true;
            slblBasicInfoTitle.BackColor = Color.Transparent;
            slblBasicInfoTitle.Font = new Font("Cairo", 10F, FontStyle.Bold);
            slblBasicInfoTitle.ForeColor = Color.FromArgb(64, 64, 64);
            slblBasicInfoTitle.Location = new Point(1420, 15);
            slblBasicInfoTitle.Name = "slblBasicInfoTitle";
            slblBasicInfoTitle.RightToLeft = RightToLeft.Yes;
            slblBasicInfoTitle.Size = new Size(134, 32);
            slblBasicInfoTitle.TabIndex = 4;
            slblBasicInfoTitle.Text = "بيانات أمر الشراء";
            slblBasicInfoTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel2
            // 
            sabraPanel2.BackColor = Color.White;
            sabraPanel2.BorderColor = Color.DimGray;
            sabraPanel2.BorderRadius = 15;
            sabraPanel2.BorderSize = 1;
            sabraPanel2.Controls.Add(scbtnDeleteInvoice);
            sabraPanel2.Controls.Add(sbtnPrint);
            sabraPanel2.Controls.Add(sbtnExportAsExcel);
            sabraPanel2.Controls.Add(icnDecreasedParts);
            sabraPanel2.Controls.Add(slblTitleOfTopPanel);
            sabraPanel2.Controls.Add(lblNewPurchaseOrderNumber);
            sabraPanel2.Dock = DockStyle.Top;
            sabraPanel2.EnableHover = true;
            sabraPanel2.ForeColor = Color.Black;
            sabraPanel2.GradientAngle = 90F;
            sabraPanel2.GradientBottomColor = Color.White;
            sabraPanel2.GradientTopColor = Color.White;
            sabraPanel2.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel2.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel2.HoverBorderSize = 2;
            sabraPanel2.Location = new Point(10, 10);
            sabraPanel2.Name = "sabraPanel2";
            sabraPanel2.Size = new Size(1587, 111);
            sabraPanel2.TabIndex = 5;
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
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.MousePointer;
            icnDecreasedParts.IconColor = Color.RoyalBlue;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1499, 21);
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
            slblTitleOfTopPanel.Location = new Point(1289, 6);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(204, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "أمر شراء جديد";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNewPurchaseOrderNumber
            // 
            lblNewPurchaseOrderNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNewPurchaseOrderNumber.BackColor = Color.Transparent;
            lblNewPurchaseOrderNumber.Font = new Font("Cairo", 12F);
            lblNewPurchaseOrderNumber.ForeColor = SystemColors.WindowFrame;
            lblNewPurchaseOrderNumber.Location = new Point(1140, 62);
            lblNewPurchaseOrderNumber.Name = "lblNewPurchaseOrderNumber";
            lblNewPurchaseOrderNumber.RightToLeft = RightToLeft.Yes;
            lblNewPurchaseOrderNumber.Size = new Size(353, 37);
            lblNewPurchaseOrderNumber.TabIndex = 16;
            lblNewPurchaseOrderNumber.Text = "PO-0046 : رقم";
            lblNewPurchaseOrderNumber.TextAlign = ContentAlignment.MiddleRight;
            lblNewPurchaseOrderNumber.Click += lblNewPurchaseOrderNumber_Click;
            // 
            // sabraPanel3
            // 
            sabraPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraPanel3.BackColor = Color.White;
            sabraPanel3.BorderColor = Color.DimGray;
            sabraPanel3.BorderRadius = 15;
            sabraPanel3.BorderSize = 1;
            sabraPanel3.Controls.Add(sabraLabel6);
            sabraPanel3.Controls.Add(stbxAmount);
            sabraPanel3.Controls.Add(dgvPurchaseOrderDetails);
            sabraPanel3.Controls.Add(lblTotalPriceOfPurchaseOrders);
            sabraPanel3.Controls.Add(btnSearch);
            sabraPanel3.Controls.Add(stbxAddPart);
            sabraPanel3.Controls.Add(sabraLabel10);
            sabraPanel3.Controls.Add(panel2);
            sabraPanel3.Controls.Add(sabraLabel11);
            sabraPanel3.EnableHover = true;
            sabraPanel3.ForeColor = Color.Black;
            sabraPanel3.GradientAngle = 90F;
            sabraPanel3.GradientBottomColor = Color.White;
            sabraPanel3.GradientTopColor = Color.White;
            sabraPanel3.HoverBackColor = Color.White;
            sabraPanel3.HoverBorderColor = Color.DimGray;
            sabraPanel3.HoverBorderSize = 2;
            sabraPanel3.Location = new Point(20, 369);
            sabraPanel3.Margin = new Padding(20);
            sabraPanel3.Name = "sabraPanel3";
            sabraPanel3.Size = new Size(1577, 537);
            sabraPanel3.TabIndex = 6;
            // 
            // sabraLabel6
            // 
            sabraLabel6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel6.AutoSize = true;
            sabraLabel6.BackColor = Color.Transparent;
            sabraLabel6.Font = new Font("Cairo", 10F);
            sabraLabel6.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel6.Location = new Point(608, 79);
            sabraLabel6.Name = "sabraLabel6";
            sabraLabel6.RightToLeft = RightToLeft.Yes;
            sabraLabel6.Size = new Size(61, 32);
            sabraLabel6.TabIndex = 24;
            sabraLabel6.Text = "الكمية";
            sabraLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // stbxAmount
            // 
            stbxAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stbxAmount.BackColor = Color.White;
            stbxAmount.BorderColor = Color.DimGray;
            stbxAmount.Font = new Font("Cairo", 10F);
            stbxAmount.ForeColor = Color.FromArgb(64, 64, 64);
            stbxAmount.Location = new Point(593, 114);
            stbxAmount.Name = "stbxAmount";
            stbxAmount.Padding = new Padding(10, 7, 25, 7);
            stbxAmount.Required = true;
            stbxAmount.RightToLeft = RightToLeft.Yes;
            stbxAmount.SelectedText = "";
            stbxAmount.SelectionLength = 0;
            stbxAmount.SelectionStart = 0;
            stbxAmount.Size = new Size(96, 47);
            stbxAmount.TabIndex = 23;
            stbxAmount.TextAlign = HorizontalAlignment.Center;
            stbxAmount.Texts = "";
            stbxAmount.Load += stbxAmount_Load;
            // 
            // dgvPurchaseOrderDetails
            // 
            dgvPurchaseOrderDetails.AllowUserToAddRows = false;
            dgvPurchaseOrderDetails.AllowUserToDeleteRows = false;
            dgvPurchaseOrderDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvPurchaseOrderDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPurchaseOrderDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvPurchaseOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPurchaseOrderDetails.BackgroundColor = Color.White;
            dgvPurchaseOrderDetails.BorderStyle = BorderStyle.None;
            dgvPurchaseOrderDetails.ButtonBackColor = Color.White;
            dgvPurchaseOrderDetails.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvPurchaseOrderDetails.ButtonHoverColor = Color.FromArgb(238, 242, 255);
            dgvPurchaseOrderDetails.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPurchaseOrderDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPurchaseOrderDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPurchaseOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPurchaseOrderDetails.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPurchaseOrderDetails.EditableCellBackColor = Color.White;
            dgvPurchaseOrderDetails.EditableCellBorderColor = Color.FromArgb(203, 213, 225);
            dgvPurchaseOrderDetails.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvPurchaseOrderDetails.EnableHeadersVisualStyles = false;
            dgvPurchaseOrderDetails.Font = new Font("Cairo", 10F);
            dgvPurchaseOrderDetails.GridColor = Color.FromArgb(226, 232, 240);
            dgvPurchaseOrderDetails.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvPurchaseOrderDetails.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvPurchaseOrderDetails.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvPurchaseOrderDetails.HeaderHeight = 4;
            dgvPurchaseOrderDetails.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvPurchaseOrderDetails.Location = new Point(21, 188);
            dgvPurchaseOrderDetails.MultiSelect = false;
            dgvPurchaseOrderDetails.Name = "dgvPurchaseOrderDetails";
            dgvPurchaseOrderDetails.RightToLeft = RightToLeft.Yes;
            dgvPurchaseOrderDetails.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvPurchaseOrderDetails.RowBackColor = Color.White;
            dgvPurchaseOrderDetails.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPurchaseOrderDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPurchaseOrderDetails.RowHeadersVisible = false;
            dgvPurchaseOrderDetails.RowHeadersWidth = 51;
            dgvPurchaseOrderDetails.RowTemplate.Height = 42;
            dgvPurchaseOrderDetails.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvPurchaseOrderDetails.SelectionForeColor = Color.White;
            dgvPurchaseOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPurchaseOrderDetails.Size = new Size(1527, 274);
            dgvPurchaseOrderDetails.TabIndex = 22;
            // 
            // lblTotalPriceOfPurchaseOrders
            // 
            lblTotalPriceOfPurchaseOrders.BackColor = Color.Transparent;
            lblTotalPriceOfPurchaseOrders.Font = new Font("Cairo Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPriceOfPurchaseOrders.ForeColor = Color.RoyalBlue;
            lblTotalPriceOfPurchaseOrders.Location = new Point(27, 465);
            lblTotalPriceOfPurchaseOrders.Name = "lblTotalPriceOfPurchaseOrders";
            lblTotalPriceOfPurchaseOrders.RightToLeft = RightToLeft.Yes;
            lblTotalPriceOfPurchaseOrders.Size = new Size(184, 51);
            lblTotalPriceOfPurchaseOrders.TabIndex = 21;
            lblTotalPriceOfPurchaseOrders.Text = "الإجمالي: 1,720 ج";
            lblTotalPriceOfPurchaseOrders.TextAlign = ContentAlignment.MiddleRight;
            lblTotalPriceOfPurchaseOrders.Click += lblTotalPriceOfPurchaseOrders_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            btnSearch.Location = new Point(392, 114);
            btnSearch.Name = "btnSearch";
            btnSearch.NormalColor = Color.RoyalBlue;
            btnSearch.Size = new Size(149, 47);
            btnSearch.TabIndex = 19;
            btnSearch.Text = "بحث";
            btnSearch.TextAlign = ContentAlignment.MiddleLeft;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // stbxAddPart
            // 
            stbxAddPart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stbxAddPart.BackColor = Color.White;
            stbxAddPart.BorderColor = Color.DimGray;
            stbxAddPart.Font = new Font("Cairo", 10F);
            stbxAddPart.ForeColor = Color.FromArgb(64, 64, 64);
            stbxAddPart.Location = new Point(764, 114);
            stbxAddPart.Name = "stbxAddPart";
            stbxAddPart.Padding = new Padding(10, 7, 25, 7);
            stbxAddPart.PlaceholderText = "أبحث بأسم أو باركود";
            stbxAddPart.Required = true;
            stbxAddPart.RightToLeft = RightToLeft.Yes;
            stbxAddPart.SelectedText = "";
            stbxAddPart.SelectionLength = 0;
            stbxAddPart.SelectionStart = 0;
            stbxAddPart.Size = new Size(790, 47);
            stbxAddPart.TabIndex = 13;
            stbxAddPart.TextAlign = HorizontalAlignment.Center;
            stbxAddPart.Texts = "";
            stbxAddPart.Load += stbxAddPart_Load;
            // 
            // sabraLabel10
            // 
            sabraLabel10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel10.AutoSize = true;
            sabraLabel10.BackColor = Color.Transparent;
            sabraLabel10.Font = new Font("Cairo", 10F);
            sabraLabel10.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel10.Location = new Point(1444, 79);
            sabraLabel10.Name = "sabraLabel10";
            sabraLabel10.RightToLeft = RightToLeft.Yes;
            sabraLabel10.Size = new Size(106, 32);
            sabraLabel10.TabIndex = 12;
            sabraLabel10.Text = "إضافة قعطة";
            sabraLabel10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.LightGray;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(4181, 1);
            panel2.TabIndex = 5;
            // 
            // sabraLabel11
            // 
            sabraLabel11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel11.AutoSize = true;
            sabraLabel11.BackColor = Color.Transparent;
            sabraLabel11.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sabraLabel11.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel11.Location = new Point(1420, 15);
            sabraLabel11.Name = "sabraLabel11";
            sabraLabel11.RightToLeft = RightToLeft.Yes;
            sabraLabel11.Size = new Size(133, 32);
            sabraLabel11.TabIndex = 4;
            sabraLabel11.Text = "القطع المطلوبة";
            sabraLabel11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // spnlLastPanel
            // 
            spnlLastPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            spnlLastPanel.BackColor = Color.White;
            spnlLastPanel.BorderColor = Color.DimGray;
            spnlLastPanel.BorderRadius = 15;
            spnlLastPanel.BorderSize = 1;
            spnlLastPanel.Controls.Add(sbtnSaveAndSent);
            spnlLastPanel.Controls.Add(btnCancel);
            spnlLastPanel.Controls.Add(btnSaveAsDraft);
            spnlLastPanel.EnableHover = true;
            spnlLastPanel.ForeColor = Color.Black;
            spnlLastPanel.GradientAngle = 90F;
            spnlLastPanel.GradientBottomColor = Color.White;
            spnlLastPanel.GradientTopColor = Color.White;
            spnlLastPanel.HoverBackColor = Color.White;
            spnlLastPanel.HoverBorderColor = Color.Black;
            spnlLastPanel.HoverBorderSize = 2;
            spnlLastPanel.Location = new Point(13, 1222);
            spnlLastPanel.Name = "spnlLastPanel";
            spnlLastPanel.Size = new Size(1587, 122);
            spnlLastPanel.TabIndex = 7;
            // 
            // sbtnSaveAndSent
            // 
            sbtnSaveAndSent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbtnSaveAndSent.BackColor = Color.Green;
            sbtnSaveAndSent.BorderColor = Color.DodgerBlue;
            sbtnSaveAndSent.BorderRadius = 20;
            sbtnSaveAndSent.BorderSize = 0;
            sbtnSaveAndSent.FlatAppearance.BorderSize = 0;
            sbtnSaveAndSent.FlatStyle = FlatStyle.Flat;
            sbtnSaveAndSent.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnSaveAndSent.ForeColor = Color.White;
            sbtnSaveAndSent.HoverColor = Color.DarkGreen;
            sbtnSaveAndSent.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            sbtnSaveAndSent.IconColor = Color.Beige;
            sbtnSaveAndSent.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnSaveAndSent.IconSize = 30;
            sbtnSaveAndSent.ImageAlign = ContentAlignment.MiddleRight;
            sbtnSaveAndSent.Location = new Point(1353, 18);
            sbtnSaveAndSent.Name = "sbtnSaveAndSent";
            sbtnSaveAndSent.NormalColor = Color.Green;
            sbtnSaveAndSent.Padding = new Padding(10, 0, 10, 0);
            sbtnSaveAndSent.Size = new Size(218, 78);
            sbtnSaveAndSent.TabIndex = 22;
            sbtnSaveAndSent.Text = "حفظ وإرسال";
            sbtnSaveAndSent.TextAlign = ContentAlignment.MiddleLeft;
            sbtnSaveAndSent.UseVisualStyleBackColor = false;
            sbtnSaveAndSent.Click += btnSaveAndSent_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.Firebrick;
            btnCancel.BorderColor = Color.DodgerBlue;
            btnCancel.BorderRadius = 20;
            btnCancel.BorderSize = 0;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.HoverColor = Color.Crimson;
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnCancel.IconColor = Color.Beige;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.IconSize = 30;
            btnCancel.ImageAlign = ContentAlignment.MiddleRight;
            btnCancel.Location = new Point(928, 28);
            btnCancel.Name = "btnCancel";
            btnCancel.NormalColor = Color.Firebrick;
            btnCancel.Padding = new Padding(10, 0, 10, 0);
            btnCancel.Size = new Size(169, 59);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSaveAsDraft
            // 
            btnSaveAsDraft.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveAsDraft.BackColor = Color.RoyalBlue;
            btnSaveAsDraft.BorderColor = Color.DodgerBlue;
            btnSaveAsDraft.BorderRadius = 20;
            btnSaveAsDraft.BorderSize = 0;
            btnSaveAsDraft.FlatAppearance.BorderSize = 0;
            btnSaveAsDraft.FlatStyle = FlatStyle.Flat;
            btnSaveAsDraft.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnSaveAsDraft.ForeColor = Color.White;
            btnSaveAsDraft.HoverColor = Color.DodgerBlue;
            btnSaveAsDraft.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            btnSaveAsDraft.IconColor = Color.Beige;
            btnSaveAsDraft.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveAsDraft.IconSize = 30;
            btnSaveAsDraft.ImageAlign = ContentAlignment.MiddleRight;
            btnSaveAsDraft.Location = new Point(1116, 18);
            btnSaveAsDraft.Name = "btnSaveAsDraft";
            btnSaveAsDraft.NormalColor = Color.RoyalBlue;
            btnSaveAsDraft.Padding = new Padding(10, 0, 10, 0);
            btnSaveAsDraft.Size = new Size(218, 78);
            btnSaveAsDraft.TabIndex = 17;
            btnSaveAsDraft.Text = "حفظ مسودة";
            btnSaveAsDraft.TextAlign = ContentAlignment.MiddleLeft;
            btnSaveAsDraft.UseVisualStyleBackColor = false;
            btnSaveAsDraft.Click += btnSaveAsDraft_Click;
            // 
            // pnlNotesPanel
            // 
            pnlNotesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlNotesPanel.BackColor = Color.White;
            pnlNotesPanel.BorderColor = Color.DimGray;
            pnlNotesPanel.BorderRadius = 15;
            pnlNotesPanel.BorderSize = 0;
            pnlNotesPanel.Controls.Add(stbxNotes);
            pnlNotesPanel.Controls.Add(sabraLabel2);
            pnlNotesPanel.EnableHover = true;
            pnlNotesPanel.ForeColor = Color.Black;
            pnlNotesPanel.GradientAngle = 90F;
            pnlNotesPanel.GradientBottomColor = Color.White;
            pnlNotesPanel.GradientTopColor = Color.White;
            pnlNotesPanel.HoverBackColor = Color.White;
            pnlNotesPanel.HoverBorderColor = Color.DimGray;
            pnlNotesPanel.HoverBorderSize = 2;
            pnlNotesPanel.Location = new Point(20, 929);
            pnlNotesPanel.Margin = new Padding(3, 30, 3, 30);
            pnlNotesPanel.Name = "pnlNotesPanel";
            pnlNotesPanel.Size = new Size(1574, 260);
            pnlNotesPanel.TabIndex = 8;
            // 
            // stbxNotes
            // 
            stbxNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stbxNotes.AutoScroll = true;
            stbxNotes.BackColor = Color.White;
            stbxNotes.BorderColor = Color.DimGray;
            stbxNotes.Font = new Font("Cairo", 10F);
            stbxNotes.ForeColor = Color.FromArgb(64, 64, 64);
            stbxNotes.Location = new Point(29, 56);
            stbxNotes.Multiline = true;
            stbxNotes.Name = "stbxNotes";
            stbxNotes.Padding = new Padding(10, 7, 25, 7);
            stbxNotes.RightToLeft = RightToLeft.Yes;
            stbxNotes.SelectedText = "";
            stbxNotes.SelectionLength = 0;
            stbxNotes.SelectionStart = 0;
            stbxNotes.Size = new Size(1525, 147);
            stbxNotes.TabIndex = 14;
            stbxNotes.Texts = "";
            stbxNotes.Load += stbxNotes_Load;
            // 
            // sabraLabel2
            // 
            sabraLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel2.AutoSize = true;
            sabraLabel2.BackColor = Color.Transparent;
            sabraLabel2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sabraLabel2.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel2.Location = new Point(1457, 21);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.RightToLeft = RightToLeft.Yes;
            sabraLabel2.Size = new Size(93, 32);
            sabraLabel2.TabIndex = 5;
            sabraLabel2.Text = "مـــلاحظات";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ucNewPurchaseOrder
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            Controls.Add(spnlLastPanel);
            Controls.Add(pnlNotesPanel);
            Controls.Add(sabraPanel3);
            Controls.Add(sabraPanel2);
            Controls.Add(sabraPanel1);
            MinimumSize = new Size(900, 1420);
            Name = "ucNewPurchaseOrder";
            Size = new Size(1607, 1420);
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            sabraPanel2.ResumeLayout(false);
            sabraPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            sabraPanel3.ResumeLayout(false);
            sabraPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseOrderDetails).EndInit();
            spnlLastPanel.ResumeLayout(false);
            pnlNotesPanel.ResumeLayout(false);
            pnlNotesPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private FontAwesome.Sharp.IconButton addSupplier;
        private SabraLabel sabraLabel7;
        private SabraLabel sabraLabel5;
        private SabraComboBox scbxSupplier;
        private Panel panel1;
        private SabraLabel slblBasicInfoTitle;
        private SabraPanel sabraPanel2;
        private SabraButton scbtnDeleteInvoice;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblNewPurchaseOrderNumber;
        private SabraLabel lblNewPurchaseOrderNumber2;
        private SabraLabel slblResponsibleEmployee;
        private SabraLabel sabraLabel3;
        private SabraDateTimePicker dtpPurchaseOrderDate;
        private SabraLabel sabraLabel1;
        private SabraPanel sabraPanel3;
        private SabraLabel sabraLabel10;
        private Panel panel2;
        private SabraLabel sabraLabel11;
        private SabraTextBox stbxAddPart;
        private SabraLabel lblTotalPriceOfPurchaseOrders;
        private SabraButton btnSearch;
        private SabraPanel sabraPanel4;
        private SabraButton sabraButton1;
        private SabraButton sabraButton2;
        private SabraButton btnSaveAsDraft;
        private SabraButton btnCancel;
        private SabraPanel pnlNotesPanel;
        private SabraTextBox stbxNotes;
        private SabraLabel sabraLabel2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private SabraLabel sabraLabel4;
        private SabraButton sbtnSaveAndSent;
        private SabraPanel spnlLastPanel;
        private SabraDataGridView dgvPurchaseOrderDetails;
        private SabraLabel sabraLabel6;
        private SabraTextBox stbxAmount;
    }
}
