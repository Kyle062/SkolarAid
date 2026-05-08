using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form.Admin;

namespace SkolarAid.form
{
    public partial class FrmNotifications : Form
    {
        private List<NotificationItem> _notifications = new List<NotificationItem>();
        private DataTable _scholarsData;
        private FlowLayoutPanel flowNotifications;
        private CheckBox chkUnreadOnly;
        private FrameworkTest.SATAButton btnMarkAllRead;
        private Label lblTotalRecords;
        private Panel _selectedPanel = null;

        // ========== DELETE BUTTONS (ADDED) ==========
        // 👇 YOU CAN ADJUST THESE VALUES TO CHANGE BUTTON POSITION AND SIZE
        private FrameworkTest.SATAButton btnDeleteAllRead;
        // Delete All Read button settings:
        // Location: X = 290, Y = 22 (Change these to move the button)
        // Size: Width = 130, Height = 35 (Change these to resize)
        // ============================================

        public FrmNotifications()
        {
            InitializeComponent();
            InitializeCustomControls();
            InitializeDeleteButtons(); // 👈 ADDED: Initialize delete buttons
            this.Load += FrmNotifications_Load;
        }

        // ========== ADDED METHOD: Initialize Delete Buttons ==========
        private void InitializeDeleteButtons()
        {
            // 👇 DELETE ALL READ BUTTON
            // To adjust position: Change X and Y values in Location
            // To adjust size: Change Width and Height values in Size
            this.btnDeleteAllRead = new FrameworkTest.SATAButton
            {
                ButtonText = "Delete All Read",
                Location = new Point(250, 22),      // 👈 X=270, Y=22 (CHANGE THESE TO MOVE BUTTON)
                Size = new Size(110, 35),           // 👈 Width=110, Height=35 (CHANGE THESE TO RESIZE)
                Font = new Font("Century Gothic", 10F),
                NormalBackground = Color.FromArgb(239, 68, 68),  // Red color
                NormalForeColor = Color.White,
                HoverBackground = Color.FromArgb(220, 50, 50),
                Rounding = new Padding(5),
                TextAutoCenter = true
            };
            this.btnDeleteAllRead.Click += BtnDeleteAllRead_Click;
            this.panelFilters.Controls.Add(this.btnDeleteAllRead);
        }

