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

        public OperationResult<List<Employee>> GetAll(bool activeOnly = true) { 
            var list = _employeeDAL.GetAll(activeOnly);
            return OperationResult<List<Employee>>.Ok(list);
        }
        public OperationResult<Employee> GetByID(int employeeID) { 
            var emp = _employeeDAL.GetByID(employeeID);
            if (emp == null)
                return OperationResult<Employee>.Fail("الموظف غير موجود");
            return OperationResult<Employee>.Ok(emp);
        }
        public OperationResult<List<Employee>> Search(string keyword) {
            if (string.IsNullOrWhiteSpace(keyword))
                return OperationResult<List<Employee>>.Fail("أدخل كلمة للبحث");
            var list = _employeeDAL.Search(keyword.Trim());
            return OperationResult<List<Employee>>.Ok(list);
        }

        public OperationResult AddEmployee(Employee emp, bool createdWallet = true) {
            if (string.IsNullOrWhiteSpace(emp.FullName))
                return OperationResult.Fail("اسم الموظف مطلوب");
            if(emp.PositionID <= 0)
                return OperationResult.Fail("يجب اختيار وظيفة للموظف");
            if(emp.BasicSalary < 0)
                return OperationResult.Fail("الراتب الأساسي لا يمكن أن يكون سالبا");
            if (emp.HireDate > DateTime.Today)
                return OperationResult.Fail("تاريخ التعيين لا يمكن أن يكون في المستبقل");
            emp.IsActive = true;
            int newID = _employeeDAL.Add(emp);

            if (createdWallet)
                _walletDAL.CreateWallet(newID);
            return OperationResult.Ok("تم إضافة الموظف بنجاح", newID);
        }

        public OperationResult UpdateEmployee(Employee emp) {
            if (string.IsNullOrWhiteSpace(emp.FullName))
                return OperationResult.Fail("أسم الموظف مطلوب");
            if (emp.BasicSalary < 0)
                return OperationResult.Fail("الراتب الأساسي لا يمكن أن يكون سالبا");

            _employeeDAL.Update(emp);
            return OperationResult.Ok("تم تحديث بيانات الموظف");
        }

        public OperationResult DeactiveEmployee(int employeeID) {
            _employeeDAL.Deactivate(employeeID);

            var user = _userDAL.GetByEmployeeID(employeeID);
            if (user != null)
                _userDAL.SetActive(user.UserID, false);
            return OperationResult.Ok("تم إيقاف الموظف بنجاح");
        }

        public OperationResult<List<EmployeePosition>> GetPositions() { 
            var list = _lookupDAL.GetAllPositions();
            return OperationResult<List<EmployeePosition>>.Ok(list);
        }

        public OperationResult AddPosition(string Name) {
            if (string.IsNullOrWhiteSpace(Name))
                return OperationResult.Fail("اسم الوظيفة مطلوب");

            _lookupDAL.AddPosition(Name.Trim());
            return OperationResult.Ok("تم إضافة الوظيفة");
        }
    }
}
