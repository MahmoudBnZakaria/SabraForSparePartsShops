namespace SabraForSpareParts.Screens
{
    partial class ucVehicleCompatibility
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

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
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            slblTitleOfTopPanel = new SabraLabel();
            lblAlertsCount = new SabraLabel();
            sbtnAddCompatability = new SabraButton();
            spnlDataGridViewOPtions = new SabraPanel();
            sabraLabel2 = new SabraLabel();
            stxbPartInfo = new SabraTextBox();
            stxbYear = new SabraTextBox();
            sabraLabel1 = new SabraLabel();
            scbxBrand = new SabraComboBox();
            btnSearch = new SabraButton();
            stxbxModel = new SabraTextBox();
            sabraDataGridView1 = new SabraDataGridView();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            spnlDataGridViewOPtions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sabraDataGridView1).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(icnDecreasedParts);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(lblAlertsCount);
            sabraPanel1.Controls.Add(sbtnAddCompatability);
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
            sabraPanel1.Size = new Size(1663, 111);
            sabraPanel1.TabIndex = 1;
            // 
            // icnDecreasedParts
            // 
            icnDecreasedParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icnDecreasedParts.BackColor = Color.Transparent;
            icnDecreasedParts.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnDecreasedParts.ForeColor = Color.RoyalBlue;
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.Car;
            icnDecreasedParts.IconColor = Color.RoyalBlue;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1569, 25);
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
            slblTitleOfTopPanel.Location = new Point(1328, 10);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.Size = new Size(235, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "تواقف السيارات";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
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
            lblAlertsCount.Location = new Point(1373, 66);
            lblAlertsCount.Name = "lblAlertsCount";
            lblAlertsCount.Size = new Size(175, 37);
            lblAlertsCount.TabIndex = 16;
            lblAlertsCount.Text = "ربط القطع بالسيارات";
            lblAlertsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sbtnAddCompatability
            // 
            sbtnAddCompatability.BackColor = Color.RoyalBlue;
            sbtnAddCompatability.BorderColor = Color.DodgerBlue;
            sbtnAddCompatability.BorderRadius = 20;
            sbtnAddCompatability.BorderSize = 0;
            sbtnAddCompatability.FlatAppearance.BorderSize = 0;
            sbtnAddCompatability.FlatStyle = FlatStyle.Flat;
            sbtnAddCompatability.Font = new Font("Cairo", 12F, FontStyle.Bold);
            sbtnAddCompatability.ForeColor = Color.White;
            sbtnAddCompatability.HoverColor = Color.CornflowerBlue;
            sbtnAddCompatability.IconChar = FontAwesome.Sharp.IconChar.None;
            sbtnAddCompatability.IconColor = Color.Black;
            sbtnAddCompatability.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnAddCompatability.Location = new Point(25, 25);
            sbtnAddCompatability.Name = "sbtnAddCompatability";
            sbtnAddCompatability.NormalColor = Color.RoyalBlue;
            sbtnAddCompatability.Size = new Size(175, 50);
            sbtnAddCompatability.TabIndex = 17;
            sbtnAddCompatability.Text = "إضافة توافق";
            sbtnAddCompatability.UseVisualStyleBackColor = false;
            sbtnAddCompatability.Click += sbtnAddCompatability_Click;
            // 
            // spnlDataGridViewOPtions
            // 
            spnlDataGridViewOPtions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            spnlDataGridViewOPtions.BackColor = Color.White;
            spnlDataGridViewOPtions.BorderColor = Color.LightGray;
            spnlDataGridViewOPtions.BorderRadius = 15;
            spnlDataGridViewOPtions.BorderSize = 0;
            spnlDataGridViewOPtions.Controls.Add(sabraLabel2);
            spnlDataGridViewOPtions.Controls.Add(stxbPartInfo);
            spnlDataGridViewOPtions.Controls.Add(stxbYear);
            spnlDataGridViewOPtions.Controls.Add(sabraLabel1);
            spnlDataGridViewOPtions.Controls.Add(scbxBrand);
            spnlDataGridViewOPtions.Controls.Add(btnSearch);
            spnlDataGridViewOPtions.Controls.Add(stxbxModel);
            spnlDataGridViewOPtions.EnableHover = true;
            spnlDataGridViewOPtions.ForeColor = Color.Black;
            spnlDataGridViewOPtions.GradientAngle = 90F;
            spnlDataGridViewOPtions.GradientBottomColor = Color.White;
            spnlDataGridViewOPtions.GradientTopColor = Color.White;
            spnlDataGridViewOPtions.HoverBackColor = Color.FromArgb(245, 248, 255);
            spnlDataGridViewOPtions.HoverBorderColor = Color.FromArgb(37, 99, 235);
            spnlDataGridViewOPtions.HoverBorderSize = 2;
            spnlDataGridViewOPtions.Location = new Point(7, 144);
            spnlDataGridViewOPtions.Margin = new Padding(20);
            spnlDataGridViewOPtions.Name = "spnlDataGridViewOPtions";
            spnlDataGridViewOPtions.Size = new Size(1663, 112);
            spnlDataGridViewOPtions.TabIndex = 12;
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
            sabraLabel2.Location = new Point(596, 36);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.Size = new Size(136, 37);
            sabraLabel2.TabIndex = 20;
            sabraLabel2.Text = ":  بحث بالقطعة";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // stxbPartInfo
            // 
            stxbPartInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stxbPartInfo.BackColor = Color.WhiteSmoke;
            stxbPartInfo.BorderRadius = 15;
            stxbPartInfo.BorderSize = 2;
            stxbPartInfo.Font = new Font("Cairo", 10F);
            stxbPartInfo.ForeColor = Color.FromArgb(64, 64, 64);
            stxbPartInfo.Location = new Point(278, 35);
            stxbPartInfo.Name = "stxbPartInfo";
            stxbPartInfo.PlaceholderText = "اسم / باركود / رقم فني..";
            stxbPartInfo.RightToLeft = RightToLeft.Yes;
            stxbPartInfo.Size = new Size(312, 39);
            stxbPartInfo.TabIndex = 19;
            stxbPartInfo.TabStop = false;
            stxbPartInfo.Texts = "";
            // 
            // stxbYear
            // 
            stxbYear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stxbYear.BackColor = Color.WhiteSmoke;
            stxbYear.BorderSize = 2;
            stxbYear.Font = new Font("Cairo", 10F);
            stxbYear.ForeColor = Color.FromArgb(64, 64, 64);
            stxbYear.Location = new Point(898, 37);
            stxbYear.Name = "stxbYear";
            stxbYear.PlaceholderText = "السنة    ";
            stxbYear.RightToLeft = RightToLeft.Yes;
            stxbYear.Size = new Size(144, 39);
            stxbYear.TabIndex = 18;
            stxbYear.TabStop = false;
            stxbYear.Texts = "";
            stxbYear.TextChanged += stxbYear_TextChanged;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel1.AutoSize = true;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.BorderColor = Color.DodgerBlue;
            sabraLabel1.BorderRadius = 8;
            sabraLabel1.BorderSize = 0;
            sabraLabel1.Font = new Font("Cairo", 12F);
            sabraLabel1.ForeColor = SystemColors.WindowText;
            sabraLabel1.Location = new Point(1519, 37);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.Size = new Size(125, 37);
            sabraLabel1.TabIndex = 17;
            sabraLabel1.Text = ": بحث بالسيارة";
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
            scbxBrand.Location = new Point(1331, 38);
            scbxBrand.Name = "scbxBrand";
            scbxBrand.RightToLeft = RightToLeft.Yes;
            scbxBrand.Size = new Size(182, 36);
            scbxBrand.TabIndex = 13;
            scbxBrand.SelectedIndexChanged += scbxBrand_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            btnSearch.Location = new Point(49, 30);
            btnSearch.Name = "btnSearch";
            btnSearch.NormalColor = Color.RoyalBlue;
            btnSearch.Size = new Size(129, 43);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "بحث";
            btnSearch.TextAlign = ContentAlignment.MiddleLeft;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // stxbxModel
            // 
            stxbxModel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stxbxModel.BackColor = Color.WhiteSmoke;
            stxbxModel.BorderSize = 2;
            stxbxModel.Font = new Font("Cairo", 10F);
            stxbxModel.ForeColor = Color.FromArgb(64, 64, 64);
            stxbxModel.Location = new Point(1063, 38);
            stxbxModel.Name = "stxbxModel";
            stxbxModel.PlaceholderText = "الموديل...";
            stxbxModel.RightToLeft = RightToLeft.Yes;
            stxbxModel.Size = new Size(253, 39);
            stxbxModel.TabIndex = 12;
            stxbxModel.TabStop = false;
            stxbxModel.Texts = "";
            stxbxModel.TextChanged += stxbxModel_TextChanged;
            // 
            // sabraDataGridView1
            // 
            sabraDataGridView1.AllowUserToAddRows = false;
            sabraDataGridView1.AllowUserToDeleteRows = false;
            sabraDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            sabraDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            sabraDataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sabraDataGridView1.BackgroundColor = Color.White;
            sabraDataGridView1.BorderStyle = BorderStyle.None;
            sabraDataGridView1.ButtonBackColor = Color.White;
            sabraDataGridView1.ButtonForeColor = Color.FromArgb(51, 65, 85);
            sabraDataGridView1.ButtonHoverColor = Color.FromArgb(238, 242, 255);
            sabraDataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            sabraDataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            sabraDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            sabraDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            sabraDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            sabraDataGridView1.EnableHeadersVisualStyles = false;
            sabraDataGridView1.Font = new Font("Cairo", 10F);
            sabraDataGridView1.GridColor = Color.FromArgb(226, 232, 240);
            sabraDataGridView1.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            sabraDataGridView1.HeaderBackColor = Color.FromArgb(248, 250, 252);
            sabraDataGridView1.HeaderForeColor = Color.FromArgb(30, 41, 59);
            sabraDataGridView1.HeaderHeight = 4;
            sabraDataGridView1.HoverBackColor = Color.FromArgb(241, 245, 249);
            sabraDataGridView1.Location = new Point(10, 279);
            sabraDataGridView1.MultiSelect = false;
            sabraDataGridView1.Name = "sabraDataGridView1";
            sabraDataGridView1.ReadOnly = true;
            sabraDataGridView1.RightToLeft = RightToLeft.Yes;
            sabraDataGridView1.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            sabraDataGridView1.RowBackColor = Color.White;
            sabraDataGridView1.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            sabraDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            sabraDataGridView1.RowHeadersVisible = false;
            sabraDataGridView1.RowHeadersWidth = 51;
            sabraDataGridView1.RowTemplate.Height = 42;
            sabraDataGridView1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            sabraDataGridView1.SelectionForeColor = Color.White;
            sabraDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sabraDataGridView1.Size = new Size(1663, 673);
            sabraDataGridView1.TabIndex = 13;
            sabraDataGridView1.CellContentClick += sabraDataGridView1_CellContentClick;
            // 
            // ucVehicleCompatibility
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sabraDataGridView1);
            Controls.Add(spnlDataGridViewOPtions);
            Controls.Add(sabraPanel1);
            Name = "ucVehicleCompatibility";
            Size = new Size(1683, 1016);
            Load += ucVehicleCompatibility_Load;
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            spnlDataGridViewOPtions.ResumeLayout(false);
            spnlDataGridViewOPtions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sabraDataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblAlertsCount;
        private SabraButton sbtnAddCompatability;
        private SabraPanel spnlDataGridViewOPtions;
        private SabraButton btnSearch;
        private SabraComboBox scbxBrand;
        private SabraTextBox stxbxModel;
        private SabraLabel sabraLabel1;
        private SabraTextBox stxbYear;
        private SabraLabel sabraLabel2;
        private SabraTextBox stxbPartInfo;
        private SabraDataGridView sabraDataGridView1;
    }
}
