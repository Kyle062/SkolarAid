using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form;
using SkolarAid.form.Scholar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class FrmScholarCompliance : Form
    {
        private int _scholarId;
        private string _scholarName;
        private string _scholarNumber;
        private List<ComplianceItem> _complianceItems;

        public FrmScholarCompliance(int scholarId, string scholarName, string scholarNumber)
        {
            InitializeComponent();
            _scholarId = scholarId;
            _scholarName = scholarName;
            _scholarNumber = scholarNumber;

            // Setup form
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            lblScholarInfo.Text = $"{_scholarName}";

            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterType.SelectedIndex = 0;

            // Setup DataGridView styles - NO color change on selection
            SetupDataGridViewStyles();

            // Wire filter events
            cmbFilterStatus.SelectedIndexChanged += (s, ev) => UpdateComplianceGrid();
            cmbFilterType.SelectedIndexChanged += (s, ev) => UpdateComplianceGrid();
            btnClearFilters.Click += (s, ev) => { cmbFilterStatus.SelectedIndex = 0; cmbFilterType.SelectedIndex = 0; };
            btnRefresh.Click += (s, ev) => LoadComplianceData();
            btnUploadDocument.Click += BtnUploadDocument_Click;
            dgvCompliance.SelectionChanged += dgvCompliance_SelectionChanged;

            // Wire sidebar navigation
            btnDashboard.Click += (s, ev) => { new FrmScholarDashboard(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnProfile.Click += (s, ev) => { new FrmScholarProfile(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnPayments.Click += (s, ev) => { new FrmPaymentHistory(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnCompliance.Click += (s, ev) => { };
            btnNotifications.Click += (s, ev) => { new FrmScholarNotifications(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnLogout.Click += BtnLogout_Click;

            // Setup card icons
            picTotalRequirements.Image = Properties.Resources.file;
            picTotalRequirements.SizeMode = PictureBoxSizeMode.Zoom;
            picCompleted.Image = Properties.Resources.file;
            picCompleted.SizeMode = PictureBoxSizeMode.Zoom;
            picPending.Image = Properties.Resources.file;
            picPending.SizeMode = PictureBoxSizeMode.Zoom;
            picOverdue.Image = Properties.Resources.file;
            picOverdue.SizeMode = PictureBoxSizeMode.Zoom;

            // Hide checked_by and remarks labels
            lblDetailCheckedByLabel.Visible = false;
            lblDetailCheckedBy.Visible = false;
            lblDetailRemarksLabel.Visible = false;
            lblDetailRemarks.Visible = false;

            // Load data
            LoadComplianceData();
        }

        /// <summary>
        /// Setup DataGridView to keep original colors when row is selected
        /// </summary>
        /// <summary>
        /// Setup DataGridView to keep original colors when row is selected
        /// Header stays dark teal (0, 68, 79)
        /// </summary>
        private void SetupDataGridViewStyles()
        {
            // Keep header color (0, 68, 79) even when clicked/sorted
            dgvCompliance.EnableHeadersVisualStyles = false;

            // Force header style
            dgvCompliance.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 68, 79);
            dgvCompliance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCompliance.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            dgvCompliance.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 68, 79);

            // Prevent selection from changing row colors
            dgvCompliance.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvCompliance.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SessionManager.ClearSession();
                new Login().Show();
                this.Close();
            }
        }

        private void LoadComplianceData()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Auto-update overdue items
                    string updateOverdue = @"UPDATE compliance_records 
                                            SET status = 'Overdue' 
                                            WHERE scholar_id = @scholarId 
                                            AND status = 'Pending' 
                                            AND due_date < CURDATE()";
                    MySqlCommand cmdUpdate = new MySqlCommand(updateOverdue, conn);
                    cmdUpdate.Parameters.AddWithValue("@scholarId", _scholarId);
                    cmdUpdate.ExecuteNonQuery();

                    // Auto-set date_submitted = DATE(created_at) for submitted items
                    string updateDates = @"UPDATE compliance_records 
                                          SET date_submitted = DATE(created_at) 
                                          WHERE scholar_id = @scholarId 
                                          AND status IN ('Submitted', 'Approved') 
                                          AND date_submitted IS NULL
                                          AND created_at IS NOT NULL";
                    MySqlCommand cmdDates = new MySqlCommand(updateDates, conn);
                    cmdDates.Parameters.AddWithValue("@scholarId", _scholarId);
                    cmdDates.ExecuteNonQuery();

                    // Load compliance records
                    string query = @"SELECT cr.id, cr.requirement_type, cr.description, 
                                    cr.due_date, cr.date_submitted, cr.status, cr.file_path
                                    FROM compliance_records cr
                                    WHERE cr.scholar_id = @scholarId
                                    ORDER BY 
                                        CASE cr.status 
                                            WHEN 'Overdue' THEN 0 
                                            WHEN 'Rejected' THEN 1
                                            WHEN 'Pending' THEN 2 
                                            WHEN 'Submitted' THEN 3 
                                            WHEN 'Approved' THEN 4 
                                            ELSE 5 
                                        END, 
                                        cr.due_date ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", _scholarId);

                    _complianceItems = new List<ComplianceItem>();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _complianceItems.Add(new ComplianceItem
                            {
                                ComplianceID = Convert.ToInt32(reader["id"]),
                                RequirementType = reader["requirement_type"].ToString(),
                                Description = reader["description"]?.ToString() ?? "",
                                DueDate = Convert.ToDateTime(reader["due_date"]),
                                DateSubmitted = reader["date_submitted"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["date_submitted"]) : (DateTime?)null,
                                Status = reader["status"].ToString(),
                                FilePath = reader["file_path"]?.ToString() ?? ""
                            });
                        }
                    }

                    UpdateFilterTypes();
                }

                UpdateComplianceGrid();
                UpdateSummaryCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading compliance data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFilterTypes()
        {
            cmbFilterType.Items.Clear();
            cmbFilterType.Items.Add("All Types");

            if (_complianceItems != null)
            {
                var types = _complianceItems.Select(c => c.RequirementType).Distinct().OrderBy(t => t);
                foreach (var type in types)
                {
                    cmbFilterType.Items.Add(type);
                }
            }
            cmbFilterType.SelectedIndex = 0;
        }

        private void UpdateComplianceGrid()
        {
            dgvCompliance.Rows.Clear();

            if (_complianceItems == null || _complianceItems.Count == 0)
            {
                lblTotalRecords.Text = "No compliance records found.";
                return;
            }

            var filteredItems = _complianceItems.AsEnumerable();

            if (cmbFilterStatus.SelectedIndex > 0)
            {
                string selectedStatus = cmbFilterStatus.SelectedItem.ToString();
                filteredItems = filteredItems.Where(c => c.Status == selectedStatus);
            }

            if (cmbFilterType.SelectedIndex > 0 && cmbFilterType.SelectedItem != null)
            {
                string selectedType = cmbFilterType.SelectedItem.ToString();
                filteredItems = filteredItems.Where(c => c.RequirementType == selectedType);
            }

            var recordsList = filteredItems.ToList();

            foreach (var item in recordsList)
            {
                int rowIndex = dgvCompliance.Rows.Add();
                DataGridViewRow row = dgvCompliance.Rows[rowIndex];

                row.Cells["colComplianceID"].Value = item.ComplianceID;
                row.Cells["colRequirementType"].Value = item.RequirementType;
                row.Cells["colDueDate"].Value = item.DueDate.ToString("MMM dd, yyyy");
                row.Cells["colDateSubmitted"].Value = item.DateSubmitted?.ToString("MMM dd, yyyy") ?? "Not submitted";
                row.Cells["colStatus"].Value = item.Status;

                // Color code status only - selection won't override this
                var statusCell = row.Cells["colStatus"];
                switch (item.Status)
                {
                    case "Approved":
                        statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                        break;
                    case "Submitted":
                        statusCell.Style.ForeColor = Color.FromArgb(0, 123, 255);
                        break;
                    case "Pending":
                        statusCell.Style.ForeColor = Color.FromArgb(255, 170, 0);
                        break;
                    case "Rejected":
                        statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                        break;
                    case "Overdue":
                        statusCell.Style.ForeColor = Color.FromArgb(220, 38, 38);
                        break;
                }
            }

            lblTotalRecords.Text = $"Showing {recordsList.Count} of {_complianceItems.Count} records";
        }

        private void UpdateSummaryCards()
        {
            if (_complianceItems == null || _complianceItems.Count == 0)
            {
                lblTotalRequirements.Text = "0";
                lblCompleted.Text = "0";
                lblPending.Text = "0";
                lblOverdue.Text = "0";
                lblComplianceRate.Text = "0%";
                progressCompliance.Value = 0;
                return;
            }

            int totalRequirements = _complianceItems.Count;
            int completed = _complianceItems.Count(c => c.Status == "Approved");
            int pending = _complianceItems.Count(c => c.Status == "Pending");
            int overdue = _complianceItems.Count(c => c.Status == "Overdue" ||
                (c.Status == "Pending" && c.DueDate < DateTime.Now));

            double complianceRate = totalRequirements > 0 ?
                Math.Round((double)completed / totalRequirements * 100, 1) : 0;

            lblTotalRequirements.Text = totalRequirements.ToString();
            lblCompleted.Text = completed.ToString();
            lblPending.Text = pending.ToString();
            lblOverdue.Text = overdue.ToString();
            lblComplianceRate.Text = $"{complianceRate}%";
            progressCompliance.Value = (int)complianceRate;
        }

        private void dgvCompliance_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompliance.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCompliance.SelectedRows[0];
                if (selectedRow.Cells["colComplianceID"].Value != null)
                {
                    int complianceId = Convert.ToInt32(selectedRow.Cells["colComplianceID"].Value);
                    var item = _complianceItems.FirstOrDefault(c => c.ComplianceID == complianceId);
                    if (item != null)
                        ShowComplianceDetails(item);
                }
            }
        }

        private void ShowComplianceDetails(ComplianceItem item)
        {
            lblDetailComplianceID.Text = $"#{item.ComplianceID}";
            lblDetailRequirementType.Text = item.RequirementType;
            lblDetailDescription.Text = item.Description;
            lblDetailDueDate.Text = item.DueDate.ToString("MMMM dd, yyyy");
            lblDetailDateSubmitted.Text = item.DateSubmitted?.ToString("MMMM dd, yyyy") ?? "Not yet submitted";
            lblDetailStatus.Text = item.Status;

            switch (item.Status)
            {
                case "Approved":
                    lblDetailStatus.ForeColor = Color.FromArgb(40, 167, 69);
                    break;
                case "Submitted":
                    lblDetailStatus.ForeColor = Color.FromArgb(0, 123, 255);
                    break;
                case "Pending":
                    lblDetailStatus.ForeColor = Color.FromArgb(255, 170, 0);
                    break;
                case "Rejected":
                    lblDetailStatus.ForeColor = Color.FromArgb(239, 68, 68);
                    break;
                case "Overdue":
                    lblDetailStatus.ForeColor = Color.FromArgb(220, 38, 38);
                    break;
            }

            btnUploadDocument.Visible = (item.Status == "Pending" || item.Status == "Rejected");
            btnUploadDocument.Tag = item;
        }

        private void BtnUploadDocument_Click(object sender, EventArgs e)
        {
            var item = btnUploadDocument.Tag as ComplianceItem;
            if (item == null) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Document Files|*.pdf;*.doc;*.docx;*.jpg;*.jpeg;*.png";
                openFileDialog.Title = $"Upload Document for {item.RequirementType}";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        string fileName = System.IO.Path.GetFileName(filePath);

                        using (MySqlConnection conn = DatabaseHelper.GetConnection())
                        {
                            conn.Open();
                            string updateQuery = @"UPDATE compliance_records 
                                                 SET status = 'Submitted', 
                                                     date_submitted = CURDATE(),
                                                     file_path = @filePath,
                                                     updated_at = NOW()
                                                 WHERE id = @id";

                            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                            cmd.Parameters.AddWithValue("@filePath", fileName);
                            cmd.Parameters.AddWithValue("@id", item.ComplianceID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Document uploaded successfully! Waiting for administrator verification.",
                            "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadComplianceData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error uploading document: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void panelContent_Paint(object sender, PaintEventArgs e) { }
    }

    public class ComplianceItem
    {
        public int ComplianceID { get; set; }
        public string RequirementType { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public string Status { get; set; }
        public string FilePath { get; set; }
    }
}