using Microsoft.Data.SqlClient;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System;
using System.Data;

namespace Sabra.DataLayer
{

    public class clsStaffWalletDAL
    {
        public StaffWallet GetByEmployee(int employeeID)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.StaffWallet_GetByEmployee))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;

                    return new StaffWallet
                    {
                        WalletID = r.GetInt("Wallet_ID"),
                        EmployeeID = r.GetInt("Employee_ID"),
                        EmployeeName = r.GetStr("Full_Name", "Employee_Name"),
                        WalletNumber = r.GetStr("Wallet_Number"),
                        CurrentBalance = r.GetDec("Current_Balance"),
                        LastUpdate = r.GetDate("Last_Update")
                    };
                }
            }
        }

        public bool CreateWallet(int employeeID, string walletNumber = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.StaffWallet_Create))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                clsDBHelper.AddParam(cmd, "@WalletNumber", walletNumber);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }

        /// <summary>delta موجب = إيداع، سالب = سحب. @UserID مطلوب في الـ SP.</summary>
        public bool AdjustBalance(int employeeID, decimal delta, int userID, string reason = null)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.StaffWallet_AdjustBalance))
            {
                clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
                clsDBHelper.AddParam(cmd, "@Delta", delta);
                clsDBHelper.AddParam(cmd, "@UserID", userID);
                clsDBHelper.AddParam(cmd, "@Reason", reason);
                conn.Open();
                return clsDBHelper.ExecuteBool(cmd);
            }
        }
    }

}