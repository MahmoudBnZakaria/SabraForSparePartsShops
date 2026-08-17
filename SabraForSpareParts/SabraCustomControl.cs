using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

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
        // --- خصائص الألوان القابلة للتخصيص ---
        private Color headerBackColor = Color.White;
        private Color headerForeColor = Color.FromArgb(64, 64, 64);
        private Color rowNormalColor = Color.White;
        private Color rowAlternateColor = Color.FromArgb(248, 248, 248); // رمادي أنعم من الكود الأصلي
        private Color rowSelectionColor = Color.FromArgb(235, 245, 255); // أزرق فاتح جداً وناعم للتحديد
        private Color rowSelectionForeColor = Color.Black;
        private Color gridLineColor = Color.LightGray;

        [Category("Custom Colors"), Description("لون خلفية رأس الجدول")]
        public Color HeaderBackColor
        {
            get { return headerBackColor; }
            set { headerBackColor = value; ApplyTheme(); }
        }

        [Category("Custom Colors"), Description("لون نص رأس الجدول")]
        public Color HeaderForeColor
        {
            get { return headerForeColor; }
            set { headerForeColor = value; ApplyTheme(); }
        }

        [Category("Custom Colors"), Description("لون الصف العادي")]
        public Color RowNormalColor
        {
            get { return rowNormalColor; }
            set { rowNormalColor = value; ApplyTheme(); }
        }

        [Category("Custom Colors"), Description("لون الصف البديل")]
        public Color RowAlternateColor
        {
            get { return rowAlternateColor; }
            set { rowAlternateColor = value; ApplyTheme(); }
        }

        [Category("Custom Colors"), Description("لون خلفية الصف المحدد")]
        public Color RowSelectionColor
        {
            get { return rowSelectionColor; }
            set { rowSelectionColor = value; ApplyTheme(); }
        }

        [Category("Custom Colors"), Description("لون نص الصف المحدد")]
        public Color RowSelectionForeColor
        {
            get { return rowSelectionForeColor; }
            set { rowSelectionForeColor = value; ApplyTheme(); }
        }

        [Category("Custom Colors"), Description("لون خطوط الشبكة")]
        public Color CustomGridLineColor
        {
            get { return gridLineColor; }
            set { gridLineColor = value; ApplyTheme(); }
        }

        // منشئ الكلاس
        public SabraDataGridView()
        {
            // --- الإعدادات الأساسية للجدول ---
            this.DoubleBuffered = true; // لمنع التقطيع أثناء التمرير
            this.BorderStyle = BorderStyle.None;
            this.BackgroundColor = Color.White;
            this.EnableHeadersVisualStyles = false; // مهم لتغيير لون الهيدر
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.ReadOnly = true;

            // --- إعدادات اللغة العربية ---
            this.RightToLeft = RightToLeft.Yes;
            this.Font = new Font("Cairo", 10F, FontStyle.Regular, GraphicsUnit.Point);

            // --- إعدادات التحديد ---
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // تحديد السطر بالكامل
            this.MultiSelect = false; // إلغاء تحديد أكثر من سطر

            // --- إعدادات الأعمدة ---
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // ملء المساحة
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // خطوط أفقية فقط

            // --- إضافة مثال لعمود الإجراءات (كما في الصورة) ---
            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn();
            actionColumn.Name = "Actions";
            actionColumn.HeaderText = "الإجراءات";
            actionColumn.UseColumnTextForButtonValue = true;
            actionColumn.Text = "عرض  تعديل  حركة"; // نص الأزرار الثلاثة
            actionColumn.FlatStyle = FlatStyle.Flat;
            actionColumn.DefaultCellStyle.BackColor = Color.White;
            actionColumn.DefaultCellStyle.ForeColor = Color.Black;
            actionColumn.DefaultCellStyle.SelectionBackColor = Color.White; // لمنع تلوين الزر عند التحديد
            actionColumn.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.Columns.Add(actionColumn);

            // --- إضافة حدث لتلوين الخلايا الخاصة (الكمية والتسميات) ---
            this.CellFormatting += SabraDataGridView_CellFormatting;
            // --- إضافة حدث لرسم الأزرار وتسميات التصنيف بشكل مخصص ---
            this.CellPainting += SabraDataGridView_CellPainting;

            ApplyTheme();
        }

        // تطبيق الألوان والأنماط المحددة
        private void ApplyTheme()
        {
            // إعدادات الهيدر (رأس الجدول)
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.ColumnHeadersDefaultCellStyle.BackColor = headerBackColor;
            this.ColumnHeadersDefaultCellStyle.ForeColor = headerForeColor;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Cairo", 10F, FontStyle.Bold, GraphicsUnit.Point); // خط غامق قليلاً
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // محاذاة لليسار
            this.ColumnHeadersHeight = 45; // ارتفاع مناسب للرأس
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // إعدادات السطور العادية
            this.DefaultCellStyle.BackColor = rowNormalColor;
            this.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            this.DefaultCellStyle.SelectionBackColor = rowSelectionColor;
            this.DefaultCellStyle.SelectionForeColor = rowSelectionForeColor;
            this.DefaultCellStyle.Font = new Font("Cairo", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // محاذاة لليسار

            // إعدادات السطور البديلة
            this.AlternatingRowsDefaultCellStyle.BackColor = rowAlternateColor;

            // إعدادات الهامش الجانبي للسطور (إخفاؤه لشكل أنظف)
            this.RowHeadersVisible = false;
            this.RowTemplate.Height = 40; // ارتفاع السطر

            // لون خطوط الشبكة
            this.GridColor = gridLineColor;
        }

        // حدث لتنسيق الخلايا الخاصة (الكمية وتلوين تسميات التصنيف)
        private void SabraDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = this.Columns[e.ColumnIndex].Name;

            // --- تلوين قيم الكمية ---
            if (columnName == "الكمية") // افترض أن اسم العمود هو "الكمية"
            {
                if (e.Value != null && e.Value != DBNull.Value && decimal.TryParse(e.Value.ToString(), out decimal quantity))
                {
                    if (quantity < 5)
                        e.CellStyle.ForeColor = Color.Red; // أحمر إذا كانت الكمية < 5
                    else
                        e.CellStyle.ForeColor = Color.LimeGreen; // أخضر إذا كانت الكمية >= 5
                }
            }
        }

        // حدث لرسم الخلايا الخاصة (الأزرار وتسميات التصنيف الدائرية)
        private void SabraDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = this.Columns[e.ColumnIndex].Name;

            // --- رسم تسميات التصنيف (Chips) ---
            if (columnName == "التصنيف") // افترض أن اسم العمود هو "التصنيف"
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All); // رسم الخلفية والحدود الافتراضية

                if (e.Value != null && e.Value != DBNull.Value)
                {
                    string text = e.Value.ToString();
                    Color chipColor = Color.FromArgb(230, 240, 255); // لون خلفية التسمية (أزرق فاتح)
                    Color textColor = Color.Black; // لون نص التسمية

                    // رسم خلفية دائرية للتسمية
                    int cornerRadius = 15;
                    Rectangle chipBounds = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 5, e.CellBounds.Width - 20, e.CellBounds.Height - 10);
                    using (Brush chipBrush = new SolidBrush(chipColor))
                    using (Brush textBrush = new SolidBrush(textColor))
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    using (Font chipFont = new Font("Cairo", 9F, FontStyle.Regular))
                    {
                        using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
                        {
                            gp.AddArc(chipBounds.X, chipBounds.Y, cornerRadius, cornerRadius, 180, 90);
                            gp.AddArc(chipBounds.Right - cornerRadius, chipBounds.Y, cornerRadius, cornerRadius, 270, 90);
                            gp.AddArc(chipBounds.Right - cornerRadius, chipBounds.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                            gp.AddArc(chipBounds.X, chipBounds.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                            gp.CloseAllFigures();
                            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            e.Graphics.FillPath(chipBrush, gp);
                            e.Graphics.DrawString(text, chipFont, textBrush, chipBounds, sf);
                            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                        }
                    }
                }
                e.Handled = true; // الإشارة إلى أننا قمنا برسم الخلية بالكامل
            }

            // --- تخصيص مظهر الأزرار في عمود الإجراءات ---
            if (this.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.SelectionBackground); // رسم خلفية الخلية والتحديد

                // رسم حدود خفيفة للأزرار البيضاء
                Rectangle buttonBounds = e.CellBounds;
                buttonBounds.Width -= 2; buttonBounds.Height -= 2;
                buttonBounds.X += 1; buttonBounds.Y += 1;

                using (Pen borderPen = new Pen(gridLineColor, 1))
                using (Brush textBrush = new SolidBrush(e.CellStyle.ForeColor))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    // رسم خلفية الزر باللون الأبيض (كما هو محدد في DefaultCellStyle لعمود الإجراءات)
                    e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), buttonBounds);
                    // رسم حدود الزر
                    e.Graphics.DrawRectangle(borderPen, buttonBounds);
                    // رسم نص الأزرار
                    e.Graphics.DrawString(this.Columns[e.ColumnIndex].DefaultCellStyle.NullValue.ToString(), e.CellStyle.Font, textBrush, e.CellBounds, sf);
                }
                e.Handled = true; // الإشارة إلى أننا قمنا برسم الخلية بالكامل
            }
        }

        // رسم إطار خارجي رفيع حول الجدول
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(gridLineColor, 1), 0, 0, this.Width - 1, this.Height - 1);
        }
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
}

