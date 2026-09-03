using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucSuppliers : SabraUserControl
    {
        #region Models

        private class Supplier
        {
            public int ID { get; set; }

            public string Name { get; set; }

            public string ContactPerson { get; set; }

            public string Phone { get; set; }

            public decimal TotalPurchases { get; set; }

            public decimal Debt { get; set; }

            public DateTime LastOrderDate { get; set; }
        }

        #endregion


        #region Fields

        private List<Supplier> _suppliers;

        #endregion


        #region Constructor

        public ucSuppliers()
        {
            InitializeComponent();

            InitializeSuppliers();

            ConfigureSuppliersGrid();

            LoadSuppliers();

            UpdateSuppliersCount();

            dgvSuppliers.CellFormatting += dgvSuppliers_CellFormatting;

            dgvSuppliers.CellContentClick += dgvSuppliers_CellContentClick;
        }

        #endregion


        #region Initialize Data

        private void InitializeSuppliers()
        {
            _suppliers = new List<Supplier>
            {
                new Supplier
                {
                    ID = 1,
                    Name = "شركة بوش مصر",
                    ContactPerson = "مهندس سامي",
                    Phone = "0222345678",
                    TotalPurchases = 245000,
                    Debt = 15200,
                    LastOrderDate = new DateTime(2025, 1, 10)
                },

                new Supplier
                {
                    ID = 2,
                    Name = "مورد NGK",
                    ContactPerson = "أستاذ رامي",
                    Phone = "0233456789",
                    TotalPurchases = 89000,
                    Debt = 8400,
                    LastOrderDate = new DateTime(2025, 1, 8)
                },

                new Supplier
                {
                    ID = 3,
                    Name = "المستورد العربي",
                    ContactPerson = "أستاذ وليد",
                    Phone = "0244567890",
                    TotalPurchases = 134000,
                    Debt = 0,
                    LastOrderDate = new DateTime(2025, 1, 5)
                },

                new Supplier
                {
                    ID = 4,
                    Name = "شركة المنصور",
                    ContactPerson = "أستاذ أحمد",
                    Phone = "0256789012",
                    TotalPurchases = 178000,
                    Debt = 22500,
                    LastOrderDate = new DateTime(2025, 1, 3)
                },

                new Supplier
                {
                    ID = 5,
                    Name = "شركة التوفيق",
                    ContactPerson = "أستاذ محمد",
                    Phone = "0267890123",
                    TotalPurchases = 97000,
                    Debt = 0,
                    LastOrderDate = new DateTime(2024, 12, 29)
                }
            };
        }

        #endregion


        #region Configure Grid

        private void ConfigureSuppliersGrid()
        {
            dgvSuppliers.AutoGenerateColumns = false;

            dgvSuppliers.Columns.Clear();

            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.AllowUserToDeleteRows = false;
            dgvSuppliers.AllowUserToResizeRows = false;

            dgvSuppliers.ReadOnly = true;

            dgvSuppliers.MultiSelect = false;

            dgvSuppliers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvSuppliers.RowHeadersVisible = false;

            dgvSuppliers.RightToLeft = RightToLeft.Yes;

            dgvSuppliers.BackgroundColor = Color.White;

            dgvSuppliers.BorderStyle = BorderStyle.None;

            dgvSuppliers.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvSuppliers.GridColor =
                Color.FromArgb(230, 234, 238);

            dgvSuppliers.EnableHeadersVisualStyles = false;

            dgvSuppliers.ColumnHeadersHeight = 50;

            dgvSuppliers.RowTemplate.Height = 48;


            // Header

            dgvSuppliers.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);

            dgvSuppliers.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(40, 50, 65);

            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Cairo", 10, FontStyle.Bold);

            dgvSuppliers.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // Cells

            dgvSuppliers.DefaultCellStyle.BackColor =
                Color.White;

            dgvSuppliers.DefaultCellStyle.ForeColor =
                Color.FromArgb(40, 50, 65);

            dgvSuppliers.DefaultCellStyle.Font =
                new Font("Cairo", 9.5f);

            dgvSuppliers.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvSuppliers.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(247, 249, 252);

            dgvSuppliers.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(40, 50, 65);


            // ==========================================
            // اسم المورد
            // ==========================================

            DataGridViewTextBoxColumn supplierName =
                new DataGridViewTextBoxColumn();

            supplierName.Name = "SupplierName";
            supplierName.HeaderText = "اسم المورد";
            supplierName.DataPropertyName = "Name";

            supplierName.FillWeight = 150;

            supplierName.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            supplierName.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            supplierName.DefaultCellStyle.Font =
                new Font("Cairo", 9.5f, FontStyle.Bold);

            dgvSuppliers.Columns.Add(supplierName);


            // ==========================================
            // الشخص المسؤول
            // ==========================================

            DataGridViewTextBoxColumn contactPerson =
                new DataGridViewTextBoxColumn();

            contactPerson.Name = "ContactPerson";
            contactPerson.HeaderText = "الشخص المسؤول";
            contactPerson.DataPropertyName = "ContactPerson";

            contactPerson.FillWeight = 130;

            contactPerson.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgvSuppliers.Columns.Add(contactPerson);


            // ==========================================
            // التليفون
            // ==========================================

            DataGridViewTextBoxColumn phone =
                new DataGridViewTextBoxColumn();

            phone.Name = "Phone";
            phone.HeaderText = "التليفون";
            phone.DataPropertyName = "Phone";

            phone.FillWeight = 110;

            phone.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgvSuppliers.Columns.Add(phone);


            // ==========================================
            // إجمالي المشتريات
            // ==========================================

            DataGridViewTextBoxColumn totalPurchases =
                new DataGridViewTextBoxColumn();

            totalPurchases.Name = "TotalPurchases";
            totalPurchases.HeaderText = "إجمالي المشتريات";
            totalPurchases.DataPropertyName = "TotalPurchases";

            totalPurchases.FillWeight = 130;

            totalPurchases.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            totalPurchases.DefaultCellStyle.Format = "#,##0 ج";

            dgvSuppliers.Columns.Add(totalPurchases);


            // ==========================================
            // مديونيتنا
            // ==========================================

            DataGridViewTextBoxColumn debt =
                new DataGridViewTextBoxColumn();

            debt.Name = "Debt";
            debt.HeaderText = "مديونيتنا";
            debt.DataPropertyName = "Debt";

            debt.FillWeight = 110;

            debt.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            debt.DefaultCellStyle.Format = "#,##0 ج";

            dgvSuppliers.Columns.Add(debt);


            // ==========================================
            // آخر طلبية
            // ==========================================

            DataGridViewTextBoxColumn lastOrder =
                new DataGridViewTextBoxColumn();

            lastOrder.Name = "LastOrder";
            lastOrder.HeaderText = "آخر طلبية";
            lastOrder.DataPropertyName = "LastOrderDate";

            lastOrder.FillWeight = 110;

            lastOrder.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            lastOrder.DefaultCellStyle.Format = "d/M/yyyy";

            dgvSuppliers.Columns.Add(lastOrder);


            // ==========================================
            // الإجراءات
            // ==========================================

            DataGridViewButtonColumn accountColumn =
                new DataGridViewButtonColumn();

            accountColumn.Name = "Account";
            accountColumn.HeaderText = "الإجراءات";

            accountColumn.Text = "كشف حساب";

            accountColumn.UseColumnTextForButtonValue = true;

            accountColumn.FillWeight = 95;

            accountColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            accountColumn.FlatStyle = FlatStyle.Flat;

            accountColumn.DefaultCellStyle.BackColor =
                Color.White;

            accountColumn.DefaultCellStyle.SelectionBackColor =
                Color.White;

            accountColumn.DefaultCellStyle.ForeColor =
                Color.FromArgb(75, 90, 110);

            dgvSuppliers.Columns.Add(accountColumn);


            // ==========================================
            // طلبية
            // ==========================================

            DataGridViewButtonColumn orderColumn =
                new DataGridViewButtonColumn();

            orderColumn.Name = "Order";
            orderColumn.HeaderText = "";

            orderColumn.Text = "طلبية";

            orderColumn.UseColumnTextForButtonValue = true;

            orderColumn.FillWeight = 70;

            orderColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            orderColumn.FlatStyle = FlatStyle.Flat;

            orderColumn.DefaultCellStyle.BackColor =
                Color.White;

            orderColumn.DefaultCellStyle.SelectionBackColor =
                Color.White;

            orderColumn.DefaultCellStyle.ForeColor =
                Color.FromArgb(75, 90, 110);

            dgvSuppliers.Columns.Add(orderColumn);


            // ==========================================
            // دفع
            // ==========================================

            DataGridViewButtonColumn paymentColumn =
                new DataGridViewButtonColumn();

            paymentColumn.Name = "Payment";
            paymentColumn.HeaderText = "";

            paymentColumn.Text = "دفع";

            paymentColumn.UseColumnTextForButtonValue = true;

            paymentColumn.FillWeight = 65;

            paymentColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            paymentColumn.FlatStyle = FlatStyle.Flat;

            paymentColumn.DefaultCellStyle.BackColor =
                Color.White;

            paymentColumn.DefaultCellStyle.SelectionBackColor =
                Color.White;

            paymentColumn.DefaultCellStyle.ForeColor =
                Color.FromArgb(75, 90, 110);

            dgvSuppliers.Columns.Add(paymentColumn);
        }

        #endregion


        #region Load Suppliers

        private void LoadSuppliers()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ContactPerson", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("TotalPurchases", typeof(decimal));
            dt.Columns.Add("Debt", typeof(decimal));
            dt.Columns.Add("LastOrderDate", typeof(DateTime));


            foreach (Supplier supplier in _suppliers)
            {
                dt.Rows.Add(
                    supplier.ID,
                    supplier.Name,
                    supplier.ContactPerson,
                    supplier.Phone,
                    supplier.TotalPurchases,
                    supplier.Debt,
                    supplier.LastOrderDate
                );
            }


            dgvSuppliers.DataSource = dt;
        }

        #endregion


        #region Suppliers Count

        private void UpdateSuppliersCount()
        {
            if (lblNumberOfSuppliers == null)
                return;

            lblNumberOfSuppliers.Text =
                $"{_suppliers.Count} مورد مسجل";
        }

        #endregion


        #region Add Supplier

        private void sbtnAddSupplier_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "سيتم فتح شاشة إضافة مورد جديد.",
                "إضافة مورد",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion


        #region Export Excel

        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات لتصديرها.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            clsGlobalClass.ExportDataGridViewToExcel(
                dgvSuppliers,
                "",
                "قائمة الموردين"
            );
        }

        #endregion


        #region Print

        private void sbtnPrint_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات للطباعة.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            clsGlobalClass.PrintDataGridView(
                dgvSuppliers,
                "قائمة الموردين"
            );
        }

        #endregion


        #region Supplier Count Click

        private void lblNumberOfSuppliers_Click(object sender, EventArgs e)
        {
        }

        #endregion


        #region Cell Formatting

        private void dgvSuppliers_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            // اسم المورد

            if (dgvSuppliers.Columns[e.ColumnIndex].Name ==
                "SupplierName")
            {
                e.CellStyle.Font =
                    new Font("Cairo", 9.5f, FontStyle.Bold);
            }


            // المديونية

            if (dgvSuppliers.Columns[e.ColumnIndex].Name ==
                "Debt")
            {
                if (e.Value != null &&
                    decimal.TryParse(
                        e.Value.ToString(),
                        out decimal debt))
                {
                    if (debt > 0)
                    {
                        e.CellStyle.ForeColor =
                            Color.FromArgb(220, 38, 38);

                        e.CellStyle.Font =
                            new Font("Cairo", 9, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor =
                            Color.FromArgb(145, 160, 180);
                    }
                }
            }
        }

        #endregion


        #region Grid Actions

        private void dgvSuppliers_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;


            DataGridViewRow row =
                dgvSuppliers.Rows[e.RowIndex];


            string supplierName =
                row.Cells["SupplierName"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(supplierName))
                return;


            string columnName =
                dgvSuppliers.Columns[e.ColumnIndex].Name;


            // ==========================================
            // كشف حساب
            // ==========================================

            if (columnName == "Account")
            {
                OpenSupplierStatement(supplierName);

                return;
            }


            // ==========================================
            // طلبية
            // ==========================================

            if (columnName == "Order")
            {
                CreateSupplierOrder(supplierName);

                return;
            }


            // ==========================================
            // دفع
            // ==========================================

            if (columnName == "Payment")
            {
                PaySupplier(supplierName);

                return;
            }
        }

        #endregion


        #region Supplier Statement

        private void OpenSupplierStatement(string supplierName)
        {
            MessageBox.Show(
                $"كشف حساب المورد\n\nالمورد: {supplierName}",
                "كشف حساب",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion


        #region Supplier Order

        private void CreateSupplierOrder(string supplierName)
        {
            MessageBox.Show(
                $"إنشاء طلبية جديدة للمورد\n\nالمورد: {supplierName}",
                "طلبية جديدة",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion


        #region Supplier Payment

        private void PaySupplier(string supplierName)
        {
            DataGridViewRow selectedRow =
                dgvSuppliers
                    .Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(
                        r =>
                            r.Cells["SupplierName"]
                             .Value?
                             .ToString() == supplierName
                    );


            if (selectedRow == null)
                return;


            decimal debt = 0;


            if (selectedRow.Cells["Debt"].Value != null)
            {
                decimal.TryParse(
                    selectedRow.Cells["Debt"].Value.ToString(),
                    out debt
                );
            }


            if (debt <= 0)
            {
                MessageBox.Show(
                    "لا توجد مديونية على هذا المورد.",
                    "الدفع",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }


            MessageBox.Show(
                $"المورد: {supplierName}\n\n" +
                $"المديونية الحالية: {debt:N0} ج",
                "دفع مستحقات المورد",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion
    }
}