using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts

{

    public class SabraDataGridView : DataGridView
    {
        #region Colors
        private Color _headerBackColor = Color.FromArgb(248, 250, 252);
        private Color _headerForeColor = Color.FromArgb(30, 41, 59);

        private Color _rowBackColor = Color.White;
        private Color _rowAlternateBackColor = Color.FromArgb(248, 250, 252);

        private Color _rowForeColor = Color.FromArgb(51, 65, 85);

        private Color _selectionBackColor = Color.FromArgb(30, 58, 138);
        private Color _selectionForeColor = Color.White;

        private Color _hoverBackColor = Color.FromArgb(241, 245, 249);
        private Color _gridLineColor = Color.FromArgb(226, 232, 240);

        // دول دلوقتي بيمثلوا لون الزرار "الافتراضي" (Kind = Default) بس،
        // كل Kind تاني (Primary/Success/Danger/Warning) ليه باليتة لون ثابتة جاهزة.
        private Color _buttonBackColor = Color.FromArgb(241, 245, 249);
        private Color _buttonForeColor = Color.FromArgb(51, 65, 85);
        private Color _buttonHoverColor = Color.FromArgb(226, 232, 240);
        #endregion

        #region Editable Columns
        // أسماء الأعمدة اللي المفروض تظهر بشكل "خانة إدخال" مميزة لأنها قابلة للتعديل فعلاً.
        private readonly HashSet<string> _editableColumnNames =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private Color _editableCellBackColor = Color.White;
        private Color _editableCellBorderColor = Color.FromArgb(203, 213, 225);

        [Category("Sabra Appearance")]
        [Description("لون خلفية الخانة القابلة للتعديل")]
        public Color EditableCellBackColor
        {
            get => _editableCellBackColor;
            set { _editableCellBackColor = value; Invalidate(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون حدود الخانة القابلة للتعديل")]
        public Color EditableCellBorderColor
        {
            get => _editableCellBorderColor;
            set { _editableCellBorderColor = value; Invalidate(); }
        }
        #endregion

        #region Cached Fonts
        // بدل ما نعمل new Font() جوه كل رسمة/كل ثيم (بيتكرر آلاف المرات وقت الـ scroll)
        // بنعمل الخطوط دي مرة واحدة بس ونعيد استخدامها، وبنتخلص منها في Dispose.
        private Font _regularFont;
        private Font _boldFont;
        private Font _smallFont;
        #endregion

        #region Hover Tracking (للأزرار تحديدًا، منفصل عن هوفر الصف)
        private int _hoveredRowIndex = -1;
        private int _hoveredColumnIndex = -1;
        #endregion

        #region Appearance Properties

        [Category("Sabra Appearance")]
        [Description("لون خلفية رأس الجدول")]
        public Color HeaderBackColor
        {
            get => _headerBackColor;
            set { _headerBackColor = value; ApplyTheme(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون نص رأس الجدول")]
        public Color HeaderForeColor
        {
            get => _headerForeColor;
            set { _headerForeColor = value; ApplyTheme(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون الصفوف")]
        public Color RowBackColor
        {
            get => _rowBackColor;
            set { _rowBackColor = value; ApplyTheme(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون الصفوف البديلة")]
        public Color RowAlternateBackColor
        {
            get => _rowAlternateBackColor;
            set { _rowAlternateBackColor = value; ApplyTheme(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون نص الصفوف")]
        public Color RowForeColor
        {
            get => _rowForeColor;
            set { _rowForeColor = value; ApplyTheme(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون خلفية الصف المحدد")]
        public Color SelectionBackColor
        {
            get => _selectionBackColor;
            set { _selectionBackColor = value; ApplyTheme(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون نص الصف المحدد")]
        public Color SelectionForeColor
        {
            get => _selectionForeColor;
            set { _selectionForeColor = value; ApplyTheme(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون الصف عند مرور الماوس")]
        public Color HoverBackColor
        {
            get => _hoverBackColor;
            set { _hoverBackColor = value; Invalidate(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون خطوط الجدول")]
        public Color GridLineCustomColor
        {
            get => _gridLineColor;
            set { _gridLineColor = value; ApplyTheme(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون خلفية الأزرار (Kind = Default بس)")]
        public Color ButtonBackColor
        {
            get => _buttonBackColor;
            set { _buttonBackColor = value; Invalidate(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون نص الأزرار (Kind = Default بس)")]
        public Color ButtonForeColor
        {
            get => _buttonForeColor;
            set { _buttonForeColor = value; Invalidate(); }
        }

        [Category("Sabra Appearance")]
        [Description("لون الزرار عند مرور الماوس (Kind = Default بس)")]
        public Color ButtonHoverColor
        {
            get => _buttonHoverColor;
            set { _buttonHoverColor = value; Invalidate(); }
        }

        #endregion

        #region Layout Properties

        [Category("Sabra Layout")]
        [DefaultValue(44)]
        public int HeaderHeight
        {
            get => ColumnHeadersHeight;
            set { ColumnHeadersHeight = Math.Max(30, value); Invalidate(); }
        }

        [Category("Sabra Layout")]
        [DefaultValue(42)]
        public int RowHeight
        {
            get => RowTemplate.Height;
            set
            {
                RowTemplate.Height = Math.Max(25, value);

                foreach (DataGridViewRow row in Rows)
                {
                    if (!row.IsNewRow)
                        row.Height = RowTemplate.Height;
                }

                Invalidate();
            }
        }

        [Category("Sabra Layout")]
        [DefaultValue(true)]
        public bool EnableHoverEffect { get; set; } = true;

        [Category("Sabra Layout")]
        [DefaultValue(true)]
        public bool ShowOuterBorder { get; set; } = true;

        private bool _showCellBorders = false;

        [Category("Sabra Layout")]
        [DefaultValue(false)]
        [Description("إظهار خط فاصل بين الصفوف")]
        public bool ShowCellBorders
        {
            get => _showCellBorders;
            set
            {
                _showCellBorders = value;

                CellBorderStyle =
                    _showCellBorders
                        ? DataGridViewCellBorderStyle.SingleHorizontal
                        : DataGridViewCellBorderStyle.None;

                Invalidate();
            }
        }

        #endregion

        #region Constructor

        public SabraDataGridView()
        {
            InitializeFonts();

            InitializeGrid();

            // أي عمود جديد بيتضاف، بيبقى ReadOnly افتراضيًا (نفس السلوك القديم بالظبط)
            // إلا لو حد نادى SetColumnEditable عليه بعد كده.
            ColumnAdded += (s, e) =>
            {
                if (!_editableColumnNames.Contains(e.Column.Name))
                    e.Column.ReadOnly = true;
            };

            CellFormatting += SabraDataGridView_CellFormatting;
            CellPainting += SabraDataGridView_CellPainting;
            CellMouseEnter += SabraDataGridView_CellMouseEnter;
            CellMouseLeave += SabraDataGridView_CellMouseLeave;
            MouseLeave += (s, e) => Cursor = Cursors.Default;

            ApplyTheme();
        }

        #endregion

        #region Fonts Init

        private void InitializeFonts()
        {
            _regularFont = new Font("Cairo", 10F, FontStyle.Regular, GraphicsUnit.Point);
            _boldFont = new Font("Cairo", 10F, FontStyle.Bold, GraphicsUnit.Point);
            _smallFont = new Font("Cairo", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        #endregion

        #region Initialization

        private void InitializeGrid()
        {
            DoubleBuffered = true;

            BorderStyle = BorderStyle.None;

            BackgroundColor = Color.White;

            EnableHeadersVisualStyles = false;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            AllowUserToOrderColumns = false;

            // القديم كان بيحط ReadOnly = true هنا على الجدول كله، وده كان بيقفل أي تعديل
            // نهائيًا حتى لو عمود بعينه كان ReadOnly = false. دلوقتي القفل بقى مركزي على
            // مستوى كل عمود لوحده (شوف ColumnAdded فوق و SetColumnEditable تحت)، فتقدر
            // تفتح عمود معين للتعديل من غير ما تفتح الجدول كله.

            MultiSelect = false;

            SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // كليكة واحدة على خانة قابلة للتعديل تدخلك على طول في وضع الكتابة،
            // بدل ما تحتاج دبل كليك أو F2 عشان تلاحظ إنها أصلاً قابلة للتعديل.
            EditMode = DataGridViewEditMode.EditOnEnter;

            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            RowHeadersVisible = false;

            RightToLeft = RightToLeft.Yes;

            Font = _regularFont;

            CellBorderStyle =
                _showCellBorders
                    ? DataGridViewCellBorderStyle.SingleHorizontal
                    : DataGridViewCellBorderStyle.None;

            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            RowTemplate.Height = 42;

            ColumnHeadersHeight = 44;

            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            ScrollBars = ScrollBars.Both;

            ShowCellToolTips = true;

            AllowUserToResizeColumns = true;

            AllowUserToResizeRows = false;
        }

        #endregion

        #region Editable Columns API

        /// <summary>
        /// يفتح عمود معين للتعديل (أو يقفله) وياديله شكل "خانة إدخال" مميز عشان يبان للمستخدم
        /// إنه قابل للتعديل. ده البديل الصحيح لمحاولة تعديل ReadOnly يدويًا على العمود،
        /// لأن الجدول أصلاً بيقفل أي عمود جديد تلقائيًا.
        /// مثال: dgv.SetColumnEditable("colQuantity");
        /// </summary>
        public void SetColumnEditable(string columnName, bool editable = true)
        {
            if (!Columns.Contains(columnName))
                return;

            Columns[columnName].ReadOnly = !editable;

            if (editable)
                _editableColumnNames.Add(columnName);
            else
                _editableColumnNames.Remove(columnName);

            Invalidate();
        }

        public bool IsColumnEditable(string columnName)
        {
            return Columns.Contains(columnName) && !Columns[columnName].ReadOnly;
        }

        #endregion

        #region Theme

        private void ApplyTheme()
        {
            SuspendLayout();

            ColumnHeadersDefaultCellStyle.BackColor = _headerBackColor;
            ColumnHeadersDefaultCellStyle.ForeColor = _headerForeColor;
            ColumnHeadersDefaultCellStyle.Font = _boldFont;
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersDefaultCellStyle.SelectionBackColor = _headerBackColor;
            ColumnHeadersDefaultCellStyle.SelectionForeColor = _headerForeColor;
            ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            DefaultCellStyle.BackColor = _rowBackColor;
            DefaultCellStyle.ForeColor = _rowForeColor;
            DefaultCellStyle.Font = _regularFont;
            DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DefaultCellStyle.SelectionBackColor = _selectionBackColor;
            DefaultCellStyle.SelectionForeColor = _selectionForeColor;
            DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            AlternatingRowsDefaultCellStyle.BackColor = _rowAlternateBackColor;
            AlternatingRowsDefaultCellStyle.ForeColor = _rowForeColor;
            AlternatingRowsDefaultCellStyle.SelectionBackColor = _selectionBackColor;
            AlternatingRowsDefaultCellStyle.SelectionForeColor = _selectionForeColor;

            GridColor = _gridLineColor;

            RowHeadersDefaultCellStyle.SelectionBackColor = _selectionBackColor;
            RowHeadersDefaultCellStyle.SelectionForeColor = _selectionForeColor;

            ResumeLayout();
        }

        #endregion

        #region Cell Formatting

        private void SabraDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCell cell = Rows[e.RowIndex].Cells[e.ColumnIndex];
            string columnName = Columns[e.ColumnIndex].Name;

            if (cell.Selected)
            {
                e.CellStyle.SelectionBackColor = _selectionBackColor;
                e.CellStyle.SelectionForeColor = _selectionForeColor;
            }

            if (columnName == "Quantity" || columnName == "الكمية")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal quantity))
                {
                    if (quantity <= 0)
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    else if (quantity < 5)
                        e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);
                    else
                        e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);

                    if (cell.Selected)
                        e.CellStyle.SelectionForeColor = _selectionForeColor;
                }
            }
        }

        #endregion

        #region Cell Painting

        private void SabraDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName = Columns[e.ColumnIndex].Name;

            if (Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                PaintButtonCell(e);
                return;
            }

            if (columnName == "Category" || columnName == "التصنيف")
            {
                PaintCategoryChip(e);
                return;
            }

            // خانة قابلة للتعديل (اتفتحت عن طريق SetColumnEditable) بتترسم بشكل خانة إدخال واضح
            if (!Columns[e.ColumnIndex].ReadOnly && _editableColumnNames.Contains(columnName))
            {
                PaintEditableCell(e);
                return;
            }
        }

        #endregion

        #region Editable Cell Painting

        private void PaintEditableCell(DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background);

            bool isSelected = Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;

            Rectangle inputBounds = new Rectangle(
                e.CellBounds.X + 6,
                e.CellBounds.Y + 6,
                e.CellBounds.Width - 12,
                e.CellBounds.Height - 12);

            using SolidBrush backBrush = new SolidBrush(_editableCellBackColor);
            using Pen borderPen = new Pen(isSelected ? _selectionBackColor : _editableCellBorderColor, 1);
            using StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using GraphicsPath path = CreateRoundedRectangle(inputBounds, 6);
            e.Graphics.FillPath(backBrush, path);
            e.Graphics.DrawPath(borderPen, path);

            e.Graphics.SmoothingMode = SmoothingMode.Default;

            string text = e.Value?.ToString() ?? "";

            using SolidBrush textBrush = new SolidBrush(_rowForeColor);
            e.Graphics.DrawString(text, _regularFont, textBrush, inputBounds, format);

            e.Handled = true;
        }

        #endregion

        #region Category Chip

        private void PaintCategoryChip(DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

            if (e.Value == null)
            {
                e.Handled = true;
                return;
            }

            string text = e.Value.ToString();
            bool selected = e.RowIndex >= 0 && Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;

            Color chipBackColor = selected ? Color.FromArgb(191, 219, 254) : Color.FromArgb(239, 246, 255);
            Color chipForeColor = Color.FromArgb(30, 64, 175);

            Rectangle bounds = new Rectangle(
                e.CellBounds.X + 8,
                e.CellBounds.Y + 7,
                e.CellBounds.Width - 16,
                e.CellBounds.Height - 14);

            using GraphicsPath path = CreateRoundedRectangle(bounds, 12);
            using SolidBrush backBrush = new SolidBrush(chipBackColor);
            using SolidBrush textBrush = new SolidBrush(chipForeColor);
            using StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(backBrush, path);
            e.Graphics.DrawString(text, _smallFont, textBrush, bounds, format);
            e.Graphics.SmoothingMode = SmoothingMode.Default;

            e.Handled = true;
        }

        #endregion

        #region Button Painting

        private (Color Back, Color Fore, Color Hover) GetButtonPalette(SabraButtonKind kind)
        {
            return kind switch
            {
                SabraButtonKind.Primary => (Color.FromArgb(219, 234, 254), Color.FromArgb(30, 64, 175), Color.FromArgb(191, 219, 254)),
                SabraButtonKind.Success => (Color.FromArgb(220, 252, 231), Color.FromArgb(22, 101, 52), Color.FromArgb(187, 247, 208)),
                SabraButtonKind.Danger => (Color.FromArgb(254, 226, 226), Color.FromArgb(153, 27, 27), Color.FromArgb(254, 202, 202)),
                SabraButtonKind.Warning => (Color.FromArgb(254, 243, 199), Color.FromArgb(146, 64, 14), Color.FromArgb(253, 230, 138)),
                _ => (_buttonBackColor, _buttonForeColor, _buttonHoverColor),
            };
        }

        private void PaintButtonCell(DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background);

            SabraButtonKind kind = SabraButtonKind.Default;
            string icon = null;

            if (Columns[e.ColumnIndex] is SabraButtonColumn sabraButtonColumn)
            {
                kind = sabraButtonColumn.Kind;
                icon = sabraButtonColumn.Icon;
            }

            var (backColor, foreColor, hoverColor) = GetButtonPalette(kind);

            bool isHovered = e.RowIndex == _hoveredRowIndex && e.ColumnIndex == _hoveredColumnIndex;

            Rectangle buttonBounds = new Rectangle(
                e.CellBounds.X + 6,
                e.CellBounds.Y + 6,
                e.CellBounds.Width - 12,
                e.CellBounds.Height - 12);

            using SolidBrush backgroundBrush = new SolidBrush(isHovered ? hoverColor : backColor);
            using SolidBrush textBrush = new SolidBrush(foreColor);
            using StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using GraphicsPath path = CreateRoundedRectangle(buttonBounds, 8);
            e.Graphics.FillPath(backgroundBrush, path);

            string text = e.Value?.ToString() ?? Columns[e.ColumnIndex].HeaderText;

            if (!string.IsNullOrEmpty(icon))
                text = $"{icon}  {text}";

            e.Graphics.DrawString(text, _smallFont, textBrush, buttonBounds, format);

            e.Graphics.SmoothingMode = SmoothingMode.Default;

            e.Handled = true;
        }

        #endregion

        #region Hover

        private void SabraDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Rows.Count)
                return;

            _hoveredRowIndex = e.RowIndex;
            _hoveredColumnIndex = e.ColumnIndex;

            if (Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                Cursor = Cursors.Hand;
                InvalidateCell(e.ColumnIndex, e.RowIndex);
                return;
            }

            if (EnableHoverEffect && !Rows[e.RowIndex].Selected)
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor = _hoverBackColor;
            }
        }

        private void SabraDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Rows.Count)
                return;

            bool wasButtonCell = Columns[e.ColumnIndex] is DataGridViewButtonColumn;

            if (_hoveredRowIndex == e.RowIndex && _hoveredColumnIndex == e.ColumnIndex)
            {
                _hoveredRowIndex = -1;
                _hoveredColumnIndex = -1;
            }

            if (wasButtonCell)
            {
                Cursor = Cursors.Default;
                InvalidateCell(e.ColumnIndex, e.RowIndex);
                return;
            }

            if (EnableHoverEffect && !Rows[e.RowIndex].Selected)
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    e.RowIndex % 2 == 0 ? _rowBackColor : _rowAlternateBackColor;
            }
        }

        #endregion

        #region Selection Fix

        protected override void OnSelectionChanged(EventArgs e)
        {
            base.OnSelectionChanged(e);

            foreach (DataGridViewRow row in Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Selected)
                {
                    row.DefaultCellStyle.SelectionBackColor = _selectionBackColor;
                    row.DefaultCellStyle.SelectionForeColor = _selectionForeColor;
                }
            }

            Invalidate();
        }

        #endregion

        #region Rounded Rectangle

        private GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        #endregion

        #region Outer Border

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!ShowOuterBorder)
                return;

            using Pen pen = new Pen(_gridLineColor, 1);
            Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);

            e.Graphics.DrawRectangle(pen, bounds);
        }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _regularFont?.Dispose();
                _boldFont?.Dispose();
                _smallFont?.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }


}
