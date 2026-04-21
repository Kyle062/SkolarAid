using System;
using MySql.Data.MySqlClient;
using SkolarAid.Data;

namespace SkolarAid.Classes
{
    public static class ActivityLogger
    {
        public static void Log(string actionType, string details, string tableAffected = null, int? recordId = null)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO activity_logs 
                        (user_id, user_name, action_type, table_affected, record_id, details) 
                        VALUES (@userId, @userName, @actionType, @tableAffected, @recordId, @details)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    var currentUser = SessionManager.CurrentUser;
                    cmd.Parameters.AddWithValue("@userId", currentUser?.Id);
                    cmd.Parameters.AddWithValue("@userName", currentUser?.Name ?? "System");
                    cmd.Parameters.AddWithValue("@actionType", actionType);
                    cmd.Parameters.AddWithValue("@tableAffected", (object)tableAffected ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@recordId", (object)recordId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@details", details);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // Silently fail - logging shouldn't break the app
            }
        }

        public static void LogLogin(int userId, string userName)
        {
            Log("LOGIN", $"{userName} logged into the system", "users", userId);
        }

        public static void LogLogout(int userId, string userName)
        {
            Log("LOGOUT", $"{userName} logged out", "users", userId);
        }

        public static void LogCreate(string tableName, int recordId, string details)
        {
            Log("CREATE", details, tableName, recordId);
        }

        public static void LogUpdate(string tableName, int recordId, string details)
        {
            Log("UPDATE", details, tableName, recordId);
        }

        public static void LogDelete(string tableName, int recordId, string details)
        {
            Log("DELETE", details, tableName, recordId);
        }
    }
}