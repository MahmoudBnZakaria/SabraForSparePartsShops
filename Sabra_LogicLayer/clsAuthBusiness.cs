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
    public class clsAuthBusiness
    {
        private readonly clsUserDAL _userDAL = new clsUserDAL();
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();
        public OperationResult<User> Login(string username, string password) {

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return OperationResult<User>.Fail("يرجى إدخال اسم المستخدم و كلمة المرور");

            var user = _userDAL.GetByUsername(username.Trim());

            if (user == null)
                return OperationResult<User>.Fail("اسم المستخدم غير موجود");

            if (!PasswordHelper.Verify(password, user.PasswordHash))
                return OperationResult<User>.Fail("كلمة المرور غير صحيحة.");

            var employee = _employeeDAL.GetByID(user.EmployeeID);
            clsAppSession.SetSession(user, employee);

            return OperationResult<User>.Ok(user, $"مرحبا، {user.EmployeeName}");
        }
        public void Logout() {
            clsAppSession.ClearSession();
        }
        public OperationResult ChangePassword(int userID, string oldPassword, string newPassword, string confirmPassword) {
            if (string.IsNullOrWhiteSpace(newPassword))
                return OperationResult.Fail("كلمة المرور الجديدة لا يمكن أن تكون فارغة ");
            if (newPassword != confirmPassword)
                return OperationResult.Fail("كلمة المرور الجديدة و تأكيدها غير متطابقتين");
            if (!PasswordHelper.IsStrong(newPassword))
                return OperationResult.Fail("كلمة المرور يجب أن تكون 6 أحرف على الأقل");
            var user = _userDAL.GetByUserID(userID);

            if (user == null)
                return OperationResult.Fail("المستخدم غير موجود");

            if (!PasswordHelper.Verify(oldPassword, user.PasswordHash))
                return OperationResult.Fail("كلمة المرور الحالية غير صحيحة");

            _userDAL.UpdatePassword(userID, PasswordHelper.Hash(newPassword));
            return OperationResult.Ok("تم تغيير كلمة المرور بنجاح");
        }
        public OperationResult ResetPassword(int userID, string newPassword, string confirmPassword) {

            if (newPassword != confirmPassword)
                return OperationResult.Fail("كلمة المرور و تأكيدها غير متطابقتين");
            if (!PasswordHelper.IsStrong(newPassword))
                return OperationResult.Fail("كلمة المرور يجب أن تكون 6 أحرف على الأقل");
            _userDAL.UpdatePassword(userID, PasswordHelper.Hash(newPassword));
            return OperationResult.Ok("تم تغيير كلمة المرور بنجاح");
        }
    }
}
