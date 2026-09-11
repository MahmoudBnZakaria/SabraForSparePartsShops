using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    public class clsAdvanceBusiness
    {
        private readonly clsAdvanceDAL _advDAL = new clsAdvanceDAL();
        private readonly clsEmployeeDAL _employeeDAL = new clsEmployeeDAL();
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        private const string PendingStatus = "قيد الانتظار";
        private const string ApprovedStatus = "موافق عليها";
        private const string RejectedStatus = "مرفوضة";
        private const string SettledStatus = "مسددة";
        private const string OutTransactionType = "صادر";

        public OperationResult<List<Advance>> GetAll(int? statusID = null, int? employeeID = null)
            => OperationResult<List<Advance>>.Ok(_advDAL.GetAll(statusID, employeeID));

        public OperationResult RequestAdvance(Advance adv)
        {
            if (adv.EmployeeID <= 0)
                return OperationResult.Fail("يجب تحديد الموظف");
            if (adv.Amount <= 0)
                return OperationResult.Fail("قيمة السلفة يجب أن تكون أكبر من الصفر");

            var employee = _employeeDAL.GetByID(adv.EmployeeID);
            if (employee == null)
                return OperationResult.Fail("الموظف غير موجود");

            var statuses = _lookupDAL.GetAllAdvanceStatuses();
            var pending = statuses.FirstOrDefault(s => s.StatusName == PendingStatus);
            if (pending == null)
                return OperationResult.Fail($"حالة ({PendingStatus}) غير معرّفة في النظام.");

            adv.StatusID = pending.StatusID;
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
                return OperationResult.Fail("السلفة غير موجودة");

            var statuses = _lookupDAL.GetAllAdvanceStatuses();
            var approvedSt = statuses.FirstOrDefault(s => s.StatusName == ApprovedStatus);
            if (approvedSt == null)
                return OperationResult.Fail($"حالة ({ApprovedStatus}) غير معرّفة في النظام.");

            if (adv.StatusID == approvedSt.StatusID)
                return OperationResult.Fail("تمت الموافقة على هذه السلفة وصرفها بالفعل.");

            var txTypes = _lookupDAL.GetAllTransactionTypes();
            var outType = txTypes.FirstOrDefault(t => t.TypeName == OutTransactionType);
            if (outType == null)
                return OperationResult.Fail($"نوع الحركة ({OutTransactionType}) غير معرّف في النظام.");

            bool updated = _advDAL.UpdateStatus(advanceID, approvedSt.StatusID, clsAppSession.CurrentEmployee.EmployeeID);
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
                return OperationResult.Fail("السلفة غير موجودة");

            var statuses = _lookupDAL.GetAllAdvanceStatuses();
            var rejectedSt = statuses.FirstOrDefault(s => s.StatusName == RejectedStatus);
            if (rejectedSt == null)
                return OperationResult.Fail($"حالة ({RejectedStatus}) غير معرّفة في النظام.");

            _advDAL.UpdateStatus(advanceID, rejectedSt.StatusID,
                clsAppSession.IsLoggedIn ? clsAppSession.CurrentEmployee.EmployeeID : (int?)null);

            return OperationResult.Ok("تم رفض طلب السلفة");
        }

        public OperationResult MarkSettled(int advanceID)
        {
            var adv = _advDAL.GetAll().FirstOrDefault(a => a.AdvanceID == advanceID);
            if (adv == null)
                return OperationResult.Fail("السلفة غير موجودة");

            var statuses = _lookupDAL.GetAllAdvanceStatuses();
            var settledSt = statuses.FirstOrDefault(s => s.StatusName == SettledStatus);
            if (settledSt == null)
                return OperationResult.Fail($"حالة ({SettledStatus}) غير معرّفة في النظام.");

            _advDAL.UpdateStatus(advanceID, settledSt.StatusID, null);
            return OperationResult.Ok("تم تسديد السلفة.");
        }
    }

}
