
using Microsoft.Data.SqlClient;


namespace Sabra.DataLayer
{
    public static class clsConnectionManager
    {
        private static string _ConnectionString = @"
                Server=.;
                Database=SabraForSparePartsDatabase;
                Integrated Security=True;
                TrustServerCertificate=True;";

        public static string ConnectionString {
            set => _ConnectionString = value;
            get => _ConnectionString;
        }

        public static SqlConnection GetConnection() {
            return new SqlConnection(_ConnectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection()) {
                    conn.Open();
                    return true;
                }
            }
            catch {
                return false;
            }
        }


    }
}
