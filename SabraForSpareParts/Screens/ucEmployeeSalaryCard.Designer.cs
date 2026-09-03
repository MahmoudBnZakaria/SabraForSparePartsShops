namespace SabraForSpareParts.Screens
{
    partial class ucEmployeeSalaryCard
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
            lblNameOfEmplyeeAndRole = new SabraLabel();
            lblBasicSalary = new SabraLabel();
            sabraLabel7 = new SabraLabel();
            lblAdvances = new SabraLabel();
            sabraLabel2 = new SabraLabel();
            lblNetSalary = new SabraLabel();
            sabraLabel4 = new SabraLabel();
            sbtnPay = new SabraButton();
            SuspendLayout();
            // 
            // lblNameOfEmplyeeAndRole
            // 
            lblNameOfEmplyeeAndRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNameOfEmplyeeAndRole.BackColor = Color.Transparent;
            lblNameOfEmplyeeAndRole.Font = new Font("Cairo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameOfEmplyeeAndRole.ForeColor = SystemColors.WindowText;
            lblNameOfEmplyeeAndRole.Location = new Point(13, 10);
            lblNameOfEmplyeeAndRole.Name = "lblNameOfEmplyeeAndRole";
            lblNameOfEmplyeeAndRole.RightToLeft = RightToLeft.Yes;
            lblNameOfEmplyeeAndRole.Size = new Size(270, 37);
            lblNameOfEmplyeeAndRole.TabIndex = 34;
            lblNameOfEmplyeeAndRole.Text = "أحمد محمد — مدير";
            lblNameOfEmplyeeAndRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBasicSalary
            // 
            lblBasicSalary.AutoSize = true;
            lblBasicSalary.BackColor = Color.Transparent;
            lblBasicSalary.Font = new Font("Cairo", 12F);
            lblBasicSalary.ForeColor = Color.DimGray;
            lblBasicSalary.Location = new Point(13, 58);
            lblBasicSalary.Name = "lblBasicSalary";
            lblBasicSalary.RightToLeft = RightToLeft.Yes;
            lblBasicSalary.Size = new Size(93, 37);
            lblBasicSalary.TabIndex = 37;
            lblBasicSalary.Text = "89,400 ج";
            lblBasicSalary.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel7
            // 
            sabraLabel7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel7.BackColor = Color.Transparent;
            sabraLabel7.Font = new Font("Cairo", 12F);
            sabraLabel7.ForeColor = SystemColors.WindowFrame;
            sabraLabel7.Location = new Point(123, 58);
            sabraLabel7.Name = "sabraLabel7";
            sabraLabel7.RightToLeft = RightToLeft.Yes;
            sabraLabel7.Size = new Size(160, 37);
            sabraLabel7.TabIndex = 36;
            sabraLabel7.Text = "الراتب الأساسي";
            sabraLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAdvances
            // 
            lblAdvances.AutoSize = true;
            lblAdvances.BackColor = Color.Transparent;
            lblAdvances.Font = new Font("Cairo", 12F);
            lblAdvances.ForeColor = Color.DarkGoldenrod;
            lblAdvances.Location = new Point(13, 98);
            lblAdvances.Name = "lblAdvances";
            lblAdvances.RightToLeft = RightToLeft.Yes;
            lblAdvances.Size = new Size(93, 37);
            lblAdvances.TabIndex = 39;
            lblAdvances.Text = "89,400 ج";
            lblAdvances.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel2
            // 
            sabraLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel2.AutoSize = true;
            sabraLabel2.BackColor = Color.Transparent;
            sabraLabel2.Font = new Font("Cairo", 12F);
            sabraLabel2.ForeColor = SystemColors.WindowFrame;
            sabraLabel2.Location = new Point(211, 95);
            sabraLabel2.Name = "sabraLabel2";
            sabraLabel2.RightToLeft = RightToLeft.Yes;
            sabraLabel2.Size = new Size(72, 37);
            sabraLabel2.TabIndex = 38;
            sabraLabel2.Text = "السلف";
            sabraLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNetSalary
            // 
            lblNetSalary.AutoSize = true;
            lblNetSalary.BackColor = Color.Transparent;
            lblNetSalary.Font = new Font("Cairo", 12F);
            lblNetSalary.ForeColor = Color.Green;
            lblNetSalary.Location = new Point(13, 135);
            lblNetSalary.Name = "lblNetSalary";
            lblNetSalary.RightToLeft = RightToLeft.Yes;
            lblNetSalary.Size = new Size(93, 37);
            lblNetSalary.TabIndex = 41;
            lblNetSalary.Text = "89,400 ج";
            lblNetSalary.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sabraLabel4
            // 
            sabraLabel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sabraLabel4.AutoSize = true;
            sabraLabel4.BackColor = Color.Transparent;
            sabraLabel4.Font = new Font("Cairo", 12F);
            sabraLabel4.ForeColor = SystemColors.WindowFrame;
            sabraLabel4.Location = new Point(206, 132);
            sabraLabel4.Name = "sabraLabel4";
            sabraLabel4.RightToLeft = RightToLeft.Yes;
            sabraLabel4.Size = new Size(77, 37);
            sabraLabel4.TabIndex = 40;
            sabraLabel4.Text = "الصافي";
            sabraLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sbtnPay
            // 
            sbtnPay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sbtnPay.BackColor = SystemColors.GrayText;
            sbtnPay.BorderColor = Color.DodgerBlue;
            sbtnPay.BorderRadius = 20;
            sbtnPay.BorderSize = 0;
            sbtnPay.FlatAppearance.BorderSize = 0;
            sbtnPay.FlatStyle = FlatStyle.Flat;
            sbtnPay.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnPay.ForeColor = Color.White;
            sbtnPay.HoverColor = Color.DimGray;
            sbtnPay.IconChar = FontAwesome.Sharp.IconChar.Reply;
            sbtnPay.IconColor = Color.Beige;
            sbtnPay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnPay.IconSize = 30;
            sbtnPay.ImageAlign = ContentAlignment.MiddleRight;
            sbtnPay.Location = new Point(13, 186);
            sbtnPay.Name = "sbtnPay";
            sbtnPay.NormalColor = SystemColors.GrayText;
            sbtnPay.Padding = new Padding(10, 0, 10, 0);
            sbtnPay.Size = new Size(270, 42);
            sbtnPay.TabIndex = 42;
            sbtnPay.Text = "صـــــرف";
            sbtnPay.UseVisualStyleBackColor = false;
            sbtnPay.Click += sbtnPay_Click;
            // 
            // ucEmployeeSalaryCard
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScrollMinSize = new Size(0, 0);
            BackColor = Color.White;
            BorderColor = Color.RoyalBlue;
            BorderRadius = 15;
            BorderSize = 1;
            Controls.Add(sbtnPay);
            Controls.Add(lblNetSalary);
            Controls.Add(sabraLabel4);
            Controls.Add(lblAdvances);
            Controls.Add(sabraLabel2);
            Controls.Add(lblBasicSalary);
            Controls.Add(sabraLabel7);
            Controls.Add(lblNameOfEmplyeeAndRole);
            MaximumSize = new Size(296, 241);
            MinimumSize = new Size(296, 241);
            Name = "ucEmployeeSalaryCard";
            Size = new Size(296, 241);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SabraLabel lblNameOfEmplyeeAndRole;
        private SabraLabel lblBasicSalary;
        private SabraLabel sabraLabel7;
        private SabraLabel lblAdvances;
        private SabraLabel sabraLabel2;
        private SabraLabel lblNetSalary;
        private SabraLabel sabraLabel4;
        private SabraButton sbtnPay;
    }
}
