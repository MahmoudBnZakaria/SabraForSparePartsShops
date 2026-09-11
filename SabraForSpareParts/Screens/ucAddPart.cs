using Sabra.DataLayer.Models;
using Sabra.LogicLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace SabraForSpareParts.Screens
{
    public partial class ucAddPart : SabraUserControl
    {

        private readonly clsInventoryBusiness _inventoryBusiness =
            new clsInventoryBusiness();


        public ucAddPart()
        {
            InitializeComponent();

            ConfigureControls();
            LoadLookups();
            WireEvents();
        }



        private void ConfigureControls()
        {
            // الأسعار
            stbxPurchasePrice.KeyPress += DecimalTextBox_KeyPress;
            stbxSellPrice.KeyPress += DecimalTextBox_KeyPress;
            stbxProfitPercentage.KeyPress += DecimalTextBox_KeyPress;

            // الكميات
            stbxCurrentAmount.KeyPress += IntegerTextBox_KeyPress;
            stbxMiniAmount.KeyPress += IntegerTextBox_KeyPress;

            // منع إدخال مسافات زائدة
            stxbxParcode.Leave += TextBox_Trim;
            stxbxPartName.Leave += TextBox_Trim;
            stbxAlternativePart.Leave += TextBox_Trim;
            stbxTechnicalNum.Leave += TextBox_Trim;

            // البداية
            stbxSellPrice.ReadOnly = true;
        }


        private void WireEvents()
        {
            sbtnSave.Click += sbtnSave_Click;

            sbtnSaveAndAdd.Click += sbtnSaveAndAdd_Click;

            stbnCancel.Click += stbnCancel_Click;


            addBrand.Click += addBrand_Click;

            addClassification.Click += addClassification_Click;

            stbxPurchasePrice.TextChanged += PriceCalculation_TextChanged;
            stbxProfitPercentage.TextChanged += PriceCalculation_TextChanged;
        }


        private void LoadLookups()
        {
            LoadSuppliers();
            LoadCategories();
            LoadBrands();
            LoadUnits();
        }


        private void LoadSuppliers()
        {
            try
            {
                // لازم نستخدم Business الخاص بالموردين
                var business = new clsSupplierBusiness();

                var result = business.GetAll();

                if (!result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                scbxSupplier.DataSource = result.Data;
                scbxSupplier.DisplayMember = "SupplierName";
                scbxSupplier.ValueMember = "SupplierID";
                scbxSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء تحميل الموردين:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void LoadCategories()
        {
            try
            {
                var result = _inventoryBusiness.GetCategories();

                if (!result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                scbxClassification.DataSource = result.Data;
                scbxClassification.DisplayMember = "CategoryName";
                scbxClassification.ValueMember = "CategoryID";
                scbxClassification.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء تحميل التصنيفات:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void LoadBrands()
        {
            try
            {
                var result = _inventoryBusiness.GetBrands();

                if (!result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                scbxBrand.DataSource = result.Data;
                scbxBrand.DisplayMember = "BrandName";
                scbxBrand.ValueMember = "BrandID";
                scbxBrand.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء تحميل الماركات:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void LoadUnits()
        {
            try
            {
                var result = _inventoryBusiness.GetUnits();

                if (!result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                scbxUnitOfSale.DataSource = result.Data;
                scbxUnitOfSale.DisplayMember = "UnitName";
                scbxUnitOfSale.ValueMember = "UnitID";
                scbxUnitOfSale.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء تحميل وحدات البيع:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private decimal GetDecimal(SabraTextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return 0;

            return decimal.TryParse(
                textBox.Text.Trim(),
                out decimal value)
                ? value
                : 0;
        }


        private int GetInteger(SabraTextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return 0;

            return int.TryParse(
                textBox.Text.Trim(),
                out int value)
                ? value
                : 0;
        }



        private void PriceCalculation_TextChanged(
            object sender,
            EventArgs e)
        {
            decimal purchasePrice = GetDecimal(stbxPurchasePrice);
            decimal profitPercentage = GetDecimal(stbxProfitPercentage);

            if (purchasePrice <= 0 || profitPercentage <= 0)
            {
                stbxSellPrice.Text = "0";
                return;
            }

            decimal sellingPrice =
                _inventoryBusiness.CalcSellingPrice(
                    purchasePrice,
                    profitPercentage);

            stbxSellPrice.Text = sellingPrice.ToString("0.00");
        }



        private InventoryItem BuildInventoryItem()
        {
            return new InventoryItem
            {
                Barcode = GetText(stxbxParcode),

                PartName = GetText(stxbxPartName),

                TechnicalNumber = GetText(stbxTechnicalNum),

                CategoryID = GetSelectedID(scbxClassification),

                BrandID = GetSelectedID(scbxBrand),

                UnitID = GetSelectedID(scbxUnitOfSale),

                SupplierID = GetSelectedID(scbxSupplier),

                PurchasePrice = GetDecimal(stbxPurchasePrice),

                MarkupPercent = GetDecimal(stbxProfitPercentage),

                SellingPrice = GetDecimal(stbxSellPrice),

                CurrentStock = GetInteger(stbxCurrentAmount),

                MinLimit = GetInteger(stbxMiniAmount),

                CrossRefID = GetAlternativePartID(),

                Notes = GetText(stbxNotes)
            };
        }



        private string GetText(SabraTextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text)
                ? null
                : textBox.Text.Trim();
        }


        private int GetSelectedID(SabraComboBox comboBox)
        {
            if (comboBox.SelectedIndex < 0 ||
                comboBox.SelectedValue == null)
            {
                return 0;
            }

            if (int.TryParse(
                comboBox.SelectedValue.ToString(),
                out int id))
            {
                return id;
            }

            return 0;
        }


        private int? GetAlternativePartID()
        {
            if (string.IsNullOrWhiteSpace(stbxAlternativePart.Text))
                return null;

            if (int.TryParse(
                stbxAlternativePart.Text.Trim(),
                out int id) &&
                id > 0)
            {
                return id;
            }

            return null;
        }



        private void SavePart(bool clearAfterSave)
        {
            string ErrorMessage = "";
            try
            {
                InventoryItem item = BuildInventoryItem();

                var result = _inventoryBusiness.AddPart(item);
                ErrorMessage = result.Message;
                if (!result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show(
                    result.Message,
                    "تم",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (clearAfterSave)
                {
                    ClearForm();
                    stxbxPartName.Focus();
                }
                else
                {
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء إضافة القطعة:\n{ErrorMessage }",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void sbtnSave_Click(
            object sender,
            EventArgs e)
        {
            SavePart(false);
        }



        private void sbtnSaveAndAdd_Click(
            object sender,
            EventArgs e)
        {
            SavePart(true);
        }



        private void stbnCancel_Click(
            object sender,
            EventArgs e)
        {
            ClearForm();
        }



        private void ClearForm()
        {
            stxbxParcode.Clear();
            stxbxPartName.Clear();
            stbxTechnicalNum.Clear();

            stbxPurchasePrice.Clear();
            stbxProfitPercentage.Clear();
            stbxSellPrice.Clear();

            stbxCurrentAmount.Clear();
            stbxMiniAmount.Clear();

            stbxAlternativePart.Clear();
            stbxNotes.Clear();

            scbxSupplier.SelectedIndex = -1;
            scbxClassification.SelectedIndex = -1;
            scbxBrand.SelectedIndex = -1;
            scbxUnitOfSale.SelectedIndex = -1;

            stxbxPartName.Focus();
        }



        private void addBrand_Click(
            object sender,
            EventArgs e)
        {
            using (Form frm = new Form())
            {
                frm.Text = "إضافة ماركة";
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Size = new System.Drawing.Size(400, 180);

                TextBox txtName = new TextBox
                {
                    Dock = DockStyle.Top,
                    Margin = new Padding(10)
                };

                Button btnSave = new Button
                {
                    Text = "حفظ",
                    Dock = DockStyle.Bottom,
                    Height = 40
                };

                frm.Controls.Add(txtName);
                frm.Controls.Add(btnSave);

                btnSave.Click += (s, ev) =>
                {
                    var result =
                        _inventoryBusiness.AddBrand(txtName.Text);

                    if (!result.Success)
                    {
                        MessageBox.Show(
                            result.Message,
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    frm.DialogResult = DialogResult.OK;
                    frm.Close();
                };

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadBrands();
                }
            }
        }



        private void addClassification_Click(
            object sender,
            EventArgs e)
        {
            using (Form frm = new Form())
            {
                frm.Text = "إضافة تصنيف";
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Size = new System.Drawing.Size(400, 180);

                TextBox txtName = new TextBox
                {
                    Dock = DockStyle.Top,
                    Margin = new Padding(10)
                };

                Button btnSave = new Button
                {
                    Text = "حفظ",
                    Dock = DockStyle.Bottom,
                    Height = 40
                };

                frm.Controls.Add(txtName);
                frm.Controls.Add(btnSave);

                btnSave.Click += (s, ev) =>
                {
                    var result =
                        _inventoryBusiness.AddCategory(txtName.Text);

                    if (!result.Success)
                    {
                        MessageBox.Show(
                            result.Message,
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    frm.DialogResult = DialogResult.OK;
                    frm.Close();
                };

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
        }


        private void TextBox_Trim(
            object sender,
            EventArgs e)
        {
            if (sender is SabraTextBox textBox)
                textBox.Text = textBox.Text.Trim();
        }

        private void DecimalTextBox_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.' &&
                !((SabraTextBox)sender).Text.Contains("."))
            {
                return;
            }

            e.Handled = true;
        }



        private void IntegerTextBox_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void sbtnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }


    }
}