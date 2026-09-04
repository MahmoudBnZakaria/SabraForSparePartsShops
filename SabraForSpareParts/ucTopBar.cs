using System;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class ucTopBar : SabraUserControl
    {
        // =========================================================
        // Session
        // =========================================================

        private int _userId;
        private string _userName = "User";
        private string _userRole = "User";

        private string _customerName = string.Empty;
        private decimal _creditLimit;

        // =========================================================
        // Events
        // =========================================================

        public event EventHandler SearchRequested;

        public event EventHandler InventoryAlertsClicked;

        public event EventHandler NewInvoiceClicked;

        public event EventHandler AddNewPartClicked;

        public event EventHandler UserAvatarClicked;

        // =========================================================
        // Constructor
        // =========================================================

        public ucTopBar()
        {
            InitializeComponent();

            ConfigureTopBar();
        }

        // =========================================================
        // Top Bar Configuration
        // =========================================================

        private void ConfigureTopBar()
        {
            ConfigureTabOrder();

            ConfigureSearch();

            ConfigureButtons();

            ConfigureUserAvatar();

            UpdateUserInterface();
        }

        // =========================================================
        // Tab Order
        // =========================================================

        private void ConfigureTabOrder()
        {
            if (sbtnSearchForCustomerInvoicePart != null)
            {
                sbtnSearchForCustomerInvoicePart.TabStop = true;
                sbtnSearchForCustomerInvoicePart.TabIndex = 0;
            }

            if (sbtnSearch != null)
            {
                sbtnSearch.TabStop = true;
                sbtnSearch.TabIndex = 1;
            }

            if (btnInverntoryAlerts != null)
            {
                btnInverntoryAlerts.TabStop = true;
                btnInverntoryAlerts.TabIndex = 2;
            }

            if (btnNewInvoice != null)
            {
                btnNewInvoice.TabStop = true;
                btnNewInvoice.TabIndex = 3;
            }

            if (AddNewPart != null)
            {
                AddNewPart.TabStop = true;
                AddNewPart.TabIndex = 4;
            }

            if (fwPbxUserAvatar != null)
            {
                fwPbxUserAvatar.TabStop = true;
                fwPbxUserAvatar.TabIndex = 5;
            }

            // Labels are not interactive.
            if (lblProgramName != null)
                lblProgramName.TabStop = false;

            if (slblCustomerNameAndCreditLimit != null)
                slblCustomerNameAndCreditLimit.TabStop = false;
        }

        // =========================================================
        // Search Configuration
        // =========================================================

        private void ConfigureSearch()
        {
            if (sbtnSearchForCustomerInvoicePart == null)
                return;

            sbtnSearchForCustomerInvoicePart.TabStop = true;

            sbtnSearchForCustomerInvoicePart.KeyDown -=
                sbtnSearchForCustomerInvoicePart_KeyDown;

            sbtnSearchForCustomerInvoicePart.KeyDown +=
                sbtnSearchForCustomerInvoicePart_KeyDown;
        }

        // =========================================================
        // Buttons Configuration
        // =========================================================

        private void ConfigureButtons()
        {
            if (sbtnSearch != null)
            {
                sbtnSearch.TabStop = true;
                sbtnSearch.Cursor = Cursors.Hand;
            }

            if (btnInverntoryAlerts != null)
            {
                btnInverntoryAlerts.TabStop = true;
                btnInverntoryAlerts.Cursor = Cursors.Hand;
            }

            if (btnNewInvoice != null)
            {
                btnNewInvoice.TabStop = true;
                btnNewInvoice.Cursor = Cursors.Hand;
            }

            if (AddNewPart != null)
            {
                AddNewPart.TabStop = true;
                AddNewPart.Cursor = Cursors.Hand;
            }
        }

        // =========================================================
        // User Avatar
        // =========================================================

        private void ConfigureUserAvatar()
        {
            if (fwPbxUserAvatar == null)
                return;

            fwPbxUserAvatar.TabStop = true;

            fwPbxUserAvatar.Cursor = Cursors.Hand;
        }

        // =========================================================
        // Keyboard Shortcuts
        // =========================================================

        protected override bool ProcessCmdKey(
            ref Message msg,
            Keys keyData)
        {
            // Ctrl + F
            if (keyData == (Keys.Control | Keys.F))
            {
                FocusSearch();

                return true;
            }

            return base.ProcessCmdKey(
                ref msg,
                keyData);
        }

        // =========================================================
        // Search - Enter
        // =========================================================

        private void sbtnSearchForCustomerInvoicePart_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            PerformSearch();

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        // =========================================================
        // Search - Button
        // =========================================================

        private void sbtnSearch_Click(
            object sender,
            EventArgs e)
        {
            PerformSearch();
        }

        // =========================================================
        // Perform Search
        // =========================================================

        private void PerformSearch()
        {
            string searchText = SearchText;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                FocusSearch();
                return;
            }

            SearchRequested?.Invoke(
                this,
                EventArgs.Empty);
        }

        // =========================================================
        // Search Text
        // =========================================================

        public string SearchText
        {
            get
            {
                if (sbtnSearchForCustomerInvoicePart == null)
                    return string.Empty;

                return sbtnSearchForCustomerInvoicePart.Text?.Trim()
                       ?? string.Empty;
            }

            set
            {
                if (sbtnSearchForCustomerInvoicePart == null)
                    return;

                sbtnSearchForCustomerInvoicePart.Text =
                    value ?? string.Empty;
            }
        }

        // =========================================================
        // Focus Search
        // =========================================================

        public void FocusSearch()
        {
            if (sbtnSearchForCustomerInvoicePart == null)
                return;

            sbtnSearchForCustomerInvoicePart.Focus();

            try
            {
                sbtnSearchForCustomerInvoicePart.SelectAll();
            }
            catch
            {
                // Custom control may not support SelectAll.
            }
        }

        // =========================================================
        // Clear Search
        // =========================================================

        public void ClearSearch()
        {
            if (sbtnSearchForCustomerInvoicePart == null)
                return;

            sbtnSearchForCustomerInvoicePart.Text =
                string.Empty;

            FocusSearch();
        }

        // =========================================================
        // User Settings
        // =========================================================

        public void SetUserSettings(
            int userId,
            string userName,
            string userRole,
            string customerName = "",
            decimal creditLimit = 0)
        {
            _userId = userId;

            _userName = string.IsNullOrWhiteSpace(userName)
                ? "User"
                : userName.Trim();

            _userRole = string.IsNullOrWhiteSpace(userRole)
                ? "User"
                : userRole.Trim();

            _customerName =
                customerName?.Trim()
                ?? string.Empty;

            _creditLimit = creditLimit;

            UpdateUserInterface();
        }

        // =========================================================
        // Update UI
        // =========================================================

        private void UpdateUserInterface()
        {
            // Program Name
            if (lblProgramName != null)
            {
                lblProgramName.Text =
                    "صبره لقطع غيار السيارات";
            }

            // Customer
            if (slblCustomerNameAndCreditLimit != null)
            {
                if (!string.IsNullOrWhiteSpace(_customerName))
                {
                    slblCustomerNameAndCreditLimit.Text =
                        $"{_customerName}  |  حد الائتمان: {_creditLimit:N2} ج";
                }
                else
                {
                    slblCustomerNameAndCreditLimit.Text =
                        string.Empty;
                }
            }

            // User Avatar
            if (fwPbxUserAvatar != null)
            {
                fwPbxUserAvatar.Cursor =
                    Cursors.Hand;
            }
        }

        // =========================================================
        // Session Properties
        // =========================================================

        public int UserId
        {
            get { return _userId; }
        }

        public string UserName
        {
            get { return _userName; }
        }

        public string UserRole
        {
            get { return _userRole; }
        }

        public string CustomerName
        {
            get { return _customerName; }
        }

        public decimal CreditLimit
        {
            get { return _creditLimit; }
        }

        // =========================================================
        // Inventory Alerts
        // =========================================================

        private void btnInverntoryAlerts_Click(
            object sender,
            EventArgs e)
        {
            InventoryAlertsClicked?.Invoke(
                this,
                EventArgs.Empty);
        }

        // =========================================================
        // New Invoice
        // =========================================================

        private void btnNewInvoice_Click(
            object sender,
            EventArgs e)
        {
            NewInvoiceClicked?.Invoke(
                this,
                EventArgs.Empty);
        }

        // =========================================================
        // Add New Part
        // =========================================================

        private void AddNewPart_Click(
            object sender,
            EventArgs e)
        {
            AddNewPartClicked?.Invoke(
                this,
                EventArgs.Empty);
        }

        // =========================================================
        // User Avatar
        // =========================================================

        private void fwPbxUserAvatar_Click(
            object sender,
            EventArgs e)
        {
            UserAvatarClicked?.Invoke(
                this,
                EventArgs.Empty);
        }

        // =========================================================
        // Program Name
        // =========================================================

        private void lblProgramName_Click(
            object sender,
            EventArgs e)
        {
        }

        // =========================================================
        // Customer Label
        // =========================================================

        private void slblCustomerNameAndCreditLimit_Click(
            object sender,
            EventArgs e)
        {
            UserAvatarClicked?.Invoke(
                this,
                EventArgs.Empty);
        }

        // =========================================================
        // Search Load
        // =========================================================

        private void sbtnSearchForCustomerInvoicePart_Load(
            object sender,
            EventArgs e)
        {
        }

        // =========================================================
        // Search KeyPress
        // =========================================================

        private void sbtnSearchForCustomerInvoicePart_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        // =========================================================
        // User Name
        // =========================================================

        private void lblCurrentUserName(
            object sender,
            EventArgs e)
        {
            UserAvatarClicked?.Invoke(
                this,
                EventArgs.Empty);
        }
    }
}