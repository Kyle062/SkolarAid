using SkolarAid.form;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class FrmPaymentHistory : Form
    {
        private int _scholarId;
        private string _scholarName;
        private string _scholarNumber;
        private List<PaymentRecord> _paymentRecords;

        public FrmPaymentHistory(int scholarId, string scholarName, string scholarNumber)
        {
            InitializeComponent();
            _scholarId = scholarId;
            _scholarName = scholarName;
            _scholarNumber = scholarNumber;

            LoadPaymentHistory();
        }

        private void FrmPaymentHistory_Load(object sender, EventArgs e)
        {
            lblScholarInfo.Text = $"{_scholarName} | Scholar #: {_scholarNumber}";
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

            // Set filter dropdowns
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterPeriod.SelectedIndex = 0;
        }

        private void LoadPaymentHistory()
        {
            // TODO: Load actual data from database
            // These are placeholder values
            _paymentRecords = new List<PaymentRecord>
            {
                new PaymentRecord {
                    PaymentID = 1,
                    Period = "March 2026",
                    Amount = 5000.00m,
                    Status = "Released",
                    ReleaseDate = new DateTime(2026, 3, 30),
                    PaymentMethod = "Bank Transfer",
                    ReferenceNumber = "TRX-2026-03-001",
                    ProcessedBy = "Mrs. Wendy Alcala"
                },
                new PaymentRecord {
                    PaymentID = 2,
                    Period = "February 2026",
                    Amount = 5000.00m,
                    Status = "Released",
                    ReleaseDate = new DateTime(2026, 2, 28),
                    PaymentMethod = "Bank Transfer",
                    ReferenceNumber = "TRX-2026-02-001",
                    ProcessedBy = "Mrs. Wendy Alcala"
                },
                new PaymentRecord {
                    PaymentID = 3,
                    Period = "January 2026",
                    Amount = 5000.00m,
                    Status = "Released",
                    ReleaseDate = new DateTime(2026, 1, 30),
                    PaymentMethod = "Bank Transfer",
                    ReferenceNumber = "TRX-2026-01-001",
                    ProcessedBy = "Mrs. Wendy Alcala"
                },
                new PaymentRecord {
                    PaymentID = 4,
                    Period = "April 2026",
                    Amount = 5000.00m,
                    Status = "Pending",
                    ReleaseDate = null,
                    PaymentMethod = "Bank Transfer",
                    ReferenceNumber = null,
                    ProcessedBy = null
                }
            };

            UpdatePaymentGrid();
            UpdateSummaryCards();
        }

        private void UpdatePaymentGrid()
        {
            dgvPayments.Rows.Clear();

            var filteredRecords = _paymentRecords.AsEnumerable();

            // Apply status filter
            if (cmbFilterStatus.SelectedIndex > 0)
            {
                string selectedStatus = cmbFilterStatus.SelectedItem.ToString();
                filteredRecords = filteredRecords.Where(p => p.Status == selectedStatus);
            }

            // Apply period filter
            if (cmbFilterPeriod.SelectedIndex > 0)
            {
                string selectedPeriod = cmbFilterPeriod.SelectedItem.ToString();
                if (selectedPeriod == "Last 3 Months")
                {
                    var threeMonthsAgo = DateTime.Now.AddMonths(-3);
                    filteredRecords = filteredRecords.Where(p =>
                        p.ReleaseDate.HasValue && p.ReleaseDate.Value >= threeMonthsAgo);
                }
                else if (selectedPeriod == "Last 6 Months")
                {
                    var sixMonthsAgo = DateTime.Now.AddMonths(-6);
                    filteredRecords = filteredRecords.Where(p =>
                        p.ReleaseDate.HasValue && p.ReleaseDate.Value >= sixMonthsAgo);
                }
                else if (selectedPeriod == "This Year")
                {
                    var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
                    filteredRecords = filteredRecords.Where(p =>
                        p.ReleaseDate.HasValue && p.ReleaseDate.Value >= startOfYear);
                }
            }

            foreach (var payment in filteredRecords.OrderByDescending(p => p.PaymentID))
            {
                int rowIndex = dgvPayments.Rows.Add();
                DataGridViewRow row = dgvPayments.Rows[rowIndex];

                row.Cells["colPaymentID"].Value = payment.PaymentID;
                row.Cells["colPeriod"].Value = payment.Period;
                row.Cells["colAmount"].Value = $"₱{payment.Amount:N2}";
                row.Cells["colStatus"].Value = payment.Status;
                row.Cells["colReleaseDate"].Value = payment.ReleaseDate?.ToString("MMM dd, yyyy") ?? "-";
                row.Cells["colPaymentMethod"].Value = payment.PaymentMethod;

                // Set status cell color
                var statusCell = row.Cells["colStatus"];
                switch (payment.Status)
                {
                    case "Released":
                        statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                        statusCell.Style.Font = new Font(dgvPayments.Font, FontStyle.Bold);
                        break;
                    case "Pending":
                        statusCell.Style.ForeColor = Color.FromArgb(255, 170, 0);
                        statusCell.Style.Font = new Font(dgvPayments.Font, FontStyle.Bold);
                        break;
                    case "Processing":
                        statusCell.Style.ForeColor = Color.FromArgb(0, 123, 255);
                        statusCell.Style.Font = new Font(dgvPayments.Font, FontStyle.Bold);
                        break;
                    case "Failed":
                        statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                        statusCell.Style.Font = new Font(dgvPayments.Font, FontStyle.Bold);
                        break;
                }
            }

            lblTotalRecords.Text = $"Showing {filteredRecords.Count()} of {_paymentRecords.Count} records";
        }

        private void UpdateSummaryCards()
        {
            decimal totalReceived = _paymentRecords
                .Where(p => p.Status == "Released")
                .Sum(p => p.Amount);

            decimal pendingAmount = _paymentRecords
                .Where(p => p.Status == "Pending" || p.Status == "Processing")
                .Sum(p => p.Amount);

            var lastPayment = _paymentRecords
                .Where(p => p.Status == "Released")
                .OrderByDescending(p => p.ReleaseDate)
                .FirstOrDefault();

            int totalPaymentsCount = _paymentRecords.Count(p => p.Status == "Released");

            lblTotalReceived.Text = $"₱{totalReceived:N2}";
            lblPendingAmount.Text = $"₱{pendingAmount:N2}";
            lblLastPayment.Text = lastPayment != null ? $"₱{lastPayment.Amount:N2}" : "₱0.00";
            lblLastPaymentDate.Text = lastPayment?.ReleaseDate?.ToString("MMM dd, yyyy") ?? "-";
            lblTotalPayments.Text = totalPaymentsCount.ToString();
        }

        private void dgvPayments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                var selectedRow = dgvPayments.SelectedRows[0];
                int paymentId = Convert.ToInt32(selectedRow.Cells["colPaymentID"].Value);

                var payment = _paymentRecords.FirstOrDefault(p => p.PaymentID == paymentId);
                if (payment != null)
                {
                    ShowPaymentDetails(payment);
                }
            }
            else
            {
                ClearPaymentDetails();
            }
        }

        private void ShowPaymentDetails(PaymentRecord payment)
        {
            lblDetailPaymentID.Text = $"#{payment.PaymentID}";
            lblDetailPeriod.Text = payment.Period;
            lblDetailAmount.Text = $"₱{payment.Amount:N2}";
            lblDetailStatus.Text = payment.Status;
            lblDetailReleaseDate.Text = payment.ReleaseDate?.ToString("MMMM dd, yyyy") ?? "Pending Release";
            lblDetailPaymentMethod.Text = payment.PaymentMethod;
            lblDetailReference.Text = payment.ReferenceNumber ?? "-";
            lblDetailProcessedBy.Text = payment.ProcessedBy ?? "-";

            // Set status color
            switch (payment.Status)
            {
                case "Released":
                    lblDetailStatus.ForeColor = Color.FromArgb(40, 167, 69);
                    break;
                case "Pending":
                    lblDetailStatus.ForeColor = Color.FromArgb(255, 170, 0);
                    break;
                case "Processing":
                    lblDetailStatus.ForeColor = Color.FromArgb(0, 123, 255);
                    break;
                case "Failed":
                    lblDetailStatus.ForeColor = Color.FromArgb(239, 68, 68);
                    break;
            }
        }

        private void ClearPaymentDetails()
        {
            lblDetailPaymentID.Text = "-";
            lblDetailPeriod.Text = "-";
            lblDetailAmount.Text = "-";
            lblDetailStatus.Text = "-";
            lblDetailReleaseDate.Text = "-";
            lblDetailPaymentMethod.Text = "-";
            lblDetailReference.Text = "-";
            lblDetailProcessedBy.Text = "-";
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePaymentGrid();
        }

        private void cmbFilterPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePaymentGrid();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterPeriod.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPaymentHistory();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "CSV File|*.csv|PDF File|*.pdf";
                saveDialog.Title = "Export Payment History";
                saveDialog.FileName = $"PaymentHistory_{_scholarNumber}_{DateTime.Now:yyyyMMdd}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Implement export functionality
                    MessageBox.Show("Payment history exported successfully!", "Export Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Already on payment history
        }

        private void btnCompliance_Click(object sender, EventArgs e)
        {
            // Navigate to compliance
            // FrmScholarCompliance compliance = new FrmScholarCompliance(_scholarId, _scholarName, _scholarNumber);
            // compliance.Show();
            // this.Close();
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

        private void panelFilters_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    // Payment record class (temporary - move to Models folder later)
    public class PaymentRecord
    {
        public int PaymentID { get; set; }
        public string Period { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; }
        public string ProcessedBy { get; set; }
    }
}