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
            ucNewInvoice1 = new SabraForSpareParts.Screens.ucNewInvoice();
            SuspendLayout();
            // 
            // ucNewInvoice1
            // 
            ucNewInvoice1.AutoScroll = true;
            ucNewInvoice1.AutoScrollMinSize = new Size(1502, 1000);
            ucNewInvoice1.BackColor = Color.WhiteSmoke;
            ucNewInvoice1.BorderColor = Color.Transparent;
            ucNewInvoice1.Dock = DockStyle.Fill;
            ucNewInvoice1.Font = new Font("Cairo", 10F);
            ucNewInvoice1.ForeColor = Color.FromArgb(40, 40, 40);
            ucNewInvoice1.Location = new Point(0, 0);
            ucNewInvoice1.Margin = new Padding(0);
            ucNewInvoice1.MinimumSize = new Size(900, 600);
            ucNewInvoice1.Name = "ucNewInvoice1";
            ucNewInvoice1.Padding = new Padding(10);
            ucNewInvoice1.RightToLeft = RightToLeft.Yes;
            ucNewInvoice1.Size = new Size(1404, 670);
            ucNewInvoice1.TabIndex = 0;
            // 
            // test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 670);
            Controls.Add(ucNewInvoice1);
            Name = "test";
            Text = "test";
            ResumeLayout(false);
        }

        #endregion

        private Screens.ucNewInvoice ucNewInvoice1;
    }
}