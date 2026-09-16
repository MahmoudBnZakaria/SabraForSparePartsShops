using Sabra.DataLayer.Models;
using Sabra.LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucAdvances : SabraUserControl
    {
        #region Fields

        private readonly clsAdvanceBusiness _advanceBusiness =
            new clsAdvanceBusiness();

        private readonly clsEmployeeBusiness _employeeBusiness =
            new clsEmployeeBusiness();

        private List<Advance> _advances =
            new List<Advance>();

        // اسم الموظف مقابل الـ ID — مستخدمة لحل اسم "الموافق" لأن
        // Advance بيرجع Employee_ID (ApprovedBy) بس مش الاسم جاهز.
        private Dictionary<int, string> _employeeNamesById =
            new Dictionary<int, string>();

        private Advance _selectedAdvance;

        #endregion


        #region Constructor

        public ucAdvances()
        {
            InitializeComponent();
            WireEvents();
        }

        #endregion


        #region Events

        private void WireEvents()
        {
            Load -= ucAdvances_Load;
            Load += ucAdvances_Load;

            sbtnAddAdvance.Click -= sbtnAddAdvance_Click;
            sbtnAddAdvance.Click += sbtnAddAdvance_Click;

            sbtnExportAsExcel.Click -= sbtnExportAsExcel_Click;
            sbtnExportAsExcel.Click += sbtnExportAsExcel_Click;

            sbtnPrint.Click -= sbtnPrint_Click;
            sbtnPrint.Click += sbtnPrint_Click;

            dgvAdvances.CellContentClick -= dgvAdvances_CellContentClick;
            dgvAdvances.CellContentClick += dgvAdvances_CellContentClick;

            dgvAdvances.CellFormatting -= dgvAdvances_CellFormatting;
            dgvAdvances.CellFormatting += dgvAdvances_CellFormatting;

            WireAdvanceContextMenu();
        }

        #endregion


        #region Load

        private void ucAdvances_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigureGrid();
                LoadEmployeeNames();
                LoadAdvances();
            }
            catch (Exception ex)
            {
                ShowUnexpectedError(ex);
            }
        }

        #endregion


        #region Data

        /// <summary>
        /// بتجيب أسماء الموظفين كلها (نشطين وغير نشطين، عشان لو المدير
        /// اللي وافق على سلفة قديمة بقى غير نشط، اسمه يفضل يظهر) لحل
        /// عمود "الموافق" اللي بيتخزن كـ ID بس في الـ Advance.
        /// </summary>
        private void LoadEmployeeNames()
        {
            var result = _employeeBusiness.GetAll(activeOnly: false);

            _employeeNamesById = result.Success && result.Data != null
                ? result.Data.ToDictionary(emp => emp.EmployeeID, emp => emp.FullName)
                : new Dictionary<int, string>();
        }

        private void LoadAdvances()
        {
            // المدير يشوف سلف كل الموظفين، أما الموظف العادي فيشوف
            // طلباته هو بس — بيانات السلف مالية وحساسة.
            int? employeeFilter = clsAppSession.IsManager
                ? (int?)null
                : clsAppSession.CurrentEmployee?.EmployeeID;

            var result = _advanceBusiness.GetAll(employeeID: employeeFilter);

            if (!result.Success)
            {
                ShowError(result.Message);
                return;
            }

            _advances = result.Data ?? new List<Advance>();

            BindAdvances();
        }


        private void BindAdvances()
        {
            dgvAdvances.DataSource = null;
            dgvAdvances.DataSource = _advances;
        }

        #endregion


        #region Grid Configuration

        private void ConfigureGrid()
        {
            ConfigureGridAppearance();
            ConfigureGridBehavior();
            ConfigureGridFonts();
            SetupColumns();
        }


        private void ConfigureGridAppearance()
        {
            dgvAdvances.RightToLeft = RightToLeft.Yes;

            dgvAdvances.RowHeadersVisible = false;

            dgvAdvances.RowTemplate.Height = 45;
            dgvAdvances.ColumnHeadersHeight = 45;

            dgvAdvances.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAdvances.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }


        private void ConfigureGridBehavior()
        {
            dgvAdvances.AutoGenerateColumns = false;

            dgvAdvances.AllowUserToAddRows = false;
            dgvAdvances.AllowUserToDeleteRows = false;

            dgvAdvances.ReadOnly = true;

            dgvAdvances.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAdvances.MultiSelect = false;
        }


        private void ConfigureGridFonts()
        {
            dgvAdvances.DefaultCellStyle.Font =
                new Font("Cairo", 10F);

            dgvAdvances.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Cairo",
                    10F,
                    FontStyle.Bold);
        }


        private void SetupColumns()
        {
            dgvAdvances.Columns.Clear();

            AddEmployeeColumn();
            AddAdvanceDateColumn();
            AddAmountColumn();
            AddApproverColumn();
            AddStatusColumn();
            AddDetailsColumn();
        }


        private void AddEmployeeColumn()
        {
            dgvAdvances.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colEmployee",
                    HeaderText = "الموظف",
                    DataPropertyName = "EmployeeName",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });
        }


        private void AddAdvanceDateColumn()
        {
            dgvAdvances.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colAdvanceDate",
                    HeaderText = "تاريخ السلفة",
                    DataPropertyName = "AdvanceDate",
                    Width = 150,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format = "dd/MM/yyyy"
                        }
                });
        }


        private void AddAmountColumn()
        {
            dgvAdvances.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colAmount",
                    HeaderText = "المبلغ",
                    DataPropertyName = "Amount",
                    Width = 150,

                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format = "#,##0.00 ج"
                        }
                });
        }


        /// <summary>
        /// عمود "الموافق" مش متربط مباشرة بـ Property (Advance معندهاش
        /// ApproverName، بس ApprovedBy كـ ID) — قيمته بتتحدد يدوياً في
        /// dgvAdvances_CellFormatting من _employeeNamesById.
        /// </summary>
        private void AddApproverColumn()
        {
            dgvAdvances.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colApprover",
                    HeaderText = "الموافق",
                    Width = 180
                });
        }


        private void AddStatusColumn()
        {
            dgvAdvances.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "الحالة",
                    DataPropertyName = "StatusName",
                    Width = 150
                });
        }


        private void AddDetailsColumn()
        {
            dgvAdvances.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colDetails",
                    HeaderText = "",
                    Text = "التفاصيل",
                    UseColumnTextForButtonValue = true,
                    Width = 110,
                    FlatStyle = FlatStyle.Flat
                });
        }


        /// <summary>يحل اسم الموافق من الـ ID المخزّن في الـ Advance.</summary>
        private void dgvAdvances_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvAdvances.Columns[e.ColumnIndex].Name != "colApprover")
                return;

            if (!(dgvAdvances.Rows[e.RowIndex].DataBoundItem is Advance advance))
                return;

            e.Value = ResolveApproverName(advance);
            e.FormattingApplied = true;
        }


        private string ResolveApproverName(Advance advance)
        {
            if (advance?.ApprovedBy == null)
                return "لم تتم الموافقة بعد";

            return _employeeNamesById.TryGetValue(advance.ApprovedBy.Value, out string name)
                ? name
                : "لم تتم الموافقة بعد";
        }

        #endregion



        #region Details

        private void dgvAdvances_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (!IsValidDetailsClick(e))
                return;

            Advance advance = GetAdvanceFromRow(e.RowIndex);

            if (advance == null)
                return;

            ShowAdvanceDetails(advance);
        }


        private bool IsValidDetailsClick(
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return false;

            if (e.ColumnIndex < 0)
                return false;

            string columnName =
                dgvAdvances.Columns[e.ColumnIndex].Name;

            return columnName == "colDetails";
        }


        private Advance GetAdvanceFromRow(int rowIndex)
        {
            if (rowIndex < 0 ||
                rowIndex >= dgvAdvances.Rows.Count)
            {
                return null;
            }

            DataGridViewRow row =
                dgvAdvances.Rows[rowIndex];

            if (row.DataBoundItem is Advance advance)
                return advance;

            return null;
        }


        private void ShowAdvanceDetails(Advance advance)
        {
            string approver = ResolveApproverName(advance);

            string message =
                $"رقم السلفة: {advance.AdvanceID}\n\n" +
                $"الموظف: {advance.EmployeeName}\n\n" +
                $"المبلغ: {advance.Amount:N2} ج\n\n" +
                $"تاريخ السلفة: {advance.AdvanceDate:dd/MM/yyyy}\n\n" +
                $"الحالة: {advance.StatusName}\n\n" +
                $"الموافق: {approver}\n\n" +
                $"تاريخ الإنشاء: {advance.CreatedAt:dd/MM/yyyy HH:mm}";

            MessageBox.Show(
                message,
                "تفاصيل السلفة",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion


        #region Add Advance

        private void sbtnAddAdvance_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using (var frm = new frmRequireAdvance())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadAdvances();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowUnexpectedError(ex);
            }
        }

        #endregion


        #region Export

        private void sbtnExportAsExcel_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                clsGlobalClass.ExportDataGridViewToExcel(
                    dgvAdvances,
                    "",
                    "Advances");
            }
            catch (Exception ex)
            {
                ShowUnexpectedError(ex);
            }
        }

        #endregion


        #region Print

        private void sbtnPrint_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                clsGlobalClass.PrintDataGridView(
                    dgvAdvances,
                    "Advances");
            }
            catch (Exception ex)
            {
                ShowUnexpectedError(ex);
            }
        }

        #endregion


        #region Messages

        private void ShowError(string message)
        {
            MessageBox.Show(
                message,
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }


        private void ShowUnexpectedError(Exception ex)
        {
            MessageBox.Show(
                "حدث خطأ غير متوقع:\n\n" +
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        #endregion


        #region Context Menu

        private void WireAdvanceContextMenu()
        {
            dgvAdvances.CellMouseDown -= dgvAdvances_CellMouseDown;
            dgvAdvances.CellMouseDown += dgvAdvances_CellMouseDown;

            ctmApprove.Click -= ctmApprove_Click;
            ctmApprove.Click += ctmApprove_Click;

            ctmReject.Click -= ctmReject_Click;
            ctmReject.Click += ctmReject_Click;

            ctmCancelRequest.Click -= ctmCancelRequest_Click;
            ctmCancelRequest.Click += ctmCancelRequest_Click;
        }

        private void dgvAdvances_CellMouseDown(
            object sender,
            DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            if (e.RowIndex < 0)
                return;

            Advance advance = GetAdvanceFromRow(e.RowIndex);

            if (advance == null)
                return;

            _selectedAdvance = advance;

            dgvAdvances.ClearSelection();

            dgvAdvances.Rows[e.RowIndex].Selected = true;

            ConfigureAdvanceMenu(_selectedAdvance);

            Point location = dgvAdvances.PointToClient(Cursor.Position);

            AdvanceOptions.Show(
                dgvAdvances, location);
        }

        private void ConfigureAdvanceMenu(Advance advance)
        {
            if (advance == null)
                return;

            bool isManager = clsAppSession.IsManager;
            bool isPending = _advanceBusiness.IsPending(advance);
            bool isOwnRequest = clsAppSession.CurrentEmployee != null &&
                                 advance.EmployeeID == clsAppSession.CurrentEmployee.EmployeeID;

            if (isManager)
            {
                ctmApprove.Visible = true;
                ctmReject.Visible = true;

                ctmApprove.Enabled = isPending;
                ctmReject.Enabled = isPending;

                // المدير برضه ممكن يكون صاحب طلب سلفة لنفسه.
                ctmCancelRequest.Visible = isOwnRequest;
                ctmCancelRequest.Enabled = isPending;
            }
            else
            {
                ctmApprove.Visible = false;
                ctmReject.Visible = false;

                // احتياطي دفاعي: حتى لو ظهرت سلفة لموظف تاني في الليستة،
                // مينفعش غير صاحبها يلغيها.
                ctmCancelRequest.Visible = isOwnRequest;
                ctmCancelRequest.Enabled = isPending;
            }
        }

        private void ctmApprove_Click(object sender, EventArgs e)
        {
            if (_selectedAdvance == null)
                return;

            if (!clsAppSession.IsManager)
                return;

            if (!_advanceBusiness.IsPending(_selectedAdvance))
            {
                ShowError(
                    "لا يمكن الموافقة على هذه السلفة.\n\n" +
                    "حالة السلفة الحالية لا تسمح بالموافقة.");

                return;
            }

            using (var frm = new frmSelectPaymentMethod())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int selectedPaymentMethodId = frm.SelectedPaymentMethodId;

                    var result = _advanceBusiness.ApproveAndPay(
                        _selectedAdvance.AdvanceID,
                        selectedPaymentMethodId);

                    if (result.Success)
                    {
                        MessageBox.Show(
                            $"تمت الموافقة وصرف السلفة رقم {_selectedAdvance.AdvanceID} بنجاح.",
                            "تمت العملية",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadAdvances();
                    }
                    else
                    {
                        MessageBox.Show(
                            result.Message,
                            "فشل",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ctmReject_Click(
            object sender,
            EventArgs e)
        {
            if (_selectedAdvance == null)
                return;

            if (!clsAppSession.IsManager)
                return;

            if (!_advanceBusiness.IsPending(_selectedAdvance))
            {
                ShowError(
                    "لا يمكن رفض هذه السلفة.\n\n" +
                    "حالة السلفة الحالية لا تسمح بالرفض.");

                return;
            }

            var result = _advanceBusiness.Reject(
                _selectedAdvance.AdvanceID);

            if (result.Success)
            {
                MessageBox.Show(
                     $"تم رفض طلب السلفة رقم {_selectedAdvance.AdvanceID} بنجاح.",
                     "تم الرفض",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning);

                LoadAdvances();
            }
            else
            {
                MessageBox.Show(
                     result.Message,
                     "فشل",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private void ctmCancelRequest_Click(
            object sender,
            EventArgs e)
        {
            if (_selectedAdvance == null)
                return;

            if (clsAppSession.CurrentEmployee == null)
                return;

            if (!_advanceBusiness.IsPending(_selectedAdvance))
            {
                ShowError(
                    "لا يمكن إلغاء هذه السلفة.\n\n" +
                    "حالة السلفة الحالية لا تسمح بالإلغاء.");

                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"هل أنت متأكد من إلغاء السلفة رقم " +
                $"{_selectedAdvance.AdvanceID}؟",
                "تأكيد إلغاء الطلب",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            var cancelResult = _advanceBusiness.CancelAdvance(
                _selectedAdvance.AdvanceID,
                clsAppSession.CurrentEmployee.EmployeeID);

            if (cancelResult.Success)
            {
                MessageBox.Show(
                    $"تم إلغاء طلب السلفة رقم {_selectedAdvance.AdvanceID} بنجاح.",
                    "تم الإلغاء",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadAdvances();
            }
            else
            {
                MessageBox.Show(
                    cancelResult.Message,
                    "فشل",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}