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
    public class clsPayrollBusiness : clsBusinessBase
    {
        private readonly clsPayrollDAL _payrollDAL = new clsPayrollDAL();
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();
        private readonly clsStaffWalletDAL _walletDAL = new clsStaffWalletDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();

        public OperationResult<List<Payroll>> GetAll(string monthYear = null, int? employeeID = null) => Execute(()
            => OperationResult<List<Payroll>>.Ok(_payrollDAL.GetAll(monthYear, employeeID)));

        /// <summary>
        /// صرف مرتب. الـ SP بتمنع التكرار لنفس الشهر، بتسجل المرتب، وبتخصم الصافي
        /// من الخزنة. الكود هنا بيتحقق بس، وبعد النجاح بيضيف للمحفظة لو الدفع محفظة.
        /// </summary>
        public OperationResult ProcessSalary(Payroll payroll, int paymentMethodID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Payroll, "صرف المرتبات");
            if (guard != null) return guard;

            if (payroll == null) return OperationResult.Fail("بيانات المرتب غير صحيحة.");
            if (payroll.EmployeeID <= 0) return OperationResult.Fail("يجب اختيار الموظف.");
            if (!IsValidMonthYear(payroll.MonthYear))
                return OperationResult.Fail("صيغة الشهر لازم تكون yyyy-MM (مثال: 2026-01).");
            if (payroll.AmountPaid <= 0) return OperationResult.Fail("المبلغ المدفوع يجب أن يكون أكبر من صفر.");
            if (payroll.Deductions < 0 || payroll.Bonuses < 0)
                return OperationResult.Fail("الخصومات والحوافز لا يمكن أن تكون سالبة.");
            if (!clsLookupCache.PaymentMethodExists(paymentMethodID))
                return OperationResult.Fail("يجب اختيار طريقة دفع صحيحة.");

            var employee = _employeeDAL.GetByID(payroll.EmployeeID);
            if (employee == null) return OperationResult.Fail("الموظف غير موجود.");
            if (!employee.IsActive) return OperationResult.Fail("الموظف ده موقوف.");

            decimal net = payroll.AmountPaid - payroll.Deductions + payroll.Bonuses;
            if (net < 0) return OperationResult.Fail("الخصومات أكبر من المرتب والحوافز.");

            if (_payrollDAL.MonthYearExists(payroll.EmployeeID, payroll.MonthYear))
                return OperationResult.Fail($"مرتب شهر {payroll.MonthYear} للموظف ده اتصرف قبل كده.");

            decimal balance = _treasuryDAL.GetCurrentBalance();
            if (net > balance)
                return OperationResult.Fail($"رصيد الخزنة ({balance:N2} جنيه) لا يكفي لصرف صافي المرتب ({net:N2} جنيه).");

            payroll.PaymentDate = payroll.PaymentDate == default ? DateTime.Today : payroll.PaymentDate;
            payroll.Notes = string.IsNullOrWhiteSpace(payroll.Notes) ? null : payroll.Notes.Trim();

            int payrollID = _payrollDAL.Add(
                payroll,
                paymentMethodID,
                clsLookupCache.TransactionTypeID(clsSystemNames.TxPayroll),
                clsAppSession.UserID);

            // لو الصرف على محفظة الموظف، بنضيف الصافي في المحفظة بعد ما الخزنة خصمته
            if (clsLookupCache.PaymentMethodName(paymentMethodID) == clsSystemNames.MethodWallet && net > 0)
            {
                var wallet = _walletDAL.GetByEmployee(payroll.EmployeeID);
                if (wallet == null) _walletDAL.CreateWallet(payroll.EmployeeID);

                _walletDAL.AdjustBalance(payroll.EmployeeID, net, clsAppSession.UserID,
                                         $"إيداع مرتب شهر {payroll.MonthYear}");
            }

            return OperationResult.Ok($"تم صرف المرتب بنجاح (الصافي {net:N2} جنيه).", payrollID);
        });

        /// <summary>بتجهّز كشف مرتبات مبدئي لكل الموظفين النشطين (من غير حفظ).</summary>
        public OperationResult<List<Payroll>> PrepareMonthlyPayroll(string monthYear) => Execute(() =>
        {
            if (!IsValidMonthYear(monthYear))
                return OperationResult<List<Payroll>>.Fail("صيغة الشهر لازم تكون yyyy-MM (مثال: 2026-01).");

            var alreadyPaid = new HashSet<int>(_payrollDAL.GetAll(monthYear).Select(p => p.EmployeeID));

            var list = _employeeDAL.GetAll(true)
                .Where(e => !alreadyPaid.Contains(e.EmployeeID))
                .Select(e => new Payroll
                {
                    EmployeeID = e.EmployeeID,
                    EmployeeName = e.FullName,
                    AmountPaid = e.BasicSalary,
                    Deductions = 0,
                    Bonuses = 0,
                    MonthYear = monthYear,
                    PaymentDate = DateTime.Today
                })
                .ToList();

            return OperationResult<List<Payroll>>.Ok(list);
        });

        public string CurrentMonthYear() => DateTime.Today.ToString("yyyy-MM");

        private static bool IsValidMonthYear(string monthYear)
            => !string.IsNullOrWhiteSpace(monthYear)
               && System.Text.RegularExpressions.Regex.IsMatch(monthYear, @"^\d{4}-(0[1-9]|1[0-2])$");
    }

}
