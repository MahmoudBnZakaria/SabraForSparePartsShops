namespace SabraForSpareParts.Screens
{
    partial class ucBackup
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
            sabraPanel1 = new SabraPanel();
            lblDateTimeAndSizeOfTheLastSuccBackUp = new SabraLabel();
            slblCustomerNameAndCreditLimit = new SabraLabel();
            panel1 = new Panel();
            slblBasicInfoTitle = new SabraLabel();
            sabraPanel2 = new SabraPanel();
            slblTitleOfTopPanel = new SabraLabel();
            sabraPanel3 = new SabraPanel();
            btnBackupToGoogleDrive = new SabraButton();
            sabraButton1 = new SabraButton();
            btnOpenLocationInComputer = new SabraButton();
            sabraLabel1 = new SabraLabel();
            stbxSaveLocationPath = new SabraTextBox();
            panel2 = new Panel();
            sabraLabel3 = new SabraLabel();
            sabraPanel5 = new SabraPanel();
            TimePicker = new DateTimePicker();
            sabraLabel10 = new SabraLabel();
            sabraLabel7 = new SabraLabel();
            cmbxRepition = new SabraComboBox();
            checkBoxActiveAutomaticBackup = new CheckBox();
            panel4 = new Panel();
            sabraLabel9 = new SabraLabel();
            sabraPanel6 = new SabraPanel();
            btnRestore = new SabraButton();
            sabraLabel12 = new SabraLabel();
            btnOpenLocationInComputer1 = new SabraButton();
            sabraTextBox1 = new SabraTextBox();
            sabraLabel11 = new SabraLabel();
            panel5 = new Panel();
            sabraLabel14 = new SabraLabel();
            sabraPanel1.SuspendLayout();
            sabraPanel2.SuspendLayout();
            sabraPanel3.SuspendLayout();
            sabraPanel5.SuspendLayout();
            sabraPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 0;
            sabraPanel1.Controls.Add(lblDateTimeAndSizeOfTheLastSuccBackUp);
            sabraPanel1.Controls.Add(slblCustomerNameAndCreditLimit);
            sabraPanel1.Controls.Add(panel1);
            sabraPanel1.Controls.Add(slblBasicInfoTitle);
            sabraPanel1.EnableHover = true;
            sabraPanel1.ForeColor = Color.Black;
            sabraPanel1.GradientAngle = 90F;
            sabraPanel1.GradientBottomColor = Color.White;
            sabraPanel1.GradientTopColor = Color.White;
            sabraPanel1.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel1.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel1.HoverBorderSize = 2;
            sabraPanel1.Location = new Point(44, 144);
            sabraPanel1.Margin = new Padding(20);
            sabraPanel1.Name = "sabraPanel1";
            sabraPanel1.Size = new Size(1410, 153);
            sabraPanel1.TabIndex = 4;
            // 
            // lblDateTimeAndSizeOfTheLastSuccBackUp
            // 
            lblDateTimeAndSizeOfTheLastSuccBackUp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblDateTimeAndSizeOfTheLastSuccBackUp.AutoSize = true;
            lblDateTimeAndSizeOfTheLastSuccBackUp.BackColor = Color.Transparent;
            lblDateTimeAndSizeOfTheLastSuccBackUp.Font = new Font("Cairo", 10F, FontStyle.Bold);
            lblDateTimeAndSizeOfTheLastSuccBackUp.ForeColor = Color.FromArgb(64, 64, 64);
            lblDateTimeAndSizeOfTheLastSuccBackUp.Location = new Point(810, 91);
            lblDateTimeAndSizeOfTheLastSuccBackUp.Name = "lblDateTimeAndSizeOfTheLastSuccBackUp";
            lblDateTimeAndSizeOfTheLastSuccBackUp.RightToLeft = RightToLeft.Yes;
            lblDateTimeAndSizeOfTheLastSuccBackUp.Size = new Size(329, 32);
            lblDateTimeAndSizeOfTheLastSuccBackUp.TabIndex = 16;
            lblDateTimeAndSizeOfTheLastSuccBackUp.Text = "15 يناير 2025 — 08:00 صباحاً | الحجم: 45 MB";
            lblDateTimeAndSizeOfTheLastSuccBackUp.TextAlign = ContentAlignment.MiddleRight;
            // 
            // slblCustomerNameAndCreditLimit
            // 
            slblCustomerNameAndCreditLimit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            slblCustomerNameAndCreditLimit.AutoSize = true;
            slblCustomerNameAndCreditLimit.BackColor = Color.FromArgb(240, 253, 244);
            slblCustomerNameAndCreditLimit.BorderColor = Color.Green;
            slblCustomerNameAndCreditLimit.BorderRadius = 20;
            slblCustomerNameAndCreditLimit.BorderSize = 1;
            slblCustomerNameAndCreditLimit.Font = new Font("Cairo", 15F);
            slblCustomerNameAndCreditLimit.ForeColor = Color.Green;
            slblCustomerNameAndCreditLimit.Location = new Point(1169, 80);
            slblCustomerNameAndCreditLimit.Name = "slblCustomerNameAndCreditLimit";
            slblCustomerNameAndCreditLimit.RightToLeft = RightToLeft.Yes;
            slblCustomerNameAndCreditLimit.Size = new Size(226, 47);
            slblCustomerNameAndCreditLimit.TabIndex = 15;
            slblCustomerNameAndCreditLimit.Text = "نسخة احتياطية ناجحة";
            slblCustomerNameAndCreditLimit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.LightGray;
            panel1.Location = new Point(-11, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(2633, 1);
            panel1.TabIndex = 5;
            // 
            // slblBasicInfoTitle
            // 
            slblBasicInfoTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblBasicInfoTitle.AutoSize = true;
            slblBasicInfoTitle.BackColor = Color.Transparent;
            slblBasicInfoTitle.Font = new Font("Cairo", 10F, FontStyle.Bold);
            slblBasicInfoTitle.ForeColor = Color.FromArgb(64, 64, 64);
            slblBasicInfoTitle.Location = new Point(1243, 16);
            slblBasicInfoTitle.Name = "slblBasicInfoTitle";
            slblBasicInfoTitle.RightToLeft = RightToLeft.Yes;
            slblBasicInfoTitle.Size = new Size(152, 32);
            slblBasicInfoTitle.TabIndex = 4;
            slblBasicInfoTitle.Text = "آخر نسخة احتياطية";
            slblBasicInfoTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel2
            // 
            sabraPanel2.BackColor = Color.White;
            sabraPanel2.BorderColor = Color.LightGray;
            sabraPanel2.BorderRadius = 15;
            sabraPanel2.BorderSize = 1;
            sabraPanel2.Controls.Add(slblTitleOfTopPanel);
            sabraPanel2.Dock = DockStyle.Top;
            sabraPanel2.EnableHover = true;
            sabraPanel2.ForeColor = Color.Black;
            sabraPanel2.GradientAngle = 90F;
            sabraPanel2.GradientBottomColor = Color.White;
            sabraPanel2.GradientTopColor = Color.White;
            sabraPanel2.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel2.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel2.HoverBorderSize = 2;
            sabraPanel2.Location = new Point(10, 10);
            sabraPanel2.Name = "sabraPanel2";
            sabraPanel2.Size = new Size(1502, 111);
            sabraPanel2.TabIndex = 5;
            // 
            // slblTitleOfTopPanel
            // 
            slblTitleOfTopPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblTitleOfTopPanel.AutoSize = true;
            slblTitleOfTopPanel.BackColor = Color.Transparent;
            slblTitleOfTopPanel.Font = new Font("Cairo", 18F, FontStyle.Bold);
            slblTitleOfTopPanel.ForeColor = Color.FromArgb(40, 40, 40);
            slblTitleOfTopPanel.Location = new Point(1231, 22);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(243, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "النسخ الاحتياطي";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel3
            // 
            sabraPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraPanel3.BackColor = Color.White;
            sabraPanel3.BorderColor = Color.LightGray;
            sabraPanel3.BorderRadius = 15;
            sabraPanel3.BorderSize = 0;
            sabraPanel3.Controls.Add(btnBackupToGoogleDrive);
            sabraPanel3.Controls.Add(sabraButton1);
            sabraPanel3.Controls.Add(btnOpenLocationInComputer);
            sabraPanel3.Controls.Add(sabraLabel1);
            sabraPanel3.Controls.Add(stbxSaveLocationPath);
            sabraPanel3.Controls.Add(panel2);
            sabraPanel3.Controls.Add(sabraLabel3);
            sabraPanel3.EnableHover = true;
            sabraPanel3.ForeColor = Color.Black;
            sabraPanel3.GradientAngle = 90F;
            sabraPanel3.GradientBottomColor = Color.White;
            sabraPanel3.GradientTopColor = Color.White;
            sabraPanel3.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel3.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel3.HoverBorderSize = 2;
            sabraPanel3.Location = new Point(44, 320);
            sabraPanel3.Margin = new Padding(20);
            sabraPanel3.Name = "sabraPanel3";
            sabraPanel3.Size = new Size(1410, 263);
            sabraPanel3.TabIndex = 6;
            // 
            // btnBackupToGoogleDrive
            // 
            btnBackupToGoogleDrive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBackupToGoogleDrive.BackColor = Color.Gray;
            btnBackupToGoogleDrive.BorderColor = Color.DodgerBlue;
            btnBackupToGoogleDrive.BorderRadius = 20;
            btnBackupToGoogleDrive.BorderSize = 0;
            btnBackupToGoogleDrive.FlatAppearance.BorderSize = 0;
            btnBackupToGoogleDrive.FlatStyle = FlatStyle.Flat;
            btnBackupToGoogleDrive.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnBackupToGoogleDrive.ForeColor = Color.White;
            btnBackupToGoogleDrive.HoverColor = Color.CornflowerBlue;
            btnBackupToGoogleDrive.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleUp;
            btnBackupToGoogleDrive.IconColor = Color.White;
            btnBackupToGoogleDrive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBackupToGoogleDrive.IconSize = 30;
            btnBackupToGoogleDrive.ImageAlign = ContentAlignment.MiddleRight;
            btnBackupToGoogleDrive.Location = new Point(965, 190);
            btnBackupToGoogleDrive.Name = "btnBackupToGoogleDrive";
            btnBackupToGoogleDrive.NormalColor = Color.Gray;
            btnBackupToGoogleDrive.Size = new Size(199, 52);
            btnBackupToGoogleDrive.TabIndex = 22;
            btnBackupToGoogleDrive.Text = "رفع لـ Google Drive";
            btnBackupToGoogleDrive.TextAlign = ContentAlignment.MiddleLeft;
            btnBackupToGoogleDrive.UseVisualStyleBackColor = false;
            btnBackupToGoogleDrive.Click += btnBackupToGoogleDrive_Click;
            // 
            // sabraButton1
            // 
            sabraButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraButton1.BackColor = Color.RoyalBlue;
            sabraButton1.BorderColor = Color.DodgerBlue;
            sabraButton1.BorderRadius = 20;
            sabraButton1.BorderSize = 0;
            sabraButton1.FlatAppearance.BorderSize = 0;
            sabraButton1.FlatStyle = FlatStyle.Flat;
            sabraButton1.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sabraButton1.ForeColor = Color.White;
            sabraButton1.HoverColor = Color.CornflowerBlue;
            sabraButton1.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleDown;
            sabraButton1.IconColor = Color.White;
            sabraButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sabraButton1.IconSize = 30;
            sabraButton1.ImageAlign = ContentAlignment.MiddleRight;
            sabraButton1.Location = new Point(1185, 190);
            sabraButton1.Name = "sabraButton1";
            sabraButton1.NormalColor = Color.RoyalBlue;
            sabraButton1.Size = new Size(199, 52);
            sabraButton1.TabIndex = 21;
            sabraButton1.Text = "نسخ احتياطي الآن";
            sabraButton1.TextAlign = ContentAlignment.MiddleLeft;
            sabraButton1.UseVisualStyleBackColor = false;
            sabraButton1.Click += sabraButton1_Click;
            // 
            // btnOpenLocationInComputer
            // 
            btnOpenLocationInComputer.BackColor = Color.Gray;
            btnOpenLocationInComputer.BorderColor = Color.DodgerBlue;
            btnOpenLocationInComputer.BorderRadius = 20;
            btnOpenLocationInComputer.BorderSize = 0;
            btnOpenLocationInComputer.FlatAppearance.BorderSize = 0;
            btnOpenLocationInComputer.FlatStyle = FlatStyle.Flat;
            btnOpenLocationInComputer.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnOpenLocationInComputer.ForeColor = Color.White;
            btnOpenLocationInComputer.HoverColor = Color.CornflowerBlue;
            btnOpenLocationInComputer.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            btnOpenLocationInComputer.IconColor = Color.White;
            btnOpenLocationInComputer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOpenLocationInComputer.IconSize = 30;
            btnOpenLocationInComputer.ImageAlign = ContentAlignment.MiddleRight;
            btnOpenLocationInComputer.Location = new Point(104, 117);
            btnOpenLocationInComputer.Name = "btnOpenLocationInComputer";
            btnOpenLocationInComputer.NormalColor = Color.Gray;
            btnOpenLocationInComputer.Size = new Size(134, 47);
            btnOpenLocationInComputer.TabIndex = 20;
            btnOpenLocationInComputer.Text = "استعراض";
            btnOpenLocationInComputer.TextAlign = ContentAlignment.MiddleLeft;
            btnOpenLocationInComputer.UseVisualStyleBackColor = false;
            btnOpenLocationInComputer.Click += btnOpenLocationInComputer_Click;
            // 
            // sabraLabel1
            // 
            sabraLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel1.AutoSize = true;
            sabraLabel1.BackColor = Color.Transparent;
            sabraLabel1.Font = new Font("Cairo", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sabraLabel1.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel1.Location = new Point(1283, 82);
            sabraLabel1.Name = "sabraLabel1";
            sabraLabel1.RightToLeft = RightToLeft.Yes;
            sabraLabel1.Size = new Size(101, 32);
            sabraLabel1.TabIndex = 18;
            sabraLabel1.Text = "مكان الحفظ";
            sabraLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // stbxSaveLocationPath
            // 
            stbxSaveLocationPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            stbxSaveLocationPath.BackColor = Color.White;
            stbxSaveLocationPath.BorderColor = Color.DimGray;
            stbxSaveLocationPath.Font = new Font("Cairo", 10F);
            stbxSaveLocationPath.ForeColor = Color.FromArgb(64, 64, 64);
            stbxSaveLocationPath.Location = new Point(268, 117);
            stbxSaveLocationPath.Name = "stbxSaveLocationPath";
            stbxSaveLocationPath.Padding = new Padding(10, 7, 25, 7);
            stbxSaveLocationPath.RightToLeft = RightToLeft.Yes;
            stbxSaveLocationPath.SelectedText = "";
            stbxSaveLocationPath.SelectionLength = 0;
            stbxSaveLocationPath.SelectionStart = 0;
            stbxSaveLocationPath.Size = new Size(1127, 47);
            stbxSaveLocationPath.TabIndex = 17;
            stbxSaveLocationPath.Texts = "C:\\Backups\\SparePartsShop\\";
            stbxSaveLocationPath.Load += stbxSaveLocationPath_Load;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.LightGray;
            panel2.Location = new Point(-11, 57);
            panel2.Name = "panel2";
            panel2.Size = new Size(3843, 1);
            panel2.TabIndex = 5;
            // 
            // sabraLabel3
            // 
            sabraLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel3.AutoSize = true;
            sabraLabel3.BackColor = Color.Transparent;
            sabraLabel3.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sabraLabel3.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel3.Location = new Point(1222, 11);
            sabraLabel3.Name = "sabraLabel3";
            sabraLabel3.RightToLeft = RightToLeft.Yes;
            sabraLabel3.Size = new Size(173, 32);
            sabraLabel3.TabIndex = 4;
            sabraLabel3.Text = "نسخة احتياطية يدوية";
            sabraLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel5
            // 
            sabraPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraPanel5.BackColor = Color.White;
            sabraPanel5.BorderColor = Color.LightGray;
            sabraPanel5.BorderRadius = 15;
            sabraPanel5.BorderSize = 0;
            sabraPanel5.Controls.Add(TimePicker);
            sabraPanel5.Controls.Add(sabraLabel10);
            sabraPanel5.Controls.Add(sabraLabel7);
            sabraPanel5.Controls.Add(cmbxRepition);
            sabraPanel5.Controls.Add(checkBoxActiveAutomaticBackup);
            sabraPanel5.Controls.Add(panel4);
            sabraPanel5.Controls.Add(sabraLabel9);
            sabraPanel5.EnableHover = true;
            sabraPanel5.ForeColor = Color.Black;
            sabraPanel5.GradientAngle = 90F;
            sabraPanel5.GradientBottomColor = Color.White;
            sabraPanel5.GradientTopColor = Color.White;
            sabraPanel5.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel5.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel5.HoverBorderSize = 2;
            sabraPanel5.Location = new Point(44, 623);
            sabraPanel5.Margin = new Padding(20);
            sabraPanel5.Name = "sabraPanel5";
            sabraPanel5.Size = new Size(1410, 159);
            sabraPanel5.TabIndex = 24;
            // 
            // TimePicker
            // 
            TimePicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TimePicker.Format = DateTimePickerFormat.Time;
            TimePicker.Location = new Point(555, 81);
            TimePicker.Name = "TimePicker";
            TimePicker.Size = new Size(146, 39);
            TimePicker.TabIndex = 25;
            TimePicker.ValueChanged += TimePicker_ValueChanged;
            // 
            // sabraLabel10
            // 
            sabraLabel10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel10.AutoSize = true;
            sabraLabel10.BackColor = Color.Transparent;
            sabraLabel10.Font = new Font("Cairo", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sabraLabel10.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel10.Location = new Point(707, 77);
            sabraLabel10.Name = "sabraLabel10";
            sabraLabel10.RightToLeft = RightToLeft.Yes;
            sabraLabel10.Size = new Size(82, 43);
            sabraLabel10.TabIndex = 24;
            sabraLabel10.Text = "الوقت:";
            sabraLabel10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel7
            // 
            sabraLabel7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel7.AutoSize = true;
            sabraLabel7.BackColor = Color.Transparent;
            sabraLabel7.Font = new Font("Cairo", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sabraLabel7.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel7.Location = new Point(1063, 77);
            sabraLabel7.Name = "sabraLabel7";
            sabraLabel7.RightToLeft = RightToLeft.Yes;
            sabraLabel7.Size = new Size(77, 43);
            sabraLabel7.TabIndex = 23;
            sabraLabel7.Text = "التكرار:";
            sabraLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbxRepition
            // 
            cmbxRepition.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbxRepition.BackColor = Color.WhiteSmoke;
            cmbxRepition.BorderColor = Color.DimGray;
            cmbxRepition.DrawMode = DrawMode.OwnerDrawFixed;
            cmbxRepition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxRepition.FlatStyle = FlatStyle.Flat;
            cmbxRepition.Font = new Font("Cairo", 9F);
            cmbxRepition.ForeColor = Color.FromArgb(64, 64, 64);
            cmbxRepition.FormattingEnabled = true;
            cmbxRepition.ItemHeight = 41;
            cmbxRepition.Items.AddRange(new object[] { "يومي", "أسبوعي" });
            cmbxRepition.Location = new Point(919, 77);
            cmbxRepition.Name = "cmbxRepition";
            cmbxRepition.RightToLeft = RightToLeft.Yes;
            cmbxRepition.Size = new Size(138, 47);
            cmbxRepition.TabIndex = 22;
            cmbxRepition.SelectedIndexChanged += cmbxRepition_SelectedIndexChanged;
            // 
            // checkBoxActiveAutomaticBackup
            // 
            checkBoxActiveAutomaticBackup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxActiveAutomaticBackup.AutoSize = true;
            checkBoxActiveAutomaticBackup.BackColor = Color.White;
            checkBoxActiveAutomaticBackup.Checked = true;
            checkBoxActiveAutomaticBackup.CheckState = CheckState.Checked;
            checkBoxActiveAutomaticBackup.ForeColor = Color.Black;
            checkBoxActiveAutomaticBackup.Location = new Point(1208, 77);
            checkBoxActiveAutomaticBackup.Name = "checkBoxActiveAutomaticBackup";
            checkBoxActiveAutomaticBackup.Size = new Size(185, 36);
            checkBoxActiveAutomaticBackup.TabIndex = 21;
            checkBoxActiveAutomaticBackup.Text = "تفعيل النسخ التلقائي";
            checkBoxActiveAutomaticBackup.UseVisualStyleBackColor = false;
            checkBoxActiveAutomaticBackup.CheckedChanged += checkBoxActiveAutomaticBackup_CheckedChanged;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.LightGray;
            panel4.Location = new Point(-11, 57);
            panel4.Name = "panel4";
            panel4.Size = new Size(6263, 1);
            panel4.TabIndex = 5;
            // 
            // sabraLabel9
            // 
            sabraLabel9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel9.AutoSize = true;
            sabraLabel9.BackColor = Color.Transparent;
            sabraLabel9.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sabraLabel9.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel9.Location = new Point(1222, 11);
            sabraLabel9.Name = "sabraLabel9";
            sabraLabel9.RightToLeft = RightToLeft.Yes;
            sabraLabel9.Size = new Size(171, 32);
            sabraLabel9.TabIndex = 4;
            sabraLabel9.Text = "جدولة النسخ التلقائي";
            sabraLabel9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraPanel6
            // 
            sabraPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraPanel6.BackColor = Color.White;
            sabraPanel6.BorderColor = Color.Brown;
            sabraPanel6.BorderRadius = 15;
            sabraPanel6.BorderSize = 1;
            sabraPanel6.Controls.Add(btnRestore);
            sabraPanel6.Controls.Add(sabraLabel12);
            sabraPanel6.Controls.Add(btnOpenLocationInComputer1);
            sabraPanel6.Controls.Add(sabraTextBox1);
            sabraPanel6.Controls.Add(sabraLabel11);
            sabraPanel6.Controls.Add(panel5);
            sabraPanel6.Controls.Add(sabraLabel14);
            sabraPanel6.EnableHover = true;
            sabraPanel6.ForeColor = Color.Black;
            sabraPanel6.GradientAngle = 90F;
            sabraPanel6.GradientBottomColor = Color.White;
            sabraPanel6.GradientTopColor = Color.White;
            sabraPanel6.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel6.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel6.HoverBorderSize = 2;
            sabraPanel6.Location = new Point(44, 809);
            sabraPanel6.Margin = new Padding(20);
            sabraPanel6.Name = "sabraPanel6";
            sabraPanel6.Size = new Size(1410, 313);
            sabraPanel6.TabIndex = 25;
            // 
            // btnRestore
            // 
            btnRestore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestore.BackColor = Color.RoyalBlue;
            btnRestore.BorderColor = Color.DimGray;
            btnRestore.BorderRadius = 20;
            btnRestore.BorderSize = 0;
            btnRestore.FlatAppearance.BorderSize = 0;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnRestore.ForeColor = Color.White;
            btnRestore.HoverColor = Color.CornflowerBlue;
            btnRestore.IconChar = FontAwesome.Sharp.IconChar.ArrowDownUpAcrossLine;
            btnRestore.IconColor = Color.White;
            btnRestore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRestore.IconSize = 30;
            btnRestore.ImageAlign = ContentAlignment.MiddleRight;
            btnRestore.Location = new Point(1256, 243);
            btnRestore.Name = "btnRestore";
            btnRestore.NormalColor = Color.RoyalBlue;
            btnRestore.Size = new Size(137, 52);
            btnRestore.TabIndex = 24;
            btnRestore.Text = "استعادة";
            btnRestore.TextAlign = ContentAlignment.MiddleLeft;
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // sabraLabel12
            // 
            sabraLabel12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel12.AutoSize = true;
            sabraLabel12.BackColor = Color.Transparent;
            sabraLabel12.Font = new Font("Cairo", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sabraLabel12.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel12.Location = new Point(1182, 140);
            sabraLabel12.Name = "sabraLabel12";
            sabraLabel12.RightToLeft = RightToLeft.Yes;
            sabraLabel12.Size = new Size(202, 32);
            sabraLabel12.TabIndex = 23;
            sabraLabel12.Text = "اختر ملف النسخة الاحتياطية";
            sabraLabel12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnOpenLocationInComputer1
            // 
            btnOpenLocationInComputer1.BackColor = Color.Gray;
            btnOpenLocationInComputer1.BorderColor = Color.DodgerBlue;
            btnOpenLocationInComputer1.BorderRadius = 20;
            btnOpenLocationInComputer1.BorderSize = 0;
            btnOpenLocationInComputer1.FlatAppearance.BorderSize = 0;
            btnOpenLocationInComputer1.FlatStyle = FlatStyle.Flat;
            btnOpenLocationInComputer1.Font = new Font("Cairo", 10F, FontStyle.Bold);
            btnOpenLocationInComputer1.ForeColor = Color.White;
            btnOpenLocationInComputer1.HoverColor = Color.CornflowerBlue;
            btnOpenLocationInComputer1.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            btnOpenLocationInComputer1.IconColor = Color.White;
            btnOpenLocationInComputer1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOpenLocationInComputer1.IconSize = 30;
            btnOpenLocationInComputer1.ImageAlign = ContentAlignment.MiddleRight;
            btnOpenLocationInComputer1.Location = new Point(104, 175);
            btnOpenLocationInComputer1.Name = "btnOpenLocationInComputer1";
            btnOpenLocationInComputer1.NormalColor = Color.Gray;
            btnOpenLocationInComputer1.Size = new Size(134, 47);
            btnOpenLocationInComputer1.TabIndex = 22;
            btnOpenLocationInComputer1.Text = "استعراض";
            btnOpenLocationInComputer1.TextAlign = ContentAlignment.MiddleLeft;
            btnOpenLocationInComputer1.UseVisualStyleBackColor = false;
            btnOpenLocationInComputer1.Click += btnOpenLocationInComputer1_Click;
            // 
            // sabraTextBox1
            // 
            sabraTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraTextBox1.BackColor = Color.White;
            sabraTextBox1.BorderColor = Color.DimGray;
            sabraTextBox1.Font = new Font("Cairo", 10F);
            sabraTextBox1.ForeColor = Color.FromArgb(64, 64, 64);
            sabraTextBox1.Location = new Point(266, 175);
            sabraTextBox1.Name = "sabraTextBox1";
            sabraTextBox1.Padding = new Padding(10, 7, 25, 7);
            sabraTextBox1.PlaceholderText = "fd";
            sabraTextBox1.RightToLeft = RightToLeft.Yes;
            sabraTextBox1.SelectedText = "";
            sabraTextBox1.SelectionLength = 0;
            sabraTextBox1.SelectionStart = 0;
            sabraTextBox1.Size = new Size(1127, 47);
            sabraTextBox1.TabIndex = 21;
            sabraTextBox1.Texts = "أختر ملف bak. أو  zip....";
            sabraTextBox1.Load += sabraTextBox1_Load;
            // 
            // sabraLabel11
            // 
            sabraLabel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sabraLabel11.BackColor = Color.FromArgb(254, 242, 242);
            sabraLabel11.BorderColor = Color.Red;
            sabraLabel11.BorderRadius = 20;
            sabraLabel11.BorderSize = 1;
            sabraLabel11.Font = new Font("Cairo", 15F);
            sabraLabel11.ForeColor = Color.Red;
            sabraLabel11.Location = new Point(13, 72);
            sabraLabel11.Name = "sabraLabel11";
            sabraLabel11.RightToLeft = RightToLeft.Yes;
            sabraLabel11.Size = new Size(1382, 47);
            sabraLabel11.TabIndex = 16;
            sabraLabel11.Text = "تحذير: الاستعادة ستمسح كل البيانات الحالية وتستبدلها بالنسخة القديمة.";
            sabraLabel11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.LightGray;
            panel5.Location = new Point(-11, 57);
            panel5.Name = "panel5";
            panel5.Size = new Size(7473, 1);
            panel5.TabIndex = 5;
            // 
            // sabraLabel14
            // 
            sabraLabel14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel14.AutoSize = true;
            sabraLabel14.BackColor = Color.Transparent;
            sabraLabel14.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sabraLabel14.ForeColor = Color.FromArgb(64, 64, 64);
            sabraLabel14.Location = new Point(1222, 11);
            sabraLabel14.Name = "sabraLabel14";
            sabraLabel14.RightToLeft = RightToLeft.Yes;
            sabraLabel14.Size = new Size(171, 32);
            sabraLabel14.TabIndex = 4;
            sabraLabel14.Text = "جدولة النسخ التلقائي";
            sabraLabel14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ucBackup
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sabraPanel6);
            Controls.Add(sabraPanel5);
            Controls.Add(sabraPanel3);
            Controls.Add(sabraPanel2);
            Controls.Add(sabraPanel1);
            Name = "ucBackup";
            Size = new Size(1502, 1433);
            Load += ucSettings_Load;
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            sabraPanel2.ResumeLayout(false);
            sabraPanel2.PerformLayout();
            sabraPanel3.ResumeLayout(false);
            sabraPanel3.PerformLayout();
            sabraPanel5.ResumeLayout(false);
            sabraPanel5.PerformLayout();
            sabraPanel6.ResumeLayout(false);
            sabraPanel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private Panel panel1;
        private SabraLabel slblBasicInfoTitle;
        private SabraPanel sabraPanel2;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblDateTimeAndSizeOfTheLastSuccBackUp;
        private SabraLabel slblCustomerNameAndCreditLimit;
        private SabraPanel sabraPanel3;
        private SabraButton btnOpenLocationInComputer;
        private SabraLabel sabraLabel1;
        private SabraTextBox stbxSaveLocationPath;
        private Panel panel2;
        private SabraLabel sabraLabel3;
        private SabraButton btnBackupToGoogleDrive;
        private SabraButton sabraButton1;
        private SabraPanel sabraPanel5;
        private Panel panel4;
        private SabraLabel sabraLabel9;
        private SabraLabel sabraLabel7;
        private SabraComboBox cmbxRepition;
        private CheckBox checkBoxActiveAutomaticBackup;
        private DateTimePicker TimePicker;
        private SabraLabel sabraLabel10;
        private SabraPanel sabraPanel6;
        private SabraLabel sabraLabel11;
        private Panel panel5;
        private SabraLabel sabraLabel14;
        private SabraButton btnRestore;
        private SabraLabel sabraLabel12;
        private SabraButton btnOpenLocationInComputer1;
        private SabraTextBox sabraTextBox1;
    }
}
