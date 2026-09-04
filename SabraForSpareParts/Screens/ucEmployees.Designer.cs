namespace SabraForSpareParts.Screens
{
    partial class ucEmployees
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
            lblNumberOfEmployees = new SabraLabel();
            sbtnAddEmployee = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            dgvEmployee = new SabraDataGridView();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(lblNumberOfEmployees);
            sabraPanel1.Controls.Add(sbtnAddEmployee);
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
            sabraPanel1.TabIndex = 7;
            // 
            // lblNumberOfEmployees
            // 
            lblNumberOfEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNumberOfEmployees.BackColor = Color.Transparent;
            lblNumberOfEmployees.Font = new Font("Cairo", 12F);
            lblNumberOfEmployees.ForeColor = SystemColors.WindowFrame;
            lblNumberOfEmployees.Location = new Point(1197, 63);
            lblNumberOfEmployees.Name = "lblNumberOfEmployees";
            lblNumberOfEmployees.RightToLeft = RightToLeft.Yes;
            lblNumberOfEmployees.Size = new Size(202, 37);
            lblNumberOfEmployees.TabIndex = 20;
            lblNumberOfEmployees.Text = "3 موظفين";
            lblNumberOfEmployees.TextAlign = ContentAlignment.MiddleRight;
            lblNumberOfEmployees.Click += lblNumberOfEmployees_Click;
            // 
            // sbtnAddEmployee
            // 
            sbtnAddEmployee.BackColor = Color.RoyalBlue;
            sbtnAddEmployee.BorderColor = Color.DodgerBlue;
            sbtnAddEmployee.BorderRadius = 15;
            sbtnAddEmployee.BorderSize = 0;
            sbtnAddEmployee.FlatAppearance.BorderSize = 0;
            sbtnAddEmployee.FlatStyle = FlatStyle.Flat;
            sbtnAddEmployee.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnAddEmployee.ForeColor = Color.White;
            sbtnAddEmployee.HoverColor = Color.CornflowerBlue;
            sbtnAddEmployee.IconChar = FontAwesome.Sharp.IconChar.Add;
            sbtnAddEmployee.IconColor = Color.White;
            sbtnAddEmployee.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnAddEmployee.IconSize = 30;
            sbtnAddEmployee.ImageAlign = ContentAlignment.MiddleRight;
            sbtnAddEmployee.Location = new Point(49, 23);
            sbtnAddEmployee.Name = "sbtnAddEmployee";
            sbtnAddEmployee.NormalColor = Color.RoyalBlue;
            sbtnAddEmployee.Size = new Size(151, 64);
            sbtnAddEmployee.TabIndex = 19;
            sbtnAddEmployee.Text = "إضافة موظف";
            sbtnAddEmployee.TextAlign = ContentAlignment.MiddleLeft;
            sbtnAddEmployee.UseVisualStyleBackColor = false;
            sbtnAddEmployee.Click += sbtnAddEmployee_Click;
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
            icnDecreasedParts.ForeColor = Color.DimGray;
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            icnDecreasedParts.IconColor = Color.DimGray;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 74;
            icnDecreasedParts.Location = new Point(1405, 23);
            icnDecreasedParts.Name = "icnDecreasedParts";
            icnDecreasedParts.Size = new Size(74, 77);
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
            slblTitleOfTopPanel.Location = new Point(1239, 7);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(160, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "الموظفين";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvEmployee
            // 
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.AllowUserToDeleteRows = false;
            dgvEmployee.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvEmployee.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployee.BackgroundColor = Color.White;
            dgvEmployee.BorderStyle = BorderStyle.None;
            dgvEmployee.ButtonBackColor = Color.FromArgb(241, 245, 249);
            dgvEmployee.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvEmployee.ButtonHoverColor = Color.FromArgb(226, 232, 240);
            dgvEmployee.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvEmployee.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvEmployee.DefaultCellStyle = dataGridViewCellStyle3;
            dgvEmployee.EditableCellBackColor = Color.White;
            dgvEmployee.EditableCellBorderColor = Color.FromArgb(203, 213, 225);
            dgvEmployee.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvEmployee.EnableHeadersVisualStyles = false;
            dgvEmployee.Font = new Font("Cairo", 10F);
            dgvEmployee.GridColor = Color.FromArgb(226, 232, 240);
            dgvEmployee.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvEmployee.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvEmployee.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvEmployee.HeaderHeight = 4;
            dgvEmployee.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvEmployee.Location = new Point(10, 156);
            dgvEmployee.MultiSelect = false;
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.RightToLeft = RightToLeft.Yes;
            dgvEmployee.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvEmployee.RowBackColor = Color.White;
            dgvEmployee.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvEmployee.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvEmployee.RowHeadersVisible = false;
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.RowTemplate.Height = 42;
            dgvEmployee.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvEmployee.SelectionForeColor = Color.White;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.Size = new Size(1479, 813);
            dgvEmployee.TabIndex = 21;
            dgvEmployee.CellContentClick += dgvEmployee_CellContentClick;
            // 
            // ucEmployees
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvEmployee);
            Controls.Add(sabraPanel1);
            Name = "ucEmployees";
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraLabel lblNumberOfEmployees;
        private SabraButton sbtnAddEmployee;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraDataGridView dgvEmployee;
    }
}
