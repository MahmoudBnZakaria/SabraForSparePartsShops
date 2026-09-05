using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;

namespace SabraForSpareParts
{
    public class SabraLabel : Label
    {
        #region Fields

        private int borderRadius = 8;
        private int borderSize = 0;
        private Color borderColor = Color.DodgerBlue;

        private bool isTitle = false;

        private bool required = false;
        private Color requiredColor = Color.Red;

        #endregion

        #region Properties

        // ==============================
        // Required
        // ==============================

        [Category("Sabra Appearance")]
        [DefaultValue(false)]
        public bool Required
        {
            get => required;
            set
            {
                if (required == value)
                    return;

                required = value;
                Invalidate();
            }
        }

        // ==============================
        // Required Color
        // ==============================

        [Category("Sabra Appearance")]
        [DefaultValue(typeof(Color), "Red")]
        public Color RequiredColor
        {
            get => requiredColor;
            set
            {
                if (requiredColor == value)
                    return;

                requiredColor = value;
                Invalidate();
            }
        }

        // ==============================
        // Is Title
        // ==============================

        [Category("Sabra Appearance")]
        [DefaultValue(false)]
        public bool IsTitle
        {
            get => isTitle;
            set
            {
                if (isTitle == value)
                    return;

                isTitle = value;

                Font = isTitle
                    ? new Font("Cairo", 12F, FontStyle.Bold)
                    : new Font("Cairo", 10F, FontStyle.Regular);

                Invalidate();
            }
        }

        // ==============================
        // Border Radius
        // ==============================

        [Category("Sabra Appearance")]
        [DefaultValue(8)]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                int newValue = Math.Max(0, value);

                if (borderRadius == newValue)
                    return;

