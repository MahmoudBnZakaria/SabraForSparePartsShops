using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.DataLayer
{
    public class clsAdvanceDAL
    {
        private Advance MapAdvance(SqlDataReader r) => new Advance
        {
            AdvanceID = (int)r["Advance_ID"],
            EmployeeID = (int)r["Employee_ID"],
            EmployeeName = r["Employee_Name"].ToString(),
            Amount = (decimal)r["Amount"],
            AdvanceDate = (DateTime)r["Advance_Date"],
            StatusID = (int)r["Status_ID"],
            StatusName = r["Status_Name"].ToString(),
            ApprovedBy = r["Approved_By"] == DBNull.Value ? (int?)null : (int)r["Approved_By"],
            ApprovedByName = r["Approver_Name"] == DBNull.Value ? null : r["Approver_Name"].ToString(),
            CreatedAt = (DateTime)r["Created_At"]
        };

        private const string _selectSql = @"
            SELECT a.*, e.Full_Name AS Employee_Name, appr.Full_Name AS Approver_Name, ads.Status_Name
            FROM ADVANCES a
            JOIN EMPLOYEES       e    ON a.Employee_ID = e.Employee_ID
            JOIN ADVANCE_STATUS  ads  ON a.Status_ID   = ads.Status_ID
            LEFT JOIN EMPLOYEES  appr ON a.Approved_By = appr.Employee_ID";
        public List<Advance> GetAll(int? statusID = null, int? employeeID = null)
        {
            var list = new List<Advance>();
            var sql = new System.Text.StringBuilder(_selectSql + " WHERE 1=1");
            if (statusID.HasValue) sql.Append(" AND a.Status_ID   = @StatusID");
            if (employeeID.HasValue) sql.Append(" AND a.Employee_ID = @EmpID");
            sql.Append(" ORDER BY a.Advance_Date DESC");
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql.ToString(), conn))
            {
                if (statusID.HasValue) cmd.Parameters.AddWithValue("@StatusID", statusID.Value);
                if (employeeID.HasValue) cmd.Parameters.AddWithValue("@EmpID", employeeID.Value);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(MapAdvance(r));
            }
            return list;
        }

        public int Add(Advance adv)
        {
            const string sql = @"
                INSERT INTO ADVANCES (Employee_ID, Amount, Advance_Date, Status_ID)
                VALUES (@EmpID, @Amount, @Date, @StatusID);
                SELECT SCOPE_IDENTITY();";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@EmpID", adv.EmployeeID);
                cmd.Parameters.AddWithValue("@Amount", adv.Amount);
                cmd.Parameters.AddWithValue("@Date", adv.AdvanceDate);
                cmd.Parameters.AddWithValue("@StatusID", adv.StatusID);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool UpdateStatus(int advanceID, int newStatusID, int? approvedBy = null)
        {
            const string sql = @"
                UPDATE ADVANCES SET Status_ID = @StatusID, Approved_By = @ApprovedBy
                WHERE Advance_ID = @ID";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@StatusID", newStatusID);
                cmd.Parameters.AddWithValue("@ApprovedBy", (object)approvedBy ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ID", advanceID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

