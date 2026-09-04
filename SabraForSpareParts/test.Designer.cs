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
            ucActivityLog1 = new ucActivityLog();
            SuspendLayout();
            // 
            // ucActivityLog1
            // 
            ucActivityLog1.AutoScroll = true;
            ucActivityLog1.AutoScrollMinSize = new Size(1502, 1000);
            ucActivityLog1.BackColor = Color.White;
            ucActivityLog1.BorderColor = Color.Transparent;
            ucActivityLog1.Dock = DockStyle.Fill;
            ucActivityLog1.Font = new Font("Cairo", 10F);
            ucActivityLog1.ForeColor = Color.FromArgb(40, 40, 40);
            ucActivityLog1.Location = new Point(0, 0);
            ucActivityLog1.Margin = new Padding(0);
            ucActivityLog1.MinimumSize = new Size(900, 600);
            ucActivityLog1.Name = "ucActivityLog1";
            ucActivityLog1.Padding = new Padding(10);
            ucActivityLog1.RightToLeft = RightToLeft.Yes;
            ucActivityLog1.Size = new Size(1404, 670);
            ucActivityLog1.TabIndex = 0;
            // 
            // test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 670);
            Controls.Add(ucActivityLog1);
            Name = "test";
            Text = "test";
            ResumeLayout(false);
        }

        #endregion

        private ucActivityLog ucActivityLog1;
    }
}