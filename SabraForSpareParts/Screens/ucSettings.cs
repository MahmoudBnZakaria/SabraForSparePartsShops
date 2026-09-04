using System;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucSettings : SabraUserControl
    {
        // =========================================================
        // Settings Model
        // =========================================================

        private class StoreSettings
        {
            public string StoreName { get; set; }
            public string Address { get; set; }
            public string MainEmail { get; set; }
            public string CommercialRegistrationNumber { get; set; }
            public string PhoneNumber { get; set; }
            public int NumberOfDaysForDeadStock { get; set; }
        }

        // =========================================================
        // Current Settings
        // =========================================================

        private StoreSettings _settings;

        // =========================================================
        // Constructor
        // =========================================================

        public ucSettings()
        {
            InitializeComponent();
        }

        // =========================================================
        // Load
        // =========================================================

        private void ucSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        // =========================================================
        // Load Settings
        // =========================================================

        private void LoadSettings()
        {
            try
            {
                // -------------------------------------------------
                // Mock Data
                // -------------------------------------------------
                // لاحقًا البيانات دي هتتجاب من SQL Server

                _settings = new StoreSettings
                {
                    StoreName = "Sabra For Spare Parts",
                    Address = "القاهرة - مصر",
                    MainEmail = "info@sabra-spareparts.com",
                    CommercialRegistrationNumber = "123456789",
                    PhoneNumber = "01000000000",
                    NumberOfDaysForDeadStock = 90
                };

                // -------------------------------------------------
                // Fill Controls
                // -------------------------------------------------

                stbxTheNameOfStore.Text =
                    _settings.StoreName;

                stbxAddressOfStore.Text =
                    _settings.Address;

                stbxMainEmail.Text =
                    _settings.MainEmail;

                sabraTextBoxCommercialregistrationnumber.Text =
                    _settings.CommercialRegistrationNumber;

                stbxPhoneNumber.Text =
                    _settings.PhoneNumber;

                sabraNumericUpDownNumberOfDaysForDeadStock.Value =
                    _settings.NumberOfDaysForDeadStock;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل إعدادات النظام:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // Save Settings
        // =========================================================

        private void stbSaveSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            try
            {
                // -------------------------------------------------
                // Validation
                // -------------------------------------------------

                if (string.IsNullOrWhiteSpace(
                    stbxTheNameOfStore.Text))
                {
                    MessageBox.Show(
                        "من فضلك أدخل اسم المتجر.",
                        "بيانات ناقصة",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    stbxTheNameOfStore.Focus();

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    stbxAddressOfStore.Text))
                {
                    MessageBox.Show(
                        "من فضلك أدخل عنوان المتجر.",
                        "بيانات ناقصة",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    stbxAddressOfStore.Focus();

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    stbxPhoneNumber.Text))
                {
                    MessageBox.Show(
                        "من فضلك أدخل رقم الهاتف.",
                        "بيانات ناقصة",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    stbxPhoneNumber.Focus();

                    return;
                }

                // -------------------------------------------------
                // Email Validation
                // -------------------------------------------------

                string email =
                    stbxMainEmail.Text.Trim();

                if (!string.IsNullOrWhiteSpace(email) &&
                    !IsValidEmail(email))
                {
                    MessageBox.Show(
                        "البريد الإلكتروني غير صحيح.",
                        "بيانات غير صحيحة",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    stbxMainEmail.Focus();

                    return;
                }

                // -------------------------------------------------
                // Update Model
                // -------------------------------------------------

                _settings.StoreName =
                    stbxTheNameOfStore.Text.Trim();

                _settings.Address =
                    stbxAddressOfStore.Text.Trim();

                _settings.MainEmail =
                    stbxMainEmail.Text.Trim();

                _settings.CommercialRegistrationNumber =
                    sabraTextBoxCommercialregistrationnumber
                    .Text.Trim();

                _settings.PhoneNumber =
                    stbxPhoneNumber.Text.Trim();

                _settings.NumberOfDaysForDeadStock =
                    Convert.ToInt32(
                        sabraNumericUpDownNumberOfDaysForDeadStock
                        .Value);

                // -------------------------------------------------
                // Save To Database
                // -------------------------------------------------
                //
                // هنا حاليًا Mock.
                //
                // لاحقًا:
                //
                // SettingsService.Update(_settings);
                //
                // -------------------------------------------------

                MessageBox.Show(
                    "تم حفظ إعدادات المتجر بنجاح.",
                    "تم الحفظ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء حفظ الإعدادات:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // Email Validation
        // =========================================================

        private bool IsValidEmail(string email)
        {
            try
            {
                var address =
                    new System.Net.Mail.MailAddress(email);

                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // =========================================================
        // Store Name
        // =========================================================

        private void stbxTheNameOfStore_Load(
            object sender,
            EventArgs e)
        {
        }

        // =========================================================
        // Store Address
        // =========================================================

        private void stbxAddressOfStore_Load(
            object sender,
            EventArgs e)
        {
        }

        // =========================================================
        // Main Email
        // =========================================================

        private void stbxMainEmail_Load(
            object sender,
            EventArgs e)
        {
        }

        // =========================================================
        // Commercial Registration Number
        // =========================================================

        private void sabraTextBoxCommercialregistrationnumber_Load(
            object sender,
            EventArgs e)
        {
        }

        // =========================================================
        // Phone Number
        // =========================================================

        private void stbxPhoneNumber_Load(
            object sender,
            EventArgs e)
        {
        }

        // =========================================================
        // Dead Stock Days
        // =========================================================

        private void sabraNumericUpDownNumberOfDaysForDeadStock_ValueChanged(
            object sender,
            EventArgs e)
        {
            // يمكن هنا تحديث Preview أو أي Label
            // لو أضفت واحد لاحقًا.

            int days =
                Convert.ToInt32(
                    sabraNumericUpDownNumberOfDaysForDeadStock.Value);

            if (days <= 0)
                return;
        }

        // =========================================================
        // Panel Paint
        // =========================================================

        private void sabraPanel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        // =========================================================
        // Label Click
        // =========================================================

        private void sabraLabel1_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}