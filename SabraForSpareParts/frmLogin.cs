using System;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public partial class frmLogin : Form
    {
        #region Animation

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

        #endregion


        public frmLogin()
        {
            InitializeComponent();

            InitializeTitleAnimation();

            Shown += frmLogin_Shown;
            FormClosing += frmLogin_FormClosing;
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
        }

        #endregion


        #region Animation Initialization

        private void InitializeTitleAnimation()
        {
            _titleTimer = new System.Windows.Forms.Timer();

            _titleTimer.Interval = 75;
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
            if (_titleTimer != null)
            {
                _titleTimer.Stop();
                _titleTimer.Dispose();
                _titleTimer = null;
            }
        }


        private void ClearTitles()
        {
            slblTitleSabra.Text = "";
            slblTitleForSpare.Text = "";
            slblTitleCarParats.Text = "";
            slblEnglishTitle.Text = "";
            slblAppVersion.Text = "";
        }

        #endregion


        #region Main Animation

        private void TitleTimer_Tick(object sender, EventArgs e)
        {
            switch (_animationPhase)
            {
                case PHASE_SABRA:
                    AnimateSabra();
                    break;

                case PHASE_SPARE:
                    AnimateSpare();
                    break;

                case PHASE_CAR_PARTS:
                    AnimateCarParts();
                    break;

                case PHASE_ENGLISH:
                    AnimateEnglish();
                    break;

                case PHASE_VERSION:
                    AnimateVersion();
                    break;

                case PHASE_PAUSE:
                    RestartAnimation();
                    break;
            }
        }

        #endregion


        #region Arabic Title

        private void AnimateSabra()
        {
            if (_animationIndex < ArabicSabra.Length)
            {
                slblTitleSabra.Text =
                    ArabicSabra.Substring(0, _animationIndex + 1);

                _animationIndex++;
                return;
            }

            MoveToNextPhase(PHASE_SPARE);
        }


        private void AnimateSpare()
        {
            if (_animationIndex < ArabicSpare.Length)
            {
                slblTitleForSpare.Text =
                    ArabicSpare.Substring(0, _animationIndex + 1);

                _animationIndex++;
                return;
            }

            MoveToNextPhase(PHASE_CAR_PARTS);
        }


        private void AnimateCarParts()
        {
            if (_animationIndex < ArabicCarParts.Length)
            {
                slblTitleCarParats.Text =
                    ArabicCarParts.Substring(0, _animationIndex + 1);

                _animationIndex++;
                return;
            }

            MoveToNextPhase(PHASE_ENGLISH);

            _titleTimer.Interval = 65;
        }

        #endregion


        #region English Title

        private void AnimateEnglish()
        {
            if (_animationIndex < EnglishTitle.Length)
            {
                slblEnglishTitle.Text =
                    EnglishTitle.Substring(0, _animationIndex + 1);

                _animationIndex++;
                return;
            }

            MoveToNextPhase(PHASE_VERSION);

            _titleTimer.Interval = 90;
        }

        #endregion


        #region Version

        private void AnimateVersion()
        {
            if (_animationIndex < AppVersion.Length)
            {
                slblAppVersion.Text =
                    AppVersion.Substring(0, _animationIndex + 1);

                _animationIndex++;
                return;
            }

            _animationPhase = PHASE_PAUSE;

            // Stay on the completed title for 3 seconds
            _titleTimer.Interval = 3000;
        }

        #endregion


        #region Animation Helpers

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


        #region Login

        private void stbnLogin_Click(object sender, EventArgs e)
        {
            string username = stbxUserName.Text.Trim();
            string password = stbxPassowrd.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "من فضلك أدخل اسم المستخدم.",
                    "تسجيل الدخول",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                stbxUserName.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "من فضلك أدخل كلمة المرور.",
                    "تسجيل الدخول",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                stbxPassowrd.Focus();
                return;
            }


            // TODO:
            // Authentication
            //
            // مثال:
            //
            // if (AuthenticateUser(username, password))
            // {
            //     frmMain main = new frmMain();
            //     Hide();
            //     main.ShowDialog();
            //     Close();
            // }


            MessageBox.Show(
                "تم استلام بيانات تسجيل الدخول.",
                "Sabra For Car Spare Parts",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion


        #region Cancel

        private void sbtnCancelLogin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "هل تريد بالفعل إغلاق البرنامج؟",
                "تأكيد الخروج",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        #endregion


        #region Keyboard

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

        #endregion
        private void cbxPasswordVisibility_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPasswordVisibility.Checked)
            {
                stbxPassowrd.PasswordChar = false;
                cbxPasswordVisibility.Text = "إخفاء كلمة المرور";
            }
            else
            {
                stbxPassowrd.PasswordChar = true;
                cbxPasswordVisibility.Text = "إظهار كلمة المرور";
            }
        }

    }
}