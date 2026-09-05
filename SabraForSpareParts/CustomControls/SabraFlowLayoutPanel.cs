using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts
{

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

}
