using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucReturns : SabraUserControl
    {
        #region Models & Enums

        private enum PartStatus
        {
            BackToStock, // ترجع للمخزون
            Damaged      // تالفة
        }

        private class ReturnModel
        {
            public string ReturnNumber { get; set; }
            public string InvoiceNumber { get; set; }
            public string CustomerName { get; set; }
            public string PartName { get; set; }
            public int Quantity { get; set; }
            public string Reason { get; set; }
            public PartStatus Status { get; set; }
            public DateTime Date { get; set; }
        }

        #endregion

        #region Fields

        // بيانات وهمية (Mock Data) - في المشروع الحقيقي هتيجي من طبقة البيانات / قاعدة البيانات
        private List<ReturnModel> _allReturns;

        #endregion

        public ucReturns()
        {
            InitializeComponent();
            this.Load += ucReturns_Load;
        }

        private void ucReturns_Load(object sender, EventArgs e)
        {
            LoadMockData();
            SetupGridColumns();
            BindGrid(_allReturns);
        }

        #region Mock Data

        private void LoadMockData()
        {
            _allReturns = new List<ReturnModel>
            {
                new ReturnModel
                {
                    ReturnNumber = "RET-001",
                    InvoiceNumber = "INV-1071",
                    CustomerName = "ورشة النيل",
                    PartName = "فلتر زيت تويوتا",
                    Quantity = 1,
                    Reason = "غلط في الطلب",
                    Status = PartStatus.BackToStock,
                    Date = new DateTime(2025, 1, 11)
                },
                new ReturnModel
                {
                    ReturnNumber = "RET-002",
                    InvoiceNumber = "INV-1065",
                    CustomerName = "محمد علي",
                    PartName = "بوجية NGK",
                    Quantity = 2,
                    Reason = "قطعة تالفة",
                    Status = PartStatus.Damaged,
                    Date = new DateTime(2025, 1, 9)
                },
                new ReturnModel
                {
                    ReturnNumber = "RET-003",
                    InvoiceNumber = "INV-1058",
                    CustomerName = "مؤسسة الجوهرة",
                    PartName = "طقم تيل فرامل",
                    Quantity = 1,
                    Reason = "مقاس غلط",
                    Status = PartStatus.BackToStock,
                    Date = new DateTime(2025, 1, 6)
                },
                new ReturnModel
                {
                    ReturnNumber = "RET-004",
                    InvoiceNumber = "INV-1050",
                    CustomerName = "عميل نقدي",
                    PartName = "بطارية 70 أمبير",
                    Quantity = 1,
                    Reason = "تالفة من المصنع",
                    Status = PartStatus.Damaged,
                    Date = new DateTime(2025, 1, 3)
                }
            };
        }

        #endregion

        #region Grid Setup

        private void SetupGridColumns()
        {
            sdgvReturns.Columns.Clear();
            sdgvReturns.AutoGenerateColumns = false;
            sdgvReturns.RightToLeft = RightToLeft.Yes;
            sdgvReturns.AllowUserToAddRows = false;
            sdgvReturns.AllowUserToDeleteRows = false;
            sdgvReturns.ReadOnly = true;
            sdgvReturns.RowHeadersVisible = false;
            sdgvReturns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sdgvReturns.MultiSelect = false;
            sdgvReturns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            sdgvReturns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colReturnNumber",
                HeaderText = "رقم المرتجع"
            });
            sdgvReturns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colInvoiceNumber",
                HeaderText = "رقم الفاتورة"
            });
            sdgvReturns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCustomer",
                HeaderText = "العميل"
            });
            sdgvReturns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPart",
                HeaderText = "القطعة"
            });
            sdgvReturns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                HeaderText = "الكمية"
            });
            sdgvReturns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colReason",
                HeaderText = "السبب"
            });
            sdgvReturns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "حالة القطعة"
            });
            sdgvReturns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "التاريخ"
            });

            sdgvReturns.CellFormatting += SdgvReturns_CellFormatting;
        }

        private void SdgvReturns_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sdgvReturns.Columns[e.ColumnIndex].Name != "colStatus") return;
            if (e.Value == null) return;

            var text = e.Value.ToString();
            if (text == "ترجع للمخزون")
                e.CellStyle.ForeColor = Color.FromArgb(46, 125, 50);   // أخضر
            else if (text == "تالفة")
                e.CellStyle.ForeColor = Color.FromArgb(211, 47, 47);   // أحمر

            e.CellStyle.Font = new Font(sdgvReturns.Font, FontStyle.Bold);
        }

        private void BindGrid(List<ReturnModel> returns)
        {
            sdgvReturns.Rows.Clear();

            foreach (var ret in returns.OrderByDescending(r => r.Date))
            {
                int rowIndex = sdgvReturns.Rows.Add();
                var row = sdgvReturns.Rows[rowIndex];

                row.Cells["colReturnNumber"].Value = ret.ReturnNumber;
                row.Cells["colInvoiceNumber"].Value = ret.InvoiceNumber;
                row.Cells["colCustomer"].Value = ret.CustomerName;
                row.Cells["colPart"].Value = ret.PartName;
                row.Cells["colQuantity"].Value = ret.Quantity.ToString(CultureInfo.InvariantCulture);
                row.Cells["colReason"].Value = ret.Reason;
                row.Cells["colStatus"].Value = GetStatusText(ret.Status);
                row.Cells["colDate"].Value = ret.Date.ToString("d/M/yyyy", CultureInfo.InvariantCulture);

                row.Tag = ret; // نربط الصف بالكائن الأصلي عشان نستخدمه لو حبينا نعرض تفاصيل
            }
        }

        private string GetStatusText(PartStatus status)
        {
            switch (status)
            {
                case PartStatus.BackToStock: return "ترجع للمخزون";
                case PartStatus.Damaged: return "تالفة";
                default: return "";
            }
        }

        #endregion

        #region Event Handlers

        private void sbtnPrint_Click(object sender, EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(sdgvReturns, "قائمة المرتجعات");
        }

        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            clsGlobalClass.ExportDataGridViewToExcel(
                sdgvReturns,
                "ReturnsList",
                "قائمة المرتجعات");
        }

        private void sbtnAddNewReturn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هيتم فتح شاشة إضافة مرتجع جديد", "إضافة مرتجع",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sdgvReturns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = sdgvReturns.Rows[e.RowIndex];
            var ret = row.Tag as ReturnModel;
            if (ret == null) return;

            MessageBox.Show(
                "مرتجع رقم " + ret.ReturnNumber +
                "\nالفاتورة: " + ret.InvoiceNumber +
                "\nالعميل: " + ret.CustomerName +
                "\nالقطعة: " + ret.PartName + " (الكمية: " + ret.Quantity + ")" +
                "\nالسبب: " + ret.Reason +
                "\nحالة القطعة: " + GetStatusText(ret.Status),
                "تفاصيل المرتجع",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}