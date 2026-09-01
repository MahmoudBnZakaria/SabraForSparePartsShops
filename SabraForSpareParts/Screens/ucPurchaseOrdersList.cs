using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucPurchaseOrdersList : SabraUserControl // تأكد من وراثة الكنترول الصحيح لمشروعك
    {
        public ucPurchaseOrdersList()
        {
            InitializeComponent();

            // ربط حدث التنسيق لتلوين الخلايا (الحالة والمتبقي)
            if (dgvPurchaseOrdars != null)
            {
                dgvPurchaseOrdars.CellFormatting += DgvPurchaseOrdars_CellFormatting;
            }
        }

        private void ucPurchaseOrdersList_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadMockData();
        }

        // إعداد أعمدة الجدول برمجياً لتطابق الصورة
        private void SetupDataGridView()
        {
            dgvPurchaseOrdars.AutoGenerateColumns = false;
            dgvPurchaseOrdars.Columns.Clear();
            dgvPurchaseOrdars.AllowUserToAddRows = false;
            dgvPurchaseOrdars.RowTemplate.Height = 40;
            dgvPurchaseOrdars.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchaseOrdars.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPurchaseOrdars.Columns.Add(new DataGridViewTextBoxColumn { Name = "PONumber", HeaderText = "رقم أمر الشراء", DataPropertyName = "PONumber", Width = 120 });
            dgvPurchaseOrdars.Columns.Add(new DataGridViewTextBoxColumn { Name = "Supplier", HeaderText = "المورد", DataPropertyName = "Supplier", Width = 180 });
            dgvPurchaseOrdars.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "التاريخ", DataPropertyName = "Date", Width = 120 });
            dgvPurchaseOrdars.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "الإجمالي", DataPropertyName = "TotalFormatted", Width = 120 });
            dgvPurchaseOrdars.Columns.Add(new DataGridViewTextBoxColumn { Name = "Paid", HeaderText = "المدفوع", DataPropertyName = "PaidFormatted", Width = 120 });

            // عمود المتبقي سيتم تلوينه في حدث CellFormatting
            dgvPurchaseOrdars.Columns.Add(new DataGridViewTextBoxColumn { Name = "Remaining", HeaderText = "المتبقي", DataPropertyName = "RemainingFormatted", Width = 120 });

            // عمود الحالة سيتم تلوينه أيضاً
            dgvPurchaseOrdars.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "الحالة", DataPropertyName = "Status", Width = 120 });

            // أزرار الإجراءات
            dgvPurchaseOrdars.Columns.Add(new DataGridViewButtonColumn { Name = "btnView", HeaderText = "الإجراءات", Text = "عرض", UseColumnTextForButtonValue = true, Width = 60 });
            dgvPurchaseOrdars.Columns.Add(new DataGridViewButtonColumn { Name = "btnReceive", HeaderText = "", Text = "استلام", UseColumnTextForButtonValue = true, Width = 60 });
            dgvPurchaseOrdars.Columns.Add(new DataGridViewButtonColumn { Name = "btnPay", HeaderText = "", Text = "دفع", UseColumnTextForButtonValue = true, Width = 60 });
        }

        // تعبئة الجدول بالبيانات الوهمية المطابقة للصورة
        private void LoadMockData()
        {
            var mockData = new List<PurchaseOrderModel>
            {
                new PurchaseOrderModel { PONumber = "PO-0045", Supplier = "شركة بوش مصر", Date = "10/1/2025", Total = 15200, Paid = 0, Remaining = 15200, Status = "مستلم بالكامل" },
                new PurchaseOrderModel { PONumber = "PO-0044", Supplier = "مورد NGK", Date = "8/1/2025", Total = 8400, Paid = 5000, Remaining = 3400, Status = "جزئي" },
                new PurchaseOrderModel { PONumber = "PO-0043", Supplier = "المستورد العربي", Date = "2/1/2025", Total = 22000, Paid = 22000, Remaining = 0, Status = "مسدد" }
            };

            dgvPurchaseOrdars.DataSource = mockData;
            lblNumberOfInvoices_Click(null, null); // تحديث العدد كمثال
        }

        // تلوين الحالات والأرقام المتبقية بناءً على القيمة
        private void DgvPurchaseOrdars_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string columnName = dgvPurchaseOrdars.Columns[e.ColumnIndex].Name;
            var row = dgvPurchaseOrdars.Rows[e.RowIndex];
            string status = row.Cells["Status"].Value?.ToString();

            // إخفاء زري "دفع" و "استلام" إذا كانت الحالة "مسدد"
            if ((columnName == "btnPay" || columnName == "btnReceive") && status == "مسدد")
            {
                e.Value = ""; // إخفاء النص لتقليل التشويش البصري
            }

            // تلوين عمود المتبقي
            if (columnName == "Remaining")
            {
                string remainingText = e.Value.ToString();
                if (remainingText.Contains("15,200"))
                    e.CellStyle.ForeColor = Color.Red;
                else if (remainingText.Contains("3,400"))
                    e.CellStyle.ForeColor = Color.DarkOrange;
                else
                    e.CellStyle.ForeColor = Color.Black;

                e.CellStyle.Font = new Font(dgvPurchaseOrdars.Font, FontStyle.Bold);
            }

            // تلوين عمود الحالة
            if (columnName == "Status")
            {
                e.CellStyle.Font = new Font(dgvPurchaseOrdars.Font, FontStyle.Bold);

                if (e.Value.ToString() == "مستلم بالكامل" || e.Value.ToString() == "مسدد")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                else if (e.Value.ToString() == "جزئي")
                {
                    e.CellStyle.BackColor = Color.Moccasin;
                    e.CellStyle.ForeColor = Color.DarkOrange;
                }
            }
        }

        // تفاعل المستخدم مع أزرار الجدول (عرض، استلام، دفع)
        private void dgvPurchaseOrdars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string poNumber = dgvPurchaseOrdars.Rows[e.RowIndex].Cells["PONumber"].Value.ToString();
                string status = dgvPurchaseOrdars.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                string colName = dgvPurchaseOrdars.Columns[e.ColumnIndex].Name;

                if (colName == "btnView")
                {
                    MessageBox.Show($"عرض تفاصيل الأمر: {poNumber}", "عرض", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (colName == "btnReceive" && status != "مسدد")
                {
                    MessageBox.Show($"جاري استلام بضاعة الأمر: {poNumber}", "استلام", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else if (colName == "btnPay" && status != "مسدد")
                {
                    MessageBox.Show($"فتح شاشة الدفع للأمر: {poNumber}", "دفع", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        // أحداث الأزرار العلوية
        private void sbtnPrint_Click(object sender, EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(dgvPurchaseOrdars, "قائمة أوامر الشراء");
        }

        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            clsGlobalClass.ExportDataGridViewToExcel(dgvPurchaseOrdars,"PO", "قائمة أوامر الشراء");
        }

        private void sbtnNewPurchaseOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("فتح شاشة أمر شراء جديد...", "جديد", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblNumberOfInvoices_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseOrdars != null && dgvPurchaseOrdars.Rows.Count > 0)
            {
                // إذا كان اللابيل موجودًا، حدث النص الخاص به
                // lblNumberOfInvoices.Text = $"عدد الفواتير: {dgvPurchaseOrdars.Rows.Count}";
            }
        }
    }

    // نموذج البيانات الوهمية (Mock Model)
    public class PurchaseOrderModel
    {
        public string PONumber { get; set; }
        public string Supplier { get; set; }
        public string Date { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Remaining { get; set; }
        public string Status { get; set; }

        // خصائص مساعدة لتنسيق الأرقام مع علامة الجنيه "ج"
        public string TotalFormatted => Total > 0 ? $"{Total:N0} ج" : "0";
        public string PaidFormatted => Paid > 0 ? $"{Paid:N0} ج" : "0 ج";
        public string RemainingFormatted => Remaining > 0 ? $"{Remaining:N0} ج" : "0";
    }
}