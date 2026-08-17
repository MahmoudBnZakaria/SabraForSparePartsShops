using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.DataLayer
{
    public class clsStaffWalletDAL
    {


        public StaffWallet GetByEmployee(int employeeID)
        {
            const string sql = @"
                SELECT sw.*, e.Full_Name FROM STAFF_WALLETS sw
                JOIN EMPLOYEES e ON sw.Employee_ID = e.Employee_ID
                WHERE sw.Employee_ID = @EmpID";
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@EmpID", employeeID);
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
            using (var cmd = new SqlCommand("INSERT INTO STAFF_WALLETS (Employee_ID, Wallet_Number, Current_Balance) VALUES (@EmpID, @WalletNum, 0)", conn))
            {
                cmd.Parameters.AddWithValue("@EmpID", employeeID);
                cmd.Parameters.AddWithValue("@WalletNum", (object)walletNumber ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateBalance(int employeeID, decimal newBalance)
        {
            using (var conn = clsConnectionManager.GetConnection())
            using (var cmd = new SqlCommand("UPDATE STAFF_WALLETS SET Current_Balance = @Balance, Last_Update = GETDATE() WHERE Employee_ID = @EmpID", conn))
            {
                cmd.Parameters.AddWithValue("@Balance", newBalance);
                cmd.Parameters.AddWithValue("@EmpID", employeeID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

}

