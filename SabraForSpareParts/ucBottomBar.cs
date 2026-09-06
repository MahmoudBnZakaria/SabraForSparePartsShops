using SabraForSpareParts.SabraForSpareParts;
using System;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class ucBottomBar : UserControl
    {
        #region Properties

        public string CurrentScreenName
        {
            get => lblCurrentScreenName?.Text ?? string.Empty;
            set
            {
                if (lblCurrentScreenName != null)
                {
                    lblCurrentScreenName.Text = string.IsNullOrWhiteSpace(value)
                        ? "الشاشة الحالية: غير محدد"
                        : $"الشاشة الحالية: {value.Trim()}";
                }
            }
        }

        public string CurrentUser
        {
            get => lblUser?.Text ?? string.Empty;
            set
            {
                if (lblUser != null)
                {
                    lblUser.Text = string.IsNullOrWhiteSpace(value)
                        ? "المستخدم: ضيف"
                        : $"المستخدم: {value.Trim()}";
                }
            }
        }

        #endregion

        #region Constructor & Initialization

        public ucBottomBar()
        {
            InitializeComponent();
            InitializeBarSettings();
        }

        private void InitializeBarSettings()
        {
            UpdateTime();

            if (timer1 != null)
            {
                timer1.Interval = 1000;
                timer1.Start();
            }

            CurrentScreenName = "الرئيسية";
            CurrentUser = "غير مسجل";
        }

        #endregion

        #region Timer Events

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            if (lblTime != null)
            {
                lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy  |  hh:mm:ss tt");
            }
        }

        #endregion

        #region Public Methods

        // هنا استخدمنا الـ Extension Method (GetDisplayName) لتحويل الـ Enum لاسم الشاشة بالعربي
        public void UpdateBottomBarInfo(MenuScreen screen, string userName)
        {
            CurrentScreenName = screen.GetDisplayName();
            CurrentUser = userName;
        }

        #endregion
    }
}