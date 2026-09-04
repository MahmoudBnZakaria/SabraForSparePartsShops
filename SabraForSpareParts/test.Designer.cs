using SabraForSpareParts.Screens;

namespace SabraForSpareParts
{
    partial class test
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ucUsers1 = new SabraForSpareParts.Screens.ucUsers();
            SuspendLayout();
            // 
            // ucUsers1
            // 
            ucUsers1.AutoScroll = true;
            ucUsers1.AutoScrollMinSize = new Size(1502, 1000);
            ucUsers1.BackColor = Color.WhiteSmoke;
            ucUsers1.BorderColor = Color.Transparent;
            ucUsers1.Dock = DockStyle.Fill;
            ucUsers1.Font = new Font("Cairo", 10F);
            ucUsers1.ForeColor = Color.FromArgb(40, 40, 40);
            ucUsers1.Location = new Point(0, 0);
            ucUsers1.Margin = new Padding(0);
            ucUsers1.MinimumSize = new Size(900, 600);
            ucUsers1.Name = "ucUsers1";
            ucUsers1.Padding = new Padding(10);
            ucUsers1.RightToLeft = RightToLeft.Yes;
            ucUsers1.Size = new Size(1404, 670);
            ucUsers1.TabIndex = 0;
            // 
            // test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 670);
            Controls.Add(ucUsers1);
            Name = "test";
            Text = "test";
            ResumeLayout(false);
        }

        #endregion

        private Screens.InventoryAlerts.ucInventoryAlertRow ucInventoryAlertRow1;
        private Screens.ucUsers ucUsers1;
    }
}