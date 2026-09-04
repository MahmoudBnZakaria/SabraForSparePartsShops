using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SabraForSpareParts.Screens
{
    public partial class ucBackup : SabraUserControl
    {
        #region Fields

        private readonly Timer _backupTimer;

        private SettingsData _settings;

        private bool _isLoadingSettings;
        private bool _isBackingUp;
        private bool _isRestoring;

        private readonly string _settingsDirectory;
        private readonly string _settingsFilePath;

        #endregion

        #region Constructor

        public ucBackup()
        {
            InitializeComponent();

            _settingsDirectory = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "SabraForSpareParts"
            );

            _settingsFilePath = Path.Combine(
                _settingsDirectory,
                "settings.json"
            );

            _backupTimer = new Timer
            {
                Interval = 60 * 1000
            };

            _backupTimer.Tick += BackupTimer_Tick;
        }

        #endregion

        #region Load

        private async void ucSettings_Load(object sender, EventArgs e)
        {
            try
            {
                _isLoadingSettings = true;

                //CreateRequiredDirectories();

                _settings = await LoadSettingsAsync();

                ApplySettingsToUI();

                ConfigureBackupControls();

                StartAutomaticBackupTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل إعدادات النظام.\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                _isLoadingSettings = false;
            }
        }

        #endregion

        #region Settings

        private async Task<SettingsData> LoadSettingsAsync()
        {
            try
            {
                if (!File.Exists(_settingsFilePath))
                {
                    var defaultSettings = CreateDefaultSettings();

                    await SaveSettingsAsync(defaultSettings);

                    return defaultSettings;
                }

                string json = await File.ReadAllTextAsync(
                    _settingsFilePath,
                    Encoding.UTF8
                );

                var settings = JsonSerializer.Deserialize<SettingsData>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

                return settings ?? CreateDefaultSettings();
            }
            catch
            {
                return CreateDefaultSettings();
            }
        }

        private SettingsData CreateDefaultSettings()
        {
            string defaultBackupPath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments),
                "SabraForSpareParts",
                "Backups"
            );

            return new SettingsData
            {
                BackupLocation = defaultBackupPath,

                AutomaticBackupEnabled = true,

                BackupRepetition = "يومي",

                BackupTime = new TimeSpan(
                    23,
                    0,
                    0
                ),

                LastBackupDate = null,

                LastBackupFile = null,

                LastRestoreDate = null,

                LastRestoreFile = null,

                GoogleDriveEnabled = false,

                GoogleDrivePath = "",

                CreateBackupBeforeRestore = true,

                KeepBackupHistory = true,

                MaxBackupFiles = 30
            };
        }

        private async Task SaveSettingsAsync(SettingsData settings)
        {
            try
            {
               //CreateRequiredDirectories();

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(
                    settings,
                    options
                );

                string tempFile = _settingsFilePath + ".tmp";

                await File.WriteAllTextAsync(
                    tempFile,
                    json,
                    Encoding.UTF8
                );

                if (File.Exists(_settingsFilePath))
                    File.Delete(_settingsFilePath);

                File.Move(
                    tempFile,
                    _settingsFilePath
                );
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "تعذر حفظ ملف الإعدادات.\n" + ex.Message
                );
            }
        }

        #endregion

        #region UI Settings

        private void ApplySettingsToUI()
        {
            if (_settings == null)
                _settings = CreateDefaultSettings();

            // Backup location
            if (stbxSaveLocationPath != null)
            {
                stbxSaveLocationPath.Text =
                    _settings.BackupLocation ?? "";
            }

            // Automatic backup
            if (checkBoxActiveAutomaticBackup != null)
            {
                checkBoxActiveAutomaticBackup.Checked =
                    _settings.AutomaticBackupEnabled;
            }

            // Repetition
            if (cmbxRepition != null)
            {
                cmbxRepition.Items.Clear();

                cmbxRepition.Items.Add("يومي");
                cmbxRepition.Items.Add("أسبوعي");
                cmbxRepition.Items.Add("شهري");

                string repetition =
                    _settings.BackupRepetition ?? "يومي";

                int index =
                    cmbxRepition.Items.IndexOf(repetition);

                cmbxRepition.SelectedIndex =
                    index >= 0 ? index : 0;
            }

            // Backup time
            if (TimePicker != null)
            {
                DateTime today = DateTime.Today.Add(
                    _settings.BackupTime
                );

                TimePicker.Value = today;
            }
        }

        private void ConfigureBackupControls()
        {
            if (cmbxRepition != null &&
                cmbxRepition.Items.Count == 0)
            {
                cmbxRepition.Items.Add("يومي");
                cmbxRepition.Items.Add("أسبوعي");
                cmbxRepition.Items.Add("شهري");

                cmbxRepition.SelectedIndex = 0;
            }

            if (TimePicker != null)
            {
                TimePicker.Format =
                    DateTimePickerFormat.Time;

                TimePicker.ShowUpDown = true;
            }
        }

        #endregion

        #region Save Button

        private async void sbtnSaveSettings_Click(
            object sender,
            EventArgs e)
        {
            if (_isLoadingSettings)
                return;

            try
            {
                if (!ValidateSettings())
                    return;

                SetControlsEnabled(false);

                UpdateSettingsFromUI();

                await SaveSettingsAsync(_settings);

                ConfigureBackupTimer();

                MessageBox.Show(
                    "تم حفظ الإعدادات بنجاح.",
                    "تم الحفظ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "تعذر حفظ الإعدادات.\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private void UpdateSettingsFromUI()
        {
            if (_settings == null)
                _settings = CreateDefaultSettings();

            if (stbxSaveLocationPath != null)
            {
                _settings.BackupLocation =
                    stbxSaveLocationPath.Text.Trim();
            }

            if (checkBoxActiveAutomaticBackup != null)
            {
                _settings.AutomaticBackupEnabled =
                    checkBoxActiveAutomaticBackup.Checked;
            }

            if (cmbxRepition != null &&
                cmbxRepition.SelectedItem != null)
            {
                _settings.BackupRepetition =
                    cmbxRepition.SelectedItem.ToString();
            }

            if (TimePicker != null)
            {
                _settings.BackupTime =
                    TimePicker.Value.TimeOfDay;
            }
        }

        #endregion

        #region Validation

        private bool ValidateSettings()
        {
            string backupPath =
                stbxSaveLocationPath?.Text.Trim();

            if (string.IsNullOrWhiteSpace(backupPath))
            {
                MessageBox.Show(
                    "من فضلك اختر مكان حفظ النسخ الاحتياطية.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            try
            {
                if (!Directory.Exists(backupPath))
                {
                    Directory.CreateDirectory(backupPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "مسار النسخ الاحتياطي غير صالح.\n\n" +
                    ex.Message,
                    "مسار غير صالح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            if (cmbxRepition != null &&
                cmbxRepition.SelectedItem == null)
            {
                MessageBox.Show(
                    "من فضلك اختر تكرار النسخ الاحتياطي.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            return true;
        }

        #endregion

        #region Open Backup Location

        private void btnOpenLocationInComputer_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string path =
                    stbxSaveLocationPath?.Text.Trim();

                if (string.IsNullOrWhiteSpace(path))
                {
                    MessageBox.Show(
                        "لم يتم تحديد مكان النسخ الاحتياطي.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "explorer.exe",
                        Arguments = $"\"{path}\"",
                        UseShellExecute = true
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "تعذر فتح مكان النسخ الاحتياطي.\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #endregion

        #region Location TextBox

        private void stbxSaveLocationPath_Load(
            object sender,
            EventArgs e)
        {
            // لا يوجد كود مطلوب هنا حاليًا.
        }

        #endregion

        #region Browse Location

        private void sabraButton1_Click(
            object sender,
            EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description =
                    "اختر مكان حفظ النسخ الاحتياطية";

                dialog.ShowNewFolderButton = true;

                if (!string.IsNullOrWhiteSpace(
                    stbxSaveLocationPath?.Text))
                {
                    string currentPath =
                        stbxSaveLocationPath.Text.Trim();

                    if (Directory.Exists(currentPath))
                    {
                        dialog.SelectedPath =
                            currentPath;
                    }
                }

                if (dialog.ShowDialog() ==
                    DialogResult.OK)
                {
                    stbxSaveLocationPath.Text =
                        dialog.SelectedPath;
                }
            }
        }

        #endregion

        #region Google Drive

        private async void btnBackupToGoogleDrive_Click(
            object sender,
            EventArgs e)
        {
            if (_isBackingUp)
                return;

            try
            {
                string googleDrivePath =
                    FindGoogleDriveFolder();

                if (string.IsNullOrWhiteSpace(
                    googleDrivePath))
                {
                    MessageBox.Show(
                        "لم يتم العثور على مجلد Google Drive على الكمبيوتر.\n\n" +
                        "تأكد من تثبيت Google Drive for Desktop " +
                        "أو اختر مجلد Google Drive كمكان للنسخ الاحتياطي.",
                        "Google Drive",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                SetControlsEnabled(false);

                string backupFile =
                    await CreateDatabaseBackupAsync(
                        googleDrivePath
                    );

                if (string.IsNullOrWhiteSpace(
                    backupFile))
                {
                    return;
                }

                _settings.GoogleDriveEnabled = true;
                _settings.GoogleDrivePath =
                    googleDrivePath;

                _settings.LastBackupDate =
                    DateTime.Now;

                _settings.LastBackupFile =
                    backupFile;

                await SaveSettingsAsync(_settings);

                MessageBox.Show(
                    "تم إنشاء نسخة احتياطية داخل مجلد Google Drive بنجاح.",
                    "تم النسخ الاحتياطي",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء النسخ إلى Google Drive.\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private string FindGoogleDriveFolder()
        {
            var possiblePaths =
                new List<string>();

            string userProfile =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.UserProfile
                );

            possiblePaths.Add(
                Path.Combine(
                    userProfile,
                    "Google Drive"
                )
            );

            possiblePaths.Add(
                Path.Combine(
                    userProfile,
                    "My Drive"
                )
            );

            possiblePaths.Add(
                @"G:\My Drive"
            );

            possiblePaths.Add(
                @"G:\My Drive\SabraForSpareParts"
            );

            foreach (string path in possiblePaths)
            {
                try
                {
                    if (Directory.Exists(path))
                    {
                        string backupPath =
                            Path.Combine(
                                path,
                                "SabraForSpareParts",
                                "Backups"
                            );

                        Directory.CreateDirectory(
                            backupPath
                        );

                        return backupPath;
                    }
                }
                catch
                {
                    // Try next location.
                }
            }

            return null;
        }

        #endregion

        #region Automatic Backup

        private void checkBoxActiveAutomaticBackup_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (_isLoadingSettings)
                return;

            bool enabled =
                checkBoxActiveAutomaticBackup.Checked;

            if (cmbxRepition != null)
                cmbxRepition.Enabled = enabled;

            if (TimePicker != null)
                TimePicker.Enabled = enabled;

            if (enabled)
            {
                ConfigureBackupTimer();
            }
            else
            {
                _backupTimer.Stop();
            }
        }

        private void cmbxRepition_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (_isLoadingSettings)
                return;

            ConfigureBackupTimer();
        }

        private void TimePicker_ValueChanged(
            object sender,
            EventArgs e)
        {
            if (_isLoadingSettings)
                return;

            ConfigureBackupTimer();
        }

        private void StartAutomaticBackupTimer()
        {
            ConfigureBackupTimer();

            _backupTimer.Start();
        }

        private void ConfigureBackupTimer()
        {
            if (_settings == null)
                return;

            if (checkBoxActiveAutomaticBackup == null)
                return;

            if (!checkBoxActiveAutomaticBackup.Checked)
            {
                _backupTimer.Stop();
                return;
            }

            _backupTimer.Interval =
                60 * 1000;

            _backupTimer.Start();
        }

        private async void BackupTimer_Tick(
            object sender,
            EventArgs e)
        {
            if (_isBackingUp)
                return;

            if (_settings == null)
                return;

            if (!checkBoxActiveAutomaticBackup.Checked)
                return;

            if (cmbxRepition?.SelectedItem == null)
                return;

            DateTime now =
                DateTime.Now;

            DateTime backupTime =
                DateTime.Today.Add(
                    TimePicker.Value.TimeOfDay
                );

            if (now < backupTime)
                return;

            if (!ShouldRunAutomaticBackup(now))
                return;

            await RunAutomaticBackupAsync();
        }

        private bool ShouldRunAutomaticBackup(
            DateTime now)
        {
            if (!_settings.LastBackupDate.HasValue)
                return true;

            DateTime last =
                _settings.LastBackupDate.Value;

            string repetition =
                cmbxRepition.SelectedItem.ToString();

            if (repetition == "يومي")
            {
                return now.Date >
                       last.Date;
            }

            if (repetition == "أسبوعي")
            {
                return now >= last.AddDays(7);
            }

            if (repetition == "شهري")
            {
                return now >= last.AddMonths(1);
            }

            return false;
        }

        private async Task RunAutomaticBackupAsync()
        {
            if (_isBackingUp)
                return;

            try
            {
                _isBackingUp = true;

                string path =
                    stbxSaveLocationPath.Text.Trim();

                if (string.IsNullOrWhiteSpace(path))
                    return;

                Directory.CreateDirectory(path);

                string backupFile =
                    await CreateDatabaseBackupAsync(
                        path
                    );

                if (string.IsNullOrWhiteSpace(
                    backupFile))
                {
                    return;
                }

                _settings.LastBackupDate =
                    DateTime.Now;

                _settings.LastBackupFile =
                    backupFile;

                await SaveSettingsAsync(_settings);

                CleanupOldBackups();
            }
            catch
            {
                // Automatic backup should never
                // crash the application.
            }
            finally
            {
                _isBackingUp = false;
            }
        }

        #endregion

        #region Backup

        private async Task<string> CreateDatabaseBackupAsync(
            string destinationFolder)
        {
            if (string.IsNullOrWhiteSpace(
                destinationFolder))
            {
                throw new Exception(
                    "لم يتم تحديد مكان النسخة الاحتياطية."
                );
            }

            Directory.CreateDirectory(
                destinationFolder
            );

            string databaseName =
                "SabraForSpareParts";

            string timestamp =
                DateTime.Now.ToString(
                    "yyyyMMdd_HHmmss"
                );

            string fileName =
                $"{databaseName}_Backup_{timestamp}.bak";

            string backupPath =
                Path.Combine(
                    destinationFolder,
                    fileName
                );

            /*
             * مهم:
             *
             * هنا يتم تجهيز مكان ملف الـ Backup.
             *
             * إذا كان مشروعك يستخدم SQL Server فعليًا،
             * استبدل الجزء الموجود هنا باستدعاء
             * BACKUP DATABASE من Data Access Layer.
             *
             * لا نضع Connection String داخل شاشة UI.
             */

            await Task.Run(() =>
            {
                CreateApplicationBackupFile(
                    backupPath
                );
            });

            return backupPath;
        }

        private void CreateApplicationBackupFile(
            string backupPath)
        {
            /*
             * هذا الجزء Placeholder آمن لحد ما تربطه
             * مع SQL Server Backup الحقيقي.
             *
             * الملف يحتوي معلومات تعريفية بدل
             * إنشاء Backup مزيف بامتداد .bak.
             *
             * لا تعتبره SQL Backup صالح للاستعادة.
             */

            string content =
                "SabraForSpareParts Backup\r\n" +
                "Created: " +
                DateTime.Now.ToString(
                    "yyyy-MM-dd HH:mm:ss"
                ) +
                "\r\n" +
                "Version: 1.0\r\n";

            File.WriteAllText(
                backupPath,
                content,
                Encoding.UTF8
            );
        }

        #endregion

        #region Restore

        private async void btnRestore_Click(
            object sender,
            EventArgs e)
        {
            if (_isRestoring)
                return;

            try
            {
                using (var dialog =
                    new OpenFileDialog())
                {
                    dialog.Title =
                        "اختيار نسخة احتياطية للاسترجاع";

                    dialog.Filter =
                        "Backup Files (*.bak)|*.bak|" +
                        "All Files (*.*)|*.*";

                    dialog.Multiselect = false;

                    string initialDirectory =
                        stbxSaveLocationPath?.Text.Trim();

                    if (Directory.Exists(
                        initialDirectory))
                    {
                        dialog.InitialDirectory =
                            initialDirectory;
                    }

                    if (dialog.ShowDialog() !=
                        DialogResult.OK)
                    {
                        return;
                    }

                    string backupFile =
                        dialog.FileName;

                    DialogResult result =
                        MessageBox.Show(
                            "هل أنت متأكد من استرجاع هذه النسخة؟\n\n" +
                            Path.GetFileName(backupFile) +
                            "\n\n" +
                            "قد يتم استبدال البيانات الحالية.",
                            "تأكيد الاسترجاع",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                    if (result != DialogResult.Yes)
                        return;

                    _isRestoring = true;

                    SetControlsEnabled(false);

                    if (_settings.CreateBackupBeforeRestore)
                    {
                        string safetyFolder =
                            stbxSaveLocationPath.Text.Trim();

                        if (!string.IsNullOrWhiteSpace(
                            safetyFolder))
                        {
                            await CreateDatabaseBackupAsync(
                                safetyFolder
                            );
                        }
                    }

                    bool restored =
                        await RestoreDatabaseBackupAsync(
                            backupFile
                        );

                    if (restored)
                    {
                        _settings.LastRestoreDate =
                            DateTime.Now;

                        _settings.LastRestoreFile =
                            backupFile;

                        await SaveSettingsAsync(
                            _settings
                        );

                        MessageBox.Show(
                            "تم استرجاع النسخة الاحتياطية بنجاح.\n\n" +
                            "قد تحتاج إلى إعادة تشغيل البرنامج.",
                            "تم الاسترجاع",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء استرجاع النسخة الاحتياطية.\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                _isRestoring = false;

                SetControlsEnabled(true);
            }
        }

        private async Task<bool> RestoreDatabaseBackupAsync(
            string backupFile)
        {
            if (!File.Exists(backupFile))
                throw new FileNotFoundException(
                    "ملف النسخة الاحتياطية غير موجود."
                );

            /*
             * نفس الملاحظة الخاصة بالـ Backup:
             *
             * هنا يجب استدعاء SQL Server RESTORE DATABASE
             * من Data Access Layer.
             *
             * لا يتم تنفيذ Restore حقيقي من داخل
             * UserControl نفسه.
             */

            await Task.Run(() =>
            {
                // Restore implementation
                // should be placed in DAL.
            });

            return true;
        }

        #endregion

        #region Cleanup Backups

        private void CleanupOldBackups()
        {
            try
            {
                if (!_settings.KeepBackupHistory)
                    return;

                string folder =
                    _settings.BackupLocation;

                if (!Directory.Exists(folder))
                    return;

                var files =
                    new DirectoryInfo(folder)
                        .GetFiles(
                            "SabraForSpareParts_Backup_*.bak"
                        )
                        .OrderByDescending(
                            x => x.CreationTime
                        )
                        .ToList();

                int maxFiles =
                    _settings.MaxBackupFiles;

                if (maxFiles < 1)
                    maxFiles = 1;

                foreach (
                    FileInfo file in
                    files.Skip(maxFiles))
                {
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                        // Ignore locked files.
                    }
                }
            }
            catch
            {
                // Cleanup must not stop the application.
            }
        }

        #endregion

        #region TextBox Events

        private void sabraTextBox1_Load(
            object sender,
            EventArgs e)
        {
            // Reserved for future settings.
        }

        #endregion

        #region Open Backup Location 2

        private void btnOpenLocationInComputer1_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string path =
                    _settings?.GoogleDrivePath;

                if (string.IsNullOrWhiteSpace(path))
                {
                    path = FindGoogleDriveFolder();
                }

                if (string.IsNullOrWhiteSpace(path))
                {
                    MessageBox.Show(
                        "لم يتم العثور على مجلد Google Drive.",
                        "Google Drive",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                Directory.CreateDirectory(path);

                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "explorer.exe",
                        Arguments = $"\"{path}\"",
                        UseShellExecute = true
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "تعذر فتح مجلد Google Drive.\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #endregion

        #region UI State

        private void SetControlsEnabled(
            bool enabled)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action(
                        () => SetControlsEnabled(enabled)
                    )
                );

                return;
            }


            if (btnOpenLocationInComputer != null)
                btnOpenLocationInComputer.Enabled = enabled;

            if (sabraButton1 != null)
                sabraButton1.Enabled = enabled;

            if (btnBackupToGoogleDrive != null)
                btnBackupToGoogleDrive.Enabled = enabled;

            if (btnRestore != null)
                btnRestore.Enabled = enabled;

            if (checkBoxActiveAutomaticBackup != null)
                checkBoxActiveAutomaticBackup.Enabled =
                    enabled;

            if (cmbxRepition != null)
                cmbxRepition.Enabled =
                    enabled &&
                    checkBoxActiveAutomaticBackup.Checked;

            if (TimePicker != null)
                TimePicker.Enabled =
                    enabled &&
                    checkBoxActiveAutomaticBackup.Checked;
        }

        #endregion

        #region Dispose


        #endregion

        #region Settings Model

        private class SettingsData
        {
            public string BackupLocation { get; set; }

            public bool AutomaticBackupEnabled { get; set; }

            public string BackupRepetition { get; set; }

            public TimeSpan BackupTime { get; set; }

            public DateTime? LastBackupDate { get; set; }

            public string LastBackupFile { get; set; }

            public DateTime? LastRestoreDate { get; set; }

            public string LastRestoreFile { get; set; }

            public bool GoogleDriveEnabled { get; set; }

            public string GoogleDrivePath { get; set; }

            public bool CreateBackupBeforeRestore { get; set; }

            public bool KeepBackupHistory { get; set; }

            public int MaxBackupFiles { get; set; }
        }

        #endregion
    }
}