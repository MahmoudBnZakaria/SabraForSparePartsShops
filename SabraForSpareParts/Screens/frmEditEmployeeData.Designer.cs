namespace SabraForSpareParts.Screens
{
    partial class frmEditEmployeeData
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
            lblName = new Label();
            txtName = new TextBox();
            lblJob = new Label();
            cmbJob = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblSalary = new Label();
            txtSalary = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Cairo", 9.75F);
            lblName.Location = new Point(34, 40);
            lblName.Name = "lblName";
            lblName.Size = new Size(110, 32);
            lblName.TabIndex = 0;
            lblName.Text = "اسم الموظف";
            // 
            // txtName
            // 
            txtName.Font = new Font("Cairo", 9.75F);
            txtName.Location = new Point(34, 87);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(479, 38);
            txtName.TabIndex = 1;
            // 
            // lblJob
            // 
            lblJob.AutoSize = true;
            lblJob.Font = new Font("Cairo", 9.75F);
            lblJob.Location = new Point(34, 153);
            lblJob.Name = "lblJob";
            lblJob.Size = new Size(73, 32);
            lblJob.TabIndex = 2;
            lblJob.Text = "الوظيفة";
            // 
            // cmbJob
            // 
            cmbJob.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJob.Font = new Font("Cairo", 10F);
            cmbJob.FormattingEnabled = true;
            cmbJob.Location = new Point(34, 200);
            cmbJob.Margin = new Padding(3, 4, 3, 4);
            cmbJob.Name = "cmbJob";
            cmbJob.Size = new Size(479, 40);
            cmbJob.TabIndex = 3;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Cairo", 9.75F);
            lblDate.Location = new Point(34, 270);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(97, 32);
            lblDate.TabIndex = 4;
            lblDate.Text = "تاريخ التعيين";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Cairo", 9.75F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(34, 316);
            dtpDate.Margin = new Padding(3, 4, 3, 4);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(479, 38);
            dtpDate.TabIndex = 5;
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Cairo", 9.75F);
            lblSalary.Location = new Point(34, 383);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(53, 32);
            lblSalary.TabIndex = 6;
            lblSalary.Text = "الراتب";
            // 
            // txtSalary
            // 
            txtSalary.Font = new Font("Cairo", 9.75F);
            txtSalary.Location = new Point(34, 430);
            txtSalary.Margin = new Padding(3, 4, 3, 4);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(479, 38);
            txtSalary.TabIndex = 7;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Cairo", 9.75F);
            lblPhoneNumber.Location = new Point(34, 496);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(100, 32);
            lblPhoneNumber.TabIndex = 8;
            lblPhoneNumber.Text = "رقم التليفون";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Cairo", 9.75F);
            txtPhoneNumber.Location = new Point(34, 543);
            txtPhoneNumber.Margin = new Padding(3, 4, 3, 4);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(479, 38);
            txtPhoneNumber.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(366, 630);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(149, 53);
            btnSave.TabIndex = 10;
            btnSave.Text = "حفظ التعديل";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // frmEditEmployeeData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 716);
            Controls.Add(btnSave);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtSalary);
            Controls.Add(lblSalary);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(cmbJob);
            Controls.Add(lblJob);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEditEmployeeData";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "تعديل بيانات الموظف";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.ComboBox cmbJob;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Button btnSave;
    }
}