using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.LogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucAdvances : SabraUserControl
    {
        #region Fields

        private readonly clsAdvanceBusiness _advanceBusiness =
            new clsAdvanceBusiness();

        private readonly List<Advance> _advances =
            new List<Advance>();

        private Advance _selectedAdvance;

        private bool _isLoading;
        private bool _isProcessing;

        private bool _isInitialized;

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
            // Load
            Load -= ucAdvances_Load;
            Load += ucAdvances_Load;

            // Buttons
            sbtnAddAdvance.Click -= sbtnAddAdvance_Click;
            sbtnAddAdvance.Click += sbtnAddAdvance_Click;

            sbtnExportAsExcel.Click -= sbtnExportAsExcel_Click;
            sbtnExportAsExcel.Click += sbtnExportAsExcel_Click;

            sbtnPrint.Click -= sbtnPrint_Click;
            sbtnPrint.Click += sbtnPrint_Click;

            // Grid
            dgvAdvances.CellMouseDown -= dgvAdvances_CellMouseDown;
            dgvAdvances.CellMouseDown += dgvAdvances_CellMouseDown;

            dgvAdvances.CellDoubleClick -= dgvAdvances_CellDoubleClick;
            dgvAdvances.CellDoubleClick += dgvAdvances_CellDoubleClick;

            // Context Menu
            ctmApprove.Click -= ctmApprove_Click;
            ctmApprove.Click += ctmApprove_Click;

            ctmReject.Click -= ctmReject_Click;
            ctmReject.Click += ctmReject_Click;

            ctmCancelRequest.Click -= ctmCancelRequest_Click;
            ctmCancelRequest.Click += ctmCancelRequest_Click;
        }

        #endregion


        #region Load

        private void ucAdvances_Load(object sender, EventArgs e)
        {
            if (_isInitialized)
                return;

            try
            {
                ConfigureGrid();
                ResetContextMenu();

                _isInitialized = true;

                LoadAdvances();
            }
            catch (Exception ex)
            {
                ShowUnexpectedError(ex);
            }
        }

        #endregion


        #region Data

        private void LoadAdvances()
        {
            if (_isLoading)
                return;

            try
            {
                _isLoading = true;

                ClearSelectedAdvance();

                var result = _advanceBusiness.GetAll();

                if (!result.Success)
                {
                    _advances.Clear();
                    BindAdvances();

                    ShowError(
                        string.IsNullOrWhiteSpace(result.Message)
                            ? "تعذر تحميل السلف."
                            : result.Message);

                    return;
                }

                _advances.Clear();

                if (result.Data != null)
                {
                    _advances.AddRange(result.Data);
                }

                BindAdvances();
            }
            catch (Exception ex)
            {
                ShowUnexpectedError(ex);
            }
            finally
            {
                _isLoading = false;
            }
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

            dgvAdvances.EnableHeadersVisualStyles = false;
        }


        private void ConfigureGridBehavior()
        {
            dgvAdvances.AutoGenerateColumns = false;

            dgvAdvances.AllowUserToAddRows = false;
            dgvAdvances.AllowUserToDeleteRows = false;
            dgvAdvances.AllowUserToResizeRows = false;

            dgvAdvances.ReadOnly = true;

            dgvAdvances.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAdvances.MultiSelect = false;

            dgvAdvances.EditMode =
                DataGridViewEditMode.EditProgrammatically;

            dgvAdvances.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;
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


        private void AddApproverColumn()
        {
            dgvAdvances.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colApprover",
                    HeaderText = "الموافق",
                    DataPropertyName = "ApproverName",
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

        #endregion


        #region Grid Selection

        private void dgvAdvances_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Advance advance = GetAdvanceFromRow(e.RowIndex);

            if (advance == null)
                return;

            ShowAdvanceDetails(advance);
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

            return row.DataBoundItem as Advance;
        }


        private void ShowAdvanceDetails(Advance advance)
        {
            if (advance == null)
                return;

            string approver =
                string.IsNullOrWhiteSpace(advance.ApproverName)
                    ? "لم تتم الموافقة بعد"
                    : advance.ApproverName.Trim();

            string status =
                string.IsNullOrWhiteSpace(advance.StatusName)
                    ? "غير محددة"
                    : advance.StatusName.Trim();

            string employee =
                string.IsNullOrWhiteSpace(advance.EmployeeName)
                    ? "غير محدد"
                    : advance.EmployeeName.Trim();

            string message =
                $"رقم السلفة: {advance.AdvanceID}\n\n" +
                $"الموظف: {employee}\n\n" +
                $"المبلغ: {advance.Amount:N2} ج\n\n" +
                $"تاريخ السلفة: {advance.AdvanceDate:dd/MM/yyyy}\n\n" +
                $"الحالة: {status}\n\n" +
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
            if (_isProcessing)
                return;

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
                if (dgvAdvances.Rows.Count == 0)
                {
                    ShowError("لا توجد بيانات لتصديرها.");
                    return;
                }

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
                if (dgvAdvances.Rows.Count == 0)
                {
                    ShowError("لا توجد بيانات لطباعتها.");
                    return;
                }

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


        #region Context Menu

        private void dgvAdvances_CellMouseDown(
            object sender,
            DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            if (e.RowIndex < 0)
                return;

            Advance advance =
                GetAdvanceFromRow(e.RowIndex);

            if (advance == null)
                return;

            _selectedAdvance = advance;

            dgvAdvances.ClearSelection();

            dgvAdvances.Rows[e.RowIndex].Selected = true;

            ConfigureAdvanceMenu(advance);

            Point location =
                dgvAdvances.PointToClient(
                    Cursor.Position);

            AdvanceOptions.Show(
                dgvAdvances,
                location);
        }


        private void ConfigureAdvanceMenu(Advance advance)
        {
            ResetContextMenu();

            if (advance == null)
                return;

            bool isManager =
                clsAppSession.IsManager;

            bool isPending =
                IsPendingAdvance(advance);

            bool isCurrentUserAdvance =
                IsCurrentUserAdvance(advance);


            // ==========================================
            // المدير
            // ==========================================

            if (isManager)
            {
                ctmApprove.Visible = true;
                ctmReject.Visible = true;

                ctmApprove.Enabled = isPending;
                ctmReject.Enabled = isPending;

                // المدير يستطيع إلغاء طلبه هو فقط
                ctmCancelRequest.Visible =
                    isCurrentUserAdvance;

                ctmCancelRequest.Enabled =
                    isPending && isCurrentUserAdvance;

                return;
            }


            // ==========================================
            // الموظف العادي
            // ==========================================

            ctmApprove.Visible = false;
            ctmReject.Visible = false;

            // الموظف يستطيع إلغاء طلبه فقط
            ctmCancelRequest.Visible =
                isCurrentUserAdvance;

            ctmCancelRequest.Enabled =
                isPending && isCurrentUserAdvance;
        }


        private void ResetContextMenu()
        {
            ctmApprove.Visible = false;
            ctmApprove.Enabled = false;

            ctmReject.Visible = false;
            ctmReject.Enabled = false;

            ctmCancelRequest.Visible = false;
            ctmCancelRequest.Enabled = false;
        }


        private void ClearSelectedAdvance()
        {
            _selectedAdvance = null;

            dgvAdvances.ClearSelection();

            ResetContextMenu();
        }


        private bool IsCurrentUserAdvance(Advance advance)
        {
            if (advance == null)
                return false;

            if (clsAppSession.CurrentEmployee == null)
                return false;

            return advance.EmployeeID ==
                   clsAppSession.CurrentEmployee.EmployeeID;
        }


        private bool IsPendingAdvance(Advance advance)
        {
            if (advance == null)
                return false;

            if (string.IsNullOrWhiteSpace(
                    advance.StatusName))
            {
                return false;
            }

            string status =
                advance.StatusName.Trim();

            return
                status.Equals(
                    "معلق",
                    StringComparison.OrdinalIgnoreCase)
                ||
                status.Equals(
                    "قيد الانتظار",
                    StringComparison.OrdinalIgnoreCase)
                ||
                status.Equals(
                    "Pending",
                    StringComparison.OrdinalIgnoreCase);
        }

        #endregion


        #region Approve

        private void ctmApprove_Click(
            object sender,
            EventArgs e)
        {
            if (_isProcessing)
                return;

            Advance advance = _selectedAdvance;

            if (!CanProcessAdvance(advance))
                return;

            if (!clsAppSession.IsManager)
            {
                ShowError(
                    "ليس لديك صلاحية الموافقة على السلف.");

                return;
            }


            // ==========================================
            // منع المدير من الموافقة على سلفته الشخصية
            // ==========================================

            if (IsCurrentUserAdvance(advance))
            {
                ShowError(
                    "لا يمكنك الموافقة على سلفتك الشخصية.");

                return;
            }


            try
            {
                using (var frm =
                       new frmSelectPaymentMethod())
                {
                    if (frm.ShowDialog() != DialogResult.OK)
                        return;

                    int paymentMethodID =
                        frm.SelectedPaymentMethodId;

                    if (paymentMethodID <= 0)
                    {
                        ShowError(
                            "يرجى اختيار طريقة دفع صحيحة.");

                        return;
                    }

                    _isProcessing = true;

                    var result =
                        _advanceBusiness.ApproveAndPay(
                            advance.AdvanceID,
                            paymentMethodID);

                    if (!result.Success)
                    {
                        ShowOperationError(
                            result.Message);

                        return;
                    }

                    ShowSuccess(
                        $"تمت الموافقة وصرف السلفة رقم " +
                        $"{advance.AdvanceID} بنجاح.");

                    LoadAdvances();
                }
            }
            catch (Exception ex)
            {
                ShowUnexpectedError(ex);
            }
            finally
            {
                _isProcessing = false;
                ClearSelectedAdvance();
            }
        }

        #endregion


        #region Reject

        private void ctmReject_Click(
            object sender,
            EventArgs e)
        {
            if (_isProcessing)
                return;

            Advance advance = _selectedAdvance;

            if (!CanProcessAdvance(advance))
                return;

            if (!clsAppSession.IsManager)
            {
                ShowError(
                    "ليس لديك صلاحية رفض السلف.");

                return;
            }


            // منع المدير من رفض سلفته الشخصية
            if (IsCurrentUserAdvance(advance))
            {
                ShowError(
                    "لا يمكنك رفض سلفتك الشخصية.");

                return;
            }


            DialogResult confirmation =
                MessageBox.Show(
                    $"هل أنت متأكد من رفض السلفة رقم " +
                    $"{advance.AdvanceID}؟",
                    "تأكيد رفض السلفة",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;


            try
            {
                _isProcessing = true;

                var result =
                    _advanceBusiness.Reject(
                        advance.AdvanceID);

                if (!result.Success)
                {
                    ShowOperationError(
                        result.Message);

                    return;
                }

                ShowSuccess(
                    $"تم رفض السلفة رقم " +
                    $"{advance.AdvanceID} بنجاح.");

                LoadAdvances();
            }
            catch (Exception ex)
            {
                ShowUnexpectedError(ex);
            }
            finally
            {
                _isProcessing = false;
                ClearSelectedAdvance();
            }
        }

        #endregion


        #region Cancel Request

        private void ctmCancelRequest_Click(
            object sender,
            EventArgs e)
        {
            if (_isProcessing)
                return;

            Advance advance = _selectedAdvance;

            if (!CanProcessAdvance(advance))
                return;


            // ==========================================
            // أهم نقطة:
            // الموظف لا يستطيع إلغاء سلفة غيره
            // ==========================================

            if (!IsCurrentUserAdvance(advance))
            {
                ShowError(
                    "لا يمكنك إلغاء طلب سلفة خاص بموظف آخر.");

                return;
            }


            DialogResult confirmation =
                MessageBox.Show(
                    $"هل أنت متأكد من إلغاء السلفة رقم " +
                    $"{advance.AdvanceID}؟",
                    "تأكيد إلغاء الطلب",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;


            try
            {
                _isProcessing = true;

                var result =
                    _advanceBusiness.CancelAdvance(
                        advance.AdvanceID);

                if (!result.Success)
                {
                    ShowOperationError(
                        result.Message);

                    return;
                }

                ShowSuccess(
                    $"تم إلغاء السلفة رقم " +
                    $"{advance.AdvanceID} بنجاح.");

                LoadAdvances();
            }
            catch (Exception ex)
            {
                ShowUnexpectedError(ex);
            }
            finally
            {
                _isProcessing = false;
                ClearSelectedAdvance();
            }
        }

        #endregion


        #region Validation

        private bool CanProcessAdvance(
            Advance advance)
        {
            if (advance == null)
            {
                ShowError(
                    "لم يتم تحديد سلفة.");

                return false;
            }


            if (!IsPendingAdvance(advance))
            {
                ShowError(
                    "لا يمكن تنفيذ هذه العملية.\n\n" +
                    "حالة السلفة الحالية لا تسمح بذلك.");

                return false;
            }


            return true;
        }

        #endregion


        #region Messages

        private void ShowError(string message)
        {
            MessageBox.Show(
                string.IsNullOrWhiteSpace(message)
                    ? "حدث خطأ أثناء تنفيذ العملية."
                    : message,
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }


        private void ShowOperationError(
            string message)
        {
            MessageBox.Show(
                string.IsNullOrWhiteSpace(message)
                    ? "فشلت العملية."
                    : message,
                "فشل العملية",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }


        private void ShowSuccess(string message)
        {
            MessageBox.Show(
                message,
                "تمت العملية",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        private void ShowUnexpectedError(Exception ex)
        {
            MessageBox.Show(
                "حدث خطأ غير متوقع.\n\n" +
                ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        #endregion

    }
}
