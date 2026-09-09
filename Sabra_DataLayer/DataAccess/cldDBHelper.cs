using Microsoft.Data.SqlClient;
using Sabra.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sabra.DataLayer
{
 
    internal static class clsDBHelper
    {
        public static SqlCommand CreateSpCommand(SqlConnection conn, string spName, SqlTransaction tran = null)
        {
            var cmd = new SqlCommand(spName, conn) { CommandType = CommandType.StoredProcedure };
            if (tran != null) cmd.Transaction = tran;
            return cmd;
        }

        public static void AddParam(SqlCommand cmd, string name, object value)
        {
            cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);
        }

        public static SqlParameter AddOutputParam(SqlCommand cmd, string name, SqlDbType type, int size = 0)
        {
            var p = size > 0
                ? new SqlParameter(name, type, size)
                : new SqlParameter(name, type);
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);
            return p;
        }

        public static SqlParameter AddDecimalOutputParam(SqlCommand cmd, string name, byte precision = 18, byte scale = 2)
        {
            var p = new SqlParameter(name, SqlDbType.Decimal)
            {
                Direction = ParameterDirection.Output,
                Precision = precision,
                Scale = scale
            };
            cmd.Parameters.Add(p);
            return p;
        }

        public static int? GetNullableInt(SqlParameter p) =>
            p.Value == null || p.Value == DBNull.Value ? (int?)null : Convert.ToInt32(p.Value);

        public static decimal? GetNullableDecimal(SqlParameter p) =>
            p.Value == null || p.Value == DBNull.Value ? (decimal?)null : Convert.ToDecimal(p.Value);

        public static bool GetBool(SqlParameter p) =>
            p.Value != null && p.Value != DBNull.Value && Convert.ToBoolean(p.Value);



        public static DataTable BuildInvoiceDetailTable(IEnumerable<InvoiceDetail> details)
        {
            var table = new DataTable();
            table.Columns.Add("Part_ID", typeof(int));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Unit_Price", typeof(decimal));

            if (details != null)
                foreach (var d in details)
                    table.Rows.Add(d.PartID, d.Quantity, d.UnitPrice);

            return table;
        }

        public static DataTable BuildPODetailTable(IEnumerable<PurchaseOrderDetail> details)
        {
            var table = new DataTable();
            table.Columns.Add("Part_ID", typeof(int));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Unit_Price", typeof(decimal));

            if (details != null)
                foreach (var d in details)
                    table.Rows.Add(d.PartID, d.Quantity, d.UnitPrice);

            return table;
        }



        public static SqlParameter AddTableValuedParam(SqlCommand cmd, string name, string typeName, DataTable table)
        {
            var p = cmd.Parameters.AddWithValue(name, table);
            p.SqlDbType = SqlDbType.Structured;
            p.TypeName = typeName;
            return p;
        }
    }
}