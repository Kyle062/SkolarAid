using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form;
using SkolarAid.form.Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class FrmPayrollProcessing : Form
    {
        private List<ScholarPayroll> _scholars = new List<ScholarPayroll>();
        private decimal _totalAmount = 0;
        private int _selectedCount = 0;
        private bool _isLoading = false;

        // ============================================
        // EMAIL NOTIFICATION CONFIGURATION
        // ============================================
        private const string SMTP_HOST = "smtp.gmail.com";
        private const int SMTP_PORT = 587;
        private const string SENDER_EMAIL = "kylealba0624@gmail.com";
        private const string SENDER_PASSWORD = "yygwothvzhrwvajv";
        private const string SENDER_NAME = "Legacy College of Compostela - ScholarAid";
        private const bool ENABLE_EMAIL_NOTIFICATIONS = true;
        private const bool ENABLE_SMS_NOTIFICATIONS = true;

        // SMS Gateway Configuration (using a free SMS API - for testing only)
        // In production, replace with a real SMS gateway like Twilio, Semaphore, etc.
        private const string SMS_GATEWAY_URL = "https://api.semaphore.co/api/v4/messages";
        private const string SMS_API_KEY = "09cabeb4384cf62307f39fd0f6a7efe5"; // Get from https://semaphore.co

        public FrmPayrollProcessing()
        {
            InitializeComponent();
            this.Load += FrmPayrollProcessing_Load_1;
            this.Resize += FrmPayrollProcessing_Resize;
        }

        private void FrmPayrollProcessing_Resize(object sender, EventArgs e)
        {
            try { AdjustLayoutForFullscreen(); }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"Resize error: {ex.Message}"); }
        }

        private void AdjustLayoutForFullscreen()
        {
            int screenWidth = this.ClientSize.Width;
            int screenHeight = this.ClientSize.Height;

            int statsCardWidth = (screenWidth - 320 - 60) / 4;

            if (panelStats1 != null)
            {
                panelStats1.Location = new Point(321, 100);
                panelStats1.Size = new Size(statsCardWidth, 110);
            }
            if (panelStats2 != null)
            {
                panelStats2.Location = new Point(321 + statsCardWidth + 15, 100);
                panelStats2.Size = new Size(statsCardWidth, 110);
            }
            if (panelStats3 != null)
            {
                panelStats3.Location = new Point(321 + (statsCardWidth + 15) * 2, 100);
                panelStats3.Size = new Size(statsCardWidth, 110);
            }
            if (panelStats4 != null)
            {
                panelStats4.Location = new Point(321 + (statsCardWidth + 15) * 3, 100);
                panelStats4.Size = new Size(statsCardWidth, 110);
            }

            if (panelFilters != null)
            {
                panelFilters.Location = new Point(301, 225);
                panelFilters.Size = new Size(screenWidth - 321, 70);
            }

            if (panelBatchControls != null)
            {
                panelBatchControls.Location = new Point(301, 310);
                panelBatchControls.Size = new Size(screenWidth - 321, 65);
            }

            int gridWidth = (int)((screenWidth - 321) * 0.78);
            int summaryWidth = screenWidth - 321 - gridWidth - 15;

            if (panelDataGrid != null)
            {
                panelDataGrid.Location = new Point(301, 390);
                panelDataGrid.Size = new Size(gridWidth, screenHeight - 420);
            }

            if (panelSummary != null)
            {
                panelSummary.Location = new Point(301 + gridWidth + 15, 390);
                panelSummary.Size = new Size(summaryWidth, screenHeight - 420);
            }
        }

        private void FrmPayrollProcessing_Load_1(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;

                dtpPaymentPeriod.Value = DateTime.Now;
                if (cmbPaymentMethod.Items.Count > 0)
                    cmbPaymentMethod.SelectedIndex = 0;

                WireUpEvents();
                LoadFilterOptions();
                LoadScholarsGrid();
                LoadStatistics();
                AdjustLayoutForFullscreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Payroll Processing form: {ex.Message}",
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WireUpEvents()
        {
            try
            {
                dgvScholars.CellValueChanged -= DgvScholars_CellValueChanged;
                dgvScholars.CurrentCellDirtyStateChanged -= DgvScholars_CurrentCellDirtyStateChanged;
                dgvScholars.CellDoubleClick -= dgvScholars_CellDoubleClick;
                btnSelectAll.Click -= BtnSelectAll_Click;
                btnClearSelection.Click -= BtnClearSelection_Click;
                btnProcessPayroll.Click -= BtnProcessPayroll_Click;
                btnPreviewPayroll.Click -= BtnPreviewPayroll_Click;
                txtSearch.TextChanged -= TxtSearch_TextChanged;
                cmbScholarshipType.SelectedIndexChanged -= Filter_Changed;
                cmbYearLevel.SelectedIndexChanged -= Filter_Changed;

                dgvScholars.CellValueChanged += DgvScholars_CellValueChanged;
                dgvScholars.CurrentCellDirtyStateChanged += DgvScholars_CurrentCellDirtyStateChanged;
                dgvScholars.CellDoubleClick += dgvScholars_CellDoubleClick;
                btnSelectAll.Click += BtnSelectAll_Click;
                btnClearSelection.Click += BtnClearSelection_Click;
                btnProcessPayroll.Click += BtnProcessPayroll_Click;
                btnPreviewPayroll.Click += BtnPreviewPayroll_Click;
                txtSearch.TextChanged += TxtSearch_TextChanged;
                cmbScholarshipType.SelectedIndexChanged += Filter_Changed;
                cmbYearLevel.SelectedIndexChanged += Filter_Changed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error wiring events: {ex.Message}", "Event Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Database Loading Methods

        private void LoadFilterOptions()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT name FROM scholarship_types WHERE is_active = TRUE ORDER BY name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbScholarshipType.Items.Clear();
                        cmbScholarshipType.Items.Add("All Scholarship Types");
                        while (reader.Read())
                            cmbScholarshipType.Items.Add(reader["name"].ToString());
                    }
                }
                if (cmbScholarshipType.Items.Count > 0) cmbScholarshipType.SelectedIndex = 0;
                if (cmbYearLevel.Items.Count > 0) cmbYearLevel.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading filter options: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadScholarsGrid()
        {
            _isLoading = true;
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                    s.id, s.scholar_number,
                                    s.email, s.contact_number,
                                    CONCAT(s.first_name, ' ', s.last_name) AS full_name,
                                    s.course, s.year_level,
                                    st.name AS scholarship_name, st.stipend_amount,
                                    CASE 
                                        WHEN NOT EXISTS (SELECT 1 FROM compliance_records cr WHERE cr.scholar_id = s.id)
                                        THEN 'No Records'
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

                    if (cmbScholarshipType.SelectedIndex > 0 && cmbScholarshipType.SelectedItem != null)
                        query += " AND st.name = @scholarship";
                    if (cmbYearLevel.SelectedIndex > 0 && cmbYearLevel.SelectedItem != null)
                        query += " AND s.year_level = @yearLevel";
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                        query += " AND (s.scholar_number LIKE @search OR s.first_name LIKE @search OR s.last_name LIKE @search)";
                    query += " ORDER BY s.id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (cmbScholarshipType.SelectedIndex > 0 && cmbScholarshipType.SelectedItem != null)
                        cmd.Parameters.AddWithValue("@scholarship", cmbScholarshipType.SelectedItem.ToString());
                    if (cmbYearLevel.SelectedIndex > 0 && cmbYearLevel.SelectedItem != null)
                        cmd.Parameters.AddWithValue("@yearLevel", cmbYearLevel.SelectedItem.ToString());
                    if (!string.IsNullOrEmpty(txtSearch.Text))
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
                                Email = reader["email"]?.ToString() ?? "",
                                ContactNumber = reader["contact_number"]?.ToString() ?? "",
                                Course = reader["course"].ToString(),
                                YearLevel = reader["year_level"].ToString(),
                                ScholarshipType = reader["scholarship_name"]?.ToString() ?? "N/A",
                                StipendAmount = reader["stipend_amount"] != DBNull.Value ? Convert.ToDecimal(reader["stipend_amount"]) : 0,
                                ComplianceStatus = reader["compliance_status"].ToString()
                            };

                            scholar.IsEligible = (scholar.ComplianceStatus == "Complete") && scholar.StipendAmount > 0;
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
                            dgvScholars.Rows[rowIndex].Cells["colEligible"].Value = scholar.IsEligible ? "✓ Eligible" : "✗ Not Eligible";

                            var complianceCell = dgvScholars.Rows[rowIndex].Cells["colComplianceStatus"];
                            var eligibleCell = dgvScholars.Rows[rowIndex].Cells["colEligible"];

                            if (scholar.ComplianceStatus == "Complete")
                            {
                                complianceCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                                complianceCell.Style.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
                            }
                            else
                            {
                                complianceCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                                complianceCell.Style.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
                            }

                            if (scholar.IsEligible)
                            {
                                eligibleCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                                eligibleCell.Style.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
                            }
                            else
                            {
                                eligibleCell.Style.ForeColor = Color.FromArgb(180, 180, 180);
                                dgvScholars.Rows[rowIndex].Cells["colSelect"].ReadOnly = true;
                                dgvScholars.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
                            }
                        }
                    }
                }
                _isLoading = false;
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                _isLoading = false;
                MessageBox.Show($"Error loading scholars grid: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string processedQuery = @"SELECT COUNT(*) FROM payments 
                                             WHERE DATE(created_at) = CURDATE() 
                                             AND status IN ('Processed', 'Released')";
                    MySqlCommand cmdProcessed = new MySqlCommand(processedQuery, conn);
                    lblProcessedToday.Text = Convert.ToInt32(cmdProcessed.ExecuteScalar()).ToString();
                }
            }
            catch (Exception ex)
            {
                lblProcessedToday.Text = "Error";
                System.Diagnostics.Debug.WriteLine($"Error loading statistics: {ex.Message}");
            }
        }

        #endregion

        #region Compliance Management

        private void ManageCompliance(int scholarId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string scholarQuery = "SELECT CONCAT(first_name, ' ', last_name) as name FROM scholars WHERE id = @id";
                    MySqlCommand scholarCmd = new MySqlCommand(scholarQuery, conn);
                    scholarCmd.Parameters.AddWithValue("@id", scholarId);
                    string scholarName = scholarCmd.ExecuteScalar()?.ToString() ?? "Unknown";

                    string query = @"SELECT id, requirement_type, description, due_date, date_submitted, status, remarks 
                                    FROM compliance_records WHERE scholar_id = @scholarId ORDER BY due_date DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", scholarId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        var records = new List<ComplianceRecordItem>();
                        while (reader.Read())
                        {
                            records.Add(new ComplianceRecordItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                RequirementType = reader["requirement_type"]?.ToString(),
                                Description = reader["description"]?.ToString(),
                                DueDate = Convert.ToDateTime(reader["due_date"]),
                                DateSubmitted = reader["date_submitted"] != DBNull.Value ? Convert.ToDateTime(reader["date_submitted"]) : (DateTime?)null,
                                Status = reader["status"]?.ToString(),
                                Remarks = reader["remarks"]?.ToString()
                            });
                        }
                        reader.Close();

                        if (records.Count == 0)
                        {
                            MessageBox.Show($"No compliance records found for {scholarName}.\n\n" +
                                "Please add compliance requirements through Scholar Management first.",
                                "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        ShowComplianceDialog(scholarId, scholarName, records);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error managing compliance: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowComplianceDialog(int scholarId, string scholarName, List<ComplianceRecordItem> records)
        {
            try
            {
                Form complianceForm = new Form
                {
                    Text = $"Compliance - {scholarName}",
                    Size = new Size(800, 550),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    BackColor = Color.White
                };

                Label lblTitle = new Label
                {
                    Text = $"📋 Compliance Records for {scholarName}",
                    Font = new Font("Century Gothic", 14F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 68, 79),
                    Location = new Point(20, 15),
                    Size = new Size(750, 30)
                };
                complianceForm.Controls.Add(lblTitle);

                Label lblInstructions = new Label
                {
                    Text = "Select a record and click Toggle to change status (Pending ↔ Approved)",
                    Font = new Font("Century Gothic", 9F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(120, 120, 120),
                    Location = new Point(20, 45),
                    Size = new Size(750, 20)
                };
                complianceForm.Controls.Add(lblInstructions);

                DataGridView dgv = new DataGridView
                {
                    Location = new Point(20, 75),
                    Size = new Size(745, 360),
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    ReadOnly = true,
                    RowHeadersVisible = false,
                    BackgroundColor = Color.White,
                    BorderStyle = BorderStyle.None,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    RowTemplate = { Height = 35 }
                };

                dgv.Columns.Add("colID", "ID");
                dgv.Columns.Add("colType", "Requirement");
                dgv.Columns.Add("colDueDate", "Due Date");
                dgv.Columns.Add("colSubmitted", "Submitted");
                dgv.Columns.Add("colStatus", "Status");
                dgv.Columns["colID"].Visible = false;

                dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 68, 79),
                    ForeColor = Color.White,
                    Font = new Font("Century Gothic", 11F, FontStyle.Bold)
                };
                dgv.DefaultCellStyle = new DataGridViewCellStyle { Font = new Font("Century Gothic", 11F) };

                foreach (var record in records)
                {
                    int rowIndex = dgv.Rows.Add(record.Id, record.RequirementType,
                        record.DueDate.ToString("MMM dd, yyyy"),
                        record.DateSubmitted?.ToString("MMM dd, yyyy") ?? "Not submitted",
                        record.Status);

                    var statusCell = dgv.Rows[rowIndex].Cells["colStatus"];
                    switch (record.Status)
                    {
                        case "Approved": statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69); dgv.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240); break;
                        case "Pending": statusCell.Style.ForeColor = Color.FromArgb(255, 170, 0); break;
                        case "Submitted": statusCell.Style.ForeColor = Color.FromArgb(0, 123, 255); break;
                        case "Overdue": statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68); dgv.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240); break;
                        case "Rejected": statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68); break;
                    }
                    statusCell.Style.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
                }
                complianceForm.Controls.Add(dgv);

                Button btnToggle = new Button
                {
                    Text = "Toggle Status (Complete/Pending)",
                    Font = new Font("Century Gothic", 11F, FontStyle.Bold),
                    BackColor = Color.FromArgb(0, 68, 79),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(20, 450),
                    Size = new Size(300, 45)
                };
                btnToggle.FlatAppearance.BorderSize = 0;
                btnToggle.Click += (s, ev) =>
                {
                    try
                    {
                        if (dgv.SelectedRows.Count > 0)
                        {
                            int complianceId = Convert.ToInt32(dgv.SelectedRows[0].Cells["colID"].Value);
                            string currentStatus = dgv.SelectedRows[0].Cells["colStatus"].Value.ToString();
                            string newStatus = (currentStatus == "Approved" || currentStatus == "Submitted") ? "Pending" : "Approved";
                            using (MySqlConnection updateConn = DatabaseHelper.GetConnection())
                            {
                                updateConn.Open();
                                MySqlCommand updateCmd = new MySqlCommand(@"UPDATE compliance_records SET status = @status, date_submitted = @dateSubmitted, remarks = @remarks WHERE id = @id", updateConn);
                                updateCmd.Parameters.AddWithValue("@status", newStatus);
                                updateCmd.Parameters.AddWithValue("@dateSubmitted", newStatus == "Approved" ? (object)DateTime.Now : DBNull.Value);
                                updateCmd.Parameters.AddWithValue("@remarks", newStatus == "Approved" ? "Marked as complete via Payroll" : "Marked as pending via Payroll");
                                updateCmd.Parameters.AddWithValue("@id", complianceId);
                                updateCmd.ExecuteNonQuery();
                                MessageBox.Show($"✅ Status updated to '{newStatus}'!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                complianceForm.Close();
                                LoadScholarsGrid();
                            }
                        }
                        else { MessageBox.Show("Please select a compliance record first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                };
                complianceForm.Controls.Add(btnToggle);

                Button btnMarkAll = new Button
                {
                    Text = "Mark All as Complete",
                    Font = new Font("Century Gothic", 11F),
                    BackColor = Color.FromArgb(40, 167, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(335, 450),
                    Size = new Size(210, 45)
                };
                btnMarkAll.FlatAppearance.BorderSize = 0;
                btnMarkAll.Click += (s, ev) =>
                {
                    try
                    {
                        if (MessageBox.Show("Mark ALL as Complete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            using (MySqlConnection updateConn = DatabaseHelper.GetConnection())
                            {
                                updateConn.Open();
                                MySqlCommand updateCmd = new MySqlCommand(@"UPDATE compliance_records SET status = 'Approved', date_submitted = NOW(), remarks = 'Bulk approved' WHERE scholar_id = @scholarId AND status IN ('Pending', 'Overdue', 'Submitted')", updateConn);
                                updateCmd.Parameters.AddWithValue("@scholarId", scholarId);
                                int affected = updateCmd.ExecuteNonQuery();
                                MessageBox.Show($"✅ {affected} records marked as Complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                complianceForm.Close();
                                LoadScholarsGrid();
                            }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                };
                complianceForm.Controls.Add(btnMarkAll);

                Button btnClose = new Button
                {
                    Text = "Close",
                    Font = new Font("Century Gothic", 11F),
                    BackColor = Color.FromArgb(180, 180, 180),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(660, 450),
                    Size = new Size(105, 45)
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, ev) => complianceForm.Close();
                complianceForm.Controls.Add(btnClose);

                complianceForm.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Event Handlers

        private void DgvScholars_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try { if (dgvScholars.IsCurrentCellDirty) dgvScholars.CommitEdit(DataGridViewDataErrorContexts.Commit); }
            catch { }
        }

        private void DgvScholars_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try { if (!_isLoading && e.RowIndex >= 0 && e.ColumnIndex == dgvScholars.Columns["colSelect"].Index) UpdateStatistics(); }
            catch { }
        }

        private void dgvScholars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int scholarId = _scholars[e.RowIndex].Id;
                    if (MessageBox.Show($"Scholar: {_scholars[e.RowIndex].FullName}\nCompliance: {_scholars[e.RowIndex].ComplianceStatus}\n\nOpen Compliance Manager?",
                        "Manage Compliance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        ManageCompliance(scholarId);
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            try { for (int i = 0; i < dgvScholars.Rows.Count; i++) { if (_scholars[i].IsEligible) dgvScholars.Rows[i].Cells["colSelect"].Value = true; } UpdateStatistics(); }
            catch { }
        }

        private void BtnClearSelection_Click(object sender, EventArgs e)
        {
            try { for (int i = 0; i < dgvScholars.Rows.Count; i++) dgvScholars.Rows[i].Cells["colSelect"].Value = false; UpdateStatistics(); }
            catch { }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) { try { LoadScholarsGrid(); } catch { } }
        private void Filter_Changed(object sender, EventArgs e) { try { LoadScholarsGrid(); } catch { } }

        private void BtnPreviewPayroll_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedScholars = GetSelectedScholars();
                if (selectedScholars.Count == 0)
                {
                    MessageBox.Show("⚠ Please select at least one eligible scholar.", "No Eligible Scholars", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string period = dtpPaymentPeriod.Value.ToString("MMMM yyyy");
                string method = cmbPaymentMethod.SelectedItem?.ToString() ?? "Bank Transfer";
                MessageBox.Show($"PAYROLL PREVIEW\n\n📅 Period: {period}\n💳 Method: {method}\n👥 Scholars: {selectedScholars.Count}\n💰 Total: ₱{_totalAmount:N2}\n\n" +
                    $"{string.Join("\n", selectedScholars.Select(s => $"• {s.FullName} - ₱{s.StipendAmount:N2}"))}",
                    "Payroll Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnProcessPayroll_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedScholars = GetSelectedScholars();
                if (selectedScholars.Count == 0)
                {
                    MessageBox.Show("⚠ Please select at least one eligible scholar.", "No Eligible Scholars", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string period = dtpPaymentPeriod.Value.ToString("MMMM yyyy");
                string method = cmbPaymentMethod.SelectedItem?.ToString() ?? "Bank Transfer";
                if (MessageBox.Show($"CONFIRM PAYROLL\n\n📅 Period: {period}\n💳 Method: {method}\n👥 Scholars: {selectedScholars.Count}\n💰 Total: ₱{_totalAmount:N2}\n\nProceed?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ProcessPayroll(selectedScholars, period, method);
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Helper Methods

        private void UpdateStatistics()
        {
            try
            {
                int eligibleCount = _scholars.Count(s => s.IsEligible);
                _selectedCount = 0; _totalAmount = 0;
                for (int i = 0; i < dgvScholars.Rows.Count; i++)
                {
                    var cellValue = dgvScholars.Rows[i].Cells["colSelect"].Value;
                    if (cellValue != null && Convert.ToBoolean(cellValue) && _scholars[i].IsEligible)
                    { _selectedCount++; _totalAmount += _scholars[i].StipendAmount; }
                }
                lblEligibleCount.Text = eligibleCount.ToString();
                lblSelectedCount.Text = _selectedCount.ToString();
                lblSelectedLabel.Text = $"Selected: {_selectedCount}";
                lblTotalAmount.Text = $"₱{_totalAmount:N2}";
                lblSummaryScholars.Text = $"👥 Selected: {_selectedCount}";
                lblSummaryAmount.Text = $"💰 Total: ₱{_totalAmount:N2}";
                lblSummaryMethod.Text = $"💳 {cmbPaymentMethod.SelectedItem ?? "Bank Transfer"}";
            }
            catch { }
        }

        private List<ScholarPayroll> GetSelectedScholars()
        {
            var selected = new List<ScholarPayroll>();
            try
            {
                for (int i = 0; i < dgvScholars.Rows.Count; i++)
                {
                    var cellValue = dgvScholars.Rows[i].Cells["colSelect"].Value;
                    if (cellValue != null && Convert.ToBoolean(cellValue) && _scholars[i].IsEligible)
                        selected.Add(_scholars[i]);
                }
            }
            catch { }
            return selected;
        }

        // ============================================
        // PROCESS PAYROLL WITH EMAIL + SMS NOTIFICATIONS
        // ============================================
        private void ProcessPayroll(List<ScholarPayroll> scholars, string period, string method)
        {
            this.Cursor = Cursors.WaitCursor;

            int emailSentCount = 0, emailFailedCount = 0;
            int smsSentCount = 0, smsFailedCount = 0;

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
                            int successCount = 0, skippedCount = 0;

                            foreach (var scholar in scholars)
                            {
                                string checkQuery = @"SELECT COUNT(*) FROM payments WHERE scholar_id = @scholarId AND payment_period = @period";
                                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, transaction);
                                checkCmd.Parameters.AddWithValue("@scholarId", scholar.Id);
                                checkCmd.Parameters.AddWithValue("@period", period);
                                if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0) { skippedCount++; continue; }

                                string insertQuery = @"INSERT INTO payments (scholar_id, payment_period, amount, computation_date, status, payment_method, processed_by, remarks) 
                            VALUES (@scholarId, @period, @amount, CURDATE(), 'Processed', @method, @processedBy, @remarks)";
                                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn, transaction);
                                insertCmd.Parameters.AddWithValue("@scholarId", scholar.Id);
                                insertCmd.Parameters.AddWithValue("@period", period);
                                insertCmd.Parameters.AddWithValue("@amount", scholar.StipendAmount);
                                insertCmd.Parameters.AddWithValue("@method", method);
                                insertCmd.Parameters.AddWithValue("@processedBy", processedBy);
                                insertCmd.Parameters.AddWithValue("@remarks", $"Batch payroll for {period}");
                                insertCmd.ExecuteNonQuery();
                                successCount++;

                                string notifQuery = @"INSERT INTO notifications (sender_id, recipient_id, title, message, notification_type, is_read) 
                            VALUES (@senderId, @recipientId, @title, @message, 'Update', FALSE)";
                                MySqlCommand notifCmd = new MySqlCommand(notifQuery, conn, transaction);
                                notifCmd.Parameters.AddWithValue("@senderId", processedBy);
                                notifCmd.Parameters.AddWithValue("@recipientId", scholar.Id);
                                notifCmd.Parameters.AddWithValue("@title", "Payment Processed");
                                notifCmd.Parameters.AddWithValue("@message", $"Your stipend for {period} has been processed. Amount: ₱{scholar.StipendAmount:N2}.");
                                notifCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            ActivityLogger.LogCreate("payments", 0, $"Processed payroll for {successCount} scholars. Period: {period}, Total: ₱{_totalAmount:N2}");

                            // ============================================
                            // SEND EMAIL + SMS TO EACH SCHOLAR
                            // ============================================
                            foreach (var scholar in scholars)
                            {
                                string scholarEmail = GetScholarEmailFromDB(scholar.Id);
                                string scholarPhone = GetScholarPhoneFromDB(scholar.Id);

                                // 1. SEND EMAIL
                                if (!string.IsNullOrEmpty(scholarEmail))
                                {
                                    bool emailResult = SendPaymentEmail(scholarEmail, scholar.FullName, period, scholar.StipendAmount, method, scholar.ScholarNumber);
                                    if (emailResult) emailSentCount++; else emailFailedCount++;
                                }

                                // 2. SEND SMS
                                if (!string.IsNullOrEmpty(scholarPhone))
                                {
                                    bool smsResult = SendPaymentSMS(scholarPhone, scholar.FullName, period, scholar.StipendAmount);
                                    if (smsResult) smsSentCount++; else smsFailedCount++;
                                }
                            }

                            // Success message
                            string resultMsg = $"✅ PAYROLL PROCESSED SUCCESSFULLY!\n\n" +
                                               $"╔══════════════════════════════╗\n" +
                                               $"║      PROCESSING SUMMARY      ║\n" +
                                               $"╚══════════════════════════════╝\n\n" +
                                               $"📅 Period: {period}\n" +
                                               $"💳 Method: {method}\n" +
                                               $"✅ Processed: {successCount} scholars\n";
                            if (skippedCount > 0) resultMsg += $"⏭ Skipped: {skippedCount} (already processed)\n";
                            resultMsg += $"💰 Total: ₱{_totalAmount:N2}\n\n" +
                                        $"📧 EMAIL: ✅ {emailSentCount} sent, ❌ {emailFailedCount} failed\n" +
                                        $"📱 SMS:   ✅ {smsSentCount} sent, ❌ {smsFailedCount} failed\n\n" +
                                        $"📨 In-app notifications sent to all recipients.";

                            MessageBox.Show(resultMsg, "Payroll Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadScholarsGrid();
                            LoadStatistics();
                        }
                        catch (Exception ex) { transaction.Rollback(); throw new Exception($"Transaction failed: {ex.Message}", ex); }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"❌ Error: {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { this.Cursor = Cursors.Default; }
        }

        // ============================================
        // DATABASE HELPERS
        // ============================================
        private string GetScholarEmailFromDB(int scholarId)
        {
            try { using (var conn = DatabaseHelper.GetConnection()) { conn.Open(); var cmd = new MySqlCommand("SELECT email FROM scholars WHERE id = @id", conn); cmd.Parameters.AddWithValue("@id", scholarId); return cmd.ExecuteScalar()?.ToString() ?? ""; } }
            catch { return ""; }
        }

        private string GetScholarPhoneFromDB(int scholarId)
        {
            try { using (var conn = DatabaseHelper.GetConnection()) { conn.Open(); var cmd = new MySqlCommand("SELECT contact_number FROM scholars WHERE id = @id", conn); cmd.Parameters.AddWithValue("@id", scholarId); return cmd.ExecuteScalar()?.ToString() ?? ""; } }
            catch { return ""; }
        }

        // ============================================
        // EMAIL NOTIFICATION - FIXED
        // ============================================
        private bool SendPaymentEmail(string toEmail, string scholarName, string period, decimal amount, string method, string scholarNumber)
        {
            if (!ENABLE_EMAIL_NOTIFICATIONS) return false;

            try
            {
                System.Diagnostics.Debug.WriteLine($"\n========================================");
                System.Diagnostics.Debug.WriteLine($"📧 SENDING EMAIL:");
                System.Diagnostics.Debug.WriteLine($"  From: {SENDER_EMAIL}");
                System.Diagnostics.Debug.WriteLine($"  To: {toEmail}");
                System.Diagnostics.Debug.WriteLine($"  Scholar: {scholarName}");
                System.Diagnostics.Debug.WriteLine($"  Period: {period}");
                System.Diagnostics.Debug.WriteLine($"  Amount: ₱{amount:N2}");
                System.Diagnostics.Debug.WriteLine($"========================================");

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SENDER_EMAIL, SENDER_NAME);

                    // Send to the scholar
                    mail.To.Add(new MailAddress(toEmail, scholarName));

                    // ALSO SEND A COPY TO YOURSELF so you can verify
                    mail.To.Add(new MailAddress("kylealba79@gmail.com", "Kyle (Test)"));

                    mail.Subject = $"ScholarAid - Payment Processed - {period} - {scholarName}";

                    // Plain text email
                    mail.Body = $"Dear {scholarName},\n\n" +
                               $"Your stipend has been processed!\n\n" +
                               $"Scholar Number: {scholarNumber}\n" +
                               $"Period: {period}\n" +
                               $"Amount: ₱{amount:N2}\n" +
                               $"Payment Method: {method}\n" +
                               $"Expected Release: Within 3-5 business days\n\n" +
                               $"For questions, contact the Scholarship Office.\n\n" +
                               $"Best regards,\nScholarAid Team\nLegacy College of Compostela\n\n" +
                               $"--\nThis is an automated notification.";

                    mail.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient(SMTP_HOST, SMTP_PORT))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);
                        smtp.Timeout = 30000;

                        System.Diagnostics.Debug.WriteLine($"Connecting to SMTP...");
                        smtp.Send(mail);
                        System.Diagnostics.Debug.WriteLine($"✅ Email sent successfully!");
                    }
                }

                ActivityLogger.LogCreate("notifications", 0, $"Email sent to {scholarName} ({toEmail}) for {period}");
                return true;
            }
            catch (SmtpException smtpEx)
            {
                string errorMsg = $"❌ SMTP Error: {smtpEx.StatusCode} - {smtpEx.Message}";
                System.Diagnostics.Debug.WriteLine(errorMsg);
                if (smtpEx.InnerException != null)
                    System.Diagnostics.Debug.WriteLine($"   Inner: {smtpEx.InnerException.Message}");

                // Show error popup for debugging
                MessageBox.Show($"EMAIL FAILED:\n\nStatus: {smtpEx.StatusCode}\n{smtpEx.Message}\n\n" +
                               $"Check: Is App Password correct? Is 2-Step Verification ON?",
                               "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ General Error: {ex.Message}");
                if (ex.InnerException != null)
                    System.Diagnostics.Debug.WriteLine($"   Inner: {ex.InnerException.Message}");
                return false;
            }
        }

        // ============================================
        // SMS NOTIFICATION - FIXED (Log + Debug)
        // ============================================
        private bool SendPaymentSMS(string phoneNumber, string scholarName, string period, decimal amount)
        {
            if (!ENABLE_SMS_NOTIFICATIONS) return false;

            try
            {
                System.Diagnostics.Debug.WriteLine($"\n========================================");
                System.Diagnostics.Debug.WriteLine($"📱 SENDING SMS:");
                System.Diagnostics.Debug.WriteLine($"  To: {phoneNumber}");
                System.Diagnostics.Debug.WriteLine($"  Scholar: {scholarName}");
                System.Diagnostics.Debug.WriteLine($"  Period: {period}");
                System.Diagnostics.Debug.WriteLine($"  Amount: ₱{amount:N2}");
                System.Diagnostics.Debug.WriteLine($"========================================");

                // Clean phone number
                string cleanPhone = phoneNumber.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("+", "");
                if (cleanPhone.StartsWith("63")) cleanPhone = "0" + cleanPhone.Substring(2);

                string smsMessage = $"ScholarAid: Hi {scholarName}, your stipend for {period} (P{amount:N0}) has been processed. Release: 3-5 days. -LCC";

                System.Diagnostics.Debug.WriteLine($"📱 Clean phone: {cleanPhone}");
                System.Diagnostics.Debug.WriteLine($"📱 SMS text: {smsMessage}");

                // Try Email-to-SMS gateway
                string smsGateway = GetSMSGateway(cleanPhone);
                System.Diagnostics.Debug.WriteLine($"📱 SMS Gateway: {smsGateway}");

                if (!string.IsNullOrEmpty(smsGateway))
                {
                    bool gatewayResult = SendSMSEmailGateway(smsGateway, smsMessage, scholarName);
                    System.Diagnostics.Debug.WriteLine($"📱 Gateway result: {(gatewayResult ? "Sent" : "Failed")}");
                }

                // ALWAYS log the SMS to activity log
                ActivityLogger.LogCreate("notifications", 0, $"SMS to {scholarName} ({cleanPhone}): {smsMessage}");
                System.Diagnostics.Debug.WriteLine($"📱 SMS logged to activity log");

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ SMS Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Formats phone number
        /// </summary>
        private string FormatPhoneNumber(string phone)
        {
            phone = phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            if (phone.StartsWith("09")) return "+63" + phone.Substring(1);
            if (phone.StartsWith("9")) return "+63" + phone;
            if (phone.StartsWith("+63")) return phone;
            return "+63" + phone;
        }

        /// <summary>
        /// Gets Email-to-SMS gateway address
        /// </summary>
        private string GetSMSGateway(string phone)
        {
            phone = phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("+", "");
            if (phone.StartsWith("63")) phone = "0" + phone.Substring(2);

            // Globe/TM
            if (phone.StartsWith("0915") || phone.StartsWith("0916") || phone.StartsWith("0917") ||
                phone.StartsWith("0926") || phone.StartsWith("0927") || phone.StartsWith("0935") ||
                phone.StartsWith("0936") || phone.StartsWith("0937") || phone.StartsWith("0994") ||
                phone.StartsWith("0995") || phone.StartsWith("0996") || phone.StartsWith("0997") ||
                phone.StartsWith("0817"))
                return phone + "@txt.globe.com.ph";

            // Smart/TNT/Sun (includes 0992 prefix)
            if (phone.StartsWith("0908") || phone.StartsWith("0909") || phone.StartsWith("0910") ||
                phone.StartsWith("0911") || phone.StartsWith("0912") || phone.StartsWith("0913") ||
                phone.StartsWith("0914") || phone.StartsWith("0918") || phone.StartsWith("0919") ||
                phone.StartsWith("0920") || phone.StartsWith("0921") || phone.StartsWith("0922") ||
                phone.StartsWith("0923") || phone.StartsWith("0925") || phone.StartsWith("0928") ||
                phone.StartsWith("0929") || phone.StartsWith("0930") || phone.StartsWith("0932") ||
                phone.StartsWith("0933") || phone.StartsWith("0934") || phone.StartsWith("0938") ||
                phone.StartsWith("0939") || phone.StartsWith("0940") || phone.StartsWith("0942") ||
                phone.StartsWith("0943") || phone.StartsWith("0946") || phone.StartsWith("0947") ||
                phone.StartsWith("0948") || phone.StartsWith("0949") || phone.StartsWith("0950") ||
                phone.StartsWith("0951") || phone.StartsWith("0970") || phone.StartsWith("0973") ||
                phone.StartsWith("0974") || phone.StartsWith("0975") || phone.StartsWith("0976") ||
                phone.StartsWith("0977") || phone.StartsWith("0978") || phone.StartsWith("0979") ||
                phone.StartsWith("0989") || phone.StartsWith("0992") || phone.StartsWith("0998") ||
                phone.StartsWith("0999"))
                return phone + "@text.smart.com.ph";

            // DITO
            if (phone.StartsWith("0895") || phone.StartsWith("0896") || phone.StartsWith("0897") ||
                phone.StartsWith("0898") || phone.StartsWith("0991") || phone.StartsWith("0993"))
                return phone + "@dito.ph";

            return phone + "@text.smart.com.ph"; // Default
        }

        /// <summary>
        /// Sends SMS via Email-to-SMS Gateway
        /// </summary>
        private bool SendSMSEmailGateway(string smsGateway, string message, string scholarName)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SENDER_EMAIL, SENDER_NAME);
                    mail.To.Add(new MailAddress(smsGateway));
                    mail.Subject = "";
                    mail.Body = message;
                    mail.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient(SMTP_HOST, SMTP_PORT))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);
                        smtp.Timeout = 15000;
                        smtp.Send(mail);
                    }
                }
                System.Diagnostics.Debug.WriteLine($"✅ Email-to-SMS sent to: {smsGateway}");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"⚠ Email-to-SMS gateway failed: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region Navigation

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            try { new FrmAdminDashboard().Show(); this.Hide(); }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnScholarMgmt_Click(object sender, EventArgs e)
        {
            try { new FrmScholarManagement().Show(); this.Hide(); }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            try { new FrmReportsAnalytics().Show(); this.Hide(); }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnActivityLog_Click(object sender, EventArgs e)
        {
            try { new FrmActivityLogs().Show(); this.Hide(); }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnReminder_Click(object sender, EventArgs e)
        {
            try { new FrmNotifications().Show(); this.Hide(); }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                ActivityLogger.LogLogout(SessionManager.CurrentUser?.Id ?? 0, SessionManager.CurrentUser?.Name ?? "");
                SessionManager.ClearSession();
                new Login().Show(); this.Close();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion
    }

    // Helper Classes
    public class ScholarPayroll
    {
        public int Id { get; set; }
        public string ScholarNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string ScholarshipType { get; set; }
        public decimal StipendAmount { get; set; }
        public string ComplianceStatus { get; set; }
        public bool IsEligible { get; set; }
    }

    public class ComplianceRecordItem
    {
        public int Id { get; set; }
        public string RequirementType { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}