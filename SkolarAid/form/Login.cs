using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form.Admin;
using SkolarAid.form.Scholar;
using SkolarAid.Models;
using System;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = true; // ← ADD THIS LINE (was missing!)
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = txtStudentID.Texts.Trim();
            string password = txtPassword.Texts.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Student ID and Password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT u.id, u.username, u.password, u.role, u.name, u.account_status,
                                    s.id as scholar_id, s.scholar_number, s.first_name, s.middle_name, s.last_name,
                                    s.email, s.status as scholar_status
                                    FROM users u
                                    LEFT JOIN scholars s ON u.id = s.user_id
                                    WHERE u.username = @username";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string accountStatus = reader["account_status"]?.ToString() ?? "Active";

                            if (accountStatus != "Active")
                            {
                                MessageBox.Show("Your account is inactive or locked. Please contact the administrator.",
                                    "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            string dbPassword = reader["password"]?.ToString() ?? "";
                            string role = reader["role"]?.ToString() ?? "";
                            string name = reader["name"]?.ToString() ?? "";

                            if (password == dbPassword)
                            {
                                // Create User object with safe conversions
                                User currentUser = new User
                                {
                                    Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                                    Username = reader["username"]?.ToString() ?? "",
                                    Role = role,
                                    Name = name,
                                    AccountStatus = accountStatus
                                };

                                Scholar currentScholar = null;

                                if (role == "SCHOLAR" && reader["scholar_id"] != DBNull.Value)
                                {
                                    currentScholar = new Scholar
                                    {
                                        Id = Convert.ToInt32(reader["scholar_id"]),
                                        UserId = currentUser.Id,
                                        ScholarNumber = reader["scholar_number"]?.ToString() ?? "",
                                        FirstName = reader["first_name"]?.ToString() ?? "",
                                        MiddleName = reader["middle_name"]?.ToString() ?? "",
                                        LastName = reader["last_name"]?.ToString() ?? "",
                                        Email = reader["email"]?.ToString() ?? "",
                                        Status = reader["scholar_status"]?.ToString() ?? "Active"
                                    };
                                }

                                // Set session with null check
                                if (currentUser != null && currentUser.Id > 0)
                                {
                                    SessionManager.SetCurrentUser(currentUser, currentScholar);
                                }

                                // Update last login
                                if (currentUser.Id > 0)
                                {
                                    UpdateLastLogin(currentUser.Id);

                                    // Log activity - with try-catch to prevent crashes
                                    try
                                    {
                                        ActivityLogger.LogLogin(currentUser.Id, currentUser.Name);
                                    }
                                    catch { }
                                }

                                // Navigate to appropriate dashboard
                                if (role == "ADMIN")
                                {
                                    FrmAdminDashboard adminDashboard = new FrmAdminDashboard();
                                    adminDashboard.Show();
                                    this.Hide();
                                }
                                else if (role == "SCHOLAR")
                                {
                                    if (currentScholar != null && !string.IsNullOrEmpty(currentScholar.Status) && currentScholar.Status == "Active")
                                    {
                                        FrmScholarDashboard scholarDashboard = new FrmScholarDashboard(
                                            currentScholar.Id,
                                            currentScholar.FullName ?? name,
                                            currentScholar.ScholarNumber ?? ""
                                        );
                                        scholarDashboard.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Scholar profile not found or inactive.", "Login Failed",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Student ID or Password.", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Student ID or Password.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show detailed error for debugging
                MessageBox.Show($"Database error: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLastLogin(int userId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE users SET last_login = NOW() WHERE id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Silent fail - non-critical
                Console.WriteLine($"UpdateLastLogin error: {ex.Message}");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Test database connection on form load
            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show("Cannot connect to database. Please check if XAMPP MySQL is running.",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sataPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void sataTextBox1_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
    }
}