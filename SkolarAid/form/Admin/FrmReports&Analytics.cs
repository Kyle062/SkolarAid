using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form;
using SkolarAid.form.Admin;
using System;
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
        // Charts
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
            if (chartScholarshipDist != null)
            {
                chartScholarshipDist.Size = new Size(panelChartScholarship.Width - 20, panelChartScholarship.Height - 55);
                chartCourseDist.Size = new Size(panelChartCourse.Width - 20, panelChartCourse.Height - 55);
                chartMonthlyDisbursement.Size = new Size(panelChartPayments.Width - 20, panelChartPayments.Height - 55);
            }
        }

        private void FrmReportsAnalytics_Load(object sender, EventArgs e)
        {
            // Set default date range
            dtpDateFrom.Value = DateTime.Now.AddMonths(-6);
            dtpDateTo.Value = DateTime.Now;

            // Set default selections
            cmbReportType.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterScholarship.SelectedIndex = 0;
            cmbFilterCourse.SelectedIndex = 0;

            // Set chart titles
            labelChart1Title.Text = "📊 Scholarship Distribution";
            labelChart1Title.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            labelChart1Title.ForeColor = Color.FromArgb(0, 68, 79);
            labelChart1Title.TextAlign = ContentAlignment.MiddleCenter;

            labelChart2Title.Text = "📊 Scholars by Course";
            labelChart2Title.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            labelChart2Title.ForeColor = Color.FromArgb(0, 68, 79);
            labelChart2Title.TextAlign = ContentAlignment.MiddleCenter;

            labelChart3Title.Text = "📈 Monthly Disbursements";
            labelChart3Title.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            labelChart3Title.ForeColor = Color.FromArgb(0, 68, 79);
            labelChart3Title.TextAlign = ContentAlignment.MiddleCenter;

            // Load filter options from database
            LoadFilterOptions();

            // Load analytics data
            LoadAnalyticsData();

            // Wire up events
            btnRefreshAnalytics.Click += BtnRefreshAnalytics_Click;
            btnGenerateReport.Click += BtnGenerateReport_Click;
            btnExportPDF.Click += BtnExportPDF_Click;
            btnExportExcel.Click += BtnExportExcel_Click;
            btnPrint.Click += BtnPrint_Click;
        }

        private void InitializeCharts()
        {
            // Clear any existing controls in the chart panels first
            panelChartScholarship.Controls.Clear();
            panelChartCourse.Controls.Clear();
            panelChartPayments.Controls.Clear();

            // ========== SCHOLARSHIP DISTRIBUTION CHART (PIE) ==========
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
                Position = new ElementPosition(5, 5, 90, 85)
            };
            chartScholarshipDist.ChartAreas.Add(pieArea);

            chartScholarshipDist.Legends.Add(new Legend
            {
                Docking = Docking.Bottom,
                Font = new Font("Century Gothic", 8F),
                BackColor = Color.Transparent,
                Alignment = StringAlignment.Center
            });

            panelChartScholarship.Controls.Add(chartScholarshipDist);

            // ========== COURSE DISTRIBUTION CHART (BAR) ==========
            chartCourseDist = new Chart
            {
                Dock = DockStyle.None,
                BackColor = Color.White,
                Location = new Point(10, 45),
                Size = new Size(panelChartCourse.Width - 20, panelChartCourse.Height - 55)
            };

            ChartArea barArea = new ChartArea("MainArea")
            {
                BackColor = Color.White,
                Position = new ElementPosition(8, 5, 88, 80)
            };
            barArea.AxisX.LabelStyle.Angle = -45;
            barArea.AxisX.LabelStyle.Font = new Font("Century Gothic", 8F);
            barArea.AxisY.LabelStyle.Font = new Font("Century Gothic", 8F);
            barArea.AxisX.Interval = 1;
            barArea.AxisX.MajorGrid.Enabled = false;
            chartCourseDist.ChartAreas.Add(barArea);

            chartCourseDist.Legends.Add(new Legend
            {
                Docking = Docking.Top,
                Font = new Font("Century Gothic", 8F),
                BackColor = Color.Transparent,
                Alignment = StringAlignment.Center
            });

            panelChartCourse.Controls.Add(chartCourseDist);

            // ========== MONTHLY DISBURSEMENT CHART (COLUMN + LINE) ==========
            chartMonthlyDisbursement = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Location = new Point(5, 45),
                Size = new Size(panelChartPayments.Width - 420, panelChartPayments.Height - 35)
            };

            ChartArea lineArea = new ChartArea("MainArea")
            {
                BackColor = Color.White,
                Position = new ElementPosition(8, 8, 88, 75)
            };
            lineArea.AxisX.Title = "Month11";
            lineArea.AxisX.TitleFont = new Font("Century Gothic", 9F, FontStyle.Bold);
            lineArea.AxisX.LabelStyle.Font = new Font("Century Gothic", 8F);
            lineArea.AxisX.LabelStyle.Angle = -45;
            lineArea.AxisX.MajorGrid.Enabled = false;
            lineArea.AxisY.Title = "Amount (₱)";
            lineArea.AxisY.TitleFont = new Font("Century Gothic", 9F, FontStyle.Bold);
            lineArea.AxisY.LabelStyle.Font = new Font("Century Gothic", 8F);
            lineArea.AxisY.LabelStyle.Format = "₱#,##0";
            lineArea.AxisX.Interval = 1;
            chartMonthlyDisbursement.ChartAreas.Add(lineArea);

            chartMonthlyDisbursement.Legends.Add(new Legend
            {
                Docking = Docking.Top,
                Font = new Font("Century Gothic", 8F),
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

                    // Load scholarship types for filter
                    string scholarshipQuery = "SELECT name FROM scholarship_types WHERE is_active = TRUE ORDER BY name";
                    MySqlCommand cmd = new MySqlCommand(scholarshipQuery, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbFilterScholarship.Items.Clear();
                        cmbFilterScholarship.Items.Add("All Scholarships");
                        while (reader.Read())
                            cmbFilterScholarship.Items.Add(reader["name"].ToString());
                    }

                    // Load courses for filter
                    string courseQuery = "SELECT DISTINCT course FROM scholars WHERE course IS NOT NULL ORDER BY course";
                    MySqlCommand courseCmd = new MySqlCommand(courseQuery, conn);
                    using (MySqlDataReader reader = courseCmd.ExecuteReader())
                    {
                        cmbFilterCourse.Items.Clear();
                        cmbFilterCourse.Items.Add("All Courses");
                        while (reader.Read())
                            cmbFilterCourse.Items.Add(reader["course"].ToString());
                    }
                }

                if (cmbFilterScholarship.Items.Count > 0) cmbFilterScholarship.SelectedIndex = 0;
                if (cmbFilterCourse.Items.Count > 0) cmbFilterCourse.SelectedIndex = 0;
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
            // Total Active Scholars
            string totalQuery = "SELECT COUNT(*) FROM scholars WHERE status = 'Active'";
            MySqlCommand cmd = new MySqlCommand(totalQuery, conn);
            lblTotalScholarsValue.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();

            // Active Scholarships Count
            string activeQuery = "SELECT COUNT(*) FROM scholars WHERE status = 'Active'";
            lblActiveScholarsValue.Text = Convert.ToInt32(new MySqlCommand(activeQuery, conn).ExecuteScalar()).ToString();

            // Total Disbursed
            string disbursedQuery = "SELECT COALESCE(SUM(amount), 0) FROM payments WHERE status = 'Released'";
            decimal disbursed = Convert.ToDecimal(new MySqlCommand(disbursedQuery, conn).ExecuteScalar());
            lblTotalDisbursedValue.Text = $"₱{disbursed:N0}";

            // Pending Payments
            string pendingQuery = "SELECT COUNT(*) FROM payments WHERE status IN ('Pending', 'Processed')";
            lblPendingPaymentsValue.Text = Convert.ToInt32(new MySqlCommand(pendingQuery, conn).ExecuteScalar()).ToString();
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

                Series series = new Series("Distribution")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    LabelFormat = "#PERCENT{P0}",
                    Font = new Font("Century Gothic", 9F, FontStyle.Bold)
                };
                chartScholarshipDist.Series.Add(series);

                Color[] colors = {
                    Color.FromArgb(0, 68, 79),
                    Color.FromArgb(40, 167, 69),
                    Color.FromArgb(255, 193, 7),
                    Color.FromArgb(0, 123, 255),
                    Color.FromArgb(111, 66, 193)
                };
                int colorIndex = 0;
                bool hasData = false;

                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    int count = Convert.ToInt32(reader["scholar_count"]);
                    if (count > 0)
                    {
                        hasData = true;
                        int idx = series.Points.AddXY(name, count);
                        series.Points[idx].Color = colors[colorIndex % colors.Length];
                        series.Points[idx].LegendText = $"{name} ({count})";
                        colorIndex++;
                    }
                }

                chartScholarshipDist.Titles.Clear();
                if (!hasData)
                {
                    chartScholarshipDist.Titles.Add(new Title("No data available",
                        Docking.Top, new Font("Century Gothic", 11F, FontStyle.Bold), Color.Gray));
                }
                else
                {
                    chartScholarshipDist.Titles.Add(new Title("Scholarship Distribution",
                        Docking.Top, new Font("Century Gothic", 11F, FontStyle.Bold), Color.FromArgb(0, 68, 79)));
                }
            }
        }

        private void LoadCourseDistributionChart(MySqlConnection conn)
        {
            string query = @"SELECT course, COUNT(*) as scholar_count
                            FROM scholars 
                            WHERE status = 'Active' AND course IS NOT NULL
                            GROUP BY course
                            ORDER BY scholar_count DESC
                            LIMIT 8";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                chartCourseDist.Series.Clear();

                Series series = new Series("By Course")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.FromArgb(0, 68, 79),
                    IsValueShownAsLabel = true,
                    Font = new Font("Century Gothic", 9F)
                };
                chartCourseDist.Series.Add(series);

                bool hasData = false;
                while (reader.Read())
                {
                    string course = reader["course"].ToString();
                    if (course.Length > 20) course = course.Substring(0, 18) + "..";
                    int count = Convert.ToInt32(reader["scholar_count"]);
                    if (count > 0)
                    {
                        hasData = true;
                        series.Points.AddXY(course, count);
                    }
                }

                chartCourseDist.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chartCourseDist.ChartAreas[0].AxisX.Interval = 1;

                chartCourseDist.Titles.Clear();
                if (!hasData)
                {
                    chartCourseDist.Titles.Add(new Title("No data available",
                        Docking.Top, new Font("Century Gothic", 11F, FontStyle.Bold), Color.Gray));
                }
                else
                {
                    chartCourseDist.Titles.Add(new Title("Scholars by Course",
                        Docking.Top, new Font("Century Gothic", 11F, FontStyle.Bold), Color.FromArgb(0, 68, 79)));
                }
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
                    Font = new Font("Century Gothic", 9F)
                };
                chartMonthlyDisbursement.Series.Add(columnSeries);

                Series lineSeries = new Series("Trend")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.FromArgb(239, 68, 68),
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 8,
                    MarkerColor = Color.FromArgb(239, 68, 68)
                };
                chartMonthlyDisbursement.Series.Add(lineSeries);

                bool hasData = false;
                while (reader.Read())
                {
                    string month = reader["month_label"].ToString();
                    decimal amount = Convert.ToDecimal(reader["total_amount"]);
                    if (amount > 0)
                    {
                        hasData = true;
                        columnSeries.Points.AddXY(month, amount);
                        lineSeries.Points.AddXY(month, amount);
                    }
                }

                chartMonthlyDisbursement.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chartMonthlyDisbursement.ChartAreas[0].AxisX.Interval = 1;

                chartMonthlyDisbursement.Titles.Clear();
                if (!hasData)
                {
                    chartMonthlyDisbursement.Titles.Add(new Title("No data available for selected period",
                        Docking.Top, new Font("Century Gothic", 11F, FontStyle.Bold), Color.Gray));
                }
                else
                {
                    chartMonthlyDisbursement.Titles.Add(new Title("Monthly Disbursement Trend",
                        Docking.Top, new Font("Century Gothic", 11F, FontStyle.Bold), Color.FromArgb(0, 68, 79)));
                }
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

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dgvReportData.DataSource = dt;

                    // Style the grid
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
            switch (reportType)
            {
                case "Scholar Census Report":
                    return @"SELECT scholar_number AS 'Scholar #', 
                                    CONCAT(first_name, ' ', last_name) AS 'Name',
                                    course AS 'Course', year_level AS 'Year',
                                    COALESCE(st.name, 'Not Assigned') AS 'Scholarship', 
                                    status AS 'Status'
                             FROM scholars s
                             LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                             WHERE s.created_at BETWEEN @dateFrom AND @dateTo
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
                    return @"SELECT s.scholar_number AS 'Scholar #',
                                    CONCAT(s.first_name, ' ', s.last_name) AS 'Name',
                                    cr.requirement_type AS 'Requirement',
                                    cr.status AS 'Status',
                                    cr.due_date AS 'Due Date',
                                    cr.date_submitted AS 'Date Submitted'
                             FROM compliance_records cr
                             JOIN scholars s ON cr.scholar_id = s.id
                             WHERE cr.due_date BETWEEN @dateFrom AND @dateTo
                             ORDER BY cr.due_date DESC";

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
                             FROM scholars
                             ORDER BY id";
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
                    sw.WriteLine("<html><head><meta charset='UTF-8'>");
                    sw.WriteLine("<title>" + reportTitle + "</title>");
                    sw.WriteLine("<style>");
                    sw.WriteLine("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 30px; background: #f5f5f5; }");
                    sw.WriteLine(".container { max-width: 1400px; margin: 0 auto; background: white; padding: 30px; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); }");
                    sw.WriteLine("h1 { color: #00444F; border-bottom: 3px solid #00444F; padding-bottom: 10px; }");
                    sw.WriteLine("h3 { color: #666; margin-top: 5px; }");
                    sw.WriteLine(".date-range { background: #e8f4f4; padding: 10px; border-radius: 5px; margin: 15px 0; }");
                    sw.WriteLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
                    sw.WriteLine("th { background-color: #00444F; color: white; padding: 12px; text-align: left; font-weight: bold; }");
                    sw.WriteLine("td { padding: 10px; border-bottom: 1px solid #ddd; }");
                    sw.WriteLine("tr:hover { background-color: #f0f8f8; }");
                    sw.WriteLine(".footer { margin-top: 30px; text-align: right; color: #888; font-size: 12px; }");
                    sw.WriteLine("@media print { body { background: white; margin: 0.5in; } .container { box-shadow: none; padding: 0; } }");
                    sw.WriteLine("</style>");
                    sw.WriteLine("</head><body>");
                    sw.WriteLine("<div class='container'>");
                    sw.WriteLine("<h1>📊 " + reportTitle + "</h1>");
                    sw.WriteLine("<h3>IskolarAid - Legacy College of Compostela</h3>");
                    sw.WriteLine("<div class='date-range'><strong>Date Range:</strong> " + dateRange + "</div>");
                    sw.WriteLine("<div><strong>Total Records:</strong> " + dgvReportData.Rows.Count + "</div>");
                    sw.WriteLine("<table>");

                    // Headers
                    sw.WriteLine("<tr>");
                    foreach (DataGridViewColumn col in dgvReportData.Columns)
                    {
                        sw.WriteLine("<th>" + col.HeaderText + "</th>");
                    }
                    sw.WriteLine("</tr>");

                    // Data
                    foreach (DataGridViewRow row in dgvReportData.Rows)
                    {
                        sw.WriteLine("<tr>");
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string value = cell.Value?.ToString() ?? "";
                            sw.WriteLine("<td>" + WebUtility.HtmlEncode(value) + "</td>");
                        }
                        sw.WriteLine("</tr>");
                    }

                    sw.WriteLine("</table>");
                    sw.WriteLine("<div class='footer'>Generated on: " + DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss") + " | IskolarAid System</div>");
                    sw.WriteLine("</div>");

                    if (autoPrint)
                    {
                        sw.WriteLine("<script>window.onload = function() { window.print(); }</script>");
                    }

                    sw.WriteLine("</body></html>");
                }

                Process.Start(fileName);
                ActivityLogger.Log("EXPORT", $"Exported {reportTitle} to HTML");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV()
        {
            if (dgvReportData.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV File|*.csv";
                    sfd.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            // Headers
                            for (int i = 0; i < dgvReportData.Columns.Count; i++)
                            {
                                sw.Write(dgvReportData.Columns[i].HeaderText);
                                if (i < dgvReportData.Columns.Count - 1) sw.Write(",");
                            }
                            sw.WriteLine();

                            // Data
                            foreach (DataGridViewRow row in dgvReportData.Rows)
                            {
                                for (int i = 0; i < dgvReportData.Columns.Count; i++)
                                {
                                    string value = row.Cells[i].Value?.ToString() ?? "";
                                    if (value.Contains(",")) value = $"\"{value}\"";
                                    sw.Write(value);
                                    if (i < dgvReportData.Columns.Count - 1) sw.Write(",");
                                }
                                sw.WriteLine();
                            }
                        }

                        MessageBox.Show($"Report exported successfully!\n\nFile: {sfd.FileName}", "Export Complete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ActivityLogger.Log("EXPORT", $"Exported report to CSV: {sfd.FileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event Handlers

        private void BtnRefreshAnalytics_Click(object sender, EventArgs e)
        {
            LoadAnalyticsData();
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            ExportToHTMLAndOpen(false);
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            ExportToHTMLAndOpen(true);
        }

        #endregion

        #region Navigation

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmAdminDashboard dashboard = new FrmAdminDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnScholarMgmt_Click(object sender, EventArgs e)
        {
            FrmScholarManagement scholarMgmt = new FrmScholarManagement();
            scholarMgmt.Show();
            this.Hide();
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            FrmPayrollProcessing payroll = new FrmPayrollProcessing();
            payroll.Show();
            this.Hide();
        }

        private void btnActivityLog_Click(object sender, EventArgs e)
        {
            FrmActivityLogs activityLogs = new FrmActivityLogs();
            activityLogs.Show();
            this.Hide();
        }

        private void btnReminder_Click(object sender, EventArgs e)
        {
            FrmNotifications notifications = new FrmNotifications();
            notifications.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ActivityLogger.LogLogout(SessionManager.CurrentUser?.Id ?? 0, SessionManager.CurrentUser?.Name ?? "");
            SessionManager.ClearSession();

            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        #endregion

        #region Designer Event Handlers (Keep for compatibility)
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
        #endregion

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}