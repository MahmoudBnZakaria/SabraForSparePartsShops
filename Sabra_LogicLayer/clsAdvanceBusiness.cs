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
        private readonly clsTreasuryLogDAL _treasuryDAL = new clsTreasuryLogDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        public OperationResult<List<Advance>> GetAll(int? statusID = null, int? employeeID = null)
            => OperationResult<List<Advance>>.Ok(_advDAL.GetAll(statusID, employeeID));

        public OperationResult RequestAdvance(Advance adv)
        {
            if (adv.EmployeeID <= 0)
                return OperationResult.Fail("يجب تحديد الموظف");
            if (adv.Amount <= 0)
                return OperationResult.Fail("قيمة السلفة يجب أن تكون أكبر من الصفر");


            var statuses = _lookupDAL.GetAllAdvanceStatuses();
            adv.StatusID = statuses.First(s => s.StatusName == "قيد الانتظار").StatusID;
            adv.AdvanceDate = DateTime.Today;

            int newID = _advDAL.Add(adv);
            return OperationResult.Ok("تم تسجيل طلب السلفة بنجاح.", newID);
        }

        public OperationResult ApproveAndPay(int advanceID, int paymentMethodID) {
            if (!clsAppSession.IsLoggedIn)
                return OperationResult.Fail("يجب تسجيل الدخول أولاً.");
            var statuses = _lookupDAL.GetAllAdvanceStatuses();
            var approvedSt = statuses.First(s => s.StatusName == "موافق عليها");

            _advDAL.UpdateStatus(advanceID, approvedSt.StatusID, clsAppSession.CurrentEmployee.EmployeeID);

            var advances = _advDAL.GetAll();
            var adv = advances.FirstOrDefault(a => a.AdvanceID == advanceID);
            if (adv == null) return OperationResult.Fail("السلفة غير موجودة");




            var txTypes = _lookupDAL.GetAllTransactionTypes();
            var outType = txTypes.First(t => t.TypeName == "صادر");

            decimal bal = _treasuryDAL.GetCurrentBalance();
            _treasuryDAL.Add(new TreasuryLog {
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


        public OperationResult Reject(int advanceID) {
            var statuses = _lookupDAL.GetAllAdvanceStatuses();
            var rejectedSt = statuses.First(s => s.StatusName == "مرفوضة");

            _advDAL.UpdateStatus(advanceID, rejectedSt.StatusID, clsAppSession.IsLoggedIn ? clsAppSession.CurrentEmployee.EmployeeID : (int?)null);
            return OperationResult.Ok("تم رفض طلب السلفة");
        }

        public OperationResult MarkSettled(int advanceID)
        {
            var statuses = _lookupDAL.GetAllAdvanceStatuses();
            var settledSt = statuses.First(s => s.StatusName == "مسددة");
            _advDAL.UpdateStatus(advanceID, settledSt.StatusID, null);
            return OperationResult.Ok("تم تسديد السلفة.");
        }
    }
}
