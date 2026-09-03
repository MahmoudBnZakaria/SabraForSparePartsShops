namespace SabraForSpareParts.Screens
{
    partial class ucTreasury
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
            lblNumberOfInvoices = new SabraLabel();
            slblTitleOfTopPanel = new SabraLabel();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            sbtnExportAsExcel = new SabraButton();
            sbtnPrint = new SabraButton();
            sbtnWithdrawal = new SabraButton();
            sbtnDeposit = new SabraButton();
            sabraPanel1 = new SabraPanel();
            sabraPanel2 = new SabraPanel();
            sbtnSearch = new SabraButton();
            sabraLabel4 = new SabraLabel();
            sabraLabel3 = new SabraLabel();
            dtpTo = new SabraDateTimePicker();
            dtpFrom = new SabraDateTimePicker();
            smbxClassification = new SabraComboBox();
            sabraPanel3 = new SabraPanel();
            lblNetBalance = new SabraLabel();
            TotalWithdrawals = new SabraLabel();
            lblTotalDeposits = new SabraLabel();
            sabraLabel6 = new SabraLabel();
            sabraLabel5 = new SabraLabel();
            panel2 = new Panel();
            sabraLabel2 = new SabraLabel();
            panel1 = new Panel();
            sabraLabel7 = new SabraLabel();
            pnlTreasuryBalance = new SabraPanel();
            lblTreasuryBalance = new SabraLabel();
            sabraLabel1 = new SabraLabel();
            dgvTreasury = new SabraDataGridView();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            sabraPanel1.SuspendLayout();
            sabraPanel2.SuspendLayout();
            sabraPanel3.SuspendLayout();
            pnlTreasuryBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTreasury).BeginInit();
            SuspendLayout();
            // 
            // lblNumberOfInvoices
            // 
            lblNumberOfInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNumberOfInvoices.AutoSize = true;
            lblNumberOfInvoices.BackColor = Color.Transparent;
            lblNumberOfInvoices.Font = new Font("Cairo", 12F);
            lblNumberOfInvoices.ForeColor = SystemColors.WindowFrame;
            lblNumberOfInvoices.Location = new Point(1218, 63);
            lblNumberOfInvoices.Name = "lblNumberOfInvoices";
            lblNumberOfInvoices.RightToLeft = RightToLeft.Yes;
            lblNumberOfInvoices.Size = new Size(163, 37);
            lblNumberOfInvoices.TabIndex = 16;
            lblNumberOfInvoices.Text = "كل حركات المالية ";
            lblNumberOfInvoices.TextAlign = ContentAlignment.MiddleRight;
            // 
            // slblTitleOfTopPanel
            // 
            slblTitleOfTopPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblTitleOfTopPanel.AutoSize = true;
            slblTitleOfTopPanel.BackColor = Color.Transparent;
            slblTitleOfTopPanel.Font = new Font("Cairo", 18F, FontStyle.Bold);
            slblTitleOfTopPanel.ForeColor = Color.FromArgb(40, 40, 40);
            slblTitleOfTopPanel.Location = new Point(1271, 9);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(110, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "الخزانة";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // icnDecreasedParts
            // 
            icnDecreasedParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icnDecreasedParts.BackColor = Color.Transparent;
            icnDecreasedParts.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnDecreasedParts.ForeColor = Color.RoyalBlue;
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTrendUp;
            icnDecreasedParts.IconColor = Color.RoyalBlue;
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 65;
            icnDecreasedParts.Location = new Point(1398, 35);
            icnDecreasedParts.Name = "icnDecreasedParts";
            icnDecreasedParts.Size = new Size(72, 65);
            icnDecreasedParts.SizeMode = PictureBoxSizeMode.Zoom;
            icnDecreasedParts.TabIndex = 14;
            icnDecreasedParts.TabStop = false;
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
            sbtnExportAsExcel.HoverColor = Color.Lime;
            sbtnExportAsExcel.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            sbtnExportAsExcel.IconColor = Color.Beige;
            sbtnExportAsExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnExportAsExcel.IconSize = 30;
            sbtnExportAsExcel.ImageAlign = ContentAlignment.MiddleRight;
            sbtnExportAsExcel.Location = new Point(315, 63);
            sbtnExportAsExcel.Name = "sbtnExportAsExcel";
            sbtnExportAsExcel.NormalColor = Color.Green;
            sbtnExportAsExcel.Padding = new Padding(10, 0, 10, 0);
            sbtnExportAsExcel.Size = new Size(157, 56);
            sbtnExportAsExcel.TabIndex = 17;
            sbtnExportAsExcel.Text = "تصدير Excel";
            sbtnExportAsExcel.TextAlign = ContentAlignment.MiddleLeft;
            sbtnExportAsExcel.UseVisualStyleBackColor = false;
            sbtnExportAsExcel.Click += sbtnExportAsExcel_Click;
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
            sbtnPrint.Location = new Point(329, 16);
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
            // sbtnWithdrawal
            // 
            sbtnWithdrawal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            sbtnWithdrawal.BackColor = Color.Brown;
            sbtnWithdrawal.BorderColor = Color.DodgerBlue;
            sbtnWithdrawal.BorderRadius = 20;
            sbtnWithdrawal.BorderSize = 0;
            sbtnWithdrawal.FlatAppearance.BorderSize = 0;
            sbtnWithdrawal.FlatStyle = FlatStyle.Flat;
            sbtnWithdrawal.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnWithdrawal.ForeColor = Color.White;
            sbtnWithdrawal.HoverColor = Color.Red;
            sbtnWithdrawal.IconChar = FontAwesome.Sharp.IconChar.Subtract;
            sbtnWithdrawal.IconColor = Color.White;
            sbtnWithdrawal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnWithdrawal.IconSize = 30;
            sbtnWithdrawal.ImageAlign = ContentAlignment.MiddleRight;
            sbtnWithdrawal.Location = new Point(153, 35);
            sbtnWithdrawal.Name = "sbtnWithdrawal";
            sbtnWithdrawal.NormalColor = Color.Brown;
            sbtnWithdrawal.Size = new Size(103, 57);
            sbtnWithdrawal.TabIndex = 19;
            sbtnWithdrawal.Text = "سحب";
            sbtnWithdrawal.TextAlign = ContentAlignment.MiddleLeft;
            sbtnWithdrawal.UseVisualStyleBackColor = false;
            sbtnWithdrawal.Click += sbtnWithdrawal_Click;
            // 
            // sbtnDeposit
            // 
            sbtnDeposit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            sbtnDeposit.BackColor = Color.DarkGreen;
            sbtnDeposit.BorderColor = Color.DodgerBlue;
            sbtnDeposit.BorderRadius = 20;
            sbtnDeposit.BorderSize = 0;
            sbtnDeposit.FlatAppearance.BorderSize = 0;
            sbtnDeposit.FlatStyle = FlatStyle.Flat;
            sbtnDeposit.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnDeposit.ForeColor = Color.White;
            sbtnDeposit.HoverColor = Color.Lime;
            sbtnDeposit.IconChar = FontAwesome.Sharp.IconChar.Add;
            sbtnDeposit.IconColor = Color.White;
            sbtnDeposit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnDeposit.IconSize = 30;
            sbtnDeposit.ImageAlign = ContentAlignment.MiddleRight;
            sbtnDeposit.Location = new Point(25, 35);
            sbtnDeposit.Name = "sbtnDeposit";
            sbtnDeposit.NormalColor = Color.DarkGreen;
            sbtnDeposit.Size = new Size(108, 57);
            sbtnDeposit.TabIndex = 20;
            sbtnDeposit.Text = "إيداع";
            sbtnDeposit.TextAlign = ContentAlignment.MiddleLeft;
            sbtnDeposit.UseVisualStyleBackColor = false;
            sbtnDeposit.Click += sbtnDeposit_Click;
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(sbtnDeposit);
            sabraPanel1.Controls.Add(sbtnWithdrawal);
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
            sabraPanel1.HoverBorderColor = Color.FromArgb(64, 64, 64);
            sabraPanel1.HoverBorderSize = 2;
            sabraPanel1.Location = new Point(10, 10);
            sabraPanel1.Name = "sabraPanel1";
            sabraPanel1.Size = new Size(1502, 131);
            sabraPanel1.TabIndex = 5;
            // 
            // sabraPanel2
            // 
            sabraPanel2.BackColor = SystemColors.Window;
            sabraPanel2.BorderColor = Color.LightGray;
            sabraPanel2.BorderRadius = 10;
            sabraPanel2.BorderSize = 0;
            sabraPanel2.Controls.Add(sbtnSearch);
            sabraPanel2.Controls.Add(sabraLabel4);
            sabraPanel2.Controls.Add(sabraLabel3);
            sabraPanel2.Controls.Add(dtpTo);
            sabraPanel2.Controls.Add(dtpFrom);
            sabraPanel2.Controls.Add(smbxClassification);
            sabraPanel2.Dock = DockStyle.Top;
            sabraPanel2.EnableHover = true;
            sabraPanel2.ForeColor = Color.Black;
            sabraPanel2.GradientAngle = 90F;
            sabraPanel2.GradientBottomColor = Color.White;
            sabraPanel2.GradientTopColor = Color.White;
            sabraPanel2.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel2.HoverBorderColor = Color.FromArgb(64, 64, 64);
            sabraPanel2.HoverBorderSize = 2;
            sabraPanel2.Location = new Point(406, 141);
            sabraPanel2.Margin = new Padding(20);
            sabraPanel2.Name = "sabraPanel2";
            sabraPanel2.Size = new Size(1106, 98);
            sabraPanel2.TabIndex = 30;
            sabraPanel2.Paint += sabraPanel2_Paint;
            // 
            // sbtnSearch
            // 
            sbtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbtnSearch.BackColor = Color.RoyalBlue;
            sbtnSearch.BorderColor = Color.DodgerBlue;
            sbtnSearch.BorderRadius = 10;
            sbtnSearch.BorderSize = 0;
            sbtnSearch.FlatAppearance.BorderSize = 0;
            sbtnSearch.FlatStyle = FlatStyle.Flat;
            sbtnSearch.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnSearch.ForeColor = Color.White;
            sbtnSearch.HoverColor = Color.CornflowerBlue;
            sbtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            sbtnSearch.IconColor = Color.Beige;
            sbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnSearch.IconSize = 30;
            sbtnSearch.ImageAlign = ContentAlignment.MiddleRight;
            sbtnSearch.Location = new Point(71, 16);
            sbtnSearch.Name = "sbtnSearch";
            sbtnSearch.NormalColor = Color.RoyalBlue;
            sbtnSearch.Padding = new Padding(10, 0, 10, 0);
            sbtnSearch.Size = new Size(58, 61);
            sbtnSearch.TabIndex = 27;
            sbtnSearch.TextAlign = ContentAlignment.MiddleLeft;
            sbtnSearch.UseVisualStyleBackColor = false;
            sbtnSearch.Click += sbtnSearch_Click;
            // 
            // sabraLabel4
            // 
            sabraLabel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel4.AutoSize = true;
            sabraLabel4.BackColor = Color.Transparent;
            sabraLabel4.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel4.ForeColor = Color.DimGray;
            sabraLabel4.Location = new Point(773, 27);
            sabraLabel4.Margin = new Padding(0);
            sabraLabel4.Name = "sabraLabel4";
            sabraLabel4.RightToLeft = RightToLeft.Yes;
            sabraLabel4.Size = new Size(42, 32);
            sabraLabel4.TabIndex = 26;
            sabraLabel4.Text = "من ";
            sabraLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel3
            // 
            sabraLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel3.AutoSize = true;
            sabraLabel3.BackColor = Color.Transparent;
            sabraLabel3.Font = new Font("Cairo Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel3.ForeColor = Color.DimGray;
            sabraLabel3.Location = new Point(435, 27);
            sabraLabel3.Margin = new Padding(0);
            sabraLabel3.Name = "sabraLabel3";
            sabraLabel3.RightToLeft = RightToLeft.Yes;
            sabraLabel3.Size = new Size(40, 32);
            sabraLabel3.TabIndex = 25;
            sabraLabel3.Text = "إلى";
            sabraLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTo.BackColor = Color.Transparent;
            dtpTo.BorderColor = Color.FromArgb(220, 225, 230);
            dtpTo.BorderRadius = 12;
            dtpTo.BorderSize = 1;
            dtpTo.Checked = true;
            dtpTo.DateFormat = "dddd، dd MMMM yyyy";
            dtpTo.FocusedBorderColor = Color.FromArgb(0, 120, 212);
            dtpTo.Font = new Font("Cairo", 10F);
            dtpTo.Location = new Point(157, 23);
            dtpTo.MinimumSize = new Size(180, 45);
            dtpTo.Name = "dtpTo";
            dtpTo.RightToLeft = RightToLeft.Yes;
            dtpTo.ShowCheckBox = false;
            dtpTo.Size = new Size(275, 45);
            dtpTo.SkinColor = Color.White;
            dtpTo.TabIndex = 24;
            dtpTo.TextColor = Color.FromArgb(45, 45, 45);
            dtpTo.Value = new DateTime(2026, 8, 30, 0, 0, 0, 0);
            dtpTo.Load += dtpTo_Load;
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFrom.BackColor = Color.Transparent;
            dtpFrom.BorderColor = Color.FromArgb(220, 225, 230);
            dtpFrom.BorderRadius = 12;
            dtpFrom.BorderSize = 1;
            dtpFrom.Checked = true;
            dtpFrom.DateFormat = "dddd، dd MMMM yyyy";
            dtpFrom.FocusedBorderColor = Color.FromArgb(0, 120, 212);
            dtpFrom.Font = new Font("Cairo", 10F);
            dtpFrom.Location = new Point(495, 23);
            dtpFrom.MinimumSize = new Size(180, 45);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.RightToLeft = RightToLeft.Yes;
            dtpFrom.ShowCheckBox = false;
            dtpFrom.Size = new Size(275, 45);
            dtpFrom.SkinColor = Color.White;
            dtpFrom.TabIndex = 22;
            dtpFrom.TextColor = Color.FromArgb(45, 45, 45);
            dtpFrom.Value = new DateTime(2026, 8, 30, 0, 0, 0, 0);
            dtpFrom.Load += dtpFrom_Load;
            // 
            // smbxClassification
            // 
            smbxClassification.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            smbxClassification.BackColor = Color.WhiteSmoke;
            smbxClassification.DrawMode = DrawMode.OwnerDrawFixed;
            smbxClassification.DropDownStyle = ComboBoxStyle.DropDownList;
            smbxClassification.FlatStyle = FlatStyle.Flat;
            smbxClassification.Font = new Font("Cairo", 10F);
            smbxClassification.ForeColor = Color.FromArgb(64, 64, 64);
            smbxClassification.FormattingEnabled = true;
            smbxClassification.ItemHeight = 30;
            smbxClassification.Items.AddRange(new object[] { "كل الحركات", "صادر", "وراد" });
            smbxClassification.Location = new Point(844, 27);
            smbxClassification.Name = "smbxClassification";
            smbxClassification.RightToLeft = RightToLeft.Yes;
            smbxClassification.Size = new Size(252, 36);
            smbxClassification.TabIndex = 23;
            smbxClassification.SelectedIndexChanged += smbxClassification_SelectedIndexChanged;
            // 
            // sabraPanel3
            // 
            sabraPanel3.AutoScroll = true;
            sabraPanel3.AutoScrollMargin = new Size(1, 0);
            sabraPanel3.AutoScrollMinSize = new Size(1, 0);
            sabraPanel3.BackColor = Color.White;
            sabraPanel3.BorderColor = Color.LightGray;
            sabraPanel3.BorderRadius = 7;
            sabraPanel3.BorderSize = 0;
            sabraPanel3.Controls.Add(lblNetBalance);
            sabraPanel3.Controls.Add(TotalWithdrawals);
            sabraPanel3.Controls.Add(lblTotalDeposits);
            sabraPanel3.Controls.Add(sabraLabel6);
            sabraPanel3.Controls.Add(sabraLabel5);
            sabraPanel3.Controls.Add(panel2);
            sabraPanel3.Controls.Add(sabraLabel2);
            sabraPanel3.Controls.Add(panel1);
            sabraPanel3.Controls.Add(sabraLabel7);
            sabraPanel3.Controls.Add(pnlTreasuryBalance);
            sabraPanel3.Dock = DockStyle.Left;
            sabraPanel3.EnableHover = true;
            sabraPanel3.ForeColor = Color.Black;
            sabraPanel3.GradientAngle = 90F;
            sabraPanel3.GradientBottomColor = Color.White;
            sabraPanel3.GradientTopColor = Color.White;
            sabraPanel3.HoverBackColor = Color.White;
            sabraPanel3.HoverBorderColor = Color.FromArgb(64, 64, 64);
            sabraPanel3.HoverBorderSize = 0;
            sabraPanel3.Location = new Point(10, 141);
            sabraPanel3.Margin = new Padding(30);
            sabraPanel3.Name = "sabraPanel3";
            sabraPanel3.Padding = new Padding(0, 0, 0, 30);
            sabraPanel3.Size = new Size(396, 894);
            sabraPanel3.TabIndex = 29;
            // 
            // lblNetBalance
            // 
            lblNetBalance.AutoSize = true;
            lblNetBalance.BackColor = Color.Transparent;
            lblNetBalance.Font = new Font("Cairo", 12F);
            lblNetBalance.ForeColor = Color.Green;
            lblNetBalance.Location = new Point(5, 384);
            lblNetBalance.Name = "lblNetBalance";
            lblNetBalance.RightToLeft = RightToLeft.Yes;
            lblNetBalance.Size = new Size(93, 37);
            lblNetBalance.TabIndex = 37;
            lblNetBalance.Text = "46,200 ج";
            lblNetBalance.TextAlign = ContentAlignment.MiddleRight;
            lblNetBalance.Click += lblNetBalance_Click;
            // 
            // TotalWithdrawals
            // 
            TotalWithdrawals.AutoSize = true;
            TotalWithdrawals.BackColor = Color.Transparent;
            TotalWithdrawals.Font = new Font("Cairo", 12F);
            TotalWithdrawals.ForeColor = Color.Red;
            TotalWithdrawals.Location = new Point(5, 328);
            TotalWithdrawals.Name = "TotalWithdrawals";
            TotalWithdrawals.RightToLeft = RightToLeft.Yes;
            TotalWithdrawals.Size = new Size(93, 37);
            TotalWithdrawals.TabIndex = 36;
            TotalWithdrawals.Text = "43,200 ج";
            TotalWithdrawals.TextAlign = ContentAlignment.MiddleRight;
            TotalWithdrawals.Click += TotalWithdrawals_Click;
            // 
            // lblTotalDeposits
            // 
            lblTotalDeposits.AutoSize = true;
            lblTotalDeposits.BackColor = Color.Transparent;
            lblTotalDeposits.Font = new Font("Cairo", 12F);
            lblTotalDeposits.ForeColor = Color.Green;
            lblTotalDeposits.Location = new Point(5, 270);
            lblTotalDeposits.Name = "lblTotalDeposits";
            lblTotalDeposits.RightToLeft = RightToLeft.Yes;
            lblTotalDeposits.Size = new Size(93, 37);
            lblTotalDeposits.TabIndex = 35;
            lblTotalDeposits.Text = "89,400 ج";
            lblTotalDeposits.TextAlign = ContentAlignment.MiddleRight;
            lblTotalDeposits.Click += lblTotalDeposits_Click;
            // 
            // sabraLabel6
            // 
            sabraLabel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraLabel6.AutoSize = true;
            sabraLabel6.BackColor = Color.Transparent;
            sabraLabel6.Font = new Font("Cairo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel6.ForeColor = SystemColors.WindowFrame;
            sabraLabel6.Location = new Point(137, 187);
            sabraLabel6.Name = "sabraLabel6";
            sabraLabel6.RightToLeft = RightToLeft.Yes;
            sabraLabel6.Size = new Size(110, 37);
            sabraLabel6.TabIndex = 34;
            sabraLabel6.Text = "هذا الشهر";
            sabraLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel5
            // 
            sabraLabel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel5.AutoSize = true;
            sabraLabel5.BackColor = Color.Transparent;
            sabraLabel5.Font = new Font("Cairo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sabraLabel5.ForeColor = SystemColors.WindowFrame;
            sabraLabel5.Location = new Point(287, 384);
            sabraLabel5.Name = "sabraLabel5";
            sabraLabel5.RightToLeft = RightToLeft.Yes;
            sabraLabel5.Size = new Size(96, 37);
            sabraLabel5.TabIndex = 33;
            sabraLabel5.Text = "الصافي : ";
            sabraLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.LightGray;
            panel2.Location = new Point(-11, 368);
            panel2.Name = "panel2";
            panel2.Size = new Size(415, 1);
            panel2.TabIndex = 32;
            // 
            // sabraLabel2
            // 
            sabraLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel2.AutoSize = true;
            sabraLabel2.BackColor = Color.Transparent;
            sabraLabel2.Font = new Font("Cairo", 12F);
            sabraLabel2.ForeColor = SystemColors.WindowFrame;
            sabraLabel2.Location = new Point(249, 328);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.RightToLeft = RightToLeft.Yes;
            sabraLabel2.Size = new Size(134, 37);
            sabraLabel2.TabIndex = 31;
            sabraLabel2.Text = "إجمالي الصادر: ";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.LightGray;
            panel1.Location = new Point(-11, 310);
            panel1.Name = "panel1";
            panel1.Size = new Size(415, 1);
            panel1.TabIndex = 30;
            // 
            // sabraLabel7
            // 
            sabraLabel7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel7.AutoSize = true;
            sabraLabel7.BackColor = Color.Transparent;
            sabraLabel7.Font = new Font("Cairo", 12F);
            sabraLabel7.ForeColor = SystemColors.WindowFrame;
            sabraLabel7.Location = new Point(255, 270);
            sabraLabel7.Name = "sabraLabel7";
            sabraLabel7.RightToLeft = RightToLeft.Yes;
            sabraLabel7.Size = new Size(128, 37);
            sabraLabel7.TabIndex = 29;
            sabraLabel7.Text = "إجمالي الوارد: ";
            sabraLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlTreasuryBalance
            // 
            pnlTreasuryBalance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTreasuryBalance.BackColor = Color.RoyalBlue;
            pnlTreasuryBalance.BorderColor = Color.LightGray;
            pnlTreasuryBalance.BorderRadius = 15;
            pnlTreasuryBalance.BorderSize = 0;
            pnlTreasuryBalance.Controls.Add(lblTreasuryBalance);
            pnlTreasuryBalance.Controls.Add(sabraLabel1);
            pnlTreasuryBalance.EnableHover = true;
            pnlTreasuryBalance.ForeColor = Color.Black;
            pnlTreasuryBalance.GradientAngle = 90F;
            pnlTreasuryBalance.GradientBottomColor = Color.RoyalBlue;
            pnlTreasuryBalance.GradientTopColor = Color.Transparent;
            pnlTreasuryBalance.HoverBackColor = Color.RoyalBlue;
            pnlTreasuryBalance.HoverBorderColor = Color.FromArgb(37, 99, 235);
            pnlTreasuryBalance.HoverBorderSize = 2;
            pnlTreasuryBalance.Location = new Point(25, 27);
            pnlTreasuryBalance.Name = "pnlTreasuryBalance";
            pnlTreasuryBalance.Size = new Size(336, 136);
            pnlTreasuryBalance.TabIndex = 0;
            // 
            // lblTreasuryBalance
            // 
            lblTreasuryBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTreasuryBalance.BackColor = Color.Transparent;
            lblTreasuryBalance.Font = new Font("Cairo", 18F, FontStyle.Bold);
            lblTreasuryBalance.ForeColor = Color.White;
            lblTreasuryBalance.Location = new Point(3, 61);
            lblTreasuryBalance.Name = "lblTreasuryBalance";
            lblTreasuryBalance.RightToLeft = RightToLeft.Yes;
            lblTreasuryBalance.Size = new Size(330, 56);
            lblTreasuryBalance.TabIndex = 18;
            lblTreasuryBalance.Text = "127,450 ج";
            lblTreasuryBalance.TextAlign = ContentAlignment.MiddleCenter;
            lblTreasuryBalance.Click += lblTreasuryBalance_Click;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraLabel1.AutoSize = true;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.Font = new Font("Cairo", 12F);
            sabraLabel1.ForeColor = SystemColors.Window;
            sabraLabel1.Location = new Point(82, 13);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.RightToLeft = RightToLeft.Yes;
            sabraLabel1.Size = new Size(163, 37);
            sabraLabel1.TabIndex = 17;
            sabraLabel1.Text = "رصيد الخزانة الحالي";
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvTreasury
            // 
            dgvTreasury.AllowUserToAddRows = false;
            dgvTreasury.AllowUserToDeleteRows = false;
            dgvTreasury.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvTreasury.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTreasury.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTreasury.BackgroundColor = Color.White;
            dgvTreasury.BorderStyle = BorderStyle.None;
            dgvTreasury.ButtonBackColor = Color.FromArgb(241, 245, 249);
            dgvTreasury.ButtonForeColor = Color.FromArgb(51, 65, 85);
            dgvTreasury.ButtonHoverColor = Color.FromArgb(226, 232, 240);
            dgvTreasury.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvTreasury.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Cairo", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTreasury.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTreasury.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTreasury.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTreasury.Dock = DockStyle.Fill;
            dgvTreasury.EditableCellBackColor = Color.White;
            dgvTreasury.EditableCellBorderColor = Color.FromArgb(203, 213, 225);
            dgvTreasury.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvTreasury.EnableHeadersVisualStyles = false;
            dgvTreasury.Font = new Font("Cairo", 10F);
            dgvTreasury.GridColor = Color.FromArgb(226, 232, 240);
            dgvTreasury.GridLineCustomColor = Color.FromArgb(226, 232, 240);
            dgvTreasury.HeaderBackColor = Color.FromArgb(248, 250, 252);
            dgvTreasury.HeaderForeColor = Color.FromArgb(30, 41, 59);
            dgvTreasury.HeaderHeight = 4;
            dgvTreasury.HoverBackColor = Color.FromArgb(241, 245, 249);
            dgvTreasury.Location = new Point(406, 239);
            dgvTreasury.Margin = new Padding(30);
            dgvTreasury.MultiSelect = false;
            dgvTreasury.Name = "dgvTreasury";
            dgvTreasury.RightToLeft = RightToLeft.Yes;
            dgvTreasury.RowAlternateBackColor = Color.FromArgb(248, 250, 252);
            dgvTreasury.RowBackColor = Color.White;
            dgvTreasury.RowForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Cairo", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvTreasury.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvTreasury.RowHeadersVisible = false;
            dgvTreasury.RowHeadersWidth = 51;
            dgvTreasury.RowTemplate.Height = 42;
            dgvTreasury.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvTreasury.SelectionForeColor = Color.White;
            dgvTreasury.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTreasury.Size = new Size(1106, 796);
            dgvTreasury.TabIndex = 0;
            dgvTreasury.CellContentClick += dgvTreasury_CellContentClick;
            // 
            // ucTreasury
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvTreasury);
            Controls.Add(sabraPanel2);
            Controls.Add(sabraPanel3);
            Controls.Add(sabraPanel1);
            Name = "ucTreasury";
            Load += ucTreasury_Load;
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            sabraPanel2.ResumeLayout(false);
            sabraPanel2.PerformLayout();
            sabraPanel3.ResumeLayout(false);
            sabraPanel3.PerformLayout();
            pnlTreasuryBalance.ResumeLayout(false);
            pnlTreasuryBalance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTreasury).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraLabel lblNumberOfInvoices;
        private SabraLabel slblTitleOfTopPanel;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraButton sbtnExportAsExcel;
        private SabraButton sbtnPrint;
        private SabraButton sbtnWithdrawal;
        private SabraButton sbtnDeposit;
        private SabraPanel sabraPanel1;
        private SabraPanel sabraPanel2;
        private SabraPanel sabraPanel3;
        private SabraDataGridView dgvTreasury;
        private SabraLabel sabraLabel4;
        private SabraLabel sabraLabel3;
        private SabraDateTimePicker dtpTo;
        private SabraDateTimePicker dtpFrom;
        private SabraComboBox smbxClassification;
        private SabraButton sbtnSearch;
        private SabraPanel pnlTreasuryBalance;
        private SabraLabel lblTreasuryBalance;
        private SabraLabel sabraLabel1;
        private SabraLabel sabraLabel6;
        private SabraLabel sabraLabel5;
        private Panel panel2;
        private SabraLabel sabraLabel2;
        private Panel panel1;
        private SabraLabel sabraLabel7;
        private SabraLabel lblNetBalance;
        private SabraLabel TotalWithdrawals;
        private SabraLabel lblTotalDeposits;
    }
}
