using SkolarAid.form;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SkolarAid.form.Scholar;
namespace SkolarAid
{
    public partial class FrmScholarNotifications : Form
    {
        private int _scholarId;
        private string _scholarName;
        private string _scholarNumber;
        private List<NotificationItem> _notifications;

        public FrmScholarNotifications(int scholarId, string scholarName, string scholarNumber)
        {
            InitializeComponent();
            _scholarId = scholarId;
            _scholarName = scholarName;
            _scholarNumber = scholarNumber;

            LoadNotifications();
        }

        private void FrmScholarNotifications_Load(object sender, EventArgs e)
        {
            lblScholarInfo.Text = $"{_scholarName} | Scholar #: {_scholarNumber}";
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

            cmbFilterType.SelectedIndex = 0;
            chkUnreadOnly.Checked = false;
        }

        private void LoadNotifications()
        {
            // TODO: Load actual data from database
            // These are placeholder values
            _notifications = new List<NotificationItem>
            {
                new NotificationItem {
                    NotificationID = 1,
                    Title = "Payment Released",
                    Message = "Your stipend for March 2026 has been released. Amount: ₱5,000.00 via Bank Transfer.",
                    Type = "Payment",
                    DateSent = new DateTime(2026, 3, 30, 9, 15, 0),
                    IsRead = false,
                    DeliveryMethod = "In-App & SMS"
                },
                new NotificationItem {
                    NotificationID = 2,
                    Title = "Compliance Reminder",
                    Message = "Reminder: Your grades submission is due on March 25, 2026. Please submit before the deadline to avoid delays in stipend processing.",
                    Type = "Reminder",
                    DateSent = new DateTime(2026, 3, 20, 14, 30, 0),
                    IsRead = true,
                    DeliveryMethod = "In-App & SMS"
                },
                new NotificationItem {
                    NotificationID = 3,
                    Title = "Document Approved",
                    Message = "Your enrollment form has been approved by Mrs. Wendy Alcala. Thank you for submitting on time.",
                    Type = "Update",
                    DateSent = new DateTime(2026, 3, 11, 10, 45, 0),
                    IsRead = true,
                    DeliveryMethod = "In-App"
                },
                new NotificationItem {
                    NotificationID = 4,
                    Title = "Important Announcement",
                    Message = "Scholarship renewal period for next semester will start on April 15, 2026. Please prepare your requirements early.",
                    Type = "Announcement",
                    DateSent = new DateTime(2026, 3, 5, 8, 0, 0),
                    IsRead = false,
                    DeliveryMethod = "In-App & SMS"
                },
                new NotificationItem {
                    NotificationID = 5,
                    Title = "Payment Processing",
                    Message = "Your stipend for April 2026 is now being processed. Expected release date: April 30, 2026.",
                    Type = "Payment",
                    DateSent = new DateTime(2026, 4, 1, 11, 20, 0),
                    IsRead = false,
                    DeliveryMethod = "In-App"
                },
                new NotificationItem {
                    NotificationID = 6,
                    Title = "Document Rejected",
                    Message = "Your Good Moral Certificate was rejected. Reason: Document is not original copy. Please submit original document from your previous school.",
                    Type = "Alert",
                    DateSent = new DateTime(2026, 3, 15, 16, 10, 0),
                    IsRead = true,
                    DeliveryMethod = "In-App & SMS"
                },
                new NotificationItem {
                    NotificationID = 7,
                    Title = "Compliance Overdue",
                    Message = "ALERT: Your Parent's Consent form is now OVERDUE. Please submit immediately to avoid scholarship suspension.",
                    Type = "Alert",
                    DateSent = new DateTime(2026, 3, 1, 7, 0, 0),
                    IsRead = false,
                    DeliveryMethod = "SMS"
                }
            };

            UpdateNotificationList();
            UpdateSummaryCards();
        }

