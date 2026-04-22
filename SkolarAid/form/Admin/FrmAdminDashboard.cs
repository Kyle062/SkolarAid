using System;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using SkolarAid.Data;
using SkolarAid.Classes;
using System.Windows.Forms.DataVisualization.Charting;

namespace SkolarAid.form.Admin
{
    public partial class FrmAdminDashboard : Form
    {
        // Chart controls
        private Chart chartScholarshipDist;
        private Chart chartMonthlyDisbursement;
        private DataGridView dgvUpcomingPayments;
        private Panel panelActivityContainer;
        private Panel panelPaymentsContainer;

        public FrmAdminDashboard()
        {
            InitializeComponent();
            InitializeAdditionalControls();
            InitializeCharts();
            InitializeUpcomingPaymentsGrid();
            this.Load += Form1_Load;
        }

        private void InitializeAdditionalControls()
        {
            SATAUiFramework.BorderRadius borderRadius8 = new SATAUiFramework.BorderRadius();
            borderRadius8.BottomLeft = 15;
            borderRadius8.BottomRight = 15;
            borderRadius8.TopLeft = 15;
            borderRadius8.TopRight = 15;

            // ========== PANEL CHART 1 (PIE CHART) ==========
            this.panelChart1 = new SATAUiFramework.SATAPanel();
            this.panelChart1.BackColor = System.Drawing.Color.White;
            this.panelChart1.BackColor2 = System.Drawing.Color.White;
            this.panelChart1.BorderColor = System.Drawing.Color.Black;
            this.panelChart1.BorderRadius = borderRadius8;
            this.panelChart1.BorderThickness = 0;
            this.panelChart1.Location = new System.Drawing.Point(321, 340);
            this.panelChart1.Name = "panelChart1";
            this.panelChart1.Size = new System.Drawing.Size(600, 290);
            this.panelChart1.TabIndex = 10;

            Label lblChart1Title = new Label
            {
                Text = "📊 Scholarship Distribution",
                Location = new Point(15, 15),
                Font = new Font("Century Gothic", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                AutoSize = true
            };
            this.panelChart1.Controls.Add(lblChart1Title);

            // ========== PANEL CHART 2 (LINE/BAR CHART) ==========
            this.panelChart2 = new SATAUiFramework.SATAPanel();
            this.panelChart2.BackColor = System.Drawing.Color.White;
            this.panelChart2.BackColor2 = System.Drawing.Color.White;
            this.panelChart2.BorderColor = System.Drawing.Color.Black;
            this.panelChart2.BorderRadius = borderRadius8;
            this.panelChart2.BorderThickness = 0;
            this.panelChart2.Location = new System.Drawing.Point(1000, 340);
            this.panelChart2.Name = "panelChart2";
            this.panelChart2.Size = new System.Drawing.Size(680, 290);
            this.panelChart2.TabIndex = 11;

            Label lblChart2Title = new Label
            {
                Text = "📈 Monthly Disbursement Trend",
                Location = new Point(15, 15),
                Font = new Font("Century Gothic", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                AutoSize = true
            };
            this.panelChart2.Controls.Add(lblChart2Title);

            // ========== PANEL RECENT ACTIVITY (WITH SCROLL) ==========
            this.panelRecentActivity.Location = new System.Drawing.Point(321, 650);
            this.panelRecentActivity.Size = new System.Drawing.Size(600, 320);

            this.panelActivityContainer = new Panel();
            this.panelActivityContainer.Location = new Point(10, 50);
            this.panelActivityContainer.Size = new Size(580, 260);
            this.panelActivityContainer.AutoScroll = true;
            this.panelActivityContainer.BorderStyle = BorderStyle.None;
            this.panelRecentActivity.Controls.Add(this.panelActivityContainer);

            // ========== PANEL UPCOMING PAYMENTS ==========
            this.panelUpcomingPayments.Location = new System.Drawing.Point(1000, 650);
            this.panelUpcomingPayments.Size = new System.Drawing.Size(680, 320);

            // Add controls to form
            this.Controls.Add(this.panelChart1);
            this.Controls.Add(this.panelChart2);
        }

        private void InitializeCharts()
        {
            // ========== PIE CHART - Scholarship Distribution ==========
            chartScholarshipDist = new Chart
            {
                Location = new Point(70, 50),
                Size = new Size(450, 220),
                BackColor = Color.White,
                BorderlineColor = Color.FromArgb(200, 200, 200),
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderlineWidth = 1
            };

            ChartArea pieArea = new ChartArea("PieArea")
            {
                BackColor = Color.White
            };
            chartScholarshipDist.ChartAreas.Add(pieArea);

            chartScholarshipDist.Legends.Add(new Legend("Legend")
            {
                Docking = Docking.Bottom,
                Font = new Font("Century Gothic", 8F),
                BackColor = Color.Transparent
            });

            // ========== LINE/BAR CHART - Monthly Disbursement ==========
            chartMonthlyDisbursement = new Chart
            {
                Location = new Point(30, 50),
                Size = new Size(630, 220),
                BackColor = Color.White,
                BorderlineColor = Color.FromArgb(200, 200, 200),
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderlineWidth = 1
            };

            ChartArea lineArea = new ChartArea("LineArea")
            {
                BackColor = Color.White
            };
            lineArea.AxisX.Title = "Month";
            lineArea.AxisX.TitleFont = new Font("Century Gothic", 9F, FontStyle.Bold);
            lineArea.AxisX.LabelStyle.Font = new Font("Century Gothic", 8F);
            lineArea.AxisY.Title = "Amount (₱)";
            lineArea.AxisY.TitleFont = new Font("Century Gothic", 9F, FontStyle.Bold);
            lineArea.AxisY.LabelStyle.Font = new Font("Century Gothic", 8F);
            lineArea.AxisY.LabelStyle.Format = "₱#,##0";
            chartMonthlyDisbursement.ChartAreas.Add(lineArea);

            chartMonthlyDisbursement.Legends.Add(new Legend("Legend")
            {
                Docking = Docking.Top,
                Font = new Font("Century Gothic", 8F),
                BackColor = Color.Transparent
            });

            // Add charts to panels
            panelChart1.Controls.Add(chartScholarshipDist);
            panelChart2.Controls.Add(chartMonthlyDisbursement);
        }

        private void InitializeUpcomingPaymentsGrid()
        {
            // ========== DATAGRIDVIEW FOR UPCOMING PAYMENTS ==========
            dgvUpcomingPayments = new DataGridView
            {
                Location = new Point(15, 50),
                Size = new Size(700, 255),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                EnableHeadersVisualStyles = false,
                GridColor = Color.FromArgb(230, 230, 230),
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 35 }
            };

            dgvUpcomingPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // 👇 HEADER STYLE - Fixed color that won't change when clicking
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 68, 79),
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 11F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                SelectionBackColor = Color.FromArgb(0, 68, 79),  
                SelectionForeColor = Color.White                
            };

