using SkolarAid.form;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SkolarAid.form.Scholar;
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

            LoadComplianceData();
        }

        private void FrmScholarCompliance_Load(object sender, EventArgs e)
        {
            lblScholarInfo.Text = $"{_scholarName} | Scholar #: {_scholarNumber}";
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterType.SelectedIndex = 0;
        }

        private void LoadComplianceData()
        {
            // TODO: Load actual data from database
            // These are placeholder values
            _complianceItems = new List<ComplianceItem>
            {
                new ComplianceItem {
                    ComplianceID = 1,
                    RequirementType = "Grades Submission",
                    Description = "Submit official grades for 1st Semester 2025-2026",
                    DueDate = new DateTime(2026, 3, 25),
                    DateSubmitted = null,
                    Status = "Pending",
                    Remarks = "Awaiting submission",
                    CheckedBy = null
                },
                new ComplianceItem {
                    ComplianceID = 2,
                    RequirementType = "Enrollment Form",
                    Description = "Submit enrollment form for 2nd Semester 2025-2026",
                    DueDate = new DateTime(2026, 3, 15),
                    DateSubmitted = new DateTime(2026, 3, 10),
                    Status = "Approved",
                    Remarks = "Form complete and verified",
                    CheckedBy = "Mrs. Wendy Alcala"
                },
                new ComplianceItem {
                    ComplianceID = 3,
                    RequirementType = "Good Moral Certificate",
                    Description = "Submit Good Moral Certificate from previous semester",
                    DueDate = new DateTime(2026, 4, 10),
                    DateSubmitted = null,
                    Status = "Pending",
                    Remarks = "Must be original copy",
                    CheckedBy = null
                },
                new ComplianceItem {
                    ComplianceID = 4,
                    RequirementType = "Parent's Consent",
                    Description = "Submit signed parent's consent form for scholarship renewal",
                    DueDate = new DateTime(2026, 2, 28),
                    DateSubmitted = new DateTime(2026, 2, 20),
                    Status = "Approved",
                    Remarks = "Signed by parent/guardian",
                    CheckedBy = "Mrs. Wendy Alcala"
                },
                new ComplianceItem {
                    ComplianceID = 5,
                    RequirementType = "Scholarship Contract",
                    Description = "Sign and submit scholarship contract for renewal",
                    DueDate = new DateTime(2026, 3, 1),
                    DateSubmitted = new DateTime(2026, 3, 5),
                    Status = "Submitted",
                    Remarks = "Pending verification",
                    CheckedBy = null
                },
                new ComplianceItem {
                    ComplianceID = 6,
                    RequirementType = "Community Service Report",
                    Description = "Submit community service hours report",
                    DueDate = new DateTime(2026, 5, 15),
                    DateSubmitted = null,
                    Status = "Pending",
                    Remarks = "Minimum 20 hours required",
                    CheckedBy = null
                }
            };

            UpdateComplianceGrid();
            UpdateSummaryCards();
        }

        private void UpdateComplianceGrid()
        {
            dgvCompliance.Rows.Clear();

            var filteredItems = _complianceItems.AsEnumerable();

            // Apply status filter
            if (cmbFilterStatus.SelectedIndex > 0)
            {
                string selectedStatus = cmbFilterStatus.SelectedItem.ToString();
                filteredItems = filteredItems.Where(c => c.Status == selectedStatus);
            }

            // Apply type filter
            if (cmbFilterType.SelectedIndex > 0)
            {
                string selectedType = cmbFilterType.SelectedItem.ToString();
                filteredItems = filteredItems.Where(c => c.RequirementType == selectedType);
            }

            foreach (var item in filteredItems.OrderBy(c => c.DueDate))
            {
                int rowIndex = dgvCompliance.Rows.Add();
                DataGridViewRow row = dgvCompliance.Rows[rowIndex];

                row.Cells["colComplianceID"].Value = item.ComplianceID;
                row.Cells["colRequirementType"].Value = item.RequirementType;
                row.Cells["colDueDate"].Value = item.DueDate.ToString("MMM dd, yyyy");
                row.Cells["colDateSubmitted"].Value = item.DateSubmitted?.ToString("MMM dd, yyyy") ?? "-";
                row.Cells["colStatus"].Value = item.Status;

                // Set status cell color
                var statusCell = row.Cells["colStatus"];
                switch (item.Status)
                {
                    case "Approved":
                        statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                        statusCell.Style.Font = new Font(dgvCompliance.Font, FontStyle.Bold);
                        break;
                    case "Pending":
                        statusCell.Style.ForeColor = Color.FromArgb(255, 170, 0);
                        statusCell.Style.Font = new Font(dgvCompliance.Font, FontStyle.Bold);
                        break;
                    case "Submitted":
                        statusCell.Style.ForeColor = Color.FromArgb(0, 123, 255);
                        statusCell.Style.Font = new Font(dgvCompliance.Font, FontStyle.Bold);
                        break;
                    case "Rejected":
                        statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                        statusCell.Style.Font = new Font(dgvCompliance.Font, FontStyle.Bold);
                        break;
                    case "Overdue":
                        statusCell.Style.ForeColor = Color.FromArgb(220, 38, 38);
                        statusCell.Style.Font = new Font(dgvCompliance.Font, FontStyle.Bold);
                        break;
                }
            }

            lblTotalRecords.Text = $"Showing {filteredItems.Count()} of {_complianceItems.Count} records";
        }

        private void UpdateSummaryCards()
        {
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

            // Set progress bar color based on rate
            if (complianceRate >= 80)
                progressCompliance.ForeColor = Color.FromArgb(40, 167, 69);
            else if (complianceRate >= 50)
                progressCompliance.ForeColor = Color.FromArgb(255, 170, 0);
            else
                progressCompliance.ForeColor = Color.FromArgb(239, 68, 68);
        }

        private void dgvCompliance_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompliance.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCompliance.SelectedRows[0];
                int complianceId = Convert.ToInt32(selectedRow.Cells["colComplianceID"].Value);

                var item = _complianceItems.FirstOrDefault(c => c.ComplianceID == complianceId);
                if (item != null)
                {
                    ShowComplianceDetails(item);
                }
            }
            else
            {
                ClearComplianceDetails();
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
            lblDetailRemarks.Text = item.Remarks ?? "-";
            lblDetailCheckedBy.Text = item.CheckedBy ?? "-";

            // Set status color
            switch (item.Status)
            {
                case "Approved":
                    lblDetailStatus.ForeColor = Color.FromArgb(40, 167, 69);
                    break;
                case "Pending":
                    lblDetailStatus.ForeColor = Color.FromArgb(255, 170, 0);
                    break;
                case "Submitted":
                    lblDetailStatus.ForeColor = Color.FromArgb(0, 123, 255);
                    break;
                case "Rejected":
                    lblDetailStatus.ForeColor = Color.FromArgb(239, 68, 68);
                    break;
                case "Overdue":
                    lblDetailStatus.ForeColor = Color.FromArgb(220, 38, 38);
                    break;
            }

            // Show upload button for pending items
            btnUploadDocument.Visible = item.Status == "Pending" || item.Status == "Rejected";
        }

        private void ClearComplianceDetails()
        {
            lblDetailComplianceID.Text = "-";
            lblDetailRequirementType.Text = "-";
            lblDetailDescription.Text = "-";
            lblDetailDueDate.Text = "-";
            lblDetailDateSubmitted.Text = "-";
            lblDetailStatus.Text = "-";
            lblDetailRemarks.Text = "-";
            lblDetailCheckedBy.Text = "-";
            btnUploadDocument.Visible = false;
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComplianceGrid();
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComplianceGrid();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterType.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadComplianceData();
        }

        private void btnUploadDocument_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Document Files|*.pdf;*.doc;*.docx;*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Upload Requirement Document";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // TODO: Upload document to server/database
                        MessageBox.Show("Document uploaded successfully! Waiting for administrator verification.",
                            "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh data
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmScholarDashboard dashboard = new FrmScholarDashboard(_scholarId, _scholarName, _scholarNumber);
            dashboard.Show();
            this.Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            FrmScholarProfile profile = new FrmScholarProfile(_scholarId, _scholarName, _scholarNumber);
            profile.Show();
            this.Close();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            FrmPaymentHistory payments = new FrmPaymentHistory(_scholarId, _scholarName, _scholarNumber);
            payments.Show();
            this.Close();
        }

        private void btnCompliance_Click(object sender, EventArgs e)
        {
            // Already on compliance
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            // Navigate to notifications
            // FrmScholarNotifications notifications = new FrmScholarNotifications(_scholarId, _scholarName, _scholarNumber);
            // notifications.Show();
            // this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }
    }

    // Compliance item class (temporary - move to Models folder later)
    public class ComplianceItem
    {
        public int ComplianceID { get; set; }
        public string RequirementType { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string CheckedBy { get; set; }
    }
}