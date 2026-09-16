using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sabra.DataLayer.Models;
using Sabra.LogicLayer;

namespace SabraForSpareParts.Screens
{
    public partial class frmAddEmployee : Form
    {
        private readonly clsEmployeeBusiness _employeeBusiness;

        public frmAddEmployee()
        {
            InitializeComponent();
            _employeeBusiness = new clsEmployeeBusiness();
        }


        private void frmAddEmployee_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today;
            dtpDate.MaxDate = DateTime.Today;

            cmbJob.DisplayMember = "PositionName";
            cmbJob.ValueMember = "PositionID";
            cmbJob.DataSource = _employeeBusiness.GetPositions().Data.ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowWarning("من فضلك أدخل اسم الموظف.", txtName);
                return;
            }

            if (cmbJob.SelectedValue == null)
            {
                ShowWarning("من فضلك اختر الوظيفة.", cmbJob);
                return;
            }

            if (!decimal.TryParse(txtSalary.Text.Trim(), out decimal salary))
            {
                ShowWarning("من فضلك أدخل راتب صحيح.", txtSalary);
                return;
            }

            var employee = new Employee
            {
                FullName = txtName.Text.Trim(),
                PositionID = Convert.ToInt32(cmbJob.SelectedValue),
                HireDate = dtpDate.Value.Date,
                BasicSalary = salary,
                PhoneNumber = string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ? null : txtPhoneNumber.Text.Trim(),
                NationalID = string.IsNullOrWhiteSpace(txtNationalID.Text) ? null : txtNationalID.Text.Trim(),
                IsActive = true
            };

            var result = _employeeBusiness.AddEmployee(employee, createWallet: true);

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Message, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ShowWarning(string message, Control controlToFocus)
        {
            MessageBox.Show(message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controlToFocus.Focus();
        }

        private void AddPosition_Click(object sender, EventArgs e)
        {
            using var form = new frmAddPosition(_employeeBusiness);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                cmbJob.DataSource = _employeeBusiness.GetPositions().Data.ToList();
            }
        }
    }
}