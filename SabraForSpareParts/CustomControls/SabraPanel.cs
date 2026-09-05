using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts
{

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

}
