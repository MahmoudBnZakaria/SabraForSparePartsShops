namespace SabraForSpareParts.Screens
{
    partial class ucUserCard
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
            fwPbxUserAvatar = new FontAwesome.Sharp.IconPictureBox();
            slblName = new SabraLabel();
            lblUsername = new SabraLabel();
            slblRole = new SabraLabel();
            lblIsActive = new SabraLabel();
            sbtnEdit = new SabraButton();
            sbtnPassword = new SabraButton();
            ((System.ComponentModel.ISupportInitialize)fwPbxUserAvatar).BeginInit();
            SuspendLayout();
            // 
            // fwPbxUserAvatar
            // 
            fwPbxUserAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            fwPbxUserAvatar.BackColor = Color.WhiteSmoke;
            fwPbxUserAvatar.ForeColor = Color.RoyalBlue;
            fwPbxUserAvatar.IconChar = FontAwesome.Sharp.IconChar.UserLarge;
            fwPbxUserAvatar.IconColor = Color.RoyalBlue;
            fwPbxUserAvatar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            fwPbxUserAvatar.IconSize = 76;
            fwPbxUserAvatar.Location = new Point(206, 13);
            fwPbxUserAvatar.Name = "fwPbxUserAvatar";
            fwPbxUserAvatar.Size = new Size(79, 76);
            fwPbxUserAvatar.TabIndex = 1;
            fwPbxUserAvatar.TabStop = false;
            fwPbxUserAvatar.Click += fwPbxUserAvatar_Click;
            // 
            // slblName
            // 
            slblName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblName.BackColor = Color.Transparent;
            slblName.Font = new Font("Cairo", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            slblName.ForeColor = Color.FromArgb(40, 40, 40);
            slblName.Location = new Point(102, 92);
            slblName.Name = "slblName";
            slblName.RightToLeft = RightToLeft.Yes;
            slblName.Size = new Size(183, 40);
            slblName.TabIndex = 17;
            slblName.Text = "محمد أحمد";
            slblName.TextAlign = ContentAlignment.MiddleRight;
            slblName.Click += slblName_Click;
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Cairo", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = SystemColors.WindowFrame;
            lblUsername.Location = new Point(164, 132);
            lblUsername.Name = "lblUsername";
            lblUsername.RightToLeft = RightToLeft.Yes;
            lblUsername.Size = new Size(121, 37);
            lblUsername.TabIndex = 18;
            lblUsername.Text = "admin";
            lblUsername.TextAlign = ContentAlignment.MiddleRight;
            lblUsername.Click += lblUserRole_Click;
            // 
            // slblRole
            // 
            slblRole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            slblRole.BackColor = Color.FromArgb(240, 253, 244);
            slblRole.BorderColor = Color.Green;
            slblRole.BorderRadius = 20;
            slblRole.BorderSize = 1;
            slblRole.Font = new Font("Cairo", 10F);
            slblRole.ForeColor = Color.Green;
            slblRole.Location = new Point(130, 184);
            slblRole.Name = "slblRole";
            slblRole.RightToLeft = RightToLeft.Yes;
            slblRole.Size = new Size(155, 32);
            slblRole.TabIndex = 19;
            slblRole.Text = "مدير";
            slblRole.TextAlign = ContentAlignment.MiddleCenter;
            slblRole.Click += slblRole_Click;
            // 
            // lblIsActive
            // 
            lblIsActive.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblIsActive.BackColor = Color.FromArgb(239, 246, 255);
            lblIsActive.BorderColor = SystemColors.GrayText;
            lblIsActive.BorderRadius = 20;
            lblIsActive.BorderSize = 1;
            lblIsActive.Font = new Font("Cairo", 10F);
            lblIsActive.ForeColor = Color.FromArgb(50, 109, 236);
            lblIsActive.Location = new Point(13, 184);
            lblIsActive.Name = "lblIsActive";
            lblIsActive.RightToLeft = RightToLeft.Yes;
            lblIsActive.Size = new Size(111, 32);
            lblIsActive.TabIndex = 20;
            lblIsActive.Text = "نشط";
            lblIsActive.TextAlign = ContentAlignment.MiddleCenter;
            lblIsActive.Click += lblIsActive_Click;
            // 
            // sbtnEdit
            // 
            sbtnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sbtnEdit.BackColor = Color.White;
            sbtnEdit.BorderColor = Color.DimGray;
            sbtnEdit.BorderRadius = 20;
            sbtnEdit.BorderSize = 1;
            sbtnEdit.FlatAppearance.BorderSize = 0;
            sbtnEdit.FlatStyle = FlatStyle.Flat;
            sbtnEdit.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnEdit.ForeColor = Color.DimGray;
            sbtnEdit.HoverColor = Color.CornflowerBlue;
            sbtnEdit.IconChar = FontAwesome.Sharp.IconChar.None;
            sbtnEdit.IconColor = Color.Beige;
            sbtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnEdit.IconSize = 30;
            sbtnEdit.ImageAlign = ContentAlignment.MiddleRight;
            sbtnEdit.Location = new Point(183, 234);
            sbtnEdit.MaximumSize = new Size(150, 41);
            sbtnEdit.Name = "sbtnEdit";
            sbtnEdit.NormalColor = Color.White;
            sbtnEdit.Padding = new Padding(10, 0, 10, 0);
            sbtnEdit.Size = new Size(102, 41);
            sbtnEdit.TabIndex = 47;
            sbtnEdit.Text = "تعديل";
            sbtnEdit.TextAlign = ContentAlignment.TopCenter;
            sbtnEdit.UseVisualStyleBackColor = false;
            sbtnEdit.Click += sbtnEdit_Click;
            // 
            // sbtnPassword
            // 
            sbtnPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sbtnPassword.BackColor = Color.White;
            sbtnPassword.BorderColor = Color.DimGray;
            sbtnPassword.BorderRadius = 20;
            sbtnPassword.BorderSize = 1;
            sbtnPassword.FlatAppearance.BorderSize = 0;
            sbtnPassword.FlatStyle = FlatStyle.Flat;
            sbtnPassword.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnPassword.ForeColor = Color.DimGray;
            sbtnPassword.HoverColor = Color.CornflowerBlue;
            sbtnPassword.IconChar = FontAwesome.Sharp.IconChar.None;
            sbtnPassword.IconColor = Color.Beige;
            sbtnPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnPassword.IconSize = 30;
            sbtnPassword.ImageAlign = ContentAlignment.MiddleRight;
            sbtnPassword.Location = new Point(13, 234);
            sbtnPassword.MaximumSize = new Size(150, 41);
            sbtnPassword.Name = "sbtnPassword";
            sbtnPassword.NormalColor = Color.White;
            sbtnPassword.Padding = new Padding(10, 0, 10, 0);
            sbtnPassword.Size = new Size(150, 41);
            sbtnPassword.TabIndex = 48;
            sbtnPassword.Text = "كلمة المرور";
            sbtnPassword.TextAlign = ContentAlignment.TopCenter;
            sbtnPassword.UseVisualStyleBackColor = false;
            sbtnPassword.Click += sbtnPassword_Click;
            // 
            // ucUserCard
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = false;
            AutoScrollMinSize = new Size(0, 0);
            BorderRadius = 15;
            Controls.Add(sbtnPassword);
            Controls.Add(sbtnEdit);
            Controls.Add(lblIsActive);
            Controls.Add(slblRole);
            Controls.Add(slblName);
            Controls.Add(lblUsername);
            Controls.Add(fwPbxUserAvatar);
            MinimumSize = new Size(298, 288);
            Name = "ucUserCard";
            Size = new Size(298, 288);
            ((System.ComponentModel.ISupportInitialize)fwPbxUserAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox fwPbxUserAvatar;
        private SabraLabel slblName;
        private SabraLabel lblUsername;
        private SabraLabel slblRole;
        private SabraLabel lblIsActive;
        private SabraButton sbtnEdit;
        private SabraButton sbtnPassword;
    }
}
