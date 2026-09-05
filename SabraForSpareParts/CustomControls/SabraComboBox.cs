using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts

{

    public class SabraComboBox : ComboBox
    {
        #region Fields

        private Color borderColor = Color.DodgerBlue;
        private Color borderFocusColor = Color.DeepSkyBlue;

        private int borderSize = 1;
        private int borderRadius = 10;

        private bool underlinedStyle = false;
        private bool isFocused = false;

        private Color arrowColor = Color.DodgerBlue;

        private int defaultSelectedIndex = 0;

        private bool required = false;
        private Color requiredColor = Color.Red;
        #endregion

        // ==============================
        // Default Selected Index
        // ==============================
        // المشكلة الأصلية: لو الـ Items بتتضاف runtime (زي ما بنعمل في
        // ucInvoicesList/ucReturns بـ Items.AddRange بعد الـ InitializeComponent)،
        // وقت ما الخاصية دي كانت بتتظبط (عادة من الـ Designer وقت الإنشاء)
        // كان Items.Count لسه = 0، فالتحديد الافتراضي مكنش بيطبّق ومفيش
        // أي محاولة تانية بعد كده. دلوقتي فيه method عامة (ApplyDefaultSelectedIndex)
        // تقدر تناديها بنفسك بعد ما تملى الـ Items، وبرضه بتتنادى تلقائيًا
        // أول ما الكنترول يتجهز (OnHandleCreated).

        [Category("Custom Properties")]
        [DefaultValue(0)]
        public int DefaultSelectedIndex
        {
            get { return defaultSelectedIndex; }
            set
            {
                defaultSelectedIndex = value;
                ApplyDefaultSelectedIndex();
                Invalidate();
            }
        }

        [Category("Custom Properties")]
        [DefaultValue(false)]
        public bool Required
        {
            get { return required; }
            set
            {
                required = value;
                Invalidate();
            }
        }
        public void ApplyDefaultSelectedIndex()
        {
            if (Items.Count > 0 &&
                defaultSelectedIndex >= 0 &&
                defaultSelectedIndex < Items.Count)
            {
                SelectedIndex = defaultSelectedIndex;
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
        // Border Radius (مكنش موجود خالص قبل كده)
        // ==============================
        // شكل التصميم عندك في الشاشات التانية (مربعات البحث، الكروت...)
        // كله حواف مدورة، وSabraTextBox بقى بيدعمها، فضفتها هنا كمان
        // عشان الشكل يبقى متسق في كل الكنترولز.

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
        // Arrow Color
        // ==============================
        // المشكلة الأصلية: الخاصية دي كانت موجودة ومعمول لها Invalidate،
        // بس مفيش أي كود في OnPaint بيستخدمها فعليًا! يعني كنت بتغيّرها
        // ومفيش أي تأثير - السهم كان بيفضل يترسم بالشكل الافتراضي اللي
        // .NET نفسه بيرسمه (رمادي/أسود) مش اللون اللي انت حددته.
        // دلوقتي بنمسح السهم الافتراضي ونرسم واحد بديل بلون ArrowColor فعليًا.

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
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw,
                true);

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
            ); // ده بينادي RecalculateItemHeight تلقائيًا (شوف Font override تحت)

            this.Size = new Size(250, 40);

            this.DropDown += SabraComboBox_DropDown;
            this.DropDownClosed += SabraComboBox_DropDownClosed;

            this.Enter += SabraComboBox_Enter;
            this.Leave += SabraComboBox_Leave;
        }

        // ==============================
        // Font (جديد) - عشان ItemHeight يتظبط تلقائي مع حجم الخط
        // ==============================
        // قبل كده ItemHeight كان رقم ثابت (30) مهما كان حجم الخط، يعني
        // لو حد كبّر الخط (accessibility مثلاً) كان النص بيتقطع جوه الليست.

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                RecalculateItemHeight();
                Invalidate();
            }
        }

        private void RecalculateItemHeight()
        {
            if (Font != null)
                ItemHeight = Math.Max(20, Font.Height + 12);
        }

        // ==============================
        // Handle Created
        // ==============================

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyDefaultSelectedIndex();
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
        // لون فاتح للحالة المعطّلة (Enabled = false)
        // ==============================
        // قبل كده لو عملت Disable للكومبو بوكس، البوردر والسهم كانوا لسه
        // بلونهم العادي الواضح (DodgerBlue مثلاً) وكأن الكنترول شغال،
        // وده مضلل بصريًا للمستخدم.

        private Color GetEffectiveColor(Color color)
        {
            return Enabled ? color : Color.FromArgb(130, color);
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

            // كانت TextFormatFlags.Right ثابتة دايمًا مهما كان اتجاه الكنترول؛
            // دلوقتي بتتظبط حسب RightToLeft فعليًا، وضفنا RightToLeft flag
            // كمان عشان شكل النص العربي (bidi shaping) يترسم صح
            bool isRtl = RightToLeft == RightToLeft.Yes;

            TextFormatFlags flags = TextFormatFlags.VerticalCenter |
                (isRtl
                    ? TextFormatFlags.Right | TextFormatFlags.RightToLeft
                    : TextFormatFlags.Left);

            Rectangle textRectangle = new Rectangle(
                10,
                e.Bounds.Y,
                e.Bounds.Width - 20,
                e.Bounds.Height
            );

            Color textColor = GetEffectiveColor(ForeColor);

            TextRenderer.DrawText(
                g,
                text,
                Font,
                textRectangle,
                textColor,
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

            // 1) .NET بترسم سهم افتراضي (رمادي/أسود) في المنطقة دي مهما
            // عملنا - بنمسحها الأول عشان نرسم بديل بلوننا احنا
            int buttonWidth = SystemInformation.VerticalScrollBarWidth + 6;
            Rectangle arrowArea = new Rectangle(
                Width - buttonWidth, 0, buttonWidth, Height);

            using (SolidBrush eraseBrush = new SolidBrush(BackColor))
            {
                g.FillRectangle(eraseBrush, arrowArea);
            }

            // 2) نرسم السهم بلون ArrowColor الحقيقي (مش الافتراضي بتاع .NET)
            DrawCustomArrow(g, arrowArea, GetEffectiveColor(arrowColor));

            // 3) البوردر - باستخدام GraphicsPath مش DrawRectangle مباشرة.
            // ملحوظة مهمة: Pen.Alignment = Inset بيتجاهله GDI+ تمامًا مع
            // DrawRectangle (باج معروف في .NET)، فلو BorderSize أكبر من 1
            // كان نص سمك الخط بيتقص برا حدود الكنترول. DrawPath بيحترم
            // Inset صح، فاستخدمناها بدل كده (زي ما عملنا في SabraTextBox).
            Color currentBorderColor = GetEffectiveColor(
                isFocused ? borderFocusColor : borderColor);

            using (Pen penBorder = new Pen(currentBorderColor, borderSize))
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
                    RectangleF rect = new RectangleF(
                        borderSize / 2f,
                        borderSize / 2f,
                        Width - borderSize,
                        Height - borderSize
                    );

                    using (GraphicsPath path = CreateRoundedRectPath(rect, borderRadius))
                    {
                        g.DrawPath(penBorder, path);
                    }
                }
            }
        }

        private void DrawCustomArrow(Graphics g, Rectangle buttonBounds, Color color)
        {
            const int arrowWidth = 8;
            const int arrowHeight = 5;

            int cx = buttonBounds.Left + buttonBounds.Width / 2;
            int cy = buttonBounds.Top + buttonBounds.Height / 2;

            Point[] arrowPoints =
            {
                new Point(cx - arrowWidth / 2, cy - arrowHeight / 2),
                new Point(cx + arrowWidth / 2, cy - arrowHeight / 2),
                new Point(cx, cy + arrowHeight / 2)
            };

            using (SolidBrush arrowBrush = new SolidBrush(color))
            {
                g.FillPolygon(arrowBrush, arrowPoints);
            }
        }

        private GraphicsPath CreateRoundedRectPath(RectangleF rect, int radius)
        {
            var path = new GraphicsPath();

            int r = Math.Min(radius, (int)Math.Min(rect.Width, rect.Height) / 2);

            if (r <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            float diameter = r * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
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

}
