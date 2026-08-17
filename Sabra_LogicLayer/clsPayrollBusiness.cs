using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    public class clsPayrollBusiness
    {
        private readonly clsPayrollDAL _payrollDAL = new clsPayrollDAL();
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();
        private readonly clsStaffWalletDAL _walletDAL = new clsStaffWalletDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        public OperationResult<List<Payroll>> GetAll(string monthYear = null, int? employeeID = null)
            => OperationResult<List<Payroll>>.Ok(_payrollDAL.GetAll(monthYear, employeeID));

        public OperationResult ProcessSalary(Payroll payroll, int paymentMethodID) {
            if (!clsAppSession.IsLoggedIn)
                return OperationResult.Fail("يجب تسجيل الدخول أولا");
            if(payroll.EmployeeID <= 0)
                return OperationResult.Fail("يجب اختيار الموظف");
            if(string.IsNullOrWhiteSpace(payroll.MonthYear))
                return OperationResult.Fail("الشهر والسنة مطلوبان (مثال: 2025-01).");
            if(payroll.AmountPaid <= 0)
                return OperationResult.Fail("المبلغ المدفوع يجب أن يكون أكبر من صفر.");
            if (payroll.Deductions < 0 || payroll.Bonuses < 0)
                return OperationResult.Fail("الخصومات والحوافز لا يمكن أن تكون سالبة.");
            if(_payrollDAL.MonthYearExists(payroll.EmployeeID, payroll.MonthYear))
                return OperationResult.Fail($"راتب هذا الموظف عن شهر {payroll.MonthYear} تم صرفه مسبقاً.");

            payroll.PaymentDate = DateTime.Today;
            int payrollID = _payrollDAL.Add(payroll);

            var methods = _lookupDAL.GetAllPaymentMethods();
            var method = methods.FirstOrDefault(m => m.PaymentMethodID == paymentMethodID);

            if (method?.MethodName == "محفظة إلكترونية") { 
                var wallet = _walletDAL.GetByEmployee(payroll.EmployeeID);
                if(wallet != null)
                    _walletDAL.UpdateBalance(payroll.EmployeeID, wallet.CurrentBalance + payroll.AmountPaid);
            }
            var txTypes = _lookupDAL.GetAllTransactionTypes();
            var outType = txTypes.First(t => t.TypeName == "صادر");

            decimal bal = _treasuryDAL.GetCurrentBalance();
            _treasuryDAL.Add(new TreasuryLog
            {
                TransactionTypeID = outType.TransactionTypeID,
                PaymentMethodID = paymentMethodID,
                Amount = payroll.AmountPaid,
                PayrollID = payrollID,
                EmployeeID = payroll.EmployeeID,
                ActionDate = DateTime.Now,
                BalanceAfter = bal - payroll.AmountPaid,
                Notes = $"راتب شهر {payroll.MonthYear} — {payroll.Notes}"
            });
            return OperationResult.Ok("تم صرف الراتب بنجاح.", payrollID);
        }

        public OperationResult<List<Payroll>> PrepareMonthlyPayroll(string monthYear) {
            var employees = _employeeDAL.GetAll(ActiveOnly: true);
            var list = employees.Select(emp => new Payroll {
                EmployeeID = emp.EmployeeID,
                EmployeeName = emp.FullName,
                AmountPaid = emp.BasicSalary,
                Deductions = 0,
                Bonuses = 0,
                MonthYear = monthYear,
                PaymentDate = DateTime.Today
            }).ToList();
            return OperationResult<List<Payroll>>.Ok(list);
        }
    }
}