        // ========== ADDED EVENT HANDLER: Delete All Read ==========
        private void BtnDeleteAllRead_Click(object sender, EventArgs e)
        {
            int readCount = _notifications.Count(n => n.IsRead);

            if (readCount == 0)
            {
                MessageBox.Show("No read notifications to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete all {readCount} read notifications?\n\nThis action cannot be undone.",
                "Confirm Delete All Read",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM notifications WHERE is_read = TRUE";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        int affected = cmd.ExecuteNonQuery();

                        ActivityLogger.Log("DELETE", $"Deleted {affected} read notifications");

                        MessageBox.Show($"{affected} read notifications deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadNotifications();
                        LoadStatistics();
                        ClearDetailView();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting notifications: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========== ADDED METHOD: Delete Single Notification ==========
        private void DeleteSingleNotification(int notificationId)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this notification?\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM notifications WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", notificationId);
                        cmd.ExecuteNonQuery();

                        ActivityLogger.Log("DELETE", $"Deleted notification ID: {notificationId}");

                        // Check if the deleted notification was selected
                        if (_selectedPanel != null)
                        {
                            var selectedNotification = _selectedPanel.Tag as NotificationItem;
                            if (selectedNotification != null && selectedNotification.Id == notificationId)
                            {
                                ClearDetailView();
                            }
                        }

                        LoadNotifications();
                        LoadStatistics();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting notification: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========== ADDED METHOD: Clear Detail View ==========
        private void ClearDetailView()
        {
            lblDetailTitle.Text = "Select a notification";
            lblDetailType.Text = "-";
            lblDetailType.ForeColor = Color.Black;
            lblDetailDate.Text = "-";
            lblDetailMessage.Text = "Click on any notification to view its details.";
            lblDetailDelivery.Text = "-";
            lblDetailSMSStatus.Text = "-";
            btnResend.Tag = null;
            _selectedPanel = null;
        }

        private void InitializeCustomControls()
        {
            // Hide the DataGridView since we're using FlowLayoutPanel
            this.dgvNotifications.Visible = false;

            // Create FlowLayoutPanel for notifications
            this.flowNotifications = new FlowLayoutPanel
            {
                Location = new Point(15, 55),
                Size = new Size(panelDataGrid.Width - 30, panelDataGrid.Height - 70),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.White
            };
            this.panelDataGrid.Controls.Add(this.flowNotifications);

            // Create Unread Only checkbox - positioned properly
            // 👇 To adjust checkbox position: Change X and Y values
            this.chkUnreadOnly = new CheckBox
            {
                Text = "Unread Only",
                Location = new Point(20, 28),      // 👈 X=20, Y=28 (CHANGE THESE TO MOVE CHECKBOX)
                Size = new Size(90, 24),          // 👈 Width=100, Height=24 (CHANGE     THESE TO RESIZE)
                Font = new Font("Century Gothic", 10F),
                BackColor = Color.Transparent,
                ForeColor = Color.Black
            };
            this.panelFilters.Controls.Add(this.chkUnreadOnly);

            // Create Mark All as Read button - positioned properly
            // 👇 To adjust button position: Change X and Y values
            this.btnMarkAllRead = new FrameworkTest.SATAButton
            {
                ButtonText = "Mark All as Read",
                Location = new Point(110, 22),     // 👈 X=110, Y=22 (CHANGE THESE TO MOVE BUTTON)
                Size = new Size(140, 35),          // 👈 Width=140, Height=35 (CHANGE THESE TO RESIZE)
                Font = new Font("Century Gothic", 10F),
                NormalBackground = Color.FromArgb(0, 68, 79),
                NormalForeColor = Color.White,
                HoverBackground = Color.FromArgb(0, 90, 105),
                Rounding = new Padding(5),
                TextAutoCenter = true
            };
            this.btnMarkAllRead.Click += BtnMarkAllRead_Click;
            this.panelFilters.Controls.Add(this.btnMarkAllRead);

            // Create Total Records label
            this.lblTotalRecords = new Label
            {
                Location = new Point(15, panelDataGrid.Height - 40),
                Size = new Size(200, 40),
                Font = new Font("Century Gothic", 9F),
                ForeColor = Color.FromArgb(100, 100, 100),
                Text = "Showing 0 notifications"
            };
            this.panelDataGrid.Controls.Add(this.lblTotalRecords);
        }

        private void FrmNotifications_Load(object sender, EventArgs e)
        {
            // Set default selections
            cmbNotificationType.SelectedIndex = 0;
            cmbComposeType.SelectedIndex = 0;
            cmbComposeRecipient.SelectedIndex = 0;
            chkSendInApp.Checked = true;
            chkUnreadOnly.Checked = false;

            // Hide upload button initially
            btnSendNotification.Enabled = false;

            // Load data
            LoadFilterOptions();
            LoadRecipientOptions();
            LoadNotifications();
            LoadStatistics();

            // Wire up events
            btnRefresh.Click += BtnRefresh_Click;
            btnClearFilters.Click += BtnClearFilters_Click;
            btnSendNotification.Click += BtnSendNotification_Click;
            btnClearForm.Click += BtnClearForm_Click;
            btnResend.Click += BtnResend_Click;
            cmbNotificationType.SelectedIndexChanged += Filter_Changed;
            chkUnreadOnly.CheckedChanged += Filter_Changed;
            cmbComposeRecipient.SelectedIndexChanged += CmbComposeRecipient_SelectedIndexChanged;
            txtNotificationTitle.TextChanged += ComposeField_Changed;
            txtNotificationMessage.TextChanged += ComposeField_Changed;
        }

        private void ComposeField_Changed(object sender, EventArgs e)
        {
            btnSendNotification.Enabled = !string.IsNullOrWhiteSpace(txtNotificationTitle.Text) &&
                                         !string.IsNullOrWhiteSpace(txtNotificationMessage.Text) &&
                                         cmbComposeRecipient.SelectedIndex >= 0;
        }

        private void CmbComposeRecipient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComposeField_Changed(sender, e);
        }

        #region Database Loading Methods

        private void LoadFilterOptions()
        {
            try
            {
                cmbNotificationType.Items.Clear();
                cmbNotificationType.Items.Add("All Types");
                cmbNotificationType.Items.Add("Reminder");
                cmbNotificationType.Items.Add("Alert");
                cmbNotificationType.Items.Add("Update");
                cmbNotificationType.Items.Add("Announcement");
                cmbNotificationType.SelectedIndex = 0;

                cmbComposeType.Items.Clear();
                cmbComposeType.Items.Add("Reminder");
                cmbComposeType.Items.Add("Alert");
                cmbComposeType.Items.Add("Update");
                cmbComposeType.Items.Add("Announcement");
                cmbComposeType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading filter options: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecipientOptions()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT id, CONCAT(first_name, ' ', last_name) AS full_name, scholar_number 
                                    FROM scholars WHERE status = 'Active' ORDER BY first_name";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    _scholarsData = new DataTable();
                    adapter.Fill(_scholarsData);

                    cmbComposeRecipient.Items.Clear();
                    cmbComposeRecipient.Items.Add("All Active Scholars");

                    foreach (DataRow row in _scholarsData.Rows)
                    {
                        cmbComposeRecipient.Items.Add($"{row["full_name"]} ({row["scholar_number"]})");
                    }
                }

                if (cmbComposeRecipient.Items.Count > 0)
                    cmbComposeRecipient.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recipients: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                           u.name as sender_name,
                                           CONCAT(s.first_name, ' ', s.last_name) AS recipient_name,
                                           s.scholar_number
                                    FROM notifications n
                                    LEFT JOIN users u ON n.sender_id = u.id
                                    JOIN scholars s ON n.recipient_id = s.id
                                    WHERE 1=1";

                    if (cmbNotificationType.SelectedIndex > 0 && cmbNotificationType.SelectedItem != null)
                        query += " AND n.notification_type = @type";

                    if (chkUnreadOnly.Checked)
                        query += " AND n.is_read = FALSE";

                    query += " ORDER BY n.date_created DESC LIMIT 50";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (cmbNotificationType.SelectedIndex > 0 && cmbNotificationType.SelectedItem != null)
                        cmd.Parameters.AddWithValue("@type", cmbNotificationType.SelectedItem.ToString());

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        _notifications.Clear();

                        while (reader.Read())
                        {
                            _notifications.Add(new NotificationItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Title = reader["title"].ToString(),
                                Message = reader["message"].ToString(),
                                Type = reader["notification_type"].ToString(),
                                DateSent = Convert.ToDateTime(reader["date_created"]),
                                IsRead = Convert.ToBoolean(reader["is_read"]),
                                ReadAt = reader["read_at"] != DBNull.Value ? Convert.ToDateTime(reader["read_at"]) : (DateTime?)null,
                                SenderName = reader["sender_name"]?.ToString() ?? "System",
                                RecipientName = reader["recipient_name"].ToString(),
                                ScholarNumber = reader["scholar_number"].ToString()
                            });
                        }
                    }
                }

                UpdateNotificationList();
                UpdateSummaryCards();
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
            _selectedPanel = null;

            foreach (var notification in _notifications.OrderByDescending(n => n.DateSent))
            {
                var panel = CreateNotificationPanel(notification);
                panel.Tag = notification;
                flowNotifications.Controls.Add(panel);
            }

            lblTotalRecords.Text = $"Showing {_notifications.Count} notifications";

            if (_notifications.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "No notifications found.",
                    Font = new Font("Century Gothic", 11F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(120, 120, 120),
                    Location = new Point(20, 20),
                    AutoSize = true
                };
                flowNotifications.Controls.Add(lblEmpty);
            }
        }

