using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;

namespace Sabra.LogicLayer
{
    public class clsAuditBusiness
    {
        private readonly clsAuditDAL _auditDAL = new clsAuditDAL();
        private readonly clsLookupDAL _lookupDAL = new clsLookupDAL();
        private readonly clsUserDAL _userDAL = new clsUserDAL();


        public OperationResult<List<AuditLog>> GetAll(
            int? partID = null,
            int? movementTypeID = null,
            DateTime? from = null,
            DateTime? to = null,
            int? userID = null)
            => OperationResult<List<AuditLog>>.Ok(
                   _auditDAL.GetAll(partID, movementTypeID, from, to, userID));

        public OperationResult<List<MovementType>> GetMovementTypes()
            => OperationResult<List<MovementType>>.Ok(_lookupDAL.GetAllMovementTypes());

        public OperationResult<List<User>> GetUsers()
            => OperationResult<List<User>>.Ok(_userDAL.GetAll());
    }
}