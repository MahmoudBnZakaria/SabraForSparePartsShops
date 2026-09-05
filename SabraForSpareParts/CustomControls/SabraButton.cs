using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts
{
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




    // ملحوظة: افترضت الـ namespace دا (SabraForSpareParts.Controls) لأنه مش موجود في اللي بعتهولي.
    // لو الكلاس عندك في namespace تاني، غيّره هنا بس.

    public enum SabraButtonKind
    {
        Default,
        Primary,
        Success,
        Danger,
        Warning,
    }

    /// <summary>
    /// عمود زرار بيدعم "نوع" (لون) جاهز — Primary لزرار التعديل، Danger لزرار الحذف، إلخ،
    /// بدل ما تكون كل الأزرار في الجدول بنفس اللون زي القديم.
    /// </summary>
    public class SabraButtonColumn : DataGridViewButtonColumn
    {
        public SabraButtonKind Kind { get; set; } = SabraButtonKind.Default;

        /// <summary>حرف أو رمز صغير يتحط قبل نص الزرار، اختياري (مثلاً "✎" أو "×")</summary>
        public string Icon { get; set; }

        public SabraButtonColumn()
        {
            UseColumnTextForButtonValue = true;
        }
    }


}
