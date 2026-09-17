using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class frmAddExpense : Form
    {
        private readonly Expense _expense;
        private readonly List<ExpenseCategory> _categories;
        private readonly List<Employee> _employees;
        private readonly List<PaymentMethod> _paymentMethods;
        private readonly dynamic _expenseBusiness; // استبدلها بنوع Class الـ Business لديك (مثل ExpenseBusiness)
        private readonly bool _isEdit;

        public frmAddExpense(
            Expense expense,
            List<ExpenseCategory> categories,
            List<Employee> employees,
            List<PaymentMethod> paymentMethods,
            dynamic expenseBusiness)
        {
            InitializeComponent();

            _expense = expense;
            _categories = categories;
            _employees = employees;
            _paymentMethods = paymentMethods;
            _expenseBusiness = expenseBusiness;

            _isEdit = _expense != null;

            SetupFormInitialData();
        }

        private void SetupFormInitialData()
        {
            this.Text = _isEdit ? "تعديل المصروف" : "إضافة مصروف جديد";
            btnSave.Text = _isEdit ? "حفظ التعديل" : "حفظ";
            dtpDate.MaxDate = DateTime.Today;

            // ربط القوائم
            cmbCategory.DataSource = new List<ExpenseCategory>(_categories);
            cmbPaidBy.DataSource = new List<Employee>(_employees);
            cmbPaymentMethod.DataSource = new List<PaymentMethod>(_paymentMethods);

            if (_isEdit)
            {
                cmbCategory.SelectedValue = _expense.CategoryID;
                dtpDate.Value = _expense.ExpenseDate;
                txtAmount.Text = _expense.Amount.ToString("0.##");

                if (_expense.PaidBy.HasValue)
                {
                    cmbPaidBy.SelectedValue = _expense.PaidBy.Value;
                }

                txtNotes.Text = _expense.Notes;
            }
            else
            {
                dtpDate.Value = DateTime.Today;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (cmbCategory.SelectedValue == null)
            {
                ShowWarning("يجب اختيار تصنيف المصروف.");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount))
            {
                ShowWarning("أدخل مبلغًا صحيحًا.");
                txtAmount.Focus();
                return;
            }

            if (amount <= 0)
            {
                ShowWarning("المبلغ يجب أن يكون أكبر من صفر.");
                txtAmount.Focus();
                return;
            }

            if (cmbPaidBy.SelectedValue == null)
            {
                ShowWarning("يجب اختيار الموظف الذي قام بالدفع.");
                return;
            }

            // ADD MODE
            if (!_isEdit)
            {
                if (cmbPaymentMethod.SelectedValue == null)
                {
                    ShowWarning("يجب اختيار طريقة الدفع.");
                    return;
                }

                Expense newExpense = new Expense
                {
                    CategoryID = Convert.ToInt32(cmbCategory.SelectedValue),
                    Amount = amount,
                    ExpenseDate = dtpDate.Value.Date,
                    PaidBy = Convert.ToInt32(cmbPaidBy.SelectedValue),
                    Notes = txtNotes.Text.Trim()
                };

                int paymentMethodID = Convert.ToInt32(cmbPaymentMethod.SelectedValue);
                var result = _expenseBusiness.Add(newExpense, paymentMethodID);

                if (!result.Success)
                {
                    ShowError(result.Message);
                    return;
                }

                MessageBox.Show(
                    result.Message,
                    "المصروفات",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // UPDATE MODE
            Expense updatedExpense = new Expense
            {
                ExpenseID = _expense.ExpenseID,
                CategoryID = Convert.ToInt32(cmbCategory.SelectedValue),
                Amount = amount,
                ExpenseDate = dtpDate.Value.Date,
                PaidBy = Convert.ToInt32(cmbPaidBy.SelectedValue),
                Notes = txtNotes.Text.Trim()
            };

            var updateResult = _expenseBusiness.Update(updatedExpense);

            if (!updateResult.Success)
            {
                ShowError(updateResult.Message);
                return;
            }

            MessageBox.Show(
                updateResult.Message,
                "المصروفات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}