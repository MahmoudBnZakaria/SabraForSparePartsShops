namespace SabraForSpareParts.Screens
{
    partial class ucAdvances
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
            lblDescription = new SabraLabel();
            sbtnAddAdvance = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            dgvAdvances = new SabraDataGridView();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdvances).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(lblDescription);
            sabraPanel1.Controls.Add(sbtnAddAdvance);
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
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDescription.AutoSize = true;
            lblDescription.BackColor = Color.Transparent;
            lblDescription.Font = new Font("Cairo", 12F);
            lblDescription.ForeColor = SystemColors.WindowFrame;
            lblDescription.Location = new Point(1222, 63);
            lblDescription.Name = "lblDescription";
            lblDescription.RightToLeft = RightToLeft.Yes;
            lblDescription.Size = new Size(150, 37);
            lblDescription.TabIndex = 20;
            lblDescription.Text = "سلف الموظفين";
            lblDescription.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sbtnAddAdvance
            // 
            sbtnAddAdvance.BackColor = Color.RoyalBlue;
            sbtnAddAdvance.BorderColor = Color.DodgerBlue;
            sbtnAddAdvance.BorderRadius = 15;
            sbtnAddAdvance.BorderSize = 0;
            sbtnAddAdvance.FlatAppearance.BorderSize = 0;
            sbtnAddAdvance.FlatStyle = FlatStyle.Flat;
            sbtnAddAdvance.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnAddAdvance.ForeColor = Color.White;
            sbtnAddAdvance.HoverColor = Color.CornflowerBlue;
            sbtnAddAdvance.IconChar = FontAwesome.Sharp.IconChar.Add;
            sbtnAddAdvance.IconColor = Color.White;
            sbtnAddAdvance.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnAddAdvance.IconSize = 30;
            sbtnAddAdvance.ImageAlign = ContentAlignment.MiddleRight;
            sbtnAddAdvance.Location = new Point(49, 23);
            sbtnAddAdvance.Name = "sbtnAddAdvance";
            sbtnAddAdvance.NormalColor = Color.RoyalBlue;
            sbtnAddAdvance.Size = new Size(151, 64);
            sbtnAddAdvance.TabIndex = 19;
            sbtnAddAdvance.Text = "سلفة جديدة";
            sbtnAddAdvance.TextAlign = ContentAlignment.MiddleLeft;
            sbtnAddAdvance.UseVisualStyleBackColor = false;
            sbtnAddAdvance.Click += sbtnAddAdvance_Click;
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
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
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
            slblTitleOfTopPanel.Location = new Point(1258, 7);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(114, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "السلف";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvAdvances
            // 
            dgvAdvances.AllowUserToAddRows = false;
            dgvAdvances.AllowUserToDeleteRows = false;
            dgvAdvances.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvAdvances.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAdvances.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvAdvances.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdvances.BackgroundColor = Color.White;
            dgvAdvances.BorderStyle = BorderStyle.None;
            dgvAdvances.ButtonBackColor = Color.FromArgb(241, 245, 249);
            dgvAdvances.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvAdvances.ButtonHoverColor = Color.FromArgb(226, 232, 240);
            dgvAdvances.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAdvances.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAdvances.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAdvances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAdvances.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAdvances.EditableCellBackColor = Color.White;
            dgvAdvances.EditableCellBorderColor = Color.FromArgb(203, 213, 225);
            dgvAdvances.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvAdvances.EnableHeadersVisualStyles = false;
            dgvAdvances.Font = new Font("Cairo", 10F);
            dgvAdvances.GridColor = Color.FromArgb(226, 232, 240);
            dgvAdvances.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvAdvances.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvAdvances.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvAdvances.HeaderHeight = 4;
            dgvAdvances.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvAdvances.Location = new Point(10, 156);
            dgvAdvances.MultiSelect = false;
            dgvAdvances.Name = "dgvAdvances";
            dgvAdvances.RightToLeft = RightToLeft.Yes;
            dgvAdvances.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvAdvances.RowBackColor = Color.White;
            dgvAdvances.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvAdvances.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvAdvances.RowHeadersVisible = false;
            dgvAdvances.RowHeadersWidth = 51;
            dgvAdvances.RowTemplate.Height = 42;
            dgvAdvances.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvAdvances.SelectionForeColor = Color.White;
            dgvAdvances.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdvances.Size = new Size(1479, 813);
            dgvAdvances.TabIndex = 21;
            dgvAdvances.CellContentClick += dgvAdvances_CellContentClick;
            // 
            // ucAdvances
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvAdvances);
            Controls.Add(sabraPanel1);
            Name = "ucAdvances";
            Load += ucAdvances_Load;
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdvances).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraLabel lblDescription;
        private SabraButton sbtnAddAdvance;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraDataGridView dgvAdvances;
    }
}
