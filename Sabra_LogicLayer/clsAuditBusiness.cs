using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;

namespace Sabra.LogicLayer
{
    public class clsAuditBusiness : clsBusinessBase
    {
        private readonly clsAuditDAL _auditDAL = new clsAuditDAL();
        private readonly clsFinancialAuditDAL _financialDAL = new clsFinancialAuditDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();
        private readonly clsUserDAL _userDAL = new clsUserDAL();

        /// <summary>حركات المخزون.</summary>
        public OperationResult<List<AuditLog>> GetAll(int? partID = null, int? movementTypeID = null,
                                                      DateTime? from = null, DateTime? to = null,
                                                      int? userID = null) => Execute(()
            => OperationResult<List<AuditLog>>.Ok(_auditDAL.GetAll(partID, movementTypeID, from, to, userID)));

        /// <summary>سجل التدقيق المالي (مين عمل إيه وإمتى على أي مستند).</summary>
        public OperationResult<List<FinancialAuditLog>> GetFinancialLog(string entityType = null, int? entityID = null,
                                                                        string actionType = null, int? userID = null,
                                                                        DateTime? from = null, DateTime? to = null) => Execute(() =>
                                                                        {
                                                                            var guard = RequirePermission(Permission.Reports, "عرض سجل التدقيق المالي");
                                                                            if (guard != null) return OperationResult<List<FinancialAuditLog>>.Fail(guard.Message);

                                                                            return OperationResult<List<FinancialAuditLog>>.Ok(
                                                                                _financialDAL.GetAll(entityType, entityID, actionType, userID, from, to));
                                                                        });

        public OperationResult<List<FinancialAuditLog>> GetEntityHistory(string entityType, int entityID) => Execute(() =>
        {
            if (string.IsNullOrWhiteSpace(entityType) || entityID <= 0)
                return OperationResult<List<FinancialAuditLog>>.Fail("بيانات المستند غير صحيحة.");

            return OperationResult<List<FinancialAuditLog>>.Ok(_financialDAL.GetByEntity(entityType.Trim(), entityID));
        });

        public OperationResult<List<MovementType>> GetMovementTypes() => Execute(()
            => OperationResult<List<MovementType>>.Ok(clsLookupCache.MovementTypes));

        public OperationResult<List<User>> GetUsers() => Execute(()
            => OperationResult<List<User>>.Ok(_userDAL.GetAll()));
    }

}