                borderRadius = newValue;
                Invalidate();
            }
        }

        // ==============================
        // Border Size
        // ==============================

        [Category("Sabra Appearance")]
        [DefaultValue(0)]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                int newValue = Math.Max(0, value);

                if (borderSize == newValue)
                    return;

                borderSize = newValue;
                Invalidate();
            }
        }

        // ==============================
        // Border Color
        // ==============================

        [Category("Sabra Appearance")]
        [DefaultValue(typeof(Color), "DodgerBlue")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                if (borderColor == value)
                    return;

                borderColor = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor

        public SabraLabel()
        {
            // ==============================
            // Custom Painting
            // ==============================

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true
            );

            DoubleBuffered = true;

            // ==============================
            // Default Settings
            // ==============================

            AutoSize = false;

            Size = new Size(120, 32);

            BackColor = Color.Transparent;

            ForeColor = Color.FromArgb(64, 64, 64);

            RightToLeft = RightToLeft.Yes;

            TextAlign = ContentAlignment.MiddleRight;

            Padding = new Padding(0);

            Font = new Font(
                "Cairo",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
        }

        #endregion

        #region Control Events

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

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            Invalidate();
        }

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);

            Invalidate();
        }

        #endregion

        #region Graphics Helpers

        private GraphicsPath GetFigurePath(
            RectangleF rect,
            float radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (rect.Width <= 0 || rect.Height <= 0)
                return path;

            radius = Math.Max(
                0,
                Math.Min(
                    radius,
                    Math.Min(
                        rect.Width / 2f,
                        rect.Height / 2f
                    )
                )
            );

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            float diameter = radius * 2f;

            path.StartFigure();

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

        private TextFormatFlags GetTextAlignment()
        {
            TextFormatFlags flags =
                TextFormatFlags.PreserveGraphicsClipping |
                TextFormatFlags.NoPadding;

            // ==============================
            // Horizontal Alignment
            // ==============================

            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:

                    flags |= TextFormatFlags.Left;
                    break;

                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:

                    flags |= TextFormatFlags.HorizontalCenter;
                    break;

                default:

                    flags |= TextFormatFlags.Right;
                    break;
            }

            // ==============================
            // Vertical Alignment
            // ==============================

            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:

                    flags |= TextFormatFlags.Top;
                    break;

                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:

                    flags |= TextFormatFlags.VerticalCenter;
                    break;

                default:

                    flags |= TextFormatFlags.Bottom;
                    break;
            }

            // ==============================
            // RTL
            // ==============================

            if (RightToLeft == RightToLeft.Yes)
            {
                flags |= TextFormatFlags.RightToLeft;
            }

            return flags;
        }

        #endregion

        #region Text Drawing

        private void DrawNormalText(
            Graphics graphics,
            Rectangle rectText)
        {
            TextRenderer.DrawText(
                graphics,
                Text,
                Font,
                rectText,
                ForeColor,
                GetTextAlignment()
            );
        }

        private void DrawRequiredText(
            Graphics graphics,
            Rectangle rectText)
        {
            if (string.IsNullOrEmpty(Text))
            {
                DrawRequiredStarOnly(
                    graphics,
                    rectText
                );

                return;
            }

            using (Font starFont = new Font(
                Font.FontFamily,
                Font.Size,
                FontStyle.Bold,
                GraphicsUnit.Point))
            {
                Size textSize = TextRenderer.MeasureText(
                    graphics,
                    Text,
                    Font,
                    rectText.Size,
                    TextFormatFlags.NoPadding
                );

                Size starSize = TextRenderer.MeasureText(
                    graphics,
                    "*",
                    starFont,
                    rectText.Size,
                    TextFormatFlags.NoPadding
                );

                const int spacing = 4;

                int totalWidth =
                    textSize.Width +
                    spacing +
                    starSize.Width;

                // ==============================
                // Calculate X
                // ==============================

                int startX;

                bool isCenter =
                    TextAlign == ContentAlignment.TopCenter ||
                    TextAlign == ContentAlignment.MiddleCenter ||
                    TextAlign == ContentAlignment.BottomCenter;

                bool isLeft =
                    TextAlign == ContentAlignment.TopLeft ||
                    TextAlign == ContentAlignment.MiddleLeft ||
                    TextAlign == ContentAlignment.BottomLeft;

                if (isCenter)
                {
                    startX =
                        rectText.Left +
                        (rectText.Width - totalWidth) / 2;
                }
                else if (isLeft)
                {
                    startX = rectText.Left;
                }
                else
                {
                    startX =
                        rectText.Right -
                        totalWidth;
                }

                // ==============================
                // Calculate Y
                // ==============================

                int startY;

                bool isTop =
                    TextAlign == ContentAlignment.TopLeft ||
                    TextAlign == ContentAlignment.TopCenter ||
                    TextAlign == ContentAlignment.TopRight;

                bool isBottom =
                    TextAlign == ContentAlignment.BottomLeft ||
                    TextAlign == ContentAlignment.BottomCenter ||
                    TextAlign == ContentAlignment.BottomRight;

                if (isTop)
                {
                    startY = rectText.Top;
                }
                else if (isBottom)
                {
                    startY =
                        rectText.Bottom -
                        Font.Height;
                }
                else
                {
                    startY =
                        rectText.Top +
                        (rectText.Height - Font.Height) / 2;
                }

                // ==============================
                // RTL
                // ==============================

                if (RightToLeft == RightToLeft.Yes)
                {
                    // النجمة ناحية اليمين
                    // والنص بعدها ناحية اليسار

                    int starX =
                        startX;

                    int textX =
                        starX +
                        starSize.Width +
                        spacing;

                    TextRenderer.DrawText(
                        graphics,
                        "*",
                        starFont,
                        new Point(starX, startY),
                        RequiredColor,
                        TextFormatFlags.NoPadding
                    );

                    TextRenderer.DrawText(
                        graphics,
                        Text,
                        Font,
                        new Point(textX, startY),
                        ForeColor,
                        TextFormatFlags.NoPadding |
                        TextFormatFlags.RightToLeft
                    );
                }
                else
                {
                    // LTR:
                    // النص ثم النجمة

                    TextRenderer.DrawText(
                        graphics,
                        Text,
                        Font,
                        new Point(startX, startY),
                        ForeColor,
                        TextFormatFlags.NoPadding
                    );

                    TextRenderer.DrawText(
                        graphics,
                        "*",
                        starFont,
                        new Point(
                            startX +
                            textSize.Width +
                            spacing,
                            startY
                        ),
                        RequiredColor,
                        TextFormatFlags.NoPadding
                    );
                }
            }
        }

        private void DrawRequiredStarOnly(
            Graphics graphics,
            Rectangle rectText)
        {
            using (Font starFont = new Font(
                Font.FontFamily,
                Font.Size,
                FontStyle.Bold,
                GraphicsUnit.Point))
            {
                Size starSize = TextRenderer.MeasureText(
                    graphics,
                    "*",
                    starFont,
                    rectText.Size,
                    TextFormatFlags.NoPadding
                );

                int x;

                switch (TextAlign)
                {
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.BottomCenter:

                        x = rectText.Left +
                            (rectText.Width - starSize.Width) / 2;
                        break;

                    case ContentAlignment.TopLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.BottomLeft:

                        x = rectText.Left;
                        break;

                    default:

                        x = rectText.Right -
                            starSize.Width;
                        break;
                }

                int y =
                    rectText.Top +
                    (rectText.Height - starFont.Height) / 2;

                TextRenderer.DrawText(
                    graphics,
                    "*",
                    starFont,
                    new Point(x, y),
                    RequiredColor,
                    TextFormatFlags.NoPadding
                );
            }
        }

        #endregion

        #region Paint

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            // ==============================
            // Graphics Quality
            // ==============================

            graphics.SmoothingMode =
                SmoothingMode.AntiAlias;

            graphics.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

            graphics.PixelOffsetMode =
                PixelOffsetMode.HighQuality;

            graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // ==============================
            // Surface
            // ==============================

            RectangleF surfaceRect =
                new RectangleF(
                    0,
                    0,
                    Width,
                    Height
                );

            if (surfaceRect.Width <= 0 ||
                surfaceRect.Height <= 0)
            {
                return;
            }

            float safeRadius =
                Math.Min(
                    borderRadius,
                    Math.Min(
                        surfaceRect.Width / 2f,
                        surfaceRect.Height / 2f
                    )
                );

            // ==============================
            // Border Rectangle
            // ==============================

            bool hasBorder =
                borderSize > 0;

            float borderHalf =
                hasBorder
                    ? borderSize / 2f
                    : 0f;

            RectangleF borderRect =
                new RectangleF(
                    borderHalf,
                    borderHalf,
                    Math.Max(
                        0,
                        Width - borderSize
                    ),
                    Math.Max(
                        0,
                        Height - borderSize
                    )
                );

            float safeBorderRadius =
                Math.Min(
                    borderRadius,
                    Math.Min(
                        borderRect.Width / 2f,
                        borderRect.Height / 2f
                    )
                );

            // ==============================
            // Background + Border
            // ==============================

            using (GraphicsPath surfacePath =
                GetFigurePath(
                    surfaceRect,
                    safeRadius))
            using (GraphicsPath borderPath =
                GetFigurePath(
                    borderRect,
                    safeBorderRadius))
            {
                // Background

                if (BackColor != Color.Transparent)
                {
                    using (SolidBrush backgroundBrush =
                        new SolidBrush(BackColor))
                    {
                        graphics.FillPath(
                            backgroundBrush,
                            surfacePath
                        );
                    }
                }

                // Border

                if (hasBorder)
                {
                    using (Pen borderPen =
                        new Pen(
                            borderColor,
                            borderSize))
                    {
                        borderPen.Alignment =
                            PenAlignment.Center;

                        graphics.DrawPath(
                            borderPen,
                            borderPath
                        );
                    }
                }
            }

            // ==============================
            // Text Area
            // ==============================

            Rectangle rectText =
                new Rectangle(
                    Padding.Left,
                    Padding.Top,
                    Math.Max(
                        0,
                        Width - Padding.Horizontal
                    ),
                    Math.Max(
                        0,
                        Height - Padding.Vertical
                    )
                );

            if (rectText.Width <= 0 ||
                rectText.Height <= 0)
            {
                return;
            }

            // ==============================
            // Text
            // ==============================

            if (Required)
            {
                DrawRequiredText(
                    graphics,
                    rectText
                );
            }
            else
            {
                DrawNormalText(
                    graphics,
                    rectText
                );
            }
        }
        #endregion Paint


    }

}