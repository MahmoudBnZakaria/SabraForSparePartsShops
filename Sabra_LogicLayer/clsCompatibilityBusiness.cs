using Sabra.DataLayer;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    public class clsCompatibilityBusiness : clsBusinessBase
    {
        private readonly clsCarCompatibilityDAL _dal = new clsCarCompatibilityDAL();

        public OperationResult<List<CarCompatibility>> GetByPart(int partID) => Execute(()
            => OperationResult<List<CarCompatibility>>.Ok(_dal.GetByPart(partID)));

        public OperationResult<List<CarCompatibility>> SearchByCar(string make, string model, string year = null) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(model))
                return OperationResult<List<CarCompatibility>>.Fail("يجب إدخال الشركة والموديل.");

            return OperationResult<List<CarCompatibility>>.Ok(
                _dal.SearchByCar(make.Trim(), model.Trim(), string.IsNullOrWhiteSpace(year) ? null : year.Trim()));
        });

        public OperationResult Add(CarCompatibility cc) => Execute(() =>
        {
            if (cc == null) return OperationResult.Fail("بيانات التوافق غير صحيحة.");
            if (cc.PartID <= 0) return OperationResult.Fail("يجب اختيار قطعة.");
            if (string.IsNullOrWhiteSpace(cc.CarMake) || string.IsNullOrWhiteSpace(cc.CarModel))
                return OperationResult.Fail("الشركة والموديل مطلوبان.");

            cc.CarMake = cc.CarMake.Trim();
            cc.CarModel = cc.CarModel.Trim();

            bool duplicate = _dal.GetByPart(cc.PartID).Any(x =>
                string.Equals(x.CarMake, cc.CarMake, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.CarModel, cc.CarModel, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.YearRange ?? "", cc.YearRange ?? "", StringComparison.OrdinalIgnoreCase));

            if (duplicate) return OperationResult.Fail("التوافق ده مسجل بالفعل للقطعة دي.");

            _dal.Add(cc);
            return OperationResult.Ok("تمت إضافة التوافق.");
        });

        public OperationResult Delete(int compatibilityID) => Execute(() =>
        {
            if (compatibilityID <= 0) return OperationResult.Fail("رقم التوافق غير صحيح.");
            _dal.Delete(compatibilityID);
            return OperationResult.Ok("تم حذف التوافق.");
        });
    }

}
