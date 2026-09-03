using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucCustomers : SabraUserControl // بافتراض أن SabraUserControl يرث من UserControl
    {
        public ucCustomers()
        {
            InitializeComponent();
        }

        private void ucCustomers_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadMockData();
        }

        private void SetupDataGridView()
        {
            dgvCustomers.Columns.Clear();
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RightToLeft = RightToLeft.Yes;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.RowTemplate.Height = 45; // ارتفاع مناسب للبيانات والأزرار
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // 1. بناء أعمدة البيانات
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "CustomerName", HeaderText = "اسم العميل", DataPropertyName = "CustomerName" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "التليفون", DataPropertyName = "Phone" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "CustomerType", HeaderText = "نوع العميل", DataPropertyName = "CustomerType" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalPurchases", HeaderText = "إجمالي المشتريات", DataPropertyName = "TotalPurchases" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "DebitBalance", HeaderText = "الرصيد المدين", DataPropertyName = "DebitBalance" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreditLimit", HeaderText = "الحد الائتماني", DataPropertyName = "CreditLimit" });

            // 2. بناء أعمدة الإجراءات (أزرار)
            dgvCustomers.Columns.Add(new DataGridViewButtonColumn { Name = "btnStatement", HeaderText = "", Text = "كشف حساب", UseColumnTextForButtonValue = true, Width = 80, FlatStyle = FlatStyle.Flat });
            dgvCustomers.Columns.Add(new DataGridViewButtonColumn { Name = "btnInvoice", HeaderText = "الإجراءات", Text = "فاتورة", UseColumnTextForButtonValue = true, Width = 70, FlatStyle = FlatStyle.Flat });
            dgvCustomers.Columns.Add(new DataGridViewButtonColumn { Name = "btnPayment", HeaderText = "", Text = "+ دفعة", UseColumnTextForButtonValue = true, Width = 70, FlatStyle = FlatStyle.Flat });

            // ربط حدث التنسيق
            dgvCustomers.CellFormatting += dgvCustomers_CellFormatting;
        }

        private void LoadMockData()
        {
            var mockData = new List<CustomerMockDTO>
            {
                new CustomerMockDTO { CustomerName = "ورشة النيل", Phone = "01012345678", CustomerType = "ورشة", TotalPurchases = "45,200 ج", DebitBalance = "0 ج", CreditLimit = "10,000 ج" },
                new CustomerMockDTO { CustomerName = "ورشة الأمل", Phone = "01098765432", CustomerType = "ورشة", TotalPurchases = "28,600 ج", DebitBalance = "7,600 ج", CreditLimit = "15,000 ج" },
                new CustomerMockDTO { CustomerName = "مؤسسة الجوهرة", Phone = "01155556666", CustomerType = "شركة", TotalPurchases = "89,400 ج", DebitBalance = "5,800 ج", CreditLimit = "50,000 ج" }
            };

            dgvCustomers.DataSource = mockData;
        }

        private void dgvCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string columnName = dgvCustomers.Columns[e.ColumnIndex].Name;

            // تنسيق الرصيد المدين (أحمر إذا كان عليه ديون، رمادي باهت إذا كان صفر)
            if (columnName == "DebitBalance")
            {
                string valueStr = e.Value.ToString();
                if (valueStr != "0 ج")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgvCustomers.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Silver;
                }
            }

            // تنسيق نوع العميل لمحاكاة شكل الـ Badge
            if (columnName == "CustomerType")
            {
                e.CellStyle.ForeColor = Color.RoyalBlue;
                e.CellStyle.Font = new Font(dgvCustomers.Font, FontStyle.Bold);
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // تجاهل الضغط على الهيدر
            if (e.RowIndex >= 0 && dgvCustomers.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string columnName = dgvCustomers.Columns[e.ColumnIndex].Name;
                string customerName = dgvCustomers.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();

                // التعامل مع الأزرار
                if (columnName == "btnStatement")
                {
                    MessageBox.Show($"سيتم فتح كشف حساب العميل: {customerName}", "إجراء", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (columnName == "btnInvoice")
                {
                    MessageBox.Show($"سيتم إنشاء فاتورة للعميل: {customerName}", "إجراء", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (columnName == "btnPayment")
                {
                    MessageBox.Show($"سيتم إضافة دفعة للعميل: {customerName}", "إجراء", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void sbtnPrint_Click(object sender, EventArgs e) {
            clsGlobalClass.PrintDataGridView(dgvCustomers,"");
        }

        private void sbtnExportAsExcel_Click(object sender, EventArgs e) {
            clsGlobalClass.ExportDataGridViewToExcel(dgvCustomers,"fada","dsaf");
        }

        private void sbtnAddCustomer_Click(object sender, EventArgs e) { /* فتح شاشة إضافة عميل */ }
        private void lblNumberAndtheSupplierOfTheOrder_Click(object sender, EventArgs e) { }
    }

    // كلاس بسيط لتمثيل البيانات المؤقتة
    public class CustomerMockDTO
    {
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string CustomerType { get; set; }
        public string TotalPurchases { get; set; }
        public string DebitBalance { get; set; }
        public string CreditLimit { get; set; }
    }
}