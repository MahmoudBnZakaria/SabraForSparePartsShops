namespace SabraForSpareParts.Screens.InventoryAlerts
{
    partial class ucInventoryAlertRow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sbtnPurchaseOrder = new SabraButton();
            icnDecreasedParts = new FontAwesome.Sharp.IconPictureBox();
            lblInventoryInfo = new SabraLabel();
            slblAlertRowTiltle = new SabraLabel();
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).BeginInit();
            SuspendLayout();
            // 
            // sbtnPurchaseOrder
            // 
            sbtnPurchaseOrder.BackColor = Color.RoyalBlue;
            sbtnPurchaseOrder.BorderColor = Color.DodgerBlue;
            sbtnPurchaseOrder.BorderRadius = 20;
            sbtnPurchaseOrder.BorderSize = 0;
            sbtnPurchaseOrder.FlatAppearance.BorderSize = 0;
            sbtnPurchaseOrder.FlatStyle = FlatStyle.Flat;
            sbtnPurchaseOrder.Font = new Font("Cairo", 10F, FontStyle.Bold);
            sbtnPurchaseOrder.ForeColor = Color.White;
            sbtnPurchaseOrder.HoverColor = Color.CornflowerBlue;
            sbtnPurchaseOrder.IconChar = FontAwesome.Sharp.IconChar.MoneyBill1;
            sbtnPurchaseOrder.IconColor = Color.Beige;
            sbtnPurchaseOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnPurchaseOrder.IconSize = 35;
            sbtnPurchaseOrder.ImageAlign = ContentAlignment.MiddleRight;
            sbtnPurchaseOrder.Location = new Point(21, 19);
            sbtnPurchaseOrder.Name = "sbtnPurchaseOrder";
            sbtnPurchaseOrder.NormalColor = Color.RoyalBlue;
            sbtnPurchaseOrder.Padding = new Padding(10, 0, 10, 0);
            sbtnPurchaseOrder.Size = new Size(153, 55);
            sbtnPurchaseOrder.TabIndex = 10;
            sbtnPurchaseOrder.Text = "طلب شراء";
            sbtnPurchaseOrder.TextAlign = ContentAlignment.MiddleLeft;
            sbtnPurchaseOrder.UseVisualStyleBackColor = false;
            // 
            // icnDecreasedParts
            // 
            icnDecreasedParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icnDecreasedParts.BackColor = Color.FromArgb(254, 242, 242);
            icnDecreasedParts.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            icnDecreasedParts.ForeColor = Color.FromArgb(232, 18, 36);
            icnDecreasedParts.IconChar = FontAwesome.Sharp.IconChar.Warning;
            icnDecreasedParts.IconColor = Color.FromArgb(232, 18, 36);
            icnDecreasedParts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icnDecreasedParts.IconSize = 55;
            icnDecreasedParts.Location = new Point(1527, 20);
            icnDecreasedParts.Name = "icnDecreasedParts";
            icnDecreasedParts.Size = new Size(60, 55);
            icnDecreasedParts.SizeMode = PictureBoxSizeMode.Zoom;
            icnDecreasedParts.TabIndex = 11;
            icnDecreasedParts.TabStop = false;
            // 
            // lblInventoryInfo
            // 
            lblInventoryInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInventoryInfo.BackColor = Color.Transparent;
            lblInventoryInfo.BorderColor = Color.Transparent;
            lblInventoryInfo.BorderRadius = 0;
            lblInventoryInfo.BorderSize = 0;
            lblInventoryInfo.Font = new Font("Cairo", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInventoryInfo.ForeColor = Color.FromArgb(71, 85, 105);
            lblInventoryInfo.Location = new Point(1174, 51);
            lblInventoryInfo.Name = "lblInventoryInfo";
            lblInventoryInfo.Size = new Size(316, 24);
            lblInventoryInfo.TabIndex = 12;
            lblInventoryInfo.Text = "المخزون الحالي: 0 | الحد الأدني: 20";
            lblInventoryInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // slblAlertRowTiltle
            // 
            slblAlertRowTiltle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            slblAlertRowTiltle.BackColor = Color.Transparent;
            slblAlertRowTiltle.BorderColor = Color.Black;
            slblAlertRowTiltle.BorderRadius = 8;
            slblAlertRowTiltle.BorderSize = 0;
            slblAlertRowTiltle.Font = new Font("Cairo", 10F);
            slblAlertRowTiltle.ForeColor = Color.Black;
            slblAlertRowTiltle.Location = new Point(1116, 19);
            slblAlertRowTiltle.Margin = new Padding(0);
            slblAlertRowTiltle.Name = "slblAlertRowTiltle";
            slblAlertRowTiltle.RightToLeft = RightToLeft.No;
            slblAlertRowTiltle.Size = new Size(374, 32);
            slblAlertRowTiltle.TabIndex = 13;
            slblAlertRowTiltle.Text = "بوجية NGK -  مخزون صفر";
            slblAlertRowTiltle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ucInventoryAlertRow
            // 
            AutoScaleDimensions = new SizeF(9F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScrollMinSize = new Size(0, 0);
            BackColor = Color.White;
            BorderRadius = 20;
            Controls.Add(slblAlertRowTiltle);
            Controls.Add(lblInventoryInfo);
            Controls.Add(icnDecreasedParts);
            Controls.Add(sbtnPurchaseOrder);
            MinimumSize = new Size(0, 0);
            Name = "ucInventoryAlertRow";
            Size = new Size(1600, 105);
            ((System.ComponentModel.ISupportInitialize)icnDecreasedParts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SabraButton sbtnPurchaseOrder;
        private FontAwesome.Sharp.IconPictureBox icnDecreasedParts;
        private SabraLabel lblInventoryInfo;
        private SabraLabel slblAlertRowTiltle;
    }
}
