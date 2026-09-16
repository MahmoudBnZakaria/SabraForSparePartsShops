using System;
using System.Windows.Forms;
using Sabra.LogicLayer;

namespace SabraForSpareParts.Screens
{
    public partial class frmAddPosition : Form
    {
        private readonly clsEmployeeBusiness _employeeBusiness;

        public frmAddPosition(clsEmployeeBusiness employeeBusiness)
        {
            InitializeComponent();
            _employeeBusiness = employeeBusiness ?? new clsEmployeeBusiness();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string positionName = txtPositionName.Text.Trim();

            if (string.IsNullOrWhiteSpace(positionName))
            {
                MessageBox.Show("من فضلك أدخل اسم الوظيفة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPositionName.Focus();
                return;
            }

            var result = _employeeBusiness.AddPosition(positionName);

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Message, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}