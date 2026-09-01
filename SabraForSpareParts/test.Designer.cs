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
            ucGoodsReceipt1 = new SabraForSpareParts.Screens.ucGoodsReceipt();
            SuspendLayout();
            // 
            // ucGoodsReceipt1
            // 
            ucGoodsReceipt1.AutoScroll = true;
            ucGoodsReceipt1.AutoScrollMinSize = new Size(1502, 1000);
            ucGoodsReceipt1.BackColor = Color.WhiteSmoke;
            ucGoodsReceipt1.BorderColor = Color.Transparent;
            ucGoodsReceipt1.Dock = DockStyle.Fill;
            ucGoodsReceipt1.Font = new Font("Cairo", 10F);
            ucGoodsReceipt1.ForeColor = Color.FromArgb(40, 40, 40);
            ucGoodsReceipt1.Location = new Point(0, 0);
            ucGoodsReceipt1.Margin = new Padding(0);
            ucGoodsReceipt1.MinimumSize = new Size(900, 600);
            ucGoodsReceipt1.Name = "ucGoodsReceipt1";
            ucGoodsReceipt1.Padding = new Padding(10);
            ucGoodsReceipt1.RightToLeft = RightToLeft.Yes;
            ucGoodsReceipt1.Size = new Size(1404, 670);
            ucGoodsReceipt1.TabIndex = 0;
            // 
            // test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 670);
            Controls.Add(ucGoodsReceipt1);
            Name = "test";
            Text = "test";
            ResumeLayout(false);
        }

        #endregion

        private Screens.ucGoodsReceipt ucGoodsReceipt1;
    }
}