namespace SkolarAid
{
    partial class FrmScholarProfile
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
            this.panelHeader = new SATAUiFramework.SATAPanel();
            this.btnLogout = new FrameworkTest.SATAButton();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblScholarInfo = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelProfileHeader = new SATAUiFramework.SATAPanel();
            this.sataButton1 = new FrameworkTest.SATAButton();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.lblProfileStatus = new System.Windows.Forms.Label();
            this.picProfilePhoto = new System.Windows.Forms.PictureBox();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnNotifications = new FrameworkTest.SATAButton();
            this.btnCompliance = new FrameworkTest.SATAButton();
            this.btnPayments = new FrameworkTest.SATAButton();
            this.btnProfile = new FrameworkTest.SATAButton();
            this.btnDashboard = new FrameworkTest.SATAButton();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.panelPersonalInfo = new SATAUiFramework.SATAPanel();
            this.txtBankAccountNumber = new System.Windows.Forms.TextBox();
            this.lblBankAccountNumber = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblPersonalTitle = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.lblContactNumber = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.panelAcademicInfo = new SATAUiFramework.SATAPanel();
            this.txtHEI = new System.Windows.Forms.TextBox();
            this.lblAcademicTitle = new System.Windows.Forms.Label();
            this.lblHEI = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.lblYearLevel = new System.Windows.Forms.Label();
            this.panelScholarshipInfo = new SATAUiFramework.SATAPanel();
            this.txtFundSource = new System.Windows.Forms.TextBox();
            this.lblFundSource = new System.Windows.Forms.Label();
            this.txtRenewalConditions = new System.Windows.Forms.TextBox();
            this.lblRenewalConditions = new System.Windows.Forms.Label();
            this.txtScholarshipTypeValue = new System.Windows.Forms.TextBox();
            this.txtStatusValue = new System.Windows.Forms.TextBox();
            this.lblScholarshipTitle = new System.Windows.Forms.Label();
            this.txtScholarNumber = new System.Windows.Forms.TextBox();
            this.lblScholarNumber = new System.Windows.Forms.Label();
            this.lblScholarshipType = new System.Windows.Forms.Label();
            this.dtpEnrollmentDate = new System.Windows.Forms.DateTimePicker();
            this.lblEnrollmentDate = new System.Windows.Forms.Label();
            this.dtpExpectedGraduation = new System.Windows.Forms.DateTimePicker();
            this.lblExpectedGraduation = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStipendAmount = new System.Windows.Forms.TextBox();
            this.lblStipendAmount = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.panelContent.SuspendLayout();
            this.panelProfileHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePhoto)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelPersonalInfo.SuspendLayout();
            this.panelAcademicInfo.SuspendLayout();
            this.panelScholarshipInfo.SuspendLayout();
            this.SuspendLayout();
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
            this.lblPageTitle.Size = new System.Drawing.Size(140, 32);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "My Profile";
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
            this.panelContent.Controls.Add(this.panelProfileHeader);
            this.panelContent.Controls.Add(this.panelSidebar);
            this.panelContent.Controls.Add(this.lblDate);
            this.panelContent.Controls.Add(this.panelPersonalInfo);
            this.panelContent.Controls.Add(this.panelAcademicInfo);
            this.panelContent.Controls.Add(this.panelScholarshipInfo);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1920, 1061);
            this.panelContent.TabIndex = 2;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // panelProfileHeader
            // 
            this.panelProfileHeader.BackColor = System.Drawing.Color.White;
            this.panelProfileHeader.BackColor2 = System.Drawing.Color.White;
            this.panelProfileHeader.BorderColor = System.Drawing.Color.Black;
            borderRadius2.BottomLeft = 15;
            borderRadius2.BottomRight = 15;
            borderRadius2.TopLeft = 15;
            borderRadius2.TopRight = 15;
            this.panelProfileHeader.BorderRadius = borderRadius2;
            this.panelProfileHeader.BorderThickness = 0;
            this.panelProfileHeader.Controls.Add(this.sataButton1);
            this.panelProfileHeader.Controls.Add(this.lblProfileName);
            this.panelProfileHeader.Controls.Add(this.lblProfileStatus);
            this.panelProfileHeader.Controls.Add(this.picProfilePhoto);
            this.panelProfileHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProfileHeader.Location = new System.Drawing.Point(300, 0);
            this.panelProfileHeader.Name = "panelProfileHeader";
            this.panelProfileHeader.Size = new System.Drawing.Size(1620, 142);
            this.panelProfileHeader.TabIndex = 0;
            // 
            // sataButton1
            // 
            this.sataButton1.ButtonText = "Logout";
            this.sataButton1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.sataButton1.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton1.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton1.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.sataButton1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton1.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.sataButton1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.sataButton1.HoverForeColor = System.Drawing.Color.White;
            this.sataButton1.HoverImage = null;
            this.sataButton1.HoverImageTint = System.Drawing.Color.White;
            this.sataButton1.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton1.Image = null;
            this.sataButton1.ImageAutoCenter = true;
            this.sataButton1.ImageExpand = new System.Drawing.Point(0, 0);
            this.sataButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.sataButton1.ImageTint = System.Drawing.Color.White;
            this.sataButton1.IsToggleButton = false;
            this.sataButton1.IsToggled = false;
            this.sataButton1.Location = new System.Drawing.Point(1463, 37);
            this.sataButton1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.sataButton1.Name = "sataButton1";
            this.sataButton1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.sataButton1.NormalForeColor = System.Drawing.Color.White;
            this.sataButton1.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton1.OutlineThickness = 2F;
            this.sataButton1.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.sataButton1.PressedForeColor = System.Drawing.Color.White;
            this.sataButton1.PressedImageTint = System.Drawing.Color.White;
            this.sataButton1.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton1.Rounding = new System.Windows.Forms.Padding(8);
            this.sataButton1.Size = new System.Drawing.Size(110, 40);
            this.sataButton1.TabIndex = 6;
            this.sataButton1.TextAutoCenter = true;
            this.sataButton1.TextOffset = new System.Drawing.Point(0, 0);
            this.sataButton1.Click += new System.EventHandler(this.sataButton1_Click);
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold);
            this.lblProfileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblProfileName.Location = new System.Drawing.Point(155, 30);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(338, 37);
            this.lblProfileName.TabIndex = 1;
            this.lblProfileName.Text = "Juan Santos Dela Cruz";
            // 
            // lblProfileStatus
            // 
            this.lblProfileStatus.AutoSize = true;
            this.lblProfileStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblProfileStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblProfileStatus.Location = new System.Drawing.Point(158, 72);
            this.lblProfileStatus.Name = "lblProfileStatus";
            this.lblProfileStatus.Size = new System.Drawing.Size(134, 19);
            this.lblProfileStatus.TabIndex = 2;
            this.lblProfileStatus.Text = "● Active Scholar";
            // 
            // picProfilePhoto
            // 
            this.picProfilePhoto.Image = global::SkolarAid.Properties.Resources.user__3_;
            this.picProfilePhoto.Location = new System.Drawing.Point(30, 25);
            this.picProfilePhoto.Name = "picProfilePhoto";
            this.picProfilePhoto.Size = new System.Drawing.Size(100, 100);
            this.picProfilePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProfilePhoto.TabIndex = 0;
            this.picProfilePhoto.TabStop = false;
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
            this.panelSidebar.Size = new System.Drawing.Size(300, 1061);
            this.panelSidebar.TabIndex = 6;
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
            this.btnNotifications.ImageOffset = new System.Drawing.Point(-35, 0);
            this.btnNotifications.ImageTint = System.Drawing.Color.White;
            this.btnNotifications.IsToggleButton = false;
            this.btnNotifications.IsToggled = false;
            this.btnNotifications.Location = new System.Drawing.Point(1, 404);
            this.btnNotifications.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
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
            this.btnCompliance.ImageOffset = new System.Drawing.Point(-35, 0);
            this.btnCompliance.ImageTint = System.Drawing.Color.White;
            this.btnCompliance.IsToggleButton = false;
            this.btnCompliance.IsToggled = false;
            this.btnCompliance.Location = new System.Drawing.Point(0, 329);
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
            this.btnPayments.ImageOffset = new System.Drawing.Point(-25, 0);
            this.btnPayments.ImageTint = System.Drawing.Color.White;
            this.btnPayments.IsToggleButton = false;
            this.btnPayments.IsToggled = false;
            this.btnPayments.Location = new System.Drawing.Point(1, 254);
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
            this.btnProfile.ImageOffset = new System.Drawing.Point(-45, 0);
            this.btnProfile.ImageTint = System.Drawing.Color.White;
            this.btnProfile.IsToggleButton = false;
            this.btnProfile.IsToggled = false;
            this.btnProfile.Location = new System.Drawing.Point(1, 179);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
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
            this.btnDashboard.IsToggled = true;
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
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblDate.Location = new System.Drawing.Point(317, 160);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(203, 21);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Monday, January 1, 2026";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelPersonalInfo
            // 
            this.panelPersonalInfo.BackColor = System.Drawing.Color.White;
            this.panelPersonalInfo.BackColor2 = System.Drawing.Color.White;
            this.panelPersonalInfo.BorderColor = System.Drawing.Color.Black;
            borderRadius3.BottomLeft = 15;
            borderRadius3.BottomRight = 15;
            borderRadius3.TopLeft = 15;
            borderRadius3.TopRight = 15;
            this.panelPersonalInfo.BorderRadius = borderRadius3;
            this.panelPersonalInfo.BorderThickness = 0;
            this.panelPersonalInfo.Controls.Add(this.txtBankAccountNumber);
            this.panelPersonalInfo.Controls.Add(this.lblBankAccountNumber);
            this.panelPersonalInfo.Controls.Add(this.txtBankName);
            this.panelPersonalInfo.Controls.Add(this.lblBankName);
            this.panelPersonalInfo.Controls.Add(this.lblPersonalTitle);
            this.panelPersonalInfo.Controls.Add(this.txtFirstName);
            this.panelPersonalInfo.Controls.Add(this.lblFirstName);
            this.panelPersonalInfo.Controls.Add(this.txtMiddleName);
            this.panelPersonalInfo.Controls.Add(this.lblMiddleName);
            this.panelPersonalInfo.Controls.Add(this.txtLastName);
            this.panelPersonalInfo.Controls.Add(this.lblLastName);
            this.panelPersonalInfo.Controls.Add(this.txtEmail);
            this.panelPersonalInfo.Controls.Add(this.lblEmail);
            this.panelPersonalInfo.Controls.Add(this.txtContactNumber);
            this.panelPersonalInfo.Controls.Add(this.lblContactNumber);
            this.panelPersonalInfo.Controls.Add(this.txtAddress);
            this.panelPersonalInfo.Controls.Add(this.lblAddress);
            this.panelPersonalInfo.Controls.Add(this.dtpBirthDate);
            this.panelPersonalInfo.Controls.Add(this.lblBirthDate);
            this.panelPersonalInfo.Controls.Add(this.cmbGender);
            this.panelPersonalInfo.Controls.Add(this.lblGender);
            this.panelPersonalInfo.Location = new System.Drawing.Point(317, 191);
            this.panelPersonalInfo.Name = "panelPersonalInfo";
            this.panelPersonalInfo.Size = new System.Drawing.Size(640, 843);
            this.panelPersonalInfo.TabIndex = 1;
            this.panelPersonalInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPersonalInfo_Paint);
            // 
            // txtBankAccountNumber
            // 
            this.txtBankAccountNumber.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtBankAccountNumber.Location = new System.Drawing.Point(25, 489);
            this.txtBankAccountNumber.Name = "txtBankAccountNumber";
            this.txtBankAccountNumber.ReadOnly = true;
            this.txtBankAccountNumber.Size = new System.Drawing.Size(580, 25);
            this.txtBankAccountNumber.TabIndex = 8;
            // 
            // lblBankAccountNumber
            // 
            this.lblBankAccountNumber.AutoSize = true;
            this.lblBankAccountNumber.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblBankAccountNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblBankAccountNumber.Location = new System.Drawing.Point(22, 469);
            this.lblBankAccountNumber.Name = "lblBankAccountNumber";
            this.lblBankAccountNumber.Size = new System.Drawing.Size(169, 19);
            this.lblBankAccountNumber.TabIndex = 9;
            this.lblBankAccountNumber.Text = "Bank Account Number:";
            // 
            // txtBankName
            // 
            this.txtBankName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtBankName.Location = new System.Drawing.Point(25, 421);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.ReadOnly = true;
            this.txtBankName.Size = new System.Drawing.Size(580, 25);
            this.txtBankName.TabIndex = 6;
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblBankName.Location = new System.Drawing.Point(22, 401);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(93, 19);
            this.lblBankName.TabIndex = 7;
            this.lblBankName.Text = "Bank Name:";
            // 
            // lblPersonalTitle
            // 
            this.lblPersonalTitle.AutoSize = true;
            this.lblPersonalTitle.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.lblPersonalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblPersonalTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPersonalTitle.Name = "lblPersonalTitle";
            this.lblPersonalTitle.Size = new System.Drawing.Size(229, 26);
            this.lblPersonalTitle.TabIndex = 0;
            this.lblPersonalTitle.Text = "Personal Information";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtFirstName.Location = new System.Drawing.Point(25, 85);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(180, 25);
            this.txtFirstName.TabIndex = 2;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblFirstName.Location = new System.Drawing.Point(22, 65);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(79, 19);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "First Name";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtMiddleName.Location = new System.Drawing.Point(225, 85);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.ReadOnly = true;
            this.txtMiddleName.Size = new System.Drawing.Size(180, 25);
            this.txtMiddleName.TabIndex = 2;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblMiddleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblMiddleName.Location = new System.Drawing.Point(222, 65);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(103, 19);
            this.lblMiddleName.TabIndex = 3;
            this.lblMiddleName.Text = "Middle Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtLastName.Location = new System.Drawing.Point(425, 85);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(180, 25);
            this.txtLastName.TabIndex = 2;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblLastName.Location = new System.Drawing.Point(422, 65);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(81, 19);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtEmail.Location = new System.Drawing.Point(25, 145);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(380, 25);
            this.txtEmail.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblEmail.Location = new System.Drawing.Point(22, 125);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(102, 19);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email Address";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtContactNumber.Location = new System.Drawing.Point(25, 205);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.ReadOnly = true;
            this.txtContactNumber.Size = new System.Drawing.Size(250, 25);
            this.txtContactNumber.TabIndex = 2;
            // 
            // lblContactNumber
            // 
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblContactNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblContactNumber.Location = new System.Drawing.Point(22, 185);
            this.lblContactNumber.Name = "lblContactNumber";
            this.lblContactNumber.Size = new System.Drawing.Size(126, 19);
            this.lblContactNumber.TabIndex = 3;
            this.lblContactNumber.Text = "Contact Number";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtAddress.Location = new System.Drawing.Point(25, 265);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(580, 50);
            this.txtAddress.TabIndex = 2;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblAddress.Location = new System.Drawing.Point(22, 245);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(61, 19);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Address";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Enabled = false;
            this.dtpBirthDate.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(25, 345);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(180, 25);
            this.dtpBirthDate.TabIndex = 4;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblBirthDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblBirthDate.Location = new System.Drawing.Point(22, 325);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(76, 19);
            this.lblBirthDate.TabIndex = 3;
            this.lblBirthDate.Text = "Birth Date";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Enabled = false;
            this.cmbGender.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbGender.Location = new System.Drawing.Point(256, 345);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(180, 28);
            this.cmbGender.TabIndex = 5;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblGender.Location = new System.Drawing.Point(253, 325);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(62, 19);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Gender";
            // 
            // panelAcademicInfo
            // 
            this.panelAcademicInfo.BackColor = System.Drawing.Color.White;
            this.panelAcademicInfo.BackColor2 = System.Drawing.Color.White;
            this.panelAcademicInfo.BorderColor = System.Drawing.Color.Black;
            borderRadius4.BottomLeft = 15;
            borderRadius4.BottomRight = 15;
            borderRadius4.TopLeft = 15;
            borderRadius4.TopRight = 15;
            this.panelAcademicInfo.BorderRadius = borderRadius4;
            this.panelAcademicInfo.BorderThickness = 0;
            this.panelAcademicInfo.Controls.Add(this.txtHEI);
            this.panelAcademicInfo.Controls.Add(this.lblAcademicTitle);
            this.panelAcademicInfo.Controls.Add(this.lblHEI);
            this.panelAcademicInfo.Controls.Add(this.txtStudentID);
            this.panelAcademicInfo.Controls.Add(this.lblStudentID);
            this.panelAcademicInfo.Controls.Add(this.cmbCourse);
            this.panelAcademicInfo.Controls.Add(this.lblCourse);
            this.panelAcademicInfo.Controls.Add(this.cmbYearLevel);
            this.panelAcademicInfo.Controls.Add(this.lblYearLevel);
            this.panelAcademicInfo.Location = new System.Drawing.Point(977, 191);
            this.panelAcademicInfo.Name = "panelAcademicInfo";
            this.panelAcademicInfo.Size = new System.Drawing.Size(915, 240);
            this.panelAcademicInfo.TabIndex = 2;
            // 
            // txtHEI
            // 
            this.txtHEI.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtHEI.Location = new System.Drawing.Point(365, 75);
            this.txtHEI.Name = "txtHEI";
            this.txtHEI.ReadOnly = true;
            this.txtHEI.Size = new System.Drawing.Size(391, 25);
            this.txtHEI.TabIndex = 12;
            // 
            // lblAcademicTitle
            // 
            this.lblAcademicTitle.AutoSize = true;
            this.lblAcademicTitle.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.lblAcademicTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblAcademicTitle.Location = new System.Drawing.Point(20, 20);
            this.lblAcademicTitle.Name = "lblAcademicTitle";
            this.lblAcademicTitle.Size = new System.Drawing.Size(253, 26);
            this.lblAcademicTitle.TabIndex = 0;
            this.lblAcademicTitle.Text = "Academic Information";
            // 
            // lblHEI
            // 
            this.lblHEI.AutoSize = true;
            this.lblHEI.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblHEI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblHEI.Location = new System.Drawing.Point(362, 55);
            this.lblHEI.Name = "lblHEI";
            this.lblHEI.Size = new System.Drawing.Size(198, 19);
            this.lblHEI.TabIndex = 13;
            this.lblHEI.Text = "Higher Education Institution";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtStudentID.Location = new System.Drawing.Point(25, 75);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.ReadOnly = true;
            this.txtStudentID.Size = new System.Drawing.Size(286, 25);
            this.txtStudentID.TabIndex = 2;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblStudentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblStudentID.Location = new System.Drawing.Point(22, 55);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(80, 19);
            this.lblStudentID.TabIndex = 3;
            this.lblStudentID.Text = "Student ID";
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Enabled = false;
            this.cmbCourse.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Items.AddRange(new object[] {
            "BS Information Technology",
            "BS Computer Science",
            "BS Information Systems",
            "BS Business Administration",
            "BS Education"});
            this.cmbCourse.Location = new System.Drawing.Point(25, 135);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(730, 28);
            this.cmbCourse.TabIndex = 5;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblCourse.Location = new System.Drawing.Point(22, 115);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(56, 19);
            this.lblCourse.TabIndex = 3;
            this.lblCourse.Text = "Course";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearLevel.Enabled = false;
            this.cmbYearLevel.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Items.AddRange(new object[] {
            "1st Year",
            "2nd Year",
            "3rd Year",
            "4th Year"});
            this.cmbYearLevel.Location = new System.Drawing.Point(24, 199);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(287, 28);
            this.cmbYearLevel.TabIndex = 5;
            // 
            // lblYearLevel
            // 
            this.lblYearLevel.AutoSize = true;
            this.lblYearLevel.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblYearLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblYearLevel.Location = new System.Drawing.Point(21, 179);
            this.lblYearLevel.Name = "lblYearLevel";
            this.lblYearLevel.Size = new System.Drawing.Size(78, 19);
            this.lblYearLevel.TabIndex = 3;
            this.lblYearLevel.Text = "Year Level";
            // 
            // panelScholarshipInfo
            // 
            this.panelScholarshipInfo.BackColor = System.Drawing.Color.White;
            this.panelScholarshipInfo.BackColor2 = System.Drawing.Color.White;
            this.panelScholarshipInfo.BorderColor = System.Drawing.Color.Black;
            this.panelScholarshipInfo.BorderRadius = borderRadius1;
            this.panelScholarshipInfo.BorderThickness = 0;
            this.panelScholarshipInfo.Controls.Add(this.txtFundSource);
            this.panelScholarshipInfo.Controls.Add(this.lblFundSource);
            this.panelScholarshipInfo.Controls.Add(this.txtRenewalConditions);
            this.panelScholarshipInfo.Controls.Add(this.lblRenewalConditions);
            this.panelScholarshipInfo.Controls.Add(this.txtScholarshipTypeValue);
            this.panelScholarshipInfo.Controls.Add(this.txtStatusValue);
            this.panelScholarshipInfo.Controls.Add(this.lblScholarshipTitle);
            this.panelScholarshipInfo.Controls.Add(this.txtScholarNumber);
            this.panelScholarshipInfo.Controls.Add(this.lblScholarNumber);
            this.panelScholarshipInfo.Controls.Add(this.lblScholarshipType);
            this.panelScholarshipInfo.Controls.Add(this.dtpEnrollmentDate);
            this.panelScholarshipInfo.Controls.Add(this.lblEnrollmentDate);
            this.panelScholarshipInfo.Controls.Add(this.dtpExpectedGraduation);
            this.panelScholarshipInfo.Controls.Add(this.lblExpectedGraduation);
            this.panelScholarshipInfo.Controls.Add(this.lblStatus);
            this.panelScholarshipInfo.Controls.Add(this.txtStipendAmount);
            this.panelScholarshipInfo.Controls.Add(this.lblStipendAmount);
            this.panelScholarshipInfo.Location = new System.Drawing.Point(977, 451);
            this.panelScholarshipInfo.Name = "panelScholarshipInfo";
            this.panelScholarshipInfo.Size = new System.Drawing.Size(915, 583);
            this.panelScholarshipInfo.TabIndex = 3;
            // 
            // txtFundSource
            // 
            this.txtFundSource.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtFundSource.Location = new System.Drawing.Point(23, 351);
            this.txtFundSource.Name = "txtFundSource";
            this.txtFundSource.ReadOnly = true;
            this.txtFundSource.Size = new System.Drawing.Size(732, 25);
            this.txtFundSource.TabIndex = 11;
            // 
            // lblFundSource
            // 
            this.lblFundSource.AutoSize = true;
            this.lblFundSource.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblFundSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblFundSource.Location = new System.Drawing.Point(21, 325);
            this.lblFundSource.Name = "lblFundSource";
            this.lblFundSource.Size = new System.Drawing.Size(177, 19);
            this.lblFundSource.TabIndex = 10;
            this.lblFundSource.Text = "Scholarship Fund Source";
            // 
            // txtRenewalConditions
            // 
            this.txtRenewalConditions.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtRenewalConditions.Location = new System.Drawing.Point(24, 280);
            this.txtRenewalConditions.Name = "txtRenewalConditions";
            this.txtRenewalConditions.ReadOnly = true;
            this.txtRenewalConditions.Size = new System.Drawing.Size(732, 25);
            this.txtRenewalConditions.TabIndex = 9;
            // 
            // lblRenewalConditions
            // 
            this.lblRenewalConditions.AutoSize = true;
            this.lblRenewalConditions.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblRenewalConditions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblRenewalConditions.Location = new System.Drawing.Point(22, 254);
            this.lblRenewalConditions.Name = "lblRenewalConditions";
            this.lblRenewalConditions.Size = new System.Drawing.Size(147, 19);
            this.lblRenewalConditions.TabIndex = 8;
            this.lblRenewalConditions.Text = "Renewal Conditions";
            // 
            // txtScholarshipTypeValue
            // 
            this.txtScholarshipTypeValue.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtScholarshipTypeValue.Location = new System.Drawing.Point(24, 141);
            this.txtScholarshipTypeValue.Name = "txtScholarshipTypeValue";
            this.txtScholarshipTypeValue.ReadOnly = true;
            this.txtScholarshipTypeValue.Size = new System.Drawing.Size(301, 25);
            this.txtScholarshipTypeValue.TabIndex = 7;
            // 
            // txtStatusValue
            // 
            this.txtStatusValue.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtStatusValue.Location = new System.Drawing.Point(24, 209);
            this.txtStatusValue.Name = "txtStatusValue";
            this.txtStatusValue.ReadOnly = true;
            this.txtStatusValue.Size = new System.Drawing.Size(301, 25);
            this.txtStatusValue.TabIndex = 6;
            // 
            // lblScholarshipTitle
            // 
            this.lblScholarshipTitle.AutoSize = true;
            this.lblScholarshipTitle.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.lblScholarshipTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblScholarshipTitle.Location = new System.Drawing.Point(20, 20);
            this.lblScholarshipTitle.Name = "lblScholarshipTitle";
            this.lblScholarshipTitle.Size = new System.Drawing.Size(261, 26);
            this.lblScholarshipTitle.TabIndex = 0;
            this.lblScholarshipTitle.Text = "Scholarship Information";
            // 
            // txtScholarNumber
            // 
            this.txtScholarNumber.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtScholarNumber.Location = new System.Drawing.Point(25, 75);
            this.txtScholarNumber.Name = "txtScholarNumber";
            this.txtScholarNumber.ReadOnly = true;
            this.txtScholarNumber.Size = new System.Drawing.Size(300, 25);
            this.txtScholarNumber.TabIndex = 2;
            // 
            // lblScholarNumber
            // 
            this.lblScholarNumber.AutoSize = true;
            this.lblScholarNumber.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblScholarNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblScholarNumber.Location = new System.Drawing.Point(22, 55);
            this.lblScholarNumber.Name = "lblScholarNumber";
            this.lblScholarNumber.Size = new System.Drawing.Size(119, 19);
            this.lblScholarNumber.TabIndex = 3;
            this.lblScholarNumber.Text = "Scholar Number";
            // 
            // lblScholarshipType
            // 
            this.lblScholarshipType.AutoSize = true;
            this.lblScholarshipType.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblScholarshipType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblScholarshipType.Location = new System.Drawing.Point(22, 115);
            this.lblScholarshipType.Name = "lblScholarshipType";
            this.lblScholarshipType.Size = new System.Drawing.Size(123, 19);
            this.lblScholarshipType.TabIndex = 3;
            this.lblScholarshipType.Text = "Scholarship Type";
            // 
            // dtpEnrollmentDate
            // 
            this.dtpEnrollmentDate.Enabled = false;
            this.dtpEnrollmentDate.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.dtpEnrollmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnrollmentDate.Location = new System.Drawing.Point(345, 75);
            this.dtpEnrollmentDate.Name = "dtpEnrollmentDate";
            this.dtpEnrollmentDate.Size = new System.Drawing.Size(411, 25);
            this.dtpEnrollmentDate.TabIndex = 4;
            // 
            // lblEnrollmentDate
            // 
            this.lblEnrollmentDate.AutoSize = true;
            this.lblEnrollmentDate.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblEnrollmentDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblEnrollmentDate.Location = new System.Drawing.Point(342, 55);
            this.lblEnrollmentDate.Name = "lblEnrollmentDate";
            this.lblEnrollmentDate.Size = new System.Drawing.Size(119, 19);
            this.lblEnrollmentDate.TabIndex = 3;
            this.lblEnrollmentDate.Text = "Enrollment Date";
            // 
            // dtpExpectedGraduation
            // 
            this.dtpExpectedGraduation.Enabled = false;
            this.dtpExpectedGraduation.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.dtpExpectedGraduation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpectedGraduation.Location = new System.Drawing.Point(345, 135);
            this.dtpExpectedGraduation.Name = "dtpExpectedGraduation";
            this.dtpExpectedGraduation.Size = new System.Drawing.Size(411, 25);
            this.dtpExpectedGraduation.TabIndex = 4;
            // 
            // lblExpectedGraduation
            // 
            this.lblExpectedGraduation.AutoSize = true;
            this.lblExpectedGraduation.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblExpectedGraduation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblExpectedGraduation.Location = new System.Drawing.Point(342, 115);
            this.lblExpectedGraduation.Name = "lblExpectedGraduation";
            this.lblExpectedGraduation.Size = new System.Drawing.Size(161, 19);
            this.lblExpectedGraduation.TabIndex = 3;
            this.lblExpectedGraduation.Text = "Expected Graduation";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblStatus.Location = new System.Drawing.Point(22, 180);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 19);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status";
            // 
            // txtStipendAmount
            // 
            this.txtStipendAmount.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtStipendAmount.Location = new System.Drawing.Point(345, 200);
            this.txtStipendAmount.Name = "txtStipendAmount";
            this.txtStipendAmount.ReadOnly = true;
            this.txtStipendAmount.Size = new System.Drawing.Size(411, 25);
            this.txtStipendAmount.TabIndex = 2;
            // 
            // lblStipendAmount
            // 
            this.lblStipendAmount.AutoSize = true;
            this.lblStipendAmount.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblStipendAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblStipendAmount.Location = new System.Drawing.Point(342, 180);
            this.lblStipendAmount.Name = "lblStipendAmount";
            this.lblStipendAmount.Size = new System.Drawing.Size(120, 19);
            this.lblStipendAmount.TabIndex = 3;
            this.lblStipendAmount.Text = "Stipend Amount";
            // 
            // FrmScholarProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1920, 1061);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScholarProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Profile - ScholarAid";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelProfileHeader.ResumeLayout(false);
            this.panelProfileHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePhoto)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelPersonalInfo.ResumeLayout(false);
            this.panelPersonalInfo.PerformLayout();
            this.panelAcademicInfo.ResumeLayout(false);
            this.panelAcademicInfo.PerformLayout();
            this.panelScholarshipInfo.ResumeLayout(false);
            this.panelScholarshipInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Header
        private SATAUiFramework.SATAPanel panelHeader;
        private FrameworkTest.SATAButton btnLogout;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblScholarInfo;

        // Content
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblDate;

        // Profile Header
        private SATAUiFramework.SATAPanel panelProfileHeader;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.Label lblProfileStatus;
        private System.Windows.Forms.PictureBox picProfilePhoto;

        // Sidebar
        private System.Windows.Forms.Panel panelSidebar;
        private FrameworkTest.SATAButton btnNotifications;
        private FrameworkTest.SATAButton btnCompliance;
        private FrameworkTest.SATAButton btnPayments;
        private FrameworkTest.SATAButton btnProfile;
        private FrameworkTest.SATAButton btnDashboard;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblBrand;
        private FrameworkTest.SATAButton sataButton1;

        // Personal Information
        private SATAUiFramework.SATAPanel panelPersonalInfo;
        private System.Windows.Forms.Label lblPersonalTitle;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Label lblContactNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.TextBox txtBankAccountNumber;
        private System.Windows.Forms.Label lblBankAccountNumber;

        // Academic Information
        private SATAUiFramework.SATAPanel panelAcademicInfo;
        private System.Windows.Forms.Label lblAcademicTitle;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.Label lblYearLevel;
        private System.Windows.Forms.TextBox txtHEI;
        private System.Windows.Forms.Label lblHEI;

        // Scholarship Information
        private SATAUiFramework.SATAPanel panelScholarshipInfo;
        private System.Windows.Forms.Label lblScholarshipTitle;
        private System.Windows.Forms.TextBox txtScholarNumber;
        private System.Windows.Forms.Label lblScholarNumber;
        private System.Windows.Forms.Label lblScholarshipType;
        private System.Windows.Forms.TextBox txtScholarshipTypeValue;
        private System.Windows.Forms.DateTimePicker dtpEnrollmentDate;
        private System.Windows.Forms.Label lblEnrollmentDate;
        private System.Windows.Forms.DateTimePicker dtpExpectedGraduation;
        private System.Windows.Forms.Label lblExpectedGraduation;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatusValue;
        private System.Windows.Forms.TextBox txtStipendAmount;
        private System.Windows.Forms.Label lblStipendAmount;
        private System.Windows.Forms.TextBox txtRenewalConditions;
        private System.Windows.Forms.Label lblRenewalConditions;
        private System.Windows.Forms.TextBox txtFundSource;
        private System.Windows.Forms.Label lblFundSource;
    }
}