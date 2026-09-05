using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts
{


    public class SabraTextBox : UserControl
    {
        // ==============================================================
        // ليه غيّرت الـ base class من TextBox لـ UserControl؟ (السبب الجذري)
        // ==============================================================
        // - TextBox هو Wrapper حوالين كنترول Windows الأصلي (Edit control)،
        //   وده بيخليه ControlStyles.UserPaint = false، يعني OnPaint بتاعك
        //   ماكنش بينفّذ أصلاً وقت الرسم الفعلي -> عشان كده الـ BorderRadius
        //   (اللي بتقول عليه "الرواندد") مكنش بيظهر أبدًا.
        // - كنت عامل TextBox جوه TextBox (الكلاس نفسه + textBox1 جواه)،
        //   يعني في native edit controls اتنين فوق بعض بيتنازعوا على الفوكس
        //   والرسم، وده سبب مباشر لمشاكل الأداء والتقطيع (flicker).
        // - UserControl هو الكلاس الصح للحالة دي: بيدعم الرسم المخصص (GDI+)
        //   بشكل طبيعي بدون أي حِيَل إضافية.

        #region Fields

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

        // عشان مانخليش الـ TextChanged يتطلق وهمي وقت ما بنغيّر النص
        // برمجيًا عشان نظبط الـ placeholder (مش المستخدم اللي بيكتب فعليًا)
        private bool _suppressTextChanged = false;

        // الـ TextBox الحقيقي الظاهر جوه الكنترول
        private TextBox textBox1;

        private bool required = false;
        private Color requiredColor = Color.Red;
        #endregion

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
        [DefaultValue(false)]
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
        // خصائص TextBox شائعة الاستخدام - مضافة عشان أي كود قديم بيستخدمها
        // مايبوظش لما TextBox اتحول لـ UserControl (زي MaxLength, ReadOnly...)
        // لو في خاصية تانية بتستخدمها في مواضع تانية وملقتهاش هنا قولّي أضيفها
        // ==============================

        [Category("Custom Properties")]
        [DefaultValue(32767)]
        public int MaxLength
        {
            get { return textBox1.MaxLength; }
            set { textBox1.MaxLength = value; }
        }

        [Category("Custom Properties")]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return textBox1.ReadOnly; }
            set { textBox1.ReadOnly = value; }
        }

        [Category("Custom Properties")]
        [DefaultValue(CharacterCasing.Normal)]
        public CharacterCasing CharacterCasing
        {
            get { return textBox1.CharacterCasing; }
            set { textBox1.CharacterCasing = value; }
        }

        [Category("Custom Properties")]
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment TextAlign
        {
            get { return textBox1.TextAlign; }
            set { textBox1.TextAlign = value; }
        }

        [Browsable(false)]
        public int SelectionStart
        {
            get { return textBox1.SelectionStart; }
            set { textBox1.SelectionStart = value; }
        }

        [Browsable(false)]
        public int SelectionLength
        {
            get { return textBox1.SelectionLength; }
            set { textBox1.SelectionLength = value; }
        }

        [Browsable(false)]
        public string SelectedText
        {
            get { return textBox1.SelectedText; }
            set { textBox1.SelectedText = value; }
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
        // Text (دي كانت المشكلة التانية الكبيرة)
        // ==============================
        // في الكود الأصلي كانت الخاصية اسمها "Texts" مش "Text"، يعني أي كود
        // بيستخدم ".Text" العادية (زي أي TextBox طبيعي) كان بيتعامل مع
        // الـ Text الأصلية المخفية بتاعة TextBox القديم اللي مالوش أي تأثير
        // ظاهر للمستخدم - يعني القراءة والكتابة بالـ ".Text" كانت مش شغالة
        // خالص من غير ما تدّي أي error. دلوقتي "Text" بقت override حقيقية.

        [Category("Custom Properties")]
        [Browsable(true)]
        public override string Text
        {
            get
            {
                if (textBox1 == null) return base.Text;
                return isPlaceholder ? "" : textBox1.Text;
            }
            set
            {
                if (textBox1 == null)
                {
                    base.Text = value;
                    return;
                }

                isPlaceholder = false;
                textBox1.ForeColor = ForeColor;
                textBox1.Text = value ?? "";

                if (string.IsNullOrWhiteSpace(value))
                    SetPlaceholder();
            }
        }

        // خلّيتها موجودة عشان أي كود قديم عندك بيستخدم ".Texts" (بالـ s)
        // يفضل شغال زي ما هو من غير ما يبوظ حاجة - بس استخدم "Text" بس
        // في أي كود جديد.
        [Browsable(false)]
        [Obsolete("استخدم الخاصية Text العادية بدل Texts - اتسابت هنا بس للتوافق مع كود قديم")]
        public string Texts
        {
            get { return Text; }
            set { Text = value; }
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

                if (textBox1 == null) return;

                // لو المستخدم مكتوبش حاجة فعلية، حدّث الـ placeholder على طول.
                // لو فيه نص حقيقي مكتوب بالفعل سيبه زي ما هو ومتمسحوش
                // (في النسخة القديمة كان بيتمسح دايمًا وده كان ممكن يمسح
                // كلام المستخدم لو الخاصية دي اتغيرت وقت الشغل)
                if (isPlaceholder || string.IsNullOrEmpty(textBox1.Text))
                {
                    _suppressTextChanged = true;
                    textBox1.Text = "";
                    _suppressTextChanged = false;

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
        // Focused
        // ==============================
        // Control.Focused الأصلية كانت هترجع false دايمًا حتى لو المستخدم
        // بيكتب فعليًا، لأن الفوكس الحقيقي بيروح لـ textBox1 الداخلي مش
        // للكنترول الخارجي نفسه.

        [Browsable(false)]
        public new bool Focused
        {
            get { return textBox1 != null && textBox1.Focused; }
        }

        // ==============================
        // Constructor
        // ==============================

        public SabraTextBox()
        {
            // رسم مخصص سلس + تقليل الوميض (flicker) وقت الرسم/الـ Resize
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);

            DoubleBuffered = true;

            textBox1 = new TextBox();

            SuspendLayout();

            // ==============================
            // Internal TextBox
            // ==============================

            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Name = "textBox1";
            textBox1.TabIndex = 0;

            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;

            // ==============================
            // Main Control
            // ==============================

            Controls.Add(textBox1);

            Padding = new Padding(10, 7, 25, 7);

            Size = new Size(250, 40);

            BackColor = Color.White;

            ForeColor = Color.FromArgb(64, 64, 64);

            RightToLeft = RightToLeft.Yes;

            Cursor = Cursors.IBeam;

            Font = new Font(
                "Cairo",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            // لو المستخدم دوس في مساحة الـ Padding حوالين الـ TextBox (يعني
            // مساحة الحدود المدورة نفسها)، نودي الفوكس تلقائيًا للـ TextBox
            // الداخلي بدل ما يفضل مش شغال
            Click += (s, e) =>
            {
                if (!textBox1.Focused)
                    textBox1.Focus();
            };

            // ==============================
            // Finish
            // ==============================

            ResumeLayout(false);
            PerformLayout();

            UpdateControlHeight();
        }

        // ==============================
        // Focus / SelectAll / Clear - Helper methods
        // ==============================

        public new bool Focus()
        {
            return textBox1 != null && textBox1.Focus();
        }

        public void SelectAll()
        {
            textBox1?.SelectAll();
        }

        public void Clear()
        {
            Text = "";
        }

        public void AppendText(string text)
        {
            isPlaceholder = false;
            textBox1?.AppendText(text);
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

                _suppressTextChanged = true;
                textBox1.Text = placeholderText;
                _suppressTextChanged = false;

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

                _suppressTextChanged = true;
                textBox1.Text = "";
                _suppressTextChanged = false;

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
            // منمنعش الحدث ده يتطلق لما بنكتب/نمسح نص الـ placeholder داخليًا
            // - بس لما المستخدم يكتب فعليًا
            if (_suppressTextChanged)
                return;

            TextChanged?.Invoke(this, e);
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

}
