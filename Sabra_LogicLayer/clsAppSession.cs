using Sabra.DataLayer.Models;

namespace Sabra.LogicLayer
{

    public static class clsAppSession
    {
        public static User CurrentUser { get; private set; }
        public static Employee CurrentEmployee { get; private set; }

        public static bool IsLoggedIn => CurrentUser != null;
        public static int UserID => CurrentUser?.UserID ?? 0;
        public static int EmployeeID => CurrentEmployee?.EmployeeID ?? CurrentUser?.EmployeeID ?? 0;

        public static bool IsManager =>
            CurrentEmployee != null &&
            !string.IsNullOrWhiteSpace(CurrentEmployee.PositionName) &&
            (CurrentEmployee.PositionName.Contains("مدير") ||
             CurrentEmployee.PositionName.Contains("Manager"));

        /// <summary>المدير عنده كل الصلاحيات، وغيره حسب الـ Bitwise في Users.Permissions.</summary>
        public static bool Has(Permission permission)
        {
            if (!IsLoggedIn) return false;
            if (IsManager) return true;
            return ((Permission)CurrentUser.Permissions & permission) == permission;
        }

        public static void SetSession(User user, Employee employee)
        {
            CurrentUser = user;
            CurrentEmployee = employee;
        }

        public static void ClearSession()
        {
            CurrentUser = null;
            CurrentEmployee = null;
            clsLookupCache.Clear();
        }
    }
}