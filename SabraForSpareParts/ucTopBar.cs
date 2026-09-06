using System;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class ucTopBar : SabraUserControl
    {
        public string UserName { get; private set; } = "User";
        public string ProgramName { get; private set; } = "صبره لقطع غيار السيارات";


        public event EventHandler InventoryAlertsClicked;
        public event EventHandler NewInvoiceClicked;
        public event EventHandler AddNewPartClicked;
        public event EventHandler UserAvatarClicked;

        public ucTopBar()
        {
            InitializeComponent();
            ConfigureTopBar();
        }


        private void ConfigureTopBar()
        {
            ConfigureControlsBehavior();
            ConfigureTabOrder();
            UpdateUserInterface();
        }


        // Set Cursor to Hand for interactive controls and enable TabStop for them
        private void ConfigureControlsBehavior()
        {
            var interactiveControls = new Control[]
            {
                btnInverntoryAlerts,
                btnNewInvoice,
                AddNewPart,
                fwPbxUserAvatar
            };

            foreach (var ctrl in interactiveControls)
            {
                if (ctrl != null)
                {
                    ctrl.Cursor = Cursors.Hand;
                    ctrl.TabStop = true;
                }
            }
        }

        // To Ease Navigation: Set TabIndex for interactive controls and disable TabStop for labels
        private void ConfigureTabOrder()
        {
            if (lblProgramName != null) lblProgramName.TabStop = false;
            if (slblUsername != null) slblUsername.TabStop = false;

            if (btnInverntoryAlerts != null) btnInverntoryAlerts.TabIndex = 2;
            if (btnNewInvoice != null) btnNewInvoice.TabIndex = 3;
            if (AddNewPart != null) AddNewPart.TabIndex = 4;
            if (fwPbxUserAvatar != null) fwPbxUserAvatar.TabIndex = 5;
        }



        // Method to set user settings and update the UI accordingly
        public void SetUserSettings(string userName, string programName)
        {
            UserName = string.IsNullOrWhiteSpace(userName) ? "User" : userName.Trim();
            ProgramName = string.IsNullOrWhiteSpace(programName) ? "صبره لقطع غيار السيارات" : programName.Trim();

            UpdateUserInterface();
        }

        private void UpdateUserInterface()
        {

            if (lblProgramName != null)
                lblProgramName.Text = ProgramName;

            if (slblUsername != null)
                slblUsername.Text = UserName;
        }

        #region Event Handlers
        private void btnInverntoryAlerts_Click(object sender, EventArgs e)
            => InventoryAlertsClicked?.Invoke(this, EventArgs.Empty);

        private void btnNewInvoice_Click(object sender, EventArgs e)
            => NewInvoiceClicked?.Invoke(this, EventArgs.Empty);

        private void AddNewPart_Click(object sender, EventArgs e)
            => AddNewPartClicked?.Invoke(this, EventArgs.Empty);

        private void fwPbxUserAvatar_Click(object sender, EventArgs e)
            => UserAvatarClicked?.Invoke(this, EventArgs.Empty);
        #endregion

        private void slblUsername_Click(object sender, EventArgs e)
        {

        }

        private void ucTopBar_Load(object sender, EventArgs e)
        {

        }
    }
}