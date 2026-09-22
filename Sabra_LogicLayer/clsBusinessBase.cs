using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{

    /// <summary>
    /// أساس مشترك: تنفيذ آمن + ترجمة أخطاء SQL + التحقق من الجلسة والصلاحيات.
    /// </summary>
    public abstract class clsBusinessBase
    {
        protected static OperationResult Execute(Func<OperationResult> action)
        {
            try { return action(); }
            catch (LookupMissingException ex) { return OperationResult.Fail(ex.Message); }
            catch (SqlException ex) { return OperationResult.Fail(Translate(ex)); }
            catch (Exception ex) { return OperationResult.Fail("حدث خطأ غير متوقع: " + ex.Message); }
        }

        protected static OperationResult<T> Execute<T>(Func<OperationResult<T>> action)
        {
            try { return action(); }
            catch (LookupMissingException ex) { return OperationResult<T>.Fail(ex.Message); }
            catch (SqlException ex) { return OperationResult<T>.Fail(Translate(ex)); }
            catch (Exception ex) { return OperationResult<T>.Fail("حدث خطأ غير متوقع: " + ex.Message); }
        }

        /// <summary>
        /// الـ SPs بترمي رسائل عربية واضحة عن طريق THROW/RAISERROR، فبنعرضها زي ما هي.
        /// الأخطاء التقنية بس هي اللي بنترجمها لرسالة مفهومة للمستخدم.
        /// </summary>
        protected static string Translate(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2627:
                case 2601: return "البيانات دي مسجلة قبل كده (تكرار غير مسموح).";
                case 547: return "العملية دي مرتبطة ببيانات تانية في النظام ولا يمكن تنفيذها.";
                case 1205: return "حصل تعارض مع عملية تانية، جرّب تاني.";
                case 53:
                case 4060:
                case 18456: return "تعذر الاتصال بقاعدة البيانات، راجع إعدادات الاتصال.";
                case -2: return "استغرقت العملية وقتًا طويلًا وتم إيقافها، جرّب تاني.";
                default: return ex.Message;
            }
        }

        protected static OperationResult RequireLogin()
            => clsAppSession.IsLoggedIn ? null : OperationResult.Fail("يجب تسجيل الدخول أولاً.");

        protected static OperationResult RequirePermission(Permission permission, string action)
            => clsAppSession.IsLoggedIn
               ? (clsAppSession.Has(permission) ? null : OperationResult.Fail($"مالكش صلاحية {action}."))
               : OperationResult.Fail("يجب تسجيل الدخول أولاً.");
    }

}
