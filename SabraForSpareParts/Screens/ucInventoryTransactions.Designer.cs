namespace SabraForSpareParts.Screens
{
    partial class ucInventoryTransactions
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            sabraPanel1 = new SabraPanel();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            lblAlertsCount = new SabraLabel();
            spnlDataGridViewOPtions = new SabraPanel();
            sabraDateTimePicker1 = new SabraDateTimePicker();
            scbtnRestFilters = new SabraButton();
            btnSearch = new SabraButton();
            smbxAllUsers = new SabraComboBox();
            cstbxMovements = new SabraComboBox();
            stxbxPartName = new SabraTextBox();
            dgvInventoryTransactions = new SabraDataGridView();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            spnlDataGridViewOPtions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventoryTransactions).BeginInit();
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
            sabraPanel1.Controls.Add(lblAlertsCount);
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
            sbtnPrint.Location = new Point(211, 23);
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
            sbtnExportAsExcel.Location = new Point(40, 23);
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
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.ArrowRightArrowLeft;
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
            slblTitleOfTopPanel.BorderColor = Color.DodgerBlue;
            slblTitleOfTopPanel.BorderRadius = 8;
            slblTitleOfTopPanel.BorderSize = 0;
            slblTitleOfTopPanel.Font = new Font("Cairo", 18F, FontStyle.Bold);
            slblTitleOfTopPanel.ForeColor = Color.FromArgb(40, 40, 40);
            slblTitleOfTopPanel.Location = new Point(1105, 10);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.Size = new Size(281, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "سجل حركة المخزون";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            slblTitleOfTopPanel.Click += slblTitleOfTopPanel_Click;
            // 
            // lblAlertsCount
            // 
            lblAlertsCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAlertsCount.AutoSize = true;
            lblAlertsCount.BackColor = Color.Transparent;
            lblAlertsCount.BorderColor = Color.DodgerBlue;
            lblAlertsCount.BorderRadius = 8;
            lblAlertsCount.BorderSize = 0;
            lblAlertsCount.Font = new Font("Cairo", 12F);
            lblAlertsCount.ForeColor = SystemColors.WindowFrame;
            lblAlertsCount.Location = new Point(1211, 66);
            lblAlertsCount.Name = "lblAlertsCount";
            lblAlertsCount.Size = new Size(178, 37);
            lblAlertsCount.TabIndex = 16;
            lblAlertsCount.Text = "كل تغير في الكميات";
            lblAlertsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // spnlDataGridViewOPtions
            // 
            spnlDataGridViewOPtions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            spnlDataGridViewOPtions.BackColor = Color.White;
            spnlDataGridViewOPtions.BorderColor = Color.LightGray;
            spnlDataGridViewOPtions.BorderRadius = 15;
            spnlDataGridViewOPtions.BorderSize = 0;
            spnlDataGridViewOPtions.Controls.Add(sabraDateTimePicker1);
            spnlDataGridViewOPtions.Controls.Add(scbtnRestFilters);
            spnlDataGridViewOPtions.Controls.Add(btnSearch);
            spnlDataGridViewOPtions.Controls.Add(smbxAllUsers);
            spnlDataGridViewOPtions.Controls.Add(cstbxMovements);
            spnlDataGridViewOPtions.Controls.Add(stxbxPartName);
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
            sabraDateTimePicker1.Location = new Point(647, 33);
            sabraDateTimePicker1.MinimumSize = new Size(180, 45);
            sabraDateTimePicker1.Name = "sabraDateTimePicker1";
            sabraDateTimePicker1.RightToLeft = RightToLeft.Yes;
            sabraDateTimePicker1.ShowCheckBox = false;
            sabraDateTimePicker1.Size = new Size(275, 45);
            sabraDateTimePicker1.SkinColor = Color.White;
            sabraDateTimePicker1.TabIndex = 15;
            sabraDateTimePicker1.TextColor = Color.FromArgb(45, 45, 45);
            sabraDateTimePicker1.Value = new DateTime(2026, 8, 30, 0, 0, 0, 0);
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
            // smbxAllUsers
            // 
            smbxAllUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            smbxAllUsers.BackColor = Color.WhiteSmoke;
            smbxAllUsers.DrawMode = DrawMode.OwnerDrawFixed;
            smbxAllUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            smbxAllUsers.FlatStyle = FlatStyle.Flat;
            smbxAllUsers.Font = new Font("Cairo", 10F);
            smbxAllUsers.ForeColor = Color.FromArgb(64, 64, 64);
            smbxAllUsers.FormattingEnabled = true;
            smbxAllUsers.ItemHeight = 30;
            smbxAllUsers.Items.AddRange(new object[] { "كل التصنيفات", "فرامل", "بواجي", "تعليق" });
            smbxAllUsers.Location = new Point(351, 37);
            smbxAllUsers.Name = "smbxAllUsers";
            smbxAllUsers.RightToLeft = RightToLeft.Yes;
            smbxAllUsers.Size = new Size(278, 36);
            smbxAllUsers.TabIndex = 17;
            smbxAllUsers.SelectedIndexChanged += smbxAllUsers_SelectedIndexChanged;
            // 
            // cstbxMovements
            // 
            cstbxMovements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cstbxMovements.BackColor = Color.WhiteSmoke;
            cstbxMovements.DrawMode = DrawMode.OwnerDrawFixed;
            cstbxMovements.DropDownStyle = ComboBoxStyle.DropDownList;
            cstbxMovements.FlatStyle = FlatStyle.Flat;
            cstbxMovements.Font = new Font("Cairo", 10F);
            cstbxMovements.ForeColor = Color.FromArgb(64, 64, 64);
            cstbxMovements.FormattingEnabled = true;
            cstbxMovements.ItemHeight = 30;
            cstbxMovements.Items.AddRange(new object[] { "كل الحركات", "بيع", "مرتجع", "شراء", "تعديل يدوي" });
            cstbxMovements.Location = new Point(940, 37);
            cstbxMovements.Name = "cstbxMovements";
            cstbxMovements.RightToLeft = RightToLeft.Yes;
            cstbxMovements.Size = new Size(234, 36);
            cstbxMovements.TabIndex = 14;
            cstbxMovements.SelectedIndexChanged += cstbxMovements_SelectedIndexChanged;
            // 
            // stxbxPartName
            // 
            stxbxPartName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            stxbxPartName.BackColor = Color.WhiteSmoke;
            stxbxPartName.BorderSize = 2;
            stxbxPartName.Font = new Font("Cairo", 10F);
            stxbxPartName.ForeColor = Color.FromArgb(64, 64, 64);
            stxbxPartName.Location = new Point(1192, 34);
            stxbxPartName.Name = "stxbxPartName";
            stxbxPartName.PlaceholderText = "اسم القعطة";
            stxbxPartName.RightToLeft = RightToLeft.Yes;
            stxbxPartName.Size = new Size(243, 39);
            stxbxPartName.TabIndex = 15;
            stxbxPartName.TabStop = false;
            stxbxPartName.Texts = "";
            stxbxPartName.TextChanged += stxbxPartName_TextChanged;
            // 
            // dgvInventoryTransactions
            // 
            dgvInventoryTransactions.AllowUserToAddRows = false;
            dgvInventoryTransactions.AllowUserToDeleteRows = false;
            dgvInventoryTransactions.AllowUserToOrderColumns = true;
            dgvInventoryTransactions.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvInventoryTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvInventoryTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInventoryTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventoryTransactions.BackgroundColor = Color.White;
            dgvInventoryTransactions.BorderStyle = BorderStyle.None;
            dgvInventoryTransactions.ButtonBackColor = Color.White;
            dgvInventoryTransactions.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvInventoryTransactions.ButtonHoverColor = Color.FromArgb(238, 242, 255);
            dgvInventoryTransactions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInventoryTransactions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvInventoryTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvInventoryTransactions.ColumnHeadersHeight = 45;
            dgvInventoryTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvInventoryTransactions.Columns.AddRange(new DataGridViewColumn[] { dataGridViewButtonColumn1 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvInventoryTransactions.DefaultCellStyle = dataGridViewCellStyle4;
            dgvInventoryTransactions.EnableHeadersVisualStyles = false;
            dgvInventoryTransactions.Font = new Font("Cairo", 10F);
            dgvInventoryTransactions.GridColor = Color.FromArgb(226, 232, 240);
            dgvInventoryTransactions.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvInventoryTransactions.HeaderBackColor = Color.White;
            dgvInventoryTransactions.HeaderForeColor = Color.FromArgb(64, 64, 64);
            dgvInventoryTransactions.HeaderHeight = 45;
            dgvInventoryTransactions.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvInventoryTransactions.Location = new Point(10, 287);
            dgvInventoryTransactions.Margin = new Padding(20);
            dgvInventoryTransactions.MultiSelect = false;
            dgvInventoryTransactions.Name = "dgvInventoryTransactions";
            dgvInventoryTransactions.ReadOnly = true;
            dgvInventoryTransactions.RightToLeft = RightToLeft.Yes;
            dgvInventoryTransactions.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvInventoryTransactions.RowBackColor = Color.White;
            dgvInventoryTransactions.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvInventoryTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvInventoryTransactions.RowHeadersVisible = false;
            dgvInventoryTransactions.RowHeadersWidth = 51;
            dgvInventoryTransactions.RowHeight = 40;
            dgvInventoryTransactions.RowTemplate.Height = 40;
            dgvInventoryTransactions.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvInventoryTransactions.SelectionForeColor = Color.White;
            dgvInventoryTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventoryTransactions.Size = new Size(1475, 607);
            dgvInventoryTransactions.TabIndex = 14;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewButtonColumn1.FlatStyle = FlatStyle.Flat;
            dataGridViewButtonColumn1.HeaderText = "الإجراءات";
            dataGridViewButtonColumn1.MinimumWidth = 6;
            dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            dataGridViewButtonColumn1.ReadOnly = true;
            dataGridViewButtonColumn1.Text = "عرض  تعديل  حركة";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // ucInventoryTransactions
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvInventoryTransactions);
            Controls.Add(spnlDataGridViewOPtions);
            Controls.Add(sabraPanel1);
            Name = "ucInventoryTransactions";
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            spnlDataGridViewOPtions.ResumeLayout(false);
            spnlDataGridViewOPtions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventoryTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblAlertsCount;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private SabraPanel spnlDataGridViewOPtions;
        private SabraComboBox scbxBrand;
        private SabraComboBox cstbxMovements;
        private SabraTextBox stxbxPartName;
        private SabraComboBox smbxAllUsers;
        private SabraButton btnSearch;
        private SabraDataGridView dgvInventoryTransactions;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private SabraButton scbtnRestFilters;
        private SabraDateTimePicker sabraDateTimePicker1;
    }
}
