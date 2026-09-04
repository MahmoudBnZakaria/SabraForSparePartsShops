namespace SabraForSpareParts.Screens
{
    partial class ucItemsRow
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

        private void InitializeComponent()
        {
            lblItem = new SabraLabel();
            lblNumberOfSelledUnites = new SabraLabel();
            sabraPanel1 = new SabraPanel();
            SuspendLayout();
            // 
            // lblItem
            // 
            lblItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblItem.BackColor = Color.Transparent;
            lblItem.BorderColor = Color.Transparent;
            lblItem.BorderRadius = 0;
            lblItem.Font = new Font("Cairo", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblItem.ForeColor = Color.FromArgb(71, 85, 105);
            lblItem.Location = new Point(110, 10);
            lblItem.Name = "lblItem";
            lblItem.RightToLeft = RightToLeft.Yes;
            lblItem.Size = new Size(225, 24);
            lblItem.TabIndex = 0;
            lblItem.Text = "فلتر زيت تويوتا";
            lblItem.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNumberOfSelledUnites
            // 
            lblNumberOfSelledUnites.AutoSize = true;
            lblNumberOfSelledUnites.BackColor = Color.Transparent;
            lblNumberOfSelledUnites.BorderColor = Color.Transparent;
            lblNumberOfSelledUnites.BorderRadius = 0;
            lblNumberOfSelledUnites.Font = new Font("Cairo", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumberOfSelledUnites.ForeColor = Color.FromArgb(30, 41, 59);
            lblNumberOfSelledUnites.Location = new Point(10, 8);
            lblNumberOfSelledUnites.Name = "lblNumberOfSelledUnites";
            lblNumberOfSelledUnites.RightToLeft = RightToLeft.Yes;
            lblNumberOfSelledUnites.Size = new Size(80, 30);
            lblNumberOfSelledUnites.TabIndex = 1;
            lblNumberOfSelledUnites.Text = "284 وحدة";
            lblNumberOfSelledUnites.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sabraPanel1
            // 
            sabraPanel1.BackColor = Color.FromArgb(226, 232, 240);
            sabraPanel1.BorderColor = Color.Transparent;
            sabraPanel1.BorderRadius = 0;
            sabraPanel1.BorderSize = 0;
            sabraPanel1.Dock = DockStyle.Bottom;
            sabraPanel1.EnableHover = false;
            sabraPanel1.ForeColor = Color.Black;
            sabraPanel1.GradientAngle = 90F;
            sabraPanel1.GradientBottomColor = Color.FromArgb(226, 232, 240);
            sabraPanel1.GradientTopColor = Color.FromArgb(226, 232, 240);
            sabraPanel1.HoverBackColor = Color.FromArgb(245, 248, 255);
            sabraPanel1.HoverBorderColor = Color.FromArgb(37, 99, 235);
            sabraPanel1.HoverBorderSize = 2;
            sabraPanel1.Location = new Point(0, 44);
            sabraPanel1.Name = "sabraPanel1";
            sabraPanel1.Size = new Size(346, 1);
            sabraPanel1.TabIndex = 2;
            // 
            // ucItemsRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(sabraPanel1);
            Controls.Add(lblNumberOfSelledUnites);
            Controls.Add(lblItem);
            Name = "ucItemsRow";
            Size = new Size(346, 45);
            ResumeLayout(false);
            PerformLayout();
        }

        private SabraLabel lblItem;
        private SabraLabel lblNumberOfSelledUnites;
        private SabraPanel sabraPanel1;

    }
}
