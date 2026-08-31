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
    /*
     * ============================================================================
     *  ملاحظات مهمة قبل التشغيل (اقرأها الأول يا ريس):
     * ============================================================================
     *  1) أعمدة dgvInvoice بيتم تجهيزها بالكامل من الكود (SetupInvoiceGrid) لأني
     *     معنديش ملف الـ Designer بتاعك. الكود بيمسح أي أعمدة قديمة في الجدول
     *     ويبنيها من جديد، فمفيش تعارض هيحصل حتى لو عندك أعمدة متعرفة في الديزاينر.
     *
     *  2) كل البيانات (القطع - العملاء) دي Mock Data في الذاكرة بس، مفيش اتصال
     *     حقيقي بقاعدة بيانات. لما تيجي تربط المشروع بالداتابيز الحقيقية،
     *     دور على التعليقات اللي كاتب جنبها "TODO".
     *
     *  3) افترضت إن الكنترولز اللي اسمها sabraNumericUpDown... وراثة من
     *     NumericUpDown (يعني عندها خاصية Value, Maximum, Enabled...). لو عندك
     *     نوع مختلف، هتحتاج تظبط الأسطر دي بسيطة.
     *
     *  4) خليت الزرار الافتراضي المحدد عند فتح الشاشة هو "تحويل" عشان يطابق
     *     الاسكرين شوت اللي بعتهولي (كان في الكود الأصلي "كاش").
     * ============================================================================
     */
    public partial class ucNewInvoice : SabraUserControl
    {
        #region أسماء الأعمدة الثابتة في جدول الفاتورة

        private const string COL_INDEX = "colIndex";
        private const string COL_PART_NAME = "colPartName";
        private const string COL_QUANTITY = "colQuantity";
        private const string COL_UNIT_PRICE = "colUnitPrice";
        private const string COL_DISCOUNT = "colDiscount";
        private const string COL_TOTAL = "colTotal";
        private const string COL_DELETE = "colDelete";

        #endregion

        #region متغيرات الحالة

        private string _selectedPaymentMethod = "تحويل";
        private bool _isUpdatingTotals = false;
        private decimal _currentNetTotal = 0;

        private static int _nextMockInvoiceNumber = 1086;

        #endregion

        #region بيانات تجريبية (Mock Data)

        private static readonly List<PartInfo> _mockParts = new List<PartInfo>
        {
            new PartInfo("1001", "فلتر زيت تويوتا كورولا", 45m),
            new PartInfo("1002", "بوجية NGK × 4", 112m),
            new PartInfo("1003", "فلتر هواء رينو لوجان", 65m),
            new PartInfo("1004", "تيل هيدروليك فرامل DOT4", 85m),
            new PartInfo("1005", "زيت فرامل شل DOT3", 60m),
            new PartInfo("1006", "فلتر بنزين هيونداي", 55m),
            new PartInfo("1007", "طقم سير كاتينة", 320m),
            new PartInfo("1008", "بطارية 70 أمبير", 1450m),
        };

        private static readonly List<CustomerInfo> _mockCustomers = new List<CustomerInfo>
        {
            new CustomerInfo("ورشة النيل", "01000000000", 10000m),
            new CustomerInfo("ورشة الأمل", "01111111111", 5000m),
            new CustomerInfo("جراج المهندس", "01222222222", 15000m),
        };

        #endregion

        public ucNewInvoice()
        {
            InitializeComponent();
        }

        #region تحميل الشاشة (Load)

        private void ucNewInvoice_Load(object sender, EventArgs e)
        {
            btnCash.Click += PaymentMethod_Click;
            btnTransfer.Click += PaymentMethod_Click;
            btnCredit.Click += PaymentMethod_Click;
            btnMixed.Click += PaymentMethod_Click;

            SetupInvoiceGrid();
            LoadMockInvoiceHeader();
            LoadMockInvoiceItems();

            // تحديد زرار افتراضي عند فتح الشاشة (تحويل - زي الاسكرين شوت)
            PaymentMethod_Click(btnTransfer, EventArgs.Empty);

            RecalculateTotals();
        }

        private void LoadMockInvoiceHeader()
        {
            lblInvoiceNumber.Text = "رقم الفاتورة: INV-1085";

            stxbCustomer.Text = "ورشة النيل";
            ShowCustomerInfo(_mockCustomers.FirstOrDefault(c => c.Name == "ورشة النيل"));

            // خصم إجمالي افتراضي في البيانات التجريبية (زي الاسكرين شوت: 497 - 10 = 487)
            numUpDownGlobalDiscount.Value = 10;
        }

        private void LoadMockInvoiceItems()
        {
            AddInvoiceRow("فلتر زيت تويوتا كورولا", 4, 45, 0);
            AddInvoiceRow("بوجية NGK × 4", 1, 112, 0);
            AddInvoiceRow("فلتر هواء رينو لوجان", 2, 65, 10);
            AddInvoiceRow("تيل هيدروليك فرامل DOT4", 1, 85, 0);
        }

        private void sabraDateTimePicker1_Load(object sender, EventArgs e)
        {
            // نفس التاريخ الموجود في الاسكرين شوت. في الاستخدام الطبيعي غيّرها لـ DateTime.Today
            sabraDateTimePicker1.Value = new DateTime(2025, 1, 15);
        }

        #endregion

        #region إعداد جدول الفاتورة (DataGridView)

        #region إعداد جدول الفاتورة DataGridView

        private void SetupInvoiceGrid()
        {
            dgvInvoice.AutoGenerateColumns = false;
            dgvInvoice.Columns.Clear();

            dgvInvoice.RightToLeft = RightToLeft.Yes;

            dgvInvoice.AllowUserToAddRows = false;
            dgvInvoice.RowHeadersVisible = false;
            dgvInvoice.AllowUserToResizeRows = false;

            dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoice.MultiSelect = false;

            // يسمح بالتعديل بالضغط والكتابة مباشرة
            dgvInvoice.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            // شكل الجدول
            dgvInvoice.BorderStyle = BorderStyle.None;
            dgvInvoice.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInvoice.GridColor = Color.FromArgb(235, 235, 235);

            dgvInvoice.BackgroundColor = Color.White;

            dgvInvoice.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvInvoice.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(248, 249, 250);

            dgvInvoice.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(60, 60, 60);

            dgvInvoice.ColumnHeadersDefaultCellStyle.Font =
                new Font("Cairo", 10F, FontStyle.Bold);

            dgvInvoice.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvInvoice.DefaultCellStyle.Font =
                new Font("Cairo", 9.5F);

            dgvInvoice.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 247, 255);

            dgvInvoice.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(40, 40, 40);

            dgvInvoice.DefaultCellStyle.Padding =
                new Padding(5, 2, 5, 2);

            dgvInvoice.RowTemplate.Height = 42;


            // # رقم
            dgvInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = COL_INDEX,
                HeaderText = "#",
                ReadOnly = true,
                Width = 40,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle =
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });


            // اسم القطعة
            dgvInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = COL_PART_NAME,
                HeaderText = "اسم القطعة",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });


            // الكمية
            dgvInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = COL_QUANTITY,
                HeaderText = "الكمية",
                ReadOnly = false,
                Width = 80,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle =
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });


            // سعر الوحدة
            dgvInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = COL_UNIT_PRICE,
                HeaderText = "سعر الوحدة",
                ReadOnly = true,
                Width = 110,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle =
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });


            // الخصم
            dgvInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = COL_DISCOUNT,
                HeaderText = "الخصم",
                ReadOnly = false,
                Width = 90,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle =
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            ForeColor = Color.FromArgb(220, 53, 69)
        }
            });


            // الإجمالي
            dgvInvoice.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = COL_TOTAL,
                HeaderText = "الإجمالي",
                ReadOnly = true,
                Width = 110,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle =
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            Font = new Font(dgvInvoice.Font, FontStyle.Bold)
        }
            });


            // زر الحذف
            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = COL_DELETE,
                HeaderText = "",
                Text = "✕",
                UseColumnTextForButtonValue = true,
                Width = 45,
                FlatStyle = FlatStyle.Flat,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            deleteColumn.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(190, 190, 190),
                BackColor = Color.White,
                SelectionForeColor = Color.FromArgb(220, 53, 69),
                SelectionBackColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };

            dgvInvoice.Columns.Add(deleteColumn);


            // Events
            dgvInvoice.CellFormatting += dgvInvoice_CellFormatting;
            dgvInvoice.CellEndEdit += dgvInvoice_CellEndEdit;
            dgvInvoice.CellContentClick += dgvInvoice_CellContentClick;
        }

        #endregion

        // بيتعمل فورمات لعمود السعر والخصم والإجمالي بحيث يظهروا "180 ج" بدل ما نخزن نص جوه الخلية
        private void dgvInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvInvoice.Columns[e.ColumnIndex].Name;

            if (colName == COL_UNIT_PRICE || colName == COL_TOTAL)
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = FormatCurrency(val);
                    e.FormattingApplied = true;
                }
            }
            else if (colName == COL_DISCOUNT)
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = val > 0 ? FormatCurrency(val) : "—";
                    e.FormattingApplied = true;
                }
            }
        }

        // لما المستخدم يعدل الكمية أو الخصم يدوياً في الجدول، بنعيد حساب السطر والإجمالي كله
        private void dgvInvoice_CellEndEdit(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string colName = dgvInvoice.Columns[e.ColumnIndex].Name;

            if (colName == COL_QUANTITY ||
                colName == COL_DISCOUNT)
            {
                RecalculateRow(e.RowIndex);
                RecalculateTotals();
            }
        }

        private void RecalculateRow(int rowIndex)
        {
            DataGridViewRow row = dgvInvoice.Rows[rowIndex];

            decimal qty = ParseDecimal(
                row.Cells[COL_QUANTITY].Value);

            decimal price = ParseDecimal(
                row.Cells[COL_UNIT_PRICE].Value);

            decimal discount = ParseDecimal(
                row.Cells[COL_DISCOUNT].Value);


            // الكمية لازم تكون 1 أو أكثر
            if (qty < 1)
            {
                qty = 1;
                row.Cells[COL_QUANTITY].Value = qty;
            }


            // الخصم لا يمكن يكون بالسالب
            if (discount < 0)
            {
                discount = 0;
                row.Cells[COL_DISCOUNT].Value = discount;
            }


            decimal total = (qty * price) - discount;

            if (total < 0)
                total = 0;


            row.Cells[COL_TOTAL].Value = total;
        }


        // زرار الـ X في كل صف - بيحذف القطعة من الفاتورة
        private void dgvInvoice_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvInvoice.Columns[e.ColumnIndex].Name != COL_DELETE)
                return;

            string partName =
                dgvInvoice.Rows[e.RowIndex]
                .Cells[COL_PART_NAME]
                .Value?.ToString();

            DialogResult confirm = MessageBox.Show(
                $"هل تريد حذف \"{partName}\" من الفاتورة؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            dgvInvoice.Rows.RemoveAt(e.RowIndex);

            RenumberInvoiceRows();
            RecalculateTotals();
        }
        private void RenumberInvoiceRows()
        {
            for (int i = 0; i < dgvInvoice.Rows.Count; i++)
            {
                dgvInvoice.Rows[i].Cells[COL_INDEX].Value = i + 1;
            }
        }

        private void AddInvoiceRow(string partName, decimal quantity, decimal unitPrice, decimal discount = 0)
        {
            decimal total = (quantity * unitPrice) - discount;
            if (total < 0) total = 0;

            int rowIndex = dgvInvoice.Rows.Add();
            DataGridViewRow row = dgvInvoice.Rows[rowIndex];

            row.Cells[COL_INDEX].Value = dgvInvoice.Rows.Count;
            row.Cells[COL_PART_NAME].Value = partName;
            row.Cells[COL_QUANTITY].Value = quantity;
            row.Cells[COL_UNIT_PRICE].Value = unitPrice;
            row.Cells[COL_DISCOUNT].Value = discount;
            row.Cells[COL_TOTAL].Value = total;
        }

        #endregion

        #region إضافة قطعة جديدة للفاتورة (شريط الإضافة العلوي)

        // بحث بسيط عن القطعة بالاسم أو الباركود عشان نملى السعر أوتوماتيك
        private void stxbPartName_TextChanged(object sender, EventArgs e)
        {
            string search = stxbPartName.Text.Trim();
            if (string.IsNullOrEmpty(search)) return;

            PartInfo match = _mockParts.FirstOrDefault(p =>
                p.Barcode == search ||
                p.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);

            if (match != null)
            {
                sabraNumericUpDownPrice.Value = match.Price;

                if (sabraNumericUpDownAmount.Value < 1)
                    sabraNumericUpDownAmount.Value = 1;
            }
        }

        private void sabraNumericUpDownPrice_ValueChanged(object sender, EventArgs e)
        {
            // مفيش حاجة مطلوبة هنا حالياً، السعر بيتحسب وقت الإضافة الفعلية للفاتورة
        }

        private void sabraNumericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            // مفيش حاجة مطلوبة هنا حالياً، الكمية بتتحسب وقت الإضافة الفعلية للفاتورة
        }

        private void stbnAddToInvoice_Click(object sender, EventArgs e)
        {
            string partName = stxbPartName.Text.Trim();

            if (string.IsNullOrEmpty(partName))
            {
                MessageBox.Show("من فضلك اكتب اسم القطعة أو الباركود أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stxbPartName.Focus();
                return;
            }

            decimal quantity = sabraNumericUpDownAmount.Value <= 0 ? 1 : sabraNumericUpDownAmount.Value;
            decimal price = sabraNumericUpDownPrice.Value;

            if (price <= 0)
            {
                MessageBox.Show("من فضلك أدخل سعر صحيح للقطعة.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sabraNumericUpDownPrice.Focus();
                return;
            }

            // لو القطعة موجودة بالفعل في الفاتورة، هنزود الكمية بدل ما نضيف سطر جديد
            DataGridViewRow existingRow = dgvInvoice.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells[COL_PART_NAME].Value?.ToString() == partName);

            if (existingRow != null)
            {
                decimal currentQty = ParseDecimal(existingRow.Cells[COL_QUANTITY].Value);
                existingRow.Cells[COL_QUANTITY].Value = currentQty + quantity;
                RecalculateRow(existingRow.Index);
            }
            else
            {
                AddInvoiceRow(partName, quantity, price, 0);
            }

            RecalculateTotals();

            // تفريغ حقول الإضافة استعداداً لقطعة جديدة
            stxbPartName.Clear();
            sabraNumericUpDownAmount.Value = 1;
            sabraNumericUpDownPrice.Value = 0;
            stxbPartName.Focus();
        }

        #endregion

        #region طريقة الدفع

        private void PaymentMethod_Click(object sender, EventArgs e)
        {
            if (sender is not SabraButton clickedButton)
                return;

            ResetPaymentButtonStyles(btnCash);
            ResetPaymentButtonStyles(btnTransfer);
            ResetPaymentButtonStyles(btnCredit);
            ResetPaymentButtonStyles(btnMixed);

            SetSelectedPaymentButtonStyle(clickedButton);

            _selectedPaymentMethod = clickedButton.Text;

            bool isCredit = _selectedPaymentMethod == "آجل";

            sabraNumericUpDownِAmountPaid.Enabled = !isCredit;

            if (isCredit)
            {
                _isUpdatingTotals = true;
                sabraNumericUpDownِAmountPaid.Value = 0;
                _isUpdatingTotals = false;
            }

            RecalculateTotals();
        }

        private void ResetPaymentButtonStyles(SabraButton btn)
        {
            btn.NormalColor = Color.White;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.DimGray;
            btn.BorderColor = Color.DimGray;
            btn.BorderSize = 1;
            btn.HoverColor = Color.CornflowerBlue;
            btn.Invalidate();
        }

        private void SetSelectedPaymentButtonStyle(SabraButton btn)
        {
            btn.NormalColor = Color.CornflowerBlue;
            btn.BackColor = Color.CornflowerBlue;
            btn.ForeColor = Color.White;
            btn.BorderColor = Color.CornflowerBlue;
            btn.BorderSize = 1;
            btn.HoverColor = Color.FromArgb(70, 130, 210);
            btn.Invalidate();
        }

        #endregion


        #region حساب الإجمالي والخصم والصافي والمتبقي

        private void RecalculateTotals()
        {
            decimal itemsTotal = 0;

            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                itemsTotal += ParseDecimal(row.Cells[COL_TOTAL].Value);
            }

            decimal globalDiscount = numUpDownGlobalDiscount.Value;
            decimal netTotal = Math.Max(itemsTotal - globalDiscount, 0);
            _currentNetTotal = netTotal;

            lblItemsTotal.Text = FormatCurrency(itemsTotal);
            lblDiscount.Text = FormatCurrency(globalDiscount);
            slblNetTotal.Text = FormatCurrency(netTotal);

            // لو طريقة الدفع مش "أجل"، هنعتبر افتراضياً إن العميل بيدفع الصافي بالكامل
            if (_selectedPaymentMethod != "أجل")
            {
                _isUpdatingTotals = true;
                decimal maxAllowed = sabraNumericUpDownِAmountPaid.Maximum;
                sabraNumericUpDownِAmountPaid.Value = netTotal > maxAllowed ? maxAllowed : netTotal;
                _isUpdatingTotals = false;
            }

            UpdateRemainingAmount();
        }

        private void UpdateRemainingAmount()
        {
            decimal amountPaid = sabraNumericUpDownِAmountPaid.Value;
            decimal remaining = _currentNetTotal - amountPaid;

            lblRemaing.Text = FormatCurrency(Math.Abs(remaining));

            lblRemaing.ForeColor = remaining <= 0
                ? Color.FromArgb(39, 130, 76)   // أخضر: تم السداد بالكامل (أو دفع أكتر)
                : Color.FromArgb(220, 53, 69);  // أحمر: لسه فيه مبلغ متبقي
        }

        private void sabraNumericUpDownِAmountPaid_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingTotals) return;
            UpdateRemainingAmount();
        }

        private void numUpDownGlobalDiscount_ValueChanged(object sender, EventArgs e)
        {
            RecalculateTotals();
        }

        private static string FormatCurrency(decimal value)
        {
            return value.ToString("N0", CultureInfo.InvariantCulture) + " ج";
        }

        private static decimal ParseDecimal(object value)
        {
            if (value == null) return 0;
            decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result);
            return result;
        }

        #endregion

        #region العميل

        private void stxbCustomer_TextChanged(object sender, EventArgs e)
        {
            string search = stxbCustomer.Text.Trim();

            if (string.IsNullOrEmpty(search))
            {
                slblCustomerNameAndCreditLimit.Visible = false;
                return;
            }

            CustomerInfo match = _mockCustomers.FirstOrDefault(c =>
                c.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Phone.Contains(search));

            ShowCustomerInfo(match);
        }

        private void ShowCustomerInfo(CustomerInfo customer)
        {
            if (customer == null)
            {
                slblCustomerNameAndCreditLimit.Visible = false;
                return;
            }

            slblCustomerNameAndCreditLimit.Text = $"{customer.Name} — حد ائتماني: {FormatCurrency(customer.CreditLimit)}";
            slblCustomerNameAndCreditLimit.BackColor = Color.FromArgb(223, 247, 232);
            slblCustomerNameAndCreditLimit.ForeColor = Color.FromArgb(39, 130, 76);
            slblCustomerNameAndCreditLimit.Visible = true;
        }

        private void slblCustomerNameAndCreditLimit_Click(object sender, EventArgs e)
        {
            string search = stxbCustomer.Text.Trim();
            CustomerInfo customer = _mockCustomers.FirstOrDefault(c => c.Name == search);

            if (customer != null)
            {
                MessageBox.Show(
                    $"العميل: {customer.Name}\nالتليفون: {customer.Phone}\nالحد الائتماني: {FormatCurrency(customer.CreditLimit)}",
                    "بيانات العميل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnAddNewCastomer_Click(object sender, EventArgs e)
        {
            using (var dialog = new AddCustomerDialog())
            {
                if (dialog.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    var newCustomer = new CustomerInfo(dialog.CustomerName, dialog.CustomerPhone, dialog.CreditLimit);
                    _mockCustomers.Add(newCustomer);

                    stxbCustomer.Text = newCustomer.Name;
                    ShowCustomerInfo(newCustomer);
                }
            }
        }

        #endregion

        #region حفظ / إلغاء / مسح الفاتورة

        private void sbtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoiceBeforeSave()) return;

            // TODO: هنا هيتم استدعاء طبقة الحفظ الحقيقية في قاعدة البيانات
            MessageBox.Show($"تم حفظ الفاتورة {lblInvoiceNumber.Text} بنجاح.", "تم الحفظ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sbtnSaveAndAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoiceBeforeSave()) return;

            // TODO: هنا هيتم استدعاء طبقة الحفظ الحقيقية في قاعدة البيانات
            MessageBox.Show($"تم حفظ الفاتورة {lblInvoiceNumber.Text} بنجاح، جاري فتح فاتورة جديدة.",
                "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            StartNewInvoice();
        }

        private void sbtnCancelSaving_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "هل تريد إلغاء الفاتورة الحالية؟ لن يتم حفظ أي بيانات.",
                "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                StartNewInvoice();
            }
        }

        private void scbtnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.Rows.Count == 0) return;

            DialogResult confirm = MessageBox.Show(
                "هل تريد مسح كل القطع من الفاتورة؟",
                "تأكيد المسح", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                dgvInvoice.Rows.Clear();
                RecalculateTotals();
            }
        }

        private bool ValidateInvoiceBeforeSave()
        {
            if (dgvInvoice.Rows.Count == 0)
            {
                MessageBox.Show("لا يمكن حفظ فاتورة فارغة، من فضلك أضف قطعة واحدة على الأقل.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(stxbCustomer.Text))
            {
                MessageBox.Show("من فضلك اختر اسم العميل قبل الحفظ.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stxbCustomer.Focus();
                return false;
            }

            return true;
        }

        private void StartNewInvoice()
        {
            dgvInvoice.Rows.Clear();

            lblInvoiceNumber.Text = $"رقم الفاتورة: INV-{_nextMockInvoiceNumber++}";
            stxbCustomer.Clear();
            slblCustomerNameAndCreditLimit.Visible = false;

            sabraDateTimePicker1.Value = DateTime.Today;
            numUpDownGlobalDiscount.Value = 0;

            _isUpdatingTotals = true;
            sabraNumericUpDownِAmountPaid.Value = 0;
            _isUpdatingTotals = false;

            stxbPartName.Clear();
            sabraNumericUpDownAmount.Value = 1;
            sabraNumericUpDownPrice.Value = 0;

            PaymentMethod_Click(btnTransfer, EventArgs.Empty);
            RecalculateTotals();
        }

        #endregion

        #region طباعة وتصدير

        private void sbtnPrint_Click(object sender, EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(
                dgvInvoice,
                $"فاتورة بيع - {lblInvoiceNumber.Text}");
        }

        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(
                dgvInvoice,
                $"تصدير - {lblInvoiceNumber.Text}");
        }

        #endregion

        #region أحداث غير مستخدمة حالياً (تظل فاضية عمداً)

        private void sabraPanel3_Paint(object sender, PaintEventArgs e) { }
        private void sabraPanel1_Paint(object sender, PaintEventArgs e) { }
        private void lblItemsTotal_Click(object sender, EventArgs e) { }
        private void lblDiscount_Click(object sender, EventArgs e) { }
        private void slblNetTotal_Click(object sender, EventArgs e) { }
        private void lblRemaing_Click(object sender, EventArgs e) { }

        private void lblInvoiceNumber_Click(object sender, EventArgs e)
        {
            // لمسة صغيرة: نسخ رقم الفاتورة للكليب بورد عند الضغط عليه
            Clipboard.SetText(lblInvoiceNumber.Text);
        }

        #endregion

        #region كلاسات مساعدة (Mock Data + نافذة إضافة عميل)

        private class PartInfo
        {
            public string Barcode { get; }
            public string Name { get; }
            public decimal Price { get; }

            public PartInfo(string barcode, string name, decimal price)
            {
                Barcode = barcode;
                Name = name;
                Price = price;
            }
        }

        private class CustomerInfo
        {
            public string Name { get; }
            public string Phone { get; }
            public decimal CreditLimit { get; }

            public CustomerInfo(string name, string phone, decimal creditLimit)
            {
                Name = name;
                Phone = phone;
                CreditLimit = creditLimit;
            }
        }

        // نافذة بسيطة مبنية بالكود بالكامل (من غير Designer) لإضافة عميل جديد
        private class AddCustomerDialog : Form
        {
            private readonly TextBox _txtName = new TextBox();
            private readonly TextBox _txtPhone = new TextBox();
            private readonly NumericUpDown _numCreditLimit = new NumericUpDown();

            public string CustomerName => _txtName.Text.Trim();
            public string CustomerPhone => _txtPhone.Text.Trim();
            public decimal CreditLimit => _numCreditLimit.Value;

            public AddCustomerDialog()
            {
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
                Text = "إضافة عميل جديد";
                FormBorderStyle = FormBorderStyle.FixedDialog;
                StartPosition = FormStartPosition.CenterParent;
                MaximizeBox = false;
                MinimizeBox = false;
                Width = 340;
                Height = 260;

                var lblName = new Label { Text = "اسم العميل:", Left = 20, Top = 20, Width = 280 };
                _txtName.Left = 20; _txtName.Top = 45; _txtName.Width = 280;

                var lblPhone = new Label { Text = "رقم الهاتف:", Left = 20, Top = 80, Width = 280 };
                _txtPhone.Left = 20; _txtPhone.Top = 105; _txtPhone.Width = 280;

                var lblCredit = new Label { Text = "الحد الائتماني:", Left = 20, Top = 140, Width = 280 };
                _numCreditLimit.Left = 20; _numCreditLimit.Top = 165; _numCreditLimit.Width = 280;
                _numCreditLimit.Maximum = 1000000;
                _numCreditLimit.Increment = 500;

                var btnOk = new Button { Text = "حفظ", Left = 120, Top = 205, Width = 80, DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "إلغاء", Left = 210, Top = 205, Width = 80, DialogResult = DialogResult.Cancel };

                btnOk.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(_txtName.Text))
                    {
                        MessageBox.Show("من فضلك اكتب اسم العميل.", "تنبيه",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                    }
                };

                Controls.AddRange(new Control[] { lblName, _txtName, lblPhone, _txtPhone, lblCredit, _numCreditLimit, btnOk, btnCancel });
                AcceptButton = btnOk;
                CancelButton = btnCancel;
            }
        }

        #endregion
    }
}