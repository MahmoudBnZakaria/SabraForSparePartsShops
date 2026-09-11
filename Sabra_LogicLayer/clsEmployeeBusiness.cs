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
    public class clsEmployeeBusiness
    {
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();
        private readonly clsUserDAL _userDAL = new clsUserDAL();
        private readonly clsStaffWalletDAL _walletDAL = new clsStaffWalletDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        public OperationResult<List<Employee>> GetAll(bool activeOnly = true)
            => OperationResult<List<Employee>>.Ok(_employeeDAL.GetAll(activeOnly));

        public OperationResult<Employee> GetByID(int employeeID)
        {
            var emp = _employeeDAL.GetByID(employeeID);
            if (emp == null)
                return OperationResult<Employee>.Fail("الموظف غير موجود");
            return OperationResult<Employee>.Ok(emp);
        }

        public OperationResult<List<Employee>> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return OperationResult<List<Employee>>.Fail("أدخل كلمة للبحث");
            return OperationResult<List<Employee>>.Ok(_employeeDAL.Search(keyword.Trim()));
        }

        public OperationResult AddEmployee(Employee emp, bool createWallet = true)
        {
            if (string.IsNullOrWhiteSpace(emp.FullName))
                return OperationResult.Fail("اسم الموظف مطلوب");
            if (emp.PositionID <= 0)
                return OperationResult.Fail("يجب اختيار وظيفة للموظف");
            if (emp.BasicSalary < 0)
                return OperationResult.Fail("الراتب الأساسي لا يمكن أن يكون سالباً");
            if (emp.HireDate == default)
                emp.HireDate = DateTime.Today;
            if (emp.HireDate > DateTime.Today)
                return OperationResult.Fail("تاريخ التعيين لا يمكن أن يكون في المستقبل");

            emp.IsActive = true;
            int newID = _employeeDAL.Add(emp);

            if (createWallet)
                _walletDAL.CreateWallet(newID);

            return OperationResult.Ok("تم إضافة الموظف بنجاح", newID);
        }

        public OperationResult UpdateEmployee(Employee emp)
        {
            if (string.IsNullOrWhiteSpace(emp.FullName))
                return OperationResult.Fail("اسم الموظف مطلوب");
            if (emp.BasicSalary < 0)
                return OperationResult.Fail("الراتب الأساسي لا يمكن أن يكون سالباً");
            if (emp.HireDate > DateTime.Today)
                return OperationResult.Fail("تاريخ التعيين لا يمكن أن يكون في المستقبل");

            var existing = _employeeDAL.GetByID(emp.EmployeeID);
            if (existing == null)
                return OperationResult.Fail("الموظف غير موجود");

            _employeeDAL.Update(emp);
            return OperationResult.Ok("تم تحديث بيانات الموظف");
        }

        public OperationResult DeactivateEmployee(int employeeID)
        {
            var emp = _employeeDAL.GetByID(employeeID);
            if (emp == null)
                return OperationResult.Fail("الموظف غير موجود");

            _employeeDAL.Deactivate(employeeID);

            var user = _userDAL.GetByEmployeeID(employeeID);
            if (user != null)
                _userDAL.SetActive(user.UserID, false);

            return OperationResult.Ok("تم إيقاف الموظف بنجاح");
        }

        public OperationResult<List<EmployeePosition>> GetPositions()
            => OperationResult<List<EmployeePosition>>.Ok(_lookupDAL.GetAllPositions());

        public OperationResult AddPosition(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return OperationResult.Fail("اسم الوظيفة مطلوب");

            _lookupDAL.AddPosition(name.Trim());
            return OperationResult.Ok("تم إضافة الوظيفة");
        }
    }

}
