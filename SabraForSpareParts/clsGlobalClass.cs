using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    /// <summary>
    /// جدول واحد مطلوب طباعته أو تصديره، مع عنوانه الخاص (اختياري)
    /// </summary>
    public class PrintableTable
    {
        public DataGridView Grid { get; }
        public string Title { get; }

        public PrintableTable(DataGridView grid, string title = null)
        {
            Grid = grid ?? throw new ArgumentNullException(nameof(grid));
            Title = title;
        }
    }

    /// <summary>
    /// إعدادات مستند الطباعة الكامل: عنوان رئيسي، ملاحظات، وأكتر من جدول
    /// </summary>
    public class PrintDocumentOptions
    {
        public string ReportTitle { get; set; } = "";
        public string Notes { get; set; }
        public bool ShowDate { get; set; } = true;
        public bool ShowPageNumbers { get; set; } = true;
        public List<PrintableTable> Tables { get; } = new List<PrintableTable>();
    }

    public static class clsGlobalClass
    {
        private const int RowHeight = 26;
        private const int TableTitleHeight = 30;
        private const int SpaceBetweenTables = 20;
        private const int HeaderHeight = 28;

        // حالة عملية الطباعة الحالية (بتتصفر مع كل طباعة جديدة)
        private static PrintDocumentOptions _options;
        private static int _currentTableIndex;
        private static int _currentRowIndex;
        private static int _currentPage;

        #region Public API - Printing

        /// <summary>
        /// طباعة جدول واحد فقط (نفس الاستخدام القديم، لسه شغال بدون تعديل باقي الكود)
        /// </summary>
        public static void PrintDataGridView(DataGridView dataGridView, string reportTitle)
        {
            var options = new PrintDocumentOptions { ReportTitle = reportTitle };
            options.Tables.Add(new PrintableTable(dataGridView));

            PrintReport(options);
        }

        /// <summary>
        /// طباعة تقرير كامل ممكن يحتوي على أكتر من جدول، وعنوان لكل جدول، وملاحظات في الآخر
        /// </summary>
        public static void PrintReport(PrintDocumentOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            bool hasData = options.Tables.Any(t =>
                t.Grid.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow));

            if (!hasData)
            {
                MessageBox.Show(
                    "لا توجد بيانات للطباعة.",
                    "الطباعة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _options = options;
            _currentTableIndex = 0;
            _currentRowIndex = 0;
            _currentPage = 1;

            using PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            using PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument;
            preview.WindowState = FormWindowState.Maximized;
            preview.ShowDialog();
        }

        #endregion

        #region Print Engine

        private static void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            int totalWidth = e.MarginBounds.Width;
            int bottomLimit = e.MarginBounds.Bottom;

            using Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            using Font tableTitleFont = new Font("Arial", 12, FontStyle.Bold);
            using Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            using Font cellFont = new Font("Arial", 9);
            using Font notesFont = new Font("Arial", 9, FontStyle.Italic);
            using Font footerFont = new Font("Arial", 8);

            // إعداد تنسيقات المحاذاة لدعم الترتيب الجديد
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            StringFormat rightFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            StringFormat leftFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };

            StringFormat rtlFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };

            // الترويسة تظهر في الصفحة الأولى (ويمكنك إلغاء شرط الصفحة الأولى لو أردت ظهورها في كل الصفحات)

            // الترويسة تظهر في الصفحة الأولى
            if (_currentPage == 1)
            {
                string systemName = "اسم الشركة";

                // السطر الأول: اسم الشركة (يمين) وتاريخ الطباعة (يسار)
                RectangleF topRowRect = new RectangleF(x, y, totalWidth, 20);
                e.Graphics.DrawString(systemName, headerFont, Brushes.Black, topRowRect, rightFormat);

                if (_options.ShowDate)
                {
                    string dateText = $"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}";
                    e.Graphics.DrawString(dateText, footerFont, Brushes.Black, topRowRect, leftFormat);
                }

                y += 25; // النزول سطر جديد للعنوان الرئيسي

                // السطر الثاني: عنوان التقرير في المنتصف (يأخذ العرض بالكامل لمنع التداخل)
                if (!string.IsNullOrWhiteSpace(_options.ReportTitle))
                {
                    RectangleF titleRect = new RectangleF(x, y, totalWidth, 35);
                    e.Graphics.DrawString(_options.ReportTitle, titleFont, Brushes.Black, titleRect, centerFormat);
                    y += 40; // النزول بعد العنوان
                }

                // رسم خط فاصل سميك أسفل الترويسة
                e.Graphics.DrawLine(new Pen(Color.Black, 2), x, y, x + totalWidth, y);

                y += 30; // مسافة كبيرة ومريحة قبل طباعة عنوان الجدول "القطع المطلوبة"
            }

            // استكمال طباعة الجداول من نفس المكان اللي وقفنا فيه في الصفحة اللي فاتت
            while (_currentTableIndex < _options.Tables.Count)
            {
                var table = _options.Tables[_currentTableIndex];

                var printableColumns = table.Grid.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible
                        && c is not DataGridViewButtonColumn
                        && c is not DataGridViewCheckBoxColumn)
                    .ToList();

                if (printableColumns.Count == 0)
                {
                    _currentTableIndex++;
                    _currentRowIndex = 0;
                    continue;
                }

                // عنوان الجدول بيتطبع مرة واحدة بس، أول ما نبدأ فيه
                if (_currentRowIndex == 0 && !string.IsNullOrWhiteSpace(table.Title))
                {
                    if (y + 30 > bottomLimit) // استبدلت TableTitleHeight بقيمة تقريبية 30
                    {
                        e.HasMorePages = true;
                        _currentPage++;
                        return;
                    }

                    e.Graphics.DrawString(table.Title, tableTitleFont, Brushes.Black, x, y, rightFormat);
                    y += 30;
                }

                int columnWidth = totalWidth / printableColumns.Count;
                int headerHeight = 30; // يفترض أن لديك متغير HeaderHeight
                int rowHeight = 25;    // يفترض أن لديك متغير RowHeight

                // صف الهيدر بيتكرر أعلى الجدول في كل صفحة يكمل فيها
                if (y + headerHeight > bottomLimit)
                {
                    e.HasMorePages = true;
                    _currentPage++;
                    return;
                }

                DrawRow(
                    e.Graphics,
                    printableColumns.Select(c => c.HeaderText).ToList(),
                    x, y, columnWidth, headerHeight,
                    headerFont, rtlFormat, isHeader: true);

                y += headerHeight;

                while (_currentRowIndex < table.Grid.Rows.Count)
                {
                    DataGridViewRow row = table.Grid.Rows[_currentRowIndex];

                    if (row.IsNewRow)
                    {
                        _currentRowIndex++;
                        continue;
                    }

                    if (y + rowHeight > bottomLimit)
                    {
                        e.HasMorePages = true;
                        _currentPage++;
                        return;
                    }

                    var values = printableColumns
                        .Select(c => row.Cells[c.Index].Value?.ToString() ?? "")
                        .ToList();

                    DrawRow(e.Graphics, values, x, y, columnWidth, rowHeight, cellFont, rtlFormat, isHeader: false);

                    y += rowHeight;
                    _currentRowIndex++;
                }

                _currentTableIndex++;
                _currentRowIndex = 0;
                y += 20; // SpaceBetweenTables
            }

            // الملاحظات بتتطبع في الآخر، بعد كل الجداول
            if (!string.IsNullOrWhiteSpace(_options.Notes))
            {
                string notesText = $"ملاحظات: {_options.Notes}";
                SizeF notesSize = e.Graphics.MeasureString(notesText, notesFont, totalWidth);

                if (y + notesSize.Height > bottomLimit)
                {
                    e.HasMorePages = true;
                    _currentPage++;
                    return;
                }

                RectangleF notesRect = new RectangleF(x, y, totalWidth, notesSize.Height);

                e.Graphics.DrawString(
                    notesText,
                    notesFont,
                    Brushes.Black,
                    notesRect,
                    rightFormat); // استخدام التنسيق الأيمن بدلاً من إنشاء واحد جديد
            }

            if (_options.ShowPageNumbers)
            {
                string pageText = $"صفحة {_currentPage}";
                SizeF pageSize = e.Graphics.MeasureString(pageText, footerFont);

                e.Graphics.DrawString(
                    pageText,
                    footerFont,
                    Brushes.Black,
                    x + (totalWidth - pageSize.Width) / 2,
                    bottomLimit + 10);
            }

            e.HasMorePages = false;

            // تصفير الحالة استعدادًا لعملية طباعة جديدة
            _currentTableIndex = 0;
            _currentRowIndex = 0;
            _currentPage = 1;
        }

        private static void DrawRow(
            Graphics graphics,
            List<string> values,
            int x,
            int y,
            int columnWidth,
            int rowHeight,
            Font font,
            StringFormat format,
            bool isHeader)
        {
            int currentX = x;

            foreach (string value in values)
            {
                Rectangle cellRectangle = new Rectangle(currentX, y, columnWidth, rowHeight);

                if (isHeader)
                {
                    graphics.FillRectangle(Brushes.WhiteSmoke, cellRectangle);
                }

                graphics.DrawRectangle(Pens.Black, cellRectangle);
                graphics.DrawString(value, font, Brushes.Black, cellRectangle, format);

                currentX += columnWidth;
            }
        }

        #endregion

        #region Export Excel

        /// <summary>
        /// تصدير جدول واحد إلى Excel (نفس الاستخدام القديم، لسه شغال)
        /// </summary>
        public static void ExportDataGridViewToExcel(
            DataGridView dataGridView,
            string fileNamePrefix,
            string worksheetName)
        {
            ExportToExcel(
                new List<PrintableTable> { new PrintableTable(dataGridView, worksheetName) },
                fileNamePrefix,
                notes: null);
        }

        /// <summary>
        /// تصدير أكتر من جدول إلى ملف Excel واحد، كل جدول في شيت منفصل، مع إمكانية إضافة ملاحظات في آخر شيت
        /// </summary>
        public static void ExportToExcel(
            List<PrintableTable> tables,
            string fileNamePrefix,
            string notes = null)
        {
            if (tables == null || tables.Count == 0)
                throw new ArgumentNullException(nameof(tables));

            bool hasData = tables.Any(t =>
                t.Grid.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow));

            if (!hasData)
            {
                MessageBox.Show(
                    "لا توجد بيانات لتصديرها.",
                    "تصدير Excel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = "حفظ ملف Excel",
                FileName = $"{fileNamePrefix}_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using XLWorkbook workbook = new XLWorkbook();
                int sheetIndex = 1;

                foreach (var table in tables)
                {
                    string sheetName = string.IsNullOrWhiteSpace(table.Title)
                        ? $"جدول {sheetIndex}"
                        : MakeSafeSheetName(table.Title, sheetIndex);

                    var worksheet = workbook.Worksheets.Add(sheetName);

                    var visibleColumns = table.Grid.Columns
                        .Cast<DataGridViewColumn>()
                        .Where(c => c.Visible && c is not DataGridViewButtonColumn)
                        .ToList();

                    int excelColumn = 1;
                    foreach (var column in visibleColumns)
                    {
                        var headerCell = worksheet.Cell(1, excelColumn);
                        headerCell.Value = column.HeaderText;
                        headerCell.Style.Font.Bold = true;
                        headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
                        excelColumn++;
                    }

                    int excelRow = 2;
                    foreach (DataGridViewRow row in table.Grid.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        excelColumn = 1;
                        foreach (var column in visibleColumns)
                        {
                            worksheet.Cell(excelRow, excelColumn).Value =
                                row.Cells[column.Index].Value?.ToString() ?? "";
                            excelColumn++;
                        }
                        excelRow++;
                    }

                    // الملاحظات بتتحط تحت آخر جدول بس (آخر شيت)
                    if (!string.IsNullOrWhiteSpace(notes) && table == tables.Last())
                    {
                        var notesCell = worksheet.Cell(excelRow + 1, 1);
                        notesCell.Value = $"ملاحظات: {notes}";
                        notesCell.Style.Font.Italic = true;
                    }

                    worksheet.RightToLeft = true;
                    worksheet.Columns().AdjustToContents();
                    worksheet.SheetView.FreezeRows(1);

                    sheetIndex++;
                }

                workbook.SaveAs(saveFileDialog.FileName);

                MessageBox.Show(
                    "تم تصدير البيانات إلى Excel بنجاح.",
                    "تم التصدير",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Process.Start(new ProcessStartInfo
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

        private static string MakeSafeSheetName(string name, int index)
        {
            // أسماء الشيتات في Excel محدودة بـ 31 حرف ومينفعش فيها بعض الرموز
            string safe = new string(name.Where(c => !"\\/?*[]:".Contains(c)).ToArray());

            if (string.IsNullOrWhiteSpace(safe))
                safe = $"جدول {index}";

            return safe.Length > 31 ? safe.Substring(0, 31) : safe;
        }

        #endregion
    }
}