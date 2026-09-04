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
            sbtnSearchForCustomerInvoicePart = new SabraTextBox();
            AddNewPart = new FontAwesome.Sharp.IconButton();
            btnNewInvoice = new FontAwesome.Sharp.IconButton();
            btnInverntoryAlerts = new FontAwesome.Sharp.IconButton();
            fwPbxUserAvatar = new FontAwesome.Sharp.IconPictureBox();
            slblCustomerNameAndCreditLimit = new SabraLabel();
            sbtnSearch = new SabraButton();
            ((System.ComponentModel.ISupportInitialize)fwPbxUserAvatar).BeginInit();
            SuspendLayout();
            // 
            // lblProgramName
            // 
            lblProgramName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblProgramName.AutoSize = true;
            lblProgramName.Font = new Font("Cairo Black", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgramName.ForeColor = Color.DarkGray;
            lblProgramName.Location = new Point(1189, 18);
            lblProgramName.Name = "lblProgramName";
            lblProgramName.Size = new Size(282, 43);
            lblProgramName.TabIndex = 0;
            lblProgramName.Text = "صبره لقطع غيار السيارات";
            // 
            // sbtnSearchForCustomerInvoicePart
            // 
            sbtnSearchForCustomerInvoicePart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbtnSearchForCustomerInvoicePart.BackColor = Color.White;
            sbtnSearchForCustomerInvoicePart.BorderColor = Color.DimGray;
            sbtnSearchForCustomerInvoicePart.Font = new Font("Cairo", 10F);
            sbtnSearchForCustomerInvoicePart.ForeColor = Color.FromArgb(64, 64, 64);
            sbtnSearchForCustomerInvoicePart.Location = new Point(694, 18);
            sbtnSearchForCustomerInvoicePart.Name = "sbtnSearchForCustomerInvoicePart";
            sbtnSearchForCustomerInvoicePart.Padding = new Padding(10, 7, 25, 7);
            sbtnSearchForCustomerInvoicePart.PlaceholderText = "ابحث عن فاتورة، عميل، قعطة...";
            sbtnSearchForCustomerInvoicePart.RightToLeft = RightToLeft.Yes;
            sbtnSearchForCustomerInvoicePart.SelectedText = "";
            sbtnSearchForCustomerInvoicePart.SelectionLength = 0;
            sbtnSearchForCustomerInvoicePart.SelectionStart = 0;
            sbtnSearchForCustomerInvoicePart.Size = new Size(446, 47);
            sbtnSearchForCustomerInvoicePart.TabIndex = 5;
            sbtnSearchForCustomerInvoicePart.Texts = "";
            sbtnSearchForCustomerInvoicePart.Load += sbtnSearchForCustomerInvoicePart_Load;
            sbtnSearchForCustomerInvoicePart.KeyDown += sbtnSearchForCustomerInvoicePart_KeyDown;
            sbtnSearchForCustomerInvoicePart.KeyPress += sbtnSearchForCustomerInvoicePart_KeyPress;
            // 
            // AddNewPart
            // 
            AddNewPart.BackColor = Color.White;
            AddNewPart.IconChar = FontAwesome.Sharp.IconChar.Add;
            AddNewPart.IconColor = Color.RoyalBlue;
            AddNewPart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AddNewPart.Location = new Point(478, 9);
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
            btnNewInvoice.Location = new Point(405, 9);
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
            btnInverntoryAlerts.Location = new Point(333, 9);
            btnInverntoryAlerts.Name = "btnInverntoryAlerts";
            btnInverntoryAlerts.Size = new Size(52, 61);
            btnInverntoryAlerts.TabIndex = 8;
            btnInverntoryAlerts.UseVisualStyleBackColor = false;
            btnInverntoryAlerts.Click += btnInverntoryAlerts_Click;
            // 
            // fwPbxUserAvatar
            // 
            fwPbxUserAvatar.BackColor = SystemColors.Window;
            fwPbxUserAvatar.ForeColor = Color.Gray;
            fwPbxUserAvatar.IconChar = FontAwesome.Sharp.IconChar.UserLarge;
            fwPbxUserAvatar.IconColor = Color.Gray;
            fwPbxUserAvatar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            fwPbxUserAvatar.IconSize = 45;
            fwPbxUserAvatar.Location = new Point(202, 20);
            fwPbxUserAvatar.Name = "fwPbxUserAvatar";
            fwPbxUserAvatar.Size = new Size(45, 45);
            fwPbxUserAvatar.TabIndex = 9;
            fwPbxUserAvatar.TabStop = false;
            fwPbxUserAvatar.Click += fwPbxUserAvatar_Click;
            // 
            // slblCustomerNameAndCreditLimit
            // 
            slblCustomerNameAndCreditLimit.BackColor = Color.White;
            slblCustomerNameAndCreditLimit.BorderColor = Color.DimGray;
            slblCustomerNameAndCreditLimit.BorderRadius = 20;
            slblCustomerNameAndCreditLimit.BorderSize = 1;
            slblCustomerNameAndCreditLimit.Font = new Font("Cairo", 15F);
            slblCustomerNameAndCreditLimit.ForeColor = Color.DimGray;
            slblCustomerNameAndCreditLimit.Location = new Point(20, 13);
            slblCustomerNameAndCreditLimit.Name = "slblCustomerNameAndCreditLimit";
            slblCustomerNameAndCreditLimit.RightToLeft = RightToLeft.Yes;
            slblCustomerNameAndCreditLimit.Size = new Size(176, 52);
            slblCustomerNameAndCreditLimit.TabIndex = 15;
            slblCustomerNameAndCreditLimit.Text = "أحمد محمد";
            slblCustomerNameAndCreditLimit.TextAlign = ContentAlignment.MiddleCenter;
            slblCustomerNameAndCreditLimit.Click += lblCurrentUserName;
            // 
            // sbtnSearch
            // 
            sbtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbtnSearch.BackColor = Color.RoyalBlue;
            sbtnSearch.BorderColor = Color.Gray;
            sbtnSearch.BorderRadius = 15;
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
            sbtnSearch.Location = new Point(627, 20);
            sbtnSearch.Name = "sbtnSearch";
            sbtnSearch.NormalColor = Color.RoyalBlue;
            sbtnSearch.Padding = new Padding(10, 0, 10, 0);
            sbtnSearch.Size = new Size(61, 45);
            sbtnSearch.TabIndex = 23;
            sbtnSearch.TextAlign = ContentAlignment.MiddleLeft;
            sbtnSearch.UseVisualStyleBackColor = false;
            sbtnSearch.Click += sbtnSearch_Click;
            // 
            // ucTopBar
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScrollMinSize = new Size(0, 0);
            BackColor = Color.White;
            BorderRadius = 15;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(sbtnSearch);
            Controls.Add(slblCustomerNameAndCreditLimit);
            Controls.Add(fwPbxUserAvatar);
            Controls.Add(btnInverntoryAlerts);
            Controls.Add(btnNewInvoice);
            Controls.Add(AddNewPart);
            Controls.Add(sbtnSearchForCustomerInvoicePart);
            Controls.Add(lblProgramName);
            MinimumSize = new Size(1493, 83);
            Name = "ucTopBar";
            Size = new Size(1493, 83);
            ((System.ComponentModel.ISupportInitialize)fwPbxUserAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProgramName;
        private SabraTextBox sbtnSearchForCustomerInvoicePart;
        private FontAwesome.Sharp.IconButton AddNewPart;
        private FontAwesome.Sharp.IconButton btnNewInvoice;
        private FontAwesome.Sharp.IconButton btnInverntoryAlerts;
        private FontAwesome.Sharp.IconPictureBox fwPbxUserAvatar;
        private SabraLabel slblCustomerNameAndCreditLimit;
        private SabraButton sbtnSearch;
    }
}
