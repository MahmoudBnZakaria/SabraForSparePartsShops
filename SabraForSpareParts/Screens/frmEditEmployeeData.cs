using Sabra.DataLayer.Models;
using Sabra.LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class frmEditEmployeeData : Form
    {
        private readonly Employee _employee;
        private readonly clsEmployeeBusiness _employeeBusiness = new clsEmployeeBusiness();

        public frmEditEmployeeData(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            LoadFormData();
        }
        private void LoadFormData()
        {
            var positionsResult = _employeeBusiness.GetPositions();

            if (positionsResult != null && positionsResult.Data != null)
            {
                cmbJob.DisplayMember = "PositionName";
                cmbJob.ValueMember = "PositionID";

                cmbJob.DataSource = _employeeBusiness.GetPositions().Data.ToList();
                cmbJob.SelectedValue = _employee.PositionID;
            }

            txtName.Text = _employee.FullName;

            dtpDate.MaxDate = DateTime.Today;
            dtpDate.Value = _employee.HireDate <= DateTime.Today
                ? _employee.HireDate
                : DateTime.Today;

            txtSalary.Text = _employee.BasicSalary.ToString("0");
            txtPhoneNumber.Text = _employee.PhoneNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("من فضلك أدخل اسم الموظف.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (cmbJob.SelectedValue == null)
            {
                MessageBox.Show("من فضلك اختر الوظيفة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbJob.Focus();
                return;
            }

            if (!decimal.TryParse(txtSalary.Text.Trim(), out decimal salary))
            {
                MessageBox.Show("الراتب غير صحيح.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalary.Focus();
                return;
            }


            var updatedEmployee = new Employee
            {
                EmployeeID = _employee.EmployeeID,
                FullName = txtName.Text.Trim(),
                PositionID = Convert.ToInt32(cmbJob.SelectedValue),
                NationalID = _employee.NationalID,
                HireDate = dtpDate.Value.Date,
                BasicSalary = salary,
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                IsActive = _employee.IsActive
            };

            var result = _employeeBusiness.UpdateEmployee(updatedEmployee);

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Message, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}