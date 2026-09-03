namespace SabraForSpareParts.Screens
{
    partial class ucCustomers
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
            lblNumberAndtheSupplierOfTheOrder = new SabraLabel();
            sbtnAddCustomer = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            dgvCustomers = new SabraDataGridView();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(lblNumberAndtheSupplierOfTheOrder);
            sabraPanel1.Controls.Add(sbtnAddCustomer);
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
            sabraPanel1.Size = new Size(1502, 119);
            sabraPanel1.TabIndex = 6;
            // 
            // lblNumberAndtheSupplierOfTheOrder
            // 
            lblNumberAndtheSupplierOfTheOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNumberAndtheSupplierOfTheOrder.AutoSize = true;
            lblNumberAndtheSupplierOfTheOrder.BackColor = Color.Transparent;
            lblNumberAndtheSupplierOfTheOrder.Font = new Font("Cairo", 12F);
            lblNumberAndtheSupplierOfTheOrder.ForeColor = SystemColors.WindowFrame;
            lblNumberAndtheSupplierOfTheOrder.Location = new Point(1252, 63);
            lblNumberAndtheSupplierOfTheOrder.Name = "lblNumberAndtheSupplierOfTheOrder";
            lblNumberAndtheSupplierOfTheOrder.RightToLeft = RightToLeft.Yes;
            lblNumberAndtheSupplierOfTheOrder.Size = new Size(149, 37);
            lblNumberAndtheSupplierOfTheOrder.TabIndex = 20;
            lblNumberAndtheSupplierOfTheOrder.Text = "87 عميل مسجل";
            lblNumberAndtheSupplierOfTheOrder.TextAlign = ContentAlignment.MiddleRight;
            lblNumberAndtheSupplierOfTheOrder.Click += lblNumberAndtheSupplierOfTheOrder_Click;
            // 
            // sbtnAddCustomer
            // 
            sbtnAddCustomer.BackColor = Color.RoyalBlue;
            sbtnAddCustomer.BorderColor = Color.DodgerBlue;
            sbtnAddCustomer.BorderRadius = 15;
            sbtnAddCustomer.BorderSize = 0;
            sbtnAddCustomer.FlatAppearance.BorderSize = 0;
            sbtnAddCustomer.FlatStyle = FlatStyle.Flat;
            sbtnAddCustomer.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnAddCustomer.ForeColor = Color.White;
            sbtnAddCustomer.HoverColor = Color.CornflowerBlue;
            sbtnAddCustomer.IconChar = FontAwesome.Sharp.IconChar.Add;
            sbtnAddCustomer.IconColor = Color.White;
            sbtnAddCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnAddCustomer.IconSize = 30;
            sbtnAddCustomer.ImageAlign = ContentAlignment.MiddleRight;
            sbtnAddCustomer.Location = new Point(49, 23);
            sbtnAddCustomer.Name = "sbtnAddCustomer";
            sbtnAddCustomer.NormalColor = Color.RoyalBlue;
            sbtnAddCustomer.Size = new Size(151, 64);
            sbtnAddCustomer.TabIndex = 19;
            sbtnAddCustomer.Text = "إضافة عميل";
            sbtnAddCustomer.TextAlign = ContentAlignment.MiddleLeft;
            sbtnAddCustomer.UseVisualStyleBackColor = false;
            sbtnAddCustomer.Click += sbtnAddCustomer_Click;
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
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            icnDecreasedParts.IconColor = SystemColors.Highlight;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1407, 23);
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
            slblTitleOfTopPanel.Location = new Point(1263, 7);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(123, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "العملاء";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dgvCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.ButtonBackColor = Color.FromArgb(241, 245, 249);
            dgvCustomers.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvCustomers.ButtonHoverColor = Color.FromArgb(226, 232, 240);
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvCustomers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle6.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle6.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle7.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvCustomers.DefaultCellStyle = dataGridViewCellStyle7;
            dgvCustomers.EditableCellBackColor = Color.White;
            dgvCustomers.EditableCellBorderColor = Color.FromArgb(203, 213, 225);
            dgvCustomers.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.Font = new Font("Cairo", 10F);
            dgvCustomers.GridColor = Color.FromArgb(226, 232, 240);
            dgvCustomers.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvCustomers.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvCustomers.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvCustomers.HeaderHeight = 4;
            dgvCustomers.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvCustomers.Location = new Point(13, 159);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RightToLeft = RightToLeft.Yes;
            dgvCustomers.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvCustomers.RowBackColor = Color.White;
            dgvCustomers.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.RowTemplate.Height = 42;
            dgvCustomers.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvCustomers.SelectionForeColor = Color.White;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(1476, 831);
            dgvCustomers.TabIndex = 7;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // ucCustomers
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvCustomers);
            Controls.Add(sabraPanel1);
            Name = "ucCustomers";
            Load += ucCustomers_Load;
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraLabel lblNumberAndtheSupplierOfTheOrder;
        private SabraButton sbtnAddCustomer;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraDataGridView dgvCustomers;
    }
}
