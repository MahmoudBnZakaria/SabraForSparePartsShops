using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SabraForSpareParts.Screens
{
    public partial class ucSalaries : SabraUserControl
    {
        private readonly List<EmployeeSalary> _employees =
            new List<EmployeeSalary>();

        public ucSalaries()
        {
            InitializeComponent();

            Load += ucSalaries_Load;
        }

        #region Load

        private void ucSalaries_Load(object sender, EventArgs e)
        {
            LoadSalaries();
        }

        private void LoadSalaries()
        {
            LoadMockData();
            LoadSummary();
            LoadEmployeeCards();
        }

        #endregion

        #region Mock Data

        private void LoadMockData()
        {
            _employees.Clear();

            _employees.AddRange(new List<EmployeeSalary>
            {
                new EmployeeSalary
                {
                    Id = 1,
                    Name = "أحمد محمد",
                    Role = "مدير",
                    BasicSalary = 4000,
                    Advances = 500,
                    IsPaid = false
                },

                new EmployeeSalary
                {
                    Id = 2,
                    Name = "محمد علي",
                    Role = "بائع",
                    BasicSalary = 3500,
                    Advances = 300,
                    IsPaid = true
                },

                new EmployeeSalary
                {
                    Id = 3,
                    Name = "سارة أحمد",
                    Role = "محاسبة",
                    BasicSalary = 4500,
                    Advances = 0,
                    IsPaid = false
                },

                new EmployeeSalary
                {
                    Id = 4,
                    Name = "محمود حسن",
                    Role = "أمين مخزن",
                    BasicSalary = 3200,
                    Advances = 700,
                    IsPaid = true
                },

                new EmployeeSalary
                {
                    Id = 5,
                    Name = "عبدالله محمد",
                    Role = "بائع",
                    BasicSalary = 3500,
                    Advances = 500,
                    IsPaid = false
                },

                new EmployeeSalary
                {
                    Id = 6,
                    Name = "إبراهيم أحمد",
                    Role = "سائق",
                    BasicSalary = 3000,
                    Advances = 250,
                    IsPaid = true
                },

                new EmployeeSalary
                {
                    Id = 7,
                    Name = "خالد حسن",
                    Role = "مندوب مبيعات",
                    BasicSalary = 4200,
                    Advances = 800,
                    IsPaid = false
                },

                new EmployeeSalary
                {
                    Id = 8,
                    Name = "مصطفى محمود",
                    Role = "مخزن",
                    BasicSalary = 3100,
                    Advances = 400,
                    IsPaid = true
                },

                new EmployeeSalary
                {
                    Id = 9,
                    Name = "عمر أحمد",
                    Role = "بائع",
                    BasicSalary = 3400,
                    Advances = 200,
                    IsPaid = false
                },

                new EmployeeSalary
                {
                    Id = 10,
                    Name = "حسن علي",
                    Role = "سائق",
                    BasicSalary = 2800,
                    Advances = 600,
                    IsPaid = true
                },

                new EmployeeSalary
                {
                    Id = 11,
                    Name = "ياسر محمود",
                    Role = "فني صيانة",
                    BasicSalary = 3800,
                    Advances = 300,
                    IsPaid = false
                },

                new EmployeeSalary
                {
                    Id = 12,
                    Name = "طارق حسن",
                    Role = "بائع",
                    BasicSalary = 3600,
                    Advances = 450,
                    IsPaid = false
                },

                new EmployeeSalary
                {
                    Id = 13,
                    Name = "كريم محمد",
                    Role = "مساعد مخزن",
                    BasicSalary = 2900,
                    Advances = 150,
                    IsPaid = true
                },

                new EmployeeSalary
                {
                    Id = 14,
                    Name = "أشرف أحمد",
                    Role = "محاسب",
                    BasicSalary = 5000,
                    Advances = 1000,
                    IsPaid = false
                },

                new EmployeeSalary
                {
                    Id = 15,
                    Name = "حسام محمود",
                    Role = "مندوب",
                    BasicSalary = 4000,
                    Advances = 350,
                    IsPaid = true
                }
            });
        }

        #endregion

        #region Summary

        private void LoadSummary()
        {
            decimal totalSalaries =
                _employees.Sum(x => x.BasicSalary);

            decimal totalAdvances =
                _employees.Sum(x => x.Advances);

            decimal netPaid =
                _employees
                    .Where(x => x.IsPaid)
                    .Sum(x => x.NetSalary);

            int numberOfEmployees =
                _employees.Count;

            lblTotalSalaries.Text =
                $"{totalSalaries:N0} ج";

            lblTotalAdvances.Text =
                $"{totalAdvances:N0} ج";

            lblNetPaid.Text =
                $"{netPaid:N0} ج";

            lblNumberOfEmployees.Text =
                numberOfEmployees.ToString();

            lblMonthAndYear.Text =
                DateTime.Today.ToString("MMMM yyyy");
        }

        #endregion

        #region Employee Cards

        private void LoadEmployeeCards()
        {
            sabraFlowLayoutPanelContainerOfCards.SuspendLayout();
            sabraFlowLayoutPanelContainerOfCards.Controls.Clear();

            // يفضل التأكد من هذه الخصائص (يمكنك ضبطها من واجهة التصميم أيضاً)
            sabraFlowLayoutPanelContainerOfCards.AutoScroll = true;
            sabraFlowLayoutPanelContainerOfCards.WrapContents = true;
            sabraFlowLayoutPanelContainerOfCards.FlowDirection = FlowDirection.RightToLeft; // لضمان الرص من اليمين لليسار عشان العربي

            foreach (EmployeeSalary employee in _employees)
            {
                ucEmployeeSalaryCard card = new ucEmployeeSalaryCard(
                    employee.Name,
                    employee.Role,
                    employee.BasicSalary,
                    employee.Advances,
                    employee.IsPaid
                );

                card.Name = $"salaryCard_{employee.Id}";

                card.Margin = new Padding(25);


                sabraFlowLayoutPanelContainerOfCards.Controls.Add(card);
            }

            sabraFlowLayoutPanelContainerOfCards.ResumeLayout();
        }

        #endregion

        #region Refresh

        public void RefreshSalaries()
        {
            LoadSalaries();
        }

        #endregion

        private void sbtnExportAsExcel_Click(object sender, EventArgs e)
        {
            using DataGridView dgv = CreateSalaryReportGrid();

            var tables = new List<PrintableTable>
    {
        new PrintableTable(dgv, "رواتب الموظفين")
    };

            clsGlobalClass.ExportToExcel(
                tables,
                "كشف رواتب الموظفين",
                $"عدد الموظفين: {_employees.Count} | إجمالي الرواتب: {_employees.Sum(x => x.BasicSalary):N0} ج | إجمالي السلف: {_employees.Sum(x => x.Advances):N0} ج"
            );
        }

        private DataGridView CreateSalaryReportGrid()
        {
            DataGridView dgv = new DataGridView();

            dgv.Columns.Add("Name", "الموظف");
            dgv.Columns.Add("Role", "الوظيفة");
            dgv.Columns.Add("BasicSalary", "الراتب الأساسي");
            dgv.Columns.Add("Advances", "السلف");
            dgv.Columns.Add("NetSalary", "الصافي");
            dgv.Columns.Add("Status", "الحالة");

            foreach (EmployeeSalary employee in _employees)
            {
                dgv.Rows.Add(
                    employee.Name,
                    employee.Role,
                    $"{employee.BasicSalary:N0} ج",
                    $"{employee.Advances:N0} ج",
                    $"{employee.NetSalary:N0} ج",
                    employee.IsPaid ? "مدفوع" : "غير مدفوع"
                );
            }

            return dgv;
        }

    }

    #region Employee Salary Model

    public class EmployeeSalary
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal Advances { get; set; }

        public bool IsPaid { get; set; }

        public decimal NetSalary
        {
            get
            {
                decimal net =
                    BasicSalary - Advances;

                return net < 0 ? 0 : net;
            }
        }
    }

    #endregion
}