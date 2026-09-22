using Sabra.DataLayer;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{


    public class clsSupplierBusiness : clsBusinessBase
    {
        private readonly clsSupplierDAL _dal = new clsSupplierDAL();
        private readonly clsReportsDAL _reportsDAL = new clsReportsDAL();

        public OperationResult<List<Supplier>> GetAll() => Execute(()
            => OperationResult<List<Supplier>>.Ok(_dal.GetAll()));

        public OperationResult<Supplier> GetByID(int supplierID) => Execute(() =>
        {
            var sup = _dal.GetByID(supplierID);
            return sup == null
                ? OperationResult<Supplier>.Fail("المورد غير موجود.")
                : OperationResult<Supplier>.Ok(sup);
        });

        public OperationResult<List<Supplier>> Search(string keyword) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return OperationResult<List<Supplier>>.Fail("أدخل كلمة للبحث.");
            return OperationResult<List<Supplier>>.Ok(_dal.Search(keyword.Trim()));
        });

        public OperationResult Add(Supplier supplier) => Execute(() =>
        {
            if (supplier == null) return OperationResult.Fail("بيانات المورد غير صحيحة.");
            if (string.IsNullOrWhiteSpace(supplier.SupplierName)) return OperationResult.Fail("اسم المورد مطلوب.");
            if (supplier.SupplierBalance < 0) return OperationResult.Fail("الرصيد الافتتاحي لا يمكن أن يكون سالباً.");

            supplier.SupplierName = supplier.SupplierName.Trim();
            int newID = _dal.Add(supplier);
            return OperationResult.Ok("تمت إضافة المورد بنجاح.", newID);
        });

        public OperationResult Update(Supplier sup) => Execute(() =>
        {
            if (sup == null) return OperationResult.Fail("بيانات المورد غير صحيحة.");
            if (string.IsNullOrWhiteSpace(sup.SupplierName)) return OperationResult.Fail("اسم المورد مطلوب.");

            var existing = _dal.GetByID(sup.SupplierID);
            if (existing == null) return OperationResult.Fail("المورد غير موجود.");

            sup.SupplierName = sup.SupplierName.Trim();
            _dal.Update(sup);
            return OperationResult.Ok("تم تحديث بيانات المورد.");
        });

        /// <summary>تسوية يدوية لرصيد المورد (delta موجب = زيادة مديونيتنا له).</summary>
        public OperationResult AdjustBalance(int supplierID, decimal delta, string reason) => Execute(() =>
        {
            var guard = RequirePermission(Permission.Treasury, "تعديل أرصدة الموردين يدويًا");
            if (guard != null) return guard;

            if (delta == 0) return OperationResult.Fail("قيمة التعديل لا يمكن أن تكون صفر.");
            if (string.IsNullOrWhiteSpace(reason)) return OperationResult.Fail("سبب التعديل مطلوب.");

            var sup = _dal.GetByID(supplierID);
            if (sup == null) return OperationResult.Fail("المورد غير موجود.");

            _dal.AdjustBalance(supplierID, delta, clsAppSession.UserID, reason.Trim());
            return OperationResult.Ok("تم تعديل رصيد المورد.");
        });

        public OperationResult<List<SupplierStatementView>> GetStatement(int supplierID) => Execute(() =>
        {
            if (supplierID <= 0) return OperationResult<List<SupplierStatementView>>.Fail("يجب اختيار المورد.");
            return OperationResult<List<SupplierStatementView>>.Ok(_reportsDAL.GetSupplierStatement(supplierID));
        });

        public OperationResult<List<SupplierPerformanceView>> GetPerformance() => Execute(()
            => OperationResult<List<SupplierPerformanceView>>.Ok(_reportsDAL.GetSupplierPerformance()));
    }

}
