using SabraForSpareParts.Screens;
using SabraForSpareParts.Screens.InventoryAlerts;
using System;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class frmMain : Form
    {
        // افترض أن لديك متغير عام يحفظ اسم المستخدم الذي سجل الدخول
        private string _loggedInUserName = "أحمد صبره"; // قم بتغييره حسب نظام الدخول الخاص بك

        public frmMain()
        {
            InitializeComponent();

            ucMenue1.ScreenSelected += UcMenue1_ScreenSelected;
            WireTopBarEvents();

            LoadScreen(MenuScreen.Main);
        }

        private void WireTopBarEvents()
        {
            if (ucTopBar1 == null) return;

            ucTopBar1.InventoryAlertsClicked += (s, e) => LoadScreen(MenuScreen.InventoryAlerts);
            ucTopBar1.NewInvoiceClicked += (s, e) => LoadScreen(MenuScreen.NewInvoice);
            ucTopBar1.AddNewPartClicked += (s, e) => LoadScreen(MenuScreen.AddPart);
            ucTopBar1.UserAvatarClicked += (s, e) => LoadScreen(MenuScreen.Settings);
        }

        private void UcMenue1_ScreenSelected(object sender, MenuScreenSelectedEventArgs e)
        {
            LoadScreen(e.Screen);
        }

        private void LoadScreen(MenuScreen screen)
        {
            SabraUserControl uc = screen switch
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
            ucMenue1.SetActiveScreen(screen);

            // التحديث الاحترافي للشريط السفلي بمجرد تحميل الشاشة
            if (ucBottomBar1 != null)
            {
                ucBottomBar1.UpdateBottomBarInfo(screen, _loggedInUserName);
            }
        }

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