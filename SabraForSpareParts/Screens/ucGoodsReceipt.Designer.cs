namespace SabraForSpareParts.Screens
{
    partial class ucGoodsReceipt
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
            lblNumberAndtheSupplierOfTheOrder = new SabraLabel();
            sbtnNewPurchaseOrder = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            sabraPanel2 = new SabraPanel();
            dgvPurchaseOrderDetails = new SabraDataGridView();
            lblNewPurchaseOrderReciveDate = new SabraLabel();
            lblNewPurchaseOrderSupplier = new SabraLabel();
            lblNewPurchaseOrderNumber = new SabraLabel();
            sabraLabel3 = new SabraLabel();
            sabraLabel2 = new SabraLabel();
            sabraLabel1 = new SabraLabel();
            panel1 = new Panel();
            slblBasicInfoTitle = new SabraLabel();
            sabraPanel3 = new SabraPanel();
            scbtnCancel = new SabraButton();
            sabraButton1 = new SabraButton();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            sabraPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseOrderDetails).BeginInit();
            sabraPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(lblNumberAndtheSupplierOfTheOrder);
            sabraPanel1.Controls.Add(sbtnNewPurchaseOrder);
            sabraPanel1.Controls.Add(sbtnPrint);
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
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
            sabraPanel1.Size = new Size(1502, 117);
            sabraPanel1.TabIndex = 5;
            // 
            // lblNumberAndtheSupplierOfTheOrder
            // 
            lblNumberAndtheSupplierOfTheOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNumberAndtheSupplierOfTheOrder.AutoSize = true;
            lblNumberAndtheSupplierOfTheOrder.BackColor = Color.Transparent;
            lblNumberAndtheSupplierOfTheOrder.Font = new Font("Cairo", 12F);
            lblNumberAndtheSupplierOfTheOrder.ForeColor = SystemColors.WindowFrame;
            lblNumberAndtheSupplierOfTheOrder.Location = new Point(1134, 67);
            lblNumberAndtheSupplierOfTheOrder.Name = "lblNumberAndtheSupplierOfTheOrder";
            lblNumberAndtheSupplierOfTheOrder.RightToLeft = RightToLeft.Yes;
            lblNumberAndtheSupplierOfTheOrder.Size = new Size(257, 37);
            lblNumberAndtheSupplierOfTheOrder.TabIndex = 20;
            lblNumberAndtheSupplierOfTheOrder.Text = "PO-0045 — شركة بوش مصر";
            lblNumberAndtheSupplierOfTheOrder.TextAlign = ContentAlignment.MiddleRight;
            lblNumberAndtheSupplierOfTheOrder.Click += lblNumberAndtheSupplierOfTheOrder_Click;
            // 
            // sbtnNewPurchaseOrder
            // 
            sbtnNewPurchaseOrder.BackColor = Color.RoyalBlue;
            sbtnNewPurchaseOrder.BorderColor = Color.DodgerBlue;
            sbtnNewPurchaseOrder.BorderRadius = 15;
            sbtnNewPurchaseOrder.BorderSize = 0;
            sbtnNewPurchaseOrder.FlatAppearance.BorderSize = 0;
            sbtnNewPurchaseOrder.FlatStyle = FlatStyle.Flat;
            sbtnNewPurchaseOrder.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnNewPurchaseOrder.ForeColor = Color.White;
            sbtnNewPurchaseOrder.HoverColor = Color.CornflowerBlue;
            sbtnNewPurchaseOrder.IconChar = FontAwesome.Sharp.IconChar.Add;
            sbtnNewPurchaseOrder.IconColor = Color.White;
            sbtnNewPurchaseOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnNewPurchaseOrder.IconSize = 30;
            sbtnNewPurchaseOrder.ImageAlign = ContentAlignment.MiddleRight;
            sbtnNewPurchaseOrder.Location = new Point(49, 23);
            sbtnNewPurchaseOrder.Name = "sbtnNewPurchaseOrder";
            sbtnNewPurchaseOrder.NormalColor = Color.RoyalBlue;
            sbtnNewPurchaseOrder.Size = new Size(151, 64);
            sbtnNewPurchaseOrder.TabIndex = 19;
            sbtnNewPurchaseOrder.Text = "أمر شراء جديد";
            sbtnNewPurchaseOrder.TextAlign = ContentAlignment.MiddleLeft;
            sbtnNewPurchaseOrder.UseVisualStyleBackColor = false;
            sbtnNewPurchaseOrder.Click += sbtnNewPurchaseOrder_Click;
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
            icnDecreasedParts.ForeColor = SystemColors.Highlight;
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            icnDecreasedParts.IconColor = SystemColors.Highlight;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1407, 28);
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
            slblTitleOfTopPanel.Location = new Point(1153, 11);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(203, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "استلام بضاعة";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel2
            // 
            sabraPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraPanel2.BackColor = Color.White;
            sabraPanel2.BorderColor = Color.LightGray;
            sabraPanel2.BorderRadius = 15;
            sabraPanel2.BorderSize = 0;
            sabraPanel2.Controls.Add(dgvPurchaseOrderDetails);
            sabraPanel2.Controls.Add(lblNewPurchaseOrderReciveDate);
            sabraPanel2.Controls.Add(lblNewPurchaseOrderSupplier);
            sabraPanel2.Controls.Add(lblNewPurchaseOrderNumber);
            sabraPanel2.Controls.Add(sabraLabel3);
            sabraPanel2.Controls.Add(sabraLabel2);
            sabraPanel2.Controls.Add(sabraLabel1);
            sabraPanel2.Controls.Add(panel1);
            sabraPanel2.Controls.Add(slblBasicInfoTitle);
            sabraPanel2.EnableHover = true;
            sabraPanel2.ForeColor = Color.Black;
            sabraPanel2.GradientAngle = 90F;
            sabraPanel2.GradientBottomColor = Color.White;
            sabraPanel2.GradientTopColor = Color.White;
            sabraPanel2.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel2.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel2.HoverBorderSize = 2;
            sabraPanel2.Location = new Point(10, 159);
            sabraPanel2.Name = "sabraPanel2";
            sabraPanel2.Size = new Size(1479, 661);
            sabraPanel2.TabIndex = 6;
            // 
            // dgvPurchaseOrderDetails
            // 
            dgvPurchaseOrderDetails.AllowUserToAddRows = false;
            dgvPurchaseOrderDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvPurchaseOrderDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPurchaseOrderDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvPurchaseOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPurchaseOrderDetails.BackgroundColor = Color.White;
            dgvPurchaseOrderDetails.BorderStyle = BorderStyle.None;
            dgvPurchaseOrderDetails.ButtonBackColor = Color.FromArgb(241, 245, 249);
            dgvPurchaseOrderDetails.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvPurchaseOrderDetails.ButtonHoverColor = Color.FromArgb(226, 232, 240);
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
            dgvPurchaseOrderDetails.EnableHeadersVisualStyles = false;
            dgvPurchaseOrderDetails.Font = new Font("Cairo", 10F);
            dgvPurchaseOrderDetails.GridColor = Color.FromArgb(226, 232, 240);
            dgvPurchaseOrderDetails.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvPurchaseOrderDetails.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvPurchaseOrderDetails.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvPurchaseOrderDetails.HeaderHeight = 4;
            dgvPurchaseOrderDetails.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvPurchaseOrderDetails.Location = new Point(28, 213);
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
            dgvPurchaseOrderDetails.Size = new Size(1434, 412);
            dgvPurchaseOrderDetails.TabIndex = 28;
            dgvPurchaseOrderDetails.CellContentClick += dgvPurchaseOrderDetails_CellContentClick;
            // 
            // lblNewPurchaseOrderReciveDate
            // 
            lblNewPurchaseOrderReciveDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNewPurchaseOrderReciveDate.BackColor = Color.White;
            lblNewPurchaseOrderReciveDate.BorderColor = Color.DimGray;
            lblNewPurchaseOrderReciveDate.BorderSize = 3;
            lblNewPurchaseOrderReciveDate.Font = new Font("Cairo", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNewPurchaseOrderReciveDate.ForeColor = Color.DimGray;
            lblNewPurchaseOrderReciveDate.Location = new Point(74, 143);
            lblNewPurchaseOrderReciveDate.Name = "lblNewPurchaseOrderReciveDate";
            lblNewPurchaseOrderReciveDate.RightToLeft = RightToLeft.Yes;
            lblNewPurchaseOrderReciveDate.Size = new Size(268, 40);
            lblNewPurchaseOrderReciveDate.TabIndex = 27;
            lblNewPurchaseOrderReciveDate.Text = "PO-0046 ";
            lblNewPurchaseOrderReciveDate.TextAlign = ContentAlignment.MiddleCenter;
            lblNewPurchaseOrderReciveDate.Click += lblNewPurchaseOrderReciveDate_Click;
            // 
            // lblNewPurchaseOrderSupplier
            // 
            lblNewPurchaseOrderSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNewPurchaseOrderSupplier.BackColor = Color.White;
            lblNewPurchaseOrderSupplier.BorderColor = Color.DimGray;
            lblNewPurchaseOrderSupplier.BorderSize = 3;
            lblNewPurchaseOrderSupplier.Font = new Font("Cairo", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNewPurchaseOrderSupplier.ForeColor = Color.DimGray;
            lblNewPurchaseOrderSupplier.Location = new Point(401, 143);
            lblNewPurchaseOrderSupplier.Name = "lblNewPurchaseOrderSupplier";
            lblNewPurchaseOrderSupplier.RightToLeft = RightToLeft.Yes;
            lblNewPurchaseOrderSupplier.Size = new Size(787, 40);
            lblNewPurchaseOrderSupplier.TabIndex = 26;
            lblNewPurchaseOrderSupplier.Text = "PO-0046 ";
            lblNewPurchaseOrderSupplier.TextAlign = ContentAlignment.MiddleCenter;
            lblNewPurchaseOrderSupplier.Click += lblNewPurchaseOrderSupplier_Click;
            // 
            // lblNewPurchaseOrderNumber
            // 
            lblNewPurchaseOrderNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNewPurchaseOrderNumber.BackColor = Color.White;
            lblNewPurchaseOrderNumber.BorderColor = Color.DimGray;
            lblNewPurchaseOrderNumber.BorderSize = 3;
            lblNewPurchaseOrderNumber.Font = new Font("Cairo", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNewPurchaseOrderNumber.ForeColor = Color.DimGray;
            lblNewPurchaseOrderNumber.Location = new Point(1261, 143);
            lblNewPurchaseOrderNumber.Name = "lblNewPurchaseOrderNumber";
            lblNewPurchaseOrderNumber.RightToLeft = RightToLeft.Yes;
            lblNewPurchaseOrderNumber.Size = new Size(201, 40);
            lblNewPurchaseOrderNumber.TabIndex = 25;
            lblNewPurchaseOrderNumber.Text = "PO-0046 ";
            lblNewPurchaseOrderNumber.TextAlign = ContentAlignment.MiddleCenter;
            lblNewPurchaseOrderNumber.Click += lblNewPurchaseOrderNumber_Click;
            // 
            // sabraLabel3
            // 
            sabraLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel3.AutoSize = true;
            sabraLabel3.BackColor = Color.Transparent;
            sabraLabel3.Font = new Font("Cairo", 12F);
            sabraLabel3.ForeColor = SystemColors.WindowFrame;
            sabraLabel3.Location = new Point(218, 106);
            sabraLabel3.Name = "sabraLabel3";
            sabraLabel3.RightToLeft = RightToLeft.Yes;
            sabraLabel3.Size = new Size(124, 37);
            sabraLabel3.TabIndex = 23;
            sabraLabel3.Text = "تاريخ الاستلام";
            sabraLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel2
            // 
            sabraLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel2.AutoSize = true;
            sabraLabel2.BackColor = Color.Transparent;
            sabraLabel2.Font = new Font("Cairo", 12F);
            sabraLabel2.ForeColor = SystemColors.WindowFrame;
            sabraLabel2.Location = new Point(1119, 106);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.RightToLeft = RightToLeft.Yes;
            sabraLabel2.Size = new Size(69, 37);
            sabraLabel2.TabIndex = 22;
            sabraLabel2.Text = "المورد";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel1.AutoSize = true;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.Font = new Font("Cairo", 12F);
            sabraLabel1.ForeColor = SystemColors.WindowFrame;
            sabraLabel1.Location = new Point(1333, 106);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.RightToLeft = RightToLeft.Yes;
            sabraLabel1.Size = new Size(129, 37);
            sabraLabel1.TabIndex = 21;
            sabraLabel1.Text = "رقم أمر الشراء";
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.LightGray;
            panel1.Location = new Point(3, 79);
            panel1.Name = "panel1";
            panel1.Size = new Size(1459, 1);
            panel1.TabIndex = 7;
            // 
            // slblBasicInfoTitle
            // 
            slblBasicInfoTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblBasicInfoTitle.AutoSize = true;
            slblBasicInfoTitle.BackColor = Color.Transparent;
            slblBasicInfoTitle.Font = new Font("Cairo", 13F, FontStyle.Bold);
            slblBasicInfoTitle.ForeColor = Color.FromArgb(64, 64, 64);
            slblBasicInfoTitle.Location = new Point(1283, 18);
            slblBasicInfoTitle.Name = "slblBasicInfoTitle";
            slblBasicInfoTitle.RightToLeft = RightToLeft.Yes;
            slblBasicInfoTitle.Size = new Size(179, 42);
            slblBasicInfoTitle.TabIndex = 6;
            slblBasicInfoTitle.Text = "تفاصيل الاستلام";
            slblBasicInfoTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel3
            // 
            sabraPanel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sabraPanel3.BackColor = Color.White;
            sabraPanel3.BorderColor = Color.LightGray;
            sabraPanel3.BorderRadius = 15;
            sabraPanel3.BorderSize = 0;
            sabraPanel3.Controls.Add(scbtnCancel);
            sabraPanel3.Controls.Add(sabraButton1);
            sabraPanel3.EnableHover = true;
            sabraPanel3.ForeColor = Color.Black;
            sabraPanel3.GradientAngle = 90F;
            sabraPanel3.GradientBottomColor = Color.White;
            sabraPanel3.GradientTopColor = Color.White;
            sabraPanel3.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel3.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel3.HoverBorderSize = 2;
            sabraPanel3.Location = new Point(0, 903);
            sabraPanel3.Name = "sabraPanel3";
            sabraPanel3.Size = new Size(1502, 142);
            sabraPanel3.TabIndex = 7;
            // 
            // scbtnCancel
            // 
            scbtnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            scbtnCancel.BackColor = Color.Firebrick;
            scbtnCancel.BorderColor = Color.DodgerBlue;
            scbtnCancel.BorderRadius = 20;
            scbtnCancel.BorderSize = 0;
            scbtnCancel.FlatAppearance.BorderSize = 0;
            scbtnCancel.FlatStyle = FlatStyle.Flat;
            scbtnCancel.Font = new Font("Cairo", 10F, FontStyle.Bold);
            scbtnCancel.ForeColor = Color.White;
            scbtnCancel.HoverColor = Color.Crimson;
            scbtnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            scbtnCancel.IconColor = Color.Beige;
            scbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            scbtnCancel.IconSize = 30;
            scbtnCancel.ImageAlign = ContentAlignment.MiddleRight;
            scbtnCancel.Location = new Point(1014, 42);
            scbtnCancel.Name = "scbtnCancel";
            scbtnCancel.NormalColor = Color.Firebrick;
            scbtnCancel.Padding = new Padding(10, 0, 10, 0);
            scbtnCancel.Size = new Size(143, 57);
            scbtnCancel.TabIndex = 22;
            scbtnCancel.Text = "إلغاء";
            scbtnCancel.UseVisualStyleBackColor = false;
            scbtnCancel.Click += scbtnCancel_Click;
            // 
            // sabraButton1
            // 
            sabraButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraButton1.BackColor = Color.Green;
            sabraButton1.BorderColor = Color.DodgerBlue;
            sabraButton1.BorderRadius = 20;
            sabraButton1.BorderSize = 0;
            sabraButton1.FlatAppearance.BorderSize = 0;
            sabraButton1.FlatStyle = FlatStyle.Flat;
            sabraButton1.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sabraButton1.ForeColor = Color.White;
            sabraButton1.HoverColor = Color.CornflowerBlue;
            sabraButton1.IconChar = FontAwesome.Sharp.IconChar.FileSignature;
            sabraButton1.IconColor = Color.Beige;
            sabraButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sabraButton1.IconSize = 30;
            sabraButton1.ImageAlign = ContentAlignment.MiddleRight;
            sabraButton1.Location = new Point(1163, 34);
            sabraButton1.Name = "sabraButton1";
            sabraButton1.NormalColor = Color.Green;
            sabraButton1.Padding = new Padding(10, 0, 10, 0);
            sabraButton1.Size = new Size(326, 72);
            sabraButton1.TabIndex = 18;
            sabraButton1.Text = "تأكيد الاستلام و تحديث المخزون";
            sabraButton1.TextAlign = ContentAlignment.MiddleLeft;
            sabraButton1.UseVisualStyleBackColor = false;
            sabraButton1.Click += sabraButton1_Click;
            // 
            // ucGoodsReceipt
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sabraPanel3);
            Controls.Add(sabraPanel2);
            Controls.Add(sabraPanel1);
            Name = "ucGoodsReceipt";
            Load += ucGoodsReceipt_Load;
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            sabraPanel2.ResumeLayout(false);
            sabraPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseOrderDetails).EndInit();
            sabraPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraButton sbtnNewPurchaseOrder;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraPanel sabraPanel2;
        private SabraLabel lblNumberAndtheSupplierOfTheOrder;
        private SabraLabel sabraLabel3;
        private SabraLabel sabraLabel2;
        private SabraLabel sabraLabel1;
        private Panel panel1;
        private SabraLabel slblBasicInfoTitle;
        private SabraLabel lblNewPurchaseOrderNumber;
        private SabraLabel lblNewPurchaseOrderReciveDate;
        private SabraLabel lblNewPurchaseOrderSupplier;
        private SabraDataGridView dgvPurchaseOrderDetails;
        private SabraPanel sabraPanel3;
        private SabraButton sabraButton1;
        private SabraButton scbtnCancel;
    }
}
