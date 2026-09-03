using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucCustomerStatement : SabraUserControl
    {
        public ucCustomerStatement()
        {
            InitializeComponent();
            // ربط حدث التحميل إذا لم يكن مربوطاً في الـ Designer
            this.Load += ucCustomerStatement_Load;
        }

        private void ucCustomerStatement_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadMockData();
        }

        private void SetupDataGridView()
        {
            dgvCustomerStatement.Columns.Clear();
            dgvCustomerStatement.AutoGenerateColumns = false;
            dgvCustomerStatement.AllowUserToAddRows = false;

            dgvCustomerStatement.ReadOnly = false;

            dgvCustomerStatement.RightToLeft = RightToLeft.Yes;
            dgvCustomerStatement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCustomerStatement.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvCustomerStatement.RowTemplate.Height = 45;
            dgvCustomerStatement.BackgroundColor = Color.White;
            dgvCustomerStatement.BorderStyle = BorderStyle.None;
            dgvCustomerStatement.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomerStatement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;


            // بناء الأعمدة بناءً على Screenshot_74.png
            dgvCustomerStatement.Columns.Add(new DataGridViewTextBoxColumn { Name = "InvoiceNo", HeaderText = "رقم الفاتورة", DataPropertyName = "InvoiceNo" });
            dgvCustomerStatement.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "التاريخ", DataPropertyName = "Date" });
            dgvCustomerStatement.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "الإجمالي", DataPropertyName = "Total" });
            dgvCustomerStatement.Columns.Add(new DataGridViewTextBoxColumn { Name = "Paid", HeaderText = "المدفوع", DataPropertyName = "Paid" });
            dgvCustomerStatement.Columns.Add(new DataGridViewTextBoxColumn { Name = "Remaining", HeaderText = "المتبقي", DataPropertyName = "Remaining" });
            dgvCustomerStatement.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "الحالة", DataPropertyName = "Status" });

            // زر الإجراءات (عرض)
            dgvCustomerStatement.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "btnView",
                HeaderText = "الإجراءات",
                Text = "عرض",
                UseColumnTextForButtonValue = true,
                Width = 80,
                FlatStyle = FlatStyle.Flat
            });

            dgvCustomerStatement.CellFormatting += dgvCustomerStatement_CellFormatting;
        }

        private void LoadMockData()
        {
            // بيانات وهمية مطابقة للصورة
            var mockData = new List<StatementMockDTO>
            {
                new StatementMockDTO { InvoiceNo = "INV-1084", Date = "15/1/2025", Total = "3,200 ج", Paid = "3,200 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" },
                new StatementMockDTO { InvoiceNo = "INV-1065", Date = "2/1/2025", Total = "1,800 ج", Paid = "1,800 ج", Remaining = "0", Status = "مسدد" }
            };

            dgvCustomerStatement.DataSource = mockData;

            // تحديث الـ Labels الوهمية لتبدو الشاشة متكاملة
            lblCustomerName.Text = "اسم العميل: ورشة النيل";
            lblNumberOfInvoices.Text = $"عدد الفواتير: {mockData.Count}";
            lblTotalPurchases.Text = "5,000";
            lblTotalPaid.Text = "5,000";
            lblDebitBalance.Text = "0";
        }

        private void dgvCustomerStatement_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string columnName = dgvCustomerStatement.Columns[e.ColumnIndex].Name;

            // تنسيق حالة الفاتورة (مسدد) باللون الأخضر
            if (columnName == "Status")
            {
                string status = e.Value.ToString();
                if (status == "مسدد")
                {
                    e.CellStyle.ForeColor = Color.MediumSeaGreen;
                    e.CellStyle.Font = new Font(dgvCustomerStatement.Font, FontStyle.Bold);
                }
            }
        }

        private void dgvCustomerStatement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomerStatement.Columns[e.ColumnIndex].Name == "btnView")
            {
                string invoiceNo = dgvCustomerStatement.Rows[e.RowIndex].Cells["InvoiceNo"].Value.ToString();
                MessageBox.Show($"سيتم عرض تفاصيل الفاتورة رقم: {invoiceNo}", "عرض فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sbtnPrint_Click(object sender, EventArgs e)
        {
            // تم افتراض وجود كلاس clsGlobalClass كما ارسلت في الكود
            clsGlobalClass.PrintDataGridView(dgvCustomerStatement, "كشف حساب العميل");
        }

        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            clsGlobalClass.ExportDataGridViewToExcel(dgvCustomerStatement, "ad", "كشف حساب العميل");
        }

        private void sbtnAddNewInvoice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("فتح شاشة إضافة فاتورة جديدة...", "فاتورة جديدة");
        }

        // أحداث الضغط على الـ Labels (يمكن تركها فارغة إذا كانت للعرض فقط)
        private void lblTotalPurchases_Click(object sender, EventArgs e) { }
        private void lblTotalPaid_Click(object sender, EventArgs e) { }
        private void lblDebitBalance_Click(object sender, EventArgs e) { }
        private void lblNumberOfInvoices_Click(object sender, EventArgs e) { }
        private void lblCustomerName_Click(object sender, EventArgs e) { }

        private void sbtnSearch_Click(object sender, EventArgs e)
        {

        }

        private void stbxSearchForSupplier_Load(object sender, EventArgs e)
        {

        }
    }

    // كلاس بسيط لتمثيل بيانات كشف الحساب
    public class StatementMockDTO
    {
        public string InvoiceNo { get; set; }
        public string Date { get; set; }
        public string Total { get; set; }
        public string Paid { get; set; }
        public string Remaining { get; set; }
        public string Status { get; set; }
    }
}