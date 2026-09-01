namespace SabraForSpareParts.Screens
{
    partial class ucReturns
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
            sbtnAddNewReturn = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            lbl = new SabraLabel();
            sdgvReturns = new SabraDataGridView();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sdgvReturns).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(sbtnAddNewReturn);
            sabraPanel1.Controls.Add(sbtnPrint);
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(lbl);
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
            sabraPanel1.TabIndex = 4;
            // 
            // sbtnAddNewReturn
            // 
            sbtnAddNewReturn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            sbtnAddNewReturn.BackColor = Color.RoyalBlue;
            sbtnAddNewReturn.BorderColor = Color.DodgerBlue;
            sbtnAddNewReturn.BorderRadius = 20;
            sbtnAddNewReturn.BorderSize = 0;
            sbtnAddNewReturn.FlatAppearance.BorderSize = 0;
            sbtnAddNewReturn.FlatStyle = FlatStyle.Flat;
            sbtnAddNewReturn.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnAddNewReturn.ForeColor = Color.White;
            sbtnAddNewReturn.HoverColor = Color.CornflowerBlue;
            sbtnAddNewReturn.IconChar = FontAwesome.Sharp.IconChar.Add;
            sbtnAddNewReturn.IconColor = Color.White;
            sbtnAddNewReturn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnAddNewReturn.IconSize = 30;
            sbtnAddNewReturn.ImageAlign = ContentAlignment.MiddleRight;
            sbtnAddNewReturn.Location = new Point(47, 20);
            sbtnAddNewReturn.Name = "sbtnAddNewReturn";
            sbtnAddNewReturn.NormalColor = Color.RoyalBlue;
            sbtnAddNewReturn.Size = new Size(151, 70);
            sbtnAddNewReturn.TabIndex = 19;
            sbtnAddNewReturn.Text = "مرتجع جديد";
            sbtnAddNewReturn.TextAlign = ContentAlignment.MiddleLeft;
            sbtnAddNewReturn.UseVisualStyleBackColor = false;
            sbtnAddNewReturn.Click += sbtnAddNewReturn_Click;
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
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.Retweet;
            icnDecreasedParts.IconColor = Color.RoyalBlue;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1522, 25);
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
            slblTitleOfTopPanel.Location = new Point(1356, 20);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.Size = new Size(160, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "المرتجعات";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl
            // 
            lbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            lbl.BorderColor = Color.DodgerBlue;
            lbl.BorderRadius = 8;
            lbl.BorderSize = 0;
            lbl.Font = new Font("Cairo", 12F);
            lbl.ForeColor = SystemColors.WindowFrame;
            lbl.Location = new Point(1353, 64);
            lbl.Name = "lbl";
            lbl.Size = new Size(163, 37);
            lbl.TabIndex = 16;
            lbl.Text = "تسجل إرجاع القطع";
            lbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sdgvReturns
            // 
            sdgvReturns.AllowUserToAddRows = false;
            sdgvReturns.AllowUserToDeleteRows = false;
            sdgvReturns.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            sdgvReturns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            sdgvReturns.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sdgvReturns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sdgvReturns.BackgroundColor = Color.White;
            sdgvReturns.BorderStyle = BorderStyle.None;
            sdgvReturns.ButtonBackColor = Color.White;
            sdgvReturns.ButtonForeColor = Color.FromArgb(51, 65, 85);
            sdgvReturns.ButtonHoverColor = Color.FromArgb(238, 242, 255);
            sdgvReturns.CellBorderStyle = DataGridViewCellBorderStyle.None;
            sdgvReturns.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            sdgvReturns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            sdgvReturns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            sdgvReturns.DefaultCellStyle = dataGridViewCellStyle3;
            sdgvReturns.EnableHeadersVisualStyles = false;
            sdgvReturns.Font = new Font("Cairo", 10F);
            sdgvReturns.GridColor = Color.FromArgb(226, 232, 240);
            sdgvReturns.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            sdgvReturns.HeaderBackColor = Color.FromArgb(248, 250, 252);
            sdgvReturns.HeaderForeColor = Color.FromArgb(30, 41, 59);
            sdgvReturns.HeaderHeight = 4;
            sdgvReturns.HoverBackColor = Color.FromArgb(241, 245, 249);
            sdgvReturns.Location = new Point(10, 149);
            sdgvReturns.MultiSelect = false;
            sdgvReturns.Name = "sdgvReturns";
            sdgvReturns.ReadOnly = true;
            sdgvReturns.RightToLeft = RightToLeft.Yes;
            sdgvReturns.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            sdgvReturns.RowBackColor = Color.White;
            sdgvReturns.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            sdgvReturns.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            sdgvReturns.RowHeadersVisible = false;
            sdgvReturns.RowHeadersWidth = 51;
            sdgvReturns.RowTemplate.Height = 42;
            sdgvReturns.SelectionBackColor = Color.FromArgb(30, 58, 138);
            sdgvReturns.SelectionForeColor = Color.White;
            sdgvReturns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sdgvReturns.Size = new Size(1605, 768);
            sdgvReturns.TabIndex = 5;
            sdgvReturns.CellContentClick += sdgvReturns_CellContentClick;
            // 
            // ucReturns
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sdgvReturns);
            Controls.Add(sabraPanel1);
            Name = "ucReturns";
            Size = new Size(1628, 1045);
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            ((System.ComponentModel.ISupportInitialize)sdgvReturns).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraButton sbtnAddNewReturn;
        private SabraButton sbtnPrint;
        private SabraButton sbtnExportAsExcel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lbl;
        private SabraDataGridView sdgvReturns;
    }
}