        private Panel CreateNotificationPanel(NotificationItem notification)
        {
            Panel panel = new Panel
            {
                Width = flowNotifications.Width - 30,
                Height = 105,
                BackColor = notification.IsRead ? Color.White : Color.FromArgb(240, 248, 248),
                Margin = new Padding(5, 0, 5, 8),
                Cursor = Cursors.Hand
            };

            // Icon
            PictureBox picIcon = new PictureBox
            {
                Location = new Point(15, 20),
                Size = new Size(40, 40),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            switch (notification.Type)
            {
                case "Payment":
                    picIcon.Image = Properties.Resources.dolllar2;
                    break;
                case "Update":
                    picIcon.Image = Properties.Resources.open_folder;
                    break;
                case "Reminder":
                    picIcon.Image = Properties.Resources.bell2;
                    break;
                case "Alert":
                    picIcon.Image = Properties.Resources.bell2;
                    break;
                default:
                    picIcon.Image = Properties.Resources.bell2;
                    break;
            }

            // Title
            Label lblTitle = new Label
            {
                Text = notification.Title,
                Location = new Point(70, 10),
                Size = new Size(panel.Width - 190, 22),
                Font = new Font("Century Gothic", 11F, notification.IsRead ? FontStyle.Regular : FontStyle.Bold),
                ForeColor = notification.IsRead ? Color.FromArgb(60, 60, 60) : Color.FromArgb(0, 68, 79),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            // Message preview
            string preview = notification.Message.Length > 35 ?
                notification.Message.Substring(0, 32) + "..." : notification.Message;

            Label lblMessage = new Label
            {
                Text = preview,
                Location = new Point(70, 32),
                Size = new Size(panel.Width - 190, 20),
                Font = new Font("Century Gothic", 9F),
                ForeColor = Color.FromArgb(80, 80, 80),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            // Recipient info
            Label lblRecipient = new Label
            {
                Text = $"To: {notification.RecipientName}",
                Location = new Point(70, 52),
                Size = new Size(180, 18),
                Font = new Font("Century Gothic", 8F),
                ForeColor = Color.FromArgb(100, 100, 100),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            // Type badge
            Label lblType = new Label
            {
                Text = notification.Type,
                Location = new Point(panel.Width - 110, 10),
                Size = new Size(85, 22),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 8F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = GetTypeColor(notification.Type),
                Cursor = Cursors.Hand
            };

            // Time
            Label lblTime = new Label
            {
                Text = GetRelativeTime(notification.DateSent),
                Location = new Point(panel.Width - 110, 35),
                Size = new Size(85, 20),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Century Gothic", 8F),
                ForeColor = Color.FromArgb(100, 100, 100),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            // Read/Unread status
            Label lblReadStatus = new Label
            {
                Text = notification.IsRead ? "✓ Read" : "● Unread",
                Location = new Point(panel.Width - 120, 55),
                Size = new Size(75, 18),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Century Gothic", 8F, FontStyle.Bold),
                ForeColor = notification.IsRead ? Color.FromArgb(40, 167, 69) : Color.FromArgb(0, 68, 79),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            // ========== DELETE BUTTON (INDIVIDUAL NOTIFICATION) ==========
            // 👇 To adjust delete button position: Change X and Y values in Location
            // 👇 To adjust delete button size: Change Width and Height values in Size
            Label lblDelete = new Label
            {
                Text = "✕",
                Location = new Point(panel.Width - 26, 8),  // 👈 X = panel.Width - 26, Y = 8 (CHANGE THESE TO MOVE BUTTON)
                Size = new Size(20, 20),                   // 👈 Width=20, Height=20 (CHANGE THESE TO RESIZE)
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                ForeColor = Color.Red,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Tag = notification.Id
            };
            lblDelete.MouseEnter += (s, e) => lblDelete.ForeColor = Color.FromArgb(239, 68, 68);
            lblDelete.MouseLeave += (s, e) => lblDelete.ForeColor = Color.FromArgb(150, 150, 150);
            lblDelete.Click += (s, e) => {
                int id = (int)((Label)s).Tag;
                DeleteSingleNotification(id);
            };
            // =============================================================

            panel.Controls.Add(picIcon);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblMessage);
            panel.Controls.Add(lblRecipient);
            panel.Controls.Add(lblType);
            panel.Controls.Add(lblTime);
            panel.Controls.Add(lblReadStatus);
            panel.Controls.Add(lblDelete); // 👈 ADDED: Delete button

            // Click event - handles selection highlighting (but not on delete button)
            panel.Click += (s, e) => {
                SelectNotificationPanel(panel, notification);
                ShowNotificationDetails(notification);
            };

            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl != lblDelete) // Skip delete button for selection
                {
                    ctrl.Click += (s, e) => {
                        SelectNotificationPanel(panel, notification);
                        ShowNotificationDetails(notification);
                    };
                }
            }

            return panel;
        }

        private void SelectNotificationPanel(Panel selectedPanel, NotificationItem notification)
        {
            // Reset previous selection
            if (_selectedPanel != null)
            {
                var prevNotification = _selectedPanel.Tag as NotificationItem;
                _selectedPanel.BackColor = prevNotification != null && prevNotification.IsRead ?
                    Color.White : Color.FromArgb(240, 248, 248);

                // Reset text colors for previous selection
                foreach (Control ctrl in _selectedPanel.Controls)
                {
                    if (ctrl is Label lbl && ctrl != _selectedPanel.Controls[_selectedPanel.Controls.Count - 1]) // Skip delete button
                    {
                        if (lbl == _selectedPanel.Controls[1]) // Title
                            lbl.ForeColor = prevNotification != null && prevNotification.IsRead ?
                                Color.FromArgb(60, 60, 60) : Color.FromArgb(0, 68, 79);
                        else if (lbl != _selectedPanel.Controls[4]) // Not the type badge
                            lbl.ForeColor = Color.FromArgb(80, 80, 80);
                    }
                }
            }

            // Highlight new selection
            selectedPanel.BackColor = Color.FromArgb(220, 240, 240);
            selectedPanel.BorderStyle = BorderStyle.None;

            _selectedPanel = selectedPanel;
        }

        private Color GetTypeColor(string type)
        {
            switch (type)
            {
                case "Payment": return Color.FromArgb(40, 167, 69);
                case "Reminder": return Color.FromArgb(255, 170, 0);
                case "Alert": return Color.FromArgb(239, 68, 68);
                case "Update": return Color.FromArgb(0, 123, 255);
                case "Announcement": return Color.FromArgb(111, 66, 193);
                default: return Color.FromArgb(0, 68, 79);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Total Sent
                    string totalQuery = "SELECT COUNT(*) FROM notifications";
                    MySqlCommand cmdTotal = new MySqlCommand(totalQuery, conn);
                    lblTotalSent.Text = Convert.ToInt32(cmdTotal.ExecuteScalar()).ToString();

                    // Unread
                    string unreadQuery = "SELECT COUNT(*) FROM notifications WHERE is_read = FALSE";
                    MySqlCommand cmdUnread = new MySqlCommand(unreadQuery, conn);
                    lblPendingSMS.Text = Convert.ToInt32(cmdUnread.ExecuteScalar()).ToString();

                    // Read
                    string deliveredQuery = "SELECT COUNT(*) FROM notifications WHERE is_read = TRUE";
                    MySqlCommand cmdDelivered = new MySqlCommand(deliveredQuery, conn);
                    lblDelivered.Text = Convert.ToInt32(cmdDelivered.ExecuteScalar()).ToString();

                    lblFailedSMS.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading statistics: {ex.Message}");
            }
        }

        private void UpdateSummaryCards()
        {
            int total = _notifications.Count;
            int unread = _notifications.Count(n => !n.IsRead);
            int delivered = _notifications.Count(n => n.IsRead);

            lblTotalSent.Text = total.ToString();
            lblPendingSMS.Text = unread.ToString();
            lblDelivered.Text = delivered.ToString();
        }

        private void ShowNotificationDetails(NotificationItem notification)
        {
            if (!notification.IsRead)
            {
                MarkAsRead(notification.Id);
                notification.IsRead = true;
                UpdateNotificationList();
                UpdateSummaryCards();
            }

            lblDetailTitle.Text = notification.Title;
            lblDetailType.Text = notification.Type;
            lblDetailType.ForeColor = GetTypeColor(notification.Type);
            lblDetailDate.Text = notification.DateSent.ToString("MMMM dd, yyyy • hh:mm tt");
            lblDetailMessage.Text = notification.Message;
            lblDetailDelivery.Text = "In-App";
            lblDetailSMSStatus.Text = notification.IsRead ? "Read" : "Unread";
            lblDetailSMSStatus.ForeColor = notification.IsRead ? Color.FromArgb(40, 167, 69) : Color.FromArgb(0, 68, 79);

            btnResend.Tag = notification;
        }

        private void MarkAsRead(int notificationId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE notifications SET is_read = TRUE, read_at = NOW() WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", notificationId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error marking as read: {ex.Message}");
            }
        }

        private string GetRelativeTime(DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;
            if (timeSpan.TotalMinutes < 1) return "Just now";
            if (timeSpan.TotalMinutes < 60) return $"{(int)timeSpan.TotalMinutes}m ago";
            if (timeSpan.TotalHours < 24) return $"{(int)timeSpan.TotalHours}h ago";
            if (timeSpan.TotalDays < 7) return $"{(int)timeSpan.TotalDays}d ago";
            return dateTime.ToString("MMM dd");
        }

        #endregion

        #region Event Handlers

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotifications();
            LoadStatistics();
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            cmbNotificationType.SelectedIndex = 0;
            chkUnreadOnly.Checked = false;
            LoadNotifications();
        }

