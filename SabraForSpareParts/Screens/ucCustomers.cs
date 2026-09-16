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
    public partial class ucCustomers : SabraUserControl
    {
        #region Fields


        private readonly clsCustomerBusiness _customerBusiness =
            new clsCustomerBusiness();

        private List<Customer> _customers =
            new List<Customer>();

        private bool _isLoading;

        public enum CustomerAction { Add, Statement, Invoice, Payment, Edit }

        public class CustomerEventArgs : EventArgs
        {

            public int CustomerID { get; }

            public CustomerAction Action { get; }
            public CustomerEventArgs(CustomerAction action, int customerID = 0)
            {
                Action = action;
                CustomerID = customerID;
            }
        }
        public event EventHandler<CustomerEventArgs> OpenScreenWithCustomerData;
        #endregion


        #region Constructor

        public ucCustomers()
        {
            InitializeComponent();

            ConfigureDataGridView();
        }

        #endregion


        #region Load

        private void ucCustomers_Load(
            object sender,
            EventArgs e)
        {
            LoadCustomers();
        }

        #endregion


        #region DataGridView Setup

        private void ConfigureDataGridView()
        {
            if (dgvCustomers == null)
                return;


            dgvCustomers.SuspendLayout();

            try
            {
                dgvCustomers.Columns.Clear();

                dgvCustomers.AutoGenerateColumns = false;

                dgvCustomers.AllowUserToAddRows = false;

                dgvCustomers.AllowUserToDeleteRows = false;

                dgvCustomers.ReadOnly = true;

                dgvCustomers.MultiSelect = false;

                dgvCustomers.RightToLeft =
                    RightToLeft.Yes;

                dgvCustomers.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvCustomers.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvCustomers.RowTemplate.Height = 45;

                dgvCustomers.BackgroundColor =
                    Color.White;

                dgvCustomers.BorderStyle =
                    BorderStyle.None;

                dgvCustomers.CellBorderStyle =
                    DataGridViewCellBorderStyle.SingleHorizontal;

                dgvCustomers.ColumnHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.Single;

                dgvCustomers.EnableHeadersVisualStyles = false;

                dgvCustomers.ColumnHeadersHeight = 60;


                // Customer ID
                dgvCustomers.Columns.Add(
                    new DataGridViewTextBoxColumn
                    {
                        Name = "CustomerID",
                        HeaderText = "رقم العميل",
                        DataPropertyName = "CustomerID",
                        FillWeight = 55,
                        Visible = false
                    });


                // اسم العميل
                dgvCustomers.Columns.Add(
                    new DataGridViewTextBoxColumn
                    {
                        Name = "CustomerName",
                        HeaderText = "اسم العميل",
                        DataPropertyName = "CustomerName",
                        FillWeight = 150
                    });


                // الهاتف
                dgvCustomers.Columns.Add(
                    new DataGridViewTextBoxColumn
                    {
                        Name = "Phone",
                        HeaderText = "التليفون",
                        DataPropertyName = "PhoneNumber",
                        FillWeight = 110
                    });


                // نوع العميل
                dgvCustomers.Columns.Add(
                    new DataGridViewTextBoxColumn
                    {
                        Name = "CustomerType",
                        HeaderText = "نوع العميل",
                        DataPropertyName = "CustomerType",
                        FillWeight = 90
                    });


                // الرصيد المدين
                dgvCustomers.Columns.Add(
                    new DataGridViewTextBoxColumn
                    {
                        Name = "DebitBalance",
                        HeaderText = "الرصيد",
                        DataPropertyName = "TotalBalance",
                        FillWeight = 90
                    });


                // الحد الائتماني
                dgvCustomers.Columns.Add(
                    new DataGridViewTextBoxColumn
                    {
                        Name = "CreditLimit",
                        HeaderText = "الحد الائتماني",
                        DataPropertyName = "CreditLimit",
                        FillWeight = 90
                    });


                // آخر دفعة
                dgvCustomers.Columns.Add(
                    new DataGridViewTextBoxColumn
                    {
                        Name = "LastPaymentDate",
                        HeaderText = "آخر دفعة",
                        DataPropertyName = "LastPaymentDate",
                        FillWeight = 90
                    });


                // كشف الحساب
                dgvCustomers.Columns.Add(
                    new DataGridViewButtonColumn
                    {
                        Name = "btnStatement",
                        HeaderText = "الإجراءات",
                        Text = "كشف حساب",
                        UseColumnTextForButtonValue = true,
                        Width = 90,
                        FillWeight = 150,
                        FlatStyle = FlatStyle.Flat
                    });


                // فاتورة
                dgvCustomers.Columns.Add(
                    new DataGridViewButtonColumn
                    {
                        Name = "btnInvoice",
                        HeaderText = "الإجراءات",
                        Text = "فاتورة",
                        UseColumnTextForButtonValue = true,
                        Width = 70,
                        FillWeight = 65,
                        FlatStyle = FlatStyle.Flat
                    });



                dgvCustomers.CellFormatting -=
                    dgvCustomers_CellFormatting;

                dgvCustomers.CellFormatting +=
                    dgvCustomers_CellFormatting;


                dgvCustomers.CellContentClick -=
                    dgvCustomers_CellContentClick;

                dgvCustomers.CellContentClick +=
                    dgvCustomers_CellContentClick;


                dgvCustomers.DataBindingComplete -=
                    dgvCustomers_DataBindingComplete;

                dgvCustomers.DataBindingComplete +=
                    dgvCustomers_DataBindingComplete;
            }
            finally
            {
                dgvCustomers.ResumeLayout();
            }
        }

        #endregion


        #region Load Customers
        private void LoadCustomers()
        {
            if (_isLoading)
                return;

            _isLoading = true;

            try
            {

                OperationResult<List<Customer>> result;

                string searchText = stbxSearchForCustomer.Text.Trim();

                if (!string.IsNullOrEmpty(searchText))
                {
                    result = _customerBusiness.Search(searchText);
                }
                else
                {
                    result = _customerBusiness.GetAll();
                }

                if (result == null)
                {
                    ShowError("تعذر الحصول على بيانات العملاء.");
                    return;
                }

                if (!result.Success)
                {
                    ShowError(result.Message);
                    return;
                }

                _customers = result.Data ?? new List<Customer>();

                if (_customers.Count == 0)
                {
                    lblNumberOfCustomers.Text = "لا يوجد أي عميل مسجل";
                }
                else
                {
                    lblNumberOfCustomers.Text = $"{_customers.Count} عميل مسجل";
                }

                BindCustomers();
            }
            catch (Exception ex)
            {
                ShowError($"حدث خطأ أثناء تحميل العملاء:\n\n{ex.Message}");
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void BindCustomers()
        {
            dgvCustomers.DataSource = null;

            dgvCustomers.DataSource =
                _customers;
        }

        #endregion



        #region DataGrid Formatting

        private void dgvCustomers_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;


            string columnName =
                dgvCustomers
                    .Columns[e.ColumnIndex]
                    .Name;


            // =========================
            // الرصيد
            // =========================

            if (columnName == "DebitBalance")
            {
                decimal balance =
                    GetDecimalValue(e.Value);


                e.Value =
                    $"{balance:N0} ج";


                if (balance > 0)
                {
                    e.CellStyle.ForeColor =
                        Color.Red;

                    e.CellStyle.Font =
                        new Font(
                            dgvCustomers.Font,
                            FontStyle.Bold);
                }
                else if (balance < 0)
                {
                    e.CellStyle.ForeColor =
                        Color.Green;

                    e.CellStyle.Font =
                        new Font(
                            dgvCustomers.Font,
                            FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor =
                        Color.Silver;
                }


                return;
            }


            // =========================
            // الحد الائتماني
            // =========================

            if (columnName == "CreditLimit")
            {
                decimal creditLimit =
                    GetDecimalValue(e.Value);


                if (creditLimit <= 0)
                {
                    e.Value =
                        "غير محدد";

                    e.CellStyle.ForeColor =
                        Color.Gray;
                }
                else
                {
                    e.Value =
                        $"{creditLimit:N0} ج";
                }


                return;
            }


            // =========================
            // آخر دفعة
            // =========================

            if (columnName == "LastPaymentDate")
            {
                if (e.Value == null ||
                    e.Value == DBNull.Value)
                {
                    e.Value =
                        "لا توجد";

                    e.CellStyle.ForeColor =
                        Color.Silver;

                    return;
                }


                if (DateTime.TryParse(
                    e.Value.ToString(),
                    out DateTime date))
                {
                    e.Value =
                        date.ToString(
                            "dd/MM/yyyy");
                }


                return;
            }


            // =========================
            // نوع العميل
            // =========================

            if (columnName == "CustomerType")
            {
                e.CellStyle.ForeColor =
                    Color.RoyalBlue;

                e.CellStyle.Font =
                    new Font(
                        dgvCustomers.Font,
                        FontStyle.Bold);
            }
        }


        private decimal GetDecimalValue(
            object value)
        {
            if (value == null ||
                value == DBNull.Value)
                return 0m;


            if (decimal.TryParse(
                value.ToString(),
                out decimal result))
            {
                return result;
            }


            return 0m;
        }

        #endregion


        #region Data Binding Complete

        private void dgvCustomers_DataBindingComplete(
            object sender,
            DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row
                    in dgvCustomers.Rows)
                {

                    row.Height = 45;
                }
            }
            catch
            {
            }
        }

        #endregion


        #region Grid Buttons

        private void dgvCustomers_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;


            if (!(dgvCustomers.Columns[e.ColumnIndex]
                is DataGridViewButtonColumn))
                return;


            var customer =
                GetCustomerFromRow(e.RowIndex);


            if (customer == null)
                return;


            string columnName =
                dgvCustomers
                    .Columns[e.ColumnIndex]
                    .Name;


            switch (columnName)
            {
                case "btnStatement":

                    OpenCustomerStatement(
                        customer);

                    break;


                case "btnInvoice":

                    CreateCustomerInvoice(
                        customer);

                    break;

            }
        }


        private Customer GetCustomerFromRow(
            int rowIndex)
        {
            if (rowIndex < 0 ||
                rowIndex >= dgvCustomers.Rows.Count)
                return null;


            var row =
                dgvCustomers.Rows[rowIndex];


            return row.DataBoundItem as Customer;
        }

        #endregion



        #region Print

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                clsGlobalClass.PrintDataGridView(
                    dgvCustomers,
                    "العملاء");
            }
            catch (Exception ex)
            {
                ShowError(
                    $"حدث خطأ أثناء الطباعة:\n\n{ex.Message}");
            }
        }

        #endregion


        #region Excel

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                clsGlobalClass.ExportDataGridViewToExcel(
                    dgvCustomers,
                    "العملاء",
                    "Customers");
            }
            catch (Exception ex)
            {
                ShowError(
                    $"حدث خطأ أثناء تصدير البيانات:\n\n{ex.Message}");
            }
        }

        #endregion


        #region Helpers

        private void ShowError(
            string message)
        {
            MessageBox.Show(
                message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        #endregion



        #region Customer Actions

        private void OpenCustomerStatement(
            Customer customer)
        {
            if (customer == null)
                return;

            OpenScreenWithCustomerData?.Invoke(this, new CustomerEventArgs(CustomerAction.Statement, customer.CustomerID));

        }


        private void CreateCustomerInvoice(
            Customer customer)
        {
            if (customer == null)
                return;
            OpenScreenWithCustomerData?.Invoke(this, new CustomerEventArgs(CustomerAction.Invoice, customer.CustomerID));

        }


        #endregion


        #region Add Customer

        private void sbtnAddCustomer_Click(
            object sender,
            EventArgs e)
        {
            OpenScreenWithCustomerData?.Invoke(this, new CustomerEventArgs(CustomerAction.Add, 0));

        }

        #endregion

        private void sbtnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

    }
}

