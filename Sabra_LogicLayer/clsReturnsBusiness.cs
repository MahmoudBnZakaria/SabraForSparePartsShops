using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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
    public class clsReturnsBusiness
    {
        private readonly clsReturnsDAL _returnsDAL = new clsReturnsDAL();
        private readonly clsInvoiceDAL _invoiceDAL = new clsInvoiceDAL();
        private readonly clsCustomerDAL _customerDAL = new clsCustomerDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        private const string ReturnToStockStatus = "سليمة ترجع للمخزون";
        private const string ReturnMovement = "مرتجع بيع";

        public OperationResult<List<Return>> GetAll(DateTime? from = null, DateTime? to = null)
            => OperationResult<List<Return>>.Ok(_returnsDAL.GetAll(from, to));

        public OperationResult ProcessReturn(Return ret)
        {
            if (!clsAppSession.IsLoggedIn)
                return OperationResult.Fail("يجب تسجيل الدخول أولاً.");

            if (ret.Quantity <= 0)
                return OperationResult.Fail("الكمية المرتجعة يجب أن تكون أكبر من صفر.");

            if (string.IsNullOrWhiteSpace(ret.Reason))
                return OperationResult.Fail("سبب الإرجاع مطلوب.");

            var details = _invoiceDAL.GetDetails(ret.InvoiceID);
            var original = details.FirstOrDefault(d => d.PartID == ret.PartID);
            if (original == null)
                return OperationResult.Fail("هذه القطعة غير موجودة في الفاتورة الأصلية");

            if (ret.Quantity > original.Quantity)
                return OperationResult.Fail(
                    $"الكمية المرتجعة ({ret.Quantity}) أكبر من الكمية في الفاتورة ({original.Quantity}).");

            // الإجراء المخزن (sp_Returns_Add) هو من يعيد القطعة فعلياً للمخزون ويسجل
            // حركتها تلقائياً، بشرط تمرير حالة القبول ونوع حركة الإرجاع ومطابقة StatusID لها.
            var statuses = _lookupDAL.GetAllItemStatuses();
            var returnToStock = statuses.FirstOrDefault(s => s.StatusName == ReturnToStockStatus);

            var movTypes = _lookupDAL.GetAllMovementTypes();
            var returnType = movTypes.FirstOrDefault(m => m.TypeName == ReturnMovement);

            ret.ReturnDate = DateTime.Today;

            int returnID = _returnsDAL.Add(
                ret,
                restockOnAccept: returnToStock != null && returnType != null,
                acceptedStatusID: returnToStock?.StatusID,
                restockMovementTypeID: returnType?.MovementTypeID,
                userID: clsAppSession.CurrentUser.UserID);

            // تحديث رصيد العميل لو الفاتورة كانت آجلة وعليه مديونية بالفعل
            var invoice = _invoiceDAL.GetByID(ret.InvoiceID);
            if (invoice?.CustomerID.HasValue == true)
            {
                decimal returnValue = ret.Quantity * original.UnitPrice;
                var customer = _customerDAL.GetByID(invoice.CustomerID.Value);

                if (customer != null && customer.TotalBalance > 0)
                {
                    decimal delta = -Math.Min(returnValue, customer.TotalBalance);
                    _customerDAL.AdjustBalance(invoice.CustomerID.Value, delta, isPayment: false, enforceCreditLimit: false);
                }
            }

            return OperationResult.Ok("تم تسجيل المرتجع بنجاح.", returnID);
        }

        public OperationResult<List<ItemStatus>> GetItemStatuses()
            => OperationResult<List<ItemStatus>>.Ok(_lookupDAL.GetAllItemStatuses());
    }
}
