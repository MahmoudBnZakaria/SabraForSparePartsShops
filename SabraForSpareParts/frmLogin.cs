using Sabra.LogicLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class frmLogin : Form
    {
        #region Animation Variables

        private System.Windows.Forms.Timer _titleTimer;
        private int _animationIndex;
        private int _animationPhase;
        private const int PHASE_SABRA = 0;
        private const int PHASE_SPARE = 1;
        private const int PHASE_CAR_PARTS = 2;
        private const int PHASE_ENGLISH = 3;
        private const int PHASE_VERSION = 4;
        private const int PHASE_PAUSE = 5;
        private const string ArabicSabra = "صبـــــــــــــــــــــره";
        private const string ArabicSpare = "لقطع";
        private const string ArabicCarParts = "غيار السيـــــــــــارات";
        private const string EnglishTitle = "Sabra For Car Spare Parts";
        private const string AppVersion = "V.0";

        // Error labels animation
        private System.Windows.Forms.Timer _errorAnimTimer;
        private Label _currentErrorLabel;
        private int _errorStartTop;
        private int _errorTargetTop;
        private const int ERROR_ANIMATION_STEPS = 10;
        private int _errorStepIndex;
        private bool _isErrorAnimating;


        private Dictionary<Label, int> _originalLabelTops;

        #endregion


        public frmLogin()
        {
            InitializeComponent();
            stbxUserName.Text = "m.ibrahim";
            stbxPassowrd.Text = "admin";
            

            // تخزين المواضع الأصلية لكل Label خاص بالأخطاء
            _originalLabelTops = new Dictionary<Label, int>
                    {
                        { slblUserIsNotExist, slblUserIsNotExist.Top },
                        { slblWrongPassword, slblWrongPassword.Top },
                        { slblGeneralError, slblGeneralError.Top }
                    };

            InitializeTitleAnimation();
            InitializeErrorAnimation();

            Shown += frmLogin_Shown;
            FormClosing += frmLogin_FormClosing;
            stbxUserName.TextChanged += (s, e) => HideAllErrors();
            stbxPassowrd.TextChanged += (s, e) => HideAllErrors();
        }

        #region Form Events

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            StartTitleAnimation();
            stbxUserName.Focus();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTitleAnimation();
            StopErrorAnimation();
        }

        #endregion

        #region Title Animation (unchanged, but kept for completeness)

        private void InitializeTitleAnimation()
        {
            _titleTimer = new System.Windows.Forms.Timer { Interval = 75 };
            _titleTimer.Tick += TitleTimer_Tick;
        }

        private void StartTitleAnimation()
        {
            _animationPhase = PHASE_SABRA;
            _animationIndex = 0;
            ClearTitles();
            _titleTimer.Interval = 75;
            _titleTimer.Start();
        }

        private void StopTitleAnimation()
        {
            _titleTimer?.Stop();
            _titleTimer?.Dispose();
            _titleTimer = null;
        }

        private void ClearTitles()
        {
            slblTitleSabra.Text = "";
            slblTitleForSpare.Text = "";
            slblTitleCarParats.Text = "";
            slblEnglishTitle.Text = "";
            slblAppVersion.Text = "";
        }

        private void TitleTimer_Tick(object sender, EventArgs e)
        {
            switch (_animationPhase)
            {
                case PHASE_SABRA: AnimateSabra(); break;
                case PHASE_SPARE: AnimateSpare(); break;
                case PHASE_CAR_PARTS: AnimateCarParts(); break;
                case PHASE_ENGLISH: AnimateEnglish(); break;
                case PHASE_VERSION: AnimateVersion(); break;
                case PHASE_PAUSE: RestartAnimation(); break;
            }
        }

        private void AnimateSabra()
        {
            if (_animationIndex < ArabicSabra.Length)
            {
                slblTitleSabra.Text = ArabicSabra.Substring(0, _animationIndex + 1);
                _animationIndex++;
                return;
            }
            MoveToNextPhase(PHASE_SPARE);
        }

        private void AnimateSpare()
        {
            if (_animationIndex < ArabicSpare.Length)
            {
                slblTitleForSpare.Text = ArabicSpare.Substring(0, _animationIndex + 1);
                _animationIndex++;
                return;
            }
            MoveToNextPhase(PHASE_CAR_PARTS);
        }

        private void AnimateCarParts()
        {
            if (_animationIndex < ArabicCarParts.Length)
            {
                slblTitleCarParats.Text = ArabicCarParts.Substring(0, _animationIndex + 1);
                _animationIndex++;
                return;
            }
            MoveToNextPhase(PHASE_ENGLISH);
            _titleTimer.Interval = 65;
        }

        private void AnimateEnglish()
        {
            if (_animationIndex < EnglishTitle.Length)
            {
                slblEnglishTitle.Text = EnglishTitle.Substring(0, _animationIndex + 1);
                _animationIndex++;
                return;
            }
            MoveToNextPhase(PHASE_VERSION);
            _titleTimer.Interval = 90;
        }

        private void AnimateVersion()
        {
            if (_animationIndex < AppVersion.Length)
            {
                slblAppVersion.Text = AppVersion.Substring(0, _animationIndex + 1);
                _animationIndex++;
                return;
            }
            _animationPhase = PHASE_PAUSE;
            _titleTimer.Interval = 3000; // Stay for 3 seconds
        }

        private void MoveToNextPhase(int nextPhase)
        {
            _animationPhase = nextPhase;
            _animationIndex = 0;
            _titleTimer.Interval = 75;
        }

        private void RestartAnimation()
        {
            ClearTitles();
            _animationPhase = PHASE_SABRA;
            _animationIndex = 0;
            _titleTimer.Interval = 75;
        }

        #endregion

        #region Error Animation Logic

        private void InitializeErrorAnimation()
        {
            _errorAnimTimer = new System.Windows.Forms.Timer { Interval = 20 };
            _errorAnimTimer.Tick += ErrorAnimTimer_Tick;
            // بداية إخفاء جميع الأخطاء
            HideAllErrors();
        }

        private void StopErrorAnimation()
        {
            _errorAnimTimer?.Stop();
            _errorAnimTimer?.Dispose();
            _errorAnimTimer = null;
        }

        /// <summary>
        /// إظهار خطأ مع تأثير انزلاق للأعلى، ثم إخفاؤه تلقائياً بعد 3 ثوانٍ.
        /// </summary>

        private void ShowError(Label errorLabel, string message)
        {
            // إخفاء أي خطأ آخر
            HideAllErrors();

            if (errorLabel == null || string.IsNullOrWhiteSpace(message))
                return;

            // التأكد من وجود الموضع الأصلي في القاموس
            if (!_originalLabelTops.ContainsKey(errorLabel))
                return;

            errorLabel.Text = message;
            errorLabel.Visible = true;

            // استخدم الموضع الأصلي الثابت (وليس الموضع الحالي المتغير)
            int originalTop = _originalLabelTops[errorLabel];
            _errorTargetTop = originalTop;               // الهدف هو المكان الأصلي
            _errorStartTop = originalTop + 20;           // نبدأ من تحت بـ 20 بكسل
            errorLabel.Top = _errorStartTop;

            _currentErrorLabel = errorLabel;
            _errorStepIndex = 0;
            _isErrorAnimating = true;

            _errorAnimTimer.Interval = 20;
            _errorAnimTimer.Start();

            // جدولة الإخفاء التلقائي بعد 3 ثوانٍ
            System.Windows.Forms.Timer autoHideTimer = new System.Windows.Forms.Timer { Interval = 3000 };
            autoHideTimer.Tick += (s, e) =>
            {
                autoHideTimer.Stop();
                autoHideTimer.Dispose();
                HideAllErrors();
            };
            autoHideTimer.Start();
        }


        private void ErrorAnimTimer_Tick(object sender, EventArgs e)
        {
            if (!_isErrorAnimating || _currentErrorLabel == null)
            {
                _errorAnimTimer.Stop();
                return;
            }

            _errorStepIndex++;
            float progress = (float)_errorStepIndex / ERROR_ANIMATION_STEPS;
            if (progress >= 1f)
            {
                progress = 1f;
                _isErrorAnimating = false;
                _errorAnimTimer.Stop();
            }

            // حساب الموضع الجديد (تزاید سلس)
            int currentTop = _errorStartTop - (int)((_errorStartTop - _errorTargetTop) * progress);
            _currentErrorLabel.Top = currentTop;
        }

        private void HideAllErrors()
        {
            _errorAnimTimer?.Stop();
            _isErrorAnimating = false;
            _currentErrorLabel = null;

            slblUserIsNotExist.Visible = false;
            slblWrongPassword.Visible = false;
            slblGeneralError.Visible = false;
        }

        #endregion

        #region Login Logic

        private void stbnLogin_Click(object sender, EventArgs e)
        {
            string username = stbxUserName.Text.Trim();
            string password = stbxPassowrd.Text;

            // تحقق أولي
            if (string.IsNullOrWhiteSpace(username))
            {
                ShowError(slblGeneralError, "يرجى إدخال اسم المستخدم.");
                stbxUserName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowError(slblGeneralError, "يرجى إدخال كلمة المرور.");
                stbxPassowrd.Focus();
                return;
            }

            // محاولة تسجيل الدخول
            clsAuthBusiness authBusiness = new clsAuthBusiness();
            var CurrentUser = authBusiness.Login(username, password);

            clsEmployeeBusiness employeeBusiness = new clsEmployeeBusiness();
            if (CurrentUser.Success)
            {
                var CurrentEmployee = employeeBusiness.GetByID(CurrentUser.Data.EmployeeID);
                this.Hide();
                frmMain main = new frmMain();
                main.ShowDialog();
                this.Close();
                clsAppSession.SetSession(CurrentUser.Data, CurrentEmployee.Data); // Assuming User has an Employee property

            }
            else
            {
                // فشل – عرض الخطأ المناسب
                string errorMsg = CurrentUser.Message;
                if (errorMsg == "اسم المستخدم غير موجود")
                {
                    ShowError(slblUserIsNotExist, errorMsg);
                    stbxUserName.Focus();
                }
                else if (errorMsg == "كلمة المرور غير صحيحة.")
                {
                    ShowError(slblWrongPassword, errorMsg);
                    stbxPassowrd.Focus();
                }
                else
                {
                    ShowError(slblGeneralError, errorMsg);
                    stbxUserName.Focus();
                }
            }
        }

        #endregion

        #region Cancel / Close

        private void sbtnCancelLogin_Click(object sender, EventArgs e)
        {
            Close();
            clsAppSession.ClearSession(); // Clear session on logout

        }

        #endregion

        protected override bool ProcessCmdKey(
            ref Message msg,
            Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                stbnLogin.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                sbtnCancelLogin.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        #region Password Visibility Toggle

        private void cbxPasswordVisibility_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPasswordVisibility.Checked)
            {
                cbxPasswordVisibility.Text = "إخفاء كلمة المرور";
                stbxPassowrd.PasswordChar = false;
            }
            else
            {
                cbxPasswordVisibility.Text = "إظهار كلمة المرور";
                stbxPassowrd.PasswordChar = true;
            }
        }

        #endregion
    }
}