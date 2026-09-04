namespace SabraForSpareParts.Screens
{
    partial class ucInvoiceRow
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
            lblCustomerName = new SabraLabel();
            lblAmount = new SabraLabel();
            lblInvoiceID = new SabraLabel();
            lblStatus = new SabraLabel();
            SuspendLayout();
            // 
            // lblCustomerName
            // 
            lblCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCustomerName.AutoSize = true;
            lblCustomerName.BackColor = Color.Transparent;
            lblCustomerName.Font = new Font("Cairo", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.FromArgb(71, 85, 105);
            lblCustomerName.Location = new Point(153, 8);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.RightToLeft = RightToLeft.Yes;
            lblCustomerName.Size = new Size(75, 29);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "ورشة النيل";
            lblCustomerName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.BackColor = Color.Transparent;
            lblAmount.Font = new Font("Cairo", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAmount.ForeColor = Color.FromArgb(15, 23, 42);
            lblAmount.Location = new Point(76, 7);
            lblAmount.Name = "lblAmount";
            lblAmount.RightToLeft = RightToLeft.Yes;
            lblAmount.Size = new Size(61, 29);
            lblAmount.TabIndex = 1;
            lblAmount.Text = "3,200 ج";
            lblAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInvoiceID
            // 
            lblInvoiceID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInvoiceID.BackColor = Color.FromArgb(239, 246, 255);
            lblInvoiceID.BorderColor = Color.Transparent;
            lblInvoiceID.BorderRadius = 14;
            lblInvoiceID.Font = new Font("Cairo", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInvoiceID.ForeColor = Color.FromArgb(37, 99, 235);
            lblInvoiceID.Location = new Point(244, 9);
            lblInvoiceID.Name = "lblInvoiceID";
            lblInvoiceID.RightToLeft = RightToLeft.Yes;
            lblInvoiceID.Size = new Size(55, 28);
            lblInvoiceID.TabIndex = 2;
            lblInvoiceID.Text = "1084";
            lblInvoiceID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.FromArgb(236, 253, 245);
            lblStatus.BorderColor = Color.Transparent;
            lblStatus.BorderRadius = 14;
            lblStatus.Font = new Font("Cairo", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(5, 150, 105);
            lblStatus.Location = new Point(10, 8);
            lblStatus.Name = "lblStatus";
            lblStatus.RightToLeft = RightToLeft.Yes;
            lblStatus.Size = new Size(50, 28);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "مسدد";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucInvoiceRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblStatus);
            Controls.Add(lblInvoiceID);
            Controls.Add(lblAmount);
            Controls.Add(lblCustomerName);
            Name = "ucInvoiceRow";
            Size = new Size(313, 44);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SabraLabel lblCustomerName;
        private SabraLabel lblAmount;
        private SabraLabel lblInvoiceID;
        private SabraLabel lblStatus;
    }
}