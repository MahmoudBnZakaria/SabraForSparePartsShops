namespace SabraForSpareParts
{
    partial class frmLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            slblTitleSabra = new SabraLabel();
            slblTitleForSpare = new SabraLabel();
            slblTitleCarParats = new SabraLabel();
            slblEnglishTitle = new SabraLabel();
            slblAppVersion = new SabraLabel();
            stbxUserName = new SabraTextBox();
            stbnLogin = new SabraButton();
            sbtnCancelLogin = new SabraButton();
            stbxPassowrd = new SabraTextBox();
            cbxPasswordVisibility = new CheckBox();
            SuspendLayout();
            // 
            // slblTitleSabra
            // 
            slblTitleSabra.AutoSize = true;
            slblTitleSabra.BackColor = Color.Transparent;
            slblTitleSabra.BorderColor = Color.DeepSkyBlue;
            slblTitleSabra.Font = new Font("Cairo", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slblTitleSabra.ForeColor = Color.White;
            slblTitleSabra.Location = new Point(455, 12);
            slblTitleSabra.Name = "slblTitleSabra";
            slblTitleSabra.RightToLeft = RightToLeft.Yes;
            slblTitleSabra.Size = new Size(322, 75);
            slblTitleSabra.TabIndex = 8;
            slblTitleSabra.Text = "صبـــــــــــــــــــــره";
            slblTitleSabra.TextAlign = ContentAlignment.MiddleRight;
            // 
            // slblTitleForSpare
            // 
            slblTitleForSpare.AutoSize = true;
            slblTitleForSpare.BackColor = Color.Transparent;
            slblTitleForSpare.BorderColor = Color.DeepSkyBlue;
            slblTitleForSpare.Font = new Font("Cairo", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slblTitleForSpare.ForeColor = Color.White;
            slblTitleForSpare.Location = new Point(455, 97);
            slblTitleForSpare.Name = "slblTitleForSpare";
            slblTitleForSpare.RightToLeft = RightToLeft.Yes;
            slblTitleForSpare.Size = new Size(124, 75);
            slblTitleForSpare.TabIndex = 9;
            slblTitleForSpare.Text = "لقطع";
            slblTitleForSpare.TextAlign = ContentAlignment.MiddleRight;
            // 
            // slblTitleCarParats
            // 
            slblTitleCarParats.AutoSize = true;
            slblTitleCarParats.BackColor = Color.Transparent;
            slblTitleCarParats.BorderColor = Color.DeepSkyBlue;
            slblTitleCarParats.Font = new Font("Cairo", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slblTitleCarParats.ForeColor = Color.White;
            slblTitleCarParats.Location = new Point(455, 172);
            slblTitleCarParats.Name = "slblTitleCarParats";
            slblTitleCarParats.RightToLeft = RightToLeft.Yes;
            slblTitleCarParats.Size = new Size(344, 75);
            slblTitleCarParats.TabIndex = 10;
            slblTitleCarParats.Text = "غيار السيـــــــــــارات";
            slblTitleCarParats.TextAlign = ContentAlignment.MiddleRight;
            // 
            // slblEnglishTitle
            // 
            slblEnglishTitle.AutoSize = true;
            slblEnglishTitle.BackColor = Color.Transparent;
            slblEnglishTitle.BorderColor = Color.FromArgb(15, 23, 42);
            slblEnglishTitle.Font = new Font("Century Schoolbook", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            slblEnglishTitle.ForeColor = Color.White;
            slblEnglishTitle.Location = new Point(505, 266);
            slblEnglishTitle.Name = "slblEnglishTitle";
            slblEnglishTitle.RightToLeft = RightToLeft.Yes;
            slblEnglishTitle.Size = new Size(231, 22);
            slblEnglishTitle.TabIndex = 11;
            slblEnglishTitle.Text = "Sabra For Car Spare Parts";
            slblEnglishTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // slblAppVersion
            // 
            slblAppVersion.AutoSize = true;
            slblAppVersion.BackColor = Color.Transparent;
            slblAppVersion.BorderColor = Color.FromArgb(15, 23, 42);
            slblAppVersion.Font = new Font("Copperplate Gothic Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slblAppVersion.ForeColor = Color.White;
            slblAppVersion.Location = new Point(589, 311);
            slblAppVersion.Name = "slblAppVersion";
            slblAppVersion.RightToLeft = RightToLeft.Yes;
            slblAppVersion.Size = new Size(44, 21);
            slblAppVersion.TabIndex = 12;
            slblAppVersion.Text = "V.0";
            slblAppVersion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // stbxUserName
            // 
            stbxUserName.BackColor = Color.FromArgb(15, 23, 42);
            stbxUserName.BorderColor = Color.DarkGray;
            stbxUserName.BorderFocusColor = Color.White;
            stbxUserName.BorderSize = 3;
            stbxUserName.Font = new Font("Cairo", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stbxUserName.ForeColor = Color.White;
            stbxUserName.Location = new Point(18, 60);
            stbxUserName.Name = "stbxUserName";
            stbxUserName.Padding = new Padding(10, 7, 25, 7);
            stbxUserName.PlaceholderText = "أدخل أسم المستخدم...";
            stbxUserName.Required = true;
            stbxUserName.RightToLeft = RightToLeft.Yes;
            stbxUserName.SelectedText = "";
            stbxUserName.SelectionLength = 0;
            stbxUserName.SelectionStart = 0;
            stbxUserName.Size = new Size(381, 58);
            stbxUserName.TabIndex = 13;
            stbxUserName.Texts = "";
            // 
            // stbnLogin
            // 
            stbnLogin.BackColor = Color.DimGray;
            stbnLogin.BorderColor = Color.FloralWhite;
            stbnLogin.BorderRadius = 20;
            stbnLogin.BorderSize = 0;
            stbnLogin.FlatAppearance.BorderSize = 0;
            stbnLogin.FlatStyle = FlatStyle.Flat;
            stbnLogin.Font = new Font("Cairo", 10F, FontStyle.Bold);
            stbnLogin.ForeColor = Color.White;
            stbnLogin.HoverColor = Color.White;
            stbnLogin.IconChar = FontAwesome.Sharp.IconChar.LockOpen;
            stbnLogin.IconColor = Color.FromArgb(15, 23, 42);
            stbnLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            stbnLogin.Location = new Point(18, 266);
            stbnLogin.Name = "stbnLogin";
            stbnLogin.NormalColor = Color.DimGray;
            stbnLogin.Size = new Size(228, 60);
            stbnLogin.TabIndex = 15;
            stbnLogin.UseVisualStyleBackColor = false;
            stbnLogin.Click += stbnLogin_Click;
            // 
            // sbtnCancelLogin
            // 
            sbtnCancelLogin.BackColor = Color.DimGray;
            sbtnCancelLogin.BorderColor = Color.FloralWhite;
            sbtnCancelLogin.BorderRadius = 20;
            sbtnCancelLogin.BorderSize = 0;
            sbtnCancelLogin.FlatAppearance.BorderSize = 0;
            sbtnCancelLogin.FlatStyle = FlatStyle.Flat;
            sbtnCancelLogin.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnCancelLogin.ForeColor = Color.White;
            sbtnCancelLogin.HoverColor = Color.White;
            sbtnCancelLogin.IconChar = FontAwesome.Sharp.IconChar.X;
            sbtnCancelLogin.IconColor = Color.FromArgb(15, 23, 42);
            sbtnCancelLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnCancelLogin.Location = new Point(269, 266);
            sbtnCancelLogin.Name = "sbtnCancelLogin";
            sbtnCancelLogin.NormalColor = Color.DimGray;
            sbtnCancelLogin.Size = new Size(120, 60);
            sbtnCancelLogin.TabIndex = 16;
            sbtnCancelLogin.UseVisualStyleBackColor = false;
            sbtnCancelLogin.Click += sbtnCancelLogin_Click;
            // 
            // stbxPassowrd
            // 
            stbxPassowrd.BackColor = Color.FromArgb(15, 23, 42);
            stbxPassowrd.BorderColor = Color.DarkGray;
            stbxPassowrd.BorderFocusColor = Color.White;
            stbxPassowrd.BorderSize = 3;
            stbxPassowrd.Font = new Font("Cairo", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stbxPassowrd.ForeColor = Color.White;
            stbxPassowrd.Location = new Point(18, 141);
            stbxPassowrd.Name = "stbxPassowrd";
            stbxPassowrd.Padding = new Padding(10, 7, 25, 7);
            stbxPassowrd.PasswordChar = true;
            stbxPassowrd.PlaceholderText = "أدخل كلمة المرور هنا....";
            stbxPassowrd.Required = true;
            stbxPassowrd.RightToLeft = RightToLeft.Yes;
            stbxPassowrd.SelectedText = "";
            stbxPassowrd.SelectionLength = 0;
            stbxPassowrd.SelectionStart = 0;
            stbxPassowrd.Size = new Size(381, 58);
            stbxPassowrd.TabIndex = 17;
            stbxPassowrd.Texts = "";
            // 
            // cbxPasswordVisibility
            // 
            cbxPasswordVisibility.AutoSize = true;
            cbxPasswordVisibility.Font = new Font("Cairo", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxPasswordVisibility.ForeColor = Color.White;
            cbxPasswordVisibility.Location = new Point(18, 211);
            cbxPasswordVisibility.Name = "cbxPasswordVisibility";
            cbxPasswordVisibility.Size = new Size(155, 36);
            cbxPasswordVisibility.TabIndex = 18;
            cbxPasswordVisibility.Text = "عرض كلمة المرور";
            cbxPasswordVisibility.UseVisualStyleBackColor = true;
            cbxPasswordVisibility.CheckedChanged += cbxPasswordVisibility_CheckedChanged;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(811, 359);
            ControlBox = false;
            Controls.Add(cbxPasswordVisibility);
            Controls.Add(stbxPassowrd);
            Controls.Add(sbtnCancelLogin);
            Controls.Add(stbnLogin);
            Controls.Add(stbxUserName);
            Controls.Add(slblAppVersion);
            Controls.Add(slblEnglishTitle);
            Controls.Add(slblTitleCarParats);
            Controls.Add(slblTitleForSpare);
            Controls.Add(slblTitleSabra);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تسجيل الدخول";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SabraLabel slblTitleSabra;
        private SabraLabel slblTitleForSpare;
        private SabraLabel slblTitleCarParats;
        private SabraLabel slblEnglishTitle;
        private SabraLabel slblAppVersion;
        private SabraTextBox stbxUserName;
        private SabraButton stbnLogin;
        private SabraButton sbtnCancelLogin;
        private SabraTextBox stbxPassowrd;
        private CheckBox cbxPasswordVisibility;
    }
}