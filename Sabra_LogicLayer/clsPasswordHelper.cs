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
        private const int SaltSize = 16;      // 128-bit
        private const int KeySize = 32;       // 256-bit
        private const int Iterations = 100_000;
        private const string Prefix = "PBKDF2";

        public static string Hash(string password)
        {
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                var salt = new byte[SaltSize];
                rng.GetBytes(salt);

                var key = DeriveKey(password, salt, Iterations, KeySize);

                return string.Join("$",
                    Prefix,
                    Iterations.ToString(),
                    Convert.ToBase64String(salt),
                    Convert.ToBase64String(key));
            }
        }

        public static bool Verify(string password, string hash)
        {
            if (string.IsNullOrEmpty(hash)) return false;

            // صيغة جديدة: PBKDF2$Iterations$Salt$Hash
            if (hash.StartsWith(Prefix + "$", StringComparison.Ordinal))
            {
                var parts = hash.Split('$');
                if (parts.Length != 4) return false;

                if (!int.TryParse(parts[1], out int iterations)) return false;
                var salt = Convert.FromBase64String(parts[2]);
                var expected = Convert.FromBase64String(parts[3]);

                var actual = DeriveKey(password, salt, iterations, expected.Length);
                return FixedTimeEquals(actual, expected);
            }

            // توافق خلفي: هاش قديم بصيغة SHA256 بدون Salt (64 حرف hex)
            return LegacySha256(password) == hash;
        }

        public static bool IsStrong(string password)
            => password != null && password.Length >= 6;

        private static byte[] DeriveKey(string password, byte[] salt, int iterations, int keyLength)
        {
            using (var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(
                       password, salt, iterations, System.Security.Cryptography.HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(keyLength);
            }
        }

        private static string LegacySha256(string password)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }

}
