using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucEmployees : SabraUserControl
    {
        #region Employee Model

        private class Employee
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string JobTitle { get; set; }

            public DateTime HireDate { get; set; }

            public decimal Salary { get; set; }

            public string Phone { get; set; }

            public string Status { get; set; }
        }

        #endregion

        #region Fields

        private readonly List<Employee> _employees = new();

        private int _nextEmployeeId = 1;

        #endregion

        public ucEmployees()
        {
            InitializeComponent();

            InitializePage();
        }

        #region Initialize

        private void InitializePage()
        {
            SetupGrid();

            LoadMockData();

            LoadEmployees();
        }

        #endregion

        #region Mock Data

        private void LoadMockData()
        {
            _employees.Clear();

            _employees.Add(new Employee
            {
                Id = _nextEmployeeId++,
                Name = "أحمد محمد",
                JobTitle = "مدير",
                HireDate = new DateTime(2020, 1, 1),
                Salary = 4000,
                Phone = "01012345678",
                Status = "نشط"
            });

            _employees.Add(new Employee
            {
                Id = _nextEmployeeId++,
                Name = "سارة أحمد",
                JobTitle = "كاشير",
                HireDate = new DateTime(2022, 3, 15),
                Salary = 3000,
                Phone = "01098765432",
                Status = "نشط"
            });

            _employees.Add(new Employee
            {
                Id = _nextEmployeeId++,
                Name = "خالد محمود",
                JobTitle = "أمين المستودع",
                HireDate = new DateTime(2023, 6, 1),
                Salary = 2000,
                Phone = "01123456789",
                Status = "نشط"
            });

            _employees.Add(new Employee
            {
                Id = _nextEmployeeId++,
                Name = "محمد علي",
                JobTitle = "بائع",
                HireDate = new DateTime(2021, 9, 10),
                Salary = 2800,
                Phone = "01234567890",
                Status = "نشط"
            });

            _employees.Add(new Employee
            {
                Id = _nextEmployeeId++,
                Name = "محمود حسن",
                JobTitle = "محاسب",
                HireDate = new DateTime(2022, 11, 5),
                Salary = 3500,
                Phone = "01198765432",
                Status = "نشط"
            });

            _employees.Add(new Employee
            {
                Id = _nextEmployeeId++,
                Name = "عمر إبراهيم",
                JobTitle = "بائع",
                HireDate = new DateTime(2024, 2, 20),
                Salary = 2500,
                Phone = "01055667788",
                Status = "غير نشط"
            });

            _employees.Add(new Employee
            {
                Id = _nextEmployeeId++,
                Name = "يوسف خالد",
                JobTitle = "عامل مخزن",
                HireDate = new DateTime(2024, 5, 12),
                Salary = 2200,
                Phone = "01211223344",
                Status = "نشط"
            });
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
                DataPropertyName = "Name",
                AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill
            };

            var jobColumn = new DataGridViewTextBoxColumn
            {
                Name = "colJobTitle",
                HeaderText = "الوظيفة",
                DataPropertyName = "JobTitle",
                Width = 150
            };

            var hireDateColumn = new DataGridViewTextBoxColumn
            {
                Name = "colHireDate",
                HeaderText = "تاريخ التعيين",
                DataPropertyName = "HireDate",
                Width = 140
            };

            var salaryColumn = new DataGridViewTextBoxColumn
            {
                Name = "colSalary",
                HeaderText = "الراتب",
                DataPropertyName = "Salary",
                Width = 130
            };

            var phoneColumn = new DataGridViewTextBoxColumn
            {
                Name = "colPhone",
                HeaderText = "رقم التليفون",
                DataPropertyName = "Phone",
                Width = 160
            };

            var statusColumn = new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "الحالة",
                DataPropertyName = "Status",
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

            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "",
                Text = "حذف",
                UseColumnTextForButtonValue = true,
                Width = 90
            };

            dgvEmployee.Columns.Add(nameColumn);
            dgvEmployee.Columns.Add(jobColumn);
            dgvEmployee.Columns.Add(hireDateColumn);
            dgvEmployee.Columns.Add(salaryColumn);
            dgvEmployee.Columns.Add(phoneColumn);
            dgvEmployee.Columns.Add(statusColumn);
            dgvEmployee.Columns.Add(editColumn);
            dgvEmployee.Columns.Add(deleteColumn);
        }

        #endregion

        #region Load Employees

        private void LoadEmployees()
        {
            dgvEmployee.Rows.Clear();

            foreach (var employee in _employees)
            {
                int rowIndex =
                    dgvEmployee.Rows.Add(
                        employee.Name,
                        employee.JobTitle,
                        employee.HireDate.ToString("d/M/yyyy"),
                        $"{employee.Salary:N0} ج",
                        employee.Phone,
                        employee.Status,
                        "تعديل",
                        "حذف"
                    );

                dgvEmployee.Rows[rowIndex].Tag =
                    employee;

                ApplyStatusStyle(
                    dgvEmployee.Rows[rowIndex],
                    employee.Status);
            }

            UpdateEmployeeCount();
        }

        private void UpdateEmployeeCount()
        {
            lblNumberOfEmployees.Text = $" عدد الموظفين : {_employees.Count.ToString("N0")} ";
        }

        #endregion

        #region Status Style

        private void ApplyStatusStyle(
            DataGridViewRow row,
            string status)
        {
            if (status == "نشط")
            {
                row.Cells["colStatus"]
                    .Style.ForeColor = Color.Green;

                row.Cells["colStatus"]
                    .Style.Font =
                    new Font("Cairo", 9, FontStyle.Bold);
            }
            else
            {
                row.Cells["colStatus"]
                    .Style.ForeColor = Color.Red;

                row.Cells["colStatus"]
                    .Style.Font =
                    new Font("Cairo", 9, FontStyle.Bold);
            }
        }

        #endregion

        #region Add Employee

        private void sbtnAddEmployee_Click(
            object sender,
            EventArgs e)
        {
            using var form = new Form();

            form.Text = "إضافة موظف جديد";
            form.StartPosition =
                FormStartPosition.CenterParent;

            form.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            form.MaximizeBox = false;
            form.MinimizeBox = false;

            form.Size = new Size(500, 570);

            form.RightToLeft =
                RightToLeft.Yes;

            form.RightToLeftLayout = true;

            var lblName = CreateLabel("اسم الموظف");
            lblName.Location = new Point(30, 30);

            var txtName = CreateTextBox();
            txtName.Location = new Point(30, 65);
            txtName.Width = 420;

            var lblJob = CreateLabel("الوظيفة");
            lblJob.Location = new Point(30, 115);

            var txtJob = CreateTextBox();
            txtJob.Location = new Point(30, 150);
            txtJob.Width = 420;

            var lblDate = CreateLabel("تاريخ التعيين");
            lblDate.Location = new Point(30, 200);

            var dtpDate = new DateTimePicker
            {
                Location = new Point(30, 235),
                Width = 420,
                Format = DateTimePickerFormat.Short
            };

            var lblSalary = CreateLabel("الراتب");
            lblSalary.Location = new Point(30, 285);

            var txtSalary = CreateTextBox();
            txtSalary.Location = new Point(30, 320);
            txtSalary.Width = 420;

            var lblPhone = CreateLabel("رقم التليفون");
            lblPhone.Location = new Point(30, 370);

            var txtPhone = CreateTextBox();
            txtPhone.Location = new Point(30, 405);
            txtPhone.Width = 420;

            var lblStatus = CreateLabel("الحالة");
            lblStatus.Location = new Point(30, 455);

            var cmbStatus = new ComboBox
            {
                Location = new Point(30, 490),
                Width = 200,
                DropDownStyle =
                    ComboBoxStyle.DropDownList
            };

            cmbStatus.Items.Add("نشط");
            cmbStatus.Items.Add("غير نشط");
            cmbStatus.SelectedIndex = 0;

            var btnSave = new Button
            {
                Text = "حفظ",
                Width = 100,
                Height = 40,
                Location = new Point(350, 490),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnSave.Click += (s, args) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show(
                        "من فضلك أدخل اسم الموظف.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(txtJob.Text))
                {
                    MessageBox.Show(
                        "من فضلك أدخل الوظيفة.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!decimal.TryParse(
                        txtSalary.Text,
                        out decimal salary))
                {
                    MessageBox.Show(
                        "من فضلك أدخل راتب صحيح.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var employee = new Employee
                {
                    Id = _nextEmployeeId++,
                    Name = txtName.Text.Trim(),
                    JobTitle = txtJob.Text.Trim(),
                    HireDate = dtpDate.Value.Date,
                    Salary = salary,
                    Phone = txtPhone.Text.Trim(),
                    Status = cmbStatus.Text
                };

                _employees.Add(employee);

                LoadEmployees();

                form.DialogResult =
                    DialogResult.OK;

                form.Close();
            };

            form.Controls.Add(lblName);
            form.Controls.Add(txtName);
            form.Controls.Add(lblJob);
            form.Controls.Add(txtJob);
            form.Controls.Add(lblDate);
            form.Controls.Add(dtpDate);
            form.Controls.Add(lblSalary);
            form.Controls.Add(txtSalary);
            form.Controls.Add(lblPhone);
            form.Controls.Add(txtPhone);
            form.Controls.Add(lblStatus);
            form.Controls.Add(cmbStatus);
            form.Controls.Add(btnSave);

            form.ShowDialog(this);
        }

        #endregion

        #region Edit / Delete

        private void dgvEmployee_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.RowIndex >= dgvEmployee.Rows.Count)
                return;

            var row =
                dgvEmployee.Rows[e.RowIndex];

            if (row.Tag is not Employee employee)
                return;

            if (dgvEmployee.Columns[e.ColumnIndex].Name ==
                "colEdit")
            {
                EditEmployee(employee);
            }
            else if (
                dgvEmployee.Columns[e.ColumnIndex].Name ==
                "colDelete")
            {
                DeleteEmployee(employee);
            }
        }

        private void EditEmployee(
            Employee employee)
        {
            using var form = new Form();

            form.Text = "تعديل بيانات الموظف";

            form.StartPosition =
                FormStartPosition.CenterParent;

            form.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            form.MaximizeBox = false;
            form.MinimizeBox = false;

            form.Size = new Size(500, 570);

            form.RightToLeft =
                RightToLeft.Yes;

            form.RightToLeftLayout = true;

            var lblName = CreateLabel("اسم الموظف");
            lblName.Location = new Point(30, 30);

            var txtName = CreateTextBox();
            txtName.Location = new Point(30, 65);
            txtName.Width = 420;
            txtName.Text = employee.Name;

            var lblJob = CreateLabel("الوظيفة");
            lblJob.Location = new Point(30, 115);

            var txtJob = CreateTextBox();
            txtJob.Location = new Point(30, 150);
            txtJob.Width = 420;
            txtJob.Text = employee.JobTitle;

            var lblDate = CreateLabel("تاريخ التعيين");
            lblDate.Location = new Point(30, 200);

            var dtpDate = new DateTimePicker
            {
                Location = new Point(30, 235),
                Width = 420,
                Format = DateTimePickerFormat.Short,
                Value = employee.HireDate
            };

            var lblSalary = CreateLabel("الراتب");
            lblSalary.Location = new Point(30, 285);

            var txtSalary = CreateTextBox();
            txtSalary.Location = new Point(30, 320);
            txtSalary.Width = 420;
            txtSalary.Text =
                employee.Salary.ToString("0");

            var lblPhone = CreateLabel("رقم التليفون");
            lblPhone.Location = new Point(30, 370);

            var txtPhone = CreateTextBox();
            txtPhone.Location = new Point(30, 405);
            txtPhone.Width = 420;
            txtPhone.Text = employee.Phone;

            var lblStatus = CreateLabel("الحالة");
            lblStatus.Location = new Point(30, 455);

            var cmbStatus = new ComboBox
            {
                Location = new Point(30, 490),
                Width = 200,
                DropDownStyle =
                    ComboBoxStyle.DropDownList
            };

            cmbStatus.Items.Add("نشط");
            cmbStatus.Items.Add("غير نشط");

            cmbStatus.SelectedItem =
                employee.Status;

            var btnSave = new Button
            {
                Text = "حفظ التعديل",
                Width = 130,
                Height = 40,
                Location = new Point(320, 490),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnSave.Click += (s, args) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                    return;

                if (string.IsNullOrWhiteSpace(txtJob.Text))
                    return;

                if (!decimal.TryParse(
                        txtSalary.Text,
                        out decimal salary))
                {
                    MessageBox.Show(
                        "الراتب غير صحيح.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                employee.Name =
                    txtName.Text.Trim();

                employee.JobTitle =
                    txtJob.Text.Trim();

                employee.HireDate =
                    dtpDate.Value.Date;

                employee.Salary =
                    salary;

                employee.Phone =
                    txtPhone.Text.Trim();

                employee.Status =
                    cmbStatus.Text;

                LoadEmployees();

                form.Close();
            };

            form.Controls.Add(lblName);
            form.Controls.Add(txtName);
            form.Controls.Add(lblJob);
            form.Controls.Add(txtJob);
            form.Controls.Add(lblDate);
            form.Controls.Add(dtpDate);
            form.Controls.Add(lblSalary);
            form.Controls.Add(txtSalary);
            form.Controls.Add(lblPhone);
            form.Controls.Add(txtPhone);
            form.Controls.Add(lblStatus);
            form.Controls.Add(cmbStatus);
            form.Controls.Add(btnSave);

            form.ShowDialog(this);
        }

        private void DeleteEmployee(
            Employee employee)
        {
            var result =
                MessageBox.Show(
                    $"هل أنت متأكد من حذف الموظف:\n\n{employee.Name}؟",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            _employees.Remove(employee);

            LoadEmployees();
        }

        #endregion

        #region Helpers

        private Label CreateLabel(string text)
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

            clsGlobalClass.ExportDataGridViewToExcel(
                dgvEmployee,
                "Employees",
                "Employees");
        }

        #endregion
    }
}