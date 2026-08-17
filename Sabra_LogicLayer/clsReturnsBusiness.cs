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
        private readonly clsInventoryDAL _inventoryDAL = new clsInventoryDAL();
        private readonly clsInvoiceDAL _invoiceDAL = new clsInvoiceDAL();
        private readonly clsCustomerDAL _customerDAL = new clsCustomerDAL();
        private readonly clsAuditDAL _auditDAL = new clsAuditDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();

        public OperationResult<List<Return>> GetAll(DateTime? from = null, DateTime? to = null)
            => OperationResult<List<Return>>.Ok(_returnsDAL.GetAll(from , to));

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

            if(ret.Quantity > original.Quantity)
                return OperationResult.Fail(
                    $"الكمية المرتجعة ({ret.Quantity}) أكبر من الكمية في الفاتورة ({original.Quantity}).");

            ret.ReturnDate = DateTime.Today;
            int returnID = _returnsDAL.Add(ret);


            // التحقيق من حالة القطعة المرتجعة 
            var statuses = _lookupDAL.GetAllItemStatuses();
            var returnToStock = statuses.FirstOrDefault(s => s.StatusName == "سليمة ترجع للمخزون");

            if (returnToStock != null && ret.StatusID == returnToStock.StatusID)
            {
                var part = _inventoryDAL.GetByID(ret.PartID);
                if (part != null)
                    _inventoryDAL.UpdateStock(ret.PartID, part.CurrentStock += ret.Quantity);

                var movTypes = _lookupDAL.GetAllMovementTypes();
                var returnType = movTypes.FirstOrDefault(m => m.TypeName == "مرتجع بيع");
                if (returnType != null)
                    _auditDAL.Add(new AuditLog
                    {
                        PartID = ret.PartID,
                        MovementTypeID = returnType.MovementTypeID,
                        QuantityChange = ret.Quantity,
                        UserID = clsAppSession.CurrentUser.UserID,
                        ActionDate = DateTime.Now,
                        Remarks = $"مرتجع من فاتورة {ret.InvoiceID} — {ret.Reason}"
                    });

            }

            // تحديث رصيد العميل لو الفاتورة كانت آجل

            var invoice = _invoiceDAL.GetByID(ret.InvoiceID);
            if (invoice?.CustomerID.HasValue == true) {
                decimal returnValue = ret.Quantity * original.UnitPrice;
                var customer = _customerDAL.GetByID(invoice.CustomerID.Value);

                if (customer != null && customer.TotalBalance > 0)
                {
                    _customerDAL.UpdateBalance(
                            invoice.CustomerID.Value,
                            Math.Max(0, customer.TotalBalance - returnValue),
                            null
                        );
                }
            }

            return OperationResult.Ok("تم تسجيل المرتجع بنجاح.", returnID);

        }

        public OperationResult<List<ItemStatus>> GetItemStatuses()
            => OperationResult<List<ItemStatus>>.Ok(_lookupDAL.GetAllItemStatuses());
    }
}
