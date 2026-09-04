using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucItemsRow : UserControl
    {
        public ucItemsRow()
        {
            InitializeComponent();

            this.Cursor = Cursors.Hand;

            this.MouseEnter += ucBestSellingItemsRow_MouseEnter;
            this.MouseLeave += ucBestSellingItemsRow_MouseLeave;

            lblItem.MouseEnter += Child_MouseEnter;
            lblNumberOfSelledUnites.MouseEnter += Child_MouseEnter;

            lblItem.MouseLeave += Child_MouseLeave;
            lblNumberOfSelledUnites.MouseLeave += Child_MouseLeave;

            this.Click += Row_Click;
            lblItem.Click += Row_Click;
            lblNumberOfSelledUnites.Click += Row_Click;
        }

        #region Properties

        private string _itemName = "فلتر زيت تويوتا";

        [Category("Best Selling Item")]
        [Description("اسم الصنف")]
        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                lblItem.Text = value;
            }
        }

        private int _soldUnits;

        [Category("Best Selling Item")]
        [Description("عدد الوحدات المباعة")]
        public int SoldUnits
        {
            get => _soldUnits;
            set
            {
                _soldUnits = value;
                lblNumberOfSelledUnites.Text = $"{value:N0} وحدة";
            }
        }

        private string _soldUnitsText;

        [Category("Best Selling Item")]
        [Description("النص المعروض لعدد الوحدات")]
        public string SoldUnitsText
        {
            get => _soldUnitsText;
            set
            {
                _soldUnitsText = value;
                lblNumberOfSelledUnites.Text = value;
            }
        }

        #endregion

        #region Styling

        private Color _hoverBackColor =
            Color.FromArgb(248, 250, 252);

        private Color _normalBackColor =
            Color.White;

        [Category("Appearance")]
        [Description("لون الخلفية عند مرور الماوس")]
        public Color HoverBackColor
        {
            get => _hoverBackColor;
            set => _hoverBackColor = value;
        }

        [Category("Appearance")]
        [Description("لون الخلفية الطبيعي")]
        public Color NormalBackColor
        {
            get => _normalBackColor;
            set
            {
                _normalBackColor = value;
                this.BackColor = value;
            }
        }

        #endregion

        #region Set Data

        public void SetData(string itemName, int soldUnits)
        {
            ItemName = itemName;
            SoldUnits = soldUnits;
        }

        public void SetData(string itemName, string soldUnitsText)
        {
            ItemName = itemName;
            SoldUnitsText = soldUnitsText;
        }

        #endregion

        #region Hover

        private void ucBestSellingItemsRow_MouseEnter(
            object sender,
            EventArgs e)
        {
            SetHoverState(true);
        }

        private void ucBestSellingItemsRow_MouseLeave(
            object sender,
            EventArgs e)
        {
            SetHoverState(false);
        }

        private void Child_MouseEnter(
            object sender,
            EventArgs e)
        {
            SetHoverState(true);
        }

        private void Child_MouseLeave(
            object sender,
            EventArgs e)
        {
            Point mousePosition = PointToClient(
                Cursor.Position
            );

            if (!ClientRectangle.Contains(mousePosition))
            {
                SetHoverState(false);
            }
        }

        private void SetHoverState(bool isHover)
        {
            if (isHover)
            {
                this.BackColor = HoverBackColor;

                lblItem.BackColor = HoverBackColor;
                lblNumberOfSelledUnites.BackColor = HoverBackColor;
            }
            else
            {
                this.BackColor = NormalBackColor;

                lblItem.BackColor = Color.Transparent;
                lblNumberOfSelledUnites.BackColor = Color.Transparent;
            }
        }

        #endregion

        #region Click

        public event EventHandler RowClicked;

        private void Row_Click(
            object sender,
            EventArgs e)
        {
            RowClicked?.Invoke(this, e);
        }

        #endregion

        #region Helpers

        public override string ToString()
        {
            return $"{ItemName} - {SoldUnits:N0} وحدة";
        }

        #endregion
    }
}