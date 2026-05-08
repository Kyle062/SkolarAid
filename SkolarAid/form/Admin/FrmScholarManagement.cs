using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form;
using SkolarAid.form.Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class FrmScholarManagement : Form
    {
        private int _currentScholarId = 0;

        public FrmScholarManagement()
        {
            InitializeComponent();
            this.Load += FrmScholarManagement_Load;
            this.Resize += FrmScholarManagement_Resize;
        }

        private void FrmScholarManagement_Resize(object sender, EventArgs e)
        {
            AdjustLayoutForFullscreen();
        }

        private void AdjustLayoutForFullscreen()
        {
            int screenWidth = this.ClientSize.Width;
            int screenHeight = this.ClientSize.Height;

            // Sidebar stays fixed at 280px
            // Main content starts at 301px

            // Search bar - full width
            if (panelSearchBar != null)
            {
                panelSearchBar.Location = new Point(301, 180);
                panelSearchBar.Size = new Size(screenWidth - 321, 75);

                // Adjust search textbox to use available space
                if (txtSearch != null)
                {
                    int searchWidth = screenWidth - 321 - 750; // Leave room for filters and button
                    txtSearch.Size = new Size(Math.Max(200, searchWidth), 27);
                }
            }

            // Scholar list grid - takes 65% of width
            int gridWidth = (int)((screenWidth - 321) * 0.62);
            int formWidth = screenWidth - 321 - gridWidth - 20;

            if (panelScholarList != null)
            {
                panelScholarList.Location = new Point(301, 275);
                panelScholarList.Size = new Size(gridWidth, screenHeight - 305);
            }

            // Form panel - takes 35% of width
            if (panelForm != null)
            {
                panelForm.Location = new Point(301 + gridWidth + 15, 275);
                panelForm.Size = new Size(formWidth, screenHeight - 305);
            }

            // Adjust form fields for wider panel
            if (formWidth > 400)
            {
                AdjustFormFields(formWidth);
            }
        }

        private void AdjustFormFields(int formWidth)
        {
            int fieldWidth = (formWidth - 70) / 2;
            int fullWidth = formWidth - 70;

            if (txtFirstName != null) txtFirstName.Size = new Size(fieldWidth, 25);
            if (txtLastName != null) { txtLastName.Size = new Size(fieldWidth, 25); txtLastName.Location = new Point(25 + fieldWidth + 15, 110); }
            if (lblLastName != null) lblLastName.Location = new Point(22 + fieldWidth + 15, 90);

            if (txtMiddleName != null) txtMiddleName.Size = new Size(fieldWidth, 25);
            if (txtEmail != null) txtEmail.Size = new Size(fullWidth, 25);
            if (txtContactNumber != null) txtContactNumber.Size = new Size(fieldWidth, 25);

            if (cmbCourse != null) cmbCourse.Size = new Size(fullWidth, 28);
            if (cmbYearLevel != null) cmbYearLevel.Size = new Size(fieldWidth, 28);
            if (cmbScholarshipType != null) cmbScholarshipType.Size = new Size(fullWidth, 28);

            if (dtpEnrollmentDate != null) dtpEnrollmentDate.Size = new Size(fieldWidth, 25);
            if (dtpExpectedGraduation != null) { dtpExpectedGraduation.Size = new Size(fieldWidth, 25); dtpExpectedGraduation.Location = new Point(25 + fieldWidth + 15, 567); }
            if (lblExpectedGrad != null) lblExpectedGrad.Location = new Point(22 + fieldWidth + 15, 547);

            if (cmbStatus != null) cmbStatus.Size = new Size(fieldWidth, 28);
            if (txtScholarNumber != null) { txtScholarNumber.Size = new Size(fieldWidth, 25); txtScholarNumber.Location = new Point(25 + fieldWidth + 15, 627); }
            if (lblScholarNumber != null) lblScholarNumber.Location = new Point(22 + fieldWidth + 15, 607);

            // Reposition buttons
            int buttonY = panelForm.Height - 75;
            if (btnSave != null) btnSave.Location = new Point(25, buttonY);
            if (btnUpdate != null) btnUpdate.Location = new Point(95, buttonY);
            if (btnDeactivate != null) btnDeactivate.Location = new Point(180, buttonY);
            if (btnViewDetails != null) btnViewDetails.Location = new Point(295, buttonY);
            if (btnCancel != null) btnCancel.Location = new Point(formWidth - 195, buttonY);
        }

        private void FrmScholarManagement_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            string adminName = SessionManager.CurrentUser?.Name ?? "Administrator";
            lblGreeting.Text = $"Scholar Management - {adminName}";

            LoadFilterOptions();
            LoadScholarsGrid();
            LoadScholarshipTypes();
            LoadCourses();
            ClearForm();

            dtpEnrollmentDate.Value = DateTime.Now;
            dtpExpectedGraduation.Value = DateTime.Now.AddYears(4);

            txtSearch.Text = "Search scholar...";
            txtSearch.ForeColor = Color.Gray;

            AdjustLayoutForFullscreen();
        }

        private void LoadFilterOptions()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    cmbFilterStatus.Items.Clear();
                    cmbFilterStatus.Items.Add("All Status");
                    cmbFilterStatus.Items.Add("Active");
                    cmbFilterStatus.Items.Add("Inactive");
                    cmbFilterStatus.Items.Add("Graduated");
                    cmbFilterStatus.Items.Add("Terminated");

                    string query = "SELECT name FROM scholarship_types WHERE is_active = TRUE ORDER BY name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbFilterScholarship.Items.Clear();
                        cmbFilterScholarship.Items.Add("All Scholarships");

                        while (reader.Read())
                        {
                            cmbFilterScholarship.Items.Add(reader["name"].ToString());
                        }
                    }
                }

                if (cmbFilterStatus.Items.Count > 0)
                    cmbFilterStatus.SelectedIndex = 0;

                if (cmbFilterScholarship.Items.Count > 0)
                    cmbFilterScholarship.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading filter options: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Database Loading Methods

        private void LoadScholarsGrid()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT s.id, s.scholar_number, s.student_id,
                            CONCAT(s.first_name, ' ', COALESCE(s.middle_name, ''), ' ', s.last_name) AS full_name,
                            s.first_name, s.middle_name, s.last_name,
                            s.course, s.year_level, st.name AS scholarship_name, s.status,
                            s.email, s.contact_number, s.enrollment_date, s.expected_graduation,
                            s.hei, s.degree_program
                            FROM scholars s
                            LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                            WHERE 1=1";

                    if (cmbFilterStatus.SelectedIndex > 0 && cmbFilterStatus.SelectedItem != null)
                        query += " AND s.status = @status";

                    if (cmbFilterScholarship.SelectedIndex > 0 && cmbFilterScholarship.SelectedItem != null)
                        query += " AND st.name = @scholarship";

                    if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "Search scholar...")
                        query += " AND (s.scholar_number LIKE @search OR s.first_name LIKE @search OR s.last_name LIKE @search OR s.student_id LIKE @search)";

                    query += " ORDER BY s.id DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (cmbFilterStatus.SelectedIndex > 0 && cmbFilterStatus.SelectedItem != null)
                        cmd.Parameters.AddWithValue("@status", cmbFilterStatus.SelectedItem.ToString());

                    if (cmbFilterScholarship.SelectedIndex > 0 && cmbFilterScholarship.SelectedItem != null)
                        cmd.Parameters.AddWithValue("@scholarship", cmbFilterScholarship.SelectedItem.ToString());

                    if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "Search scholar...")
                        cmd.Parameters.AddWithValue("@search", $"%{txtSearch.Text}%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvScholars.Rows.Clear();

                        while (reader.Read())
                        {
                            int rowIndex = dgvScholars.Rows.Add();
                            dgvScholars.Rows[rowIndex].Cells["colScholarID"].Value = reader["id"];
                            dgvScholars.Rows[rowIndex].Cells["colScholarNumber"].Value = reader["scholar_number"];
                            dgvScholars.Rows[rowIndex].Cells["colStudentID"].Value = reader["student_id"];
                            dgvScholars.Rows[rowIndex].Cells["colName"].Value = reader["full_name"];
                            dgvScholars.Rows[rowIndex].Cells["colCourse"].Value = reader["course"];
                            dgvScholars.Rows[rowIndex].Cells["colYearLevel"].Value = reader["year_level"];
                            dgvScholars.Rows[rowIndex].Cells["colScholarship"].Value = reader["scholarship_name"];
                            dgvScholars.Rows[rowIndex].Cells["colStatus"].Value = reader["status"];

                            // Store additional data in Tag for view details
                            var scholarData = new ScholarDetailData
                            {
                                ScholarId = Convert.ToInt32(reader["id"]),
                                ScholarNumber = reader["scholar_number"]?.ToString(),
                                StudentId = reader["student_id"]?.ToString(),
                                FirstName = reader["first_name"]?.ToString(),
                                MiddleName = reader["middle_name"]?.ToString(),
                                LastName = reader["last_name"]?.ToString(),
                                Email = reader["email"]?.ToString(),
                                ContactNumber = reader["contact_number"]?.ToString(),
                                Course = reader["course"]?.ToString(),
                                YearLevel = reader["year_level"]?.ToString(),
                                ScholarshipName = reader["scholarship_name"]?.ToString(),
                                Status = reader["status"]?.ToString(),
                                EnrollmentDate = reader["enrollment_date"] != DBNull.Value ? Convert.ToDateTime(reader["enrollment_date"]) : (DateTime?)null,
                                ExpectedGraduation = reader["expected_graduation"] != DBNull.Value ? Convert.ToDateTime(reader["expected_graduation"]) : (DateTime?)null,
                                HEI = reader["hei"]?.ToString(),
                                DegreeProgram = reader["degree_program"]?.ToString()
                            };
                            dgvScholars.Rows[rowIndex].Tag = scholarData;

                            // Color code status
                            string status = reader["status"].ToString();
                            var statusCell = dgvScholars.Rows[rowIndex].Cells["colStatus"];
                            if (status == "Active")
                            {
                                statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                                statusCell.Style.Font = new Font(dgvScholars.Font, FontStyle.Bold);
                            }
                            else if (status == "Inactive")
                            {
                                statusCell.Style.ForeColor = Color.FromArgb(255, 170, 0);
                                statusCell.Style.Font = new Font(dgvScholars.Font, FontStyle.Bold);
                            }
                            else if (status == "Graduated")
                            {
                                statusCell.Style.ForeColor = Color.FromArgb(0, 123, 255);
                                statusCell.Style.Font = new Font(dgvScholars.Font, FontStyle.Bold);
                            }
                            else if (status == "Terminated")
                            {
                                statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                                statusCell.Style.Font = new Font(dgvScholars.Font, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading scholars: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadScholarshipTypes()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, name FROM scholarship_types WHERE is_active = TRUE ORDER BY name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbScholarshipType.Items.Clear();

                        while (reader.Read())
                        {
                            cmbScholarshipType.Items.Add(new ComboBoxItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading scholarship types: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourses()
        {
            cmbCourse.Items.Clear();
            cmbCourse.Items.AddRange(new object[] {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS Business Administration",
                "BS Education",
                "BS Criminology",
                "BS Tourism Management",
                "BS Accountancy",
                "BS Civil Engineering",
                "BS Nursing",
                "BS Hospitality Management",
                "BS Psychology",
                "BS Agriculture",
                "BS Social Work",
                "BS Biology",
                "BS Medical Technology",
                "BS Physical Education",
                "BS Music Education",
                "BA Communication",
                "BA Broadcasting",
                "BS Entrepreneurship",
                "BS Environmental Science"
            });
        }

        private void LoadScholarDetails(int scholarId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT s.*, st.id as scholarship_type_id, st.name as scholarship_name
                                    FROM scholars s
                                    LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                                    WHERE s.id = @scholarId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", scholarId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _currentScholarId = scholarId;

                            txtScholarNumber.Text = reader["scholar_number"]?.ToString() ?? "";
                            txtFirstName.Text = reader["first_name"]?.ToString() ?? "";
                            txtMiddleName.Text = reader["middle_name"]?.ToString() ?? "";
                            txtLastName.Text = reader["last_name"]?.ToString() ?? "";
                            txtEmail.Text = reader["email"]?.ToString() ?? "";
                            txtContactNumber.Text = reader["contact_number"]?.ToString() ?? "";

                            string course = reader["course"]?.ToString() ?? "";
                            if (cmbCourse.Items.Contains(course))
                                cmbCourse.SelectedItem = course;

                            string yearLevel = reader["year_level"]?.ToString() ?? "";
                            if (cmbYearLevel.Items.Contains(yearLevel))
                                cmbYearLevel.SelectedItem = yearLevel;

                            int scholarshipTypeId = reader["scholarship_type_id"] != DBNull.Value ?
                                Convert.ToInt32(reader["scholarship_type_id"]) : 0;

                            for (int i = 0; i < cmbScholarshipType.Items.Count; i++)
                            {
                                ComboBoxItem item = cmbScholarshipType.Items[i] as ComboBoxItem;
                                if (item != null && item.Id == scholarshipTypeId)
                                {
                                    cmbScholarshipType.SelectedIndex = i;
                                    break;
                                }
                            }

                            if (reader["enrollment_date"] != DBNull.Value)
                                dtpEnrollmentDate.Value = Convert.ToDateTime(reader["enrollment_date"]);

                            if (reader["expected_graduation"] != DBNull.Value)
                                dtpExpectedGraduation.Value = Convert.ToDateTime(reader["expected_graduation"]);

                            string status = reader["status"]?.ToString() ?? "Active";
                            if (cmbStatus.Items.Contains(status))
                                cmbStatus.SelectedItem = status;

                            // Update deactivate button text based on status
                            UpdateDeactivateButton(status);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading scholar details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDeactivateButton(string status)
        {
            if (btnDeactivate != null)
            {
                if (status == "Active")
                {
                    btnDeactivate.ButtonText = "Deactivate";
                    btnDeactivate.NormalBackground = Color.FromArgb(255, 170, 0);
                    btnDeactivate.HoverBackground = Color.FromArgb(230, 150, 0);
                }
                else if (status == "Inactive")
                {
                    btnDeactivate.ButtonText = "Activate";
                    btnDeactivate.NormalBackground = Color.FromArgb(40, 167, 69);
                    btnDeactivate.HoverBackground = Color.FromArgb(30, 140, 55);
                }
                else
                {
                    btnDeactivate.ButtonText = "Deactivate";
                    btnDeactivate.NormalBackground = Color.FromArgb(180, 180, 180);
                    btnDeactivate.Enabled = false;
                }
            }
        }

        #endregion

        #region CRUD Operations

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string scholarNumber = GenerateScholarNumber(conn, transaction);

                            int scholarshipTypeId = 0;
                            ComboBoxItem selected = cmbScholarshipType.SelectedItem as ComboBoxItem;
                            if (selected != null)
                                scholarshipTypeId = selected.Id;

                            string query = @"INSERT INTO scholars 
                                (scholar_number, first_name, middle_name, last_name, email, 
                                 contact_number, course, year_level, scholarship_type_id,
                                 enrollment_date, expected_graduation, status, hei, degree_program, program,
                                 student_id) 
                                VALUES 
                                (@scholarNumber, @firstName, @middleName, @lastName, @email,
                                 @contactNumber, @course, @yearLevel, @scholarshipTypeId,
                                 @enrollmentDate, @expectedGraduation, @status, 
                                 'Legacy College of Compostela', @course, 'Undergraduate',
                                 @studentId)";

                            // Generate student ID from scholar number
                            string studentId = scholarNumber.Replace("SCH-", "2024-00");

                            MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
                            cmd.Parameters.AddWithValue("@scholarNumber", scholarNumber);
                            cmd.Parameters.AddWithValue("@studentId", studentId);
                            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                            cmd.Parameters.AddWithValue("@middleName", txtMiddleName.Text.Trim());
                            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactNumber", txtContactNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@course", cmbCourse.SelectedItem?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@yearLevel", cmbYearLevel.SelectedItem?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@scholarshipTypeId", scholarshipTypeId);
                            cmd.Parameters.AddWithValue("@enrollmentDate", dtpEnrollmentDate.Value);
                            cmd.Parameters.AddWithValue("@expectedGraduation", dtpExpectedGraduation.Value);
                            cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem?.ToString() ?? "Active");

                            cmd.ExecuteNonQuery();
                            transaction.Commit();

                            ActivityLogger.LogCreate("scholars", 0, $"Created new scholar: {txtFirstName.Text} {txtLastName.Text}");

                            MessageBox.Show("Scholar added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadScholarsGrid();
                            ClearForm();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving scholar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentScholarId == 0)
            {
                MessageBox.Show("Please select a scholar to update.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    int scholarshipTypeId = 0;
                    ComboBoxItem selected = cmbScholarshipType.SelectedItem as ComboBoxItem;
                    if (selected != null)
                        scholarshipTypeId = selected.Id;

                    string query = @"UPDATE scholars SET 
                                    first_name = @firstName, middle_name = @middleName, last_name = @lastName,
                                    email = @email, contact_number = @contactNumber, course = @course,
                                    year_level = @yearLevel, scholarship_type_id = @scholarshipTypeId,
                                    enrollment_date = @enrollmentDate, expected_graduation = @expectedGraduation,
                                    status = @status, degree_program = @course
                                    WHERE id = @scholarId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@middleName", txtMiddleName.Text.Trim());
                    cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@contactNumber", txtContactNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@course", cmbCourse.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@yearLevel", cmbYearLevel.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@scholarshipTypeId", scholarshipTypeId);
                    cmd.Parameters.AddWithValue("@enrollmentDate", dtpEnrollmentDate.Value);
                    cmd.Parameters.AddWithValue("@expectedGraduation", dtpExpectedGraduation.Value);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem?.ToString() ?? "Active");
                    cmd.Parameters.AddWithValue("@scholarId", _currentScholarId);

                    cmd.ExecuteNonQuery();

                    ActivityLogger.LogUpdate("scholars", _currentScholarId, $"Updated scholar: {txtFirstName.Text} {txtLastName.Text}");

                    MessageBox.Show("Scholar updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadScholarsGrid();

                    // Reload the current scholar details
                    LoadScholarDetails(_currentScholarId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating scholar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (_currentScholarId == 0)
            {
                MessageBox.Show("Please select a scholar first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus = cmbStatus.SelectedItem?.ToString() ?? "";
            string newStatus = currentStatus == "Active" ? "Inactive" : "Active";
            string action = currentStatus == "Active" ? "deactivate" : "reactivate";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to {action} this scholar?\n\n" +
                $"Scholar: {txtFirstName.Text} {txtLastName.Text}\n" +
                $"Current Status: {currentStatus}\n" +
                $"New Status: {newStatus}",
                $"Confirm {action}",
                MessageBoxButtons.YesNo,
                currentStatus == "Active" ? MessageBoxIcon.Warning : MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();

                        string query = "UPDATE scholars SET status = @status WHERE id = @scholarId";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@scholarId", _currentScholarId);
                        cmd.ExecuteNonQuery();

                        string logAction = currentStatus == "Active" ? "Deactivated" : "Reactivated";
                        ActivityLogger.LogUpdate("scholars", _currentScholarId, $"{logAction} scholar: {txtFirstName.Text} {txtLastName.Text}");

                        MessageBox.Show($"Scholar {action}d successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadScholarsGrid();
                        LoadScholarDetails(_currentScholarId);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error {action}ing scholar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (_currentScholarId == 0)
            {
                MessageBox.Show("Please select a scholar to view details.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create and show the scholar details view form
            FrmScholarDetailsView detailsView = new FrmScholarDetailsView(_currentScholarId);
            detailsView.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddScholar_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtFirstName.Focus();
        }

        #endregion

        #region Helper Methods

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (cmbCourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a course.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCourse.Focus();
                return false;
            }

            if (cmbYearLevel.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a year level.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbYearLevel.Focus();
                return false;
            }

            if (cmbScholarshipType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a scholarship type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbScholarshipType.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            _currentScholarId = 0;
            txtScholarNumber.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtContactNumber.Text = "";
            cmbCourse.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;
            cmbScholarshipType.SelectedIndex = -1;
            dtpEnrollmentDate.Value = DateTime.Now;
            dtpExpectedGraduation.Value = DateTime.Now.AddYears(4);
            cmbStatus.SelectedIndex = 0;

            if (btnDeactivate != null)
            {
                btnDeactivate.ButtonText = "Deactivate";
                btnDeactivate.NormalBackground = Color.FromArgb(255, 170, 0);
                btnDeactivate.Enabled = true;
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

        #endregion

        #region Event Handlers

        private void dgvScholars_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvScholars.SelectedRows.Count > 0)
            {
                int scholarId = Convert.ToInt32(dgvScholars.SelectedRows[0].Cells["colScholarID"].Value);
                LoadScholarDetails(scholarId);
            }
        }

        private void dgvScholars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int scholarId = Convert.ToInt32(dgvScholars.Rows[e.RowIndex].Cells["colScholarID"].Value);
                FrmScholarDetailsView detailsView = new FrmScholarDetailsView(scholarId);
                detailsView.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadScholarsGrid();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search scholar...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search scholar...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadScholarsGrid();
        }

        private void cmbFilterScholarship_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadScholarsGrid();
        }

        #endregion

        #region Navigation

        private void btnDashboard1_Click(object sender, EventArgs e)
        {
            FrmAdminDashboard dashboard = new FrmAdminDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnPayroll1_Click(object sender, EventArgs e)
        {
            FrmPayrollProcessing payroll = new FrmPayrollProcessing();
            payroll.Show();
            this.Hide();
        }

        private void btnReports1_Click(object sender, EventArgs e)
        {
            FrmReportsAnalytics reports = new FrmReportsAnalytics();
            reports.Show();
            this.Hide();
        }

        private void btnActivityLog1_Click(object sender, EventArgs e)
        {
            FrmActivityLogs activityLogs = new FrmActivityLogs();
            activityLogs.Show();
            this.Hide();
        }

        private void btnReminder1_Click(object sender, EventArgs e)
        {
            FrmNotifications notifications = new FrmNotifications();
            notifications.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ActivityLogger.LogLogout(SessionManager.CurrentUser?.Id ?? 0, SessionManager.CurrentUser?.Name ?? "");
            SessionManager.ClearSession();

            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        #endregion

        #region Empty Event Handlers
        private void panelContent_Paint(object sender, PaintEventArgs e) { }
        private void panelContent_Paint_1(object sender, PaintEventArgs e) { }
        private void panelContent_Paint_2(object sender, PaintEventArgs e) { }
        private void panelContent_Paint_3(object sender, PaintEventArgs e) { }
        private void dgvScholars_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion
    }

    // Helper class for ComboBox items
    public class ComboBoxItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    // Helper class for storing scholar detail data in grid rows
    public class ScholarDetailData
    {
        public int ScholarId { get; set; }
        public string ScholarNumber { get; set; }
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string ScholarshipName { get; set; }
        public string Status { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime? ExpectedGraduation { get; set; }
        public string HEI { get; set; }
        public string DegreeProgram { get; set; }
    }
}