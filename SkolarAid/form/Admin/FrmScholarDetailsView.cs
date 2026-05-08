using MySql.Data.MySqlClient;
using SkolarAid.Data;
using System;
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
                                    (SELECT COUNT(*) FROM compliance_records WHERE scholar_id = s.id AND status = 'Pending') as pending_compliance
                                    FROM scholars s
                                    LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                                    WHERE s.id = @scholarId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", _scholarId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Header
                            lblScholarName.Text = $"{reader["first_name"]} {reader["middle_name"]} {reader["last_name"]}";
                            lblScholarNumber.Text = $"Scholar #: {reader["scholar_number"]}";
                            lblStudentID.Text = $"Student ID: {reader["student_id"]}";

                            // Status badge
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
                                case "Graduated":
                                    lblStatus.ForeColor = Color.FromArgb(0, 123, 255);
                                    panelStatusBadge.BackColor = Color.FromArgb(204, 229, 255);
                                    break;
                                case "Terminated":
                                    lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                                    panelStatusBadge.BackColor = Color.FromArgb(248, 215, 218);
                                    break;
                            }

                            // Personal Information
                            lblFirstNameValue.Text = reader["first_name"]?.ToString() ?? "N/A";
                            lblMiddleNameValue.Text = reader["middle_name"]?.ToString() ?? "N/A";
                            lblLastNameValue.Text = reader["last_name"]?.ToString() ?? "N/A";
                            lblEmailValue.Text = reader["email"]?.ToString() ?? "N/A";
                            lblContactValue.Text = reader["contact_number"]?.ToString() ?? "N/A";

                            // Academic Information
                            lblCourseValue.Text = reader["course"]?.ToString() ?? "N/A";
                            lblYearLevelValue.Text = reader["year_level"]?.ToString() ?? "N/A";
                            lblHEIValue.Text = reader["hei"]?.ToString() ?? "Legacy College of Compostela";
                            lblDegreeProgramValue.Text = reader["degree_program"]?.ToString() ?? "N/A";

                            // Scholarship Information
                            lblScholarshipTypeValue.Text = reader["scholarship_name"]?.ToString() ?? "N/A";
                            lblEnrollmentDateValue.Text = reader["enrollment_date"] != DBNull.Value ?
                                Convert.ToDateTime(reader["enrollment_date"]).ToString("MMMM dd, yyyy") : "N/A";
                            lblExpectedGradValue.Text = reader["expected_graduation"] != DBNull.Value ?
                                Convert.ToDateTime(reader["expected_graduation"]).ToString("MMMM dd, yyyy") : "N/A";

                            // Summary Stats
                            lblPaymentCount.Text = reader["payment_count"]?.ToString() ?? "0";
                            lblTotalReceived.Text = $"₱{Convert.ToDecimal(reader["total_received"]):N2}";
                            lblPendingCompliance.Text = reader["pending_compliance"]?.ToString() ?? "0";
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
            this.tabSummary = new System.Windows.Forms.TabPage();

            // Labels for Personal Info
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

            // Labels for Academic Info
            this.lblCourseLabel = new System.Windows.Forms.Label();
            this.lblCourseValue = new System.Windows.Forms.Label();
            this.lblYearLevelLabel = new System.Windows.Forms.Label();
            this.lblYearLevelValue = new System.Windows.Forms.Label();
            this.lblHEILabel = new System.Windows.Forms.Label();
            this.lblHEIValue = new System.Windows.Forms.Label();
            this.lblDegreeProgramLabel = new System.Windows.Forms.Label();
            this.lblDegreeProgramValue = new System.Windows.Forms.Label();

            // Labels for Scholarship Info
            this.lblScholarshipTypeLabel = new System.Windows.Forms.Label();
            this.lblScholarshipTypeValue = new System.Windows.Forms.Label();
            this.lblEnrollmentDateLabel = new System.Windows.Forms.Label();
            this.lblEnrollmentDateValue = new System.Windows.Forms.Label();
            this.lblExpectedGradLabel = new System.Windows.Forms.Label();
            this.lblExpectedGradValue = new System.Windows.Forms.Label();

            // Labels for Summary
            this.panelPaymentStats = new System.Windows.Forms.Panel();
            this.lblPaymentCountLabel = new System.Windows.Forms.Label();
            this.lblPaymentCount = new System.Windows.Forms.Label();
            this.panelTotalReceived = new System.Windows.Forms.Panel();
            this.lblTotalReceivedLabel = new System.Windows.Forms.Label();
            this.lblTotalReceived = new System.Windows.Forms.Label();
            this.panelCompliance = new System.Windows.Forms.Panel();
            this.lblPendingComplianceLabel = new System.Windows.Forms.Label();
            this.lblPendingCompliance = new System.Windows.Forms.Label();

            // Form
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(0, 68, 79);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Size = new Size(750, 100);
            this.panelHeader.Controls.Add(this.lblScholarName);
            this.panelHeader.Controls.Add(this.lblScholarNumber);
            this.panelHeader.Controls.Add(this.lblStudentID);
            this.panelHeader.Controls.Add(this.panelStatusBadge);
            this.panelHeader.Controls.Add(this.btnClose);

            // lblScholarName
            this.lblScholarName.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            this.lblScholarName.ForeColor = Color.White;
            this.lblScholarName.Location = new Point(25, 15);
            this.lblScholarName.Size = new Size(500, 30);
            this.lblScholarName.Text = "Scholar Name";

            // lblScholarNumber
            this.lblScholarNumber.Font = new Font("Century Gothic", 10F);
            this.lblScholarNumber.ForeColor = Color.FromArgb(200, 200, 200);
            this.lblScholarNumber.Location = new Point(25, 48);
            this.lblScholarNumber.Size = new Size(200, 20);

            // lblStudentID
            this.lblStudentID.Font = new Font("Century Gothic", 10F);
            this.lblStudentID.ForeColor = Color.FromArgb(200, 200, 200);
            this.lblStudentID.Location = new Point(25, 70);
            this.lblStudentID.Size = new Size(200, 20);

            // panelStatusBadge
            this.panelStatusBadge.Location = new Point(600, 30);
            this.panelStatusBadge.Size = new Size(100, 35);
            this.panelStatusBadge.BackColor = Color.FromArgb(212, 237, 218);
            this.panelStatusBadge.Controls.Add(this.lblStatus);

            // lblStatus
            this.lblStatus.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            this.lblStatus.Dock = DockStyle.Fill;
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            this.lblStatus.Text = "Active";

            // btnClose
            this.btnClose.Text = "✕";
            this.btnClose.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.ForeColor = Color.White;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.Location = new Point(710, 10);
            this.btnClose.Size = new Size(30, 30);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // tabControl
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new Font("Century Gothic", 11F);

            // Tab: Personal Information
            this.tabPersonal.Text = "Personal Info";
            this.tabPersonal.BackColor = Color.White;
            AddLabelPair(tabPersonal, lblFirstNameLabel, "First Name:", lblFirstNameValue, "N/A", 20, 20);
            AddLabelPair(tabPersonal, lblMiddleNameLabel, "Middle Name:", lblMiddleNameValue, "N/A", 20, 70);
            AddLabelPair(tabPersonal, lblLastNameLabel, "Last Name:", lblLastNameValue, "N/A", 20, 120);
            AddLabelPair(tabPersonal, lblEmailLabel, "Email:", lblEmailValue, "N/A", 20, 170);
            AddLabelPair(tabPersonal, lblContactLabel, "Contact Number:", lblContactValue, "N/A", 20, 220);

            // Tab: Academic Information
            this.tabAcademic.Text = "Academic Info";
            this.tabAcademic.BackColor = Color.White;
            AddLabelPair(tabAcademic, lblCourseLabel, "Course:", lblCourseValue, "N/A", 20, 20);
            AddLabelPair(tabAcademic, lblYearLevelLabel, "Year Level:", lblYearLevelValue, "N/A", 20, 70);
            AddLabelPair(tabAcademic, lblHEILabel, "Institution:", lblHEIValue, "N/A", 20, 120);
            AddLabelPair(tabAcademic, lblDegreeProgramLabel, "Degree Program:", lblDegreeProgramValue, "N/A", 20, 170);

            // Tab: Scholarship Information
            this.tabScholarship.Text = "Scholarship Info";
            this.tabScholarship.BackColor = Color.White;
            AddLabelPair(tabScholarship, lblScholarshipTypeLabel, "Scholarship Type:", lblScholarshipTypeValue, "N/A", 20, 20);
            AddLabelPair(tabScholarship, lblEnrollmentDateLabel, "Enrollment Date:", lblEnrollmentDateValue, "N/A", 20, 70);
            AddLabelPair(tabScholarship, lblExpectedGradLabel, "Expected Graduation:", lblExpectedGradValue, "N/A", 20, 120);

            // Tab: Summary
            this.tabSummary.Text = "Summary";
            this.tabSummary.BackColor = Color.White;

            // ========== Total Payments Panel ==========
            this.panelPaymentStats.BackColor = Color.FromArgb(232, 245, 233);
            this.panelPaymentStats.Location = new Point(20, 20);
            this.panelPaymentStats.Size = new Size(220, 120);  // Increased height from 100 to 120

            this.lblPaymentCountLabel.Text = "Total Payments";
            this.lblPaymentCountLabel.Font = new Font("Century Gothic", 11F, FontStyle.Bold);  // Added font
            this.lblPaymentCountLabel.ForeColor = Color.FromArgb(80, 80, 80);  // Added color
            this.lblPaymentCountLabel.Location = new Point(15, 15);  // Adjusted position
            this.lblPaymentCountLabel.Size = new Size(190, 25);  // Added size
            this.lblPaymentCountLabel.AutoSize = false;  // Prevent auto-sizing issues

            this.lblPaymentCount.Text = "0";
            this.lblPaymentCount.Font = new Font("Century Gothic", 32F, FontStyle.Bold);  // Increased from 28F to 32F
            this.lblPaymentCount.ForeColor = Color.FromArgb(0, 68, 79);  // Added color
            this.lblPaymentCount.Location = new Point(15, 45);  // Adjusted position
            this.lblPaymentCount.Size = new Size(190, 60);  // INCREASED HEIGHT for larger font
            this.lblPaymentCount.TextAlign = ContentAlignment.MiddleLeft;  // Added alignment

            this.panelPaymentStats.Controls.Add(lblPaymentCountLabel);
            this.panelPaymentStats.Controls.Add(lblPaymentCount);

            // ========== Total Received Panel ==========
            this.panelTotalReceived.BackColor = Color.FromArgb(227, 242, 253);
            this.panelTotalReceived.Location = new Point(260, 20);
            this.panelTotalReceived.Size = new Size(220, 120);  // Increased height from 100 to 120

            this.lblTotalReceivedLabel.Text = "Total Received";
            this.lblTotalReceivedLabel.Font = new Font("Century Gothic", 11F, FontStyle.Bold);  // Added font
            this.lblTotalReceivedLabel.ForeColor = Color.FromArgb(80, 80, 80);  // Added color
            this.lblTotalReceivedLabel.Location = new Point(15, 15);  // Adjusted position
            this.lblTotalReceivedLabel.Size = new Size(190, 25);  // Added size
            this.lblTotalReceivedLabel.AutoSize = false;  // Prevent auto-sizing issues

            this.lblTotalReceived.Text = "₱0.00";
            this.lblTotalReceived.Font = new Font("Century Gothic", 24F, FontStyle.Bold);  // Increased from 22F to 24F
            this.lblTotalReceived.ForeColor = Color.FromArgb(0, 68, 79);  // Added color
            this.lblTotalReceived.Location = new Point(15, 45);  // Adjusted position
            this.lblTotalReceived.Size = new Size(190, 60);  // INCREASED HEIGHT for larger font
            this.lblTotalReceived.TextAlign = ContentAlignment.MiddleLeft;  // Added alignment

            this.panelTotalReceived.Controls.Add(lblTotalReceivedLabel);
            this.panelTotalReceived.Controls.Add(lblTotalReceived);

            // ========== Pending Compliance Panel ==========
            this.panelCompliance.BackColor = Color.FromArgb(255, 243, 205);
            this.panelCompliance.Location = new Point(500, 20);
            this.panelCompliance.Size = new Size(220, 120);  // Increased height from 100 to 120

            this.lblPendingComplianceLabel.Text = "Pending Requirements";
            this.lblPendingComplianceLabel.Font = new Font("Century Gothic", 11F, FontStyle.Bold);  // Added font
            this.lblPendingComplianceLabel.ForeColor = Color.FromArgb(80, 80, 80);  // Added color
            this.lblPendingComplianceLabel.Location = new Point(15, 15);  // Adjusted position
            this.lblPendingComplianceLabel.Size = new Size(190, 25);  // Added size
            this.lblPendingComplianceLabel.AutoSize = false;  // Prevent auto-sizing issues

            this.lblPendingCompliance.Text = "0";
            this.lblPendingCompliance.Font = new Font("Century Gothic", 32F, FontStyle.Bold);  // Increased from 28F to 32F
            this.lblPendingCompliance.ForeColor = Color.FromArgb(0, 68, 79);  // Added color
            this.lblPendingCompliance.Location = new Point(15, 45);  // Adjusted position
            this.lblPendingCompliance.Size = new Size(190, 60);  // INCREASED HEIGHT for larger font
            this.lblPendingCompliance.TextAlign = ContentAlignment.MiddleLeft;  // Added alignment

            this.panelCompliance.Controls.Add(lblPendingComplianceLabel);
            this.panelCompliance.Controls.Add(lblPendingCompliance);

            // Add panels to tab
            this.tabSummary.Controls.Add(panelPaymentStats);
            this.tabSummary.Controls.Add(panelTotalReceived);
            this.tabSummary.Controls.Add(panelCompliance);
            // Add tabs
            this.tabControl.TabPages.Add(tabPersonal);
            this.tabControl.TabPages.Add(tabAcademic);
            this.tabControl.TabPages.Add(tabScholarship);
            this.tabControl.TabPages.Add(tabSummary);

            // panelContent
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(tabControl);

            // Form
            this.ClientSize = new Size(750, 550);
            this.Controls.Add(panelContent);
            this.Controls.Add(panelHeader);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Scholar Details";

            this.ResumeLayout(false);
        }

        private void AddLabelPair(TabPage tab, Label labelField, string labelText, Label valueField, string valueText, int x, int y)
        {
            labelField.Text = labelText;
            labelField.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            labelField.ForeColor = Color.FromArgb(80, 80, 80);
            labelField.Location = new Point(x, y);
            labelField.Size = new Size(200, 25);

            valueField.Text = valueText;
            valueField.Font = new Font("Century Gothic", 12F);
            valueField.ForeColor = Color.FromArgb(0, 68, 79);
            valueField.Location = new Point(x, y + 25);
            valueField.Size = new Size(600, 25);

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
        private TabPage tabPersonal, tabAcademic, tabScholarship, tabSummary;

        private Label lblFirstNameLabel, lblFirstNameValue;
        private Label lblMiddleNameLabel, lblMiddleNameValue;
        private Label lblLastNameLabel, lblLastNameValue;
        private Label lblEmailLabel, lblEmailValue;
        private Label lblContactLabel, lblContactValue;
        private Label lblCourseLabel, lblCourseValue;
        private Label lblYearLevelLabel, lblYearLevelValue;
        private Label lblHEILabel, lblHEIValue;
        private Label lblDegreeProgramLabel, lblDegreeProgramValue;
        private Label lblScholarshipTypeLabel, lblScholarshipTypeValue;
        private Label lblEnrollmentDateLabel, lblEnrollmentDateValue;
        private Label lblExpectedGradLabel, lblExpectedGradValue;

        private Panel panelPaymentStats, panelTotalReceived, panelCompliance;
        private Label lblPaymentCountLabel, lblPaymentCount;
        private Label lblTotalReceivedLabel, lblTotalReceived;
        private Label lblPendingComplianceLabel, lblPendingCompliance;
    }
}