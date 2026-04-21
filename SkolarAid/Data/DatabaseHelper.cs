using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SkolarAid.Data
{
    public class DatabaseHelper
    {
        private static string connectionString;

        static DatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["IskolarAidDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                // Fallback for development
                connectionString = "server=localhost;port=3306;database=iskolaraid;uid=root;password=;SslMode=none;Charset=utf8mb4;AllowZeroDateTime=True;ConvertZeroDateTime=True";
            }
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                return false;
            }
        }

        public static string ConnectionString => connectionString;
    }
}