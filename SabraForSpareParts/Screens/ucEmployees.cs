using Sabra.DataLayer.Models;
using Sabra.LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucEmployees : SabraUserControl
    {
        #region Fields

        private readonly clsEmployeeBusiness _employeeBusiness =
            new clsEmployeeBusiness();

        private List<Employee> _employees =
            new List<Employee>();

        private List<EmployeePosition> _positions =
            new List<EmployeePosition>();

        #endregion


        #region Constructor

        public ucEmployees()
        {
            InitializeComponent();

            InitializePage();
        }

        #endregion


        #region Initialize

        private void InitializePage()
        {
            SetupGrid();

            LoadPositions();

            LoadEmployees();
        }

        #endregion


        #region Grid Setup

        private void SetupGrid()
        {
            dgvEmployee.AutoGenerateColumns = false;

            dgvEmployee.RightToLeft = RightToLeft.Yes;

            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.AllowUserToDeleteRows = false;
            dgvEmployee.AllowUserToResizeRows = false;

            dgvEmployee.ReadOnly = true;

            dgvEmployee.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvEmployee.MultiSelect = false;

            dgvEmployee.RowHeadersVisible = false;

            dgvEmployee.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgvEmployee.ColumnHeadersDefaultCellStyle.Font =
                new Font("Cairo", 10, FontStyle.Bold);

            dgvEmployee.DefaultCellStyle.Font =
                new Font("Cairo", 9);

            dgvEmployee.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvEmployee.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvEmployee.RowTemplate.Height = 45;

            dgvEmployee.CellContentClick -=
                dgvEmployee_CellContentClick;

            dgvEmployee.CellContentClick +=
                dgvEmployee_CellContentClick;

            CreateGridColumns();
        }


        private void CreateGridColumns()
        {
            if (dgvEmployee.Columns.Count > 0)
                return;


            var nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "الاسم",
                DataPropertyName = "FullName",
                AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill
            };


            var jobColumn = new DataGridViewTextBoxColumn
            {
                Name = "colJobTitle",
                HeaderText = "الوظيفة",
                Width = 150
            };


            var hireDateColumn = new DataGridViewTextBoxColumn
            {
                Name = "colHireDate",
                HeaderText = "تاريخ التعيين",
                Width = 140
            };


            var salaryColumn = new DataGridViewTextBoxColumn
            {
                Name = "colSalary",
                HeaderText = "الراتب",
                Width = 130
            };


            var PhoneNumberColumn = new DataGridViewTextBoxColumn
            {
                Name = "colPhoneNumber",
                HeaderText = "رقم التليفون",
                Width = 160
            };


            var statusColumn = new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "الحالة",
                Width = 120
            };


            var editColumn = new DataGridViewButtonColumn
            {
                Name = "colEdit",
                HeaderText = "الإجراءات",
                Text = "تعديل",
                UseColumnTextForButtonValue = true,
                Width = 100
            };


            var statusActionColumn = new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "",
                UseColumnTextForButtonValue = false,
                Width = 100
            };


            dgvEmployee.Columns.Add(nameColumn);
            dgvEmployee.Columns.Add(jobColumn);
            dgvEmployee.Columns.Add(hireDateColumn);
            dgvEmployee.Columns.Add(salaryColumn);
            dgvEmployee.Columns.Add(PhoneNumberColumn);
            dgvEmployee.Columns.Add(statusColumn);
            dgvEmployee.Columns.Add(editColumn);
            dgvEmployee.Columns.Add(statusActionColumn);
        }

        #endregion


        #region Load Positions

        private void LoadPositions()
        {
            var result =
                _employeeBusiness.GetPositions();

            if (!result.Success)
            {
                MessageBox.Show(
                    result.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _positions =
                result.Data ?? new List<EmployeePosition>();
        }


        private string GetPositionName(int positionID)
        {
            var position =
                _positions.FirstOrDefault(
                    p => p.PositionID == positionID);

            return position?.PositionName ?? "غير محدد";
        }

        #endregion


        #region Load Employees

        private void LoadEmployees()
        {
            var result =
                _employeeBusiness.GetAll(false);

            if (!result.Success)
            {
                MessageBox.Show(
                    result.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _employees =
                result.Data ?? new List<Employee>();

            dgvEmployee.Rows.Clear();

            foreach (var employee in _employees)
            {
                int rowIndex =
                    dgvEmployee.Rows.Add(
                        employee.FullName,
                        GetPositionName(employee.PositionID),
                        employee.HireDate.ToString("d/M/yyyy"),
                        $"{employee.BasicSalary:N0} ج",
                        employee.PhoneNumber,
                        employee.IsActive
                            ? "نشط"
                            : "غير نشط",
                        "تعديل",
                        employee.IsActive
                            ? "إيقاف"
                            : "تفعيل"
                    );

                dgvEmployee.Rows[rowIndex].Tag =
                    employee;

                ApplyStatusStyle(
                    dgvEmployee.Rows[rowIndex],
                    employee.IsActive);

                ApplyActionButtonStyle(
                    dgvEmployee.Rows[rowIndex],
                    employee.IsActive);
            }

            UpdateEmployeeCount();
        }


        private void UpdateEmployeeCount()
        {
            lblNumberOfEmployees.Text =
                $" عدد الموظفين : {_employees.Count:N0} ";
        }

        #endregion


        #region Status Style

        private void ApplyStatusStyle(
            DataGridViewRow row,
            bool isActive)
        {
            row.Cells["colStatus"]
                .Style.ForeColor =
                isActive
                    ? Color.Green
                    : Color.Red;

            row.Cells["colStatus"]
                .Style.Font =
                new Font(
                    "Cairo",
                    9,
                    FontStyle.Bold);
        }


        private void ApplyActionButtonStyle(
            DataGridViewRow row,
            bool isActive)
        {
            row.Cells["colDelete"]
                .Value =
                isActive
                    ? "إيقاف"
                    : "تفعيل";
        }

        #endregion


        #region Add Employee

        private void sbtnAddEmployee_Click(
            object sender,
            EventArgs e)
        {
            frmAddEmployee form = new frmAddEmployee();
            form.ShowDialog();

            if (form.DialogResult ==
                DialogResult.OK)
            {
                LoadEmployees();
            }
        }
        #endregion


        #region Edit / Status

        private void dgvEmployee_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.RowIndex >=
                dgvEmployee.Rows.Count)
                return;


            var row =
                dgvEmployee.Rows[e.RowIndex];


            if (row.Tag is not Employee employee)
                return;


            string columnName =
                dgvEmployee
                    .Columns[e.ColumnIndex]
                    .Name;


            if (columnName == "colEdit")
            {
                EditEmployee(employee);
            }
            else if (columnName == "colDelete")
            {
                ChangeEmployeeStatus(employee);
            }
        }


        private void EditEmployee(
            Employee employee)
        {
            frmEditEmployeeData form = new frmEditEmployeeData(employee);
            form.ShowDialog(this);
            if (form.DialogResult ==
                DialogResult.OK)
            {
                LoadEmployees();
            }
        }

        #endregion


        #region Activate / Deactivate

        private void ChangeEmployeeStatus(
            Employee employee)
        {
            string message =
                employee.IsActive
                    ? $"هل أنت متأكد من إيقاف الموظف:\n\n{employee.FullName}؟"
                    : $"هل تريد تفعيل الموظف:\n\n{employee.FullName}؟";


            var confirmation =
                MessageBox.Show(
                    message,
                    "تأكيد",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


            if (confirmation !=
                DialogResult.Yes)
                return;


            OperationResult result;


            if (employee.IsActive)
            {
                result =
                    _employeeBusiness
                        .DeactivateEmployee(
                            employee.EmployeeID);
            }
            else
            {
                result =
                    _employeeBusiness
                        .ActivateEmployee(
                            employee.EmployeeID);
            }


            if (!result.Success)
            {
                MessageBox.Show(
                    result.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            MessageBox.Show(
                result.Message,
                "تم",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);


            LoadEmployees();
        }

        #endregion


        #region Helpers

        private Label CreateLabel(
            string text)
        {
            return new Label
            {
                Text = text,

                AutoSize = true,

                Font =
                    new Font(
                        "Cairo",
                        10,
                        FontStyle.Bold),

                ForeColor =
                    Color.FromArgb(
                        55,
                        65,
                        81)
            };
        }


        private TextBox CreateTextBox()
        {
            return new TextBox
            {
                Font =
                    new Font(
                        "Cairo",
                        10),

                Height = 35,

                BorderStyle =
                    BorderStyle.FixedSingle
            };
        }

        #endregion


        #region Cards

        private void lblNumberOfEmployees_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                $"عدد الموظفين الحالي:\n\n{_employees.Count:N0}",
                "الموظفين",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion


        #region Print

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            if (dgvEmployee.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات للطباعة.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            clsGlobalClass.PrintDataGridView(
                dgvEmployee,
                "Employees Report");
        }

        #endregion


        #region Excel

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            if (dgvEmployee.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات للتصدير.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            clsGlobalClass
                .ExportDataGridViewToExcel(
                    dgvEmployee,
                    "Employees",
                    "Employees");
        }

        #endregion
    }
}