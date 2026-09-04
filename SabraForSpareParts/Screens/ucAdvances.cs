using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.Design;

namespace SabraForSpareParts.Screens
{
    public partial class ucAdvances : SabraUserControl
    {
        private DataTable _dtAdvances;

        public ucAdvances()
        {
            InitializeComponent();

        }

        private void ucAdvances_Load(object sender, EventArgs e)
        {
            LoadMockData();
            ConfigureGrid();
            RefreshStatistics();
        }

        #region Data

        private void LoadMockData()
        {
            _dtAdvances = new DataTable();

            _dtAdvances.Columns.Add("AdvanceID", typeof(int));
            _dtAdvances.Columns.Add("Employee", typeof(string));
            _dtAdvances.Columns.Add("AdvanceDate", typeof(DateTime));
            _dtAdvances.Columns.Add("Amount", typeof(decimal));
            _dtAdvances.Columns.Add("Paid", typeof(decimal));
            _dtAdvances.Columns.Add("Remaining", typeof(decimal));
            _dtAdvances.Columns.Add("MonthlyDeduction", typeof(decimal));
            _dtAdvances.Columns.Add("Status", typeof(string));

            _dtAdvances.Rows.Add(
                1,
                "أحمد محمد",
                new DateTime(2025, 1, 5),
                500,
                0,
                500,
                500,
                "غير مسددة"
            );

            _dtAdvances.Rows.Add(
                2,
                "سارة أحمد",
                new DateTime(2025, 1, 3),
                700,
                0,
                700,
                350,
                "غير مسددة"
            );

            _dtAdvances.Rows.Add(
                3,
                "محمد علي",
                new DateTime(2025, 2, 10),
                1500,
                500,
                1000,
                500,
                "جزئية"
            );

            _dtAdvances.Rows.Add(
                4,
                "محمود حسن",
                new DateTime(2025, 2, 15),
                1000,
                1000,
                0,
                500,
                "مسددة"
            );

            _dtAdvances.Rows.Add(
                5,
                "عمر خالد",
                new DateTime(2025, 3, 1),
                2000,
                1000,
                1000,
                500,
                "جزئية"
            );

            dgvAdvances.DataSource = _dtAdvances;
        }

        #endregion

        #region Grid

        private void ConfigureGrid()
        {
            dgvAdvances.RightToLeft = RightToLeft.Yes;

            dgvAdvances.AutoGenerateColumns = false;
            dgvAdvances.AllowUserToAddRows = false;
            dgvAdvances.AllowUserToDeleteRows = false;
            dgvAdvances.ReadOnly = true;

            dgvAdvances.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAdvances.MultiSelect = false;

            dgvAdvances.RowHeadersVisible = false;

            dgvAdvances.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgvAdvances.RowTemplate.Height = 45;

            dgvAdvances.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvAdvances.ColumnHeadersHeight = 50;

            dgvAdvances.EnableHeadersVisualStyles = false;

            dgvAdvances.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAdvances.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAdvances.DefaultCellStyle.Font =
                new Font("Cairo", 10F);

            dgvAdvances.ColumnHeadersDefaultCellStyle.Font =
                new Font("Cairo", 10F, FontStyle.Bold);

            dgvAdvances.CellContentClick -=
                dgvAdvances_CellContentClick;

            dgvAdvances.CellContentClick +=
                dgvAdvances_CellContentClick;

            SetupColumns();
        }

