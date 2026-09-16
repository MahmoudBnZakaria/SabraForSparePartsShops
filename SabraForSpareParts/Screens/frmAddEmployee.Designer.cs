namespace SabraForSpareParts.Screens
{
    partial class frmAddEmployee
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            lblNationalID = new Label();
            txtNationalID = new TextBox();
            btnSave = new Button();
            AddPosition = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Cairo", 10F);
            lblName.Location = new Point(30, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(110, 32);
            lblName.TabIndex = 12;
            lblName.Text = "اسم الموظف";
            // 
            // txtName
            // 
            txtName.Font = new Font("Cairo", 10F);
            txtName.Location = new Point(30, 50);
            txtName.Name = "txtName";
            txtName.Size = new Size(420, 39);
            txtName.TabIndex = 11;
            // 
            // lblJob
            // 
            lblJob.AutoSize = true;
            lblJob.Font = new Font("Cairo", 10F);
            lblJob.Location = new Point(30, 95);
            lblJob.Name = "lblJob";
            lblJob.Size = new Size(73, 32);
            lblJob.TabIndex = 10;
            lblJob.Text = "الوظيفة";
            // 
            // cmbJob
            // 
            cmbJob.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJob.Font = new Font("Cairo", 10F);
            cmbJob.FormattingEnabled = true;
            cmbJob.Location = new Point(30, 125);
            cmbJob.Name = "cmbJob";
            cmbJob.Size = new Size(420, 40);
            cmbJob.TabIndex = 9;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Cairo", 10F);
            lblDate.Location = new Point(30, 170);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(97, 32);
            lblDate.TabIndex = 8;
            lblDate.Text = "تاريخ التعيين";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Cairo", 10F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(30, 200);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(420, 39);
            dtpDate.TabIndex = 7;
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Cairo", 10F);
            lblSalary.Location = new Point(30, 245);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(53, 32);
            lblSalary.TabIndex = 6;
            lblSalary.Text = "الراتب";
            // 
            // txtSalary
            // 
            txtSalary.Font = new Font("Cairo", 10F);
            txtSalary.Location = new Point(30, 275);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(420, 39);
            txtSalary.TabIndex = 5;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Cairo", 10F);
            lblPhoneNumber.Location = new Point(30, 320);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(100, 32);
            lblPhoneNumber.TabIndex = 4;
            lblPhoneNumber.Text = "رقم التليفون";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Cairo", 10F);
            txtPhoneNumber.Location = new Point(30, 350);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(420, 39);
            txtPhoneNumber.TabIndex = 3;
            // 
            // lblNationalID
            // 
            lblNationalID.AutoSize = true;
            lblNationalID.Font = new Font("Cairo", 10F);
            lblNationalID.Location = new Point(30, 395);
            lblNationalID.Name = "lblNationalID";
            lblNationalID.Size = new Size(111, 32);
            lblNationalID.TabIndex = 2;
            lblNationalID.Text = "الرقم القومي";
            // 
            // txtNationalID
            // 
            txtNationalID.Font = new Font("Cairo", 10F);
            txtNationalID.Location = new Point(30, 425);
            txtNationalID.Name = "txtNationalID";
            txtNationalID.Size = new Size(420, 39);
            txtNationalID.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(350, 480);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // AddPosition
            // 
            AddPosition.BackColor = SystemColors.Control;
            AddPosition.FlatStyle = FlatStyle.Flat;
            AddPosition.Font = new Font("Cairo", 9F, FontStyle.Bold);
            AddPosition.ForeColor = Color.Black;
            AddPosition.Location = new Point(30, 474);
            AddPosition.Margin = new Padding(3, 4, 3, 4);
            AddPosition.Name = "AddPosition";
            AddPosition.Size = new Size(120, 46);
            AddPosition.TabIndex = 13;
            AddPosition.Text = "إضافة وظيفة";
            AddPosition.UseVisualStyleBackColor = false;
            AddPosition.Click += AddPosition_Click;
            // 
            // frmAddEmployee
            // 
            ClientSize = new Size(484, 545);
            Controls.Add(AddPosition);
            Controls.Add(btnSave);
            Controls.Add(txtNationalID);
            Controls.Add(lblNationalID);
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
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddEmployee";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إضافة موظف جديد";
            Load += frmAddEmployee_Load;
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
        private System.Windows.Forms.Label lblNationalID;
        private System.Windows.Forms.TextBox txtNationalID;
        private System.Windows.Forms.Button btnSave;
        private Button AddPosition;
    }
}