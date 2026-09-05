using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts
{
    public class SabraCalendarPopup : Form
    {
        private enum CalendarView
        {
            Days,
            Months,
            Years
        }

        private DateTime selectedDate;
        private DateTime displayedMonth;
        private CalendarView currentView = CalendarView.Days;

        private readonly CultureInfo arabicCulture = new CultureInfo("ar-EG");

        private readonly Button btnHeaderTitle; // تحويل Label إلى Button للضغط عليه
        private readonly Button btnNext;
        private readonly Button btnPrevious;
        private readonly Button btnToday;
        private readonly Button btnClose;

        private readonly TableLayoutPanel daysPanel;

        private Color primaryColor = Color.FromArgb(0, 120, 212);
        private Color hoverColor = Color.FromArgb(235, 242, 250);
        private Color textColor = Color.FromArgb(45, 45, 45);

        public event EventHandler<DateTime> DateSelected;

        public SabraCalendarPopup(DateTime date, bool rtl = true)
        {
            selectedDate = date.Date;
            displayedMonth = new DateTime(date.Year, date.Month, 1);

            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;

            Width = 420;
            Height = 470;
            BackColor = Color.White;

            RightToLeft = rtl ? RightToLeft.Yes : RightToLeft.No;
            RightToLeftLayout = rtl;
            Padding = new Padding(16);

            // Header Title Button
            btnHeaderTitle = new Button
            {
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Cairo", 12F, FontStyle.Bold),
                ForeColor = textColor,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                TabStop = false
            };
            btnHeaderTitle.FlatAppearance.BorderSize = 0;
            btnHeaderTitle.Click += BtnHeaderTitle_Click;

            btnPrevious = CreateHeaderButton("‹");
            btnNext = CreateHeaderButton("›");

            btnPrevious.Click += (s, e) => Navigate(-1);
            btnNext.Click += (s, e) => Navigate(1);

            TableLayoutPanel header = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 64,
                ColumnCount = 3,
                RowCount = 1
            };

            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55));

            header.Controls.Add(btnPrevious, 0, 0);
            header.Controls.Add(btnHeaderTitle, 1, 0);
            header.Controls.Add(btnNext, 2, 0);

            daysPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 7,
                RowCount = 7,
                Padding = new Padding(2, 10, 2, 10)
            };

            btnToday = CreateFooterButton("اليوم");
            btnClose = CreateFooterButton("إغلاق");

            btnToday.Click += (s, e) =>
            {
                displayedMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                selectedDate = DateTime.Today;
                currentView = CalendarView.Days;
                RenderCalendar();
            };

            btnClose.Click += (s, e) => Close();

            TableLayoutPanel footer = new TableLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 55,
                ColumnCount = 2,
                Padding = new Padding(0, 5, 0, 0)
            };

            footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            footer.Controls.Add(btnToday, 0, 0);
            footer.Controls.Add(btnClose, 1, 0);

            Controls.Add(daysPanel);
            Controls.Add(footer);
            Controls.Add(header);

            Deactivate += (s, e) => BeginInvoke(new Action(Close));

            RenderCalendar();
        }

        private void Navigate(int direction)
        {
            switch (currentView)
            {
                case CalendarView.Days:
                    displayedMonth = displayedMonth.AddMonths(direction);
                    break;
                case CalendarView.Months:
                    displayedMonth = displayedMonth.AddYears(direction);
                    break;
                case CalendarView.Years:
                    displayedMonth = displayedMonth.AddYears(direction * 12);
                    break;
            }
            RenderCalendar();
        }

        private void BtnHeaderTitle_Click(object sender, EventArgs e)
        {
            if (currentView == CalendarView.Days)
                currentView = CalendarView.Months;
            else if (currentView == CalendarView.Months)
                currentView = CalendarView.Years;

            RenderCalendar();
        }

        private void RenderCalendar()
        {
            daysPanel.SuspendLayout();
            daysPanel.Controls.Clear();
            daysPanel.ColumnStyles.Clear();
            daysPanel.RowStyles.Clear();

            switch (currentView)
            {
                case CalendarView.Days:
                    RenderDaysView();
                    break;
                case CalendarView.Months:
                    RenderMonthsView();
                    break;
                case CalendarView.Years:
                    RenderYearsView();
                    break;
            }

            daysPanel.ResumeLayout();
        }

        private void RenderDaysView()
        {
            btnHeaderTitle.Text = displayedMonth.ToString("MMMM yyyy", arabicCulture);

            daysPanel.ColumnCount = 7;
            daysPanel.RowCount = 7;

            for (int i = 0; i < 7; i++)
                daysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));

            for (int i = 0; i < 7; i++)
                daysPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857F));

            string[] dayNames = { "ح", "ن", "ث", "ر", "خ", "ج", "س" };
            for (int i = 0; i < 7; i++)
            {
                Label dayLabel = new Label
                {
                    Text = dayNames[i],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Cairo", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(130, 135, 145)
                };
                daysPanel.Controls.Add(dayLabel, i, 0);
            }

            int firstDayIndex = ((int)displayedMonth.DayOfWeek + 1) % 7;
            int daysInMonth = DateTime.DaysInMonth(displayedMonth.Year, displayedMonth.Month);
            int day = 1;

            for (int row = 1; row <= 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (row == 1 && col < firstDayIndex) continue;
                    if (day > daysInMonth) break;

                    DateTime currentDate = new DateTime(displayedMonth.Year, displayedMonth.Month, day);
                    Button dayButton = CreateDayButton(currentDate);
                    daysPanel.Controls.Add(dayButton, col, row);
                    day++;
                }
            }
        }

        private void RenderMonthsView()
        {
            btnHeaderTitle.Text = displayedMonth.ToString("yyyy", arabicCulture);

            daysPanel.ColumnCount = 3;
            daysPanel.RowCount = 4;

            for (int i = 0; i < 3; i++)
                daysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            for (int i = 0; i < 4; i++)
                daysPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            for (int m = 1; m <= 12; m++)
            {
                int monthIndex = m;
                DateTime monthDate = new DateTime(displayedMonth.Year, monthIndex, 1);
                Button btnMonth = new Button
                {
                    Text = monthDate.ToString("MMMM", arabicCulture),
                    Dock = DockStyle.Fill,
                    Font = new Font("Cairo", 10F, FontStyle.Regular),
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(3),
                    Cursor = Cursors.Hand,
                    BackColor = (monthIndex == displayedMonth.Month) ? primaryColor : Color.White,
                    ForeColor = (monthIndex == displayedMonth.Month) ? Color.White : textColor
                };
                btnMonth.FlatAppearance.BorderSize = 0;

                btnMonth.Click += (s, e) =>
                {
                    displayedMonth = new DateTime(displayedMonth.Year, monthIndex, 1);
                    currentView = CalendarView.Days;
                    RenderCalendar();
                };

                int row = (m - 1) / 3;
                int col = (m - 1) % 3;
                daysPanel.Controls.Add(btnMonth, col, row);
            }
        }

        private void RenderYearsView()
        {
            int startYear = displayedMonth.Year - (displayedMonth.Year % 12);
            int endYear = startYear + 11;

            btnHeaderTitle.Text = $"{startYear} - {endYear}";

            daysPanel.ColumnCount = 3;
            daysPanel.RowCount = 4;

            for (int i = 0; i < 3; i++)
                daysPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

            for (int i = 0; i < 4; i++)
                daysPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            for (int i = 0; i < 12; i++)
            {
                int year = startYear + i;
                Button btnYear = new Button
                {
                    Text = year.ToString(),
                    Dock = DockStyle.Fill,
                    Font = new Font("Cairo", 10F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(3),
                    Cursor = Cursors.Hand,
                    BackColor = (year == displayedMonth.Year) ? primaryColor : Color.White,
                    ForeColor = (year == displayedMonth.Year) ? Color.White : textColor
                };
                btnYear.FlatAppearance.BorderSize = 0;

                btnYear.Click += (s, e) =>
                {
                    displayedMonth = new DateTime(year, displayedMonth.Month, 1);
                    currentView = CalendarView.Months;
                    RenderCalendar();
                };

                int row = i / 3;
                int col = i % 3;
                daysPanel.Controls.Add(btnYear, col, row);
            }
        }

        private Button CreateHeaderButton(string text)
        {
            return new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 20F, FontStyle.Regular),
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = Color.White,
                ForeColor = textColor,
                Cursor = Cursors.Hand,
                TabStop = false
            };
        }

        private Button CreateFooterButton(string text)
        {
            return new Button
            {
                Text = text,
                Font = new Font("Cairo", 9.5F),
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = text == "اليوم" ? primaryColor : Color.FromArgb(245, 247, 249),
                ForeColor = text == "اليوم" ? Color.White : textColor,
                Cursor = Cursors.Hand,
                Margin = new Padding(5, 0, 5, 0)
            };
        }

        private Button CreateDayButton(DateTime date)
        {
            bool isSelected = date.Date == selectedDate.Date;
            bool isToday = date.Date == DateTime.Today;

            Button button = new Button
            {
                Text = date.Day.ToString(),
                Dock = DockStyle.Fill,
                Font = new Font("Cairo", 9.5F, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Margin = new Padding(4),
                Cursor = Cursors.Hand,
                Tag = date,
                BackColor = isSelected ? primaryColor : Color.White,
                ForeColor = isSelected ? Color.White : textColor
            };

            if (isToday && !isSelected)
            {
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.BorderColor = primaryColor;
            }

            button.MouseEnter += (s, e) => { if (!isSelected) button.BackColor = hoverColor; };
            button.MouseLeave += (s, e) => { if (!isSelected) button.BackColor = Color.White; };
            button.Click += DayButton_Click;

            return button;
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is DateTime date)
            {
                selectedDate = date;
                DateSelected?.Invoke(this, selectedDate);
                Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle shadowRect = new Rectangle(3, 3, Width - 7, Height - 7);
            using Pen shadowPen = new Pen(Color.FromArgb(35, 0, 0, 0), 3);
            e.Graphics.DrawRectangle(shadowPen, shadowRect);

            using Pen borderPen = new Pen(Color.FromArgb(225, 230, 235), 1);
            e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
        }
    }

}
