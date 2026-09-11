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
    public class clsUserBusiness
    {
        private readonly clsUserDAL _userDAL = new clsUserDAL();
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();

        public OperationResult<List<User>> GetAll()
            => OperationResult<List<User>>.Ok(_userDAL.GetAll());

        public OperationResult<User> GetByID(int userID)
        {
            var user = _userDAL.GetByID(userID);
            if (user == null) return OperationResult<User>.Fail("المستخدم غير موجود");
            return OperationResult<User>.Ok(user);
        }

        public OperationResult CreateUser(int employeeID, string username, string password, string confirmPassword)
        {
            if (employeeID <= 0)
                return OperationResult.Fail("يجب اختيار الموظف");
            if (string.IsNullOrWhiteSpace(username))
                return OperationResult.Fail("اسم المستخدم مطلوب");
            if (string.IsNullOrEmpty(password))
                return OperationResult.Fail("كلمة المرور مطلوبة");
            if (password != confirmPassword)
                return OperationResult.Fail("كلمة المرور وتأكيدها غير متطابقتين");
            if (!PasswordHelper.IsStrong(password))
                return OperationResult.Fail("كلمة المرور يجب أن تكون 6 أحرف على الأقل");

            if (_userDAL.UsernameExists(username.Trim()))
                return OperationResult.Fail("اسم المستخدم موجود مسبقاً");

            var emp = _employeeDAL.GetByID(employeeID);
            if (emp == null)
                return OperationResult.Fail("الموظف غير موجود");

            if (_userDAL.GetByEmployeeID(employeeID) != null)
                return OperationResult.Fail("هذا الموظف لديه حساب مستخدم بالفعل");

            var user = new User
            {
                EmployeeID = employeeID,
                Username = username.Trim(),
                PasswordHash = PasswordHelper.Hash(password),
                IsActive = true
            };

            int newId = _userDAL.Add(user);
            return OperationResult.Ok("تم إنشاء حساب المستخدم بنجاح", newId);
        }

        public OperationResult ToggleActive(int userID, bool isActive)
        {
            var user = _userDAL.GetByID(userID);
            if (user == null)
                return OperationResult.Fail("المستخدم غير موجود");

            _userDAL.SetActive(userID, isActive);
            return OperationResult.Ok(isActive ? "تم تفعيل الحساب." : "تم إيقاف الحساب.");
        }
    }

}
