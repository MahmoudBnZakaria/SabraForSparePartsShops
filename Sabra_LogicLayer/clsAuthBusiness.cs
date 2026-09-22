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

    public class clsAuthBusiness : clsBusinessBase
    {
        private readonly clsUserDAL _userDAL = new clsUserDAL();
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();

        public OperationResult<User> Login(string username, string password) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return OperationResult<User>.Fail("يرجى إدخال اسم المستخدم وكلمة المرور.");

            var user = _userDAL.GetByUsername(username.Trim());

            // رسالة واحدة للاسم والباسورد الغلط (عشان محدش يعرف الأسماء الموجودة)
            if (user == null || !PasswordHelper.Verify(password, user.PasswordHash))
                return OperationResult<User>.Fail("اسم المستخدم أو كلمة المرور غير صحيحة.");

            if (!user.IsActive)
                return OperationResult<User>.Fail("هذا الحساب موقوف، يرجى مراجعة الإدارة.");

            var employee = _employeeDAL.GetByID(user.EmployeeID);
            if (employee == null)
                return OperationResult<User>.Fail("حساب المستخدم غير مرتبط بموظف صالح.");

            if (!employee.IsActive)
                return OperationResult<User>.Fail("الموظف صاحب الحساب موقوف.");

            // ترقية تلقائية للهاش القديم بعد أول تسجيل دخول ناجح
            if (PasswordHelper.NeedsUpgrade(user.PasswordHash))
            {
                var newHash = PasswordHelper.Hash(password);
                if (_userDAL.UpdatePassword(user.UserID, newHash))
                    user.PasswordHash = newHash;
            }

            clsLookupCache.Clear();
            clsAppSession.SetSession(user, employee);
            return OperationResult<User>.Ok(user, $"مرحباً، {employee.FullName}");
        });

        public void Logout() => clsAppSession.ClearSession();

        public OperationResult ChangePassword(int userID, string oldPassword, string newPassword, string confirmPassword) => Execute(() =>
        {
            var guard = RequireLogin();
            if (guard != null) return guard;

            if (userID != clsAppSession.UserID && !clsAppSession.Has(Permission.UsersAdmin))
                return OperationResult.Fail("مالكش صلاحية تغيير كلمة مرور مستخدم تاني.");

            if (newPassword != confirmPassword)
                return OperationResult.Fail("كلمة المرور الجديدة وتأكيدها غير متطابقتين.");
            if (!PasswordHelper.IsStrong(newPassword))
                return OperationResult.Fail("كلمة المرور يجب أن تكون 6 أحرف على الأقل.");

            var user = _userDAL.GetByID(userID);
            if (user == null) return OperationResult.Fail("المستخدم غير موجود.");

            if (!PasswordHelper.Verify(oldPassword, user.PasswordHash))
                return OperationResult.Fail("كلمة المرور الحالية غير صحيحة.");

            if (PasswordHelper.Verify(newPassword, user.PasswordHash))
                return OperationResult.Fail("كلمة المرور الجديدة لا يمكن أن تكون نفس القديمة.");

            _userDAL.UpdatePassword(userID, PasswordHelper.Hash(newPassword));
            return OperationResult.Ok("تم تغيير كلمة المرور بنجاح.");
        });

        /// <summary>إعادة تعيين كلمة المرور من الإدارة (بدون معرفة القديمة).</summary>
        public OperationResult ResetPassword(int userID, string newPassword, string confirmPassword) => Execute(() =>
        {
            var guard = RequirePermission(Permission.UsersAdmin, "إعادة تعيين كلمات المرور");
            if (guard != null) return guard;

            if (newPassword != confirmPassword)
                return OperationResult.Fail("كلمة المرور وتأكيدها غير متطابقتين.");
            if (!PasswordHelper.IsStrong(newPassword))
                return OperationResult.Fail("كلمة المرور يجب أن تكون 6 أحرف على الأقل.");

            var user = _userDAL.GetByID(userID);
            if (user == null) return OperationResult.Fail("المستخدم غير موجود.");

            _userDAL.UpdatePassword(userID, PasswordHelper.Hash(newPassword));
            return OperationResult.Ok("تم تغيير كلمة المرور بنجاح.");
        });
    }

}
