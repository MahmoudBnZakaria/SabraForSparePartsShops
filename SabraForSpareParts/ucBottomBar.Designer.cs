namespace SabraForSpareParts
{
    partial class ucBottomBar
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
            components = new System.ComponentModel.Container();
            lblUser = new Label();
            label = new Label();
            label1 = new Label();
            lblScreenName = new Label();
            lblTime = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.ForeColor = Color.FromArgb(92, 115, 134);
            lblUser.Location = new Point(1152, 2);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(140, 38);
            lblUser.TabIndex = 0;
            lblUser.Text = "أحمد محمد";
            // 
            // label
            // 
            label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.ForeColor = Color.FromArgb(68, 67, 89);
            label.Location = new Point(1298, 2);
            label.Name = "label";
            label.Size = new Size(141, 38);
            label.TabIndex = 1;
            label.Text = ":المستخدم ";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(68, 67, 89);
            label1.Location = new Point(1029, 2);
            label1.Name = "label1";
            label1.Size = new Size(100, 38);
            label1.TabIndex = 3;
            label1.Text = "الشاشة";
            // 
            // lblScreenName
            // 
            lblScreenName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblScreenName.AutoSize = true;
            lblScreenName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScreenName.ForeColor = Color.FromArgb(92, 115, 134);
            lblScreenName.Location = new Point(852, 2);
            lblScreenName.Name = "lblScreenName";
            lblScreenName.Size = new Size(171, 38);
            lblScreenName.TabIndex = 2;
            lblScreenName.Text = "أمر شراء جديد";
            lblScreenName.Click += lblScreenName_Click;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Cairo", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 178);
            lblTime.ForeColor = Color.FromArgb(92, 115, 134);
            lblTime.Location = new Point(3, -4);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(131, 53);
            lblTime.TabIndex = 4;
            lblTime.Text = "10:10:20";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // ucBottomBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            Controls.Add(lblTime);
            Controls.Add(label1);
            Controls.Add(lblScreenName);
            Controls.Add(label);
            Controls.Add(lblUser);
            Name = "ucBottomBar";
            Size = new Size(1447, 49);
            Load += ucBottomBar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private Label label;
        private Label label1;
        private Label lblScreenName;
        private Label lblTime;
        private System.Windows.Forms.Timer timer1;
    }
}
