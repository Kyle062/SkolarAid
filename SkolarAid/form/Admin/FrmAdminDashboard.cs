
using SkolarAid.Classes;
using SkolarAid.Data;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace SkolarAid.form.Admin
{
    public partial class FrmAdminDashboard : Form
    {
        // Chart controls
        private Chart chartScholarshipDist;
        private Chart chartMonthlyDisbursement;
        private DataGridView dgvUpcomingPayments;
        private Panel panelActivityContainer;

        public FrmAdminDashboard()
        {
            InitializeComponent();
            InitializeAdditionalControls();
            InitializeCharts();
            InitializeUpcomingPaymentsGrid();
            this.Load += Form1_Load;
            this.Resize += FrmAdminDashboard_Resize;
        }

        private void FrmAdminDashboard_Resize(object sender, EventArgs e)
        {
            AdjustControlPositions();
        }

        private void AdjustControlPositions()
        {
            int screenWidth = this.ClientSize.Width;
            int screenHeight = this.ClientSize.Height;

            // Stats cards - horizontal row below greeting
            int statsY = 185;
            int statsCardWidth = (screenWidth - 320 - 60) / 4; // 4 cards with gaps

            if (panelStats1 != null)
            {
                panelStats1.Location = new Point(321, statsY);
                panelStats1.Size = new Size(statsCardWidth, 130);

                panelStats2.Location = new Point(321 + statsCardWidth + 15, statsY);
                panelStats2.Size = new Size(statsCardWidth, 130);

                panelStats3.Location = new Point(321 + (statsCardWidth + 15) * 2, statsY);
                panelStats3.Size = new Size(statsCardWidth, 130);

                panelStats4.Location = new Point(321 + (statsCardWidth + 15) * 3, statsY);
                panelStats4.Size = new Size(statsCardWidth, 130);
            }

            // CHARTS ROW - MADE BIGGER (60% of remaining height)
            int chartsY = 340;
            int availableHeight = screenHeight - chartsY - 30;
            int chartsHeight = (int)(availableHeight * 0.60); // 60% for charts
            int chartPanelWidth = (screenWidth - 320 - 40) / 2;

            if (panelChart1 != null)
            {
                panelChart1.Location = new Point(321, chartsY);
                panelChart1.Size = new Size(chartPanelWidth, chartsHeight);

                if (chartScholarshipDist != null)
                {
                    chartScholarshipDist.Location = new Point(20, 45);
                    chartScholarshipDist.Size = new Size(chartPanelWidth - 50, chartsHeight - 65);
                }
            }

            if (panelChart2 != null)
            {
                panelChart2.Location = new Point(321 + chartPanelWidth + 15, chartsY);
                panelChart2.Size = new Size(chartPanelWidth, chartsHeight);

                if (chartMonthlyDisbursement != null)
                {
                    chartMonthlyDisbursement.Location = new Point(20, 45);
                    chartMonthlyDisbursement.Size = new Size(chartPanelWidth - 50, chartsHeight - 65);
                }
            }

            // BOTTOM ROW - MADE SMALLER (40% of remaining height)
            int bottomY = chartsY + chartsHeight + 20;
            int bottomHeight = (int)(availableHeight * 0.40); // 40% for bottom panels
            int bottomPanelWidth = (screenWidth - 320 - 40) / 2;

            if (panelRecentActivity != null)
            {
                panelRecentActivity.Location = new Point(321, bottomY);
                panelRecentActivity.Size = new Size(bottomPanelWidth, bottomHeight);

                if (panelActivityContainer != null)
                    panelActivityContainer.Size = new Size(bottomPanelWidth - 20, bottomHeight - 60);
            }

            if (panelUpcomingPayments != null)
            {
                panelUpcomingPayments.Location = new Point(321 + bottomPanelWidth + 15, bottomY);
                panelUpcomingPayments.Size = new Size(bottomPanelWidth, bottomHeight);

                if (dgvUpcomingPayments != null)
                    dgvUpcomingPayments.Size = new Size(bottomPanelWidth - 30, bottomHeight - 70);
            }
        }

        private void InitializeAdditionalControls()
        {
            SATAUiFramework.BorderRadius borderRadius8 = new SATAUiFramework.BorderRadius();
            borderRadius8.BottomLeft = 15;
            borderRadius8.BottomRight = 15;
            borderRadius8.TopLeft = 15;
            borderRadius8.TopRight = 15;

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height - 80;

            // ========== PANEL CHART 1 (PIE CHART) ==========
            this.panelChart1 = new SATAUiFramework.SATAPanel();
            this.panelChart1.BackColor = Color.White;
            this.panelChart1.BackColor2 = Color.White;
            this.panelChart1.BorderColor = Color.Black;
            this.panelChart1.BorderRadius = borderRadius8;
            this.panelChart1.BorderThickness = 0;
            this.panelChart1.Location = new Point(321, 340);
            this.panelChart1.Name = "panelChart1";
            this.panelChart1.Size = new Size(600, 290);
            this.panelChart1.TabIndex = 10;

            Label lblChart1Title = new Label
            {
                Text = "📊 Scholarship Distribution",
                Location = new Point(15, 12),
                Font = new Font("Century Gothic", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                AutoSize = true
            };
            this.panelChart1.Controls.Add(lblChart1Title);

            // ========== PANEL CHART 2 (LINE/BAR CHART) ==========
            this.panelChart2 = new SATAUiFramework.SATAPanel();
            this.panelChart2.BackColor = Color.White;
            this.panelChart2.BackColor2 = Color.White;
            this.panelChart2.BorderColor = Color.Black;
            this.panelChart2.BorderRadius = borderRadius8;
            this.panelChart2.BorderThickness = 0;
            this.panelChart2.Location = new Point(950, 340);
            this.panelChart2.Name = "panelChart2";
            this.panelChart2.Size = new Size(680, 290);
            this.panelChart2.TabIndex = 11;

            Label lblChart2Title = new Label
            {
                Text = "📈 Monthly Disbursement Trend",
                Location = new Point(15, 12),
                Font = new Font("Century Gothic", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                AutoSize = true
            };
            this.panelChart2.Controls.Add(lblChart2Title);

            // ========== PANEL RECENT ACTIVITY (WITH SCROLL) - SMALLER ==========
            this.panelRecentActivity.Location = new Point(321, 650);
            this.panelRecentActivity.Size = new Size(600, 250);

            this.panelActivityContainer = new Panel();
            this.panelActivityContainer.Location = new Point(10, 50);
            this.panelActivityContainer.Size = new Size(580, 190);
            this.panelActivityContainer.AutoScroll = true;
            this.panelActivityContainer.BorderStyle = BorderStyle.None;
            this.panelRecentActivity.Controls.Add(this.panelActivityContainer);

            // ========== PANEL UPCOMING PAYMENTS - SMALLER ==========
            this.panelUpcomingPayments.Location = new Point(950, 650);
            this.panelUpcomingPayments.Size = new Size(680, 250);

            // Add controls to form
            this.Controls.Add(this.panelChart1);
            this.Controls.Add(this.panelChart2);
        }

        private void InitializeCharts()
        {
            // ========== PIE CHART - Scholarship Distribution ==========
            chartScholarshipDist = new Chart
            {
                Location = new Point(30, 50),
                Size = new Size(530, 220),
                BackColor = Color.White,
                BorderlineColor = Color.Transparent,
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderlineWidth = 0
            };

            ChartArea pieArea = new ChartArea("PieArea")
            {
                BackColor = Color.White
            };
            chartScholarshipDist.ChartAreas.Add(pieArea);

            Legend pieLegend = new Legend("Legend")
            {
                Docking = Docking.Right,
                Font = new Font("Century Gothic", 10F),
                BackColor = Color.Transparent,
                Alignment = StringAlignment.Center
            };
            chartScholarshipDist.Legends.Add(pieLegend);

            // ========== COLUMN + LINE CHART - Monthly Disbursement ==========
            chartMonthlyDisbursement = new Chart
            {
                Location = new Point(30, 50),
                Size = new Size(630, 220),
                BackColor = Color.White,
                BorderlineColor = Color.Transparent,
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderlineWidth = 0
            };

            ChartArea lineArea = new ChartArea("LineArea")
            {
                BackColor = Color.White
            };
            lineArea.AxisX.Title = "Month";
            lineArea.AxisX.TitleFont = new Font("Century Gothic", 10F, FontStyle.Bold);
            lineArea.AxisX.LabelStyle.Font = new Font("Century Gothic", 9F);
            lineArea.AxisX.LabelStyle.ForeColor = Color.FromArgb(80, 80, 80);
            lineArea.AxisY.Title = "Amount (₱)";
            lineArea.AxisY.TitleFont = new Font("Century Gothic", 10F, FontStyle.Bold);
            lineArea.AxisY.LabelStyle.Font = new Font("Century Gothic", 9F);
            lineArea.AxisY.LabelStyle.Format = "₱#,##0";
            lineArea.AxisY.LabelStyle.ForeColor = Color.FromArgb(80, 80, 80);
            lineArea.AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            lineArea.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            chartMonthlyDisbursement.ChartAreas.Add(lineArea);

            Legend lineLegend = new Legend("Legend")
            {
                Docking = Docking.Top,
                Font = new Font("Century Gothic", 9F),
                BackColor = Color.Transparent
            };
            chartMonthlyDisbursement.Legends.Add(lineLegend);

            // Add charts to panels
            panelChart1.Controls.Add(chartScholarshipDist);
            panelChart2.Controls.Add(chartMonthlyDisbursement);
        }

        private void InitializeUpcomingPaymentsGrid()
        {
            dgvUpcomingPayments = new DataGridView
            {
                Location = new Point(15, 50),
                Size = new Size(650, 185),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                EnableHeadersVisualStyles = false,
                GridColor = Color.FromArgb(230, 230, 230),
                ColumnHeadersHeight = 35,
                RowTemplate = { Height = 30 }
            };

            dgvUpcomingPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 68, 79),
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                SelectionBackColor = Color.FromArgb(0, 68, 79),
                SelectionForeColor = Color.White
            };
            dgvUpcomingPayments.ColumnHeadersDefaultCellStyle = headerStyle;

            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Century Gothic", 9F),
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = Color.FromArgb(230, 245, 245),
                SelectionForeColor = Color.Black,
                Padding = new Padding(5, 0, 0, 0)
            };
            dgvUpcomingPayments.DefaultCellStyle = defaultCellStyle;

            dgvUpcomingPayments.Columns.Add("colScholar", "Scholar");
            dgvUpcomingPayments.Columns.Add("colPeriod", "Period");
            dgvUpcomingPayments.Columns.Add("colAmount", "Amount");
            dgvUpcomingPayments.Columns.Add("colStatus", "Status");
            dgvUpcomingPayments.Columns.Add("colReleaseDate", "Release");

            dgvUpcomingPayments.Columns["colAmount"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvUpcomingPayments.Columns["colAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            panelUpcomingPayments.Controls.Add(dgvUpcomingPayments);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = false;

            LoadDashboardStats();
            AdjustControlPositions();

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
                            LIMIT 10";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                panelActivityContainer.Controls.Clear();

                int yPos = 5;
                int index = 1;
                int containerWidth = panelActivityContainer.Width - 25;

                while (reader.Read())
                {
                    string userName = reader["user_name"]?.ToString() ?? "System";
                    string details = reader["details"]?.ToString() ?? "";
                    DateTime createdAt = Convert.ToDateTime(reader["created_at"]);
                    string timeAgo = GetRelativeTime(createdAt);

                    // Create a panel for each activity item
                    Panel activityItem = new Panel
                    {
                        Location = new Point(5, yPos),
                        Size = new Size(containerWidth - 5, 40),
                        BackColor = index % 2 == 0 ? Color.FromArgb(248, 250, 252) : Color.White,
                        Cursor = Cursors.Default
                    };

                    // Activity icon indicator
                    Label lblIcon = new Label
                    {
                        Text = "●",
                        Location = new Point(5, 10),
                        Size = new Size(15, 20),
                        Font = new Font("Century Gothic", 10F),
                        ForeColor = Color.FromArgb(0, 68, 79),
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    activityItem.Controls.Add(lblIcon);

                    // User name
                    Label lblUser = new Label
                    {
                        Text = userName,
                        Location = new Point(22, 3),
                        Size = new Size(120, 18),
                        Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(0, 68, 79),
                        AutoSize = false
                    };
                    activityItem.Controls.Add(lblUser);

                    // Activity details
                    Label lblDetails = new Label
                    {
                        Text = details.Length > 50 ? details.Substring(0, 47) + "..." : details,
                        Location = new Point(22, 20),
                        Size = new Size(containerWidth - 160, 18),
                        Font = new Font("Century Gothic", 8F),
                        ForeColor = Color.FromArgb(100, 100, 100),
                        AutoSize = false
                    };
                    activityItem.Controls.Add(lblDetails);

                    // Time
                    Label lblTime = new Label
                    {
                        Text = timeAgo,
                        Location = new Point(containerWidth - 120, 10),
                        Size = new Size(110, 20),
                        Font = new Font("Century Gothic", 8F),
                        ForeColor = Color.FromArgb(150, 150, 150),
                        TextAlign = ContentAlignment.MiddleRight
                    };
                    activityItem.Controls.Add(lblTime);

                    panelActivityContainer.Controls.Add(activityItem);
                    yPos += 45;
                    index++;
                }

                if (index == 1)
                {
                    Label lblNoActivity = new Label
                    {
                        Text = "No recent activity found.",
                        Location = new Point(10, 15),
                        Size = new Size(containerWidth, 30),
                        Font = new Font("Century Gothic", 10F, FontStyle.Italic),
                        ForeColor = Color.FromArgb(150, 150, 150)
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
                             LIMIT 10";

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
                        Convert.ToDateTime(reader["release_date"]).ToString("MMM dd, yyyy") : "Pending";

                    int rowIndex = dgvUpcomingPayments.Rows.Add(scholar, period, amount, statusText, releaseDate);

                    if (status == "Processed")
                        dgvUpcomingPayments.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(255, 170, 0);
                    else if (status == "Pending")
                        dgvUpcomingPayments.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(40, 167, 69);
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
                            HAVING scholar_count >= 0
                            ORDER BY scholar_count DESC";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                chartScholarshipDist.Series.Clear();
                chartScholarshipDist.Titles.Clear();

                // Title
                Title chartTitle = new Title("Scholar Count by Scholarship Type",
                    Docking.Top,
                    new Font("Century Gothic", 12F, FontStyle.Bold),
                    Color.FromArgb(0, 68, 79));
                chartScholarshipDist.Titles.Add(chartTitle);

                Series series = new Series("ScholarshipDist")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    LabelFormat = "#VAL{D}",
                    Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                    BorderWidth = 2,
                    BorderColor = Color.White
                };
                chartScholarshipDist.Series.Add(series);

                // Modern color palette
                Color[] colors = {
                    Color.FromArgb(0, 68, 79),       // Dark teal
                    Color.FromArgb(33, 150, 243),    // Blue
                    Color.FromArgb(76, 175, 80),     // Green
                    Color.FromArgb(255, 152, 0),     // Orange
                    Color.FromArgb(156, 39, 176),    // Purple
                    Color.FromArgb(233, 30, 99),     // Pink
                    Color.FromArgb(0, 150, 136)      // Teal
                };

                int colorIndex = 0;
                bool hasData = false;

                while (reader.Read())
                {
                    string name = reader["name"]?.ToString() ?? "Unknown";
                    int count = Convert.ToInt32(reader["scholar_count"]);

                    if (count > 0 || !hasData) // Include empty types for completeness
                    {
                        int idx = series.Points.AddXY(name, count);
                        series.Points[idx].Color = colors[colorIndex % colors.Length];
                        series.Points[idx].LegendText = $"{name}: {count} scholar{(count != 1 ? "s" : "")}";
                        series.Points[idx].Label = count > 0 ? $"{count}" : "";
                        series.Points[idx].Font = new Font("Century Gothic", 10F, FontStyle.Bold);
                        colorIndex++;
                        if (count > 0) hasData = true;
                    }
                }

                // If no data, show message
                if (!hasData)
                {
                    chartScholarshipDist.Titles.Clear();
                    chartScholarshipDist.Titles.Add(new Title("No scholar data available",
                        Docking.Top,
                        new Font("Century Gothic", 12F, FontStyle.Italic),
                        Color.FromArgb(150, 150, 150)));
                }
            }
        }

        private void LoadMonthlyDisbursementChart(MySqlConnection conn)
        {
            string query = @"SELECT DATE_FORMAT(release_date, '%b %Y') as month_label,
                                    DATE_FORMAT(release_date, '%Y-%m') as month_sort,
                                    SUM(amount) as total_amount,
                                    COUNT(DISTINCT scholar_id) as scholar_count
                             FROM payments 
                             WHERE status = 'Released' AND release_date >= DATE_SUB(NOW(), INTERVAL 12 MONTH)
                             GROUP BY DATE_FORMAT(release_date, '%b %Y'), DATE_FORMAT(release_date, '%Y-%m')
                             ORDER BY month_sort ASC";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                chartMonthlyDisbursement.Series.Clear();
                chartMonthlyDisbursement.Titles.Clear();

                // Title
                Title chartTitle = new Title("Monthly Disbursement Summary (Last 12 Months)",
                    Docking.Top,
                    new Font("Century Gothic", 12F, FontStyle.Bold),
                    Color.FromArgb(0, 68, 79));
                chartMonthlyDisbursement.Titles.Add(chartTitle);

                // Column series for amount
                Series columnSeries = new Series("Total Amount")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.FromArgb(0, 68, 79),
                    IsValueShownAsLabel = true,
                    LabelFormat = "₱#,##0",
                    Font = new Font("Century Gothic", 8F, FontStyle.Bold),
                    LabelForeColor = Color.FromArgb(0, 68, 79)
                };
                chartMonthlyDisbursement.Series.Add(columnSeries);

                // Line series for trend
                Series lineSeries = new Series("Trend Line")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.FromArgb(255, 152, 0),
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 8,
                    MarkerColor = Color.FromArgb(255, 152, 0),
                    MarkerBorderColor = Color.White,
                    MarkerBorderWidth = 2
                };
                chartMonthlyDisbursement.Series.Add(lineSeries);

                bool hasData = false;
                while (reader.Read())
                {
                    string month = reader["month_label"]?.ToString() ?? "";
                    decimal amount = Convert.ToDecimal(reader["total_amount"]);

                    columnSeries.Points.AddXY(month, amount);
                    lineSeries.Points.AddXY(month, amount);

                    // Color the column based on value (higher = darker)
                    int colorIntensity = Math.Min(200, Math.Max(50, 200 - (int)(amount / 100)));
                    columnSeries.Points[columnSeries.Points.Count - 1].Color =
                        Color.FromArgb(0, colorIntensity / 2 + 20, colorIntensity);

                    hasData = true;
                }

                if (!hasData)
                {
                    chartMonthlyDisbursement.Titles.Clear();
                    chartMonthlyDisbursement.Titles.Add(new Title("No disbursement data available",
                        Docking.Top,
                        new Font("Century Gothic", 12F, FontStyle.Italic),
                        Color.FromArgb(150, 150, 150)));
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
            if (timeSpan.TotalDays < 30) return $"{(int)(timeSpan.TotalDays / 7)}w ago";
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
            AdjustControlPositions();
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

        private void FrmAdminDashboard_Load(object sender, EventArgs e) { }
    }
}