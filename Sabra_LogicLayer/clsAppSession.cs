using Sabra.DataLayer.Models;

namespace Sabra.LogicLayer
{
    public static class clsAppSession
    {
        public static User  CurrentUser { get;private set; }
        public static Employee CurrentEmployee { get;private set; }
        public static bool IsLoggedIn => CurrentUser != null;

        public static void SetSession(User user, Employee employee) { 
            CurrentUser = user;
            CurrentEmployee = employee;
        }

        public static void ClearSession() {
            CurrentUser = null;
            CurrentEmployee = null; 
        }
    }
}
