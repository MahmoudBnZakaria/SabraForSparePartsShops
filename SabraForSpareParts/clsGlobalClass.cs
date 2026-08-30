using ClosedXML.Excel;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public static class clsGlobalClass
    {
        private static int _printRowIndex;
        private static DataGridView _printDataGridView;

        #region Print

        public static void PrintDataGridView(
            DataGridView dataGridView,
            string reportTitle)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات للطباعة.",
                    "الطباعة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            _printDataGridView = dataGridView;
            _printRowIndex = 0;

            PrintDocument printDocument =
                new PrintDocument();

            printDocument.PrintPage +=
                (sender, e) => PrintDocument_PrintPage(
                    sender,
                    e,
                    reportTitle);

            using PrintPreviewDialog preview =
                new PrintPreviewDialog();

            preview.Document = printDocument;

            preview.WindowState =
                FormWindowState.Maximized;

            preview.ShowDialog();
        }

        private static void PrintDocument_PrintPage(
            object sender,
            PrintPageEventArgs e,
            string reportTitle)
        {
            using Font titleFont = new Font(
                "Arial",
                18,
                FontStyle.Bold);

            using Font headerFont = new Font(
                "Arial",
                10,
                FontStyle.Bold);

            using Font cellFont = new Font(
                "Arial",
                9);

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            e.Graphics.DrawString(
                reportTitle,
                titleFont,
                Brushes.Black,
                x,
                y);

            y += 50;

            int rowHeight = 30;

            int totalWidth = e.MarginBounds.Width;

            var printableColumns =
                _printDataGridView.Columns
                .Cast<DataGridViewColumn>()
                .Where(column =>
                    column.Visible &&
                    column is not DataGridViewButtonColumn &&
                    column is not DataGridViewCheckBoxColumn)
                .ToList();

            if (printableColumns.Count == 0)
            {
                e.HasMorePages = false;
                return;
            }

            int columnWidth =
                totalWidth / printableColumns.Count;

            #region Print Headers

            int currentX = x;

            foreach (DataGridViewColumn column
                in printableColumns)
            {
                Rectangle headerRectangle =
                    new Rectangle(
                        currentX,
                        y,
                        columnWidth,
                        rowHeight);

                e.Graphics.DrawRectangle(
                    Pens.Black,
                    headerRectangle);

                StringFormat format =
                    new StringFormat();

                format.Alignment =
                    StringAlignment.Center;

                format.LineAlignment =
                    StringAlignment.Center;

                format.FormatFlags =
                    StringFormatFlags.DirectionRightToLeft;

                e.Graphics.DrawString(
                    column.HeaderText,
                    headerFont,
                    Brushes.Black,
                    headerRectangle,
                    format);

                currentX += columnWidth;
            }

            #endregion

            y += rowHeight;

            #region Print Rows

            while (_printRowIndex <
                   _printDataGridView.Rows.Count)
            {
                if (y + rowHeight >
                    e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                DataGridViewRow row =
                    _printDataGridView.Rows[
                        _printRowIndex];

                if (row.IsNewRow)
                {
                    _printRowIndex++;
                    continue;
                }

                currentX = x;

                foreach (DataGridViewColumn column
                    in printableColumns)
                {
                    Rectangle cellRectangle =
                        new Rectangle(
                            currentX,
                            y,
                            columnWidth,
                            rowHeight);

                    e.Graphics.DrawRectangle(
                        Pens.Black,
                        cellRectangle);

                    string value =
                        row.Cells[column.Index]
                        .Value?
                        .ToString() ?? "";

                    StringFormat format =
                        new StringFormat();

                    format.Alignment =
                        StringAlignment.Center;

                    format.LineAlignment =
                        StringAlignment.Center;

                    format.FormatFlags =
                        StringFormatFlags.DirectionRightToLeft;

                    e.Graphics.DrawString(
                        value,
                        cellFont,
                        Brushes.Black,
                        cellRectangle,
                        format);

                    currentX += columnWidth;
                }

                y += rowHeight;
                _printRowIndex++;
            }

            #endregion

            e.HasMorePages = false;
            _printRowIndex = 0;
        }

        #endregion

        #region Export Excel

        public static void ExportDataGridViewToExcel(
            DataGridView dataGridView,
            string fileNamePrefix,
            string worksheetName)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات لتصديرها.",
                    "تصدير Excel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using SaveFileDialog saveFileDialog =
                new SaveFileDialog();

            saveFileDialog.Filter =
                "Excel Files (*.xlsx)|*.xlsx";

            saveFileDialog.Title =
                "حفظ ملف Excel";

            saveFileDialog.FileName =
                $"{fileNamePrefix}_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx";

            if (saveFileDialog.ShowDialog() !=
                DialogResult.OK)
            {
                return;
            }

            try
            {
                using XLWorkbook workbook =
                    new XLWorkbook();

                var worksheet =
                    workbook.Worksheets.Add(
                        worksheetName);

                int excelColumn = 1;

                #region Export Headers

                foreach (DataGridViewColumn column
                    in dataGridView.Columns)
                {
                    if (!column.Visible ||
                        column is DataGridViewButtonColumn)
                    {
                        continue;
                    }

                    worksheet.Cell(
                        1,
                        excelColumn).Value =
                        column.HeaderText;

                    worksheet.Cell(
                        1,
                        excelColumn)
                        .Style
                        .Font
                        .Bold = true;

                    excelColumn++;
                }

                #endregion

                int excelRow = 2;

                #region Export Rows

                foreach (DataGridViewRow row
                    in dataGridView.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    excelColumn = 1;

                    foreach (
                        DataGridViewColumn column
                        in dataGridView.Columns)
                    {
                        if (!column.Visible ||
                            column is DataGridViewButtonColumn)
                        {
                            continue;
                        }

                        object value =
                            row.Cells[column.Index].Value;

                        worksheet.Cell(
                            excelRow,
                            excelColumn).Value =
                            value?.ToString() ?? "";

                        excelColumn++;
                    }

                    excelRow++;
                }

                #endregion

                worksheet.RightToLeft = true;

                worksheet.Columns()
                    .AdjustToContents();

                worksheet.SheetView
                    .FreezeRows(1);

                workbook.SaveAs(
                    saveFileDialog.FileName);

                MessageBox.Show(
                    "تم تصدير البيانات إلى Excel بنجاح.",
                    "تم التصدير",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName =
                            saveFileDialog.FileName,

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

        #endregion
    }
}