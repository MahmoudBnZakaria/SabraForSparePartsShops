using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{

    public class clsCustomerBusiness : clsBusinessBase
    {
        private readonly clsCustomerDAL _dal = new clsCustomerDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();
        private readonly clsReportsDAL _reportsDAL = new clsReportsDAL();

        public OperationResult<List<Customer>> GetAll() => Execute(()
            => OperationResult<List<Customer>>.Ok(_dal.GetAll()));

        public OperationResult<Customer> GetByID(int customerID) => Execute(() =>
        {
            var cust = _dal.GetByID(customerID);
            return cust == null
                ? OperationResult<Customer>.Fail("العميل غير موجود.")
                : OperationResult<Customer>.Ok(cust);
        });

        /// <summary>debtFilter: "hasDebt" أو "exceeded" أو null.</summary>
        public OperationResult<List<Customer>> Search(string keyword, int? typeID = null, string debtFilter = null) => Execute(()
            => OperationResult<List<Customer>>.Ok(_dal.Search(string.IsNullOrWhiteSpace(keyword) ? null : keyword.Trim(), typeID, debtFilter)));

        public OperationResult<List<CustomerType>> GetCustomerTypes() => Execute(()
            => OperationResult<List<CustomerType>>.Ok(_lookupDAL.GetAllCustomerTypes()));

        public OperationResult Add(Customer cust) => Execute(() =>
        {
            var invalid = Validate(cust);
            if (invalid != null) return invalid;

            cust.CustomerName = cust.CustomerName.Trim();
            int newID = _dal.Add(cust);
            return OperationResult.Ok("تمت إضافة العميل بنجاح.", newID);
        });

        public OperationResult Update(Customer cust) => Execute(() =>
        {
            var invalid = Validate(cust);
            if (invalid != null) return invalid;

            var existing = _dal.GetByID(cust.CustomerID);
            if (existing == null) return OperationResult.Fail("العميل غير موجود.");

            // منع خفض الحد الائتماني تحت المديونية الحالية
            if (cust.CreditLimit > 0 && cust.CreditLimit < existing.TotalBalance)
                return OperationResult.Fail(
                    $"الحد الائتماني ({cust.CreditLimit:N2}) أقل من مديونية العميل الحالية ({existing.TotalBalance:N2}).");

            cust.CustomerName = cust.CustomerName.Trim();
            _dal.Update(cust);
            return OperationResult.Ok("تم تحديث بيانات العميل.");
        });

        /// <summary>
        /// تعديل يدوي على رصيد العميل (تسوية). delta موجب = زيادة مديونية،
        /// سالب = تقليلها. بيتسجل في سجل التدقيق المالي باسم المستخدم والسبب.
        /// </summary>
        public OperationResult AdjustBalance(int customerID, decimal delta, string reason, bool isPayment = false) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Treasury, "تعديل أرصدة العملاء يدويًا");
            if (guard != null) return guard;

            if (delta == 0) return OperationResult.Fail("قيمة التعديل لا يمكن أن تكون صفر.");
            if (string.IsNullOrWhiteSpace(reason)) return OperationResult.Fail("سبب التعديل مطلوب.");

            var cust = _dal.GetByID(customerID);
            if (cust == null) return OperationResult.Fail("العميل غير موجود.");

            bool ok = _dal.AdjustBalance(customerID, delta, clsAppSession.UserID,
                                         isPayment: isPayment, enforceCreditLimit: delta > 0, reason: reason.Trim());

            return ok ? OperationResult.Ok("تم تعديل رصيد العميل.")
                      : OperationResult.Fail("لم يتم تعديل الرصيد.");
        });

        public OperationResult<List<CustomersWithDebtView>> GetCustomersWithDebt() => Execute(()
            => OperationResult<List<CustomersWithDebtView>>.Ok(_reportsDAL.GetCustomersWithDebt()));

        public OperationResult<List<CustomerStatementView>> GetStatement(int customerID, DateTime? from = null, DateTime? to = null) => Execute(() =>
        {
            if (customerID <= 0) return OperationResult<List<CustomerStatementView>>.Fail("يجب اختيار العميل.");
            return OperationResult<List<CustomerStatementView>>.Ok(_reportsDAL.GetCustomerStatement(customerID, from, to));
        });

        public bool HasExceededCreditLimit(Customer customer, decimal additionalAmount)
            => customer != null && customer.CreditLimit > 0 &&
               (customer.TotalBalance + additionalAmount) > customer.CreditLimit;

        private static OperationResult Validate(Customer cust)
        {
            if (cust == null) return OperationResult.Fail("بيانات العميل غير صحيحة.");
            if (string.IsNullOrWhiteSpace(cust.CustomerName)) return OperationResult.Fail("اسم العميل مطلوب.");
            if (cust.CustomerName.Trim().Length > 150) return OperationResult.Fail("اسم العميل طويل جدًا (150 حرف كحد أقصى).");
            if (!string.IsNullOrWhiteSpace(cust.PhoneNumber) && cust.PhoneNumber.Trim().Length > 20)
                return OperationResult.Fail("رقم الهاتف طويل جدًا.");
            if (cust.CreditLimit < 0) return OperationResult.Fail("الحد الائتماني لا يمكن أن يكون سالباً.");
            return null;
        }
    }
}
