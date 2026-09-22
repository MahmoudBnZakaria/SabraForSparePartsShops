using Microsoft.Data.SqlClient;
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


    public class clsEmployeeBusiness : clsBusinessBase
    {
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();
        private readonly clsUserDAL _userDAL = new clsUserDAL();
        private readonly clsStaffWalletDAL _walletDAL = new clsStaffWalletDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();
        private readonly clsReportsDAL _reportsDAL = new clsReportsDAL();

        public OperationResult<List<Employee>> GetAll(bool activeOnly = true) => Execute(()
            => OperationResult<List<Employee>>.Ok(_employeeDAL.GetAll(activeOnly)));

        public OperationResult<Employee> GetByID(int employeeID) => Execute(() =>
        {
            var emp = _employeeDAL.GetByID(employeeID);
            return emp == null
                ? OperationResult<Employee>.Fail("الموظف غير موجود.")
                : OperationResult<Employee>.Ok(emp);
        });

        public OperationResult<List<Employee>> Search(string keyword) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return OperationResult<List<Employee>>.Fail("أدخل كلمة للبحث.");
            return OperationResult<List<Employee>>.Ok(_employeeDAL.Search(keyword.Trim()));
        });

        public OperationResult AddEmployee(Employee emp, bool createWallet = true) => Execute(() =>
        {
            var invalid = Validate(emp);
            if (invalid != null) return invalid;

            emp.FullName = emp.FullName.Trim();
            emp.IsActive = true;
            if (emp.HireDate == default) emp.HireDate = DateTime.Today;

            int newID = _employeeDAL.Add(emp);

            if (createWallet)
            {
                try { _walletDAL.CreateWallet(newID); }
                catch (SqlException) { /* المحفظة موجودة بالفعل – مش سبب لفشل إضافة الموظف */ }
            }

            return OperationResult.Ok("تمت إضافة الموظف بنجاح.", newID);
        });

        public OperationResult UpdateEmployee(Employee emp) => Execute(() =>
        {
            var invalid = Validate(emp);
            if (invalid != null) return invalid;

            var existing = _employeeDAL.GetByID(emp.EmployeeID);
            if (existing == null) return OperationResult.Fail("الموظف غير موجود.");

            emp.FullName = emp.FullName.Trim();
            _employeeDAL.Update(emp);

            // لو الموظف اتوقف، نوقف حسابه كمان
            if (!emp.IsActive)
            {
                var user = _userDAL.GetByEmployeeID(emp.EmployeeID);
                if (user != null && user.IsActive) _userDAL.SetActive(user.UserID, false);
            }

            return OperationResult.Ok("تم تحديث بيانات الموظف.");
        });

        public OperationResult DeactivateEmployee(int employeeID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.UsersAdmin, "إيقاف الموظفين");
            if (guard != null) return guard;

            if (employeeID == clsAppSession.EmployeeID)
                return OperationResult.Fail("لا يمكنك إيقاف نفسك.");

            var emp = _employeeDAL.GetByID(employeeID);
            if (emp == null) return OperationResult.Fail("الموظف غير موجود.");

            _employeeDAL.Deactivate(employeeID);

            var user = _userDAL.GetByEmployeeID(employeeID);
            if (user != null) _userDAL.SetActive(user.UserID, false);

            return OperationResult.Ok("تم إيقاف الموظف بنجاح.");
        });

        public OperationResult ActivateEmployee(int employeeID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.UsersAdmin, "تفعيل الموظفين");
            if (guard != null) return guard;

            var emp = _employeeDAL.GetByID(employeeID);
            if (emp == null) return OperationResult.Fail("الموظف غير موجود.");

            _employeeDAL.Activate(employeeID);
            return OperationResult.Ok("تم تفعيل الموظف بنجاح.");
        });

        public OperationResult<List<EmployeePosition>> GetPositions() => Execute(()
            => OperationResult<List<EmployeePosition>>.Ok(_lookupDAL.GetAllPositions()));

        public OperationResult AddPosition(string name) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(name)) return OperationResult.Fail("اسم الوظيفة مطلوب.");

            name = name.Trim();
            if (_lookupDAL.GetAllPositions().Any(p => string.Equals(p.PositionName, name, StringComparison.OrdinalIgnoreCase)))
                return OperationResult.Fail("الوظيفة دي موجودة بالفعل.");

            _lookupDAL.AddPosition(name);
            return OperationResult.Ok("تمت إضافة الوظيفة.");
        });

        // ── المحفظة ───────────────────────────────────────────────────────────
        public OperationResult<StaffWallet> GetWallet(int employeeID) => Execute(() =>
        {
            var wallet = _walletDAL.GetByEmployee(employeeID);
            return wallet == null
                ? OperationResult<StaffWallet>.Fail("لا توجد محفظة لهذا الموظف.")
                : OperationResult<StaffWallet>.Ok(wallet);
        });

        public OperationResult CreateWallet(int employeeID, string walletNumber = null) => Execute(() =>
        {
            var emp = _employeeDAL.GetByID(employeeID);
            if (emp == null) return OperationResult.Fail("الموظف غير موجود.");

            _walletDAL.CreateWallet(employeeID, walletNumber);
            return OperationResult.Ok("تم إنشاء المحفظة.");
        });

        /// <summary>إيداع/سحب من محفظة الموظف. delta موجب = إيداع.</summary>
        public OperationResult AdjustWallet(int employeeID, decimal delta, string reason) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Payroll, "تعديل محافظ الموظفين");
            if (guard != null) return guard;

            if (delta == 0) return OperationResult.Fail("قيمة التعديل لا يمكن أن تكون صفر.");
            if (string.IsNullOrWhiteSpace(reason)) return OperationResult.Fail("سبب التعديل مطلوب.");

            _walletDAL.AdjustBalance(employeeID, delta, clsAppSession.UserID, reason.Trim());
            return OperationResult.Ok("تم تعديل رصيد المحفظة.");
        });

        public OperationResult<List<EmployeeFinancialSummaryView>> GetFinancialSummary(int? employeeID = null) => Execute(()
            => OperationResult<List<EmployeeFinancialSummaryView>>.Ok(_reportsDAL.GetEmployeeFinancialSummary(employeeID)));

        private static OperationResult Validate(Employee emp)
        {
            if (emp == null) return OperationResult.Fail("بيانات الموظف غير صحيحة.");
            if (string.IsNullOrWhiteSpace(emp.FullName)) return OperationResult.Fail("اسم الموظف مطلوب.");
            if (emp.PositionID <= 0) return OperationResult.Fail("يجب اختيار وظيفة للموظف.");
            if (emp.BasicSalary < 0) return OperationResult.Fail("الراتب الأساسي لا يمكن أن يكون سالباً.");
            if (emp.HireDate != default && emp.HireDate.Date > DateTime.Today)
                return OperationResult.Fail("تاريخ التعيين لا يمكن أن يكون في المستقبل.");
            if (!string.IsNullOrWhiteSpace(emp.NationalID) && emp.NationalID.Trim().Length > 20)
                return OperationResult.Fail("الرقم القومي طويل جدًا.");
            return null;
        }
    }
}
