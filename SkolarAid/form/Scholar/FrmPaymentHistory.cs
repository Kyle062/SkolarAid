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

            // Setup form
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            lblScholarInfo.Text = $"{_scholarName}";

            // Set filter dropdowns
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterPeriod.SelectedIndex = 0;

            // Setup DataGridView styles - keep header color, no selection color change
            SetupDataGridViewStyles();

            // Wire filter events
            cmbFilterStatus.SelectedIndexChanged += (s, ev) => UpdatePaymentGrid();
            cmbFilterPeriod.SelectedIndexChanged += (s, ev) => UpdatePaymentGrid();

            // Wire button events
            btnClearFilters.Click += (s, ev) => { cmbFilterStatus.SelectedIndex = 0; cmbFilterPeriod.SelectedIndex = 0; };
            btnRefresh.Click += (s, ev) => LoadPaymentHistory();
            btnExport.Click += (s, ev) => ExportPayments();

            // Wire sidebar navigation
            btnDashboard.Click += (s, ev) => { new FrmScholarDashboard(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnProfile.Click += (s, ev) => { new FrmScholarProfile(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnPayments.Click += (s, ev) => { }; // Already on payment history
            btnCompliance.Click += (s, ev) => { new FrmScholarCompliance(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnNotifications.Click += (s, ev) => { new FrmScholarNotifications(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };

            // Wire logout
            btnLogout.Click += BtnLogout_Click;

            // Wire datagrid selection
            dgvPayments.SelectionChanged += dgvPayments_SelectionChanged;

            // Setup card icons
            picTotalReceived.Image = Properties.Resources.dollar;
            picTotalReceived.SizeMode = PictureBoxSizeMode.Zoom;
            picPendingAmount.Image = Properties.Resources.dollar;
            picPendingAmount.SizeMode = PictureBoxSizeMode.Zoom;
            picLastPayment.Image = Properties.Resources.dollar;
            picLastPayment.SizeMode = PictureBoxSizeMode.Zoom;
            picTotalPayments.Image = Properties.Resources.dollar;
            picTotalPayments.SizeMode = PictureBoxSizeMode.Zoom;

            LoadPaymentHistory();
        }

        /// <summary>
        /// Setup DataGridView to keep header color (0, 68, 79) and prevent selection color change
        /// </summary>
        private void SetupDataGridViewStyles()
        {
            // Keep header color (0, 68, 79) even when clicked/sorted
            dgvPayments.EnableHeadersVisualStyles = false;

            // Force header style
            dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 68, 79);
            dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            dgvPayments.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 68, 79);

            // Prevent selection from changing row colors
            dgvPayments.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPayments.DefaultCellStyle.SelectionForeColor = Color.Black;
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

        private void LoadPaymentHistory()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT id, payment_period, amount, status, release_date, 
                                    payment_method, reference_number, processed_by, remarks,
                                    computation_date, created_at
                                    FROM payments 
                                    WHERE scholar_id = @scholarId 
                                    ORDER BY created_at DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", _scholarId);

                    _paymentRecords = new List<PaymentRecord>();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Get processor name if available
                            string processedByName = "System";
                            if (reader["processed_by"] != DBNull.Value)
                            {
                                try
                                {
                                    using (MySqlConnection conn2 = DatabaseHelper.GetConnection())
                                    {
                                        conn2.Open();
                                        MySqlCommand cmdUser = new MySqlCommand(
                                            "SELECT name FROM users WHERE id = @uid", conn2);
                                        cmdUser.Parameters.AddWithValue("@uid", Convert.ToInt32(reader["processed_by"]));
                                        object userName = cmdUser.ExecuteScalar();
                                        if (userName != null) processedByName = userName.ToString();
                                    }
                                }
                                catch { }
                            }

                            _paymentRecords.Add(new PaymentRecord
                            {
                                PaymentID = Convert.ToInt32(reader["id"]),
                                Period = reader["payment_period"].ToString(),
                                Amount = Convert.ToDecimal(reader["amount"]),
                                Status = reader["status"].ToString(),
                                ReleaseDate = reader["release_date"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["release_date"]) : (DateTime?)null,
                                PaymentMethod = reader["payment_method"].ToString(),
                                ReferenceNumber = reader["reference_number"]?.ToString() ?? "",
                                ProcessedBy = processedByName,
                                Remarks = reader["remarks"]?.ToString() ?? ""
                            });
                        }
                    }
                }

                UpdatePaymentGrid();
                UpdateSummaryCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePaymentGrid()
        {
            dgvPayments.Rows.Clear();

            if (_paymentRecords == null || _paymentRecords.Count == 0)
            {
                lblTotalRecords.Text = "No payment records found.";
                return;
            }

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
                DateTime filterDate = DateTime.Now;

                if (selectedPeriod == "Last 3 Months")
                    filterDate = DateTime.Now.AddMonths(-3);
                else if (selectedPeriod == "Last 6 Months")
                    filterDate = DateTime.Now.AddMonths(-6);
                else if (selectedPeriod == "This Year")
                    filterDate = new DateTime(DateTime.Now.Year, 1, 1);

                filteredRecords = filteredRecords.Where(p =>
                    p.ReleaseDate.HasValue && p.ReleaseDate.Value >= filterDate);
            }

            var recordsList = filteredRecords.ToList();

            foreach (var payment in recordsList)
            {
                int rowIndex = dgvPayments.Rows.Add();
                DataGridViewRow row = dgvPayments.Rows[rowIndex];

                row.Cells["colPaymentID"].Value = payment.PaymentID;
                row.Cells["colPeriod"].Value = payment.Period;
                row.Cells["colAmount"].Value = $"₱{payment.Amount:N2}";
                row.Cells["colStatus"].Value = payment.Status;
                row.Cells["colReleaseDate"].Value = payment.ReleaseDate?.ToString("MMM dd, yyyy") ?? "Pending";
                row.Cells["colPaymentMethod"].Value = payment.PaymentMethod;

                // Color code status
                var statusCell = row.Cells["colStatus"];
                switch (payment.Status)
                {
                    case "Released":
                        statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                        break;
                    case "Pending":
                        statusCell.Style.ForeColor = Color.FromArgb(255, 170, 0);
                        break;
                    case "Processing":
                    case "Processed":
                        statusCell.Style.ForeColor = Color.FromArgb(0, 123, 255);
                        break;
                    case "Failed":
                        statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68);
                        break;
                }
            }

            lblTotalRecords.Text = $"Showing {recordsList.Count} of {_paymentRecords.Count} records";
        }

        private void UpdateSummaryCards()
        {
            if (_paymentRecords == null || _paymentRecords.Count == 0)
            {
                lblTotalReceived.Text = "₱0.00";
                lblPendingAmount.Text = "₱0.00";
                lblLastPayment.Text = "₱0.00";
                lblLastPaymentDate.Text = "-";
                lblTotalPayments.Text = "0";
                return;
            }

            decimal totalReceived = _paymentRecords
                .Where(p => p.Status == "Released")
                .Sum(p => p.Amount);

            decimal pendingAmount = _paymentRecords
                .Where(p => p.Status == "Pending" || p.Status == "Processing" || p.Status == "Processed")
                .Sum(p => p.Amount);

            var lastPayment = _paymentRecords
                .Where(p => p.Status == "Released" && p.ReleaseDate.HasValue)
                .OrderByDescending(p => p.ReleaseDate)
                .FirstOrDefault();

            int totalPaymentsCount = _paymentRecords.Count(p => p.Status == "Released");

            lblTotalReceived.Text = $"₱{totalReceived:N0}";
            lblPendingAmount.Text = $"₱{pendingAmount:N0}";
            lblLastPayment.Text = lastPayment != null ? $"₱{lastPayment.Amount:N0}" : "₱0";
            lblLastPaymentDate.Text = lastPayment?.ReleaseDate?.ToString("MMM dd, yyyy") ?? "-";
            lblTotalPayments.Text = totalPaymentsCount.ToString();
        }

        private void dgvPayments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                var selectedRow = dgvPayments.SelectedRows[0];
                if (selectedRow.Cells["colPaymentID"].Value != null)
                {
                    int paymentId = Convert.ToInt32(selectedRow.Cells["colPaymentID"].Value);
                    var payment = _paymentRecords.FirstOrDefault(p => p.PaymentID == paymentId);
                    if (payment != null)
                        ShowPaymentDetails(payment);
                }
            }
        }

        private void ShowPaymentDetails(PaymentRecord payment)
        {
            lblDetailPaymentID.Text = $"Payment #{payment.PaymentID}";
            lblDetailPeriod.Text = payment.Period;
            lblDetailAmount.Text = $"₱{payment.Amount:N2}";
            lblDetailStatus.Text = payment.Status;
            lblDetailReleaseDate.Text = payment.ReleaseDate?.ToString("MMMM dd, yyyy") ?? "Pending Release";
            lblDetailPaymentMethod.Text = payment.PaymentMethod;
            lblDetailReference.Text = string.IsNullOrEmpty(payment.ReferenceNumber) ? "-" : payment.ReferenceNumber;
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
                case "Processed":
                    lblDetailStatus.ForeColor = Color.FromArgb(0, 123, 255);
                    break;
                case "Failed":
                    lblDetailStatus.ForeColor = Color.FromArgb(239, 68, 68);
                    break;
                default:
                    lblDetailStatus.ForeColor = Color.Black;
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

        private void ExportPayments()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "CSV File|*.csv";
                saveDialog.Title = "Export Payment History";
                saveDialog.FileName = $"PaymentHistory_{_scholarNumber}_{DateTime.Now:yyyyMMdd}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveDialog.FileName))
                        {
                            sw.WriteLine("ID,Period,Amount,Status,Release Date,Payment Method,Reference Number,Processed By");

                            foreach (var payment in _paymentRecords)
                            {
                                sw.WriteLine($"{payment.PaymentID},{payment.Period},{payment.Amount:F2},{payment.Status}," +
                                    $"{payment.ReleaseDate?.ToString("yyyy-MM-dd") ?? ""},{payment.PaymentMethod}," +
                                    $"{payment.ReferenceNumber},{payment.ProcessedBy}");
                            }
                        }

                        MessageBox.Show("Payment history exported successfully!", "Export Complete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void panelFilters_Paint(object sender, PaintEventArgs e) { }
        private void panelContent_Paint(object sender, PaintEventArgs e) { }
    }

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
        public string Remarks { get; set; }
    }
}