using Sabra.DataLayer;
using Sabra.DataLayer.Models;
using Sabra.LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucExpenses : SabraUserControl
    {
#region Fields

    private readonly clsExpenseBusiness _expenseBusiness =
        new clsExpenseBusiness();

        private readonly clsEmployeeBusiness _employeeBusiness =
            new clsEmployeeBusiness();

        private List<Expense> _expenses =
            new List<Expense>();

        private List<ExpenseCategory> _categories =
            new List<ExpenseCategory>();

        private List<PaymentMethod> _paymentMethods =
            new List<PaymentMethod>();

        private List<Employee> _employees =
            new List<Employee>();

        #endregion


        #region Constructor

        public ucExpenses()
        {
            InitializeComponent();

            Load += ucExpenses_Load;

            btnSearch.Click +=
                btnSearch_Click;

            smbxPeriod.SelectedIndexChanged +=
                smbxPeriod_SelectedIndexChanged;

            cmbClassification.SelectedIndexChanged +=
                cmbClassification_SelectedIndexChanged;
        }

        #endregion


        #region Load

        private void ucExpenses_Load(
            object sender,
            EventArgs e)
        {
            SetupScreen();
        }


        private void SetupScreen()
        {
            SetupPeriodFilter();

            SetupGrid();

            LoadCategories();

            LoadPaymentMethods();

            LoadEmployees();

            dtpFrom.Value =
                DateTime.Today.AddDays(-30);

            dtpTo.Value =
                DateTime.Today;

            smbxPeriod.SelectedIndex =
                0;

            LoadExpenses();
        }

        #endregion


        #region Categories

        private void LoadCategories()
        {
            var result =
                _expenseBusiness
                    .GetCategories();


            if (!result.Success)
            {
                ShowError(
                    result.Message);

                return;
            }


            _categories =
                result.Data ??
                new List<ExpenseCategory>();


            cmbClassification.Items.Clear();


            cmbClassification.Items.Add(
                new ExpenseCategory
                {
                    CategoryID = 0,

                    CategoryName =
                        "كل التصنيفات"
                });


            foreach (var category in _categories)
            {
                cmbClassification.Items.Add(
                    category);
            }


            cmbClassification.DisplayMember =
                "CategoryName";

            cmbClassification.ValueMember =
                "CategoryID";


            if (cmbClassification.Items.Count > 0)
            {
                cmbClassification.SelectedIndex =
                    0;
            }
        }

        #endregion


        #region Payment Methods

        private void LoadPaymentMethods()
        {
            var result =
                _expenseBusiness
                    .GetPaymentMethods();


            if (!result.Success)
            {
                ShowError(
                    result.Message);

                return;
            }


            _paymentMethods =
                result.Data ??
                new List<PaymentMethod>();
        }

        #endregion


        #region Employees

        private void LoadEmployees()
        {
            var result =
                _employeeBusiness
                    .GetAll(true);


            if (!result.Success)
            {
                ShowError(
                    result.Message);

                return;
            }


            _employees =
                result.Data ??
                new List<Employee>();
        }

        #endregion


        #region Period

        private void SetupPeriodFilter()
        {
            smbxPeriod.Items.Clear();

            smbxPeriod.Items.Add(
                "كل الفترات");

            smbxPeriod.Items.Add(
                "اليوم");

            smbxPeriod.Items.Add(
                "هذا الأسبوع");

            smbxPeriod.Items.Add(
                "هذا الشهر");
        }


        private void ApplyPeriodFilter()
        {
            string period =
                smbxPeriod.SelectedItem
                    ?.ToString();


            if (string.IsNullOrWhiteSpace(
                period))
            {
                return;
            }


            DateTime today =
                DateTime.Today;


            switch (period)
            {
                case "اليوم":

                    dtpFrom.Value =
                        today;

                    dtpTo.Value =
                        today;

                    break;


                case "هذا الأسبوع":

                    int difference =
                        (7 +
                         (today.DayOfWeek -
                          DayOfWeek.Saturday))
                        % 7;


                    dtpFrom.Value =
                        today.AddDays(
                            -difference);

                    dtpTo.Value =
                        today;

                    break;


                case "هذا الشهر":

                    dtpFrom.Value =
                        new DateTime(
                            today.Year,
                            today.Month,
                            1);

                    dtpTo.Value =
                        today;

                    break;
            }


            LoadExpenses();
        }

        #endregion


        #region Grid

        private void SetupGrid()
        {
            dgvExpenses.AutoGenerateColumns =
                false;

            dgvExpenses.Columns.Clear();

            dgvExpenses.RightToLeft =
                RightToLeft.Yes;

            dgvExpenses.AllowUserToAddRows =
                false;

            dgvExpenses.AllowUserToDeleteRows =
                false;

            dgvExpenses.ReadOnly =
                true;

            dgvExpenses.RowHeadersVisible =
                false;

            dgvExpenses.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvExpenses.MultiSelect =
                false;

            dgvExpenses.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvExpenses.ColumnHeadersHeight =
                45;

            dgvExpenses.RowTemplate.Height =
                48;

            dgvExpenses.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvExpenses.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvExpenses.DefaultCellStyle.Font =
                new Font(
                    "Cairo",
                    10F);

            dgvExpenses.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Cairo",
                    10F,
                    FontStyle.Bold);


            AddTextColumn(
                "colDate",
                "التاريخ",
                "ExpenseDate",
                "dd/MM/yyyy");


            AddTextColumn(
                "colClassification",
                "التصنيف",
                "CategoryName");


            AddTextColumn(
                "colAmount",
                "المبلغ",
                "Amount",
                "N2");


            AddTextColumn(
                "colPaidBy",
                "دفع بواسطة",
                "PaidByName");


            AddTextColumn(
                "colNotes",
                "ملاحظات",
                "Notes");


            DataGridViewButtonColumn actions =
                new DataGridViewButtonColumn
                {
                    Name =
                        "colActions",

                    HeaderText =
                        "الإجراءات",

                    Text =
                        "إجراءات",

                    UseColumnTextForButtonValue =
                        true,

                    ReadOnly =
                        true,

                    FillWeight =
                        100
                };


            dgvExpenses.Columns.Add(
                actions);


            dgvExpenses.CellContentClick -=
                dgvExpenses_CellContentClick;

            dgvExpenses.CellContentClick +=
                dgvExpenses_CellContentClick;
        }


        private void AddTextColumn(
            string name,
            string header,
            string property,
            string format = null)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn();


            column.Name =
                name;

            column.HeaderText =
                header;

            column.DataPropertyName =
                property;

            column.SortMode =
                DataGridViewColumnSortMode.NotSortable;


            if (!string.IsNullOrEmpty(format))
            {
                column.DefaultCellStyle.Format =
                    format;
            }


            dgvExpenses.Columns.Add(
                column);
        }

        #endregion


        #region Load Expenses

        private void LoadExpenses()
        {
            DateTime from =
                dtpFrom.Value.Date;


            DateTime to =
                dtpTo.Value.Date;


            if (from > to)
            {
                ShowWarning(
                    "تاريخ البداية لا يمكن أن يكون بعد تاريخ النهاية.");

                return;
            }


            int? categoryID =
                GetSelectedCategoryID();


            var result =
                _expenseBusiness.GetAll(
                    from,
                    to,
                    categoryID);


            if (!result.Success)
            {
                ShowError(
                    result.Message);

                return;
            }


            _expenses =
                result.Data ??
                new List<Expense>();


            _expenses =
                _expenses
                    .OrderByDescending(
                        x => x.ExpenseDate)
                    .ThenByDescending(
                        x => x.ExpenseID)
                    .ToList();


            dgvExpenses.DataSource =
                null;

            dgvExpenses.DataSource =
                _expenses;


            UpdateSummary(
                _expenses);
        }


        private int? GetSelectedCategoryID()
        {
            if (cmbClassification.SelectedItem
                is ExpenseCategory category)
            {
                if (category.CategoryID <= 0)
                    return null;


                return category.CategoryID;
            }


            return null;
        }

        #endregion


        #region Summary

        private void UpdateSummary(
            List<Expense> expenses)
        {
            decimal total =
                expenses.Sum(
                    x => x.Amount);


            decimal rent =
                expenses
                    .Where(
                        x => x.CategoryName ==
                             "إيجار")
                    .Sum(
                        x => x.Amount);


            decimal electricity =
                expenses
                    .Where(
                        x => x.CategoryName ==
                             "كهرباء")
                    .Sum(
                        x => x.Amount);


            decimal other =
                expenses
                    .Where(
                        x =>
                            x.CategoryName !=
                                "إيجار"
                            &&
                            x.CategoryName !=
                                "كهرباء")
                    .Sum(
                        x => x.Amount);


            lblTotalExpenses.Text =
                total.ToString("N2") +
                " ج";


            lblReleaseFees.Text =
                rent.ToString("N2") +
                " ج";


            lblElectricity.Text =
                electricity.ToString("N2") +
                " ج";


            lblOtherExpenses.Text =
                other.ToString("N2") +
                " ج";


            lblNameOfTheMonthAndYear.Text =
                GetPeriodTitle();
        }


        private string GetPeriodTitle()
        {
            string period =
                smbxPeriod.SelectedItem
                    ?.ToString();


            if (period == "اليوم")
            {
                return DateTime.Today
                    .ToString("dd/MM/yyyy");
            }


            if (period == "هذا الأسبوع")
            {
                return "هذا الأسبوع";
            }


            if (period == "هذا الشهر")
            {
                return DateTime.Today
                    .ToString("MMMM yyyy");
            }


            return
                dtpFrom.Value
                    .ToString("dd/MM/yyyy")
                +
                " - "
                +
                dtpTo.Value
                    .ToString("dd/MM/yyyy");
        }

        #endregion


        #region Search

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            LoadExpenses();
        }


        private void smbxPeriod_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ApplyPeriodFilter();
        }


        private void cmbClassification_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadExpenses();
            }
        }

        #endregion


        #region Add

        private void sbtnAddNewExpense_Click(
            object sender,
            EventArgs e)
        {
            ShowExpenseForm(
                null);
        }

        #endregion


        #region Edit

        private void EditExpense(
            Expense expense)
        {
            ShowExpenseForm(
                expense);
        }

        #endregion


        #region Expense Form

        private void ShowExpenseForm(
            Expense expense)
        {
            bool isEdit =
                expense != null;


            using Form form =
                new Form();


            form.Text =
                isEdit
                    ? "تعديل المصروف"
                    : "إضافة مصروف جديد";


            form.StartPosition =
                FormStartPosition.CenterParent;


            form.FormBorderStyle =
                FormBorderStyle.FixedDialog;


            form.MaximizeBox =
                false;

            form.MinimizeBox =
                false;


            form.Size =
                new Size(
                    520,
                    600);


            form.RightToLeft =
                RightToLeft.Yes;

            form.RightToLeftLayout =
                true;


            // =====================================================
            // Category
            // =====================================================

            Label lblCategory =
                CreateLabel(
                    "تصنيف المصروف");


            lblCategory.Location =
                new Point(
                    30,
                    25);


            ComboBox cmbCategory =
                new ComboBox
                {
                    Location =
                        new Point(
                            30,
                            60),

                    Width =
                        440,

                    DropDownStyle =
                        ComboBoxStyle.DropDownList,

                    Font =
                        new Font(
                            "Cairo",
                            10),

                    DisplayMember =
                        "CategoryName",

                    ValueMember =
                        "CategoryID"
                };


            cmbCategory.DataSource =
                new List<ExpenseCategory>(
                    _categories);


            if (isEdit)
            {
                cmbCategory.SelectedValue =
                    expense.CategoryID;
            }


            // =====================================================
            // Date
            // =====================================================

            Label lblDate =
                CreateLabel(
                    "التاريخ");


            lblDate.Location =
                new Point(
                    30,
                    110);


            DateTimePicker dtpDate =
                new DateTimePicker
                {
                    Location =
                        new Point(
                            30,
                            145),

                    Width =
                        440,

                    Format =
                        DateTimePickerFormat.Short,

                    MaxDate =
                        DateTime.Today,

                    Value =
                        isEdit
                            ? expense.ExpenseDate
                            : DateTime.Today
                };


            // =====================================================
            // Amount
            // =====================================================

            Label lblAmount =
                CreateLabel(
                    "المبلغ");


            lblAmount.Location =
                new Point(
                    30,
                    195);


            TextBox txtAmount =
                CreateTextBox();


            txtAmount.Location =
                new Point(
                    30,
                    230);


            txtAmount.Width =
                440;


            if (isEdit)
            {
                txtAmount.Text =
                    expense.Amount
                        .ToString("0.##");
            }


            // =====================================================
            // Paid By
            // =====================================================

            Label lblPaidBy =
                CreateLabel(
                    "دفع بواسطة");


            lblPaidBy.Location =
                new Point(
                    30,
                    280);


            ComboBox cmbPaidBy =
                new ComboBox
                {
                    Location =
                        new Point(
                            30,
                            315),

                    Width =
                        440,

                    DropDownStyle =
                        ComboBoxStyle.DropDownList,

                    Font =
                        new Font(
                            "Cairo",
                            10),

                    DisplayMember =
                        "FullName",

                    ValueMember =
                        "EmployeeID"
                };


            cmbPaidBy.DataSource =
                new List<Employee>(
                    _employees);


            if (isEdit &&
                expense.PaidBy.HasValue)
            {
                cmbPaidBy.SelectedValue =
                    expense.PaidBy.Value;
            }


            // =====================================================
            // Payment Method
            // =====================================================

            Label lblPaymentMethod =
                CreateLabel(
                    "طريقة الدفع");


            lblPaymentMethod.Location =
                new Point(
                    30,
                    365);


            ComboBox cmbPaymentMethod =
                new ComboBox
                {
                    Location =
                        new Point(
                            30,
                            400),

                    Width =
                        440,

                    DropDownStyle =
                        ComboBoxStyle.DropDownList,

                    Font =
                        new Font(
                            "Cairo",
                            10),

                    DisplayMember =
                        "MethodName",

                    ValueMember =
                        "PaymentMethodID"
                };


            cmbPaymentMethod.DataSource =
                new List<PaymentMethod>(
                    _paymentMethods);


            // =====================================================
            // Notes
            // =====================================================

            Label lblNotes =
                CreateLabel(
                    "ملاحظات");


            lblNotes.Location =
                new Point(
                    30,
                    450);


            TextBox txtNotes =
                CreateTextBox();


            txtNotes.Location =
                new Point(
                    30,
                    485);


            txtNotes.Width =
                440;


            if (isEdit)
            {
                txtNotes.Text =
                    expense.Notes;
            }


            // =====================================================
            // Save
            // =====================================================

            Button btnSave =
                new Button
                {
                    Text =
                        isEdit
                            ? "حفظ التعديل"
                            : "حفظ",

                    Width =
                        130,

                    Height =
                        40,

                    Location =
                        new Point(
                            340,
                            525),

                    BackColor =
                        Color.RoyalBlue,

                    ForeColor =
                        Color.White,

                    FlatStyle =
                        FlatStyle.Flat,

                    Font =
                        new Font(
                            "Cairo",
                            9,
                            FontStyle.Bold)
                };


            btnSave.Click +=
                (s, e) =>
                {
                    // =================================================
                    // Validation
                    // =================================================

                    if (cmbCategory.SelectedValue == null)
                    {
                        ShowWarning(
                            "يجب اختيار تصنيف المصروف.");

                        return;
                    }


                    if (!decimal.TryParse(
                        txtAmount.Text.Trim(),
                        out decimal amount))
                    {
                        ShowWarning(
                            "أدخل مبلغًا صحيحًا.");

                        txtAmount.Focus();

                        return;
                    }


                    if (amount <= 0)
                    {
                        ShowWarning(
                            "المبلغ يجب أن يكون أكبر من صفر.");

                        txtAmount.Focus();

                        return;
                    }


                    if (cmbPaidBy.SelectedValue == null)
                    {
                        ShowWarning(
                            "يجب اختيار الموظف الذي قام بالدفع.");

                        return;
                    }


                    // =================================================
                    // ADD
                    // =================================================

                    if (!isEdit)
                    {
                        if (cmbPaymentMethod.SelectedValue == null)
                        {
                            ShowWarning(
                                "يجب اختيار طريقة الدفع.");

                            return;
                        }


                        Expense newExpense =
                            new Expense
                            {
                                CategoryID =
                                    Convert.ToInt32(
                                        cmbCategory.SelectedValue),

                                Amount =
                                    amount,

                                ExpenseDate =
                                    dtpDate.Value.Date,

                                PaidBy =
                                    Convert.ToInt32(
                                        cmbPaidBy.SelectedValue),

                                Notes =
                                    txtNotes.Text.Trim()
                            };


                        int paymentMethodID =
                            Convert.ToInt32(
                                cmbPaymentMethod.SelectedValue);


                        var result =
                            _expenseBusiness.Add(
                                newExpense,
                                paymentMethodID);


                        if (!result.Success)
                        {
                            ShowError(
                                result.Message);

                            return;
                        }


                        MessageBox.Show(
                            result.Message,
                            "المصروفات",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


                        form.DialogResult =
                            DialogResult.OK;


                        form.Close();

                        return;
                    }


                    // =================================================
                    // UPDATE
                    // =================================================

                    Expense updatedExpense =
                        new Expense
                        {
                            ExpenseID =
                                expense.ExpenseID,

                            CategoryID =
                                Convert.ToInt32(
                                    cmbCategory.SelectedValue),

                            Amount =
                                amount,

                            ExpenseDate =
                                dtpDate.Value.Date,

                            PaidBy =
                                Convert.ToInt32(
                                    cmbPaidBy.SelectedValue),

                            Notes =
                                txtNotes.Text.Trim()
                        };


                    var updateResult =
                        _expenseBusiness.Update(
                            updatedExpense);


                    if (!updateResult.Success)
                    {
                        ShowError(
                            updateResult.Message);

                        return;
                    }


                    MessageBox.Show(
                        updateResult.Message,
                        "المصروفات",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);


                    form.DialogResult =
                        DialogResult.OK;


                    form.Close();
                };


            // =====================================================
            // Add Controls
            // =====================================================

            form.Controls.Add(
                lblCategory);

            form.Controls.Add(
                cmbCategory);


            form.Controls.Add(
                lblDate);

            form.Controls.Add(
                dtpDate);


            form.Controls.Add(
                lblAmount);

            form.Controls.Add(
                txtAmount);


            form.Controls.Add(
                lblPaidBy);

            form.Controls.Add(
                cmbPaidBy);


            form.Controls.Add(
                lblPaymentMethod);

            form.Controls.Add(
                cmbPaymentMethod);


            form.Controls.Add(
                lblNotes);

            form.Controls.Add(
                txtNotes);


            form.Controls.Add(
                btnSave);


            if (form.ShowDialog(this) ==
                DialogResult.OK)
            {
                LoadExpenses();
            }
        }

        #endregion


        #region Grid Actions

        private void dgvExpenses_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (e.ColumnIndex < 0)
                return;


            if (dgvExpenses
                    .Columns[e.ColumnIndex]
                    .Name !=
                "colActions")
            {
                return;
            }


            Expense expense =
                dgvExpenses
                    .Rows[e.RowIndex]
                    .DataBoundItem
                    as Expense;


            if (expense == null)
                return;


            ShowExpenseActions(
                expense);
        }


        private void ShowExpenseActions(
            Expense expense)
        {
            using ContextMenuStrip menu =
                new ContextMenuStrip();


            ToolStripMenuItem edit =
                new ToolStripMenuItem(
                    "تعديل");


            ToolStripMenuItem delete =
                new ToolStripMenuItem(
                    "حذف");


            edit.Click +=
                (s, e) =>
                {
                    EditExpense(
                        expense);
                };


            delete.Click +=
                (s, e) =>
                {
                    DeleteExpense(
                        expense);
                };


            menu.Items.Add(
                edit);

            menu.Items.Add(
                delete);


            menu.Show(
                dgvExpenses,
                dgvExpenses.PointToClient(
                    Cursor.Position));
        }

        #endregion


        #region Delete

        private void DeleteExpense(
            Expense expense)
        {
            DialogResult result =
                MessageBox.Show(
                    $"هل أنت متأكد من حذف المصروف؟\n\n" +
                    $"التصنيف: {expense.CategoryName}\n" +
                    $"المبلغ: {expense.Amount:N2} ج\n" +
                    $"التاريخ: {expense.ExpenseDate:dd/MM/yyyy}",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);


            if (result !=
                DialogResult.Yes)
            {
                return;
            }


            var deleteResult =
                _expenseBusiness.Delete(
                    expense.ExpenseID);


            if (!deleteResult.Success)
            {
                ShowError(
                    deleteResult.Message);

                return;
            }


            MessageBox.Show(
                deleteResult.Message,
                "المصروفات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);


            LoadExpenses();
        }

        #endregion


        #region Add Category

        private void AddCategory()
        {
            using Form form =
                new Form();


            form.Text =
                "إضافة تصنيف مصروف";


            form.StartPosition =
                FormStartPosition.CenterParent;


            form.FormBorderStyle =
                FormBorderStyle.FixedDialog;


            form.MaximizeBox =
                false;

            form.MinimizeBox =
                false;


            form.Size =
                new Size(
                    420,
                    230);


            form.RightToLeft =
                RightToLeft.Yes;

            form.RightToLeftLayout =
                true;


            Label label =
                CreateLabel(
                    "اسم التصنيف");


            label.Location =
                new Point(
                    30,
                    30);


            TextBox textBox =
                CreateTextBox();


            textBox.Location =
                new Point(
                    30,
                    65);


            textBox.Width =
                340;


            Button save =
                new Button
                {
                    Text =
                        "حفظ",

                    Width =
                        100,

                    Height =
                        35,

                    Location =
                        new Point(
                            270,
                            120),

                    BackColor =
                        Color.RoyalBlue,

                    ForeColor =
                        Color.White,

                    FlatStyle =
                        FlatStyle.Flat
                };


            save.Click +=
                (s, e) =>
                {
                    var result =
                        _expenseBusiness
                            .AddCategory(
                                textBox.Text);


                    if (!result.Success)
                    {
                        ShowError(
                            result.Message);

                        return;
                    }


                    MessageBox.Show(
                        result.Message,
                        "المصروفات",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);


                    form.DialogResult =
                        DialogResult.OK;


                    form.Close();
                };


            form.Controls.Add(
                label);

            form.Controls.Add(
                textBox);

            form.Controls.Add(
                save);


            if (form.ShowDialog(this) ==
                DialogResult.OK)
            {
                LoadCategories();

                LoadExpenses();
            }
        }

        #endregion


        #region Helpers

        private Label CreateLabel(
            string text)
        {
            return new Label
            {
                Text =
                    text,

                AutoSize =
                    true,

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

                Height =
                    35,

                BorderStyle =
                    BorderStyle.FixedSingle
            };
        }


        private void ShowError(
            string message)
        {
            MessageBox.Show(
                message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }


        private void ShowWarning(
            string message)
        {
            MessageBox.Show(
                message,
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        #endregion


        #region Export

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            if (dgvExpenses.Rows.Count == 0)
            {
                ShowWarning(
                    "لا توجد بيانات للتصدير.");

                return;
            }


            clsGlobalClass
                .ExportDataGridViewToExcel(
                    dgvExpenses,
                    "",
                    "Expenses Report");
        }


        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            if (dgvExpenses.Rows.Count == 0)
            {
                ShowWarning(
                    "لا توجد بيانات للطباعة.");

                return;
            }


            clsGlobalClass.PrintDataGridView(
                dgvExpenses,
                "Expenses Report");
        }

        #endregion


        #region Existing Designer Events

        private void lblNameOfTheMonthAndYear_Click(
            object sender,
            EventArgs e)
        {
        }


        private void lblTotalExpenses_Click(
            object sender,
            EventArgs e)
        {
        }


        private void lblReleaseFees_Click(
            object sender,
            EventArgs e)
        {
        }


        private void lblElectricity_Click(
            object sender,
            EventArgs e)
        {
        }


        private void lblOtherExpenses_Click(
            object sender,
            EventArgs e)
        {
        }


        private void sabraPanel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }


        private void dtpFrom_Load(
            object sender,
            EventArgs e)
        {
        }


        private void dtpTo_Load(
            object sender,
            EventArgs e)
        {
        }

        #endregion
    }

}
