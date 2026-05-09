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

        // SMS Gateway Configuration
        private const string SMS_GATEWAY_URL = "https://api.semaphore.co/api/v4/messages";
        private const string SMS_API_KEY = "09cabeb4384cf62307f39fd0f6a7efe5";

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

                // Set payment method items
                cmbPaymentMethod.Items.Clear();
                cmbPaymentMethod.Items.Add("Bank Transfer");
                cmbPaymentMethod.Items.Add("Cheque");
                cmbPaymentMethod.Items.Add("Cash");
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
                // Unwire first to prevent duplicates
                dgvScholars.CellValueChanged -= DgvScholars_CellValueChanged;
                dgvScholars.CurrentCellDirtyStateChanged -= DgvScholars_CurrentCellDirtyStateChanged;
                btnSelectAll.Click -= BtnSelectAll_Click;
                btnClearSelection.Click -= BtnClearSelection_Click;
                btnProcessPayroll.Click -= BtnProcessPayroll_Click;
                btnPreviewPayroll.Click -= BtnPreviewPayroll_Click;
                txtSearch.TextChanged -= TxtSearch_TextChanged;
                cmbScholarshipType.SelectedIndexChanged -= Filter_Changed;
                cmbYearLevel.SelectedIndexChanged -= Filter_Changed;

                // Wire events
                dgvScholars.CellValueChanged += DgvScholars_CellValueChanged;
                dgvScholars.CurrentCellDirtyStateChanged += DgvScholars_CurrentCellDirtyStateChanged;
                btnSelectAll.Click += BtnSelectAll_Click;
                btnClearSelection.Click += BtnClearSelection_Click;
                btnProcessPayroll.Click += BtnProcessPayroll_Click;
                btnPreviewPayroll.Click += BtnPreviewPayroll_Click;
                txtSearch.TextChanged += TxtSearch_TextChanged;
                cmbScholarshipType.SelectedIndexChanged += Filter_Changed;
                cmbYearLevel.SelectedIndexChanged += Filter_Changed;

                // Make ALL columns read-only except checkbox column
                // DO NOT set dgvScholars.ReadOnly = true at grid level
                dgvScholars.ReadOnly = false; // Allow editing at grid level
                foreach (DataGridViewColumn col in dgvScholars.Columns)
                {
                    col.ReadOnly = true; // Make each column read-only
                }
                // Then make only the checkbox column editable
                if (dgvScholars.Columns.Contains("colSelect"))
                {
                    dgvScholars.Columns["colSelect"].ReadOnly = false;
                }
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
                            dgvScholars.Rows[rowIndex].Tag = scholar.Id; // Store ID in Tag for lookup
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

        #region Event Handlers

        private void DgvScholars_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try { if (dgvScholars.IsCurrentCellDirty) dgvScholars.CommitEdit(DataGridViewDataErrorContexts.Commit); }
            catch { }
        }

        private void DgvScholars_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!_isLoading && e.RowIndex >= 0 && e.ColumnIndex == dgvScholars.Columns["colSelect"].Index)
                    UpdateStatistics();
            }
            catch { }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Use ID-based lookup instead of index-based
                for (int i = 0; i < dgvScholars.Rows.Count; i++)
                {
                    int scholarId = Convert.ToInt32(dgvScholars.Rows[i].Tag);
                    var scholar = _scholars.FirstOrDefault(s => s.Id == scholarId);
                    if (scholar != null && scholar.IsEligible)
                    {
                        dgvScholars.Rows[i].Cells["colSelect"].Value = true;
                    }
                }
                UpdateStatistics();
            }
            catch { }
        }

        private void BtnClearSelection_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvScholars.Rows.Count; i++)
                    dgvScholars.Rows[i].Cells["colSelect"].Value = false;
                UpdateStatistics();
            }
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
                _selectedCount = 0;
                _totalAmount = 0;

                for (int i = 0; i < dgvScholars.Rows.Count; i++)
                {
                    var cellValue = dgvScholars.Rows[i].Cells["colSelect"].Value;
                    if (cellValue != null && Convert.ToBoolean(cellValue))
                    {
                        // Find scholar by ID stored in the grid row
                        int scholarId = Convert.ToInt32(dgvScholars.Rows[i].Tag);
                        var scholar = _scholars.FirstOrDefault(s => s.Id == scholarId);
                        if (scholar != null && scholar.IsEligible)
                        {
                            _selectedCount++;
                            _totalAmount += scholar.StipendAmount;
                        }
                    }
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
                    if (cellValue != null && Convert.ToBoolean(cellValue))
                    {
                        // Find scholar by ID stored in the grid row
                        int scholarId = Convert.ToInt32(dgvScholars.Rows[i].Tag);
                        var scholar = _scholars.FirstOrDefault(s => s.Id == scholarId);
                        if (scholar != null && scholar.IsEligible)
                            selected.Add(scholar);
                    }
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
                                // In ProcessPayroll method, update the insert query remarks:
                                insertCmd.Parameters.AddWithValue("@remarks", $"Batch payroll for {period} via {method}");
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

                            // SEND EMAIL + SMS TO EACH SCHOLAR
                            foreach (var scholar in scholars)
                            {
                                string scholarEmail = GetScholarEmailFromDB(scholar.Id);
                                string scholarPhone = GetScholarPhoneFromDB(scholar.Id);

                                if (!string.IsNullOrEmpty(scholarEmail))
                                {
                                    bool emailResult = SendPaymentEmail(scholarEmail, scholar.FullName, period, scholar.StipendAmount, method, scholar.ScholarNumber);
                                    if (emailResult) emailSentCount++; else emailFailedCount++;
                                }

                                if (!string.IsNullOrEmpty(scholarPhone))
                                {
                                    bool smsResult = SendPaymentSMS(scholarPhone, scholar.FullName, period, scholar.StipendAmount);
                                    if (smsResult) smsSentCount++; else smsFailedCount++;
                                }
                            }

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

        private bool SendPaymentEmail(string toEmail, string scholarName, string period, decimal amount, string method, string scholarNumber)
        {
            if (!ENABLE_EMAIL_NOTIFICATIONS) return false;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SENDER_EMAIL, SENDER_NAME);
                    mail.To.Add(new MailAddress(toEmail, scholarName));
                    mail.To.Add(new MailAddress("kylealba79@gmail.com", "Kyle (Test)"));
                    mail.Subject = $"ScholarAid - Payment Processed - {period} - {scholarName}";
                    mail.Body = $"Dear {scholarName},\n\nYour stipend has been processed!\n\nScholar Number: {scholarNumber}\nPeriod: {period}\nAmount: ₱{amount:N2}\nPayment Method: {method}\nExpected Release: Within 3-5 business days\n\nFor questions, contact the Scholarship Office.\n\nBest regards,\nScholarAid Team\nLegacy College of Compostela\n\n--\nThis is an automated notification.";
                    mail.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient(SMTP_HOST, SMTP_PORT))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);
                        smtp.Timeout = 30000;
                        smtp.Send(mail);
                    }
                }
                ActivityLogger.LogCreate("notifications", 0, $"Email sent to {scholarName} ({toEmail}) for {period}");
                return true;
            }
            catch (SmtpException smtpEx)
            {
                System.Diagnostics.Debug.WriteLine($"❌ SMTP Error: {smtpEx.StatusCode} - {smtpEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ General Error: {ex.Message}");
                return false;
            }
        }

        private bool SendPaymentSMS(string phoneNumber, string scholarName, string period, decimal amount)
        {
            if (!ENABLE_SMS_NOTIFICATIONS) return false;
            try
            {
                string cleanPhone = phoneNumber.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("+", "");
                if (cleanPhone.StartsWith("63")) cleanPhone = "0" + cleanPhone.Substring(2);
                string smsMessage = $"ScholarAid: Hi {scholarName}, your stipend for {period} (P{amount:N0}) has been processed. Release: 3-5 days. -LCC";
                string smsGateway = GetSMSGateway(cleanPhone);
                if (!string.IsNullOrEmpty(smsGateway))
                    SendSMSEmailGateway(smsGateway, smsMessage, scholarName);
                ActivityLogger.LogCreate("notifications", 0, $"SMS to {scholarName} ({cleanPhone}): {smsMessage}");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ SMS Error: {ex.Message}");
                return false;
            }
        }

        private string GetSMSGateway(string phone)
        {
            phone = phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("+", "");
            if (phone.StartsWith("63")) phone = "0" + phone.Substring(2);
            if (phone.StartsWith("0915") || phone.StartsWith("0916") || phone.StartsWith("0917") || phone.StartsWith("0926") || phone.StartsWith("0927") || phone.StartsWith("0935") || phone.StartsWith("0936") || phone.StartsWith("0937") || phone.StartsWith("0994") || phone.StartsWith("0995") || phone.StartsWith("0996") || phone.StartsWith("0997") || phone.StartsWith("0817"))
                return phone + "@txt.globe.com.ph";
            return phone + "@text.smart.com.ph";
        }

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
                return true;
            }
            catch { return false; }
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
}