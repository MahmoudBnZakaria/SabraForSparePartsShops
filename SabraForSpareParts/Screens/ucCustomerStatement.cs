using Sabra.DataLayer.Models;
using Sabra.LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucCustomerStatement : SabraUserControl
    {
        #region Fields

        private readonly clsCustomerBusiness _customerBusiness =
            new clsCustomerBusiness();

        private readonly clsSalesInvoiceBusiness _invoiceBusiness =
            new clsSalesInvoiceBusiness();

        private int _customerID;
        private Customer _customer;


        //locks
        private bool _isLoading;
        private bool _isGridConfigured;

        #endregion


        #region View Model

        private sealed class StatementRow
        {
            public int InvoiceNo { get; set; }
            public string Date { get; set; }
            public decimal Total { get; set; }
            public decimal Paid { get; set; }
            public decimal Remaining { get; set; }
            public string Status { get; set; }
        }

        #endregion


        #region Customer Statement Event


        public enum CustomerStatementAction
        {
            NewInvoice,
            ViewInvoice
        }

        public sealed class CustomerStatementEventArgs : EventArgs
        {
            public CustomerStatementAction Action { get; }

            public int CustomerID { get; }

            public int InvoiceID { get; }


            public CustomerStatementEventArgs(
                CustomerStatementAction action,
                int customerID = 0,
                int invoiceID = 0)
            {
                Action = action;
                CustomerID = customerID;
                InvoiceID = invoiceID;
            }
        }

        #endregion

        #region Events

        public event EventHandler<CustomerStatementEventArgs>
            OpenScreenRequested;

        private void RaiseOpenScreenRequested(
            CustomerStatementAction action,
            int customerID = 0,
            int invoiceID = 0)
        {
            OpenScreenRequested?.Invoke(
                this,
                new CustomerStatementEventArgs(
                    action,
                    customerID,
                    invoiceID));
        }

        #endregion


        #region Constructor

        public ucCustomerStatement()
        {
            InitializeComponent();

            this.Load += ucCustomerStatement_Load;
        }

        #endregion


        #region Load

        private void ucCustomerStatement_Load(
            object sender,
            EventArgs e)
        {
            ConfigureDataGridView();
        }

        #endregion


        #region Customer Loading

        public void LoadCustomer(int customerID)
        {
            if (customerID <= 0)
            {
                ShowCustomerNotFound();
                return;
            }

            if (_isLoading)
                return;

            _isLoading = true;

            try
            {
                ConfigureDataGridView();

                _customerID = customerID;

                ClearCustomerData();

                LoadCustomerInfo();
            }
            catch (Exception ex)
            {
                ClearCustomerData();

                MessageBox.Show(
                    "حدث خطأ أثناء تحميل بيانات العميل.\n\n" +
                    ex.Message,
                    "كشف حساب العميل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }
        }

        #endregion


        #region Customer Information

        private void LoadCustomerInfo()
        {
            OperationResult<Customer> result =
                _customerBusiness.GetByID(_customerID);

            if (result == null)
            {
                ShowCustomerNotFound();
                return;
            }

            if (!result.Success)
            {
                MessageBox.Show(
                    result.Message,
                    "كشف حساب العميل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (result.Data == null)
            {
                ShowCustomerNotFound();
                return;
            }

            _customer = result.Data;

            DisplayCustomerInfo();
        }


        private void DisplayCustomerInfo()
        {
            if (_customer == null)
                return;

            lblCustomerName.Text = $"اسم العميل: {_customer.CustomerName}";
            lblDebitBalance.Text = FormatMoney(_customer.TotalBalance);

            var invoicesResult = _invoiceBusiness.GetAll(null, null, _customerID, null, null);

            if (!invoicesResult.Success)
            {
                MessageBox.Show(
                    invoicesResult.Message,
                    "كشف حساب العميل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            List<SalesInvoice> invoices = invoicesResult.Success
                ? invoicesResult.Data ?? new List<SalesInvoice>()
                : new List<SalesInvoice>();

            lblNumberOfInvoices.Text = $"عدد الفواتير: {invoices.Count}";
            lblTotalPurchases.Text = FormatMoney(invoices.Sum(inv => inv.FinalAmount));
            lblTotalPaid.Text = FormatMoney(invoices.Sum(inv => inv.PaidAmount));

            var statementData = invoices
                .Select(inv => new StatementRow
                {
                    InvoiceNo = inv.InvoiceID,
                    Date = inv.DateTime.ToString("yyyy-MM-dd HH:mm"),
                    Total = inv.FinalAmount,
                    Paid = inv.PaidAmount,
                    Remaining = inv.RemainingBalance,
                    Status = inv.PaymentStatus ?? "-"
                })
                .ToList();

            dgvCustomerStatement.DataSource = statementData;
        }
        #endregion


        #region DataGridView

        private void ConfigureDataGridView()
        {
            if (_isGridConfigured)
                return;

            if (dgvCustomerStatement == null)
                return;

            _isGridConfigured = true;

            dgvCustomerStatement.SuspendLayout();

            try
            {
                dgvCustomerStatement.AutoGenerateColumns = false;

                dgvCustomerStatement.AllowUserToAddRows = false;
                dgvCustomerStatement.AllowUserToDeleteRows = false;
                dgvCustomerStatement.ReadOnly = true;

                dgvCustomerStatement.RightToLeft =
                    RightToLeft.Yes;

                dgvCustomerStatement.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvCustomerStatement.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvCustomerStatement.MultiSelect = false;

                dgvCustomerStatement.RowTemplate.Height = 45;

                dgvCustomerStatement.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvCustomerStatement.BackgroundColor =
                    Color.White;

                dgvCustomerStatement.BorderStyle =
                    BorderStyle.None;

                dgvCustomerStatement.CellBorderStyle =
                    DataGridViewCellBorderStyle.SingleHorizontal;

                dgvCustomerStatement.ColumnHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.Single;

                AddGridColumns();

                dgvCustomerStatement.CellFormatting -=
                    dgvCustomerStatement_CellFormatting;

                dgvCustomerStatement.CellFormatting +=
                    dgvCustomerStatement_CellFormatting;

                dgvCustomerStatement.CellContentClick -=
                    dgvCustomerStatement_CellContentClick;

                dgvCustomerStatement.CellContentClick +=
                    dgvCustomerStatement_CellContentClick;
            }
            finally
            {
                dgvCustomerStatement.ResumeLayout();
            }
        }



        private void AddGridColumns()
        {
            dgvCustomerStatement.Columns.Clear();

            dgvCustomerStatement.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "InvoiceNo",
                    HeaderText = "رقم الفاتورة",
                    DataPropertyName = "InvoiceNo"
                });

            dgvCustomerStatement.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Date",
                    HeaderText = "التاريخ",
                    DataPropertyName = "Date"
                });

            dgvCustomerStatement.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    HeaderText = "الإجمالي",
                    DataPropertyName = "Total",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                });

            dgvCustomerStatement.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Paid",
                    HeaderText = "المدفوع",
                    DataPropertyName = "Paid",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                });

            dgvCustomerStatement.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Remaining",
                    HeaderText = "المتبقي",
                    DataPropertyName = "Remaining",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                });

            dgvCustomerStatement.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "الحالة",
                    DataPropertyName = "Status"
                });

            dgvCustomerStatement.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "btnView",
                    HeaderText = "الإجراءات",
                    Text = "عرض",
                    UseColumnTextForButtonValue = true,
                    Width = 150,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    FlatStyle = FlatStyle.Flat
                });
        }

        #endregion


        #region Grid Formatting


        private void dgvCustomerStatement_CellFormatting(
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
                dgvCustomerStatement
                    .Columns[e.ColumnIndex]
                    .Name;

            if (columnName == "Status")
            {
                string status =
                    e.Value.ToString();

                if (status.Contains("بالكامل"))
                {
                    e.CellStyle.ForeColor =
                        Color.MediumSeaGreen;

                    e.CellStyle.Font =
                        new Font(
                            dgvCustomerStatement.Font,
                            FontStyle.Bold);
                }
                else if (status.Contains("جزئي"))
                {
                    e.CellStyle.ForeColor =
                        Color.DarkOrange;

                    e.CellStyle.Font =
                        new Font(
                            dgvCustomerStatement.Font,
                            FontStyle.Bold);
                }
                else if (status.Contains("آجل"))
                {
                    e.CellStyle.ForeColor =
                        Color.Firebrick;

                    e.CellStyle.Font =
                        new Font(
                            dgvCustomerStatement.Font,
                            FontStyle.Bold);
                }
            }

            if (columnName == "Remaining")
            {
                if (decimal.TryParse(
                    e.Value.ToString(),
                    out decimal remaining))
                {
                    if (remaining > 0)
                    {
                        e.CellStyle.ForeColor =
                            Color.Firebrick;

                        e.CellStyle.Font =
                            new Font(
                                dgvCustomerStatement.Font,
                                FontStyle.Bold);
                    }
                }
            }
        }

        #endregion


        #region Grid Actions

        /// <summary>
        /// التعامل مع زر عرض الفاتورة.
        /// </summary>
        private void dgvCustomerStatement_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
            {
                return;
            }

            if (dgvCustomerStatement
                    .Columns[e.ColumnIndex]
                    .Name != "btnView")
            {
                return;
            }

            DataGridViewRow row =
                dgvCustomerStatement.Rows[e.RowIndex];


            object invoiceIDValue =
                row.Cells["InvoiceNo"].Value;

            if (invoiceIDValue == null)
                return;

            if (!int.TryParse(
                invoiceIDValue.ToString(),
                out int invoiceID))
            {
                MessageBox.Show(
                    "رقم الفاتورة غير صالح.",
                    "كشف حساب العميل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (invoiceID <= 0)
                return;

            RaiseOpenScreenRequested(
                CustomerStatementAction.ViewInvoice,
                _customerID,
                invoiceID);
        }

        #endregion


        #region New Invoice

        private void sbtnAddNewInvoice_Click(
            object sender,
            EventArgs e)
        {
            if (_customer == null ||
                _customerID <= 0)
            {
                MessageBox.Show(
                    "لا يوجد عميل محدد.",
                    "فاتورة جديدة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            RaiseOpenScreenRequested(
                CustomerStatementAction.NewInvoice,
                _customerID);
        }

        #endregion


        #region Print / Export

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            if (_customer == null)
            {
                MessageBox.Show(
                    "يرجى اختيار عميل أولًا.",
                    "كشف حساب العميل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                clsGlobalClass.PrintDataGridView(
                    dgvCustomerStatement,
                    $"كشف حساب العميل - {_customer.CustomerName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء الطباعة.\n\n" +
                    ex.Message,
                    "الطباعة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            if (_customer == null)
            {
                MessageBox.Show(
                    "يرجى اختيار عميل أولًا.",
                    "كشف حساب العميل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                clsGlobalClass.ExportDataGridViewToExcel(
                    dgvCustomerStatement,
                    "CustomerStatement",
                    $"كشف حساب العميل - {_customer.CustomerName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تصدير كشف الحساب.\n\n" +
                    ex.Message,
                    "تصدير Excel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion


        #region Search

        private void sbtnSearch_Click(
            object sender,
            EventArgs e)
        {
            /*
             * هذه الشاشة مرتبطة بعميل محدد.
             *
             * لذلك البحث هنا لا يبحث عن العملاء.
             *
             * لاحقًا يمكن استخدامه للبحث داخل
             * كشف حساب العميل بواسطة:
             *
             * - رقم الفاتورة
             * - التاريخ
             * - الحالة
             */
        }

        #endregion


        #region Helpers

        /// <summary>
        /// تنظيف بيانات العميل الحالية.
        /// </summary>
        private void ClearCustomerData()
        {
            _customer = null;

            if (dgvCustomerStatement != null)
                dgvCustomerStatement.DataSource = null;

            lblCustomerName.Text =
                "اسم العميل: -";

            lblNumberOfInvoices.Text =
                "عدد الفواتير: 0";

            lblTotalPurchases.Text =
                "0.00";

            lblTotalPaid.Text =
                "0.00";

            lblDebitBalance.Text =
                "0.00";
        }


        private void ShowCustomerNotFound()
        {
            ClearCustomerData();

            MessageBox.Show(
                "العميل غير موجود.",
                "كشف حساب العميل",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        private string FormatMoney(decimal amount)
        {
            return amount.ToString("N2");
        }

        #endregion


    }

}