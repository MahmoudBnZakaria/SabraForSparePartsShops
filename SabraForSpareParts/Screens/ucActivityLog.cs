using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucActivityLog : SabraUserControl
    {
        // =========================================================
        // Activity Log Model
        // =========================================================

        private class ActivityLogItem
        {
            public DateTime DateTime { get; set; }
            public string User { get; set; }
            public string Operation { get; set; }
            public string Details { get; set; }
            public string IP { get; set; }
        }

        // =========================================================
        // Fields
        // =========================================================

        private readonly List<ActivityLogItem> _activityLogs =
            new List<ActivityLogItem>();

        private List<ActivityLogItem> _filteredLogs =
            new List<ActivityLogItem>();

        private readonly PrintDocument _printDocument =
            new PrintDocument();

        private int _printRowIndex = 0;

        private Font _printHeaderFont;
        private Font _printTitleFont;
        private Font _printBodyFont;

        // =========================================================
        // Constructor
        // =========================================================

        public ucActivityLog()
        {
            InitializeComponent();

        }
    //    private void LogActivity(
    //string user,
    //string operation,
    //string details,
    //string ip)
    //    {

    //        _activityLogs.Add(new ActivityLogItem
    //        {
    //            DateTime = DateTime.Now,
    //            User = user,
    //            Operation = operation,
    //            Details = details,
    //            IP = ip
    //        });
    //    }


        // =========================================================
        // Load
        // =========================================================

        private void ucActivityLog_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeActivityLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل سجل الأنشطة:\n\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // Initialize
        // =========================================================

        private void InitializeActivityLog()
        {
            ConfigurePage();

            CreateMockData();

            ConfigureFilters();

            ConfigureGrid();

            LoadActivityLogs();

            UpdateResultsCount();
        }

        // =========================================================
        // Page Configuration
        // =========================================================

        private void ConfigurePage()
        {
            RightToLeft = RightToLeft.Yes;
            BackColor = Color.White;

            _printTitleFont = new Font(
                "Segoe UI",
                14,
                FontStyle.Bold);

            _printHeaderFont = new Font(
                "Segoe UI",
                9,
                FontStyle.Bold);

            _printBodyFont = new Font(
                "Segoe UI",
                9,
                FontStyle.Regular);
        }

        // =========================================================
        // Mock Data
        // =========================================================

        private void CreateMockData()
        {
            _activityLogs.Clear();

            _activityLogs.AddRange(new[]
            {
                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 15, 11, 23, 0),
                    User = "admin",
                    Operation = "فاتورة جديدة",
                    Details = "إنشاء INV-1084 بقيمة 3,200 ج",
                    IP = "192.168.1.1"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 15, 10, 5, 0),
                    User = "admin",
                    Operation = "تعديل سعر",
                    Details = "تغيير سعر فلتر زيت من 40 لـ 45 ج",
                    IP = "192.168.1.1"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 15, 9, 0, 0),
                    User = "sara_cashier",
                    Operation = "دخول للنظام",
                    Details = "تسجيل دخول ناجح",
                    IP = "192.168.1.5"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 14, 16, 45, 0),
                    User = "khaled_store",
                    Operation = "استلام بضاعة",
                    Details = "PO-0045 — 30 فلتر تويوتا",
                    IP = "192.168.1.8"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 14, 15, 20, 0),
                    User = "admin",
                    Operation = "إضافة مستخدم",
                    Details = "إضافة المستخدم ahmed_sales",
                    IP = "192.168.1.1"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 14, 14, 10, 0),
                    User = "ahmed_sales",
                    Operation = "فاتورة جديدة",
                    Details = "إنشاء INV-1083 بقيمة 1,850 ج",
                    IP = "192.168.1.12"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 14, 12, 35, 0),
                    User = "sara_cashier",
                    Operation = "تعديل فاتورة",
                    Details = "تعديل الكمية في INV-1081",
                    IP = "192.168.1.5"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 14, 11, 15, 0),
                    User = "khaled_store",
                    Operation = "إضافة صنف",
                    Details = "إضافة Bosch Oil Filter إلى المخزون",
                    IP = "192.168.1.8"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 13, 17, 30, 0),
                    User = "admin",
                    Operation = "تعديل مستخدم",
                    Details = "تعديل صلاحيات المستخدم sara_cashier",
                    IP = "192.168.1.1"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 13, 15, 50, 0),
                    User = "ahmed_sales",
                    Operation = "حذف فاتورة",
                    Details = "حذف الفاتورة INV-1078",
                    IP = "192.168.1.12"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 13, 13, 25, 0),
                    User = "sara_cashier",
                    Operation = "صرف نقدية",
                    Details = "صرف مبلغ 500 ج من الخزينة",
                    IP = "192.168.1.5"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 13, 10, 40, 0),
                    User = "khaled_store",
                    Operation = "تعديل مخزون",
                    Details = "تعديل كمية فلتر هواء Toyota من 12 إلى 20",
                    IP = "192.168.1.8"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 12, 18, 5, 0),
                    User = "admin",
                    Operation = "تصدير تقرير",
                    Details = "تصدير تقرير المبيعات إلى Excel",
                    IP = "192.168.1.1"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 12, 16, 20, 0),
                    User = "ahmed_sales",
                    Operation = "تسجيل خروج",
                    Details = "تسجيل خروج من النظام",
                    IP = "192.168.1.12"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 12, 9, 10, 0),
                    User = "sara_cashier",
                    Operation = "دخول للنظام",
                    Details = "تسجيل دخول ناجح",
                    IP = "192.168.1.5"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 11, 14, 45, 0),
                    User = "admin",
                    Operation = "تعديل إعدادات",
                    Details = "تعديل إعدادات الضرائب والفواتير",
                    IP = "192.168.1.1"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 11, 12, 30, 0),
                    User = "khaled_store",
                    Operation = "استلام بضاعة",
                    Details = "PO-0044 — 50 فلتر زيت",
                    IP = "192.168.1.8"
                },

                new ActivityLogItem
                {
                    DateTime = new DateTime(2026, 1, 10, 17, 15, 0),
                    User = "ahmed_sales",
                    Operation = "فاتورة جديدة",
                    Details = "إنشاء INV-1075 بقيمة 4,700 ج",
                    IP = "192.168.1.12"
                }
            });
        }

        // =========================================================
        // Filters
        // =========================================================

        private void ConfigureFilters()
        {
            // Users
            cstbxUsers.Items.Clear();

            cstbxUsers.Items.Add("كل المستخدمين");

            foreach (string user in _activityLogs
                .Select(x => x.User)
                .Distinct()
                .OrderBy(x => x))
            {
                cstbxUsers.Items.Add(user);
            }

            cstbxUsers.SelectedIndex = 0;

            // Operations
            cmbxAllTransations.Items.Clear();

            cmbxAllTransations.Items.Add("كل العمليات");

            foreach (string operation in _activityLogs
                .Select(x => x.Operation)
                .Distinct()
                .OrderBy(x => x))
            {
                cmbxAllTransations.Items.Add(operation);
            }

            cmbxAllTransations.SelectedIndex = 0;

            // Dates
            DateTime minDate = _activityLogs.Min(x => x.DateTime).Date;
            DateTime maxDate = _activityLogs.Max(x => x.DateTime).Date;


            sabraDateTimePickerFrom.Value = minDate;
            sabraDateTimePickerTo.Value = maxDate;
        }

        // =========================================================
        // Grid
        // =========================================================

        private void ConfigureGrid()
        {
            dgvLogActivity.SuspendLayout();

            dgvLogActivity.AutoGenerateColumns = false;

            dgvLogActivity.Columns.Clear();

            dgvLogActivity.RightToLeft = RightToLeft.Yes;

            dgvLogActivity.AllowUserToAddRows = false;
            dgvLogActivity.AllowUserToDeleteRows = false;
            dgvLogActivity.AllowUserToResizeRows = false;

            dgvLogActivity.ReadOnly = true;

            dgvLogActivity.MultiSelect = false;
            dgvLogActivity.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvLogActivity.RowHeadersVisible = false;

            dgvLogActivity.BackgroundColor = Color.White;
            dgvLogActivity.BorderStyle = BorderStyle.None;

            dgvLogActivity.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvLogActivity.GridColor =
                Color.FromArgb(235, 238, 242);

            dgvLogActivity.EnableHeadersVisualStyles = false;

            dgvLogActivity.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            dgvLogActivity.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(45, 55, 72);

            dgvLogActivity.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            dgvLogActivity.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvLogActivity.ColumnHeadersHeight = 42;

            dgvLogActivity.DefaultCellStyle.Font =
                new Font("Segoe UI", 9);

            dgvLogActivity.DefaultCellStyle.ForeColor =
                Color.FromArgb(45, 55, 72);

            dgvLogActivity.DefaultCellStyle.BackColor =
                Color.White;

            dgvLogActivity.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 242, 255);

            dgvLogActivity.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(30, 40, 55);

            dgvLogActivity.DefaultCellStyle.Padding =
                new Padding(8, 5, 8, 5);

            dgvLogActivity.RowTemplate.Height = 45;

            // Date & Time
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "DateTime",
                    HeaderText = "التاريخ والوقت",
                    DataPropertyName = "DateTime",
                    Width = 140,
                    MinimumWidth = 120,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                        Format = "dd/MM/yyyy HH:mm"
                    }
                });

            // User
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "User",
                    HeaderText = "المستخدم",
                    DataPropertyName = "User",
                    Width = 150,
                    MinimumWidth = 110,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            // Operation
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Operation",
                    HeaderText = "العملية",
                    DataPropertyName = "Operation",
                    Width = 150,
                    MinimumWidth = 120,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            // Details
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Details",
                    HeaderText = "التفاصيل",
                    DataPropertyName = "Details",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    MinimumWidth = 250,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                });

            // IP
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "IP",
                    HeaderText = "IP",
                    DataPropertyName = "IP",
                    Width = 135,
                    MinimumWidth = 110,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            dgvLogActivity.CellFormatting +=
                dgvLogActivity_CellFormatting;

            dgvLogActivity.ResumeLayout();
        }

        // =========================================================
        // Load Grid Data
        // =========================================================

        private void LoadActivityLogs()
        {
            _filteredLogs = _activityLogs
                .OrderByDescending(x => x.DateTime)
                .ToList();

            BindGrid(_filteredLogs);
        }

        private void BindGrid(IEnumerable<ActivityLogItem> logs)
        {
            dgvLogActivity.DataSource = null;

            dgvLogActivity.DataSource =
                logs.Select(x => new
                {
                    x.DateTime,
                    x.User,
                    x.Operation,
                    x.Details,
                    x.IP
                })
                .ToList();

            UpdateResultsCount();
        }

        // =========================================================
        // Search
        // =========================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            try
            {
                DateTime fromDate =
                    sabraDateTimePickerFrom.Value.Date;

                DateTime toDate =
                    sabraDateTimePickerTo.Value.Date.AddDays(1).AddTicks(-1);

                if (fromDate > toDate)
                {
                    MessageBox.Show(
                        "تاريخ البداية يجب أن يكون قبل تاريخ النهاية.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string selectedUser =
                    cstbxUsers.SelectedItem?.ToString();

                string selectedOperation =
                    cmbxAllTransations.SelectedItem?.ToString();

                IEnumerable<ActivityLogItem> query =
                    _activityLogs;

                // Date
                query = query.Where(x =>
                    x.DateTime >= fromDate &&
                    x.DateTime <= toDate);

                // User
                if (!string.IsNullOrWhiteSpace(selectedUser) &&
                    selectedUser != "كل المستخدمين")
                {
                    query = query.Where(x =>
                        x.User.Equals(
                            selectedUser,
                            StringComparison.OrdinalIgnoreCase));
                }

                // Operation
                if (!string.IsNullOrWhiteSpace(selectedOperation) &&
                    selectedOperation != "كل العمليات")
                {
                    query = query.Where(x =>
                        x.Operation == selectedOperation);
                }

                _filteredLogs = query
                    .OrderByDescending(x => x.DateTime)
                    .ToList();

                BindGrid(_filteredLogs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء البحث:\n\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // User Filter
        // =========================================================

        private void cstbxUsers_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            // Apply automatically when user changes the filter.
            // If you want search to happen only after pressing
            // Search, remove the next line.

            ApplyFilters();
        }

        // =========================================================
        // Operation Filter
        // =========================================================

        private void cmbxAllTransations_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        // =========================================================
        // Date Pickers
        // =========================================================

        private void sabraDateTimePickerFrom_Load(
            object sender,
            EventArgs e)
        {
        }

        private void sabraDateTimePickerTo_Load(
            object sender,
            EventArgs e)
        {
        }

        // =========================================================
        // Reset Filters
        // =========================================================

        private void scbtnRestFilters_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (cstbxUsers.Items.Count > 0)
                    cstbxUsers.SelectedIndex = 0;

                if (cmbxAllTransations.Items.Count > 0)
                    cmbxAllTransations.SelectedIndex = 0;

                if (_activityLogs.Count > 0)
                {
                    sabraDateTimePickerFrom.Value =
                        _activityLogs.Min(x => x.DateTime).Date;

                    sabraDateTimePickerTo.Value =
                        _activityLogs.Max(x => x.DateTime).Date;
                }

                _filteredLogs =
                    _activityLogs
                    .OrderByDescending(x => x.DateTime)
                    .ToList();

                BindGrid(_filteredLogs);

                UpdateResultsCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء إعادة ضبط الفلاتر:\n\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // Results Count
        // =========================================================

        private void UpdateResultsCount()
        {
            // If your page contains a label for the number of results,
            // you can set its Text here.
            //
            // Example:
            // lblResultsCount.Text = $"عدد العمليات: {_filteredLogs.Count}";

            if (dgvLogActivity.Parent != null)
            {
                dgvLogActivity.Parent.PerformLayout();
            }
        }

        // =========================================================
        // Grid Formatting
        // =========================================================

        private void dgvLogActivity_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;

            string operation =
                dgvLogActivity.Rows[e.RowIndex]
                .Cells["Operation"]
                .Value?.ToString();

            if (string.IsNullOrWhiteSpace(operation))
                return;

            // Login
            if (operation == "دخول للنظام")
            {
                e.CellStyle.ForeColor =
                    Color.FromArgb(39, 125, 161);

                e.CellStyle.Font =
                    new Font(
                        dgvLogActivity.Font,
                        FontStyle.Bold);
            }

            // Logout
            else if (operation == "تسجيل خروج")
            {
                e.CellStyle.ForeColor =
                    Color.FromArgb(100, 116, 139);

                e.CellStyle.Font =
                    new Font(
                        dgvLogActivity.Font,
                        FontStyle.Bold);
            }

            // Delete
            else if (operation == "حذف فاتورة")
            {
                e.CellStyle.ForeColor =
                    Color.FromArgb(190, 50, 50);

                e.CellStyle.Font =
                    new Font(
                        dgvLogActivity.Font,
                        FontStyle.Bold);
            }

            // Money
            else if (operation == "صرف نقدية")
            {
                e.CellStyle.ForeColor =
                    Color.FromArgb(170, 110, 20);

                e.CellStyle.Font =
                    new Font(
                        dgvLogActivity.Font,
                        FontStyle.Bold);
            }

            // Create
            else if (operation == "فاتورة جديدة")
            {
                e.CellStyle.ForeColor =
                    Color.FromArgb(35, 130, 80);

                e.CellStyle.Font =
                    new Font(
                        dgvLogActivity.Font,
                        FontStyle.Bold);
            }

            // Stock
            else if (operation.Contains("مخزون") ||
                     operation.Contains("بضاعة"))
            {
                e.CellStyle.ForeColor =
                    Color.FromArgb(100, 80, 170);

                e.CellStyle.Font =
                    new Font(
                        dgvLogActivity.Font,
                        FontStyle.Bold);
            }
        }

        // =========================================================
        // View Details
        // =========================================================

        private void dgvLogActivity_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvLogActivity.Rows.Count == 0)
                return;

            DataGridViewRow row =
                dgvLogActivity.Rows[e.RowIndex];

            string dateTime =
                row.Cells["DateTime"].Value?.ToString();

            string user =
                row.Cells["User"].Value?.ToString();

            string operation =
                row.Cells["Operation"].Value?.ToString();

            string details =
                row.Cells["Details"].Value?.ToString();

            string ip =
                row.Cells["IP"].Value?.ToString();

            string message =
                "التاريخ والوقت: " + dateTime +
                "\n\nالمستخدم: " + user +
                "\n\nالعملية: " + operation +
                "\n\nالتفاصيل: " + details +
                "\n\nعنوان IP: " + ip;

            MessageBox.Show(
                message,
                "تفاصيل النشاط",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // Export Excel
        // =========================================================

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            clsGlobalClass.ExportDataGridViewToExcel(
                dgvLogActivity,"","سجل الأنشطة");
        }

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(dgvLogActivity, "سجل الأنشطة");
        }
    }
}