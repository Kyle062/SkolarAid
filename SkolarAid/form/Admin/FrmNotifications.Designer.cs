using SATAUiFramework;

namespace SkolarAid.form
{
    partial class FrmNotifications
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius3 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius4 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius5 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius6 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius7 = new SATAUiFramework.BorderRadius();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            SATAUiFramework.BorderRadius borderRadius8 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius9 = new SATAUiFramework.BorderRadius();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotifications));
            this.panelStats1 = new SATAUiFramework.SATAPanel();
            this.lblTotalSent = new System.Windows.Forms.Label();
            this.lblTotalSentLabel = new System.Windows.Forms.Label();
            this.panelStats2 = new SATAUiFramework.SATAPanel();
            this.lblPendingSMS = new System.Windows.Forms.Label();
            this.lblPendingSMSLabel = new System.Windows.Forms.Label();
            this.panelStats3 = new SATAUiFramework.SATAPanel();
            this.lblDelivered = new System.Windows.Forms.Label();
            this.lblDeliveredLabel = new System.Windows.Forms.Label();
            this.panelStats4 = new SATAUiFramework.SATAPanel();
            this.lblFailedSMS = new System.Windows.Forms.Label();
            this.lblFailedSMSLabel = new System.Windows.Forms.Label();
            this.panelFilters = new SATAUiFramework.SATAPanel();
            this.cmbNotificationType = new System.Windows.Forms.ComboBox();
            this.lblNotificationType = new System.Windows.Forms.Label();
            this.cmbDeliveryMethod = new System.Windows.Forms.ComboBox();
            this.lblDeliveryMethod = new System.Windows.Forms.Label();
            this.cmbRecipient = new System.Windows.Forms.ComboBox();
            this.lblRecipient = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnClearFilters = new FrameworkTest.SATAButton();
            this.btnRefresh = new FrameworkTest.SATAButton();
            this.panelCompose = new SATAUiFramework.SATAPanel();
            this.lblComposeTitle = new System.Windows.Forms.Label();
            this.cmbComposeRecipient = new System.Windows.Forms.ComboBox();
            this.lblComposeRecipient = new System.Windows.Forms.Label();
            this.cmbComposeType = new System.Windows.Forms.ComboBox();
            this.lblComposeType = new System.Windows.Forms.Label();
            this.chkSendSMS = new System.Windows.Forms.CheckBox();
            this.chkSendInApp = new System.Windows.Forms.CheckBox();
            this.txtNotificationTitle = new System.Windows.Forms.TextBox();
            this.lblNotificationTitle = new System.Windows.Forms.Label();
            this.txtNotificationMessage = new System.Windows.Forms.RichTextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClearForm = new FrameworkTest.SATAButton();
            this.panelDataGrid = new SATAUiFramework.SATAPanel();
            this.dgvNotifications = new System.Windows.Forms.DataGridView();
            this.colNotificationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateSent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecipient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSMSStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDetailView = new SATAUiFramework.SATAPanel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblDetailDate = new System.Windows.Forms.Label();
            this.lblDetailSender = new System.Windows.Forms.Label();
            this.lblDetailRecipient = new System.Windows.Forms.Label();
            this.lblDetailType = new System.Windows.Forms.Label();
            this.lblDetailDelivery = new System.Windows.Forms.Label();
            this.lblDetailSMSStatus = new System.Windows.Forms.Label();
            this.txtDetailMessage = new System.Windows.Forms.RichTextBox();
            this.lblDetailMessage = new System.Windows.Forms.Label();
            this.btnResend = new FrameworkTest.SATAButton();
            this.btnSendNotification = new FrameworkTest.SATAButton();
            this.picFailedSMS = new System.Windows.Forms.PictureBox();
            this.picDelivered = new System.Windows.Forms.PictureBox();
            this.picPendingSMS = new System.Windows.Forms.PictureBox();
            this.picTotalSent = new System.Windows.Forms.PictureBox();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnReminder = new FrameworkTest.SATAButton();
            this.btnActivityLog = new FrameworkTest.SATAButton();
            this.btnReports = new FrameworkTest.SATAButton();
            this.btnPayroll = new FrameworkTest.SATAButton();
            this.btnScholarMgmt = new FrameworkTest.SATAButton();
            this.btnDashboard = new FrameworkTest.SATAButton();
            this.panelHeader = new SATAUiFramework.SATAPanel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnLogout = new FrameworkTest.SATAButton();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.panelStats1.SuspendLayout();
            this.panelStats2.SuspendLayout();
            this.panelStats3.SuspendLayout();
            this.panelStats4.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.panelCompose.SuspendLayout();
            this.panelDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).BeginInit();
            this.panelDetailView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFailedSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelivered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPendingSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalSent)).BeginInit();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStats1
            // 
            this.panelStats1.BackColor = System.Drawing.Color.White;
            this.panelStats1.BackColor2 = System.Drawing.Color.White;
            this.panelStats1.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.panelStats1.BorderRadius = borderRadius1;
            this.panelStats1.BorderThickness = 0;
            this.panelStats1.Controls.Add(this.lblTotalSent);
            this.panelStats1.Controls.Add(this.lblTotalSentLabel);
            this.panelStats1.Controls.Add(this.picTotalSent);
            this.panelStats1.Location = new System.Drawing.Point(322, 153);
            this.panelStats1.Name = "panelStats1";
            this.panelStats1.Size = new System.Drawing.Size(230, 110);
            this.panelStats1.TabIndex = 4;
            // 
            // lblTotalSent
            // 
            this.lblTotalSent.AutoSize = true;
            this.lblTotalSent.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblTotalSent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblTotalSent.Location = new System.Drawing.Point(70, 40);
            this.lblTotalSent.Name = "lblTotalSent";
            this.lblTotalSent.Size = new System.Drawing.Size(42, 47);
            this.lblTotalSent.TabIndex = 0;
            this.lblTotalSent.Text = "0";
            // 
            // lblTotalSentLabel
            // 
            this.lblTotalSentLabel.AutoSize = true;
            this.lblTotalSentLabel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalSentLabel.ForeColor = System.Drawing.Color.Black;
            this.lblTotalSentLabel.Location = new System.Drawing.Point(74, 15);
            this.lblTotalSentLabel.Name = "lblTotalSentLabel";
            this.lblTotalSentLabel.Size = new System.Drawing.Size(77, 18);
            this.lblTotalSentLabel.TabIndex = 0;
            this.lblTotalSentLabel.Text = "Total Sent";
            // 
            // panelStats2
            // 
            this.panelStats2.BackColor = System.Drawing.Color.White;
            this.panelStats2.BackColor2 = System.Drawing.Color.White;
            this.panelStats2.BorderColor = System.Drawing.Color.Black;
            borderRadius2.BottomLeft = 10;
            borderRadius2.BottomRight = 10;
            borderRadius2.TopLeft = 10;
            borderRadius2.TopRight = 10;
            this.panelStats2.BorderRadius = borderRadius2;
            this.panelStats2.BorderThickness = 0;
            this.panelStats2.Controls.Add(this.lblPendingSMS);
            this.panelStats2.Controls.Add(this.lblPendingSMSLabel);
            this.panelStats2.Controls.Add(this.picPendingSMS);
            this.panelStats2.Location = new System.Drawing.Point(572, 153);
            this.panelStats2.Name = "panelStats2";
            this.panelStats2.Size = new System.Drawing.Size(230, 110);
            this.panelStats2.TabIndex = 5;
            // 
            // lblPendingSMS
            // 
            this.lblPendingSMS.AutoSize = true;
            this.lblPendingSMS.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblPendingSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.lblPendingSMS.Location = new System.Drawing.Point(70, 40);
            this.lblPendingSMS.Name = "lblPendingSMS";
            this.lblPendingSMS.Size = new System.Drawing.Size(42, 47);
            this.lblPendingSMS.TabIndex = 0;
            this.lblPendingSMS.Text = "0";
            // 
            // lblPendingSMSLabel
            // 
            this.lblPendingSMSLabel.AutoSize = true;
            this.lblPendingSMSLabel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblPendingSMSLabel.ForeColor = System.Drawing.Color.Black;
            this.lblPendingSMSLabel.Location = new System.Drawing.Point(74, 15);
            this.lblPendingSMSLabel.Name = "lblPendingSMSLabel";
            this.lblPendingSMSLabel.Size = new System.Drawing.Size(102, 18);
            this.lblPendingSMSLabel.TabIndex = 0;
            this.lblPendingSMSLabel.Text = "Pending SMS";
            // 
            // panelStats3
            // 
            this.panelStats3.BackColor = System.Drawing.Color.White;
            this.panelStats3.BackColor2 = System.Drawing.Color.White;
            this.panelStats3.BorderColor = System.Drawing.Color.Black;
            borderRadius3.BottomLeft = 10;
            borderRadius3.BottomRight = 10;
            borderRadius3.TopLeft = 10;
            borderRadius3.TopRight = 10;
            this.panelStats3.BorderRadius = borderRadius3;
            this.panelStats3.BorderThickness = 0;
            this.panelStats3.Controls.Add(this.lblDelivered);
            this.panelStats3.Controls.Add(this.lblDeliveredLabel);
            this.panelStats3.Controls.Add(this.picDelivered);
            this.panelStats3.Location = new System.Drawing.Point(822, 153);
            this.panelStats3.Name = "panelStats3";
            this.panelStats3.Size = new System.Drawing.Size(230, 110);
            this.panelStats3.TabIndex = 6;
            // 
            // lblDelivered
            // 
            this.lblDelivered.AutoSize = true;
            this.lblDelivered.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblDelivered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblDelivered.Location = new System.Drawing.Point(70, 40);
            this.lblDelivered.Name = "lblDelivered";
            this.lblDelivered.Size = new System.Drawing.Size(42, 47);
            this.lblDelivered.TabIndex = 0;
            this.lblDelivered.Text = "0";
            // 
            // lblDeliveredLabel
            // 
            this.lblDeliveredLabel.AutoSize = true;
            this.lblDeliveredLabel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblDeliveredLabel.ForeColor = System.Drawing.Color.Black;
            this.lblDeliveredLabel.Location = new System.Drawing.Point(74, 15);
            this.lblDeliveredLabel.Name = "lblDeliveredLabel";
            this.lblDeliveredLabel.Size = new System.Drawing.Size(80, 18);
            this.lblDeliveredLabel.TabIndex = 0;
            this.lblDeliveredLabel.Text = "Delivered";
            // 
            // panelStats4
            // 
            this.panelStats4.BackColor = System.Drawing.Color.White;
            this.panelStats4.BackColor2 = System.Drawing.Color.White;
            this.panelStats4.BorderColor = System.Drawing.Color.Black;
            borderRadius4.BottomLeft = 10;
            borderRadius4.BottomRight = 10;
            borderRadius4.TopLeft = 10;
            borderRadius4.TopRight = 10;
            this.panelStats4.BorderRadius = borderRadius4;
            this.panelStats4.BorderThickness = 0;
            this.panelStats4.Controls.Add(this.lblFailedSMS);
            this.panelStats4.Controls.Add(this.lblFailedSMSLabel);
            this.panelStats4.Controls.Add(this.picFailedSMS);
            this.panelStats4.Location = new System.Drawing.Point(1072, 153);
            this.panelStats4.Name = "panelStats4";
            this.panelStats4.Size = new System.Drawing.Size(230, 110);
            this.panelStats4.TabIndex = 7;
            // 
            // lblFailedSMS
            // 
            this.lblFailedSMS.AutoSize = true;
            this.lblFailedSMS.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblFailedSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.lblFailedSMS.Location = new System.Drawing.Point(70, 40);
            this.lblFailedSMS.Name = "lblFailedSMS";
            this.lblFailedSMS.Size = new System.Drawing.Size(42, 47);
            this.lblFailedSMS.TabIndex = 0;
            this.lblFailedSMS.Text = "0";
            // 
            // lblFailedSMSLabel
            // 
            this.lblFailedSMSLabel.AutoSize = true;
            this.lblFailedSMSLabel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblFailedSMSLabel.ForeColor = System.Drawing.Color.Black;
            this.lblFailedSMSLabel.Location = new System.Drawing.Point(74, 15);
            this.lblFailedSMSLabel.Name = "lblFailedSMSLabel";
            this.lblFailedSMSLabel.Size = new System.Drawing.Size(87, 18);
            this.lblFailedSMSLabel.TabIndex = 0;
            this.lblFailedSMSLabel.Text = "Failed SMS";
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.BackColor2 = System.Drawing.Color.White;
            this.panelFilters.BorderColor = System.Drawing.Color.Black;
            borderRadius5.BottomLeft = 10;
            borderRadius5.BottomRight = 10;
            borderRadius5.TopLeft = 10;
            borderRadius5.TopRight = 10;
            this.panelFilters.BorderRadius = borderRadius5;
            this.panelFilters.BorderThickness = 0;
            this.panelFilters.Controls.Add(this.cmbNotificationType);
            this.panelFilters.Controls.Add(this.lblNotificationType);
            this.panelFilters.Controls.Add(this.cmbDeliveryMethod);
            this.panelFilters.Controls.Add(this.lblDeliveryMethod);
            this.panelFilters.Controls.Add(this.cmbRecipient);
            this.panelFilters.Controls.Add(this.lblRecipient);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Controls.Add(this.btnClearFilters);
            this.panelFilters.Controls.Add(this.btnRefresh);
            this.panelFilters.Location = new System.Drawing.Point(321, 269);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1356, 75);
            this.panelFilters.TabIndex = 8;
            // 
            // cmbNotificationType
            // 
            this.cmbNotificationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNotificationType.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbNotificationType.FormattingEnabled = true;
            this.cmbNotificationType.Items.AddRange(new object[] {
            "All Types",
            "Reminder",
            "Alert",
            "Update",
            "Announcement"});
            this.cmbNotificationType.Location = new System.Drawing.Point(323, 31);
            this.cmbNotificationType.Name = "cmbNotificationType";
            this.cmbNotificationType.Size = new System.Drawing.Size(140, 28);
            this.cmbNotificationType.TabIndex = 3;
            // 
            // lblNotificationType
            // 
            this.lblNotificationType.AutoSize = true;
            this.lblNotificationType.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblNotificationType.Location = new System.Drawing.Point(320, 11);
            this.lblNotificationType.Name = "lblNotificationType";
            this.lblNotificationType.Size = new System.Drawing.Size(39, 17);
            this.lblNotificationType.TabIndex = 2;
            this.lblNotificationType.Text = "Type";
            // 
            // cmbDeliveryMethod
            // 
            this.cmbDeliveryMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryMethod.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbDeliveryMethod.FormattingEnabled = true;
            this.cmbDeliveryMethod.Items.AddRange(new object[] {
            "All Methods",
            "SMS",
            "In-App",
            "Both"});
            this.cmbDeliveryMethod.Location = new System.Drawing.Point(483, 31);
            this.cmbDeliveryMethod.Name = "cmbDeliveryMethod";
            this.cmbDeliveryMethod.Size = new System.Drawing.Size(120, 28);
            this.cmbDeliveryMethod.TabIndex = 3;
            // 
            // lblDeliveryMethod
            // 
            this.lblDeliveryMethod.AutoSize = true;
            this.lblDeliveryMethod.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblDeliveryMethod.Location = new System.Drawing.Point(480, 11);
            this.lblDeliveryMethod.Name = "lblDeliveryMethod";
            this.lblDeliveryMethod.Size = new System.Drawing.Size(60, 17);
            this.lblDeliveryMethod.TabIndex = 2;
            this.lblDeliveryMethod.Text = "Method";
            // 
            // cmbRecipient
            // 
            this.cmbRecipient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipient.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbRecipient.FormattingEnabled = true;
            this.cmbRecipient.Items.AddRange(new object[] {
            "All Recipients"});
            this.cmbRecipient.Location = new System.Drawing.Point(163, 31);
            this.cmbRecipient.Name = "cmbRecipient";
            this.cmbRecipient.Size = new System.Drawing.Size(140, 28);
            this.cmbRecipient.TabIndex = 3;
            // 
            // lblRecipient
            // 
            this.lblRecipient.AutoSize = true;
            this.lblRecipient.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecipient.Location = new System.Drawing.Point(160, 11);
            this.lblRecipient.Name = "lblRecipient";
            this.lblRecipient.Size = new System.Drawing.Size(72, 17);
            this.lblRecipient.TabIndex = 2;
            this.lblRecipient.Text = "Recipient";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtSearch.Location = new System.Drawing.Point(23, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(20, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(54, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.ButtonText = "Clear";
            this.btnClearFilters.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnClearFilters.CheckedForeColor = System.Drawing.Color.White;
            this.btnClearFilters.CheckedImageTint = System.Drawing.Color.White;
            this.btnClearFilters.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnClearFilters.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClearFilters.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnClearFilters.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClearFilters.HoverForeColor = System.Drawing.Color.White;
            this.btnClearFilters.HoverImage = null;
            this.btnClearFilters.HoverImageTint = System.Drawing.Color.White;
            this.btnClearFilters.HoverOutline = System.Drawing.Color.Empty;
            this.btnClearFilters.Image = null;
            this.btnClearFilters.ImageAutoCenter = true;
            this.btnClearFilters.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnClearFilters.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnClearFilters.ImageTint = System.Drawing.Color.White;
            this.btnClearFilters.IsToggleButton = false;
            this.btnClearFilters.IsToggled = false;
            this.btnClearFilters.Location = new System.Drawing.Point(1259, 21);
            this.btnClearFilters.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.NormalBackground = System.Drawing.Color.Gray;
            this.btnClearFilters.NormalForeColor = System.Drawing.Color.White;
            this.btnClearFilters.NormalOutline = System.Drawing.Color.Empty;
            this.btnClearFilters.OutlineThickness = 2F;
            this.btnClearFilters.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnClearFilters.PressedForeColor = System.Drawing.Color.White;
            this.btnClearFilters.PressedImageTint = System.Drawing.Color.White;
            this.btnClearFilters.PressedOutline = System.Drawing.Color.Empty;
            this.btnClearFilters.Rounding = new System.Windows.Forms.Padding(5);
            this.btnClearFilters.Size = new System.Drawing.Size(80, 35);
            this.btnClearFilters.TabIndex = 5;
            this.btnClearFilters.TextAutoCenter = true;
            this.btnClearFilters.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonText = "Refresh";
            this.btnRefresh.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnRefresh.CheckedForeColor = System.Drawing.Color.White;
            this.btnRefresh.CheckedImageTint = System.Drawing.Color.White;
            this.btnRefresh.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnRefresh.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefresh.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnRefresh.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnRefresh.HoverForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverImage = null;
            this.btnRefresh.HoverImageTint = System.Drawing.Color.White;
            this.btnRefresh.HoverOutline = System.Drawing.Color.Empty;
            this.btnRefresh.Image = null;
            this.btnRefresh.ImageAutoCenter = true;
            this.btnRefresh.ImageExpand = new System.Drawing.Point(8, 8);
            this.btnRefresh.ImageOffset = new System.Drawing.Point(-10, 0);
            this.btnRefresh.ImageTint = System.Drawing.Color.White;
            this.btnRefresh.IsToggleButton = false;
            this.btnRefresh.IsToggled = false;
            this.btnRefresh.Location = new System.Drawing.Point(1139, 21);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnRefresh.NormalForeColor = System.Drawing.Color.White;
            this.btnRefresh.NormalOutline = System.Drawing.Color.Empty;
            this.btnRefresh.OutlineThickness = 2F;
            this.btnRefresh.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnRefresh.PressedForeColor = System.Drawing.Color.White;
            this.btnRefresh.PressedImageTint = System.Drawing.Color.White;
            this.btnRefresh.PressedOutline = System.Drawing.Color.Empty;
            this.btnRefresh.Rounding = new System.Windows.Forms.Padding(5);
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.TextAutoCenter = true;
            this.btnRefresh.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // panelCompose
            // 
            this.panelCompose.BackColor = System.Drawing.Color.White;
            this.panelCompose.BackColor2 = System.Drawing.Color.White;
            this.panelCompose.BorderColor = System.Drawing.Color.Black;
            borderRadius6.BottomLeft = 10;
            borderRadius6.BottomRight = 10;
            borderRadius6.TopLeft = 10;
            borderRadius6.TopRight = 10;
            this.panelCompose.BorderRadius = borderRadius6;
            this.panelCompose.BorderThickness = 0;
            this.panelCompose.Controls.Add(this.lblComposeTitle);
            this.panelCompose.Controls.Add(this.cmbComposeRecipient);
            this.panelCompose.Controls.Add(this.lblComposeRecipient);
            this.panelCompose.Controls.Add(this.cmbComposeType);
            this.panelCompose.Controls.Add(this.lblComposeType);
            this.panelCompose.Controls.Add(this.chkSendSMS);
            this.panelCompose.Controls.Add(this.chkSendInApp);
            this.panelCompose.Controls.Add(this.txtNotificationTitle);
            this.panelCompose.Controls.Add(this.lblNotificationTitle);
            this.panelCompose.Controls.Add(this.txtNotificationMessage);
            this.panelCompose.Controls.Add(this.lblMessage);
            this.panelCompose.Controls.Add(this.btnSendNotification);
            this.panelCompose.Controls.Add(this.btnClearForm);
            this.panelCompose.Location = new System.Drawing.Point(321, 350);
            this.panelCompose.Name = "panelCompose";
            this.panelCompose.Size = new System.Drawing.Size(580, 672);
            this.panelCompose.TabIndex = 9;
            // 
            // lblComposeTitle
            // 
            this.lblComposeTitle.AutoSize = true;
            this.lblComposeTitle.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.lblComposeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblComposeTitle.Location = new System.Drawing.Point(20, 20);
            this.lblComposeTitle.Name = "lblComposeTitle";
            this.lblComposeTitle.Size = new System.Drawing.Size(211, 23);
            this.lblComposeTitle.TabIndex = 0;
            this.lblComposeTitle.Text = "Compose Notification";
            // 
            // cmbComposeRecipient
            // 
            this.cmbComposeRecipient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComposeRecipient.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbComposeRecipient.FormattingEnabled = true;
            this.cmbComposeRecipient.Items.AddRange(new object[] {
            "All Active Scholars",
            "Select Specific Scholars..."});
            this.cmbComposeRecipient.Location = new System.Drawing.Point(24, 80);
            this.cmbComposeRecipient.Name = "cmbComposeRecipient";
            this.cmbComposeRecipient.Size = new System.Drawing.Size(250, 28);
            this.cmbComposeRecipient.TabIndex = 3;
            // 
            // lblComposeRecipient
            // 
            this.lblComposeRecipient.AutoSize = true;
            this.lblComposeRecipient.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblComposeRecipient.Location = new System.Drawing.Point(21, 60);
            this.lblComposeRecipient.Name = "lblComposeRecipient";
            this.lblComposeRecipient.Size = new System.Drawing.Size(72, 17);
            this.lblComposeRecipient.TabIndex = 2;
            this.lblComposeRecipient.Text = "Recipient";
            // 
            // cmbComposeType
            // 
            this.cmbComposeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComposeType.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbComposeType.FormattingEnabled = true;
            this.cmbComposeType.Items.AddRange(new object[] {
            "Reminder",
            "Alert",
            "Update",
            "Announcement"});
            this.cmbComposeType.Location = new System.Drawing.Point(300, 80);
            this.cmbComposeType.Name = "cmbComposeType";
            this.cmbComposeType.Size = new System.Drawing.Size(250, 28);
            this.cmbComposeType.TabIndex = 3;
            // 
            // lblComposeType
            // 
            this.lblComposeType.AutoSize = true;
            this.lblComposeType.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblComposeType.Location = new System.Drawing.Point(297, 60);
            this.lblComposeType.Name = "lblComposeType";
            this.lblComposeType.Size = new System.Drawing.Size(121, 17);
            this.lblComposeType.TabIndex = 2;
            this.lblComposeType.Text = "Notification Type";
            // 
            // chkSendSMS
            // 
            this.chkSendSMS.AutoSize = true;
            this.chkSendSMS.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.chkSendSMS.Location = new System.Drawing.Point(200, 125);
            this.chkSendSMS.Name = "chkSendSMS";
            this.chkSendSMS.Size = new System.Drawing.Size(94, 23);
            this.chkSendSMS.TabIndex = 4;
            this.chkSendSMS.Text = "Send SMS";
            this.chkSendSMS.UseVisualStyleBackColor = true;
            // 
            // chkSendInApp
            // 
            this.chkSendInApp.AutoSize = true;
            this.chkSendInApp.Checked = true;
            this.chkSendInApp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendInApp.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.chkSendInApp.Location = new System.Drawing.Point(24, 125);
            this.chkSendInApp.Name = "chkSendInApp";
            this.chkSendInApp.Size = new System.Drawing.Size(196, 23);
            this.chkSendInApp.TabIndex = 4;
            this.chkSendInApp.Text = "Send In-App Notification";
            this.chkSendInApp.UseVisualStyleBackColor = true;
            // 
            // txtNotificationTitle
            // 
            this.txtNotificationTitle.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtNotificationTitle.Location = new System.Drawing.Point(24, 175);
            this.txtNotificationTitle.Name = "txtNotificationTitle";
            this.txtNotificationTitle.Size = new System.Drawing.Size(526, 26);
            this.txtNotificationTitle.TabIndex = 1;
            // 
            // lblNotificationTitle
            // 
            this.lblNotificationTitle.AutoSize = true;
            this.lblNotificationTitle.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblNotificationTitle.Location = new System.Drawing.Point(21, 155);
            this.lblNotificationTitle.Name = "lblNotificationTitle";
            this.lblNotificationTitle.Size = new System.Drawing.Size(117, 17);
            this.lblNotificationTitle.TabIndex = 0;
            this.lblNotificationTitle.Text = "Notification Title";
            // 
            // txtNotificationMessage
            // 
            this.txtNotificationMessage.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtNotificationMessage.Location = new System.Drawing.Point(24, 240);
            this.txtNotificationMessage.Name = "txtNotificationMessage";
            this.txtNotificationMessage.Size = new System.Drawing.Size(526, 200);
            this.txtNotificationMessage.TabIndex = 5;
            this.txtNotificationMessage.Text = "";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Location = new System.Drawing.Point(21, 220);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(69, 17);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message";
            // 
            // btnClearForm
            // 
            this.btnClearForm.ButtonText = "Clear Form";
            this.btnClearForm.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnClearForm.CheckedForeColor = System.Drawing.Color.White;
            this.btnClearForm.CheckedImageTint = System.Drawing.Color.White;
            this.btnClearForm.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnClearForm.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClearForm.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.btnClearForm.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClearForm.HoverForeColor = System.Drawing.Color.White;
            this.btnClearForm.HoverImage = null;
            this.btnClearForm.HoverImageTint = System.Drawing.Color.White;
            this.btnClearForm.HoverOutline = System.Drawing.Color.Empty;
            this.btnClearForm.Image = null;
            this.btnClearForm.ImageAutoCenter = true;
            this.btnClearForm.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnClearForm.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnClearForm.ImageTint = System.Drawing.Color.White;
            this.btnClearForm.IsToggleButton = false;
            this.btnClearForm.IsToggled = false;
            this.btnClearForm.Location = new System.Drawing.Point(24, 480);
            this.btnClearForm.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.NormalBackground = System.Drawing.Color.Gray;
            this.btnClearForm.NormalForeColor = System.Drawing.Color.White;
            this.btnClearForm.NormalOutline = System.Drawing.Color.Empty;
            this.btnClearForm.OutlineThickness = 2F;
            this.btnClearForm.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnClearForm.PressedForeColor = System.Drawing.Color.White;
            this.btnClearForm.PressedImageTint = System.Drawing.Color.White;
            this.btnClearForm.PressedOutline = System.Drawing.Color.Empty;
            this.btnClearForm.Rounding = new System.Windows.Forms.Padding(5);
            this.btnClearForm.Size = new System.Drawing.Size(120, 50);
            this.btnClearForm.TabIndex = 6;
            this.btnClearForm.TextAutoCenter = true;
            this.btnClearForm.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.BackColor = System.Drawing.Color.White;
            this.panelDataGrid.BackColor2 = System.Drawing.Color.White;
            this.panelDataGrid.BorderColor = System.Drawing.Color.Black;
            borderRadius7.BottomLeft = 10;
            borderRadius7.BottomRight = 10;
            borderRadius7.TopLeft = 10;
            borderRadius7.TopRight = 10;
            this.panelDataGrid.BorderRadius = borderRadius7;
            this.panelDataGrid.BorderThickness = 0;
            this.panelDataGrid.Controls.Add(this.dgvNotifications);
            this.panelDataGrid.Location = new System.Drawing.Point(921, 350);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(475, 672);
            this.panelDataGrid.TabIndex = 10;
            // 
            // dgvNotifications
            // 
            this.dgvNotifications.AllowUserToAddRows = false;
            this.dgvNotifications.AllowUserToDeleteRows = false;
            this.dgvNotifications.AllowUserToResizeRows = false;
            this.dgvNotifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotifications.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotifications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNotifications.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotifications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNotifications.ColumnHeadersHeight = 40;
            this.dgvNotifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNotificationID,
            this.colDateSent,
            this.colRecipient,
            this.colTitle,
            this.colType,
            this.colDeliveryMethod,
            this.colSMSStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNotifications.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotifications.EnableHeadersVisualStyles = false;
            this.dgvNotifications.GridColor = System.Drawing.Color.LightGray;
            this.dgvNotifications.Location = new System.Drawing.Point(0, 0);
            this.dgvNotifications.MultiSelect = false;
            this.dgvNotifications.Name = "dgvNotifications";
            this.dgvNotifications.ReadOnly = true;
            this.dgvNotifications.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvNotifications.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNotifications.RowTemplate.Height = 35;
            this.dgvNotifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotifications.Size = new System.Drawing.Size(475, 672);
            this.dgvNotifications.TabIndex = 0;
            // 
            // colNotificationID
            // 
            this.colNotificationID.FillWeight = 30F;
            this.colNotificationID.HeaderText = "ID";
            this.colNotificationID.Name = "colNotificationID";
            this.colNotificationID.ReadOnly = true;
            // 
            // colDateSent
            // 
            this.colDateSent.HeaderText = "Date";
            this.colDateSent.Name = "colDateSent";
            this.colDateSent.ReadOnly = true;
            // 
            // colRecipient
            // 
            this.colRecipient.HeaderText = "Recipient";
            this.colRecipient.Name = "colRecipient";
            this.colRecipient.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.FillWeight = 50F;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colDeliveryMethod
            // 
            this.colDeliveryMethod.HeaderText = "Method";
            this.colDeliveryMethod.Name = "colDeliveryMethod";
            this.colDeliveryMethod.ReadOnly = true;
            // 
            // colSMSStatus
            // 
            this.colSMSStatus.HeaderText = "SMS Status";
            this.colSMSStatus.Name = "colSMSStatus";
            this.colSMSStatus.ReadOnly = true;
            // 
            // panelDetailView
            // 
            this.panelDetailView.BackColor = System.Drawing.Color.White;
            this.panelDetailView.BackColor2 = System.Drawing.Color.White;
            this.panelDetailView.BorderColor = System.Drawing.Color.Black;
            borderRadius8.BottomLeft = 10;
            borderRadius8.BottomRight = 10;
            borderRadius8.TopLeft = 10;
            borderRadius8.TopRight = 10;
            this.panelDetailView.BorderRadius = borderRadius8;
            this.panelDetailView.BorderThickness = 0;
            this.panelDetailView.Controls.Add(this.lblDetailTitle);
            this.panelDetailView.Controls.Add(this.lblDetailDate);
            this.panelDetailView.Controls.Add(this.lblDetailSender);
            this.panelDetailView.Controls.Add(this.lblDetailRecipient);
            this.panelDetailView.Controls.Add(this.lblDetailType);
            this.panelDetailView.Controls.Add(this.lblDetailDelivery);
            this.panelDetailView.Controls.Add(this.lblDetailSMSStatus);
            this.panelDetailView.Controls.Add(this.txtDetailMessage);
            this.panelDetailView.Controls.Add(this.lblDetailMessage);
            this.panelDetailView.Controls.Add(this.btnResend);
            this.panelDetailView.Location = new System.Drawing.Point(1414, 350);
            this.panelDetailView.Name = "panelDetailView";
            this.panelDetailView.Size = new System.Drawing.Size(263, 672);
            this.panelDetailView.TabIndex = 11;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(150, 19);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "Notification Details";
            // 
            // lblDetailDate
            // 
            this.lblDetailDate.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblDetailDate.ForeColor = System.Drawing.Color.Black;
            this.lblDetailDate.Location = new System.Drawing.Point(16, 50);
            this.lblDetailDate.Name = "lblDetailDate";
            this.lblDetailDate.Size = new System.Drawing.Size(230, 20);
            this.lblDetailDate.TabIndex = 1;
            this.lblDetailDate.Text = "Date: -";
            // 
            // lblDetailSender
            // 
            this.lblDetailSender.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblDetailSender.ForeColor = System.Drawing.Color.Black;
            this.lblDetailSender.Location = new System.Drawing.Point(16, 75);
            this.lblDetailSender.Name = "lblDetailSender";
            this.lblDetailSender.Size = new System.Drawing.Size(230, 20);
            this.lblDetailSender.TabIndex = 1;
            this.lblDetailSender.Text = "Sender: -";
            // 
            // lblDetailRecipient
            // 
            this.lblDetailRecipient.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblDetailRecipient.ForeColor = System.Drawing.Color.Black;
            this.lblDetailRecipient.Location = new System.Drawing.Point(16, 100);
            this.lblDetailRecipient.Name = "lblDetailRecipient";
            this.lblDetailRecipient.Size = new System.Drawing.Size(230, 20);
            this.lblDetailRecipient.TabIndex = 1;
            this.lblDetailRecipient.Text = "Recipient: -";
            // 
            // lblDetailType
            // 
            this.lblDetailType.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblDetailType.ForeColor = System.Drawing.Color.Black;
            this.lblDetailType.Location = new System.Drawing.Point(16, 125);
            this.lblDetailType.Name = "lblDetailType";
            this.lblDetailType.Size = new System.Drawing.Size(230, 20);
            this.lblDetailType.TabIndex = 1;
            this.lblDetailType.Text = "Type: -";
            // 
            // lblDetailDelivery
            // 
            this.lblDetailDelivery.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblDetailDelivery.ForeColor = System.Drawing.Color.Black;
            this.lblDetailDelivery.Location = new System.Drawing.Point(16, 150);
            this.lblDetailDelivery.Name = "lblDetailDelivery";
            this.lblDetailDelivery.Size = new System.Drawing.Size(230, 20);
            this.lblDetailDelivery.TabIndex = 1;
            this.lblDetailDelivery.Text = "Delivery Method: -";
            // 
            // lblDetailSMSStatus
            // 
            this.lblDetailSMSStatus.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblDetailSMSStatus.ForeColor = System.Drawing.Color.Black;
            this.lblDetailSMSStatus.Location = new System.Drawing.Point(16, 175);
            this.lblDetailSMSStatus.Name = "lblDetailSMSStatus";
            this.lblDetailSMSStatus.Size = new System.Drawing.Size(230, 20);
            this.lblDetailSMSStatus.TabIndex = 1;
            this.lblDetailSMSStatus.Text = "SMS Status: -";
            // 
            // txtDetailMessage
            // 
            this.txtDetailMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDetailMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetailMessage.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtDetailMessage.Location = new System.Drawing.Point(20, 240);
            this.txtDetailMessage.Name = "txtDetailMessage";
            this.txtDetailMessage.ReadOnly = true;
            this.txtDetailMessage.Size = new System.Drawing.Size(226, 349);
            this.txtDetailMessage.TabIndex = 5;
            this.txtDetailMessage.Text = "";
            // 
            // lblDetailMessage
            // 
            this.lblDetailMessage.AutoSize = true;
            this.lblDetailMessage.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailMessage.ForeColor = System.Drawing.Color.Black;
            this.lblDetailMessage.Location = new System.Drawing.Point(16, 220);
            this.lblDetailMessage.Name = "lblDetailMessage";
            this.lblDetailMessage.Size = new System.Drawing.Size(73, 17);
            this.lblDetailMessage.TabIndex = 0;
            this.lblDetailMessage.Text = "Message:";
            // 
            // btnResend
            // 
            this.btnResend.ButtonText = "Resend Notification";
            this.btnResend.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnResend.CheckedForeColor = System.Drawing.Color.White;
            this.btnResend.CheckedImageTint = System.Drawing.Color.White;
            this.btnResend.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnResend.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnResend.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnResend.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnResend.HoverForeColor = System.Drawing.Color.White;
            this.btnResend.HoverImage = null;
            this.btnResend.HoverImageTint = System.Drawing.Color.White;
            this.btnResend.HoverOutline = System.Drawing.Color.Empty;
            this.btnResend.Image = global::SkolarAid.Properties.Resources.bell__1_;
            this.btnResend.ImageAutoCenter = true;
            this.btnResend.ImageExpand = new System.Drawing.Point(6, 6);
            this.btnResend.ImageOffset = new System.Drawing.Point(-15, 0);
            this.btnResend.ImageTint = System.Drawing.Color.White;
            this.btnResend.IsToggleButton = false;
            this.btnResend.IsToggled = false;
            this.btnResend.Location = new System.Drawing.Point(20, 610);
            this.btnResend.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnResend.Name = "btnResend";
            this.btnResend.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnResend.NormalForeColor = System.Drawing.Color.White;
            this.btnResend.NormalOutline = System.Drawing.Color.Empty;
            this.btnResend.OutlineThickness = 2F;
            this.btnResend.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnResend.PressedForeColor = System.Drawing.Color.White;
            this.btnResend.PressedImageTint = System.Drawing.Color.White;
            this.btnResend.PressedOutline = System.Drawing.Color.Empty;
            this.btnResend.Rounding = new System.Windows.Forms.Padding(5);
            this.btnResend.Size = new System.Drawing.Size(226, 40);
            this.btnResend.TabIndex = 6;
            this.btnResend.TextAutoCenter = true;
            this.btnResend.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnSendNotification
            // 
            this.btnSendNotification.ButtonText = "Send Notification";
            this.btnSendNotification.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnSendNotification.CheckedForeColor = System.Drawing.Color.White;
            this.btnSendNotification.CheckedImageTint = System.Drawing.Color.White;
            this.btnSendNotification.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSendNotification.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSendNotification.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnSendNotification.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnSendNotification.HoverForeColor = System.Drawing.Color.White;
            this.btnSendNotification.HoverImage = null;
            this.btnSendNotification.HoverImageTint = System.Drawing.Color.White;
            this.btnSendNotification.HoverOutline = System.Drawing.Color.Empty;
            this.btnSendNotification.Image = global::SkolarAid.Properties.Resources.bell__1_;
            this.btnSendNotification.ImageAutoCenter = true;
            this.btnSendNotification.ImageExpand = new System.Drawing.Point(8, 8);
            this.btnSendNotification.ImageOffset = new System.Drawing.Point(-20, 0);
            this.btnSendNotification.ImageTint = System.Drawing.Color.White;
            this.btnSendNotification.IsToggleButton = false;
            this.btnSendNotification.IsToggled = false;
            this.btnSendNotification.Location = new System.Drawing.Point(300, 480);
            this.btnSendNotification.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSendNotification.Name = "btnSendNotification";
            this.btnSendNotification.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSendNotification.NormalForeColor = System.Drawing.Color.White;
            this.btnSendNotification.NormalOutline = System.Drawing.Color.Empty;
            this.btnSendNotification.OutlineThickness = 2F;
            this.btnSendNotification.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnSendNotification.PressedForeColor = System.Drawing.Color.White;
            this.btnSendNotification.PressedImageTint = System.Drawing.Color.White;
            this.btnSendNotification.PressedOutline = System.Drawing.Color.Empty;
            this.btnSendNotification.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSendNotification.Size = new System.Drawing.Size(250, 50);
            this.btnSendNotification.TabIndex = 6;
            this.btnSendNotification.TextAutoCenter = true;
            this.btnSendNotification.TextOffset = new System.Drawing.Point(-10, 0);
            // 
            // picFailedSMS
            // 
            this.picFailedSMS.Location = new System.Drawing.Point(15, 40);
            this.picFailedSMS.Name = "picFailedSMS";
            this.picFailedSMS.Size = new System.Drawing.Size(45, 48);
            this.picFailedSMS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFailedSMS.TabIndex = 2;
            this.picFailedSMS.TabStop = false;
            // 
            // picDelivered
            // 
            this.picDelivered.Location = new System.Drawing.Point(15, 40);
            this.picDelivered.Name = "picDelivered";
            this.picDelivered.Size = new System.Drawing.Size(45, 48);
            this.picDelivered.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDelivered.TabIndex = 2;
            this.picDelivered.TabStop = false;
            // 
            // picPendingSMS
            // 
            this.picPendingSMS.Location = new System.Drawing.Point(15, 40);
            this.picPendingSMS.Name = "picPendingSMS";
            this.picPendingSMS.Size = new System.Drawing.Size(45, 48);
            this.picPendingSMS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPendingSMS.TabIndex = 2;
            this.picPendingSMS.TabStop = false;
            // 
            // picTotalSent
            // 
            this.picTotalSent.Image = global::SkolarAid.Properties.Resources.bell__1_;
            this.picTotalSent.Location = new System.Drawing.Point(15, 40);
            this.picTotalSent.Name = "picTotalSent";
            this.picTotalSent.Size = new System.Drawing.Size(45, 48);
            this.picTotalSent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTotalSent.TabIndex = 2;
            this.picTotalSent.TabStop = false;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.panelSidebar.Controls.Add(this.btnReminder);
            this.panelSidebar.Controls.Add(this.btnActivityLog);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnPayroll);
            this.panelSidebar.Controls.Add(this.btnScholarMgmt);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 80);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(280, 970);
            this.panelSidebar.TabIndex = 12;
            // 
            // btnReminder
            // 
            this.btnReminder.ButtonText = "Reminder & Notification";
            this.btnReminder.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnReminder.CheckedForeColor = System.Drawing.Color.White;
            this.btnReminder.CheckedImageTint = System.Drawing.Color.White;
            this.btnReminder.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReminder.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReminder.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnReminder.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnReminder.HoverForeColor = System.Drawing.Color.White;
            this.btnReminder.HoverImage = null;
            this.btnReminder.HoverImageTint = System.Drawing.Color.White;
            this.btnReminder.HoverOutline = System.Drawing.Color.Empty;
            this.btnReminder.Image = global::SkolarAid.Properties.Resources.bell__1_;
            this.btnReminder.ImageAutoCenter = true;
            this.btnReminder.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnReminder.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnReminder.ImageTint = System.Drawing.Color.White;
            this.btnReminder.IsToggleButton = false;
            this.btnReminder.IsToggled = false;
            this.btnReminder.Location = new System.Drawing.Point(0, 420);
            this.btnReminder.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnReminder.Name = "btnReminder";
            this.btnReminder.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnReminder.NormalForeColor = System.Drawing.Color.White;
            this.btnReminder.NormalOutline = System.Drawing.Color.Empty;
            this.btnReminder.OutlineThickness = 2F;
            this.btnReminder.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnReminder.PressedForeColor = System.Drawing.Color.White;
            this.btnReminder.PressedImageTint = System.Drawing.Color.White;
            this.btnReminder.PressedOutline = System.Drawing.Color.Empty;
            this.btnReminder.Rounding = new System.Windows.Forms.Padding(0);
            this.btnReminder.Size = new System.Drawing.Size(280, 55);
            this.btnReminder.TabIndex = 5;
            this.btnReminder.TextAutoCenter = true;
            this.btnReminder.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // btnActivityLog
            // 
            this.btnActivityLog.ButtonText = "Activity Log";
            this.btnActivityLog.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnActivityLog.CheckedForeColor = System.Drawing.Color.White;
            this.btnActivityLog.CheckedImageTint = System.Drawing.Color.White;
            this.btnActivityLog.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnActivityLog.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnActivityLog.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnActivityLog.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnActivityLog.HoverForeColor = System.Drawing.Color.White;
            this.btnActivityLog.HoverImage = null;
            this.btnActivityLog.HoverImageTint = System.Drawing.Color.White;
            this.btnActivityLog.HoverOutline = System.Drawing.Color.Empty;
            this.btnActivityLog.Image = global::SkolarAid.Properties.Resources.file;
            this.btnActivityLog.ImageAutoCenter = true;
            this.btnActivityLog.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnActivityLog.ImageOffset = new System.Drawing.Point(-35, 0);
            this.btnActivityLog.ImageTint = System.Drawing.Color.White;
            this.btnActivityLog.IsToggleButton = false;
            this.btnActivityLog.IsToggled = false;
            this.btnActivityLog.Location = new System.Drawing.Point(0, 345);
            this.btnActivityLog.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnActivityLog.Name = "btnActivityLog";
            this.btnActivityLog.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnActivityLog.NormalForeColor = System.Drawing.Color.White;
            this.btnActivityLog.NormalOutline = System.Drawing.Color.Empty;
            this.btnActivityLog.OutlineThickness = 2F;
            this.btnActivityLog.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnActivityLog.PressedForeColor = System.Drawing.Color.White;
            this.btnActivityLog.PressedImageTint = System.Drawing.Color.White;
            this.btnActivityLog.PressedOutline = System.Drawing.Color.Empty;
            this.btnActivityLog.Rounding = new System.Windows.Forms.Padding(0);
            this.btnActivityLog.Size = new System.Drawing.Size(280, 55);
            this.btnActivityLog.TabIndex = 4;
            this.btnActivityLog.TextAutoCenter = true;
            this.btnActivityLog.TextOffset = new System.Drawing.Point(-25, 0);
            // 
            // btnReports
            // 
            this.btnReports.ButtonText = "Reports & Analytics";
            this.btnReports.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnReports.CheckedForeColor = System.Drawing.Color.White;
            this.btnReports.CheckedImageTint = System.Drawing.Color.White;
            this.btnReports.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReports.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReports.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnReports.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnReports.HoverForeColor = System.Drawing.Color.White;
            this.btnReports.HoverImage = null;
            this.btnReports.HoverImageTint = System.Drawing.Color.White;
            this.btnReports.HoverOutline = System.Drawing.Color.Empty;
            this.btnReports.Image = global::SkolarAid.Properties.Resources.analysis;
            this.btnReports.ImageAutoCenter = true;
            this.btnReports.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnReports.ImageOffset = new System.Drawing.Point(-15, 0);
            this.btnReports.ImageTint = System.Drawing.Color.White;
            this.btnReports.IsToggleButton = false;
            this.btnReports.IsToggled = false;
            this.btnReports.Location = new System.Drawing.Point(0, 270);
            this.btnReports.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnReports.Name = "btnReports";
            this.btnReports.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnReports.NormalForeColor = System.Drawing.Color.White;
            this.btnReports.NormalOutline = System.Drawing.Color.Empty;
            this.btnReports.OutlineThickness = 2F;
            this.btnReports.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnReports.PressedForeColor = System.Drawing.Color.White;
            this.btnReports.PressedImageTint = System.Drawing.Color.White;
            this.btnReports.PressedOutline = System.Drawing.Color.Empty;
            this.btnReports.Rounding = new System.Windows.Forms.Padding(0);
            this.btnReports.Size = new System.Drawing.Size(280, 55);
            this.btnReports.TabIndex = 3;
            this.btnReports.TextAutoCenter = true;
            this.btnReports.TextOffset = new System.Drawing.Point(-5, 0);
            // 
            // btnPayroll
            // 
            this.btnPayroll.ButtonText = "Payroll Processing";
            this.btnPayroll.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnPayroll.CheckedForeColor = System.Drawing.Color.White;
            this.btnPayroll.CheckedImageTint = System.Drawing.Color.White;
            this.btnPayroll.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnPayroll.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPayroll.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnPayroll.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnPayroll.HoverForeColor = System.Drawing.Color.White;
            this.btnPayroll.HoverImage = null;
            this.btnPayroll.HoverImageTint = System.Drawing.Color.White;
            this.btnPayroll.HoverOutline = System.Drawing.Color.Empty;
            this.btnPayroll.Image = global::SkolarAid.Properties.Resources.dollar;
            this.btnPayroll.ImageAutoCenter = true;
            this.btnPayroll.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnPayroll.ImageOffset = new System.Drawing.Point(-25, 0);
            this.btnPayroll.ImageTint = System.Drawing.Color.White;
            this.btnPayroll.IsToggleButton = false;
            this.btnPayroll.IsToggled = false;
            this.btnPayroll.Location = new System.Drawing.Point(0, 195);
            this.btnPayroll.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPayroll.Name = "btnPayroll";
            this.btnPayroll.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnPayroll.NormalForeColor = System.Drawing.Color.White;
            this.btnPayroll.NormalOutline = System.Drawing.Color.Empty;
            this.btnPayroll.OutlineThickness = 2F;
            this.btnPayroll.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnPayroll.PressedForeColor = System.Drawing.Color.White;
            this.btnPayroll.PressedImageTint = System.Drawing.Color.White;
            this.btnPayroll.PressedOutline = System.Drawing.Color.Empty;
            this.btnPayroll.Rounding = new System.Windows.Forms.Padding(0);
            this.btnPayroll.Size = new System.Drawing.Size(280, 55);
            this.btnPayroll.TabIndex = 2;
            this.btnPayroll.TextAutoCenter = true;
            this.btnPayroll.TextOffset = new System.Drawing.Point(-15, 0);
            // 
            // btnScholarMgmt
            // 
            this.btnScholarMgmt.ButtonText = "Scholar Management";
            this.btnScholarMgmt.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnScholarMgmt.CheckedForeColor = System.Drawing.Color.White;
            this.btnScholarMgmt.CheckedImageTint = System.Drawing.Color.White;
            this.btnScholarMgmt.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnScholarMgmt.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnScholarMgmt.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnScholarMgmt.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnScholarMgmt.HoverForeColor = System.Drawing.Color.White;
            this.btnScholarMgmt.HoverImage = null;
            this.btnScholarMgmt.HoverImageTint = System.Drawing.Color.White;
            this.btnScholarMgmt.HoverOutline = System.Drawing.Color.Empty;
            this.btnScholarMgmt.Image = global::SkolarAid.Properties.Resources.scholar;
            this.btnScholarMgmt.ImageAutoCenter = true;
            this.btnScholarMgmt.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnScholarMgmt.ImageOffset = new System.Drawing.Point(-10, 0);
            this.btnScholarMgmt.ImageTint = System.Drawing.Color.White;
            this.btnScholarMgmt.IsToggleButton = false;
            this.btnScholarMgmt.IsToggled = false;
            this.btnScholarMgmt.Location = new System.Drawing.Point(0, 120);
            this.btnScholarMgmt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnScholarMgmt.Name = "btnScholarMgmt";
            this.btnScholarMgmt.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnScholarMgmt.NormalForeColor = System.Drawing.Color.White;
            this.btnScholarMgmt.NormalOutline = System.Drawing.Color.Empty;
            this.btnScholarMgmt.OutlineThickness = 2F;
            this.btnScholarMgmt.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnScholarMgmt.PressedForeColor = System.Drawing.Color.White;
            this.btnScholarMgmt.PressedImageTint = System.Drawing.Color.White;
            this.btnScholarMgmt.PressedOutline = System.Drawing.Color.Empty;
            this.btnScholarMgmt.Rounding = new System.Windows.Forms.Padding(0);
            this.btnScholarMgmt.Size = new System.Drawing.Size(280, 55);
            this.btnScholarMgmt.TabIndex = 1;
            this.btnScholarMgmt.TextAutoCenter = true;
            this.btnScholarMgmt.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnDashboard
            // 
            this.btnDashboard.ButtonText = "Dashboard";
            this.btnDashboard.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnDashboard.CheckedForeColor = System.Drawing.Color.White;
            this.btnDashboard.CheckedImageTint = System.Drawing.Color.White;
            this.btnDashboard.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDashboard.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnDashboard.HoverForeColor = System.Drawing.Color.White;
            this.btnDashboard.HoverImage = null;
            this.btnDashboard.HoverImageTint = System.Drawing.Color.White;
            this.btnDashboard.HoverOutline = System.Drawing.Color.Empty;
            this.btnDashboard.Image = global::SkolarAid.Properties.Resources.dashboard__3_;
            this.btnDashboard.ImageAutoCenter = true;
            this.btnDashboard.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnDashboard.ImageOffset = new System.Drawing.Point(-40, 0);
            this.btnDashboard.ImageTint = System.Drawing.Color.White;
            this.btnDashboard.IsToggleButton = false;
            this.btnDashboard.IsToggled = true;
            this.btnDashboard.Location = new System.Drawing.Point(0, 45);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnDashboard.NormalForeColor = System.Drawing.Color.White;
            this.btnDashboard.NormalOutline = System.Drawing.Color.Empty;
            this.btnDashboard.OutlineThickness = 2F;
            this.btnDashboard.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnDashboard.PressedForeColor = System.Drawing.Color.White;
            this.btnDashboard.PressedImageTint = System.Drawing.Color.White;
            this.btnDashboard.PressedOutline = System.Drawing.Color.Empty;
            this.btnDashboard.Rounding = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Size = new System.Drawing.Size(280, 55);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.TextAutoCenter = true;
            this.btnDashboard.TextOffset = new System.Drawing.Point(-30, 0);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.panelHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.panelHeader.BorderColor = System.Drawing.Color.Black;
            borderRadius9.BottomLeft = 1;
            borderRadius9.BottomRight = 1;
            borderRadius9.TopLeft = 1;
            borderRadius9.TopRight = 1;
            this.panelHeader.BorderRadius = borderRadius9;
            this.panelHeader.BorderThickness = 0;
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblBrand);
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Controls.Add(this.picUser);
            this.panelHeader.Controls.Add(this.lblRole);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1700, 80);
            this.panelHeader.TabIndex = 13;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::SkolarAid.Properties.Resources.scholar;
            this.picLogo.Location = new System.Drawing.Point(20, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(55, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblBrand.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(85, 28);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(203, 26);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "ScholarAid Admin";
            // 
            // btnLogout
            // 
            this.btnLogout.ButtonText = "Logout";
            this.btnLogout.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLogout.CheckedForeColor = System.Drawing.Color.White;
            this.btnLogout.CheckedImageTint = System.Drawing.Color.White;
            this.btnLogout.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnLogout.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogout.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogout.HoverForeColor = System.Drawing.Color.White;
            this.btnLogout.HoverImage = null;
            this.btnLogout.HoverImageTint = System.Drawing.Color.White;
            this.btnLogout.HoverOutline = System.Drawing.Color.Empty;
            this.btnLogout.Image = null;
            this.btnLogout.ImageAutoCenter = true;
            this.btnLogout.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnLogout.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnLogout.ImageTint = System.Drawing.Color.White;
            this.btnLogout.IsToggleButton = false;
            this.btnLogout.IsToggled = false;
            this.btnLogout.Location = new System.Drawing.Point(1567, 14);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnLogout.NormalForeColor = System.Drawing.Color.White;
            this.btnLogout.NormalOutline = System.Drawing.Color.Empty;
            this.btnLogout.OutlineThickness = 2F;
            this.btnLogout.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnLogout.PressedForeColor = System.Drawing.Color.White;
            this.btnLogout.PressedImageTint = System.Drawing.Color.White;
            this.btnLogout.PressedOutline = System.Drawing.Color.Empty;
            this.btnLogout.Rounding = new System.Windows.Forms.Padding(8);
            this.btnLogout.Size = new System.Drawing.Size(110, 40);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.TextAutoCenter = true;
            this.btnLogout.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // picUser
            // 
            this.picUser.Image = global::SkolarAid.Properties.Resources.user__3_;
            this.picUser.Location = new System.Drawing.Point(1398, 19);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(36, 35);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 3;
            this.picUser.TabStop = false;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblRole.Location = new System.Drawing.Point(1440, 27);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(111, 19);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Administrator";
            // 
            // FrmNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1700, 1050);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelDetailView);
            this.Controls.Add(this.panelDataGrid);
            this.Controls.Add(this.panelCompose);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelStats4);
            this.Controls.Add(this.panelStats3);
            this.Controls.Add(this.panelStats2);
            this.Controls.Add(this.panelStats1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotifications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifications & Reminders - ScholarAid";
            this.Load += new System.EventHandler(this.FrmNotifications_Load);
            this.panelStats1.ResumeLayout(false);
            this.panelStats1.PerformLayout();
            this.panelStats2.ResumeLayout(false);
            this.panelStats2.PerformLayout();
            this.panelStats3.ResumeLayout(false);
            this.panelStats3.PerformLayout();
            this.panelStats4.ResumeLayout(false);
            this.panelStats4.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelCompose.ResumeLayout(false);
            this.panelCompose.PerformLayout();
            this.panelDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).EndInit();
            this.panelDetailView.ResumeLayout(false);
            this.panelDetailView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFailedSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelivered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPendingSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalSent)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Stats Cards
        private SATAUiFramework.SATAPanel panelStats1;
        private System.Windows.Forms.Label lblTotalSent;
        private System.Windows.Forms.Label lblTotalSentLabel;
        private System.Windows.Forms.PictureBox picTotalSent;
        private SATAUiFramework.SATAPanel panelStats2;
        private System.Windows.Forms.Label lblPendingSMS;
        private System.Windows.Forms.Label lblPendingSMSLabel;
        private System.Windows.Forms.PictureBox picPendingSMS;
        private SATAUiFramework.SATAPanel panelStats3;
        private System.Windows.Forms.Label lblDelivered;
        private System.Windows.Forms.Label lblDeliveredLabel;
        private System.Windows.Forms.PictureBox picDelivered;
        private SATAUiFramework.SATAPanel panelStats4;
        private System.Windows.Forms.Label lblFailedSMS;
        private System.Windows.Forms.Label lblFailedSMSLabel;
        private System.Windows.Forms.PictureBox picFailedSMS;

        // Filters Panel
        private SATAUiFramework.SATAPanel panelFilters;
        private System.Windows.Forms.ComboBox cmbNotificationType;
        private System.Windows.Forms.Label lblNotificationType;
        private System.Windows.Forms.ComboBox cmbDeliveryMethod;
        private System.Windows.Forms.Label lblDeliveryMethod;
        private System.Windows.Forms.ComboBox cmbRecipient;
        private System.Windows.Forms.Label lblRecipient;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private FrameworkTest.SATAButton btnClearFilters;
        private FrameworkTest.SATAButton btnRefresh;

        // Compose Panel
        private SATAUiFramework.SATAPanel panelCompose;
        private System.Windows.Forms.Label lblComposeTitle;
        private System.Windows.Forms.ComboBox cmbComposeRecipient;
        private System.Windows.Forms.Label lblComposeRecipient;
        private System.Windows.Forms.ComboBox cmbComposeType;
        private System.Windows.Forms.Label lblComposeType;
        private System.Windows.Forms.CheckBox chkSendSMS;
        private System.Windows.Forms.CheckBox chkSendInApp;
        private System.Windows.Forms.TextBox txtNotificationTitle;
        private System.Windows.Forms.Label lblNotificationTitle;
        private System.Windows.Forms.RichTextBox txtNotificationMessage;
        private System.Windows.Forms.Label lblMessage;
        private FrameworkTest.SATAButton btnSendNotification;
        private FrameworkTest.SATAButton btnClearForm;

        // Data Grid
        private SATAUiFramework.SATAPanel panelDataGrid;
        private System.Windows.Forms.DataGridView dgvNotifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotificationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateSent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecipient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSMSStatus;

        // Detail View Panel
        private SATAUiFramework.SATAPanel panelDetailView;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblDetailDate;
        private System.Windows.Forms.Label lblDetailSender;
        private System.Windows.Forms.Label lblDetailRecipient;
        private System.Windows.Forms.Label lblDetailType;
        private System.Windows.Forms.Label lblDetailDelivery;
        private System.Windows.Forms.Label lblDetailSMSStatus;
        private System.Windows.Forms.RichTextBox txtDetailMessage;
        private System.Windows.Forms.Label lblDetailMessage;
        private FrameworkTest.SATAButton btnResend;
        private System.Windows.Forms.Panel panelSidebar;
        private FrameworkTest.SATAButton btnReminder;
        private FrameworkTest.SATAButton btnActivityLog;
        private FrameworkTest.SATAButton btnReports;
        private FrameworkTest.SATAButton btnPayroll;
        private FrameworkTest.SATAButton btnScholarMgmt;
        private FrameworkTest.SATAButton btnDashboard;
        private SATAPanel panelHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblBrand;
        private FrameworkTest.SATAButton btnLogout;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblRole;
        //private BorderRadius borderRadius8;
    }
}
