using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    /// <summary>
    /// بيحمّل الجداول المرجعية مرة واحدة ويحوّل الاسم لـ ID.
    /// ده بيمنع تكرار الكود ويمنع نسيان التحقق من إن القيمة موجودة أصلًا.
    /// </summary>
    public static class clsLookupCache
    {
        private static readonly clsLookupDAL _dal = new clsLookupDAL();
        private static readonly object _sync = new object();

        private static List<TransactionType> _txTypes;
        private static List<PaymentStatus> _paymentStatuses;
        private static List<AdvanceStatus> _advanceStatuses;
        private static List<PurchaseOrderStatus> _poStatuses;
        private static List<MovementType> _movementTypes;
        private static List<ItemStatus> _itemStatuses;
        private static List<PaymentMethod> _paymentMethods;

        public static void Clear()
        {
            lock (_sync)
            {
                _txTypes = null; _paymentStatuses = null; _advanceStatuses = null;
                _poStatuses = null; _movementTypes = null; _itemStatuses = null;
                _paymentMethods = null;
            }
        }

        public static List<TransactionType> TransactionTypes
        { get { lock (_sync) { return _txTypes ?? (_txTypes = _dal.GetAllTransactionTypes()); } } }

        public static List<PaymentStatus> PaymentStatuses
        { get { lock (_sync) { return _paymentStatuses ?? (_paymentStatuses = _dal.GetAllPaymentStatuses()); } } }

        public static List<AdvanceStatus> AdvanceStatuses
        { get { lock (_sync) { return _advanceStatuses ?? (_advanceStatuses = _dal.GetAllAdvanceStatuses()); } } }

        public static List<PurchaseOrderStatus> POStatuses
        { get { lock (_sync) { return _poStatuses ?? (_poStatuses = _dal.GetAllPOStatuses()); } } }

        public static List<MovementType> MovementTypes
        { get { lock (_sync) { return _movementTypes ?? (_movementTypes = _dal.GetAllMovementTypes()); } } }

        public static List<ItemStatus> ItemStatuses
        { get { lock (_sync) { return _itemStatuses ?? (_itemStatuses = _dal.GetAllItemStatuses()); } } }

        public static List<PaymentMethod> PaymentMethods
        { get { lock (_sync) { return _paymentMethods ?? (_paymentMethods = _dal.GetAllPaymentMethods()); } } }

        // ── تحويل الاسم لـ ID (بترمي LookupMissingException لو مش موجود) ──────
        public static int TransactionTypeID(string name) =>
            Require(TransactionTypes.FirstOrDefault(t => t.TypeName == name)?.TransactionTypeID, "نوع الحركة", name);

        public static int PaymentStatusID(string name) =>
            Require(PaymentStatuses.FirstOrDefault(s => s.StatusName == name)?.StatusID, "حالة الدفع", name);

        public static int AdvanceStatusID(string name) =>
            Require(AdvanceStatuses.FirstOrDefault(s => s.StatusName == name)?.StatusID, "حالة السلفة", name);

        public static int POStatusID(string name) =>
            Require(POStatuses.FirstOrDefault(s => s.StatusName == name)?.StatusID, "حالة أمر الشراء", name);

        public static int MovementTypeID(string name) =>
            Require(MovementTypes.FirstOrDefault(m => m.TypeName == name)?.MovementTypeID, "نوع حركة المخزون", name);

        public static int ItemStatusID(string name) =>
            Require(ItemStatuses.FirstOrDefault(s => s.StatusName == name)?.StatusID, "حالة الصنف المرتجع", name);

        public static string PaymentMethodName(int id) =>
            PaymentMethods.FirstOrDefault(m => m.PaymentMethodID == id)?.MethodName;

        public static bool PaymentMethodExists(int id) =>
            PaymentMethods.Any(m => m.PaymentMethodID == id);

        private static int Require(int? value, string kind, string name)
        {
            if (value.HasValue) return value.Value;
            throw new LookupMissingException($"{kind} ({name}) غير معرّف في قاعدة البيانات. شغّل سكريبت البيانات المرجعية.");
        }
    }

    public class LookupMissingException : Exception
    {
        public LookupMissingException(string message) : base(message) { }
    }

}
