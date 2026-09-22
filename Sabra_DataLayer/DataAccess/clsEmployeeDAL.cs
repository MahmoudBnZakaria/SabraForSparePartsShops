
using Microsoft.Data.SqlClient;
using Sabra.DataLayer;
using Sabra.DataLayer.DataAccess;
using Sabra.DataLayer.Models;
using Sabra.DataLayer.ModelsAndSP;
using System.Data;

public class clsEmployeeDAL
{
    private Employee MapEmployee(SqlDataReader r) => new Employee
    {
        EmployeeID = r.GetInt("Employee_ID"),
        PositionID = r.GetInt("Position_ID"),
        PositionName = r.GetStr("Position_Name"),
        FullName = r.GetStr("Full_Name"),
        BasicSalary = r.GetDec("Basic_Salary"),
        HireDate = r.GetDate("Hire_Date"),
        PhoneNumber = r.GetStr("Phone_Number"),
        NationalID = r.GetStr("National_ID"),
        IsActive = r.GetBool("Is_Active"),
        CreatedAt = r.GetDate("Created_At"),
        UpdatedAt = r.GetDate("Updated_At")
    };

    public List<Employee> GetAll(bool activeOnly = false)
    {
        var list = new List<Employee>();
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Employee_GetAll))
        {
            clsDBHelper.AddParam(cmd, "@ActiveOnly", activeOnly);
            conn.Open();
            using (var r = cmd.ExecuteReader())
                while (r.Read())
                    list.Add(MapEmployee(r));
        }
        return list;
    }

    public Employee GetByID(int employeeID)
    {
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Employee_GetByID))
        {
            clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
            conn.Open();
            using (var r = cmd.ExecuteReader())
                return r.Read() ? MapEmployee(r) : null;
        }
    }

    public List<Employee> Search(string keyword)
    {
        var list = new List<Employee>();
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Employee_Search))
        {
            clsDBHelper.AddParam(cmd, "@Keyword", keyword);
            conn.Open();
            using (var r = cmd.ExecuteReader())
                while (r.Read())
                    list.Add(MapEmployee(r));
        }
        return list;
    }

    /// <summary>بترجع الـ Employee_ID الجديد.</summary>
    public int Add(Employee emp)
    {
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Employee_Add))
        {
            clsDBHelper.AddParam(cmd, "@PositionID", emp.PositionID);
            clsDBHelper.AddParam(cmd, "@FullName", emp.FullName);
            clsDBHelper.AddParam(cmd, "@BasicSalary", emp.BasicSalary);
            clsDBHelper.AddParam(cmd, "@HireDate", emp.HireDate.Date);
            clsDBHelper.AddParam(cmd, "@PhoneNumber", emp.PhoneNumber);
            clsDBHelper.AddParam(cmd, "@NationalID", emp.NationalID);
            clsDBHelper.AddParam(cmd, "@IsActive", emp.IsActive);
            var outId = clsDBHelper.AddOutputParam(cmd, "@NewEmployeeID", SqlDbType.Int);

            conn.Open();
            cmd.ExecuteNonQuery();
            return clsDBHelper.GetInt(outId);
        }
    }

    public bool Update(Employee emp)
    {
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Employee_Update))
        {
            clsDBHelper.AddParam(cmd, "@EmployeeID", emp.EmployeeID);
            clsDBHelper.AddParam(cmd, "@PositionID", emp.PositionID);
            clsDBHelper.AddParam(cmd, "@FullName", emp.FullName);
            clsDBHelper.AddParam(cmd, "@BasicSalary", emp.BasicSalary);
            clsDBHelper.AddParam(cmd, "@HireDate", emp.HireDate.Date);
            clsDBHelper.AddParam(cmd, "@PhoneNumber", emp.PhoneNumber);
            clsDBHelper.AddParam(cmd, "@NationalID", emp.NationalID);
            clsDBHelper.AddParam(cmd, "@IsActive", emp.IsActive);
            conn.Open();
            return clsDBHelper.ExecuteBool(cmd);
        }
    }

    public bool Deactivate(int employeeID)
    {
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Employee_Deactivate))
        {
            clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
            conn.Open();
            return clsDBHelper.ExecuteBool(cmd);
        }
    }

    public bool Activate(int employeeID)
    {
        using (var conn = clsConnectionManager.GetConnection())
        using (var cmd = clsDBHelper.CreateSpCommand(conn, SP.Employee_Activate))
        {
            clsDBHelper.AddParam(cmd, "@EmployeeID", employeeID);
            conn.Open();
            return clsDBHelper.ExecuteBool(cmd);
        }
    }
}

