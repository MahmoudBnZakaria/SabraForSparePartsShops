using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsAdvanceDAL
    {
        private Advance MapAdvance(SqlDataReader r) => new Advance
        {
            AdvanceID = r.GetInt("Advance_ID"),
            EmployeeID = r.GetInt("Employee_ID"),
            EmployeeName = r.GetStr("Employee_Name", "Full_Name"),
            Amount = r.GetDec("Amount"),
            AdvanceDate = r.GetDate("Advance_Date"),
            StatusID = r.GetInt("Status_ID"),
            StatusName = r.GetStr("Status_Name"),
            ApprovedBy = r.GetIntOrNull("Approved_By"),
            ApproverName = r.GetStr("Approver_Name"),
            CreatedAt = r.GetDate("Created_At"),
            TreasuryID = r.GetIntOrNull("Treasury_ID")   // nullable: بيتملى وقت الصرف بس
        };

        public List<Advance> GetAll(int? statusID = null, int? employeeID = null)
        {
            var list = new List<Advance>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Advance_GetAll))
            {
                clsDBHelper.AddParam(cmd, "@StatusID", statusID);
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);

                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(MapAdvance(r));
            }
            return list;
        }

        /// <summary>بتضيف سلفة وترجع الـ Advance_ID الجديد.</summary>
        public int Add(Advance adv, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Advance_Add))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", adv.EmployeeID);
                clsDBHelper.AddParam(cmd, "@Amount", adv.Amount);
                clsDBHelper.AddParam(cmd, "@AdvanceDate", adv.AdvanceDate);
                clsDBHelper.AddParam(cmd, "@StatusID", adv.StatusID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewAdvanceID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetInt(outId);
            }
        }

        /// <summary>صرف السلفة من الخزنة؛ بترجع رقم حركة الخزنة الجديدة.</summary>
        public int Pay(int advanceID, int paymentMethodID, int userID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Advance_Pay))
            {
                clsDBHelper.AddParam(cmd, "@AdvanceID", advanceID);
                clsDBHelper.AddParam(cmd, "@PaymentMethodID", paymentMethodID);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                var outId = clsDBHelper.AddOutputParam(cmd, "@NewTransactionID", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                return clsDBHelper.GetInt(outId);
            }
        }

        /// <summary>
        /// تغيير حالة السلفة. لو isDisbursement = true لازم تبعت paymentMethodID
        /// و disbursementTransactionTypeID عشان الـ SP تسجل الصرف في الخزنة.
        /// </summary>
        public bool UpdateStatus(
            int advanceID,
            int newStatusID,
            int userID,
            int? approvedBy = null,
            bool isDisbursement = false,
            int? paymentMethodID = null,
            int? disbursementTransactionTypeID = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Advance_UpdateStatus))
            {
                clsDBHelper.AddParam(cmd, "@AdvanceID", advanceID);
                clsDBHelper.AddParam(cmd, "@NewStatusID", newStatusID);
                clsDBHelper.AddParam(cmd, "@ApprovedBy", approvedBy);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@IsDisbursement", isDisbursement);
                clsDBHelper.AddParam(cmd, "@PaymentMethodID", paymentMethodID);
                clsDBHelper.AddParam(cmd, "@DisbursementTransactionTypeID", disbursementTransactionTypeID);

                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>اختصار للوصول لحالات السلف (نفس الميثود الموجودة في clsLookupDAL).</summary>
        public List<AdvanceStatus> GetAllStatuses()
        {
            var list = new List<AdvanceStatus>();
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Lookup_GetAllAdvanceStatuses))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new AdvanceStatus
                        {
                            StatusID = r.GetInt("Status_ID"),
                            StatusName = r.GetStr("Status_Name")
                        });
            }
            return list;
        }
    }

}