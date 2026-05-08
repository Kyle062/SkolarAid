using SATAUiFramework;

namespace SkolarAid.form
{
    partial class FrmActivityLogs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            SATAUiFramework.BorderRadius borderRadius6 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius7 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius8 = new SATAUiFramework.BorderRadius();
            this.panelStats1 = new SATAUiFramework.SATAPanel();
            this.lblTotalLogs = new System.Windows.Forms.Label();
            this.lblTotalLogsLabel = new System.Windows.Forms.Label();
            this.picTotalLogs = new System.Windows.Forms.PictureBox();
            this.panelStats2 = new SATAUiFramework.SATAPanel();
            this.lblTodayLogs = new System.Windows.Forms.Label();
            this.lblTodayLogsLabel = new System.Windows.Forms.Label();
            this.picTodayLogs = new System.Windows.Forms.PictureBox();
            this.panelStats3 = new SATAUiFramework.SATAPanel();
            this.lblUniqueUsers = new System.Windows.Forms.Label();
            this.lblUniqueUsersLabel = new System.Windows.Forms.Label();
            this.picUniqueUsers = new System.Windows.Forms.PictureBox();
            this.panelFilters = new SATAUiFramework.SATAPanel();
            this.cmbActionType = new System.Windows.Forms.ComboBox();
            this.lblActionType = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnExportLogs = new FrameworkTest.SATAButton();
            this.btnClearFilters = new FrameworkTest.SATAButton();
            this.btnRefresh = new FrameworkTest.SATAButton();
            this.panelDataGrid = new SATAUiFramework.SATAPanel();
            this.dgvActivityLogs = new System.Windows.Forms.DataGridView();
            this.colLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableAffected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDetailView = new SATAUiFramework.SATAPanel();
            this.lblDetailDescription = new System.Windows.Forms.Label();
            this.txtDetailDescription = new System.Windows.Forms.RichTextBox();
            this.lblDetailRecordID = new System.Windows.Forms.Label();
            this.lblDetailTable = new System.Windows.Forms.Label();
            this.lblDetailAction = new System.Windows.Forms.Label();
            this.lblDetailUser = new System.Windows.Forms.Label();
            this.lblDetailTimestamp = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.panelPagination = new SATAUiFramework.SATAPanel();
            this.btnLastPage = new FrameworkTest.SATAButton();
            this.btnNextPage = new FrameworkTest.SATAButton();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnPrevPage = new FrameworkTest.SATAButton();
            this.btnFirstPage = new FrameworkTest.SATAButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.picTotalLogs)).BeginInit();
            this.panelStats2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTodayLogs)).BeginInit();
            this.panelStats3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUniqueUsers)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.panelDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).BeginInit();
            this.panelDetailView.SuspendLayout();
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
            this.panelStats1.Controls.Add(this.lblTotalLogs);
            this.panelStats1.Controls.Add(this.lblTotalLogsLabel);
            this.panelStats1.Controls.Add(this.picTotalLogs);
            this.panelStats1.Location = new System.Drawing.Point(376, 100);
            this.panelStats1.Name = "panelStats1";
            this.panelStats1.Size = new System.Drawing.Size(255, 120);
            this.panelStats1.TabIndex = 4;
            // 
            // lblTotalLogs
            // 
            this.lblTotalLogs.AutoSize = true;
            this.lblTotalLogs.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblTotalLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblTotalLogs.Location = new System.Drawing.Point(82, 45);
            this.lblTotalLogs.Name = "lblTotalLogs";
            this.lblTotalLogs.Size = new System.Drawing.Size(42, 47);
            this.lblTotalLogs.TabIndex = 0;
            this.lblTotalLogs.Text = "0";
            // 
            // lblTotalLogsLabel
            // 
            this.lblTotalLogsLabel.AutoSize = true;
            this.lblTotalLogsLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalLogsLabel.ForeColor = System.Drawing.Color.Black;
            this.lblTotalLogsLabel.Location = new System.Drawing.Point(86, 18);
            this.lblTotalLogsLabel.Name = "lblTotalLogsLabel";
            this.lblTotalLogsLabel.Size = new System.Drawing.Size(83, 19);
            this.lblTotalLogsLabel.TabIndex = 0;
            this.lblTotalLogsLabel.Text = "Total Logs";
            // 
            // picTotalLogs
            // 
            this.picTotalLogs.Image = global::SkolarAid.Properties.Resources.file;
            this.picTotalLogs.Location = new System.Drawing.Point(23, 45);
            this.picTotalLogs.Name = "picTotalLogs";
            this.picTotalLogs.Size = new System.Drawing.Size(48, 52);
            this.picTotalLogs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTotalLogs.TabIndex = 2;
            this.picTotalLogs.TabStop = false;
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
            this.panelStats2.Controls.Add(this.lblTodayLogs);
            this.panelStats2.Controls.Add(this.lblTodayLogsLabel);
            this.panelStats2.Controls.Add(this.picTodayLogs);
            this.panelStats2.Location = new System.Drawing.Point(885, 100);
            this.panelStats2.Name = "panelStats2";
            this.panelStats2.Size = new System.Drawing.Size(255, 120);
            this.panelStats2.TabIndex = 5;
            // 
            // lblTodayLogs
            // 
            this.lblTodayLogs.AutoSize = true;
            this.lblTodayLogs.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblTodayLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblTodayLogs.Location = new System.Drawing.Point(82, 45);
            this.lblTodayLogs.Name = "lblTodayLogs";
            this.lblTodayLogs.Size = new System.Drawing.Size(42, 47);
            this.lblTodayLogs.TabIndex = 0;
            this.lblTodayLogs.Text = "0";
            // 
            // lblTodayLogsLabel
            // 
            this.lblTodayLogsLabel.AutoSize = true;
            this.lblTodayLogsLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblTodayLogsLabel.ForeColor = System.Drawing.Color.Black;
            this.lblTodayLogsLabel.Location = new System.Drawing.Point(86, 18);
            this.lblTodayLogsLabel.Name = "lblTodayLogsLabel";
            this.lblTodayLogsLabel.Size = new System.Drawing.Size(138, 19);
            this.lblTodayLogsLabel.TabIndex = 0;
            this.lblTodayLogsLabel.Text = "Today\'s Activities";
            // 
            // picTodayLogs
            // 
            this.picTodayLogs.Location = new System.Drawing.Point(23, 45);
            this.picTodayLogs.Name = "picTodayLogs";
            this.picTodayLogs.Size = new System.Drawing.Size(48, 52);
            this.picTodayLogs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTodayLogs.TabIndex = 2;
            this.picTodayLogs.TabStop = false;
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
            this.panelStats3.Controls.Add(this.lblUniqueUsers);
            this.panelStats3.Controls.Add(this.lblUniqueUsersLabel);
            this.panelStats3.Controls.Add(this.picUniqueUsers);
            this.panelStats3.Location = new System.Drawing.Point(1414, 100);
            this.panelStats3.Name = "panelStats3";
            this.panelStats3.Size = new System.Drawing.Size(255, 120);
            this.panelStats3.TabIndex = 6;
            // 
            // lblUniqueUsers
            // 
            this.lblUniqueUsers.AutoSize = true;
            this.lblUniqueUsers.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblUniqueUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblUniqueUsers.Location = new System.Drawing.Point(82, 45);
            this.lblUniqueUsers.Name = "lblUniqueUsers";
            this.lblUniqueUsers.Size = new System.Drawing.Size(42, 47);
            this.lblUniqueUsers.TabIndex = 0;
            this.lblUniqueUsers.Text = "0";
            // 
            // lblUniqueUsersLabel
            // 
            this.lblUniqueUsersLabel.AutoSize = true;
            this.lblUniqueUsersLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblUniqueUsersLabel.ForeColor = System.Drawing.Color.Black;
            this.lblUniqueUsersLabel.Location = new System.Drawing.Point(86, 18);
            this.lblUniqueUsersLabel.Name = "lblUniqueUsersLabel";
            this.lblUniqueUsersLabel.Size = new System.Drawing.Size(99, 19);
            this.lblUniqueUsersLabel.TabIndex = 0;
            this.lblUniqueUsersLabel.Text = "Active Users";
            // 
            // picUniqueUsers
            // 
            this.picUniqueUsers.Image = global::SkolarAid.Properties.Resources.user__3_;
            this.picUniqueUsers.Location = new System.Drawing.Point(23, 45);
            this.picUniqueUsers.Name = "picUniqueUsers";
            this.picUniqueUsers.Size = new System.Drawing.Size(48, 52);
            this.picUniqueUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUniqueUsers.TabIndex = 2;
            this.picUniqueUsers.TabStop = false;
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.BackColor2 = System.Drawing.Color.White;
            this.panelFilters.BorderColor = System.Drawing.Color.Black;
            borderRadius4.BottomLeft = 10;
            borderRadius4.BottomRight = 10;
            borderRadius4.TopLeft = 10;
            borderRadius4.TopRight = 10;
            this.panelFilters.BorderRadius = borderRadius4;
            this.panelFilters.BorderThickness = 0;
            this.panelFilters.Controls.Add(this.cmbActionType);
            this.panelFilters.Controls.Add(this.lblActionType);
            this.panelFilters.Controls.Add(this.cmbUser);
            this.panelFilters.Controls.Add(this.lblUser);
            this.panelFilters.Controls.Add(this.dtpDateTo);
            this.panelFilters.Controls.Add(this.lblDateTo);
            this.panelFilters.Controls.Add(this.dtpDateFrom);
            this.panelFilters.Controls.Add(this.lblDateFrom);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Controls.Add(this.btnExportLogs);
            this.panelFilters.Controls.Add(this.btnClearFilters);
            this.panelFilters.Controls.Add(this.btnRefresh);
            this.panelFilters.Location = new System.Drawing.Point(324, 226);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1356, 85);
            this.panelFilters.TabIndex = 7;
            // 
            // cmbActionType
            // 
            this.cmbActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionType.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbActionType.FormattingEnabled = true;
            this.cmbActionType.Items.AddRange(new object[] {
            "All Actions",
            "Login",
            "Logout",
            "Create",
            "Update",
            "Delete",
            "View",
            "Export",
            "Process Payroll"});
            this.cmbActionType.Location = new System.Drawing.Point(430, 35);
            this.cmbActionType.Name = "cmbActionType";
            this.cmbActionType.Size = new System.Drawing.Size(150, 28);
            this.cmbActionType.TabIndex = 3;
            // 
            // lblActionType
            // 
            this.lblActionType.AutoSize = true;
            this.lblActionType.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblActionType.Location = new System.Drawing.Point(427, 15);
            this.lblActionType.Name = "lblActionType";
            this.lblActionType.Size = new System.Drawing.Size(87, 17);
            this.lblActionType.TabIndex = 2;
            this.lblActionType.Text = "Action Type";
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Items.AddRange(new object[] {
            "All Users"});
            this.cmbUser.Location = new System.Drawing.Point(600, 35);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(150, 28);
            this.cmbUser.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(597, 15);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(36, 17);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "User";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(295, 35);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(115, 26);
            this.dtpDateTo.TabIndex = 4;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateTo.Location = new System.Drawing.Point(292, 15);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(23, 17);
            this.lblDateTo.TabIndex = 2;
            this.lblDateTo.Text = "To";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(160, 35);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(115, 26);
            this.dtpDateFrom.TabIndex = 4;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateFrom.Location = new System.Drawing.Point(157, 15);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(42, 17);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "From";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtSearch.Location = new System.Drawing.Point(23, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(117, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(20, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(54, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search";
            // 
            // btnExportLogs
            // 
            this.btnExportLogs.ButtonText = "Export Logs";
            this.btnExportLogs.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnExportLogs.CheckedForeColor = System.Drawing.Color.White;
            this.btnExportLogs.CheckedImageTint = System.Drawing.Color.White;
            this.btnExportLogs.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExportLogs.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExportLogs.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnExportLogs.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnExportLogs.HoverForeColor = System.Drawing.Color.White;
            this.btnExportLogs.HoverImage = null;
            this.btnExportLogs.HoverImageTint = System.Drawing.Color.White;
            this.btnExportLogs.HoverOutline = System.Drawing.Color.Empty;
            this.btnExportLogs.Image = global::SkolarAid.Properties.Resources.file;
            this.btnExportLogs.ImageAutoCenter = true;
            this.btnExportLogs.ImageExpand = new System.Drawing.Point(8, 8);
            this.btnExportLogs.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnExportLogs.ImageTint = System.Drawing.Color.White;
            this.btnExportLogs.IsToggleButton = false;
            this.btnExportLogs.IsToggled = false;
            this.btnExportLogs.Location = new System.Drawing.Point(1170, 28);
            this.btnExportLogs.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnExportLogs.Name = "btnExportLogs";
            this.btnExportLogs.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportLogs.NormalForeColor = System.Drawing.Color.White;
            this.btnExportLogs.NormalOutline = System.Drawing.Color.Empty;
            this.btnExportLogs.OutlineThickness = 2F;
            this.btnExportLogs.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnExportLogs.PressedForeColor = System.Drawing.Color.White;
            this.btnExportLogs.PressedImageTint = System.Drawing.Color.White;
            this.btnExportLogs.PressedOutline = System.Drawing.Color.Empty;
            this.btnExportLogs.Rounding = new System.Windows.Forms.Padding(5);
            this.btnExportLogs.Size = new System.Drawing.Size(154, 35);
            this.btnExportLogs.TabIndex = 5;
            this.btnExportLogs.TextAutoCenter = true;
            this.btnExportLogs.TextOffset = new System.Drawing.Point(-5, 0);
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
            this.btnClearFilters.Location = new System.Drawing.Point(1090, 28);
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
            this.btnClearFilters.Size = new System.Drawing.Size(55, 35);
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
            this.btnRefresh.Location = new System.Drawing.Point(968, 28);
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
            this.btnRefresh.Size = new System.Drawing.Size(105, 35);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.TextAutoCenter = true;
            this.btnRefresh.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.BackColor = System.Drawing.Color.White;
            this.panelDataGrid.BackColor2 = System.Drawing.Color.White;
            this.panelDataGrid.BorderColor = System.Drawing.Color.Black;
            borderRadius5.BottomLeft = 10;
            borderRadius5.BottomRight = 10;
            borderRadius5.TopLeft = 10;
            borderRadius5.TopRight = 10;
            this.panelDataGrid.BorderRadius = borderRadius5;
            this.panelDataGrid.BorderThickness = 0;
            this.panelDataGrid.Controls.Add(this.dgvActivityLogs);
            this.panelDataGrid.Location = new System.Drawing.Point(324, 337);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(993, 571);
            this.panelDataGrid.TabIndex = 8;
            // 
            // dgvActivityLogs
            // 
            this.dgvActivityLogs.AllowUserToAddRows = false;
            this.dgvActivityLogs.AllowUserToDeleteRows = false;
            this.dgvActivityLogs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvActivityLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActivityLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActivityLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvActivityLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActivityLogs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActivityLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvActivityLogs.ColumnHeadersHeight = 40;
            this.dgvActivityLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLogID,
            this.colTimestamp,
            this.colUser,
            this.colRole,
            this.colActionType,
            this.colTableAffected,
            this.colDetails,
            this.colIPAddress});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActivityLogs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvActivityLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivityLogs.EnableHeadersVisualStyles = false;
            this.dgvActivityLogs.GridColor = System.Drawing.Color.LightGray;
            this.dgvActivityLogs.Location = new System.Drawing.Point(0, 0);
            this.dgvActivityLogs.MultiSelect = false;
            this.dgvActivityLogs.Name = "dgvActivityLogs";
            this.dgvActivityLogs.ReadOnly = true;
            this.dgvActivityLogs.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvActivityLogs.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvActivityLogs.RowTemplate.Height = 35;
            this.dgvActivityLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActivityLogs.Size = new System.Drawing.Size(993, 571);
            this.dgvActivityLogs.TabIndex = 0;
            // 
            // colLogID
            // 
            this.colLogID.FillWeight = 40F;
            this.colLogID.HeaderText = "ID";
            this.colLogID.Name = "colLogID";
            this.colLogID.ReadOnly = true;
            // 
            // colTimestamp
            // 
            this.colTimestamp.FillWeight = 90F;
            this.colTimestamp.HeaderText = "Timestamp";
            this.colTimestamp.Name = "colTimestamp";
            this.colTimestamp.ReadOnly = true;
            // 
            // colUser
            // 
            this.colUser.HeaderText = "User";
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // colRole
            // 
            this.colRole.FillWeight = 60F;
            this.colRole.HeaderText = "Role";
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            // 
            // colActionType
            // 
            this.colActionType.HeaderText = "Action";
            this.colActionType.Name = "colActionType";
            this.colActionType.ReadOnly = true;
            // 
            // colTableAffected
            // 
            this.colTableAffected.HeaderText = "Table";
            this.colTableAffected.Name = "colTableAffected";
            this.colTableAffected.ReadOnly = true;
            // 
            // colDetails
            // 
            this.colDetails.FillWeight = 150F;
            this.colDetails.HeaderText = "Details";
            this.colDetails.Name = "colDetails";
            this.colDetails.ReadOnly = true;
            // 
            // colIPAddress
            // 
            this.colIPAddress.FillWeight = 80F;
            this.colIPAddress.HeaderText = "IP Address";
            this.colIPAddress.Name = "colIPAddress";
            this.colIPAddress.ReadOnly = true;
            // 
            // panelDetailView
            // 
            this.panelDetailView.BackColor = System.Drawing.Color.White;
            this.panelDetailView.BackColor2 = System.Drawing.Color.White;
            this.panelDetailView.BorderColor = System.Drawing.Color.Black;
            borderRadius6.BottomLeft = 10;
            borderRadius6.BottomRight = 10;
            borderRadius6.TopLeft = 10;
            borderRadius6.TopRight = 10;
            this.panelDetailView.BorderRadius = borderRadius6;
            this.panelDetailView.BorderThickness = 0;
            this.panelDetailView.Controls.Add(this.lblDetailDescription);
            this.panelDetailView.Controls.Add(this.txtDetailDescription);
            this.panelDetailView.Controls.Add(this.lblDetailRecordID);
            this.panelDetailView.Controls.Add(this.lblDetailTable);
            this.panelDetailView.Controls.Add(this.lblDetailAction);
            this.panelDetailView.Controls.Add(this.lblDetailUser);
            this.panelDetailView.Controls.Add(this.lblDetailTimestamp);
            this.panelDetailView.Controls.Add(this.lblDetailTitle);
            this.panelDetailView.Location = new System.Drawing.Point(1340, 337);
            this.panelDetailView.Name = "panelDetailView";
            this.panelDetailView.Size = new System.Drawing.Size(337, 571);
            this.panelDetailView.TabIndex = 9;
            // 
            // lblDetailDescription
            // 
            this.lblDetailDescription.AutoSize = true;
            this.lblDetailDescription.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetailDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDetailDescription.Location = new System.Drawing.Point(21, 212);
            this.lblDetailDescription.Name = "lblDetailDescription";
            this.lblDetailDescription.Size = new System.Drawing.Size(95, 18);
            this.lblDetailDescription.TabIndex = 0;
            this.lblDetailDescription.Text = "Description:";
            // 
            // txtDetailDescription
            // 
            this.txtDetailDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDetailDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetailDescription.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtDetailDescription.Location = new System.Drawing.Point(25, 235);
            this.txtDetailDescription.Name = "txtDetailDescription";
            this.txtDetailDescription.ReadOnly = true;
            this.txtDetailDescription.Size = new System.Drawing.Size(290, 281);
            this.txtDetailDescription.TabIndex = 2;
            this.txtDetailDescription.Text = "";
            // 
            // lblDetailRecordID
            // 
            this.lblDetailRecordID.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblDetailRecordID.ForeColor = System.Drawing.Color.Black;
            this.lblDetailRecordID.Location = new System.Drawing.Point(21, 180);
            this.lblDetailRecordID.Name = "lblDetailRecordID";
            this.lblDetailRecordID.Size = new System.Drawing.Size(295, 25);
            this.lblDetailRecordID.TabIndex = 1;
            this.lblDetailRecordID.Text = "Record ID: -";
            // 
            // lblDetailTable
            // 
            this.lblDetailTable.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblDetailTable.ForeColor = System.Drawing.Color.Black;
            this.lblDetailTable.Location = new System.Drawing.Point(21, 150);
            this.lblDetailTable.Name = "lblDetailTable";
            this.lblDetailTable.Size = new System.Drawing.Size(295, 25);
            this.lblDetailTable.TabIndex = 1;
            this.lblDetailTable.Text = "Table Affected: -";
            // 
            // lblDetailAction
            // 
            this.lblDetailAction.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblDetailAction.ForeColor = System.Drawing.Color.Black;
            this.lblDetailAction.Location = new System.Drawing.Point(21, 120);
            this.lblDetailAction.Name = "lblDetailAction";
            this.lblDetailAction.Size = new System.Drawing.Size(295, 25);
            this.lblDetailAction.TabIndex = 1;
            this.lblDetailAction.Text = "Action: -";
            // 
            // lblDetailUser
            // 
            this.lblDetailUser.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblDetailUser.ForeColor = System.Drawing.Color.Black;
            this.lblDetailUser.Location = new System.Drawing.Point(21, 90);
            this.lblDetailUser.Name = "lblDetailUser";
            this.lblDetailUser.Size = new System.Drawing.Size(295, 25);
            this.lblDetailUser.TabIndex = 1;
            this.lblDetailUser.Text = "User: -";
            // 
            // lblDetailTimestamp
            // 
            this.lblDetailTimestamp.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblDetailTimestamp.ForeColor = System.Drawing.Color.Black;
            this.lblDetailTimestamp.Location = new System.Drawing.Point(21, 60);
            this.lblDetailTimestamp.Name = "lblDetailTimestamp";
            this.lblDetailTimestamp.Size = new System.Drawing.Size(295, 25);
            this.lblDetailTimestamp.TabIndex = 1;
            this.lblDetailTimestamp.Text = "Timestamp: -";
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(20, 20);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(159, 23);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "Log Entry Details";
            // 
            // panelPagination
            // 
            this.panelPagination.BackColor = System.Drawing.Color.White;
            this.panelPagination.BackColor2 = System.Drawing.Color.White;
            this.panelPagination.BorderColor = System.Drawing.Color.Black;
            borderRadius7.BottomLeft = 10;
            borderRadius7.BottomRight = 10;
            borderRadius7.TopLeft = 10;
            borderRadius7.TopRight = 10;
            this.panelPagination.BorderRadius = borderRadius7;
            this.panelPagination.BorderThickness = 0;
            this.panelPagination.Location = new System.Drawing.Point(327, 906);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(1142, 23);
            this.panelPagination.TabIndex = 10;
            this.panelPagination.Visible = false;
            // 
            // btnLastPage
            // 
            this.btnLastPage.ButtonText = ">>";
            this.btnLastPage.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnLastPage.CheckedForeColor = System.Drawing.Color.White;
            this.btnLastPage.CheckedImageTint = System.Drawing.Color.White;
            this.btnLastPage.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnLastPage.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLastPage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnLastPage.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnLastPage.HoverForeColor = System.Drawing.Color.White;
            this.btnLastPage.HoverImage = null;
            this.btnLastPage.HoverImageTint = System.Drawing.Color.White;
            this.btnLastPage.HoverOutline = System.Drawing.Color.Empty;
            this.btnLastPage.Image = null;
            this.btnLastPage.ImageAutoCenter = true;
            this.btnLastPage.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnLastPage.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnLastPage.ImageTint = System.Drawing.Color.White;
            this.btnLastPage.IsToggleButton = false;
            this.btnLastPage.IsToggled = false;
            this.btnLastPage.Location = new System.Drawing.Point(1380, 1031);
            this.btnLastPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnLastPage.NormalForeColor = System.Drawing.Color.White;
            this.btnLastPage.NormalOutline = System.Drawing.Color.Empty;
            this.btnLastPage.OutlineThickness = 2F;
            this.btnLastPage.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnLastPage.PressedForeColor = System.Drawing.Color.White;
            this.btnLastPage.PressedImageTint = System.Drawing.Color.White;
            this.btnLastPage.PressedOutline = System.Drawing.Color.Empty;
            this.btnLastPage.Rounding = new System.Windows.Forms.Padding(3);
            this.btnLastPage.Size = new System.Drawing.Size(40, 21);
            this.btnLastPage.TabIndex = 4;
            this.btnLastPage.TextAutoCenter = true;
            this.btnLastPage.TextOffset = new System.Drawing.Point(0, 0);
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click_1);
            // 
            // btnNextPage
            // 
            this.btnNextPage.ButtonText = ">";
            this.btnNextPage.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnNextPage.CheckedForeColor = System.Drawing.Color.White;
            this.btnNextPage.CheckedImageTint = System.Drawing.Color.White;
            this.btnNextPage.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnNextPage.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNextPage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnNextPage.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnNextPage.HoverForeColor = System.Drawing.Color.White;
            this.btnNextPage.HoverImage = null;
            this.btnNextPage.HoverImageTint = System.Drawing.Color.White;
            this.btnNextPage.HoverOutline = System.Drawing.Color.Empty;
            this.btnNextPage.Image = null;
            this.btnNextPage.ImageAutoCenter = true;
            this.btnNextPage.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnNextPage.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnNextPage.ImageTint = System.Drawing.Color.White;
            this.btnNextPage.IsToggleButton = false;
            this.btnNextPage.IsToggled = false;
            this.btnNextPage.Location = new System.Drawing.Point(1330, 1031);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnNextPage.NormalForeColor = System.Drawing.Color.White;
            this.btnNextPage.NormalOutline = System.Drawing.Color.Empty;
            this.btnNextPage.OutlineThickness = 2F;
            this.btnNextPage.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnNextPage.PressedForeColor = System.Drawing.Color.White;
            this.btnNextPage.PressedImageTint = System.Drawing.Color.White;
            this.btnNextPage.PressedOutline = System.Drawing.Color.Empty;
            this.btnNextPage.Rounding = new System.Windows.Forms.Padding(3);
            this.btnNextPage.Size = new System.Drawing.Size(40, 21);
            this.btnNextPage.TabIndex = 3;
            this.btnNextPage.TextAutoCenter = true;
            this.btnNextPage.TextOffset = new System.Drawing.Point(0, 0);
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click_1);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblPageInfo.ForeColor = System.Drawing.Color.Black;
            this.lblPageInfo.Location = new System.Drawing.Point(749, 1031);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(94, 19);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "Page 1 of 10";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPageInfo.Click += new System.EventHandler(this.lblPageInfo_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.ButtonText = "<";
            this.btnPrevPage.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnPrevPage.CheckedForeColor = System.Drawing.Color.White;
            this.btnPrevPage.CheckedImageTint = System.Drawing.Color.White;
            this.btnPrevPage.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnPrevPage.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrevPage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrevPage.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnPrevPage.HoverForeColor = System.Drawing.Color.White;
            this.btnPrevPage.HoverImage = null;
            this.btnPrevPage.HoverImageTint = System.Drawing.Color.White;
            this.btnPrevPage.HoverOutline = System.Drawing.Color.Empty;
            this.btnPrevPage.Image = null;
            this.btnPrevPage.ImageAutoCenter = true;
            this.btnPrevPage.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnPrevPage.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnPrevPage.ImageTint = System.Drawing.Color.White;
            this.btnPrevPage.IsToggleButton = false;
            this.btnPrevPage.IsToggled = false;
            this.btnPrevPage.Location = new System.Drawing.Point(361, 1031);
            this.btnPrevPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnPrevPage.NormalForeColor = System.Drawing.Color.White;
            this.btnPrevPage.NormalOutline = System.Drawing.Color.Empty;
            this.btnPrevPage.OutlineThickness = 2F;
            this.btnPrevPage.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnPrevPage.PressedForeColor = System.Drawing.Color.White;
            this.btnPrevPage.PressedImageTint = System.Drawing.Color.White;
            this.btnPrevPage.PressedOutline = System.Drawing.Color.Empty;
            this.btnPrevPage.Rounding = new System.Windows.Forms.Padding(3);
            this.btnPrevPage.Size = new System.Drawing.Size(40, 21);
            this.btnPrevPage.TabIndex = 1;
            this.btnPrevPage.TextAutoCenter = true;
            this.btnPrevPage.TextOffset = new System.Drawing.Point(0, 0);
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click_1);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.ButtonText = "<<";
            this.btnFirstPage.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnFirstPage.CheckedForeColor = System.Drawing.Color.White;
            this.btnFirstPage.CheckedImageTint = System.Drawing.Color.White;
            this.btnFirstPage.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnFirstPage.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFirstPage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnFirstPage.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnFirstPage.HoverForeColor = System.Drawing.Color.White;
            this.btnFirstPage.HoverImage = null;
            this.btnFirstPage.HoverImageTint = System.Drawing.Color.White;
            this.btnFirstPage.HoverOutline = System.Drawing.Color.Empty;
            this.btnFirstPage.Image = null;
            this.btnFirstPage.ImageAutoCenter = true;
            this.btnFirstPage.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnFirstPage.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnFirstPage.ImageTint = System.Drawing.Color.White;
            this.btnFirstPage.IsToggleButton = false;
            this.btnFirstPage.IsToggled = false;
            this.btnFirstPage.Location = new System.Drawing.Point(311, 1031);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnFirstPage.NormalForeColor = System.Drawing.Color.White;
            this.btnFirstPage.NormalOutline = System.Drawing.Color.Empty;
            this.btnFirstPage.OutlineThickness = 2F;
            this.btnFirstPage.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnFirstPage.PressedForeColor = System.Drawing.Color.White;
            this.btnFirstPage.PressedImageTint = System.Drawing.Color.White;
            this.btnFirstPage.PressedOutline = System.Drawing.Color.Empty;
            this.btnFirstPage.Rounding = new System.Windows.Forms.Padding(3);
            this.btnFirstPage.Size = new System.Drawing.Size(40, 21);
            this.btnFirstPage.TabIndex = 0;
            this.btnFirstPage.TextAutoCenter = true;
            this.btnFirstPage.TextOffset = new System.Drawing.Point(0, 0);
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click_1);
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
            this.panelSidebar.Size = new System.Drawing.Size(280, 981);
            this.panelSidebar.TabIndex = 11;
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
            this.btnReminder.Click += new System.EventHandler(this.btnReminder_Click);
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
            this.btnActivityLog.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
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
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
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
            this.btnPayroll.Click += new System.EventHandler(this.btnPayroll_Click);
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
            this.btnScholarMgmt.Click += new System.EventHandler(this.btnScholarMgmt_Click);
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
            this.btnDashboard.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
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
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.panelHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.panelHeader.BorderColor = System.Drawing.Color.Black;
            borderRadius8.BottomLeft = 1;
            borderRadius8.BottomRight = 1;
            borderRadius8.TopLeft = 1;
            borderRadius8.TopRight = 1;
            this.panelHeader.BorderRadius = borderRadius8;
            this.panelHeader.BorderThickness = 0;
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblBrand);
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Controls.Add(this.picUser);
            this.panelHeader.Controls.Add(this.lblRole);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1920, 80);
            this.panelHeader.TabIndex = 12;
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
            this.lblBrand.Size = new System.Drawing.Size(194, 26);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "IskolarAid Admin";
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
            this.btnLogout.Location = new System.Drawing.Point(1769, 20);
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
            // picUser
            // 
            this.picUser.Image = global::SkolarAid.Properties.Resources.user__3_;
            this.picUser.Location = new System.Drawing.Point(1600, 25);
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
            this.lblRole.Location = new System.Drawing.Point(1642, 33);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(111, 19);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Administrator";
            // 
            // FrmActivityLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1920, 1061);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.panelDetailView);
            this.Controls.Add(this.panelDataGrid);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelStats3);
            this.Controls.Add(this.panelStats2);
            this.Controls.Add(this.panelStats1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmActivityLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activity Logs - ScholarAid";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmActivityLogs_Load_1);
            this.panelStats1.ResumeLayout(false);
            this.panelStats1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalLogs)).EndInit();
            this.panelStats2.ResumeLayout(false);
            this.panelStats2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTodayLogs)).EndInit();
            this.panelStats3.ResumeLayout(false);
            this.panelStats3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUniqueUsers)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).EndInit();
            this.panelDetailView.ResumeLayout(false);
            this.panelDetailView.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Stats Cards
        private SATAUiFramework.SATAPanel panelStats1;
        private System.Windows.Forms.Label lblTotalLogs;
        private System.Windows.Forms.Label lblTotalLogsLabel;
        private System.Windows.Forms.PictureBox picTotalLogs;
        private SATAUiFramework.SATAPanel panelStats2;
        private System.Windows.Forms.Label lblTodayLogs;
        private System.Windows.Forms.Label lblTodayLogsLabel;
        private System.Windows.Forms.PictureBox picTodayLogs;
        private SATAUiFramework.SATAPanel panelStats3;
        private System.Windows.Forms.Label lblUniqueUsers;
        private System.Windows.Forms.Label lblUniqueUsersLabel;
        private System.Windows.Forms.PictureBox picUniqueUsers;

        // Filters Panel
        private SATAUiFramework.SATAPanel panelFilters;
        private System.Windows.Forms.ComboBox cmbActionType;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private FrameworkTest.SATAButton btnExportLogs;
        private FrameworkTest.SATAButton btnClearFilters;
        private FrameworkTest.SATAButton btnRefresh;

        // Data Grid
        private SATAUiFramework.SATAPanel panelDataGrid;
        private System.Windows.Forms.DataGridView dgvActivityLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableAffected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIPAddress;

        // Detail View Panel
        private SATAUiFramework.SATAPanel panelDetailView;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblDetailTimestamp;
        private System.Windows.Forms.Label lblDetailUser;
        private System.Windows.Forms.Label lblDetailAction;
        private System.Windows.Forms.Label lblDetailTable;
        private System.Windows.Forms.Label lblDetailRecordID;
        private System.Windows.Forms.RichTextBox txtDetailDescription;
        private System.Windows.Forms.Label lblDetailDescription;

        // Pagination
        private SATAUiFramework.SATAPanel panelPagination;
        private FrameworkTest.SATAButton btnLastPage;
        private FrameworkTest.SATAButton btnNextPage;
        private System.Windows.Forms.Label lblPageInfo;
        private FrameworkTest.SATAButton btnPrevPage;
        private FrameworkTest.SATAButton btnFirstPage;
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
    }
}