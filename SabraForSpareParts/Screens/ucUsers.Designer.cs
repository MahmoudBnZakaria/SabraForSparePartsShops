namespace SabraForSpareParts.Screens
{
    partial class ucUsers
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
            sbtnAddNewUser = new SabraButton();
            sbtnExportAsExcel = new SabraButton();
            slblTitleOfTopPanel = new SabraLabel();
            icnSalary = new FontAwesome.Sharp.IconPictureBox();
            lblNumberOfUsers = new SabraLabel();
            sabraFlowLayoutPanelContainerOfCards = new SabraFlowLayoutPanel();
            sabraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icnSalary).BeginInit();
            SuspendLayout();
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.White;
            sabraPanel1.BorderColor = Color.LightGray;
            sabraPanel1.BorderRadius = 15;
            sabraPanel1.BorderSize = 1;
            sabraPanel1.Controls.Add(sbtnAddNewUser);
            sabraPanel1.Controls.Add(sbtnExportAsExcel);
            sabraPanel1.Controls.Add(slblTitleOfTopPanel);
            sabraPanel1.Controls.Add(icnSalary);
            sabraPanel1.Controls.Add(lblNumberOfUsers);
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
            sabraPanel1.Size = new Size(1502, 111);
            sabraPanel1.TabIndex = 4;
            // 
            // sbtnAddNewUser
            // 
            sbtnAddNewUser.BackColor = Color.RoyalBlue;
            sbtnAddNewUser.BorderColor = Color.DodgerBlue;
            sbtnAddNewUser.BorderRadius = 20;
            sbtnAddNewUser.BorderSize = 0;
            sbtnAddNewUser.FlatAppearance.BorderSize = 0;
            sbtnAddNewUser.FlatStyle = FlatStyle.Flat;
            sbtnAddNewUser.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnAddNewUser.ForeColor = Color.White;
            sbtnAddNewUser.HoverColor = Color.CornflowerBlue;
            sbtnAddNewUser.IconChar = FontAwesome.Sharp.IconChar.Add;
            sbtnAddNewUser.IconColor = Color.White;
            sbtnAddNewUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnAddNewUser.IconSize = 30;
            sbtnAddNewUser.ImageAlign = ContentAlignment.MiddleRight;
            sbtnAddNewUser.Location = new Point(34, 23);
            sbtnAddNewUser.Name = "sbtnAddNewUser";
            sbtnAddNewUser.NormalColor = Color.RoyalBlue;
            sbtnAddNewUser.Size = new Size(165, 70);
            sbtnAddNewUser.TabIndex = 20;
            sbtnAddNewUser.Text = "إضافة مستخدم";
            sbtnAddNewUser.TextAlign = ContentAlignment.MiddleLeft;
            sbtnAddNewUser.UseVisualStyleBackColor = false;
            sbtnAddNewUser.Click += sbtnAddNewUser_Click;
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
            sbtnExportAsExcel.Location = new Point(233, 26);
            sbtnExportAsExcel.Name = "sbtnExportAsExcel";
            sbtnExportAsExcel.NormalColor = Color.Green;
            sbtnExportAsExcel.Padding = new Padding(10, 0, 10, 0);
            sbtnExportAsExcel.Size = new Size(157, 65);
            sbtnExportAsExcel.TabIndex = 19;
            sbtnExportAsExcel.Text = "تصدير Excel";
            sbtnExportAsExcel.TextAlign = ContentAlignment.MiddleLeft;
            sbtnExportAsExcel.UseVisualStyleBackColor = false;
            sbtnExportAsExcel.Click += sbtnExportAsExcel_Click;
            // 
            // slblTitleOfTopPanel
            // 
            slblTitleOfTopPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblTitleOfTopPanel.AutoSize = true;
            slblTitleOfTopPanel.BackColor = Color.Transparent;
            slblTitleOfTopPanel.Font = new Font("Cairo", 18F, FontStyle.Bold);
            slblTitleOfTopPanel.ForeColor = Color.FromArgb(40, 40, 40);
            slblTitleOfTopPanel.Location = new Point(1017, 5);
            slblTitleOfTopPanel.Name = "slblTitleOfTopPanel";
            slblTitleOfTopPanel.RightToLeft = RightToLeft.Yes;
            slblTitleOfTopPanel.Size = new Size(350, 56);
            slblTitleOfTopPanel.TabIndex = 15;
            slblTitleOfTopPanel.Text = "المستخدمين والصلاحيات";
            slblTitleOfTopPanel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // icnSalary
            // 
            icnSalary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icnSalary.BackColor = Color.Transparent;
            icnSalary.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnSalary.ForeColor = Color.RoyalBlue;
            icnSalary.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            icnSalary.IconColor = Color.RoyalBlue;
            icnSalary.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnSalary.IconSize = 65;
            icnSalary.Location = new Point(1373, 23);
            icnSalary.Name = "icnSalary";
            icnSalary.Size = new Size(72, 65);
            icnSalary.SizeMode = PictureBoxSizeMode.Zoom;
            icnSalary.TabIndex = 14;
            icnSalary.TabStop = false;
            // 
            // lblNumberOfUsers
            // 
            lblNumberOfUsers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNumberOfUsers.BackColor = Color.Transparent;
            lblNumberOfUsers.Font = new Font("Cairo", 12F);
            lblNumberOfUsers.ForeColor = SystemColors.WindowFrame;
            lblNumberOfUsers.Location = new Point(1134, 56);
            lblNumberOfUsers.Name = "lblNumberOfUsers";
            lblNumberOfUsers.RightToLeft = RightToLeft.Yes;
            lblNumberOfUsers.Size = new Size(233, 37);
            lblNumberOfUsers.TabIndex = 16;
            lblNumberOfUsers.Text = "3 مستخدمين مسجلين";
            lblNumberOfUsers.TextAlign = ContentAlignment.MiddleRight;
            lblNumberOfUsers.Click += lblNumberOfUsers_Click;
            // 
            // sabraFlowLayoutPanelContainerOfCards
            // 
            sabraFlowLayoutPanelContainerOfCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sabraFlowLayoutPanelContainerOfCards.AutoScroll = true;
            sabraFlowLayoutPanelContainerOfCards.BackColor = Color.WhiteSmoke;
            sabraFlowLayoutPanelContainerOfCards.BorderColor = Color.Transparent;
            sabraFlowLayoutPanelContainerOfCards.BorderRadius = 20;
            sabraFlowLayoutPanelContainerOfCards.BorderSize = 1;
            sabraFlowLayoutPanelContainerOfCards.Location = new Point(44, 148);
            sabraFlowLayoutPanelContainerOfCards.Name = "sabraFlowLayoutPanelContainerOfCards";
            sabraFlowLayoutPanelContainerOfCards.Size = new Size(1411, 723);
            sabraFlowLayoutPanelContainerOfCards.TabIndex = 6;
            // 
            // ucUsers
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sabraFlowLayoutPanelContainerOfCards);
            Controls.Add(sabraPanel1);
            Name = "ucUsers";
            Load += ucUsers_Load;
            sabraPanel1.ResumeLayout(false);
            sabraPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icnSalary).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraPanel sabraPanel1;
        private SabraButton sbtnPurchaseOrder;
        private FontAwesome.Sharp.IconPictureBox icnSalary;
        private SabraLabel slblTitleOfTopPanel;
        private SabraLabel lblNumberOfUsers;
        private SabraLabel lblTotalPurchases;
        private SabraLabel lblNumberOfOrdars;
        private SabraLabel lblTotalPaid;
        private SabraFlowLayoutPanel sabraFlowLayoutPanelContainerOfCards;
        private SabraButton sbtnExportAsExcel;
        private SabraButton sbtnAddNewUser;
    }
}
