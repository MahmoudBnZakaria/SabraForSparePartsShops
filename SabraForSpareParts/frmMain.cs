using DocumentFormat.OpenXml.Drawing;
using Sabra.DataLayer.Models;
using Sabra.LogicLayer;
using SabraForSpareParts.Screens;
using SabraForSpareParts.Screens.InventoryAlerts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static SabraForSpareParts.Screens.ucCustomers;

namespace SabraForSpareParts
{
    public partial class frmMain : Form
    {
        #region Fields

        private SabraUserControl _currentScreen;

        private readonly Dictionary<MenuScreen, SabraUserControl> _screenCache
            = new Dictionary<MenuScreen, SabraUserControl>();

        #endregion


        #region Constructor

        public frmMain()
        {
            InitializeComponent();

            InitializeNavigation();
        }

        #endregion


        #region Initialization

        private void InitializeNavigation()
        {
            WireMenuEvents();
            WireTopBarEvents();

            LoadScreen(MenuScreen.Main);
        }

        private void WireMenuEvents()
        {
            if (ucMenue1 == null)
                return;

            ucMenue1.ScreenSelected -= UcMenue1_ScreenSelected;
            ucMenue1.ScreenSelected += UcMenue1_ScreenSelected;
        }

        private void WireTopBarEvents()
        {
            if (ucTopBar1 == null)
                return;

            ucTopBar1.InventoryAlertsClicked -= UcTopBar1_InventoryAlertsClicked;
            ucTopBar1.InventoryAlertsClicked += UcTopBar1_InventoryAlertsClicked;

            ucTopBar1.NewInvoiceClicked -= UcTopBar1_NewInvoiceClicked;
            ucTopBar1.NewInvoiceClicked += UcTopBar1_NewInvoiceClicked;

            ucTopBar1.AddNewPartClicked -= UcTopBar1_AddNewPartClicked;
            ucTopBar1.AddNewPartClicked += UcTopBar1_AddNewPartClicked;

            ucTopBar1.UserAvatarClicked -= UcTopBar1_UserAvatarClicked;
            ucTopBar1.UserAvatarClicked += UcTopBar1_UserAvatarClicked;
        }

        #endregion


        #region Menu Events

        private void UcMenue1_ScreenSelected(
            object sender,
            MenuScreenSelectedEventArgs e)
        {
            if (e == null)
                return;

            LoadScreen(e.Screen);
        }

        #endregion


        #region Top Bar Events

        private void UcTopBar1_InventoryAlertsClicked(
            object sender,
            EventArgs e)
        {
            LoadScreen(MenuScreen.InventoryAlerts);
        }

        private void UcTopBar1_NewInvoiceClicked(
            object sender,
            EventArgs e)
        {
            LoadScreen(MenuScreen.NewInvoice);
        }

        private void UcTopBar1_AddNewPartClicked(
            object sender,
            EventArgs e)
        {
            LoadScreen(MenuScreen.AddPart);
        }

        private void UcTopBar1_UserAvatarClicked(
            object sender,
            EventArgs e)
        {
            LoadScreen(MenuScreen.Settings);
        }

        #endregion


        #region Screen Navigation

        private void LoadScreen(MenuScreen screen)
        {
            SabraUserControl userControl = GetOrCreateScreen(screen);

            if (userControl == null)
                return;

            ShowScreen(userControl);

            UpdateNavigationState(screen);

            userControl.Focus();
        }

        private SabraUserControl GetOrCreateScreen(MenuScreen screen)
        {

            if (_screenCache.TryGetValue(screen, out SabraUserControl cachedScreen))
            {
                return cachedScreen;
            }

            SabraUserControl newScreen = CreateScreen(screen);

            if (newScreen == null)
                return null;

            WireScreenEvents(newScreen);

            _screenCache.Add(screen, newScreen);

            return newScreen;
        }

