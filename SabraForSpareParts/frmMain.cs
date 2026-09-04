using System;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class frmMain : Form
    {
        // =========================================================
        // Current Screen
        // =========================================================

        private Control _currentScreen;

        // =========================================================
        // Constructor
        // =========================================================

        public frmMain()
        {
            InitializeComponent();

            InitializeMainForm();
            InitializeTopBar();
            InitializeSidebar();
            InitializeBottomBar();

            ShowDashboard();
        }

        // =========================================================
        // Main Form Initialization
        // =========================================================

        private void InitializeMainForm()
        {
            StartPosition = FormStartPosition.CenterScreen;

            MinimumSize = new Size(1000, 650);

            WindowState = FormWindowState.Maximized;

            KeyPreview = true;

            RightToLeft = RightToLeft.Yes;

            RightToLeftLayout = true;

            BackColor = Color.WhiteSmoke;

            FormBorderStyle = FormBorderStyle.Sizable;

            ShowIcon = false;

            ShowInTaskbar = true;

            KeyDown += FrmMain_KeyDown;
        }

        // =========================================================
        // Top Bar
        // =========================================================

        private void InitializeTopBar()
        {
            if (ucTopBar1 == null)
                return;

            ucTopBar1.Dock = DockStyle.Top;

            ucTopBar1.Height = 83;

            ucTopBar1.BringToFront();

            ucTopBar1.SearchRequested -= UcTopBar1_SearchRequested;
            ucTopBar1.SearchRequested += UcTopBar1_SearchRequested;

            ucTopBar1.InventoryAlertsClicked -=
                UcTopBar1_InventoryAlertsClicked;

            ucTopBar1.InventoryAlertsClicked +=
                UcTopBar1_InventoryAlertsClicked;

            ucTopBar1.NewInvoiceClicked -=
                UcTopBar1_NewInvoiceClicked;

            ucTopBar1.NewInvoiceClicked +=
                UcTopBar1_NewInvoiceClicked;

            ucTopBar1.AddNewPartClicked -=
                UcTopBar1_AddNewPartClicked;

            ucTopBar1.AddNewPartClicked +=
                UcTopBar1_AddNewPartClicked;

            ucTopBar1.UserAvatarClicked -=
                UcTopBar1_UserAvatarClicked;

            ucTopBar1.UserAvatarClicked +=
                UcTopBar1_UserAvatarClicked;
        }

        // =========================================================
        // Sidebar
        // =========================================================

        private void InitializeSidebar()
        {
            if (splitContainer2 == null)
                return;

            splitContainer2.Dock = DockStyle.Fill;

            splitContainer2.Orientation =
                Orientation.Vertical;

            splitContainer2.IsSplitterFixed = true;

            splitContainer2.SplitterWidth = 1;

            splitContainer2.FixedPanel =
                FixedPanel.Panel2;

            splitContainer2.Panel2MinSize = 210;

            splitContainer2.Panel1MinSize = 500;

            // Sidebar width
            splitContainer2.SplitterDistance =
                Math.Max(
                    700,
                    ClientSize.Width - 260
                );

            ConfigureSidebarButton();
        }

        // =========================================================
        // Sidebar Button
        // =========================================================

        private void ConfigureSidebarButton()
        {
            if (sabraButton1 == null)
                return;

            sabraButton1.Dock =
                DockStyle.Top;

            sabraButton1.Height = 55;

            sabraButton1.Margin =
                new Padding(10);

            sabraButton1.Text =
                "الرئيسية";

            sabraButton1.IconChar =
                FontAwesome.Sharp.IconChar.House;

            sabraButton1.IconColor =
                Color.White;

            sabraButton1.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            sabraButton1.IconSize =
                24;

            sabraButton1.TextAlign =
                ContentAlignment.MiddleCenter;

            sabraButton1.Cursor =
                Cursors.Hand;

            sabraButton1.TabStop = true;

            sabraButton1.Click -=
                sabraButton1_Click;

            sabraButton1.Click +=
                sabraButton1_Click;
        }

        // =========================================================
        // Bottom Bar
        // =========================================================

        private void InitializeBottomBar()
        {
            if (ucBottomBar1 == null)
                return;

            ucBottomBar1.Dock =
                DockStyle.Bottom;

            ucBottomBar1.Height = 42;

            ucBottomBar1.BringToFront();
        }

        // =========================================================
        // Dashboard
        // =========================================================

        private void ShowDashboard()
        {
            if (ucMain1 == null)
                return;

            ShowScreen(ucMain1);

            UpdateSidebarSelection(
                sabraButton1
            );
        }

        // =========================================================
        // Show Screen
        // =========================================================

        public void ShowScreen(Control screen)
        {
            if (screen == null)
                return;

            if (splitContainer2 == null)
                return;

            Control contentPanel =
                splitContainer2.Panel1;

            if (contentPanel == null)
                return;

            // Remove current screen
            if (_currentScreen != null &&
                _currentScreen != screen)
            {
                contentPanel.Controls.Remove(
                    _currentScreen
                );

                if (_currentScreen != ucMain1)
                {
                    _currentScreen.Dispose();
                }
            }

            _currentScreen = screen;

            if (!contentPanel.Controls.Contains(screen))
            {
                contentPanel.Controls.Add(screen);
            }

            screen.Dock =
                DockStyle.Fill;

            screen.BringToFront();

            contentPanel.BackColor =
                Color.WhiteSmoke;
        }

        // =========================================================
        // TopBar - Search
        // =========================================================

        private void UcTopBar1_SearchRequested(
            object sender,
            EventArgs e)
        {
            string searchText =
                ucTopBar1.SearchText;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ucTopBar1.FocusSearch();
                return;
            }

            ExecuteGlobalSearch(searchText);
        }

        // =========================================================
        // Global Search
        // =========================================================

        private void ExecuteGlobalSearch(
            string searchText)
        {
            searchText =
                searchText?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(searchText))
                return;

            // هنا مكان البحث الحقيقي.
            //
            // مثال:
            //
            // البحث عن:
            // فاتورة
            // عميل
            // قطعة غيار
            // رقم هاتف
            // كود قطعة
            //
            // وبعدها نعرض النتيجة في Screen مخصص.

            MessageBox.Show(
                $"البحث عن:\n{searchText}",
                "البحث",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // =========================================================
        // Inventory Alerts
        // =========================================================

        private void UcTopBar1_InventoryAlertsClicked(
            object sender,
            EventArgs e)
        {
            OpenInventoryAlerts();
        }

        private void OpenInventoryAlerts()
        {
            // ضع هنا Screen تنبيهات المخزون
            //
            // مثال مستقبلاً:
            //
            // ShowScreen(new ucInventoryAlerts());
        }

        // =========================================================
        // New Invoice
        // =========================================================

        private void UcTopBar1_NewInvoiceClicked(
            object sender,
            EventArgs e)
        {
            OpenNewInvoice();
        }

        private void OpenNewInvoice()
        {
            // ضع هنا Screen إنشاء فاتورة جديدة
            //
            // مثال مستقبلاً:
            //
            // ShowScreen(new ucNewInvoice());
        }

        // =========================================================
        // Add New Part
        // =========================================================

        private void UcTopBar1_AddNewPartClicked(
            object sender,
            EventArgs e)
        {
            OpenAddNewPart();
        }

        private void OpenAddNewPart()
        {
            // ضع هنا Screen إضافة قطعة جديدة
            //
            // مثال مستقبلاً:
            //
            // ShowScreen(new ucAddNewPart());
        }

        // =========================================================
        // User Avatar
        // =========================================================

        private void UcTopBar1_UserAvatarClicked(
            object sender,
            EventArgs e)
        {
            ShowUserMenu();
        }

        // =========================================================
        // User Menu
        // =========================================================

        private void ShowUserMenu()
        {
            using (ContextMenuStrip menu =
                   new ContextMenuStrip())
            {
                ToolStripMenuItem userInfo =
                    new ToolStripMenuItem(
                        ucTopBar1.UserName
                    );

                userInfo.Enabled = false;

                ToolStripMenuItem settings =
                    new ToolStripMenuItem(
                        "الإعدادات"
                    );

                ToolStripMenuItem logout =
                    new ToolStripMenuItem(
                        "تسجيل الخروج"
                    );

                settings.Click +=
                    Settings_Click;

                logout.Click +=
                    Logout_Click;

                menu.Items.Add(userInfo);

                menu.Items.Add(
                    new ToolStripSeparator()
                );

                menu.Items.Add(settings);

                menu.Items.Add(logout);

                menu.Show(
                    fwGetAvatarLocation(),
                    ToolStripDropDownDirection.BelowLeft
                );
            }
        }

        private Point fwGetAvatarLocation()
        {
            if (ucTopBar1 == null)
                return Point.Empty;

            Point location =
                ucTopBar1.PointToScreen(
                    new Point(
                        ucTopBar1.Width - 80,
                        ucTopBar1.Height
                    )
                );

            return location;
        }

        // =========================================================
        // Settings
        // =========================================================

        private void Settings_Click(
            object sender,
            EventArgs e)
        {
            // افتح شاشة الإعدادات هنا
        }

        // =========================================================
        // Logout
        // =========================================================

        private void Logout_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "هل أنت متأكد من تسجيل الخروج؟",
                    "تسجيل الخروج",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
                return;

            // هنا تقدر تمسح Session المستخدم
            //
            // ثم ترجع لشاشة Login.

            Close();
        }

        // =========================================================
        // Sidebar Button
        // =========================================================

        private void sabraButton1_Click(
            object sender,
            EventArgs e)
        {
            ShowDashboard();
        }

        // =========================================================
        // Sidebar Selection
        // =========================================================

        private void UpdateSidebarSelection(
            Control selectedControl)
        {
            if (selectedControl == null)
                return;

            if (selectedControl is SabraButton button)
            {
                button.BackColor =
                    Color.FromArgb(
                        37,
                        99,
                        235
                    );
            }
        }

        // =========================================================
        // Keyboard
        // =========================================================

        private void FrmMain_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            // Escape
            if (e.KeyCode == Keys.Escape)
            {
                if (ucTopBar1 != null)
                    ucTopBar1.ClearSearch();

                e.Handled = true;
            }
        }

        // =========================================================
        // Login User Settings
        // =========================================================

        public void SetLoggedInUser(
            int userId,
            string userName,
            string userRole,
            string customerName = "",
            decimal creditLimit = 0)
        {
            if (ucTopBar1 == null)
                return;

            ucTopBar1.SetUserSettings(
                userId,
                userName,
                userRole,
                customerName,
                creditLimit
            );
        }

        // =========================================================
        // Session Properties
        // =========================================================

        public int CurrentUserId
        {
            get
            {
                return ucTopBar1?.UserId ?? 0;
            }
        }

        public string CurrentUserName
        {
            get
            {
                return ucTopBar1?.UserName ?? "User";
            }
        }

        public string CurrentUserRole
        {
            get
            {
                return ucTopBar1?.UserRole ?? "User";
            }
        }

        // =========================================================
        // Form Closing
        // =========================================================

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            if (ucTopBar1 != null)
            {
                ucTopBar1.SearchRequested -=
                    UcTopBar1_SearchRequested;

                ucTopBar1.InventoryAlertsClicked -=
                    UcTopBar1_InventoryAlertsClicked;

                ucTopBar1.NewInvoiceClicked -=
                    UcTopBar1_NewInvoiceClicked;

                ucTopBar1.AddNewPartClicked -=
                    UcTopBar1_AddNewPartClicked;

                ucTopBar1.UserAvatarClicked -=
                    UcTopBar1_UserAvatarClicked;
            }

            base.OnFormClosed(e);
        }
    }
}