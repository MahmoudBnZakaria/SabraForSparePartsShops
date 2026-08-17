using Sabra.DataLayer;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    public class clsSupplierBusiness
    {
        private readonly clsSupplierDAL _dal = new clsSupplierDAL();

        public OperationResult<List<Supplier>> GetAll()
            => OperationResult<List<Supplier>>.Ok(_dal.GetAll());

        public OperationResult<Supplier> GetByID(int id) { 
            var sup = _dal.GetByID(id);
            if (sup == null)
                return OperationResult<Supplier>.Fail("المورد غير موجود");
            return OperationResult<Supplier>.Ok(sup);
        
        }

        public OperationResult<List<Supplier>> Search(string keyword) {
            if (string.IsNullOrWhiteSpace(keyword))
                return OperationResult<List<Supplier>>.Fail("أدخل كلمة للبحث");
            return OperationResult<List<Supplier>>.Ok(_dal.Search(keyword.Trim()));
            
        }

        public OperationResult Add(Supplier supplier) {
            if (string.IsNullOrWhiteSpace(supplier.SupplierName))
                return OperationResult.Fail("اسم المورد مطلوب");
            int newID = _dal.Add(supplier);
            return OperationResult.Ok("تمت إضافة المورد بنجاح", newID);
        }

        public OperationResult Update(Supplier sup) {
            if (string.IsNullOrWhiteSpace(sup.SupplierName))
                return OperationResult.Fail("اسم المورد مطلوب");
            _dal.Update(sup);
            return OperationResult.Ok("تم تحديث بيانات المورد");
        }
    }
}
