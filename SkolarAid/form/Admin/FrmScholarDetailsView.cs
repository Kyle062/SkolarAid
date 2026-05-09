using MySql.Data.MySqlClient;
using SkolarAid.Data;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SkolarAid.form.Admin
{
    public partial class FrmScholarDetailsView : Form
    {
        private int _scholarId;

        public FrmScholarDetailsView(int scholarId)
        {
            _scholarId = scholarId;
            InitializeComponent();
            this.Load += FrmScholarDetailsView_Load;
        }

        private void FrmScholarDetailsView_Load(object sender, EventArgs e)
        {
            LoadScholarDetails();
            LoadComplianceSummary();
        }

        private void LoadScholarDetails()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT s.*, st.name as scholarship_name,
                                    (SELECT COUNT(*) FROM payments WHERE scholar_id = s.id) as payment_count,
                                    (SELECT COALESCE(SUM(amount), 0) FROM payments WHERE scholar_id = s.id AND status = 'Released') as total_received,
                                    (SELECT COUNT(*) FROM compliance_records WHERE scholar_id = s.id AND status IN ('Pending', 'Overdue')) as pending_compliance,
                                    (SELECT COUNT(*) FROM compliance_records WHERE scholar_id = s.id AND status = 'Approved') as approved_compliance,
                                    (SELECT COUNT(*) FROM compliance_records WHERE scholar_id = s.id) as total_compliance
                                    FROM scholars s
                                    LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                                    WHERE s.id = @scholarId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", _scholarId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string middleName = reader["middle_name"]?.ToString();
                            string fullName = reader["first_name"] + (string.IsNullOrEmpty(middleName) ? " " : " " + middleName + " ") + reader["last_name"];
                            lblScholarName.Text = fullName;
                            lblScholarNumber.Text = $"Scholar #: {reader["scholar_number"]}";
                            lblStudentID.Text = $"Student ID: {reader["student_id"]}";

                            string status = reader["status"]?.ToString() ?? "Active";
                            lblStatus.Text = status;
                            switch (status)
                            {
                                case "Active":
                                    lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
                                    panelStatusBadge.BackColor = Color.FromArgb(212, 237, 218);
                                    break;
                                case "Inactive":
                                    lblStatus.ForeColor = Color.FromArgb(255, 170, 0);
                                    panelStatusBadge.BackColor = Color.FromArgb(255, 243, 205);
                                    break;
                                case "Probation":
                                    lblStatus.ForeColor = Color.FromArgb(255, 193, 7);
                                    panelStatusBadge.BackColor = Color.FromArgb(255, 248, 225);
                                    break;
                                case "Suspended":
                                    lblStatus.ForeColor = Color.FromArgb(220, 53, 69);
                                    panelStatusBadge.BackColor = Color.FromArgb(248, 215, 218);
                                    break;
                                case "Graduated":
                                    lblStatus.ForeColor = Color.FromArgb(0, 123, 255);
                                    panelStatusBadge.BackColor = Color.FromArgb(204, 229, 255);
                                    break;
                                case "Terminated":
                                case "Expelled":
                                    lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                                    panelStatusBadge.BackColor = Color.FromArgb(248, 215, 218);
                                    break;
                                case "Withdrawn":
                                case "Dropped":
                                    lblStatus.ForeColor = Color.FromArgb(108, 117, 125);
                                    panelStatusBadge.BackColor = Color.FromArgb(233, 236, 239);
                                    break;
                                case "Completed":
                                    lblStatus.ForeColor = Color.FromArgb(72, 199, 142);
                                    panelStatusBadge.BackColor = Color.FromArgb(220, 248, 235);
                                    break;
                                default:
                                    lblStatus.ForeColor = Color.FromArgb(80, 80, 80);
                                    panelStatusBadge.BackColor = Color.FromArgb(230, 230, 230);
                                    break;
                            }

                            lblFirstNameValue.Text = reader["first_name"]?.ToString() ?? "N/A";
                            lblMiddleNameValue.Text = reader["middle_name"]?.ToString() ?? "N/A";
                            lblLastNameValue.Text = reader["last_name"]?.ToString() ?? "N/A";
                            lblEmailValue.Text = reader["email"]?.ToString() ?? "N/A";
                            lblContactValue.Text = reader["contact_number"]?.ToString() ?? "N/A";
                            lblGenderValue.Text = reader["gender"]?.ToString() ?? "N/A";
                            lblDOBValue.Text = reader["date_of_birth"] != DBNull.Value ?
                                Convert.ToDateTime(reader["date_of_birth"]).ToString("MMMM dd, yyyy") : "N/A";
                            lblAddressValue.Text = reader["address"]?.ToString() ?? "N/A";

                            lblCourseValue.Text = reader["course"]?.ToString() ?? "N/A";
                            lblYearLevelValue.Text = reader["year_level"]?.ToString() ?? "N/A";
                            lblHEIValue.Text = reader["hei"]?.ToString() ?? "Legacy College of Compostela";
                            lblDegreeProgramValue.Text = reader["degree_program"]?.ToString() ?? "N/A";

                            lblScholarshipTypeValue.Text = reader["scholarship_name"]?.ToString() ?? "N/A";
                            lblStipendAmountValue.Text = reader["stipend_amount"] != DBNull.Value ?
                                $"₱{Convert.ToDecimal(reader["stipend_amount"]):N2}" : "₱0.00";
                            lblStipendFrequencyValue.Text = reader["stipend_frequency"]?.ToString() ?? "Monthly";
                            lblFundSourceValue.Text = reader["scholarship_fund_source"]?.ToString() ?? "N/A";
                            lblRenewalConditionsValue.Text = reader["renewal_conditions"]?.ToString() ?? "N/A";
                            lblBankNameValue.Text = reader["bank_name"]?.ToString() ?? "N/A";
                            lblBankAccountValue.Text = reader["bank_account_number"]?.ToString() ?? "N/A";
                            lblEnrollmentDateValue.Text = reader["enrollment_date"] != DBNull.Value ?
                                Convert.ToDateTime(reader["enrollment_date"]).ToString("MMMM dd, yyyy") : "N/A";
                            lblExpectedGradValue.Text = reader["expected_graduation"] != DBNull.Value ?
                                Convert.ToDateTime(reader["expected_graduation"]).ToString("MMMM dd, yyyy") : "N/A";

                            lblPaymentCount.Text = reader["payment_count"]?.ToString() ?? "0";
                            lblTotalReceived.Text = $"₱{Convert.ToDecimal(reader["total_received"]):N2}";
                            lblPendingCompliance.Text = reader["pending_compliance"]?.ToString() ?? "0";
                            lblApprovedCompliance.Text = reader["approved_compliance"]?.ToString() ?? "0";
                            lblTotalCompliance.Text = reader["total_compliance"]?.ToString() ?? "0";
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

        private void LoadComplianceSummary()
        {
            try
            {
                dgvCompliance.Rows.Clear();

                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT cr.id, cr.requirement_type, cr.description, cr.status, 
                                    cr.due_date, cr.date_submitted, cr.remarks,
                                    (SELECT COUNT(*) FROM file_attachments fa WHERE fa.compliance_id = cr.id) as file_count
                                    FROM compliance_records cr
                                    WHERE cr.scholar_id = @scholarId
                                    ORDER BY FIELD(cr.requirement_type, 
                                        'PSA Birth Certificate', 'COE (Current Sem)', 'COR', 
                                        'Latest Grades', 'Scholarship Contract'), cr.due_date DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", _scholarId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int rowIndex = dgvCompliance.Rows.Add();
                            // Use index-based access since columns are added dynamically
                            dgvCompliance.Rows[rowIndex].Cells[0].Value = reader["requirement_type"]?.ToString();
                            dgvCompliance.Rows[rowIndex].Cells[1].Value = reader["description"]?.ToString();
                            dgvCompliance.Rows[rowIndex].Cells[2].Value = reader["status"]?.ToString();
                            dgvCompliance.Rows[rowIndex].Cells[3].Value = reader["due_date"] != DBNull.Value ?
                                Convert.ToDateTime(reader["due_date"]).ToString("yyyy-MM-dd") : "N/A";
                            dgvCompliance.Rows[rowIndex].Cells[4].Value = reader["date_submitted"] != DBNull.Value ?
                                Convert.ToDateTime(reader["date_submitted"]).ToString("yyyy-MM-dd") : "";
                            dgvCompliance.Rows[rowIndex].Cells[5].Value = reader["remarks"]?.ToString() ?? "";
                            dgvCompliance.Rows[rowIndex].Cells[6].Value = Convert.ToInt32(reader["file_count"]) > 0 ? "📎" : "";

                            string status = reader["status"]?.ToString();
                            var statusCell = dgvCompliance.Rows[rowIndex].Cells[2];
                            switch (status)
                            {
                                case "Approved":
                                    statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                                    dgvCompliance.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
                                    break;
                                case "Submitted":
                                    statusCell.Style.ForeColor = Color.FromArgb(0, 123, 255);
                                    break;
                                case "Pending":
                                    statusCell.Style.ForeColor = Color.FromArgb(255, 170, 0);
                                    break;
                                case "Overdue":
                                    statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                                    dgvCompliance.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240);
                                    break;
                                case "Rejected":
                                    statusCell.Style.ForeColor = Color.FromArgb(220, 50, 50);
                                    break;
                            }
                            statusCell.Style.Font = new Font(dgvCompliance.Font, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (dgvCompliance.Columns.Count > 0)
                {
                    dgvCompliance.Rows.Add();
                    dgvCompliance.Rows[0].Cells[0].Value = $"Error: {ex.Message}";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblScholarName = new System.Windows.Forms.Label();
            this.lblScholarNumber = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.panelStatusBadge = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPersonal = new System.Windows.Forms.TabPage();
            this.tabAcademic = new System.Windows.Forms.TabPage();
            this.tabScholarship = new System.Windows.Forms.TabPage();
            this.tabBank = new System.Windows.Forms.TabPage();
            this.tabComplianceTab = new System.Windows.Forms.TabPage();
            this.tabSummary = new System.Windows.Forms.TabPage();

            // Compliance DataGridView - create columns directly without class-level fields
            this.dgvCompliance = new System.Windows.Forms.DataGridView();
            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "Requirement"; col0.FillWeight = 18;
            col1.HeaderText = "Description"; col1.FillWeight = 22;
            col2.HeaderText = "Status"; col2.FillWeight = 12;
            col3.HeaderText = "Due Date"; col3.FillWeight = 13;
            col4.HeaderText = "Submitted"; col4.FillWeight = 13;
            col5.HeaderText = "Remarks"; col5.FillWeight = 17;
            col6.HeaderText = "File"; col6.FillWeight = 5;

            // Personal Info Labels
            this.lblFirstNameLabel = new System.Windows.Forms.Label();
            this.lblFirstNameValue = new System.Windows.Forms.Label();
            this.lblMiddleNameLabel = new System.Windows.Forms.Label();
            this.lblMiddleNameValue = new System.Windows.Forms.Label();
            this.lblLastNameLabel = new System.Windows.Forms.Label();
            this.lblLastNameValue = new System.Windows.Forms.Label();
            this.lblEmailLabel = new System.Windows.Forms.Label();
            this.lblEmailValue = new System.Windows.Forms.Label();
            this.lblContactLabel = new System.Windows.Forms.Label();
            this.lblContactValue = new System.Windows.Forms.Label();
            this.lblGenderLabel = new System.Windows.Forms.Label();
            this.lblGenderValue = new System.Windows.Forms.Label();
            this.lblDOBLabel = new System.Windows.Forms.Label();
            this.lblDOBValue = new System.Windows.Forms.Label();
            this.lblAddressLabel = new System.Windows.Forms.Label();
            this.lblAddressValue = new System.Windows.Forms.Label();

            // Academic Info Labels
            this.lblCourseLabel = new System.Windows.Forms.Label();
            this.lblCourseValue = new System.Windows.Forms.Label();
            this.lblYearLevelLabel = new System.Windows.Forms.Label();
            this.lblYearLevelValue = new System.Windows.Forms.Label();
            this.lblHEILabel = new System.Windows.Forms.Label();
            this.lblHEIValue = new System.Windows.Forms.Label();
            this.lblDegreeProgramLabel = new System.Windows.Forms.Label();
            this.lblDegreeProgramValue = new System.Windows.Forms.Label();

            // Scholarship Info Labels
            this.lblScholarshipTypeLabel = new System.Windows.Forms.Label();
            this.lblScholarshipTypeValue = new System.Windows.Forms.Label();
            this.lblStipendAmountLabel = new System.Windows.Forms.Label();
            this.lblStipendAmountValue = new System.Windows.Forms.Label();
            this.lblStipendFrequencyLabel = new System.Windows.Forms.Label();
            this.lblStipendFrequencyValue = new System.Windows.Forms.Label();
            this.lblFundSourceLabel = new System.Windows.Forms.Label();
            this.lblFundSourceValue = new System.Windows.Forms.Label();
            this.lblRenewalConditionsLabel = new System.Windows.Forms.Label();
            this.lblRenewalConditionsValue = new System.Windows.Forms.Label();
            this.lblEnrollmentDateLabel = new System.Windows.Forms.Label();
            this.lblEnrollmentDateValue = new System.Windows.Forms.Label();
            this.lblExpectedGradLabel = new System.Windows.Forms.Label();
            this.lblExpectedGradValue = new System.Windows.Forms.Label();

            // Bank Info Labels
            this.lblBankNameLabel = new System.Windows.Forms.Label();
            this.lblBankNameValue = new System.Windows.Forms.Label();
            this.lblBankAccountLabel = new System.Windows.Forms.Label();
            this.lblBankAccountValue = new System.Windows.Forms.Label();

            // Summary Panels
            this.panelPaymentStats = new System.Windows.Forms.Panel();
            this.lblPaymentCountLabel = new System.Windows.Forms.Label();
            this.lblPaymentCount = new System.Windows.Forms.Label();
            this.panelTotalReceived = new System.Windows.Forms.Panel();
            this.lblTotalReceivedLabel = new System.Windows.Forms.Label();
            this.lblTotalReceived = new System.Windows.Forms.Label();
            this.panelPendingCompliance = new System.Windows.Forms.Panel();
            this.lblPendingComplianceLabel = new System.Windows.Forms.Label();
            this.lblPendingCompliance = new System.Windows.Forms.Label();
            this.panelApprovedCompliance = new System.Windows.Forms.Panel();
            this.lblApprovedComplianceLabel = new System.Windows.Forms.Label();
            this.lblApprovedCompliance = new System.Windows.Forms.Label();
            this.panelTotalCompliance = new System.Windows.Forms.Panel();
            this.lblTotalComplianceLabel = new System.Windows.Forms.Label();
            this.lblTotalCompliance = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ========== FORM CONFIGURATION ==========
            this.ClientSize = new Size(800, 620);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Scholar Details";
            this.BackColor = Color.White;

            // ========== HEADER PANEL ==========
            this.panelHeader = new Panel();
            this.panelHeader.BackColor = Color.FromArgb(0, 68, 79);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Size = new Size(800, 100);

            this.lblScholarName = new Label();
            this.lblScholarName.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            this.lblScholarName.ForeColor = Color.White;
            this.lblScholarName.Location = new Point(25, 15);
            this.lblScholarName.Size = new Size(550, 30);

            this.lblScholarNumber = new Label();
            this.lblScholarNumber.Font = new Font("Century Gothic", 10F);
            this.lblScholarNumber.ForeColor = Color.FromArgb(200, 200, 200);
            this.lblScholarNumber.Location = new Point(25, 48);
            this.lblScholarNumber.Size = new Size(300, 20);

            this.lblStudentID = new Label();
            this.lblStudentID.Font = new Font("Century Gothic", 10F);
            this.lblStudentID.ForeColor = Color.FromArgb(200, 200, 200);
            this.lblStudentID.Location = new Point(25, 70);
            this.lblStudentID.Size = new Size(300, 20);

            this.panelStatusBadge = new Panel();
            this.panelStatusBadge.Location = new Point(650, 30);
            this.panelStatusBadge.Size = new Size(120, 35);
            this.panelStatusBadge.BackColor = Color.FromArgb(212, 237, 218);

            this.lblStatus = new Label();
            this.lblStatus.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            this.lblStatus.Dock = DockStyle.Fill;
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            this.lblStatus.Text = "Active";
            this.panelStatusBadge.Controls.Add(lblStatus);

            this.btnClose = new Button();
            this.btnClose.Text = "✕";
            this.btnClose.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.ForeColor = Color.White;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.Location = new Point(760, 10);
            this.btnClose.Size = new Size(30, 30);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.btnClose.Cursor = Cursors.Hand;

            this.panelHeader.Controls.Add(lblScholarName);
            this.panelHeader.Controls.Add(lblScholarNumber);
            this.panelHeader.Controls.Add(lblStudentID);
            this.panelHeader.Controls.Add(panelStatusBadge);
            this.panelHeader.Controls.Add(btnClose);

            // ========== TAB CONTROL ==========
            this.tabControl = new TabControl();
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new Font("Century Gothic", 11F);

            // ---- Tab: Personal Info ----
            this.tabPersonal = new TabPage();
            this.tabPersonal.Text = "Personal Info";
            this.tabPersonal.BackColor = Color.White;
            AddLabelPair(tabPersonal, lblFirstNameLabel, "First Name:", lblFirstNameValue, 20, 15);
            AddLabelPair(tabPersonal, lblMiddleNameLabel, "Middle Name:", lblMiddleNameValue, 310, 15);
            AddLabelPair(tabPersonal, lblLastNameLabel, "Last Name:", lblLastNameValue, 20, 70);
            AddLabelPair(tabPersonal, lblEmailLabel, "Email:", lblEmailValue, 310, 70);
            AddLabelPair(tabPersonal, lblContactLabel, "Contact Number:", lblContactValue, 20, 125);
            AddLabelPair(tabPersonal, lblGenderLabel, "Gender:", lblGenderValue, 310, 125);
            AddLabelPair(tabPersonal, lblDOBLabel, "Date of Birth:", lblDOBValue, 20, 180);
            AddLabelPair(tabPersonal, lblAddressLabel, "Address:", lblAddressValue, 20, 230);

            // ---- Tab: Academic Info ----
            this.tabAcademic = new TabPage();
            this.tabAcademic.Text = "Academic Info";
            this.tabAcademic.BackColor = Color.White;
            AddLabelPair(tabAcademic, lblCourseLabel, "Course:", lblCourseValue, 20, 15);
            AddLabelPair(tabAcademic, lblYearLevelLabel, "Year Level:", lblYearLevelValue, 310, 15);
            AddLabelPair(tabAcademic, lblHEILabel, "Institution:", lblHEIValue, 20, 70);
            AddLabelPair(tabAcademic, lblDegreeProgramLabel, "Degree Program:", lblDegreeProgramValue, 20, 120);

            // ---- Tab: Scholarship Info ----
            this.tabScholarship = new TabPage();
            this.tabScholarship.Text = "Scholarship";
            this.tabScholarship.BackColor = Color.White;
            AddLabelPair(tabScholarship, lblScholarshipTypeLabel, "Scholarship Type:", lblScholarshipTypeValue, 20, 15);
            AddLabelPair(tabScholarship, lblStipendAmountLabel, "Stipend Amount:", lblStipendAmountValue, 310, 15);
            AddLabelPair(tabScholarship, lblStipendFrequencyLabel, "Stipend Frequency:", lblStipendFrequencyValue, 20, 70);
            AddLabelPair(tabScholarship, lblFundSourceLabel, "Fund Source:", lblFundSourceValue, 310, 70);
            AddLabelPair(tabScholarship, lblRenewalConditionsLabel, "Renewal Conditions:", lblRenewalConditionsValue, 20, 125);
            AddLabelPair(tabScholarship, lblEnrollmentDateLabel, "Enrollment Date:", lblEnrollmentDateValue, 20, 180);
            AddLabelPair(tabScholarship, lblExpectedGradLabel, "Expected Graduation:", lblExpectedGradValue, 310, 180);

            // ---- Tab: Bank Info ----
            this.tabBank = new TabPage();
            this.tabBank.Text = "Bank Details";
            this.tabBank.BackColor = Color.White;
            AddLabelPair(tabBank, lblBankNameLabel, "Bank Name:", lblBankNameValue, 20, 15);
            AddLabelPair(tabBank, lblBankAccountLabel, "Account Number:", lblBankAccountValue, 20, 70);

            // ---- Tab: Compliance Records ----
            this.tabComplianceTab = new TabPage();
            this.tabComplianceTab.Text = "Compliance";
            this.tabComplianceTab.BackColor = Color.White;

            this.dgvCompliance = new DataGridView();
            this.dgvCompliance.AllowUserToAddRows = false;
            this.dgvCompliance.AllowUserToDeleteRows = false;
            this.dgvCompliance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompliance.BackgroundColor = Color.White;
            this.dgvCompliance.BorderStyle = BorderStyle.None;
            this.dgvCompliance.ColumnHeadersHeight = 38;
            this.dgvCompliance.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 68, 79),
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            this.dgvCompliance.EnableHeadersVisualStyles = false;
            this.dgvCompliance.GridColor = Color.FromArgb(230, 230, 230);
            this.dgvCompliance.Location = new Point(15, 15);
            this.dgvCompliance.Size = new Size(755, 430);
            this.dgvCompliance.MultiSelect = false;
            this.dgvCompliance.ReadOnly = true;
            this.dgvCompliance.RowHeadersVisible = false;
            this.dgvCompliance.RowTemplate.Height = 35;
            this.dgvCompliance.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10F);
            this.dgvCompliance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompliance.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2, col3, col4, col5, col6 });
            this.tabComplianceTab.Controls.Add(dgvCompliance);

            // ---- Tab: Summary ----
            this.tabSummary = new TabPage();
            this.tabSummary.Text = "Summary";
            this.tabSummary.BackColor = Color.White;

            this.panelPaymentStats = new Panel();
            this.panelPaymentStats.BackColor = Color.FromArgb(232, 245, 233);
            this.panelPaymentStats.Location = new Point(15, 15);
            this.panelPaymentStats.Size = new Size(180, 110);
            this.panelPaymentStats.BorderStyle = BorderStyle.FixedSingle;
            this.lblPaymentCountLabel = new Label();
            this.lblPaymentCountLabel.Text = "Total Payments";
            this.lblPaymentCountLabel.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            this.lblPaymentCountLabel.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblPaymentCountLabel.Location = new Point(15, 12);
            this.lblPaymentCountLabel.Size = new Size(150, 22);
            this.lblPaymentCount = new Label();
            this.lblPaymentCount.Text = "0";
            this.lblPaymentCount.Font = new Font("Century Gothic", 32F, FontStyle.Bold);
            this.lblPaymentCount.ForeColor = Color.FromArgb(0, 68, 79);
            this.lblPaymentCount.Location = new Point(15, 42);
            this.lblPaymentCount.Size = new Size(150, 55);
            this.lblPaymentCount.TextAlign = ContentAlignment.MiddleLeft;
            this.panelPaymentStats.Controls.Add(lblPaymentCountLabel);
            this.panelPaymentStats.Controls.Add(lblPaymentCount);

            this.panelTotalReceived = new Panel();
            this.panelTotalReceived.BackColor = Color.FromArgb(227, 242, 253);
            this.panelTotalReceived.Location = new Point(210, 15);
            this.panelTotalReceived.Size = new Size(180, 110);
            this.panelTotalReceived.BorderStyle = BorderStyle.FixedSingle;
            this.lblTotalReceivedLabel = new Label();
            this.lblTotalReceivedLabel.Text = "Total Received";
            this.lblTotalReceivedLabel.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            this.lblTotalReceivedLabel.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblTotalReceivedLabel.Location = new Point(15, 12);
            this.lblTotalReceivedLabel.Size = new Size(150, 22);
            this.lblTotalReceived = new Label();
            this.lblTotalReceived.Text = "₱0.00";
            this.lblTotalReceived.Font = new Font("Century Gothic", 20F, FontStyle.Bold);
            this.lblTotalReceived.ForeColor = Color.FromArgb(0, 68, 79);
            this.lblTotalReceived.Location = new Point(15, 42);
            this.lblTotalReceived.Size = new Size(150, 55);
            this.lblTotalReceived.TextAlign = ContentAlignment.MiddleLeft;
            this.panelTotalReceived.Controls.Add(lblTotalReceivedLabel);
            this.panelTotalReceived.Controls.Add(lblTotalReceived);

            this.panelPendingCompliance = new Panel();
            this.panelPendingCompliance.BackColor = Color.FromArgb(255, 243, 205);
            this.panelPendingCompliance.Location = new Point(405, 15);
            this.panelPendingCompliance.Size = new Size(180, 110);
            this.panelPendingCompliance.BorderStyle = BorderStyle.FixedSingle;
            this.lblPendingComplianceLabel = new Label();
            this.lblPendingComplianceLabel.Text = "Pending Reqs";
            this.lblPendingComplianceLabel.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            this.lblPendingComplianceLabel.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblPendingComplianceLabel.Location = new Point(15, 12);
            this.lblPendingComplianceLabel.Size = new Size(150, 22);
            this.lblPendingCompliance = new Label();
            this.lblPendingCompliance.Text = "0";
            this.lblPendingCompliance.Font = new Font("Century Gothic", 32F, FontStyle.Bold);
            this.lblPendingCompliance.ForeColor = Color.FromArgb(0, 68, 79);
            this.lblPendingCompliance.Location = new Point(15, 42);
            this.lblPendingCompliance.Size = new Size(150, 55);
            this.lblPendingCompliance.TextAlign = ContentAlignment.MiddleLeft;
            this.panelPendingCompliance.Controls.Add(lblPendingComplianceLabel);
            this.panelPendingCompliance.Controls.Add(lblPendingCompliance);

            this.panelApprovedCompliance = new Panel();
            this.panelApprovedCompliance.BackColor = Color.FromArgb(220, 248, 220);
            this.panelApprovedCompliance.Location = new Point(15, 140);
            this.panelApprovedCompliance.Size = new Size(180, 110);
            this.panelApprovedCompliance.BorderStyle = BorderStyle.FixedSingle;
            this.lblApprovedComplianceLabel = new Label();
            this.lblApprovedComplianceLabel.Text = "Approved Reqs";
            this.lblApprovedComplianceLabel.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            this.lblApprovedComplianceLabel.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblApprovedComplianceLabel.Location = new Point(15, 12);
            this.lblApprovedComplianceLabel.Size = new Size(150, 22);
            this.lblApprovedCompliance = new Label();
            this.lblApprovedCompliance.Text = "0";
            this.lblApprovedCompliance.Font = new Font("Century Gothic", 32F, FontStyle.Bold);
            this.lblApprovedCompliance.ForeColor = Color.FromArgb(0, 68, 79);
            this.lblApprovedCompliance.Location = new Point(15, 42);
            this.lblApprovedCompliance.Size = new Size(150, 55);
            this.lblApprovedCompliance.TextAlign = ContentAlignment.MiddleLeft;
            this.panelApprovedCompliance.Controls.Add(lblApprovedComplianceLabel);
            this.panelApprovedCompliance.Controls.Add(lblApprovedCompliance);

            this.panelTotalCompliance = new Panel();
            this.panelTotalCompliance.BackColor = Color.FromArgb(240, 240, 250);
            this.panelTotalCompliance.Location = new Point(210, 140);
            this.panelTotalCompliance.Size = new Size(180, 110);
            this.panelTotalCompliance.BorderStyle = BorderStyle.FixedSingle;
            this.lblTotalComplianceLabel = new Label();
            this.lblTotalComplianceLabel.Text = "Total Reqs";
            this.lblTotalComplianceLabel.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            this.lblTotalComplianceLabel.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblTotalComplianceLabel.Location = new Point(15, 12);
            this.lblTotalComplianceLabel.Size = new Size(150, 22);
            this.lblTotalCompliance = new Label();
            this.lblTotalCompliance.Text = "0";
            this.lblTotalCompliance.Font = new Font("Century Gothic", 32F, FontStyle.Bold);
            this.lblTotalCompliance.ForeColor = Color.FromArgb(0, 68, 79);
            this.lblTotalCompliance.Location = new Point(15, 42);
            this.lblTotalCompliance.Size = new Size(150, 55);
            this.lblTotalCompliance.TextAlign = ContentAlignment.MiddleLeft;
            this.panelTotalCompliance.Controls.Add(lblTotalComplianceLabel);
            this.panelTotalCompliance.Controls.Add(lblTotalCompliance);

            this.tabSummary.Controls.Add(panelPaymentStats);
            this.tabSummary.Controls.Add(panelTotalReceived);
            this.tabSummary.Controls.Add(panelPendingCompliance);
            this.tabSummary.Controls.Add(panelApprovedCompliance);
            this.tabSummary.Controls.Add(panelTotalCompliance);

            this.tabControl.TabPages.Add(tabPersonal);
            this.tabControl.TabPages.Add(tabAcademic);
            this.tabControl.TabPages.Add(tabScholarship);
            this.tabControl.TabPages.Add(tabBank);
            this.tabControl.TabPages.Add(tabComplianceTab);
            this.tabControl.TabPages.Add(tabSummary);

            this.panelContent = new Panel();
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(tabControl);

            this.Controls.Add(panelContent);
            this.Controls.Add(panelHeader);

            this.ResumeLayout(false);
        }

        private void AddLabelPair(TabPage tab, Label labelField, string labelText, Label valueField, int x, int y)
        {
            labelField.Text = labelText;
            labelField.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            labelField.ForeColor = Color.FromArgb(80, 80, 80);
            labelField.Location = new Point(x, y);
            labelField.Size = new Size(180, 20);

            valueField.Text = "N/A";
            valueField.Font = new Font("Century Gothic", 11F);
            valueField.ForeColor = Color.FromArgb(0, 68, 79);
            valueField.Location = new Point(x, y + 22);
            valueField.Size = new Size(270, 22);

            tab.Controls.Add(labelField);
            tab.Controls.Add(valueField);
        }

        // Control declarations
        private Panel panelHeader;
        private Label lblScholarName, lblScholarNumber, lblStudentID, lblStatus;
        private Panel panelStatusBadge;
        private Button btnClose;
        private Panel panelContent;
        private TabControl tabControl;
        private TabPage tabPersonal, tabAcademic, tabScholarship, tabBank, tabComplianceTab, tabSummary;
        private DataGridView dgvCompliance;

        private Label lblFirstNameLabel, lblFirstNameValue;
        private Label lblMiddleNameLabel, lblMiddleNameValue;
        private Label lblLastNameLabel, lblLastNameValue;
        private Label lblEmailLabel, lblEmailValue;
        private Label lblContactLabel, lblContactValue;
        private Label lblGenderLabel, lblGenderValue;
        private Label lblDOBLabel, lblDOBValue;
        private Label lblAddressLabel, lblAddressValue;
        private Label lblCourseLabel, lblCourseValue;
        private Label lblYearLevelLabel, lblYearLevelValue;
        private Label lblHEILabel, lblHEIValue;
        private Label lblDegreeProgramLabel, lblDegreeProgramValue;
        private Label lblScholarshipTypeLabel, lblScholarshipTypeValue;
        private Label lblStipendAmountLabel, lblStipendAmountValue;
        private Label lblStipendFrequencyLabel, lblStipendFrequencyValue;
        private Label lblFundSourceLabel, lblFundSourceValue;
        private Label lblRenewalConditionsLabel, lblRenewalConditionsValue;
        private Label lblEnrollmentDateLabel, lblEnrollmentDateValue;
        private Label lblExpectedGradLabel, lblExpectedGradValue;
        private Label lblBankNameLabel, lblBankNameValue;
        private Label lblBankAccountLabel, lblBankAccountValue;

        private Panel panelPaymentStats, panelTotalReceived, panelPendingCompliance, panelApprovedCompliance, panelTotalCompliance;
        private Label lblPaymentCountLabel, lblPaymentCount;
        private Label lblTotalReceivedLabel, lblTotalReceived;
        private Label lblPendingComplianceLabel, lblPendingCompliance;
        private Label lblApprovedComplianceLabel, lblApprovedCompliance;
        private Label lblTotalComplianceLabel, lblTotalCompliance;
    }
}