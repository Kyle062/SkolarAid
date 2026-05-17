using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form;
using SkolarAid.form.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
        private Panel panelTemplates;
        private Button btnToggleTemplates;
        private bool isTemplatesPanelVisible = false;

        public FrmReportsAnalytics()
        {
            InitializeComponent();
            InitializeCharts();
            InitializeTemplatesPanel();
            InitializeToggleButton();
            this.Load += FrmReportsAnalytics_Load;
            this.Resize += FrmReportsAnalytics_Resize;
        }

        /// <summary>
        /// Creates a toggle button to show/hide the templates panel
        /// </summary>
        private void InitializeToggleButton()
        {
            btnToggleTemplates = new Button
            {
                Text = "📄 View Templates",
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 68, 79),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(160, 38),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                Visible = true
            };
            btnToggleTemplates.FlatAppearance.BorderSize = 0;
            btnToggleTemplates.Click += BtnToggleTemplates_Click;
            this.Controls.Add(btnToggleTemplates);
            btnToggleTemplates.BringToFront();
        }

        /// <summary>
        /// Toggle button click - shows/hides the templates panel and adjusts layout
        /// </summary>
        private void BtnToggleTemplates_Click(object sender, EventArgs e)
        {
            isTemplatesPanelVisible = !isTemplatesPanelVisible;

            if (isTemplatesPanelVisible)
            {
                panelTemplates.Visible = true;
                btnToggleTemplates.Text = "✖ Hide Templates";
                btnToggleTemplates.BackColor = Color.FromArgb(220, 53, 69);
            }
            else
            {
                panelTemplates.Visible = false;
                btnToggleTemplates.Text = "📄 View Templates";
                btnToggleTemplates.BackColor = Color.FromArgb(0, 68, 79);
            }

            AdjustLayoutForFullscreen();
        }

        /// <summary>
        /// Creates the right-side templates panel programmatically (hidden by default)
        /// </summary>
        private void InitializeTemplatesPanel()
        {
            panelTemplates = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(this.ClientSize.Width - 290, 100),
                Size = new Size(270, this.ClientSize.Height - 130),
                AutoScroll = true,
                Visible = false
            };
            this.Controls.Add(panelTemplates);
            panelTemplates.BringToFront();

            // Title
            Label lblTemplatesTitle = new Label
            {
                Text = "📄 Report Templates",
                Font = new Font("Century Gothic", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                Location = new Point(15, 15),
                AutoSize = true
            };
            panelTemplates.Controls.Add(lblTemplatesTitle);

            // Description
            Label lblTemplatesDesc = new Label
            {
                Text = "Download editable Word/Excel templates\nfor reports and liquidations:",
                Font = new Font("Century Gothic", 9F),
                ForeColor = Color.Gray,
                Location = new Point(15, 45),
                Size = new Size(235, 35)
            };
            panelTemplates.Controls.Add(lblTemplatesDesc);

            // Template buttons data
            var templates = new[]
            {
                new { Title = "Scholar Census Report", Icon = "📊", FileName = "Scholar_Census_Report_Template.docx" },
                new { Title = "Payroll Summary Report", Icon = "💰", FileName = "Payroll_Summary_Report_Template.docx" },
                new { Title = "Compliance Report", Icon = "📋", FileName = "Compliance_Report_Template.docx" },
                new { Title = "Payment History Report", Icon = "💳", FileName = "Payment_History_Report_Template.docx" },
                new { Title = "Activity Log Report", Icon = "📝", FileName = "Activity_Log_Report_Template.docx" },
                new { Title = "Disbursement Voucher", Icon = "🧾", FileName = "Disbursement_Voucher_Template.xlsx" },
                new { Title = "Liquidation Report", Icon = "📑", FileName = "Liquidation_Report_Template.xlsx" },
                new { Title = "Stipend Release Form", Icon = "💵", FileName = "Stipend_Release_Form_Template.docx" }
            };

            int yPos = 90;
            foreach (var template in templates)
            {
                Button btnTemplate = new Button
                {
                    Text = $"  {template.Icon}  {template.Title}",
                    Font = new Font("Century Gothic", 9F),
                    BackColor = Color.FromArgb(0, 68, 79),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(15, yPos),
                    Size = new Size(235, 38),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    Tag = template.FileName
                };
                btnTemplate.FlatAppearance.BorderSize = 0;
                btnTemplate.Click += BtnTemplate_Click;
                panelTemplates.Controls.Add(btnTemplate);
                yPos += 45;
            }

            // Separator for Receipt section
            yPos += 10;
            Label lblSeparator = new Label
            {
                Text = "━━━━━━━━━━━━━━━━━━━━━━",
                Font = new Font("Century Gothic", 8F),
                ForeColor = Color.LightGray,
                Location = new Point(15, yPos),
                AutoSize = true
            };
            panelTemplates.Controls.Add(lblSeparator);
            yPos += 20;

            // Receipt Section Title
            Label lblReceiptTitle = new Label
            {
                Text = "🧾 Payroll Receipt",
                Font = new Font("Century Gothic", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                Location = new Point(15, yPos),
                AutoSize = true
            };
            panelTemplates.Controls.Add(lblReceiptTitle);
            yPos += 35;

            // Print Receipt Button
            Button btnPrintReceipt = new Button
            {
                Text = "🖨️  Print Disbursement Receipt",
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(15, yPos),
                Size = new Size(235, 45),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            btnPrintReceipt.FlatAppearance.BorderSize = 0;
            btnPrintReceipt.Click += BtnPrintReceipt_Click;
            panelTemplates.Controls.Add(btnPrintReceipt);
        }

        private void FrmReportsAnalytics_Resize(object sender, EventArgs e)
        {
            AdjustLayoutForFullscreen();
        }

        private void AdjustLayoutForFullscreen()
        {
            int screenWidth = this.ClientSize.Width;
            int screenHeight = this.ClientSize.Height;

            // Position the toggle button in the top-right area
            if (btnToggleTemplates != null)
            {
                btnToggleTemplates.Location = new Point(screenWidth - 180, 108);
            }

            // Position the templates panel on the right
            if (panelTemplates != null)
            {
                panelTemplates.Location = new Point(screenWidth - 290, 100);
                panelTemplates.Size = new Size(270, screenHeight - 130);
            }

            // Adjust tabControlReports based on whether templates panel is visible
            if (tabControlReports != null)
            {
                tabControlReports.Location = new Point(301, 100);

                if (isTemplatesPanelVisible)
                {
                    tabControlReports.Size = new Size(screenWidth - 321 - 280, screenHeight - 130);
                }
                else
                {
                    tabControlReports.Size = new Size(screenWidth - 321, screenHeight - 130);
                }
            }

            if (tabControlReports != null)
            {
                int tabWidth = tabControlReports.Width - 40;
                int chartPanelWidth = (tabWidth - 80) / 3;

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
        /// Template download button click handler
        /// </summary>
        private void BtnTemplate_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string templateName = btn.Tag.ToString();
            string templatesDir = Path.Combine(Application.StartupPath, "Templates");
            string htmlFileName = templateName.Replace(".docx", ".html").Replace(".xlsx", ".html");
            string htmlFilePath = Path.Combine(templatesDir, htmlFileName);

            // Create Templates directory if it doesn't exist
            if (!Directory.Exists(templatesDir))
            {
                Directory.CreateDirectory(templatesDir);
            }

            // Create the HTML template if it doesn't exist
            if (!File.Exists(htmlFilePath))
            {
                CreateSampleTemplate(htmlFilePath, templateName);
            }

            try
            {
                // Open the HTML file in the default browser
                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlFilePath,
                    UseShellExecute = true
                });

                ActivityLogger.Log("DOWNLOAD_TEMPLATE", $"Opened template: {templateName}");

                MessageBox.Show(
                    $"Template opened in your browser.\n\n" +
                    $"To save as Word/Excel:\n" +
                    $"1. Press Ctrl+P in your browser\n" +
                    $"2. Select 'Save as PDF' or print\n" +
                    $"3. Or copy the content to Word/Excel\n\n" +
                    $"Template location:\n{htmlFilePath}",
                    "Template Opened",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Fallback: open the folder containing the template
                try
                {
                    Process.Start("explorer.exe", $"/select,\"{htmlFilePath}\"");
                    MessageBox.Show(
                        $"Template created at:\n{htmlFilePath}\n\n" +
                        $"Right-click the file and open with your browser or Word.",
                        "Template Created",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show($"Error opening template: {ex.Message}\n\nTemplate location:\n{htmlFilePath}",
                        "Template Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Creates a sample template file with proper formatting
        /// </summary>
        private void CreateSampleTemplate(string htmlFilePath, string originalFileName)
        {
            try
            {
                string reportName = originalFileName.Replace("_Template.docx", "").Replace("_Template.xlsx", "")
                    .Replace("_", " ").Replace("_Form", " Form");

                string reportType = originalFileName.Contains(".xlsx") ? "Excel" : "Word";

                string htmlContent = $@"<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>{reportName} - Legacy College of Compostela</title>
    <style>
        * {{ margin: 0; padding: 0; box-sizing: border-box; }}
        body {{ 
            font-family: 'Segoe UI', Arial, sans-serif; 
            font-size: 14px; 
            color: #333; 
            max-width: 1000px; 
            margin: 0 auto; 
            padding: 30px;
            background: #fff;
        }}
        .header {{ 
            text-align: center; 
            border-bottom: 3px solid #00444F; 
            padding-bottom: 20px; 
            margin-bottom: 30px; 
        }}
        .header .logo {{ 
            font-size: 40px; 
            margin-bottom: 10px; 
        }}
        .header h3 {{ 
            color: #666; 
            font-size: 16px; 
            margin: 5px 0; 
            font-weight: normal;
        }}
        .header h2 {{ 
            color: #00444F; 
            font-size: 20px; 
            margin: 5px 0; 
        }}
        .header h1 {{ 
            color: #00444F; 
            font-size: 26px; 
            margin: 15px 0; 
            text-transform: uppercase;
            letter-spacing: 1px;
        }}
        .meta-info {{
            background: #f0f8f8;
            border: 1px solid #00444F;
            padding: 15px;
            margin: 20px 0;
            border-radius: 5px;
            display: flex;
            justify-content: space-between;
            flex-wrap: wrap;
        }}
        .meta-info div {{
            margin: 5px 15px;
        }}
        .meta-info strong {{
            color: #00444F;
        }}
        .instructions {{
            background: #fff9e6;
            border: 1px solid #ffc107;
            padding: 15px;
            margin: 20px 0;
            border-radius: 5px;
        }}
        .instructions h4 {{
            color: #856404;
            margin-bottom: 10px;
        }}
        .instructions ol {{
            margin-left: 20px;
            color: #856404;
        }}
        .instructions li {{
            margin: 5px 0;
        }}
        table {{ 
            width: 100%; 
            border-collapse: collapse; 
            margin: 25px 0; 
            font-size: 13px; 
        }}
        th {{ 
            background-color: #00444F; 
            color: white; 
            padding: 14px 12px; 
            text-align: left; 
            font-weight: bold; 
            font-size: 14px;
            border: 1px solid #003038;
        }}
        td {{ 
            padding: 12px 10px; 
            border: 1px solid #ddd; 
            font-size: 13px;
            vertical-align: top;
        }}
        tr:nth-child(even) {{ background-color: #f9f9f9; }}
        tr:hover {{ background-color: #e8f4f4; }}
        .editable {{ 
            background-color: #ffffcc;
            border-bottom: 1px dashed #999;
            padding: 2px 5px;
        }}
        .footer {{ 
            margin-top: 50px; 
            display: flex; 
            justify-content: space-between; 
        }}
        .signature-box {{ 
            text-align: center; 
            width: 45%; 
        }}
        .sig-line {{ 
            border-top: 1px solid #000; 
            margin: 70px 30px 8px 30px; 
        }}
        .sig-name {{ 
            font-weight: bold; 
            font-size: 15px; 
        }}
        .sig-title {{ 
            font-size: 13px; 
            color: #666; 
        }}
        .print-btn {{
            position: fixed;
            top: 20px;
            right: 20px;
            background: #00444F;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
        }}
        .print-btn:hover {{
            background: #006675;
        }}
        @media print {{
            body {{ margin: 0; padding: 20px; }}
            .print-btn {{ display: none; }}
            .instructions {{ display: none; }}
            @page {{ size: A4 portrait; margin: 15mm; }}
        }}
    </style>
</head>
<body>
    <button class='print-btn' onclick='window.print()'>🖨️ Print / Save as PDF</button>

    <div class='header'>
        <div class='logo'>🏫</div>
        <h3>Legacy College of Compostela</h3>
        <h2>IskolarAid Scholarship Management System</h2>
        <h1>{reportName}</h1>
    </div>

    <div class='meta-info'>
        <div><strong>School Year:</strong> <span class='editable'>2025-2026</span></div>
        <div><strong>Semester:</strong> <span class='editable'>2nd Semester</span></div>
        <div><strong>Date:</strong> <span class='editable'>___________________</span></div>
        <div><strong>Prepared by:</strong> <span class='editable'>___________________</span></div>
    </div>

    <div class='instructions'>
        <h4>📝 Instructions:</h4>
        <ol>
            <li>This is an editable template - replace all <span style='background:#ffffcc;padding:2px 5px;'>highlighted</span> text with actual data</li>
            <li>Add or remove table rows as needed</li>
            <li>To save: Press <strong>Ctrl+P</strong> → Select <strong>'Save as PDF'</strong></li>
            <li>Or copy the table to <strong>Microsoft {reportType}</strong> for advanced editing</li>
            <li>Delete this instruction box before printing</li>
        </ol>
    </div>

    <table>
        <thead>
            <tr>
                <th>#</th>
                <th>Scholar Number</th>
                <th>Full Name</th>
                <th>Course</th>
                <th>Year Level</th>
                <th>Scholarship</th>
                <th>Status</th>
                <th>Remarks</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>1</td>
                <td><span class='editable'>SCH-2024-001</span></td>
                <td><span class='editable'>Juan Dela Cruz</span></td>
                <td><span class='editable'>BS Information Technology</span></td>
                <td><span class='editable'>3rd Year</span></td>
                <td><span class='editable'>Academic Excellence</span></td>
                <td><span class='editable'>Active</span></td>
                <td><span class='editable'></span></td>
            </tr>
            <tr>
                <td>2</td>
                <td><span class='editable'>SCH-2024-002</span></td>
                <td><span class='editable'>Maria Santos</span></td>
                <td><span class='editable'>BS Business Administration</span></td>
                <td><span class='editable'>2nd Year</span></td>
                <td><span class='editable'>Financial Assistance</span></td>
                <td><span class='editable'>Active</span></td>
                <td><span class='editable'></span></td>
            </tr>
            <tr>
                <td>3</td>
                <td><span class='editable'>SCH-2024-003</span></td>
                <td><span class='editable'>Pedro Reyes</span></td>
                <td><span class='editable'>BS Criminology</span></td>
                <td><span class='editable'>4th Year</span></td>
                <td><span class='editable'>President's List</span></td>
                <td><span class='editable'>Active</span></td>
                <td><span class='editable'></span></td>
            </tr>
            <tr>
                <td>4</td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
            </tr>
            <tr>
                <td>5</td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
                <td><span class='editable'></span></td>
            </tr>
        </tbody>
    </table>

    <div style='margin-top:30px;'>
        <p><strong>Summary / Notes:</strong></p>
        <p class='editable' style='min-height:60px; padding:10px;'>&nbsp;</p>
    </div>

    <div class='footer'>
        <div class='signature-box'>
            <div class='sig-line'></div>
            <p class='sig-name'>Prepared by</p>
            <p class='sig-title'>Scholarship Coordinator</p>
        </div>
        <div class='signature-box'>
            <div class='sig-line'></div>
            <p class='sig-name'>MRS. WENDY ALCALA</p>
            <p class='sig-title'>Approved by</p>
        </div>
    </div>

    <p style='text-align:center;color:#888;font-size:11px;margin-top:40px;'>
        Generated by IskolarAid System | Legacy College of Compostela | {DateTime.Now.Year}<br>
        <em>This is a template - replace sample data with actual records</em>
    </p>

</body>
</html>";

                // Write the HTML file
                File.WriteAllText(htmlFilePath, htmlContent, System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating template: {ex.Message}");
                // Create a simple fallback file
                string fallbackTitle = originalFileName.Replace("_Template.docx", "").Replace("_Template.xlsx", "")
                    .Replace("_", " ");
                File.WriteAllText(htmlFilePath, $"<html><body><h1>{fallbackTitle}</h1><p>Template created. Open in browser to view.</p></body></html>");
            }
        }

        /// <summary>
        /// Print Receipt button click handler
        /// </summary>
        private void BtnPrintReceipt_Click(object sender, EventArgs e)
        {
            Form receiptForm = new Form
            {
                Text = "Print Disbursement Receipt",
                Size = new Size(650, 550),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblTitle = new Label
            {
                Text = "Select Payment to Print Receipt",
                Font = new Font("Century Gothic", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 68, 79),
                Location = new Point(20, 20),
                AutoSize = true
            };
            receiptForm.Controls.Add(lblTitle);

            DataGridView dgvPayments = new DataGridView
            {
                Location = new Point(20, 60),
                Size = new Size(590, 350),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 68, 79),
                    ForeColor = Color.White,
                    Font = new Font("Century Gothic", 9F, FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Century Gothic", 9F)
                }
            };
            receiptForm.Controls.Add(dgvPayments);

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT p.id, s.scholar_number AS 'Scholar #', 
                                    CONCAT(s.first_name, ' ', s.last_name) AS 'Scholar Name',
                                    p.payment_period AS 'Period', 
                                    p.amount AS 'Amount', 
                                    p.release_date AS 'Release Date'
                                    FROM payments p
                                    JOIN scholars s ON p.scholar_id = s.id
                                    WHERE p.status = 'Released'
                                    ORDER BY p.release_date DESC
                                    LIMIT 50";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvPayments.DataSource = dt;

                    if (dgvPayments.Columns.Contains("id"))
                        dgvPayments.Columns["id"].Visible = false;
                    if (dgvPayments.Columns.Contains("Amount"))
                        dgvPayments.Columns["Amount"].DefaultCellStyle.Format = "₱#,##0.00";
                    dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Button btnPrint = new Button
            {
                Text = "🖨️  Print Receipt",
                Font = new Font("Century Gothic", 11F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 68, 79),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(430, 430),
                Size = new Size(180, 45),
                Cursor = Cursors.Hand
            };
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Click += (s, ev) =>
            {
                if (dgvPayments.SelectedRows.Count > 0)
                {
                    int paymentId = Convert.ToInt32(dgvPayments.SelectedRows[0].Cells["id"].Value);
                    PrintPaymentReceipt(paymentId);
                    receiptForm.Close();
                }
                else
                {
                    MessageBox.Show("Please select a payment to print.", "Select Payment",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            receiptForm.Controls.Add(btnPrint);

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Font = new Font("Century Gothic", 10F),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(330, 430),
                Size = new Size(90, 45),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => receiptForm.Close();
            receiptForm.Controls.Add(btnCancel);

            receiptForm.ShowDialog();
        }

        /// <summary>
        /// Generates and prints a payment receipt in PORTRAIT orientation with LARGER fonts
        /// </summary>
        private void PrintPaymentReceipt(int paymentId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT p.*, s.scholar_number, s.student_id,
                                    CONCAT(s.first_name, ' ', IFNULL(s.middle_name, ''), ' ', s.last_name) AS scholar_name,
                                    s.course, s.year_level, s.email,
                                    st.name AS scholarship_name, s.bank_name, s.bank_account_number,
                                    s.address, s.program, s.hei
                                    FROM payments p
                                    JOIN scholars s ON p.scholar_id = s.id
                                    LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
                                    WHERE p.id = @paymentId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@paymentId", paymentId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string scholarNumber = reader["scholar_number"].ToString();
                            string scholarName = reader["scholar_name"].ToString();
                            string studentId = reader["student_id"]?.ToString() ?? "";
                            string course = reader["course"]?.ToString() ?? "";
                            string yearLevel = reader["year_level"]?.ToString() ?? "";
                            string scholarshipName = reader["scholarship_name"]?.ToString() ?? "N/A";
                            string paymentPeriod = reader["payment_period"].ToString();
                            decimal amount = Convert.ToDecimal(reader["amount"]);
                            string status = reader["status"].ToString();
                            string releaseDate = reader["release_date"] != DBNull.Value ?
                                Convert.ToDateTime(reader["release_date"]).ToString("MMMM dd, yyyy") : "";
                            string paymentMethod = reader["payment_method"]?.ToString() ?? "Bank Transfer";
                            string bankName = reader["bank_name"]?.ToString() ?? "";
                            string bankAccount = reader["bank_account_number"]?.ToString() ?? "";
                            string program = reader["program"]?.ToString() ?? "";
                            string hei = reader["hei"]?.ToString() ?? "";
                            string address = reader["address"]?.ToString() ?? "";

                            string fileName = Path.Combine(Path.GetTempPath(),
                                $"Receipt_{scholarNumber}_{DateTime.Now:yyyyMMddHHmmss}.html");

                            using (StreamWriter sw = new StreamWriter(fileName))
                            {
                                sw.WriteLine("<!DOCTYPE html>");
                                sw.WriteLine("<html><head><meta charset='UTF-8'>");
                                sw.WriteLine("<title>Disbursement Receipt - " + scholarName + "</title>");
                                sw.WriteLine("<style>");
                                sw.WriteLine("@page { size: A4 portrait; margin: 15mm; }");
                                sw.WriteLine("@media print { body { margin: 0; } .no-print { display: none; } }");
                                sw.WriteLine("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 20px; color: #333; font-size: 15px; }");
                                sw.WriteLine(".receipt-container { max-width: 750px; margin: 0 auto; border: 2px solid #00444F; padding: 30px; }");
                                sw.WriteLine(".header { text-align: center; border-bottom: 2px solid #00444F; padding-bottom: 15px; margin-bottom: 25px; }");
                                sw.WriteLine(".header h3 { color: #666; font-size: 18px; margin: 3px 0; }");
                                sw.WriteLine(".header h2 { color: #00444F; font-size: 22px; margin: 5px 0; }");
                                sw.WriteLine(".header h1 { color: #00444F; font-size: 28px; margin: 10px 0; text-transform: uppercase; letter-spacing: 2px; }");
                                sw.WriteLine(".receipt-no { text-align: right; font-size: 15px; color: #666; margin-bottom: 20px; }");
                                sw.WriteLine(".section { margin: 20px 0; }");
                                sw.WriteLine(".section h4 { color: #00444F; font-size: 18px; border-bottom: 1px solid #ddd; padding-bottom: 5px; margin-bottom: 12px; }");
                                sw.WriteLine("table.info-table { width: 100%; border-collapse: collapse; font-size: 16px; }");
                                sw.WriteLine("table.info-table td { padding: 12px 10px; border-bottom: 1px solid #eee; vertical-align: top; }");
                                sw.WriteLine("table.info-table td.label { font-weight: bold; color: #00444F; width: 35%; font-size: 16px; }");
                                sw.WriteLine("table.info-table td.value { color: #333; font-size: 16px; }");
                                sw.WriteLine(".amount-box { background: #f0f8f8; border: 2px solid #00444F; padding: 25px; text-align: center; margin: 25px 0; }");
                                sw.WriteLine(".amount-box .amount { font-size: 38px; font-weight: bold; color: #00444F; }");
                                sw.WriteLine(".amount-box .amount-label { font-size: 15px; color: #666; }");
                                sw.WriteLine(".footer { margin-top: 50px; display: flex; justify-content: space-between; font-size: 15px; }");
                                sw.WriteLine(".signature-box { text-align: center; width: 45%; }");
                                sw.WriteLine(".sig-line { border-top: 1px solid #000; margin: 70px 20px 5px 20px; }");
                                sw.WriteLine(".sig-name { font-weight: bold; font-size: 16px; }");
                                sw.WriteLine(".sig-title { font-size: 14px; color: #666; }");
                                sw.WriteLine(".print-btn { text-align: center; margin: 20px 0; }");
                                sw.WriteLine(".print-btn button { padding: 14px 35px; font-size: 17px; background: #00444F; color: white; border: none; cursor: pointer; border-radius: 5px; }");
                                sw.WriteLine("</style></head><body>");

                                sw.WriteLine("<div class='receipt-container'>");

                                sw.WriteLine("<div class='header'>");
                                sw.WriteLine("<h3>Legacy College of Compostela</h3>");
                                sw.WriteLine("<h2>IskolarAid Scholarship Program</h2>");
                                sw.WriteLine("<h1>OFFICIAL DISBURSEMENT RECEIPT</h1>");
                                sw.WriteLine("</div>");

                                sw.WriteLine($"<div class='receipt-no'><strong>Receipt #:</strong> REC-{paymentId:D6}<br/><strong>Date:</strong> {DateTime.Now:MMMM dd, yyyy}</div>");

                                sw.WriteLine("<div class='section'>");
                                sw.WriteLine("<h4>📋 Scholar Information</h4>");
                                sw.WriteLine("<table class='info-table'>");
                                sw.WriteLine($"<tr><td class='label'>Scholar Number:</td><td class='value'>{scholarNumber}</td></tr>");
                                sw.WriteLine($"<tr><td class='label'>Full Name:</td><td class='value'>{scholarName}</td></tr>");
                                sw.WriteLine($"<tr><td class='label'>Student ID:</td><td class='value'>{studentId}</td></tr>");
                                if (!string.IsNullOrEmpty(program))
                                    sw.WriteLine($"<tr><td class='label'>Program:</td><td class='value'>{program}</td></tr>");
                                if (!string.IsNullOrEmpty(course))
                                    sw.WriteLine($"<tr><td class='label'>Course:</td><td class='value'>{course}</td></tr>");
                                if (!string.IsNullOrEmpty(yearLevel))
                                    sw.WriteLine($"<tr><td class='label'>Year Level:</td><td class='value'>{yearLevel}</td></tr>");
                                if (!string.IsNullOrEmpty(hei))
                                    sw.WriteLine($"<tr><td class='label'>HEI:</td><td class='value'>{hei}</td></tr>");
                                sw.WriteLine($"<tr><td class='label'>Scholarship:</td><td class='value'>{scholarshipName}</td></tr>");
                                if (!string.IsNullOrEmpty(address))
                                    sw.WriteLine($"<tr><td class='label'>Address:</td><td class='value'>{address}</td></tr>");
                                sw.WriteLine("</table>");
                                sw.WriteLine("</div>");

                                sw.WriteLine("<div class='section'>");
                                sw.WriteLine("<h4>💳 Payment Details</h4>");
                                sw.WriteLine("<table class='info-table'>");
                                sw.WriteLine($"<tr><td class='label'>Payment Period:</td><td class='value'>{paymentPeriod}</td></tr>");
                                sw.WriteLine($"<tr><td class='label'>Release Date:</td><td class='value'>{releaseDate}</td></tr>");
                                sw.WriteLine($"<tr><td class='label'>Payment Method:</td><td class='value'>{paymentMethod}</td></tr>");
                                if (!string.IsNullOrEmpty(bankName))
                                    sw.WriteLine($"<tr><td class='label'>Bank Name:</td><td class='value'>{bankName}</td></tr>");
                                if (!string.IsNullOrEmpty(bankAccount))
                                    sw.WriteLine($"<tr><td class='label'>Account Number:</td><td class='value'>{bankAccount}</td></tr>");
                                sw.WriteLine($"<tr><td class='label'>Status:</td><td class='value' style='color:green; font-weight:bold; font-size:16px;'>✓ {status}</td></tr>");
                                sw.WriteLine("</table>");
                                sw.WriteLine("</div>");

                                sw.WriteLine("<div class='amount-box'>");
                                sw.WriteLine("<div class='amount-label'>TOTAL AMOUNT DISBURSED</div>");
                                sw.WriteLine($"<div class='amount'>₱{amount:N2}</div>");
                                sw.WriteLine($"<div class='amount-label' style='font-style:italic; margin-top:8px;'>({AmountToWords(amount)})</div>");
                                sw.WriteLine("</div>");

                                sw.WriteLine("<div class='footer'>");
                                sw.WriteLine("<div class='signature-box'><div class='sig-line'></div><p class='sig-name'>" + scholarName + "</p><p class='sig-title'>Scholar / Payee</p></div>");
                                sw.WriteLine("<div class='signature-box'><div class='sig-line'></div><p class='sig-name'>MRS. WENDY ALCALA</p><p class='sig-title'>Scholarship Coordinator</p></div>");
                                sw.WriteLine("</div>");

                                sw.WriteLine("<p style='text-align:center;color:#888;font-size:13px;margin-top:40px;'>This is a system-generated official receipt. | Legacy College of Compostela | IskolarAid | " + DateTime.Now.Year + "</p>");

                                sw.WriteLine("</div>");

                                sw.WriteLine("<div class='print-btn no-print'><button onclick='window.print()'>🖨️ Print Receipt</button></div>");
                                sw.WriteLine("<script>window.onload = function() { setTimeout(function() { window.print(); }, 500); }</script>");
                                sw.WriteLine("</body></html>");
                            }

                            Process.Start(fileName);
                            ActivityLogger.Log("PRINT_RECEIPT", $"Printed disbursement receipt for {scholarName} (#{paymentId})");
                        }
                        else
                        {
                            MessageBox.Show("Payment record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing receipt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Converts a decimal amount to words
        /// </summary>
        private string AmountToWords(decimal amount)
        {
            if (amount == 0) return "Zero Pesos Only";

            string[] ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] thousands = { "", "Thousand", "Million" };

            string words = "";
            long wholePart = (long)amount;
            int centavos = (int)((amount - wholePart) * 100);

            if (wholePart == 0)
            {
                words = "Zero";
            }
            else
            {
                int thousandIndex = 0;
                while (wholePart > 0)
                {
                    int part = (int)(wholePart % 1000);
                    if (part > 0)
                    {
                        string partWords = "";
                        if (part >= 100)
                        {
                            partWords += ones[part / 100] + " Hundred ";
                            part %= 100;
                        }
                        if (part >= 10 && part < 20)
                            partWords += teens[part - 10] + " ";
                        else
                        {
                            if (part >= 20)
                                partWords += tens[part / 10] + " ";
                            if (part % 10 > 0)
                                partWords += ones[part % 10] + " ";
                        }
                        words = partWords + thousands[thousandIndex] + " " + words;
                    }
                    wholePart /= 1000;
                    thousandIndex++;
                }
            }

            words = words.Trim() + " Pesos";

            if (centavos > 0)
                words += $" and {centavos}/100 Centavos";
            else
                words += " Only";

            return words;
        }

        private void UpdateScholarCourses()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
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
                        Console.WriteLine($"Updated {updatedCount} scholar courses to approved list.");
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
                    string scholarshipQuery = "SELECT id, name FROM scholarship_types WHERE is_active = TRUE ORDER BY name";
                    MySqlCommand cmd = new MySqlCommand(scholarshipQuery, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbFilterScholarship.Items.Clear();
                        cmbFilterScholarship.Items.Add("All Scholarships");
                        while (reader.Read())
                            cmbFilterScholarship.Items.Add(reader["name"].ToString());
                    }

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
                    Label = "#VALX\n(#VALY scholars)",
                    Font = new Font("Century Gothic", 8F, FontStyle.Bold)
                };
                chartScholarshipDist.Series.Add(series);

                Color[] colors = {
                    Color.FromArgb(0, 68, 79), Color.FromArgb(40, 167, 69),
                    Color.FromArgb(255, 193, 7), Color.FromArgb(0, 123, 255),
                    Color.FromArgb(111, 66, 193), Color.FromArgb(220, 53, 69)
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

                Legend legend = new Legend("CourseLegend")
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    Font = new Font("Century Gothic", 9F),
                    BackColor = Color.Transparent,
                    BorderColor = Color.Transparent,
                    TableStyle = LegendTableStyle.Wide,
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
                    Color.FromArgb(0, 68, 79), Color.FromArgb(40, 167, 69),
                    Color.FromArgb(255, 193, 7), Color.FromArgb(0, 123, 255),
                    Color.FromArgb(111, 66, 193), Color.FromArgb(220, 53, 69),
                    Color.FromArgb(23, 162, 184), Color.FromArgb(255, 140, 0),
                    Color.FromArgb(75, 192, 192), Color.FromArgb(153, 102, 255)
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
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvReportData.DataSource = dt;

                    dgvReportData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 68, 79);
                    dgvReportData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvReportData.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
                    dgvReportData.ColumnHeadersHeight = 50;
                    dgvReportData.DefaultCellStyle.Font = new Font("Century Gothic", 11F);
                    dgvReportData.RowTemplate.Height = 35;
                    dgvReportData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 250, 250);
                    dgvReportData.AlternatingRowsDefaultCellStyle.Font = new Font("Century Gothic", 11F);
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
                    sw.WriteLine("@page { size: A4 portrait; margin: 15mm; }");
                    sw.WriteLine("@media print { body { margin: 0; } .no-print { display: none; } }");
                    sw.WriteLine("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 20px; background: #fff; font-size: 14px; }");
                    sw.WriteLine(".header { text-align: center; border-bottom: 2px solid #00444F; padding-bottom: 15px; margin-bottom: 25px; }");
                    sw.WriteLine("h1 { color: #00444F; font-size: 22px; margin: 0; }");
                    sw.WriteLine("h3 { color: #666; font-size: 16px; margin: 5px 0; }");
                    sw.WriteLine(".info-bar { background: #e8f4f4; padding: 12px; border-radius: 5px; margin: 15px 0; font-size: 14px; }");
                    sw.WriteLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; font-size: 14px; }");
                    sw.WriteLine("th { background-color: #00444F; color: white; padding: 12px 10px; text-align: left; font-weight: bold; font-size: 15px; }");
                    sw.WriteLine("td { padding: 10px 8px; border-bottom: 1px solid #ddd; font-size: 14px; }");
                    sw.WriteLine("tr:nth-child(even) { background-color: #f9f9f9; }");
                    sw.WriteLine(".footer { margin-top: 40px; display: flex; justify-content: space-between; font-size: 14px; }");
                    sw.WriteLine(".signature-box { text-align: center; width: 45%; }");
                    sw.WriteLine(".sig-line { border-top: 1px solid #000; margin: 60px 20px 5px 20px; }");
                    sw.WriteLine(".sig-name { font-weight: bold; font-size: 15px; }");
                    sw.WriteLine(".sig-title { font-size: 13px; color: #666; }");
                    sw.WriteLine(".print-btn { text-align: center; margin: 20px 0; }");
                    sw.WriteLine(".print-btn button { padding: 12px 30px; font-size: 16px; background: #00444F; color: white; border: none; cursor: pointer; border-radius: 5px; }");
                    sw.WriteLine("</style></head><body>");

                    sw.WriteLine("<div class='header'>");
                    sw.WriteLine("<h3>Legacy College of Compostela</h3>");
                    sw.WriteLine("<h1>" + reportTitle + "</h1>");
                    sw.WriteLine("<p style='color:#666; font-size:14px;'>IskolarAid Scholarship Management System</p>");
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

                    sw.WriteLine("<p style='text-align:center;color:#888;font-size:12px;margin-top:30px;'>Generated by IskolarAid System | Legacy College of Compostela | " + DateTime.Now.Year + "</p>");

                    if (autoPrint)
                    {
                        sw.WriteLine("<div class='print-btn no-print'><button onclick='window.print()'>🖨️ Print Report</button></div>");
                        sw.WriteLine("<script>window.onload = function() { window.print(); }</script>");
                    }
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