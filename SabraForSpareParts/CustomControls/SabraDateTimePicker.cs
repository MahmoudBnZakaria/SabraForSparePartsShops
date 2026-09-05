using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts
{

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

        private bool required = false;
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
        [DefaultValue(false)]
        public bool Required
        {
            get => required;
            set
            {
                if (required == value)
                    return;

                required = value;
                UpdateDateText();
                Invalidate();
            }
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

}
