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

            public static SqlCommand CreateTextCommand(SqlConnection conn, string sql, SqlTransaction tran = null)
            {
                var cmd = new SqlCommand(sql, conn) { CommandType = CommandType.Text };
                if (tran != null) cmd.Transaction = tran;
                return cmd;
            }

            public static SqlParameter AddParam(SqlCommand cmd, string name, object value)
            {
                SqlParameter p;

                if (value == null || value == DBNull.Value)
                {
                    p = new SqlParameter(name, DBNull.Value);
                }
                else if (value is string)
                {
                    var s = (string)value;
                    if (string.IsNullOrWhiteSpace(s))
                    {
                        p = new SqlParameter(name, SqlDbType.NVarChar, 4000) { Value = DBNull.Value };
                    }
                    else
                    {
                        s = s.Trim();
                        p = new SqlParameter(name, SqlDbType.NVarChar, s.Length > 4000 ? -1 : 4000) { Value = s };
                    }
                }
                else if (value is decimal)
                {
                    p = new SqlParameter(name, SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 4,
                        Value = value
                    };
                }
                else if (value is double || value is float)
                {
                    p = new SqlParameter(name, SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 4,
                        Value = Convert.ToDecimal(value)
                    };
                }
                else if (value is DateTime)
                {
                    p = new SqlParameter(name, SqlDbType.DateTime2) { Value = value };
                }
                else if (value is bool)
                {
                    p = new SqlParameter(name, SqlDbType.Bit) { Value = value };
                }
                else if (value is int || value is short || value is byte)
                {
                    p = new SqlParameter(name, SqlDbType.Int) { Value = Convert.ToInt32(value) };
                }
                else if (value is long)
                {
                    p = new SqlParameter(name, SqlDbType.BigInt) { Value = value };
                }
                else
                {
                    p = new SqlParameter(name, value);
                }

                cmd.Parameters.Add(p);
                return p;
            }

            public static SqlParameter AddOutputParam(SqlCommand cmd, string name, SqlDbType type, int size = 0)
            {
                var p = size > 0 ? new SqlParameter(name, type, size) : new SqlParameter(name, type);
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

            public static SqlParameter AddTableValuedParam(SqlCommand cmd, string name, string typeName, DataTable table)
            {
                var p = new SqlParameter(name, SqlDbType.Structured)
                {
                    TypeName = typeName,
                    Value = table
                };
                cmd.Parameters.Add(p);
                return p;
            }

            // ── قراءة قيم الـ OUTPUT parameters بأمان ─────────────────────────────
            public static int GetInt(SqlParameter p) =>
                p == null || p.Value == null || p.Value == DBNull.Value ? 0 : Convert.ToInt32(p.Value);

            public static int? GetNullableInt(SqlParameter p) =>
                p == null || p.Value == null || p.Value == DBNull.Value ? (int?)null : Convert.ToInt32(p.Value);

            public static decimal GetDecimal(SqlParameter p) =>
                p == null || p.Value == null || p.Value == DBNull.Value ? 0m : Convert.ToDecimal(p.Value);

            public static decimal? GetNullableDecimal(SqlParameter p) =>
                p == null || p.Value == null || p.Value == DBNull.Value ? (decimal?)null : Convert.ToDecimal(p.Value);

            public static bool GetBool(SqlParameter p) =>
                p != null && p.Value != null && p.Value != DBNull.Value && Convert.ToBoolean(p.Value);

            /// <summary>
            /// بتنفّذ الأمر وترجع true لو العملية نجحت.
            /// مهم: الـ SPs شغالة بـ SET NOCOUNT ON فبترجع -1، فالمقارنة الصح هي (!= 0)
            /// مش (> 0). أي فشل حقيقي بيطلع كـ SqlException من THROW جوه الـ SP.
            /// </summary>
            public static bool ExecuteBool(SqlCommand cmd) => cmd.ExecuteNonQuery() != 0;

            // ── Table Valued Parameters ───────────────────────────────────────────
            // مهم: ترتيب الأعمدة لازم يطابق ترتيب أعمدة الـ Table Type في الداتابيز،
            // لأن SqlClient بيربط الأعمدة بالترتيب مش بالاسم.
            public static DataTable BuildInvoiceDetailTable(IEnumerable<InvoiceDetail> details)
            {
                var table = new DataTable();
                table.Columns.Add("Part_ID", typeof(int));
                table.Columns.Add("Quantity", typeof(int));
                table.Columns.Add("Unit_Price", typeof(decimal));

                if (details != null)
                    foreach (var d in details)
                        if (d != null)
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
                        if (d != null)
                            table.Rows.Add(d.PartID, d.Quantity, d.UnitPrice);

                return table;
            }
        }
}