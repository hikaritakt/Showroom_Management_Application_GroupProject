using Microsoft.Data.SqlClient;
using ShowroomApp.Shared;
using System.Data;

namespace ShowroomApp.Data
{
    internal static class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(Constants.ConnectionString);
        }

        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            using SqlCommand cmd = new(query, conn);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            using SqlDataAdapter adapter = new(cmd);
            DataTable table = new();
            adapter.Fill(table);
            return table;
        }

        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();
            using SqlCommand cmd = new(query, conn);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            return cmd.ExecuteNonQuery();
        }

        public static object? ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();
            using SqlCommand cmd = new(query, conn);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            return cmd.ExecuteScalar();
        }
    }
}