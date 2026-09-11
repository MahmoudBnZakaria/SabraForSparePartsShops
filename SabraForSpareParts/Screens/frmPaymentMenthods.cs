using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens 
{
    public class PaymentMethodItem
    {
        public int Payment_Method_ID { get; set; }
        public string Method_Name { get; set; }
    }

    public class frmSelectPaymentMethod : Form
    {
        public int SelectedPaymentMethodId { get; private set; }
        private ComboBox cmbMethods;

        public frmSelectPaymentMethod()
        {
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "اختر طريقة الدفع";
            this.Size = new System.Drawing.Size(320, 190);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            Label lbl = new Label() { Text = "طريقة الدفع:", Left = 20, Top = 20, AutoSize = true };

            cmbMethods = new ComboBox()
            {
                Left = 20,
                Top = 45,
                Width = 260,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // قائمة طرق الدفع المطلوب عرضها
            var methodsList = new List<PaymentMethodItem>
            {
                new PaymentMethodItem { Payment_Method_ID = 1, Method_Name = "كاش" },
                new PaymentMethodItem { Payment_Method_ID = 2, Method_Name = "تحويل بنكي" },
                new PaymentMethodItem { Payment_Method_ID = 3, Method_Name = "فيزا" },
                new PaymentMethodItem { Payment_Method_ID = 4, Method_Name = "محفظة إلكترونية" }
            };

            cmbMethods.DataSource = methodsList;
            cmbMethods.DisplayMember = "Method_Name";
            cmbMethods.ValueMember = "Payment_Method_ID";

            Button btnOk = new Button() { Text = "تأكيد", Left = 115, Top = 95, Width = 80, Height = 30, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "إلغاء", Left = 200, Top = 95, Width = 80, Height =30, DialogResult = DialogResult.Cancel };

            btnOk.Click += (s, e) =>
            {
                if (cmbMethods.SelectedValue != null)
                {
                    SelectedPaymentMethodId = (int)cmbMethods.SelectedValue;
                }
            };

            this.Controls.Add(lbl);
            this.Controls.Add(cmbMethods);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }
    }
}