        private void BtnMarkAllRead_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE notifications SET is_read = TRUE, read_at = NOW() WHERE is_read = FALSE";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int affected = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{affected} notifications marked as read.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadNotifications();
                    LoadStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking as read: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSendNotification_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNotificationTitle.Text))
            {
                MessageBox.Show("Please enter a notification title.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNotificationMessage.Text))
            {
                MessageBox.Show("Please enter a notification message.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            int senderId = SessionManager.CurrentUser?.Id ?? 1;
                            string type = cmbComposeType.SelectedItem?.ToString() ?? "Update";
                            int successCount = 0;

                            if (cmbComposeRecipient.SelectedIndex == 0)
                            {
                                string insertQuery = @"INSERT INTO notifications 
                                    (sender_id, recipient_id, title, message, notification_type, is_read) 
                                    SELECT @senderId, id, @title, @message, @type, FALSE 
                                    FROM scholars WHERE status = 'Active'";

                                MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction);
                                cmd.Parameters.AddWithValue("@senderId", senderId);
                                cmd.Parameters.AddWithValue("@title", txtNotificationTitle.Text.Trim());
                                cmd.Parameters.AddWithValue("@message", txtNotificationMessage.Text.Trim());
                                cmd.Parameters.AddWithValue("@type", type);

                                successCount = cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                int selectedIndex = cmbComposeRecipient.SelectedIndex - 1;
                                if (selectedIndex >= 0 && selectedIndex < _scholarsData.Rows.Count)
                                {
                                    int recipientId = Convert.ToInt32(_scholarsData.Rows[selectedIndex]["id"]);

                                    string insertQuery = @"INSERT INTO notifications 
                                        (sender_id, recipient_id, title, message, notification_type, is_read) 
                                        VALUES (@senderId, @recipientId, @title, @message, @type, FALSE)";

                                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction);
                                    cmd.Parameters.AddWithValue("@senderId", senderId);
                                    cmd.Parameters.AddWithValue("@recipientId", recipientId);
                                    cmd.Parameters.AddWithValue("@title", txtNotificationTitle.Text.Trim());
                                    cmd.Parameters.AddWithValue("@message", txtNotificationMessage.Text.Trim());
                                    cmd.Parameters.AddWithValue("@type", type);

                                    successCount = cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            ActivityLogger.Log("CREATE", $"Sent notification: {txtNotificationTitle.Text} to {successCount} recipient(s)");

                            MessageBox.Show($"Notification sent successfully to {successCount} recipient(s)!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearComposeForm();
                            LoadNotifications();
                            LoadStatistics();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending notification: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearForm_Click(object sender, EventArgs e)
        {
            ClearComposeForm();
        }

        private void BtnResend_Click(object sender, EventArgs e)
        {
            var notification = btnResend.Tag as NotificationItem;
            if (notification != null)
            {
                txtNotificationTitle.Text = notification.Title;
                txtNotificationMessage.Text = notification.Message;
                cmbComposeType.SelectedItem = notification.Type;
                cmbComposeRecipient.SelectedIndex = 0;
            }
        }

        private void ClearComposeForm()
        {
            txtNotificationTitle.Text = "";
            txtNotificationMessage.Text = "";
            cmbComposeType.SelectedIndex = 0;
            cmbComposeRecipient.SelectedIndex = 0;
            chkSendInApp.Checked = true;
            chkSendSMS.Checked = false;
            btnSendNotification.Enabled = false;
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            LoadNotifications();
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

        private void btnReports_Click(object sender, EventArgs e)
        {
            FrmReportsAnalytics reports = new FrmReportsAnalytics();
            reports.Show();
            this.Hide();
        }

        private void btnActivityLog_Click(object sender, EventArgs e)
        {
            FrmActivityLogs activityLogs = new FrmActivityLogs();
            activityLogs.Show();
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

        #region Designer Event Handlers
        private void sataButton1_Click(object sender, EventArgs e) => btnDashboard_Click(sender, e);
        private void sataButton1_Click_1(object sender, EventArgs e) => btnDashboard_Click(sender, e);
        private void sataButton2_Click_1(object sender, EventArgs e) => btnScholarMgmt_Click(sender, e);
        private void sataButton2_Click_2(object sender, EventArgs e) => btnScholarMgmt_Click(sender, e);
        private void sataButton3_Click(object sender, EventArgs e) => btnPayroll_Click(sender, e);
        private void sataButton3_Click_1(object sender, EventArgs e) => btnPayroll_Click(sender, e);
        private void sataButton4_Click(object sender, EventArgs e) => btnReports_Click(sender, e);
        private void sataButton4_Click_1(object sender, EventArgs e) => btnReports_Click(sender, e);
        private void sataButton5_Click(object sender, EventArgs e) => btnActivityLog_Click(sender, e);
        private void sataButton6_Click(object sender, EventArgs e) { } // Already on Notifications
        private void btnActivityLog_Click_1(object sender, EventArgs e) => btnActivityLog_Click(sender, e);
        private void panelHeader_Paint(object sender, PaintEventArgs e) { }
        #endregion
    }

    // Helper class for notification items
    public class NotificationItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public string SenderName { get; set; }
        public string RecipientName { get; set; }
        public string ScholarNumber { get; set; }
    }
}