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
    public partial class ucActivityLog : SabraUserControl
    {

        private const string AllUsersLabel = "كل المستخدمين";
        private const string AllOperationsLabel = "كل العمليات";

        // =========================================================
        // Fields
        // =========================================================

        private readonly clsAuditBusiness _auditBusiness = new clsAuditBusiness();

        private List<AuditLog> _filteredLogs = new List<AuditLog>();

        // =========================================================
        // Constructor
        // =========================================================

        public ucActivityLog()
        {
            InitializeComponent();
        }

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

            ConfigureGrid();

            ConfigureFilters();

            ApplyFilters();
        }

        // =========================================================
        // Page Configuration
        // =========================================================

        private void ConfigurePage()
        {
            RightToLeft = RightToLeft.Yes;
            BackColor = Color.White;
        }


        private sealed class LookupItem
        {
            public int Id { get; }
            public string Name { get; }

            public LookupItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString() => Name;
        }


        private void ConfigureFilters()
        {
            var usersResult = _auditBusiness.GetUsers();

            cstbxUsers.Items.Clear();
            cstbxUsers.Items.Add(AllUsersLabel);

            if (usersResult.Success && usersResult.Data != null)
            {
                foreach (var user in usersResult.Data
                    .OrderBy(u => u.Username))
                {
                    cstbxUsers.Items.Add(new LookupItem(user.UserID, user.Username));
                }
            }

            cstbxUsers.SelectedIndex = 0;

            var movTypesResult = _auditBusiness.GetMovementTypes();

            cmbxAllTransations.Items.Clear();
            cmbxAllTransations.Items.Add(AllOperationsLabel);

            if (movTypesResult.Success && movTypesResult.Data != null)
            {
                foreach (var movType in movTypesResult.Data
                    .OrderBy(m => m.TypeName))
                {
                    cmbxAllTransations.Items.Add(new LookupItem(movType.MovementTypeID, movType.TypeName));
                }
            }

            cmbxAllTransations.SelectedIndex = 0;

            sabraDateTimePickerFrom.Value = DateTime.Today.AddDays(-30);
            sabraDateTimePickerTo.Value = DateTime.Today;
        }

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

            // التاريخ والوقت
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ActionDate",
                    HeaderText = "التاريخ والوقت",
                    DataPropertyName = "ActionDate",
                    Width = 140,
                    MinimumWidth = 120,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                        Format = "dd/MM/yyyy HH:mm"
                    }
                });

            // المستخدم
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Username",
                    HeaderText = "المستخدم",
                    DataPropertyName = "Username",
                    Width = 130,
                    MinimumWidth = 100,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            // نوع الحركة
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "MovementType",
                    HeaderText = "نوع الحركة",
                    DataPropertyName = "MovementType",
                    Width = 130,
                    MinimumWidth = 110,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            // الصنف
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "PartName",
                    HeaderText = "الصنف",
                    DataPropertyName = "PartName",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    MinimumWidth = 200,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                });

            // التغيير بالكمية
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "QuantityChange",
                    HeaderText = "التغيير بالكمية",
                    DataPropertyName = "QuantityChange",
                    Width = 120,
                    MinimumWidth = 100,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

            // ملاحظات
            dgvLogActivity.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Remarks",
                    HeaderText = "ملاحظات",
                    DataPropertyName = "Remarks",
                    Width = 220,
                    MinimumWidth = 150,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                });

            dgvLogActivity.CellFormatting +=
                dgvLogActivity_CellFormatting;

            dgvLogActivity.ResumeLayout();
        }

        // =========================================================
        // Bind Grid Data
        // =========================================================

        private void BindGrid(IEnumerable<AuditLog> logs)
        {
            dgvLogActivity.DataSource = null;
            dgvLogActivity.DataSource = logs.ToList();

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

                int? selectedUserID = (cstbxUsers.SelectedItem as LookupItem)?.Id;
                int? selectedMovementTypeID = (cmbxAllTransations.SelectedItem as LookupItem)?.Id;

                var result = _auditBusiness.GetAll(
                    partID: null,
                    movementTypeID: selectedMovementTypeID,
                    from: fromDate,
                    to: toDate,
                    userID: selectedUserID);

                if (!result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                _filteredLogs = result.Data
                    .OrderByDescending(x => x.ActionDate)
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
            // بيطبّق الفلتر تلقائياً أول ما يتغيّر.
            // لو عايزه يطبّق بس بعد الضغط على "بحث"، امسح السطر اللي جاي.

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

                sabraDateTimePickerFrom.Value = DateTime.Today.AddDays(-30);
                sabraDateTimePickerTo.Value = DateTime.Today;

                ApplyFilters();
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
            // لو الشاشة فيها Label لعدد النتائج، حدّث نصه هنا. مثال:
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

            string columnName = dgvLogActivity.Columns[e.ColumnIndex].Name;

            // تلوين عمود "نوع الحركة" حسب نوعها
            if (columnName == "MovementType")
            {
                string movementType =
                    dgvLogActivity.Rows[e.RowIndex]
                    .Cells["MovementType"]
                    .Value?.ToString();

                if (string.IsNullOrWhiteSpace(movementType))
                    return;

                if (movementType.Contains("بيع"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(35, 130, 80);
                    e.CellStyle.Font = new Font(dgvLogActivity.Font, FontStyle.Bold);
                }
                else if (movementType.Contains("شراء"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(39, 125, 161);
                    e.CellStyle.Font = new Font(dgvLogActivity.Font, FontStyle.Bold);
                }
                else if (movementType.Contains("مرتجع"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(190, 50, 50);
                    e.CellStyle.Font = new Font(dgvLogActivity.Font, FontStyle.Bold);
                }
                else if (movementType.Contains("تعديل"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(100, 80, 170);
                    e.CellStyle.Font = new Font(dgvLogActivity.Font, FontStyle.Bold);
                }
            }

            // تلوين عمود "التغيير بالكمية": أخضر للزيادة، أحمر للنقصان
            else if (columnName == "QuantityChange" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int qtyChange))
                {
                    e.Value = qtyChange > 0 ? "+" + qtyChange : qtyChange.ToString();
                    e.FormattingApplied = true;

                    e.CellStyle.ForeColor = qtyChange >= 0
                        ? Color.FromArgb(35, 130, 80)
                        : Color.FromArgb(190, 50, 50);

                    e.CellStyle.Font = new Font(dgvLogActivity.Font, FontStyle.Bold);
                }
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
                row.Cells["ActionDate"].Value?.ToString();

            string user =
                row.Cells["Username"].Value?.ToString();

            string operation =
                row.Cells["MovementType"].Value?.ToString();

            string part =
                row.Cells["PartName"].Value?.ToString();

            string quantityChange =
                row.Cells["QuantityChange"].Value?.ToString();

            string remarks =
                row.Cells["Remarks"].Value?.ToString();

            string message =
                "التاريخ والوقت: " + dateTime +
                "\n\nالمستخدم: " + user +
                "\n\nنوع الحركة: " + operation +
                "\n\nالصنف: " + part +
                "\n\nالتغيير بالكمية: " + quantityChange +
                "\n\nملاحظات: " + (string.IsNullOrWhiteSpace(remarks) ? "—" : remarks);

            MessageBox.Show(
                message,
                "تفاصيل الحركة",
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
                dgvLogActivity, "", "سجل الأنشطة");
        }

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(dgvLogActivity, "سجل الأنشطة");
        }
    }
}