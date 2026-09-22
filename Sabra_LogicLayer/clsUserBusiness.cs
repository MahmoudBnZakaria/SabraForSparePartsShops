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


    public class clsUserBusiness : clsBusinessBase
    {
        private readonly clsUserDAL _userDAL = new clsUserDAL();
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();

        public OperationResult<List<User>> GetAll() => Execute(()
            => OperationResult<List<User>>.Ok(_userDAL.GetAll()));

        public OperationResult<User> GetByID(int userID) => Execute(() =>
        {
            var user = _userDAL.GetByID(userID);
            return user == null
                ? OperationResult<User>.Fail("المستخدم غير موجود.")
                : OperationResult<User>.Ok(user);
        });

        public OperationResult CreateUser(int employeeID, string username, string password,
                                          string confirmPassword, Permission permissions = Permission.None) => Execute(() =>
                                          {
                                              var guard = RequirePermission(Permission.UsersAdmin, "إنشاء مستخدمين");
                                              if (guard != null) return guard;

                                              if (employeeID <= 0) return OperationResult.Fail("يجب اختيار الموظف.");
                                              if (string.IsNullOrWhiteSpace(username)) return OperationResult.Fail("اسم المستخدم مطلوب.");
                                              if (password != confirmPassword) return OperationResult.Fail("كلمة المرور وتأكيدها غير متطابقتين.");
                                              if (!PasswordHelper.IsStrong(password)) return OperationResult.Fail("كلمة المرور يجب أن تكون 6 أحرف على الأقل.");

                                              username = username.Trim();

                                              if (_userDAL.UsernameExists(username))
                                                  return OperationResult.Fail("اسم المستخدم موجود مسبقاً.");

                                              var emp = _employeeDAL.GetByID(employeeID);
                                              if (emp == null) return OperationResult.Fail("الموظف غير موجود.");
                                              if (!emp.IsActive) return OperationResult.Fail("لا يمكن إنشاء حساب لموظف موقوف.");

                                              if (_userDAL.GetByEmployeeID(employeeID) != null)
                                                  return OperationResult.Fail("هذا الموظف لديه حساب مستخدم بالفعل.");

                                              int newID = _userDAL.Add(new User
                                              {
                                                  EmployeeID = employeeID,
                                                  Username = username,
                                                  PasswordHash = PasswordHelper.Hash(password),
                                                  IsActive = true,
                                                  Permissions = (int)permissions
                                              });

                                              return OperationResult.Ok("تم إنشاء حساب المستخدم بنجاح.", newID);
                                          });

        public OperationResult UpdatePermissions(int userID, Permission permissions) => Execute(() =>
        {
            var guard = RequirePermission(Permission.UsersAdmin, "تعديل الصلاحيات");
            if (guard != null) return guard;

            var user = _userDAL.GetByID(userID);
            if (user == null) return OperationResult.Fail("المستخدم غير موجود.");

            _userDAL.UpdatePermissions(userID, (int)permissions);

            if (userID == clsAppSession.UserID)
            {
                user.Permissions = (int)permissions;
                clsAppSession.SetSession(user, clsAppSession.CurrentEmployee);
            }

            return OperationResult.Ok("تم تحديث الصلاحيات.");
        });

        public OperationResult ToggleActive(int userID, bool isActive) => Execute(() =>
        {
            var guard = RequirePermission(Permission.UsersAdmin, "تفعيل/إيقاف الحسابات");
            if (guard != null) return guard;

            if (userID == clsAppSession.UserID && !isActive)
                return OperationResult.Fail("لا يمكنك إيقاف حسابك الشخصي.");

            var user = _userDAL.GetByID(userID);
            if (user == null) return OperationResult.Fail("المستخدم غير موجود.");

            _userDAL.SetActive(userID, isActive);
            return OperationResult.Ok(isActive ? "تم تفعيل الحساب." : "تم إيقاف الحساب.");
        });
    }
}
