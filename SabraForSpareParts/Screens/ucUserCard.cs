using FontAwesome.Sharp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucUserCard : SabraUserControl
    {
        public ucUserCard()
        {
            InitializeComponent();

            ConfigureCard();
            WireEvents();

            UpdateUI();
        }

        #region Properties

        private string _userName = "أحمد محمد";

        [Category("User")]
        [Description("اسم المستخدم")]
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                UpdateUI();
            }
        }

        private string _userRole = "مدير";

        [Category("User")]
        [Description("وظيفة المستخدم")]
        public string UserRole
        {
            get => _userRole;
            set
            {
                _userRole = value;
                UpdateUI();
            }
        }

        private bool _isActive = true;

        [Category("User")]
        [Description("حالة المستخدم")]
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                UpdateUI();
            }
        }

        private bool _isFemale = false;

        [Category("User")]
        [Description("هل المستخدم أنثى؟")]
        public bool IsFemale
        {
            get => _isFemale;
            set
            {
                _isFemale = value;
                UpdateAvatar();
            }
        }

        private string _phone = "01012345678";

        [Category("User")]
        [Description("رقم الهاتف")]
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                UpdateUI();
            }
        }

        private string _username = "ahmed";

        [Category("User")]
        [Description("اسم الدخول")]
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                UpdateUI();
            }
        }

        private DateTime _createdDate = new DateTime(2025, 1, 1);

        [Category("User")]
        [Description("تاريخ إنشاء الحساب")]
        public DateTime CreatedDate
        {
            get => _createdDate;
            set
            {
                _createdDate = value;
                UpdateUI();
            }
        }

        #endregion

        #region Appearance

        private Color _activeColor = Color.FromArgb(22, 163, 74);

        [Category("Appearance")]
        public Color ActiveColor
        {
            get => _activeColor;
            set
            {
                _activeColor = value;
                UpdateStatusColor();
            }
        }

        private Color _inactiveColor = Color.FromArgb(100, 116, 139);

        [Category("Appearance")]
        public Color InactiveColor
        {
            get => _inactiveColor;
            set
            {
                _inactiveColor = value;
                UpdateStatusColor();
            }
        }

        private Color _cardHoverColor =
            Color.FromArgb(248, 250, 252);

        [Category("Appearance")]
        public Color CardHoverColor
        {
            get => _cardHoverColor;
            set => _cardHoverColor = value;
        }

        private Color _cardNormalColor = Color.White;

        [Category("Appearance")]
        public Color CardNormalColor
        {
            get => _cardNormalColor;
            set
            {
                _cardNormalColor = value;
                BackColor = value;
                fwPbxUserAvatar.BackColor = value;
            }
        }

        #endregion

        #region Setup

        private void ConfigureCard()
        {
            BackColor = Color.White;
            Cursor = Cursors.Hand;

            DoubleBuffered = true;

            if (fwPbxUserAvatar != null)
            {
                fwPbxUserAvatar.BackColor = Color.White;
            }

            UpdateUI();
        }

        private void WireEvents()
        {
            MouseEnter += Card_MouseEnter;
            MouseLeave += Card_MouseLeave;

            fwPbxUserAvatar.MouseEnter += Child_MouseEnter;
            fwPbxUserAvatar.MouseLeave += Child_MouseLeave;

            fwPbxUserAvatar.MouseEnter += Child_MouseEnter;
            fwPbxUserAvatar.MouseLeave += Child_MouseLeave;

            slblName.MouseEnter += Child_MouseEnter;
            slblName.MouseLeave += Child_MouseLeave;

            slblRole.MouseEnter += Child_MouseEnter;
            slblRole.MouseLeave += Child_MouseLeave;

            //lblus.MouseEnter += Child_MouseEnter;
            //lblUserRole.MouseLeave += Child_MouseLeave;

            lblIsActive.MouseEnter += Child_MouseEnter;
            lblIsActive.MouseLeave += Child_MouseLeave;

            fwPbxUserAvatar.Click += Card_Click;
            slblName.Click += Card_Click;
            slblRole.Click += Card_Click;
            //lblUserRole.Click += Card_Click;
            lblIsActive.Click += Card_Click;
            fwPbxUserAvatar.Click += Card_Click;
        }

        #endregion

        #region Update UI

        private void UpdateUI()
        {
            if (IsDisposed)
                return;

            if (slblName != null)
                slblName.Text = UserName;

            if (slblRole != null)
                slblRole.Text = UserRole;

            lblUsername.Text = $"اسم المستخدم: {Username}";

            if (lblIsActive != null)
            {
                lblIsActive.Text = IsActive
                    ? "نشط"
                    : "غير نشط";
            }

            UpdateAvatar();
            UpdateStatusColor();
        }

        private void UpdateAvatar()
        {
            if (fwPbxUserAvatar == null)
                return;

            fwPbxUserAvatar.IconChar = IsFemale
                ? IconChar.User
                : IconChar.UserTie;

            fwPbxUserAvatar.IconColor = IsFemale
                ? Color.FromArgb(219, 39, 119)
                : Color.FromArgb(37, 99, 235);
        }

        private void UpdateStatusColor()
        {
            if (lblIsActive == null)
                return;

            lblIsActive.ForeColor = IsActive
                ? ActiveColor
                : InactiveColor;
        }

        #endregion

        #region Hover

        private void Card_MouseEnter(object sender, EventArgs e)
        {
            SetHoverState(true);
        }

        private void Card_MouseLeave(object sender, EventArgs e)
        {
            CheckMousePosition();
        }

        private void Child_MouseEnter(object sender, EventArgs e)
        {
            SetHoverState(true);
        }

        private void Child_MouseLeave(object sender, EventArgs e)
        {
            CheckMousePosition();
        }

        private void CheckMousePosition()
        {
            Point position = PointToClient(Cursor.Position);

            if (!ClientRectangle.Contains(position))
            {
                SetHoverState(false);
            }
        }

        private void SetHoverState(bool hover)
        {
            Color color = hover
                ? CardHoverColor
                : CardNormalColor;

            BackColor = color;

            if (fwPbxUserAvatar != null)
                fwPbxUserAvatar.BackColor = color;

            if (slblName != null)
                slblName.BackColor = color;

            if (slblRole != null)
                slblRole.BackColor = color;

            //if (lblUserRole != null)
            //    lblUserRole.BackColor = color;

            if (lblIsActive != null)
                lblIsActive.BackColor = color;

            if (fwPbxUserAvatar != null)
                fwPbxUserAvatar.BackColor = color;
        }

        #endregion

        #region Click

        public event EventHandler CardClicked;

        private void Card_Click(object sender, EventArgs e)
        {
            CardClicked?.Invoke(this, e);
        }

        #endregion

        #region Buttons

        public event EventHandler EditClicked;

        public event EventHandler ChangePasswordClicked;

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, e);
        }

        private void sbtnPassword_Click(object sender, EventArgs e)
        {
            ChangePasswordClicked?.Invoke(this, e);
        }

        #endregion

        #region Existing Events

        private void lblUserRole_Click(object sender, EventArgs e)
        {
            Card_Click(sender, e);
        }

        private void fwPbxUserAvatar_Click(object sender, EventArgs e)
        {
            Card_Click(sender, e);
        }

        private void slblName_Click(object sender, EventArgs e)
        {
            Card_Click(sender, e);
        }

        private void slblRole_Click(object sender, EventArgs e)
        {
            Card_Click(sender, e);
        }

        private void lblIsActive_Click(object sender, EventArgs e)
        {
            Card_Click(sender, e);
        }

        #endregion

        #region Helpers

        public void SetData(
            string name,
            string role,
            string username,
            string phone,
            bool isActive,
            bool isFemale)
        {
            UserName = name;
            UserRole = role;
            Username = username;
            Phone = phone;
            IsActive = isActive;
            IsFemale = isFemale;
        }

        public override string ToString()
        {
            return $"{UserName} - {UserRole}";
        }

        #endregion
    }
}