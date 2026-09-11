using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sabra.LogicLayer
{
    public enum AdvanceStatus
    {
        Pending = 1,  // قيد الانتظار
        Approved = 2, // تمت الموافقة
        Rejected = 3, // مرفوضة
        Canceled = 4  // ملغاة
    }

    public class clsAdvanceBusiness
    {
        private readonly clsAdvanceDAL _advDAL = new clsAdvanceDAL();
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        private const string OutTransactionType = "صادر";

        public OperationResult<List<Advance>> GetAll(int? statusID = null, int? employeeID = null)
        {
            var user = clsAppSession.CurrentUser;
            if (user == null)
                return OperationResult<List<Advance>>.Fail("لا يوجد مستخدم مسجل الدخول.");

            if (clsAppSession.IsManager)
            {
                return OperationResult<List<Advance>>.Ok(_advDAL.GetAll());
            }

            return OperationResult<List<Advance>>.Ok(
                _advDAL.GetAll(null, clsAppSession.CurrentEmployee.EmployeeID));
        }

        public OperationResult RequestAdvance(Advance adv)
        {
            if (adv.EmployeeID <= 0)
                return OperationResult.Fail("يجب تحديد الموظف.");

            if (adv.Amount <= 0)
                return OperationResult.Fail("قيمة السلفة يجب أن تكون أكبر من الصفر.");

            var employee = _employeeDAL.GetByID(adv.EmployeeID);
            if (employee == null)
                return OperationResult.Fail("الموظف غير موجود.");

            adv.StatusID = (int)AdvanceStatus.Pending;
            adv.AdvanceDate = DateTime.Today;

            int newID = _advDAL.Add(adv);
            return OperationResult.Ok("تم تسجيل طلب السلفة بنجاح.", newID);
        }

        public OperationResult ApproveAndPay(int advanceID, int paymentMethodID)
        {
            if (!clsAppSession.IsLoggedIn)
                return OperationResult.Fail("يجب تسجيل الدخول أولاً.");

            if (paymentMethodID <= 0)
                return OperationResult.Fail("يجب اختيار طريقة الدفع.");

            var adv = _advDAL.GetAll().FirstOrDefault(a => a.AdvanceID == advanceID);
            if (adv == null)
                return OperationResult.Fail("السلفة غير موجودة.");

            if (adv.StatusID == (int)AdvanceStatus.Approved)
                return OperationResult.Fail("تمت الموافقة على هذه السلفة وصرفها بالفعل.");


            var txTypes = _lookupDAL.GetAllTransactionTypes();
            var outType = txTypes.FirstOrDefault(t => t.TypeName == OutTransactionType);
            if (outType == null)
                return OperationResult.Fail($"نوع الحركة ({OutTransactionType}) غير معرّف في النظام.");

            bool updated = _advDAL.UpdateStatus(advanceID, (int)AdvanceStatus.Approved, clsAppSession.CurrentEmployee.EmployeeID);
            if (!updated)
                return OperationResult.Fail("فشل تحديث حالة السلفة.");


            decimal bal = _treasuryDAL.GetCurrentBalance();
            _treasuryDAL.Add(new TreasuryLog
            {
                TransactionTypeID = outType.TransactionTypeID,
                PaymentMethodID = paymentMethodID,
                Amount = adv.Amount,
                AdvanceID = advanceID,
                EmployeeID = adv.EmployeeID,
                ActionDate = DateTime.Now,
                BalanceAfter = bal - adv.Amount,
                Notes = $"سلفة للموظف {adv.EmployeeName}"
            });

            return OperationResult.Ok("تمت الموافقة وصرف السلفة بنجاح.");
        }

        public OperationResult Reject(int advanceID)
        {
            var adv = _advDAL.GetAll().FirstOrDefault(a => a.AdvanceID == advanceID);
            if (adv == null)
                return OperationResult.Fail("السلفة غير موجودة.");

            // تحديث الحالة إلى (مرفوضة = 3)
            int? actionByUserId = clsAppSession.IsLoggedIn ? clsAppSession.CurrentEmployee.EmployeeID : (int?)null;

            _advDAL.UpdateStatus(advanceID, (int)AdvanceStatus.Rejected, actionByUserId);

            return OperationResult.Ok("تم رفض طلب السلفة بنجاح.");
        }

        public OperationResult CancelAdvance(int advanceID)
        {
            var adv = _advDAL.GetAll().FirstOrDefault(a => a.AdvanceID == advanceID);
            if (adv == null)
                return OperationResult.Fail("السلفة غير موجودة.");

            if (adv.StatusID == (int)AdvanceStatus.Approved)
                return OperationResult.Fail("لا يمكن إلغاء سلفة تم صرفها بالفعل.");

            int? actionByUserId = clsAppSession.IsLoggedIn ? clsAppSession.CurrentEmployee.EmployeeID : (int?)null;

            _advDAL.UpdateStatus(advanceID, (int)AdvanceStatus.Canceled, actionByUserId);

            return OperationResult.Ok("تم إلغاء طلب السلفة.");
        }
    }
}