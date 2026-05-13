using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace SkolarAid.form
{
    public partial class FrmNotifications : Form
    {
        private List<NotificationItem> _notifications = new List<NotificationItem>();
        private List<RegistrationItem> _registrations = new List<RegistrationItem>();
        private DataTable _scholarsData;
        private FlowLayoutPanel flowNotifications;
        private FlowLayoutPanel flowRegistrations;
        private CheckBox chkUnreadOnly;
        private FrameworkTest.SATAButton btnMarkAllRead;
        private Label lblTotalRecords;
        private Panel _selectedPanel = null;

        // Delete buttons
        private FrameworkTest.SATAButton btnDeleteAllRead;

        // Registration tab controls
        private TabControl tabControlMain;
        private TabPage tabNotifications;
        private TabPage tabRegistrations;
        private Panel panelRegList;
        private Panel panelRegDetail;
        private Label lblRegDetailTitle;
        private Label lblRegDetailInfo;
        private RichTextBox txtRegDetailInfo;
        private FrameworkTest.SATAButton btnApproveReg;
        private FrameworkTest.SATAButton btnRejectReg;
        private Label lblRegCount;

        // Email configuration - Now uses EmailService class
        private EmailService _emailService;

        public FrmNotifications()
        {
            InitializeComponent();
            _emailService = new EmailService(); // Initialize email service
            InitializeCustomControls();
            InitializeTabControl();
            InitializeDeleteButtons();
            this.Load += FrmNotifications_Load;
            this.Resize += FrmNotifications_Resize;
        }

        private void FrmNotifications_Resize(object sender, EventArgs e) { AdjustLayoutForFullscreen(); }

        private void AdjustLayoutForFullscreen()
        {
            int screenWidth = this.ClientSize.Width;
            int screenHeight = this.ClientSize.Height;
            int cardWidth = (screenWidth - 301 - 60) / 4;
            int statsY = 90;
            int statsHeight = 85;

            if (panelStats1 != null) { panelStats1.Location = new Point(301, statsY); panelStats1.Size = new Size(cardWidth, statsHeight); }
            if (panelStats2 != null) { panelStats2.Location = new Point(301 + cardWidth + 15, statsY); panelStats2.Size = new Size(cardWidth, statsHeight); }
            if (panelStats3 != null) { panelStats3.Location = new Point(301 + (cardWidth + 15) * 2, statsY); panelStats3.Size = new Size(cardWidth, statsHeight); }
            if (panelStats4 != null) { panelStats4.Location = new Point(301 + (cardWidth + 15) * 3, statsY); panelStats4.Size = new Size(cardWidth, statsHeight); }

            int tabTopSpacing = 100;
            int tabBottomMargin = 25;
            int tabTop = statsY + tabTopSpacing;

            if (tabControlMain != null) { tabControlMain.Location = new Point(301, tabTop); tabControlMain.Size = new Size(screenWidth - 321, screenHeight - tabTop - tabBottomMargin); }

            int tabPadding = 25;
            int tabContentPadding = 35;
            int tabWidth = tabControlMain.Width - tabPadding;
            int tabHeight = tabControlMain.Height - tabContentPadding;

            int filterY = 5;
            int filterHeight = 65;
            if (panelFilters != null) { panelFilters.Location = new Point(10, filterY); panelFilters.Size = new Size(tabWidth - 15, filterHeight); }

            int contentStartY = filterY + filterHeight + 5 + 50;
            int bottomPadding = 5;
            int contentHeight = tabHeight - contentStartY - bottomPadding - 100;

            double composePct = 0.37;
            double gridPct = 0.35;
            double detailPct = 0.28;
            int spacing = 7;

            int composeWidth = (int)(tabWidth * composePct);
            int gridWidth = (int)(tabWidth * gridPct);
            int detailWidth = tabWidth - composeWidth - gridWidth - (spacing * 3);

            if (panelCompose != null) { panelCompose.Location = new Point(10, contentStartY); panelCompose.Size = new Size(composeWidth, contentHeight); }
            if (panelDataGrid != null) { panelDataGrid.Location = new Point(composeWidth + spacing, contentStartY); panelDataGrid.Size = new Size(gridWidth, contentHeight); }

            if (flowNotifications != null)
            {
                int innerPadding = 3;
                flowNotifications.Location = new Point(innerPadding, innerPadding);
                flowNotifications.Size = new Size(panelDataGrid.Width - (innerPadding * 2), panelDataGrid.Height - (innerPadding * 2));
            }

            if (panelDetailView != null) { panelDetailView.Location = new Point(composeWidth + gridWidth + (spacing * 2), contentStartY); panelDetailView.Size = new Size(detailWidth, contentHeight); }

            if (lblTotalRecords != null) { lblTotalRecords.Location = new Point(composeWidth + spacing, contentStartY + contentHeight + 2); lblTotalRecords.Size = new Size(gridWidth, 16); }

            int regY = 5;
            int regBottomPadding = 10;
            int regContentHeight = tabHeight - regY - regBottomPadding;
            double regListPct = 0.48;
            int regListWidth = (int)(tabWidth * regListPct);
            int regDetailWidth = tabWidth - regListWidth - 30;

            if (panelRegList != null) { panelRegList.Location = new Point(10, regY); panelRegList.Size = new Size(regListWidth, regContentHeight); }
            if (panelRegDetail != null) { panelRegDetail.Location = new Point(regListWidth + 20, regY); panelRegDetail.Size = new Size(regDetailWidth, regContentHeight); }

            int txtTop = 110;
            int txtBottomSpace = 130;
            if (txtRegDetailInfo != null) { txtRegDetailInfo.Location = new Point(15, txtTop); txtRegDetailInfo.Size = new Size(panelRegDetail.Width - 30, panelRegDetail.Height - txtTop - txtBottomSpace); }

            int btnY = txtRegDetailInfo.Bottom + 10;
            if (btnApproveReg != null) { btnApproveReg.Location = new Point(20, btnY); btnApproveReg.Size = new Size(180, 40); }
            if (btnRejectReg != null) { btnRejectReg.Location = new Point(210, btnY); btnRejectReg.Size = new Size(180, 40); }
        }

        private void InitializeCustomControls()
        {
            this.dgvNotifications.Visible = false;
            this.flowNotifications = new FlowLayoutPanel { Location = new Point(15, 55), Size = new Size(panelDataGrid.Width - 30, panelDataGrid.Height - 70), AutoScroll = true, FlowDirection = FlowDirection.TopDown, WrapContents = false, BackColor = Color.White };
            this.panelDataGrid.Controls.Add(this.flowNotifications);

            this.chkUnreadOnly = new CheckBox { Text = "Unread Only", Location = new Point(20, 28), Size = new Size(90, 24), Font = new Font("Century Gothic", 10F), BackColor = Color.Transparent, ForeColor = Color.Black };
            this.panelFilters.Controls.Add(this.chkUnreadOnly);

            this.btnMarkAllRead = new FrameworkTest.SATAButton { ButtonText = "Mark All as Read", Location = new Point(110, 22), Size = new Size(140, 35), Font = new Font("Century Gothic", 10F), NormalBackground = Color.FromArgb(0, 68, 79), NormalForeColor = Color.White, HoverBackground = Color.FromArgb(0, 90, 105), Rounding = new Padding(5), TextAutoCenter = true };
            this.btnMarkAllRead.Click += BtnMarkAllRead_Click;
            this.panelFilters.Controls.Add(this.btnMarkAllRead);

            this.lblTotalRecords = new Label { Location = new Point(15, panelDataGrid.Height - 40), Size = new Size(200, 40), Font = new Font("Century Gothic", 9F), ForeColor = Color.FromArgb(100, 100, 100), Text = "Showing 0 notifications" };
            this.panelDataGrid.Controls.Add(this.lblTotalRecords);

            this.lblRegCount = new Label { Location = new Point(660, 28), Size = new Size(130, 24), Font = new Font("Century Gothic", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 68, 79), Text = "0 Pending" };
            this.panelFilters.Controls.Add(this.lblRegCount);
        }

        private void InitializeTabControl()
        {
            tabControlMain = new TabControl { Font = new Font("Century Gothic", 11F, FontStyle.Bold), Location = new Point(301, 220), Size = new Size(this.ClientSize.Width - 321, this.ClientSize.Height - 250) };
            tabNotifications = new TabPage { Text = "📬 Notifications", BackColor = Color.FromArgb(243, 244, 246), AutoScroll = true };
            tabNotifications.Controls.Add(panelFilters);
            tabNotifications.Controls.Add(panelCompose);
            tabNotifications.Controls.Add(panelDataGrid);
            tabNotifications.Controls.Add(panelDetailView);

            tabRegistrations = new TabPage { Text = "📝 Scholar Registrations", BackColor = Color.FromArgb(243, 244, 246), AutoScroll = true };
            InitializeRegistrationTab();
            tabRegistrations.Controls.Add(panelRegList);
            tabRegistrations.Controls.Add(panelRegDetail);

            tabControlMain.TabPages.Add(tabNotifications);
            tabControlMain.TabPages.Add(tabRegistrations);
            tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;
            this.Controls.Add(tabControlMain);

            if (panelStats1 != null) panelStats1.BringToFront();
            if (panelStats2 != null) panelStats2.BringToFront();
            if (panelStats3 != null) panelStats3.BringToFront();
            if (panelStats4 != null) panelStats4.BringToFront();
        }

        private void InitializeRegistrationTab()
        {
            panelRegList = new Panel { Location = new Point(20, 10), Size = new Size(850, 850), AutoScroll = true, BackColor = Color.White };
            flowRegistrations = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, FlowDirection = FlowDirection.TopDown, WrapContents = false, BackColor = Color.White };
            panelRegList.Controls.Add(flowRegistrations);

            panelRegDetail = new Panel { Location = new Point(875, 10), Size = new Size(830, 850), BackColor = Color.White };
            Label lblDetailHeader = new Label { Text = "Registration Details", Font = new Font("Century Gothic", 16F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 68, 79), Location = new Point(20, 15), AutoSize = true };
            lblRegDetailTitle = new Label { Text = "Select a registration to view details", Font = new Font("Century Gothic", 12F), ForeColor = Color.Gray, Location = new Point(20, 55), AutoSize = true };
            lblRegDetailInfo = new Label { Text = "Scholar Information:", Font = new Font("Century Gothic", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 68, 79), Location = new Point(20, 90), AutoSize = true };

            txtRegDetailInfo = new RichTextBox { Location = new Point(20, 120), Size = new Size(panelRegDetail.Width - 60, 400), Font = new Font("Century Gothic", 12F), ReadOnly = true, BackColor = Color.FromArgb(248, 248, 248), BorderStyle = BorderStyle.None };

            btnApproveReg = new FrameworkTest.SATAButton { ButtonText = "✓ Approve Registration", Location = new Point(20, 540), Size = new Size(200, 45), Font = new Font("Century Gothic", 11F, FontStyle.Bold), NormalBackground = Color.FromArgb(40, 167, 69), NormalForeColor = Color.White, HoverBackground = Color.FromArgb(30, 140, 55), Rounding = new Padding(8), TextAutoCenter = true };
            btnApproveReg.Click += BtnApproveReg_Click;

            btnRejectReg = new FrameworkTest.SATAButton { ButtonText = "✗ Reject Registration", Location = new Point(240, 540), Size = new Size(200, 45), Font = new Font("Century Gothic", 11F, FontStyle.Bold), NormalBackground = Color.FromArgb(239, 68, 68), NormalForeColor = Color.White, HoverBackground = Color.FromArgb(200, 40, 40), Rounding = new Padding(8), TextAutoCenter = true };
            btnRejectReg.Click += BtnRejectReg_Click;

            panelRegDetail.Controls.Add(lblDetailHeader);
            panelRegDetail.Controls.Add(lblRegDetailTitle);
            panelRegDetail.Controls.Add(lblRegDetailInfo);
            panelRegDetail.Controls.Add(txtRegDetailInfo);
            panelRegDetail.Controls.Add(btnApproveReg);
            panelRegDetail.Controls.Add(btnRejectReg);
        }

        private void InitializeDeleteButtons()
        {
            this.btnDeleteAllRead = new FrameworkTest.SATAButton { ButtonText = "Delete All Read", Location = new Point(250, 22), Size = new Size(110, 35), Font = new Font("Century Gothic", 10F), NormalBackground = Color.FromArgb(239, 68, 68), NormalForeColor = Color.White, HoverBackground = Color.FromArgb(220, 50, 50), Rounding = new Padding(5), TextAutoCenter = true };
            this.btnDeleteAllRead.Click += BtnDeleteAllRead_Click;
            this.panelFilters.Controls.Add(this.btnDeleteAllRead);
        }

        private void FrmNotifications_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            cmbNotificationType.SelectedIndex = 0;
            cmbComposeType.SelectedIndex = 0;
            cmbComposeRecipient.SelectedIndex = 0;
            chkSendInApp.Checked = true;
            chkUnreadOnly.Checked = false;

            btnRefresh.Click += BtnRefresh_Click;
            btnClearFilters.Click += BtnClearFilters_Click;
            btnSendNotification.Click += BtnSendNotification_Click;
            btnClearForm.Click += BtnClearForm_Click;
            btnResend.Click += BtnResend_Click;
            cmbNotificationType.SelectedIndexChanged += Filter_Changed;
            chkUnreadOnly.CheckedChanged += Filter_Changed;
            txtNotificationTitle.TextChanged += (s, ev) => ValidateComposeForm();
            txtNotificationMessage.TextChanged += (s, ev) => ValidateComposeForm();
            cmbComposeRecipient.SelectedIndexChanged += (s, ev) => ValidateComposeForm();

            LoadFilterOptions();
            LoadRecipientOptions();
            LoadNotifications();
            LoadRegistrations();
            LoadStatistics();
            AdjustLayoutForFullscreen();
        }

        private void ValidateComposeForm() { btnSendNotification.Enabled = !string.IsNullOrWhiteSpace(txtNotificationTitle.Text) && !string.IsNullOrWhiteSpace(txtNotificationMessage.Text) && cmbComposeRecipient.SelectedIndex >= 0; }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabRegistrations) { LoadRegistrations(); LoadStatistics(); }
            else if (tabControlMain.SelectedTab == tabNotifications) { LoadNotifications(); LoadStatistics(); }
        }

        #region Database Loading Methods

        private void LoadFilterOptions()
        {
            cmbNotificationType.Items.Clear();
            cmbNotificationType.Items.AddRange(new[] { "All Types", "Reminder", "Alert", "Update", "Announcement" });
            cmbNotificationType.SelectedIndex = 0;
            cmbComposeType.Items.Clear();
            cmbComposeType.Items.AddRange(new[] { "Reminder", "Alert", "Update", "Announcement" });
            cmbComposeType.SelectedIndex = 0;
        }

        private void LoadRecipientOptions()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT id, CONCAT(first_name, ' ', last_name) AS full_name, scholar_number FROM scholars WHERE status = 'Active' ORDER BY first_name";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                _scholarsData = new DataTable();
                adapter.Fill(_scholarsData);
                cmbComposeRecipient.Items.Clear();
                cmbComposeRecipient.Items.Add("All Active Scholars");
                foreach (DataRow row in _scholarsData.Rows) cmbComposeRecipient.Items.Add($"{row["full_name"]} ({row["scholar_number"]})");
            }
            if (cmbComposeRecipient.Items.Count > 0) cmbComposeRecipient.SelectedIndex = 0;
        }

        private void LoadNotifications()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT n.id, n.title, n.message, n.notification_type, n.date_created, n.is_read, n.read_at, u.name as sender_name, CONCAT(s.first_name, ' ', s.last_name) AS recipient_name, s.scholar_number FROM notifications n LEFT JOIN users u ON n.sender_id = u.id JOIN scholars s ON n.recipient_id = s.id WHERE 1=1";
                if (cmbNotificationType.SelectedIndex > 0) query += " AND n.notification_type = @type";
                if (chkUnreadOnly.Checked) query += " AND n.is_read = FALSE";
                query += " ORDER BY n.date_created DESC LIMIT 50";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (cmbNotificationType.SelectedIndex > 0) cmd.Parameters.AddWithValue("@type", cmbNotificationType.SelectedItem.ToString());

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    _notifications.Clear();
                    while (reader.Read())
                        _notifications.Add(new NotificationItem { Id = Convert.ToInt32(reader["id"]), Title = reader["title"].ToString(), Message = reader["message"].ToString(), Type = reader["notification_type"].ToString(), DateSent = Convert.ToDateTime(reader["date_created"]), IsRead = Convert.ToBoolean(reader["is_read"]), ReadAt = reader["read_at"] != DBNull.Value ? Convert.ToDateTime(reader["read_at"]) : (DateTime?)null, SenderName = reader["sender_name"]?.ToString() ?? "System", RecipientName = reader["recipient_name"].ToString(), ScholarNumber = reader["scholar_number"].ToString() });
                }
            }
            UpdateNotificationList();
            UpdateSummaryCards();
        }

        private void LoadRegistrations()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Check if new columns exist, add if missing
                    string[] newColumns = {
                "program", "hei", "degree_program",
                "enrollment_date", "expected_graduation",
                "stipend_amount", "stipend_frequency",
                "scholarship_fund_source", "renewal_conditions"
            };

                    foreach (string col in newColumns)
                    {
                        try { new MySqlCommand($"SELECT {col} FROM scholar_registrations LIMIT 1", conn).ExecuteScalar(); }
                        catch
                        {
                            string alterSql = "";
                            if (col == "program")
                                alterSql = "ALTER TABLE scholar_registrations ADD COLUMN program VARCHAR(100) DEFAULT 'Undergraduate'";
                            else if (col == "hei")
                                alterSql = "ALTER TABLE scholar_registrations ADD COLUMN hei VARCHAR(200) DEFAULT 'Legacy College of Compostela'";
                            else if (col == "degree_program")
                                alterSql = "ALTER TABLE scholar_registrations ADD COLUMN degree_program VARCHAR(200)";
                            else if (col == "enrollment_date")
                                alterSql = "ALTER TABLE scholar_registrations ADD COLUMN enrollment_date DATE";
                            else if (col == "expected_graduation")
                                alterSql = "ALTER TABLE scholar_registrations ADD COLUMN expected_graduation DATE";
                            else if (col == "stipend_amount")
                                alterSql = "ALTER TABLE scholar_registrations ADD COLUMN stipend_amount DECIMAL(10,2)";
                            else if (col == "stipend_frequency")
                                alterSql = "ALTER TABLE scholar_registrations ADD COLUMN stipend_frequency VARCHAR(20)";
                            else if (col == "scholarship_fund_source")
                                alterSql = "ALTER TABLE scholar_registrations ADD COLUMN scholarship_fund_source VARCHAR(100)";
                            else if (col == "renewal_conditions")
                                alterSql = "ALTER TABLE scholar_registrations ADD COLUMN renewal_conditions TEXT";
                            if (!string.IsNullOrEmpty(alterSql))
                            {
                                try { new MySqlCommand(alterSql, conn).ExecuteNonQuery(); } catch { }
                            }
                        }
                    }

                    string query = @"SELECT * FROM scholar_registrations 
                            ORDER BY CASE status 
                                WHEN 'Pending' THEN 1 
                                WHEN 'Approved' THEN 2 
                                WHEN 'Rejected' THEN 3 
                            END, created_at DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        _registrations.Clear();
                        while (reader.Read())
                        {
                            var reg = new RegistrationItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                FirstName = reader["first_name"]?.ToString() ?? "",
                                MiddleName = reader["middle_name"]?.ToString() ?? "",
                                LastName = reader["last_name"]?.ToString() ?? "",
                                Suffix = reader["suffix"]?.ToString() ?? "",
                                Email = reader["email"]?.ToString() ?? "",
                                ContactNumber = reader["contact_number"]?.ToString() ?? "",
                                Course = reader["course"]?.ToString() ?? "",
                                YearLevel = reader["year_level"]?.ToString() ?? "",
                                Status = reader["status"]?.ToString() ?? "Pending",
                                RejectionReason = reader["rejection_reason"]?.ToString() ?? "",
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : DateTime.Now
                            };

                            // Safe reading for optional fields
                            try { reg.DateOfBirth = reader["date_of_birth"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_birth"]) : (DateTime?)null; } catch { }
                            try { reg.Gender = reader["gender"]?.ToString() ?? ""; } catch { }
                            try { reg.Address = reader["address"]?.ToString() ?? ""; } catch { }
                            try { reg.ScholarshipTypeId = reader["scholarship_type_id"] != DBNull.Value ? Convert.ToInt32(reader["scholarship_type_id"]) : 0; } catch { }
                            try { reg.BankName = reader["bank_name"]?.ToString() ?? ""; } catch { }
                            try { reg.BankAccountNumber = reader["bank_account_number"]?.ToString() ?? ""; } catch { }
                            try { reg.FilePSA = reader["file_psa"]?.ToString() ?? ""; } catch { }
                            try { reg.FileCOE = reader["file_coe"]?.ToString() ?? ""; } catch { }
                            try { reg.FileCOR = reader["file_cor"]?.ToString() ?? ""; } catch { }
                            try { reg.FileGrades = reader["file_grades"]?.ToString() ?? ""; } catch { }
                            try { reg.FileContract = reader["file_contract"]?.ToString() ?? ""; } catch { }
                            try { reg.Notes = reader["notes"]?.ToString() ?? ""; } catch { }

                            // NEW FIELDS
                            try { reg.Program = reader["program"]?.ToString() ?? "Undergraduate"; } catch { }
                            try { reg.HEI = reader["hei"]?.ToString() ?? "Legacy College of Compostela"; } catch { }
                            try { reg.DegreeProgram = reader["degree_program"]?.ToString() ?? ""; } catch { }
                            try { reg.EnrollmentDate = reader["enrollment_date"] != DBNull.Value ? Convert.ToDateTime(reader["enrollment_date"]) : (DateTime?)null; } catch { }
                            try { reg.ExpectedGraduation = reader["expected_graduation"] != DBNull.Value ? Convert.ToDateTime(reader["expected_graduation"]) : (DateTime?)null; } catch { }
                            try { reg.StipendAmount = reader["stipend_amount"] != DBNull.Value ? Convert.ToDecimal(reader["stipend_amount"]) : (decimal?)null; } catch { }
                            try { reg.StipendFrequency = reader["stipend_frequency"]?.ToString() ?? ""; } catch { }
                            try { reg.ScholarshipFundSource = reader["scholarship_fund_source"]?.ToString() ?? "Government"; } catch { }
                            try { reg.RenewalConditions = reader["renewal_conditions"]?.ToString() ?? ""; } catch { }

                            _registrations.Add(reg);
                        }
                    }
                }
                UpdateRegistrationList();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"Error loading registrations: {ex.Message}"); }
        }
        private void UpdateRegistrationList()
        {
            flowRegistrations.Controls.Clear();
            foreach (var reg in _registrations) { Panel panel = CreateRegistrationCard(reg); flowRegistrations.Controls.Add(panel); }
            int pendingCount = _registrations.Count(r => r.Status == "Pending");
            lblRegCount.Text = $"{pendingCount} Pending";
            if (_registrations.Count == 0) { Label lblEmpty = new Label { Text = "No registrations found.", Font = new Font("Century Gothic", 11F, FontStyle.Italic), ForeColor = Color.FromArgb(120, 120, 120), Location = new Point(20, 20), AutoSize = true }; flowRegistrations.Controls.Add(lblEmpty); }
        }

        private Panel CreateRegistrationCard(RegistrationItem reg)
        {
            Panel panel = new Panel { Width = flowRegistrations.Width - 30, Height = 95, BackColor = reg.Status == "Pending" ? Color.FromArgb(255, 252, 235) : reg.Status == "Approved" ? Color.FromArgb(240, 255, 240) : Color.FromArgb(255, 240, 240), Margin = new Padding(5, 0, 5, 8), Cursor = Cursors.Hand };
            string fullName = $"{reg.FirstName} {reg.MiddleName} {reg.LastName} {reg.Suffix}".Replace("  ", " ").Trim();
            Color statusColor = reg.Status == "Pending" ? Color.FromArgb(255, 170, 0) : reg.Status == "Approved" ? Color.FromArgb(40, 167, 69) : Color.FromArgb(239, 68, 68);

            Label lblName = new Label { Text = fullName, Location = new Point(15, 10), Size = new Size(panel.Width - 200, 22), Font = new Font("Century Gothic", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 68, 79), BackColor = Color.Transparent, Cursor = Cursors.Hand };
            Label lblEmail = new Label { Text = $"📧 {reg.Email}", Location = new Point(15, 35), Size = new Size(280, 18), Font = new Font("Century Gothic", 9F), ForeColor = Color.FromArgb(80, 80, 80), BackColor = Color.Transparent, Cursor = Cursors.Hand };
            Label lblCourse = new Label { Text = $"🎓 {reg.Course} | Year: {reg.YearLevel}", Location = new Point(15, 55), Size = new Size(280, 18), Font = new Font("Century Gothic", 9F), ForeColor = Color.FromArgb(80, 80, 80), BackColor = Color.Transparent, Cursor = Cursors.Hand };
            Label lblStatus = new Label { Text = reg.Status, Location = new Point(panel.Width - 110, 10), Size = new Size(85, 22), TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Century Gothic", 8F, FontStyle.Bold), ForeColor = Color.White, BackColor = statusColor, Cursor = Cursors.Hand };
            Label lblDate = new Label { Text = reg.CreatedAt.ToString("MMM dd, yyyy"), Location = new Point(15, 75), Size = new Size(150, 18), Font = new Font("Century Gothic", 8F), ForeColor = Color.FromArgb(100, 100, 100), BackColor = Color.Transparent, Cursor = Cursors.Hand };

            panel.Controls.Add(lblName); panel.Controls.Add(lblEmail); panel.Controls.Add(lblCourse); panel.Controls.Add(lblStatus); panel.Controls.Add(lblDate);
            panel.Click += (s, e) => ShowRegistrationDetails(reg);
            foreach (Control ctrl in panel.Controls) ctrl.Click += (s, e) => ShowRegistrationDetails(reg);
            return panel;
        }

        private void ShowRegistrationDetails(RegistrationItem reg)
        {
            string fullName = $"{reg.FirstName} {reg.MiddleName} {reg.LastName} {reg.Suffix}".Replace("  ", " ").Trim();
            lblRegDetailTitle.Text = $"Registration: {fullName}";
            lblRegDetailTitle.ForeColor = Color.FromArgb(0, 68, 79);

            string scholarshipName = "N/A";
            if (reg.ScholarshipTypeId > 0)
            {
                try
                {
                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT name FROM scholarship_types WHERE id = @id", conn);
                        cmd.Parameters.AddWithValue("@id", reg.ScholarshipTypeId);
                        object r = cmd.ExecuteScalar();
                        if (r != null) scholarshipName = r.ToString();
                    }
                }
                catch { }
            }

            // Clear dynamic controls
            var controlsToRemove = new List<Control>();
            foreach (Control ctrl in panelRegDetail.Controls)
            {
                if (ctrl != lblRegDetailTitle &&
                    ctrl != lblRegDetailInfo &&
                    ctrl != txtRegDetailInfo &&
                    ctrl != btnApproveReg &&
                    ctrl != btnRejectReg &&
                    ctrl.Name != "lblDetailHeader")
                {
                    if (ctrl is Label && ctrl.Location.Y < 20 && ctrl.Font.Size >= 14)
                        continue;
                    controlsToRemove.Add(ctrl);
                }
            }
            foreach (Control ctrl in controlsToRemove)
            {
                panelRegDetail.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            // Build info text with NEW FIELDS
            string infoText = $"📋 Full Name: {fullName}\n" +
                             $"📧 Email: {reg.Email}\n" +
                             $"📱 Contact: {reg.ContactNumber}\n" +
                             $"🎂 Date of Birth: {reg.DateOfBirth?.ToString("MMM dd, yyyy") ?? "N/A"}\n" +
                             $"👤 Gender: {reg.Gender}\n" +
                             $"📍 Address: {reg.Address}\n" +
                             $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                             $"📚 Program: {reg.Program}\n" +
                             $"🏫 HEI: {reg.HEI}\n" +
                             $"📖 Degree: {reg.DegreeProgram}\n" +
                             $"🎓 Course: {reg.Course}\n" +
                             $"📆 Year Level: {reg.YearLevel}\n" +
                             $"📅 Enrolled: {reg.EnrollmentDate?.ToString("MMM dd, yyyy") ?? "N/A"}\n" +
                             $"🎯 Expected Graduation: {reg.ExpectedGraduation?.ToString("MMM dd, yyyy") ?? "N/A"}\n" +
                             $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                             $"🎖 Scholarship: {scholarshipName}\n" +
                             $"💵 Stipend: ₱{reg.StipendAmount:N2} / {reg.StipendFrequency}\n" +
                             $"💰 Fund Source: {reg.ScholarshipFundSource}\n" +
                             $"🔄 Renewal: {reg.RenewalConditions}\n" +
                             $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                             $"🏦 Bank: {reg.BankName}\n" +
                             $"💳 Account: {reg.BankAccountNumber}\n" +
                             $"📅 Registered: {reg.CreatedAt:MMM dd, yyyy hh:mm tt}\n" +
                             $"📌 Status: {reg.Status}\n" +
                             (reg.Status == "Rejected" ? $"❌ Reason: {reg.RejectionReason}\n" : "");

            txtRegDetailInfo.Text = infoText;
            txtRegDetailInfo.Size = new Size(panelRegDetail.Width - 40, 220);
            txtRegDetailInfo.Location = new Point(15, 110);

            // File links
            var fileInfo = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(reg.FilePSA)) fileInfo["PSA Birth Certificate"] = reg.FilePSA;
            if (!string.IsNullOrEmpty(reg.FileCOE)) fileInfo["Certificate of Enrollment (COE)"] = reg.FileCOE;
            if (!string.IsNullOrEmpty(reg.FileCOR)) fileInfo["Certificate of Registration (COR)"] = reg.FileCOR;
            if (!string.IsNullOrEmpty(reg.FileGrades)) fileInfo["Latest Grades/TOR"] = reg.FileGrades;
            if (!string.IsNullOrEmpty(reg.FileContract)) fileInfo["Scholarship Contract"] = reg.FileContract;

            int fileY = txtRegDetailInfo.Bottom + 10;

            Label lblFilesHeader = new Label
            {
                Text = "📁 Uploaded Files:",
                Font = new Font("Century Gothic", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                Location = new Point(20, fileY),
                AutoSize = true,
                Name = "dynamicFileHeader"
            };
            panelRegDetail.Controls.Add(lblFilesHeader);
            fileY += 25;

            if (fileInfo.Count > 0)
            {
                foreach (var file in fileInfo)
                {
                    Label lblFile = new Label
                    {
                        Text = $"📎 {file.Key} - {Path.GetFileName(file.Value)}",
                        Font = new Font("Century Gothic", 10F, FontStyle.Underline),
                        ForeColor = Color.Blue,
                        BackColor = Color.Transparent,
                        Location = new Point(35, fileY),
                        AutoSize = true,
                        Cursor = Cursors.Hand,
                        Tag = file.Value,
                        Name = "dynamicFileLink"
                    };
                    lblFile.MouseEnter += (s, ev) => { ((Label)s).ForeColor = Color.DarkBlue; };
                    lblFile.MouseLeave += (s, ev) => { ((Label)s).ForeColor = Color.Blue; };
                    lblFile.Click += (s, ev) => { OpenFileFromRegistration(((Label)s).Tag.ToString()); };
                    panelRegDetail.Controls.Add(lblFile);
                    fileY += 22;
                }
            }
            else
            {
                Label lblNoFiles = new Label
                {
                    Text = "  No files uploaded",
                    Font = new Font("Century Gothic", 10F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Location = new Point(35, fileY),
                    AutoSize = true,
                    Name = "dynamicNoFiles"
                };
                panelRegDetail.Controls.Add(lblNoFiles);
                fileY += 25;
            }

            // Notes
            fileY += 5;
            Label lblNotesHeader = new Label
            {
                Text = "📝 Notes:",
                Font = new Font("Century Gothic", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                Location = new Point(20, fileY),
                AutoSize = true,
                Name = "dynamicNotesHeader"
            };
            panelRegDetail.Controls.Add(lblNotesHeader);
            fileY += 22;

            Label lblNotes = new Label
            {
                Text = string.IsNullOrEmpty(reg.Notes) ? "None" : reg.Notes,
                Font = new Font("Century Gothic", 10F),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(35, fileY),
                Size = new Size(panelRegDetail.Width - 60, 40),
                AutoSize = true,
                Name = "dynamicNotes"
            };
            panelRegDetail.Controls.Add(lblNotes);

            // Reposition buttons
            int btnY = fileY + 55;
            if (btnY < txtRegDetailInfo.Bottom + 15)
                btnY = txtRegDetailInfo.Bottom + 15;

            btnApproveReg.Location = new Point(20, btnY);
            btnRejectReg.Location = new Point(230, btnY);

            txtRegDetailInfo.Tag = fileInfo;
            btnApproveReg.Tag = reg;
            btnRejectReg.Tag = reg;
            btnApproveReg.Enabled = reg.Status == "Pending";
            btnRejectReg.Enabled = reg.Status == "Pending";
        }

        private void TxtRegDetailInfo_MouseClick(object sender, MouseEventArgs e)
        {
            var fileInfo = txtRegDetailInfo.Tag as Dictionary<string, string>;
            if (fileInfo == null || fileInfo.Count == 0) return;
            int lineIndex = txtRegDetailInfo.GetLineFromCharIndex(txtRegDetailInfo.GetCharIndexFromPosition(e.Location));
            string clickedLine = txtRegDetailInfo.Lines.Length > lineIndex ? txtRegDetailInfo.Lines[lineIndex] : "";
            foreach (var file in fileInfo) { if (clickedLine.Contains(file.Key) && clickedLine.Contains("📎")) { OpenFileFromRegistration(file.Value); break; } }
        }

        private void OpenFileFromRegistration(string filePath)
        {
            try
            {
                string fullPath = Path.Combine(@"C:\xampp\htdocs\skolaraid\", filePath.Replace("/", "\\"));
                if (File.Exists(fullPath)) System.Diagnostics.Process.Start(fullPath);
                else MessageBox.Show($"File not found: {Path.GetFileName(filePath)}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) { MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UpdateNotificationList()
        {
            flowNotifications.Controls.Clear(); _selectedPanel = null;
            foreach (var n in _notifications.OrderByDescending(n => n.DateSent)) { var p = CreateNotificationPanel(n); p.Tag = n; flowNotifications.Controls.Add(p); }
            lblTotalRecords.Text = $"Showing {_notifications.Count} notifications";
            if (_notifications.Count == 0) flowNotifications.Controls.Add(new Label { Text = "No notifications found.", Font = new Font("Century Gothic", 11F, FontStyle.Italic), ForeColor = Color.FromArgb(120, 120, 120), Location = new Point(20, 20), AutoSize = true });
        }

        private Panel CreateNotificationPanel(NotificationItem n)
        {
            Panel p = new Panel { Width = flowNotifications.Width - 30, Height = 105, BackColor = n.IsRead ? Color.White : Color.FromArgb(240, 248, 248), Margin = new Padding(5, 0, 5, 8), Cursor = Cursors.Hand };
            PictureBox pic = new PictureBox { Location = new Point(15, 20), Size = new Size(40, 40), SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.Transparent };
            switch (n.Type) { case "Payment": pic.Image = Properties.Resources.dollar; break; default: pic.Image = Properties.Resources.bell__1_; break; }
            Label t = new Label { Text = n.Title, Location = new Point(70, 10), Size = new Size(p.Width - 190, 22), Font = new Font("Century Gothic", 11F, n.IsRead ? FontStyle.Regular : FontStyle.Bold), ForeColor = n.IsRead ? Color.FromArgb(60, 60, 60) : Color.FromArgb(0, 68, 79), BackColor = Color.Transparent, Cursor = Cursors.Hand };
            Label m = new Label { Text = n.Message.Length > 35 ? n.Message.Substring(0, 32) + "..." : n.Message, Location = new Point(70, 32), Size = new Size(p.Width - 190, 20), Font = new Font("Century Gothic", 9F), ForeColor = Color.FromArgb(80, 80, 80), BackColor = Color.Transparent, Cursor = Cursors.Hand };
            Label r = new Label { Text = $"To: {n.RecipientName}", Location = new Point(70, 52), Size = new Size(180, 18), Font = new Font("Century Gothic", 8F), ForeColor = Color.FromArgb(100, 100, 100), BackColor = Color.Transparent, Cursor = Cursors.Hand };
            Label ty = new Label { Text = n.Type, Location = new Point(p.Width - 110, 10), Size = new Size(85, 22), TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Century Gothic", 8F, FontStyle.Bold), ForeColor = Color.White, BackColor = GetTypeColor(n.Type), Cursor = Cursors.Hand };
            Label ti = new Label { Text = GetRelativeTime(n.DateSent), Location = new Point(p.Width - 110, 35), Size = new Size(85, 20), TextAlign = ContentAlignment.MiddleRight, Font = new Font("Century Gothic", 8F), ForeColor = Color.FromArgb(100, 100, 100), BackColor = Color.Transparent, Cursor = Cursors.Hand };
            Label rs = new Label { Text = n.IsRead ? "✓ Read" : "● Unread", Location = new Point(p.Width - 120, 55), Size = new Size(75, 18), TextAlign = ContentAlignment.MiddleRight, Font = new Font("Century Gothic", 8F, FontStyle.Bold), ForeColor = n.IsRead ? Color.FromArgb(40, 167, 69) : Color.FromArgb(0, 68, 79), BackColor = Color.Transparent, Cursor = Cursors.Hand };
            Label del = new Label { Text = "✕", Location = new Point(p.Width - 26, 8), Size = new Size(20, 20), TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Century Gothic", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(150, 150, 150), BackColor = Color.Transparent, Cursor = Cursors.Hand, Tag = n.Id };
            del.MouseEnter += (s, e) => del.ForeColor = Color.FromArgb(239, 68, 68);
            del.MouseLeave += (s, e) => del.ForeColor = Color.FromArgb(150, 150, 150);
            del.Click += (s, e) => DeleteSingleNotification((int)((Label)s).Tag);

            p.Controls.Add(pic); p.Controls.Add(t); p.Controls.Add(m); p.Controls.Add(r); p.Controls.Add(ty); p.Controls.Add(ti); p.Controls.Add(rs); p.Controls.Add(del);
            p.Click += (s, e) => { SelectNotificationPanel(p, n); ShowNotificationDetails(n); };
            foreach (Control c in p.Controls) if (c != del) c.Click += (s, e) => { SelectNotificationPanel(p, n); ShowNotificationDetails(n); };
            return p;
        }

        private void SelectNotificationPanel(Panel sp, NotificationItem n) { if (_selectedPanel != null) { var pn = _selectedPanel.Tag as NotificationItem; _selectedPanel.BackColor = pn != null && pn.IsRead ? Color.White : Color.FromArgb(240, 248, 248); } sp.BackColor = Color.FromArgb(220, 240, 240); _selectedPanel = sp; }
        private Color GetTypeColor(string type) { switch (type) { case "Payment": return Color.FromArgb(40, 167, 69); case "Reminder": return Color.FromArgb(255, 170, 0); case "Alert": return Color.FromArgb(239, 68, 68); case "Update": return Color.FromArgb(0, 123, 255); case "Announcement": return Color.FromArgb(111, 66, 193); default: return Color.FromArgb(0, 68, 79); } }

        private void LoadStatistics()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                lblTotalSent.Text = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM notifications", conn).ExecuteScalar()).ToString();
                lblPendingSMS.Text = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM notifications WHERE is_read = FALSE", conn).ExecuteScalar()).ToString();
                lblDelivered.Text = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM notifications WHERE is_read = TRUE", conn).ExecuteScalar()).ToString();
                try { int regs = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM scholar_registrations WHERE status = 'Pending'", conn).ExecuteScalar()); lblFailedSMS.Text = regs.ToString(); lblRegCount.Text = $"{regs} Pending"; } catch { lblFailedSMS.Text = "0"; }
            }
        }

        private void UpdateSummaryCards() { int t = _notifications.Count; lblTotalSent.Text = t.ToString(); lblPendingSMS.Text = _notifications.Count(n => !n.IsRead).ToString(); lblDelivered.Text = _notifications.Count(n => n.IsRead).ToString(); }
        private void ShowNotificationDetails(NotificationItem n) { if (!n.IsRead) { MarkAsRead(n.Id); n.IsRead = true; UpdateNotificationList(); UpdateSummaryCards(); } lblDetailTitle.Text = n.Title; lblDetailType.Text = n.Type; lblDetailType.ForeColor = GetTypeColor(n.Type); lblDetailDate.Text = n.DateSent.ToString("MMMM dd, yyyy • hh:mm tt"); txtDetailMessage.Text = n.Message; lblDetailDelivery.Text = "In-App"; lblDetailSMSStatus.Text = n.IsRead ? "Read" : "Unread"; lblDetailSMSStatus.ForeColor = n.IsRead ? Color.FromArgb(40, 167, 69) : Color.FromArgb(0, 68, 79); btnResend.Tag = n; }
        private void MarkAsRead(int id) { using (MySqlConnection conn = DatabaseHelper.GetConnection()) { conn.Open(); new MySqlCommand("UPDATE notifications SET is_read = TRUE, read_at = NOW() WHERE id = " + id, conn).ExecuteNonQuery(); } }
        private string GetRelativeTime(DateTime dt) { var ts = DateTime.Now - dt; if (ts.TotalMinutes < 1) return "Just now"; if (ts.TotalMinutes < 60) return $"{(int)ts.TotalMinutes}m ago"; if (ts.TotalHours < 24) return $"{(int)ts.TotalHours}h ago"; if (ts.TotalDays < 7) return $"{(int)ts.TotalDays}d ago"; return dt.ToString("MMM dd"); }

        #endregion

        #region Notification Actions

        private void BtnResend_Click(object sender, EventArgs e) { var n = btnResend.Tag as NotificationItem; if (n != null) { txtNotificationTitle.Text = n.Title; txtNotificationMessage.Text = n.Message; cmbComposeType.SelectedItem = n.Type; cmbComposeRecipient.SelectedIndex = 0; panelCompose.Focus(); } else MessageBox.Show("Please select a notification to resend.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        private void BtnRefresh_Click(object sender, EventArgs e) { LoadNotifications(); LoadRegistrations(); LoadStatistics(); }
        private void BtnClearFilters_Click(object sender, EventArgs e) { cmbNotificationType.SelectedIndex = 0; chkUnreadOnly.Checked = false; LoadNotifications(); }
        private void BtnMarkAllRead_Click(object sender, EventArgs e) { using (MySqlConnection conn = DatabaseHelper.GetConnection()) { conn.Open(); int a = new MySqlCommand("UPDATE notifications SET is_read = TRUE, read_at = NOW() WHERE is_read = FALSE", conn).ExecuteNonQuery(); MessageBox.Show($"{a} notifications marked as read.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); LoadNotifications(); LoadStatistics(); } }
        private void BtnSendNotification_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNotificationTitle.Text) || string.IsNullOrWhiteSpace(txtNotificationMessage.Text))
            {
                MessageBox.Show("Please fill in title and message.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction tr = conn.BeginTransaction())
                {
                    try
                    {
                        int sid = SessionManager.CurrentUser?.Id ?? 1;
                        string type = cmbComposeType.SelectedItem?.ToString() ?? "Update";
                        string title = txtNotificationTitle.Text.Trim();
                        string message = txtNotificationMessage.Text.Trim();

                        if (cmbComposeRecipient.SelectedIndex == 0) // All Active Scholars
                        {
                            string query = @"INSERT INTO notifications (sender_id, recipient_id, title, message, notification_type, is_read, date_created) 
                                   SELECT @sid, id, @t, @m, @ty, FALSE, NOW() 
                                   FROM scholars WHERE status = 'Active'";

                            MySqlCommand cmd = new MySqlCommand(query, conn, tr);
                            cmd.Parameters.AddWithValue("@sid", sid);
                            cmd.Parameters.AddWithValue("@t", title);
                            cmd.Parameters.AddWithValue("@m", message);
                            cmd.Parameters.AddWithValue("@ty", type);
                            cmd.ExecuteNonQuery();
                        }
                        else // Specific Scholar
                        {
                            int rid = Convert.ToInt32(_scholarsData.Rows[cmbComposeRecipient.SelectedIndex - 1]["id"]);

                            string query = @"INSERT INTO notifications (sender_id, recipient_id, title, message, notification_type, is_read, date_created) 
                                   VALUES (@sid, @rid, @t, @m, @ty, FALSE, NOW())";

                            MySqlCommand cmd = new MySqlCommand(query, conn, tr);
                            cmd.Parameters.AddWithValue("@sid", sid);
                            cmd.Parameters.AddWithValue("@rid", rid);
                            cmd.Parameters.AddWithValue("@t", title);
                            cmd.Parameters.AddWithValue("@m", message);
                            cmd.Parameters.AddWithValue("@ty", type);
                            cmd.ExecuteNonQuery();
                        }

                        tr.Commit();

                        MessageBox.Show("Notification sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearComposeForm();
                        LoadNotifications();
                        LoadStatistics();
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        MessageBox.Show($"Error sending notification: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void BtnClearForm_Click(object sender, EventArgs e) => ClearComposeForm();
        private void ClearComposeForm() { txtNotificationTitle.Text = ""; txtNotificationMessage.Text = ""; cmbComposeType.SelectedIndex = 0; cmbComposeRecipient.SelectedIndex = 0; chkSendInApp.Checked = true; chkSendSMS.Checked = false; btnSendNotification.Enabled = false; }
        private void BtnDeleteAllRead_Click(object sender, EventArgs e) { int c = _notifications.Count(n => n.IsRead); if (c == 0) { MessageBox.Show("No read notifications to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; } if (MessageBox.Show($"Delete all {c} read notifications?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) { using (MySqlConnection conn = DatabaseHelper.GetConnection()) { conn.Open(); new MySqlCommand("DELETE FROM notifications WHERE is_read = TRUE", conn).ExecuteNonQuery(); } LoadNotifications(); LoadStatistics(); } }
        private void DeleteSingleNotification(int id) { if (MessageBox.Show("Delete this notification?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { using (MySqlConnection conn = DatabaseHelper.GetConnection()) { conn.Open(); new MySqlCommand("DELETE FROM notifications WHERE id = " + id, conn).ExecuteNonQuery(); } LoadNotifications(); LoadStatistics(); } }
        private void Filter_Changed(object sender, EventArgs e) => LoadNotifications();

        #endregion

        #region Registration Actions

        private void BtnApproveReg_Click(object sender, EventArgs e)
        {
            var reg = btnApproveReg.Tag as RegistrationItem;
            if (reg == null) return;
            if (MessageBox.Show($"Approve registration for {reg.FirstName} {reg.LastName}?\n\nThis will create a scholar account and send welcome email.", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction tr = conn.BeginTransaction())
                    {
                        string year = DateTime.Now.Year.ToString();
                        int count = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM scholars WHERE scholar_number LIKE 'SCH-" + year + "-%'", conn, tr).ExecuteScalar()) + 1;
                        string schNum = $"SCH-{year}-{count:D3}";
                        string studentId = $"{year}-{count:D6}";
                        string fullName = $"{reg.FirstName} {reg.MiddleName} {reg.LastName} {reg.Suffix}".Replace("  ", " ").Trim();
                        string lastNameForDB = string.IsNullOrWhiteSpace(reg.Suffix) ? reg.LastName : $"{reg.LastName} {reg.Suffix}".Trim();

                        // Get scholarship details for stipend info
                        decimal stipendAmount = reg.StipendAmount ?? 0;
                        string stipendFrequency = reg.StipendFrequency ?? "Monthly";

                        if (reg.ScholarshipTypeId > 0 && (stipendAmount == 0 || string.IsNullOrEmpty(stipendFrequency)))
                        {
                            try
                            {
                                MySqlCommand cmdSch = new MySqlCommand("SELECT stipend_amount, payment_frequency FROM scholarship_types WHERE id = @id", conn, tr);
                                cmdSch.Parameters.AddWithValue("@id", reg.ScholarshipTypeId);
                                using (var rdr = cmdSch.ExecuteReader())
                                {
                                    if (rdr.Read())
                                    {
                                        if (stipendAmount == 0) stipendAmount = rdr["stipend_amount"] != DBNull.Value ? Convert.ToDecimal(rdr["stipend_amount"]) : 0;
                                        if (string.IsNullOrEmpty(stipendFrequency)) stipendFrequency = rdr["payment_frequency"]?.ToString() ?? "Monthly";
                                    }
                                }
                            }
                            catch { }
                        }

                        // Insert scholar with ALL new fields
                        MySqlCommand cmdS = new MySqlCommand(@"INSERT INTO scholars (
                    student_id, scholar_number, 
                    first_name, middle_name, last_name, 
                    email, contact_number, 
                    date_of_birth, gender, address,
                    program, hei, degree_program,
                    course, year_level,
                    scholarship_type_id, 
                    stipend_amount, stipend_frequency,
                    scholarship_fund_source, renewal_conditions,
                    enrollment_date, expected_graduation,
                    bank_name, bank_account_number,
                    status, created_at
                ) VALUES (
                    @sid, @sn, 
                    @fn, @mn, @ln, 
                    @em, @cn, 
                    @dob, @gen, @addr,
                    @prog, @hei, @deg,
                    @course, @yl,
                    @stid,
                    @stipend, @freq,
                    @fund, @renewal,
                    @enroll, @grad,
                    @bank, @acct,
                    'Active', NOW()
                ); SELECT LAST_INSERT_ID();", conn, tr);

                        cmdS.Parameters.AddWithValue("@sid", studentId);
                        cmdS.Parameters.AddWithValue("@sn", schNum);
                        cmdS.Parameters.AddWithValue("@fn", reg.FirstName);
                        cmdS.Parameters.AddWithValue("@mn", reg.MiddleName);
                        cmdS.Parameters.AddWithValue("@ln", lastNameForDB);
                        cmdS.Parameters.AddWithValue("@em", reg.Email);
                        cmdS.Parameters.AddWithValue("@cn", reg.ContactNumber);
                        cmdS.Parameters.AddWithValue("@dob", reg.DateOfBirth ?? DateTime.Now.AddYears(-18));
                        cmdS.Parameters.AddWithValue("@gen", reg.Gender ?? "Male");
                        cmdS.Parameters.AddWithValue("@addr", reg.Address ?? "");
                        cmdS.Parameters.AddWithValue("@prog", reg.Program ?? "Undergraduate");
                        cmdS.Parameters.AddWithValue("@hei", reg.HEI ?? "Legacy College of Compostela");
                        cmdS.Parameters.AddWithValue("@deg", reg.DegreeProgram ?? reg.Course ?? "");
                        cmdS.Parameters.AddWithValue("@course", reg.Course ?? "");
                        cmdS.Parameters.AddWithValue("@yl", reg.YearLevel ?? "");
                        cmdS.Parameters.AddWithValue("@stid", reg.ScholarshipTypeId > 0 ? (object)reg.ScholarshipTypeId : DBNull.Value);
                        cmdS.Parameters.AddWithValue("@stipend", stipendAmount > 0 ? (object)stipendAmount : DBNull.Value);
                        cmdS.Parameters.AddWithValue("@freq", string.IsNullOrEmpty(stipendFrequency) ? (object)DBNull.Value : stipendFrequency);
                        cmdS.Parameters.AddWithValue("@fund", reg.ScholarshipFundSource ?? "Government");
                        cmdS.Parameters.AddWithValue("@renewal", reg.RenewalConditions ?? "Minimum GPA of 2.5, No failing grades");
                        cmdS.Parameters.AddWithValue("@enroll", reg.EnrollmentDate ?? DateTime.Now);
                        cmdS.Parameters.AddWithValue("@grad", reg.ExpectedGraduation ?? DateTime.Now.AddYears(4));
                        cmdS.Parameters.AddWithValue("@bank", reg.BankName ?? "");
                        cmdS.Parameters.AddWithValue("@acct", reg.BankAccountNumber ?? "");

                        int newScholarId = Convert.ToInt32(cmdS.ExecuteScalar());

                        // Create user account
                        string password = GenerateScholarPassword(reg.FirstName, reg.LastName);
                        MySqlCommand cmdU = new MySqlCommand(@"INSERT INTO users (username, password, role, name, account_status, created_at) 
                                                      VALUES (@un, @pw, 'SCHOLAR', @nm, 'Active', NOW()); SELECT LAST_INSERT_ID();", conn, tr);
                        cmdU.Parameters.AddWithValue("@un", studentId);
                        cmdU.Parameters.AddWithValue("@pw", password);
                        cmdU.Parameters.AddWithValue("@nm", fullName);
                        int userId = Convert.ToInt32(cmdU.ExecuteScalar());
                        new MySqlCommand($"UPDATE scholars SET user_id = {userId} WHERE id = {newScholarId}", conn, tr).ExecuteNonQuery();

                        // Create compliance records and copy files
                        string[] dbTypes = { "PSA Birth Certificate", "Enrollment Form", "COR", "Grades", "Scholarship Contract" };
                        string[] descriptions = { "Submit PSA Birth Certificate", "Certificate of Enrollment (current semester)", "Certificate of Registration", "Latest grades and transcript of records", "Signed and notarized scholarship contract" };
                        string[] docKeys = { "PSA", "COE", "COR", "Grades", "Contract" };

                        var fileMapping = new Dictionary<string, string>
                {
                    { "PSA", reg.FilePSA },
                    { "COE", reg.FileCOE },
                    { "COR", reg.FileCOR },
                    { "Grades", reg.FileGrades },
                    { "Contract", reg.FileContract }
                };

                        string uploadSourcePath = @"C:\xampp\htdocs\skolaraid\";

                        for (int i = 0; i < dbTypes.Length; i++)
                        {
                            string type = dbTypes[i];
                            string docKey = docKeys[i];
                            string registrationFilePath = fileMapping.ContainsKey(docKey) ? fileMapping[docKey] : null;
                            bool hasFile = !string.IsNullOrEmpty(registrationFilePath);
                            string compStatus = hasFile ? "Submitted" : "Pending";

                            string insComp = @"INSERT INTO compliance_records (scholar_id, requirement_type, description, due_date, status) 
                                      VALUES (@sid, @type, @desc, @due, @status); SELECT LAST_INSERT_ID();";
                            MySqlCommand cmdComp = new MySqlCommand(insComp, conn, tr);
                            cmdComp.Parameters.AddWithValue("@sid", newScholarId);
                            cmdComp.Parameters.AddWithValue("@type", type);
                            cmdComp.Parameters.AddWithValue("@desc", descriptions[i]);
                            cmdComp.Parameters.AddWithValue("@due", DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"));
                            cmdComp.Parameters.AddWithValue("@status", compStatus);
                            int compId = Convert.ToInt32(cmdComp.ExecuteScalar());

                            if (hasFile)
                            {
                                try
                                {
                                    string sourceFile = Path.Combine(uploadSourcePath, registrationFilePath.Replace("/", "\\"));
                                    if (File.Exists(sourceFile))
                                    {
                                        byte[] fileData = File.ReadAllBytes(sourceFile);
                                        string fileName = Path.GetFileName(registrationFilePath);
                                        string fileExt = Path.GetExtension(registrationFilePath).ToLower();

                                        string insFile = @"INSERT INTO file_attachments (scholar_id, compliance_id, file_name, original_name, file_type, file_size, file_data, uploaded_by) 
                                                  VALUES (@sid, @cid, @fn, @on, @ft, @sz, @data, @uploadedBy)";
                                        MySqlCommand cmdFile = new MySqlCommand(insFile, conn, tr);
                                        cmdFile.Parameters.AddWithValue("@sid", newScholarId);
                                        cmdFile.Parameters.AddWithValue("@cid", compId);
                                        cmdFile.Parameters.AddWithValue("@fn", fileName);
                                        cmdFile.Parameters.AddWithValue("@on", fileName);
                                        cmdFile.Parameters.AddWithValue("@ft", fileExt);
                                        cmdFile.Parameters.AddWithValue("@sz", fileData.Length);
                                        cmdFile.Parameters.AddWithValue("@data", fileData);
                                        cmdFile.Parameters.AddWithValue("@uploadedBy", SessionManager.CurrentUser?.Id ?? 1);
                                        cmdFile.ExecuteNonQuery();

                                        new MySqlCommand($"UPDATE compliance_records SET file_path = @fp WHERE id = {compId}", conn, tr)
                                            .Parameters.AddWithValue("@fp", fileName);
                                        new MySqlCommand($"UPDATE compliance_records SET file_path = @fp WHERE id = {compId}", conn, tr).ExecuteNonQuery();
                                    }
                                }
                                catch (Exception fileEx)
                                {
                                    System.Diagnostics.Debug.WriteLine($"Error copying file {docKey}: {fileEx.Message}");
                                }
                            }
                        }

                        // Update registration status
                        new MySqlCommand($"UPDATE scholar_registrations SET status = 'Approved' WHERE id = {reg.Id}", conn, tr).ExecuteNonQuery();
                        tr.Commit();

                        // Send welcome email using EmailService
                        bool emailSent = _emailService.SendWelcomeEmail(reg.Email, fullName, schNum, studentId, password);

                        string message = $"✅ Registration approved!\n\n👤 {fullName}\n🔢 {schNum}\n💵 Stipend: ₱{stipendAmount:N2} / {stipendFrequency}";
                        if (emailSent)
                            message += $"\n📧 Login details sent to {reg.Email}";
                        else
                            message += $"\n⚠️ Failed to send email to {reg.Email}";

                        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRegistrations(); LoadStatistics();
                        txtRegDetailInfo.Text = "";
                        lblRegDetailTitle.Text = "Select a registration to view details";
                        lblRegDetailTitle.ForeColor = Color.Gray;
                        btnApproveReg.Tag = null; btnRejectReg.Tag = null;
                        btnApproveReg.Enabled = false; btnRejectReg.Enabled = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnRejectReg_Click(object sender, EventArgs e)
        {
            var reg = btnRejectReg.Tag as RegistrationItem;
            if (reg == null) return;

            Form reasonForm = new Form
            {
                Text = "Rejection Reason",
                Size = new Size(650, 350), // Increased width from 500 to 550, height from 300 to 350
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblReason = new Label
            {
                Text = "Please provide a reason for rejection.\nThis will be sent to the applicant via email:",
                Font = new Font("Century Gothic", 10F),
                Location = new Point(20, 15),
                Size = new Size(490, 40) // Increased size
            };

            Label lblEmail = new Label
            {
                Text = reg.Email,
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                Location = new Point(20, 55),
                AutoSize = true
            };

            TextBox txtReason = new TextBox
            {
                Multiline = true,
                Location = new Point(20, 80),
                Size = new Size(490, 120), // Increased width from 440 to 490, height from 100 to 120
                Font = new Font("Century Gothic", 10F),
                ScrollBars = ScrollBars.Vertical
            };

            CheckBox chkSend = new CheckBox
            {
                Text = "Send rejection email to applicant",
                Location = new Point(20, 210), // Adjusted Y position
                Size = new Size(250, 24),
                Font = new Font("Century Gothic", 10F),
                Checked = true
            };

            FrameworkTest.SATAButton btnSub = new FrameworkTest.SATAButton
            {
                ButtonText = "Submit Rejection",
                Location = new Point(370, 215), // Adjusted position
                Size = new Size(140, 40),
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                NormalBackground = Color.FromArgb(239, 68, 68),
                NormalForeColor = Color.White,
                HoverBackground = Color.FromArgb(200, 40, 40),
                Rounding = new Padding(8),
                TextAutoCenter = true
            };

            btnSub.Click += (s, ev) =>
            {
                string reason = txtReason.Text.Trim();
                if (string.IsNullOrWhiteSpace(reason))
                {
                    MessageBox.Show("Please enter a rejection reason.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // FIXED: Properly parameterize the SQL query
                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(
                            "UPDATE scholar_registrations SET status = 'Rejected', rejection_reason = @r WHERE id = @id",
                            conn
                        );
                        cmd.Parameters.AddWithValue("@r", reason);
                        cmd.Parameters.AddWithValue("@id", reg.Id);
                        cmd.ExecuteNonQuery();
                    }

                    // Send rejection email using EmailService
                    bool emailSent = false;
                    if (chkSend.Checked)
                    {
                        emailSent = _emailService.SendRejectionEmail(
                            reg.Email,
                            $"{reg.FirstName} {reg.LastName}",
                            reason
                        );
                    }

                    string message = $"Registration rejected.\nReason: {reason}";
                    if (chkSend.Checked)
                    {
                        message += emailSent
                            ? $"\n📧 Rejection email sent to {reg.Email}"
                            : $"\n⚠️ Failed to send rejection email to {reg.Email}";
                    }

                    MessageBox.Show(message, "Registration Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reasonForm.Close();
                    LoadRegistrations();
                    LoadStatistics();
                    txtRegDetailInfo.Text = "";
                    lblRegDetailTitle.Text = "Select a registration to view details";
                    lblRegDetailTitle.ForeColor = Color.Gray;
                    btnApproveReg.Tag = null;
                    btnRejectReg.Tag = null;
                    btnApproveReg.Enabled = false;
                    btnRejectReg.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error rejecting registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            reasonForm.Controls.Add(lblReason);
            reasonForm.Controls.Add(lblEmail);
            reasonForm.Controls.Add(txtReason);
            reasonForm.Controls.Add(chkSend);
            reasonForm.Controls.Add(btnSub);
            reasonForm.ShowDialog();
        }

        private string GenerateScholarPassword(string fn, string ln)
        {
            string np = fn.Length >= 3 ? fn.Substring(0, 3) : fn.PadRight(3, 'X');
            string lp = ln.Length >= 3 ? ln.Substring(0, 3) : ln.PadRight(3, 'X');
            char[] sc = { '@', '#', '$', '&', '*', '!' };
            Random rng = new Random();
            return char.ToUpper(np[0]) + np.Substring(1).ToLower() + sc[rng.Next(sc.Length)] + char.ToUpper(lp[0]) + lp.Substring(1).ToLower() + sc[rng.Next(sc.Length)];
        }

        #endregion

        #region Navigation

        private void btnDashboard_Click(object sender, EventArgs e) { new FrmAdminDashboard().Show(); this.Hide(); }
        private void btnScholarMgmt_Click(object sender, EventArgs e) { new FrmScholarManagement().Show(); this.Hide(); }
        private void btnPayroll_Click(object sender, EventArgs e) { new FrmPayrollProcessing().Show(); this.Hide(); }
        private void btnReports_Click(object sender, EventArgs e) { new FrmReportsAnalytics().Show(); this.Hide(); }
        private void btnActivityLog_Click(object sender, EventArgs e) { new FrmActivityLogs().Show(); this.Hide(); }
        private void btnLogout_Click(object sender, EventArgs e) { SessionManager.ClearSession(); new Login().Show(); this.Close(); }

        #endregion

        #region Designer Events

        private void sataButton1_Click(object sender, EventArgs e) => btnDashboard_Click(sender, e);
        private void sataButton1_Click_1(object sender, EventArgs e) => btnDashboard_Click(sender, e);
        private void sataButton2_Click_1(object sender, EventArgs e) => btnScholarMgmt_Click(sender, e);
        private void sataButton2_Click_2(object sender, EventArgs e) => btnScholarMgmt_Click(sender, e);
        private void sataButton3_Click(object sender, EventArgs e) => btnPayroll_Click(sender, e);
        private void sataButton3_Click_1(object sender, EventArgs e) => btnPayroll_Click(sender, e);
        private void sataButton4_Click(object sender, EventArgs e) => btnReports_Click(sender, e);
        private void sataButton4_Click_1(object sender, EventArgs e) => btnReports_Click(sender, e);
        private void sataButton5_Click(object sender, EventArgs e) => btnActivityLog_Click(sender, e);
        private void sataButton6_Click(object sender, EventArgs e) { }
        private void btnActivityLog_Click_1(object sender, EventArgs e) => btnActivityLog_Click(sender, e);
        private void panelHeader_Paint(object sender, PaintEventArgs e) { }

        #endregion
    }

    // Email Service Class
    public class EmailService
    {
        private const string SMTP_HOST = "smtp.gmail.com";
        private const int SMTP_PORT = 587;
        private const string SENDER_EMAIL = "kylealba0624@gmail.com";
        private const string SENDER_PASSWORD = "yygwothvzhrwvajv";
        private const string SENDER_NAME = "Legacy College of Compostela - ScholarAid";

        public bool SendWelcomeEmail(string email, string fullName, string scholarNumber, string studentId, string password)
        {
            try
            {
                using (MailMessage m = new MailMessage())
                {
                    m.From = new MailAddress(SENDER_EMAIL, SENDER_NAME);
                    m.To.Add(email);
                    m.Subject = $"ScholarAid - Registration Approved - {fullName}";
                    m.IsBodyHtml = true;
                    m.Body = $@"<html>
                    <body style='font-family: Arial, sans-serif;'>
                        <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                            <h2 style='color: #00444F;'>Welcome to ScholarAid, {fullName}!</h2>
                            <p>Your scholarship registration has been approved. Here are your login credentials:</p>
                            <div style='background-color: #f5f5f5; padding: 15px; border-radius: 5px; margin: 20px 0;'>
                                <p><strong>Scholar Number:</strong> {scholarNumber}</p>
                                <p><strong>Username:</strong> {studentId}</p>
                                <p><strong>Password:</strong> {password}</p>
                            </div>
                            <p style='color: #666;'>Please change your password after your first login for security purposes.</p>
                            <p style='color: #666;'>If you have any questions, please contact the Scholarship Office.</p>
                        </div>
                    </body>
                    </html>";

                    using (SmtpClient smtp = new SmtpClient(SMTP_HOST, SMTP_PORT))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);
                        smtp.Send(m);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Email error: {ex.Message}");
                return false;
            }
        }

        public bool SendRejectionEmail(string email, string fullName, string reason)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SENDER_EMAIL, SENDER_NAME);
                    mail.To.Add(email);
                    mail.Subject = $"ScholarAid - Registration Update";
                    mail.IsBodyHtml = true;
                    mail.Body = $@"<html>
                    <body style='font-family: Arial, sans-serif;'>
                        <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                            <h3 style='color: #00444F;'>Dear {fullName},</h3>
                            <p>We regret to inform you that your scholarship registration has not been approved.</p>
                            <div style='background-color: #f5f5f5; padding: 15px; border-radius: 5px; margin: 20px 0;'>
                                <p><strong>Reason for Rejection:</strong></p>
                                <p>{reason}</p>
                            </div>
                            <p style='color: #666;'>If you have any questions or would like to appeal this decision, please contact the Scholarship Office.</p>
                        </div>
                    </body>
                    </html>";

                    using (SmtpClient smtp = new SmtpClient(SMTP_HOST, SMTP_PORT))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);
                        smtp.Send(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Rejection email error: {ex.Message}");
                return false;
            }
        }
    }

    public class NotificationItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public string SenderName { get; set; }
        public string RecipientName { get; set; }
        public string ScholarNumber { get; set; }
    }

    public class RegistrationItem
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        // NEW FIELDS
        public string Program { get; set; }
        public string HEI { get; set; }
        public string DegreeProgram { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime? ExpectedGraduation { get; set; }
        public decimal? StipendAmount { get; set; }
        public string StipendFrequency { get; set; }
        public string ScholarshipFundSource { get; set; }
        public string RenewalConditions { get; set; }
        // END NEW FIELDS
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public int ScholarshipTypeId { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string FilePSA { get; set; }
        public string FileCOE { get; set; }
        public string FileCOR { get; set; }
        public string FileGrades { get; set; }
        public string FileContract { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public string RejectionReason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}