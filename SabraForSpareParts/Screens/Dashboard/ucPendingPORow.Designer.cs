namespace SabraForSpareParts.Screens
{
    partial class ucPendingPORow
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

        #endregion

        private void InitializeComponent()
        {
            lblPOInfo = new SabraLabel();
            lblAmount = new SabraLabel();
            sabraPanel1 = new SabraPanel();
            SuspendLayout();

            // 
            // lblPOInfo (كود الأمر — اسم المورد)
            // 
            lblPOInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPOInfo.AutoSize = false;
            lblPOInfo.BackColor = Color.Transparent;
            lblPOInfo.BorderColor = Color.Transparent;
            lblPOInfo.BorderRadius = 0;
            lblPOInfo.BorderSize = 0;
            lblPOInfo.Font = new Font("Cairo", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPOInfo.ForeColor = Color.FromArgb(71, 85, 105); // لون رمادي كحلي أنيق
            lblPOInfo.Location = new Point(110, 10);
            lblPOInfo.Name = "lblPOInfo";
            lblPOInfo.Size = new Size(225, 24);
            lblPOInfo.TabIndex = 0;
            lblPOInfo.Text = "PO-0045 — بوش";
            lblPOInfo.TextAlign = ContentAlignment.MiddleRight;

            // 
            // lblAmount (المبلغ)
            // 
            lblAmount.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblAmount.AutoSize = true;
            lblAmount.BackColor = Color.Transparent;
            lblAmount.BorderColor = Color.Transparent;
            lblAmount.BorderRadius = 0;
            lblAmount.BorderSize = 0;
            lblAmount.Font = new Font("Cairo", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAmount.ForeColor = Color.FromArgb(30, 41, 59); // أسود داكن
            lblAmount.Location = new Point(10, 8);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(80, 30);
            lblAmount.TabIndex = 1;
            lblAmount.Text = "15,200 ج";
            lblAmount.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // sabraPanel1 (الخط الفاصل)
            // 
            sabraPanel1.BackColor = Color.FromArgb(226, 232, 240);
            sabraPanel1.BorderColor = Color.Transparent;
            sabraPanel1.BorderRadius = 0;
            sabraPanel1.BorderSize = 0;
            sabraPanel1.Dock = DockStyle.Bottom;
            sabraPanel1.EnableHover = false;
            sabraPanel1.GradientAngle = 90F;
            sabraPanel1.GradientBottomColor = Color.FromArgb(226, 232, 240);
            sabraPanel1.GradientTopColor = Color.FromArgb(226, 232, 240);
            sabraPanel1.Location = new Point(0, 44);
            sabraPanel1.Name = "sabraPanel1";
            sabraPanel1.Size = new Size(346, 1); // خط رفيع بارتفاع 1 بيكسل
            sabraPanel1.TabIndex = 2;

            // 
            // ucPendingPORow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(sabraPanel1);
            Controls.Add(lblAmount);
            Controls.Add(lblPOInfo);
            Name = "ucPendingPORow";
            Size = new Size(346, 45);
            ResumeLayout(false);
            PerformLayout();
        }

        private SabraLabel lblPOInfo;
        private SabraLabel lblAmount;
        private SabraPanel sabraPanel1;
    }
}
