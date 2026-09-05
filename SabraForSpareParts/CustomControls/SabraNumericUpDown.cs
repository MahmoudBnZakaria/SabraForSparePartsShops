using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts
{


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
