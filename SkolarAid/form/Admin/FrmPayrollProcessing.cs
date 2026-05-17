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
        private const string SENDER_EMAIL = "iskolaraid@gmail.com";
        private const string SENDER_PASSWORD = "gmvlmnme fgfr mzjy";
        private const string SENDER_NAME = "Legacy College of Compostela - ScholarAid";
        private const bool ENABLE_EMAIL_NOTIFICATIONS = true;
        private const bool ENABLE_SMS_NOTIFICATIONS = true;

        private FrameworkTest.SATAButton btnRelease;
        private FrameworkTest.SATAButton btnInfo;
        private DataGridView dgvDisbursementHistory; // NEW: Disbursement history grid
        private Label lblHistoryTitle; // NEW: History section title

        public FrmPayrollProcessing()
        {
            InitializeComponent();
            InitializeDisbursementHistoryGrid(); // NEW: Add history grid
            this.Load += FrmPayrollProcessing_Load_1;
            this.Resize += FrmPayrollProcessing_Resize;
        }

        /// <summary>
        /// Creates the disbursement history grid in the summary panel
        /// </summary>
        private void InitializeDisbursementHistoryGrid()
        {
            // History section title
            lblHistoryTitle = new Label
            {
                Text = "📋 Disbursement History",
                Font = new Font("Century Gothic", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                Location = new Point(20, 200),
                AutoSize = true
            };
            panelSummary.Controls.Add(lblHistoryTitle);

            // Description label
            Label lblHistoryDesc = new Label
            {
                Text = "Already paid for current period:",
                Font = new Font("Century Gothic", 9F),
                ForeColor = Color.Gray,
                Location = new Point(20, 225),
                AutoSize = true
            };
            panelSummary.Controls.Add(lblHistoryDesc);

            // Disbursement history grid
            dgvDisbursementHistory = new DataGridView
            {
                Location = new Point(20, 250),
                Size = new Size(panelSummary.Width - 40, 200),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 68, 79),
                    ForeColor = Color.White,
                    Font = new Font("Century Gothic", 8F, FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Century Gothic", 8F)
                },
                RowTemplate = { Height = 28 }
            };

            // Add columns
            dgvDisbursementHistory.Columns.Add("colHistScholar", "Scholar");
            dgvDisbursementHistory.Columns.Add("colHistPeriod", "Period");
            dgvDisbursementHistory.Columns.Add("colHistAmount", "Amount");
            dgvDisbursementHistory.Columns.Add("colHistStatus", "Status");
            dgvDisbursementHistory.Columns.Add("colHistDate", "Release Date");

            // Column widths
            dgvDisbursementHistory.Columns["colHistScholar"].FillWeight = 35;
            dgvDisbursementHistory.Columns["colHistPeriod"].FillWeight = 25;
            dgvDisbursementHistory.Columns["colHistAmount"].FillWeight = 15;
            dgvDisbursementHistory.Columns["colHistStatus"].FillWeight = 12;
            dgvDisbursementHistory.Columns["colHistDate"].FillWeight = 13;

            // Format amount column
            dgvDisbursementHistory.Columns["colHistAmount"].DefaultCellStyle.Format = "₱#,##0";
            dgvDisbursementHistory.Columns["colHistAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            panelSummary.Controls.Add(dgvDisbursementHistory);

            // Adjust Release button position (moved lower to accommodate history grid)
            if (btnRelease != null)
            {
                btnRelease.Location = new Point(20, panelSummary.Height - 70);
            }
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

            int gridWidth = (int)((screenWidth - 321) * 0.75);
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

            // Adjust history grid size
            if (dgvDisbursementHistory != null && panelSummary != null)
            {
                dgvDisbursementHistory.Size = new Size(panelSummary.Width - 40, panelSummary.Height - 340);
            }

            // Adjust release button position
            if (btnRelease != null && panelSummary != null)
            {
                btnRelease.Location = new Point(20, panelSummary.Height - 70);
                btnRelease.Size = new Size(panelSummary.Width - 40, 45);
            }
        }

        private void FrmPayrollProcessing_Load_1(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;

                dtpPaymentPeriod.Value = DateTime.Now;
                cmbPaymentMethod.Items.Clear();
                cmbPaymentMethod.Items.Add("Bank Transfer");
                cmbPaymentMethod.Items.Add("Cheque");
                cmbPaymentMethod.Items.Add("Cash");
                cmbPaymentMethod.SelectedIndex = 0;

                cmbYearLevel.Items.Clear();
                cmbYearLevel.Items.Add("All Year Levels");
                for (int i = 1; i <= 4; i++)
                    cmbYearLevel.Items.Add($"Year {i}");
                if (cmbYearLevel.Items.Count > 0) cmbYearLevel.SelectedIndex = 0;

                WireUpEvents();
                AddReleaseButton();
                AddInfoButton();
                LoadFilterOptions();
                LoadScholarsGrid();
                LoadStatistics();
                LoadDisbursementHistory(); // NEW: Load history on startup
                AdjustLayoutForFullscreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Payroll Processing form: {ex.Message}",
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads disbursement history for the current payment period
        /// Shows which scholars have already been paid to prevent double disbursement
        /// </summary>
        private void LoadDisbursementHistory()
        {
            try
            {
                dgvDisbursementHistory.Rows.Clear();
                string currentPeriod = dtpPaymentPeriod.Value.ToString("MMMM yyyy");

                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        CONCAT(s.first_name, ' ', s.last_name) AS scholar_name,
                                        s.scholar_number,
                                        p.payment_period,
                                        p.amount,
                                        p.status,
                                        p.release_date,
                                        p.payment_method,
                                        p.reference_number
                                    FROM payments p
                                    JOIN scholars s ON p.scholar_id = s.id
                                    WHERE p.payment_period = @period
                                    ORDER BY p.release_date DESC, p.status ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@period", currentPeriod);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int releasedCount = 0;
                        int processedCount = 0;
                        int pendingCount = 0;

                        while (reader.Read())
                        {
                            string scholarName = reader["scholar_name"].ToString();
                            string period = reader["payment_period"].ToString();
                            decimal amount = Convert.ToDecimal(reader["amount"]);
                            string status = reader["status"].ToString();
                            string releaseDate = reader["release_date"] != DBNull.Value ?
                                Convert.ToDateTime(reader["release_date"]).ToString("MMM dd, yyyy") : "Pending";

                            int rowIndex = dgvDisbursementHistory.Rows.Add();
                            dgvDisbursementHistory.Rows[rowIndex].Cells["colHistScholar"].Value = scholarName;
                            dgvDisbursementHistory.Rows[rowIndex].Cells["colHistPeriod"].Value = period;
                            dgvDisbursementHistory.Rows[rowIndex].Cells["colHistAmount"].Value = amount;
                            dgvDisbursementHistory.Rows[rowIndex].Cells["colHistStatus"].Value = status;
                            dgvDisbursementHistory.Rows[rowIndex].Cells["colHistDate"].Value = releaseDate;

                            // Color code by status
                            var statusCell = dgvDisbursementHistory.Rows[rowIndex].Cells["colHistStatus"];
                            switch (status)
                            {
                                case "Released":
                                    statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                                    statusCell.Style.Font = new Font("Century Gothic", 8F, FontStyle.Bold);
                                    dgvDisbursementHistory.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
                                    releasedCount++;
                                    break;
                                case "Processed":
                                    statusCell.Style.ForeColor = Color.FromArgb(255, 193, 7);
                                    statusCell.Style.Font = new Font("Century Gothic", 8F, FontStyle.Bold);
                                    dgvDisbursementHistory.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 252, 235);
                                    processedCount++;
                                    break;
                                case "Pending":
                                    statusCell.Style.ForeColor = Color.FromArgb(108, 117, 125);
                                    statusCell.Style.Font = new Font("Century Gothic", 8F, FontStyle.Bold);
                                    pendingCount++;
                                    break;
                                case "Failed":
                                    statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                                    statusCell.Style.Font = new Font("Century Gothic", 8F, FontStyle.Bold);
                                    dgvDisbursementHistory.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240);
                                    break;
                            }
                        }

                        // Update history title with counts
                        string statusSummary = "";
                        if (releasedCount > 0) statusSummary += $"✅ {releasedCount} Released";
                        if (processedCount > 0) statusSummary += (statusSummary.Length > 0 ? " | " : "") + $"🟡 {processedCount} Processed";
                        if (pendingCount > 0) statusSummary += (statusSummary.Length > 0 ? " | " : "") + $"⏳ {pendingCount} Pending";

                        lblHistoryTitle.Text = statusSummary.Length > 0
                            ? $"📋 Disbursement History ({statusSummary})"
                            : "📋 Disbursement History (No payments yet)";

                        // If no records, show a message
                        if (dgvDisbursementHistory.Rows.Count == 0)
                        {
                            dgvDisbursementHistory.Rows.Add("", "No disbursements for this period", "", "", "");
                            dgvDisbursementHistory.Rows[0].DefaultCellStyle.ForeColor = Color.Gray;
                            dgvDisbursementHistory.Rows[0].DefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Italic);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading disbursement history: {ex.Message}");
            }
        }

        private void AddReleaseButton()
        {
            btnRelease = new FrameworkTest.SATAButton
            {
                ButtonText = "Release Payments",
                Name = "btnRelease",
                Font = new Font("Century Gothic", 11F, FontStyle.Bold),
                NormalBackground = Color.FromArgb(40, 167, 69),
                NormalForeColor = Color.White,
                HoverBackground = Color.FromArgb(30, 140, 55),
                Rounding = new Padding(8),
                TextAutoCenter = true,
                Size = new Size(panelSummary.Width - 40, 45),
                Location = new Point(20, panelSummary.Height - 70)
            };
            btnRelease.Click += BtnRelease_Click;
            panelSummary.Controls.Add(btnRelease);
        }

        private void AddInfoButton()
        {
            btnInfo = new FrameworkTest.SATAButton
            {
                ButtonText = "❓ How It Works",
                Name = "btnInfo",
                Font = new Font("Century Gothic", 10F, FontStyle.Regular),
                NormalBackground = Color.FromArgb(52, 73, 94),
                NormalForeColor = Color.White,
                HoverBackground = Color.FromArgb(44, 62, 80),
                Rounding = new Padding(6),
                TextAutoCenter = true,
                Size = new Size(140, 38),
                Location = new Point(btnProcessPayroll.Right + 205, btnProcessPayroll.Top)
            };
            btnInfo.Click += BtnInfo_Click;
            panelBatchControls.Controls.Add(btnInfo);
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            string infoMessage =
                "╔══════════════════════════════════════════════════════════════╗\n" +
                "║              📋 HOW PAYMENT PROCESSING WORKS                ║\n" +
                "╚══════════════════════════════════════════════════════════════╝\n\n" +
                "🔵 STEP 1: SELECT SCHOLARS\n" +
                "   ─────────────────────────────────────────────────────────\n" +
                "   • Choose eligible scholars from the list below\n" +
                "   • Only scholars with ALL documents APPROVED are eligible\n" +
                "   • Check the box ☑ next to each scholar's name\n" +
                "   • Check Disbursement History to avoid duplicates\n\n" +
                "🟢 STEP 2: PROCESS PAYROLL\n" +
                "   ─────────────────────────────────────────────────────────\n" +
                "   • Click the 'Process Payroll' button\n" +
                "   • System creates payment records\n" +
                "   • Status becomes 'PROCESSED'\n" +
                "   • Release date is set to 3 days from now\n\n" +
                "🟡 STEP 3: WAIT FOR RELEASE DATE\n" +
                "   ─────────────────────────────────────────────────────────\n" +
                "   • Payments have a 3-day waiting period\n" +
                "   • This allows time for bank processing\n" +
                "   • You CANNOT release payments before this date\n\n" +
                "🔴 STEP 4: RELEASE PAYMENTS\n" +
                "   ─────────────────────────────────────────────────────────\n" +
                "   • After the release date, click 'Release Payments'\n" +
                "   • Status changes to 'RELEASED'\n" +
                "   • Scholar receives email and SMS notification\n" +
                "   • Funds are sent to the scholar\n\n" +
                "╔══════════════════════════════════════════════════════════════╗\n" +
                "║  ⚠ IMPORTANT: Check Disbursement History!                  ║\n" +
                "║  • The right panel shows who has been paid this period     ║\n" +
                "║  • Scholars already 'Released' will be SKIPPED             ║\n" +
                "║  • This prevents accidental DOUBLE DISBURSEMENT           ║\n" +
                "╚══════════════════════════════════════════════════════════════╝";

            MessageBox.Show(infoMessage, "Payment Processing Guide",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WireUpEvents()
        {
            try
            {
                dgvScholars.CellValueChanged -= DgvScholars_CellValueChanged;
                dgvScholars.CurrentCellDirtyStateChanged -= DgvScholars_CurrentCellDirtyStateChanged;
                btnSelectAll.Click -= BtnSelectAll_Click;
                btnClearSelection.Click -= BtnClearSelection_Click;
                btnProcessPayroll.Click -= BtnProcessPayroll_Click;
                btnPreviewPayroll.Click -= BtnPreviewPayroll_Click;
                txtSearch.TextChanged -= TxtSearch_TextChanged;
                cmbScholarshipType.SelectedIndexChanged -= Filter_Changed;
                cmbYearLevel.SelectedIndexChanged -= Filter_Changed;
                dtpPaymentPeriod.ValueChanged -= DtpPaymentPeriod_ValueChanged; // NEW

                dgvScholars.CellValueChanged += DgvScholars_CellValueChanged;
                dgvScholars.CurrentCellDirtyStateChanged += DgvScholars_CurrentCellDirtyStateChanged;
                btnSelectAll.Click += BtnSelectAll_Click;
                btnClearSelection.Click += BtnClearSelection_Click;
                btnProcessPayroll.Click += BtnProcessPayroll_Click;
                btnPreviewPayroll.Click += BtnPreviewPayroll_Click;
                txtSearch.TextChanged += TxtSearch_TextChanged;
                cmbScholarshipType.SelectedIndexChanged += Filter_Changed;
                cmbYearLevel.SelectedIndexChanged += Filter_Changed;
                dtpPaymentPeriod.ValueChanged += DtpPaymentPeriod_ValueChanged; // NEW

                dgvScholars.ReadOnly = false;
                foreach (DataGridViewColumn col in dgvScholars.Columns)
                {
                    col.ReadOnly = true;
                }
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

        // NEW: Reload history when payment period changes
        private void DtpPaymentPeriod_ValueChanged(object sender, EventArgs e)
        {
            LoadDisbursementHistory();
        }

        #region Database Loading Methods

        private void LoadFilterOptions()
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
                        cmbScholarshipType.Items.Add(new ComboItem { Id = 0, Name = "All Scholarship Types" });
                        while (reader.Read())
                        {
                            cmbScholarshipType.Items.Add(new ComboItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString()
                            });
                        }
                    }
                }
                if (cmbScholarshipType.Items.Count > 0) cmbScholarshipType.SelectedIndex = 0;
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

                    string query = @"
                        SELECT 
                            s.id, 
                            s.scholar_number,
                            s.email, 
                            s.contact_number,
                            CONCAT(s.first_name, ' ', s.last_name) AS full_name,
                            s.course, 
                            s.year_level,
                            st.id AS scholarship_type_id,
                            st.name AS scholarship_name, 
                            st.stipend_amount,
                            s.status,
                            CASE 
                                WHEN NOT EXISTS (SELECT 1 FROM compliance_records cr WHERE cr.scholar_id = s.id) 
                                    THEN 'No Records'
                                WHEN NOT EXISTS (SELECT 1 FROM compliance_records cr 
                                                 WHERE cr.scholar_id = s.id 
                                                 AND cr.status = 'Approved') 
                                    THEN 'Pending Approval'
                                WHEN EXISTS (SELECT 1 FROM compliance_records cr 
                                             WHERE cr.scholar_id = s.id 
                                             AND cr.status IN ('Pending', 'Overdue', 'Submitted')) 
                                    THEN 'Incomplete'
                                ELSE 'Complete'
                            END AS compliance_status,
                            CASE 
                                WHEN EXISTS (
                                    SELECT 1 FROM payments p 
                                    WHERE p.scholar_id = s.id 
                                    AND p.payment_period = @currentPeriod
                                    AND p.status IN ('Released', 'Processed')
                                ) THEN 'Already Paid'
                                ELSE 'Not Paid'
                            END AS payment_status
                        FROM scholars s
                        LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                        WHERE s.status = 'Active'";

                    if (cmbScholarshipType.SelectedItem is ComboItem selectedType && selectedType.Id > 0)
                        query += " AND s.scholarship_type_id = @scholarshipTypeId";
                    if (cmbYearLevel.SelectedIndex > 0 && cmbYearLevel.SelectedItem.ToString() != "All Year Levels")
                        query += " AND s.year_level = @yearLevel";
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                        query += " AND (s.scholar_number LIKE @search OR s.first_name LIKE @search OR s.last_name LIKE @search OR CONCAT(s.first_name, ' ', s.last_name) LIKE @search)";
                    query += " ORDER BY s.id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@currentPeriod", dtpPaymentPeriod.Value.ToString("MMMM yyyy"));
                    if (cmbScholarshipType.SelectedItem is ComboItem selectedTypeParam && selectedTypeParam.Id > 0)
                        cmd.Parameters.AddWithValue("@scholarshipTypeId", selectedTypeParam.Id);
                    if (cmbYearLevel.SelectedIndex > 0 && cmbYearLevel.SelectedItem.ToString() != "All Year Levels")
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
                                ScholarshipTypeId = reader["scholarship_type_id"] != DBNull.Value ? Convert.ToInt32(reader["scholarship_type_id"]) : 0,
                                StipendAmount = reader["stipend_amount"] != DBNull.Value ? Convert.ToDecimal(reader["stipend_amount"]) : 0,
                                ComplianceStatus = reader["compliance_status"].ToString(),
                                PaymentStatus = reader["payment_status"].ToString()
                            };

                            bool alreadyPaid = scholar.PaymentStatus == "Already Paid";
                            scholar.IsEligible = (scholar.ComplianceStatus == "Complete") && scholar.StipendAmount > 0 && !alreadyPaid;
                            _scholars.Add(scholar);

                            int rowIndex = dgvScholars.Rows.Add();
                            dgvScholars.Rows[rowIndex].Tag = scholar.Id;
                            dgvScholars.Rows[rowIndex].Cells["colSelect"].Value = false;
                            dgvScholars.Rows[rowIndex].Cells["colScholarNumber"].Value = scholar.ScholarNumber;
                            dgvScholars.Rows[rowIndex].Cells["colName"].Value = scholar.FullName;
                            dgvScholars.Rows[rowIndex].Cells["colCourse"].Value = scholar.Course;
                            dgvScholars.Rows[rowIndex].Cells["colYearLevel"].Value = scholar.YearLevel;
                            dgvScholars.Rows[rowIndex].Cells["colScholarshipType"].Value = scholar.ScholarshipType;
                            dgvScholars.Rows[rowIndex].Cells["colStipendAmount"].Value = $"₱{scholar.StipendAmount:N2}";
                            dgvScholars.Rows[rowIndex].Cells["colComplianceStatus"].Value = scholar.ComplianceStatus;

                            // Show payment status in eligible column
                            if (alreadyPaid)
                            {
                                dgvScholars.Rows[rowIndex].Cells["colEligible"].Value = "⚠ Already Paid";
                                dgvScholars.Rows[rowIndex].Cells["colEligible"].Style.ForeColor = Color.FromArgb(255, 140, 0);
                                dgvScholars.Rows[rowIndex].Cells["colEligible"].Style.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
                                dgvScholars.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 240);
                                dgvScholars.Rows[rowIndex].Cells["colSelect"].ReadOnly = true;
                            }
                            else if (scholar.IsEligible)
                            {
                                dgvScholars.Rows[rowIndex].Cells["colEligible"].Value = "✓ Eligible";
                                dgvScholars.Rows[rowIndex].Cells["colEligible"].Style.ForeColor = Color.FromArgb(40, 167, 69);
                                dgvScholars.Rows[rowIndex].Cells["colEligible"].Style.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
                            }
                            else
                            {
                                dgvScholars.Rows[rowIndex].Cells["colEligible"].Value = "✗ Not Eligible";
                                dgvScholars.Rows[rowIndex].Cells["colEligible"].Style.ForeColor = Color.FromArgb(180, 180, 180);
                                dgvScholars.Rows[rowIndex].Cells["colSelect"].ReadOnly = true;
                                dgvScholars.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
                            }

                            // Color compliance status
                            var complianceCell = dgvScholars.Rows[rowIndex].Cells["colComplianceStatus"];
                            if (scholar.ComplianceStatus == "Complete")
                            {
                                complianceCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                                complianceCell.Style.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
                            }
                            else if (scholar.ComplianceStatus == "Pending Approval")
                            {
                                complianceCell.Style.ForeColor = Color.FromArgb(255, 193, 7);
                                complianceCell.Style.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
                            }
                            else
                            {
                                complianceCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                                complianceCell.Style.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
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

                    string readyQuery = @"SELECT COUNT(*) FROM payments 
                                         WHERE status = 'Processed' 
                                         AND release_date IS NOT NULL 
                                         AND release_date <= CURDATE()";
                    MySqlCommand cmdReady = new MySqlCommand(readyQuery, conn);
                    int readyCount = Convert.ToInt32(cmdReady.ExecuteScalar());

                    if (btnRelease != null)
                    {
                        btnRelease.ButtonText = readyCount > 0
                            ? $"🔓 Release Payments ({readyCount} ready)"
                            : "🔓 Release Payments";
                    }
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
                for (int i = 0; i < dgvScholars.Rows.Count; i++)
                {
                    int scholarId = Convert.ToInt32(dgvScholars.Rows[i].Tag);
                    var scholar = _scholars.FirstOrDefault(s => s.Id == scholarId);
                    if (scholar != null && scholar.IsEligible && scholar.PaymentStatus != "Already Paid")
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
        private void Filter_Changed(object sender, EventArgs e) { try { LoadScholarsGrid(); LoadDisbursementHistory(); } catch { } }

        private void BtnPreviewPayroll_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedScholars = GetSelectedScholars();
                if (selectedScholars.Count == 0)
                {
                    MessageBox.Show("⚠ Please select at least one eligible scholar.\n\n" +
                                   "Note: Scholars marked '⚠ Already Paid' cannot be selected.",
                        "No Eligible Scholars", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string period = dtpPaymentPeriod.Value.ToString("MMMM yyyy");
                string method = cmbPaymentMethod.SelectedItem?.ToString() ?? "Bank Transfer";

                var existingPayments = CheckExistingPayments(selectedScholars, period);
                var newScholars = selectedScholars.Where(scholar => !existingPayments.Any(existing => existing.Id == scholar.Id)).ToList();

                string previewMessage = $"📋 PAYROLL PREVIEW\n\n" +
                                       $"📅 Period: {period}\n" +
                                       $"💳 Method: {method}\n" +
                                       $"👥 Selected Scholars: {selectedScholars.Count}\n";

                if (existingPayments.Any())
                {
                    previewMessage += $"⚠ Already Paid (will be skipped): {existingPayments.Count}\n" +
                                     $"✅ New Scholars: {newScholars.Count}\n\n";
                }

                previewMessage += $"💰 Total Amount: ₱{_totalAmount:N2}\n\n" +
                                 $"{string.Join("\n", selectedScholars.Select(s => $"• {s.FullName} - ₱{s.StipendAmount:N2}"))}";

                if (existingPayments.Any())
                {
                    previewMessage += $"\n\n⚠ NOTE: {existingPayments.Count} scholar(s) already have payments for this period and will be skipped.";
                }

                previewMessage += $"\n\n💡 TIP: Check the 'Disbursement History' panel to see who has already been paid.";

                MessageBox.Show(previewMessage, "Payroll Preview",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Preview Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnProcessPayroll_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedScholars = GetSelectedScholars();
                if (selectedScholars.Count == 0)
                {
                    MessageBox.Show("⚠ Please select at least one eligible scholar.\n\n" +
                                   "Note: Scholars marked '⚠ Already Paid' cannot be selected.",
                        "No Eligible Scholars", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string period = dtpPaymentPeriod.Value.ToString("MMMM yyyy");
                string method = cmbPaymentMethod.SelectedItem?.ToString() ?? "Bank Transfer";

                var existingPayments = CheckExistingPayments(selectedScholars, period);
                if (existingPayments.Any())
                {
                    string existingList = string.Join("\n", existingPayments.Select(s => $"• {s.FullName}"));
                    DialogResult result = MessageBox.Show(
                        $"⚠ DOUBLE DISBURSEMENT WARNING!\n\n" +
                        $"These scholars already have payments for {period}:\n\n{existingList}\n\n" +
                        $"Check the Disbursement History panel for details.\n\n" +
                        $"Do you want to skip them and process only the remaining scholars?",
                        "⚠ Duplicate Payment Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                        return;

                    selectedScholars = selectedScholars.Where(scholar => !existingPayments.Any(existing => existing.Id == scholar.Id)).ToList();

                    if (selectedScholars.Count == 0)
                    {
                        MessageBox.Show("All selected scholars already have payments for this period.\n\n" +
                                       "Check the Disbursement History panel for details.",
                            "No New Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (MessageBox.Show($"CONFIRM PAYROLL\n\n📅 Period: {period}\n💳 Method: {method}\n👥 Scholars: {selectedScholars.Count}\n💰 Total: ₱{_totalAmount:N2}\n\nProceed?",
                    "Confirm Payroll Processing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProcessPayroll(selectedScholars, period, method);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Release Payments

        private List<ScholarPayroll> CheckExistingPayments(List<ScholarPayroll> scholars, string period)
        {
            var existing = new List<ScholarPayroll>();
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    foreach (var scholar in scholars)
                    {
                        string checkQuery = "SELECT COUNT(*) FROM payments WHERE scholar_id = @sid AND payment_period = @period";
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@sid", scholar.Id);
                        checkCmd.Parameters.AddWithValue("@period", period);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                            existing.Add(scholar);
                    }
                }
            }
            catch { }
            return existing;
        }

        private void BtnRelease_Click(object sender, EventArgs e)
        {
            try
            {
                var processedPayments = GetProcessedPaymentsReadyForRelease();

                if (processedPayments.Count == 0)
                {
                    MessageBox.Show(
                        "📋 NO PAYMENTS READY FOR RELEASE\n\n" +
                        "Payments must meet ALL these conditions:\n" +
                        "✓ Status = 'Processed'\n" +
                        "✓ Release date is today or earlier\n\n" +
                        "📌 Note: Newly processed payments have a 3-day waiting period before release.\n" +
                        "📌 Check back after the release date to release payments.\n\n" +
                        "💡 Tip: Check the Disbursement History panel for payment status.",
                        "No Payments Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                decimal totalToRelease = processedPayments.Sum(p => p.Amount);

                string message = $"📋 RELEASE PAYMENTS\n\n" +
                                $"👥 Scholars: {processedPayments.Count}\n" +
                                $"💰 Total Amount: ₱{totalToRelease:N2}\n\n" +
                                $"This will:\n" +
                                $"• Mark payments as 'Released'\n" +
                                $"• Set release date to today\n" +
                                $"• Send release notifications to scholars\n\n" +
                                $"Continue?";

                if (MessageBox.Show(message, "Confirm Release",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ReleasePayments(processedPayments);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Release Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<PaymentRelease> GetProcessedPaymentsReadyForRelease()
        {
            var payments = new List<PaymentRelease>();

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT p.id, p.scholar_id, p.payment_period, p.amount, 
                                    p.release_date, p.payment_method, p.reference_number, p.status,
                                    CONCAT(s.first_name, ' ', s.last_name) AS scholar_name,
                                    s.scholar_number, s.email, s.contact_number
                                    FROM payments p
                                    JOIN scholars s ON p.scholar_id = s.id
                                    WHERE p.status = 'Processed' 
                                    AND p.release_date IS NOT NULL 
                                    AND p.release_date <= CURDATE()
                                    ORDER BY p.release_date ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(new PaymentRelease
                            {
                                PaymentId = Convert.ToInt32(reader["id"]),
                                ScholarId = Convert.ToInt32(reader["scholar_id"]),
                                ScholarName = reader["scholar_name"].ToString(),
                                ScholarNumber = reader["scholar_number"].ToString(),
                                Email = reader["email"]?.ToString() ?? "",
                                ContactNumber = reader["contact_number"]?.ToString() ?? "",
                                Period = reader["payment_period"].ToString(),
                                Amount = Convert.ToDecimal(reader["amount"]),
                                PaymentMethod = reader["payment_method"].ToString(),
                                ReferenceNumber = reader["reference_number"]?.ToString() ?? "",
                                Status = reader["status"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting processed payments: {ex.Message}");
            }

            return payments;
        }

        private void ReleasePayments(List<PaymentRelease> payments)
        {
            this.Cursor = Cursors.WaitCursor;

            int releasedCount = 0;
            int emailSentCount = 0;
            int notifSentCount = 0;

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction tr = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (var payment in payments)
                            {
                                string updateQuery = @"UPDATE payments 
                                                     SET status = 'Released', 
                                                         release_date = CURDATE(),
                                                         updated_at = NOW()
                                                     WHERE id = @pid AND status = 'Processed'";

                                MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn, tr);
                                cmdUpdate.Parameters.AddWithValue("@pid", payment.PaymentId);
                                int rowsAffected = cmdUpdate.ExecuteNonQuery();
                                if (rowsAffected > 0) releasedCount++;

                                string notifQuery = @"INSERT INTO notifications 
                                    (sender_id, recipient_id, title, message, notification_type, is_read)
                                    VALUES (@sid, @rid, @title, @msg, 'Update', 0)";

                                MySqlCommand cmdNotif = new MySqlCommand(notifQuery, conn, tr);
                                cmdNotif.Parameters.AddWithValue("@sid", SessionManager.CurrentUser?.Id ?? 1);
                                cmdNotif.Parameters.AddWithValue("@rid", payment.ScholarId);
                                cmdNotif.Parameters.AddWithValue("@title", "🎉 Payment Released!");
                                cmdNotif.Parameters.AddWithValue("@msg",
                                    $"Great news, {payment.ScholarName}!\n\n" +
                                    $"Your stipend for {payment.Period} has been RELEASED.\n" +
                                    $"Amount: ₱{payment.Amount:N2}\n" +
                                    $"Method: {payment.PaymentMethod}\n" +
                                    $"Reference: {payment.ReferenceNumber}\n\n" +
                                    $"The funds should reflect in your account within 1-3 business days.");
                                cmdNotif.ExecuteNonQuery();
                                notifSentCount++;
                            }

                            tr.Commit();

                            foreach (var payment in payments)
                            {
                                if (!string.IsNullOrEmpty(payment.Email))
                                {
                                    bool emailResult = SendReleaseEmail(payment);
                                    if (emailResult) emailSentCount++;
                                }
                            }

                            ActivityLogger.LogCreate("payments", 0,
                                $"Released {releasedCount} payments. Total: ₱{payments.Sum(p => p.Amount):N2}");

                            string resultMsg = $"✅ PAYMENTS RELEASED SUCCESSFULLY!\n\n" +
                                              $"🔓 Released: {releasedCount} payments\n" +
                                              $"📧 Emails: {emailSentCount} sent\n" +
                                              $"🔔 Notifications: {notifSentCount} sent\n\n" +
                                              $"Scholars have been notified of their released stipends.";

                            MessageBox.Show(resultMsg, "Release Complete",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadScholarsGrid();
                            LoadStatistics();
                            LoadDisbursementHistory(); // NEW: Refresh history after release
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            throw new Exception($"Release failed: {ex.Message}", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error releasing payments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool SendReleaseEmail(PaymentRelease payment)
        {
            if (!ENABLE_EMAIL_NOTIFICATIONS) return false;

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SENDER_EMAIL, SENDER_NAME);
                    mail.To.Add(new MailAddress(payment.Email, payment.ScholarName));
                    mail.Subject = $"🎉 ScholarAid - Payment Released! - {payment.Period}";
                    mail.IsBodyHtml = true;

                    mail.Body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: 'Century Gothic', Arial, sans-serif; background: #f4f6f8; padding: 20px; }}
        .container {{ max-width: 550px; margin: 0 auto; background: white; border-radius: 12px; overflow: hidden; }}
        .header {{ background: linear-gradient(135deg, #28a745, #20c997); padding: 25px; text-align: center; color: white; }}
        .content {{ padding: 25px; }}
        .amount {{ font-size: 28px; color: #28a745; font-weight: bold; text-align: center; margin: 15px 0; }}
        .details {{ background: #f8f9fa; border-radius: 8px; padding: 15px; margin: 15px 0; }}
        .row {{ display: flex; justify-content: space-between; padding: 6px 0; }}
        .label {{ color: #666; }}
        .value {{ color: #333; font-weight: 600; }}
        .footer {{ background: #f8f9fa; padding: 15px; text-align: center; color: #999; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h2>🎉 Payment Released!</h2>
            <p style='opacity:0.9;'>Your stipend is now available</p>
        </div>
        <div class='content'>
            <p>Dear <strong>{payment.ScholarName}</strong>,</p>
            <p>Great news! Your stipend has been <strong>RELEASED</strong>!</p>
            <div class='amount'>₱{payment.Amount:N2}</div>
            <div class='details'>
                <div class='row'><span class='label'>Scholar Number:</span><span class='value'>{payment.ScholarNumber}</span></div>
                <div class='row'><span class='label'>Period:</span><span class='value'>{payment.Period}</span></div>
                <div class='row'><span class='label'>Method:</span><span class='value'>{payment.PaymentMethod}</span></div>
                <div class='row'><span class='label'>Reference:</span><span class='value'>{payment.ReferenceNumber}</span></div>
                <div class='row'><span class='label'>Release Date:</span><span class='value'>{DateTime.Now:MMM dd, yyyy}</span></div>
            </div>
            <p>Funds should reflect in your account within <strong>1-3 business days</strong>.</p>
            <p>Thank you for being a ScholarAid scholar!</p>
        </div>
        <div class='footer'>
            <p>© {DateTime.Now.Year} ScholarAid - Legacy College of Compostela</p>
        </div>
    </div>
</body>
</html>";

                    using (SmtpClient smtp = new SmtpClient(SMTP_HOST, SMTP_PORT))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);
                        smtp.Timeout = 30000;
                        smtp.Send(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Release Email Error: {ex.Message}");
                return false;
            }
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
                        int scholarId = Convert.ToInt32(dgvScholars.Rows[i].Tag);
                        var scholar = _scholars.FirstOrDefault(s => s.Id == scholarId);
                        if (scholar != null && scholar.IsEligible && scholar.PaymentStatus != "Already Paid")
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
                        int scholarId = Convert.ToInt32(dgvScholars.Rows[i].Tag);
                        var scholar = _scholars.FirstOrDefault(s => s.Id == scholarId);
                        if (scholar != null && scholar.IsEligible && scholar.PaymentStatus != "Already Paid")
                            selected.Add(scholar);
                    }
                }
            }
            catch { }
            return selected;
        }

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
                            int successCount = 0;

                            foreach (var scholar in scholars)
                            {
                                if (!IsScholarEligible(scholar.Id))
                                {
                                    System.Diagnostics.Debug.WriteLine($"Scholar {scholar.FullName} (ID:{scholar.Id}) not eligible - skipping");
                                    continue;
                                }

                                string dbMethod;
                                switch (method.ToLower())
                                {
                                    case "bank transfer": dbMethod = "Bank Transfer"; break;
                                    case "cheque": dbMethod = "Cheque"; break;
                                    case "cash": dbMethod = "Cash"; break;
                                    default: dbMethod = "Bank Transfer"; break;
                                }

                                string referenceNumber = $"PAY-{DateTime.Now:yyyyMMdd}-{scholar.Id:D4}-{DateTime.Now:HHmmssfff}";
                                DateTime releaseDate = CalculateReleaseDate(DateTime.Now.AddDays(3));

                                string insertQuery = @"INSERT INTO payments 
                                    (scholar_id, payment_period, amount, computation_date, release_date, 
                                     status, payment_method, reference_number, processed_by, remarks) 
                                    VALUES (@scholarId, @period, @amount, CURDATE(), @releaseDate, 
                                            'Processed', @method, @referenceNumber, @processedBy, @remarks)";

                                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn, transaction);
                                insertCmd.Parameters.AddWithValue("@scholarId", scholar.Id);
                                insertCmd.Parameters.AddWithValue("@period", period);
                                insertCmd.Parameters.AddWithValue("@amount", scholar.StipendAmount);
                                insertCmd.Parameters.AddWithValue("@releaseDate", releaseDate.ToString("yyyy-MM-dd"));
                                insertCmd.Parameters.AddWithValue("@method", dbMethod);
                                insertCmd.Parameters.AddWithValue("@referenceNumber", referenceNumber);
                                insertCmd.Parameters.AddWithValue("@processedBy", processedBy);
                                insertCmd.Parameters.AddWithValue("@remarks", $"Batch payroll for {period} via {method}. Ref: {referenceNumber}");
                                insertCmd.ExecuteNonQuery();
                                successCount++;

                                string notifQuery = @"INSERT INTO notifications 
                                    (sender_id, recipient_id, title, message, notification_type, is_read) 
                                    VALUES (@senderId, @recipientId, @title, @message, 'Update', FALSE)";
                                MySqlCommand notifCmd = new MySqlCommand(notifQuery, conn, transaction);
                                notifCmd.Parameters.AddWithValue("@senderId", processedBy);
                                notifCmd.Parameters.AddWithValue("@recipientId", scholar.Id);
                                notifCmd.Parameters.AddWithValue("@title", "Payment Processed");
                                notifCmd.Parameters.AddWithValue("@message",
                                    $"Your stipend for {period} has been processed.\n" +
                                    $"Amount: ₱{scholar.StipendAmount:N2}\n" +
                                    $"Reference: {referenceNumber}\n" +
                                    $"Expected Release: {releaseDate:MMM dd, yyyy}\n" +
                                    $"Payment Method: {method}");
                                notifCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            ActivityLogger.LogCreate("payments", 0,
                                $"Processed payroll for {successCount} scholars. Period: {period}, Total: ₱{_totalAmount:N2}");

                            MessageBox.Show($"✅ PAYROLL PROCESSED SUCCESSFULLY!\n\n" +
                                           $"📅 Period: {period}\n💳 Method: {method}\n" +
                                           $"✅ Processed: {successCount} scholars\n" +
                                           $"💰 Total: ₱{_totalAmount:N2}\n\n" +
                                           $"📧 Sending notifications...",
                                           "Payroll Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            foreach (var scholar in scholars)
                            {
                                string scholarEmail = GetScholarEmailFromDB(scholar.Id);
                                string scholarPhone = GetScholarPhoneFromDB(scholar.Id);

                                if (!string.IsNullOrEmpty(scholarEmail))
                                {
                                    string refNum = GetPaymentReference(scholar.Id, period);
                                    DateTime relDate = GetPaymentReleaseDate(scholar.Id, period);

                                    bool emailResult = SendPaymentEmail(scholarEmail, scholar.FullName, period,
                                        scholar.StipendAmount, method, scholar.ScholarNumber, refNum, relDate);
                                    if (emailResult) emailSentCount++; else emailFailedCount++;
                                }

                                if (!string.IsNullOrEmpty(scholarPhone))
                                {
                                    bool smsResult = SendPaymentSMS(scholarPhone, scholar.FullName, period, scholar.StipendAmount);
                                    if (smsResult) smsSentCount++; else smsFailedCount++;
                                }
                            }

                            if (emailSentCount > 0 || smsSentCount > 0)
                            {
                                MessageBox.Show($"📧 Notifications Sent:\n✅ Emails: {emailSentCount}\n❌ Failed: {emailFailedCount}\n\n" +
                                               $"📱 SMS: ✅ {smsSentCount}\n❌ Failed: {smsFailedCount}",
                                               "Notification Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            LoadScholarsGrid();
                            LoadStatistics();
                            LoadDisbursementHistory(); // NEW: Refresh history after processing
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Transaction failed: {ex.Message}", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool IsScholarEligible(int scholarId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            CASE 
                                WHEN COUNT(*) = 0 THEN 'No Records'
                                WHEN SUM(CASE WHEN status = 'Approved' THEN 1 ELSE 0 END) = COUNT(*) THEN 'Complete'
                                WHEN SUM(CASE WHEN status IN ('Pending', 'Overdue', 'Submitted') THEN 1 ELSE 0 END) > 0 THEN 'Incomplete'
                                ELSE 'Unknown'
                            END AS compliance_status
                        FROM compliance_records 
                        WHERE scholar_id = @sid";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sid", scholarId);
                    string status = cmd.ExecuteScalar()?.ToString() ?? "No Records";

                    string stipendQuery = "SELECT stipend_amount FROM scholars s LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id WHERE s.id = @sid";
                    MySqlCommand stipendCmd = new MySqlCommand(stipendQuery, conn);
                    stipendCmd.Parameters.AddWithValue("@sid", scholarId);
                    decimal stipend = stipendCmd.ExecuteScalar() != DBNull.Value ? Convert.ToDecimal(stipendCmd.ExecuteScalar()) : 0;

                    // Also check if already paid for current period
                    string paymentCheck = @"SELECT COUNT(*) FROM payments 
                                           WHERE scholar_id = @sid 
                                           AND payment_period = @period 
                                           AND status IN ('Released', 'Processed')";
                    MySqlCommand paymentCmd = new MySqlCommand(paymentCheck, conn);
                    paymentCmd.Parameters.AddWithValue("@sid", scholarId);
                    paymentCmd.Parameters.AddWithValue("@period", dtpPaymentPeriod.Value.ToString("MMMM yyyy"));
                    int existingPayments = Convert.ToInt32(paymentCmd.ExecuteScalar());

                    return status == "Complete" && stipend > 0 && existingPayments == 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error checking eligibility: {ex.Message}");
                return false;
            }
        }

        private DateTime CalculateReleaseDate(DateTime date)
        {
            while (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
            }
            return date;
        }

        private string GetPaymentReference(int scholarId, string period)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "SELECT reference_number FROM payments WHERE scholar_id = @sid AND payment_period = @period ORDER BY created_at DESC LIMIT 1", conn);
                    cmd.Parameters.AddWithValue("@sid", scholarId);
                    cmd.Parameters.AddWithValue("@period", period);
                    return cmd.ExecuteScalar()?.ToString() ?? "N/A";
                }
            }
            catch { return "N/A"; }
        }

        private DateTime GetPaymentReleaseDate(int scholarId, string period)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "SELECT release_date FROM payments WHERE scholar_id = @sid AND payment_period = @period ORDER BY created_at DESC LIMIT 1", conn);
                    cmd.Parameters.AddWithValue("@sid", scholarId);
                    cmd.Parameters.AddWithValue("@period", period);
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value && result != null ? Convert.ToDateTime(result) : DateTime.Now.AddDays(3);
                }
            }
            catch { return DateTime.Now.AddDays(3); }
        }

        private string GetScholarEmailFromDB(int scholarId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT email FROM scholars WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", scholarId);
                    return cmd.ExecuteScalar()?.ToString() ?? "";
                }
            }
            catch { return ""; }
        }

        private string GetScholarPhoneFromDB(int scholarId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT contact_number FROM scholars WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", scholarId);
                    return cmd.ExecuteScalar()?.ToString() ?? "";
                }
            }
            catch { return ""; }
        }

        private bool SendPaymentEmail(string toEmail, string scholarName, string period, decimal amount, string method, string scholarNumber, string referenceNumber, DateTime releaseDate)
        {
            if (!ENABLE_EMAIL_NOTIFICATIONS) return false;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SENDER_EMAIL, SENDER_NAME);
                    mail.To.Add(new MailAddress(toEmail, scholarName));
                    mail.Subject = $"ScholarAid - Payment Processed - {period} - {scholarName}";
                    mail.IsBodyHtml = true;

                    mail.Body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: 'Century Gothic', Arial, sans-serif; background-color: #f4f6f8; margin: 0; padding: 20px; }}
        .container {{ max-width: 600px; margin: 0 auto; background: white; border-radius: 12px; box-shadow: 0 4px 6px rgba(0,0,0,0.1); overflow: hidden; }}
        .header {{ background: linear-gradient(135deg, #00444F, #006875); padding: 25px; text-align: center; color: white; }}
        .content {{ padding: 25px; }}
        .details {{ background: #f8f9fa; border-radius: 8px; padding: 15px; margin: 15px 0; }}
        .amount {{ font-size: 24px; color: #00444F; font-weight: bold; text-align: center; margin: 15px 0; }}
        .footer {{ background: #f8f9fa; padding: 15px; text-align: center; color: #999; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'><h2>📋 Payment Processed</h2></div>
        <div class='content'>
            <p>Dear <strong>{scholarName}</strong>,</p>
            <p>Your stipend has been <strong>processed</strong>!</p>
            <div class='amount'>₱{amount:N2}</div>
            <div class='details'>
                <p><strong>Scholar:</strong> {scholarNumber}</p>
                <p><strong>Period:</strong> {period}</p>
                <p><strong>Method:</strong> {method}</p>
                <p><strong>Reference:</strong> {referenceNumber}</p>
                <p><strong>Expected Release:</strong> {releaseDate:MMM dd, yyyy}</p>
            </div>
            <p>Release within <strong>3-5 business days</strong>.</p>
        </div>
        <div class='footer'><p>© {DateTime.Now.Year} ScholarAid</p></div>
    </div>
</body>
</html>";

                    using (SmtpClient smtp = new SmtpClient(SMTP_HOST, SMTP_PORT))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);
                        smtp.Timeout = 30000;
                        smtp.Send(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Email Error: {ex.Message}");
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
                    SendSMSEmailGateway(smsGateway, smsMessage);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SMS Error: {ex.Message}");
                return false;
            }
        }

        private string GetSMSGateway(string phone)
        {
            phone = phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("+", "");
            if (phone.StartsWith("63")) phone = "0" + phone.Substring(2);

            if (phone.StartsWith("0915") || phone.StartsWith("0916") || phone.StartsWith("0917") ||
                phone.StartsWith("0926") || phone.StartsWith("0927") || phone.StartsWith("0935") ||
                phone.StartsWith("0936") || phone.StartsWith("0937") || phone.StartsWith("0994") ||
                phone.StartsWith("0995") || phone.StartsWith("0996") || phone.StartsWith("0997") ||
                phone.StartsWith("0817") || phone.StartsWith("0905") || phone.StartsWith("0906"))
                return phone + "@txt.globe.com.ph";

            return phone + "@txt.smart.com.ph";
        }

        private bool SendSMSEmailGateway(string smsGateway, string message)
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SMS Gateway Error: {ex.Message}");
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
                new Login().Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion
    }

    // ============================================
    // DATA CLASSES
    // ============================================
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
        public int ScholarshipTypeId { get; set; }
        public decimal StipendAmount { get; set; }
        public string ComplianceStatus { get; set; }
        public string PaymentStatus { get; set; } // NEW: "Already Paid" or "Not Paid"
        public bool IsEligible { get; set; }
    }

    public class PaymentRelease
    {
        public int PaymentId { get; set; }
        public int ScholarId { get; set; }
        public string ScholarName { get; set; }
        public string ScholarNumber { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Period { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; }
        public string Status { get; set; }
    }

    public class ComboItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}