namespace SabraForSpareParts.Screens
{
    partial class ucPurchaseOrdersList
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
            sbtnNewPurchaseOrder = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            lblNumberOfInvoices = new SabraLabel();
            dgvPurchaseOrdars = new SabraDataGridView();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseOrdars).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(sbtnNewPurchaseOrder);
            sabraPanel1.Controls.Add(sbtnPrint);
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(lblNumberOfInvoices);
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
            sabraPanel1.Size = new Size(1502, 122);
            sabraPanel1.TabIndex = 4;
            // 
            // sbtnNewPurchaseOrder
            // 
            sbtnNewPurchaseOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            sbtnNewPurchaseOrder.BackColor = Color.RoyalBlue;
            sbtnNewPurchaseOrder.BorderColor = Color.DodgerBlue;
            sbtnNewPurchaseOrder.BorderRadius = 20;
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
            sbtnNewPurchaseOrder.Location = new Point(47, 28);
            sbtnNewPurchaseOrder.Name = "sbtnNewPurchaseOrder";
            sbtnNewPurchaseOrder.NormalColor = Color.RoyalBlue;
            sbtnNewPurchaseOrder.Size = new Size(151, 65);
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
            icnDecreasedParts.ForeColor = Color.RoyalBlue;
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            icnDecreasedParts.IconColor = Color.RoyalBlue;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1407, 24);
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
            slblTitleOfTopPanel.Location = new Point(1136, 9);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(265, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "قائمة أوامر الشراء";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNumberOfInvoices
            // 
            lblNumberOfInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNumberOfInvoices.AutoSize = true;
            lblNumberOfInvoices.BackColor = Color.Transparent;
            lblNumberOfInvoices.Font = new Font("Cairo", 12F);
            lblNumberOfInvoices.ForeColor = SystemColors.WindowFrame;
            lblNumberOfInvoices.Location = new Point(1248, 65);
            lblNumberOfInvoices.Name = "lblNumberOfInvoices";
            lblNumberOfInvoices.RightToLeft = RightToLeft.Yes;
            lblNumberOfInvoices.Size = new Size(109, 37);
            lblNumberOfInvoices.TabIndex = 16;
            lblNumberOfInvoices.Text = "46 أمر شراء";
            lblNumberOfInvoices.TextAlign = ContentAlignment.MiddleRight;
            lblNumberOfInvoices.Click += lblNumberOfInvoices_Click;
            // 
            // dgvPurchaseOrdars
            // 
            dgvPurchaseOrdars.AllowUserToAddRows = false;
            dgvPurchaseOrdars.AllowUserToDeleteRows = false;
            dgvPurchaseOrdars.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dgvPurchaseOrdars.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvPurchaseOrdars.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPurchaseOrdars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPurchaseOrdars.BackgroundColor = Color.White;
            dgvPurchaseOrdars.BorderStyle = BorderStyle.None;
            dgvPurchaseOrdars.ButtonBackColor = Color.FromArgb(241, 245, 249);
            dgvPurchaseOrdars.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvPurchaseOrdars.ButtonHoverColor = Color.FromArgb(226, 232, 240);
            dgvPurchaseOrdars.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPurchaseOrdars.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle6.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle6.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvPurchaseOrdars.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvPurchaseOrdars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle7.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvPurchaseOrdars.DefaultCellStyle = dataGridViewCellStyle7;
            dgvPurchaseOrdars.EditableCellBackColor = Color.White;
            dgvPurchaseOrdars.EditableCellBorderColor = Color.FromArgb(203, 213, 225);
            dgvPurchaseOrdars.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvPurchaseOrdars.EnableHeadersVisualStyles = false;
            dgvPurchaseOrdars.Font = new Font("Cairo", 10F);
            dgvPurchaseOrdars.GridColor = Color.FromArgb(226, 232, 240);
            dgvPurchaseOrdars.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvPurchaseOrdars.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvPurchaseOrdars.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvPurchaseOrdars.HeaderHeight = 4;
            dgvPurchaseOrdars.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvPurchaseOrdars.Location = new Point(27, 162);
            dgvPurchaseOrdars.MultiSelect = false;
            dgvPurchaseOrdars.Name = "dgvPurchaseOrdars";
            dgvPurchaseOrdars.RightToLeft = RightToLeft.Yes;
            dgvPurchaseOrdars.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvPurchaseOrdars.RowBackColor = Color.White;
            dgvPurchaseOrdars.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvPurchaseOrdars.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvPurchaseOrdars.RowHeadersVisible = false;
            dgvPurchaseOrdars.RowHeadersWidth = 51;
            dgvPurchaseOrdars.RowTemplate.Height = 42;
            dgvPurchaseOrdars.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvPurchaseOrdars.SelectionForeColor = Color.White;
            dgvPurchaseOrdars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPurchaseOrdars.Size = new Size(1442, 853);
            dgvPurchaseOrdars.TabIndex = 5;
            dgvPurchaseOrdars.CellContentClick += dgvPurchaseOrdars_CellContentClick;
            // 
            // ucPurchaseOrdersList
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvPurchaseOrdars);
            Controls.Add(sabraPanel1);
            Name = "ucPurchaseOrdersList";
            Load += ucPurchaseOrdersList_Load;
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseOrdars).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraButton sbtnNewPurchaseOrder;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblNumberOfInvoices;
        private SabraDataGridView dgvPurchaseOrdars;
    }
}
