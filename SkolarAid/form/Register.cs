using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class Register : Form
    {
        private Dictionary<string, string> _uploadedFiles = new Dictionary<string, string>();
        private string _uploadDirectory = @"C:\xampp\htdocs\skolaraid\uploads\registrations\";

        public Register()
        {
            InitializeComponent();
            InitializeFileUploadControls();
        }

        private void InitializeFileUploadControls()
        {
            // Set up file upload buttons
            SetupFileUploadButton(btnUploadPSA, "PSA Birth Certificate", "PSA");
            SetupFileUploadButton(btnUploadCOE, "Certificate of Enrollment", "COE");
            SetupFileUploadButton(btnUploadCOR, "Certificate of Registration", "COR");
            SetupFileUploadButton(btnUploadGrades, "Latest Grades/TOR", "Grades");
            SetupFileUploadButton(btnUploadContract, "Scholarship Contract", "Contract");

            // Ensure upload directory exists
            if (!Directory.Exists(_uploadDirectory))
            {
                Directory.CreateDirectory(_uploadDirectory);
            }
        }

        private void SetupFileUploadButton(Button btn, string fileType, string fileKey)
        {
            btn.Click += (sender, e) =>
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = $"Select {fileType}";
                    openFileDialog.Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.Multiselect = false;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string fileName = $"{fileKey}_{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(openFileDialog.FileName)}";
                            string destPath = Path.Combine(_uploadDirectory, fileName);

                            // Copy file to upload directory
                            File.Copy(openFileDialog.FileName, destPath, true);

                            // Store relative path
                            string relativePath = $"uploads/registrations/{fileName}";
                            _uploadedFiles[fileKey] = relativePath;

                            // Update button appearance
                            btn.Text = $"✓ {fileType} Uploaded";
                            btn.BackColor = Color.FromArgb(40, 167, 69);
                            btn.ForeColor = Color.White;

                            // Show file name label
                            UpdateFileLabel(fileKey, openFileDialog.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error uploading file: {ex.Message}", "Upload Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };
        }

        private void UpdateFileLabel(string fileKey, string originalFileName)
        {
            switch (fileKey)
            {
                case "PSA":
                    lblPSAFile.Text = $"📎 {Path.GetFileName(originalFileName)}";
                    lblPSAFile.Visible = true;
                    break;
                case "COE":
                    lblCOEFile.Text = $"📎 {Path.GetFileName(originalFileName)}";
                    lblCOEFile.Visible = true;
                    break;
                case "COR":
                    lblCORFile.Text = $"📎 {Path.GetFileName(originalFileName)}";
                    lblCORFile.Visible = true;
                    break;
                case "Grades":
                    lblGradesFile.Text = $"📎 {Path.GetFileName(originalFileName)}";
                    lblGradesFile.Visible = true;
                    break;
                case "Contract":
                    lblContractFile.Text = $"📎 {Path.GetFileName(originalFileName)}";
                    lblContractFile.Visible = true;
                    break;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            sataComboBox1.SelectedIndex = -1;
            cmbScholarshipType.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;

            LoadScholarshipTypes();

            // Set default dates
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);
            dtpEnrollmentDate.Value = DateTime.Now;
            dtpExpectedGraduation.Value = DateTime.Now.AddYears(4);
        }

        private void LoadScholarshipTypes()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, name, stipend_amount, payment_frequency, fund_source, renewal_conditions FROM scholarship_types WHERE status = 'Active' ORDER BY name";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbScholarshipType.DisplayMember = "name";
                    cmbScholarshipType.ValueMember = "id";
                    cmbScholarshipType.DataSource = dt;
                    cmbScholarshipType.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading scholarship types: {ex.Message}");
            }
        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (!ValidateRegistrationForm())
            {
                return;
            }

            try
            {
                if (RegisterScholar())
                {
                    MessageBox.Show("Registration submitted successfully!\n\nYour application will be reviewed by the Scholarship Office.\nYou will receive an email notification once approved.",
                        "Registration Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Login loginForm = new Login();
                    loginForm.Show();
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    MessageBox.Show("This Student ID or Email is already registered.", "Registration Failed",
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

        private bool ValidateRegistrationForm()
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Texts))
            {
                MessageBox.Show("Please enter your Student ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Texts))
            {
                MessageBox.Show("Please enter your First Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Texts))
            {
                MessageBox.Show("Please enter your Last Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Texts))
            {
                MessageBox.Show("Please enter your Email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Texts))
            {
                MessageBox.Show("Please enter a valid Email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContactNumber.Texts))
            {
                MessageBox.Show("Please enter your Contact Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNumber.Focus();
                return false;
            }

            if (cmbScholarshipType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Scholarship Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbScholarshipType.Focus();
                return false;
            }

            if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your Gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
                return false;
            }

            if (cmbYearLevel.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your Year Level.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbYearLevel.Focus();
                return false;
            }

            if (sataComboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your Degree Program.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sataComboBox1.Focus();
                return false;
            }

            // Check required files
            if (!_uploadedFiles.ContainsKey("PSA"))
            {
                MessageBox.Show("Please upload your PSA Birth Certificate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_uploadedFiles.ContainsKey("COE"))
            {
                MessageBox.Show("Please upload your Certificate of Enrollment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_uploadedFiles.ContainsKey("COR"))
            {
                MessageBox.Show("Please upload your Certificate of Registration.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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
                        string fullName = $"{txtFirstName.Texts} {txtMiddleName.Texts} {txtLastName.Texts} {txtSuffix.Texts}".Replace("  ", " ").Trim();
                        string lastNameForDB = string.IsNullOrWhiteSpace(txtSuffix.Texts) ?
                            txtLastName.Texts.Trim() :
                            $"{txtLastName.Texts.Trim()} {txtSuffix.Texts.Trim()}";

                        // Get scholarship details from the selected scholarship type
                        decimal stipendAmount = 0;
                        string stipendFrequency = "Monthly";
                        string fundSource = "Government";
                        string renewalConditions = "";

                        if (cmbScholarshipType.SelectedValue != null)
                        {
                            DataRowView selectedRow = cmbScholarshipType.SelectedItem as DataRowView;
                            if (selectedRow != null)
                            {
                                stipendAmount = Convert.ToDecimal(selectedRow["stipend_amount"]);
                                stipendFrequency = selectedRow["payment_frequency"]?.ToString() ?? "Monthly";
                                fundSource = selectedRow["fund_source"]?.ToString() ?? "Government";
                                renewalConditions = selectedRow["renewal_conditions"]?.ToString() ?? "";
                            }
                        }

                        // 1. Insert into scholar_registrations table
                        string registrationQuery = @"INSERT INTO scholar_registrations 
                            (first_name, middle_name, last_name, suffix, 
                             email, contact_number, 
                             date_of_birth, gender, address,
                             program, hei, degree_program,
                             course, year_level,
                             scholarship_type_id,
                             stipend_amount, stipend_frequency,
                             scholarship_fund_source, renewal_conditions,
                             enrollment_date, expected_graduation,
                             bank_name, bank_account_number,
                             file_psa, file_coe, file_cor, file_grades, file_contract,
                             notes, status, created_at) 
                            VALUES 
                            (@first_name, @middle_name, @last_name, @suffix,
                             @email, @contact_number,
                             @date_of_birth, @gender, @address,
                             @program, @hei, @degree_program,
                             @course, @year_level,
                             @scholarship_type_id,
                             @stipend_amount, @stipend_frequency,
                             @scholarship_fund_source, @renewal_conditions,
                             @enrollment_date, @expected_graduation,
                             @bank_name, @bank_account_number,
                             @file_psa, @file_coe, @file_cor, @file_grades, @file_contract,
                             @notes, 'Pending', NOW());
                           SELECT LAST_INSERT_ID();";

                        MySqlCommand regCmd = new MySqlCommand(registrationQuery, conn, transaction);

                        // Personal Information
                        regCmd.Parameters.AddWithValue("@first_name", txtFirstName.Texts.Trim());
                        regCmd.Parameters.AddWithValue("@middle_name", txtMiddleName.Texts.Trim());
                        regCmd.Parameters.AddWithValue("@last_name", lastNameForDB);
                        regCmd.Parameters.AddWithValue("@suffix", txtSuffix.Texts.Trim());
                        regCmd.Parameters.AddWithValue("@email", txtEmail.Texts.Trim());
                        regCmd.Parameters.AddWithValue("@contact_number", txtContactNumber.Texts.Trim());
                        regCmd.Parameters.AddWithValue("@date_of_birth", dtpDateOfBirth.Value);
                        regCmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem?.ToString() ?? "");
                        regCmd.Parameters.AddWithValue("@address", txtAddress.Texts.Trim());

                        // Academic Information
                        regCmd.Parameters.AddWithValue("@program", cmbProgram.SelectedItem?.ToString() ?? "Undergraduate");
                        regCmd.Parameters.AddWithValue("@hei", txtHEI.Texts.Trim());
                        regCmd.Parameters.AddWithValue("@degree_program", sataComboBox1.SelectedItem?.ToString() ?? "");
                        regCmd.Parameters.AddWithValue("@course", sataComboBox1.SelectedItem?.ToString() ?? "");
                        regCmd.Parameters.AddWithValue("@year_level", cmbYearLevel.SelectedItem?.ToString() ?? "");

                        // Scholarship Information - Auto-filled from scholarship type selection
                        regCmd.Parameters.AddWithValue("@scholarship_type_id", cmbScholarshipType.SelectedValue ?? DBNull.Value);
                        regCmd.Parameters.AddWithValue("@stipend_amount", stipendAmount);
                        regCmd.Parameters.AddWithValue("@stipend_frequency", stipendFrequency);
                        regCmd.Parameters.AddWithValue("@scholarship_fund_source", fundSource);
                        regCmd.Parameters.AddWithValue("@renewal_conditions", renewalConditions);

                        // Dates
                        regCmd.Parameters.AddWithValue("@enrollment_date", dtpEnrollmentDate.Value);
                        regCmd.Parameters.AddWithValue("@expected_graduation", dtpExpectedGraduation.Value);

                        // Banking Information
                        regCmd.Parameters.AddWithValue("@bank_name", txtBankName.Texts.Trim());
                        regCmd.Parameters.AddWithValue("@bank_account_number", txtBankAccountNumber.Texts.Trim());

                        // File Attachments
                        regCmd.Parameters.AddWithValue("@file_psa", _uploadedFiles.ContainsKey("PSA") ? _uploadedFiles["PSA"] : "");
                        regCmd.Parameters.AddWithValue("@file_coe", _uploadedFiles.ContainsKey("COE") ? _uploadedFiles["COE"] : "");
                        regCmd.Parameters.AddWithValue("@file_cor", _uploadedFiles.ContainsKey("COR") ? _uploadedFiles["COR"] : "");
                        regCmd.Parameters.AddWithValue("@file_grades", _uploadedFiles.ContainsKey("Grades") ? _uploadedFiles["Grades"] : "");
                        regCmd.Parameters.AddWithValue("@file_contract", _uploadedFiles.ContainsKey("Contract") ? _uploadedFiles["Contract"] : "");

                        // Notes
                        regCmd.Parameters.AddWithValue("@notes", txtNotes.Texts.Trim());

                        int registrationId = Convert.ToInt32(regCmd.ExecuteScalar());

                        // 2. Log Activity
                        string logQuery = @"INSERT INTO activity_logs (user_name, action_type, table_affected, details) 
                                          VALUES ('System', 'REGISTER', 'scholar_registrations', @details)";

                        MySqlCommand logCmd = new MySqlCommand(logQuery, conn, transaction);
                        logCmd.Parameters.AddWithValue("@details",
                            $"New scholar registration submitted: {fullName} (Student ID: {txtStudentID.Texts.Trim()})");
                        logCmd.ExecuteNonQuery();

                        transaction.Commit();

                        // Clear uploaded files dictionary after successful registration
                        _uploadedFiles.Clear();

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

        // Scholarship type selection changed - auto-fill scholarship details
        private void cmbScholarshipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbScholarshipType.SelectedItem != null)
            {
                DataRowView selectedRow = cmbScholarshipType.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    decimal stipend = Convert.ToDecimal(selectedRow["stipend_amount"]);
                    string frequency = selectedRow["payment_frequency"]?.ToString() ?? "Monthly";
                    string fundSource = selectedRow["fund_source"]?.ToString() ?? "Government";
                    string renewalConditions = selectedRow["renewal_conditions"]?.ToString() ?? "";

                    // Auto-fill the scholarship info display
                    lblAutoStipendAmount.Text = $"₱{stipend:N2}";
                    lblAutoStipendFrequency.Text = frequency;
                    lblAutoFundSource.Text = fundSource;
                    lblAutoRenewalConditions.Text = string.IsNullOrEmpty(renewalConditions) ? "N/A" : renewalConditions;

                    // Show the auto-filled information panel
                    panelAutoFilledInfo.Visible = true;
                }
            }
            else
            {
                // Hide when no scholarship selected
                panelAutoFilledInfo.Visible = false;
                lblAutoStipendAmount.Text = "";
                lblAutoStipendFrequency.Text = "";
                lblAutoFundSource.Text = "";
                lblAutoRenewalConditions.Text = "";
            }
        }
    }
}