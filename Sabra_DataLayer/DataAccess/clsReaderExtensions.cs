using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.DataLayer.DataAccess
{
    /// <summary>
    /// قراءة آمنة من الـ Reader: لو العمود مش موجود أو قيمته NULL بترجع القيمة
    /// الافتراضية بدل ما ترمي Exception. وكمان بتقبل أكتر من اسم محتمل للعمود.
    /// </summary>
    internal static class clsReaderExtensions
    {
        public static bool HasColumn(this IDataRecord r, string name)
        {
            if (r == null || string.IsNullOrEmpty(name)) return false;
            for (int i = 0; i < r.FieldCount; i++)
                if (string.Equals(r.GetName(i), name, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        private static object Raw(IDataRecord r, string[] names)
        {
            if (r == null || names == null) return null;
            foreach (var n in names)
            {
                if (!r.HasColumn(n)) continue;
                var v = r[n];
                return v == DBNull.Value ? null : v;
            }
            return null;
        }

        public static string GetStr(this IDataRecord r, params string[] names)
        {
            var v = Raw(r, names);
            return v == null ? null : v.ToString();
        }

        public static int GetInt(this IDataRecord r, params string[] names)
        {
            var v = Raw(r, names);
            return v == null ? 0 : Convert.ToInt32(v);
        }

        public static int? GetIntOrNull(this IDataRecord r, params string[] names)
        {
            var v = Raw(r, names);
            return v == null ? (int?)null : Convert.ToInt32(v);
        }

        public static decimal GetDec(this IDataRecord r, params string[] names)
        {
            var v = Raw(r, names);
            return v == null ? 0m : Convert.ToDecimal(v);
        }

        public static decimal? GetDecOrNull(this IDataRecord r, params string[] names)
        {
            var v = Raw(r, names);
            return v == null ? (decimal?)null : Convert.ToDecimal(v);
        }

        public static DateTime GetDate(this IDataRecord r, params string[] names)
        {
            var v = Raw(r, names);
            return v == null ? DateTime.MinValue : Convert.ToDateTime(v);
        }

        public static DateTime? GetDateOrNull(this IDataRecord r, params string[] names)
        {
            var v = Raw(r, names);
            return v == null ? (DateTime?)null : Convert.ToDateTime(v);
        }

        /// <summary>بتتعامل مع BIT و 0/1 و "نعم"/"لا" و "true"/"false".</summary>
        public static bool GetBool(this IDataRecord r, params string[] names)
        {
            var v = Raw(r, names);
            if (v == null) return false;
            if (v is bool) return (bool)v;

            if (v is string)
            {
                var s = ((string)v).Trim();
                return s == "1" || s == "نعم"
                       || s.Equals("true", StringComparison.OrdinalIgnoreCase)
                       || s.Equals("yes", StringComparison.OrdinalIgnoreCase);
            }

            try { return Convert.ToDecimal(v) != 0m; }
            catch { return false; }
        }
    }
}
