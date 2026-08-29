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
            ucInventory1 = new SabraForSpareParts.Screens.ucInventory();
            SuspendLayout();
            // 
            // ucInventory1
            // 
            ucInventory1.AutoScroll = true;
            ucInventory1.AutoScrollMinSize = new Size(1502, 1000);
            ucInventory1.BackColor = Color.WhiteSmoke;
            ucInventory1.BorderColor = Color.Transparent;
            ucInventory1.Dock = DockStyle.Fill;
            ucInventory1.Font = new Font("Cairo", 10F);
            ucInventory1.ForeColor = Color.FromArgb(40, 40, 40);
            ucInventory1.Location = new Point(0, 0);
            ucInventory1.Margin = new Padding(0);
            ucInventory1.MinimumSize = new Size(900, 600);
            ucInventory1.Name = "ucInventory1";
            ucInventory1.Padding = new Padding(10);
            ucInventory1.RightToLeft = RightToLeft.Yes;
            ucInventory1.Size = new Size(1404, 670);
            ucInventory1.TabIndex = 0;
            // 
            // test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 670);
            Controls.Add(ucInventory1);
            Name = "test";
            Text = "test";
            ResumeLayout(false);
        }

        #endregion

        private Screens.ucInventory ucInventory1;
    }
}