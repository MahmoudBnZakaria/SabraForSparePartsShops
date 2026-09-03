using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucExpenses : SabraUserControl
    {
        private readonly List<Expense> _expenses = new List<Expense>();

        public ucExpenses()
        {
            InitializeComponent();

            Load += ucExpenses_Load;
            btnSearch.Click += btnSearch_Click;
            smbxPeriod.SelectedIndexChanged += smbxPeriod_SelectedIndexChanged;
            cmbClassification.SelectedIndexChanged += cmbClassification_SelectedIndexChanged;
        }

        private void ucExpenses_Load(object sender, EventArgs e)
        {
            SetupExpenseScreen();
        }

        #region Setup

        private void SetupExpenseScreen()
        {
            LoadMockData();
            SetupFilters();
            SetupGrid();

            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;

            smbxPeriod.SelectedIndex = 0;
            cmbClassification.SelectedIndex = 0;

            LoadExpenses();
        }

        #endregion

        #region Mock Data

        private void LoadMockData()
        {
            _expenses.Clear();

            string[] employees =
            {
                "أحمد محمد",
                "سارة أحمد",
                "محمود حسن",
                "محمد علي",
                "عبدالله محمد",
                "إبراهيم أحمد",
                "خالد حسن",
                "مصطفى محمود"
            };

            string[] paymentMethods =
            {
                "كاش",
                "تحويل",
                "بطاقة"
            };

            var random = new Random(2025);

            DateTime startDate = DateTime.Today.AddDays(-60);

            for (int i = 1; i <= 100; i++)
            {
                DateTime date =
                    startDate.AddDays(random.Next(0, 61));

                int type = random.Next(0, 5);

                string classification;
                string notes;

                switch (type)
                {
                    case 0:
                        classification = "كهرباء";
                        notes = "فاتورة كهرباء شهرية";
                        break;

                    case 1:
                        classification = "إيجار";
                        notes = "إيجار المحل";
                        break;

                    case 2:
                        classification = "مستلزمات";
                        notes = "شراء مستلزمات للمحل";
                        break;

                    case 3:
                        classification = "نقل وشحن";
                        notes = "شحن بضاعة من المورد";
                        break;

                    default:
                        classification = "أخرى";
                        notes = "مصروفات تشغيلية";
                        break;
                }

                decimal amount;

                switch (classification)
                {
                    case "كهرباء":
                        amount = random.Next(500, 2501);
                        break;

                    case "إيجار":
                        amount = random.Next(2500, 6001);
                        break;

                    case "مستلزمات":
                        amount = random.Next(150, 1501);
                        break;

                    case "نقل وشحن":
                        amount = random.Next(100, 1201);
                        break;

                    default:
                        amount = random.Next(100, 2001);
                        break;
                }

                _expenses.Add(new Expense
                {
                    Id = i,
                    Date = date,
                    Classification = classification,
                    Amount = amount,
                    PaidBy = employees[random.Next(employees.Length)],
                    PaymentMethod = paymentMethods[
                        random.Next(paymentMethods.Length)
                    ],
                    Notes = notes
                });
            }

            // بيانات واضحة وثابتة للتجربة

            _expenses.Add(new Expense
            {
                Id = 101,
                Date = new DateTime(2025, 1, 15),
                Classification = "كهرباء",
                Amount = 850,
                PaidBy = "أحمد محمد",
                PaymentMethod = "كاش",
                Notes = "فاتورة كهرباء يناير"
            });

            _expenses.Add(new Expense
            {
                Id = 102,
                Date = new DateTime(2025, 1, 1),
                Classification = "إيجار",
                Amount = 3500,
                PaidBy = "أحمد محمد",
                PaymentMethod = "تحويل",
                Notes = "إيجار يناير 2025"
            });

            _expenses.Add(new Expense
            {
                Id = 103,
                Date = new DateTime(2025, 1, 5),
                Classification = "مستلزمات",
                Amount = 450,
                PaidBy = "سارة أحمد",
                PaymentMethod = "كاش",
                Notes = "أوراق طباعة وأقلام"
            });

            _expenses.Add(new Expense
            {
                Id = 104,
                Date = new DateTime(2025, 1, 8),
                Classification = "نقل وشحن",
                Amount = 600,
                PaidBy = "أحمد محمد",
                PaymentMethod = "كاش",
                Notes = "شحن من المورد"
            });

            _expenses.Add(new Expense
            {
                Id = 105,
                Date = new DateTime(2025, 1, 10),
                Classification = "أخرى",
                Amount = 750,
                PaidBy = "محمود حسن",
                PaymentMethod = "بطاقة",
                Notes = "مصاريف تشغيل"
            });
        }

        #endregion

        #region Filters

        private void SetupFilters()
        {
            smbxPeriod.Items.Clear();

            smbxPeriod.Items.Add("كل الفترات");
            smbxPeriod.Items.Add("اليوم");
            smbxPeriod.Items.Add("هذا الأسبوع");
            smbxPeriod.Items.Add("هذا الشهر");

            cmbClassification.Items.Clear();

            cmbClassification.Items.Add("كل التصنيفات");
            cmbClassification.Items.Add("إيجار");
            cmbClassification.Items.Add("كهرباء");
            cmbClassification.Items.Add("مستلزمات");
            cmbClassification.Items.Add("نقل وشحن");
            cmbClassification.Items.Add("أخرى");
        }

        private void ApplyPeriodFilter()
        {
            string period =
                smbxPeriod.SelectedItem?.ToString();

            if (period == null)
                return;

            DateTime today = DateTime.Today;

            switch (period)
            {
                case "اليوم":
                    dtpFrom.Value = today;
                    dtpTo.Value = today;
                    break;

                case "هذا الأسبوع":

                    int difference =
                        (7 + (today.DayOfWeek - DayOfWeek.Saturday)) % 7;

                    DateTime startOfWeek =
                        today.AddDays(-difference);

                    dtpFrom.Value = startOfWeek;
                    dtpTo.Value = today;

                    break;

                case "هذا الشهر":

                    dtpFrom.Value =
                        new DateTime(
                            today.Year,
                            today.Month,
                            1
                        );

                    dtpTo.Value = today;

                    break;
            }

            LoadExpenses();
        }

        #endregion

        #region DataGridView

        private void SetupGrid()
        {
            dgvExpenses.AutoGenerateColumns = false;
            dgvExpenses.Columns.Clear();

            dgvExpenses.RightToLeft = RightToLeft.Yes;

            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AllowUserToDeleteRows = false;

            dgvExpenses.ReadOnly = true;

            dgvExpenses.RowHeadersVisible = false;

            dgvExpenses.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvExpenses.MultiSelect = false;

            dgvExpenses.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvExpenses.ColumnHeadersHeight = 45;
            dgvExpenses.RowTemplate.Height = 48;

            dgvExpenses.EnableHeadersVisualStyles = false;

            dgvExpenses.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvExpenses.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvExpenses.DefaultCellStyle.Font =
                new Font("Cairo", 10F);

            dgvExpenses.ColumnHeadersDefaultCellStyle.Font =
                new Font("Cairo", 10F, FontStyle.Bold);

            // التاريخ

            AddTextColumn(
                "colDate",
                "التاريخ",
                "Date",
                "dd/MM/yyyy"
            );

            // التصنيف

            AddTextColumn(
                "colClassification",
                "التصنيف",
                "Classification"
            );

            // المبلغ

            AddTextColumn(
                "colAmount",
                "المبلغ",
                "Amount",
                "N2"
            );

            // دفع بواسطة

            AddTextColumn(
                "colPaidBy",
                "دفع بواسطة",
                "PaidBy"
            );

            // طريقة الدفع

            AddTextColumn(
                "colPaymentMethod",
                "طريقة الدفع",
                "PaymentMethod"
            );

            // ملاحظات

            AddTextColumn(
                "colNotes",
                "ملاحظات",
                "Notes"
            );

            // الإجراءات

            DataGridViewTextBoxColumn actions =
                new DataGridViewTextBoxColumn();

            actions.Name = "colActions";
            actions.HeaderText = "الإجراءات";
            actions.ReadOnly = true;
            actions.FillWeight = 100;

            dgvExpenses.Columns.Add(actions);
        }

        private void AddTextColumn(
            string name,
            string header,
            string property,
            string format = null)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn();

            column.Name = name;
            column.HeaderText = header;
            column.DataPropertyName = property;
            column.SortMode =
                DataGridViewColumnSortMode.NotSortable;

            if (!string.IsNullOrEmpty(format))
                column.DefaultCellStyle.Format = format;

            dgvExpenses.Columns.Add(column);
        }

        #endregion

        #region Load Expenses

        private void LoadExpenses()
        {
            DateTime from =
                dtpFrom.Value.Date;

            DateTime to =
                dtpTo.Value.Date.AddDays(1).AddTicks(-1);

            string classification =
                cmbClassification.SelectedItem?.ToString()
                ?? "كل التصنيفات";

            IEnumerable<Expense> query =
                _expenses.Where(x =>
                    x.Date >= from &&
                    x.Date <= to
                );

            if (classification != "كل التصنيفات")
            {
                query = query.Where(x =>
                    x.Classification == classification
                );
            }

            List<Expense> result =
                query
                    .OrderByDescending(x => x.Date)
                    .ThenByDescending(x => x.Id)
                    .ToList();

            dgvExpenses.DataSource = null;
            dgvExpenses.DataSource = result;

            UpdateSummary(result);
        }

        #endregion

        #region Summary

        private void UpdateSummary(List<Expense> expenses)
        {
            decimal total =
                expenses.Sum(x => x.Amount);

            decimal releaseFees =
                expenses
                    .Where(x => x.Classification == "إيجار")
                    .Sum(x => x.Amount);

            decimal electricity =
                expenses
                    .Where(x => x.Classification == "كهرباء")
                    .Sum(x => x.Amount);

            decimal other =
                expenses
                    .Where(x =>
                        x.Classification != "إيجار" &&
                        x.Classification != "كهرباء")
                    .Sum(x => x.Amount);

            lblTotalExpenses.Text =
                total.ToString("N2") + " ج";

            lblReleaseFees.Text =
                releaseFees.ToString("N2") + " ج";

            lblElectricity.Text =
                electricity.ToString("N2") + " ج";

            lblOtherExpenses.Text =
                other.ToString("N2") + " ج";

            lblNameOfTheMonthAndYear.Text =
                GetPeriodTitle();
        }

        private string GetPeriodTitle()
        {
            string period =
                smbxPeriod.SelectedItem?.ToString();

            if (period == "اليوم")
                return DateTime.Today.ToString("dd/MM/yyyy");

            if (period == "هذا الشهر")
                return DateTime.Today.ToString("MMMM yyyy");

            if (period == "هذا الأسبوع")
                return "هذا الأسبوع";

            return
                dtpFrom.Value.ToString("dd/MM/yyyy")
                + " - "
                + dtpTo.Value.ToString("dd/MM/yyyy");
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
                LoadExpenses();
        }

        #endregion

        #region Add Expense

        private void sbtnAddNewExpense_Click(
            object sender,
            EventArgs e)
        {
            int newId =
                _expenses.Any()
                    ? _expenses.Max(x => x.Id) + 1
                    : 1;

            _expenses.Add(new Expense
            {
                Id = newId,
                Date = DateTime.Today,
                Classification = "أخرى",
                Amount = 500,
                PaidBy = "المستخدم الحالي",
                PaymentMethod = "كاش",
                Notes = "مصروف تجريبي جديد"
            });

            LoadExpenses();

            MessageBox.Show(
                "تم إضافة المصروف بنجاح",
                "المصروفات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
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

            if (dgvExpenses.Columns[e.ColumnIndex].Name
                != "colActions")
                return;

            Expense expense =
                dgvExpenses.Rows[e.RowIndex].DataBoundItem
                as Expense;

            if (expense == null)
                return;

            ShowExpenseActions(expense);
        }

        private void ShowExpenseActions(Expense expense)
        {
            ContextMenuStrip menu =
                new ContextMenuStrip();

            ToolStripMenuItem edit =
                new ToolStripMenuItem("تعديل");

            ToolStripMenuItem delete =
                new ToolStripMenuItem("حذف");

            edit.Click += (s, e) =>
            {
                MessageBox.Show(
                    "تعديل المصروف رقم " + expense.Id,
                    "تعديل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            };

            delete.Click += (s, e) =>
            {
                DialogResult result =
                    MessageBox.Show(
                        "هل أنت متأكد من حذف هذا المصروف؟",
                        "تأكيد الحذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                if (result == DialogResult.Yes)
                {
                    _expenses.Remove(expense);
                    LoadExpenses();
                }
            };

            menu.Items.Add(edit);
            menu.Items.Add(delete);

            menu.Show(
                dgvExpenses,
                dgvExpenses.PointToClient(
                    Cursor.Position
                )
            );
        }

        #endregion

        #region Export & Print

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            clsGlobalClass.ExportDataGridViewToExcel(
                dgvExpenses,
                "",
                "Expenses Report"
            );
        }

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(
                dgvExpenses,
                "Expenses Report"
            );
        }

        #endregion

        #region Empty Events

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

    #region Expense Model

    public class Expense
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Classification { get; set; }

        public decimal Amount { get; set; }

        public string PaidBy { get; set; }

        public string PaymentMethod { get; set; }

        public string Notes { get; set; }
    }

    #endregion
}