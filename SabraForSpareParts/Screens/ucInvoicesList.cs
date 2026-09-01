using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucInvoicesList : SabraUserControl
    {
        #region Models & Enums

        private enum InvoicePaymentStatus
        {
            Paid,       // مسدد بالكامل
            Partial,    // مدفوع جزئي
            Deferred    // آجل
        }

        private enum PeriodFilter
        {
            All = 0,
            Today = 1,
            ThisWeek = 2,
            ThisMonth = 3
        }

        private class InvoiceModel
        {
            public string InvoiceNumber { get; set; }
            public DateTime Date { get; set; }
            public string CustomerName { get; set; }
            public string EmployeeName { get; set; }
            public decimal NetAmount { get; set; }
            public decimal PaidAmount { get; set; }
            public decimal RemainingAmount => NetAmount - PaidAmount;
            public InvoicePaymentStatus Status { get; set; }
        }

        #endregion

        #region Fields

        // بيانات وهمية (Mock Data) - في المشروع الحقيقي هتيجي من طبقة البيانات / قاعدة البيانات
        private List<InvoiceModel> _allInvoices;

        // إجماليات الكروت العلوية (KPI Cards) - وهمية زي ما هي في التصميم، أصلها استعلام تجميعي على كل الفواتير
        private const decimal MockOutstandingDebts = 123340m;   // المديونيات
        private const decimal MockCollected = 723890m;          // المحصل
        private const decimal MockTotalSales = 847230m;         // إجمالي المبيعات
        private const int MockTotalInvoicesCount = 1084;        // إجمالي الفواتير

        // أسماء أعمدة الأزرار في الجدول
        private const string ColView = "colView";
        private const string ColPrint = "colPrint";
        private const string ColAction = "colAction"; // دفعة أو مرتجع حسب حالة الفاتورة

        // عشان منمنعش الفلاتر إنها تشتغل قبل ما التحميل الأولي يخلص
        private bool _isInitialized = false;

        #endregion

        public ucInvoicesList()
        {
            InitializeComponent();
            this.Load += ucInvoicesList_Load;
        }

        private void ucInvoicesList_Load(object sender, EventArgs e)
        {
            LoadMockData();
            SetupGridColumns();
            SetupDatePickers();
            SetupFilters();

            BindGrid(_allInvoices);
            UpdateSummaryCards();

            _isInitialized = true;
        }

        #region Mock Data

        private void LoadMockData()
        {
            _allInvoices = new List<InvoiceModel>
            {
                new InvoiceModel
                {
                    InvoiceNumber = "INV-1084",
                    Date = new DateTime(2025, 1, 15, 11, 23, 0),
                    CustomerName = "ورشة النيل",
                    EmployeeName = "أحمد",
                    NetAmount = 3200,
                    PaidAmount = 3200,
                    Status = InvoicePaymentStatus.Paid
                },
                new InvoiceModel
                {
                    InvoiceNumber = "INV-1083",
                    Date = new DateTime(2025, 1, 15, 10, 5, 0),
                    CustomerName = "محمد علي",
                    EmployeeName = "سارة",
                    NetAmount = 850,
                    PaidAmount = 500,
                    Status = InvoicePaymentStatus.Partial
                },
                new InvoiceModel
                {
                    InvoiceNumber = "INV-1082",
                    Date = new DateTime(2025, 1, 15, 9, 30, 0),
                    CustomerName = "عميل نقدي",
                    EmployeeName = "أحمد",
                    NetAmount = 1450,
                    PaidAmount = 1450,
                    Status = InvoicePaymentStatus.Paid
                },
                new InvoiceModel
                {
                    InvoiceNumber = "INV-1081",
                    Date = new DateTime(2025, 1, 14, 16, 45, 0),
                    CustomerName = "ورشة الأمل",
                    EmployeeName = "سارة",
                    NetAmount = 7600,
                    PaidAmount = 0,
                    Status = InvoicePaymentStatus.Deferred
                },
                new InvoiceModel
                {
                    InvoiceNumber = "INV-1079",
                    Date = new DateTime(2025, 1, 14, 11, 22, 0),
                    CustomerName = "مؤسسة الجوهرة",
                    EmployeeName = "سارة",
                    NetAmount = 15800,
                    PaidAmount = 10000,
                    Status = InvoicePaymentStatus.Partial
                },

                // فواتير إضافية بتواريخ قريبة من دلوقتي عشان فلاتر "اليوم / هذا الأسبوع / هذا الشهر" يكون ليها معنى فعلي
                new InvoiceModel
                {
                    InvoiceNumber = "INV-1078",
                    Date = DateTime.Now.AddDays(-2),
                    CustomerName = "عميل نقدي",
                    EmployeeName = "أحمد",
                    NetAmount = 640,
                    PaidAmount = 640,
                    Status = InvoicePaymentStatus.Paid
                },
                new InvoiceModel
                {
                    InvoiceNumber = "INV-1077",
                    Date = DateTime.Now.AddDays(-10),
                    CustomerName = "ورشة السلام",
                    EmployeeName = "سارة",
                    NetAmount = 2300,
                    PaidAmount = 1000,
                    Status = InvoicePaymentStatus.Partial
                },
                new InvoiceModel
                {
                    InvoiceNumber = "INV-1076",
                    Date = DateTime.Now,
                    CustomerName = "محمود سعيد",
                    EmployeeName = "أحمد",
                    NetAmount = 990,
                    PaidAmount = 990,
                    Status = InvoicePaymentStatus.Paid
                }
            };
        }

        #endregion

        #region Grid Setup

        private void SetupGridColumns()
        {
            dgvInvoicesList.Columns.Clear();
            dgvInvoicesList.AutoGenerateColumns = false;
            dgvInvoicesList.RightToLeft = RightToLeft.Yes;
            dgvInvoicesList.AllowUserToAddRows = false;
            dgvInvoicesList.AllowUserToDeleteRows = false;
            dgvInvoicesList.ReadOnly = true;
            dgvInvoicesList.RowHeadersVisible = false;
            dgvInvoicesList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoicesList.MultiSelect = false;
            dgvInvoicesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvInvoicesList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colInvoiceNumber",
                HeaderText = "رقم الفاتورة"
            });
            dgvInvoicesList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "التاريخ"
            });
            dgvInvoicesList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCustomer",
                HeaderText = "العميل"
            });
            dgvInvoicesList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmployee",
                HeaderText = "الموظف"
            });
            dgvInvoicesList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNet",
                HeaderText = "الصافي"
            });
            dgvInvoicesList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPaid",
                HeaderText = "المدفوع"
            });
            dgvInvoicesList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRemaining",
                HeaderText = "المتبقي"
            });
            dgvInvoicesList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "الحالة"
            });
            dgvInvoicesList.Columns.Add(new DataGridViewButtonColumn
            {
                Name = ColView,
                HeaderText = "",
                Text = "عرض",
                UseColumnTextForButtonValue = true
            });
            dgvInvoicesList.Columns.Add(new DataGridViewButtonColumn
            {
                Name = ColPrint,
                HeaderText = "",
                Text = "طباعة",
                UseColumnTextForButtonValue = true
            });
            dgvInvoicesList.Columns.Add(new DataGridViewButtonColumn
            {
                Name = ColAction,
                HeaderText = "الإجراءات",
                UseColumnTextForButtonValue = false // النص هيتحدد لكل صف حسب حالته (دفعة / مرتجع)
            });

            dgvInvoicesList.CellFormatting += DgvInvoicesList_CellFormatting;
        }

        private void DgvInvoicesList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInvoicesList.Columns[e.ColumnIndex].Name != "colStatus") return;
            if (e.Value == null) return;

            var text = e.Value.ToString();
            if (text == "مسدد")
                e.CellStyle.ForeColor = Color.FromArgb(46, 125, 50);   // أخضر
            else if (text == "جزئي")
                e.CellStyle.ForeColor = Color.FromArgb(237, 108, 2);   // برتقالي
            else if (text == "آجل")
                e.CellStyle.ForeColor = Color.FromArgb(211, 47, 47);   // أحمر

            e.CellStyle.Font = new Font(dgvInvoicesList.Font, FontStyle.Bold);
        }

        private void BindGrid(List<InvoiceModel> invoices)
        {
            dgvInvoicesList.Rows.Clear();

            foreach (var inv in invoices.OrderByDescending(i => i.Date))
            {
                int rowIndex = dgvInvoicesList.Rows.Add();
                var row = dgvInvoicesList.Rows[rowIndex];

                row.Cells["colInvoiceNumber"].Value = inv.InvoiceNumber;
                row.Cells["colDate"].Value = inv.Date.ToString("HH:mm dd/M/yyyy", CultureInfo.InvariantCulture);
                row.Cells["colCustomer"].Value = inv.CustomerName;
                row.Cells["colEmployee"].Value = inv.EmployeeName;
                row.Cells["colNet"].Value = inv.NetAmount.ToString("N0", CultureInfo.InvariantCulture) + " ج";
                row.Cells["colPaid"].Value = inv.PaidAmount.ToString("N0", CultureInfo.InvariantCulture) + " ج";
                row.Cells["colRemaining"].Value = inv.RemainingAmount > 0
                    ? inv.RemainingAmount.ToString("N0", CultureInfo.InvariantCulture) + " ج"
                    : "0";
                row.Cells["colStatus"].Value = GetStatusText(inv.Status);
                row.Cells[ColAction].Value = inv.Status == InvoicePaymentStatus.Paid ? "مرتجع" : "+ دفعة";

                row.Tag = inv; // نربط الصف بالكائن الأصلي عشان نستخدمه في أحداث أزرار الإجراءات
            }
        }

        private string GetStatusText(InvoicePaymentStatus status)
        {
            switch (status)
            {
                case InvoicePaymentStatus.Paid: return "مسدد";
                case InvoicePaymentStatus.Partial: return "جزئي";
                case InvoicePaymentStatus.Deferred: return "آجل";
                default: return "";
            }
        }

        #endregion

        #region Filters Setup

        private void SetupFilters()
        {
            smbxPeriod.Items.Clear();
            smbxPeriod.Items.AddRange(new object[]
            {
                "كل الفترات",
                "اليوم",
                "هذا الإسبوع",
                "هذا الشهر"
            });
            smbxPeriod.SelectedIndex = 0;

            cmbPaymentStatus.Items.Clear();
            cmbPaymentStatus.Items.AddRange(new object[]
            {
                "كل الحالات",
                "مدفوع بالكامل",
                "مدفوع جزئي",
                "آجل"
            });
            cmbPaymentStatus.SelectedIndex = 0;
        }

        private void SetupDatePickers()
        {
            // افتراضيًا بنعرض آخر سنة كاملة عشان نضمن ظهور كل بيانات الـ Mock
            dtpFrom.Value = DateTime.Now.AddYears(-1);
            dtpTo.Value = DateTime.Now;
        }

        #endregion

        #region Filtering Logic

        private void ApplyFilters()
        {
            if (!_isInitialized || _allInvoices == null) return;

            IEnumerable<InvoiceModel> query = _allInvoices;

            // فلترة النص (رقم فاتورة أو اسم عميل)
            var searchText = stxbxInvoiceNumber.Text != null ? stxbxInvoiceNumber.Text.Trim() : string.Empty;
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(i =>
                    i.InvoiceNumber.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    i.CustomerName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // فلترة المدى الزمني (بيتحدد تلقائيًا من اختيار "الفترة" أو يدويًا من التقويمين)
            var fromDate = dtpFrom.Value.Date;
            var toDate = dtpTo.Value.Date;
            query = query.Where(i => i.Date.Date >= fromDate && i.Date.Date <= toDate);

            // فلترة الحالة
            var statusIndex = cmbPaymentStatus.SelectedIndex;
            if (statusIndex > 0)
            {
                InvoicePaymentStatus selectedStatus;
                switch (statusIndex)
                {
                    case 1: selectedStatus = InvoicePaymentStatus.Paid; break;
                    case 2: selectedStatus = InvoicePaymentStatus.Partial; break;
                    case 3: selectedStatus = InvoicePaymentStatus.Deferred; break;
                    default: selectedStatus = InvoicePaymentStatus.Paid; break;
                }
                query = query.Where(i => i.Status == selectedStatus);
            }

            BindGrid(query.ToList());
        }

        private void ApplyPeriodToDatePickers(PeriodFilter period)
        {
            var today = DateTime.Now.Date;
            switch (period)
            {
                case PeriodFilter.Today:
                    dtpFrom.Value = today;
                    dtpTo.Value = today;
                    break;
                case PeriodFilter.ThisWeek:
                    var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
                    dtpFrom.Value = startOfWeek;
                    dtpTo.Value = today;
                    break;
                case PeriodFilter.ThisMonth:
                    dtpFrom.Value = new DateTime(today.Year, today.Month, 1);
                    dtpTo.Value = today;
                    break;
                case PeriodFilter.All:
                default:
                    dtpFrom.Value = DateTime.Now.AddYears(-1);
                    dtpTo.Value = today;
                    break;
            }
        }

        #endregion

        #region Summary Cards

        private void UpdateSummaryCards()
        {
            // القيم دي بتيجي من استعلام تجميعي على كل الفواتير في قاعدة البيانات
            // هنا محطوطة Mock ثابت مطابق للتصميم
            lblOutstandingDebts.Text = MockOutstandingDebts.ToString("N0", CultureInfo.InvariantCulture);
            lblCollected.Text = MockCollected.ToString("N0", CultureInfo.InvariantCulture);
            lblTotalSales.Text = MockTotalSales.ToString("N0", CultureInfo.InvariantCulture);
            lblTotalInvoice.Text = MockTotalInvoicesCount.ToString("N0", CultureInfo.InvariantCulture);
        }

        #endregion

        #region Event Handlers

        private void lblNumberOfInvoices_Click(object sender, EventArgs e)
        {
        }

        private void sbtnPrint_Click(object sender, EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(
                dgvInvoicesList,
                "قائمة الفواتير");
        }

        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            clsGlobalClass.ExportDataGridViewToExcel(
                dgvInvoicesList,
                "InvoicesList",
                "قائمة الفواتير");
        }

        private void sbtnAddNewInvoice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هيتم فتح شاشة إضافة فاتورة جديدة", "إضافة فاتورة",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // الضغط على كارت "المديونيات" -> يفلتر على الفواتير الآجلة
        private void lblOutstandingDebts_Click(object sender, EventArgs e)
        {
            cmbPaymentStatus.SelectedIndex = 3; // آجل
        }

        // الضغط على كارت "المحصل" -> يفلتر على الفواتير المدفوعة بالكامل
        private void lblCollected_Click(object sender, EventArgs e)
        {
            cmbPaymentStatus.SelectedIndex = 1; // مدفوع بالكامل
        }

        // الضغط على كارت "إجمالي المبيعات" -> يرجّع كل الفلاتر لوضعها الافتراضي
        private void lblTotalSales_Click(object sender, EventArgs e)
        {
            cmbPaymentStatus.SelectedIndex = 0;
            smbxPeriod.SelectedIndex = 0;
        }

        // الضغط على كارت "إجمالي الفواتير" -> يعرض كل الفواتير من غير أي فلتر
        private void lblTotalInvoice_Click(object sender, EventArgs e)
        {
            stxbxInvoiceNumber.Text = string.Empty;
            cmbPaymentStatus.SelectedIndex = 0;
            smbxPeriod.SelectedIndex = 0;
            ApplyFilters();
        }

        private void stxbxInvoiceNumber_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void smbxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isInitialized) return;

            var period = (PeriodFilter)smbxPeriod.SelectedIndex;
            ApplyPeriodToDatePickers(period);
            ApplyFilters();
        }

        private void dtpFrom_Load(object sender, EventArgs e)
        {
        }

        private void dtpTo_Load(object sender, EventArgs e)
        {
        }

        private void cmbPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dgvInvoicesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvInvoicesList.Rows[e.RowIndex];
            var invoice = row.Tag as InvoiceModel;
            if (invoice == null) return;

            var columnName = dgvInvoicesList.Columns[e.ColumnIndex].Name;

            if (columnName == ColView)
            {
                MessageBox.Show("عرض تفاصيل الفاتورة رقم " + invoice.InvoiceNumber, "عرض فاتورة",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (columnName == ColPrint)
            {
                MessageBox.Show("جاري طباعة الفاتورة رقم " + invoice.InvoiceNumber, "طباعة فاتورة",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (columnName == ColAction)
            {
                if (invoice.Status == InvoicePaymentStatus.Paid)
                {
                    var confirm = MessageBox.Show(
                        "هل أنت متأكد من عمل مرتجع للفاتورة رقم " + invoice.InvoiceNumber + "؟",
                        "تأكيد المرتجع", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        MessageBox.Show("تم تسجيل المرتجع بنجاح", "تم",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "هيتم فتح شاشة تسجيل دفعة جديدة للفاتورة رقم " + invoice.InvoiceNumber +
                        "\nالمتبقي حاليًا: " + invoice.RemainingAmount.ToString("N0", CultureInfo.InvariantCulture) + " ج",
                        "تسجيل دفعة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

    }
}