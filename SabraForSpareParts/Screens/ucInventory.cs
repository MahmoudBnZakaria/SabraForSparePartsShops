using Sabra.LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;


namespace SabraForSpareParts.Screens
{
    public partial class ucInventory : SabraUserControl
    {
        private readonly List<SparePartMock> _allParts = new();
        private readonly BindingSource _bindingSource = new();

        private PrintDocument _printDocument;
        private int _printRowIndex;

        public ucInventory()
        {
            InitializeComponent();

            Load += ucInventory_Load;
        }

        private void ucInventory_Load(object sender, EventArgs e)
        {
            SetupFilters();
            LoadMockData();
            SetupGridColumns();
            SetupGrid();

            ApplyFilters();
        }

        #region Setup

        private void SetupFilters()
        {
            scbxClassification.Items.Clear();
            scbxBrand.Items.Clear();
            cmbInventoryStatus.Items.Clear();

            scbxClassification.Items.AddRange(new object[]
            {
                "كل التصنيفات",
                "فلاتر",
                "بواجي",
                "فرامل",
                "تعليق",
                "تيل وسوائل"
            });

            scbxBrand.Items.AddRange(new object[]
            {
                "كل الماركات",
                "Bosch",
                "NGK",
                "Mann",
                "Denso",
                "Ferodo",
                "SKF",
                "—"
            });

            cmbInventoryStatus.Items.AddRange(new object[]
            {
                "كل الحالات",
                "متوفر",
                "مخزون منخفض",
                "نفد المخزون"
            });

            scbxClassification.SelectedIndex = 0;
            scbxBrand.SelectedIndex = 0;
            cmbInventoryStatus.SelectedIndex = 0;
        }

        private void SetupGrid()
        {
            sabraDataGridView1.AutoGenerateColumns = false;
            sabraDataGridView1.DataSource = _bindingSource;

            sabraDataGridView1.AllowUserToAddRows = false;
            sabraDataGridView1.AllowUserToDeleteRows = false;
            sabraDataGridView1.ReadOnly = true;
            sabraDataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            sabraDataGridView1.MultiSelect = false;

            sabraDataGridView1.CellContentClick -=
                sabraDataGridView1_CellContentClick;

            sabraDataGridView1.CellContentClick +=
                sabraDataGridView1_CellContentClick;
        }

        private void SetupGridColumns()
        {
            sabraDataGridView1.Columns.Clear();

            sabraDataGridView1.Columns.Add(
                CreateTextColumn(
                    "Barcode",
                    "Barcode",
                    "الباركود"));

            sabraDataGridView1.Columns.Add(
                CreateTextColumn(
                    "PartNumber",
                    "PartNumber",
                    "الرقم الفني"));

            sabraDataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    DataPropertyName = "Name",
                    HeaderText = "اسم القطعة",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });

            sabraDataGridView1.Columns.Add(
                CreateTextColumn(
                    "Category",
                    "Category",
                    "التصنيف"));

            sabraDataGridView1.Columns.Add(
                CreateTextColumn(
                    "Brand",
                    "Brand",
                    "الماركة"));

            sabraDataGridView1.Columns.Add(
                CreateTextColumn(
                    "Quantity",
                    "Quantity",
                    "الكمية"));

            sabraDataGridView1.Columns.Add(
                CreateTextColumn(
                    "MinLimit",
                    "MinLimit",
                    "الحد الأدنى"));

            sabraDataGridView1.Columns.Add(
                CreateTextColumn(
                    "Price",
                    "PriceString",
                    "سعر البيع"));

            sabraDataGridView1.Columns.Add(
                CreateTextColumn(
                    "Shelf",
                    "Shelf",
                    "الرف"));

            sabraDataGridView1.Columns.Add(
                CreateButtonColumn(
                    "btnView",
                    "عرض",
                    "عرض"));

            sabraDataGridView1.Columns.Add(
                CreateButtonColumn(
                    "btnEdit",
                    "تعديل",
                    "تعديل"));

