using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

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
                // Simplified connection string for XAMPP
                connectionString = "server=localhost;port=3306;database=iskolaraid;uid=root;password=;";
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
                    MessageBox.Show("Database connection successful5!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"MySQL Connection Failed!\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"Connection String: {connectionString}\n\n" +
                    $"Please ensure:\n" +
                    $"1. XAMPP MySQL is running\n" +
                    $"2. Database 'iskolaraid' exists\n" +
                    $"3. MySQL is on port 3306",
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        public static string ConnectionString => connectionString;
    }
}