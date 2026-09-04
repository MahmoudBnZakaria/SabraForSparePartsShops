using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucUsers : SabraUserControl
    {
        #region Fields

        private readonly List<UserModel> _users = new();

        // Pool: نحتفظ بالكروت اللي اتعملت قبل كدا بدل ما نعمل
        // Destroy / Create في كل مرة (أغلى عملية في WinForms).
        private readonly Dictionary<int, ucUserCard> _cardPool = new();

        private TextBox txtSearchUsers;
        private ComboBox cmbUserStatus;
        private Button btnRefreshUsers;

        // بنأخر تنفيذ الفلترة شوية بعد آخر حرف يتكتب
        // عشان ما نعملش LoadUsers مع كل ضغطة زرار.
        private readonly System.Windows.Forms.Timer _searchDebounceTimer =
            new() { Interval = 250 };

        // بديل الـ Panel اللي كانت بتتعمل من الصفر كل مرة
        // مفيش يوزرز مطابقين للفلترة.
        private Panel _emptyStatePanel;
        private IconPictureBox _emptyStateIcon;
        private Label _emptyStateLabel;

        // Card Layout
        private const int CardHeight = 235;
        private const int MinimumCardWidth = 300;

        // المسافة بين الكروت
        private const int CardHorizontalGap = 16;
        private const int CardVerticalGap = 16;

        // المسافة الداخلية للـ container
        private const int ContainerPadding = 16;

        // خطوط ثابتة (Static) بدل ما نعمل "new Font" في كل مرة.
        // إنشاء Font مكلف نسبيًا وبيسيب Handle، فتفضيل إعادة استخدامه.
        private static readonly Font FontCairo10 = new("Cairo", 10F);
        private static readonly Font FontCairo9Bold = new("Cairo", 9F, FontStyle.Bold);
        private static readonly Font FontCairo11Bold = new("Cairo", 11F, FontStyle.Bold);

        private bool _isLoadingUsers;

        #endregion

        #region Constructor

        public ucUsers()
        {
            InitializeComponent();

            InitializePage();
            LoadMockData();
            LoadUsers();
        }

        #endregion

        #region Initialize

        private void InitializePage()
        {
            ConfigureCardsContainer();
            CreateSearchControls();
            ConfigureAddButton();
            ConfigureSearchDebounce();
            CreateEmptyStatePanelOnce();
        }

        private void ConfigureSearchDebounce()
        {
            _searchDebounceTimer.Tick += (s, e) =>
            {
                _searchDebounceTimer.Stop();
                LoadUsers();
            };
        }

        #endregion

        #region Cards Container

        private void ConfigureCardsContainer()
        {
            if (sabraFlowLayoutPanelContainerOfCards == null)
                return;

            sabraFlowLayoutPanelContainerOfCards.AutoScroll = true;

            sabraFlowLayoutPanelContainerOfCards.WrapContents = true;

            // RTL مناسب للواجهة العربية
            sabraFlowLayoutPanelContainerOfCards.FlowDirection =
                FlowDirection.RightToLeft;

            sabraFlowLayoutPanelContainerOfCards.Padding =
                new Padding(ContainerPadding);

            sabraFlowLayoutPanelContainerOfCards.Margin =
                new Padding(0);

            sabraFlowLayoutPanelContainerOfCards.BackColor =
                Color.FromArgb(248, 250, 252);

            sabraFlowLayoutPanelContainerOfCards.Resize -=
                sabraFlowLayoutPanelContainerOfCards_Resize;

            sabraFlowLayoutPanelContainerOfCards.Resize +=
                sabraFlowLayoutPanelContainerOfCards_Resize;
        }

        private void sabraFlowLayoutPanelContainerOfCards_Resize(
            object sender,
            EventArgs e)
        {
            ResizeUserCards();
            RepositionEmptyState();
        }

        private void ResizeUserCards()
        {
            if (sabraFlowLayoutPanelContainerOfCards == null)
                return;

            if (sabraFlowLayoutPanelContainerOfCards.IsDisposed)
                return;

            // بنحسب بس على الكروت الظاهرة فعليًا (المفلترة)
            var cards =
                sabraFlowLayoutPanelContainerOfCards.Controls
                    .OfType<ucUserCard>()
                    .Where(c => c.Visible)
                    .ToList();

            if (cards.Count == 0)
                return;

            int availableWidth =
                sabraFlowLayoutPanelContainerOfCards.ClientSize.Width
                - sabraFlowLayoutPanelContainerOfCards.Padding.Left
                - sabraFlowLayoutPanelContainerOfCards.Padding.Right;

            if (availableWidth <= 0)
                return;

            /*
             * نحسب عدد الأعمدة المناسب.
             *
             * مثال:
             *
             * عرض 1000
             * => 3 Cards
             *
             * عرض 1400
             * => 4 Cards
             *
             * عرض 1800
             * => 5 Cards
             */

            int columns = Math.Max(
                1,
                (availableWidth + CardHorizontalGap) /
                (MinimumCardWidth + CardHorizontalGap)
            );

            // لا نريد عدد أعمدة أكبر من عدد الكروت
            columns = Math.Min(columns, cards.Count);

            /*
             * لو الـ FlowLayoutPanel عنده Vertical Scrollbar
             * نقلل المساحة المتاحة قليلًا لتجنب ظهور Card
             * أعرض من المساحة الفعلية.
             */

            if (sabraFlowLayoutPanelContainerOfCards.VerticalScroll.Visible)
            {
                availableWidth -=
                    SystemInformation.VerticalScrollBarWidth;
            }

            if (availableWidth <= 0)
                return;

            /*
             * المساحة الكلية التي ستأخذها الـ gaps.
             */

            int totalGapWidth =
                (columns - 1) * CardHorizontalGap;

            /*
             * العرض الحقيقي لكل Card.
             */

            int cardWidth =
                (availableWidth - totalGapWidth) / columns;

            /*
             * حماية إضافية.
             */

            if (cardWidth < MinimumCardWidth)
            {
                columns = Math.Max(
                    1,
                    availableWidth /
                    (MinimumCardWidth + CardHorizontalGap)
                );

                columns = Math.Min(
                    columns,
                    cards.Count
                );

                totalGapWidth =
                    (columns - 1) * CardHorizontalGap;

                cardWidth =
                    (availableWidth - totalGapWidth) /
                    columns;
            }

            /*
             * نوقف الـ Layout أثناء تغيير أحجام
             * كل الكروت حتى لا يحصل Flickering.
             * ونتجنب إعادة ضبط عرض/هامش الكارت لو
             * هو أصلًا نفس القيمة، عشان نقلل Layout Passes.
             */

            sabraFlowLayoutPanelContainerOfCards.SuspendLayout();

            try
            {
                var newMargin = new Padding(
                    CardHorizontalGap / 2,
                    CardVerticalGap / 2,
                    CardHorizontalGap / 2,
                    CardVerticalGap / 2
                );

                foreach (var card in cards)
                {
                    if (card.Width != cardWidth)
                        card.Width = cardWidth;

                    if (card.Height != CardHeight)
                        card.Height = CardHeight;

                    if (card.Margin != newMargin)
                        card.Margin = newMargin;
                }
            }
            finally
            {
                sabraFlowLayoutPanelContainerOfCards.ResumeLayout(
                    true
                );
            }
        }

        #endregion

        #region Search Controls

        private void CreateSearchControls()
        {
            txtSearchUsers = new TextBox
            {
                Name = "txtSearchUsers",
                Font = FontCairo10,
                RightToLeft = RightToLeft.Yes,
                PlaceholderText =
                    "بحث بالاسم أو اسم المستخدم أو الوظيفة...",
                Size = new Size(320, 38)
            };

            txtSearchUsers.TextChanged +=
                txtSearchUsers_TextChanged;

            cmbUserStatus = new ComboBox
            {
                Name = "cmbUserStatus",
                Font = FontCairo10,
                RightToLeft = RightToLeft.Yes,
                DropDownStyle =
                    ComboBoxStyle.DropDownList,
                FlatStyle =
                    FlatStyle.Flat,
                Size =
                    new Size(150, 38)
            };

            cmbUserStatus.Items.AddRange(
                new object[]
                {
                    "كل المستخدمين",
                    "نشط",
                    "غير نشط"
                }
            );

            cmbUserStatus.SelectedIndex = 0;

            cmbUserStatus.SelectedIndexChanged +=
                cmbUserStatus_SelectedIndexChanged;

            btnRefreshUsers = new Button
            {
                Name = "btnRefreshUsers",
                Text = "تحديث",
                Font = FontCairo9Bold,
                Size =
                    new Size(100, 38),
                FlatStyle =
                    FlatStyle.Flat,
                BackColor =
                    Color.FromArgb(37, 99, 235),
                ForeColor =
                    Color.White,
                Cursor =
                    Cursors.Hand
            };

            btnRefreshUsers.FlatAppearance.BorderSize = 0;

            btnRefreshUsers.Click +=
                btnRefreshUsers_Click;

            Controls.Add(txtSearchUsers);
            Controls.Add(cmbUserStatus);
            Controls.Add(btnRefreshUsers);

            PositionSearchControls();

            Resize -= ucUsers_Resize;
            Resize += ucUsers_Resize;
        }

        private void PositionSearchControls()
        {
            if (txtSearchUsers == null ||
                cmbUserStatus == null ||
                btnRefreshUsers == null)
                return;

            const int top = 20;
            const int left = 20;
            const int gap = 10;

            txtSearchUsers.Location =
                new Point(
                    left,
                    top
                );

            cmbUserStatus.Location =
                new Point(
                    txtSearchUsers.Right + gap,
                    top
                );

            btnRefreshUsers.Location =
                new Point(
                    cmbUserStatus.Right + gap,
                    top
                );
        }

        private void ucUsers_Resize(
            object sender,
            EventArgs e)
        {
            PositionSearchControls();

            /*
             * لا نستخدم BeginInvoke هنا.
             *
             * الـ FlowLayoutPanel نفسه لديه Resize Event
             * وسيقوم بتحديث الكروت.
             */
        }

        #endregion

        #region Add Button

        private void ConfigureAddButton()
        {
            if (sbtnAddNewUser == null)
                return;

            sbtnAddNewUser.Click -=
                sbtnAddNewUser_Click;

            sbtnAddNewUser.Click +=
                sbtnAddNewUser_Click;
        }

        #endregion

        #region Mock Data

        private void LoadMockData()
        {
            _users.Clear();

            _users.AddRange(
                new List<UserModel>
                {
                    new UserModel
                    {
                        Id = 1,
                        Name = "أحمد محمد",
                        Role = "مدير",
                        Username = "ahmed",
                        Phone = "01012345678",
                        IsActive = true,
                        IsFemale = false,
                        CreatedDate =
                            new DateTime(2020, 1, 1)
                    },

                    new UserModel
                    {
                        Id = 2,
                        Name = "سارة أحمد",
                        Role = "كاشيير",
                        Username = "sara",
                        Phone = "01098765432",
                        IsActive = true,
                        IsFemale = true,
                        CreatedDate =
                            new DateTime(2022, 3, 15)
                    },

                    new UserModel
                    {
                        Id = 3,
                        Name = "خالد محمود",
                        Role = "أمين المستودع",
                        Username = "khaled",
                        Phone = "01123456789",
                        IsActive = true,
                        IsFemale = false,
                        CreatedDate =
                            new DateTime(2023, 6, 1)
                    },

                    new UserModel
                    {
                        Id = 4,
                        Name = "منى علي",
                        Role = "موظفة مبيعات",
                        Username = "mona",
                        Phone = "01234567890",
                        IsActive = true,
                        IsFemale = true,
                        CreatedDate =
                            new DateTime(2023, 8, 12)
                    },

                    new UserModel
                    {
                        Id = 5,
                        Name = "محمد حسن",
                        Role = "محاسب",
                        Username = "mohamed",
                        Phone = "01155667788",
                        IsActive = true,
                        IsFemale = false,
                        CreatedDate =
                            new DateTime(2024, 2, 10)
                    },

                    new UserModel
                    {
                        Id = 6,
                        Name = "نورهان محمود",
                        Role = "كاشيير",
                        Username = "norhan",
                        Phone = "01055667788",
                        IsActive = false,
                        IsFemale = true,
                        CreatedDate =
                            new DateTime(2024, 5, 20)
                    },

                    new UserModel
                    {
                        Id = 7,
                        Name = "مصطفى علي",
                        Role = "موظف مبيعات",
                        Username = "mostafa",
                        Phone = "01222333444",
                        IsActive = true,
                        IsFemale = false,
                        CreatedDate =
                            new DateTime(2024, 7, 5)
                    },

                    new UserModel
                    {
                        Id = 8,
                        Name = "هند أحمد",
                        Role = "مديرة حسابات",
                        Username = "hend",
                        Phone = "01011223344",
                        IsActive = true,
                        IsFemale = true,
                        CreatedDate =
                            new DateTime(2025, 1, 18)
                    },

                    new UserModel
                    {
                        Id = 9,
                        Name = "عمر خالد",
                        Role = "مبيعات",
                        Username = "omar",
                        Phone = "01199887766",
                        IsActive = false,
                        IsFemale = false,
                        CreatedDate =
                            new DateTime(2025, 4, 3)
                    }
                }
            );
        }

        #endregion

        #region Load Users

        private void LoadUsers()
        {
            if (sabraFlowLayoutPanelContainerOfCards == null)
                return;

            if (_isLoadingUsers)
                return;

            _isLoadingUsers = true;

            sabraFlowLayoutPanelContainerOfCards.SuspendLayout();

            try
            {
                string searchText =
                    txtSearchUsers?.Text?.Trim() ?? "";

                string status =
                    cmbUserStatus?.SelectedItem?.ToString()
                    ?? "كل المستخدمين";

                IEnumerable<UserModel> filteredUsers =
                    _users;

                // Search
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    filteredUsers =
                        filteredUsers.Where(user =>
                            Contains(
                                user.Name,
                                searchText
                            )
                            ||
                            Contains(
                                user.Username,
                                searchText
                            )
                            ||
                            Contains(
                                user.Role,
                                searchText
                            )
                            ||
                            Contains(
                                user.Phone,
                                searchText
                            )
                        );
                }

                // Status
                if (status == "نشط")
                {
                    filteredUsers =
                        filteredUsers.Where(
                            user => user.IsActive
                        );
                }
                else if (status == "غير نشط")
                {
                    filteredUsers =
                        filteredUsers.Where(
                            user => !user.IsActive
                        );
                }

                var usersList =
                    filteredUsers
                        .OrderByDescending(
                            user => user.IsActive
                        )
                        .ThenBy(
                            user => user.Name
                        )
                        .ToList();

                SyncCardsWithUsersList(usersList);

                UpdateUsersCount(
                    usersList.Count
                );

                SetEmptyStateVisible(
                    usersList.Count == 0
                );
            }
            finally
            {
                _isLoadingUsers = false;

                sabraFlowLayoutPanelContainerOfCards.ResumeLayout(
                    true
                );
            }

            /*
             * مهم:
             *
             * LoadUsers قد يتم استدعاؤها أثناء الـ constructor،
             * لذلك لا نحاول عمل Resize هنا.
             *
             * الـ Load Event سيعمل أول Resize بعد إنشاء الشاشة.
             *
             * وبعد ذلك Resize الخاص بالـ FlowLayoutPanel
             * سيعيد توزيع الكروت تلقائيًا.
             */
        }

        /// <summary>
        /// بدل ما نمسح كل الكروت ونعمل Instance جديد لكل يوزر
        /// في كل فلترة (وده أغلى حاجة بتأثر على الأداء في WinForms)،
        /// بنستخدم Pool: كل يوزر ليه كارت واحد بس بيتعمل مرة واحدة،
        /// وبعد كدا بس بنظبط ترتيبه وظهوره/إخفاءه.
        /// </summary>
        private void SyncCardsWithUsersList(List<UserModel> usersList)
        {
            var visibleIds = new HashSet<int>(usersList.Select(u => u.Id));

            // إخفاء أي كارت مش موجود في النتيجة الحالية
            foreach (var kvp in _cardPool)
            {
                if (!visibleIds.Contains(kvp.Key))
                {
                    kvp.Value.Visible = false;
                }
            }

            // إظهار/إنشاء الكروت بالترتيب الصحيح
            for (int i = 0; i < usersList.Count; i++)
            {
                var user = usersList[i];

                var card = GetOrCreateCard(user);

                UpdateCardFromUser(card, user);

                card.Visible = true;

                // بيحافظ على ترتيب العرض المطلوب جوه الـ FlowLayoutPanel
                sabraFlowLayoutPanelContainerOfCards.Controls.SetChildIndex(
                    card,
                    i
                );
            }
        }

        private ucUserCard GetOrCreateCard(UserModel user)
        {
            if (_cardPool.TryGetValue(user.Id, out var existingCard))
                return existingCard;

            var card =
                new ucUserCard
                {
                    Width = MinimumCardWidth,
                    Height = CardHeight,

                    Margin =
                        new Padding(
                            CardHorizontalGap / 2,
                            CardVerticalGap / 2,
                            CardHorizontalGap / 2,
                            CardVerticalGap / 2
                        )
                };

            card.EditClicked += UserCard_EditClicked;
            card.ChangePasswordClicked += UserCard_ChangePasswordClicked;
            card.CardClicked += UserCard_CardClicked;

            _cardPool[user.Id] = card;

            sabraFlowLayoutPanelContainerOfCards.Controls.Add(card);

            return card;
        }

        private static void UpdateCardFromUser(ucUserCard card, UserModel user)
        {
            // بنحدث بس القيم اللي اتغيرت فعلًا، عشان نتجنب
            // إعادة رسم/Invalidate مش لازمة على كل Property.
            if (card.UserName != user.Name) card.UserName = user.Name;
            if (card.UserRole != user.Role) card.UserRole = user.Role;
            if (card.Username != user.Username) card.Username = user.Username;
            if (card.Phone != user.Phone) card.Phone = user.Phone;
            if (card.IsActive != user.IsActive) card.IsActive = user.IsActive;
            if (card.IsFemale != user.IsFemale) card.IsFemale = user.IsFemale;

            card.Tag = user;
        }

        private bool Contains(
            string source,
            string search)
        {
            if (string.IsNullOrWhiteSpace(source))
                return false;

            return source.Contains(
                search,
                StringComparison.OrdinalIgnoreCase
            );
        }

        #endregion

        #region Empty State

        private void CreateEmptyStatePanelOnce()
        {
            _emptyStatePanel = new Panel
            {
                Height = 180,
                BackColor = Color.White,
                Margin = new Padding(8),
                Visible = false
            };

            _emptyStateIcon = new IconPictureBox
            {
                IconChar = IconChar.UserSlash,
                IconFont = IconFont.Auto,
                IconColor = Color.FromArgb(148, 163, 184),
                BackColor = Color.Transparent,
                Size = new Size(55, 55),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(0, 25)
            };

            _emptyStateLabel = new Label
            {
                Text = "لا يوجد مستخدمون مطابقون للبحث",
                Font = FontCairo11Bold,
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                RightToLeft = RightToLeft.Yes,
                Height = 50,
                Location = new Point(0, 95)
            };

            _emptyStatePanel.Controls.Add(_emptyStateIcon);
            _emptyStatePanel.Controls.Add(_emptyStateLabel);

            sabraFlowLayoutPanelContainerOfCards.Controls.Add(_emptyStatePanel);

            RepositionEmptyState();
        }

        private void RepositionEmptyState()
        {
            if (_emptyStatePanel == null)
                return;

            int width =
                Math.Max(
                    400,
                    sabraFlowLayoutPanelContainerOfCards.ClientSize.Width
                    - sabraFlowLayoutPanelContainerOfCards.Padding.Left
                    - sabraFlowLayoutPanelContainerOfCards.Padding.Right
                );

            _emptyStatePanel.Width = width;
            _emptyStateIcon.Location =
                new Point((width - _emptyStateIcon.Width) / 2, 25);
            _emptyStateLabel.Width = width;
        }

        private void SetEmptyStateVisible(bool visible)
        {
            if (_emptyStatePanel == null)
                return;

            if (visible)
                RepositionEmptyState();

            _emptyStatePanel.Visible = visible;
        }

        #endregion

        #region Counter

        private void UpdateUsersCount(
            int count)
        {
            if (lblNumberOfUsers == null)
                return;

            lblNumberOfUsers.Text =
                $"عدد المستخدمين: {count:N0}";
        }

        private void lblNumberOfUsers_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                $"إجمالي المستخدمين: {_users.Count:N0}",
                "المستخدمون",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

        #region Search

        private void txtSearchUsers_TextChanged(
            object sender,
            EventArgs e)
        {
            // بدل ما نعمل LoadUsers على طول مع كل حرف،
            // بنستنى شوية (Debounce) عشان الأداء يبقى أفضل
            // خصوصًا لو عدد المستخدمين كبير.
            _searchDebounceTimer.Stop();
            _searchDebounceTimer.Start();
        }

        private void cmbUserStatus_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadUsers();
        }

        #endregion

        #region Refresh

        private void btnRefreshUsers_Click(
            object sender,
            EventArgs e)
        {
            _searchDebounceTimer.Stop();

            txtSearchUsers.Clear();

            cmbUserStatus.SelectedIndex = 0;

            LoadUsers();
        }

        #endregion

        #region Add User

        private void sbtnAddNewUser_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "هنا سيتم فتح شاشة إضافة مستخدم جديد.",
                "إضافة مستخدم",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

        #region Edit User

        private void UserCard_EditClicked(
            object sender,
            EventArgs e)
        {
            if (sender is not ucUserCard card)
                return;

            if (card.Tag is not UserModel user)
                return;

            MessageBox.Show(
                $"تعديل المستخدم:\n\n" +
                $"الاسم: {user.Name}\n" +
                $"الوظيفة: {user.Role}\n" +
                $"اسم المستخدم: {user.Username}\n" +
                $"الهاتف: {user.Phone}",
                "تعديل المستخدم",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

        #region Change Password

        private void UserCard_ChangePasswordClicked(
            object sender,
            EventArgs e)
        {
            if (sender is not ucUserCard card)
                return;

            if (card.Tag is not UserModel user)
                return;

            MessageBox.Show(
                $"تغيير كلمة مرور المستخدم:\n\n{user.Name}",
                "تغيير كلمة المرور",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

        #region Card Click

        private void UserCard_CardClicked(
            object sender,
            EventArgs e)
        {
            if (sender is not ucUserCard card)
                return;

            if (card.Tag is not UserModel user)
                return;

            // فتح تفاصيل المستخدم هنا
            // OpenUserDetails(user.Id);
        }

        #endregion

        #region Export

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            DataTable table =
                new DataTable();

            table.Columns.Add("الاسم");
            table.Columns.Add("الوظيفة");
            table.Columns.Add("اسم المستخدم");
            table.Columns.Add("رقم الهاتف");
            table.Columns.Add("الحالة");
            table.Columns.Add("تاريخ إنشاء الحساب");

            foreach (var user in _users)
            {
                table.Rows.Add(
                    user.Name,
                    user.Role,
                    user.Username,
                    user.Phone,
                    user.IsActive
                        ? "نشط"
                        : "غير نشط",
                    user.CreatedDate.ToString(
                        "dd/MM/yyyy"
                    )
                );
            }

            ExportUsersToExcel(table);
        }

        private void ExportUsersToExcel(
            DataTable table)
        {
            try
            {
                string tempFile =
                    System.IO.Path.Combine(
                        System.IO.Path.GetTempPath(),
                        $"Users_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                    );

                using (
                    var workbook =
                        new ClosedXML.Excel.XLWorkbook()
                )
                {
                    var worksheet =
                        workbook.Worksheets.Add(
                            "Users"
                        );

                    worksheet.Cell(1, 1)
                        .InsertTable(table);

                    worksheet.Columns()
                        .AdjustToContents();

                    workbook.SaveAs(tempFile);
                }

                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = tempFile,
                        UseShellExecute = true
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء تصدير المستخدمين:\n\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #endregion

        #region Public Helpers

        public void RefreshUsers()
        {
            LoadUsers();
        }

        public void AddUser(
            UserModel user)
        {
            if (user == null)
                return;

            _users.Add(user);

            LoadUsers();
        }

        public void RemoveUser(
            int userId)
        {
            var user =
                _users.FirstOrDefault(
                    x => x.Id == userId
                );

            if (user == null)
                return;

            _users.Remove(user);

            // لازم نشيل الكارت بتاعه من الـ Pool كمان
            // وإلا هيفضل شبح موجود في الـ Controls Collection.
            if (_cardPool.TryGetValue(userId, out var card))
            {
                sabraFlowLayoutPanelContainerOfCards.Controls.Remove(card);
                card.EditClicked -= UserCard_EditClicked;
                card.ChangePasswordClicked -= UserCard_ChangePasswordClicked;
                card.CardClicked -= UserCard_CardClicked;
                card.Dispose();

                _cardPool.Remove(userId);
            }

            LoadUsers();
        }

        #endregion

        #region User Model

        public class UserModel
        {
            public int Id { get; set; }

            public string Name { get; set; } = "";

            public string Role { get; set; } = "";

            public string Username { get; set; } = "";

            public string Phone { get; set; } = "";

            public bool IsActive { get; set; }

            public bool IsFemale { get; set; }

            public DateTime CreatedDate { get; set; }
        }

        #endregion

        #region Load Event

        private void ucUsers_Load(
            object sender,
            EventArgs e)
        {
            /*
             * أول مرة فقط:
             * الشاشة أصبحت موجودة فعليًا،
             * وبالتالي الـ FlowLayoutPanel لديه
             * الحجم الحقيقي.
             */

            ResizeUserCards();
            RepositionEmptyState();
        }

        #endregion

        #region Existing Events

        private void sabraFlowLayoutPanelContainerOfCards_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        #endregion

        #region Dispose

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _searchDebounceTimer.Tick -= null;
        //        _searchDebounceTimer.Dispose();
        //    }

        //    base.Dispose(disposing);
        //}

        #endregion
    }
}