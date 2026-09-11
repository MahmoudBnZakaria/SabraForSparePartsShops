using Sabra.DataLayer.Models;
using Sabra.LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class frmRequireAdvance : Form
    {


        private readonly clsAdvanceBusiness _advanceBusiness =
            new clsAdvanceBusiness();

        private readonly clsEmployeeBusiness _employeeBusiness =
            new clsEmployeeBusiness();


        private ComboBox cmbEmployee;
        private NumericUpDown nudAmount;
        private DateTimePicker dtpDate;

        private Button btnSave;
        private Button btnCancel;



        private List<Employee> _employees =
            new List<Employee>();


        // =========================
        // Constructor
        // =========================

        public frmRequireAdvance()
        {
            InitializeComponent();

            InitializeForm();
            InitializeControls();
            LoadEmployees();
        }


        // =========================
        // Form Settings
        // =========================

        private void InitializeForm()
        {
            Text = "إضافة سلفة";

            StartPosition = FormStartPosition.CenterParent;

            Size = new Size(400, 300);

            FormBorderStyle =
                FormBorderStyle.FixedDialog;

            MaximizeBox = false;
            MinimizeBox = false;

            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }


        // =========================
        // Initialize Controls
        // =========================

        private void InitializeControls()
        {
            // -------------------------
            // Employee Label
            // -------------------------

            Label lblEmployee = new Label
            {
                Text = "الموظف:",
                Location = new Point(30, 30),
                AutoSize = true
            };


            // -------------------------
            // Employee ComboBox
            // -------------------------

            cmbEmployee = new ComboBox
            {
                Location = new Point(130, 25),
                Width = 220,

                DropDownStyle =
                    ComboBoxStyle.DropDownList
            };


            // -------------------------
            // Amount Label
            // -------------------------

            Label lblAmount = new Label
            {
                Text = "المبلغ:",
                Location = new Point(30, 80),
                AutoSize = true
            };


            // -------------------------
            // Amount
            // -------------------------

            nudAmount = new NumericUpDown
            {
                Location = new Point(130, 75),
                Width = 220,

                Minimum = 0,
                Maximum = 1000000,

                DecimalPlaces = 2,

                ThousandsSeparator = true
            };


            // -------------------------
            // Date Label
            // -------------------------

            Label lblDate = new Label
            {
                Text = "التاريخ:",
                Location = new Point(30, 130),
                AutoSize = true
            };


            // -------------------------
            // Date
            // -------------------------

            dtpDate = new DateTimePicker
            {
                Location = new Point(130, 125),
                Width = 220,

                Format =
                    DateTimePickerFormat.Short,

                Value = DateTime.Today
            };


            // -------------------------
            // Save Button
            // -------------------------

            btnSave = new Button
            {
                Text = "حفظ",
                Location = new Point(130, 190),
                Width = 100,
                Height = 30
            };

            btnSave.Click += btnSave_Click;


            // -------------------------
            // Cancel Button
            // -------------------------

            btnCancel = new Button
            {
                Text = "إلغاء",
                Location = new Point(250, 190),
                Width = 100,
                Height = 30,

                DialogResult = DialogResult.Cancel
            };


            // -------------------------
            // Add Controls
            // -------------------------

            Controls.Add(lblEmployee);
            Controls.Add(cmbEmployee);

            Controls.Add(lblAmount);
            Controls.Add(nudAmount);

            Controls.Add(lblDate);
            Controls.Add(dtpDate);

            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }


        // =========================
        // Load Employees
        // =========================

        private void LoadEmployees()
        {
            var result =
                _employeeBusiness.GetAll();

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


            // =========================
            // Manager
            // =========================

            if (clsAppSession.IsManager)
            {
                cmbEmployee.DataSource =
                    _employees;
            }

            // =========================
            // Normal Employee
            // =========================

            else
            {
                _employees =
                    _employees
                    .Where(emp =>
                        emp.EmployeeID ==
                        clsAppSession.CurrentEmployee.EmployeeID)
                    .ToList();

                cmbEmployee.DataSource =
                    _employees;
            }


            // =========================
            // Display / Value
            // =========================

            cmbEmployee.DisplayMember =
                "FullName";

            cmbEmployee.ValueMember =
                "EmployeeID";
        }


        // =========================
        // Save
        // =========================

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            // -------------------------
            // Validate Employee
            // -------------------------

            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show(
                    "يرجى اختيار الموظف.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // -------------------------
            // Validate Amount
            // -------------------------

            if (nudAmount.Value <= 0)
            {
                MessageBox.Show(
                    "يرجى إدخال مبلغ صحيح.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                nudAmount.Focus();

                return;
            }


            // -------------------------
            // Create Advance
            // -------------------------

            var newAdvance = new Advance
            {
                EmployeeID =
                    Convert.ToInt32(
                        cmbEmployee.SelectedValue),

                Amount =
                    nudAmount.Value,

                AdvanceDate =
                    dtpDate.Value.Date
            };


            // -------------------------
            // Request Advance
            // -------------------------

            var result =
                _advanceBusiness.RequestAdvance(
                    newAdvance);


            // -------------------------
            // Result
            // -------------------------

            if (!result.Success)
            {
                MessageBox.Show(
                    result.Message,
                    "فشل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // -------------------------
            // Success
            // -------------------------

            MessageBox.Show(
                "تم إدخال بيانات السلفة بنجاح.",
                "نجاح",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult =
                DialogResult.OK;

            Close();
        }
    }
}
