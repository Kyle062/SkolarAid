namespace SkolarAid
{
    partial class FrmScholarNotifications
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnNotifications = new FrameworkTest.SATAButton();
            this.btnCompliance = new FrameworkTest.SATAButton();
            this.btnPayments = new FrameworkTest.SATAButton();
            this.btnProfile = new FrameworkTest.SATAButton();
            this.btnDashboard = new FrameworkTest.SATAButton();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.panelHeader = new SATAUiFramework.SATAPanel();
            this.btnLogout = new FrameworkTest.SATAButton();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblScholarInfo = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.panelSummaryCards = new System.Windows.Forms.Panel();
            this.panelCard1 = new SATAUiFramework.SATAPanel();
            this.lblTotalNotifications = new System.Windows.Forms.Label();
            this.lblTotalNotificationsLabel = new System.Windows.Forms.Label();
            this.picTotalNotifications = new System.Windows.Forms.PictureBox();
            this.panelCard2 = new SATAUiFramework.SATAPanel();
            this.lblUnreadCount = new System.Windows.Forms.Label();
            this.lblUnreadCountLabel = new System.Windows.Forms.Label();
            this.picUnread = new System.Windows.Forms.PictureBox();
            this.panelCard3 = new SATAUiFramework.SATAPanel();
            this.lblPaymentNotifs = new System.Windows.Forms.Label();
            this.lblPaymentNotifsLabel = new System.Windows.Forms.Label();
            this.picPaymentNotifs = new System.Windows.Forms.PictureBox();
            this.panelCard4 = new SATAUiFramework.SATAPanel();
            this.lblAlertNotifs = new System.Windows.Forms.Label();
            this.lblAlertNotifsLabel = new System.Windows.Forms.Label();
            this.picAlertNotifs = new System.Windows.Forms.PictureBox();
            this.panelFilters = new SATAUiFramework.SATAPanel();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.chkUnreadOnly = new System.Windows.Forms.CheckBox();
            this.btnClearFilters = new FrameworkTest.SATAButton();
            this.btnRefresh = new FrameworkTest.SATAButton();
            this.btnMarkAllRead = new FrameworkTest.SATAButton();
            this.panelNotificationList = new SATAUiFramework.SATAPanel();
            this.flowNotifications = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.panelDetailView = new SATAUiFramework.SATAPanel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblDetailType = new System.Windows.Forms.Label();
            this.lblDetailDate = new System.Windows.Forms.Label();
            this.lblDetailMessage = new System.Windows.Forms.Label();
            this.lblDetailDeliveryLabel = new System.Windows.Forms.Label();
            this.lblDetailDelivery = new System.Windows.Forms.Label();
            this.lblDetailStatusLabel = new System.Windows.Forms.Label();
            this.lblDetailStatus = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.panelContent.SuspendLayout();
            this.panelSummaryCards.SuspendLayout();
            this.panelCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalNotifications)).BeginInit();
            this.panelCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUnread)).BeginInit();
            this.panelCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPaymentNotifs)).BeginInit();
            this.panelCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertNotifs)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.panelNotificationList.SuspendLayout();
            this.panelDetailView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.panelSidebar.Controls.Add(this.btnNotifications);
            this.panelSidebar.Controls.Add(this.btnCompliance);
            this.panelSidebar.Controls.Add(this.btnPayments);
            this.panelSidebar.Controls.Add(this.btnProfile);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.picLogo);
            this.panelSidebar.Controls.Add(this.lblBrand);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(300, 1050);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnNotifications
            // 
            this.btnNotifications.ButtonText = "Notifications";
            this.btnNotifications.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnNotifications.CheckedForeColor = System.Drawing.Color.White;
            this.btnNotifications.CheckedImageTint = System.Drawing.Color.White;
            this.btnNotifications.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnNotifications.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNotifications.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnNotifications.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnNotifications.HoverForeColor = System.Drawing.Color.White;
            this.btnNotifications.HoverImage = null;
            this.btnNotifications.HoverImageTint = System.Drawing.Color.White;
            this.btnNotifications.HoverOutline = System.Drawing.Color.Empty;
            this.btnNotifications.Image = global::SkolarAid.Properties.Resources.bell__1_;
            this.btnNotifications.ImageAutoCenter = true;
            this.btnNotifications.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnNotifications.ImageOffset = new System.Drawing.Point(-15, 0);
            this.btnNotifications.ImageTint = System.Drawing.Color.White;
            this.btnNotifications.IsToggleButton = false;
            this.btnNotifications.IsToggled = true;
            this.btnNotifications.Location = new System.Drawing.Point(0, 410);
            this.btnNotifications.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnNotifications.NormalForeColor = System.Drawing.Color.White;
            this.btnNotifications.NormalOutline = System.Drawing.Color.Empty;
            this.btnNotifications.OutlineThickness = 2F;
            this.btnNotifications.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnNotifications.PressedForeColor = System.Drawing.Color.White;
            this.btnNotifications.PressedImageTint = System.Drawing.Color.White;
            this.btnNotifications.PressedOutline = System.Drawing.Color.Empty;
            this.btnNotifications.Rounding = new System.Windows.Forms.Padding(0);
            this.btnNotifications.Size = new System.Drawing.Size(300, 60);
            this.btnNotifications.TabIndex = 4;
            this.btnNotifications.TextAutoCenter = true;
            this.btnNotifications.TextOffset = new System.Drawing.Point(-5, 0);
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // btnCompliance
            // 
            this.btnCompliance.ButtonText = "Compliance";
            this.btnCompliance.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnCompliance.CheckedForeColor = System.Drawing.Color.White;
            this.btnCompliance.CheckedImageTint = System.Drawing.Color.White;
            this.btnCompliance.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnCompliance.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCompliance.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnCompliance.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnCompliance.HoverForeColor = System.Drawing.Color.White;
            this.btnCompliance.HoverImage = null;
            this.btnCompliance.HoverImageTint = System.Drawing.Color.White;
            this.btnCompliance.HoverOutline = System.Drawing.Color.Empty;
            this.btnCompliance.Image = global::SkolarAid.Properties.Resources.file;
            this.btnCompliance.ImageAutoCenter = true;
            this.btnCompliance.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnCompliance.ImageOffset = new System.Drawing.Point(-25, 0);
            this.btnCompliance.ImageTint = System.Drawing.Color.White;
            this.btnCompliance.IsToggleButton = false;
            this.btnCompliance.IsToggled = false;
            this.btnCompliance.Location = new System.Drawing.Point(0, 335);
            this.btnCompliance.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnCompliance.Name = "btnCompliance";
            this.btnCompliance.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnCompliance.NormalForeColor = System.Drawing.Color.White;
            this.btnCompliance.NormalOutline = System.Drawing.Color.Empty;
            this.btnCompliance.OutlineThickness = 2F;
            this.btnCompliance.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnCompliance.PressedForeColor = System.Drawing.Color.White;
            this.btnCompliance.PressedImageTint = System.Drawing.Color.White;
            this.btnCompliance.PressedOutline = System.Drawing.Color.Empty;
            this.btnCompliance.Rounding = new System.Windows.Forms.Padding(0);
            this.btnCompliance.Size = new System.Drawing.Size(300, 60);
            this.btnCompliance.TabIndex = 3;
            this.btnCompliance.TextAutoCenter = true;
            this.btnCompliance.TextOffset = new System.Drawing.Point(-15, 0);
            this.btnCompliance.Click += new System.EventHandler(this.btnCompliance_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.ButtonText = "Payment History";
            this.btnPayments.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnPayments.CheckedForeColor = System.Drawing.Color.White;
            this.btnPayments.CheckedImageTint = System.Drawing.Color.White;
            this.btnPayments.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnPayments.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPayments.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnPayments.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnPayments.HoverForeColor = System.Drawing.Color.White;
            this.btnPayments.HoverImage = null;
            this.btnPayments.HoverImageTint = System.Drawing.Color.White;
            this.btnPayments.HoverOutline = System.Drawing.Color.Empty;
            this.btnPayments.Image = global::SkolarAid.Properties.Resources.dollar;
            this.btnPayments.ImageAutoCenter = true;
            this.btnPayments.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnPayments.ImageOffset = new System.Drawing.Point(-20, 0);
            this.btnPayments.ImageTint = System.Drawing.Color.White;
            this.btnPayments.IsToggleButton = false;
            this.btnPayments.IsToggled = false;
            this.btnPayments.Location = new System.Drawing.Point(0, 260);
            this.btnPayments.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnPayments.NormalForeColor = System.Drawing.Color.White;
            this.btnPayments.NormalOutline = System.Drawing.Color.Empty;
            this.btnPayments.OutlineThickness = 2F;
            this.btnPayments.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnPayments.PressedForeColor = System.Drawing.Color.White;
            this.btnPayments.PressedImageTint = System.Drawing.Color.White;
            this.btnPayments.PressedOutline = System.Drawing.Color.Empty;
            this.btnPayments.Rounding = new System.Windows.Forms.Padding(0);
            this.btnPayments.Size = new System.Drawing.Size(300, 60);
            this.btnPayments.TabIndex = 2;
            this.btnPayments.TextAutoCenter = true;
            this.btnPayments.TextOffset = new System.Drawing.Point(-10, 0);
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.ButtonText = "My Profile";
            this.btnProfile.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnProfile.CheckedForeColor = System.Drawing.Color.White;
            this.btnProfile.CheckedImageTint = System.Drawing.Color.White;
            this.btnProfile.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnProfile.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnProfile.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnProfile.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnProfile.HoverForeColor = System.Drawing.Color.White;
            this.btnProfile.HoverImage = null;
            this.btnProfile.HoverImageTint = System.Drawing.Color.White;
            this.btnProfile.HoverOutline = System.Drawing.Color.Empty;
            this.btnProfile.Image = global::SkolarAid.Properties.Resources.user__8_;
            this.btnProfile.ImageAutoCenter = true;
            this.btnProfile.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnProfile.ImageOffset = new System.Drawing.Point(-30, 0);
            this.btnProfile.ImageTint = System.Drawing.Color.White;
            this.btnProfile.IsToggleButton = false;
            this.btnProfile.IsToggled = false;
            this.btnProfile.Location = new System.Drawing.Point(0, 185);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnProfile.NormalForeColor = System.Drawing.Color.White;
            this.btnProfile.NormalOutline = System.Drawing.Color.Empty;
            this.btnProfile.OutlineThickness = 2F;
            this.btnProfile.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnProfile.PressedForeColor = System.Drawing.Color.White;
            this.btnProfile.PressedImageTint = System.Drawing.Color.White;
            this.btnProfile.PressedOutline = System.Drawing.Color.Empty;
            this.btnProfile.Rounding = new System.Windows.Forms.Padding(0);
            this.btnProfile.Size = new System.Drawing.Size(300, 60);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.TextAutoCenter = true;
            this.btnProfile.TextOffset = new System.Drawing.Point(-20, 0);
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.ButtonText = "Dashboard";
            this.btnDashboard.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnDashboard.CheckedForeColor = System.Drawing.Color.White;
            this.btnDashboard.CheckedImageTint = System.Drawing.Color.White;
            this.btnDashboard.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnDashboard.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnDashboard.HoverForeColor = System.Drawing.Color.White;
            this.btnDashboard.HoverImage = null;
            this.btnDashboard.HoverImageTint = System.Drawing.Color.White;
            this.btnDashboard.HoverOutline = System.Drawing.Color.Empty;
            this.btnDashboard.Image = global::SkolarAid.Properties.Resources.dashboard__3_;
            this.btnDashboard.ImageAutoCenter = true;
            this.btnDashboard.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnDashboard.ImageOffset = new System.Drawing.Point(-35, 0);
            this.btnDashboard.ImageTint = System.Drawing.Color.White;
            this.btnDashboard.IsToggleButton = false;
            this.btnDashboard.IsToggled = false;
            this.btnDashboard.Location = new System.Drawing.Point(0, 110);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnDashboard.NormalForeColor = System.Drawing.Color.White;
            this.btnDashboard.NormalOutline = System.Drawing.Color.Empty;
            this.btnDashboard.OutlineThickness = 2F;
            this.btnDashboard.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnDashboard.PressedForeColor = System.Drawing.Color.White;
            this.btnDashboard.PressedImageTint = System.Drawing.Color.White;
            this.btnDashboard.PressedOutline = System.Drawing.Color.Empty;
            this.btnDashboard.Rounding = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Size = new System.Drawing.Size(300, 60);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.TextAutoCenter = true;
            this.btnDashboard.TextOffset = new System.Drawing.Point(-25, 0);
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = global::SkolarAid.Properties.Resources.scholar;
            this.picLogo.Location = new System.Drawing.Point(20, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(60, 55);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 10;
            this.picLogo.TabStop = false;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(85, 30);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(157, 26);
            this.lblBrand.TabIndex = 9;
            this.lblBrand.Text = "Scholar Portal";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.BackColor2 = System.Drawing.Color.White;
            this.panelHeader.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 1;
            borderRadius1.BottomRight = 1;
            borderRadius1.TopLeft = 1;
            borderRadius1.TopRight = 1;
            this.panelHeader.BorderRadius = borderRadius1;
            this.panelHeader.BorderThickness = 0;
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Controls.Add(this.lblPageTitle);
            this.panelHeader.Controls.Add(this.picUser);
            this.panelHeader.Controls.Add(this.lblScholarInfo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(300, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1400, 85);
            this.panelHeader.TabIndex = 1;
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
            this.btnLogout.Location = new System.Drawing.Point(1250, 22);
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
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPageTitle.Location = new System.Drawing.Point(30, 26);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(173, 32);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Notifications";
            // 
            // picUser
            // 
            this.picUser.Image = global::SkolarAid.Properties.Resources.user__3_;
            this.picUser.Location = new System.Drawing.Point(1080, 25);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(40, 38);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 3;
            this.picUser.TabStop = false;
            // 
            // lblScholarInfo
            // 
            this.lblScholarInfo.AutoSize = true;
            this.lblScholarInfo.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblScholarInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblScholarInfo.Location = new System.Drawing.Point(1125, 33);
            this.lblScholarInfo.Name = "lblScholarInfo";
            this.lblScholarInfo.Size = new System.Drawing.Size(119, 21);
            this.lblScholarInfo.TabIndex = 4;
            this.lblScholarInfo.Text = "Scholar Name";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panelContent.Controls.Add(this.lblDate);
            this.panelContent.Controls.Add(this.panelSummaryCards);
            this.panelContent.Controls.Add(this.panelFilters);
            this.panelContent.Controls.Add(this.panelNotificationList);
            this.panelContent.Controls.Add(this.panelDetailView);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(300, 85);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1400, 965);
            this.panelContent.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblDate.Location = new System.Drawing.Point(1050, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(203, 21);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Monday, January 1, 2026";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelSummaryCards
            // 
            this.panelSummaryCards.Controls.Add(this.panelCard1);
            this.panelSummaryCards.Controls.Add(this.panelCard2);
            this.panelSummaryCards.Controls.Add(this.panelCard3);
            this.panelSummaryCards.Controls.Add(this.panelCard4);
            this.panelSummaryCards.Location = new System.Drawing.Point(40, 20);
            this.panelSummaryCards.Name = "panelSummaryCards";
            this.panelSummaryCards.Size = new System.Drawing.Size(1320, 140);
            this.panelSummaryCards.TabIndex = 0;
            // 
            // panelCard1
            // 
            this.panelCard1.BackColor = System.Drawing.Color.White;
            this.panelCard1.BackColor2 = System.Drawing.Color.White;
            this.panelCard1.BorderColor = System.Drawing.Color.Black;
            borderRadius2.BottomLeft = 15;
            borderRadius2.BottomRight = 15;
            borderRadius2.TopLeft = 15;
            borderRadius2.TopRight = 15;
            this.panelCard1.BorderRadius = borderRadius2;
            this.panelCard1.BorderThickness = 0;
            this.panelCard1.Controls.Add(this.lblTotalNotifications);
            this.panelCard1.Controls.Add(this.lblTotalNotificationsLabel);
            this.panelCard1.Controls.Add(this.picTotalNotifications);
            this.panelCard1.Location = new System.Drawing.Point(0, 0);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(310, 130);
            this.panelCard1.TabIndex = 0;
            // 
            // lblTotalNotifications
            // 
            this.lblTotalNotifications.AutoSize = true;
            this.lblTotalNotifications.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblTotalNotifications.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblTotalNotifications.Location = new System.Drawing.Point(85, 55);
            this.lblTotalNotifications.Name = "lblTotalNotifications";
            this.lblTotalNotifications.Size = new System.Drawing.Size(42, 47);
            this.lblTotalNotifications.TabIndex = 0;
            this.lblTotalNotifications.Text = "0";
            // 
            // lblTotalNotificationsLabel
            // 
            this.lblTotalNotificationsLabel.AutoSize = true;
            this.lblTotalNotificationsLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalNotificationsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTotalNotificationsLabel.Location = new System.Drawing.Point(88, 25);
            this.lblTotalNotificationsLabel.Name = "lblTotalNotificationsLabel";
            this.lblTotalNotificationsLabel.Size = new System.Drawing.Size(142, 19);
            this.lblTotalNotificationsLabel.TabIndex = 1;
            this.lblTotalNotificationsLabel.Text = "Total Notifications";
            // 
            // picTotalNotifications
            // 
            this.picTotalNotifications.Image = global::SkolarAid.Properties.Resources.bell__1_;
            this.picTotalNotifications.Location = new System.Drawing.Point(20, 40);
            this.picTotalNotifications.Name = "picTotalNotifications";
            this.picTotalNotifications.Size = new System.Drawing.Size(50, 55);
            this.picTotalNotifications.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTotalNotifications.TabIndex = 2;
            this.picTotalNotifications.TabStop = false;
            // 
            // panelCard2
            // 
            this.panelCard2.BackColor = System.Drawing.Color.White;
            this.panelCard2.BackColor2 = System.Drawing.Color.White;
            this.panelCard2.BorderColor = System.Drawing.Color.Black;
            borderRadius3.BottomLeft = 15;
            borderRadius3.BottomRight = 15;
            borderRadius3.TopLeft = 15;
            borderRadius3.TopRight = 15;
            this.panelCard2.BorderRadius = borderRadius3;
            this.panelCard2.BorderThickness = 0;
            this.panelCard2.Controls.Add(this.lblUnreadCount);
            this.panelCard2.Controls.Add(this.lblUnreadCountLabel);
            this.panelCard2.Controls.Add(this.picUnread);
            this.panelCard2.Location = new System.Drawing.Point(335, 0);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Size = new System.Drawing.Size(310, 130);
            this.panelCard2.TabIndex = 1;
            // 
            // lblUnreadCount
            // 
            this.lblUnreadCount.AutoSize = true;
            this.lblUnreadCount.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblUnreadCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.lblUnreadCount.Location = new System.Drawing.Point(85, 55);
            this.lblUnreadCount.Name = "lblUnreadCount";
            this.lblUnreadCount.Size = new System.Drawing.Size(42, 47);
            this.lblUnreadCount.TabIndex = 0;
            this.lblUnreadCount.Text = "0";
            // 
            // lblUnreadCountLabel
            // 
            this.lblUnreadCountLabel.AutoSize = true;
            this.lblUnreadCountLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblUnreadCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblUnreadCountLabel.Location = new System.Drawing.Point(88, 25);
            this.lblUnreadCountLabel.Name = "lblUnreadCountLabel";
            this.lblUnreadCountLabel.Size = new System.Drawing.Size(116, 19);
            this.lblUnreadCountLabel.TabIndex = 1;
            this.lblUnreadCountLabel.Text = "Unread Count";
            // 
            // picUnread
            // 
            this.picUnread.Location = new System.Drawing.Point(20, 40);
            this.picUnread.Name = "picUnread";
            this.picUnread.Size = new System.Drawing.Size(50, 55);
            this.picUnread.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUnread.TabIndex = 2;
            this.picUnread.TabStop = false;
            // 
            // panelCard3
            // 
            this.panelCard3.BackColor = System.Drawing.Color.White;
            this.panelCard3.BackColor2 = System.Drawing.Color.White;
            this.panelCard3.BorderColor = System.Drawing.Color.Black;
            borderRadius4.BottomLeft = 15;
            borderRadius4.BottomRight = 15;
            borderRadius4.TopLeft = 15;
            borderRadius4.TopRight = 15;
            this.panelCard3.BorderRadius = borderRadius4;
            this.panelCard3.BorderThickness = 0;
            this.panelCard3.Controls.Add(this.lblPaymentNotifs);
            this.panelCard3.Controls.Add(this.lblPaymentNotifsLabel);
            this.panelCard3.Controls.Add(this.picPaymentNotifs);
            this.panelCard3.Location = new System.Drawing.Point(670, 0);
            this.panelCard3.Name = "panelCard3";
            this.panelCard3.Size = new System.Drawing.Size(310, 130);
            this.panelCard3.TabIndex = 2;
            // 
            // lblPaymentNotifs
            // 
            this.lblPaymentNotifs.AutoSize = true;
            this.lblPaymentNotifs.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblPaymentNotifs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblPaymentNotifs.Location = new System.Drawing.Point(85, 55);
            this.lblPaymentNotifs.Name = "lblPaymentNotifs";
            this.lblPaymentNotifs.Size = new System.Drawing.Size(42, 47);
            this.lblPaymentNotifs.TabIndex = 0;
            this.lblPaymentNotifs.Text = "0";
            // 
            // lblPaymentNotifsLabel
            // 
            this.lblPaymentNotifsLabel.AutoSize = true;
            this.lblPaymentNotifsLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblPaymentNotifsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblPaymentNotifsLabel.Location = new System.Drawing.Point(88, 25);
            this.lblPaymentNotifsLabel.Name = "lblPaymentNotifsLabel";
            this.lblPaymentNotifsLabel.Size = new System.Drawing.Size(175, 19);
            this.lblPaymentNotifsLabel.TabIndex = 1;
            this.lblPaymentNotifsLabel.Text = "Payment Notifications";
            // 
            // picPaymentNotifs
            // 
            this.picPaymentNotifs.Image = global::SkolarAid.Properties.Resources.dollar;
            this.picPaymentNotifs.Location = new System.Drawing.Point(20, 40);
            this.picPaymentNotifs.Name = "picPaymentNotifs";
            this.picPaymentNotifs.Size = new System.Drawing.Size(50, 55);
            this.picPaymentNotifs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPaymentNotifs.TabIndex = 2;
            this.picPaymentNotifs.TabStop = false;
            // 
            // panelCard4
            // 
            this.panelCard4.BackColor = System.Drawing.Color.White;
            this.panelCard4.BackColor2 = System.Drawing.Color.White;
            this.panelCard4.BorderColor = System.Drawing.Color.Black;
            borderRadius5.BottomLeft = 15;
            borderRadius5.BottomRight = 15;
            borderRadius5.TopLeft = 15;
            borderRadius5.TopRight = 15;
            this.panelCard4.BorderRadius = borderRadius5;
            this.panelCard4.BorderThickness = 0;
            this.panelCard4.Controls.Add(this.lblAlertNotifs);
            this.panelCard4.Controls.Add(this.lblAlertNotifsLabel);
            this.panelCard4.Controls.Add(this.picAlertNotifs);
            this.panelCard4.Location = new System.Drawing.Point(1005, 0);
            this.panelCard4.Name = "panelCard4";
            this.panelCard4.Size = new System.Drawing.Size(310, 130);
            this.panelCard4.TabIndex = 3;
            // 
            // lblAlertNotifs
            // 
            this.lblAlertNotifs.AutoSize = true;
            this.lblAlertNotifs.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblAlertNotifs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblAlertNotifs.Location = new System.Drawing.Point(85, 55);
            this.lblAlertNotifs.Name = "lblAlertNotifs";
            this.lblAlertNotifs.Size = new System.Drawing.Size(42, 47);
            this.lblAlertNotifs.TabIndex = 0;
            this.lblAlertNotifs.Text = "0";
            // 
            // lblAlertNotifsLabel
            // 
            this.lblAlertNotifsLabel.AutoSize = true;
            this.lblAlertNotifsLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblAlertNotifsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblAlertNotifsLabel.Location = new System.Drawing.Point(88, 25);
            this.lblAlertNotifsLabel.Name = "lblAlertNotifsLabel";
            this.lblAlertNotifsLabel.Size = new System.Drawing.Size(141, 19);
            this.lblAlertNotifsLabel.TabIndex = 1;
            this.lblAlertNotifsLabel.Text = "Alert Notifications";
            // 
            // picAlertNotifs
            // 
            this.picAlertNotifs.Location = new System.Drawing.Point(20, 40);
            this.picAlertNotifs.Name = "picAlertNotifs";
            this.picAlertNotifs.Size = new System.Drawing.Size(50, 55);
            this.picAlertNotifs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAlertNotifs.TabIndex = 2;
            this.picAlertNotifs.TabStop = false;
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.BackColor2 = System.Drawing.Color.White;
            this.panelFilters.BorderColor = System.Drawing.Color.Black;
            borderRadius6.BottomLeft = 15;
            borderRadius6.BottomRight = 15;
            borderRadius6.TopLeft = 15;
            borderRadius6.TopRight = 15;
            this.panelFilters.BorderRadius = borderRadius6;
            this.panelFilters.BorderThickness = 0;
            this.panelFilters.Controls.Add(this.cmbFilterType);
            this.panelFilters.Controls.Add(this.lblFilterType);
            this.panelFilters.Controls.Add(this.chkUnreadOnly);
            this.panelFilters.Controls.Add(this.btnClearFilters);
            this.panelFilters.Controls.Add(this.btnRefresh);
            this.panelFilters.Controls.Add(this.btnMarkAllRead);
            this.panelFilters.Location = new System.Drawing.Point(40, 175);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(940, 70);
            this.panelFilters.TabIndex = 1;
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Items.AddRange(new object[] {
            "All Types",
            "Payment",
            "Reminder",
            "Alert",
            "Update",
            "Announcement"});
            this.cmbFilterType.Location = new System.Drawing.Point(80, 22);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(150, 28);
            this.cmbFilterType.TabIndex = 1;
            // 
            // lblFilterType
            // 
            this.lblFilterType.AutoSize = true;
            this.lblFilterType.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblFilterType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblFilterType.Location = new System.Drawing.Point(20, 26);
            this.lblFilterType.Name = "lblFilterType";
            this.lblFilterType.Size = new System.Drawing.Size(47, 18);
            this.lblFilterType.TabIndex = 0;
            this.lblFilterType.Text = "Type:";
            // 
            // chkUnreadOnly
            // 
            this.chkUnreadOnly.AutoSize = true;
            this.chkUnreadOnly.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.chkUnreadOnly.Location = new System.Drawing.Point(260, 24);
            this.chkUnreadOnly.Name = "chkUnreadOnly";
            this.chkUnreadOnly.Size = new System.Drawing.Size(120, 24);
            this.chkUnreadOnly.TabIndex = 2;
            this.chkUnreadOnly.Text = "Unread Only";
            this.chkUnreadOnly.UseVisualStyleBackColor = true;
            this.chkUnreadOnly.CheckedChanged += new System.EventHandler(this.chkUnreadOnly_CheckedChanged);
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
            this.btnClearFilters.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
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
            this.btnClearFilters.Location = new System.Drawing.Point(720, 20);
            this.btnClearFilters.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnClearFilters.NormalForeColor = System.Drawing.Color.White;
            this.btnClearFilters.NormalOutline = System.Drawing.Color.Empty;
            this.btnClearFilters.OutlineThickness = 2F;
            this.btnClearFilters.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnClearFilters.PressedForeColor = System.Drawing.Color.White;
            this.btnClearFilters.PressedImageTint = System.Drawing.Color.White;
            this.btnClearFilters.PressedOutline = System.Drawing.Color.Empty;
            this.btnClearFilters.Rounding = new System.Windows.Forms.Padding(6);
            this.btnClearFilters.Size = new System.Drawing.Size(80, 32);
            this.btnClearFilters.TabIndex = 4;
            this.btnClearFilters.TextAutoCenter = true;
            this.btnClearFilters.TextOffset = new System.Drawing.Point(0, 0);
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonText = "Refresh";
            this.btnRefresh.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnRefresh.CheckedForeColor = System.Drawing.Color.White;
            this.btnRefresh.CheckedImageTint = System.Drawing.Color.White;
            this.btnRefresh.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnRefresh.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefresh.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnRefresh.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.btnRefresh.HoverForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverImage = null;
            this.btnRefresh.HoverImageTint = System.Drawing.Color.White;
            this.btnRefresh.HoverOutline = System.Drawing.Color.Empty;
            this.btnRefresh.Image = null;
            this.btnRefresh.ImageAutoCenter = true;
            this.btnRefresh.ImageExpand = new System.Drawing.Point(6, 6);
            this.btnRefresh.ImageOffset = new System.Drawing.Point(-10, 0);
            this.btnRefresh.ImageTint = System.Drawing.Color.White;
            this.btnRefresh.IsToggleButton = false;
            this.btnRefresh.IsToggled = false;
            this.btnRefresh.Location = new System.Drawing.Point(620, 20);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnRefresh.NormalForeColor = System.Drawing.Color.White;
            this.btnRefresh.NormalOutline = System.Drawing.Color.Empty;
            this.btnRefresh.OutlineThickness = 2F;
            this.btnRefresh.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnRefresh.PressedForeColor = System.Drawing.Color.White;
            this.btnRefresh.PressedImageTint = System.Drawing.Color.White;
            this.btnRefresh.PressedOutline = System.Drawing.Color.Empty;
            this.btnRefresh.Rounding = new System.Windows.Forms.Padding(6);
            this.btnRefresh.Size = new System.Drawing.Size(90, 32);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.TextAutoCenter = true;
            this.btnRefresh.TextOffset = new System.Drawing.Point(0, 0);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnMarkAllRead
            // 
            this.btnMarkAllRead.ButtonText = "Mark All as Read";
            this.btnMarkAllRead.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnMarkAllRead.CheckedForeColor = System.Drawing.Color.White;
            this.btnMarkAllRead.CheckedImageTint = System.Drawing.Color.White;
            this.btnMarkAllRead.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnMarkAllRead.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMarkAllRead.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnMarkAllRead.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.btnMarkAllRead.HoverForeColor = System.Drawing.Color.White;
            this.btnMarkAllRead.HoverImage = null;
            this.btnMarkAllRead.HoverImageTint = System.Drawing.Color.White;
            this.btnMarkAllRead.HoverOutline = System.Drawing.Color.Empty;
            this.btnMarkAllRead.Image = null;
            this.btnMarkAllRead.ImageAutoCenter = true;
            this.btnMarkAllRead.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnMarkAllRead.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnMarkAllRead.ImageTint = System.Drawing.Color.White;
            this.btnMarkAllRead.IsToggleButton = false;
            this.btnMarkAllRead.IsToggled = false;
            this.btnMarkAllRead.Location = new System.Drawing.Point(400, 20);
            this.btnMarkAllRead.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnMarkAllRead.Name = "btnMarkAllRead";
            this.btnMarkAllRead.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnMarkAllRead.NormalForeColor = System.Drawing.Color.White;
            this.btnMarkAllRead.NormalOutline = System.Drawing.Color.Empty;
            this.btnMarkAllRead.OutlineThickness = 2F;
            this.btnMarkAllRead.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnMarkAllRead.PressedForeColor = System.Drawing.Color.White;
            this.btnMarkAllRead.PressedImageTint = System.Drawing.Color.White;
            this.btnMarkAllRead.PressedOutline = System.Drawing.Color.Empty;
            this.btnMarkAllRead.Rounding = new System.Windows.Forms.Padding(6);
            this.btnMarkAllRead.Size = new System.Drawing.Size(140, 32);
            this.btnMarkAllRead.TabIndex = 3;
            this.btnMarkAllRead.TextAutoCenter = true;
            this.btnMarkAllRead.TextOffset = new System.Drawing.Point(0, 0);
            this.btnMarkAllRead.Click += new System.EventHandler(this.btnMarkAllRead_Click);
            // 
            // panelNotificationList
            // 
            this.panelNotificationList.BackColor = System.Drawing.Color.White;
            this.panelNotificationList.BackColor2 = System.Drawing.Color.White;
            this.panelNotificationList.BorderColor = System.Drawing.Color.Black;
            this.panelNotificationList.BorderRadius = borderRadius1;
            this.panelNotificationList.BorderThickness = 0;
            this.panelNotificationList.Controls.Add(this.flowNotifications);
            this.panelNotificationList.Controls.Add(this.lblTotalRecords);
            this.panelNotificationList.Location = new System.Drawing.Point(40, 260);
            this.panelNotificationList.Name = "panelNotificationList";
            this.panelNotificationList.Size = new System.Drawing.Size(940, 680);
            this.panelNotificationList.TabIndex = 2;
            // 
            // flowNotifications
            // 
            this.flowNotifications.AutoScroll = true;
            this.flowNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowNotifications.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowNotifications.Location = new System.Drawing.Point(0, 0);
            this.flowNotifications.Name = "flowNotifications";
            this.flowNotifications.Padding = new System.Windows.Forms.Padding(15);
            this.flowNotifications.Size = new System.Drawing.Size(940, 680);
            this.flowNotifications.TabIndex = 0;
            this.flowNotifications.WrapContents = false;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblTotalRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTotalRecords.Location = new System.Drawing.Point(15, 658);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(116, 17);
            this.lblTotalRecords.TabIndex = 1;
            this.lblTotalRecords.Text = "Showing 0 records";
            // 
            // panelDetailView
            // 
            this.panelDetailView.BackColor = System.Drawing.Color.White;
            this.panelDetailView.BackColor2 = System.Drawing.Color.White;
            this.panelDetailView.BorderColor = System.Drawing.Color.Black;
            this.panelDetailView.BorderRadius = borderRadius1;
            this.panelDetailView.BorderThickness = 0;
            this.panelDetailView.Controls.Add(this.lblDetailTitle);
            this.panelDetailView.Controls.Add(this.lblDetailType);
            this.panelDetailView.Controls.Add(this.lblDetailDate);
            this.panelDetailView.Controls.Add(this.lblDetailMessage);
            this.panelDetailView.Controls.Add(this.lblDetailDeliveryLabel);
            this.panelDetailView.Controls.Add(this.lblDetailDelivery);
            this.panelDetailView.Controls.Add(this.lblDetailStatusLabel);
            this.panelDetailView.Controls.Add(this.lblDetailStatus);
            this.panelDetailView.Location = new System.Drawing.Point(1000, 260);
            this.panelDetailView.Name = "panelDetailView";
            this.panelDetailView.Size = new System.Drawing.Size(360, 680);
            this.panelDetailView.TabIndex = 3;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(20, 20);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(320, 30);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "Select a notification";
            // 
            // lblDetailType
            // 
            this.lblDetailType.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetailType.Location = new System.Drawing.Point(21, 60);
            this.lblDetailType.Name = "lblDetailType";
            this.lblDetailType.Size = new System.Drawing.Size(320, 25);
            this.lblDetailType.TabIndex = 1;
            this.lblDetailType.Text = "-";
            // 
            // lblDetailDate
            // 
            this.lblDetailDate.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblDetailDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblDetailDate.Location = new System.Drawing.Point(21, 85);
            this.lblDetailDate.Name = "lblDetailDate";
            this.lblDetailDate.Size = new System.Drawing.Size(320, 25);
            this.lblDetailDate.TabIndex = 2;
            this.lblDetailDate.Text = "-";
            // 
            // lblDetailMessage
            // 
            this.lblDetailMessage.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lblDetailMessage.ForeColor = System.Drawing.Color.Black;
            this.lblDetailMessage.Location = new System.Drawing.Point(21, 130);
            this.lblDetailMessage.Name = "lblDetailMessage";
            this.lblDetailMessage.Size = new System.Drawing.Size(320, 300);
            this.lblDetailMessage.TabIndex = 3;
            this.lblDetailMessage.Text = "Click on any notification to view its details.";
            // 
            // lblDetailDeliveryLabel
            // 
            this.lblDetailDeliveryLabel.AutoSize = true;
            this.lblDetailDeliveryLabel.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailDeliveryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblDetailDeliveryLabel.Location = new System.Drawing.Point(21, 450);
            this.lblDetailDeliveryLabel.Name = "lblDetailDeliveryLabel";
            this.lblDetailDeliveryLabel.Size = new System.Drawing.Size(122, 17);
            this.lblDetailDeliveryLabel.TabIndex = 4;
            this.lblDetailDeliveryLabel.Text = "Delivery Method:";
            // 
            // lblDetailDelivery
            // 
            this.lblDetailDelivery.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lblDetailDelivery.ForeColor = System.Drawing.Color.Black;
            this.lblDetailDelivery.Location = new System.Drawing.Point(21, 470);
            this.lblDetailDelivery.Name = "lblDetailDelivery";
            this.lblDetailDelivery.Size = new System.Drawing.Size(320, 25);
            this.lblDetailDelivery.TabIndex = 5;
            this.lblDetailDelivery.Text = "-";
            // 
            // lblDetailStatusLabel
            // 
            this.lblDetailStatusLabel.AutoSize = true;
            this.lblDetailStatusLabel.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblDetailStatusLabel.Location = new System.Drawing.Point(21, 510);
            this.lblDetailStatusLabel.Name = "lblDetailStatusLabel";
            this.lblDetailStatusLabel.Size = new System.Drawing.Size(50, 17);
            this.lblDetailStatusLabel.TabIndex = 4;
            this.lblDetailStatusLabel.Text = "Status:";
            // 
            // lblDetailStatus
            // 
            this.lblDetailStatus.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetailStatus.Location = new System.Drawing.Point(21, 530);
            this.lblDetailStatus.Name = "lblDetailStatus";
            this.lblDetailStatus.Size = new System.Drawing.Size(320, 25);
            this.lblDetailStatus.TabIndex = 5;
            this.lblDetailStatus.Text = "-";
            // 
            // FrmScholarNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1700, 1050);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScholarNotifications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifications - ScholarAid";
            this.Load += new System.EventHandler(this.FrmScholarNotifications_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelSummaryCards.ResumeLayout(false);
            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalNotifications)).EndInit();
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUnread)).EndInit();
            this.panelCard3.ResumeLayout(false);
            this.panelCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPaymentNotifs)).EndInit();
            this.panelCard4.ResumeLayout(false);
            this.panelCard4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertNotifs)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelNotificationList.ResumeLayout(false);
            this.panelNotificationList.PerformLayout();
            this.panelDetailView.ResumeLayout(false);
            this.panelDetailView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Sidebar
        private System.Windows.Forms.Panel panelSidebar;
        private FrameworkTest.SATAButton btnDashboard;
        private FrameworkTest.SATAButton btnProfile;
        private FrameworkTest.SATAButton btnPayments;
        private FrameworkTest.SATAButton btnCompliance;
        private FrameworkTest.SATAButton btnNotifications;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblBrand;

        // Header
        private SATAUiFramework.SATAPanel panelHeader;
        private FrameworkTest.SATAButton btnLogout;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblScholarInfo;

        // Content
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblDate;

        // Summary Cards
        private System.Windows.Forms.Panel panelSummaryCards;
        private SATAUiFramework.SATAPanel panelCard1;
        private System.Windows.Forms.Label lblTotalNotifications;
        private System.Windows.Forms.Label lblTotalNotificationsLabel;
        private System.Windows.Forms.PictureBox picTotalNotifications;
        private SATAUiFramework.SATAPanel panelCard2;
        private System.Windows.Forms.Label lblUnreadCount;
        private System.Windows.Forms.Label lblUnreadCountLabel;
        private System.Windows.Forms.PictureBox picUnread;
        private SATAUiFramework.SATAPanel panelCard3;
        private System.Windows.Forms.Label lblPaymentNotifs;
        private System.Windows.Forms.Label lblPaymentNotifsLabel;
        private System.Windows.Forms.PictureBox picPaymentNotifs;
        private SATAUiFramework.SATAPanel panelCard4;
        private System.Windows.Forms.Label lblAlertNotifs;
        private System.Windows.Forms.Label lblAlertNotifsLabel;
        private System.Windows.Forms.PictureBox picAlertNotifs;

        // Filters
        private SATAUiFramework.SATAPanel panelFilters;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.CheckBox chkUnreadOnly;
        private FrameworkTest.SATAButton btnClearFilters;
        private FrameworkTest.SATAButton btnRefresh;
        private FrameworkTest.SATAButton btnMarkAllRead;

        // Notification List
        private SATAUiFramework.SATAPanel panelNotificationList;
        private System.Windows.Forms.FlowLayoutPanel flowNotifications;
        private System.Windows.Forms.Label lblTotalRecords;

        // Detail View
        private SATAUiFramework.SATAPanel panelDetailView;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblDetailType;
        private System.Windows.Forms.Label lblDetailDate;
        private System.Windows.Forms.Label lblDetailMessage;
        private System.Windows.Forms.Label lblDetailDeliveryLabel;
        private System.Windows.Forms.Label lblDetailDelivery;
        private System.Windows.Forms.Label lblDetailStatusLabel;
        private System.Windows.Forms.Label lblDetailStatus;
    }
}