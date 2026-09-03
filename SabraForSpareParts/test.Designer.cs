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
            ucSalaries1 = new SabraForSpareParts.Screens.ucSalaries();
            SuspendLayout();
            // 
            // ucSalaries1
            // 
            ucSalaries1.AutoScroll = true;
            ucSalaries1.AutoScrollMinSize = new Size(1502, 1000);
            ucSalaries1.BackColor = Color.WhiteSmoke;
            ucSalaries1.BorderColor = Color.Transparent;
            ucSalaries1.Dock = DockStyle.Fill;
            ucSalaries1.Font = new Font("Cairo", 10F);
            ucSalaries1.ForeColor = Color.FromArgb(40, 40, 40);
            ucSalaries1.Location = new Point(0, 0);
            ucSalaries1.Margin = new Padding(0);
            ucSalaries1.MinimumSize = new Size(900, 600);
            ucSalaries1.Name = "ucSalaries1";
            ucSalaries1.Padding = new Padding(10);
            ucSalaries1.RightToLeft = RightToLeft.Yes;
            ucSalaries1.Size = new Size(1404, 670);
            ucSalaries1.TabIndex = 0;
            // 
            // test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 670);
            Controls.Add(ucSalaries1);
            Name = "test";
            Text = "test";
            ResumeLayout(false);
        }

        #endregion

        private Screens.InventoryAlerts.ucInventoryAlertRow ucInventoryAlertRow1;
        private Screens.ucSalaries ucSalaries1;
    }
}