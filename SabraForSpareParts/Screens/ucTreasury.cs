using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucTreasury : SabraUserControl
    {
        private readonly List<TreasuryTransaction> _transactions =
            new List<TreasuryTransaction>();

        public ucTreasury()
        {
            InitializeComponent();

            // لو الـ events مش مربوطة من الـ Designer
            this.Load += ucTreasury_Load;
            sbtnSearch.Click += sbtnSearch_Click;
            sbtnWithdrawal.Click += sbtnWithdrawal_Click;
            sbtnDeposit.Click += sbtnDeposit_Click;
        }

        private void ucTreasury_Load(object sender, EventArgs e)
        {
            InitializeTreasury();
        }

        private void InitializeTreasury()
        {
            LoadMockData();
            SetupClassificationComboBox();
            SetupTreasuryGrid();

            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;

            LoadTreasuryData();
        }

        #region Mock Data

        private void LoadMockData()
        {
            _transactions.Clear();

            var random = new Random(12345);

            string[] descriptions =
            {
                "بيع فاتورة",
                "شراء بضاعة",
                "دفع إيجار المحل",
                "تحصيل مديونية عميل",
                "دفع فاتورة كهرباء",
                "مصاريف نقل",
                "بيع قطع غيار",
                "تحصيل نقدية",
                "شراء قطع غيار",
                "مصاريف صيانة",
                "دفع رواتب",
                "تحصيل حساب عميل",
                "مصروفات تشغيل",
                "مرتجع مشتريات",
                "مرتجع مبيعات"
            };

            string[] employees =
            {
                "أحمد محمد",
                "محمد علي",
                "محمود حسن",
                "عبدالله أحمد",
                "إبراهيم محمد",
                "خالد محمود"
            };

            DateTime startDate = DateTime.Today.AddDays(-60);

            for (int i = 1; i <= 100; i++)
            {
                DateTime date = startDate.AddDays(random.Next(0, 61));

                bool isDeposit = random.Next(0, 100) < 55;

                decimal amount;

                if (isDeposit)
                {
                    amount = random.Next(500, 15000);
                }
                else
                {
                    amount = random.Next(300, 10000);
                }

                string description;

                if (isDeposit)
                {
                    string[] deposits =
                    {
                        "بيع فاتورة",
                        "تحصيل مديونية عميل",
                        "بيع قطع غيار",
                        "تحصيل نقدية",
                        "تحصيل حساب عميل",
                        "مرتجع مشتريات"
                    };

                    description = deposits[random.Next(deposits.Length)];
                }
                else
                {
                    string[] withdrawals =
                    {
                        "شراء بضاعة",
                        "دفع إيجار المحل",
                        "دفع فاتورة كهرباء",
                        "مصاريف نقل",
                        "شراء قطع غيار",
                        "مصاريف صيانة",
                        "دفع رواتب",
                        "مصروفات تشغيل",
                        "مرتجع مبيعات"
                    };

                    description = withdrawals[random.Next(withdrawals.Length)];
                }

                _transactions.Add(new TreasuryTransaction
                {
                    Id = i,
                    Date = date,
                    Type = isDeposit ? TreasuryType.Deposit : TreasuryType.Withdrawal,
                    Description = description,
                    Amount = amount,
                    Employee = employees[random.Next(employees.Length)],
                    Reference = $"TR-{1000 + i}"
                });
            }

            // بيانات ثابتة عشان نضمن أرقام واضحة في التجربة
            _transactions.Add(new TreasuryTransaction
            {
                Id = 101,
                Date = DateTime.Today,
                Type = TreasuryType.Deposit,
                Description = "بيع فاتورة",
                Amount = 12000,
                Employee = "أحمد محمد",
                Reference = "INV-1084"
            });

            _transactions.Add(new TreasuryTransaction
            {
                Id = 102,
                Date = DateTime.Today,
                Type = TreasuryType.Withdrawal,
                Description = "شراء بضاعة",
                Amount = 7500,
                Employee = "محمود حسن",
                Reference = "PUR-542"
            });

            _transactions.Add(new TreasuryTransaction
            {
                Id = 103,
                Date = DateTime.Today,
                Type = TreasuryType.Deposit,
                Description = "تحصيل مديونية عميل",
                Amount = 8500,
                Employee = "محمد علي",
                Reference = "REC-321"
            });

            _transactions.Add(new TreasuryTransaction
            {
                Id = 104,
                Date = DateTime.Today,
                Type = TreasuryType.Withdrawal,
                Description = "دفع إيجار المحل",
                Amount = 4000,
                Employee = "عبدالله أحمد",
                Reference = "EXP-102"
            });
        }

        #endregion

        #region ComboBox

        private void SetupClassificationComboBox()
        {
            smbxClassification.Items.Clear();

            smbxClassification.Items.Add("كل الحركات");
            smbxClassification.Items.Add("إيداع");
            smbxClassification.Items.Add("سحب");

            smbxClassification.SelectedIndex = 0;
        }

        #endregion

        #region DataGridView

        private void SetupTreasuryGrid()
        {
            dgvTreasury.AutoGenerateColumns = false;
            dgvTreasury.Columns.Clear();

            dgvTreasury.RightToLeft = RightToLeft.Yes;

            dgvTreasury.AllowUserToAddRows = false;
            dgvTreasury.AllowUserToDeleteRows = false;
            dgvTreasury.ReadOnly = true;

            dgvTreasury.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTreasury.MultiSelect = false;

            dgvTreasury.RowHeadersVisible = false;

            dgvTreasury.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvTreasury.ColumnHeadersHeight = 45;
            dgvTreasury.RowTemplate.Height = 42;

            AddColumn(
                "colId",
                "م",
                "Id"
            );

            AddColumn(
                "colReference",
                "المرجع",
                "Reference"
            );

            AddColumn(
                "colDate",
                "التاريخ",
                "Date",
                "dd/MM/yyyy"
            );

            AddColumn(
                "colDescription",
                "البيان",
                "Description"
            );

            AddColumn(
                "colType",
                "نوع الحركة",
                "TypeText"
            );

            AddColumn(
                "colAmount",
                "المبلغ",
                "Amount",
                "N2"
            );

            AddColumn(
                "colEmployee",
                "الموظف المسؤول",
                "Employee"
            );
        }

        private void AddColumn(
            string name,
            string headerText,
            string dataProperty,
            string format = null)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn();

            column.Name = name;
            column.HeaderText = headerText;
            column.DataPropertyName = dataProperty;

            if (!string.IsNullOrEmpty(format))
                column.DefaultCellStyle.Format = format;

            column.SortMode =
                DataGridViewColumnSortMode.NotSortable;

            dgvTreasury.Columns.Add(column);
        }

        #endregion

        #region Load Data

        private void LoadTreasuryData()
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date.AddDays(1).AddTicks(-1);

            string classification =
                smbxClassification.SelectedItem?.ToString()
                ?? "كل الحركات";

            IEnumerable<TreasuryTransaction> query =
                _transactions.Where(x =>
                    x.Date >= fromDate &&
                    x.Date <= toDate);

            if (classification == "إيداع")
            {
                query = query.Where(x =>
                    x.Type == TreasuryType.Deposit);
            }
            else if (classification == "سحب")
            {
                query = query.Where(x =>
                    x.Type == TreasuryType.Withdrawal);
            }

            List<TreasuryTransaction> result =
                query
                .OrderByDescending(x => x.Date)
                .ThenByDescending(x => x.Id)
                .ToList();

            dgvTreasury.DataSource = null;
            dgvTreasury.DataSource = result;

            CalculateTreasurySummary(result);
        }

        #endregion

        #region Summary

        private void CalculateTreasurySummary(
            List<TreasuryTransaction> transactions)
        {
            decimal deposits =
                transactions
                    .Where(x => x.Type == TreasuryType.Deposit)
                    .Sum(x => x.Amount);

            decimal withdrawals =
                transactions
                    .Where(x => x.Type == TreasuryType.Withdrawal)
                    .Sum(x => x.Amount);

            decimal netBalance =
                deposits - withdrawals;

            // الرصيد السابق للحركات المعروضة
            DateTime fromDate = dtpFrom.Value.Date;

            decimal previousBalance =
                _transactions
                    .Where(x => x.Date < fromDate)
                    .Sum(x =>
                        x.Type == TreasuryType.Deposit
                            ? x.Amount
                            : -x.Amount);

            decimal treasuryBalance =
                previousBalance + netBalance;

            lblTotalDeposits.Text =
                deposits.ToString("N2") + " ج";

            TotalWithdrawals.Text =
                withdrawals.ToString("N2") + " ج";

            lblNetBalance.Text =
                netBalance.ToString("N2") + " ج";

            lblTreasuryBalance.Text =
                treasuryBalance.ToString("N2") + " ج";
        }

        #endregion

        #region Search

        private void sbtnSearch_Click(object sender, EventArgs e)
        {
            LoadTreasuryData();
        }

        private void smbxClassification_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            // فلترة مباشرة عند تغيير النوع
            if (IsHandleCreated)
                LoadTreasuryData();
        }

        #endregion

        #region Deposit

        private void sbtnDeposit_Click(object sender, EventArgs e)
        {
            AddMockTransaction(
                TreasuryType.Deposit,
                "إيداع نقدية",
                5000,
                "DEP-" + DateTime.Now.ToString("HHmmss")
            );

            LoadTreasuryData();

            MessageBox.Show(
                "تم تسجيل الإيداع بنجاح",
                "الخزانة",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

        #region Withdrawal

        private void sbtnWithdrawal_Click(object sender, EventArgs e)
        {
            AddMockTransaction(
                TreasuryType.Withdrawal,
                "سحب نقدية",
                2500,
                "WIT-" + DateTime.Now.ToString("HHmmss")
            );

            LoadTreasuryData();

            MessageBox.Show(
                "تم تسجيل السحب بنجاح",
                "الخزانة",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

        #region Add Transaction

        private void AddMockTransaction(
            TreasuryType type,
            string description,
            decimal amount,
            string reference)
        {
            int newId =
                _transactions.Any()
                    ? _transactions.Max(x => x.Id) + 1
                    : 1;

            _transactions.Add(new TreasuryTransaction
            {
                Id = newId,
                Date = DateTime.Now,
                Type = type,
                Description = description,
                Amount = amount,
                Employee = "المستخدم الحالي",
                Reference = reference
            });
        }

        #endregion

        #region Events

        private void sabraPanel2_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void dgvTreasury_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void dtpTo_Load(
            object sender,
            EventArgs e)
        {
        }

        private void dtpFrom_Load(
            object sender,
            EventArgs e)
        {
        }

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(
                dgvTreasury,
                "Treasury Report"
            );
        }

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            clsGlobalClass.ExportDataGridViewToExcel(
                dgvTreasury,
                "",
                "Treasury Report"
            );
        }

        private void lblTreasuryBalance_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTotalDeposits_Click(
            object sender,
            EventArgs e)
        {
        }

        private void TotalWithdrawals_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblNetBalance_Click(
            object sender,
            EventArgs e)
        {
        }

        #endregion
    }

    #region Treasury Transaction

    public class TreasuryTransaction
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public TreasuryType Type { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public string Employee { get; set; }

        public string Reference { get; set; }

        public string TypeText
        {
            get
            {
                return Type == TreasuryType.Deposit
                    ? "إيداع"
                    : "سحب";
            }
        }
    }

    public enum TreasuryType
    {
        Deposit,
        Withdrawal
    }

    #endregion
}