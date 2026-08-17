namespace SabraForSpareParts.Screens
{
    partial class ucAlertRow
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
            lblProductName = new SabraLabel();
            lblStock = new SabraLabel();
            sabraPanel1 = new SabraPanel();
            SuspendLayout();

            // 
            // lblProductName
            // 
            lblProductName.Anchor = AnchorStyles.Top | AnchorStyles.Right; // التثبيت يمين
            lblProductName.AutoSize = false; // إلغاء الحجم التلقائي لضمان المحاذاة لليمين
            lblProductName.BackColor = Color.Transparent;
            lblProductName.BorderColor = Color.Transparent;
            lblProductName.BorderRadius = 0;
            lblProductName.BorderSize = 0;
            lblProductName.Font = new Font("Cairo", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductName.ForeColor = Color.FromArgb(71, 85, 105); // رمادي غامق أنيق
            lblProductName.Location = new Point(135, 10); // موقع تقريبي
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(200, 24);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "فلتر زيت تويوتا";
            lblProductName.TextAlign = ContentAlignment.MiddleRight;

            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.BackColor = Color.Transparent;
            lblStock.BorderColor = Color.Transparent;
            lblStock.BorderRadius = 0;
            lblStock.BorderSize = 0;
            lblStock.Font = new Font("Cairo", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStock.ForeColor = Color.FromArgb(220, 38, 38); // لون أحمر افتراضي (سيتغير بالكود)
            lblStock.Location = new Point(10, 8); // مسافة صغيرة من اليسار
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(89, 30);
            lblStock.TabIndex = 1;
            lblStock.Text = "المخزون: 2";
            lblStock.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // sabraPanel1 (الخط الفاصل)
            // 
            sabraPanel1.BackColor = Color.FromArgb(226, 232, 240); // رمادي فاتح جداً للخط الفاصل
            sabraPanel1.BorderColor = Color.Transparent;
            sabraPanel1.BorderRadius = 0; // بدون حواف دائرية لأنه خط
            sabraPanel1.BorderSize = 0;
            sabraPanel1.Dock = DockStyle.Bottom; // يثبت في الأسفل دائماً
            sabraPanel1.EnableHover = false; // تعطيل الـ Hover لأنه مجرد خط
            sabraPanel1.GradientAngle = 90F;
            sabraPanel1.GradientBottomColor = Color.FromArgb(226, 232, 240);
            sabraPanel1.GradientTopColor = Color.FromArgb(226, 232, 240);
            sabraPanel1.Location = new Point(0, 44);
            sabraPanel1.Name = "sabraPanel1";
            sabraPanel1.Size = new Size(346, 1); // السر هنا: الارتفاع 1 بيكسل فقط
            sabraPanel1.TabIndex = 2;

            // 
            // ucAlertRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White; // خلفية بيضاء نقية
            Controls.Add(sabraPanel1);
            Controls.Add(lblStock);
            Controls.Add(lblProductName);
            Name = "ucAlertRow";
            Size = new Size(346, 45); // ارتفاع السطر ممتاز للـ FlowLayoutPanel
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SabraLabel lblProductName;
        private SabraLabel lblStock;
        private SabraPanel sabraPanel1;
    }
}