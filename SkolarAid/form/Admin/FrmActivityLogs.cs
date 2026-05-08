using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form.Admin;

namespace SkolarAid.form
{
    public partial class FrmActivityLogs : Form
    {
        private int _currentPage = 1;
        private int _totalPages = 1;
        private int _recordsPerPage = 15;
        private DataTable _activityData;

        public FrmActivityLogs()
        {
            InitializeComponent();
            this.Load += FrmActivityLogs_Load_1;
            this.Resize += FrmActivityLogs_Resize;
        }

        private void FrmActivityLogs_Resize(object sender, EventArgs e)
        {
            try { AdjustLayoutForFullscreen(); }
            catch { }
        }

        private void AdjustLayoutForFullscreen()
        {
            int screenWidth = this.ClientSize.Width;
            int screenHeight = this.ClientSize.Height;

            // Stats cards row
            int statsCardWidth = (screenWidth - 320 - 60) / 3;
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

            // Filters bar - full width
            if (panelFilters != null)
            {
                panelFilters.Location = new Point(301, 225);
                panelFilters.Size = new Size(screenWidth - 321, 70);
            }

            // Grid + Detail panels
            int gridWidth = (int)((screenWidth - 321) * 0.72);
            int detailWidth = screenWidth - 321 - gridWidth - 15;

            if (panelDataGrid != null)
            {
                panelDataGrid.Location = new Point(301, 310);
                panelDataGrid.Size = new Size(gridWidth, screenHeight - 380);
            }

            if (panelDetailView != null)
            {
                panelDetailView.Location = new Point(301 + gridWidth + 15, 310);
                panelDetailView.Size = new Size(detailWidth, screenHeight - 380);
            }

            // Pagination bar
            if (panelPagination != null)
            {
                panelPagination.Location = new Point(301, screenHeight - 55);
                panelPagination.Size = new Size(gridWidth, 35);
            }
        }

        private void FrmActivityLogs_Load_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            dtpDateFrom.Value = DateTime.Now.AddDays(-30);
            dtpDateTo.Value = DateTime.Now;
            cmbActionType.SelectedIndex = 0;
            cmbUser.SelectedIndex = 0;

            WireUpEvents();
            LoadFilterOptions();
            LoadActivityLogs();
            LoadStatistics();
            AdjustLayoutForFullscreen();
        }

        private void WireUpEvents()
        {
            btnRefresh.Click -= BtnRefresh_Click;
            btnClearFilters.Click -= BtnClearFilters_Click;
            btnExportLogs.Click -= BtnExportLogs_Click;
            btnFirstPage.Click -= BtnFirstPage_Click;
            btnPrevPage.Click -= BtnPrevPage_Click;
            btnNextPage.Click -= BtnNextPage_Click;
            btnLastPage.Click -= BtnLastPage_Click;
            dgvActivityLogs.SelectionChanged -= DgvActivityLogs_SelectionChanged;
            txtSearch.TextChanged -= TxtSearch_TextChanged;
            cmbActionType.SelectedIndexChanged -= Filter_Changed;
            cmbUser.SelectedIndexChanged -= Filter_Changed;
            dtpDateFrom.ValueChanged -= Filter_Changed;
            dtpDateTo.ValueChanged -= Filter_Changed;

            btnRefresh.Click += BtnRefresh_Click;
            btnClearFilters.Click += BtnClearFilters_Click;
            btnExportLogs.Click += BtnExportLogs_Click;
            btnFirstPage.Click += BtnFirstPage_Click;
            btnPrevPage.Click += BtnPrevPage_Click;
            btnNextPage.Click += BtnNextPage_Click;
            btnLastPage.Click += BtnLastPage_Click;
            dgvActivityLogs.SelectionChanged += DgvActivityLogs_SelectionChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cmbActionType.SelectedIndexChanged += Filter_Changed;
            cmbUser.SelectedIndexChanged += Filter_Changed;
            dtpDateFrom.ValueChanged += Filter_Changed;
            dtpDateTo.ValueChanged += Filter_Changed;
        }

        #region Database Loading Methods