            dgvUpcomingPayments.ColumnHeadersDefaultCellStyle = headerStyle;

            // 👇 DEFAULT CELL STYLE - For data rows only (headers not affected)
            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Century Gothic", 10F),
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = Color.FromArgb(230, 245, 245),  
                SelectionForeColor = Color.Black,
                Padding = new Padding(5, 0, 0, 0)
            };

            dgvUpcomingPayments.DefaultCellStyle = defaultCellStyle;

            // 👇 Also set individual column header cells to prevent selection color change
            dgvUpcomingPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvUpcomingPayments.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 68, 79);
            dgvUpcomingPayments.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Add columns
            dgvUpcomingPayments.Columns.Add("colScholar", "Scholar");
            dgvUpcomingPayments.Columns.Add("colPeriod", "Period");
            dgvUpcomingPayments.Columns.Add("colAmount", "Amount");
            dgvUpcomingPayments.Columns.Add("colStatus", "Status");
            dgvUpcomingPayments.Columns.Add("colReleaseDate", "Release");

            // Set column widths
            dgvUpcomingPayments.Columns["colScholar"].Width = 180;
            dgvUpcomingPayments.Columns["colPeriod"].Width = 120;
            dgvUpcomingPayments.Columns["colAmount"].Width = 120;
            dgvUpcomingPayments.Columns["colAmount"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvUpcomingPayments.Columns["colAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvUpcomingPayments.Columns["colStatus"].Width = 110;
            dgvUpcomingPayments.Columns["colReleaseDate"].Width = 130;

            // 👇 CRITICAL: Prevent header highlighting when clicking rows
            dgvUpcomingPayments.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    // Force headers to maintain their original color
                    foreach (DataGridViewColumn col in dgvUpcomingPayments.Columns)
                    {
                        col.HeaderCell.Style.SelectionBackColor = Color.FromArgb(0, 68, 79);
                        col.HeaderCell.Style.SelectionForeColor = Color.White;
                    }
                }
            };

            // 👇 Also handle SelectionChanged event
            dgvUpcomingPayments.SelectionChanged += (sender, e) =>
            {
                // Reset header colors when selection changes
                foreach (DataGridViewColumn col in dgvUpcomingPayments.Columns)
                {
                    col.HeaderCell.Style.SelectionBackColor = Color.FromArgb(0, 68, 79);
                    col.HeaderCell.Style.SelectionForeColor = Color.White;
                }
            };

            panelUpcomingPayments.Controls.Add(dgvUpcomingPayments);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDashboardStats();
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            string adminName = SessionManager.CurrentUser?.Name ?? "Administrator";
            lblGreeting.Text = $"Welcome back, {adminName}! 👋";
        }

        private void LoadDashboardStats()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Stats Cards
                    string totalScholarsQuery = "SELECT COUNT(*) FROM scholars WHERE status = 'Active'";
                    MySqlCommand cmdTotal = new MySqlCommand(totalScholarsQuery, conn);
                    lblTotalScholars.Text = Convert.ToInt32(cmdTotal.ExecuteScalar()).ToString();

                    string activeScholarshipsQuery = "SELECT COUNT(*) FROM scholarship_types WHERE is_active = TRUE";
                    MySqlCommand cmdActive = new MySqlCommand(activeScholarshipsQuery, conn);
                    lblActiveScholarships.Text = Convert.ToInt32(cmdActive.ExecuteScalar()).ToString();

                    string totalDisbursedQuery = "SELECT COALESCE(SUM(amount), 0) FROM payments WHERE status = 'Released'";
                    MySqlCommand cmdDisbursed = new MySqlCommand(totalDisbursedQuery, conn);
                    decimal totalDisbursed = Convert.ToDecimal(cmdDisbursed.ExecuteScalar());
                    lblTotalDisbursed.Text = $"₱{totalDisbursed:N0}";

                    string pendingPaymentsQuery = "SELECT COUNT(*) FROM payments WHERE status IN ('Pending', 'Processed')";
                    MySqlCommand cmdPending = new MySqlCommand(pendingPaymentsQuery, conn);
                    lblPendingPayments.Text = Convert.ToInt32(cmdPending.ExecuteScalar()).ToString();

                    LoadRecentActivity(conn);
                    LoadUpcomingPaymentsGrid(conn);
                    LoadScholarshipDistributionChart(conn);
                    LoadMonthlyDisbursementChart(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentActivity(MySqlConnection conn)
        {
            string query = @"SELECT user_name, details, created_at 
                            FROM activity_logs 
                            ORDER BY created_at DESC 
                            LIMIT 15";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                panelActivityContainer.Controls.Clear();

                int yPos = 5;
                int index = 1;

                while (reader.Read())
                {
                    string userName = reader["user_name"]?.ToString() ?? "System";
                    string details = reader["details"]?.ToString() ?? "";
                    DateTime createdAt = Convert.ToDateTime(reader["created_at"]);
                    string timeAgo = GetRelativeTime(createdAt);
                    string activityText = $"{userName} {details}";
                    if (activityText.Length > 40) activityText = activityText.Substring(0, 37) + "...";

                    Label lblActivity = new Label
                    {
                        Name = "lblActivityList",
                        Text = $"• {activityText}",
                        Location = new Point(5, yPos),
                        Size = new Size(330, 25),
                        Font = new Font("Century Gothic", 9F),
                        ForeColor = Color.FromArgb(60, 60, 60),
                        AutoSize = false
                    };

                    Label lblTime = new Label
                    {
                        Name = "lblActivityList",
                        Text = timeAgo,
                        Location = new Point(340, yPos + 3),
                        Size = new Size(85, 20),
                        Font = new Font("Century Gothic", 8F),
                        ForeColor = Color.FromArgb(120, 120, 120),
                        TextAlign = ContentAlignment.TopRight
                    };

                    panelActivityContainer.Controls.Add(lblActivity);
                    panelActivityContainer.Controls.Add(lblTime);

                    yPos += 30;
                    index++;
                }

                if (index == 1)
                {
                    Label lblNoActivity = new Label
                    {
                        Text = "No recent activity found.",
                        Location = new Point(5, 5),
                        Size = new Size(430, 30),
                        Font = new Font("Century Gothic", 9F, FontStyle.Italic),
                        ForeColor = Color.FromArgb(120, 120, 120)
                    };
                    panelActivityContainer.Controls.Add(lblNoActivity);
                }
            }
        }

        private void LoadUpcomingPaymentsGrid(MySqlConnection conn)
        {
            string query = @"SELECT CONCAT(s.first_name, ' ', s.last_name) AS scholar_name, 
                                    p.payment_period, p.amount, p.status, p.release_date
                             FROM payments p
                             JOIN scholars s ON p.scholar_id = s.id
                             WHERE p.status IN ('Processed', 'Pending')
                             ORDER BY p.release_date ASC
                             LIMIT 15";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                dgvUpcomingPayments.Rows.Clear();
                while (reader.Read())
                {
                    string scholar = reader["scholar_name"]?.ToString() ?? "";
                    string period = reader["payment_period"]?.ToString() ?? "";
                    decimal amount = Convert.ToDecimal(reader["amount"]);
                    string status = reader["status"]?.ToString() ?? "";
                    string statusText = status == "Processed" ? "Processing" : status;
                    string releaseDate = reader["release_date"] != DBNull.Value ?
                        Convert.ToDateTime(reader["release_date"]).ToString("MMM dd") : "Pending";

                    int rowIndex = dgvUpcomingPayments.Rows.Add(scholar, period, amount, statusText, releaseDate);

                    if (status == "Processed")
                        dgvUpcomingPayments.Rows[rowIndex].Cells["colStatus"].Style.ForeColor = Color.FromArgb(255, 170, 0);
                    else
                        dgvUpcomingPayments.Rows[rowIndex].Cells["colStatus"].Style.ForeColor = Color.FromArgb(40, 167, 69);
                }
            }
        }

        private void LoadScholarshipDistributionChart(MySqlConnection conn)
        {
            string query = @"SELECT st.name, COUNT(s.id) as scholar_count
                            FROM scholarship_types st
                            LEFT JOIN scholars s ON st.id = s.scholarship_type_id AND s.status = 'Active'
                            WHERE st.is_active = TRUE
                            GROUP BY st.id, st.name
                            HAVING scholar_count > 0
                            ORDER BY scholar_count DESC";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                chartScholarshipDist.Series.Clear();
                Series series = new Series("ScholarshipDist")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    LabelFormat = "#PERCENT{P0}",
                    Font = new Font("Century Gothic", 8F, FontStyle.Bold)
                };
                chartScholarshipDist.Series.Add(series);

                Color[] colors = { Color.FromArgb(0, 68, 79), Color.FromArgb(40, 167, 69),
                                  Color.FromArgb(255, 193, 7), Color.FromArgb(0, 123, 255),
                                  Color.FromArgb(111, 66, 193), Color.FromArgb(239, 68, 68) };
                int colorIndex = 0;

                while (reader.Read())
                {
                    string name = reader["name"]?.ToString() ?? "Unknown";
                    int count = Convert.ToInt32(reader["scholar_count"]);
                    int idx = series.Points.AddXY(name, count);
                    series.Points[idx].Color = colors[colorIndex % colors.Length];
                    series.Points[idx].LegendText = $"{name} ({count})";
                    colorIndex++;
                }
            }
        }

        private void LoadMonthlyDisbursementChart(MySqlConnection conn)
        {
            string query = @"SELECT DATE_FORMAT(release_date, '%b') as month_label,
                                    DATE_FORMAT(release_date, '%Y-%m') as month_sort,
                                    SUM(amount) as total_amount
                             FROM payments 
                             WHERE status = 'Released' AND release_date >= DATE_SUB(NOW(), INTERVAL 6 MONTH)
                             GROUP BY DATE_FORMAT(release_date, '%b'), DATE_FORMAT(release_date, '%Y-%m')
                             ORDER BY month_sort ASC";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                chartMonthlyDisbursement.Series.Clear();

                Series barSeries = new Series("Disbursement")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.FromArgb(0, 68, 79),
                    IsValueShownAsLabel = false
                };
                chartMonthlyDisbursement.Series.Add(barSeries);

                Series lineSeries = new Series("Trend")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.FromArgb(239, 68, 68),
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 6,
                    MarkerColor = Color.FromArgb(239, 68, 68)
                };
                chartMonthlyDisbursement.Series.Add(lineSeries);

                while (reader.Read())
                {
                    string month = reader["month_label"]?.ToString() ?? "";
                    decimal amount = Convert.ToDecimal(reader["total_amount"]);
                    barSeries.Points.AddXY(month, amount);
                    lineSeries.Points.AddXY(month, amount);
                }
            }
        }

        private string GetRelativeTime(DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;
            if (timeSpan.TotalMinutes < 1) return "Just now";
            if (timeSpan.TotalMinutes < 60) return $"{(int)timeSpan.TotalMinutes}m ago";
            if (timeSpan.TotalHours < 24) return $"{(int)timeSpan.TotalHours}h ago";
            if (timeSpan.TotalDays < 7) return $"{(int)timeSpan.TotalDays}d ago";
            return dateTime.ToString("MMM dd");
        }

        #region Navigation
        private void sataButton2_Click(object sender, EventArgs e)
        {
            FrmScholarManagement scholar = new FrmScholarManagement();
            scholar.Show();
            this.Hide();
        }

        private void sataButton6_Click(object sender, EventArgs e)
        {
            FrmNotifications notifications = new FrmNotifications();
            notifications.Show();
            this.Hide();
        }

        private void sataButton5_Click(object sender, EventArgs e)
        {
            FrmActivityLogs activityLogs = new FrmActivityLogs();
            activityLogs.Show();
            this.Hide();
        }

        private void sataButton4_Click(object sender, EventArgs e)
        {
            FrmReportsAnalytics reportsAnalytics = new FrmReportsAnalytics();
            reportsAnalytics.Show();
            this.Hide();
        }

        private void sataButton3_Click(object sender, EventArgs e)
        {
            FrmPayrollProcessing payrollProcessing = new FrmPayrollProcessing();
            payrollProcessing.Show();
            this.Hide();
        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            LoadDashboardStats();
        }

        private void sataButton7_Click(object sender, EventArgs e)
        {
            ActivityLogger.LogLogout(SessionManager.CurrentUser?.Id ?? 0, SessionManager.CurrentUser?.Name ?? "");
            SessionManager.ClearSession();
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }
        #endregion

        #region Empty Event Handlers
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void sataPanel1_Paint(object sender, PaintEventArgs e) { }
        private void sataPanel2_Paint(object sender, PaintEventArgs e) { }
        private void sataPanel3_Paint(object sender, PaintEventArgs e) { }
        private void sataPanel4_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e) { }
        #endregion

        private void FrmAdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}