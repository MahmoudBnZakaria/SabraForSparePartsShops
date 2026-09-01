using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucNewPurchaseOrder : SabraUserControl
    {
        #region Models

        private class PartCatalogItem
        {
            public string Barcode { get; set; }
            public string Name { get; set; }
            public decimal DefaultUnitPrice { get; set; }
        }

        private class PurchaseOrderLine : INotifyPropertyChanged
        {
            private int requiredQuantity;
            private decimal unitPrice;

            public string Barcode { get; set; }

            public string PartName { get; set; }

            public int RequiredQuantity
            {
                get => requiredQuantity;

                set
                {
                    if (requiredQuantity == value)
                        return;

                    requiredQuantity = value;

                    OnPropertyChanged(nameof(RequiredQuantity));
                    OnPropertyChanged(nameof(LineTotal));
                }
            }

            public decimal UnitPrice
            {
                get => unitPrice;

                set
                {
                    if (unitPrice == value)
                        return;

                    unitPrice = value;

                    OnPropertyChanged(nameof(UnitPrice));
                    OnPropertyChanged(nameof(LineTotal));
                }
            }

            public decimal LineTotal =>
                RequiredQuantity * UnitPrice;

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(propertyName)
                );
            }
        }

        #endregion


        #region Mock Data

        private readonly List<PartCatalogItem> _partsCatalog =
            new List<PartCatalogItem>
            {
                new PartCatalogItem
                {
                    Barcode = "OC90-001",
                    Name = "فلتر زيت تويوتا OC90",
                    DefaultUnitPrice = 32m
                },

                new PartCatalogItem
                {
                    Barcode = "HY-i10-002",
                    Name = "فلتر صالون هيونداي i10",
                    DefaultUnitPrice = 38m
                },

                new PartCatalogItem
                {
                    Barcode = "BRK-003",
                    Name = "تيل فرامل أمامي",
                    DefaultUnitPrice = 145m
                },

                new PartCatalogItem
                {
                    Barcode = "SPK-004",
                    Name = "بوجيهات NGK",
                    DefaultUnitPrice = 65m
                },

                new PartCatalogItem
                {
                    Barcode = "AIR-005",
                    Name = "فلتر هواء",
                    DefaultUnitPrice = 55m
                },

                new PartCatalogItem
                {
                    Barcode = "BAT-006",
                    Name = "بطارية 70 أمبير",
                    DefaultUnitPrice = 2100m
                }
            };


        private readonly List<string> _suppliers =
            new List<string>
            {
                "شركة النصر لقطع الغيار",
                "مؤسسة الأمانة للتوريدات",
                "مصنع الدلتا للفلاتر",
                "شركة المتحدة لقطع الغيار"
            };


        private readonly BindingList<PurchaseOrderLine> _orderLines =
            new BindingList<PurchaseOrderLine>();


        private const string ResponsibleEmployeeMock = "أحمد محمود";

        #endregion


        #region Constructor

        public ucNewPurchaseOrder()
        {
            InitializeComponent();

            ConfigureScreen();

            SetupGrid();

            SetupSupplierComboBox();

            GenerateNewOrderNumber();

            dtpPurchaseOrderDate.Value = DateTime.Now;

            slblResponsibleEmployee.Text =
                ResponsibleEmployeeMock;

            stbxNotes.Text = string.Empty;

            LoadMockOrderData();

            RecalculateTotal();
        }

        #endregion


        #region Screen Configuration

        private void ConfigureScreen()
        {
            RightToLeft = RightToLeft.Yes;
        }

        #endregion


        #region Grid Setup

        private void SetupGrid()
        {
            dgvPurchaseOrderDetails.SuspendLayout();

            // ============================================
            // RTL
            // ============================================

            dgvPurchaseOrderDetails.RightToLeft =
                RightToLeft.Yes;


            // ============================================
            // Basic Settings
            // ============================================

            dgvPurchaseOrderDetails.AutoGenerateColumns = false;

            dgvPurchaseOrderDetails.Columns.Clear();

            dgvPurchaseOrderDetails.AllowUserToAddRows = false;

            dgvPurchaseOrderDetails.AllowUserToDeleteRows = false;

            dgvPurchaseOrderDetails.AllowUserToResizeRows = false;

            dgvPurchaseOrderDetails.RowHeadersVisible = false;

            dgvPurchaseOrderDetails.MultiSelect = false;

            dgvPurchaseOrderDetails.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPurchaseOrderDetails.EditMode =
                DataGridViewEditMode.EditOnKeystrokeOrF2;

            dgvPurchaseOrderDetails.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgvPurchaseOrderDetails.RowTemplate.Height = 45;


            // ============================================
            // Header
            // ============================================

            dgvPurchaseOrderDetails.EnableHeadersVisualStyles = false;

            dgvPurchaseOrderDetails.ColumnHeadersHeight = 48;

            dgvPurchaseOrderDetails.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    Alignment =
                        DataGridViewContentAlignment.MiddleCenter,

                    Font = new Font(
                        "Cairo",
                        10F,
                        FontStyle.Bold
                    ),

                    WrapMode =
                        DataGridViewTriState.False
                };


            // ============================================
            // Rows
            // ============================================

            dgvPurchaseOrderDetails.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    Font = new Font(
                        "Cairo",
                        9.5F
                    ),

                    Alignment =
                        DataGridViewContentAlignment.MiddleCenter,

                    SelectionBackColor =
                        Color.FromArgb(235, 241, 255),

                    SelectionForeColor =
                        Color.Black,

                    BackColor =
                        Color.White,

                    ForeColor =
                        Color.FromArgb(45, 45, 45),

                    Padding =
                        new Padding(5, 0, 5, 0)
                };


            dgvPurchaseOrderDetails.AlternatingRowsDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(250, 251, 253)
                };


            // ============================================
            // 1. Part Name
            //
            // RTL:
            // أول عمود = أقصى اليمين
            // ============================================

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colPartName",

                    HeaderText = "القطعة",

                    DataPropertyName =
                        nameof(PurchaseOrderLine.PartName),

                    ReadOnly = true,

                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,

                    MinimumWidth = 250,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Alignment =
                                DataGridViewContentAlignment.MiddleRight
                        }
                }
            );


            // ============================================
            // 2. Quantity
            // ============================================

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colQuantity",

                    HeaderText = "الكمية المطلوبة",

                    DataPropertyName =
                        nameof(PurchaseOrderLine.RequiredQuantity),

                    ReadOnly = false,

                    Width = 150,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Alignment =
                                DataGridViewContentAlignment.MiddleCenter,

                            Format = "N0"
                        }
                }
            );


            // ============================================
            // 3. Unit Price
            // ============================================

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colUnitPrice",

                    HeaderText = "سعر الوحدة",

                    DataPropertyName =
                        nameof(PurchaseOrderLine.UnitPrice),

                    ReadOnly = false,

                    Width = 150,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Alignment =
                                DataGridViewContentAlignment.MiddleCenter,

                            Format = "N2"
                        }
                }
            );


            // ============================================
            // 4. Line Total
            // ============================================

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colLineTotal",

                    HeaderText = "إجمالي السطر",

                    DataPropertyName =
                        nameof(PurchaseOrderLine.LineTotal),

                    ReadOnly = true,

                    Width = 170,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Alignment =
                                DataGridViewContentAlignment.MiddleCenter,

                            Format = "N2"
                        }
                }
            );


            // ============================================
            // 5. Delete
            //
            // لأنه RTL وآخر عمود:
            // يظهر أقصى الشمال
            // ============================================

            dgvPurchaseOrderDetails.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colDelete",

                    HeaderText = string.Empty,

                    Text = "حذف",

                    UseColumnTextForButtonValue = true,

                    Width = 75,

                    FlatStyle = FlatStyle.Flat,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Alignment =
                                DataGridViewContentAlignment.MiddleCenter,

                            ForeColor =
                                Color.FromArgb(190, 35, 35),

                            SelectionForeColor =
                                Color.FromArgb(190, 35, 35),

                            BackColor =
                                Color.White,

                            SelectionBackColor =
                                Color.FromArgb(250, 250, 250),

                            Font = new Font(
                                "Cairo",
                                8.5F,
                                FontStyle.Bold
                            )
                        }
                }
            );


            // ============================================
            // Data Source
            // ============================================

            dgvPurchaseOrderDetails.DataSource =
                _orderLines;


            // ============================================
            // Events
            // ============================================

            dgvPurchaseOrderDetails.CellValueChanged -=
                DgvPurchaseOrderDetails_CellValueChanged;

            dgvPurchaseOrderDetails.CellValueChanged +=
                DgvPurchaseOrderDetails_CellValueChanged;


            dgvPurchaseOrderDetails.CellContentClick -=
                dgvPurchaseOrderDetails_CellContentClick;

            dgvPurchaseOrderDetails.CellContentClick +=
                dgvPurchaseOrderDetails_CellContentClick;


            dgvPurchaseOrderDetails.CellValidating -=
                DgvPurchaseOrderDetails_CellValidating;

            dgvPurchaseOrderDetails.CellValidating +=
                DgvPurchaseOrderDetails_CellValidating;


            dgvPurchaseOrderDetails.DataError -=
                DgvPurchaseOrderDetails_DataError;

            dgvPurchaseOrderDetails.DataError +=
                DgvPurchaseOrderDetails_DataError;


            dgvPurchaseOrderDetails.CurrentCellDirtyStateChanged -=
                DgvPurchaseOrderDetails_CurrentCellDirtyStateChanged;

            dgvPurchaseOrderDetails.CurrentCellDirtyStateChanged +=
                DgvPurchaseOrderDetails_CurrentCellDirtyStateChanged;


            dgvPurchaseOrderDetails.CellPainting -=
                DgvPurchaseOrderDetails_CellPainting;

            dgvPurchaseOrderDetails.CellPainting +=
                DgvPurchaseOrderDetails_CellPainting;


            dgvPurchaseOrderDetails.ResumeLayout();
        }

        #endregion


        #region Mock Table Data

        private void LoadMockOrderData()
        {
            _orderLines.Clear();


            // ============================================
            // Mock rows
            // ============================================

            _orderLines.Add(
                new PurchaseOrderLine
                {
                    Barcode = "OC90-001",

                    PartName = "فلتر زيت تويوتا OC90",

                    RequiredQuantity = 5,

                    UnitPrice = 32m
                }
            );


            _orderLines.Add(
                new PurchaseOrderLine
                {
                    Barcode = "HY-i10-002",

                    PartName = "فلتر صالون هيونداي i10",

                    RequiredQuantity = 3,

                    UnitPrice = 38m
                }
            );


            _orderLines.Add(
                new PurchaseOrderLine
                {
                    Barcode = "BRK-003",

                    PartName = "تيل فرامل أمامي",

                    RequiredQuantity = 4,

                    UnitPrice = 145m
                }
            );


            _orderLines.Add(
                new PurchaseOrderLine
                {
                    Barcode = "SPK-004",

                    PartName = "بوجيهات NGK",

                    RequiredQuantity = 8,

                    UnitPrice = 65m
                }
            );


            _orderLines.Add(
                new PurchaseOrderLine
                {
                    Barcode = "AIR-005",

                    PartName = "فلتر هواء",

                    RequiredQuantity = 6,

                    UnitPrice = 55m
                }
            );


            _orderLines.Add(
                new PurchaseOrderLine
                {
                    Barcode = "BAT-006",

                    PartName = "بطارية 70 أمبير",

                    RequiredQuantity = 2,

                    UnitPrice = 2100m
                }
            );


            dgvPurchaseOrderDetails.Refresh();

            RecalculateTotal();
        }

        #endregion


        #region Grid Events

        private void DgvPurchaseOrderDetails_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;


            string columnName =
                dgvPurchaseOrderDetails
                    .Columns[e.ColumnIndex]
                    .Name;


            if (
                columnName == "colQuantity" ||
                columnName == "colUnitPrice"
            )
            {
                dgvPurchaseOrderDetails
                    .InvalidateRow(e.RowIndex);

                RecalculateTotal();
            }
        }


        private void DgvPurchaseOrderDetails_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e)
        {
            if (
                dgvPurchaseOrderDetails
                    .IsCurrentCellDirty
            )
            {
                dgvPurchaseOrderDetails.CommitEdit(
                    DataGridViewDataErrorContexts.Commit
                );
            }
        }


        private void DgvPurchaseOrderDetails_CellValidating(
            object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            string columnName =
                dgvPurchaseOrderDetails
                    .Columns[e.ColumnIndex]
                    .Name;


            // ============================================
            // Quantity Validation
            // ============================================

            if (columnName == "colQuantity")
            {
                if (
                    !int.TryParse(
                        e.FormattedValue?.ToString(),
                        out int quantity
                    )
                    ||
                    quantity <= 0
                )
                {
                    e.Cancel = true;

                    MessageBox.Show(
                        "الكمية المطلوبة يجب أن تكون أكبر من صفر.",
                        "قيمة غير صحيحة",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }
            }


            // ============================================
            // Unit Price Validation
            // ============================================

            if (columnName == "colUnitPrice")
            {
                if (
                    !decimal.TryParse(
                        e.FormattedValue?.ToString(),
                        out decimal price
                    )
                    ||
                    price < 0
                )
                {
                    e.Cancel = true;

                    MessageBox.Show(
                        "سعر الوحدة غير صحيح.",
                        "قيمة غير صحيحة",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }


        private void DgvPurchaseOrderDetails_DataError(
            object sender,
            DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            MessageBox.Show(
                "من فضلك أدخل قيمة رقمية صحيحة.",
                "قيمة غير صحيحة",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }


        private void dgvPurchaseOrderDetails_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (
                dgvPurchaseOrderDetails
                    .Columns[e.ColumnIndex]
                    .Name != "colDelete"
            )
            {
                return;
            }


            if (e.RowIndex >= _orderLines.Count)
                return;


            PurchaseOrderLine line =
                _orderLines[e.RowIndex];


            DialogResult result =
                MessageBox.Show(
                    $"هل تريد حذف \"{line.PartName}\" من أمر الشراء؟",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


            if (result != DialogResult.Yes)
                return;


            _orderLines.RemoveAt(e.RowIndex);

            RecalculateTotal();
        }


        private void DgvPurchaseOrderDetails_CellPainting(
            object sender,
            DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (
                e.ColumnIndex >= 0 &&
                dgvPurchaseOrderDetails
                    .Columns[e.ColumnIndex]
                    .Name == "colDelete"
            )
            {
                e.PaintBackground(
                    e.CellBounds,
                    true
                );


                TextRenderer.DrawText(
                    e.Graphics,
                    "حذف",
                    new Font(
                        "Cairo",
                        8.5F,
                        FontStyle.Bold
                    ),
                    e.CellBounds,
                    Color.FromArgb(190, 35, 35),
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.NoPadding
                );


                e.Handled = true;
            }
        }

        #endregion


        #region Search & Add Part

        private void stbxAddPart_Load(
            object sender,
            EventArgs e)
        {
            stbxAddPart.Text =
                string.Empty;
        }


        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            string searchTerm =
                stbxAddPart.Text?.Trim();


            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show(
                    "من فضلك اكتب اسم القطعة أو الباركود للبحث.",
                    "بحث",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                stbxAddPart.Focus();

                return;
            }


            List<PartCatalogItem> matches =
                _partsCatalog
                    .Where(
                        p =>
                            p.Name.Contains(
                                searchTerm,
                                StringComparison.OrdinalIgnoreCase
                            )
                            ||
                            p.Barcode.Contains(
                                searchTerm,
                                StringComparison.OrdinalIgnoreCase
                            )
                    )
                    .ToList();


            if (matches.Count == 0)
            {
                MessageBox.Show(
                    "لم يتم العثور على قطعة مطابقة.",
                    "بحث",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            PartCatalogItem selectedPart =
                matches.Count == 1
                    ? matches[0]
                    : PromptUserToChoosePart(matches);


            if (selectedPart == null)
                return;


            AddPartToOrder(selectedPart);


            stbxAddPart.Clear();

            stbxAddPart.Focus();
        }


        private PartCatalogItem PromptUserToChoosePart(
            List<PartCatalogItem> matches)
        {
            using Form form =
                new Form
                {
                    Text = "اختيار القطعة",

                    StartPosition =
                        FormStartPosition.CenterParent,

                    FormBorderStyle =
                        FormBorderStyle.FixedDialog,

                    MinimizeBox = false,

                    MaximizeBox = false,

                    Width = 500,

                    Height = 350,

                    RightToLeft =
                        RightToLeft.Yes,

                    RightToLeftLayout = true
                };


            ListBox listBox =
                new ListBox
                {
                    Dock = DockStyle.Top,

                    Height = 230,

                    Font = new Font(
                        "Cairo",
                        10F
                    ),

                    DisplayMember =
                        nameof(PartCatalogItem.Name),

                    DataSource = matches,

                    IntegralHeight = false
                };


            Button okButton =
                new Button
                {
                    Text = "اختيار",

                    Width = 90,

                    Height = 40,

                    Top = 250,

                    Left = 290,

                    DialogResult =
                        DialogResult.OK
                };


            Button cancelButton =
                new Button
                {
                    Text = "إلغاء",

                    Width = 90,

                    Height = 40,

                    Top = 250,

                    Left = 390,

                    DialogResult =
                        DialogResult.Cancel
                };


            form.Controls.Add(listBox);

            form.Controls.Add(okButton);

            form.Controls.Add(cancelButton);


            form.AcceptButton =
                okButton;

            form.CancelButton =
                cancelButton;


            return form.ShowDialog() ==
                   DialogResult.OK
                ? listBox.SelectedItem
                    as PartCatalogItem
                : null;
        }


        private void AddPartToOrder(
            PartCatalogItem part)
        {
            PurchaseOrderLine existingLine =
                _orderLines.FirstOrDefault(
                    l => l.Barcode == part.Barcode
                );


            if (existingLine != null)
            {
                existingLine.RequiredQuantity++;

                dgvPurchaseOrderDetails.Refresh();
            }
            else
            {
                _orderLines.Add(
                    new PurchaseOrderLine
                    {
                        Barcode =
                            part.Barcode,

                        PartName =
                            part.Name,

                        RequiredQuantity =
                            1,

                        UnitPrice =
                            part.DefaultUnitPrice
                    }
                );
            }


            RecalculateTotal();
        }

        #endregion


        #region Totals

        private void RecalculateTotal()
        {
            decimal total =
                _orderLines.Sum(
                    l => l.LineTotal
                );


            lblTotalPriceOfPurchaseOrders.Text =
                $"الإجمالي: {total:N2} ج";
        }


        private void lblTotalPriceOfPurchaseOrders_Click(
            object sender,
            EventArgs e)
        {
        }

        #endregion


        #region Header Info

        private void GenerateNewOrderNumber()
        {
            string orderNumber =
                $"PO-{DateTime.Now:yyyyMMdd}-{new Random().Next(100, 999)}";


            lblNewPurchaseOrderNumber.Text =
                orderNumber;


            lblNewPurchaseOrderNumber2.Text =
                orderNumber;
        }


        private void lblNewPurchaseOrderNumber_Click(
            object sender,
            EventArgs e)
        {
        }


        private void lblNewPurchaseOrderNumber2_Click(
            object sender,
            EventArgs e)
        {
        }


        private void dtpPurchaseOrderDate_Load(
            object sender,
            EventArgs e)
        {
            dtpPurchaseOrderDate.Value =
                DateTime.Now;
        }


        private void slblResponsibleEmployee_Click(
            object sender,
            EventArgs e)
        {
            string newEmployee =
                ShowInputBox(
                    "اسم الموظف المسؤول:",
                    "تغيير الموظف المسؤول",
                    slblResponsibleEmployee.Text
                );


            if (!string.IsNullOrWhiteSpace(newEmployee))
            {
                slblResponsibleEmployee.Text =
                    newEmployee.Trim();
            }
        }


        private void stbxNotes_Load(
            object sender,
            EventArgs e)
        {
            stbxNotes.Text =
                string.Empty;
        }


        private void sabraPanel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        #endregion


        #region Supplier

        private void SetupSupplierComboBox()
        {
            scbxSupplier.Items.Clear();

            scbxSupplier.Items.AddRange(
                _suppliers.ToArray()
            );


            if (scbxSupplier.Items.Count > 0)
            {
                scbxSupplier.SelectedIndex = 0;
            }
        }


        private void scbxSupplier_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }


        private void addSupplier_Click(
            object sender,
            EventArgs e)
        {
            string newSupplierName =
                ShowInputBox(
                    "اسم المورد الجديد:",
                    "إضافة مورد"
                );


            if (string.IsNullOrWhiteSpace(
                newSupplierName))
            {
                return;
            }


            newSupplierName =
                newSupplierName.Trim();


            if (
                _suppliers.Any(
                    s => string.Equals(
                        s,
                        newSupplierName,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
            )
            {
                MessageBox.Show(
                    "هذا المورد موجود بالفعل.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }


            _suppliers.Add(
                newSupplierName
            );


            scbxSupplier.Items.Add(
                newSupplierName
            );


            scbxSupplier.SelectedItem =
                newSupplierName;
        }

        #endregion


        #region Save / Cancel / Delete

        private bool ValidateOrderBeforeSave()
        {
            if (
                scbxSupplier.SelectedItem == null
                &&
                string.IsNullOrWhiteSpace(
                    scbxSupplier.Text
                )
            )
            {
                MessageBox.Show(
                    "من فضلك اختر المورد أولاً.",
                    "بيانات ناقصة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                scbxSupplier.Focus();

                return false;
            }


            if (_orderLines.Count == 0)
            {
                MessageBox.Show(
                    "من فضلك أضف قطعة واحدة على الأقل.",
                    "بيانات ناقصة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                stbxAddPart.Focus();

                return false;
            }


            if (
                _orderLines.Any(
                    l => l.RequiredQuantity <= 0
                )
            )
            {
                MessageBox.Show(
                    "الكمية المطلوبة يجب أن تكون أكبر من صفر.",
                    "بيانات غير صحيحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }


            if (
                _orderLines.Any(
                    l => l.UnitPrice < 0
                )
            )
            {
                MessageBox.Show(
                    "سعر الوحدة لا يمكن أن يكون بالسالب.",
                    "بيانات غير صحيحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }


            return true;
        }


        private void btnSaveAndSent_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateOrderBeforeSave())
                return;


            decimal total =
                _orderLines.Sum(
                    l => l.LineTotal
                );


            MessageBox.Show(
                $"تم حفظ وإرسال أمر الشراء رقم " +
                $"{lblNewPurchaseOrderNumber.Text} " +
                $"إلى \"{scbxSupplier.Text}\" " +
                $"بإجمالي {total:N2} ج.",

                "تم الحفظ",

                MessageBoxButtons.OK,

                MessageBoxIcon.Information
            );
        }


        private void btnSaveAsDraft_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                $"تم حفظ أمر الشراء رقم " +
                $"{lblNewPurchaseOrderNumber.Text} " +
                "كمسودة.",

                "تم الحفظ كمسودة",

                MessageBoxButtons.OK,

                MessageBoxIcon.Information
            );
        }


        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "هل تريد إلغاء أمر الشراء؟ لن يتم حفظ أي بيانات.",

                    "تأكيد الإلغاء",

                    MessageBoxButtons.YesNo,

                    MessageBoxIcon.Question
                );


            if (result != DialogResult.Yes)
                return;


            ClearOrder();
        }


        private void scbtnDeleteInvoice_Click(
            object sender,
            EventArgs e)
        {
            if (_orderLines.Count == 0)
                return;


            DialogResult result =
                MessageBox.Show(
                    "هل تريد حذف كل القطع من أمر الشراء؟",

                    "تأكيد الحذف",

                    MessageBoxButtons.YesNo,

                    MessageBoxIcon.Warning
                );


            if (result != DialogResult.Yes)
                return;


            _orderLines.Clear();

            RecalculateTotal();
        }


        private void ClearOrder()
        {
            _orderLines.Clear();

            stbxAddPart.Clear();

            stbxNotes.Clear();

            RecalculateTotal();

            GenerateNewOrderNumber();

            if (scbxSupplier.Items.Count > 0)
            {
                scbxSupplier.SelectedIndex = 0;
            }
        }

        #endregion


        #region Print / Export

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            var options =
                new PrintDocumentOptions
                {
                    ReportTitle =
                        $"أمر شراء رقم " +
                        $"{lblNewPurchaseOrderNumber.Text} " +
                        $"- المورد: {scbxSupplier.Text}",

                    Notes =
                        stbxNotes.Text
                };


            options.Tables.Add(
                new PrintableTable(
                    dgvPurchaseOrderDetails,
                    "القطع المطلوبة"
                )
            );


            clsGlobalClass.PrintReport(
                options
            );
        }


        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            var tables =
                new List<PrintableTable>
                {
                    new PrintableTable(
                        dgvPurchaseOrderDetails,
                        "القطع المطلوبة"
                    )
                };


            clsGlobalClass.ExportToExcel(
                tables,

                $"PurchaseOrder_" +
                $"{lblNewPurchaseOrderNumber.Text}",

                stbxNotes.Text
            );
        }

        #endregion


        #region Input Box

        private static string ShowInputBox(
            string prompt,
            string title,
            string defaultValue = "")
        {
            using Form form =
                new Form
                {
                    Text = title,

                    StartPosition =
                        FormStartPosition.CenterParent,

                    FormBorderStyle =
                        FormBorderStyle.FixedDialog,

                    MinimizeBox = false,

                    MaximizeBox = false,

                    Width = 400,

                    Height = 190,

                    RightToLeft =
                        RightToLeft.Yes,

                    RightToLeftLayout = true
                };


            Label label =
                new Label
                {
                    Left = 20,

                    Top = 15,

                    Width = 340,

                    Height = 30,

                    Text = prompt,

                    Font = new Font(
                        "Cairo",
                        9.5F
                    )
                };


            TextBox textBox =
                new TextBox
                {
                    Left = 20,

                    Top = 50,

                    Width = 340,

                    Height = 30,

                    Text = defaultValue,

                    Font = new Font(
                        "Cairo",
                        9.5F
                    ),

                    RightToLeft =
                        RightToLeft.Yes
                };


            Button okButton =
                new Button
                {
                    Text = "موافق",

                    Left = 180,

                    Width = 80,

                    Height = 35,

                    Top = 100,

                    DialogResult =
                        DialogResult.OK
                };


            Button cancelButton =
                new Button
                {
                    Text = "إلغاء",

                    Left = 280,

                    Width = 80,

                    Height = 35,

                    Top = 100,

                    DialogResult =
                        DialogResult.Cancel
                };


            form.Controls.Add(label);

            form.Controls.Add(textBox);

            form.Controls.Add(okButton);

            form.Controls.Add(cancelButton);


            form.AcceptButton =
                okButton;

            form.CancelButton =
                cancelButton;


            form.Shown +=
                (sender, e) =>
                {
                    textBox.Focus();

                    textBox.SelectAll();
                };


            return form.ShowDialog() ==
                   DialogResult.OK

                ? textBox.Text

                : null;
        }

        #endregion


        #region Designer Events

        private void stbxAmount_Load(
            object sender,
            EventArgs e)
        {
        }

        #endregion

    }
}