        private SabraUserControl CreateScreen(MenuScreen screen)
        {
            switch (screen)
            {
                case MenuScreen.Main:
                    return new usDashboard();

                case MenuScreen.InventoryList:
                    return new ucInventory();

                case MenuScreen.AddPart:
                    return new ucAddPart();

                case MenuScreen.InventoryAlerts:
                    return new ucInventoryAlerts();

                case MenuScreen.CarCompatibility:
                    return new ucVehicleCompatibility();

                case MenuScreen.InventoryTransaction:
                    return new ucInventoryTransactions();

                case MenuScreen.NewInvoice:
                    return new ucNewInvoice();

                case MenuScreen.InvoicesList:
                    return new ucInvoicesList();

                case MenuScreen.Returns:
                    return new ucReturns();

                case MenuScreen.NewPurchaseOrder:
                    return new ucNewPurchaseOrder();

                case MenuScreen.PurchaseOrdersList:
                    return new ucPurchaseOrdersList();

                case MenuScreen.ReceiveGoods:
                    return new ucGoodsReceipt();

                case MenuScreen.Customers:
                    return new ucCustomers();

                case MenuScreen.CustomerStatement:
                    return new ucCustomerStatement();

                case MenuScreen.Suppliers:
                    return new ucSuppliers();

                case MenuScreen.SupplierStatement:
                    return new ucSupplierStatement();

                case MenuScreen.Treasury:
                    return new ucTreasury();

                case MenuScreen.Expenses:
                    return new ucExpenses();

                case MenuScreen.Salaries:
                    return new ucSalaries();

                case MenuScreen.Advances:
                    return new ucAdvances();

                case MenuScreen.Reports:
                    return new ucFinancialReports();

                case MenuScreen.CashFlow:
                    return new ucCashFlow();

                case MenuScreen.Employees:
                    return new ucEmployees();

                case MenuScreen.Users:
                    return new ucUsers();

                case MenuScreen.Settings:
                    return new ucSettings();

                case MenuScreen.Backup:
                    return new ucBackup();

                case MenuScreen.ActivityLog:
                    return new ucActivityLog();

                default:
                    return null;
            }
        }

        #endregion


        #region Screen Events

        private void WireScreenEvents(SabraUserControl screen)
        {
            if (screen == null)
                return;

            // ==============================
            // Inventory Alerts
            // ==============================

            if (screen is ucInventoryAlerts inventoryAlerts)
            {
                inventoryAlerts.CreatePurchaseOrderRequested -=
                    InventoryAlerts_CreatePurchaseOrderRequested;

                inventoryAlerts.CreatePurchaseOrderRequested +=
                    InventoryAlerts_CreatePurchaseOrderRequested;
            }


            // ==============================
            // Customers
            // ==============================

            if (screen is ucCustomers customers)
            {
                customers.OpenScreenWithCustomerData -=
                    Customers_OpenScreenWithCustomerData;

                customers.OpenScreenWithCustomerData +=
                    Customers_OpenScreenWithCustomerData;
            }

        }


        private void InventoryAlerts_CreatePurchaseOrderRequested(
            object sender,
            EventArgs e)
        {
            LoadScreen(MenuScreen.NewPurchaseOrder);
        }


        private void Customers_OpenScreenWithCustomerData(
            object sender,
            CustomerEventArgs e)
        {
            if (e == null)
                return;

            switch (e.Action)
            {
                case CustomerAction.Add:

                    LoadScreen(MenuScreen.Customers);

                    break;


                case CustomerAction.Statement:

                    OpenCustomerStatement(e.CustomerID);

                    break;


                case CustomerAction.Invoice:

                    OpenCustomerInvoice(e.CustomerID);

                    break;


                case CustomerAction.Payment:

                    OpenCustomerPayment(e.CustomerID);

                    break;


                case CustomerAction.Edit:

                    OpenCustomerEdit(e.CustomerID);

                    break;
            }
        }

        #endregion


        #region Customer Navigation

        private void OpenCustomerStatement(int customerID)
        {
            if (customerID <= 0)
                return;

            var screen =
                GetOrCreateScreen(MenuScreen.CustomerStatement)
                as ucCustomerStatement;

            if (screen == null)
                return;

            screen.LoadCustomer(customerID);

            ShowScreen(screen);

            UpdateNavigationState(
                MenuScreen.CustomerStatement);
        }


        private void OpenCustomerInvoice(int customerID)
        {
            if (customerID <= 0)
                return;

            /*
             * لو ucNewInvoice عندك فيها:
             *
             * LoadCustomer(customerID)
             *
             * استخدمها هنا.
             */

            var screen =
                GetOrCreateScreen(MenuScreen.NewInvoice)
                as ucNewInvoice;

            if (screen == null)
                return;

            //screen.(customerID);

            ShowScreen(screen);

            UpdateNavigationState(
                MenuScreen.NewInvoice);
        }


