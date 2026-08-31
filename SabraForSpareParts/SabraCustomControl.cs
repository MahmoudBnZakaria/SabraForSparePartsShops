using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class SabraCustomControl : Control
    {
    }

    public class SabraButton : IconButton
    {
        private int borderSize = 0;
        private int borderRadius = 20;
        private Color borderColor = Color.DodgerBlue;
        private Color hoverColor = Color.CornflowerBlue;
        private Color normalColor = Color.RoyalBlue;

        [Category("Custom Properties")]
        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; this.Invalidate(); }
        }

        [Category("Custom Properties")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; this.Invalidate(); }
        }

        [Category("Custom Properties")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }

        [Category("Custom Properties")]
        public Color HoverColor
        {
            get { return hoverColor; }
            set { hoverColor = value; }
        }

        [Category("Custom Properties")]
        public Color NormalColor
        {
            get { return normalColor; }
            set
            {
                normalColor = value;
                this.BackColor = normalColor;
                this.Invalidate();
            }
        }

        public SabraButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = normalColor;
            this.ForeColor = Color.White;
            this.Font = new Font("Cairo", 10F, FontStyle.Bold, GraphicsUnit.Point);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = hoverColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = normalColor;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (borderRadius > this.Height)
                borderRadius = this.Height;
            this.Invalidate();
        }

        // --- رسم الشكل الدائري للزرار ---
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                {
                    // حماية من NullReference لو الزرار مش موجود على Form لسه
                    Color parentColor = this.Parent != null ? this.Parent.BackColor : this.BackColor;

                    using (Pen penSurface = new Pen(parentColor, smoothSize))
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        this.Region = new Region(pathSurface);
                        pevent.Graphics.DrawPath(penSurface, pathSurface);
                        if (borderSize >= 1)
                            pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
    }


    public class SabraLabel : Label
    {
        private int borderRadius = 8;
        private int borderSize = 0;
        private Color borderColor = Color.DodgerBlue;
        private bool isTitle = false;

        [Category("Sabra Appearance")]
        [DefaultValue(false)]
        public bool IsTitle
        {
            get => isTitle;
            set
            {
                isTitle = value;
                Font = isTitle
                    ? new Font("Cairo", 12F, FontStyle.Bold)
                    : new Font("Cairo", 10F, FontStyle.Regular);
                Invalidate();
            }
        }

        [Category("Sabra Appearance")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = Math.Max(0, value); Invalidate(); }
        }

        [Category("Sabra Appearance")]
        public int BorderSize
        {
            get => borderSize;
            set { borderSize = Math.Max(0, value); Invalidate(); }
        }

        [Category("Sabra Appearance")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        public SabraLabel()
        {
            // تفعيل الرسم المخصص بالكامل ودعم الشفافية
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);

            DoubleBuffered = true;
            AutoSize = false;
            Size = new Size(120, 32);
            BackColor = Color.Transparent;
            TextAlign = ContentAlignment.MiddleRight;
            Padding = new Padding(0);
        }

        // --- إجبار الكنترول على إعادة الرسم عند تغيير الخصائص الأساسية ---
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            Invalidate();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }

        // بناء المسار الدائري مع حماية من الأرقام الكبيرة
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curve = radius * 2F;

            if (rect.Width <= 0 || rect.Height <= 0) return path;

            // لو مفيش انحناء، ارسم مستطيل عادي
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curve, curve, 180, 90);
            path.AddArc(rect.Right - curve, rect.Y, curve, curve, 270, 90);
            path.AddArc(rect.Right - curve, rect.Bottom - curve, curve, curve, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curve, curve, curve, 90, 90);
            path.CloseFigure();

            return path;
        }

        // ضبط محاذاة النص
        private TextFormatFlags GetTextAlignment()
        {
            TextFormatFlags flags = TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.WordBreak;

            // أفقي
            if (TextAlign == ContentAlignment.TopLeft || TextAlign == ContentAlignment.MiddleLeft || TextAlign == ContentAlignment.BottomLeft)
                flags |= TextFormatFlags.Left;
            else if (TextAlign == ContentAlignment.TopCenter || TextAlign == ContentAlignment.MiddleCenter || TextAlign == ContentAlignment.BottomCenter)
                flags |= TextFormatFlags.HorizontalCenter;
            else
                flags |= TextFormatFlags.Right;

            // عمودي
            if (TextAlign == ContentAlignment.TopLeft || TextAlign == ContentAlignment.TopCenter || TextAlign == ContentAlignment.TopRight)
                flags |= TextFormatFlags.Top;
            else if (TextAlign == ContentAlignment.MiddleLeft || TextAlign == ContentAlignment.MiddleCenter || TextAlign == ContentAlignment.MiddleRight)
                flags |= TextFormatFlags.VerticalCenter;
            else
                flags |= TextFormatFlags.Bottom;

            return flags;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // تحسين جودة الرسم لأقصى درجة
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);

            // حماية: التأكد إن الـ Radius مش أكبر من نص حجم الكنترول عشان الشكل ميبوظش
            float safeRadius = Math.Min(borderRadius, Math.Min(rectSurface.Width / 2, rectSurface.Height / 2));

            bool hasBorder = borderSize > 0;
            float borderHalf = hasBorder ? borderSize / 2f : 0f;

            // مستطيل الإطار (أصغر شوية عشان يترسم جوه الكنترول بالظبط وميتقصش منه حاجة)
            RectangleF rectBorder = new RectangleF(
                borderHalf, borderHalf,
                rectSurface.Width - borderSize,
                rectSurface.Height - borderSize);

            float safeBorderRadius = Math.Min(borderRadius, Math.Min(rectBorder.Width / 2, rectBorder.Height / 2));

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, safeRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, safeBorderRadius))
            {
                // 1. رسم الخلفية
                if (BackColor != Color.Transparent)
                {
                    using (SolidBrush brush = new SolidBrush(BackColor))
                    {
                        e.Graphics.FillPath(brush, pathSurface);
                    }
                }

                // 2. رسم الإطار
                if (hasBorder)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Center;
                        e.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }

            // 3. رسم النص
            Rectangle rectText = new Rectangle(
                Padding.Left,
                Padding.Top,
                this.Width - Padding.Horizontal,
                this.Height - Padding.Vertical
            );

            // رسم النص باستخدام ForeColor اللي بيتحدث تلقائي
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, rectText, this.ForeColor, GetTextAlignment());
        }
    }


    public class SabraTextBox : TextBox
    {
        // ==============================
        // Custom Properties
        // ==============================

        private Color borderColor = Color.DodgerBlue;
        private Color borderFocusColor = Color.DeepSkyBlue;

        private int borderRadius = 10;
        private int borderSize = 1;

        private bool underlinedStyle = false;
        private bool isFocused = false;

        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPassword = false;

        // Internal TextBox
        private TextBox textBox1;

        // ==============================
        // Events
        // ==============================

        public new event EventHandler TextChanged;

        // ==============================
        // Border Color
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(typeof(Color), "DodgerBlue")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        // ==============================
        // Border Focus Color
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(typeof(Color), "DeepSkyBlue")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set
            {
                borderFocusColor = value;
                Invalidate();
            }
        }

        // ==============================
        // Border Size
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(1)]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value < 1)
                    value = 1;

                borderSize = value;
                Invalidate();
            }
        }

        // ==============================
        // Border Radius
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(10)]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value < 0)
                    value = 0;

                borderRadius = value;
                Invalidate();
            }
        }

        // ==============================
        // Underlined Style
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(false)]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                Invalidate();
            }
        }

        // ==============================
        // Password
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(false)]
        public bool PasswordChar
        {
            get { return isPassword; }
            set
            {
                isPassword = value;

                if (!isPlaceholder)
                    textBox1.UseSystemPasswordChar = value;
            }
        }

        // ==============================
        // Multiline
        // ==============================

        [Category("Custom Properties")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set
            {
                textBox1.Multiline = value;
                UpdateControlHeight();
            }
        }

        // ==============================
        // BackColor
        // ==============================

        [Category("Custom Properties")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;

                if (textBox1 != null)
                    textBox1.BackColor = value;

                Invalidate();
            }
        }

        // ==============================
        // ForeColor
        // ==============================

        [Category("Custom Properties")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;

                if (textBox1 != null && !isPlaceholder)
                    textBox1.ForeColor = value;

                Invalidate();
            }
        }

        // ==============================
        // Font
        // ==============================

        [Category("Custom Properties")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;

                if (textBox1 != null)
                    textBox1.Font = value;

                UpdateControlHeight();
            }
        }

        // ==============================
        // Text
        // ==============================

        [Category("Custom Properties")]
        [Browsable(false)]
        public string Texts
        {
            get
            {
                if (isPlaceholder)
                    return "";

                return textBox1.Text;
            }
            set
            {
                if (textBox1 == null)
                    return;

                isPlaceholder = false;
                textBox1.Text = value;

                if (string.IsNullOrWhiteSpace(value))
                    SetPlaceholder();
            }
        }

        // ==============================
        // Placeholder Text
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue("")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;

                if (textBox1 != null)
                {
                    textBox1.Text = "";
                    SetPlaceholder();
                }
            }
        }

        // ==============================
        // Placeholder Color
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(typeof(Color), "DarkGray")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;

                if (isPlaceholder && textBox1 != null)
                    textBox1.ForeColor = value;

                Invalidate();
            }
        }

        // ==============================
        // Constructor
        // ==============================

        public SabraTextBox()
        {
            textBox1 = new TextBox();

            SuspendLayout();

            // ==============================
            // Internal TextBox
            // ==============================

            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(10, 7);
            textBox1.Name = "textBox1";
            textBox1.TabIndex = 0;

            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;

            // ==============================
            // Main Control
            // ==============================

            Controls.Add(textBox1);

            Padding = new Padding(10, 7, 10, 7);

            Size = new Size(250, 40);

            BackColor = Color.White;

            ForeColor = Color.FromArgb(64, 64, 64);

            RightToLeft = RightToLeft.Yes;

            Font = new Font(
                "Cairo",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            // ==============================
            // Finish
            // ==============================

            ResumeLayout(false);
            PerformLayout();

            UpdateControlHeight();
        }

        // ==============================
        // Placeholder
        // ==============================

        private void SetPlaceholder()
        {
            if (textBox1 == null)
                return;

            if (
                string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrWhiteSpace(placeholderText)
            )
            {
                isPlaceholder = true;

                textBox1.Text = placeholderText;

                textBox1.ForeColor = placeholderColor;

                if (isPassword)
                    textBox1.UseSystemPasswordChar = false;
            }
        }

        private void RemovePlaceholder()
        {
            if (
                isPlaceholder &&
                !string.IsNullOrWhiteSpace(placeholderText)
            )
            {
                isPlaceholder = false;

                textBox1.Text = "";

                textBox1.ForeColor = ForeColor;

                if (isPassword)
                    textBox1.UseSystemPasswordChar = true;
            }
        }

        // ==============================
        // Text Changed
        // ==============================

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
                TextChanged.Invoke(sender, e);
        }

        // ==============================
        // Enter
        // ==============================

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;

            RemovePlaceholder();

            Invalidate();
        }

        // ==============================
        // Leave
        // ==============================

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;

            SetPlaceholder();

            Invalidate();
        }

        // ==============================
        // Update Height
        // ==============================

        private void UpdateControlHeight()
        {
            if (textBox1 == null)
                return;

            if (!textBox1.Multiline)
            {
                int textHeight =
                    TextRenderer.MeasureText(
                        "Text",
                        Font
                    ).Height + 1;

                textBox1.MinimumSize =
                    new Size(0, textHeight);

                Height =
                    textHeight +
                    Padding.Top +
                    Padding.Bottom;
            }
        }

        // ==============================
        // Resize
        // ==============================

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            UpdateControlHeight();

            Invalidate();
        }

        // ==============================
        // Paint
        // ==============================

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode =
                SmoothingMode.AntiAlias;

            Color currentBorderColor =
                isFocused
                    ? borderFocusColor
                    : borderColor;

            using (Pen penBorder =
                new Pen(
                    currentBorderColor,
                    borderSize
                ))
            {
                penBorder.Alignment =
                    PenAlignment.Inset;

                // ==============================
                // Underline
                // ==============================

                if (underlinedStyle)
                {
                    g.DrawLine(
                        penBorder,
                        0,
                        Height - 1,
                        Width,
                        Height - 1
                    );

                    return;
                }

                // ==============================
                // Rounded Border
                // ==============================

                int radius = Math.Min(
                    borderRadius,
                    Math.Min(
                        Width,
                        Height
                    ) / 2
                );

                RectangleF rect =
                    new RectangleF(
                        borderSize / 2f,
                        borderSize / 2f,
                        Width - borderSize,
                        Height - borderSize
                    );

                using (GraphicsPath path =
                    new GraphicsPath())
                {
                    if (radius == 0)
                    {
                        path.AddRectangle(rect);
                    }
                    else
                    {
                        float diameter =
                            radius * 2;

                        path.AddArc(
                            rect.X,
                            rect.Y,
                            diameter,
                            diameter,
                            180,
                            90
                        );

                        path.AddArc(
                            rect.Right - diameter,
                            rect.Y,
                            diameter,
                            diameter,
                            270,
                            90
                        );

                        path.AddArc(
                            rect.Right - diameter,
                            rect.Bottom - diameter,
                            diameter,
                            diameter,
                            0,
                            90
                        );

                        path.AddArc(
                            rect.X,
                            rect.Bottom - diameter,
                            diameter,
                            diameter,
                            90,
                            90
                        );

                        path.CloseFigure();
                    }

                    g.DrawPath(
                        penBorder,
                        path
                    );
                }
            }
        }

    }
    public class SabraComboBox : ComboBox
    {
        // ==============================
        // Custom Properties
        // ==============================

        private Color borderColor = Color.DodgerBlue;
        private Color borderFocusColor = Color.DeepSkyBlue;

        private int borderSize = 1;

        private bool underlinedStyle = false;
        private bool isFocused = false;

        private Color arrowColor = Color.DodgerBlue;

        private int defaultSelectedIndex = 0;

        [Category("Custom Properties")]
        [DefaultValue(0)]
        public int DefaultSelectedIndex
        {
            get { return defaultSelectedIndex; }
            set
            {
                defaultSelectedIndex = value;

                if (Items.Count > 0 &&
                    value >= 0 &&
                    value < Items.Count)
                {
                    SelectedIndex = value;
                }

                Invalidate();
            }
        }

        // ==============================
        // Border Color
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(typeof(Color), "DodgerBlue")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        // ==============================
        // Border Focus Color
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(typeof(Color), "DeepSkyBlue")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set
            {
                borderFocusColor = value;
                Invalidate();
            }
        }

        // ==============================
        // Border Size
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(1)]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value < 1)
                    value = 1;

                borderSize = value;
                Invalidate();
            }
        }

        // ==============================
        // Underlined Style
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(false)]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                Invalidate();
            }
        }

        // ==============================
        // Arrow Color
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(typeof(Color), "DodgerBlue")]
        public Color ArrowColor
        {
            get { return arrowColor; }
            set
            {
                arrowColor = value;
                Invalidate();
            }
        }

        // ==============================
        // Constructor
        // ==============================

        public SabraComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            this.FlatStyle = FlatStyle.Flat;

            this.BackColor = Color.White;
            this.ForeColor = Color.FromArgb(64, 64, 64);

            this.RightToLeft = RightToLeft.Yes;

            this.Font = new Font(
                "Cairo",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            this.Size = new Size(250, 40);

            this.ItemHeight = 30;

            this.DropDown += SabraComboBox_DropDown;
            this.DropDownClosed += SabraComboBox_DropDownClosed;

            this.Enter += SabraComboBox_Enter;
            this.Leave += SabraComboBox_Leave;
        }

        // ==============================
        // Focus
        // ==============================

        private void SabraComboBox_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            Invalidate();
        }

        private void SabraComboBox_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            Invalidate();
        }

        // ==============================
        // Dropdown
        // ==============================

        private void SabraComboBox_DropDown(object sender, EventArgs e)
        {
            isFocused = true;
            Invalidate();
        }

        private void SabraComboBox_DropDownClosed(object sender, EventArgs e)
        {
            isFocused = false;
            Invalidate();
        }

        // ==============================
        // Draw Items
        // ==============================

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (e.Index < 0)
                return;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            bool selected =
                (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color backgroundColor = selected
                ? Color.FromArgb(240, 245, 250)
                : BackColor;

            using (SolidBrush backgroundBrush =
                    new SolidBrush(backgroundColor))
            {
                g.FillRectangle(
                    backgroundBrush,
                    e.Bounds
                );
            }

            string text = GetItemText(Items[e.Index]);

            TextFormatFlags flags =
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.Right;

            Rectangle textRectangle = new Rectangle(
                10,
                e.Bounds.Y,
                e.Bounds.Width - 20,
                e.Bounds.Height
            );

            TextRenderer.DrawText(
                g,
                text,
                Font,
                textRectangle,
                ForeColor,
                flags
            );

            e.DrawFocusRectangle();
        }

        // ==============================
        // Paint
        // ==============================

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color currentBorderColor =
                isFocused
                    ? borderFocusColor
                    : borderColor;

            using (Pen penBorder =
                    new Pen(currentBorderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;

                if (underlinedStyle)
                {
                    g.DrawLine(
                        penBorder,
                        0,
                        Height - 1,
                        Width,
                        Height - 1
                    );
                }
                else
                {
                    g.DrawRectangle(
                        penBorder,
                        0,
                        0,
                        Width - 1,
                        Height - 1
                    );
                }
            }
        }

        // ==============================
        // Resize
        // ==============================

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Invalidate();
        }
    }

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

        private Color _buttonBackColor = Color.White;
        private Color _buttonForeColor = Color.FromArgb(51, 65, 85);
        private Color _buttonHoverColor = Color.FromArgb(238, 242, 255);
        #endregion

        #region Cached Fonts
        // بدل ما نعمل new Font() جوه كل رسمة/كل ثيم (بيتكرر آلاف المرات وقت الـ scroll)
        // بنعمل الخطوط دي مرة واحدة بس ونعيد استخدامها، وبنتخلص منها في Dispose.
        private Font _regularFont;
        private Font _boldFont;
        private Font _smallFont;
        #endregion

        #region Appearance Properties

        [Category("Sabra Appearance")]
        [Description("لون خلفية رأس الجدول")]
        public Color HeaderBackColor
        {
            get => _headerBackColor;
            set
            {
                _headerBackColor = value;
                ApplyTheme();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون نص رأس الجدول")]
        public Color HeaderForeColor
        {
            get => _headerForeColor;
            set
            {
                _headerForeColor = value;
                ApplyTheme();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون الصفوف")]
        public Color RowBackColor
        {
            get => _rowBackColor;
            set
            {
                _rowBackColor = value;
                ApplyTheme();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون الصفوف البديلة")]
        public Color RowAlternateBackColor
        {
            get => _rowAlternateBackColor;
            set
            {
                _rowAlternateBackColor = value;
                ApplyTheme();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون نص الصفوف")]
        public Color RowForeColor
        {
            get => _rowForeColor;
            set
            {
                _rowForeColor = value;
                ApplyTheme();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون خلفية الصف المحدد")]
        public Color SelectionBackColor
        {
            get => _selectionBackColor;
            set
            {
                _selectionBackColor = value;
                ApplyTheme();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون نص الصف المحدد")]
        public Color SelectionForeColor
        {
            get => _selectionForeColor;
            set
            {
                _selectionForeColor = value;
                ApplyTheme();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون الصف عند مرور الماوس")]
        public Color HoverBackColor
        {
            get => _hoverBackColor;
            set
            {
                _hoverBackColor = value;
                Invalidate();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون خطوط الجدول")]
        public Color GridLineCustomColor
        {
            get => _gridLineColor;
            set
            {
                _gridLineColor = value;
                ApplyTheme();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون خلفية أزرار الجدول")]
        public Color ButtonBackColor
        {
            get => _buttonBackColor;
            set
            {
                _buttonBackColor = value;
                ApplyTheme();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون نص أزرار الجدول")]
        public Color ButtonForeColor
        {
            get => _buttonForeColor;
            set
            {
                _buttonForeColor = value;
                ApplyTheme();
            }
        }

        [Category("Sabra Appearance")]
        [Description("لون الزر عند مرور الماوس")]
        public Color ButtonHoverColor
        {
            get => _buttonHoverColor;
            set
            {
                _buttonHoverColor = value;
                Invalidate();
            }
        }

        #endregion

        #region Layout Properties

        [Category("Sabra Layout")]
        [DefaultValue(44)]
        public int HeaderHeight
        {
            get => ColumnHeadersHeight;
            set
            {
                ColumnHeadersHeight = Math.Max(30, value);
                Invalidate();
            }
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

        // كانت الخاصية دي معمولة بس مش متوصّلة بحاجة فعليًا (dead property) —
        // الفاصل بين الصفوف كان جاي من قيمة CellBorderStyle المكتوبة تابت في InitializeGrid.
        // دلوقتي هي فعليًا اللي بتتحكم في ظهور الخط الفاصل، والافتراضي False (من غير بوردرز).
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

            CellFormatting += SabraDataGridView_CellFormatting;
            CellPainting += SabraDataGridView_CellPainting;
            CellMouseEnter += SabraDataGridView_CellMouseEnter;
            CellMouseLeave += SabraDataGridView_CellMouseLeave;

            ApplyTheme();
        }

        #endregion

        #region Fonts Init

        private void InitializeFonts()
        {
            _regularFont =
                new Font(
                    "Cairo",
                    10F,
                    FontStyle.Regular,
                    GraphicsUnit.Point);

            _boldFont =
                new Font(
                    "Cairo",
                    10F,
                    FontStyle.Bold,
                    GraphicsUnit.Point);

            _smallFont =
                new Font(
                    "Cairo",
                    9F,
                    FontStyle.Regular,
                    GraphicsUnit.Point);
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

            ReadOnly = true;

            MultiSelect = false;

            SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            RowHeadersVisible = false;

            RightToLeft = RightToLeft.Yes;

            Font = _regularFont;

            // مفيش خطوط فاصلة بين الخلايا افتراضيًا (كانت رخمة الشكل).
            // لو حد حابب يرجعها يقدر يفعّل ShowCellBorders = true.
            CellBorderStyle =
                _showCellBorders
                    ? DataGridViewCellBorderStyle.SingleHorizontal
                    : DataGridViewCellBorderStyle.None;

            ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            RowTemplate.Height = 42;

            ColumnHeadersHeight = 44;

            ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            ScrollBars =
                ScrollBars.Both;

            ShowCellToolTips = true;

            AllowUserToResizeColumns = true;

            AllowUserToResizeRows = false;
        }

        #endregion

        #region Theme

        private void ApplyTheme()
        {
            SuspendLayout();

            // Header
            ColumnHeadersDefaultCellStyle.BackColor =
                _headerBackColor;

            ColumnHeadersDefaultCellStyle.ForeColor =
                _headerForeColor;

            ColumnHeadersDefaultCellStyle.Font =
                _boldFont;

            ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            ColumnHeadersDefaultCellStyle.SelectionBackColor =
                _headerBackColor;

            ColumnHeadersDefaultCellStyle.SelectionForeColor =
                _headerForeColor;

            ColumnHeadersDefaultCellStyle.Padding =
                new Padding(8, 0, 8, 0);

            // Normal cells
            DefaultCellStyle.BackColor =
                _rowBackColor;

            DefaultCellStyle.ForeColor =
                _rowForeColor;

            DefaultCellStyle.Font =
                _regularFont;

            DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            DefaultCellStyle.SelectionBackColor =
                _selectionBackColor;

            DefaultCellStyle.SelectionForeColor =
                _selectionForeColor;

            DefaultCellStyle.Padding =
                new Padding(8, 0, 8, 0);

            DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            // Alternating rows
            AlternatingRowsDefaultCellStyle.BackColor =
                _rowAlternateBackColor;

            AlternatingRowsDefaultCellStyle.ForeColor =
                _rowForeColor;

            AlternatingRowsDefaultCellStyle.SelectionBackColor =
                _selectionBackColor;

            AlternatingRowsDefaultCellStyle.SelectionForeColor =
                _selectionForeColor;

            // Grid
            GridColor = _gridLineColor;

            // Row headers
            RowHeadersDefaultCellStyle.SelectionBackColor =
                _selectionBackColor;

            RowHeadersDefaultCellStyle.SelectionForeColor =
                _selectionForeColor;

            ResumeLayout();
        }

        #endregion

        #region Cell Formatting

        private void SabraDataGridView_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;

            DataGridViewCell cell =
                Rows[e.RowIndex].Cells[e.ColumnIndex];

            string columnName =
                Columns[e.ColumnIndex].Name;

            // مهم جدًا:
            // التحديد لازم يفضل بلون النص الواضح
            // بدل ما الخلية تاخد لون نص باهت.

            if (cell.Selected)
            {
                e.CellStyle.SelectionBackColor =
                    _selectionBackColor;

                e.CellStyle.SelectionForeColor =
                    _selectionForeColor;
            }

            // Quantity
            if (columnName == "Quantity" ||
                columnName == "الكمية")
            {
                if (e.Value != null &&
                    decimal.TryParse(
                        e.Value.ToString(),
                        out decimal quantity))
                {
                    if (quantity <= 0)
                    {
                        e.CellStyle.ForeColor =
                            Color.FromArgb(220, 38, 38);
                    }
                    else if (quantity < 5)
                    {
                        e.CellStyle.ForeColor =
                            Color.FromArgb(217, 119, 6);
                    }
                    else
                    {
                        e.CellStyle.ForeColor =
                            Color.FromArgb(22, 163, 74);
                    }

                    // عند تحديد الصف:
                    // نخلي النص غامق وواضح
                    if (cell.Selected)
                    {
                        e.CellStyle.SelectionForeColor =
                            _selectionForeColor;
                    }
                }
            }
        }

        #endregion

        #region Cell Painting

        private void SabraDataGridView_CellPainting(
            object sender,
            DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;

            string columnName =
                Columns[e.ColumnIndex].Name;

            // Category Chip
            if (columnName == "Category" ||
                columnName == "التصنيف")
            {
                PaintCategoryChip(e);

                return;
            }

            // Button
            if (Columns[e.ColumnIndex]
                is DataGridViewButtonColumn)
            {
                PaintButtonCell(e);

                return;
            }
        }

        #endregion

        #region Category Chip

        private void PaintCategoryChip(
            DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(
                e.CellBounds,
                DataGridViewPaintParts.Background |
                DataGridViewPaintParts.Border);

            if (e.Value == null)
            {
                e.Handled = true;
                return;
            }

            string text = e.Value.ToString();

            bool selected = e.RowIndex >= 0 &&
                            Rows[e.RowIndex]
                            .Cells[e.ColumnIndex]
                            .Selected;

            Color chipBackColor;
            Color chipForeColor;

            if (selected)
            {
                chipBackColor =
                    Color.FromArgb(191, 219, 254);

                chipForeColor =
                    Color.FromArgb(30, 64, 175);
            }
            else
            {
                chipBackColor =
                    Color.FromArgb(239, 246, 255);

                chipForeColor =
                    Color.FromArgb(30, 64, 175);
            }

            Rectangle bounds =
                new Rectangle(
                    e.CellBounds.X + 8,
                    e.CellBounds.Y + 7,
                    e.CellBounds.Width - 16,
                    e.CellBounds.Height - 14);

            using GraphicsPath path =
                CreateRoundedRectangle(
                    bounds,
                    12);

            using SolidBrush backBrush =
                new SolidBrush(chipBackColor);

            using SolidBrush textBrush =
                new SolidBrush(chipForeColor);

            using StringFormat format =
                new StringFormat
                {
                    Alignment =
                        StringAlignment.Center,

                    LineAlignment =
                        StringAlignment.Center
                };

            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;

            e.Graphics.FillPath(
                backBrush,
                path);

            e.Graphics.DrawString(
                text,
                _smallFont,
                textBrush,
                bounds,
                format);

            e.Graphics.SmoothingMode =
                SmoothingMode.Default;

            e.Handled = true;
        }

        #endregion

        #region Button Painting

        private void PaintButtonCell(
            DataGridViewCellPaintingEventArgs e)
        {
            bool selected =
                Rows[e.RowIndex]
                .Cells[e.ColumnIndex]
                .Selected;

            Color backgroundColor =
                selected
                    ? _buttonHoverColor
                    : _buttonBackColor;

            Color foregroundColor =
                _buttonForeColor;

            e.Paint(
                e.CellBounds,
                DataGridViewPaintParts.Border);

            Rectangle buttonBounds =
                new Rectangle(
                    e.CellBounds.X + 5,
                    e.CellBounds.Y + 5,
                    e.CellBounds.Width - 10,
                    e.CellBounds.Height - 10);

            using SolidBrush backgroundBrush =
                new SolidBrush(backgroundColor);

            using Pen borderPen =
                new Pen(
                    _gridLineColor,
                    1);

            using SolidBrush textBrush =
                new SolidBrush(foregroundColor);

            using StringFormat format =
                new StringFormat
                {
                    Alignment =
                        StringAlignment.Center,

                    LineAlignment =
                        StringAlignment.Center
                };

            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;

            e.Graphics.FillRectangle(
                backgroundBrush,
                buttonBounds);

            e.Graphics.DrawRectangle(
                borderPen,
                buttonBounds);

            string text =
                e.Value?.ToString() ??
                Columns[e.ColumnIndex]
                .HeaderText;

            e.Graphics.DrawString(
                text,
                _smallFont,
                textBrush,
                buttonBounds,
                format);

            e.Graphics.SmoothingMode =
                SmoothingMode.Default;

            e.Handled = true;
        }

        #endregion

        #region Hover

        private void SabraDataGridView_CellMouseEnter(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (!EnableHoverEffect ||
                e.RowIndex < 0)
                return;

            if (e.RowIndex >= Rows.Count)
                return;

            if (Rows[e.RowIndex].Selected)
                return;

            Rows[e.RowIndex].DefaultCellStyle.BackColor =
                _hoverBackColor;
        }

        private void SabraDataGridView_CellMouseLeave(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (!EnableHoverEffect ||
                e.RowIndex < 0)
                return;

            if (e.RowIndex >= Rows.Count)
                return;

            if (Rows[e.RowIndex].Selected)
                return;

            Rows[e.RowIndex].DefaultCellStyle.BackColor =
                e.RowIndex % 2 == 0
                    ? _rowBackColor
                    : _rowAlternateBackColor;
        }

        #endregion

        #region Selection Fix

        protected override void OnSelectionChanged(
            EventArgs e)
        {
            base.OnSelectionChanged(e);

            foreach (DataGridViewRow row in Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Selected)
                {
                    row.DefaultCellStyle.SelectionBackColor =
                        _selectionBackColor;

                    row.DefaultCellStyle.SelectionForeColor =
                        _selectionForeColor;
                }
            }

            Invalidate();
        }

        #endregion

        #region Rounded Rectangle

        private GraphicsPath CreateRoundedRectangle(
            Rectangle bounds,
            int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            path.AddArc(
                bounds.X,
                bounds.Y,
                diameter,
                diameter,
                180,
                90);

            path.AddArc(
                bounds.Right - diameter,
                bounds.Y,
                diameter,
                diameter,
                270,
                90);

            path.AddArc(
                bounds.Right - diameter,
                bounds.Bottom - diameter,
                diameter,
                diameter,
                0,
                90);

            path.AddArc(
                bounds.X,
                bounds.Bottom - diameter,
                diameter,
                diameter,
                90,
                90);

            path.CloseFigure();

            return path;
        }

        #endregion

        #region Outer Border

        protected override void OnPaint(
            PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!ShowOuterBorder)
                return;

            using Pen pen =
                new Pen(
                    _gridLineColor,
                    1);

            Rectangle bounds =
                new Rectangle(
                    0,
                    0,
                    Width - 1,
                    Height - 1);

            e.Graphics.DrawRectangle(
                pen,
                bounds);
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

    public class SabraPanel : Panel
    {
        private int borderRadius = 15;
        private int borderSize = 0;
        private Color borderColor = Color.LightGray;

        private Color gradientTopColor = Color.White;
        private Color gradientBottomColor = Color.White;
        private float gradientAngle = 90F;

        private bool enableHover = true;
        private Color hoverBackColor = Color.FromArgb(245, 248, 255);
        private Color hoverBorderColor = Color.FromArgb(37, 99, 235);
        private int hoverBorderSize = 2;

        private Color normalBackColor;
        private Color normalBorderColor;
        private int normalBorderSize;
        private bool isHovered = false;

        private GraphicsPath pathSurface;
        private GraphicsPath pathBorder;

        #region Properties

        [Category("Sabra Hover")]
        public bool EnableHover
        {
            get => enableHover;
            set => enableHover = value;
        }

        [Category("Sabra Hover")]
        public Color HoverBackColor { get => hoverBackColor; set => hoverBackColor = value; }

        [Category("Sabra Hover")]
        public Color HoverBorderColor { get => hoverBorderColor; set => hoverBorderColor = value; }

        [Category("Sabra Hover")]
        public int HoverBorderSize { get => hoverBorderSize; set => hoverBorderSize = value; }

        [Category("Sabra Custom")]
        public int BorderRadius
        {
            get => borderRadius;
            set { if (borderRadius != value) { borderRadius = value; UpdatePathsAndRegion(); Invalidate(); } }
        }

        [Category("Sabra Custom")]
        public int BorderSize
        {
            get => borderSize;
            set { if (borderSize != value) { borderSize = value; UpdatePathsAndRegion(); Invalidate(); } }
        }

        [Category("Sabra Custom")]
        public Color BorderColor
        {
            get => borderColor;
            set { if (borderColor != value) { borderColor = value; Invalidate(); } }
        }

        [Category("Sabra Custom")]
        public Color GradientTopColor
        {
            get => gradientTopColor;
            set { if (gradientTopColor != value) { gradientTopColor = value; Invalidate(); } }
        }

        [Category("Sabra Custom")]
        public Color GradientBottomColor
        {
            get => gradientBottomColor;
            set { if (gradientBottomColor != value) { gradientBottomColor = value; Invalidate(); } }
        }

        [Category("Sabra Custom")]
        public float GradientAngle
        {
            get => gradientAngle;
            set { if (gradientAngle != value) { gradientAngle = value; Invalidate(); } }
        }

        #endregion

        public SabraPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            BackColor = Color.White;
            ForeColor = Color.Black;
            Size = new Size(200, 150);

            normalBackColor = BackColor;
            normalBorderColor = borderColor;
            normalBorderSize = borderSize;

            MouseEnter += Control_MouseEnter;
            MouseLeave += Control_MouseLeave;

            // تسجيل الأحداث بطريقة تمنع الـ Memory Leak
            ControlAdded += Child_ControlAdded;
            ControlRemoved += Child_ControlRemoved;
        }

        #region Event Management

        private void Child_ControlAdded(object sender, ControlEventArgs e)
        {
            RegisterChildEvents(e.Control);
        }

        private void Child_ControlRemoved(object sender, ControlEventArgs e)
        {
            UnregisterChildEvents(e.Control);
        }

        private void RegisterChildEvents(Control child)
        {
            child.MouseEnter += Control_MouseEnter;
            child.MouseLeave += Control_MouseLeave;
            child.ControlAdded += Child_ControlAdded;
            child.ControlRemoved += Child_ControlRemoved;

            foreach (Control c in child.Controls) RegisterChildEvents(c);
        }

        private void UnregisterChildEvents(Control child)
        {
            child.MouseEnter -= Control_MouseEnter;
            child.MouseLeave -= Control_MouseLeave;
            child.ControlAdded -= Child_ControlAdded;
            child.ControlRemoved -= Child_ControlRemoved;

            foreach (Control c in child.Controls) UnregisterChildEvents(c);
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            if (!enableHover || isHovered) return;

            isHovered = true;
            normalBackColor = BackColor;
            normalBorderColor = borderColor;
            normalBorderSize = borderSize;

            BackColor = hoverBackColor;
            borderColor = hoverBorderColor;
            borderSize = hoverBorderSize;
            Cursor = Cursors.Hand;

            UpdatePathsAndRegion();
            Invalidate();
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            if (!enableHover || !isHovered) return;

            Point p = PointToClient(Cursor.Position);
            if (ClientRectangle.Contains(p)) return;

            isHovered = false;
            BackColor = normalBackColor;
            borderColor = normalBorderColor;
            borderSize = normalBorderSize;
            Cursor = Cursors.Default;

            UpdatePathsAndRegion();
            Invalidate();
        }

        #endregion

        #region Drawing Methods

        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0) radius = 1;
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void UpdatePathsAndRegion()
        {
            Rectangle rectSurface = this.ClientRectangle;
            if (rectSurface.Width <= 0 || rectSurface.Height <= 0) return;

            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);

            pathSurface?.Dispose();
            pathBorder?.Dispose();

            if (borderRadius > 2)
            {
                pathSurface = GetFigurePath(rectSurface, borderRadius);
                pathBorder = GetFigurePath(rectBorder, Math.Max(1, borderRadius - borderSize));

                Region oldRegion = this.Region;
                this.Region = new Region(pathSurface);
                oldRegion?.Dispose();
            }
            else
            {
                pathSurface = null;
                pathBorder = null;

                Region oldRegion = this.Region;
                this.Region = new Region(rectSurface);
                oldRegion?.Dispose();
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            UpdatePathsAndRegion();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (ClientRectangle.Width <= 0 || ClientRectangle.Height <= 0) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // تحديد ألوان الرسم بناءً على حالة المؤشر (Hover)
            Color currentTop = (isHovered && enableHover) ? hoverBackColor : gradientTopColor;
            Color currentBottom = (isHovered && enableHover) ? hoverBackColor : gradientBottomColor;

            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(ClientRectangle, currentTop, currentBottom, gradientAngle))
            {
                if (borderRadius > 2 && pathSurface != null)
                {
                    e.Graphics.FillPath(gradientBrush, pathSurface);

                    if (borderSize > 0 && pathBorder != null)
                    {
                        using (Pen penBorder = new Pen(borderColor, borderSize))
                        {
                            e.Graphics.DrawPath(penBorder, pathBorder);
                        }
                    }
                }
                else
                {
                    e.Graphics.FillRectangle(gradientBrush, ClientRectangle);

                    if (borderSize > 0)
                    {
                        using (Pen penBorder = new Pen(borderColor, borderSize) { Alignment = PenAlignment.Inset })
                        {
                            e.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                        }
                    }
                }
            }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pathSurface?.Dispose();
                pathBorder?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class SabraTableLayoutPanel : TableLayoutPanel
    {
        #region Fields

        private int columns = 12;
        private int rows = 3;

        #endregion

        #region Properties

        [Category("Sabra Layout")]
        [DefaultValue(12)]
        public int Columns
        {
            get => columns;
            set
            {
                if (value <= 0) return;

                columns = value;
                BuildColumns();
            }
        }

        [Category("Sabra Layout")]
        [DefaultValue(1)]
        public int Rows
        {
            get => rows;
            set
            {
                if (value <= 0) return;

                rows = value;
                BuildRows();
            }
        }

        #endregion

        #region Constructor

        public SabraTableLayoutPanel()
        {
            SuspendLayout();

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);

            DoubleBuffered = true;

            // Appearance
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(40, 40, 40);

            // Layout
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            Padding = new Padding(30);

            // Behavior
            AutoScroll = true;
            AutoSize = false;
            GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            // RTL
            RightToLeft = RightToLeft.Yes;

            // Default Grid
            BuildColumns();
            BuildRows();

            ResumeLayout(false);
        }

        #endregion

        #region Private Methods

        private void BuildColumns()
        {
            SuspendLayout();

            ColumnCount = columns;
            ColumnStyles.Clear();

            float percent = 100f / columns;

            for (int i = 0; i < columns; i++)
            {
                ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, percent));
            }

            ResumeLayout();
        }

        private void BuildRows()
        {
            SuspendLayout();

            RowCount = rows;
            RowStyles.Clear();

            float percent = 100f / rows;

            for (int i = 0; i < rows; i++)
            {
                RowStyles.Add(
                    new RowStyle(SizeType.Percent, percent));
            }

            ResumeLayout();
        }

        #endregion
    }

    public class SabraUserControl : UserControl
    {
        #region Fields

        private int borderRadius = 0;
        private int borderSize = 0;
        private Color borderColor = Color.Transparent;

        #endregion

        #region Properties

        [Category("Sabra Appearance")]
        [DefaultValue(0)]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        [Category("Sabra Appearance")]
        [DefaultValue(0)]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        [Category("Sabra Appearance")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor

        public SabraUserControl()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);

            DoubleBuffered = true;

            Font = new Font("Cairo", 10F, FontStyle.Regular);

            BackColor = Color.WhiteSmoke;
            ForeColor = Color.FromArgb(40, 40, 40);

            Margin = new Padding(0);
            Padding = new Padding(10);

            //Dock = DockStyle.Fill;

            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout();

            AutoScaleMode = AutoScaleMode.Dpi;

            AutoScrollMinSize = new Size(1502, 1000);
            MinimumSize = new Size(900, 600);
            Size = new Size(1502, 1045);
        }

        #endregion

        #region RTL

        private void RightToLeftLayout()
        {
            RightToLeft = RightToLeft.Yes;
        }

        #endregion

        #region Painting

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (borderRadius <= 0)
                return;

            Rectangle rect = ClientRectangle;
            rect.Width--;
            rect.Height--;

            using GraphicsPath path = GetPath(rect, borderRadius);

            Region = new Region(path);

            if (borderSize > 0)
            {
                using Pen pen = new(borderColor, borderSize);

                pen.Alignment = PenAlignment.Inset;

                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new();

            float curve = radius * 2;

            path.StartFigure();

            path.AddArc(rect.X, rect.Y, curve, curve, 180, 90);
            path.AddArc(rect.Right - curve, rect.Y, curve, curve, 270, 90);
            path.AddArc(rect.Right - curve, rect.Bottom - curve, curve, curve, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curve, curve, curve, 90, 90);

            path.CloseFigure();

            return path;
        }

        #endregion

        #region Resize

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        #endregion
    }

    public class SabraFlowLayoutPanel : FlowLayoutPanel
    {
        // الحقول (Fields)
        private int borderSize = 0;
        private int borderRadius = 15;
        private Color borderColor = Color.DodgerBlue;

        // الخصائص (Properties) اللي هتظهر في الديزاينر
        [Category("Sabra Custom Properties")]
        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; this.Invalidate(); }
        }

        [Category("Sabra Custom Properties")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; this.Invalidate(); }
        }

        [Category("Sabra Custom Properties")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }

        // الـ Constructor
        public SabraFlowLayoutPanel()
        {
            this.BorderStyle = BorderStyle.None; // بنلغي البوردر العادي بتاع الويندوز
            this.BackColor = Color.White;

            // عشان نمنع الـ Flickering (الرعشة) وقت الرسم
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            if (borderRadius > this.Height)
                borderRadius = this.Height;
            this.Invalidate();
        }

        // --- رسم الشكل الدائري للكونتينر ---
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                {
                    Color parentColor = this.Parent != null ? this.Parent.BackColor : this.BackColor;

                    using (Pen penSurface = new Pen(parentColor, smoothSize))
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        // قص الحواف عشان تكون دائرية
                        this.Region = new Region(pathSurface);

                        // رسم الحواف الخارجية
                        e.Graphics.DrawPath(penSurface, pathSurface);
                        if (borderSize >= 1)
                            e.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
    }

    public class SabraDateTimePicker : UserControl
    {
        private DateTime selectedDate = DateTime.Today;
        private readonly Label lblDate;
        private readonly Button btnCalendar;
        private readonly CheckBox chkEnable;

        private SabraCalendarPopup calendarPopup;

        private Color borderColor = Color.FromArgb(220, 225, 230);
        private Color focusedBorderColor = Color.FromArgb(0, 120, 212);
        private Color skinColor = Color.White;
        private Color textColor = Color.FromArgb(45, 45, 45);
        private Color disabledTextColor = Color.FromArgb(190, 190, 190);

        private int borderRadius = 12;
        private int borderSize = 1;

        private bool isFocused = false;

        // *** إضافة: دعم Checked / ShowCheckBox زي الـ DateTimePicker الأصلي ***
        private bool showCheckBox = false;
        private bool isChecked = true;

        public event EventHandler ValueChanged;

        public SabraDateTimePicker()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;

            Font = new Font("Cairo", 10F);
            Size = new Size(250, 52);
            MinimumSize = new Size(180, 45);

            RightToLeft = RightToLeft.Yes;
            BackColor = Color.Transparent;

            lblDate = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(15, 0, 50, 0),
                Cursor = Cursors.Hand,
                Font = Font,
                ForeColor = textColor,
                RightToLeft = RightToLeft.Yes
            };

            btnCalendar = new Button
            {
                Dock = DockStyle.Left,
                Width = 48,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
            {
                BorderSize = 0,
                MouseDownBackColor = Color.Transparent,
                MouseOverBackColor = Color.Transparent
            },
                Cursor = Cursors.Hand,
                Text = "▾",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 80),
                BackColor = Color.Transparent,
                TabStop = false
            };

            chkEnable = new CheckBox
            {
                Dock = DockStyle.Right,
                Width = 30,
                Checked = true,
                Visible = false,
                Cursor = Cursors.Hand,
                BackColor = Color.Transparent,
                TabStop = false,
                Text = string.Empty
            };

            lblDate.Click += (sender, e) => this.Focus();
            btnCalendar.Click += Control_Click;
            chkEnable.CheckedChanged += ChkEnable_CheckedChanged;

            MouseEnter += Control_MouseEnter;
            MouseLeave += Control_MouseLeave;

            // ملحوظة على الترتيب: الكنترولز اللي بتتضاف بعد الـ Dock.Fill
            // هي اللي بتاخد مساحتها الأول (الأحدث إضافة = أول حجز مساحة)،
            // فلازم lblDate (Fill) يتضاف الأول عشان ياخد الباقي.
            Controls.Add(lblDate);
            Controls.Add(btnCalendar);
            Controls.Add(chkEnable);

            UpdateDateText();
            UpdateEnabledState();
        }

        [Category("Sabra Custom Properties")]
        public DateTime Value
        {
            get => selectedDate;
            set
            {
                if (selectedDate == value)
                    return;

                selectedDate = value;
                UpdateDateText();

                ValueChanged?.Invoke(this, EventArgs.Empty);
                Invalidate();
            }
        }

        [Category("Sabra Custom Properties")]
        public string DateFormat { get; set; } = "dddd، dd MMMM yyyy";

        /// <summary>
        /// يظهر أو يخفي مربع الاختيار الخاص بتفعيل/تعطيل الفلتر (مثل DateTimePicker الأصلي).
        /// </summary>
        [Category("Sabra Custom Properties")]
        public bool ShowCheckBox
        {
            get => showCheckBox;
            set
            {
                if (showCheckBox == value)
                    return;

                showCheckBox = value;
                chkEnable.Visible = value;
                UpdateEnabledState();
                Invalidate();
            }
        }

        /// <summary>
        /// يحدد إذا كانت القيمة مفعّلة (سارية) أو لأ. مفيدة لعمل فلتر تاريخ اختياري.
        /// لما ShowCheckBox = false هتبقى دايمًا true بمعنى القيمة سارية دايمًا.
        /// </summary>
        [Category("Sabra Custom Properties")]
        public bool Checked
        {
            get => isChecked;
            set
            {
                if (isChecked == value)
                    return;

                isChecked = value;

                chkEnable.CheckedChanged -= ChkEnable_CheckedChanged;
                chkEnable.Checked = value;
                chkEnable.CheckedChanged += ChkEnable_CheckedChanged;

                UpdateEnabledState();

                ValueChanged?.Invoke(this, EventArgs.Empty);
                Invalidate();
            }
        }

        [Category("Sabra Custom Properties")]
        public Color SkinColor
        {
            get => skinColor;
            set
            {
                skinColor = value;
                Invalidate();
            }
        }

        [Category("Sabra Custom Properties")]
        public Color TextColor
        {
            get => textColor;
            set
            {
                textColor = value;
                UpdateEnabledState();
                Invalidate();
            }
        }

        [Category("Sabra Custom Properties")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("Sabra Custom Properties")]
        public Color FocusedBorderColor
        {
            get => focusedBorderColor;
            set
            {
                focusedBorderColor = value;
                Invalidate();
            }
        }

        [Category("Sabra Custom Properties")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("Sabra Custom Properties")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = Math.Max(0, value);
                Invalidate();
            }
        }

        private void ChkEnable_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = chkEnable.Checked;
            UpdateEnabledState();

            ValueChanged?.Invoke(this, EventArgs.Empty);
            Invalidate();
        }

        /// <summary>
        /// بيفعّل/يعطّل قابلية الضغط والقراءة الخاصة بالتاريخ حسب حالة الـ Checked.
        /// </summary>
        private void UpdateEnabledState()
        {
            bool isActive = !showCheckBox || isChecked;

            lblDate.Enabled = isActive;
            btnCalendar.Enabled = isActive;
            lblDate.ForeColor = isActive ? textColor : disabledTextColor;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            // لو الفلتر متعطّل (Checked = false) منمنعش فتح التقويم بالغلط
            if (showCheckBox && !isChecked)
                return;

            ShowCalendar();
        }

        private void ShowCalendar()
        {
            if (calendarPopup != null && !calendarPopup.IsDisposed)
            {
                calendarPopup.Close();
                return;
            }

            calendarPopup = new SabraCalendarPopup(
                selectedDate,
                RightToLeft == RightToLeft.Yes
            );

            calendarPopup.DateSelected += CalendarPopup_DateSelected;
            calendarPopup.FormClosed += CalendarPopup_FormClosed;

            Point screenLocation = PointToScreen(
                new Point(0, Height + 6)
            );

            Rectangle screenBounds = Screen.FromControl(this).WorkingArea;

            if (screenLocation.X + calendarPopup.Width > screenBounds.Right)
            {
                screenLocation.X =
                    screenBounds.Right - calendarPopup.Width - 10;
            }

            if (screenLocation.Y + calendarPopup.Height > screenBounds.Bottom)
            {
                screenLocation.Y =
                    PointToScreen(new Point(0, 0)).Y
                    - calendarPopup.Height
                    - 6;
            }

            calendarPopup.Location = screenLocation;

            isFocused = true;
            Invalidate();

            calendarPopup.Show();
        }

        private void CalendarPopup_DateSelected(
            object sender,
            DateTime date)
        {
            Value = date;
        }

        private void CalendarPopup_FormClosed(
            object sender,
            FormClosedEventArgs e)
        {
            isFocused = false;
            Invalidate();

            calendarPopup = null;
        }

        private void UpdateDateText()
        {
            lblDate.Text = selectedDate.ToString(
                DateFormat,
                new CultureInfo("ar-EG")
            );
        }

        private void Control_MouseEnter(
            object sender,
            EventArgs e)
        {
            isFocused = true;
            Invalidate();
        }

        private void Control_MouseLeave(
            object sender,
            EventArgs e)
        {
            if (calendarPopup == null)
            {
                isFocused = false;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = ClientRectangle;
            rect.Width--;
            rect.Height--;

            using GraphicsPath path =
                CreateRoundedPath(rect, borderRadius);

            using SolidBrush backgroundBrush =
                new SolidBrush(skinColor);

            e.Graphics.FillPath(backgroundBrush, path);

            Color currentBorder =
                isFocused
                    ? focusedBorderColor
                    : borderColor;

            using Pen borderPen =
                new Pen(currentBorder, borderSize);

            borderPen.Alignment = PenAlignment.Inset;

            if (borderSize > 0)
            {
                e.Graphics.DrawPath(borderPen, path);
            }

            // لو الـ CheckBox ظاهر، أيقونة الكالندر بتتحرك عشان متتصادمش معاه
            DrawCalendarIcon(e.Graphics);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (showCheckBox && !isChecked)
                return;

            // إذا كانت حركة العجلة للأعلى، نضيف يوم. وإذا كانت للأسفل، نطرح يوم.
            if (e.Delta > 0)
            {
                Value = Value.AddDays(1);
            }
            else if (e.Delta < 0)
            {
                Value = Value.AddDays(-1);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // التأكد من أن الأداة محددة (Focused) وسارية (Checked) قبل تغيير التاريخ
            if (this.ContainsFocus && (!showCheckBox || isChecked))
            {
                if (keyData == Keys.Up || keyData == Keys.Right)
                {
                    Value = Value.AddDays(1);
                    return true; // إخبار النظام أنه تم التعامل مع الزر لمنع تغيير الـ Focus
                }
                else if (keyData == Keys.Down || keyData == Keys.Left)
                {
                    Value = Value.AddDays(-1);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DrawCalendarIcon(Graphics g)
        {
            int size = 20;

            // نحجز مساحة الـ CheckBox عشان الأيقونة متترسمش فوقه
            int reservedForCheckBox = showCheckBox ? chkEnable.Width : 0;

            int x = Width - size - 15 - reservedForCheckBox;
            int y = (Height - size) / 2;

            using Pen pen = new Pen(
                focusedBorderColor,
                1.8F
            );

            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;

            g.DrawRectangle(
                pen,
                x,
                y + 3,
                size,
                size - 3
            );

            g.DrawLine(
                pen,
                x,
                y + 8,
                x + size,
                y + 8
            );

            g.DrawLine(
                pen,
                x + 5,
                y,
                x + 5,
                y + 5
            );

            g.DrawLine(
                pen,
                x + size - 5,
                y,
                x + size - 5,
                y + 5
            );

            using SolidBrush dotBrush =
                new SolidBrush(focusedBorderColor);

            g.FillEllipse(
                dotBrush,
                x + 5,
                y + 12,
                3,
                3
            );

            g.FillEllipse(
                dotBrush,
                x + 12,
                y + 12,
                3,
                3
            );
        }

        private GraphicsPath CreateRoundedPath(
            Rectangle rect,
            int radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;

            path.AddArc(
                rect.X,
                rect.Y,
                diameter,
                diameter,
                180,
                90
            );

            path.AddArc(
                rect.Right - diameter,
                rect.Y,
                diameter,
                diameter,
                270,
                90
            );

            path.AddArc(
                rect.Right - diameter,
                rect.Bottom - diameter,
                diameter,
                diameter,
                0,
                90
            );

            path.AddArc(
                rect.X,
                rect.Bottom - diameter,
                diameter,
                diameter,
                90,
                90
            );

            path.CloseFigure();

            return path;
        }
    }

    public class SabraCalendarPopup : Form
    {
        private enum CalendarView
        {
            Days,
            Months,
            Years
        }

        private DateTime selectedDate;
        private DateTime displayedMonth;
        private CalendarView currentView = CalendarView.Days;

        private readonly CultureInfo arabicCulture = new CultureInfo("ar-EG");

        private readonly Button btnHeaderTitle; // تحويل Label إلى Button للضغط عليه
        private readonly Button btnNext;
        private readonly Button btnPrevious;
        private readonly Button btnToday;
        private readonly Button btnClose;

        private readonly TableLayoutPanel daysPanel;

        private Color primaryColor = Color.FromArgb(0, 120, 212);
        private Color hoverColor = Color.FromArgb(235, 242, 250);
        private Color textColor = Color.FromArgb(45, 45, 45);

        public event EventHandler<DateTime> DateSelected;

        public SabraCalendarPopup(DateTime date, bool rtl = true)
        {
            selectedDate = date.Date;
            displayedMonth = new DateTime(date.Year, date.Month, 1);

            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;

            Width = 420;
            Height = 470;
            BackColor = Color.White;

            RightToLeft = rtl ? RightToLeft.Yes : RightToLeft.No;
            RightToLeftLayout = rtl;
            Padding = new Padding(16);

            // Header Title Button
            btnHeaderTitle = new Button
            {
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Cairo", 12F, FontStyle.Bold),
                ForeColor = textColor,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                TabStop = false
            };
            btnHeaderTitle.FlatAppearance.BorderSize = 0;
            btnHeaderTitle.Click += BtnHeaderTitle_Click;

            btnPrevious = CreateHeaderButton("‹");
            btnNext = CreateHeaderButton("›");

            btnPrevious.Click += (s, e) => Navigate(-1);
            btnNext.Click += (s, e) => Navigate(1);

            TableLayoutPanel header = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 64,
                ColumnCount = 3,
                RowCount = 1
            };

            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55));

            header.Controls.Add(btnPrevious, 0, 0);
            header.Controls.Add(btnHeaderTitle, 1, 0);
            header.Controls.Add(btnNext, 2, 0);

            daysPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 7,
                RowCount = 7,
                Padding = new Padding(2, 10, 2, 10)
            };

            btnToday = CreateFooterButton("اليوم");
            btnClose = CreateFooterButton("إغلاق");

            btnToday.Click += (s, e) =>
            {
                displayedMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                selectedDate = DateTime.Today;
                currentView = CalendarView.Days;
                RenderCalendar();
            };

            btnClose.Click += (s, e) => Close();

            TableLayoutPanel footer = new TableLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 55,
                ColumnCount = 2,
                Padding = new Padding(0, 5, 0, 0)
            };

            footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            footer.Controls.Add(btnToday, 0, 0);
            footer.Controls.Add(btnClose, 1, 0);

            Controls.Add(daysPanel);
            Controls.Add(footer);
            Controls.Add(header);

            Deactivate += (s, e) => BeginInvoke(new Action(Close));

            RenderCalendar();
        }

        private void Navigate(int direction)
        {
            switch (currentView)
            {
                case CalendarView.Days:
                    displayedMonth = displayedMonth.AddMonths(direction);
                    break;
                case CalendarView.Months:
                    displayedMonth = displayedMonth.AddYears(direction);
                    break;
                case CalendarView.Years:
                    displayedMonth = displayedMonth.AddYears(direction * 12);
                    break;
            }
            RenderCalendar();
        }

        private void BtnHeaderTitle_Click(object sender, EventArgs e)
        {
            if (currentView == CalendarView.Days)
                currentView = CalendarView.Months;
            else if (currentView == CalendarView.Months)
                currentView = CalendarView.Years;

            RenderCalendar();
        }

        private void RenderCalendar()
        {
            daysPanel.SuspendLayout();
            daysPanel.Controls.Clear();
            daysPanel.ColumnStyles.Clear();
            daysPanel.RowStyles.Clear();

            switch (currentView)
            {
                case CalendarView.Days:
                    RenderDaysView();
                    break;
                case CalendarView.Months:
                    RenderMonthsView();
                    break;
                case CalendarView.Years:
                    RenderYearsView();
                    break;
            }

            daysPanel.ResumeLayout();
        }

        private void RenderDaysView()
        {
            btnHeaderTitle.Text = displayedMonth.ToString("MMMM yyyy", arabicCulture);

            daysPanel.ColumnCount = 7;
            daysPanel.RowCount = 7;

            for (int i = 0; i < 7; i++)
                daysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));

            for (int i = 0; i < 7; i++)
                daysPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857F));

            string[] dayNames = { "ح", "ن", "ث", "ر", "خ", "ج", "س" };
            for (int i = 0; i < 7; i++)
            {
                Label dayLabel = new Label
                {
                    Text = dayNames[i],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Cairo", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(130, 135, 145)
                };
                daysPanel.Controls.Add(dayLabel, i, 0);
            }

            int firstDayIndex = ((int)displayedMonth.DayOfWeek + 1) % 7;
            int daysInMonth = DateTime.DaysInMonth(displayedMonth.Year, displayedMonth.Month);
            int day = 1;

            for (int row = 1; row <= 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (row == 1 && col < firstDayIndex) continue;
                    if (day > daysInMonth) break;

                    DateTime currentDate = new DateTime(displayedMonth.Year, displayedMonth.Month, day);
                    Button dayButton = CreateDayButton(currentDate);
                    daysPanel.Controls.Add(dayButton, col, row);
                    day++;
                }
            }
        }

        private void RenderMonthsView()
        {
            btnHeaderTitle.Text = displayedMonth.ToString("yyyy", arabicCulture);

            daysPanel.ColumnCount = 3;
            daysPanel.RowCount = 4;

            for (int i = 0; i < 3; i++)
                daysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            for (int i = 0; i < 4; i++)
                daysPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            for (int m = 1; m <= 12; m++)
            {
                int monthIndex = m;
                DateTime monthDate = new DateTime(displayedMonth.Year, monthIndex, 1);
                Button btnMonth = new Button
                {
                    Text = monthDate.ToString("MMMM", arabicCulture),
                    Dock = DockStyle.Fill,
                    Font = new Font("Cairo", 10F, FontStyle.Regular),
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(3),
                    Cursor = Cursors.Hand,
                    BackColor = (monthIndex == displayedMonth.Month) ? primaryColor : Color.White,
                    ForeColor = (monthIndex == displayedMonth.Month) ? Color.White : textColor
                };
                btnMonth.FlatAppearance.BorderSize = 0;

                btnMonth.Click += (s, e) =>
                {
                    displayedMonth = new DateTime(displayedMonth.Year, monthIndex, 1);
                    currentView = CalendarView.Days;
                    RenderCalendar();
                };

                int row = (m - 1) / 3;
                int col = (m - 1) % 3;
                daysPanel.Controls.Add(btnMonth, col, row);
            }
        }

        private void RenderYearsView()
        {
            int startYear = displayedMonth.Year - (displayedMonth.Year % 12);
            int endYear = startYear + 11;

            btnHeaderTitle.Text = $"{startYear} - {endYear}";

            daysPanel.ColumnCount = 3;
            daysPanel.RowCount = 4;

            for (int i = 0; i < 3; i++)
                daysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            for (int i = 0; i < 4; i++)
                daysPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            for (int i = 0; i < 12; i++)
            {
                int year = startYear + i;
                Button btnYear = new Button
                {
                    Text = year.ToString(),
                    Dock = DockStyle.Fill,
                    Font = new Font("Cairo", 10F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(3),
                    Cursor = Cursors.Hand,
                    BackColor = (year == displayedMonth.Year) ? primaryColor : Color.White,
                    ForeColor = (year == displayedMonth.Year) ? Color.White : textColor
                };
                btnYear.FlatAppearance.BorderSize = 0;

                btnYear.Click += (s, e) =>
                {
                    displayedMonth = new DateTime(year, displayedMonth.Month, 1);
                    currentView = CalendarView.Months;
                    RenderCalendar();
                };

                int row = i / 3;
                int col = i % 3;
                daysPanel.Controls.Add(btnYear, col, row);
            }
        }

        private Button CreateHeaderButton(string text)
        {
            return new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 20F, FontStyle.Regular),
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = Color.White,
                ForeColor = textColor,
                Cursor = Cursors.Hand,
                TabStop = false
            };
        }

        private Button CreateFooterButton(string text)
        {
            return new Button
            {
                Text = text,
                Font = new Font("Cairo", 9.5F),
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = text == "اليوم" ? primaryColor : Color.FromArgb(245, 247, 249),
                ForeColor = text == "اليوم" ? Color.White : textColor,
                Cursor = Cursors.Hand,
                Margin = new Padding(5, 0, 5, 0)
            };
        }

        private Button CreateDayButton(DateTime date)
        {
            bool isSelected = date.Date == selectedDate.Date;
            bool isToday = date.Date == DateTime.Today;

            Button button = new Button
            {
                Text = date.Day.ToString(),
                Dock = DockStyle.Fill,
                Font = new Font("Cairo", 9.5F, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Margin = new Padding(4),
                Cursor = Cursors.Hand,
                Tag = date,
                BackColor = isSelected ? primaryColor : Color.White,
                ForeColor = isSelected ? Color.White : textColor
            };

            if (isToday && !isSelected)
            {
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.BorderColor = primaryColor;
            }

            button.MouseEnter += (s, e) => { if (!isSelected) button.BackColor = hoverColor; };
            button.MouseLeave += (s, e) => { if (!isSelected) button.BackColor = Color.White; };
            button.Click += DayButton_Click;

            return button;
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is DateTime date)
            {
                selectedDate = date;
                DateSelected?.Invoke(this, selectedDate);
                Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle shadowRect = new Rectangle(3, 3, Width - 7, Height - 7);
            using Pen shadowPen = new Pen(Color.FromArgb(35, 0, 0, 0), 3);
            e.Graphics.DrawRectangle(shadowPen, shadowRect);

            using Pen borderPen = new Pen(Color.FromArgb(225, 230, 235), 1);
            e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
        }
    }
    

    public class SabraNumericUpDown : NumericUpDown
        {
            #region Fields

            private Color _borderColor = Color.FromArgb(218, 222, 225);
            private Color _borderFocusColor = Color.FromArgb(52, 152, 219);
            private bool _isFocused = false;

            #endregion

            #region Properties

            [Category("Sabra Properties")]
            public Color BorderColor
            {
                get => _borderColor;
                set { _borderColor = value; Invalidate(); }
            }

            [Category("Sabra Properties")]
            public Color BorderFocusColor
            {
                get => _borderFocusColor;
                set { _borderFocusColor = value; Invalidate(); }
            }

            #endregion

            #region Constructor

            public SabraNumericUpDown()
            {
                this.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                this.ForeColor = Color.FromArgb(64, 64, 64);
                this.BackColor = Color.White;
            }

            #endregion

            #region Overrides & Painting

            protected override void OnGotFocus(EventArgs e)
            {
                base.OnGotFocus(e);
                _isFocused = true;
                this.Invalidate();
            }

            protected override void OnLostFocus(EventArgs e)
            {
                base.OnLostFocus(e);
                _isFocused = false;
                this.Invalidate();
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // رسم الإطار الخارجي المخصص فوق الأداة الأصلية عند حدوث إعادة رسم (WM_PAINT)
                if (m.Msg == 0x000F)
                {
                    using (Graphics g = Graphics.FromHwnd(this.Handle))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        Color currentBorder = _isFocused ? _borderFocusColor : _borderColor;

                        using (Pen pen = new Pen(currentBorder, 1.5f))
                        {
                            g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                        }
                    }
                }
            }

            #endregion
        }
    

}


