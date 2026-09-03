using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucSupplierStatement : SabraUserControl
    {
        #region Model

        private class SupplierOrder
        {
            public int ID { get; set; }

            public string PurchaseOrderNumber { get; set; }

            public DateTime Date { get; set; }

            public decimal Total { get; set; }

            public decimal Paid { get; set; }

            public decimal Remaining
            {
                get
                {
                    return Total - Paid;
                }
            }

            public string Status { get; set; }
        }

        #endregion


        #region Fields

        private List<SupplierOrder> _orders;

        private string _supplierName = "شركة بوش مصر";

        #endregion


        #region Constructor

        public ucSupplierStatement()
        {
            InitializeComponent();

            InitializeOrders();

            ConfigureGrid();

            LoadOrders();

            UpdateStatementSummary();

            dgvSupplierStatement.CellFormatting +=
                dgvSupplierStatement_CellFormatting;

            dgvSupplierStatement.CellContentClick +=
                dgvSupplierStatement_CellContentClick;
        }

        #endregion


        #region Initialize Orders

        private void InitializeOrders()
        {
            _orders = new List<SupplierOrder>
            {
                new SupplierOrder
                {
                    ID = 1,
                    PurchaseOrderNumber = "PO-0045",
                    Date = new DateTime(2025, 1, 10),
                    Total = 15200,
                    Paid = 0,
                    Status = "مستلم بالكامل"
                },

                new SupplierOrder
                {
                    ID = 2,
                    PurchaseOrderNumber = "PO-0043",
                    Date = new DateTime(2025, 1, 2),
                    Total = 22000,
                    Paid = 22000,
                    Status = "مسدد"
                },

                new SupplierOrder
                {
                    ID = 3,
                    PurchaseOrderNumber = "PO-0041",
                    Date = new DateTime(2024, 12, 25),
                    Total = 18500,
                    Paid = 10000,
                    Status = "جزئي"
                },

                new SupplierOrder
                {
                    ID = 4,
                    PurchaseOrderNumber = "PO-0038",
                    Date = new DateTime(2024, 12, 15),
                    Total = 30750,
                    Paid = 30750,
                    Status = "مسدد"
                },

                new SupplierOrder
                {
                    ID = 5,
                    PurchaseOrderNumber = "PO-0034",
                    Date = new DateTime(2024, 12, 3),
                    Total = 12800,
                    Paid = 0,
                    Status = "مستلم بالكامل"
                }
            };
        }

        #endregion


        #region Configure Grid

        private void ConfigureGrid()
        {
            dgvSupplierStatement.AutoGenerateColumns = false;

            dgvSupplierStatement.Columns.Clear();

            dgvSupplierStatement.AllowUserToAddRows = false;
            dgvSupplierStatement.AllowUserToDeleteRows = false;
            dgvSupplierStatement.AllowUserToResizeRows = false;

            dgvSupplierStatement.ReadOnly = true;

            dgvSupplierStatement.MultiSelect = false;

            dgvSupplierStatement.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvSupplierStatement.RowHeadersVisible = false;

            dgvSupplierStatement.RightToLeft =
                RightToLeft.Yes;

            dgvSupplierStatement.BackgroundColor =
                Color.White;

            dgvSupplierStatement.BorderStyle =
                BorderStyle.None;

            dgvSupplierStatement.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvSupplierStatement.GridColor =
                Color.FromArgb(230, 234, 238);

            dgvSupplierStatement.EnableHeadersVisualStyles =
                false;

            dgvSupplierStatement.ColumnHeadersHeight =
                50;

            dgvSupplierStatement.RowTemplate.Height =
                48;


            // ==========================================
            // Header
            // ==========================================

            dgvSupplierStatement.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);

            dgvSupplierStatement.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(40, 50, 65);

            dgvSupplierStatement.ColumnHeadersDefaultCellStyle.Font =
                new Font("Cairo", 10, FontStyle.Bold);

            dgvSupplierStatement.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // ==========================================
            // Cells
            // ==========================================

            dgvSupplierStatement.DefaultCellStyle.BackColor =
                Color.White;

            dgvSupplierStatement.DefaultCellStyle.ForeColor =
                Color.FromArgb(40, 50, 65);

            dgvSupplierStatement.DefaultCellStyle.Font =
                new Font("Cairo", 9.5f);

            dgvSupplierStatement.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvSupplierStatement.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(247, 249, 252);

            dgvSupplierStatement.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(40, 50, 65);


            // ==========================================
            // رقم أمر الشراء
            // ==========================================

            DataGridViewTextBoxColumn purchaseOrderColumn =
                new DataGridViewTextBoxColumn();

            purchaseOrderColumn.Name =
                "PurchaseOrderNumber";

            purchaseOrderColumn.HeaderText =
                "رقم أمر الشراء";

            purchaseOrderColumn.DataPropertyName =
                "PurchaseOrderNumber";

            purchaseOrderColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            purchaseOrderColumn.FillWeight =
                110;

            purchaseOrderColumn.DefaultCellStyle.Font =
                new Font("Cairo", 9.5f, FontStyle.Bold);

            dgvSupplierStatement.Columns.Add(
                purchaseOrderColumn
            );


            // ==========================================
            // التاريخ
            // ==========================================

            DataGridViewTextBoxColumn dateColumn =
                new DataGridViewTextBoxColumn();

            dateColumn.Name = "Date";

            dateColumn.HeaderText =
                "التاريخ";

            dateColumn.DataPropertyName =
                "Date";

            dateColumn.DefaultCellStyle.Format =
                "d/M/yyyy";

            dateColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dateColumn.FillWeight =
                100;

            dgvSupplierStatement.Columns.Add(
                dateColumn
            );


            // ==========================================
            // الإجمالي
            // ==========================================

            DataGridViewTextBoxColumn totalColumn =
                new DataGridViewTextBoxColumn();

            totalColumn.Name =
                "Total";

            totalColumn.HeaderText =
                "الإجمالي";

            totalColumn.DataPropertyName =
                "Total";

            totalColumn.DefaultCellStyle.Format =
                "#,##0 ج";

            totalColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            totalColumn.FillWeight =
                105;

            dgvSupplierStatement.Columns.Add(
                totalColumn
            );


            // ==========================================
            // المدفوع
            // ==========================================

            DataGridViewTextBoxColumn paidColumn =
                new DataGridViewTextBoxColumn();

            paidColumn.Name =
                "Paid";

            paidColumn.HeaderText =
                "المدفوع";

            paidColumn.DataPropertyName =
                "Paid";

            paidColumn.DefaultCellStyle.Format =
                "#,##0 ج";

            paidColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            paidColumn.FillWeight =
                105;

            dgvSupplierStatement.Columns.Add(
                paidColumn
            );


            // ==========================================
            // المتبقي
            // ==========================================

            DataGridViewTextBoxColumn remainingColumn =
                new DataGridViewTextBoxColumn();

            remainingColumn.Name =
                "Remaining";

            remainingColumn.HeaderText =
                "المتبقي";

            remainingColumn.DataPropertyName =
                "Remaining";

            remainingColumn.DefaultCellStyle.Format =
                "#,##0 ج";

            remainingColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            remainingColumn.FillWeight =
                105;

            dgvSupplierStatement.Columns.Add(
                remainingColumn
            );


            // ==========================================
            // الحالة
            // ==========================================

            DataGridViewTextBoxColumn statusColumn =
                new DataGridViewTextBoxColumn();

            statusColumn.Name =
                "Status";

            statusColumn.HeaderText =
                "الحالة";

            statusColumn.DataPropertyName =
                "Status";

            statusColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            statusColumn.FillWeight =
                115;

            dgvSupplierStatement.Columns.Add(
                statusColumn
            );


            // ==========================================
            // عرض
            // ==========================================

            DataGridViewButtonColumn viewColumn =
                new DataGridViewButtonColumn();

            viewColumn.Name =
                "View";

            viewColumn.HeaderText =
                "الإجراءات";

            viewColumn.Text =
                "عرض";

            viewColumn.UseColumnTextForButtonValue =
                true;

            viewColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            viewColumn.FillWeight =
                70;

            viewColumn.FlatStyle =
                FlatStyle.Flat;

            viewColumn.DefaultCellStyle.BackColor =
                Color.White;

            viewColumn.DefaultCellStyle.SelectionBackColor =
                Color.White;

            viewColumn.DefaultCellStyle.ForeColor =
                Color.FromArgb(75, 90, 110);

            dgvSupplierStatement.Columns.Add(
                viewColumn
            );


            // ==========================================
            // دفع
            // ==========================================

            DataGridViewButtonColumn paymentColumn =
                new DataGridViewButtonColumn();

            paymentColumn.Name =
                "Payment";

            paymentColumn.HeaderText =
                "";

            paymentColumn.Text =
                "دفع";

            paymentColumn.UseColumnTextForButtonValue =
                true;

            paymentColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            paymentColumn.FillWeight =
                65;

            paymentColumn.FlatStyle =
                FlatStyle.Flat;

            paymentColumn.DefaultCellStyle.BackColor =
                Color.White;

            paymentColumn.DefaultCellStyle.SelectionBackColor =
                Color.White;

            paymentColumn.DefaultCellStyle.ForeColor =
                Color.FromArgb(75, 90, 110);

            dgvSupplierStatement.Columns.Add(
                paymentColumn
            );
        }

        #endregion


        #region Load Orders

        private void LoadOrders()
        {
            DataTable dt =
                new DataTable();

            dt.Columns.Add(
                "ID",
                typeof(int)
            );

            dt.Columns.Add(
                "PurchaseOrderNumber",
                typeof(string)
            );

            dt.Columns.Add(
                "Date",
                typeof(DateTime)
            );

            dt.Columns.Add(
                "Total",
                typeof(decimal)
            );

            dt.Columns.Add(
                "Paid",
                typeof(decimal)
            );

            dt.Columns.Add(
                "Remaining",
                typeof(decimal)
            );

            dt.Columns.Add(
                "Status",
                typeof(string)
            );


            foreach (SupplierOrder order in _orders)
            {
                dt.Rows.Add(
                    order.ID,
                    order.PurchaseOrderNumber,
                    order.Date,
                    order.Total,
                    order.Paid,
                    order.Remaining,
                    order.Status
                );
            }


            dgvSupplierStatement.DataSource =
                dt;
        }

        #endregion


        #region Update Summary

        private void UpdateStatementSummary()
        {
            decimal totalPurchases =
                _orders.Sum(x => x.Total);

            decimal totalPaid =
                _orders.Sum(x => x.Paid);

            decimal debitBalance =
                _orders.Sum(x => x.Remaining);

            int numberOfOrders =
                _orders.Count;


            // اسم المورد

            if (lblSupplierName != null)
            {
                lblSupplierName.Text =
                    _supplierName;
            }


            // إجمالي المشتريات

            if (lblTotalPurchases != null)
            {
                lblTotalPurchases.Text =
                    $"{totalPurchases:N0} ج";
            }


            // إجمالي المدفوع

            if (lblTotalPaid != null)
            {
                lblTotalPaid.Text =
                    $"{totalPaid:N0} ج";
            }


            // الرصيد المدين

            if (lblDebitBalance != null)
            {
                lblDebitBalance.Text =
                    $"{debitBalance:N0} ج";
            }


            // عدد الطلبيات

            if (lblNumberOfOrdars != null)
            {
                lblNumberOfOrdars.Text =
                    numberOfOrders.ToString("N0");
            }
        }

        #endregion


        #region Labels

        private void lblTotalPurchases_Click(
            object sender,
            EventArgs e)
        {
        }


        private void lblTotalPaid_Click(
            object sender,
            EventArgs e)
        {
        }


        private void lblDebitBalance_Click(
            object sender,
            EventArgs e)
        {
        }


        private void lblNumberOfOrdars_Click(
            object sender,
            EventArgs e)
        {
        }


        private void lblSupplierName_Click(
            object sender,
            EventArgs e)
        {
        }

        #endregion


        #region Panel Paint

        private void sabraPanel2_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        #endregion


        #region Print

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            if (dgvSupplierStatement.Rows.Count == 0)
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
                dgvSupplierStatement,
                $"كشف حساب المورد - {_supplierName}"
            );
        }

        #endregion


        #region Export Excel

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            if (dgvSupplierStatement.Rows.Count == 0)
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
                dgvSupplierStatement,
                "",
                $"كشف حساب المورد - {_supplierName}"
            );
        }

        #endregion


        #region Grid Formatting

        private void dgvSupplierStatement_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            string columnName =
                dgvSupplierStatement
                    .Columns[e.ColumnIndex]
                    .Name;


            // ==========================================
            // المتبقي
            // ==========================================

            if (columnName == "Remaining")
            {
                if (e.Value != null &&
                    decimal.TryParse(
                        e.Value.ToString(),
                        out decimal remaining))
                {
                    if (remaining > 0)
                    {
                        e.CellStyle.ForeColor =
                            Color.FromArgb(220, 38, 38);

                        e.CellStyle.Font =
                            new Font(
                                "Cairo",
                                9,
                                FontStyle.Bold
                            );
                    }
                    else
                    {
                        e.CellStyle.ForeColor =
                            Color.FromArgb(145, 160, 180);
                    }
                }
            }


            // ==========================================
            // الحالة
            // ==========================================

            if (columnName == "Status")
            {
                string status =
                    e.Value?.ToString();


                if (status == "مستلم بالكامل")
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(37, 99, 235);

                    e.CellStyle.BackColor =
                        Color.FromArgb(239, 246, 255);

                    e.CellStyle.Font =
                        new Font(
                            "Cairo",
                            9,
                            FontStyle.Bold
                        );
                }
                else if (status == "مسدد")
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(22, 163, 74);

                    e.CellStyle.BackColor =
                        Color.FromArgb(240, 253, 244);

                    e.CellStyle.Font =
                        new Font(
                            "Cairo",
                            9,
                            FontStyle.Bold
                        );
                }
                else if (status == "جزئي")
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(217, 119, 6);

                    e.CellStyle.BackColor =
                        Color.FromArgb(255, 251, 235);

                    e.CellStyle.Font =
                        new Font(
                            "Cairo",
                            9,
                            FontStyle.Bold
                        );
                }
            }
        }

        #endregion


        #region Grid Actions

        private void dgvSupplierStatement_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;


            DataGridViewRow row =
                dgvSupplierStatement.Rows[e.RowIndex];


            string orderNumber =
                row.Cells["PurchaseOrderNumber"]
                   .Value?
                   .ToString();


            if (string.IsNullOrWhiteSpace(orderNumber))
                return;


            string columnName =
                dgvSupplierStatement
                    .Columns[e.ColumnIndex]
                    .Name;


            // ==========================================
            // عرض أمر الشراء
            // ==========================================

            if (columnName == "View")
            {
                ShowPurchaseOrder(orderNumber);

                return;
            }


            // ==========================================
            // دفع
            // ==========================================

            if (columnName == "Payment")
            {
                PayPurchaseOrder(orderNumber);

                return;
            }
        }

        #endregion


        #region Show Purchase Order

        private void ShowPurchaseOrder(
            string purchaseOrderNumber)
        {
            SupplierOrder order =
                _orders.FirstOrDefault(
                    x =>
                        x.PurchaseOrderNumber ==
                        purchaseOrderNumber
                );


            if (order == null)
                return;


            string message =
                $"أمر الشراء: {order.PurchaseOrderNumber}\n\n" +
                $"المورد: {_supplierName}\n\n" +
                $"التاريخ: {order.Date:d/M/yyyy}\n\n" +
                $"الإجمالي: {order.Total:N0} ج\n\n" +
                $"المدفوع: {order.Paid:N0} ج\n\n" +
                $"المتبقي: {order.Remaining:N0} ج\n\n" +
                $"الحالة: {order.Status}";


            MessageBox.Show(
                message,
                "تفاصيل أمر الشراء",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion


        #region Pay Purchase Order

        private void PayPurchaseOrder(
            string purchaseOrderNumber)
        {
            SupplierOrder order =
                _orders.FirstOrDefault(
                    x =>
                        x.PurchaseOrderNumber ==
                        purchaseOrderNumber
                );


            if (order == null)
                return;


            if (order.Remaining <= 0)
            {
                MessageBox.Show(
                    "هذا الأمر مسدد بالكامل.",
                    "الدفع",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }


            MessageBox.Show(
                $"أمر الشراء: {order.PurchaseOrderNumber}\n\n" +
                $"المورد: {_supplierName}\n\n" +
                $"المبلغ المستحق: {order.Remaining:N0} ج",
                "دفع مستحقات المورد",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion


        #region New Purchase Order

        private void sbtnPurchaseOrder_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                $"إنشاء أمر شراء جديد\n\nالمورد: {_supplierName}",
                "أمر شراء جديد",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion
    }
}