        private void UpdateNotificationList()
        {
            flowNotifications.Controls.Clear();

            var filteredNotifications = _notifications.AsEnumerable();

            // Apply type filter
            if (cmbFilterType.SelectedIndex > 0)
            {
                string selectedType = cmbFilterType.SelectedItem.ToString();
                filteredNotifications = filteredNotifications.Where(n => n.Type == selectedType);
            }

            // Apply unread filter
            if (chkUnreadOnly.Checked)
            {
                filteredNotifications = filteredNotifications.Where(n => !n.IsRead);
            }

            foreach (var notification in filteredNotifications.OrderByDescending(n => n.DateSent))
            {
                var notificationPanel = CreateNotificationPanel(notification);
                flowNotifications.Controls.Add(notificationPanel);
            }

            lblTotalRecords.Text = $"Showing {filteredNotifications.Count()} of {_notifications.Count} notifications";
        }

        private Panel CreateNotificationPanel(NotificationItem notification)
        {
            Panel panel = new Panel
            {
                Width = flowNotifications.Width - 25,
                Height = 100,
                BackColor = notification.IsRead ? Color.White : Color.FromArgb(240, 248, 248),
                Margin = new Padding(0, 0, 0, 10)
            };

            // Icon PictureBox
            PictureBox picIcon = new PictureBox
            {
                Location = new Point(15, 15),
                Size = new Size(45, 45),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            // Set icon based on notification type
            switch (notification.Type)
            {
                case "Payment":
                    picIcon.Image = Properties.Resources.dollar;
                    break;
                case "Reminder":
                    picIcon.Image = Properties.Resources.bell__1_;
                    break;
                case "Alert":
                    picIcon.Image = Properties.Resources.file;
                    break;
                case "Announcement":
                    picIcon.Image = Properties.Resources.analysis;
                    break;
                default:
                    picIcon.Image = Properties.Resources.bell__1_;
                    break;
            }

            // Title Label
            Label lblTitle = new Label
            {
                Text = notification.Title,
                Location = new Point(75, 12),
                Size = new Size(panel.Width - 200, 20),
                Font = new Font("Century Gothic", 12, notification.IsRead ? FontStyle.Regular : FontStyle.Bold),
                ForeColor = notification.IsRead ? Color.FromArgb(80, 80, 80) : Color.FromArgb(0, 68, 79)
            };

            // Message Label
            Label lblMessage = new Label
            {
                Text = notification.Message.Length > 60 ? notification.Message.Substring(0, 57) + "..." : notification.Message,
                Location = new Point(75, 35),
                Size = new Size(panel.Width - 200, 40),
                Font = new Font("Century Gothic", 10),
                ForeColor = Color.FromArgb(100, 100, 100)
            };

            // Type Badge
            Label lblType = new Label
            {
                Text = notification.Type,
                Location = new Point(panel.Width - 120, 15),
                Size = new Size(90, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 9, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = GetTypeColor(notification.Type)
            };

            // Date Label
            Label lblDate = new Label
            {
                Text = GetRelativeTime(notification.DateSent),
                Location = new Point(panel.Width - 120, 45),
                Size = new Size(105, 20),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Century Gothic", 9),
                ForeColor = Color.FromArgb(120, 120, 120)
            };

            // Delivery Method Icon
            Label lblDelivery = new Label
            {
                Text = notification.DeliveryMethod.Contains("SMS") ? "📱 SMS" : "📱 In-App",
                Location = new Point(panel.Width - 120, 70),
                Size = new Size(105, 20),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Century Gothic", 8),
                ForeColor = Color.FromArgb(120, 120, 120)
            };

            // Unread indicator
            if (!notification.IsRead)
            {
                Panel unreadIndicator = new Panel
                {
                    Location = new Point(5, 5),
                    Size = new Size(8, 8),
                    BackColor = Color.FromArgb(0, 68, 79)
                };
                panel.Controls.Add(unreadIndicator);
            }

            panel.Controls.AddRange(new Control[] { picIcon, lblTitle, lblMessage, lblType, lblDate, lblDelivery });

            // Click event to view details
            panel.Click += (s, e) => ShowNotificationDetails(notification);
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Click += (s, e) => ShowNotificationDetails(notification);
            }
            panel.Cursor = Cursors.Hand;

            return panel;
        }

        private Color GetTypeColor(string type)
        {
            switch (type)
            {
                case "Payment":
                    return Color.FromArgb(40, 167, 69);
                case "Reminder":
                    return Color.FromArgb(255, 170, 0);
                case "Alert":
                    return Color.FromArgb(239, 68, 68);
                case "Announcement":
                    return Color.FromArgb(0, 123, 255);
                default:
                    return Color.FromArgb(0, 68, 79);
            }
        }

        private string GetRelativeTime(DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan.TotalMinutes < 1)
                return "Just now";
            if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} min ago";
            if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} hour{((int)timeSpan.TotalHours > 1 ? "s" : "")} ago";
            if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} day{((int)timeSpan.TotalDays > 1 ? "s" : "")} ago";

            return dateTime.ToString("MMM dd, yyyy");
        }

        private void ShowNotificationDetails(NotificationItem notification)
        {
            // Mark as read
            if (!notification.IsRead)
            {
                notification.IsRead = true;
                UpdateNotificationList();
                UpdateSummaryCards();
            }

            // Show details in detail panel
            lblDetailTitle.Text = notification.Title;
            lblDetailType.Text = notification.Type;
            lblDetailType.ForeColor = GetTypeColor(notification.Type);
            lblDetailDate.Text = notification.DateSent.ToString("MMMM dd, yyyy • hh:mm tt");
            lblDetailMessage.Text = notification.Message;
            lblDetailDelivery.Text = notification.DeliveryMethod;
            lblDetailStatus.Text = notification.IsRead ? "Read" : "Unread";
            lblDetailStatus.ForeColor = notification.IsRead ? Color.FromArgb(40, 167, 69) : Color.FromArgb(0, 68, 79);
        }

        private void ClearNotificationDetails()
        {
            lblDetailTitle.Text = "Select a notification";
            lblDetailType.Text = "-";
            lblDetailDate.Text = "-";
            lblDetailMessage.Text = "Click on any notification to view its details.";
            lblDetailDelivery.Text = "-";
            lblDetailStatus.Text = "-";
        }

        private void UpdateSummaryCards()
        {
            int totalNotifications = _notifications.Count;
            int unreadCount = _notifications.Count(n => !n.IsRead);
            int paymentNotifs = _notifications.Count(n => n.Type == "Payment");
            int alertNotifs = _notifications.Count(n => n.Type == "Alert");

            lblTotalNotifications.Text = totalNotifications.ToString();
            lblUnreadCount.Text = unreadCount.ToString();
            lblPaymentNotifs.Text = paymentNotifs.ToString();
            lblAlertNotifs.Text = alertNotifs.ToString();
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNotificationList();
        }

        private void chkUnreadOnly_CheckedChanged(object sender, EventArgs e)
        {
            UpdateNotificationList();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbFilterType.SelectedIndex = 0;
            chkUnreadOnly.Checked = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void btnMarkAllRead_Click(object sender, EventArgs e)
        {
            foreach (var notification in _notifications)
            {
                notification.IsRead = true;
            }
            UpdateNotificationList();
            UpdateSummaryCards();
            ClearNotificationDetails();
            MessageBox.Show("All notifications marked as read.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FrmScholarCompliance compliance = new FrmScholarCompliance(_scholarId, _scholarName, _scholarNumber);
            compliance.Show();
            this.Close();
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            // Already on notifications
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

    // Notification item class (temporary - move to Models folder later)
    public class NotificationItem
    {
        public int NotificationID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsRead { get; set; }
        public string DeliveryMethod { get; set; }
    }
}