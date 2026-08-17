using Sabra.DataLayer;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    public class clsCustomerBusiness
    {
        private readonly clsCustomerDAL _dal = new clsCustomerDAL();
        public OperationResult<List<Customer>> GetAll()
            => OperationResult<List<Customer>>.Ok(_dal.GetAll());

        public OperationResult<Customer> GetByID(int id) { 
            var cust = _dal.GetByID(id);
            if (cust == null)
                return OperationResult<Customer>.Fail("العميل غير موجود");
            return OperationResult<Customer>.Ok(cust);
        }

        public OperationResult<List<Customer>> Search(string keyword, int? typeID = null, string debtFilter = null)
            => OperationResult<List<Customer>>.Ok(_dal.Search(keyword, typeID, debtFilter));

        public OperationResult Add(Customer cust) {
            if (string.IsNullOrWhiteSpace(cust.CustomerName))
                return OperationResult.Fail("اسم العميل مطلوب.");
            if (cust.CreditLimit < 0)
                return OperationResult.Fail("الحد الائتماني لا يمكن أن يكون سالباً.");

            int newID = _dal.Add(cust);
            return OperationResult.Ok("تمت إضافة العميل بنجاح.", newID);

        }

        public OperationResult Update(Customer cust) {
            if (string.IsNullOrWhiteSpace(cust.CustomerName))
                return OperationResult.Fail("اسم العميل مطلوب");
            _dal.Update(cust);
            return OperationResult.Ok("تم تحديث بيانات العميل");
            
        }

        public bool HasExceededCreditLimit(Customer customer, decimal additionalAmount)
            => customer.CreditLimit > 0 &&
                (customer.TotalBalance + additionalAmount) > customer.CreditLimit;
    }
}
