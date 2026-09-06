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
            lblCurrentScreenName = new Label();
            lblTime = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblUser.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.ForeColor = Color.FromArgb(92, 115, 134);
            lblUser.Location = new Point(1176, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(264, 38);
            lblUser.TabIndex = 0;
            lblUser.Text = "أحمد محمد";
            lblUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCurrentScreenName
            // 
            lblCurrentScreenName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblCurrentScreenName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentScreenName.ForeColor = Color.FromArgb(92, 115, 134);
            lblCurrentScreenName.Location = new Point(608, 0);
            lblCurrentScreenName.Name = "lblCurrentScreenName";
            lblCurrentScreenName.Size = new Size(517, 38);
            lblCurrentScreenName.TabIndex = 2;
            lblCurrentScreenName.Text = "أمر شراء جديد";
            lblCurrentScreenName.TextAlign = ContentAlignment.MiddleRight;
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
            Controls.Add(lblCurrentScreenName);
            Controls.Add(lblUser);
            Name = "ucBottomBar";
            Size = new Size(1447, 49);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private Label lblCurrentScreenName;
        private Label lblTime;
        private System.Windows.Forms.Timer timer1;
    }
}
