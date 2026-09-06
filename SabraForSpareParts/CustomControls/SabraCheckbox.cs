using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabraForSpareParts
{
    public class SabraCheckbox : CheckBox
    {
        public SabraCheckbox()
        {
            InitializeSabraCheckbox();
        }

        private void InitializeSabraCheckbox()
        {
            // Basic Settings
            AutoSize = true;
            BackColor = Color.Transparent;
            ForeColor = Color.White;

            // Font
            Font = new Font(
                "Cairo",
                10.2F,
                FontStyle.Regular,
                GraphicsUnit.Point,
                0
            );

            // Appearance
            FlatStyle = FlatStyle.Standard;

            // Layout
            RightToLeft = RightToLeft.Yes;

            // Default
            Checked = false;
            TabStop = true;
        }
    }
}