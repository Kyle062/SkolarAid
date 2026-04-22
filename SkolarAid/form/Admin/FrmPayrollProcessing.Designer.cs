namespace SkolarAid
{
    partial class FrmPayrollProcessing
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
            this.panelStats1 = new SATAUiFramework.SATAPanel();
            this.lblEligibleCount = new System.Windows.Forms.Label();
            this.lblEligibleLabel = new System.Windows.Forms.Label();
            this.picEligible = new System.Windows.Forms.PictureBox();
            this.panelStats2 = new SATAUiFramework.SATAPanel();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.lblSelectedLabel = new System.Windows.Forms.Label();
            this.picSelected = new System.Windows.Forms.PictureBox();
            this.panelStats3 = new SATAUiFramework.SATAPanel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmountLabel = new System.Windows.Forms.Label();
            this.picTotalAmount = new System.Windows.Forms.PictureBox();
            this.panelStats4 = new SATAUiFramework.SATAPanel();
            this.lblProcessedToday = new System.Windows.Forms.Label();
            this.lblProcessedLabel = new System.Windows.Forms.Label();
            this.picProcessed = new System.Windows.Forms.PictureBox();
            this.panelFilters = new SATAUiFramework.SATAPanel();
            this.cmbScholarshipType = new System.Windows.Forms.ComboBox();
            this.lblScholarshipType = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.lblYearLevel = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSelectAll = new FrameworkTest.SATAButton();
            this.btnClearSelection = new FrameworkTest.SATAButton();
            this.panelBatchControls = new SATAUiFramework.SATAPanel();
            this.dtpPaymentPeriod = new System.Windows.Forms.DateTimePicker();
            this.lblPaymentPeriod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.btnProcessPayroll = new FrameworkTest.SATAButton();
            this.btnPreviewPayroll = new FrameworkTest.SATAButton();
            this.panelDataGrid = new SATAUiFramework.SATAPanel();
            this.dgvScholars = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colScholarNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYearLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScholarshipType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStipendAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComplianceStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEligible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelSummary = new SATAUiFramework.SATAPanel();
            this.lblSummaryMethod = new System.Windows.Forms.Label();
            this.lblSummaryAmount = new System.Windows.Forms.Label();
            this.lblSummaryScholars = new System.Windows.Forms.Label();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.picEligible)).BeginInit();
            this.panelStats2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelected)).BeginInit();
            this.panelStats3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalAmount)).BeginInit();
            this.panelStats4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessed)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.panelBatchControls.SuspendLayout();
            this.panelDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScholars)).BeginInit();
            this.panelSummary.SuspendLayout();
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
            this.panelStats1.Controls.Add(this.lblEligibleCount);
            this.panelStats1.Controls.Add(this.lblEligibleLabel);
            this.panelStats1.Controls.Add(this.picEligible);
            this.panelStats1.Location = new System.Drawing.Point(321, 100);
            this.panelStats1.Name = "panelStats1";
            this.panelStats1.Size = new System.Drawing.Size(255, 120);
            this.panelStats1.TabIndex = 4;
            // 
            // lblEligibleCount
            // 
            this.lblEligibleCount.AutoSize = true;
            this.lblEligibleCount.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblEligibleCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblEligibleCount.Location = new System.Drawing.Point(82, 45);
            this.lblEligibleCount.Name = "lblEligibleCount";
            this.lblEligibleCount.Size = new System.Drawing.Size(42, 47);
            this.lblEligibleCount.TabIndex = 0;
            this.lblEligibleCount.Text = "0";
            // 
            // lblEligibleLabel
            // 
            this.lblEligibleLabel.AutoSize = true;
            this.lblEligibleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblEligibleLabel.ForeColor = System.Drawing.Color.Black;
            this.lblEligibleLabel.Location = new System.Drawing.Point(86, 18);
            this.lblEligibleLabel.Name = "lblEligibleLabel";
            this.lblEligibleLabel.Size = new System.Drawing.Size(133, 19);
            this.lblEligibleLabel.TabIndex = 0;
            this.lblEligibleLabel.Text = "Eligible Scholars";
            // 
            // picEligible
            // 
            this.picEligible.Location = new System.Drawing.Point(23, 45);
            this.picEligible.Name = "picEligible";
            this.picEligible.Size = new System.Drawing.Size(48, 52);
            this.picEligible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEligible.TabIndex = 2;
            this.picEligible.TabStop = false;
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
            this.panelStats2.Controls.Add(this.lblSelectedCount);
            this.panelStats2.Controls.Add(this.lblSelectedLabel);
            this.panelStats2.Controls.Add(this.picSelected);
            this.panelStats2.Location = new System.Drawing.Point(677, 100);
            this.panelStats2.Name = "panelStats2";
            this.panelStats2.Size = new System.Drawing.Size(255, 120);
            this.panelStats2.TabIndex = 5;
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblSelectedCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblSelectedCount.Location = new System.Drawing.Point(82, 45);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(42, 47);
            this.lblSelectedCount.TabIndex = 0;
            this.lblSelectedCount.Text = "0";
            // 
            // lblSelectedLabel
            // 
            this.lblSelectedLabel.AutoSize = true;
            this.lblSelectedLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblSelectedLabel.ForeColor = System.Drawing.Color.Black;
            this.lblSelectedLabel.Location = new System.Drawing.Point(86, 18);
            this.lblSelectedLabel.Name = "lblSelectedLabel";
            this.lblSelectedLabel.Size = new System.Drawing.Size(101, 19);
            this.lblSelectedLabel.TabIndex = 0;
            this.lblSelectedLabel.Text = "Selected (0)";
            // 
            // picSelected
            // 
            this.picSelected.Location = new System.Drawing.Point(23, 45);
            this.picSelected.Name = "picSelected";
            this.picSelected.Size = new System.Drawing.Size(48, 52);
            this.picSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSelected.TabIndex = 2;
            this.picSelected.TabStop = false;
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
            this.panelStats3.Controls.Add(this.lblTotalAmount);
            this.panelStats3.Controls.Add(this.lblTotalAmountLabel);
            this.panelStats3.Controls.Add(this.picTotalAmount);
            this.panelStats3.Location = new System.Drawing.Point(1057, 100);
            this.panelStats3.Name = "panelStats3";
            this.panelStats3.Size = new System.Drawing.Size(255, 120);
            this.panelStats3.TabIndex = 6;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(82, 45);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(55, 38);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "₱0";
            // 
            // lblTotalAmountLabel
            // 
            this.lblTotalAmountLabel.AutoSize = true;
            this.lblTotalAmountLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmountLabel.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmountLabel.Location = new System.Drawing.Point(86, 18);
            this.lblTotalAmountLabel.Name = "lblTotalAmountLabel";
            this.lblTotalAmountLabel.Size = new System.Drawing.Size(111, 19);
            this.lblTotalAmountLabel.TabIndex = 0;
            this.lblTotalAmountLabel.Text = "Total Amount";
            // 
            // picTotalAmount
            // 
            this.picTotalAmount.Location = new System.Drawing.Point(23, 45);
            this.picTotalAmount.Name = "picTotalAmount";
            this.picTotalAmount.Size = new System.Drawing.Size(48, 52);
            this.picTotalAmount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTotalAmount.TabIndex = 2;
            this.picTotalAmount.TabStop = false;
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
            this.panelStats4.Controls.Add(this.lblProcessedToday);
            this.panelStats4.Controls.Add(this.lblProcessedLabel);
            this.panelStats4.Controls.Add(this.picProcessed);
            this.panelStats4.Location = new System.Drawing.Point(1422, 100);
            this.panelStats4.Name = "panelStats4";
            this.panelStats4.Size = new System.Drawing.Size(255, 120);
            this.panelStats4.TabIndex = 7;
            // 
            // lblProcessedToday
            // 
            this.lblProcessedToday.AutoSize = true;
            this.lblProcessedToday.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.lblProcessedToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblProcessedToday.Location = new System.Drawing.Point(82, 45);
            this.lblProcessedToday.Name = "lblProcessedToday";
            this.lblProcessedToday.Size = new System.Drawing.Size(42, 47);
            this.lblProcessedToday.TabIndex = 0;
            this.lblProcessedToday.Text = "0";
            // 
            // lblProcessedLabel
            // 
            this.lblProcessedLabel.AutoSize = true;
            this.lblProcessedLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblProcessedLabel.ForeColor = System.Drawing.Color.Black;
            this.lblProcessedLabel.Location = new System.Drawing.Point(86, 18);
            this.lblProcessedLabel.Name = "lblProcessedLabel";
            this.lblProcessedLabel.Size = new System.Drawing.Size(138, 19);
            this.lblProcessedLabel.TabIndex = 0;
            this.lblProcessedLabel.Text = "Processed Today";
            // 
            // picProcessed
            // 
            this.picProcessed.Location = new System.Drawing.Point(23, 45);
            this.picProcessed.Name = "picProcessed";
            this.picProcessed.Size = new System.Drawing.Size(48, 52);
            this.picProcessed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProcessed.TabIndex = 2;
            this.picProcessed.TabStop = false;
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
            this.panelFilters.Controls.Add(this.cmbScholarshipType);
            this.panelFilters.Controls.Add(this.lblScholarshipType);
            this.panelFilters.Controls.Add(this.cmbYearLevel);
            this.panelFilters.Controls.Add(this.lblYearLevel);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Controls.Add(this.btnSelectAll);
            this.panelFilters.Controls.Add(this.btnClearSelection);
            this.panelFilters.Location = new System.Drawing.Point(321, 240);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1356, 80);
            this.panelFilters.TabIndex = 8;
            // 
            // cmbScholarshipType
            // 
            this.cmbScholarshipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScholarshipType.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbScholarshipType.FormattingEnabled = true;
            this.cmbScholarshipType.Items.AddRange(new object[] {
            "All Scholarship Types",
            "Academic Scholarship",
            "Athletic Scholarship",
            "Financial Aid Grant"});
            this.cmbScholarshipType.Location = new System.Drawing.Point(541, 35);
            this.cmbScholarshipType.Name = "cmbScholarshipType";
            this.cmbScholarshipType.Size = new System.Drawing.Size(180, 28);
            this.cmbScholarshipType.TabIndex = 3;
            // 
            // lblScholarshipType
            // 
            this.lblScholarshipType.AutoSize = true;
            this.lblScholarshipType.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblScholarshipType.Location = new System.Drawing.Point(538, 15);
            this.lblScholarshipType.Name = "lblScholarshipType";
            this.lblScholarshipType.Size = new System.Drawing.Size(120, 17);
            this.lblScholarshipType.TabIndex = 2;
            this.lblScholarshipType.Text = "Scholarship Type";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearLevel.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Items.AddRange(new object[] {
            "All Year Levels",
            "1st Year",
            "2nd Year",
            "3rd Year",
            "4th Year"});
            this.cmbYearLevel.Location = new System.Drawing.Point(741, 35);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(130, 28);
            this.cmbYearLevel.TabIndex = 3;
            // 
            // lblYearLevel
            // 
            this.lblYearLevel.AutoSize = true;
            this.lblYearLevel.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblYearLevel.Location = new System.Drawing.Point(738, 15);
            this.lblYearLevel.Name = "lblYearLevel";
            this.lblYearLevel.Size = new System.Drawing.Size(77, 17);
            this.lblYearLevel.TabIndex = 2;
            this.lblYearLevel.Text = "Year Level";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtSearch.Location = new System.Drawing.Point(23, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(500, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(20, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(140, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search by Name/ID";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.ButtonText = "Select All Eligible";
            this.btnSelectAll.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnSelectAll.CheckedForeColor = System.Drawing.Color.White;
            this.btnSelectAll.CheckedImageTint = System.Drawing.Color.White;
            this.btnSelectAll.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSelectAll.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSelectAll.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnSelectAll.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnSelectAll.HoverForeColor = System.Drawing.Color.White;
            this.btnSelectAll.HoverImage = null;
            this.btnSelectAll.HoverImageTint = System.Drawing.Color.White;
            this.btnSelectAll.HoverOutline = System.Drawing.Color.Empty;
            this.btnSelectAll.Image = null;
            this.btnSelectAll.ImageAutoCenter = true;
            this.btnSelectAll.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSelectAll.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSelectAll.ImageTint = System.Drawing.Color.White;
            this.btnSelectAll.IsToggleButton = false;
            this.btnSelectAll.IsToggled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(992, 23);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnSelectAll.NormalForeColor = System.Drawing.Color.White;
            this.btnSelectAll.NormalOutline = System.Drawing.Color.Empty;
            this.btnSelectAll.OutlineThickness = 2F;
            this.btnSelectAll.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnSelectAll.PressedForeColor = System.Drawing.Color.White;
            this.btnSelectAll.PressedImageTint = System.Drawing.Color.White;
            this.btnSelectAll.PressedOutline = System.Drawing.Color.Empty;
            this.btnSelectAll.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSelectAll.Size = new System.Drawing.Size(158, 35);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.TextAutoCenter = true;
            this.btnSelectAll.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.ButtonText = "Clear Selection";
            this.btnClearSelection.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnClearSelection.CheckedForeColor = System.Drawing.Color.White;
            this.btnClearSelection.CheckedImageTint = System.Drawing.Color.White;
            this.btnClearSelection.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnClearSelection.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClearSelection.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnClearSelection.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClearSelection.HoverForeColor = System.Drawing.Color.White;
            this.btnClearSelection.HoverImage = null;
            this.btnClearSelection.HoverImageTint = System.Drawing.Color.White;
            this.btnClearSelection.HoverOutline = System.Drawing.Color.Empty;
            this.btnClearSelection.Image = null;
            this.btnClearSelection.ImageAutoCenter = true;
            this.btnClearSelection.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnClearSelection.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnClearSelection.ImageTint = System.Drawing.Color.White;
            this.btnClearSelection.IsToggleButton = false;
            this.btnClearSelection.IsToggled = false;
            this.btnClearSelection.Location = new System.Drawing.Point(1174, 23);
            this.btnClearSelection.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.NormalBackground = System.Drawing.Color.Gray;
            this.btnClearSelection.NormalForeColor = System.Drawing.Color.White;
            this.btnClearSelection.NormalOutline = System.Drawing.Color.Empty;
            this.btnClearSelection.OutlineThickness = 2F;
            this.btnClearSelection.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnClearSelection.PressedForeColor = System.Drawing.Color.White;
            this.btnClearSelection.PressedImageTint = System.Drawing.Color.White;
            this.btnClearSelection.PressedOutline = System.Drawing.Color.Empty;
            this.btnClearSelection.Rounding = new System.Windows.Forms.Padding(5);
            this.btnClearSelection.Size = new System.Drawing.Size(133, 35);
            this.btnClearSelection.TabIndex = 5;
            this.btnClearSelection.TextAutoCenter = true;
            this.btnClearSelection.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // panelBatchControls
            // 
            this.panelBatchControls.BackColor = System.Drawing.Color.White;
            this.panelBatchControls.BackColor2 = System.Drawing.Color.White;
            this.panelBatchControls.BorderColor = System.Drawing.Color.Black;
            borderRadius6.BottomLeft = 10;
            borderRadius6.BottomRight = 10;
            borderRadius6.TopLeft = 10;
            borderRadius6.TopRight = 10;
            this.panelBatchControls.BorderRadius = borderRadius6;
            this.panelBatchControls.BorderThickness = 0;
            this.panelBatchControls.Controls.Add(this.dtpPaymentPeriod);
            this.panelBatchControls.Controls.Add(this.lblPaymentPeriod);
            this.panelBatchControls.Controls.Add(this.cmbPaymentMethod);
            this.panelBatchControls.Controls.Add(this.lblPaymentMethod);
            this.panelBatchControls.Controls.Add(this.btnProcessPayroll);
            this.panelBatchControls.Controls.Add(this.btnPreviewPayroll);
            this.panelBatchControls.Location = new System.Drawing.Point(321, 335);
            this.panelBatchControls.Name = "panelBatchControls";
            this.panelBatchControls.Size = new System.Drawing.Size(1356, 75);
            this.panelBatchControls.TabIndex = 9;
            // 
            // dtpPaymentPeriod
            // 
            this.dtpPaymentPeriod.CustomFormat = "MMMM yyyy";
            this.dtpPaymentPeriod.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.dtpPaymentPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentPeriod.Location = new System.Drawing.Point(23, 28);
            this.dtpPaymentPeriod.Name = "dtpPaymentPeriod";
            this.dtpPaymentPeriod.Size = new System.Drawing.Size(180, 26);
            this.dtpPaymentPeriod.TabIndex = 3;
            // 
            // lblPaymentPeriod
            // 
            this.lblPaymentPeriod.AutoSize = true;
            this.lblPaymentPeriod.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblPaymentPeriod.Location = new System.Drawing.Point(20, 8);
            this.lblPaymentPeriod.Name = "lblPaymentPeriod";
            this.lblPaymentPeriod.Size = new System.Drawing.Size(114, 17);
            this.lblPaymentPeriod.TabIndex = 2;
            this.lblPaymentPeriod.Text = "Payment Period";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Bank Transfer",
            "Cash",
            "Mobile Wallet"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(230, 28);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(180, 28);
            this.cmbPaymentMethod.TabIndex = 3;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblPaymentMethod.Location = new System.Drawing.Point(227, 8);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(123, 17);
            this.lblPaymentMethod.TabIndex = 2;
            this.lblPaymentMethod.Text = "Payment Method";
            // 
            // btnProcessPayroll
            // 
            this.btnProcessPayroll.ButtonText = "Process Payroll";
            this.btnProcessPayroll.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnProcessPayroll.CheckedForeColor = System.Drawing.Color.White;
            this.btnProcessPayroll.CheckedImageTint = System.Drawing.Color.White;
            this.btnProcessPayroll.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnProcessPayroll.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnProcessPayroll.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnProcessPayroll.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnProcessPayroll.HoverForeColor = System.Drawing.Color.White;
            this.btnProcessPayroll.HoverImage = null;
            this.btnProcessPayroll.HoverImageTint = System.Drawing.Color.White;
            this.btnProcessPayroll.HoverOutline = System.Drawing.Color.Empty;
            this.btnProcessPayroll.Image = global::SkolarAid.Properties.Resources.dollar;
            this.btnProcessPayroll.ImageAutoCenter = true;
            this.btnProcessPayroll.ImageExpand = new System.Drawing.Point(8, 8);
            this.btnProcessPayroll.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnProcessPayroll.ImageTint = System.Drawing.Color.White;
            this.btnProcessPayroll.IsToggleButton = false;
            this.btnProcessPayroll.IsToggled = false;
            this.btnProcessPayroll.Location = new System.Drawing.Point(992, 16);
            this.btnProcessPayroll.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnProcessPayroll.Name = "btnProcessPayroll";
            this.btnProcessPayroll.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnProcessPayroll.NormalForeColor = System.Drawing.Color.White;
            this.btnProcessPayroll.NormalOutline = System.Drawing.Color.Empty;
            this.btnProcessPayroll.OutlineThickness = 2F;
            this.btnProcessPayroll.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnProcessPayroll.PressedForeColor = System.Drawing.Color.White;
            this.btnProcessPayroll.PressedImageTint = System.Drawing.Color.White;
            this.btnProcessPayroll.PressedOutline = System.Drawing.Color.Empty;
            this.btnProcessPayroll.Rounding = new System.Windows.Forms.Padding(5);
            this.btnProcessPayroll.Size = new System.Drawing.Size(158, 40);
            this.btnProcessPayroll.TabIndex = 4;
            this.btnProcessPayroll.TextAutoCenter = true;
            this.btnProcessPayroll.TextOffset = new System.Drawing.Point(-10, 0);
            // 
            // btnPreviewPayroll
            // 
            this.btnPreviewPayroll.ButtonText = "Preview";
            this.btnPreviewPayroll.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnPreviewPayroll.CheckedForeColor = System.Drawing.Color.White;
            this.btnPreviewPayroll.CheckedImageTint = System.Drawing.Color.White;
            this.btnPreviewPayroll.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnPreviewPayroll.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPreviewPayroll.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.btnPreviewPayroll.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnPreviewPayroll.HoverForeColor = System.Drawing.Color.White;
            this.btnPreviewPayroll.HoverImage = null;
            this.btnPreviewPayroll.HoverImageTint = System.Drawing.Color.White;
            this.btnPreviewPayroll.HoverOutline = System.Drawing.Color.Empty;
            this.btnPreviewPayroll.Image = global::SkolarAid.Properties.Resources.analysis;
            this.btnPreviewPayroll.ImageAutoCenter = true;
            this.btnPreviewPayroll.ImageExpand = new System.Drawing.Point(8, 8);
            this.btnPreviewPayroll.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnPreviewPayroll.ImageTint = System.Drawing.Color.White;
            this.btnPreviewPayroll.IsToggleButton = false;
            this.btnPreviewPayroll.IsToggled = false;
            this.btnPreviewPayroll.Location = new System.Drawing.Point(1167, 15);
            this.btnPreviewPayroll.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPreviewPayroll.Name = "btnPreviewPayroll";
            this.btnPreviewPayroll.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnPreviewPayroll.NormalForeColor = System.Drawing.Color.White;
            this.btnPreviewPayroll.NormalOutline = System.Drawing.Color.Empty;
            this.btnPreviewPayroll.OutlineThickness = 2F;
            this.btnPreviewPayroll.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnPreviewPayroll.PressedForeColor = System.Drawing.Color.White;
            this.btnPreviewPayroll.PressedImageTint = System.Drawing.Color.White;
            this.btnPreviewPayroll.PressedOutline = System.Drawing.Color.Empty;
            this.btnPreviewPayroll.Rounding = new System.Windows.Forms.Padding(5);
            this.btnPreviewPayroll.Size = new System.Drawing.Size(140, 40);
            this.btnPreviewPayroll.TabIndex = 5;
            this.btnPreviewPayroll.TextAutoCenter = true;
            this.btnPreviewPayroll.TextOffset = new System.Drawing.Point(0, 0);
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
            this.panelDataGrid.Controls.Add(this.dgvScholars);
            this.panelDataGrid.Location = new System.Drawing.Point(321, 425);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(974, 547);
            this.panelDataGrid.TabIndex = 10;
            // 
            // dgvScholars
            // 
            this.dgvScholars.AllowUserToAddRows = false;
            this.dgvScholars.AllowUserToDeleteRows = false;
            this.dgvScholars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScholars.BackgroundColor = System.Drawing.Color.White;
            this.dgvScholars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvScholars.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScholars.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScholars.ColumnHeadersHeight = 40;
            this.dgvScholars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colScholarNumber,
            this.colName,
            this.colCourse,
            this.colYearLevel,
            this.colScholarshipType,
            this.colStipendAmount,
            this.colComplianceStatus,
            this.colEligible});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScholars.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScholars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScholars.EnableHeadersVisualStyles = false;
            this.dgvScholars.GridColor = System.Drawing.Color.LightGray;
            this.dgvScholars.Location = new System.Drawing.Point(0, 0);
            this.dgvScholars.Name = "dgvScholars";
            this.dgvScholars.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvScholars.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvScholars.RowTemplate.Height = 35;
            this.dgvScholars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScholars.Size = new System.Drawing.Size(974, 547);
            this.dgvScholars.TabIndex = 0;
            // 
            // colSelect
            // 
            this.colSelect.FillWeight = 30F;
            this.colSelect.HeaderText = "";
            this.colSelect.Name = "colSelect";
            // 
            // colScholarNumber
            // 
            this.colScholarNumber.HeaderText = "Scholar #";
            this.colScholarNumber.Name = "colScholarNumber";
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colCourse
            // 
            this.colCourse.HeaderText = "Course";
            this.colCourse.Name = "colCourse";
            // 
            // colYearLevel
            // 
            this.colYearLevel.HeaderText = "Year";
            this.colYearLevel.Name = "colYearLevel";
            // 
            // colScholarshipType
            // 
            this.colScholarshipType.HeaderText = "Scholarship";
            this.colScholarshipType.Name = "colScholarshipType";
            // 
            // colStipendAmount
            // 
            this.colStipendAmount.HeaderText = "Stipend";
            this.colStipendAmount.Name = "colStipendAmount";
            // 
            // colComplianceStatus
            // 
            this.colComplianceStatus.HeaderText = "Compliance";
            this.colComplianceStatus.Name = "colComplianceStatus";
            // 
            // colEligible
            // 
            this.colEligible.HeaderText = "Eligible";
            this.colEligible.Name = "colEligible";
            this.colEligible.ReadOnly = true;
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.Color.White;
            this.panelSummary.BackColor2 = System.Drawing.Color.White;
            this.panelSummary.BorderColor = System.Drawing.Color.Black;
            borderRadius8.BottomLeft = 10;
            borderRadius8.BottomRight = 10;
            borderRadius8.TopLeft = 10;
            borderRadius8.TopRight = 10;
            this.panelSummary.BorderRadius = borderRadius8;
            this.panelSummary.BorderThickness = 0;
            this.panelSummary.Controls.Add(this.lblSummaryMethod);
            this.panelSummary.Controls.Add(this.lblSummaryAmount);
            this.panelSummary.Controls.Add(this.lblSummaryScholars);
            this.panelSummary.Controls.Add(this.lblSummaryTitle);
            this.panelSummary.Location = new System.Drawing.Point(1313, 425);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(364, 547);
            this.panelSummary.TabIndex = 11;
            // 
            // lblSummaryMethod
            // 
            this.lblSummaryMethod.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lblSummaryMethod.ForeColor = System.Drawing.Color.Black;
            this.lblSummaryMethod.Location = new System.Drawing.Point(21, 150);
            this.lblSummaryMethod.Name = "lblSummaryMethod";
            this.lblSummaryMethod.Size = new System.Drawing.Size(215, 30);
            this.lblSummaryMethod.TabIndex = 1;
            this.lblSummaryMethod.Text = "Method: Bank Transfer";
            // 
            // lblSummaryAmount
            // 
            this.lblSummaryAmount.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.lblSummaryAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblSummaryAmount.Location = new System.Drawing.Point(21, 100);
            this.lblSummaryAmount.Name = "lblSummaryAmount";
            this.lblSummaryAmount.Size = new System.Drawing.Size(215, 40);
            this.lblSummaryAmount.TabIndex = 1;
            this.lblSummaryAmount.Text = "Total: ₱0.00";
            // 
            // lblSummaryScholars
            // 
            this.lblSummaryScholars.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lblSummaryScholars.ForeColor = System.Drawing.Color.Black;
            this.lblSummaryScholars.Location = new System.Drawing.Point(21, 60);
            this.lblSummaryScholars.Name = "lblSummaryScholars";
            this.lblSummaryScholars.Size = new System.Drawing.Size(215, 30);
            this.lblSummaryScholars.TabIndex = 1;
            this.lblSummaryScholars.Text = "Selected Scholars: 0";
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblSummaryTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(155, 23);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "Batch Summary";
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
            this.panelSidebar.Size = new System.Drawing.Size(280, 920);
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
            // FrmPayrollProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1700, 1000);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.panelDataGrid);
            this.Controls.Add(this.panelBatchControls);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelStats4);
            this.Controls.Add(this.panelStats3);
            this.Controls.Add(this.panelStats2);
            this.Controls.Add(this.panelStats1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPayrollProcessing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payroll Processing - ScholarAid";
            this.Load += new System.EventHandler(this.FrmPayrollProcessing_Load_1);
            this.panelStats1.ResumeLayout(false);
            this.panelStats1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEligible)).EndInit();
            this.panelStats2.ResumeLayout(false);
            this.panelStats2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelected)).EndInit();
            this.panelStats3.ResumeLayout(false);
            this.panelStats3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalAmount)).EndInit();
            this.panelStats4.ResumeLayout(false);
            this.panelStats4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessed)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelBatchControls.ResumeLayout(false);
            this.panelBatchControls.PerformLayout();
            this.panelDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScholars)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
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
        private System.Windows.Forms.Label lblEligibleCount;
        private System.Windows.Forms.Label lblEligibleLabel;
        private System.Windows.Forms.PictureBox picEligible;
        private SATAUiFramework.SATAPanel panelStats2;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.Label lblSelectedLabel;
        private System.Windows.Forms.PictureBox picSelected;
        private SATAUiFramework.SATAPanel panelStats3;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalAmountLabel;
        private System.Windows.Forms.PictureBox picTotalAmount;
        private SATAUiFramework.SATAPanel panelStats4;
        private System.Windows.Forms.Label lblProcessedToday;
        private System.Windows.Forms.Label lblProcessedLabel;
        private System.Windows.Forms.PictureBox picProcessed;

        // Filters Panel
        private SATAUiFramework.SATAPanel panelFilters;
        private System.Windows.Forms.ComboBox cmbScholarshipType;
        private System.Windows.Forms.Label lblScholarshipType;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.Label lblYearLevel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private FrameworkTest.SATAButton btnSelectAll;
        private FrameworkTest.SATAButton btnClearSelection;

        // Batch Controls
        private SATAUiFramework.SATAPanel panelBatchControls;
        private System.Windows.Forms.DateTimePicker dtpPaymentPeriod;
        private System.Windows.Forms.Label lblPaymentPeriod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblPaymentMethod;
        private FrameworkTest.SATAButton btnProcessPayroll;
        private FrameworkTest.SATAButton btnPreviewPayroll;

        // Data Grid
        private SATAUiFramework.SATAPanel panelDataGrid;
        private System.Windows.Forms.DataGridView dgvScholars;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScholarNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYearLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScholarshipType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStipendAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComplianceStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEligible;

        // Summary Panel
        private SATAUiFramework.SATAPanel panelSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblSummaryScholars;
        private System.Windows.Forms.Label lblSummaryAmount;
        private System.Windows.Forms.Label lblSummaryMethod;
        private System.Windows.Forms.Panel panelSidebar;
        private FrameworkTest.SATAButton btnReminder;
        private FrameworkTest.SATAButton btnActivityLog;
        private FrameworkTest.SATAButton btnReports;
        private FrameworkTest.SATAButton btnPayroll;
        private FrameworkTest.SATAButton btnScholarMgmt;
        private FrameworkTest.SATAButton btnDashboard;
        private SATAUiFramework.SATAPanel panelHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblBrand;
        private FrameworkTest.SATAButton btnLogout;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblRole;
    }
}