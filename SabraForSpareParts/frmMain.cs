using SabraForSpareParts.Screens;
using SabraForSpareParts.Screens.InventoryAlerts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // القائمة الجانبية
            ucMenue1.ScreenSelected += UcMenue1_ScreenSelected;

            // التوب بار
            WireTopBarEvents();

            // الشاشة الافتراضية
            LoadScreen(MenuScreen.Main);
        }

        // =========================================================
        // ربط أحداث التوب بار
        // =========================================================
        private void WireTopBarEvents()
        {
            if (ucTopBar1 == null) return;

            ucTopBar1.InventoryAlertsClicked += (s, e) => LoadScreen(MenuScreen.InventoryAlerts);
            ucTopBar1.NewInvoiceClicked += (s, e) => LoadScreen(MenuScreen.NewInvoice);
            ucTopBar1.AddNewPartClicked += (s, e) => LoadScreen(MenuScreen.AddPart);

            // البحث
            ucTopBar1.SearchRequested += UcTopBar1_SearchRequested;

            // صورة المستخدم (تقدر تفتح الإعدادات أو بروفايل)
            ucTopBar1.UserAvatarClicked += (s, e) => LoadScreen(MenuScreen.Settings);
        }

        // =========================================================
        // حدث البحث من التوب بار
        // =========================================================
        private void UcTopBar1_SearchRequested(object sender, EventArgs e)
        {
            string searchText = ucTopBar1.SearchText;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ucTopBar1.FocusSearch();
                return;
            }

            // هنا تقدر تعمل اللي انت عايزه بالبحث
            // مثال بسيط: افتح شاشة المخزون وابحث فيها (لو عندك ميثود بحث)
            // أو افتح شاشة الفواتير... حسب منطق برنامجك

            // حالياً هفتح شاشة المخزون كمثال:
            LoadScreen(MenuScreen.InventoryList);

            // لو عايز تبعت نص البحث للشاشات، تقدر تعمل كده:
            // if (pnlContent.Controls.Count > 0 && pnlContent.Controls[0] is ucInventory inv)
            // {
            //     inv.Search(searchText);
            // }
        }

        // =========================================================
        // حدث اختيار شاشة من القائمة الجانبية
        // =========================================================
        private void UcMenue1_ScreenSelected(object sender, MenuScreenSelectedEventArgs e)
        {
            LoadScreen(e.Screen);
        }

        // =========================================================
        // تطبيق الصلاحيات بعد تسجيل الدخول
        // =========================================================
        private void OnUserLoggedIn(List<string> userPermissionCodes)
        {
            ucMenue1.ApplyPermissions(userPermissionCodes);

            // تقدر كمان تحدث بيانات المستخدم في التوب بار
            // ucTopBar1.SetUserSettings(userId, userName, userRole);
        }

        // =========================================================
        // تحميل الشاشة
        // =========================================================
        private void LoadScreen(MenuScreen screen)
        {
            UserControl uc = screen switch
            {
                MenuScreen.Main => new usDashboard(),
                MenuScreen.InventoryList => new ucInventory(),
                MenuScreen.AddPart => new ucAddPart(),
                MenuScreen.InventoryAlerts => new ucInventoryAlerts(),
                MenuScreen.CarCompatibility => new ucVehicleCompatibility(),
                MenuScreen.InventoryTransaction => new ucInventoryTransactions(),
                MenuScreen.NewInvoice => new ucNewInvoice(),
                MenuScreen.InvoicesList => new ucInvoicesList(),
                MenuScreen.Returns => new ucReturns(),
                MenuScreen.NewPurchaseOrder => new ucNewPurchaseOrder(),
                MenuScreen.PurchaseOrdersList => new ucPurchaseOrdersList(),
                MenuScreen.ReceiveGoods => new ucGoodsReceipt(),
                MenuScreen.Customers => new ucCustomers(),
                MenuScreen.CustomerStatement => new ucCustomerStatement(),
                MenuScreen.Suppliers => new ucSuppliers(),
                MenuScreen.SupplierStatement => new ucSupplierStatement(),
                MenuScreen.Treasury => new ucTreasury(),
                MenuScreen.Expenses => new ucExpenses(),
                MenuScreen.Salaries => new ucSalaries(),
                MenuScreen.Advances => new ucAdvances(),
                MenuScreen.Reports => new ucFinancialReports(),
                MenuScreen.CashFlow => new ucCashFlow(),
                MenuScreen.Employees => new ucEmployees(),
                MenuScreen.Users => new ucUsers(),
                MenuScreen.Settings => new ucSettings(),
                MenuScreen.Backup => new ucBackup(),
                MenuScreen.ActivityLog => new ucActivityLog(),
                _ => null
            };

            if (uc == null) return;

            ShowScreen(uc);

            // مهم جدًا: خلي الزرار في القائمة الجانبية يتلون
            ucMenue1.SetActiveScreen(screen);
        }

        // =========================================================
        // عرض الشاشة جوه البانل
        // =========================================================
        private void ShowScreen(UserControl screen)
        {
            if (screen == null) return;

            pnlContent.SuspendLayout();
            try
            {
                foreach (Control control in pnlContent.Controls)
                    control.Dispose();

                pnlContent.Controls.Clear();

                screen.Dock = DockStyle.Fill;
                screen.Margin = new Padding(0);
                pnlContent.Controls.Add(screen);
                screen.BringToFront();
            }
            finally
            {
                pnlContent.ResumeLayout(true);
            }
        }
    }
}