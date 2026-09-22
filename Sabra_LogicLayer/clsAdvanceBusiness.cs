using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sabra.LogicLayer
{

    public class clsAdvanceBusiness : clsBusinessBase
    {
        private readonly clsAdvanceDAL _advDAL = new clsAdvanceDAL();
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();

        public OperationResult<List<Advance>> GetAll(int? statusID = null, int? employeeID = null) => Execute(()
            => OperationResult<List<Advance>>.Ok(_advDAL.GetAll(statusID, employeeID)));

        public OperationResult<List<AdvanceStatus>> GetStatuses() => Execute(()
            => OperationResult<List<AdvanceStatus>>.Ok(clsLookupCache.AdvanceStatuses));

        public OperationResult RequestAdvance(Advance adv) => Execute(() =>
        {
            var guard = RequireLogin();
            if (guard != null) return guard;

            if (adv == null) return OperationResult.Fail("بيانات السلفة غير صحيحة.");
            if (adv.EmployeeID <= 0) return OperationResult.Fail("يجب تحديد الموظف.");
            if (adv.Amount <= 0) return OperationResult.Fail("قيمة السلفة يجب أن تكون أكبر من الصفر.");

            var employee = _employeeDAL.GetByID(adv.EmployeeID);
            if (employee == null) return OperationResult.Fail("الموظف غير موجود.");
            if (!employee.IsActive) return OperationResult.Fail("الموظف ده موقوف.");

            // الموظف العادي يطلب لنفسه بس
            if (adv.EmployeeID != clsAppSession.EmployeeID && !clsAppSession.Has(Permission.Payroll))
                return OperationResult.Fail("مالكش صلاحية تسجيل سلفة لموظف تاني.");

            int pendingID = clsLookupCache.AdvanceStatusID(clsSystemNames.AdvPending);

            bool hasOpenRequest = _advDAL.GetAll(pendingID, adv.EmployeeID).Any();
            if (hasOpenRequest)
                return OperationResult.Fail("الموظف عنده طلب سلفة قيد الانتظار بالفعل.");

            adv.StatusID = pendingID;
            adv.AdvanceDate = adv.AdvanceDate == default ? DateTime.Today : adv.AdvanceDate;

            int newID = _advDAL.Add(adv, clsAppSession.UserID);
            return OperationResult.Ok("تم تسجيل طلب السلفة بنجاح.", newID);
        });

        /// <summary>
        /// الموافقة على السلفة وصرفها من الخزنة في خطوة واحدة (SP واحدة):
        /// بتغيّر الحالة، بتسجل حركة صادر في الخزنة، وبتملّي Treasury_ID في السلفة
        /// عشان مستحيل تتصرف مرتين.
        /// </summary>
        public OperationResult ApproveAndPay(int advanceID, int paymentMethodID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Payroll, "اعتماد وصرف السلف");
            if (guard != null) return guard;

            if (!clsLookupCache.PaymentMethodExists(paymentMethodID))
                return OperationResult.Fail("يجب اختيار طريقة دفع صحيحة.");

            var adv = _advDAL.GetAll(null, null).FirstOrDefault(a => a.AdvanceID == advanceID);
            if (adv == null) return OperationResult.Fail("السلفة غير موجودة.");

            if (adv.TreasuryID.HasValue)
                return OperationResult.Fail("السلفة دي اتصرفت بالفعل.");

            if (adv.StatusID == clsLookupCache.AdvanceStatusID(clsSystemNames.AdvRejected) ||
                adv.StatusID == clsLookupCache.AdvanceStatusID(clsSystemNames.AdvCancelled))
                return OperationResult.Fail("لا يمكن صرف سلفة مرفوضة أو ملغاة.");

            decimal balance = _treasuryDAL.GetCurrentBalance();
            if (adv.Amount > balance)
                return OperationResult.Fail($"رصيد الخزنة ({balance:N2} جنيه) لا يكفي لصرف السلفة.");

            bool ok = _advDAL.UpdateStatus(
                advanceID,
                clsLookupCache.AdvanceStatusID(clsSystemNames.AdvApproved),
                clsAppSession.UserID,
                approvedBy: clsAppSession.EmployeeID,
                isDisbursement: true,
                paymentMethodID: paymentMethodID,
                disbursementTransactionTypeID: clsLookupCache.TransactionTypeID(clsSystemNames.TxAdvance));

            return ok ? OperationResult.Ok("تمت الموافقة وصرف السلفة بنجاح.")
                      : OperationResult.Fail("لم يتم صرف السلفة.");
        });

        public OperationResult Reject(int advanceID, string reason = null) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Payroll, "رفض السلف");
            if (guard != null) return guard;

            var adv = _advDAL.GetAll(null, null).FirstOrDefault(a => a.AdvanceID == advanceID);
            if (adv == null) return OperationResult.Fail("السلفة غير موجودة.");
            if (adv.TreasuryID.HasValue) return OperationResult.Fail("لا يمكن رفض سلفة تم صرفها بالفعل.");

            _advDAL.UpdateStatus(advanceID, clsLookupCache.AdvanceStatusID(clsSystemNames.AdvRejected),
                                 clsAppSession.UserID, approvedBy: clsAppSession.EmployeeID);

            return OperationResult.Ok("تم رفض طلب السلفة.");
        });

        public OperationResult CancelAdvance(int advanceID, int requestingEmployeeID) => Execute(() =>
        {
            var guard = RequireLogin();
            if (guard != null) return guard;

            var adv = _advDAL.GetAll(null, null).FirstOrDefault(a => a.AdvanceID == advanceID);
            if (adv == null) return OperationResult.Fail("السلفة غير موجودة.");

            if (adv.EmployeeID != requestingEmployeeID && !clsAppSession.Has(Permission.Payroll))
                return OperationResult.Fail("لا يمكنك إلغاء طلب سلفة خاص بموظف آخر.");

            if (adv.TreasuryID.HasValue) return OperationResult.Fail("لا يمكن إلغاء سلفة تم صرفها.");
            if (!IsPending(adv)) return OperationResult.Fail("حالة الطلب الحالية لا تسمح بالإلغاء.");

            bool ok = _advDAL.UpdateStatus(advanceID, clsLookupCache.AdvanceStatusID(clsSystemNames.AdvCancelled),
                                           clsAppSession.UserID);

            return ok ? OperationResult.Ok("تم إلغاء طلب السلفة.")
                      : OperationResult.Fail("فشل إلغاء طلب السلفة.");
        });

        /// <summary>تعليم السلفة كمسددة (بعد خصمها من المرتب مثلاً).</summary>
        public OperationResult MarkSettled(int advanceID) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Payroll, "تسوية السلف");
            if (guard != null) return guard;

            var adv = _advDAL.GetAll(null, null).FirstOrDefault(a => a.AdvanceID == advanceID);
            if (adv == null) return OperationResult.Fail("السلفة غير موجودة.");

            if (!adv.TreasuryID.HasValue)
                return OperationResult.Fail("السلفة دي ماتصرفتش أصلاً عشان تتسدد.");

            if (adv.StatusID == clsLookupCache.AdvanceStatusID(clsSystemNames.AdvSettled))
                return OperationResult.Fail("السلفة دي مسددة بالفعل.");

            _advDAL.UpdateStatus(advanceID, clsLookupCache.AdvanceStatusID(clsSystemNames.AdvSettled),
                                 clsAppSession.UserID);

            return OperationResult.Ok("تم تسديد السلفة.");
        });

        public bool IsPending(Advance advance)
            => advance != null && advance.StatusID == clsLookupCache.AdvanceStatusID(clsSystemNames.AdvPending);
    }
}