        private void OpenCustomerPayment(int customerID)
        {
            if (customerID <= 0)
                return;

            /*
             * هنا ضع طريقة فتح شاشة الدفعة
             * الخاصة بالعميل.
             *
             * مثال:
             *
             * var screen = new ucCustomerPayment(customerID);
             *
             * أو:
             *
             * screen.LoadCustomer(customerID);
             *
             * حسب تصميم الشاشة عندك.
             */

            MessageBox.Show(
                $"فتح دفعة للعميل رقم {customerID}",
                "دفعة العميل",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        private void OpenCustomerEdit(int customerID)
        {
            if (customerID <= 0)
                return;

            /*
             * هنا نفس الفكرة:
             *
             * شاشة تعديل العميل
             * تأخذ CustomerID.
             */

            MessageBox.Show(
                $"تعديل بيانات العميل رقم {customerID}",
                "تعديل العميل",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion


        #region Show Screen

        private void ShowScreen(SabraUserControl screen)
        {
            if (screen == null)
                return;

            if (ReferenceEquals(_currentScreen, screen))
                return;

            pnlContent.SuspendLayout();

            try
            {
                if (_currentScreen != null)
                {
                    pnlContent.Controls.Remove(_currentScreen);
                    _currentScreen.Visible = false;
                }

                if (!pnlContent.Controls.Contains(screen))
                {
                    screen.Dock = DockStyle.Fill;
                    screen.Margin = new Padding(0);

                    pnlContent.Controls.Add(screen);
                }

                screen.Visible = true;
                screen.BringToFront();

                _currentScreen = screen;
            }
            finally
            {
                pnlContent.ResumeLayout(true);
            }
        }

        #endregion


        #region Navigation UI

        private void UpdateNavigationState(MenuScreen screen)
        {
            if (ucMenue1 != null)
            {
                ucMenue1.SetActiveScreen(screen);
            }

            if (ucBottomBar1 != null)
            {
                string userName = GetLoggedInUserName();

                ucBottomBar1.UpdateBottomBarInfo(
                    screen,
                    userName);
            }
        }

        private string GetLoggedInUserName()
        {
            if (clsAppSession.CurrentUser != null)
            {
                if (!string.IsNullOrWhiteSpace(
                    clsAppSession.CurrentUser.EmployeeName))
                {
                    return clsAppSession.CurrentUser.EmployeeName;
                }

                if (!string.IsNullOrWhiteSpace(
                    clsAppSession.CurrentUser.Username))
                {
                    return clsAppSession.CurrentUser.Username;
                }
            }

            return "المستخدم";
        }

        #endregion


        #region Form Closing

        protected override void OnFormClosed(FormClosedEventArgs e)
        {


            if (ucMenue1 != null)
            {
                ucMenue1.ScreenSelected -=
                    UcMenue1_ScreenSelected;
            }

            if (ucTopBar1 != null)
            {
                ucTopBar1.InventoryAlertsClicked -=
                    UcTopBar1_InventoryAlertsClicked;

                ucTopBar1.NewInvoiceClicked -=
                    UcTopBar1_NewInvoiceClicked;

                ucTopBar1.AddNewPartClicked -=
                    UcTopBar1_AddNewPartClicked;

                ucTopBar1.UserAvatarClicked -=
                    UcTopBar1_UserAvatarClicked;
            }


            foreach (SabraUserControl screen in _screenCache.Values)
            {
                if (screen == null)
                    continue;

                if (screen is ucInventoryAlerts inventoryAlerts)
                {
                    inventoryAlerts.CreatePurchaseOrderRequested -=
                        InventoryAlerts_CreatePurchaseOrderRequested;
                }

                if (screen is ucCustomers customers)
                {
                    customers.OpenScreenWithCustomerData -=
                        Customers_OpenScreenWithCustomerData;
                }

                screen.Dispose();
            }

            _screenCache.Clear();

            _currentScreen = null;

            base.OnFormClosed(e);
        }

        #endregion
    }
}