        private void SetupColumns()
        {
            dgvAdvances.Columns.Clear();

            dgvAdvances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmployee",
                HeaderText = "الموظف",
                DataPropertyName = "Employee",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvAdvances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAdvanceDate",
                HeaderText = "تاريخ السلفة",
                DataPropertyName = "AdvanceDate",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "d/M/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvAdvances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAmount",
                HeaderText = "المبلغ",
                DataPropertyName = "Amount",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0.## ج",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvAdvances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPaid",
                HeaderText = "المسدد",
                DataPropertyName = "Paid",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0.## ج",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvAdvances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRemaining",
                HeaderText = "المتبقي",
                DataPropertyName = "Remaining",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0.## ج",
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Cairo", 10F, FontStyle.Bold)
                }
            });

            dgvAdvances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMonthlyDeduction",
                HeaderText = "الخصم الشهري",
                DataPropertyName = "MonthlyDeduction",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0.## ج",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvAdvances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "الحالة",
                DataPropertyName = "Status",
                Width = 120
            });

            dgvAdvances.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colDetails",
                HeaderText = "الإجراءات",
                Text = "تفاصيل",
                UseColumnTextForButtonValue = true,
                Width = 110,
                FlatStyle = FlatStyle.Flat
            });
        }

        #endregion

        #region Statistics

        private void RefreshStatistics()
        {
            if (_dtAdvances == null)
                return;

            decimal totalAdvances =
                _dtAdvances.AsEnumerable()
                    .Sum(row => row.Field<decimal>("Amount"));

            decimal totalPaid =
                _dtAdvances.AsEnumerable()
                    .Sum(row => row.Field<decimal>("Paid"));

            decimal totalRemaining =
                _dtAdvances.AsEnumerable()
                    .Sum(row => row.Field<decimal>("Remaining"));

            // لو عندك Cards في الشاشة:
            //
            // lblTotalAdvances.Text = $"{totalAdvances:N0} ج";
            // lblTotalPaid.Text = $"{totalPaid:N0} ج";
            // lblTotalRemaining.Text = $"{totalRemaining:N0} ج";
            //
            // lblAdvanceCount.Text = _dtAdvances.Rows.Count.ToString();
        }

        #endregion

        #region Export / Print

        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            clsGlobalClass.ExportDataGridViewToExcel(
                dgvAdvances,
                "",
                "Advances"
            );
        }

        private void sbtnPrint_Click(object sender, EventArgs e)
        {
            clsGlobalClass.PrintDataGridView(
                dgvAdvances,
                "Advances"
            );
        }

        #endregion

        #region Add Advance

        private void sbtnAddAdvance_Click(object sender, EventArgs e)
        {
            using (Form frm = CreateAddAdvanceForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string employee =
                        frm.Controls["txtEmployee"].Text.Trim();

                    decimal amount =
                        Convert.ToDecimal(
                            ((NumericUpDown)frm.Controls["nudAmount"]).Value
                        );

                    decimal monthlyDeduction =
                        Convert.ToDecimal(
                            ((NumericUpDown)frm.Controls["nudMonthly"]).Value
                        );

                    DateTime date =
                        ((DateTimePicker)frm.Controls["dtpDate"]).Value;

                    if (amount <= 0)
                    {
                        MessageBox.Show(
                            "يجب إدخال مبلغ سلفة صحيح.",
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    if (monthlyDeduction <= 0)
                    {
                        MessageBox.Show(
                            "يجب إدخال قيمة الخصم الشهري.",
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    if (monthlyDeduction > amount)
                    {
                        monthlyDeduction = amount;
                    }

                    int newID =
                        _dtAdvances.AsEnumerable()
                            .Select(r => r.Field<int>("AdvanceID"))
                            .DefaultIfEmpty(0)
                            .Max() + 1;

                    _dtAdvances.Rows.Add(
                        newID,
                        employee,
                        date,
                        amount,
                        0,
                        amount,
                        monthlyDeduction,
                        "غير مسددة"
                    );

                    dgvAdvances.DataSource = null;
                    dgvAdvances.DataSource = _dtAdvances;

                    RefreshStatistics();

                    MessageBox.Show(
                        "تمت إضافة السلفة بنجاح.",
                        "تم",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private Form CreateAddAdvanceForm()
        {
            Form frm = new Form();

            frm.Name = "frmAddAdvance";
            frm.Text = "سلفة جديدة";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Size = new Size(500, 420);
            frm.RightToLeft = RightToLeft.Yes;
            frm.Font = new Font("Cairo", 10F);

            Label lblEmployee = new Label
            {
                Text = "الموظف",
                Location = new Point(330, 35),
                AutoSize = true
            };

            TextBox txtEmployee = new TextBox
            {
                Name = "txtEmployee",
                Location = new Point(40, 65),
                Width = 390
            };

            Label lblAmount = new Label
            {
                Text = "مبلغ السلفة",
                Location = new Point(330, 110),
                AutoSize = true
            };

            NumericUpDown nudAmount = new NumericUpDown
            {
                Name = "nudAmount",
                Location = new Point(40, 140),
                Width = 390,
                Minimum = 1,
                Maximum = 100000000,
                Increment = 100,
                ThousandsSeparator = true
            };

            Label lblMonthly = new Label
            {
                Text = "الخصم الشهري",
                Location = new Point(330, 185),
                AutoSize = true
            };

            NumericUpDown nudMonthly = new NumericUpDown
            {
                Name = "nudMonthly",
                Location = new Point(40, 215),
                Width = 390,
                Minimum = 1,
                Maximum = 100000000,
                Increment = 50,
                ThousandsSeparator = true
            };

            Label lblDate = new Label
            {
                Text = "تاريخ السلفة",
                Location = new Point(330, 260),
                AutoSize = true
            };

            DateTimePicker dtpDate = new DateTimePicker
            {
                Name = "dtpDate",
                Location = new Point(40, 290),
                Width = 390,
                Format = DateTimePickerFormat.Short
            };

            Button btnSave = new Button
            {
                Text = "حفظ السلفة",
                DialogResult = DialogResult.OK,
                Location = new Point(250, 335),
                Width = 180,
                Height = 40
            };

            Button btnCancel = new Button
            {
                Text = "إلغاء",
                DialogResult = DialogResult.Cancel,
                Location = new Point(40, 335),
                Width = 180,
                Height = 40
            };

            frm.Controls.Add(lblEmployee);
            frm.Controls.Add(txtEmployee);

            frm.Controls.Add(lblAmount);
            frm.Controls.Add(nudAmount);

            frm.Controls.Add(lblMonthly);
            frm.Controls.Add(nudMonthly);

            frm.Controls.Add(lblDate);
            frm.Controls.Add(dtpDate);

            frm.Controls.Add(btnSave);
            frm.Controls.Add(btnCancel);

            frm.AcceptButton = btnSave;
            frm.CancelButton = btnCancel;

            return frm;
        }

        #endregion

        #region Details

        private void dgvAdvances_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvAdvances.Columns[e.ColumnIndex].Name != "colDetails")
                return;

            DataGridViewRow row =
                dgvAdvances.Rows[e.RowIndex];

            string employee =
                row.Cells["colEmployee"].Value?.ToString();

            DateTime date =
                Convert.ToDateTime(
                    row.Cells["colAdvanceDate"].Value
                );

            decimal amount =
                Convert.ToDecimal(
                    row.Cells["colAmount"].Value
                );

            decimal paid =
                Convert.ToDecimal(
                    row.Cells["colPaid"].Value
                );

            decimal remaining =
                Convert.ToDecimal(
                    row.Cells["colRemaining"].Value
                );

            decimal monthly =
                Convert.ToDecimal(
                    row.Cells["colMonthlyDeduction"].Value
                );

            string status =
                row.Cells["colStatus"].Value?.ToString();

            string message =
                $"الموظف: {employee}\n\n" +
                $"تاريخ السلفة: {date:d/M/yyyy}\n\n" +
                $"مبلغ السلفة: {amount:N0} ج\n\n" +
                $"المسدد: {paid:N0} ج\n\n" +
                $"المتبقي: {remaining:N0} ج\n\n" +
                $"الخصم الشهري: {monthly:N0} ج\n\n" +
                $"الحالة: {status}";

            MessageBox.Show(
                message,
                "تفاصيل السلفة",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

    }
}