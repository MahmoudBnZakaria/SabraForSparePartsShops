using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Data;

namespace Sabra.DataLayer
{
    public class clsStaffWalletDAL
    {
        public StaffWallet GetByEmployee(int employeeID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_StaffWallet_GetByEmployee"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                        return new StaffWallet
                        {
                            WalletID = (int)r["Wallet_ID"],
                            EmployeeID = (int)r["Employee_ID"],
                            EmployeeName = r["Full_Name"].ToString(),
                            WalletNumber = r["Wallet_Number"] == DBNull.Value ? null : r["Wallet_Number"].ToString(),
                            CurrentBalance = (decimal)r["Current_Balance"],
                            LastUpdate = (DateTime)r["Last_Update"]
                        };
                    return null;
                }
            }
        }

        public bool CreateWallet(int employeeID, string walletNumber = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_StaffWallet_Create"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                clsDBHelper.AddParam(cmd, "@WalletNumber", walletNumber);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool AdjustBalance(int employeeID, decimal delta)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, "sp_StaffWallet_AdjustBalance"))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                clsDBHelper.AddParam(cmd, "@Delta", delta);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}