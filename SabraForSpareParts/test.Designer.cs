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
            ucInventoryTransactions1 = new SabraForSpareParts.Screens.ucInventoryTransactions();
            SuspendLayout();
            // 
            // ucInventoryTransactions1
            // 
            ucInventoryTransactions1.Dock = DockStyle.Fill;
            ucInventoryTransactions1.Location = new Point(0, 0);
            ucInventoryTransactions1.Name = "ucInventoryTransactions1";
            ucInventoryTransactions1.Size = new Size(1404, 670);
            ucInventoryTransactions1.TabIndex = 0;
            // 
            // test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 670);
            Controls.Add(ucInventoryTransactions1);
            Name = "test";
            Text = "test";
            ResumeLayout(false);
        }

        #endregion

        private Screens.ucInventoryTransactions ucInventoryTransactions1;
    }
}