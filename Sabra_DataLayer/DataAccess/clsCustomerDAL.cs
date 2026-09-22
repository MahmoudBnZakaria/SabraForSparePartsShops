

using Microsoft.Data.SqlClient;
using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System.Data;

public class clsCustomerDAL
{
    private Customer MapCustomer(SqlDataReader r) => new Customer
    {
        CustomerID = r.GetInt("Customer_ID"),
        CustomerName = r.GetStr("Customer_Name"),
        PhoneNumber = r.GetStr("Phone_Number"),
        CustomerTypeID = r.GetIntOrNull("Customer_Type_ID"),
        CustomerType = r.GetStr("Type_Name", "Customer_Type"),
        CreditLimit = r.GetDec("Credit_Limit"),
        TotalBalance = r.GetDec("Total_Balance"),
        LastPaymentDate = r.GetDateOrNull("Last_Payment_Date"),
        CreatedAt = r.GetDate("Created_At")
    };

    public List<Customer> GetAll()
    {
        var list = new List<Customer>();
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Customer_GetAll))
        {
            conn.Open();
            using (var r = cmd.ExecuteReader())
                while (r.Read())
                    list.Add(MapCustomer(r));
        }
        return list;
    }

    public Customer GetByID(int customerID)
    {
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Customer_GetByID))
        {
            clsDBHelper.AddParam(cmd, "@CustomerID", customerID);
            conn.Open();
            using (var r = cmd.ExecuteReader())
                return r.Read() ? MapCustomer(r) : null;
        }
    }

    /// <summary>debtFilter: "hasDebt" أو "exceeded" أو null.</summary>
    public List<Customer> Search(string keyword = null, int? typeID = null, string debtFilter = null)
    {
        var list = new List<Customer>();
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Customer_Search))
        {
            clsDBHelper.AddParam(cmd, "@Keyword", keyword);
            clsDBHelper.AddParam(cmd, "@TypeID", typeID);
            clsDBHelper.AddParam(cmd, "@DebtFilter", debtFilter);
            conn.Open();
            using (var r = cmd.ExecuteReader())
                while (r.Read())
                    list.Add(MapCustomer(r));
        }
        return list;
    }

    /// <summary>بترجع الـ Customer_ID الجديد.</summary>
    public int Add(Customer cust)
    {
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Customer_Add))
        {
            clsDBHelper.AddParam(cmd, "@CustomerName", cust.CustomerName);
            clsDBHelper.AddParam(cmd, "@PhoneNumber", cust.PhoneNumber);
            clsDBHelper.AddParam(cmd, "@CustomerTypeID", cust.CustomerTypeID);
            clsDBHelper.AddParam(cmd, "@CreditLimit", cust.CreditLimit);
            var outId = clsDBHelper.AddOutputParam(cmd, "@NewCustomerID", SqlDbType.Int);

            conn.Open();
            cmd.ExecuteNonQuery();
            return clsDBHelper.GetInt(outId);
        }
    }

    public bool Update(Customer cust)
    {
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Customer_Update))
        {
            clsDBHelper.AddParam(cmd, "@CustomerID", cust.CustomerID);
            clsDBHelper.AddParam(cmd, "@CustomerName", cust.CustomerName);
            clsDBHelper.AddParam(cmd, "@PhoneNumber", cust.PhoneNumber);
            clsDBHelper.AddParam(cmd, "@CustomerTypeID", cust.CustomerTypeID);
            clsDBHelper.AddParam(cmd, "@CreditLimit", cust.CreditLimit);
            conn.Open();
            return clsDBHelper.ExecuteBool(cmd);
        }
    }

    /// <summary>
    /// تعديل رصيد العميل. @UserID مطلوب في الـ SP (كان ناقص قبل كده).
    /// isPayment = true يعني تحصيل (بيقلل المديونية).
    /// </summary>
    public bool AdjustBalance(int customerID, decimal delta, int userID,
                              bool isPayment = false, bool enforceCreditLimit = true,
                              string reason = null)
    {
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Customer_AdjustBalance))
        {
            clsDBHelper.AddParam(cmd, "@CustomerID", customerID);
            clsDBHelper.AddParam(cmd, "@Delta", delta);
            clsDBHelper.AddParam(cmd, "@IsPayment", isPayment);
            clsDBHelper.AddParam(cmd, "@EnforceCreditLimit", enforceCreditLimit);
            clsDBHelper.AddParam(cmd, "@UserID", userID);
            clsDBHelper.AddParam(cmd, "@Reason", reason);
            conn.Open();
            return clsDBHelper.ExecuteBool(cmd);
        }
    }
}
