using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SkolarAid.form.Scholar
{
    public partial class FrmScholarDashboard : Form
    {
        private int _scholarId;
        private string _scholarName;
        private string _scholarNumber;

        public FrmScholarDashboard(int scholarId, string scholarName, string scholarNumber)
        {
            InitializeComponent();
            _scholarId = scholarId;
            _scholarName = scholarName;
            _scholarNumber = scholarNumber;
        
        }

        private void FrmScholarDashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            lblWelcome.Text = $"Welcome back, {_scholarName}! 👋";
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            lblRole.Text = _scholarName;

            SetupStatsIcons();
            LoadDashboardData();

            // Wire navigation buttons
            btnDashboard.Click += (s, ev) => { }; // Already on dashboard
            btnProfile.Click += (s, ev) => { new FrmScholarProfile(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnPayments.Click += (s, ev) => { new FrmPaymentHistory(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnCompliance.Click += (s, ev) => { new FrmScholarCompliance(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnNotifications.Click += (s, ev) => { new FrmScholarNotifications(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnViewAllPayments.Click += (s, ev) => { new FrmPaymentHistory(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnViewAllCompliance.Click += (s, ev) => { new FrmScholarCompliance(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };

            // Wire logout buttons
            btnLogout.Click += BtnLogout_Click;
            sataButton1.Click += BtnLogout_Click;
        }

        private void SetupStatsIcons()
        {
            picTotalStipend.Image = Properties.Resources.dollar;
            picTotalStipend.SizeMode = PictureBoxSizeMode.Zoom;

            picNextPayment.Image = Properties.Resources.dollar;
            picNextPayment.SizeMode = PictureBoxSizeMode.Zoom;

            picScholarship.Image = Properties.Resources.scholar;
            picScholarship.SizeMode = PictureBoxSizeMode.Zoom;

            picCompliance.Image = Properties.Resources.file;
            picCompliance.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.ClearSession();
            new Login().Show();
            this.Close();
        }

        private void LoadDashboardData()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string scholarQuery = @"SELECT s.stipend_frequency, st.name AS scholarship_name, 
                                           st.stipend_amount AS scholarship_stipend
                                           FROM scholars s
                                           LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                                           WHERE s.id = @scholarId";
                    MySqlCommand cmd = new MySqlCommand(scholarQuery, conn);
                    cmd.Parameters.AddWithValue("@scholarId", _scholarId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string scholarshipName = reader["scholarship_name"]?.ToString() ?? "N/A";
                            if (scholarshipName.Length > 20)
                                scholarshipName = scholarshipName.Substring(0, 18) + "...";
                            lblScholarshipType.Text = scholarshipName;

                            decimal stipend = reader["scholarship_stipend"] != DBNull.Value ?
                                Convert.ToDecimal(reader["scholarship_stipend"]) : 0;
                            lblNextPayment.Text = $"₱{stipend:N0}";

                            string frequency = reader["stipend_frequency"]?.ToString() ?? "Monthly";
                            lblNextPaymentDate.Text = GetNextPaymentDate(frequency);
                        }
                        else
                        {
                            lblScholarshipType.Text = "N/A";
                            lblNextPayment.Text = "₱0";
                            lblNextPaymentDate.Text = "N/A";
                        }
                    }

                    string totalQuery = @"SELECT COALESCE(SUM(amount), 0) FROM payments 
                                         WHERE scholar_id = @scholarId AND status = 'Released'";
                    MySqlCommand cmdTotal = new MySqlCommand(totalQuery, conn);
                    cmdTotal.Parameters.AddWithValue("@scholarId", _scholarId);
                    object totalResult = cmdTotal.ExecuteScalar();
                    decimal totalStipend = Convert.ToDecimal(totalResult);
                    lblTotalStipend.Text = $"₱{totalStipend:N0}";

                    string compQuery = @"SELECT 
                                        COUNT(*) AS total,
                                        SUM(CASE WHEN status IN ('Approved','Submitted') THEN 1 ELSE 0 END) AS completed
                                        FROM compliance_records WHERE scholar_id = @scholarId";
                    MySqlCommand cmdComp = new MySqlCommand(compQuery, conn);
                    cmdComp.Parameters.AddWithValue("@scholarId", _scholarId);
                    using (MySqlDataReader reader = cmdComp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int total = Convert.ToInt32(reader["total"]);
                            int completed = reader["completed"] != DBNull.Value ?
                                Convert.ToInt32(reader["completed"]) : 0;
                            int rate = total > 0 ? (completed * 100) / total : 0;
                            lblComplianceRate.Text = $"{rate}%";
                            progressCompliance.Value = rate > 100 ? 100 : rate;
                        }
                    }

                    LoadRecentPayments(conn);
                    LoadComplianceOverview(conn);
                    LoadRecentNotifications(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetNextPaymentDate(string frequency)
        {
            DateTime now = DateTime.Now;
            switch (frequency?.ToLower())
            {
                case "weekly":
                    return now.AddDays(7).ToString("MMM dd, yyyy");
                case "bi-weekly":
                    return now.AddDays(14).ToString("MMM dd, yyyy");
                case "monthly":
                    return new DateTime(now.Year, now.Month, 1).AddMonths(1).ToString("MMM dd, yyyy");
                case "quarterly":
                    int currentQuarter = ((now.Month - 1) / 3) + 1;
                    int nextQuarterMonth = (currentQuarter * 3) + 1;
                    if (nextQuarterMonth > 12) nextQuarterMonth = 1;
                    DateTime nextQuarter = new DateTime(now.Year, nextQuarterMonth, 1);
                    if (nextQuarter <= now) nextQuarter = nextQuarter.AddYears(1);
                    return nextQuarter.ToString("MMM dd, yyyy");
                case "semester":
                case "semi-annual":
                    if (now.Month <= 6)
                        return new DateTime(now.Year, 7, 1).ToString("MMM dd, yyyy");
                    else
                        return new DateTime(now.Year + 1, 1, 1).ToString("MMM dd, yyyy");
                case "annual":
                case "annually":
                    return new DateTime(now.Year + 1, 1, 1).ToString("MMM dd, yyyy");
                default:
                    return new DateTime(now.Year, now.Month, 1).AddMonths(1).ToString("MMM dd, yyyy");
            }
        }

        private void LoadRecentPayments(MySqlConnection conn)
        {
            string query = @"SELECT payment_period, amount, status, release_date 
                            FROM payments WHERE scholar_id = @scholarId 
                            ORDER BY created_at DESC LIMIT 5";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@scholarId", _scholarId);
            dgvRecentPayments.Rows.Clear();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int row = dgvRecentPayments.Rows.Add();
                    dgvRecentPayments.Rows[row].Cells["colPeriod"].Value = reader["payment_period"].ToString();
                    dgvRecentPayments.Rows[row].Cells["colAmount"].Value =
                        $"₱{Convert.ToDecimal(reader["amount"]):N2}";
                    string status = reader["status"].ToString();
                    dgvRecentPayments.Rows[row].Cells["colStatus"].Value = status;
                    dgvRecentPayments.Rows[row].Cells["colReleaseDate"].Value =
                        reader["release_date"] != DBNull.Value ?
                        Convert.ToDateTime(reader["release_date"]).ToString("MMM dd, yyyy") : "Pending";

                    DataGridViewCell statusCell = dgvRecentPayments.Rows[row].Cells["colStatus"];
                    if (status == "Released")
                        statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                    else if (status == "Processing")
                        statusCell.Style.ForeColor = Color.FromArgb(0, 123, 255);
                    else if (status == "Pending")
                        statusCell.Style.ForeColor = Color.FromArgb(255, 170, 0);
                    else
                        statusCell.Style.ForeColor = Color.Gray;
                }
            }
        }

        private void LoadComplianceOverview(MySqlConnection conn)
        {
            panelRequirement1.Visible = false;
            panelRequirement2.Visible = false;
            panelRequirement3.Visible = false;

            var oldFlow = panelCompliance.Controls["flowCompliance"] as FlowLayoutPanel;
            if (oldFlow != null)
                panelCompliance.Controls.Remove(oldFlow);

            FlowLayoutPanel flowCompliance = new FlowLayoutPanel
            {
                Name = "flowCompliance",
                Location = new Point(10, 55),
                Size = new Size(panelCompliance.Width - 20, panelCompliance.Height - 65),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.White
            };
            panelCompliance.Controls.Add(flowCompliance);

            btnViewAllCompliance.BringToFront();

            string query = @"SELECT requirement_type, description, status, due_date, date_submitted 
                            FROM compliance_records 
                            WHERE scholar_id = @scholarId 
                            ORDER BY 
                                CASE status 
                                    WHEN 'Overdue' THEN 0 
                                    WHEN 'Rejected' THEN 1
                                    WHEN 'Pending' THEN 2 
                                    WHEN 'Submitted' THEN 3 
                                    WHEN 'Approved' THEN 4 
                                    ELSE 5 
                                END, 
                                due_date ASC";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@scholarId", _scholarId);

            bool hasRecords = false;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    hasRecords = true;
                    Panel reqPanel = CreateComplianceItem(
                        reader["requirement_type"].ToString(),
                        reader["description"].ToString(),
                        reader["status"].ToString(),
                        Convert.ToDateTime(reader["due_date"]),
                        reader["date_submitted"] != DBNull.Value ?
                            (DateTime?)Convert.ToDateTime(reader["date_submitted"]) : null
                    );
                    flowCompliance.Controls.Add(reqPanel);
                }
            }

            if (!hasRecords)
            {
                Label lblNoCompliance = new Label
                {
                    Text = "No compliance requirements found.",
                    Font = new Font("Century Gothic", 10F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(120, 120, 120),
                    Location = new Point(10, 10),
                    AutoSize = true
                };
                flowCompliance.Controls.Add(lblNoCompliance);
            }
        }

        private Panel CreateComplianceItem(string type, string description, string status,
            DateTime dueDate, DateTime? dateSubmitted)
        {
            int panelWidth = panelCompliance.Width - 45;

            Panel panel = new Panel
            {
                Width = panelWidth,
                Height = 58,
                BackColor = Color.FromArgb(250, 250, 250),
                Margin = new Padding(0, 0, 0, 4)
            };

            Color statusColor;
            switch (status)
            {
                case "Approved": statusColor = Color.FromArgb(40, 167, 69); break;
                case "Submitted": statusColor = Color.FromArgb(0, 123, 255); break;
                case "Pending": statusColor = Color.FromArgb(255, 170, 0); break;
                case "Overdue": statusColor = Color.FromArgb(239, 68, 68); break;
                case "Rejected": statusColor = Color.FromArgb(220, 50, 50); break;
                default: statusColor = Color.Gray; break;
            }

            Panel colorBar = new Panel
            {
                Width = 4,
                Height = 58,
                BackColor = statusColor,
                Location = new Point(0, 0)
            };

            Label lblName = new Label
            {
                Text = type,
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(12, 6),
                Size = new Size(panelWidth - 120, 18),
                BackColor = Color.Transparent
            };

            string descText = description != null && description.Length > 40 ?
                description.Substring(0, 37) + "..." : (description ?? "");
            Label lblDesc = new Label
            {
                Text = descText,
                Font = new Font("Century Gothic", 8F),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(12, 24),
                Size = new Size(panelWidth - 120, 14),
                BackColor = Color.Transparent
            };

            string dueText = $"Due: {dueDate:MMM dd, yyyy}";
            if (dateSubmitted.HasValue)
                dueText += $"  •  Submitted: {dateSubmitted.Value:MMM dd, yyyy}";

            Label lblDue = new Label
            {
                Text = dueText,
                Font = new Font("Century Gothic", 8F),
                ForeColor = Color.FromArgb(120, 120, 120),
                Location = new Point(12, 40),
                Size = new Size(panelWidth - 120, 14),
                BackColor = Color.Transparent
            };

            Label lblStatus = new Label
            {
                Text = status,
                Font = new Font("Century Gothic", 8F, FontStyle.Bold),
                ForeColor = statusColor,
                Location = new Point(panelWidth - 90, 20),
                Size = new Size(80, 20),
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.Transparent
            };

            panel.Controls.Add(colorBar);
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblDesc);
            panel.Controls.Add(lblDue);
            panel.Controls.Add(lblStatus);

            return panel;
        }

        private void LoadRecentNotifications(MySqlConnection conn)
        {
            string query = @"SELECT id, title, message, notification_type, date_created, is_read 
                            FROM notifications 
                            WHERE recipient_id = @scholarId 
                            ORDER BY date_created DESC LIMIT 3";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@scholarId", _scholarId);

            var notifPanels = new[] { panelNotification1, panelNotification2, panelNotification3 };
            var titleLabels = new[] { lblNotif1Title, lblNotif2Title, lblNotif3Title };
            var msgLabels = new[] { lblNotif1Message, lblNotif2Message, lblNotif3Message };
            var timeLabels = new[] { lblNotif1Time, lblNotif2Time, lblNotif3Time };

            foreach (var p in notifPanels) p.Visible = false;

            int index = 0;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read() && index < 3)
                {
                    notifPanels[index].Visible = true;
                    titleLabels[index].Text = reader["title"].ToString();
                    string msg = reader["message"].ToString();
                    msgLabels[index].Text = msg.Length > 50 ? msg.Substring(0, 47) + "..." : msg;
                    DateTime sent = Convert.ToDateTime(reader["date_created"]);
                    timeLabels[index].Text = GetRelativeTime(sent);
                    bool isRead = reader["is_read"] != DBNull.Value && Convert.ToBoolean(reader["is_read"]);
                    notifPanels[index].BackColor = isRead ?
                        Color.FromArgb(250, 250, 250) : Color.FromArgb(235, 245, 245);
                    index++;
                }
            }
        }

        private string GetRelativeTime(DateTime dateTime)
        {
            var ts = DateTime.Now - dateTime;
            if (ts.TotalMinutes < 1) return "Just now";
            if (ts.TotalMinutes < 60) return $"{(int)ts.TotalMinutes}m ago";
            if (ts.TotalHours < 24) return $"{(int)ts.TotalHours}h ago";
            if (ts.TotalDays < 7) return $"{(int)ts.TotalDays}d ago";
            return dateTime.ToString("MMM dd");
        }

        private void panelContent_Paint(object sender, PaintEventArgs e) { }
        private void panelHeader_Paint(object sender, PaintEventArgs e) { }

        private void lblBrand_Click(object sender, EventArgs e)
        {

        }
    }
}