using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using System;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            sataComboBox1.SelectedIndex = -1;
        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(sataTextBox1.Texts))
            {
                MessageBox.Show("Please enter your Student ID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(sataTextBox3.Texts))
            {
                MessageBox.Show("Please enter your First Name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(sataTextBox5.Texts))
            {
                MessageBox.Show("Please enter your Last Name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (RegisterScholar())
                {
                    MessageBox.Show("Registration successful! You can now login with your Student ID.\nDefault password: scholar123",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Login loginForm = new Login();
                    loginForm.Show();
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    MessageBox.Show("This Student ID is already registered.", "Registration Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Registration failed: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool RegisterScholar()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Create User Account
                        string username = sataTextBox1.Texts.Trim();
                        string password = "scholar123"; // Default password
                        string fullName = $"{sataTextBox3.Texts} {sataTextBox4.Texts} {sataTextBox5.Texts}".Trim();

                        string userQuery = @"INSERT INTO users (username, password, role, name, account_status) 
                                           VALUES (@username, @password, 'SCHOLAR', @name, 'Active');
                                           SELECT LAST_INSERT_ID();";

                        MySqlCommand userCmd = new MySqlCommand(userQuery, conn, transaction);
                        userCmd.Parameters.AddWithValue("@username", username);
                        userCmd.Parameters.AddWithValue("@password", password);
                        userCmd.Parameters.AddWithValue("@name", fullName);

                        int userId = Convert.ToInt32(userCmd.ExecuteScalar());

                        // 2. Generate Scholar Number
                        string scholarNumber = GenerateScholarNumber(conn, transaction);

                        // 3. Create Scholar Record
                        string scholarQuery = @"INSERT INTO scholars 
                            (user_id, student_id, scholar_number, first_name, middle_name, last_name, 
                             email, contact_number, address, program, hei, degree_program, status) 
                            VALUES 
                            (@user_id, @student_id, @scholar_number, @first_name, @middle_name, @last_name, 
                             @email, @contact_number, @address, @program, @hei, @degree_program, 'Active')";

                        MySqlCommand scholarCmd = new MySqlCommand(scholarQuery, conn, transaction);
                        scholarCmd.Parameters.AddWithValue("@user_id", userId);
                        scholarCmd.Parameters.AddWithValue("@student_id", username);
                        scholarCmd.Parameters.AddWithValue("@scholar_number", scholarNumber);
                        scholarCmd.Parameters.AddWithValue("@first_name", sataTextBox3.Texts.Trim());
                        scholarCmd.Parameters.AddWithValue("@middle_name", sataTextBox4.Texts.Trim());
                        scholarCmd.Parameters.AddWithValue("@last_name", sataTextBox5.Texts.Trim());
                        scholarCmd.Parameters.AddWithValue("@email", sataTextBox2.Texts.Trim());
                        scholarCmd.Parameters.AddWithValue("@contact_number", sataTextBox6.Texts.Trim());
                        scholarCmd.Parameters.AddWithValue("@address", sataTextBox9.Texts.Trim());
                        scholarCmd.Parameters.AddWithValue("@program", sataTextBox2.Texts.Trim());
                        scholarCmd.Parameters.AddWithValue("@hei", sataTextBox7.Texts.Trim());
                        scholarCmd.Parameters.AddWithValue("@degree_program", sataComboBox1.SelectedItem?.ToString() ?? "");

                        scholarCmd.ExecuteNonQuery();

                        // 4. Log Activity (system-generated since user not logged in yet)
                        string logQuery = @"INSERT INTO activity_logs (user_name, action_type, table_affected, details) 
                                          VALUES ('System', 'REGISTER', 'users', @details)";

                        MySqlCommand logCmd = new MySqlCommand(logQuery, conn, transaction);
                        logCmd.Parameters.AddWithValue("@details", $"New scholar registered: {fullName} (Student ID: {username})");
                        logCmd.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private string GenerateScholarNumber(MySqlConnection conn, MySqlTransaction transaction)
        {
            string year = DateTime.Now.Year.ToString();

            string query = "SELECT COUNT(*) FROM scholars WHERE scholar_number LIKE @pattern";
            MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@pattern", $"SCH-{year}-%");

            int count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            return $"SCH-{year}-{count:D3}";
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e) { }
    }
}