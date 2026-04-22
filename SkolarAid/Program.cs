using System;
using System.Windows.Forms;
using SkolarAid.Data;
using SkolarAid.form.Scholar;
using SkolarAid.form.Admin;

namespace SkolarAid
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Test database connection on startup
            if (DatabaseHelper.TestConnection())
            {
                Application.Run(new FrmAdminDashboard());
            }
            else
            {
                MessageBox.Show(
                    "Cannot connect to database. Please ensure:\n\n" +
                    "1. XAMPP is running\n" +
                    "2. MySQL service is started\n" +
                    "3. Database 'iskolaraid' exists\n\n" +
                    "Check App.config for correct connection settings.",
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}