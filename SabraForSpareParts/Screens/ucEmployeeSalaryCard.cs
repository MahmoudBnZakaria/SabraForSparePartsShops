using System;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucEmployeeSalaryCard : SabraUserControl
    {
        #region Fields

        private string _employeeName;
        private string _employeeRole;

        private decimal _basicSalary;
        private decimal _advances;
        private decimal _netSalary;

        private bool _isPaid;

        #endregion

        #region Constructor

        public ucEmployeeSalaryCard()
        {
            InitializeComponent();
        }

        public ucEmployeeSalaryCard(
            string employeeName,
            string employeeRole,
            decimal basicSalary,
            decimal advances,
            bool isPaid = false)
        {
            InitializeComponent();

            _employeeName = employeeName;
            _employeeRole = employeeRole;

            _basicSalary = basicSalary;
            _advances = advances;

            CalculateNetSalary();

            _isPaid = isPaid;

            UpdateCard();
        }

        #endregion

        #region Properties

        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                _employeeName = value;
                UpdateEmployeeName();
            }
        }

        public string EmployeeRole
        {
            get => _employeeRole;
            set
            {
                _employeeRole = value;
                UpdateEmployeeName();
            }
        }

        public decimal BasicSalary
        {
            get => _basicSalary;
            set
            {
                _basicSalary = value;
                CalculateNetSalary();
                UpdateSalary();
            }
        }

        public decimal Advances
        {
            get => _advances;
            set
            {
                _advances = value;
                CalculateNetSalary();
                UpdateSalary();
            }
        }

        public decimal NetSalary
        {
            get => _netSalary;
        }

        public bool IsPaid
        {
            get => _isPaid;
            set
            {
                _isPaid = value;
                UpdatePaymentStatus();
            }
        }

        #endregion

        #region Initialization

        private void CalculateNetSalary()
        {
            _netSalary = _basicSalary - _advances;

            if (_netSalary < 0)
                _netSalary = 0;
        }

        private void UpdateCard()
        {
            UpdateEmployeeName();
            UpdateSalary();
            UpdatePaymentStatus();
        }

        #endregion

        #region UI Update

        private void UpdateEmployeeName()
        {
            if (string.IsNullOrWhiteSpace(_employeeName))
                return;

            if (string.IsNullOrWhiteSpace(_employeeRole))
                lblNameOfEmplyeeAndRole.Text = _employeeName;
            else
                lblNameOfEmplyeeAndRole.Text =
                    $"{_employeeName} — {_employeeRole}";
        }

        private void UpdateSalary()
        {
            lblBasicSalary.Text =
                $"{_basicSalary:N0} ج";

            lblAdvances.Text =
                $"{_advances:N0} ج";

            lblNetSalary.Text =
                $"{_netSalary:N0} ج";
        }

        private void UpdatePaymentStatus()
        {
            sabraLabel7.Text = _isPaid
                ? "تم الصرف"
                : "صرف";
        }

        #endregion

        #region Methods

        public void SetEmployee(
            string employeeName,
            string employeeRole,
            decimal basicSalary,
            decimal advances,
            bool isPaid = false)
        {
            _employeeName = employeeName;
            _employeeRole = employeeRole;

            _basicSalary = basicSalary;
            _advances = advances;

            _isPaid = isPaid;

            CalculateNetSalary();
            UpdateCard();
        }

        public void MarkAsPaid()
        {
            _isPaid = true;
            UpdatePaymentStatus();
        }

        public void ResetPayment()
        {
            _isPaid = false;
            UpdatePaymentStatus();
        }

        #endregion

        #region Events

        private void sbtnPay_Click(
            object sender,
            EventArgs e)
        {
            if (_isPaid)
                return;

            DialogResult result = MessageBox.Show(
                $"هل تريد صرف راتب {_employeeName}؟\n\n" +
                $"الصافي: {_netSalary:N0} ج",
                "صرف الراتب",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            MarkAsPaid();

            MessageBox.Show(
                "تم صرف الراتب بنجاح",
                "صرف الراتب",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion
    }
}