        private void LoadFilterOptions()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string userQuery = "SELECT DISTINCT user_name FROM activity_logs WHERE user_name IS NOT NULL ORDER BY user_name";
                    MySqlCommand cmd = new MySqlCommand(userQuery, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbUser.Items.Clear();
                        cmbUser.Items.Add("All Users");
                        while (reader.Read())
                            cmbUser.Items.Add(reader["user_name"].ToString());
                    }
                }
                if (cmbUser.Items.Count > 0) cmbUser.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show($"Error loading filters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadActivityLogs()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = GetActivityQuery();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

                    adapter.SelectCommand.Parameters.AddWithValue("@dateFrom", dtpDateFrom.Value.ToString("yyyy-MM-dd"));
                    adapter.SelectCommand.Parameters.AddWithValue("@dateTo", dtpDateTo.Value.ToString("yyyy-MM-dd"));

                    if (cmbActionType.SelectedIndex > 0 && cmbActionType.SelectedItem != null)
                        adapter.SelectCommand.Parameters.AddWithValue("@actionType", cmbActionType.SelectedItem.ToString());
                    if (cmbUser.SelectedIndex > 0 && cmbUser.SelectedItem != null)
                        adapter.SelectCommand.Parameters.AddWithValue("@userName", cmbUser.SelectedItem.ToString());
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                        adapter.SelectCommand.Parameters.AddWithValue("@search", $"%{txtSearch.Text}%");

                    _activityData = new DataTable();
                    adapter.Fill(_activityData);

                    _totalPages = (int)Math.Ceiling((double)_activityData.Rows.Count / _recordsPerPage);
                    if (_totalPages == 0) _totalPages = 1;
                    if (_currentPage > _totalPages) _currentPage = _totalPages;

                    DisplayPage();
                    UpdatePaginationInfo();
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error loading logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private string GetActivityQuery()
        {
            string query = @"SELECT id, user_name, 
                            CASE WHEN user_name LIKE '%Admin%' THEN 'ADMIN' ELSE 'USER' END as role,
                            action_type, table_affected, record_id, details, 
                            COALESCE(ip_address, '-') as ip_address, created_at
                            FROM activity_logs
                            WHERE DATE(created_at) BETWEEN @dateFrom AND @dateTo";

            if (cmbActionType.SelectedIndex > 0 && cmbActionType.SelectedItem != null)
                query += " AND action_type = @actionType";
            if (cmbUser.SelectedIndex > 0 && cmbUser.SelectedItem != null)
                query += " AND user_name = @userName";
            if (!string.IsNullOrEmpty(txtSearch.Text))
                query += " AND (user_name LIKE @search OR details LIKE @search OR action_type LIKE @search)";
            query += " ORDER BY created_at DESC";
            return query;
        }

        private void DisplayPage()
        {
            dgvActivityLogs.Rows.Clear();
            int startIndex = (_currentPage - 1) * _recordsPerPage;
            int endIndex = Math.Min(startIndex + _recordsPerPage, _activityData.Rows.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                DataRow row = _activityData.Rows[i];
                int rowIndex = dgvActivityLogs.Rows.Add();
                dgvActivityLogs.Rows[rowIndex].Cells["colLogID"].Value = row["id"];
                dgvActivityLogs.Rows[rowIndex].Cells["colTimestamp"].Value = Convert.ToDateTime(row["created_at"]).ToString("MMM dd, yyyy HH:mm");
                dgvActivityLogs.Rows[rowIndex].Cells["colUser"].Value = row["user_name"];
                dgvActivityLogs.Rows[rowIndex].Cells["colRole"].Value = row["role"];
                dgvActivityLogs.Rows[rowIndex].Cells["colActionType"].Value = row["action_type"];
                dgvActivityLogs.Rows[rowIndex].Cells["colTableAffected"].Value = row["table_affected"]?.ToString() ?? "-";
                dgvActivityLogs.Rows[rowIndex].Cells["colDetails"].Value = row["details"];
                dgvActivityLogs.Rows[rowIndex].Cells["colIPAddress"].Value = row["ip_address"];

                string actionType = row["action_type"].ToString();
                var actionCell = dgvActivityLogs.Rows[rowIndex].Cells["colActionType"];
                if (actionType.Contains("LOGIN") || actionType.Contains("LOGOUT"))
                    actionCell.Style.ForeColor = Color.FromArgb(0, 123, 255);
                else if (actionType.Contains("CREATE") || actionType.Contains("REGISTER"))
                    actionCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                else if (actionType.Contains("UPDATE"))
                    actionCell.Style.ForeColor = Color.FromArgb(255, 193, 7);
                else if (actionType.Contains("DELETE"))
                    actionCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                else if (actionType.Contains("EXPORT") || actionType.Contains("VIEW"))
                    actionCell.Style.ForeColor = Color.FromArgb(111, 66, 193);
                actionCell.Style.Font = new Font(dgvActivityLogs.Font, FontStyle.Bold);
            }
        }

        private void UpdatePaginationInfo()
        {
            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
            btnFirstPage.Enabled = _currentPage > 1;
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
            btnLastPage.Enabled = _currentPage < _totalPages;
            panelPagination.Visible = _totalPages > 1;
        }

        private void LoadStatistics()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    lblTotalLogs.Text = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM activity_logs", conn).ExecuteScalar()).ToString();
                    lblTodayLogs.Text = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM activity_logs WHERE DATE(created_at) = CURDATE()", conn).ExecuteScalar()).ToString();
                    lblUniqueUsers.Text = Convert.ToInt32(new MySqlCommand("SELECT COUNT(DISTINCT user_id) FROM activity_logs WHERE DATE(created_at) = CURDATE()", conn).ExecuteScalar()).ToString();
                }
            }
            catch { }
        }

        private void ShowLogDetails(int logId)
        {
            try
            {
                DataRow[] rows = _activityData.Select($"id = {logId}");
                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    lblDetailTimestamp.Text = $"📅 {Convert.ToDateTime(row["created_at"]):MMMM dd, yyyy HH:mm:ss}";
                    lblDetailUser.Text = $"👤 {row["user_name"]}";
                    lblDetailAction.Text = $"⚡ {row["action_type"]}";
                    lblDetailTable.Text = $"📋 {row["table_affected"]?.ToString() ?? "N/A"}";
                    lblDetailRecordID.Text = $"🔢 Record ID: {row["record_id"]?.ToString() ?? "N/A"}";
                    txtDetailDescription.Text = row["details"].ToString();
                }
            }
            catch { }
        }

        #endregion

        #region Export Methods

        private void ExportToCSV()
        {
            if (dgvActivityLogs.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV File|*.csv";
                    sfd.FileName = $"ActivityLogs_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            for (int i = 0; i < dgvActivityLogs.Columns.Count; i++)
                            { sw.Write(dgvActivityLogs.Columns[i].HeaderText); if (i < dgvActivityLogs.Columns.Count - 1) sw.Write(","); }
                            sw.WriteLine();
                            foreach (DataGridViewRow row in dgvActivityLogs.Rows)
                            {
                                for (int i = 0; i < dgvActivityLogs.Columns.Count; i++)
                                { string value = row.Cells[i].Value?.ToString() ?? ""; if (value.Contains(",")) value = $"\"{value}\""; sw.Write(value); if (i < dgvActivityLogs.Columns.Count - 1) sw.Write(","); }
                                sw.WriteLine();
                            }
                        }
                        MessageBox.Show($"Exported to:\n{sfd.FileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActivityLogger.Log("EXPORT", "Exported activity logs to CSV");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Export error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Event Handlers

        private void BtnRefresh_Click(object sender, EventArgs e) { _currentPage = 1; LoadActivityLogs(); LoadStatistics(); }
        private void BtnClearFilters_Click(object sender, EventArgs e) { cmbActionType.SelectedIndex = 0; cmbUser.SelectedIndex = 0; dtpDateFrom.Value = DateTime.Now.AddDays(-30); dtpDateTo.Value = DateTime.Now; txtSearch.Text = ""; _currentPage = 1; LoadActivityLogs(); }
        private void BtnExportLogs_Click(object sender, EventArgs e) { ExportToCSV(); }
        private void BtnFirstPage_Click(object sender, EventArgs e) { _currentPage = 1; DisplayPage(); UpdatePaginationInfo(); }
        private void BtnPrevPage_Click(object sender, EventArgs e) { if (_currentPage > 1) { _currentPage--; DisplayPage(); UpdatePaginationInfo(); } }
        private void BtnNextPage_Click(object sender, EventArgs e) { if (_currentPage < _totalPages) { _currentPage++; DisplayPage(); UpdatePaginationInfo(); } }
        private void BtnLastPage_Click(object sender, EventArgs e) { _currentPage = _totalPages; DisplayPage(); UpdatePaginationInfo(); }

        private void DgvActivityLogs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvActivityLogs.SelectedRows.Count > 0)
                ShowLogDetails(Convert.ToInt32(dgvActivityLogs.SelectedRows[0].Cells["colLogID"].Value));
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) { _currentPage = 1; LoadActivityLogs(); }
        private void Filter_Changed(object sender, EventArgs e) { _currentPage = 1; LoadActivityLogs(); }

        #endregion

        #region Navigation

        private void btnDashboard_Click(object sender, EventArgs e) { new FrmAdminDashboard().Show(); this.Hide(); }
        private void btnScholarMgmt_Click(object sender, EventArgs e) { new FrmScholarManagement().Show(); this.Hide(); }
        private void btnPayroll_Click(object sender, EventArgs e) { new FrmPayrollProcessing().Show(); this.Hide(); }
        private void btnReports_Click(object sender, EventArgs e) { new FrmReportsAnalytics().Show(); this.Hide(); }
        private void btnReminder_Click(object sender, EventArgs e) { new FrmNotifications().Show(); this.Hide(); }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ActivityLogger.LogLogout(SessionManager.CurrentUser?.Id ?? 0, SessionManager.CurrentUser?.Name ?? "");
            SessionManager.ClearSession();
            new Login().Show(); this.Close();
        }

        #endregion

        private void FrmActivityLogs_Load(object sender, EventArgs e) { }
        private void sataButton1_Click(object sender, EventArgs e) => btnDashboard_Click(sender, e);
        private void sataButton2_Click(object sender, EventArgs e) => btnScholarMgmt_Click(sender, e);
        private void sataButton3_Click(object sender, EventArgs e) => btnPayroll_Click(sender, e);
        private void sataButton4_Click(object sender, EventArgs e) => btnReports_Click(sender, e);
        private void sataButton6_Click(object sender, EventArgs e) => btnReminder_Click(sender, e);

        private void lblPageInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevPage_Click_1(object sender, EventArgs e)
        {

        }

        private void btnFirstPage_Click_1(object sender, EventArgs e)
        {

        }

        private void btnNextPage_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLastPage_Click_1(object sender, EventArgs e)
        {

        }
    }
}