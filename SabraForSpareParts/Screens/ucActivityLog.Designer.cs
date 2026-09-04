namespace SabraForSpareParts.Screens
{
    partial class ucActivityLog
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            sabraPanel1 = new SabraPanel();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            label = new SabraLabel();
            spnlDataGridViewOPtions = new SabraPanel();
            scbtnRestFilters = new SabraButton();
            btnSearch = new SabraButton();
            cmbxAllTransations = new SabraComboBox();
            cstbxUsers = new SabraComboBox();
            dgvLogActivity = new SabraDataGridView();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            sabraDateTimePickerFrom = new SabraDateTimePicker();
            sabraDateTimePickerTo = new SabraDateTimePicker();
            sabraLabel1 = new SabraLabel();
            sabraLabel2 = new SabraLabel();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            spnlDataGridViewOPtions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogActivity).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(sbtnPrint);
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(label);
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
            sabraPanel1.TabIndex = 2;
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
            sbtnPrint.Location = new Point(202, 39);
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
            sbtnExportAsExcel.Location = new Point(31, 39);
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
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.Archive;
            icnDecreasedParts.IconColor = Color.RoyalBlue;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1407, 25);
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
            slblTitleOfTopPanel.Location = new Point(1192, 10);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(209, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "سجل الأنشطة";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label
            // 
            label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Cairo", 12F);
            label.ForeColor = SystemColors.WindowFrame;
            label.Location = new Point(1238, 53);
            label.Name = "label";
            label.RightToLeft = RightToLeft.Yes;
            label.Size = new Size(163, 37);
            label.TabIndex = 16;
            label.Text = "كل عمليات النظام";
            label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // spnlDataGridViewOPtions
            // 
            spnlDataGridViewOPtions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            spnlDataGridViewOPtions.BackColor = Color.White;
            spnlDataGridViewOPtions.BorderColor = Color.LightGray;
            spnlDataGridViewOPtions.BorderRadius = 15;
            spnlDataGridViewOPtions.BorderSize = 0;
            spnlDataGridViewOPtions.Controls.Add(sabraLabel2);
            spnlDataGridViewOPtions.Controls.Add(sabraLabel1);
            spnlDataGridViewOPtions.Controls.Add(sabraDateTimePickerTo);
            spnlDataGridViewOPtions.Controls.Add(sabraDateTimePickerFrom);
            spnlDataGridViewOPtions.Controls.Add(scbtnRestFilters);
            spnlDataGridViewOPtions.Controls.Add(btnSearch);
            spnlDataGridViewOPtions.Controls.Add(cmbxAllTransations);
            spnlDataGridViewOPtions.Controls.Add(cstbxUsers);
            spnlDataGridViewOPtions.EnableHover = true;
            spnlDataGridViewOPtions.ForeColor = Color.Black;
            spnlDataGridViewOPtions.GradientAngle = 90F;
            spnlDataGridViewOPtions.GradientBottomColor = Color.White;
            spnlDataGridViewOPtions.GradientTopColor = Color.White;
            spnlDataGridViewOPtions.HoverBackColor = Color.FromArgb(245, 248, 255);
            spnlDataGridViewOPtions.HoverBorderColor = Color.FromArgb(37, 99, 235);
            spnlDataGridViewOPtions.HoverBorderSize = 2;
            spnlDataGridViewOPtions.Location = new Point(10, 144);
            spnlDataGridViewOPtions.Margin = new Padding(20);
            spnlDataGridViewOPtions.Name = "spnlDataGridViewOPtions";
            spnlDataGridViewOPtions.Size = new Size(1479, 112);
            spnlDataGridViewOPtions.TabIndex = 13;
            // 
            // scbtnRestFilters
            // 
            scbtnRestFilters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            scbtnRestFilters.BackColor = Color.DimGray;
            scbtnRestFilters.BorderColor = Color.DodgerBlue;
            scbtnRestFilters.BorderRadius = 20;
            scbtnRestFilters.BorderSize = 0;
            scbtnRestFilters.FlatAppearance.BorderSize = 0;
            scbtnRestFilters.FlatStyle = FlatStyle.Flat;
            scbtnRestFilters.Font = new Font("Cairo", 10F, FontStyle.Bold);
            scbtnRestFilters.ForeColor = Color.White;
            scbtnRestFilters.HoverColor = Color.CornflowerBlue;
            scbtnRestFilters.IconChar = FontAwesome.Sharp.IconChar.DeleteLeft;
            scbtnRestFilters.IconColor = Color.Beige;
            scbtnRestFilters.IconFont = FontAwesome.Sharp.IconFont.Auto;
            scbtnRestFilters.IconSize = 30;
            scbtnRestFilters.ImageAlign = ContentAlignment.MiddleRight;
            scbtnRestFilters.Location = new Point(175, 32);
            scbtnRestFilters.Name = "scbtnRestFilters";
            scbtnRestFilters.NormalColor = Color.DimGray;
            scbtnRestFilters.Padding = new Padding(10, 0, 10, 0);
            scbtnRestFilters.Size = new Size(117, 41);
            scbtnRestFilters.TabIndex = 20;
            scbtnRestFilters.Text = "مسح";
            scbtnRestFilters.TextAlign = ContentAlignment.MiddleLeft;
            scbtnRestFilters.UseVisualStyleBackColor = false;
            scbtnRestFilters.Click += scbtnRestFilters_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSearch.BackColor = Color.RoyalBlue;
            btnSearch.BorderColor = Color.DodgerBlue;
            btnSearch.BorderRadius = 20;
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
            btnSearch.Location = new Point(40, 28);
            btnSearch.Name = "btnSearch";
            btnSearch.NormalColor = Color.RoyalBlue;
            btnSearch.Size = new Size(129, 43);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "بحث";
            btnSearch.TextAlign = ContentAlignment.MiddleLeft;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbxAllTransations
            // 
            cmbxAllTransations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cmbxAllTransations.BackColor = Color.WhiteSmoke;
            cmbxAllTransations.DrawMode = DrawMode.OwnerDrawFixed;
            cmbxAllTransations.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxAllTransations.FlatStyle = FlatStyle.Flat;
            cmbxAllTransations.Font = new Font("Cairo", 10F);
            cmbxAllTransations.ForeColor = Color.FromArgb(64, 64, 64);
            cmbxAllTransations.FormattingEnabled = true;
            cmbxAllTransations.ItemHeight = 44;
            cmbxAllTransations.Items.AddRange(new object[] { "كل التصنيفات", "فرامل", "بواجي", "تعليق" });
            cmbxAllTransations.Location = new Point(990, 33);
            cmbxAllTransations.Name = "cmbxAllTransations";
            cmbxAllTransations.RightToLeft = RightToLeft.Yes;
            cmbxAllTransations.Size = new Size(216, 50);
            cmbxAllTransations.TabIndex = 17;
            cmbxAllTransations.SelectedIndexChanged += cmbxAllTransations_SelectedIndexChanged;
            // 
            // cstbxUsers
            // 
            cstbxUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cstbxUsers.BackColor = Color.WhiteSmoke;
            cstbxUsers.DrawMode = DrawMode.OwnerDrawFixed;
            cstbxUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            cstbxUsers.FlatStyle = FlatStyle.Flat;
            cstbxUsers.Font = new Font("Cairo", 10F);
            cstbxUsers.ForeColor = Color.FromArgb(64, 64, 64);
            cstbxUsers.FormattingEnabled = true;
            cstbxUsers.ItemHeight = 44;
            cstbxUsers.Items.AddRange(new object[] { "كل الحركات", "بيع", "مرتجع", "شراء", "تعديل يدوي" });
            cstbxUsers.Location = new Point(1238, 33);
            cstbxUsers.Name = "cstbxUsers";
            cstbxUsers.RightToLeft = RightToLeft.Yes;
            cstbxUsers.Size = new Size(205, 50);
            cstbxUsers.TabIndex = 14;
            cstbxUsers.SelectedIndexChanged += cstbxUsers_SelectedIndexChanged;
            // 
            // dgvLogActivity
            // 
            dgvLogActivity.AllowUserToAddRows = false;
            dgvLogActivity.AllowUserToDeleteRows = false;
            dgvLogActivity.AllowUserToOrderColumns = true;
            dgvLogActivity.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dgvLogActivity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvLogActivity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLogActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogActivity.BackgroundColor = Color.White;
            dgvLogActivity.BorderStyle = BorderStyle.None;
            dgvLogActivity.ButtonBackColor = Color.White;
            dgvLogActivity.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvLogActivity.ButtonHoverColor = Color.FromArgb(238, 242, 255);
            dgvLogActivity.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLogActivity.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle7.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle7.SelectionBackColor = Color.White;
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvLogActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvLogActivity.ColumnHeadersHeight = 45;
            dgvLogActivity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLogActivity.Columns.AddRange(new DataGridViewColumn[] { dataGridViewButtonColumn1 });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle9.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvLogActivity.DefaultCellStyle = dataGridViewCellStyle9;
            dgvLogActivity.EditableCellBackColor = Color.White;
            dgvLogActivity.EditableCellBorderColor = Color.FromArgb(203, 213, 225);
            dgvLogActivity.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvLogActivity.EnableHeadersVisualStyles = false;
            dgvLogActivity.Font = new Font("Cairo", 10F);
            dgvLogActivity.GridColor = Color.FromArgb(226, 232, 240);
            dgvLogActivity.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvLogActivity.HeaderBackColor = Color.White;
            dgvLogActivity.HeaderForeColor = Color.FromArgb(64, 64, 64);
            dgvLogActivity.HeaderHeight = 45;
            dgvLogActivity.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvLogActivity.Location = new Point(10, 287);
            dgvLogActivity.Margin = new Padding(20);
            dgvLogActivity.MultiSelect = false;
            dgvLogActivity.Name = "dgvLogActivity";
            dgvLogActivity.ReadOnly = true;
            dgvLogActivity.RightToLeft = RightToLeft.Yes;
            dgvLogActivity.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvLogActivity.RowBackColor = Color.White;
            dgvLogActivity.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Control;
            dataGridViewCellStyle10.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvLogActivity.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvLogActivity.RowHeadersVisible = false;
            dgvLogActivity.RowHeadersWidth = 51;
            dgvLogActivity.RowHeight = 40;
            dgvLogActivity.RowTemplate.Height = 40;
            dgvLogActivity.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvLogActivity.SelectionForeColor = Color.White;
            dgvLogActivity.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogActivity.Size = new Size(1475, 607);
            dgvLogActivity.TabIndex = 14;
            dgvLogActivity.CellContentClick += dgvLogActivity_CellContentClick;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewButtonColumn1.FlatStyle = FlatStyle.Flat;
            dataGridViewButtonColumn1.HeaderText = "الإجراءات";
            dataGridViewButtonColumn1.MinimumWidth = 6;
            dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            dataGridViewButtonColumn1.ReadOnly = true;
            dataGridViewButtonColumn1.Text = "عرض  تعديل  حركة";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // sabraDateTimePickerFrom
            // 
            sabraDateTimePickerFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraDateTimePickerFrom.BackColor = Color.Transparent;
            sabraDateTimePickerFrom.BorderColor = Color.FromArgb(220, 225, 230);
            sabraDateTimePickerFrom.BorderRadius = 12;
            sabraDateTimePickerFrom.BorderSize = 1;
            sabraDateTimePickerFrom.Checked = true;
            sabraDateTimePickerFrom.DateFormat = "dddd، dd MMMM yyyy";
            sabraDateTimePickerFrom.FocusedBorderColor = Color.FromArgb(0, 120, 212);
            sabraDateTimePickerFrom.Font = new Font("Cairo", 10F);
            sabraDateTimePickerFrom.Location = new Point(652, 33);
            sabraDateTimePickerFrom.MinimumSize = new Size(180, 45);
            sabraDateTimePickerFrom.Name = "sabraDateTimePickerFrom";
            sabraDateTimePickerFrom.RightToLeft = RightToLeft.Yes;
            sabraDateTimePickerFrom.ShowCheckBox = false;
            sabraDateTimePickerFrom.Size = new Size(275, 45);
            sabraDateTimePickerFrom.SkinColor = Color.White;
            sabraDateTimePickerFrom.TabIndex = 15;
            sabraDateTimePickerFrom.TextColor = Color.FromArgb(45, 45, 45);
            sabraDateTimePickerFrom.Value = new DateTime(2026, 8, 30, 0, 0, 0, 0);
            sabraDateTimePickerFrom.Load += sabraDateTimePickerFrom_Load;
            // 
            // sabraDateTimePickerTo
            // 
            sabraDateTimePickerTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraDateTimePickerTo.BackColor = Color.Transparent;
            sabraDateTimePickerTo.BorderColor = Color.FromArgb(220, 225, 230);
            sabraDateTimePickerTo.BorderRadius = 12;
            sabraDateTimePickerTo.BorderSize = 1;
            sabraDateTimePickerTo.Checked = true;
            sabraDateTimePickerTo.DateFormat = "dddd، dd MMMM yyyy";
            sabraDateTimePickerTo.FocusedBorderColor = Color.FromArgb(0, 120, 212);
            sabraDateTimePickerTo.Font = new Font("Cairo", 10F);
            sabraDateTimePickerTo.Location = new Point(333, 33);
            sabraDateTimePickerTo.MinimumSize = new Size(180, 45);
            sabraDateTimePickerTo.Name = "sabraDateTimePickerTo";
            sabraDateTimePickerTo.RightToLeft = RightToLeft.Yes;
            sabraDateTimePickerTo.ShowCheckBox = false;
            sabraDateTimePickerTo.Size = new Size(275, 45);
            sabraDateTimePickerTo.SkinColor = Color.White;
            sabraDateTimePickerTo.TabIndex = 21;
            sabraDateTimePickerTo.TextColor = Color.FromArgb(45, 45, 45);
            sabraDateTimePickerTo.Value = new DateTime(2026, 8, 30, 0, 0, 0, 0);
            sabraDateTimePickerTo.Load += sabraDateTimePickerTo_Load;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel1.AutoSize = true;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.Font = new Font("Cairo", 12F);
            sabraLabel1.ForeColor = SystemColors.WindowFrame;
            sabraLabel1.Location = new Point(933, 38);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.RightToLeft = RightToLeft.Yes;
            sabraLabel1.Size = new Size(44, 37);
            sabraLabel1.TabIndex = 22;
            sabraLabel1.Text = "من";
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel2
            // 
            sabraLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel2.AutoSize = true;
            sabraLabel2.BackColor = Color.Transparent;
            sabraLabel2.Font = new Font("Cairo", 12F);
            sabraLabel2.ForeColor = SystemColors.WindowFrame;
            sabraLabel2.Location = new Point(594, 38);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.RightToLeft = RightToLeft.Yes;
            sabraLabel2.Size = new Size(42, 37);
            sabraLabel2.TabIndex = 23;
            sabraLabel2.Text = "إلى";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ucActivityLog
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvLogActivity);
            Controls.Add(spnlDataGridViewOPtions);
            Controls.Add(sabraPanel1);
            Name = "ucActivityLog";
            Load += ucActivityLog_Load;
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            spnlDataGridViewOPtions.ResumeLayout(false);
            spnlDataGridViewOPtions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogActivity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel label;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private SabraPanel spnlDataGridViewOPtions;
        private SabraComboBox scbxBrand;
        private SabraComboBox cstbxUsers;
        private SabraComboBox cmbxAllTransations;
        private SabraButton btnSearch;
        private SabraDataGridView dgvLogActivity;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private SabraButton scbtnRestFilters;
        private SabraDateTimePicker sabraDateTimePickerFrom;
        private SabraDateTimePicker sabraDateTimePickerTo;
        private SabraLabel sabraLabel2;
        private SabraLabel sabraLabel1;
    }
}
