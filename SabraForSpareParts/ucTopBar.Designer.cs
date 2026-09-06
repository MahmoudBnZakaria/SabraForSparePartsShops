namespace SabraForSpareParts
{
    partial class ucTopBar
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
            lblProgramName = new Label();
            AddNewPart = new FontAwesome.Sharp.IconButton();
            btnNewInvoice = new FontAwesome.Sharp.IconButton();
            btnInverntoryAlerts = new FontAwesome.Sharp.IconButton();
            fwPbxUserAvatar = new FontAwesome.Sharp.IconPictureBox();
            slblUsername = new SabraLabel();
            ((System.ComponentModel.ISupportInitialize)fwPbxUserAvatar).BeginInit();
            SuspendLayout();
            // 
            // lblProgramName
            // 
            lblProgramName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblProgramName.AutoSize = true;
            lblProgramName.BackColor = Color.White;
            lblProgramName.Font = new Font("Cairo Black", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgramName.ForeColor = Color.FromArgb(15, 23, 42);
            lblProgramName.Location = new Point(1213, 15);
            lblProgramName.Name = "lblProgramName";
            lblProgramName.Size = new Size(282, 43);
            lblProgramName.TabIndex = 0;
            lblProgramName.Text = "صبره لقطع غيار السيارات";
            // 
            // AddNewPart
            // 
            AddNewPart.BackColor = Color.White;
            AddNewPart.ForeColor = Color.Violet;
            AddNewPart.IconChar = FontAwesome.Sharp.IconChar.Add;
            AddNewPart.IconColor = Color.RoyalBlue;
            AddNewPart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AddNewPart.Location = new Point(486, 9);
            AddNewPart.Name = "AddNewPart";
            AddNewPart.Size = new Size(52, 61);
            AddNewPart.TabIndex = 6;
            AddNewPart.UseVisualStyleBackColor = false;
            AddNewPart.Click += AddNewPart_Click;
            // 
            // btnNewInvoice
            // 
            btnNewInvoice.BackColor = Color.White;
            btnNewInvoice.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            btnNewInvoice.IconColor = Color.RoyalBlue;
            btnNewInvoice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNewInvoice.Location = new Point(414, 9);
            btnNewInvoice.Name = "btnNewInvoice";
            btnNewInvoice.Size = new Size(52, 61);
            btnNewInvoice.TabIndex = 7;
            btnNewInvoice.UseVisualStyleBackColor = false;
            btnNewInvoice.Click += btnNewInvoice_Click;
            // 
            // btnInverntoryAlerts
            // 
            btnInverntoryAlerts.BackColor = Color.White;
            btnInverntoryAlerts.IconChar = FontAwesome.Sharp.IconChar.Warning;
            btnInverntoryAlerts.IconColor = Color.RoyalBlue;
            btnInverntoryAlerts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInverntoryAlerts.Location = new Point(342, 9);
            btnInverntoryAlerts.Name = "btnInverntoryAlerts";
            btnInverntoryAlerts.Size = new Size(52, 61);
            btnInverntoryAlerts.TabIndex = 8;
            btnInverntoryAlerts.UseVisualStyleBackColor = false;
            btnInverntoryAlerts.Click += btnInverntoryAlerts_Click;
            // 
            // fwPbxUserAvatar
            // 
            fwPbxUserAvatar.BackColor = Color.White;
            fwPbxUserAvatar.ForeColor = Color.RoyalBlue;
            fwPbxUserAvatar.IconChar = FontAwesome.Sharp.IconChar.UserLarge;
            fwPbxUserAvatar.IconColor = Color.RoyalBlue;
            fwPbxUserAvatar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            fwPbxUserAvatar.IconSize = 45;
            fwPbxUserAvatar.Location = new Point(200, 20);
            fwPbxUserAvatar.Name = "fwPbxUserAvatar";
            fwPbxUserAvatar.Size = new Size(45, 45);
            fwPbxUserAvatar.TabIndex = 9;
            fwPbxUserAvatar.TabStop = false;
            fwPbxUserAvatar.Click += fwPbxUserAvatar_Click;
            // 
            // slblUsername
            // 
            slblUsername.BackColor = Color.White;
            slblUsername.BorderColor = Color.DimGray;
            slblUsername.BorderRadius = 20;
            slblUsername.BorderSize = 1;
            slblUsername.Font = new Font("Cairo", 15F);
            slblUsername.ForeColor = Color.RoyalBlue;
            slblUsername.Location = new Point(18, 15);
            slblUsername.Name = "slblUsername";
            slblUsername.RightToLeft = RightToLeft.Yes;
            slblUsername.Size = new Size(176, 52);
            slblUsername.TabIndex = 15;
            slblUsername.Text = "أحمد محمد";
            slblUsername.TextAlign = ContentAlignment.MiddleCenter;
            slblUsername.Click += slblUsername_Click;
            // 
            // ucTopBar
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScrollMinSize = new Size(0, 0);
            BackColor = Color.White;
            BorderColor = Color.Gray;
            BorderRadius = 15;
            BorderSize = 3;
            Controls.Add(slblUsername);
            Controls.Add(fwPbxUserAvatar);
            Controls.Add(btnInverntoryAlerts);
            Controls.Add(btnNewInvoice);
            Controls.Add(AddNewPart);
            Controls.Add(lblProgramName);
            MinimumSize = new Size(1493, 83);
            Name = "ucTopBar";
            Padding = new Padding(0);
            Size = new Size(1495, 83);
            Load += ucTopBar_Load;
            ((System.ComponentModel.ISupportInitialize)fwPbxUserAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProgramName;
        private FontAwesome.Sharp.IconButton AddNewPart;
        private FontAwesome.Sharp.IconButton btnNewInvoice;
        private FontAwesome.Sharp.IconButton btnInverntoryAlerts;
        private FontAwesome.Sharp.IconPictureBox fwPbxUserAvatar;
        private SabraLabel slblUsername;
    }
}
