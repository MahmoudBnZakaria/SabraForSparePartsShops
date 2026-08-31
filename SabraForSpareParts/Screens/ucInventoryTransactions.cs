using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucInventoryTransactions : SabraUserControl
    {
        #region Fields

        private DataTable _transactionsTable;

        // يمنع تشغيل الفلترة أثناء تجهيز الـ Controls
        private bool _isInitializing = true;

        #endregion

        #region Constructor

        public ucInventoryTransactions()
        {
            InitializeComponent();

            InitializeScreen();
        }

        #endregion

        #region Initialization

        private void InitializeScreen()
        {
            try
            {
                _isInitializing = true;

                CreateMockData();

                SetupDataGridView();

                SetupFilters();

                ConfigureEvents();

                _isInitializing = false;

                ApplyFilters();
            }
            catch (Exception ex)
            {
                _isInitializing = false;

                MessageBox.Show(
                    $"حدث خطأ أثناء تحميل شاشة سجل حركة المخزون:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Mock Data

        private void CreateMockData()
        {
            _transactionsTable = new DataTable();

            _transactionsTable.Columns.Add(
                "DateTime",
                typeof(DateTime));

            _transactionsTable.Columns.Add(
                "PartName",
                typeof(string));

            _transactionsTable.Columns.Add(
                "MovementType",
                typeof(string));

            _transactionsTable.Columns.Add(
                "Change",
                typeof(int));

            _transactionsTable.Columns.Add(
                "Reference",
                typeof(string));

            _transactionsTable.Columns.Add(
                "User",
                typeof(string));

            _transactionsTable.Columns.Add(
                "Note",
                typeof(string));

            AddTransaction(
                new DateTime(2026, 1, 15, 11, 23, 0),
                "فلتر زيت تويوتا",
                "بيع",
                -4,
                "INV-1084",
                "أحمد",
                "—");

            AddTransaction(
                new DateTime(2026, 1, 15, 10, 0, 0),
                "بوجية NGK",
                "بيع",
                -1,
                "INV-1083",
                "سارة",
                "—");

            AddTransaction(
                new DateTime(2026, 1, 14, 16, 0, 0),
                "فلتر زيت تويوتا",
                "شراء",
                30,
                "PO-0045",
                "خالد",
                "استلام بضاعة");

            AddTransaction(
                new DateTime(2026, 1, 13, 11, 0, 0),
                "فلتر هواء رينو",
                "مرتجع",
                1,
                "RET-001",
                "أحمد",
                "غلط في الطلب");

            AddTransaction(
                new DateTime(2026, 1, 12, 14, 30, 0),
                "تيل فرامل هيونداي",
                "بيع",
                -2,
                "INV-1082",
                "سارة",
                "—");

            AddTransaction(
                new DateTime(2026, 1, 12, 9, 15, 0),
                "بطارية فارتا",
                "شراء",
                15,
                "PO-0044",
                "خالد",
                "استلام شحنة جديدة");

            AddTransaction(
                new DateTime(2026, 1, 11, 18, 20, 0),
                "زيت محرك موبيل",
                "تعديل",
                -3,
                "ADJ-001",
                "أحمد",
                "تصحيح كمية المخزون");

            AddTransaction(
                new DateTime(2026, 1, 10, 12, 45, 0),
                "فلتر هواء رينو",
                "مرتجع",
                2,
                "RET-002",
                "سارة",
                "مرتجع من العميل");

            AddTransaction(
                new DateTime(2026, 1, 10, 10, 10, 0),
                "بوجية Bosch",
                "شراء",
                50,
                "PO-0043",
                "خالد",
                "توريد جديد");

            AddTransaction(
                new DateTime(2026, 1, 9, 17, 40, 0),
                "فلتر زيت تويوتا",
                "بيع",
                -6,
                "INV-1081",
                "أحمد",
                "—");

            AddTransaction(
                new DateTime(2026, 1, 8, 15, 25, 0),
                "تيل فرامل هيونداي",
                "شراء",
                20,
                "PO-0042",
                "خالد",
                "—");

            AddTransaction(
                new DateTime(2026, 1, 7, 13, 10, 0),
                "زيت محرك موبيل",
                "بيع",
                -5,
                "INV-1080",
                "سارة",
                "—");

            AddTransaction(
                new DateTime(2026, 1, 6, 11, 50, 0),
                "بطارية فارتا",
                "مرتجع",
                1,
                "RET-003",
                "أحمد",
                "البطارية غير مناسبة");

            AddTransaction(
                new DateTime(2026, 1, 5, 16, 35, 0),
                "فلتر هواء رينو",
                "تعديل",
                -1,
                "ADJ-002",
                "خالد",
                "تصحيح جرد");

            AddTransaction(
                new DateTime(2026, 1, 4, 10, 20, 0),
                "بوجية NGK",
                "بيع",
                -3,
                "INV-1079",
                "سارة",
                "—");
        }

        private void AddTransaction(
            DateTime dateTime,
            string partName,
            string movementType,
            int change,
            string reference,
            string user,
            string note)
        {
            _transactionsTable.Rows.Add(
                dateTime,
                partName,
                movementType,
                change,
                reference,
                user,
                note);
        }

        #endregion

        #region DataGridView

        private void SetupDataGridView()
        {
            dgvInventoryTransactions.AutoGenerateColumns =
                false;

            dgvInventoryTransactions.Columns.Clear();

            AddDateTimeColumn();

            AddTextColumn(
                "colPartName",
                "القطعة",
                "PartName",
                20);

            AddTextColumn(
                "colMovementType",
                "نوع الحركة",
                "MovementType",
                12);

            AddTextColumn(
                "colChange",
                "التغيير",
                "Change",
                10);

            AddTextColumn(
                "colReference",
                "المرجع",
                "Reference",
                12);

            AddTextColumn(
                "colUser",
                "المستخدم",
                "User",
                10);

            AddTextColumn(
                "colNote",
                "ملاحظة",
                "Note",
                18);

            ConfigureGridAppearance();

            dgvInventoryTransactions.CellFormatting -=
                dgvInventoryTransactions_CellFormatting;

            dgvInventoryTransactions.CellFormatting +=
                dgvInventoryTransactions_CellFormatting;

            // *** BUGFIX: الجدول كان بيتفلتر من غير ما يتربط بأي DataSource خالص،
            // فكانت الشاشة بتفضل فاضية مهما اتغيّرت الفلاتر. ***
            dgvInventoryTransactions.DataSource =
                _transactionsTable.DefaultView;
        }

        private void AddDateTimeColumn()
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn
                {
                    Name = "colDateTime",
                    HeaderText = "التاريخ والوقت",
                    DataPropertyName = "DateTime",
                    FillWeight = 18
                };

            column.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm",
                    Alignment =
                        DataGridViewContentAlignment.MiddleCenter
                };

            dgvInventoryTransactions.Columns.Add(
                column);
        }

        private void AddTextColumn(
            string name,
            string headerText,
            string dataPropertyName,
            float fillWeight)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn
                {
                    Name = name,
                    HeaderText = headerText,
                    DataPropertyName = dataPropertyName,
                    FillWeight = fillWeight
                };

            dgvInventoryTransactions.Columns.Add(
                column);
        }

        private void ConfigureGridAppearance()
        {
            dgvInventoryTransactions.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvInventoryTransactions.AllowUserToAddRows =
                false;

            dgvInventoryTransactions.AllowUserToDeleteRows =
                false;

            dgvInventoryTransactions.AllowUserToResizeRows =
                false;

            dgvInventoryTransactions.ReadOnly =
                true;

            dgvInventoryTransactions.MultiSelect =
                false;

            dgvInventoryTransactions.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvInventoryTransactions.RowHeadersVisible =
                false;

            dgvInventoryTransactions.AutoGenerateColumns =
                false;
        }

        #endregion

        #region Filters

        private void SetupFilters()
        {
            SetupUsersFilter();

            SetupMovementFilter();

            SetupDateFilter();
        }

        private void SetupUsersFilter()
        {
            smbxAllUsers.Items.Clear();

            smbxAllUsers.Items.Add(
                "كل المستخدمين");

            IEnumerable<string> users =
                _transactionsTable
                .AsEnumerable()
                .Select(row =>
                    row.Field<string>("User"))
                .Where(user =>
                    !string.IsNullOrWhiteSpace(user))
                .Distinct()
                .OrderBy(user => user);

            foreach (string user in users)
            {
                smbxAllUsers.Items.Add(user);
            }

            smbxAllUsers.SelectedIndex = 0;
        }

        private void SetupMovementFilter()
        {
            cstbxMovements.Items.Clear();

            cstbxMovements.Items.Add(
                "كل الحركات");

            IEnumerable<string> movements =
                _transactionsTable
                .AsEnumerable()
                .Select(row =>
                    row.Field<string>("MovementType"))
                .Where(movement =>
                    !string.IsNullOrWhiteSpace(movement))
                .Distinct()
                .OrderBy(movement => movement);

            foreach (string movement in movements)
            {
                cstbxMovements.Items.Add(
                    movement);
            }

            cstbxMovements.SelectedIndex = 0;
        }

        private void SetupDateFilter()
        {
            // *** BUGFIX: SabraDateTimePicker بقى فيها Checked / ShowCheckBox فعليًا،
            // فبقى ممكن نفعّل فلتر التاريخ الاختياري زي الـ DateTimePicker الأصلي. ***
            sabraDateTimePicker1.ShowCheckBox = true;
            sabraDateTimePicker1.Checked = false;
            sabraDateTimePicker1.Value = DateTime.Today;
        }

        #endregion

        #region Events

        private void ConfigureEvents()
        {
            smbxAllUsers.SelectedIndexChanged -=
                smbxAllUsers_SelectedIndexChanged;

            smbxAllUsers.SelectedIndexChanged +=
                smbxAllUsers_SelectedIndexChanged;

            cstbxMovements.SelectedIndexChanged -=
                cstbxMovements_SelectedIndexChanged;

            cstbxMovements.SelectedIndexChanged +=
                cstbxMovements_SelectedIndexChanged;

            sabraDateTimePicker1.ValueChanged -=
                sabraDateTimePicker1_ValueChanged;

            sabraDateTimePicker1.ValueChanged +=
                sabraDateTimePicker1_ValueChanged;

            stxbxPartName.TextChanged -=
                stxbxPartName_TextChanged;

            stxbxPartName.TextChanged +=
                stxbxPartName_TextChanged;
        }

        #endregion

        #region Filtering

        private void ApplyFilters()
        {
            if (_isInitializing || _transactionsTable == null)
            {
                return;
            }

            List<string> filters = new List<string>();

            // 1. فلتر اسم القطعة
            string partName = stxbxPartName.Text.Trim();
            if (!string.IsNullOrWhiteSpace(partName))
            {
                filters.Add(
                    $"[PartName] LIKE '%{EscapeForRowFilter(partName)}%'");
            }

            // 2. فلتر نوع الحركة
            string movement = cstbxMovements.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(movement) && movement != "كل الحركات")
            {
                filters.Add(
                    $"[MovementType] = '{EscapeForRowFilter(movement)}'");
            }

            // 3. فلتر المستخدم
            string user = smbxAllUsers.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(user) && user != "كل المستخدمين")
            {
                filters.Add(
                    $"[User] = '{EscapeForRowFilter(user)}'");
            }

            // 4. فلتر التاريخ (اختياري - بيتفعّل بس لما يبقى محدد Checked)
            if (sabraDateTimePicker1.Checked)
            {
                DateTime selectedDate = sabraDateTimePicker1.Value.Date;
                DateTime nextDate = selectedDate.AddDays(1);

                // صيغة التاريخ المدعومة في RowFilter (culture-invariant)
                string filterStartDate = selectedDate.ToString("MM/dd/yyyy");
                string filterEndDate = nextDate.ToString("MM/dd/yyyy");

                filters.Add(
                    $"[DateTime] >= #{filterStartDate}# AND [DateTime] < #{filterEndDate}#");
            }

            // تجميع الشروط وتطبيقها على الـ DefaultView
            string finalFilter = string.Join(" AND ", filters);

            try
            {
                _transactionsTable.DefaultView.RowFilter = finalFilter;
            }
            catch (Exception ex)
            {
                // حماية من أي خطأ غير متوقع في صياغة الفلتر بدل ما الشاشة تقفل فجأة
                MessageBox.Show(
                    $"تعذر تطبيق الفلتر:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// يهرّب علامة التنصيص المفردة عشان تبقى آمنة داخل RowFilter.
        /// </summary>
        private static string EscapeForRowFilter(string value)
        {
            return value?.Replace("'", "''") ?? string.Empty;
        }

        #endregion

        #region Reset Filters

        private void ResetFilters()
        {
            _isInitializing = true;

            try
            {
                stxbxPartName.Clear();

                if (smbxAllUsers.Items.Count > 0)
                    smbxAllUsers.SelectedIndex = 0;

                if (cstbxMovements.Items.Count > 0)
                    cstbxMovements.SelectedIndex = 0;

                sabraDateTimePicker1.Checked = false;
                sabraDateTimePicker1.Value = DateTime.Today;
            }
            finally
            {
                _isInitializing = false;
            }

            ApplyFilters();
        }

        #endregion

        #region Grid Formatting

        private void dgvInventoryTransactions_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0 ||
                e.Value == null)
            {
                return;
            }

            string columnName =
                dgvInventoryTransactions
                .Columns[e.ColumnIndex]
                .Name;

            if (columnName == "colChange")
            {
                FormatChangeCell(e);
            }

            if (columnName ==
                "colMovementType")
            {
                FormatMovementCell(e);
            }
        }

        private void FormatChangeCell(
            DataGridViewCellFormattingEventArgs e)
        {
            if (!int.TryParse(
                    e.Value.ToString(),
                    out int change))
            {
                return;
            }

            e.Value =
                change > 0
                    ? $"+{change}"
                    : change.ToString();

            e.CellStyle.Font =
                new Font(
                    dgvInventoryTransactions.Font,
                    FontStyle.Bold);

            e.CellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        private void FormatMovementCell(
            DataGridViewCellFormattingEventArgs e)
        {
            string movement =
                e.Value.ToString();

            switch (movement)
            {
                case "بيع":
                    e.CellStyle.ForeColor =
                        Color.Firebrick;
                    break;

                case "شراء":
                    e.CellStyle.ForeColor =
                        Color.ForestGreen;
                    break;

                case "مرتجع":
                    e.CellStyle.ForeColor =
                        Color.DarkOrange;
                    break;

                case "تعديل":
                    e.CellStyle.ForeColor =
                        Color.RoyalBlue;
                    break;
            }

            e.CellStyle.Font =
                new Font(
                    dgvInventoryTransactions.Font,
                    FontStyle.Bold);
        }

        #endregion

        #region Control Events

        private void slblTitleOfTopPanel_Click(
            object sender,
            EventArgs e)
        {
        }

        private void smbxAllUsers_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void sabraDateTimePicker1_ValueChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void cstbxMovements_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void stxbxPartName_TextChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void scbtnRestFilters_Click(
            object sender,
            EventArgs e)
        {
            ResetFilters();
        }

        #endregion

        #region Print

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(
                dgvInventoryTransactions,
                "سجل حركة المخزون");
        }

        #endregion

        #region Export Excel

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            clsGlobalClass.ExportDataGridViewToExcel(
                dgvInventoryTransactions,
                "Inventory_Movement_Log",
                "سجل حركة المخزون");
        }

        #endregion
    }
}