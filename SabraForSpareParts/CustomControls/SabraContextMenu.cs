using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SabraForSpareParts.Controls
{
    // =========================================================
    // Sabra Context Menu
    // =========================================================

    public class SabraContextMenu : ContextMenuStrip
    {
        // =====================================================
        // Colors
        // =====================================================

        public Color MenuBackColor { get; set; } =
            Color.White;

        public Color MenuTextColor { get; set; } =
            Color.FromArgb(45, 45, 45);

        public Color HoverColor { get; set; } =
            Color.FromArgb(235, 242, 250);

        public Color PressedColor { get; set; } =
            Color.FromArgb(225, 235, 245);

        public Color BorderColor { get; set; } =
            Color.FromArgb(225, 228, 233);

        public Color AccentColor { get; set; } =
            Color.FromArgb(35, 105, 170);


        // =====================================================
        // Constructor
        // =====================================================

        public SabraContextMenu()
        {
            InitializeMenu();
        }


        // =====================================================
        // Initialize
        // =====================================================

        private void InitializeMenu()
        {
            Font = new Font(
                "Cairo",
                10F,
                FontStyle.Regular);

            RightToLeft = RightToLeft.Yes;

            ShowImageMargin = true;
            ShowCheckMargin = true;

            Padding = new Padding(
                6,
                6,
                6,
                6);

            BackColor = MenuBackColor;
            ForeColor = MenuTextColor;

            Renderer = new SabraMenuRenderer(this);

            AutoSize = true;
        }


        // =====================================================
        // Opening
        // =====================================================

        protected override void OnOpening(
            System.ComponentModel.CancelEventArgs e)
        {
            base.OnOpening(e);

            if (Items.Count == 0)
                e.Cancel = true;
        }


        // =====================================================
        // Add Normal Item
        // =====================================================

        public ToolStripMenuItem AddItem(
            string text,
            EventHandler click = null,
            Image image = null)
        {
            var item = new ToolStripMenuItem(text)
            {
                Font = new Font(
                    "Cairo",
                    10F,
                    FontStyle.Regular),

                Image = image,

                RightToLeft = RightToLeft.Yes
            };

            if (click != null)
                item.Click += click;

            Items.Add(item);

            return item;
        }


        // =====================================================
        // Add Radio Item
        // =====================================================

        public ToolStripMenuItem AddRadioItem(
            string text,
            string groupName,
            bool selected = false,
            EventHandler click = null)
        {
            var item = new ToolStripMenuItem(text)
            {
                Font = new Font(
                    "Cairo",
                    10F,
                    FontStyle.Regular),

                CheckOnClick = true,

                Checked = selected,

                Tag = groupName,

                RightToLeft = RightToLeft.Yes
            };

            item.Click += (s, e) =>
            {
                SelectRadioItem(
                    item,
                    groupName);

                click?.Invoke(s, e);
            };

            Items.Add(item);

            return item;
        }


        // =====================================================
        // Select Radio
        // =====================================================

        private void SelectRadioItem(
            ToolStripMenuItem selectedItem,
            string groupName)
        {
            foreach (ToolStripItem toolItem in Items)
            {
                if (toolItem is ToolStripMenuItem item &&
                    item.Tag?.ToString() == groupName)
                {
                    item.Checked =
                        item == selectedItem;
                }
            }
        }


        // =====================================================
        // Separator
        // =====================================================

        public void AddSeparator()
        {
            Items.Add(
                new ToolStripSeparator());
        }
    }


    // =========================================================
    // Sabra Menu Renderer
    // =========================================================

    public class SabraMenuRenderer :
        ToolStripProfessionalRenderer
    {
        private readonly SabraContextMenu _menu;


        // =====================================================
        // Constructor
        // =====================================================

        public SabraMenuRenderer(
            SabraContextMenu menu)
            : base(new SabraColorTable(menu))
        {
            _menu = menu;
        }


        // =====================================================
        // Background
        // =====================================================

        protected override void OnRenderToolStripBackground(
            ToolStripRenderEventArgs e)
        {
            using (SolidBrush brush =
                   new SolidBrush(_menu.MenuBackColor))
            {
                e.Graphics.FillRectangle(
                    brush,
                    e.AffectedBounds);
            }
        }


        // =====================================================
        // Item Background
        // =====================================================

        protected override void OnRenderMenuItemBackground(
            ToolStripItemRenderEventArgs e)
        {
            if (e.Item is not ToolStripMenuItem)
                return;


            Rectangle rect = new Rectangle(
                4,
                2,
                e.Item.Width - 8,
                e.Item.Height - 4);


            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;


            // ================================================
            // Pressed
            // ================================================

            if (e.Item.Pressed &&
                e.Item.Enabled)
            {
                using (GraphicsPath path =
                       CreateRoundedRectangle(
                           rect,
                           6))
                using (SolidBrush brush =
                       new SolidBrush(
                           _menu.PressedColor))
                {
                    e.Graphics.FillPath(
                        brush,
                        path);
                }

                return;
            }


            // ================================================
            // Hover
            // ================================================

            if (e.Item.Selected &&
                e.Item.Enabled)
            {
                using (GraphicsPath path =
                       CreateRoundedRectangle(
                           rect,
                           6))
                using (SolidBrush brush =
                       new SolidBrush(
                           _menu.HoverColor))
                {
                    e.Graphics.FillPath(
                        brush,
                        path);
                }

                return;
            }
        }


        // =====================================================
        // Text
        // =====================================================

        protected override void OnRenderItemText(
            ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor =
                e.Item.Enabled
                    ? _menu.MenuTextColor
                    : Color.LightGray;

            e.TextFont =
                new Font(
                    "Cairo",
                    10F,
                    FontStyle.Regular);

            base.OnRenderItemText(e);
        }


        // =====================================================
        // Separator
        // =====================================================

        protected override void OnRenderSeparator(
            ToolStripSeparatorRenderEventArgs e)
        {
            int y =
                e.Item.Height / 2;

            using (Pen pen =
                   new Pen(
                       _menu.BorderColor))
            {
                e.Graphics.DrawLine(
                    pen,
                    12,
                    y,
                    e.Item.Width - 12,
                    y);
            }
        }


        // =====================================================
        // Radio / Check
        // =====================================================

        protected override void OnRenderItemCheck(
            ToolStripItemImageRenderEventArgs e)
        {
            if (e.Item is not ToolStripMenuItem item)
                return;


            Rectangle rect =
                new Rectangle(
                    e.ImageRectangle.X + 4,
                    e.ImageRectangle.Y + 4,
                    16,
                    16);


            DrawRadio(
                e.Graphics,
                rect,
                item.Checked,
                item.Enabled);
        }


        // =====================================================
        // Draw Radio
        // =====================================================

        private void DrawRadio(
            Graphics g,
            Rectangle rect,
            bool selected,
            bool enabled)
        {
            g.SmoothingMode =
                SmoothingMode.AntiAlias;


            Color borderColor =
                enabled
                    ? _menu.AccentColor
                    : Color.LightGray;


            // ================================================
            // Outer Circle
            // ================================================

            using (Pen pen =
                   new Pen(
                       borderColor,
                       1.5f))
            {
                g.DrawEllipse(
                    pen,
                    rect);
            }


            // ================================================
            // Selected
            // ================================================

            if (selected)
            {
                Rectangle inner =
                    new Rectangle(
                        rect.X + 4,
                        rect.Y + 4,
                        rect.Width - 8,
                        rect.Height - 8);


                using (SolidBrush brush =
                       new SolidBrush(
                           _menu.AccentColor))
                {
                    g.FillEllipse(
                        brush,
                        inner);
                }
            }
        }


        // =====================================================
        // Rounded Rectangle
        // =====================================================

        private GraphicsPath CreateRoundedRectangle(
            Rectangle rect,
            int radius)
        {
            GraphicsPath path =
                new GraphicsPath();


            int diameter =
                radius * 2;


            path.AddArc(
                rect.X,
                rect.Y,
                diameter,
                diameter,
                180,
                90);


            path.AddArc(
                rect.Right - diameter,
                rect.Y,
                diameter,
                diameter,
                270,
                90);


            path.AddArc(
                rect.Right - diameter,
                rect.Bottom - diameter,
                diameter,
                diameter,
                0,
                90);


            path.AddArc(
                rect.X,
                rect.Bottom - diameter,
                diameter,
                diameter,
                90,
                90);


            path.CloseFigure();


            return path;
        }
    }


    // =========================================================
    // Color Table
    // =========================================================

    public class SabraColorTable :
        ProfessionalColorTable
    {
        private readonly SabraContextMenu _menu;


        public SabraColorTable(
            SabraContextMenu menu)
        {
            _menu = menu;
        }


        public override Color ToolStripDropDownBackground =>
            _menu.MenuBackColor;


        public override Color MenuBorder =>
            _menu.BorderColor;


        public override Color MenuItemBorder =>
            Color.Transparent;


        public override Color MenuItemSelected =>
            _menu.HoverColor;


        public override Color MenuItemSelectedGradientBegin =>
            _menu.HoverColor;


        public override Color MenuItemSelectedGradientEnd =>
            _menu.HoverColor;


        public override Color ToolStripBorder =>
            _menu.BorderColor;
    }
}