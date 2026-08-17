using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    internal static class PasswordHelper
    {
        public static string Hash(string password) {
            using (var sha = SHA256.Create()) { 
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public static bool Verify(string password, string hash) 
            => Hash(password) == hash;

        public static bool IsStrong(string password)
            => password != null && password.Length >= 6;
    }
}
