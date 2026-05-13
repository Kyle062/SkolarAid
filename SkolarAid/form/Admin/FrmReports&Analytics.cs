using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form;
using SkolarAid.form.Admin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SkolarAid
{
    public partial class FrmReportsAnalytics : Form
    {
        private Chart chartScholarshipDist;
        private Chart chartCourseDist;
        private Chart chartMonthlyDisbursement;

        public FrmReportsAnalytics()
        {
            InitializeComponent();
            InitializeCharts();
            this.Load += FrmReportsAnalytics_Load;
            this.Resize += FrmReportsAnalytics_Resize;
        }

        private void FrmReportsAnalytics_Resize(object sender, EventArgs e)
        {
            AdjustLayoutForFullscreen();
        }

        private void AdjustLayoutForFullscreen()
        {
            int screenWidth = this.ClientSize.Width;
            int screenHeight = this.ClientSize.Height;

            if (tabControlReports != null)
            {
                tabControlReports.Location = new Point(301, 100);
                tabControlReports.Size = new Size(screenWidth - 321, screenHeight - 130);
            }

            if (tabControlReports != null)
            {
                int tabWidth = tabControlReports.Width - 40;
                int chartPanelWidth = (tabWidth - 80) / 3;

                // Position chart panels evenly across the width
                if (panelChartScholarship != null)
                {
                    panelChartScholarship.Location = new Point(20, 45);
                    panelChartScholarship.Size = new Size(chartPanelWidth, panelCharts.Height - 65);
                }
                if (panelChartCourse != null)
                {
                    panelChartCourse.Location = new Point(30 + chartPanelWidth, 45);
                    panelChartCourse.Size = new Size(chartPanelWidth, panelCharts.Height - 65);
                }
                if (panelChartPayments != null)
                {
                    panelChartPayments.Location = new Point(40 + chartPanelWidth * 2, 45);
                    panelChartPayments.Size = new Size(chartPanelWidth, panelCharts.Height - 65);
                }

                // Adjust charts to fill their panels
                if (chartScholarshipDist != null && panelChartScholarship != null)
                {
                    chartScholarshipDist.Size = new Size(panelChartScholarship.Width - 20, panelChartScholarship.Height - 55);
                    chartScholarshipDist.Location = new Point(10, 45);
                }
                if (chartCourseDist != null && panelChartCourse != null)
                {
                    chartCourseDist.Size = new Size(panelChartCourse.Width - 20, panelChartCourse.Height - 55);
                    chartCourseDist.Location = new Point(10, 45);
                }
                if (chartMonthlyDisbursement != null && panelChartPayments != null)
                {
                    chartMonthlyDisbursement.Size = new Size(panelChartPayments.Width - 20, panelChartPayments.Height - 55);
                    chartMonthlyDisbursement.Location = new Point(10, 45);
                }

                if (panelReportPreview != null)
                    panelReportPreview.Size = new Size(tabWidth - 50, tabControlReports.Height - 160);
                if (dgvReportData != null && panelReportPreview != null)
                    dgvReportData.Size = new Size(panelReportPreview.Width - 10, panelReportPreview.Height - 10);
                if (panelCharts != null)
                    panelCharts.Size = new Size(tabWidth - 50, tabControlReports.Height - 250);
                if (panelStatsCards != null)
                    panelStatsCards.Size = new Size(tabWidth - 50, 160);
            }
        }

        private void FrmReportsAnalytics_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            dtpDateFrom.Value = DateTime.Now.AddMonths(-6);
            dtpDateTo.Value = DateTime.Now;

            if (cmbReportType.Items.Count > 0) cmbReportType.SelectedIndex = 0;

            // Update scholar courses to approved list (run once)
            UpdateScholarCourses();

            LoadFilterOptions();
            LoadAnalyticsData();

            btnRefreshAnalytics.Click += BtnRefreshAnalytics_Click;
            btnGenerateReport.Click += BtnGenerateReport_Click;
            btnExportPDF.Click += BtnExportPDF_Click;
            btnExportExcel.Click += BtnExportExcel_Click;
            btnPrint.Click += BtnPrint_Click;

            AdjustLayoutForFullscreen();
        }

        /// <summary>
        /// Updates all scholars with old course names to the new approved course names
        /// </summary>
        private void UpdateScholarCourses()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Mapping of old course names to new approved course names
                    var courseMapping = new Dictionary<string, string>
                    {
                        { "BS Computer Science", "Bachelor of Science in Information Technology" },
                        { "BS Information Systems", "Bachelor of Science in Information Technology" },
                        { "BS Information Technology", "Bachelor of Science in Information Technology" },
                        { "BS Business Administration", "Bachelor of Science in Business Administration (Major in Financial Management)" },
                        { "BS Education", "Bachelor of Elementary Education (Generalist)" },
                        { "BS Elementary Education", "Bachelor of Elementary Education (Generalist)" },
                        { "BS Criminology", "Bachelor of Science in Criminology" },
                        { "BS Tourism Management", "Bachelor of Science in Tourism Management" },
                        { "BS Accountancy", "Bachelor of Science in Business Administration (Major in Financial Management)" },
                        { "BS Civil Engineering", "Bachelor of Science in Information Technology" },
                        { "BS Nursing", "Bachelor of Science in Information Technology" },
                        { "BS Hospitality Management", "Bachelor of Science in Tourism Management" },
                        { "BS Psychology", "Bachelor of Secondary Education (Major in Values Education)" },
                        { "BS Agriculture", "Bachelor of Science in Information Technology" },
                        { "BS Social Work", "Bachelor of Secondary Education (Major in Social Studies)" },
                        { "BS Biology", "Bachelor of Secondary Education (Major in Values Education)" },
                        { "BS Medical Technology", "Bachelor of Science in Information Technology" },
                        { "BS Physical Education", "Bachelor of Secondary Education (Major in Values Education)" },
                        { "BS Music Education", "Bachelor of Secondary Education (Major in English)" },
                        { "BA Communication", "Bachelor of Secondary Education (Major in English)" },
                        { "BA Broadcasting", "Bachelor of Secondary Education (Major in English)" },
                        { "BS Entrepreneurship", "Bachelor of Science in Business Administration (Major in Marketing Management)" },
                        { "BS Environmental Science", "Bachelor of Science in Information Technology" },
                        { "BS Marketing Management", "Bachelor of Science in Business Administration (Major in Marketing Management)" }
                    };

                    int updatedCount = 0;
                    foreach (var mapping in courseMapping)
                    {
                        string updateQuery = "UPDATE scholars SET course = @newCourse, degree_program = @newCourse WHERE course = @oldCourse";
                        MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@newCourse", mapping.Value);
                        cmd.Parameters.AddWithValue("@oldCourse", mapping.Key);
                        updatedCount += cmd.ExecuteNonQuery();
                    }

                    if (updatedCount > 0)
                    {
                        Console.WriteLine($"Updated {updatedCount} scholar courses to approved list.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating scholar courses: {ex.Message}");
            }
        }

        private void InitializeCharts()
        {
            panelChartScholarship.Controls.Clear();
            panelChartCourse.Controls.Clear();
            panelChartPayments.Controls.Clear();

            // ========== SCHOLARSHIP DISTRIBUTION CHART (PIE with counts) ==========
            chartScholarshipDist = new Chart
            {
                Dock = DockStyle.None,
                BackColor = Color.White,
                Location = new Point(10, 45),
                Size = new Size(panelChartScholarship.Width - 20, panelChartScholarship.Height - 55)
            };

            ChartArea pieArea = new ChartArea("MainArea")
            {
                BackColor = Color.White,
                Position = new ElementPosition(3, 5, 94, 80)
            };
            chartScholarshipDist.ChartAreas.Add(pieArea);

            chartScholarshipDist.Legends.Add(new Legend
            {
                Docking = Docking.Bottom,
                Font = new Font("Century Gothic", 7F),
                BackColor = Color.Transparent,
                Alignment = StringAlignment.Center
            });

            panelChartScholarship.Controls.Add(chartScholarshipDist);

            // ========== COURSE DISTRIBUTION CHART (DONUT with counts) ==========
            chartCourseDist = new Chart
            {
                Dock = DockStyle.None,
                BackColor = Color.White,
                Location = new Point(10, 45),
                Size = new Size(panelChartCourse.Width - 20, panelChartCourse.Height - 55)
            };

            ChartArea donutArea = new ChartArea("MainArea")
            {
                BackColor = Color.White,
                Position = new ElementPosition(3, 5, 94, 80)
            };
            chartCourseDist.ChartAreas.Add(donutArea);

            chartCourseDist.Legends.Add(new Legend
            {
                Docking = Docking.Bottom,
                Font = new Font("Century Gothic", 7F),
                BackColor = Color.Transparent,
                Alignment = StringAlignment.Center
            });

            panelChartCourse.Controls.Add(chartCourseDist);

            // ========== MONTHLY DISBURSEMENT CHART ==========
            chartMonthlyDisbursement = new Chart
            {
                Dock = DockStyle.None,
                BackColor = Color.White,
                Location = new Point(10, 45),
                Size = new Size(panelChartPayments.Width - 20, panelChartPayments.Height - 55)
            };

            ChartArea lineArea = new ChartArea("MainArea")
            {
                BackColor = Color.White,
                Position = new ElementPosition(5, 5, 90, 75)
            };
            lineArea.AxisX.LabelStyle.Angle = -45;
            lineArea.AxisX.LabelStyle.Font = new Font("Century Gothic", 7F);
            lineArea.AxisY.LabelStyle.Font = new Font("Century Gothic", 7F);
            lineArea.AxisY.LabelStyle.Format = "₱#,##0";
            lineArea.AxisX.Interval = 1;
            lineArea.AxisX.MajorGrid.Enabled = false;
            chartMonthlyDisbursement.ChartAreas.Add(lineArea);

            chartMonthlyDisbursement.Legends.Add(new Legend
            {
                Docking = Docking.Top,
                Font = new Font("Century Gothic", 7F),
                BackColor = Color.Transparent,
                Alignment = StringAlignment.Center
            });

            panelChartPayments.Controls.Add(chartMonthlyDisbursement);
        }

        #region Database Loading Methods

        private void LoadFilterOptions()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Load ACTIVE scholarship types only
                    string scholarshipQuery = "SELECT id, name FROM scholarship_types WHERE is_active = TRUE ORDER BY name";
                    MySqlCommand cmd = new MySqlCommand(scholarshipQuery, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbFilterScholarship.Items.Clear();
                        cmbFilterScholarship.Items.Add("All Scholarships");
                        while (reader.Read())
                            cmbFilterScholarship.Items.Add(reader["name"].ToString());
                    }

                    // Load approved courses
                    cmbFilterCourse.Items.Clear();
                    cmbFilterCourse.Items.Add("All Courses");
                    cmbFilterCourse.Items.AddRange(new object[] {
                        "Bachelor of Science in Business Administration (Major in Financial Management)",
                        "Bachelor of Science in Business Administration (Major in Marketing Management)",
                        "Bachelor of Science in Business Administration (Major in Human Resource Management)",
                        "Bachelor of Science in Criminology",
                        "Bachelor of Elementary Education (Generalist)",
                        "Bachelor of Secondary Education (Major in English)",
                        "Bachelor of Secondary Education (Major in Social Studies)",
                        "Bachelor of Secondary Education (Major in Values Education)",
                        "Bachelor of Science in Information Technology",
                        "Bachelor of Science in Tourism Management"
                    });

                    // Status filter
                    cmbFilterStatus.Items.Clear();
                    cmbFilterStatus.Items.Add("All Status");
                    cmbFilterStatus.Items.Add("Active");
                    cmbFilterStatus.Items.Add("Inactive");
                    cmbFilterStatus.Items.Add("Probation");
                    cmbFilterStatus.Items.Add("Suspended");
                    cmbFilterStatus.Items.Add("Graduated");
                    cmbFilterStatus.Items.Add("Terminated");
                    cmbFilterStatus.Items.Add("Withdrawn");
                    cmbFilterStatus.Items.Add("Expelled");
                    cmbFilterStatus.Items.Add("Completed");
                    cmbFilterStatus.Items.Add("Dropped");
                }

                if (cmbFilterScholarship.Items.Count > 0) cmbFilterScholarship.SelectedIndex = 0;
                if (cmbFilterCourse.Items.Count > 0) cmbFilterCourse.SelectedIndex = 0;
                if (cmbFilterStatus.Items.Count > 0) cmbFilterStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading filter options: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAnalyticsData()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    LoadStatisticsCards(conn);
                    LoadScholarshipDistributionChart(conn);
                    LoadCourseDistributionChart(conn);
                    LoadMonthlyDisbursementChart(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading analytics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatisticsCards(MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM scholars WHERE status = 'Active'", conn);
            lblTotalScholarsValue.Text = cmd.ExecuteScalar().ToString();

            cmd = new MySqlCommand("SELECT COUNT(*) FROM scholars WHERE status = 'Active'", conn);
            lblActiveScholarsValue.Text = cmd.ExecuteScalar().ToString();

            cmd = new MySqlCommand("SELECT COALESCE(SUM(amount), 0) FROM payments WHERE status = 'Released'", conn);
            decimal disbursed = Convert.ToDecimal(cmd.ExecuteScalar());
            lblTotalDisbursedValue.Text = $"₱{disbursed:N0}";

            cmd = new MySqlCommand("SELECT COUNT(*) FROM payments WHERE status IN ('Pending', 'Processed')", conn);
            lblPendingPaymentsValue.Text = cmd.ExecuteScalar().ToString();
        }

        private void LoadScholarshipDistributionChart(MySqlConnection conn)
        {
            string query = @"SELECT st.name, COUNT(s.id) as scholar_count
                            FROM scholarship_types st
                            LEFT JOIN scholars s ON st.id = s.scholarship_type_id AND s.status = 'Active'
                            WHERE st.is_active = TRUE
                            GROUP BY st.id, st.name
                            ORDER BY scholar_count DESC";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                chartScholarshipDist.Series.Clear();

                Series series = new Series("Distribution")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    Label = "#VALX\n(#VALY scholars)", // Show name and count
                    Font = new Font("Century Gothic", 8F, FontStyle.Bold)
                };
                chartScholarshipDist.Series.Add(series);

                Color[] colors = {
                    Color.FromArgb(0, 68, 79),
                    Color.FromArgb(40, 167, 69),
                    Color.FromArgb(255, 193, 7),
                    Color.FromArgb(0, 123, 255),
                    Color.FromArgb(111, 66, 193),
                    Color.FromArgb(220, 53, 69)
                };
                int colorIndex = 0;

                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    int count = Convert.ToInt32(reader["scholar_count"]);
                    if (count > 0)
                    {
                        int idx = series.Points.AddXY(name, count);
                        series.Points[idx].Color = colors[colorIndex % colors.Length];
                        series.Points[idx].LegendText = $"{name} ({count} scholars)";
                        colorIndex++;
                    }
                }

                chartScholarshipDist.Titles.Clear();
                chartScholarshipDist.Titles.Add(new Title("Scholarship Distribution",
                    Docking.Top, new Font("Century Gothic", 10F, FontStyle.Bold), Color.FromArgb(0, 68, 79)));
            }
        }

        private void LoadCourseDistributionChart(MySqlConnection conn)
        {
            string query = @"SELECT course, COUNT(*) as scholar_count
                    FROM scholars 
                    WHERE status = 'Active' AND course IS NOT NULL
                    GROUP BY course
                    ORDER BY scholar_count DESC
                    LIMIT 10";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                chartCourseDist.Series.Clear();
                chartCourseDist.Legends.Clear();
                chartCourseDist.Titles.Clear();

                // Create and configure legend
                Legend legend = new Legend("CourseLegend")
                {
                    Docking = Docking.Bottom,           // Position at bottom
                    Alignment = StringAlignment.Center, // Center the legend items
                    Font = new Font("Century Gothic", 9F),
                    BackColor = Color.Transparent,
                    BorderColor = Color.Transparent,
                    TableStyle = LegendTableStyle.Wide, // Wide layout (horizontal)
                    IsTextAutoFit = true,
                    TextWrapThreshold = 30
                };
                chartCourseDist.Legends.Add(legend);

                Series series = new Series("By Course")
                {
                    ChartType = SeriesChartType.Doughnut,
                    IsValueShownAsLabel = true,
                    Label = "#VALX\n(#VALY scholars)",
                    Font = new Font("Century Gothic", 8F, FontStyle.Bold)
                };
                chartCourseDist.Series.Add(series);

                Color[] colors = {
            Color.FromArgb(0, 68, 79),
            Color.FromArgb(40, 167, 69),
            Color.FromArgb(255, 193, 7),
            Color.FromArgb(0, 123, 255),
            Color.FromArgb(111, 66, 193),
            Color.FromArgb(220, 53, 69),
            Color.FromArgb(23, 162, 184),
            Color.FromArgb(255, 140, 0),
            Color.FromArgb(75, 192, 192),
            Color.FromArgb(153, 102, 255)
        };
                int colorIndex = 0;

                while (reader.Read())
                {
                    string course = reader["course"].ToString();
                    if (course.Length > 28) course = course.Substring(0, 26) + "..";
                    int count = Convert.ToInt32(reader["scholar_count"]);
                    if (count > 0)
                    {
                        int idx = series.Points.AddXY(course, count);
                        series.Points[idx].Color = colors[colorIndex % colors.Length];
                        series.Points[idx].LegendText = $"{course} ({count})";
                        colorIndex++;
                    }
                }

                chartCourseDist.Titles.Add(new Title("Scholars by Course",
                    Docking.Top, new Font("Century Gothic", 10F, FontStyle.Bold), Color.FromArgb(0, 68, 79)));
            }
        }

        private void LoadMonthlyDisbursementChart(MySqlConnection conn)
        {
            string query = @"SELECT DATE_FORMAT(release_date, '%b %Y') as month_label,
                                    DATE_FORMAT(release_date, '%Y-%m') as month_sort,
                                    SUM(amount) as total_amount
                             FROM payments 
                             WHERE status = 'Released' 
                             AND release_date BETWEEN @dateFrom AND @dateTo
                             GROUP BY DATE_FORMAT(release_date, '%b %Y'), DATE_FORMAT(release_date, '%Y-%m')
                             ORDER BY month_sort ASC";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@dateFrom", dtpDateFrom.Value);
            cmd.Parameters.AddWithValue("@dateTo", dtpDateTo.Value);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                chartMonthlyDisbursement.Series.Clear();

                Series columnSeries = new Series("Disbursement")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.FromArgb(0, 68, 79),
                    IsValueShownAsLabel = true,
                    LabelFormat = "₱#,##0",
                    Font = new Font("Century Gothic", 7F)
                };
                chartMonthlyDisbursement.Series.Add(columnSeries);

                Series lineSeries = new Series("Trend")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.FromArgb(239, 68, 68),
                    BorderWidth = 2,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 6,
                    MarkerColor = Color.FromArgb(239, 68, 68)
                };
                chartMonthlyDisbursement.Series.Add(lineSeries);

                while (reader.Read())
                {
                    string month = reader["month_label"].ToString();
                    decimal amount = Convert.ToDecimal(reader["total_amount"]);
                    columnSeries.Points.AddXY(month, amount);
                    lineSeries.Points.AddXY(month, amount);
                }

                chartMonthlyDisbursement.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chartMonthlyDisbursement.ChartAreas[0].AxisX.Interval = 1;

                chartMonthlyDisbursement.Titles.Clear();
                chartMonthlyDisbursement.Titles.Add(new Title("Monthly Disbursement Trend",
                    Docking.Top, new Font("Century Gothic", 10F, FontStyle.Bold), Color.FromArgb(0, 68, 79)));
            }
        }

        private void GenerateReport()
        {
            string reportType = cmbReportType.SelectedItem?.ToString() ?? "";
            string dateFrom = dtpDateFrom.Value.ToString("yyyy-MM-dd");
            string dateTo = dtpDateTo.Value.ToString("yyyy-MM-dd");

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = GetReportQuery(reportType);

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                    cmd.Parameters.AddWithValue("@dateTo", dateTo);

                    if (cmbFilterStatus.SelectedIndex > 0)
                        cmd.Parameters.AddWithValue("@status", cmbFilterStatus.SelectedItem.ToString());
                    if (cmbFilterScholarship.SelectedIndex > 0)
                        cmd.Parameters.AddWithValue("@scholarship", cmbFilterScholarship.SelectedItem.ToString());
                    if (cmbFilterCourse.SelectedIndex > 0)
                        cmd.Parameters.AddWithValue("@course", cmbFilterCourse.SelectedItem.ToString());

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dgvReportData.DataSource = dt;

                    dgvReportData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 68, 79);
                    dgvReportData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvReportData.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
                    dgvReportData.ColumnHeadersHeight = 40;
                    dgvReportData.DefaultCellStyle.Font = new Font("Century Gothic", 9F);
                    dgvReportData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvReportData.EnableHeadersVisualStyles = false;

                    MessageBox.Show($"Report generated successfully!\n\nTotal Records: {dt.Rows.Count}",
                        "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ActivityLogger.Log("GENERATE_REPORT", $"Generated {reportType} report with {dt.Rows.Count} records");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetReportQuery(string reportType)
        {
            string statusFilter = cmbFilterStatus.SelectedIndex > 0 ? " AND s.status = @status" : "";
            string scholarshipFilter = cmbFilterScholarship.SelectedIndex > 0 ? " AND st.name = @scholarship" : "";
            string courseFilter = cmbFilterCourse.SelectedIndex > 0 ? " AND s.course = @course" : "";

            switch (reportType)
            {
                case "Scholar Census Report":
                    return $@"SELECT s.scholar_number AS 'Scholar #', 
                                    CONCAT(s.first_name, ' ', s.last_name) AS 'Name',
                                    s.course AS 'Course', s.year_level AS 'Year',
                                    COALESCE(st.name, 'Not Assigned') AS 'Scholarship', 
                                    s.status AS 'Status'
                             FROM scholars s
                             LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                             WHERE s.created_at BETWEEN @dateFrom AND @dateTo{statusFilter}{scholarshipFilter}{courseFilter}
                             ORDER BY s.id";

                case "Payroll Summary Report":
                    return @"SELECT payment_period AS 'Period', 
                                    COUNT(*) AS 'Total Payments',
                                    SUM(amount) AS 'Total Amount',
                                    status AS 'Status'
                             FROM payments
                             WHERE release_date BETWEEN @dateFrom AND @dateTo
                             GROUP BY payment_period, status
                             ORDER BY payment_period DESC";

                case "Compliance Report":
                    return $@"SELECT s.scholar_number AS 'Scholar #',
                                    CONCAT(s.first_name, ' ', s.last_name) AS 'Name',
                                    s.course AS 'Course',
                                    cr.requirement_type AS 'Requirement',
                                    cr.status AS 'Status',
                                    cr.due_date AS 'Due Date',
                                    cr.date_submitted AS 'Date Submitted',
                                    cr.remarks AS 'Remarks'
                             FROM compliance_records cr
                             JOIN scholars s ON cr.scholar_id = s.id
                             LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                             WHERE 1=1{scholarshipFilter}{courseFilter}
                             ORDER BY s.last_name, cr.requirement_type";

                case "Payment History Report":
                    return @"SELECT s.scholar_number AS 'Scholar #',
                                    CONCAT(s.first_name, ' ', s.last_name) AS 'Name',
                                    p.payment_period AS 'Period',
                                    p.amount AS 'Amount',
                                    p.status AS 'Status',
                                    p.release_date AS 'Release Date',
                                    p.payment_method AS 'Method'
                             FROM payments p
                             JOIN scholars s ON p.scholar_id = s.id
                             WHERE p.release_date BETWEEN @dateFrom AND @dateTo
                             ORDER BY p.release_date DESC";

                case "Activity Log Report":
                    return @"SELECT user_name AS 'User',
                                    action_type AS 'Action',
                                    details AS 'Details',
                                    created_at AS 'Timestamp'
                             FROM activity_logs
                             WHERE created_at BETWEEN @dateFrom AND @dateTo
                             ORDER BY created_at DESC";

                default:
                    return @"SELECT scholar_number AS 'Scholar #',
                                    CONCAT(first_name, ' ', last_name) AS 'Name',
                                    course AS 'Course', status AS 'Status'
                             FROM scholars ORDER BY id";
            }
        }

        #endregion

        #region Export Methods

        private void ExportToHTMLAndOpen(bool autoPrint = false)
        {
            if (dgvReportData.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string fileName = Path.Combine(Path.GetTempPath(), $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                string reportTitle = cmbReportType.SelectedItem?.ToString() ?? "Report";
                string dateRange = $"{dtpDateFrom.Value:MMMM dd, yyyy} - {dtpDateTo.Value:MMMM dd, yyyy}";

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("<!DOCTYPE html>");
                    sw.WriteLine("<html><head><meta charset='UTF-8'><title>" + reportTitle + "</title>");
                    sw.WriteLine("<style>");
                    sw.WriteLine("@page { size: landscape; margin: 15mm; }");
                    sw.WriteLine("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 20px; background: #fff; }");
                    sw.WriteLine(".header { display: flex; align-items: center; border-bottom: 2px solid #00444F; padding-bottom: 15px; margin-bottom: 20px; }");
                    sw.WriteLine(".logo-container img { width: 80px; height: 80px; margin-right: 20px; }");
                    sw.WriteLine(".title-section { text-align: center; flex-grow: 1; }");
                    sw.WriteLine("h1 { color: #00444F; font-size: 20px; margin: 0; }");
                    sw.WriteLine("h3 { color: #666; font-size: 14px; margin: 5px 0; }");
                    sw.WriteLine(".info-bar { background: #e8f4f4; padding: 10px; border-radius: 5px; margin: 15px 0; }");
                    sw.WriteLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; font-size: 10px; }");
                    sw.WriteLine("th { background-color: #00444F; color: white; padding: 8px 6px; text-align: left; font-weight: bold; font-size: 10px; }");
                    sw.WriteLine("td { padding: 6px; border-bottom: 1px solid #ddd; }");
                    sw.WriteLine("tr:nth-child(even) { background-color: #f9f9f9; }");
                    sw.WriteLine(".footer { margin-top: 30px; display: flex; justify-content: space-between; }");
                    sw.WriteLine(".signature-box { text-align: center; width: 45%; }");
                    sw.WriteLine(".sig-line { border-top: 1px solid #000; margin: 50px 20px 5px 20px; }");
                    sw.WriteLine(".sig-name { font-weight: bold; }");
                    sw.WriteLine(".sig-title { font-size: 11px; color: #666; }");
                    sw.WriteLine("@media print { body { margin: 0.5in; } }");
                    sw.WriteLine("</style></head><body>");

                    sw.WriteLine("<div class='header'>");
                    sw.WriteLine("<div class='logo-container'><img src='file:///C:/Users/kylea/OneDrive/Desktop/SkolarAid/SkolarAid/Resources/LCC_Logo.png' alt='LCC Logo'/></div>");
                    sw.WriteLine("<div class='title-section'><h3>Legacy College of Compostela</h3><h1>" + reportTitle + "</h1><p style='color:#666;'>IskolarAid Scholarship Management System</p></div>");
                    sw.WriteLine("</div>");

                    sw.WriteLine("<div class='info-bar'><strong>Date Range:</strong> " + dateRange + " | <strong>Total Records:</strong> " + dgvReportData.Rows.Count + " | <strong>Generated:</strong> " + DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss") + "</div>");

                    sw.WriteLine("<table><tr>");
                    foreach (DataGridViewColumn col in dgvReportData.Columns)
                        sw.WriteLine("<th>" + col.HeaderText + "</th>");
                    sw.WriteLine("</tr>");

                    foreach (DataGridViewRow row in dgvReportData.Rows)
                    {
                        sw.WriteLine("<tr>");
                        foreach (DataGridViewCell cell in row.Cells)
                            sw.WriteLine("<td>" + WebUtility.HtmlEncode(cell.Value?.ToString() ?? "") + "</td>");
                        sw.WriteLine("</tr>");
                    }
                    sw.WriteLine("</table>");

                    sw.WriteLine("<div class='footer'>");
                    sw.WriteLine("<div class='signature-box'><div class='sig-line'></div><p class='sig-name'>MRS. WENDY ALCALA</p><p class='sig-title'>Scholarship Coordinator</p></div>");
                    sw.WriteLine("<div class='signature-box'><div class='sig-line'></div><p class='sig-name'>________________________</p><p class='sig-title'>HR Officer / Administrator</p></div>");
                    sw.WriteLine("</div>");

                    sw.WriteLine("<p style='text-align:center;color:#888;font-size:10px;margin-top:30px;'>Generated by IskolarAid System | Legacy College of Compostela | " + DateTime.Now.Year + "</p>");

                    if (autoPrint) sw.WriteLine("<script>window.onload = function() { window.print(); }</script>");
                    sw.WriteLine("</body></html>");
                }

                Process.Start(fileName);
                ActivityLogger.Log("EXPORT", $"Exported {reportTitle} to HTML");
            }
            catch (Exception ex) { MessageBox.Show($"Error exporting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ExportToCSV()
        {
            if (dgvReportData.Rows.Count == 0) { MessageBox.Show("No data to export.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV File|*.csv"; sfd.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            for (int i = 0; i < dgvReportData.Columns.Count; i++) { sw.Write(dgvReportData.Columns[i].HeaderText); if (i < dgvReportData.Columns.Count - 1) sw.Write(","); }
                            sw.WriteLine();
                            foreach (DataGridViewRow row in dgvReportData.Rows)
                            {
                                for (int i = 0; i < dgvReportData.Columns.Count; i++) { string v = row.Cells[i].Value?.ToString() ?? ""; if (v.Contains(",")) v = $"\"{v}\""; sw.Write(v); if (i < dgvReportData.Columns.Count - 1) sw.Write(","); }
                                sw.WriteLine();
                            }
                        }
                        MessageBox.Show($"Report exported!\nFile: {sfd.FileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActivityLogger.Log("EXPORT", $"Exported report to CSV: {sfd.FileName}");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Event Handlers
        private void BtnRefreshAnalytics_Click(object sender, EventArgs e) { LoadAnalyticsData(); }
        private void BtnGenerateReport_Click(object sender, EventArgs e) { GenerateReport(); }
        private void BtnExportPDF_Click(object sender, EventArgs e) { ExportToHTMLAndOpen(false); }
        private void BtnExportExcel_Click(object sender, EventArgs e) { ExportToCSV(); }
        private void BtnPrint_Click(object sender, EventArgs e) { ExportToHTMLAndOpen(true); }
        #endregion

        #region Navigation
        private void btnDashboard_Click(object sender, EventArgs e) { new FrmAdminDashboard().Show(); this.Hide(); }
        private void btnScholarMgmt_Click(object sender, EventArgs e) { new FrmScholarManagement().Show(); this.Hide(); }
        private void btnPayroll_Click(object sender, EventArgs e) { new FrmPayrollProcessing().Show(); this.Hide(); }
        private void btnActivityLog_Click(object sender, EventArgs e) { new FrmActivityLogs().Show(); this.Hide(); }
        private void btnReminder_Click(object sender, EventArgs e) { new FrmNotifications().Show(); this.Hide(); }
        private void btnLogout_Click(object sender, EventArgs e) { ActivityLogger.LogLogout(SessionManager.CurrentUser?.Id ?? 0, SessionManager.CurrentUser?.Name ?? ""); SessionManager.ClearSession(); new Login().Show(); this.Close(); }
        #endregion

        #region Designer Event Handlers
        private void FrmReports_Load(object sender, EventArgs e) { }
        private void sataButton1_Click(object sender, EventArgs e) => btnDashboard_Click(sender, e);
        private void sataButton2_Click(object sender, EventArgs e) => btnScholarMgmt_Click(sender, e);
        private void sataButton3_Click(object sender, EventArgs e) => btnPayroll_Click(sender, e);
        private void sataButton4_Click(object sender, EventArgs e) => btnReports_Click(sender, e);
        private void sataButton5_Click(object sender, EventArgs e) => btnActivityLog_Click(sender, e);
        private void sataButton6_Click(object sender, EventArgs e) => btnReminder_Click(sender, e);
        private void sataButtonLogout_Click(object sender, EventArgs e) => btnLogout_Click(sender, e);
        private void btnReports_Click(object sender, EventArgs e) { }
        #endregion

        #region Empty Event Handlers
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void ScholarAid_Click(object sender, EventArgs e) { }
        private void panelContent_Paint(object sender, PaintEventArgs e) { }
        private void panelHeader_Paint(object sender, PaintEventArgs e) { }
        #endregion
    }
}