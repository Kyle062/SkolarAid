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

            // Setup form
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            lblScholarInfo.Text = $"{_scholarName}";

            cmbFilterType.SelectedIndex = 0;
            chkUnreadOnly.Checked = false;

            // Wire filter events
            cmbFilterType.SelectedIndexChanged += (s, ev) => UpdateNotificationList();
            chkUnreadOnly.CheckedChanged += (s, ev) => UpdateNotificationList();
            btnClearFilters.Click += (s, ev) => { cmbFilterType.SelectedIndex = 0; chkUnreadOnly.Checked = false; };
            btnRefresh.Click += (s, ev) => LoadNotifications();
            btnMarkAllRead.Click += BtnMarkAllRead_Click;

            // Wire sidebar navigation using .Hide()
            btnDashboard.Click += (s, ev) => { new FrmScholarDashboard(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnProfile.Click += (s, ev) => { new FrmScholarProfile(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnPayments.Click += (s, ev) => { new FrmPaymentHistory(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnCompliance.Click += (s, ev) => { new FrmScholarCompliance(_scholarId, _scholarName, _scholarNumber).Show(); this.Hide(); };
            btnNotifications.Click += (s, ev) => { }; // Already on notifications
            btnLogout.Click += BtnLogout_Click;

            // Setup card icons
            picTotalNotifications.Image = Properties.Resources.bell__1_;
            picTotalNotifications.SizeMode = PictureBoxSizeMode.Zoom;
            picUnread.Image = Properties.Resources.bell__1_;
            picUnread.SizeMode = PictureBoxSizeMode.Zoom;
            picPaymentNotifs.Image = Properties.Resources.dollar;
            picPaymentNotifs.SizeMode = PictureBoxSizeMode.Zoom;
            picAlertNotifs.Image = Properties.Resources.file;
            picAlertNotifs.SizeMode = PictureBoxSizeMode.Zoom;

            LoadNotifications();
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

        private void LoadNotifications()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT n.id, n.title, n.message, n.notification_type, 
                                    n.date_created, n.is_read, n.read_at,
                                    COALESCE(u.name, 'System') AS sender_name
                                    FROM notifications n
                                    LEFT JOIN users u ON n.sender_id = u.id
                                    WHERE n.recipient_id = @scholarId
                                    ORDER BY n.date_created DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", _scholarId);

                    _notifications = new List<NotificationItem>();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _notifications.Add(new NotificationItem
                            {
                                NotificationID = Convert.ToInt32(reader["id"]),
                                Title = reader["title"].ToString(),
                                Message = reader["message"].ToString(),
                                Type = reader["notification_type"].ToString(),
                                DateSent = Convert.ToDateTime(reader["date_created"]),
                                IsRead = Convert.ToBoolean(reader["is_read"]),
                                SenderName = reader["sender_name"].ToString()
                            });
                        }
                    }
                }

                UpdateNotificationList();
                UpdateSummaryCards();
                ClearNotificationDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading notifications: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateNotificationList()
        {
            flowNotifications.Controls.Clear();

            if (_notifications == null || _notifications.Count == 0)
            {
                lblTotalRecords.Text = "No notifications found.";
                Label lblEmpty = new Label
                {
                    Text = "📭 No notifications to display.",
                    Font = new Font("Century Gothic", 11F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(120, 120, 120),
                    Location = new Point(20, 20),
                    AutoSize = true
                };
                flowNotifications.Controls.Add(lblEmpty);
                return;
            }

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

            var recordsList = filteredNotifications.OrderByDescending(n => n.DateSent).ToList();

            foreach (var notification in recordsList)
            {
                var notificationPanel = CreateNotificationPanel(notification);
                flowNotifications.Controls.Add(notificationPanel);
            }

            lblTotalRecords.Text = $"Showing {recordsList.Count} of {_notifications.Count} notifications";
        }

        private Panel CreateNotificationPanel(NotificationItem notification)
        {
            Panel panel = new Panel
            {
                Width = flowNotifications.Width - 30,
                Height = 100,
                BackColor = notification.IsRead ? Color.White : Color.FromArgb(240, 248, 248),
                Margin = new Padding(0, 0, 0, 10),
                Cursor = Cursors.Hand
            };

            // Unread indicator dot
            if (!notification.IsRead)
            {
                Panel dot = new Panel
                {
                    Location = new Point(8, 15),
                    Size = new Size(10, 10),
                    BackColor = Color.FromArgb(0, 68, 79)
                };
                panel.Controls.Add(dot);
            }

            // Icon
            PictureBox picIcon = new PictureBox
            {
                Location = new Point(25, 15),
                Size = new Size(40, 40),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            switch (notification.Type)
            {
                case "Payment":
                case "Update":
                    picIcon.Image = Properties.Resources.dollar;
                    break;
                case "Alert":
                    picIcon.Image = Properties.Resources.file;
                    break;
                case "Reminder":
                    picIcon.Image = Properties.Resources.bell__1_;
                    break;
                default:
                    picIcon.Image = Properties.Resources.bell__1_;
                    break;
            }

            // Title
            Label lblTitle = new Label
            {
                Text = notification.Title,
                Location = new Point(75, 12),
                Size = new Size(panel.Width - 200, 22),
                Font = new Font("Century Gothic", 11F, notification.IsRead ? FontStyle.Regular : FontStyle.Bold),
                ForeColor = notification.IsRead ? Color.FromArgb(60, 60, 60) : Color.FromArgb(0, 68, 79),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            // Message preview
            Label lblMessage = new Label
            {
                Text = notification.Message.Length > 55 ? notification.Message.Substring(0, 52) + "..." : notification.Message,
                Location = new Point(75, 35),
                Size = new Size(panel.Width - 200, 20),
                Font = new Font("Century Gothic", 9F),
                ForeColor = Color.FromArgb(100, 100, 100),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            // Sender
            Label lblSender = new Label
            {
                Text = $"From: {notification.SenderName}",
                Location = new Point(75, 55),
                Size = new Size(150, 18),
                Font = new Font("Century Gothic", 8F),
                ForeColor = Color.FromArgb(120, 120, 120),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            // Type badge
            Label lblType = new Label
            {
                Text = notification.Type,
                Location = new Point(panel.Width - 110, 12),
                Size = new Size(85, 22),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 8F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = GetTypeColor(notification.Type),
                Cursor = Cursors.Hand
            };

            // Date
            Label lblDate = new Label
            {
                Text = GetRelativeTime(notification.DateSent),
                Location = new Point(panel.Width - 110, 38),
                Size = new Size(85, 20),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Century Gothic", 8F),
                ForeColor = Color.FromArgb(120, 120, 120),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            // Read status
            Label lblStatus = new Label
            {
                Text = notification.IsRead ? "✓ Read" : "● Unread",
                Location = new Point(panel.Width - 115, 58),
                Size = new Size(90, 18),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Century Gothic", 8F, FontStyle.Bold),
                ForeColor = notification.IsRead ? Color.FromArgb(40, 167, 69) : Color.FromArgb(0, 68, 79),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            panel.Controls.AddRange(new Control[] { picIcon, lblTitle, lblMessage, lblSender, lblType, lblDate, lblStatus });

            // Click event
            panel.Click += (s, e) => ShowNotificationDetails(notification);
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Click += (s, e) => ShowNotificationDetails(notification);
            }

            return panel;
        }

        private Color GetTypeColor(string type)
        {
            switch (type)
            {
                case "Payment":
                case "Update":
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

            if (timeSpan.TotalMinutes < 1) return "Just now";
            if (timeSpan.TotalMinutes < 60) return $"{(int)timeSpan.TotalMinutes}m ago";
            if (timeSpan.TotalHours < 24) return $"{(int)timeSpan.TotalHours}h ago";
            if (timeSpan.TotalDays < 7) return $"{(int)timeSpan.TotalDays}d ago";
            return dateTime.ToString("MMM dd, yyyy");
        }

        private void ShowNotificationDetails(NotificationItem notification)
        {
            // Mark as read in database
            if (!notification.IsRead)
            {
                MarkNotificationAsRead(notification.NotificationID);
                notification.IsRead = true;
                UpdateNotificationList();
                UpdateSummaryCards();
            }

            lblDetailTitle.Text = notification.Title;
            lblDetailType.Text = notification.Type;
            lblDetailType.ForeColor = GetTypeColor(notification.Type);
            lblDetailDate.Text = notification.DateSent.ToString("MMMM dd, yyyy • hh:mm tt");
            lblDetailMessage.Text = notification.Message;
            lblDetailDelivery.Text = "In-App Notification";
            lblDetailStatus.Text = notification.IsRead ? "Read" : "Unread";
            lblDetailStatus.ForeColor = notification.IsRead ? Color.FromArgb(40, 167, 69) : Color.FromArgb(0, 68, 79);
        }

        private void MarkNotificationAsRead(int notificationId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE notifications 
                                    SET is_read = TRUE, read_at = NOW() 
                                    WHERE id = @id AND is_read = FALSE";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", notificationId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        private void ClearNotificationDetails()
        {
            lblDetailTitle.Text = "Select a notification";
            lblDetailType.Text = "-";
            lblDetailType.ForeColor = Color.Gray;
            lblDetailDate.Text = "-";
            lblDetailMessage.Text = "Click on any notification to view its details.";
            lblDetailDelivery.Text = "-";
            lblDetailStatus.Text = "-";
            lblDetailStatus.ForeColor = Color.Gray;
        }

        private void UpdateSummaryCards()
        {
            if (_notifications == null || _notifications.Count == 0)
            {
                lblTotalNotifications.Text = "0";
                lblUnreadCount.Text = "0";
                lblPaymentNotifs.Text = "0";
                lblAlertNotifs.Text = "0";
                return;
            }

            int total = _notifications.Count;
            int unread = _notifications.Count(n => !n.IsRead);
            int payment = _notifications.Count(n => n.Type == "Payment" || n.Type == "Update");
            int alert = _notifications.Count(n => n.Type == "Alert");

            lblTotalNotifications.Text = total.ToString();
            lblUnreadCount.Text = unread.ToString();
            lblPaymentNotifs.Text = payment.ToString();
            lblAlertNotifs.Text = alert.ToString();
        }

        private void BtnMarkAllRead_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE notifications 
                                    SET is_read = TRUE, read_at = NOW() 
                                    WHERE recipient_id = @scholarId AND is_read = FALSE";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", _scholarId);
                    int updated = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{updated} notifications marked as read.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadNotifications();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelContent_Paint(object sender, PaintEventArgs e) { }
    }

    public class NotificationItem
    {
        public int NotificationID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsRead { get; set; }
        public string SenderName { get; set; }
    }
}