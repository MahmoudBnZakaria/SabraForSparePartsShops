using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucVehicleCompatibility : SabraUserControl
    {
        private readonly List<VehicleCompatibilityMock> _allCompatibilities = new();
        private readonly BindingSource _bindingSource = new();

        public ucVehicleCompatibility()
        {
            InitializeComponent();

            Load += ucVehicleCompatibility_Load;
        }

        #region Load

        private void ucVehicleCompatibility_Load(object sender, EventArgs e)
        {
            LoadMockData();

            SetupBrandFilter();
            SetupGrid();
            ApplyFilters();
        }

        #endregion

        #region Mock Data

        private void LoadMockData()
        {
            _allCompatibilities.Clear();

            _allCompatibilities.Add(new VehicleCompatibilityMock
            {
                Id = 1,
                PartName = "فلتر زيت OC90",
                Brand = "Toyota",
                Model = "Corolla",
                StartYear = 2018,
                EndYear = 2023
            });

            _allCompatibilities.Add(new VehicleCompatibilityMock
            {
                Id = 2,
                PartName = "بوجية BKR6E",
                Brand = "Kia",
                Model = "Cerato",
                StartYear = 2019,
                EndYear = 2024
            });

            _allCompatibilities.Add(new VehicleCompatibilityMock
            {
                Id = 3,
                PartName = "ديسك فرامل DF47",
                Brand = "Hyundai",
                Model = "Accent",
                StartYear = 2017,
                EndYear = 2022
            });

            _allCompatibilities.Add(new VehicleCompatibilityMock
            {
                Id = 4,
                PartName = "فلتر هواء OF124",
                Brand = "Renault",
                Model = "Logan",
                StartYear = 2016,
                EndYear = 2021
            });

            _allCompatibilities.Add(new VehicleCompatibilityMock
            {
                Id = 5,
                PartName = "تيل فرامل BP450",
                Brand = "Nissan",
                Model = "Sunny",
                StartYear = 2018,
                EndYear = 2023
            });

            _allCompatibilities.Add(new VehicleCompatibilityMock
            {
                Id = 6,
                PartName = "طقم بواجي NGK",
                Brand = "Hyundai",
                Model = "Elantra",
                StartYear = 2020,
                EndYear = 2025
            });

            _allCompatibilities.Add(new VehicleCompatibilityMock
            {
                Id = 7,
                PartName = "فلتر بنزين FF100",
                Brand = "BMW",
                Model = "320i",
                StartYear = 2019,
                EndYear = 2024
            });
        }

        #endregion

        #region Brand Filter

        private void SetupBrandFilter()
        {
            scbxBrand.Items.Clear();

            scbxBrand.Items.Add("كل الشركات");

            var brands = _allCompatibilities
                .Select(x => x.Brand)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            foreach (string brand in brands)
            {
                scbxBrand.Items.Add(brand);
            }

            scbxBrand.SelectedIndex = 0;
        }

        #endregion

        #region Grid

        private void SetupGrid()
        {
            sabraDataGridView1.AutoGenerateColumns = false;
            sabraDataGridView1.Columns.Clear();

            sabraDataGridView1.AllowUserToAddRows = false;
            sabraDataGridView1.AllowUserToDeleteRows = false;

            sabraDataGridView1.ReadOnly = true;

            sabraDataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            sabraDataGridView1.MultiSelect = false;

            sabraDataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "PartName",
                    DataPropertyName = "PartName",
                    HeaderText = "اسم القطعة",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill
                });

            sabraDataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Brand",
                    DataPropertyName = "Brand",
                    HeaderText = "شركة السيارة",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.AllCells
                });

            sabraDataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Model",
                    DataPropertyName = "Model",
                    HeaderText = "الموديل",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.AllCells
                });

            sabraDataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Years",
                    DataPropertyName = "Years",
                    HeaderText = "سنوات التشغيل",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.AllCells
                });

            sabraDataGridView1.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "btnEdit",
                    HeaderText = "تعديل",
                    Text = "تعديل",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.AllCells
                });

            sabraDataGridView1.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "btnDelete",
                    HeaderText = "حذف",
                    Text = "حذف",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.AllCells
                });

            _bindingSource.DataSource = new List<VehicleCompatibilityMock>();

            sabraDataGridView1.DataSource = _bindingSource;
        }

        #endregion

        #region Filters

        private void ApplyFilters()
        {
            IEnumerable<VehicleCompatibilityMock> result =
                _allCompatibilities;

            // =========================================
            // 1. اسم القطعة
            // =========================================

            string partSearch =
                stxbPartInfo.Text.Trim();

            if (!string.IsNullOrWhiteSpace(partSearch))
            {
                result = result.Where(x =>
                    x.PartName.Contains(
                        partSearch,
                        StringComparison.OrdinalIgnoreCase));
            }

            // =========================================
            // 2. شركة السيارة
            // =========================================

            string selectedBrand =
                scbxBrand.SelectedItem?.ToString();

            if (!string.IsNullOrWhiteSpace(selectedBrand) &&
                selectedBrand != "كل الشركات")
            {
                result = result.Where(x =>
                    x.Brand.Equals(
                        selectedBrand,
                        StringComparison.OrdinalIgnoreCase));
            }

            // =========================================
            // 3. الموديل
            // =========================================

            string modelSearch =
                stxbxModel.Text.Trim();

            if (!string.IsNullOrWhiteSpace(modelSearch))
            {
                result = result.Where(x =>
                    x.Model.Contains(
                        modelSearch,
                        StringComparison.OrdinalIgnoreCase));
            }

            // =========================================
            // 4. سنة السيارة
            // =========================================

            string yearText =
                stxbYear.Text.Trim();

            if (int.TryParse(yearText, out int year))
            {
                result = result.Where(x =>
                    year >= x.StartYear &&
                    year <= x.EndYear);
            }

            // =========================================
            // عرض النتيجة
            // =========================================

            _bindingSource.DataSource =
                result.ToList();
        }

        private void scbxBrand_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void stxbPartInfo_TextChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void stxbxModel_TextChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        private void stxbYear_TextChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        #endregion

        #region Search

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            ApplyFilters();
        }

        #endregion

        #region Grid Actions

        private void sabraDataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;

            if (sabraDataGridView1.Rows[e.RowIndex]
                .DataBoundItem is not VehicleCompatibilityMock compatibility)
                return;

            string columnName =
                sabraDataGridView1.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "btnEdit":

                    EditCompatibility(compatibility);

                    break;

                case "btnDelete":

                    DeleteCompatibility(compatibility);

                    break;
            }
        }

        #endregion

        #region Edit

        private void EditCompatibility(
            VehicleCompatibilityMock compatibility)
        {
            using Form form = new Form();

            form.Text = "تعديل توافق السيارة";
            form.StartPosition =
                FormStartPosition.CenterParent;

            form.Width = 450;
            form.Height = 350;

            form.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            form.MaximizeBox = false;
            form.MinimizeBox = false;

            Label lblPart = new Label
            {
                Text = "اسم القطعة",
                Left = 30,
                Top = 30,
                Width = 100
            };

            TextBox txtPart = new TextBox
            {
                Left = 140,
                Top = 25,
                Width = 240,
                Text = compatibility.PartName
            };

            Label lblBrand = new Label
            {
                Text = "شركة السيارة",
                Left = 30,
                Top = 80,
                Width = 100
            };

            TextBox txtBrand = new TextBox
            {
                Left = 140,
                Top = 75,
                Width = 240,
                Text = compatibility.Brand
            };

            Label lblModel = new Label
            {
                Text = "الموديل",
                Left = 30,
                Top = 130,
                Width = 100
            };

            TextBox txtModel = new TextBox
            {
                Left = 140,
                Top = 125,
                Width = 240,
                Text = compatibility.Model
            };

            Label lblStartYear = new Label
            {
                Text = "من سنة",
                Left = 30,
                Top = 180,
                Width = 100
            };

            NumericUpDown numStartYear = new NumericUpDown
            {
                Left = 140,
                Top = 175,
                Width = 100,
                Minimum = 1900,
                Maximum = 2100,
                Value = compatibility.StartYear
            };

            Label lblEndYear = new Label
            {
                Text = "إلى سنة",
                Left = 250,
                Top = 180,
                Width = 70
            };

            NumericUpDown numEndYear = new NumericUpDown
            {
                Left = 320,
                Top = 175,
                Width = 60,
                Minimum = 1900,
                Maximum = 2100,
                Value = compatibility.EndYear
            };

            Button btnSave = new Button
            {
                Text = "حفظ",
                Left = 140,
                Top = 230,
                Width = 110,
                Height = 35
            };

            Button btnCancel = new Button
            {
                Text = "إلغاء",
                Left = 270,
                Top = 230,
                Width = 110,
                Height = 35
            };

            btnSave.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPart.Text))
                {
                    MessageBox.Show(
                        "من فضلك أدخل اسم القطعة.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBrand.Text))
                {
                    MessageBox.Show(
                        "من فضلك أدخل شركة السيارة.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(txtModel.Text))
                {
                    MessageBox.Show(
                        "من فضلك أدخل الموديل.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (numStartYear.Value > numEndYear.Value)
                {
                    MessageBox.Show(
                        "سنة البداية يجب أن تكون أقل من أو تساوي سنة النهاية.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                compatibility.PartName =
                    txtPart.Text.Trim();

                compatibility.Brand =
                    txtBrand.Text.Trim();

                compatibility.Model =
                    txtModel.Text.Trim();

                compatibility.StartYear =
                    (int)numStartYear.Value;

                compatibility.EndYear =
                    (int)numEndYear.Value;

                ApplyFilters();

                MessageBox.Show(
                    "تم تعديل توافق السيارة بنجاح.",
                    "تم الحفظ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                form.DialogResult =
                    DialogResult.OK;

                form.Close();
            };

            btnCancel.Click += (s, e) =>
            {
                form.DialogResult =
                    DialogResult.Cancel;

                form.Close();
            };

            form.Controls.Add(lblPart);
            form.Controls.Add(txtPart);

            form.Controls.Add(lblBrand);
            form.Controls.Add(txtBrand);

            form.Controls.Add(lblModel);
            form.Controls.Add(txtModel);

            form.Controls.Add(lblStartYear);
            form.Controls.Add(numStartYear);

            form.Controls.Add(lblEndYear);
            form.Controls.Add(numEndYear);

            form.Controls.Add(btnSave);
            form.Controls.Add(btnCancel);

            form.ShowDialog();
        }

        #endregion

        #region Delete

        private void DeleteCompatibility(
            VehicleCompatibilityMock compatibility)
        {
            DialogResult result =
                MessageBox.Show(
                    $"هل أنت متأكد من حذف توافق القطعة:\n\n" +
                    $"{compatibility.PartName}\n" +
                    $"{compatibility.Brand} {compatibility.Model}\n" +
                    $"{compatibility.Years}",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            _allCompatibilities.Remove(compatibility);

            ApplyFilters();

            MessageBox.Show(
                "تم حذف التوافق بنجاح.",
                "تم الحذف",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion

        #region Add Compatibility

        private void sbtnAddCompatability_Click(
            object sender,
            EventArgs e)
        {
            using Form form = new Form();

            form.Text = "إضافة توافق سيارة";
            form.StartPosition =
                FormStartPosition.CenterParent;

            form.Width = 450;
            form.Height = 350;

            form.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            form.MaximizeBox = false;
            form.MinimizeBox = false;

            Label lblPart = new Label
            {
                Text = "اسم القطعة",
                Left = 30,
                Top = 30,
                Width = 100
            };

            TextBox txtPart = new TextBox
            {
                Left = 140,
                Top = 25,
                Width = 240
            };

            Label lblBrand = new Label
            {
                Text = "شركة السيارة",
                Left = 30,
                Top = 80,
                Width = 100
            };

            TextBox txtBrand = new TextBox
            {
                Left = 140,
                Top = 75,
                Width = 240
            };

            Label lblModel = new Label
            {
                Text = "الموديل",
                Left = 30,
                Top = 130,
                Width = 100
            };

            TextBox txtModel = new TextBox
            {
                Left = 140,
                Top = 125,
                Width = 240
            };

            Label lblStartYear = new Label
            {
                Text = "من سنة",
                Left = 30,
                Top = 180,
                Width = 100
            };

            NumericUpDown numStartYear = new NumericUpDown
            {
                Left = 140,
                Top = 175,
                Width = 100,
                Minimum = 1900,
                Maximum = 2100,
                Value = DateTime.Now.Year
            };

            Label lblEndYear = new Label
            {
                Text = "إلى سنة",
                Left = 250,
                Top = 180,
                Width = 70
            };

            NumericUpDown numEndYear = new NumericUpDown
            {
                Left = 320,
                Top = 175,
                Width = 60,
                Minimum = 1900,
                Maximum = 2100,
                Value = DateTime.Now.Year
            };

            Button btnSave = new Button
            {
                Text = "إضافة",
                Left = 140,
                Top = 230,
                Width = 110,
                Height = 35
            };

            Button btnCancel = new Button
            {
                Text = "إلغاء",
                Left = 270,
                Top = 230,
                Width = 110,
                Height = 35
            };

            btnSave.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPart.Text) ||
                    string.IsNullOrWhiteSpace(txtBrand.Text) ||
                    string.IsNullOrWhiteSpace(txtModel.Text))
                {
                    MessageBox.Show(
                        "من فضلك أكمل جميع البيانات.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (numStartYear.Value > numEndYear.Value)
                {
                    MessageBox.Show(
                        "سنة البداية يجب أن تكون أقل من أو تساوي سنة النهاية.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                int newId = _allCompatibilities.Count == 0
                    ? 1
                    : _allCompatibilities.Max(x => x.Id) + 1;

                _allCompatibilities.Add(
                    new VehicleCompatibilityMock
                    {
                        Id = newId,
                        PartName = txtPart.Text.Trim(),
                        Brand = txtBrand.Text.Trim(),
                        Model = txtModel.Text.Trim(),
                        StartYear = (int)numStartYear.Value,
                        EndYear = (int)numEndYear.Value
                    });

                SetupBrandFilter();
                ApplyFilters();

                MessageBox.Show(
                    "تم إضافة توافق السيارة بنجاح.",
                    "تمت الإضافة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                form.DialogResult =
                    DialogResult.OK;

                form.Close();
            };

            btnCancel.Click += (s, e) =>
            {
                form.DialogResult =
                    DialogResult.Cancel;

                form.Close();
            };

            form.Controls.Add(lblPart);
            form.Controls.Add(txtPart);

            form.Controls.Add(lblBrand);
            form.Controls.Add(txtBrand);

            form.Controls.Add(lblModel);
            form.Controls.Add(txtModel);

            form.Controls.Add(lblStartYear);
            form.Controls.Add(numStartYear);

            form.Controls.Add(lblEndYear);
            form.Controls.Add(numEndYear);

            form.Controls.Add(btnSave);
            form.Controls.Add(btnCancel);

            form.ShowDialog();
        }

        #endregion


    }

    public class VehicleCompatibilityMock
    {
        public int Id { get; set; }

        public string PartName { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int StartYear { get; set; }

        public int EndYear { get; set; }

        public string Years =>
            $"{StartYear}–{EndYear}";
    }
}