using System;
using Microsoft.Data.SqlClient;

namespace ShowroomApp.Data
{
    public class DBHelper
    {
        private static readonly string ConnectionString = "Data Source=ROG-STRIX;Initial Catalog=ShowroomDB;User Id=sa;Password=245072968;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
