using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucGoodsReceipt : SabraUserControl
    {
        private BindingList<ReceiptItemModel> _receiptItems;
        private bool _isSaved = false;

        public ucGoodsReceipt()
        {
            InitializeComponent();

            // مهم حتى لا يتكرر تحميل الصفحة أكثر من مرة
            this.Load += ucGoodsReceipt_Load;
        }

        #region Load

        private void ucGoodsReceipt_Load(object sender, EventArgs e)
        {
            InitializeReceipt();
        }

        private void InitializeReceipt()
        {
            SetupHeader();
            SetupDataGridView();
            LoadMockData();
            SetupButtons();

            CalculateReceiptSummary();
        }

        #endregion

        #region Header

        private void SetupHeader()
        {
            // بيانات وهمية للتجربة
            lblNewPurchaseOrderNumber.Text = "PO-20260901-230";
            lblNewPurchaseOrderSupplier.Text = "شركة النصر لقطع الغيار";
            lblNewPurchaseOrderReciveDate.Text =
                DateTime.Now.ToString("yyyy-MM-dd");

            // لو عندك Labels إضافية للترويسة تقدر تضيفها هنا
            // مثال:
            // lblReceiptNumber.Text = "GR-20260901-001";
            // lblEmployee.Text = "محمد أحمد";
            // lblStatus.Text = "قيد الاستلام";
        }

        #endregion

        #region DataGridView Setup

        private void SetupDataGridView()
        {
            if (dgvPurchaseOrderDetails == null)
                return;

            dgvPurchaseOrderDetails.DataSource = null;
            dgvPurchaseOrderDetails.Columns.Clear();

            dgvPurchaseOrderDetails.AutoGenerateColumns = false;
            dgvPurchaseOrderDetails.AllowUserToAddRows = false;
            dgvPurchaseOrderDetails.AllowUserToDeleteRows = false;
            dgvPurchaseOrderDetails.AllowUserToResizeRows = false;

            dgvPurchaseOrderDetails.RowHeadersVisible = false;

            dgvPurchaseOrderDetails.SelectionMode =
                DataGridViewSelectionMode.CellSelect;

            dgvPurchaseOrderDetails.MultiSelect = false;

            dgvPurchaseOrderDetails.EditMode =
                DataGridViewEditMode.EditOnKeystrokeOrF2;

            dgvPurchaseOrderDetails.RightToLeft =
                RightToLeft.Yes;

            dgvPurchaseOrderDetails.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPurchaseOrderDetails.RowTemplate.Height = 45;

            dgvPurchaseOrderDetails.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvPurchaseOrderDetails.DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            dgvPurchaseOrderDetails.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvPurchaseOrderDetails.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            dgvPurchaseOrderDetails.ColumnHeadersHeight = 48;

            // منع تغيير حجم الأعمدة
            foreach (DataGridViewColumn column in dgvPurchaseOrderDetails.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            #region Item Name

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ItemName",
                    HeaderText = "اسم القطعة",
                    DataPropertyName = "ItemName",
                    ReadOnly = true,
                    FillWeight = 30
                });

            #endregion

            #region Required Quantity

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "RequiredQuantity",
                    HeaderText = "الكمية المطلوبة",
                    DataPropertyName = "RequiredQuantity",
                    ReadOnly = true,
                    FillWeight = 14
                });

            #endregion

            #region Previously Received

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "PreviouslyReceived",
                    HeaderText = "المستلم سابقاً",
                    DataPropertyName = "PreviouslyReceived",
                    ReadOnly = true,
                    FillWeight = 14
                });

            #endregion

            #region Remaining Quantity

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "RemainingQuantity",
                    HeaderText = "المتبقي",
                    DataPropertyName = "RemainingQuantity",
                    ReadOnly = true,
                    FillWeight = 14
                });

            #endregion

            #region Received Today

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ReceivedToday",
                    HeaderText = "الكمية المستلمة اليوم",
                    DataPropertyName = "ReceivedToday",
                    ReadOnly = false,
                    FillWeight = 18
                });

            #endregion

            #region Note

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Note",
                    HeaderText = "ملاحظة",
                    DataPropertyName = "Note",
                    ReadOnly = false,
                    FillWeight = 20
                });

            #endregion

            dgvPurchaseOrderDetails.CellValidating -=
                dgvPurchaseOrderDetails_CellValidating;

            dgvPurchaseOrderDetails.CellValidating +=
                dgvPurchaseOrderDetails_CellValidating;

            dgvPurchaseOrderDetails.CellValueChanged -=
                dgvPurchaseOrderDetails_CellValueChanged;

            dgvPurchaseOrderDetails.CellValueChanged +=
                dgvPurchaseOrderDetails_CellValueChanged;

            dgvPurchaseOrderDetails.DataError -=
                dgvPurchaseOrderDetails_DataError;

            dgvPurchaseOrderDetails.DataError +=
                dgvPurchaseOrderDetails_DataError;
        }

        #endregion

        #region Mock Data

        private void LoadMockData()
        {
            _receiptItems = new BindingList<ReceiptItemModel>
            {
                new ReceiptItemModel
                {
                    ItemId = 1,
                    ItemName = "فلتر زيت تويوتا OC90",
                    RequiredQuantity = 30,
                    PreviouslyReceived = 0,
                    ReceivedToday = 30,
                    Note = ""
                },

                new ReceiptItemModel
                {
                    ItemId = 2,
                    ItemName = "فلتر صالون هيونداي SP45",
                    RequiredQuantity = 20,
                    PreviouslyReceived = 0,
                    ReceivedToday = 18,
                    Note = "2 ناقصين"
                },

                new ReceiptItemModel
                {
                    ItemId = 3,
                    ItemName = "تيل فرامل أمامي تويوتا",
                    RequiredQuantity = 15,
                    PreviouslyReceived = 5,
                    ReceivedToday = 10,
                    Note = ""
                },

                new ReceiptItemModel
                {
                    ItemId = 4,
                    ItemName = "بوجيه NGK BKR6E",
                    RequiredQuantity = 50,
                    PreviouslyReceived = 25,
                    ReceivedToday = 20,
                    Note = "متبقي 5"
                },

                new ReceiptItemModel
                {
                    ItemId = 5,
                    ItemName = "سير دينامو هيونداي",
                    RequiredQuantity = 10,
                    PreviouslyReceived = 0,
                    ReceivedToday = 10,
                    Note = ""
                },

                new ReceiptItemModel
                {
                    ItemId = 6,
                    ItemName = "فلتر هواء نيسان صني",
                    RequiredQuantity = 25,
                    PreviouslyReceived = 10,
                    ReceivedToday = 15,
                    Note = ""
                }
            };

            foreach (var item in _receiptItems)
            {
                item.CalculateRemaining();
            }

            dgvPurchaseOrderDetails.DataSource = _receiptItems;
        }

        #endregion

        #region Buttons

        private void SetupButtons()
        {
            // لا يوجد شيء إجباري هنا.
            // الأحداث مرتبطة من الـ Designer بالأسماء الموجودة عندك.
        }

        #endregion

        #region Grid Validation

        private void dgvPurchaseOrderDetails_CellValidating(
            object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvPurchaseOrderDetails.Columns[e.ColumnIndex].Name !=
                "ReceivedToday")
                return;

            string value = e.FormattedValue?.ToString()?.Trim();

            if (string.IsNullOrWhiteSpace(value))
            {
                e.Cancel = true;

                MessageBox.Show(
                    "يجب إدخال الكمية المستلمة.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(value, out int quantity))
            {
                e.Cancel = true;

                MessageBox.Show(
                    "الكمية يجب أن تكون رقمًا صحيحًا.",
                    "قيمة غير صحيحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (quantity < 0)
            {
                e.Cancel = true;

                MessageBox.Show(
                    "لا يمكن أن تكون الكمية أقل من صفر.",
                    "قيمة غير صحيحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var item =
                dgvPurchaseOrderDetails.Rows[e.RowIndex]
                .DataBoundItem as ReceiptItemModel;

            if (item == null)
                return;

            int maxAllowed =
                item.RequiredQuantity -
                item.PreviouslyReceived;

            if (quantity > maxAllowed)
            {
                e.Cancel = true;

                MessageBox.Show(
                    $"الكمية المستلمة لا يمكن أن تتجاوز الكمية المتبقية.\n\n" +
                    $"الكمية المطلوبة: {item.RequiredQuantity}\n" +
                    $"المستلم سابقاً: {item.PreviouslyReceived}\n" +
                    $"المتبقي: {maxAllowed}",
                    "كمية غير صحيحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvPurchaseOrderDetails_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvPurchaseOrderDetails.Columns[e.ColumnIndex].Name !=
                "ReceivedToday")
                return;

            var item =
                dgvPurchaseOrderDetails.Rows[e.RowIndex]
                .DataBoundItem as ReceiptItemModel;

            if (item == null)
                return;

            item.CalculateRemaining();

            CalculateReceiptSummary();
        }

        private void dgvPurchaseOrderDetails_DataError(
            object sender,
            DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            MessageBox.Show(
                "حدث خطأ في قيمة تم إدخالها داخل الجدول.",
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        #endregion

        #region Receipt Calculations

        private void CalculateReceiptSummary()
        {
            if (_receiptItems == null)
                return;

            foreach (var item in _receiptItems)
            {
                item.CalculateRemaining();
            }

            // لو عندك Labels للملخص تقدر تعرض البيانات فيها هنا.
            //
            // مثال:
            //
            // lblTotalItems.Text =
            //     _receiptItems.Count.ToString();
            //
            // lblTotalRequired.Text =
            //     _receiptItems.Sum(x => x.RequiredQuantity).ToString();
            //
            // lblTotalReceived.Text =
            //     _receiptItems.Sum(x => x.ReceivedToday).ToString();
            //
            // lblTotalRemaining.Text =
            //     _receiptItems.Sum(x => x.RemainingQuantity).ToString();
        }

        #endregion

        #region Save

        private void sabraButton1_Click(object sender, EventArgs e)
        {
            SaveReceipt();
        }

        private void SaveReceipt()
        {
            if (_receiptItems == null ||
                _receiptItems.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد أصناف في أمر الشراء.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // إنهاء أي تعديل حالي في الخلية
            dgvPurchaseOrderDetails.EndEdit();

            // تحديث البيانات
            CalculateReceiptSummary();

            // التحقق من الكميات
            foreach (var item in _receiptItems)
            {
                int maxAllowed =
                    item.RequiredQuantity -
                    item.PreviouslyReceived;

                if (item.ReceivedToday < 0)
                {
                    MessageBox.Show(
                        $"الكمية المستلمة للصنف:\n{item.ItemName}\nغير صحيحة.",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (item.ReceivedToday > maxAllowed)
                {
                    MessageBox.Show(
                        $"الكمية المستلمة للصنف:\n{item.ItemName}\n" +
                        $"تتجاوز الكمية المتبقية.",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            int totalReceived =
                _receiptItems.Sum(x => x.ReceivedToday);

            if (totalReceived == 0)
            {
                MessageBox.Show(
                    "لم يتم إدخال أي كمية مستلمة.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حفظ عملية استلام البضاعة؟",
                "تأكيد الاستلام",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            // هنا لاحقاً نربط الـ Business Layer
            // ونحفظ Receipt + ReceiptDetails
            //
            // مثال:
            //
            // clsGoodsReceiptBusiness.Save(...);

            _isSaved = true;

            MessageBox.Show(
                "تم حفظ استلام البضاعة بنجاح.\n" +
                $"إجمالي الكمية المستلمة: {totalReceived}",
                "تم الحفظ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion

        #region Cancel

        private void scbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من إلغاء عملية الاستلام؟\n\n" +
                "سيتم تجاهل التعديلات الحالية.",
                "إلغاء الاستلام",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            ResetReceipt();
        }

        private void ResetReceipt()
        {
            _isSaved = false;

            SetupHeader();
            LoadMockData();
            CalculateReceiptSummary();

            MessageBox.Show(
                "تم إلغاء العملية وإعادة البيانات.",
                "إلغاء",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion

        #region New Purchase Order

        private void sbtnNewPurchaseOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "هل تريد إنشاء عملية استلام جديدة؟\n\n" +
                "سيتم فقد أي تعديلات غير محفوظة.",
                "عملية استلام جديدة",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            _isSaved = false;

            // Mock Order جديد
            lblNewPurchaseOrderNumber.Text =
                "PO-" + DateTime.Now.ToString("yyyyMMdd-HHmm");

            lblNewPurchaseOrderSupplier.Text =
                "شركة الأمل لقطع الغيار";

            lblNewPurchaseOrderReciveDate.Text =
                DateTime.Now.ToString("yyyy-MM-dd");

            LoadNewMockData();

            MessageBox.Show(
                "تم إنشاء عملية استلام جديدة.",
                "عملية جديدة",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void LoadNewMockData()
        {
            _receiptItems = new BindingList<ReceiptItemModel>
            {
                new ReceiptItemModel
                {
                    ItemId = 101,
                    ItemName = "فلتر بنزين كيا سيراتو",
                    RequiredQuantity = 20,
                    PreviouslyReceived = 0,
                    ReceivedToday = 20,
                    Note = ""
                },

                new ReceiptItemModel
                {
                    ItemId = 102,
                    ItemName = "تيل فرامل خلفي كيا",
                    RequiredQuantity = 15,
                    PreviouslyReceived = 0,
                    ReceivedToday = 12,
                    Note = "3 ناقصين"
                },

                new ReceiptItemModel
                {
                    ItemId = 103,
                    ItemName = "فلتر زيت شيفروليه",
                    RequiredQuantity = 30,
                    PreviouslyReceived = 10,
                    ReceivedToday = 20,
                    Note = ""
                }
            };

            foreach (var item in _receiptItems)
            {
                item.CalculateRemaining();
            }

            dgvPurchaseOrderDetails.DataSource = _receiptItems;

            CalculateReceiptSummary();
        }

        #endregion

        #region Export

        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseOrderDetails.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات لتصديرها.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                dgvPurchaseOrderDetails.EndEdit();

                clsGlobalClass.ExportDataGridViewToExcel(
                    dgvPurchaseOrderDetails,
                    "GoodsReceipt",
                    "تقرير استلام البضائع");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تصدير البيانات.\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Print

        private void sbtnPrint_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseOrderDetails.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات للطباعة.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                dgvPurchaseOrderDetails.EndEdit();

                clsGlobalClass.PrintDataGridView(
                    dgvPurchaseOrderDetails,
                    "تقرير استلام البضائع");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء الطباعة.\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Existing Events

        private void lblNumberAndtheSupplierOfTheOrder_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblNewPurchaseOrderNumber_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblNewPurchaseOrderSupplier_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblNewPurchaseOrderReciveDate_Click(
            object sender,
            EventArgs e)
        {
        }

        private void dgvPurchaseOrderDetails_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        #endregion
    }

    #region Receipt Item Model

    public class ReceiptItemModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int RequiredQuantity { get; set; }

        public int PreviouslyReceived { get; set; }

        public int RemainingQuantity { get; set; }

        public int ReceivedToday { get; set; }

        public string Note { get; set; }

        public void CalculateRemaining()
        {
            RemainingQuantity =
                Math.Max(
                    0,
                    RequiredQuantity -
                    PreviouslyReceived -
                    ReceivedToday);
        }
    }

    #endregion
}
