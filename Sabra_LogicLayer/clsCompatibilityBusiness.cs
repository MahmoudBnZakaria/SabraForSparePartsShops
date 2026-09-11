using Sabra.DataLayer;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer
{
    public class clsCompatibilityBusiness
    {
        private readonly clsCarCompatibilityDAL _dal = new clsCarCompatibilityDAL();

        public OperationResult<List<CarCompatibility>> GetByPart(int partID)
            => OperationResult<List<CarCompatibility>>.Ok(_dal.GetByPart(partID));

        public OperationResult<List<CarCompatibility>> SearchByCar(string make, string model, string year = null)
        {
            if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(model))
                return OperationResult<List<CarCompatibility>>.Fail("يجب إدخال الشركة والموديل.");

            var list = _dal.SearchByCar(make.Trim(), model.Trim(), string.IsNullOrWhiteSpace(year) ? null : year.Trim());
            return OperationResult<List<CarCompatibility>>.Ok(list);
        }

        public OperationResult Add(CarCompatibility cc)
        {
            if (cc.PartID <= 0)
                return OperationResult.Fail("يجب اختيار قطعة");
            if (string.IsNullOrWhiteSpace(cc.CarMake) || string.IsNullOrWhiteSpace(cc.CarModel))
                return OperationResult.Fail("الشركة والموديل مطلوبان");

            _dal.Add(cc);
            return OperationResult.Ok("تمت إضافة التوافق");
        }

        public OperationResult Delete(int compatibilityID)
        {
            _dal.Delete(compatibilityID);
            return OperationResult.Ok("تم حذف التوافق");
        }
    }

}
