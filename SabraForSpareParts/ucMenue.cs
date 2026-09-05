using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class ucMenue : SabraUserControl
    {
        // ================== الألوان ==================
        private static readonly Color NormalBg = Color.FromArgb(15, 23, 42);
        private static readonly Color ActiveBg = Color.FromArgb(37, 99, 235);

        // خريطة: كل شاشة على الزرار بتاعها
        private Dictionary<MenuScreen, SabraButton> _screenButtons;

        // خريطة: كل عنوان قسم على أزراره
        private Dictionary<SabraLabel, SabraButton[]> _sectionMap;

        // نسخة من ستايل الصفوف الأصلية عشان نرجعها لما نظهر الصف تاني
        private RowStyle[] _originalRowStyles;

        // الزرار النشط حالياً
        private SabraButton _activeButton;

        /// <summary>
        /// بيتبعت لما المستخدم يدوس على أي زرار في القائمة.
        /// </summary>
        public event EventHandler<MenuScreenSelectedEventArgs> ScreenSelected;

        public ucMenue()
        {
            InitializeComponent();
            BuildMaps();
            SetActiveButton(MenuScreen.Main);   // عشان الـ Dashboard يبقى مختار من الأول
            // الشاشة الافتراضية = Dashboard
            SetActiveButton(MenuScreen.Main);
        }

        private void BuildMaps()
        {
            _screenButtons = new Dictionary<MenuScreen, SabraButton>
            {
                { MenuScreen.Main, btnMainScreen },
                { MenuScreen.InventoryList, btnInventoryListScreen },
                { MenuScreen.AddPart, btnAddPartScreen },
                { MenuScreen.InventoryAlerts, btnInventroyAlertsScreen },
                { MenuScreen.CarCompatibility, btnCarCompatibilityScreen },
                { MenuScreen.InventoryTransaction, btnInventoryTransactionScreen },
                { MenuScreen.NewInvoice, btnNewInvoice },
                { MenuScreen.InvoicesList, btnInvoicesListScreen },
                { MenuScreen.Returns, btnReturnsScreen },
                { MenuScreen.NewPurchaseOrder, btnNewPurchaseOrderScreen },
                { MenuScreen.PurchaseOrdersList, btnPurchaseOrdersListScreen },
                { MenuScreen.ReceiveGoods, btnReceiveGoodsScreen },
                { MenuScreen.Customers, btnCustomersScreen },
                { MenuScreen.CustomerStatement, btnCustomerStatementScreen },
                { MenuScreen.Suppliers, btnSuppliersScreen },
                { MenuScreen.SupplierStatement, btnSupplierStatementScreen },
                { MenuScreen.Treasury, btnTreasury },
                { MenuScreen.Expenses, btnExpensesScreen },
                { MenuScreen.Salaries, btnSalariesScreen },
                { MenuScreen.Advances, btnAdvancesScreen },
                { MenuScreen.Reports, btnReportesScreen },
                { MenuScreen.CashFlow, btnCashFlowScreen },
                { MenuScreen.Employees, btnEmployeesScreen },
                { MenuScreen.Users, btnUsersScreen },
                { MenuScreen.Settings, btnSettingsScreen },
                { MenuScreen.Backup, btnBackupScreen },
                { MenuScreen.ActivityLog, btnActvityScreenScreen },
            };

            _sectionMap = new Dictionary<SabraLabel, SabraButton[]>
            {
                { lblGeneral, new[] { btnMainScreen } },
                { lblInventory, new[] { btnInventoryListScreen, btnAddPartScreen, btnInventroyAlertsScreen, btnCarCompatibilityScreen, btnInventoryTransactionScreen } },
                { lblSales, new[] { btnNewInvoice, btnInvoicesListScreen, btnReturnsScreen } },
                { lblPurchases, new[] { btnNewPurchaseOrderScreen, btnPurchaseOrdersListScreen, btnReceiveGoodsScreen } },
                { lblSuppliersAndCustomers, new[] { btnCustomersScreen, btnCustomerStatementScreen, btnSuppliersScreen, btnSupplierStatementScreen } },
                { lblFinancial, new[] { btnTreasury, btnExpensesScreen, btnSalariesScreen, btnAdvancesScreen, btnReportesScreen, btnCashFlowScreen } },
                { sabraLabel6, new[] { btnEmployeesScreen, btnUsersScreen, btnSettingsScreen, btnBackupScreen, btnActvityScreenScreen } },
            };

            _originalRowStyles = sabraTableLayoutPanel1.RowStyles
                .Cast<RowStyle>()
                .Select(rs => new RowStyle(rs.SizeType, rs.Height))
                .ToArray();
        }

        // ========================================================
        //                      الصلاحيات
        // ========================================================

        public void ApplyPermissions(IEnumerable<MenuScreen> allowedScreens)
        {
            var allowed = new HashSet<MenuScreen>(allowedScreens ?? Enumerable.Empty<MenuScreen>());

            foreach (var kvp in _screenButtons)
                kvp.Value.Visible = allowed.Contains(kvp.Key);

            foreach (var section in _sectionMap)
                section.Key.Visible = section.Value.Any(b => b.Visible);

            UpdateRowsVisibility();
        }

        public void ApplyPermissions(IEnumerable<string> allowedPermissionCodes)
        {
            var screens = new List<MenuScreen>();

            foreach (var code in allowedPermissionCodes ?? Enumerable.Empty<string>())
            {
                if (Enum.TryParse<MenuScreen>(code, true, out var screen))
                    screens.Add(screen);
            }

            ApplyPermissions(screens);
        }

        private void UpdateRowsVisibility()
        {
            sabraTableLayoutPanel1.SuspendLayout();

            foreach (var kvp in _screenButtons)
                SetRowVisible(kvp.Value, kvp.Value.Visible);

            foreach (var section in _sectionMap)
                SetRowVisible(section.Key, section.Key.Visible);

            sabraTableLayoutPanel1.ResumeLayout(true);
        }

        private void SetRowVisible(Control control, bool visible)
        {
            int row = sabraTableLayoutPanel1.GetRow(control);
            if (row < 0 || row >= sabraTableLayoutPanel1.RowStyles.Count)
                return;

            var style = sabraTableLayoutPanel1.RowStyles[row];

            if (visible)
            {
                style.SizeType = _originalRowStyles[row].SizeType;
                style.Height = _originalRowStyles[row].Height;
            }
            else
            {
                style.SizeType = SizeType.Absolute;
                style.Height = 0;
            }
        }

        // ========================================================
        //                   الزرار النشط
        // ========================================================

        /// <summary>
        /// بتخلي الزرار بتاع الشاشة دي Active (لون مميز) طول ما الشاشة مفتوحة.
        /// </summary>
        public void SetActiveScreen(MenuScreen screen)
        {
            SetActiveButton(screen);
        }


        private void SetActiveButton(MenuScreen screen)
        {
            // رجّع الزرار القديم
            if (_activeButton != null)
            {
                _activeButton.NormalColor = NormalBg;
                _activeButton.ForeColor = Color.White;
                _activeButton.IconColor = Color.White;
            }

            // فعّل الزرار الجديد
            if (_screenButtons.TryGetValue(screen, out var button))
            {
                button.NormalColor = ActiveBg;
                button.ForeColor = Color.White;
                button.IconColor = Color.White;
                _activeButton = button;
            }
        }

        // ========================================================
        //                    أحداث الأزرار
        // ========================================================

        private void RaiseScreenSelected(MenuScreen screen)
        {
            SetActiveButton(screen);   // يفضل لونه مميز طول ما الشاشة مفتوحة
            ScreenSelected?.Invoke(this, new MenuScreenSelectedEventArgs(screen));
        }

        private void btnMainScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Main);
        private void btnInventoryListScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.InventoryList);
        private void btnAddPartScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.AddPart);
        private void btnInventroyAlertsScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.InventoryAlerts);
        private void btnCarCompatibilityScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.CarCompatibility);
        private void btnInventoryTransactionScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.InventoryTransaction);
        private void btnNewInvoice_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.NewInvoice);
        private void btnInvoicesListScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.InvoicesList);
        private void btnReturnsScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Returns);
        private void btnNewPurchaseOrderScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.NewPurchaseOrder);
        private void btnPurchaseOrdersListScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.PurchaseOrdersList);
        private void btnReceiveGoodsScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.ReceiveGoods);
        private void btnCustomersScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Customers);
        private void btnCustomerStatementScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.CustomerStatement);
        private void btnSuppliersScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Suppliers);
        private void btnSupplierStatementScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.SupplierStatement);
        private void btnTreasury_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Treasury);
        private void btnExpensesScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Expenses);
        private void btnSalariesScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Salaries);
        private void btnAdvancesScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Advances);
        private void btnReportesScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Reports);
        private void btnCashFlowScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.CashFlow);
        private void btnEmployeesScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Employees);
        private void btnUsersScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Users);
        private void btnSettingsScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Settings);
        private void btnBackupScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.Backup);
        private void btnActvityScreenScreen_Click(object sender, EventArgs e) => RaiseScreenSelected(MenuScreen.ActivityLog);
    }
}