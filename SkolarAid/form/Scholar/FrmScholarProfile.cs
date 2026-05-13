using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form;
using SkolarAid.form.Scholar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class FrmScholarProfile : Form
    {
        private int _scholarId;
        private string _scholarName;
        private string _scholarNumber;

        public FrmScholarProfile(int scholarId, string scholarName, string scholarNumber)
        {
            InitializeComponent();
            _scholarId = scholarId;
            _scholarName = scholarName;
            _scholarNumber = scholarNumber;

            this.Load += FrmScholarProfile_Load;
        }

        private void FrmScholarProfile_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            lblProfileName.Text = _scholarName;
            lblScholarInfo.Text = _scholarName;

            // Wire sidebar navigation
            btnDashboard.Click += (s, ev) => { new FrmScholarDashboard(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnProfile.Click += (s, ev) => { };
            btnPayments.Click += (s, ev) => { new FrmPaymentHistory(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnCompliance.Click += (s, ev) => { new FrmScholarCompliance(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnNotifications.Click += (s, ev) => { new FrmScholarNotifications(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };

            // Wire logout buttons
            btnLogout.Click += BtnLogout_Click;
            sataButton1.Click += BtnLogout_Click;

            LoadProfileData();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SessionManager.ClearSession();
                new Login().Show();
                this.Close();
            }
        }

        private void LoadProfileData()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT s.*, st.name AS scholarship_type_name, 
                            st.stipend_amount AS scholarship_stipend_amount,
                            st.payment_frequency
                            FROM scholars s
                            LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                            WHERE s.id = @scholarId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", _scholarId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // ===== PERSONAL INFORMATION =====
                            txtFirstName.Text = reader["first_name"]?.ToString() ?? "";
                            txtMiddleName.Text = reader["middle_name"]?.ToString() ?? "";
                            txtLastName.Text = reader["last_name"]?.ToString() ?? "";
                            txtEmail.Text = reader["email"]?.ToString() ?? "";
                            txtContactNumber.Text = reader["contact_number"]?.ToString() ?? "";
                            txtAddress.Text = reader["address"]?.ToString() ?? "";

                            if (reader["date_of_birth"] != DBNull.Value)
                                dtpBirthDate.Value = Convert.ToDateTime(reader["date_of_birth"]);

                            string gender = reader["gender"]?.ToString() ?? "";
                            if (gender == "Male") cmbGender.SelectedIndex = 0;
                            else if (gender == "Female") cmbGender.SelectedIndex = 1;
                            else if (gender == "Other") cmbGender.SelectedIndex = 2;

                            // Bank Info
                            txtBankName.Text = reader["bank_name"]?.ToString() ?? "";
                            txtBankAccountNumber.Text = reader["bank_account_number"]?.ToString() ?? "";

                            // ===== ACADEMIC INFORMATION =====
                            txtStudentID.Text = reader["student_id"]?.ToString() ?? "";
                            txtHEI.Text = reader["hei"]?.ToString() ?? "";

                            // Course - FIXED: Add course if not found in ComboBox
                            string course = reader["course"]?.ToString() ?? "";
                            if (!string.IsNullOrEmpty(course))
                            {
                                int courseIndex = cmbCourse.FindStringExact(course);
                                if (courseIndex >= 0)
                                {
                                    cmbCourse.SelectedIndex = courseIndex;
                                }
                                else
                                {
                                    // Course not in the list, add it and select it
                                    cmbCourse.Items.Add(course);
                                    cmbCourse.SelectedIndex = cmbCourse.Items.Count - 1;
                                }
                            }

                            // Year Level - FIXED: Add year level if not found in ComboBox
                            string yearLevel = reader["year_level"]?.ToString() ?? "";
                            if (!string.IsNullOrEmpty(yearLevel))
                            {
                                int yearIndex = cmbYearLevel.FindStringExact(yearLevel);
                                if (yearIndex >= 0)
                                {
                                    cmbYearLevel.SelectedIndex = yearIndex;
                                }
                                else
                                {
                                    // Year level not in the list, add it and select it
                                    cmbYearLevel.Items.Add(yearLevel);
                                    cmbYearLevel.SelectedIndex = cmbYearLevel.Items.Count - 1;
                                }
                            }

                            // ===== SCHOLARSHIP INFORMATION =====
                            txtScholarNumber.Text = reader["scholar_number"]?.ToString() ?? _scholarNumber;

                            // Scholarship Type - FIXED: Add if not found
                            string scholarshipTypeName = reader["scholarship_type_name"]?.ToString() ?? "";
                            txtScholarshipTypeValue.Text = scholarshipTypeName;

                            // Status
                            string status = reader["status"]?.ToString() ?? "Active";
                            txtStatusValue.Text = status;

                            if (reader["enrollment_date"] != DBNull.Value)
                                dtpEnrollmentDate.Value = Convert.ToDateTime(reader["enrollment_date"]);

                            if (reader["expected_graduation"] != DBNull.Value)
                                dtpExpectedGraduation.Value = Convert.ToDateTime(reader["expected_graduation"]);

                            decimal stipendAmount = reader["scholarship_stipend_amount"] != DBNull.Value ?
                                Convert.ToDecimal(reader["scholarship_stipend_amount"]) : 0;
                            string paymentFreq = reader["payment_frequency"]?.ToString() ?? "";
                            txtStipendAmount.Text = $"₱{stipendAmount:N2} / {paymentFreq}";

                            txtRenewalConditions.Text = reader["renewal_conditions"]?.ToString() ?? "";
                            txtFundSource.Text = reader["scholarship_fund_source"]?.ToString() ?? "";

                            // ===== PROFILE HEADER STATUS =====
                            string scholarStatus = reader["status"]?.ToString() ?? "Active";
                            switch (scholarStatus)
                            {
                                case "Active":
                                    lblProfileStatus.Text = "● Active Scholar";
                                    lblProfileStatus.ForeColor = Color.FromArgb(40, 167, 69);
                                    break;
                                case "Inactive":
                                    lblProfileStatus.Text = "● Inactive Scholar";
                                    lblProfileStatus.ForeColor = Color.FromArgb(150, 150, 150);
                                    break;
                                case "Graduated":
                                    lblProfileStatus.Text = "● Graduated";
                                    lblProfileStatus.ForeColor = Color.FromArgb(0, 123, 255);
                                    break;
                                case "Terminated":
                                    lblProfileStatus.Text = "● Terminated";
                                    lblProfileStatus.ForeColor = Color.FromArgb(239, 68, 68);
                                    break;
                                case "Suspended":
                                    lblProfileStatus.Text = "● Suspended";
                                    lblProfileStatus.ForeColor = Color.FromArgb(255, 170, 0);
                                    break;
                                case "Probation":
                                    lblProfileStatus.Text = "● Probation";
                                    lblProfileStatus.ForeColor = Color.FromArgb(255, 170, 0);
                                    break;
                                default:
                                    lblProfileStatus.Text = $"● {scholarStatus}";
                                    lblProfileStatus.ForeColor = Color.Gray;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Designer event handlers
        private void btnLogout_Click(object sender, EventArgs e) { }
        private void sataButton1_Click(object sender, EventArgs e) { }
        private void panelPersonalInfo_Paint(object sender, PaintEventArgs e) { }
        private void panelContent_Paint(object sender, PaintEventArgs e) { }
    }
}