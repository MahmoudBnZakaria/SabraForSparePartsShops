using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts
{

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