            sabraDataGridView1.Columns.Add(
                CreateButtonColumn(
                    "btnMovement",
                    "حركة",
                    "حركة"));
        }

        private DataGridViewTextBoxColumn CreateTextColumn(
            string name,
            string dataPropertyName,
            string headerText)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                DataPropertyName = dataPropertyName,
                HeaderText = headerText,
                AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells
            };
        }

        private DataGridViewButtonColumn CreateButtonColumn(
            string name,
            string headerText,
            string text)
        {
            return new DataGridViewButtonColumn
            {
                Name = name,
                HeaderText = headerText,
                Text = text,
                UseColumnTextForButtonValue = true,
                AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells
            };
        }

        #endregion

        #region Data

        private void LoadMockData()
        {
            _allParts.Clear();

            _allParts.Add(new SparePartMock
            {
                Barcode = "4001234001",
                PartNumber = "OC90",
                Name = "فلتر زيت تويوتا كورولا",
                Category = "فلاتر",
                Brand = "Mann",
                Quantity = 2,
                MinLimit = 10,
                Price = 45,
                Shelf = "A1-R3"
            });

            _allParts.Add(new SparePartMock
            {
                Barcode = "5003456002",
                PartNumber = "BKR6E",
                Name = "بوجية NGK كيا سيراتو",
                Category = "بواجي",
                Brand = "NGK",
                Quantity = 0,
                MinLimit = 20,
                Price = 28,
                Shelf = "B2-R1"
            });

            _allParts.Add(new SparePartMock
            {
                Barcode = "7008765003",
                PartNumber = "DF47",
                Name = "ديسك فرامل أمامي هيونداي اكسنت",
                Category = "فرامل",
                Brand = "Ferodo",
                Quantity = 15,
                MinLimit = 5,
                Price = 220,
                Shelf = "C3-R2"
            });

            _allParts.Add(new SparePartMock
            {
                Barcode = "3002345004",
                PartNumber = "OF124",
                Name = "فلتر هواء رينو لوجان",
                Category = "فلاتر",
                Brand = "Bosch",
                Quantity = 4,
                MinLimit = 8,
                Price = 65,
                Shelf = "A2-R1"
            });

            _allParts.Add(new SparePartMock
            {
                Barcode = "6004567005",
                PartNumber = "TH22",
                Name = "تيل هيدروليك فرامل",
                Category = "تيل وسوائل",
                Brand = "—",
                Quantity = 3,
                MinLimit = 2,
                Price = 1085,
                Shelf = "D1-R4"
            });

            _allParts.Add(new SparePartMock
            {
                Barcode = "9007890006",
                PartNumber = "SK301",
                Name = "طقم صدمات أمامي كيا ريو",
                Category = "تعليق",
                Brand = "SKF",
                Quantity = 8,
                MinLimit = 3,
                Price = 450,
                Shelf = "E2-R1"
            });
        }

        #endregion

        #region Filters

        private void ApplyFilters()
        {
            IEnumerable<SparePartMock> filteredData = _allParts;

            string searchText = stxbxSearch.Text.Trim();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredData = filteredData.Where(part =>
                    ContainsText(part.Name, searchText) ||
                    ContainsText(part.Barcode, searchText) ||
                    ContainsText(part.PartNumber, searchText));
            }

            string selectedCategory =
                scbxClassification.SelectedItem?.ToString();

            if (!string.IsNullOrWhiteSpace(selectedCategory) &&
                selectedCategory != "كل التصنيفات")
            {
                filteredData = filteredData.Where(part =>
                    part.Category == selectedCategory);
            }

            string selectedBrand =
                scbxBrand.SelectedItem?.ToString();

            if (!string.IsNullOrWhiteSpace(selectedBrand) &&
                selectedBrand != "كل الماركات")
            {
                filteredData = filteredData.Where(part =>
                    part.Brand == selectedBrand);
            }

            string selectedStatus =
                cmbInventoryStatus.SelectedItem?.ToString();

            filteredData = selectedStatus switch
            {
                "نفد المخزون" =>
                    filteredData.Where(part => part.Quantity == 0),

                "مخزون منخفض" =>
                    filteredData.Where(part =>
                        part.Quantity > 0 &&
                        part.Quantity <= part.MinLimit),

                "متوفر" =>
                    filteredData.Where(part =>
                        part.Quantity > part.MinLimit),

                _ => filteredData
            };

            var result = filteredData.ToList();

            _bindingSource.DataSource = result;

            UpdateResultCount(result.Count);
        }

        private bool ContainsText(
            string source,
            string searchText)
        {
            return source?.IndexOf(
                searchText,
                StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void ResetFilters()
        {
            stxbxSearch.Clear();

            scbxClassification.SelectedIndex = 0;
            scbxBrand.SelectedIndex = 0;
            cmbInventoryStatus.SelectedIndex = 0;

            ApplyFilters();
        }

        private void UpdateResultCount(int count)
        {
            // لو عندك Label لعدد النتائج حط اسمه هنا

            // مثلا:
            // slblResultCount.Text =
            //     $"عدد الأصناف: {count}";
        }

        #endregion

        #region Filter Events

        private void stxbxSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void scbxClassification_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void scbxBrand_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbInventoryStatus_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void scbtnDeleteFilters_Click(
            object sender,
            EventArgs e)
        {
            ResetFilters();
        }

        #endregion

        #region Grid Actions

        private void sabraDataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName =
                sabraDataGridView1.Columns[e.ColumnIndex].Name;

            if (columnName != "btnView" &&
                columnName != "btnEdit" &&
                columnName != "btnMovement")
                return;

            if (sabraDataGridView1.Rows[e.RowIndex].DataBoundItem
                is not SparePartMock part)
                return;

            switch (columnName)
            {
                case "btnView":

                    ShowPartDetails(part);
                    break;

                case "btnEdit":

                    EditPart(part);
                    break;

                case "btnMovement":

                    ShowPartMovement(part);
                    break;
            }
        }

        private void ShowPartDetails(SparePartMock part)
        {
            MessageBox.Show(
                $"اسم القطعة: {part.Name}\n" +
                $"الباركود: {part.Barcode}\n" +
                $"الرقم الفني: {part.PartNumber}\n" +
                $"التصنيف: {part.Category}\n" +
                $"الماركة: {part.Brand}\n" +
                $"الكمية: {part.Quantity}\n" +
                $"الحد الأدنى: {part.MinLimit}\n" +
                $"السعر: {part.PriceString}\n" +
                $"المكان: {part.Shelf}",

                "تفاصيل القطعة",

                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void EditPart(SparePartMock part)
        {
            MessageBox.Show(
                $"هنا هتفتح شاشة تعديل القطعة:\n{part.Name}",

                "تعديل الصنف",

                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // بعدين بدل MessageBox:
            // frmAddEditPart form = new frmAddEditPart(part);
            // form.ShowDialog();
            // ApplyFilters();
        }

        private void ShowPartMovement(SparePartMock part)
        {
            MessageBox.Show(
                $"هنا هتفتح شاشة حركة المخزون للقطعة:\n{part.Name}",

                "حركة المخزون",

                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // بعدين تفتح شاشة حركة المخزون
        }

        #endregion

        #region Buttons

        private void sbtnAddPart_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "هنا هتفتح شاشة إضافة قطعة جديدة.",

                "إضافة صنف",

                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // بعدين:
            // frmAddEditPart form = new frmAddEditPart();
            // form.ShowDialog();
            // LoadDataFromDatabase();
            // ApplyFilters();
        }


        #endregion

        #region Print

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            if (sabraDataGridView1.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات للطباعة.",

                    "الطباعة",

                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            _printRowIndex = 0;

            _printDocument ??= new PrintDocument();

            _printDocument.PrintPage -= PrintDocument_PrintPage;
            _printDocument.PrintPage += PrintDocument_PrintPage;

            using PrintPreviewDialog preview =
                new PrintPreviewDialog();

            preview.Document = _printDocument;

            preview.WindowState =
                FormWindowState.Maximized;

            preview.ShowDialog();
        }

        private void PrintDocument_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            Font titleFont = new Font(
                "Arial",
                18,
                FontStyle.Bold);

            Font headerFont = new Font(
                "Arial",
                10,
                FontStyle.Bold);

            Font cellFont = new Font(
                "Arial",
                9);

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            e.Graphics.DrawString(
                "تقرير المخزون",

                titleFont,

                Brushes.Black,

                x,

                y);

            y += 50;

            int rowHeight = 30;
            int barcodeWidth = 120;
            int nameWidth = 300;
            int quantityWidth = 100;
            int minLimitWidth = 100;
            int priceWidth = 120;

            e.Graphics.DrawString(
                "الباركود",
                headerFont,
                Brushes.Black,
                x,
                y);

            e.Graphics.DrawString(
                "اسم القطعة",
                headerFont,
                Brushes.Black,
                x + barcodeWidth,
                y);

            e.Graphics.DrawString(
                "الكمية",
                headerFont,
                Brushes.Black,
                x + barcodeWidth + nameWidth,
                y);

            e.Graphics.DrawString(
                "الحد الأدنى",
                headerFont,
                Brushes.Black,
                x + barcodeWidth + nameWidth + quantityWidth,
                y);

            e.Graphics.DrawString(
                "السعر",
                headerFont,
                Brushes.Black,
                x + barcodeWidth + nameWidth +
                quantityWidth + minLimitWidth,
                y);

            y += rowHeight;

            while (_printRowIndex <
                   sabraDataGridView1.Rows.Count)
            {
                if (y + rowHeight >
                    e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                if (sabraDataGridView1.Rows[_printRowIndex]
                    .DataBoundItem is SparePartMock part)
                {
                    e.Graphics.DrawString(
                        part.Barcode,
                        cellFont,
                        Brushes.Black,
                        x,
                        y);

                    e.Graphics.DrawString(
                        part.Name,
                        cellFont,
                        Brushes.Black,
                        x + barcodeWidth,
                        y);

                    e.Graphics.DrawString(
                        part.Quantity.ToString(),
                        cellFont,
                        Brushes.Black,
                        x + barcodeWidth + nameWidth,
                        y);

                    e.Graphics.DrawString(
                        part.MinLimit.ToString(),
                        cellFont,
                        Brushes.Black,
                        x + barcodeWidth + nameWidth +
                        quantityWidth,
                        y);

                    e.Graphics.DrawString(
                        part.PriceString,
                        cellFont,
                        Brushes.Black,
                        x + barcodeWidth + nameWidth +
                        quantityWidth + minLimitWidth,
                        y);
                }

                y += rowHeight;
                _printRowIndex++;
            }

            e.HasMorePages = false;
            _printRowIndex = 0;
        }

        #endregion

        private void sabraTableLayoutPanel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            if (sabraDataGridView1.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات لتصديرها.",
                    "تصدير Excel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "حفظ ملف Excel";
            saveFileDialog.FileName = $"Inventory_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using XLWorkbook workbook = new XLWorkbook();

                var worksheet = workbook.Worksheets.Add("المخزون");

                int excelColumn = 1;

                // إضافة عناوين الأعمدة
                foreach (DataGridViewColumn column in sabraDataGridView1.Columns)
                {
                    // تجاهل أعمدة الأزرار
                    if (column is DataGridViewButtonColumn)
                        continue;

                    worksheet.Cell(1, excelColumn).Value = column.HeaderText;

                    worksheet.Cell(1, excelColumn).Style.Font.Bold = true;

                    excelColumn++;
                }

                int excelRow = 2;

                // إضافة الصفوف
                foreach (DataGridViewRow row in sabraDataGridView1.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    excelColumn = 1;

                    foreach (DataGridViewColumn column in sabraDataGridView1.Columns)
                    {
                        // تجاهل أعمدة الأزرار
                        if (column is DataGridViewButtonColumn)
                            continue;

                        worksheet.Cell(excelRow, excelColumn).Value =
                            row.Cells[column.Index].Value?.ToString() ?? "";

                        excelColumn++;
                    }

                    excelRow++;
                }

                // ضبط اتجاه الشيت للعربي
                worksheet.RightToLeft = true;

                // ضبط عرض الأعمدة تلقائيًا
                worksheet.Columns().AdjustToContents();

                // تثبيت صف العناوين
                worksheet.SheetView.FreezeRows(1);

                workbook.SaveAs(saveFileDialog.FileName);

                MessageBox.Show(
                    "تم تصدير بيانات المخزون إلى Excel بنجاح.",
                    "تم التصدير",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = saveFileDialog.FileName,
                        UseShellExecute = true
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء تصدير الملف:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }

    public class SparePartMock
    {
        public string Barcode { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        public int Quantity { get; set; }
        public int MinLimit { get; set; }

        public decimal Price { get; set; }

        public string Shelf { get; set; }

        public string PriceString =>
            $"{Price:N2} ج";
    }
}