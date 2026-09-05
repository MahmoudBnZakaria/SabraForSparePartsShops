using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabraForSpareParts
{

    public class SabraTableLayoutPanel : TableLayoutPanel
    {
        #region Fields

        private int columns = 12;
        private int rows = 3;

        #endregion

        #region Properties

        [Category("Sabra Layout")]
        [DefaultValue(12)]
        public int Columns
        {
            get => columns;
            set
            {
                if (value <= 0) return;

                columns = value;
                BuildColumns();
            }
        }

        [Category("Sabra Layout")]
        [DefaultValue(1)]
        public int Rows
        {
            get => rows;
            set
            {
                if (value <= 0) return;

                rows = value;
                BuildRows();
            }
        }

        #endregion

        #region Constructor

        public SabraTableLayoutPanel()
        {
            SuspendLayout();

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);

            DoubleBuffered = true;

            // Appearance
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(40, 40, 40);

            // Layout
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            Padding = new Padding(30);

            // Behavior
            AutoScroll = true;
            AutoSize = false;
            GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            // RTL
            RightToLeft = RightToLeft.Yes;

            // Default Grid
            BuildColumns();
            BuildRows();

            ResumeLayout(false);
        }

        #endregion

        #region Private Methods

        private void BuildColumns()
        {
            SuspendLayout();

            ColumnCount = columns;
            ColumnStyles.Clear();

            float percent = 100f / columns;

            for (int i = 0; i < columns; i++)
            {
                ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, percent));
            }

            ResumeLayout();
        }

        private void BuildRows()
        {
            SuspendLayout();

            RowCount = rows;
            RowStyles.Clear();

            float percent = 100f / rows;

            for (int i = 0; i < rows; i++)
            {
                RowStyles.Add(
                    new RowStyle(SizeType.Percent, percent));
            }

            ResumeLayout();
        }

        #endregion
    }

}
