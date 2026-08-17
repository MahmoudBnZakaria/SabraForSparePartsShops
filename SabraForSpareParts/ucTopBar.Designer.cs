namespace SabraForSpareParts
{
    partial class ucTopBar
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
            lblProgramName = new Label();
            btnNewInvoice = new Button();
            lblAddPart = new Button();
            btnAlarms = new Button();
            btnPrint = new Button();
            lblSearchBar = new TextBox();
            SuspendLayout();
            // 
            // lblProgramName
            // 
            lblProgramName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblProgramName.AutoSize = true;
            lblProgramName.Font = new Font("Cairo Black", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgramName.Location = new Point(1208, 9);
            lblProgramName.Name = "lblProgramName";
            lblProgramName.Size = new Size(282, 43);
            lblProgramName.TabIndex = 0;
            lblProgramName.Text = "صبره لقطع غيار السيارات";
            lblProgramName.Click += lblProgramName_Click;
            // 
            // btnNewInvoice
            // 
            btnNewInvoice.BackColor = Color.Transparent;
            btnNewInvoice.Font = new Font("Cairo", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewInvoice.Location = new Point(425, 9);
            btnNewInvoice.Name = "btnNewInvoice";
            btnNewInvoice.Size = new Size(115, 44);
            btnNewInvoice.TabIndex = 1;
            btnNewInvoice.Text = "فاتورة جديدة";
            btnNewInvoice.UseVisualStyleBackColor = false;
            // 
            // lblAddPart
            // 
            lblAddPart.BackColor = Color.Transparent;
            lblAddPart.Font = new Font("Cairo", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddPart.Location = new Point(304, 9);
            lblAddPart.Name = "lblAddPart";
            lblAddPart.Size = new Size(115, 44);
            lblAddPart.TabIndex = 2;
            lblAddPart.Text = "إضافة قطعة";
            lblAddPart.UseVisualStyleBackColor = false;
            // 
            // btnAlarms
            // 
            btnAlarms.BackColor = Color.Transparent;
            btnAlarms.Font = new Font("Cairo", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAlarms.Location = new Point(183, 9);
            btnAlarms.Name = "btnAlarms";
            btnAlarms.Size = new Size(115, 44);
            btnAlarms.TabIndex = 3;
            btnAlarms.Text = "تنبيهات";
            btnAlarms.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.Transparent;
            btnPrint.Font = new Font("Cairo", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.Location = new Point(62, 9);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(115, 44);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "طباعة";
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // lblSearchBar
            // 
            lblSearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSearchBar.BackColor = Color.FromArgb(244, 246, 249);
            lblSearchBar.BorderStyle = BorderStyle.FixedSingle;
            lblSearchBar.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearchBar.Location = new Point(613, 11);
            lblSearchBar.Name = "lblSearchBar";
            lblSearchBar.PlaceholderText = "....ابحث عن قطعة، فاتورة، عميل";
            lblSearchBar.Size = new Size(558, 38);
            lblSearchBar.TabIndex = 5;
            lblSearchBar.TextAlign = HorizontalAlignment.Right;
            // 
            // ucTopBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblSearchBar);
            Controls.Add(btnPrint);
            Controls.Add(btnAlarms);
            Controls.Add(lblAddPart);
            Controls.Add(btnNewInvoice);
            Controls.Add(lblProgramName);
            Name = "ucTopBar";
            Size = new Size(1493, 61);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProgramName;
        private Button btnNewInvoice;
        private Button lblAddPart;
        private Button btnAlarms;
        private Button btnPrint;
        private TextBox lblSearchBar;
    }
}
