using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form;
using SkolarAid.form.Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class FrmPayrollProcessing : Form
    {
        private List<ScholarPayroll> _scholars = new List<ScholarPayroll>();
        private decimal _totalAmount = 0;
        private int _selectedCount = 0;

        public FrmPayrollProcessing()
        {
            InitializeComponent();
            this.Load += FrmPayrollProcessing_Load_1;
        }

        private void FrmPayrollProcessing_Load_1(object sender, EventArgs e)
        {
            // Set default values
            dtpPaymentPeriod.Value = DateTime.Now;
            cmbPaymentMethod.SelectedIndex = 0;

            // Load filter options
            LoadFilterOptions();

            // Load scholars grid
            LoadScholarsGrid();

            // Load statistics
            LoadStatistics();

            // Wire up events
            dgvScholars.CellValueChanged += DgvScholars_CellValueChanged;
            dgvScholars.CurrentCellDirtyStateChanged += DgvScholars_CurrentCellDirtyStateChanged;
            btnSelectAll.Click += BtnSelectAll_Click;
            btnClearSelection.Click += BtnClearSelection_Click;
            btnProcessPayroll.Click += BtnProcessPayroll_Click;
            btnPreviewPayroll.Click += BtnPreviewPayroll_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cmbScholarshipType.SelectedIndexChanged += Filter_Changed;
            cmbYearLevel.SelectedIndexChanged += Filter_Changed;
        }

        #region Database Loading Methods

        private void LoadFilterOptions()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Load scholarship types for filter
                    string query = "SELECT name FROM scholarship_types WHERE is_active = TRUE ORDER BY name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbScholarshipType.Items.Clear();
                        cmbScholarshipType.Items.Add("All Scholarship Types");

                        while (reader.Read())
                        {
                            cmbScholarshipType.Items.Add(reader["name"].ToString());
                        }
                    }
                }

                if (cmbScholarshipType.Items.Count > 0)
                    cmbScholarshipType.SelectedIndex = 0;

                if (cmbYearLevel.Items.Count > 0)
                    cmbYearLevel.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading filter options: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadScholarsGrid()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT 
                                    s.id,
                                    s.scholar_number,
                                    CONCAT(s.first_name, ' ', s.last_name) AS full_name,
                                    s.course,
                                    s.year_level,
                                    st.name AS scholarship_name,
                                    st.stipend_amount,
                                    CASE 
                                        WHEN EXISTS (SELECT 1 FROM compliance_records cr 
                                                     WHERE cr.scholar_id = s.id 
                                                     AND cr.status IN ('Pending', 'Overdue')) 
                                        THEN 'Incomplete'
                                        ELSE 'Complete'
                                    END AS compliance_status,
                                    s.status
                                    FROM scholars s
                                    LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                                    WHERE s.status = 'Active'";

                    // Apply filters
                    if (cmbScholarshipType.SelectedIndex > 0 && cmbScholarshipType.SelectedItem != null)
                        query += " AND st.name = @scholarship";

                    if (cmbYearLevel.SelectedIndex > 0 && cmbYearLevel.SelectedItem != null)
                        query += " AND s.year_level = @yearLevel";

                    if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "Search scholar...")
                        query += " AND (s.scholar_number LIKE @search OR s.first_name LIKE @search OR s.last_name LIKE @search)";

                    query += " ORDER BY s.id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (cmbScholarshipType.SelectedIndex > 0 && cmbScholarshipType.SelectedItem != null)
                        cmd.Parameters.AddWithValue("@scholarship", cmbScholarshipType.SelectedItem.ToString());

                    if (cmbYearLevel.SelectedIndex > 0 && cmbYearLevel.SelectedItem != null)
                        cmd.Parameters.AddWithValue("@yearLevel", cmbYearLevel.SelectedItem.ToString());

                    if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "Search scholar...")
                        cmd.Parameters.AddWithValue("@search", $"%{txtSearch.Text}%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        _scholars.Clear();
                        dgvScholars.Rows.Clear();

                        while (reader.Read())
                        {
                            var scholar = new ScholarPayroll
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                ScholarNumber = reader["scholar_number"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Course = reader["course"].ToString(),
                                YearLevel = reader["year_level"].ToString(),
                                ScholarshipType = reader["scholarship_name"]?.ToString() ?? "N/A",
                                StipendAmount = reader["stipend_amount"] != DBNull.Value ? Convert.ToDecimal(reader["stipend_amount"]) : 0,
                                ComplianceStatus = reader["compliance_status"].ToString()
                            };

                            // Determine eligibility
                            scholar.IsEligible = scholar.ComplianceStatus == "Complete" && scholar.StipendAmount > 0;

                            _scholars.Add(scholar);

                            int rowIndex = dgvScholars.Rows.Add();
                            dgvScholars.Rows[rowIndex].Cells["colSelect"].Value = false;
                            dgvScholars.Rows[rowIndex].Cells["colScholarNumber"].Value = scholar.ScholarNumber;
                            dgvScholars.Rows[rowIndex].Cells["colName"].Value = scholar.FullName;
                            dgvScholars.Rows[rowIndex].Cells["colCourse"].Value = scholar.Course;
                            dgvScholars.Rows[rowIndex].Cells["colYearLevel"].Value = scholar.YearLevel;
                            dgvScholars.Rows[rowIndex].Cells["colScholarshipType"].Value = scholar.ScholarshipType;
                            dgvScholars.Rows[rowIndex].Cells["colStipendAmount"].Value = $"₱{scholar.StipendAmount:N2}";
                            dgvScholars.Rows[rowIndex].Cells["colComplianceStatus"].Value = scholar.ComplianceStatus;
                            dgvScholars.Rows[rowIndex].Cells["colEligible"].Value = scholar.IsEligible;

                            // Style compliance status cell
                            var statusCell = dgvScholars.Rows[rowIndex].Cells["colComplianceStatus"];
                            if (scholar.ComplianceStatus == "Complete")
                            {
                                statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                                statusCell.Style.Font = new Font(dgvScholars.Font, FontStyle.Bold);
                            }
                            else
                            {
                                statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                                statusCell.Style.Font = new Font(dgvScholars.Font, FontStyle.Bold);
                            }

                            // Disable selection for ineligible scholars
                            if (!scholar.IsEligible)
                            {
                                dgvScholars.Rows[rowIndex].Cells["colSelect"].ReadOnly = true;
                                dgvScholars.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                            }
                        }
                    }
                }

                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading scholars: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Get processed today count
                    string processedQuery = @"SELECT COUNT(*) FROM payments 
                                             WHERE DATE(created_at) = CURDATE() 
                                             AND status IN ('Processed', 'Released')";
                    MySqlCommand cmdProcessed = new MySqlCommand(processedQuery, conn);
                    lblProcessedToday.Text = Convert.ToInt32(cmdProcessed.ExecuteScalar()).ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading statistics: {ex.Message}");
            }
        }

        #endregion

        #region Event Handlers

        private void DgvScholars_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvScholars.IsCurrentCellDirty)
            {
                dgvScholars.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvScholars_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvScholars.Columns["colSelect"].Index)
            {
                UpdateStatistics();
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvScholars.Rows.Count; i++)
            {
                if (_scholars[i].IsEligible)
                {
                    dgvScholars.Rows[i].Cells["colSelect"].Value = true;
                }
            }
            UpdateStatistics();
        }

        private void BtnClearSelection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvScholars.Rows.Count; i++)
            {
                dgvScholars.Rows[i].Cells["colSelect"].Value = false;
            }
            UpdateStatistics();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadScholarsGrid();
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            LoadScholarsGrid();
        }

        private void BtnPreviewPayroll_Click(object sender, EventArgs e)
        {
            var selectedScholars = GetSelectedScholars();

            if (selectedScholars.Count == 0)
            {
                MessageBox.Show("Please select at least one eligible scholar.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string period = dtpPaymentPeriod.Value.ToString("MMMM yyyy");
            string method = cmbPaymentMethod.SelectedItem?.ToString() ?? "Bank Transfer";

            string message = $"PAYROLL PREVIEW\n\n" +
                            $"Period: {period}\n" +
                            $"Payment Method: {method}\n" +
                            $"Selected Scholars: {selectedScholars.Count}\n" +
                            $"Total Amount: ₱{_totalAmount:N2}\n\n" +
                            $"Scholars to be processed:\n" +
                            $"{string.Join("\n", selectedScholars.Select(s => $"• {s.FullName} - ₱{s.StipendAmount:N2}"))}";

            MessageBox.Show(message, "Payroll Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnProcessPayroll_Click(object sender, EventArgs e)
        {
            var selectedScholars = GetSelectedScholars();

            if (selectedScholars.Count == 0)
            {
                MessageBox.Show("Please select at least one eligible scholar.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string period = dtpPaymentPeriod.Value.ToString("MMMM yyyy");
            string method = cmbPaymentMethod.SelectedItem?.ToString() ?? "Bank Transfer";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to process payroll for {selectedScholars.Count} scholars?\n\n" +
                $"Period: {period}\n" +
                $"Total Amount: ₱{_totalAmount:N2}",
                "Confirm Payroll Processing",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ProcessPayroll(selectedScholars, period, method);
            }
        }

        #endregion

        #region Helper Methods

        private void UpdateStatistics()
        {
            int eligibleCount = _scholars.Count(s => s.IsEligible);
            _selectedCount = 0;
            _totalAmount = 0;

            for (int i = 0; i < dgvScholars.Rows.Count; i++)
            {
                var cellValue = dgvScholars.Rows[i].Cells["colSelect"].Value;
                if (cellValue != null && Convert.ToBoolean(cellValue) && _scholars[i].IsEligible)
                {
                    _selectedCount++;
                    _totalAmount += _scholars[i].StipendAmount;
                }
            }

            lblEligibleCount.Text = eligibleCount.ToString();
            lblSelectedCount.Text = _selectedCount.ToString();
            lblSelectedLabel.Text = $"Selected ({_selectedCount})";
            lblTotalAmount.Text = $"₱{_totalAmount:N2}";

            lblSummaryScholars.Text = $"Selected Scholars: {_selectedCount}";
            lblSummaryAmount.Text = $"Total: ₱{_totalAmount:N2}";
            lblSummaryMethod.Text = $"Method: {cmbPaymentMethod.SelectedItem ?? "Bank Transfer"}";
        }

        private List<ScholarPayroll> GetSelectedScholars()
        {
            var selected = new List<ScholarPayroll>();

            for (int i = 0; i < dgvScholars.Rows.Count; i++)
            {
                var cellValue = dgvScholars.Rows[i].Cells["colSelect"].Value;
                if (cellValue != null && Convert.ToBoolean(cellValue) && _scholars[i].IsEligible)
                {
                    selected.Add(_scholars[i]);
                }
            }

            return selected;
        }

        private void ProcessPayroll(List<ScholarPayroll> scholars, string period, string method)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            int processedBy = SessionManager.CurrentUser?.Id ?? 1;
                            int successCount = 0;

                            foreach (var scholar in scholars)
                            {
                                // Check if already processed for this period
                                string checkQuery = @"SELECT COUNT(*) FROM payments 
                                                     WHERE scholar_id = @scholarId 
                                                     AND payment_period = @period";
                                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, transaction);
                                checkCmd.Parameters.AddWithValue("@scholarId", scholar.Id);
                                checkCmd.Parameters.AddWithValue("@period", period);

                                int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (existingCount > 0)
                                {
                                    continue; // Skip if already processed
                                }

                                // Insert payment record
                                string insertQuery = @"INSERT INTO payments 
                                    (scholar_id, payment_period, amount, computation_date, status, 
                                     payment_method, processed_by, remarks) 
                                    VALUES 
                                    (@scholarId, @period, @amount, CURDATE(), 'Processed', 
                                     @method, @processedBy, @remarks)";

                                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn, transaction);
                                insertCmd.Parameters.AddWithValue("@scholarId", scholar.Id);
                                insertCmd.Parameters.AddWithValue("@period", period);
                                insertCmd.Parameters.AddWithValue("@amount", scholar.StipendAmount);
                                insertCmd.Parameters.AddWithValue("@method", method);
                                insertCmd.Parameters.AddWithValue("@processedBy", processedBy);
                                insertCmd.Parameters.AddWithValue("@remarks", $"Batch payroll for {period}");

                                insertCmd.ExecuteNonQuery();
                                successCount++;

                                // Create notification for scholar
                                string notifQuery = @"INSERT INTO notifications 
                                    (sender_id, recipient_id, title, message, notification_type, is_read) 
                                    VALUES 
                                    (@senderId, @recipientId, @title, @message, 'Update', FALSE)";

                                MySqlCommand notifCmd = new MySqlCommand(notifQuery, conn, transaction);
                                notifCmd.Parameters.AddWithValue("@senderId", processedBy);
                                notifCmd.Parameters.AddWithValue("@recipientId", scholar.Id);
                                notifCmd.Parameters.AddWithValue("@title", "Payment Processed");
                                notifCmd.Parameters.AddWithValue("@message", $"Your stipend for {period} has been processed. Amount: ₱{scholar.StipendAmount:N2}. Expected release: within 3-5 business days.");

                                notifCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            // Log activity
                            ActivityLogger.LogCreate("payments", 0, $"Processed payroll for {successCount} scholars. Period: {period}, Total: ₱{_totalAmount:N2}");

                            MessageBox.Show($"Payroll processed successfully!\n\n" +
                                           $"Processed: {successCount} scholars\n" +
                                           $"Total Amount: ₱{_totalAmount:N2}",
                                           "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload grid and clear selections
                            LoadScholarsGrid();
                            LoadStatistics();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payroll: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Navigation

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmAdminDashboard dashboard = new FrmAdminDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnScholarMgmt_Click(object sender, EventArgs e)
        {
            FrmScholarManagement scholarMgmt = new FrmScholarManagement();
            scholarMgmt.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FrmReportsAnalytics reports = new FrmReportsAnalytics();
            reports.Show();
            this.Hide();
        }

        private void btnActivityLog_Click(object sender, EventArgs e)
        {
            FrmActivityLogs activityLogs = new FrmActivityLogs();
            activityLogs.Show();
            this.Hide();
        }

        private void btnReminder_Click(object sender, EventArgs e)
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

        #region Designer Event Handlers (Keep for compatibility)
        private void sataButton1_Click(object sender, EventArgs e) => btnDashboard_Click(sender, e);
        private void sataButton2_Click(object sender, EventArgs e) => btnScholarMgmt_Click(sender, e);
        private void sataButton3_Click(object sender, EventArgs e) { }
        private void sataButton4_Click(object sender, EventArgs e) => btnReports_Click(sender, e);
        private void sataButton5_Click(object sender, EventArgs e) => btnActivityLog_Click(sender, e);
        private void sataButton6_Click(object sender, EventArgs e) => btnReminder_Click(sender, e);
        #endregion

        private void FrmPayrollProcessing_Load(object sender, EventArgs e) { }

       
    }

    // Helper class for scholar payroll data
    public class ScholarPayroll
    {
        public int Id { get; set; }
        public string ScholarNumber { get; set; }
        public string FullName { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string ScholarshipType { get; set; }
        public decimal StipendAmount { get; set; }
        public string ComplianceStatus { get; set; }
        public bool IsEligible { get; set; }
    }
}