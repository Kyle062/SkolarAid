namespace SkolarAid
{
    partial class FrmReportsAnalytics : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius3 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius4 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius5 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius6 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius7 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius8 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius9 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius10 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius11 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius12 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius13 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tabControlReports = new System.Windows.Forms.TabControl();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.panelReports = new SATAUiFramework.SATAPanel();
            this.btnPrint = new FrameworkTest.SATAButton();
            this.btnExportExcel = new FrameworkTest.SATAButton();
            this.btnExportPDF = new FrameworkTest.SATAButton();
            this.btnGenerateReport = new FrameworkTest.SATAButton();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.cmbFilterScholarship = new System.Windows.Forms.ComboBox();
            this.cmbFilterCourse = new System.Windows.Forms.ComboBox();
            this.labelFilterOptions = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.labelDateRange = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.labelReportType = new System.Windows.Forms.Label();
            this.panelReportPreview = new SATAUiFramework.SATAPanel();
            this.dgvReportData = new System.Windows.Forms.DataGridView();
            this.tabPageAnalytics = new System.Windows.Forms.TabPage();
            this.panelAnalytics = new SATAUiFramework.SATAPanel();
            this.panelCharts = new SATAUiFramework.SATAPanel();
            this.btnRefreshAnalytics = new FrameworkTest.SATAButton();
            this.labelCharts = new System.Windows.Forms.Label();
            this.panelChartPayments = new SATAUiFramework.SATAPanel();
            this.labelChart3Title = new System.Windows.Forms.Label();
            this.panelChartCourse = new SATAUiFramework.SATAPanel();
            this.labelChart2Title = new System.Windows.Forms.Label();
            this.panelChartScholarship = new SATAUiFramework.SATAPanel();
            this.labelChart1Title = new System.Windows.Forms.Label();
            this.panelStatsCards = new SATAUiFramework.SATAPanel();
            this.panelPendingPayments = new SATAUiFramework.SATAPanel();
            this.lblPendingPaymentsTitle = new System.Windows.Forms.Label();
            this.lblPendingPaymentsValue = new System.Windows.Forms.Label();
            this.panelTotalDisbursed = new SATAUiFramework.SATAPanel();
            this.lblTotalDisbursedTitle = new System.Windows.Forms.Label();
            this.lblTotalDisbursedValue = new System.Windows.Forms.Label();
            this.panelActiveScholars = new SATAUiFramework.SATAPanel();
            this.lblActiveScholarsTitle = new System.Windows.Forms.Label();
            this.lblActiveScholarsValue = new System.Windows.Forms.Label();
            this.panelTotalScholars = new SATAUiFramework.SATAPanel();
            this.lblTotalScholarsTitle = new System.Windows.Forms.Label();
            this.lblTotalScholarsValue = new System.Windows.Forms.Label();
            this.pictureBoxChart3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxChart2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxChart1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPending = new System.Windows.Forms.PictureBox();
            this.pictureBoxDisbursed = new System.Windows.Forms.PictureBox();
            this.pictureBoxActive = new System.Windows.Forms.PictureBox();
            this.pictureBoxScholars = new System.Windows.Forms.PictureBox();
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
            this.panelContent.SuspendLayout();
            this.tabControlReports.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.panelReports.SuspendLayout();
            this.panelReportPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportData)).BeginInit();
            this.tabPageAnalytics.SuspendLayout();
            this.panelAnalytics.SuspendLayout();
            this.panelCharts.SuspendLayout();
            this.panelChartPayments.SuspendLayout();
            this.panelChartCourse.SuspendLayout();
            this.panelChartScholarship.SuspendLayout();
            this.panelStatsCards.SuspendLayout();
            this.panelPendingPayments.SuspendLayout();
            this.panelTotalDisbursed.SuspendLayout();
            this.panelActiveScholars.SuspendLayout();
            this.panelTotalScholars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPending)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisbursed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScholars)).BeginInit();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.panelSidebar);
            this.panelContent.Controls.Add(this.panelHeader);
            this.panelContent.Controls.Add(this.tabControlReports);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1700, 1050);
            this.panelContent.TabIndex = 4;
            // 
            // tabControlReports
            // 
            this.tabControlReports.Controls.Add(this.tabPageReports);
            this.tabControlReports.Controls.Add(this.tabPageAnalytics);
            this.tabControlReports.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.tabControlReports.Location = new System.Drawing.Point(288, 125);
            this.tabControlReports.Name = "tabControlReports";
            this.tabControlReports.SelectedIndex = 0;
            this.tabControlReports.Size = new System.Drawing.Size(1389, 850);
            this.tabControlReports.TabIndex = 0;
            // 
            // tabPageReports
            // 
            this.tabPageReports.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageReports.Controls.Add(this.panelReports);
            this.tabPageReports.Location = new System.Drawing.Point(4, 25);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReports.Size = new System.Drawing.Size(1381, 821);
            this.tabPageReports.TabIndex = 0;
            this.tabPageReports.Text = "Generate Reports";
            // 
            // panelReports
            // 
            this.panelReports.BackColor = System.Drawing.Color.White;
            this.panelReports.BackColor2 = System.Drawing.Color.White;
            this.panelReports.BorderColor = System.Drawing.Color.LightGray;
            borderRadius2.BottomLeft = 10;
            borderRadius2.BottomRight = 10;
            borderRadius2.TopLeft = 10;
            borderRadius2.TopRight = 10;
            this.panelReports.BorderRadius = borderRadius2;
            this.panelReports.BorderThickness = 1;
            this.panelReports.Controls.Add(this.btnPrint);
            this.panelReports.Controls.Add(this.btnExportExcel);
            this.panelReports.Controls.Add(this.btnExportPDF);
            this.panelReports.Controls.Add(this.btnGenerateReport);
            this.panelReports.Controls.Add(this.cmbFilterStatus);
            this.panelReports.Controls.Add(this.cmbFilterScholarship);
            this.panelReports.Controls.Add(this.cmbFilterCourse);
            this.panelReports.Controls.Add(this.labelFilterOptions);
            this.panelReports.Controls.Add(this.dtpDateTo);
            this.panelReports.Controls.Add(this.labelTo);
            this.panelReports.Controls.Add(this.dtpDateFrom);
            this.panelReports.Controls.Add(this.labelDateRange);
            this.panelReports.Controls.Add(this.cmbReportType);
            this.panelReports.Controls.Add(this.labelReportType);
            this.panelReports.Controls.Add(this.panelReportPreview);
            this.panelReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReports.Location = new System.Drawing.Point(3, 3);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(1375, 815);
            this.panelReports.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.ButtonText = "Print";
            this.btnPrint.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnPrint.CheckedForeColor = System.Drawing.Color.White;
            this.btnPrint.CheckedImageTint = System.Drawing.Color.White;
            this.btnPrint.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnPrint.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnPrint.HoverForeColor = System.Drawing.Color.White;
            this.btnPrint.HoverImage = null;
            this.btnPrint.HoverImageTint = System.Drawing.Color.White;
            this.btnPrint.HoverOutline = System.Drawing.Color.Empty;
            this.btnPrint.Image = null;
            this.btnPrint.ImageAutoCenter = true;
            this.btnPrint.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnPrint.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnPrint.ImageTint = System.Drawing.Color.White;
            this.btnPrint.IsToggleButton = false;
            this.btnPrint.IsToggled = false;
            this.btnPrint.Location = new System.Drawing.Point(1272, 58);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnPrint.NormalForeColor = System.Drawing.Color.White;
            this.btnPrint.NormalOutline = System.Drawing.Color.Empty;
            this.btnPrint.OutlineThickness = 2F;
            this.btnPrint.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnPrint.PressedForeColor = System.Drawing.Color.White;
            this.btnPrint.PressedImageTint = System.Drawing.Color.White;
            this.btnPrint.PressedOutline = System.Drawing.Color.Empty;
            this.btnPrint.Rounding = new System.Windows.Forms.Padding(5);
            this.btnPrint.Size = new System.Drawing.Size(80, 35);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.TextAutoCenter = true;
            this.btnPrint.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.ButtonText = "Export Excel";
            this.btnExportExcel.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnExportExcel.CheckedForeColor = System.Drawing.Color.White;
            this.btnExportExcel.CheckedImageTint = System.Drawing.Color.White;
            this.btnExportExcel.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExportExcel.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExportExcel.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportExcel.HoverForeColor = System.Drawing.Color.White;
            this.btnExportExcel.HoverImage = null;
            this.btnExportExcel.HoverImageTint = System.Drawing.Color.White;
            this.btnExportExcel.HoverOutline = System.Drawing.Color.Empty;
            this.btnExportExcel.Image = null;
            this.btnExportExcel.ImageAutoCenter = true;
            this.btnExportExcel.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnExportExcel.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnExportExcel.ImageTint = System.Drawing.Color.White;
            this.btnExportExcel.IsToggleButton = false;
            this.btnExportExcel.IsToggled = false;
            this.btnExportExcel.Location = new System.Drawing.Point(1140, 58);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportExcel.NormalForeColor = System.Drawing.Color.White;
            this.btnExportExcel.NormalOutline = System.Drawing.Color.Empty;
            this.btnExportExcel.OutlineThickness = 2F;
            this.btnExportExcel.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.btnExportExcel.PressedForeColor = System.Drawing.Color.White;
            this.btnExportExcel.PressedImageTint = System.Drawing.Color.White;
            this.btnExportExcel.PressedOutline = System.Drawing.Color.Empty;
            this.btnExportExcel.Rounding = new System.Windows.Forms.Padding(5);
            this.btnExportExcel.Size = new System.Drawing.Size(100, 35);
            this.btnExportExcel.TabIndex = 12;
            this.btnExportExcel.TextAutoCenter = true;
            this.btnExportExcel.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.ButtonText = "Export PDF";
            this.btnExportPDF.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnExportPDF.CheckedForeColor = System.Drawing.Color.White;
            this.btnExportPDF.CheckedImageTint = System.Drawing.Color.White;
            this.btnExportPDF.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExportPDF.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExportPDF.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportPDF.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnExportPDF.HoverForeColor = System.Drawing.Color.White;
            this.btnExportPDF.HoverImage = null;
            this.btnExportPDF.HoverImageTint = System.Drawing.Color.White;
            this.btnExportPDF.HoverOutline = System.Drawing.Color.Empty;
            this.btnExportPDF.Image = null;
            this.btnExportPDF.ImageAutoCenter = true;
            this.btnExportPDF.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnExportPDF.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnExportPDF.ImageTint = System.Drawing.Color.White;
            this.btnExportPDF.IsToggleButton = false;
            this.btnExportPDF.IsToggled = false;
            this.btnExportPDF.Location = new System.Drawing.Point(1015, 58);
            this.btnExportPDF.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnExportPDF.NormalForeColor = System.Drawing.Color.White;
            this.btnExportPDF.NormalOutline = System.Drawing.Color.Empty;
            this.btnExportPDF.OutlineThickness = 2F;
            this.btnExportPDF.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnExportPDF.PressedForeColor = System.Drawing.Color.White;
            this.btnExportPDF.PressedImageTint = System.Drawing.Color.White;
            this.btnExportPDF.PressedOutline = System.Drawing.Color.Empty;
            this.btnExportPDF.Rounding = new System.Windows.Forms.Padding(5);
            this.btnExportPDF.Size = new System.Drawing.Size(100, 35);
            this.btnExportPDF.TabIndex = 11;
            this.btnExportPDF.TextAutoCenter = true;
            this.btnExportPDF.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.ButtonText = "Generate Report";
            this.btnGenerateReport.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnGenerateReport.CheckedForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.CheckedImageTint = System.Drawing.Color.White;
            this.btnGenerateReport.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGenerateReport.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGenerateReport.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerateReport.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnGenerateReport.HoverForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.HoverImage = null;
            this.btnGenerateReport.HoverImageTint = System.Drawing.Color.White;
            this.btnGenerateReport.HoverOutline = System.Drawing.Color.Empty;
            this.btnGenerateReport.Image = null;
            this.btnGenerateReport.ImageAutoCenter = true;
            this.btnGenerateReport.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnGenerateReport.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnGenerateReport.ImageTint = System.Drawing.Color.White;
            this.btnGenerateReport.IsToggleButton = false;
            this.btnGenerateReport.IsToggled = false;
            this.btnGenerateReport.Location = new System.Drawing.Point(842, 58);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnGenerateReport.NormalForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.NormalOutline = System.Drawing.Color.Empty;
            this.btnGenerateReport.OutlineThickness = 2F;
            this.btnGenerateReport.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnGenerateReport.PressedForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.PressedImageTint = System.Drawing.Color.White;
            this.btnGenerateReport.PressedOutline = System.Drawing.Color.Empty;
            this.btnGenerateReport.Rounding = new System.Windows.Forms.Padding(5);
            this.btnGenerateReport.Size = new System.Drawing.Size(140, 35);
            this.btnGenerateReport.TabIndex = 10;
            this.btnGenerateReport.TextAutoCenter = true;
            this.btnGenerateReport.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Items.AddRange(new object[] {
            "All Status",
            "Active",
            "Inactive",
            "Graduated",
            "Terminated"});
            this.cmbFilterStatus.Location = new System.Drawing.Point(550, 62);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbFilterStatus.TabIndex = 9;
            // 
            // cmbFilterScholarship
            // 
            this.cmbFilterScholarship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterScholarship.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.cmbFilterScholarship.FormattingEnabled = true;
            this.cmbFilterScholarship.Items.AddRange(new object[] {
            "All Scholarships",
            "Academic Excellence",
            "Athletic Scholarship",
            "Financial Need",
            "President\'s List"});
            this.cmbFilterScholarship.Location = new System.Drawing.Point(350, 62);
            this.cmbFilterScholarship.Name = "cmbFilterScholarship";
            this.cmbFilterScholarship.Size = new System.Drawing.Size(180, 25);
            this.cmbFilterScholarship.TabIndex = 8;
            // 
            // cmbFilterCourse
            // 
            this.cmbFilterCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCourse.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.cmbFilterCourse.FormattingEnabled = true;
            this.cmbFilterCourse.Items.AddRange(new object[] {
            "All Courses",
            "BS Information Technology",
            "BS Computer Science",
            "BS Information Systems",
            "BS Business Administration",
            "BS Education"});
            this.cmbFilterCourse.Location = new System.Drawing.Point(130, 62);
            this.cmbFilterCourse.Name = "cmbFilterCourse";
            this.cmbFilterCourse.Size = new System.Drawing.Size(200, 25);
            this.cmbFilterCourse.TabIndex = 7;
            // 
            // labelFilterOptions
            // 
            this.labelFilterOptions.AutoSize = true;
            this.labelFilterOptions.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.labelFilterOptions.ForeColor = System.Drawing.Color.Black;
            this.labelFilterOptions.Location = new System.Drawing.Point(25, 65);
            this.labelFilterOptions.Name = "labelFilterOptions";
            this.labelFilterOptions.Size = new System.Drawing.Size(100, 17);
            this.labelFilterOptions.TabIndex = 6;
            this.labelFilterOptions.Text = "Filter Options:";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(640, 22);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(120, 24);
            this.dtpDateTo.TabIndex = 5;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelTo.ForeColor = System.Drawing.Color.Black;
            this.labelTo.Location = new System.Drawing.Point(608, 25);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(23, 19);
            this.labelTo.TabIndex = 4;
            this.labelTo.Text = "to";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(480, 22);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(120, 24);
            this.dtpDateFrom.TabIndex = 3;
            // 
            // labelDateRange
            // 
            this.labelDateRange.AutoSize = true;
            this.labelDateRange.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.labelDateRange.ForeColor = System.Drawing.Color.Black;
            this.labelDateRange.Location = new System.Drawing.Point(380, 25);
            this.labelDateRange.Name = "labelDateRange";
            this.labelDateRange.Size = new System.Drawing.Size(91, 17);
            this.labelDateRange.TabIndex = 2;
            this.labelDateRange.Text = "Date Range:";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Scholar Census Report",
            "Payroll Summary Report",
            "Compliance Report",
            "Payment History Report",
            "Activity Log Report"});
            this.cmbReportType.Location = new System.Drawing.Point(130, 22);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(220, 25);
            this.cmbReportType.TabIndex = 1;
            // 
            // labelReportType
            // 
            this.labelReportType.AutoSize = true;
            this.labelReportType.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.labelReportType.ForeColor = System.Drawing.Color.Black;
            this.labelReportType.Location = new System.Drawing.Point(25, 25);
            this.labelReportType.Name = "labelReportType";
            this.labelReportType.Size = new System.Drawing.Size(90, 17);
            this.labelReportType.TabIndex = 0;
            this.labelReportType.Text = "Report Type:";
            // 
            // panelReportPreview
            // 
            this.panelReportPreview.BackColor = System.Drawing.Color.White;
            this.panelReportPreview.BackColor2 = System.Drawing.Color.White;
            this.panelReportPreview.BorderColor = System.Drawing.Color.LightGray;
            borderRadius3.BottomLeft = 10;
            borderRadius3.BottomRight = 10;
            borderRadius3.TopLeft = 10;
            borderRadius3.TopRight = 10;
            this.panelReportPreview.BorderRadius = borderRadius3;
            this.panelReportPreview.BorderThickness = 1;
            this.panelReportPreview.Controls.Add(this.dgvReportData);
            this.panelReportPreview.Location = new System.Drawing.Point(25, 115);
            this.panelReportPreview.Name = "panelReportPreview";
            this.panelReportPreview.Size = new System.Drawing.Size(1215, 670);
            this.panelReportPreview.TabIndex = 14;
            // 
            // dgvReportData
            // 
            this.dgvReportData.AllowUserToAddRows = false;
            this.dgvReportData.AllowUserToDeleteRows = false;
            this.dgvReportData.BackgroundColor = System.Drawing.Color.White;
            this.dgvReportData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportData.Location = new System.Drawing.Point(0, 0);
            this.dgvReportData.Name = "dgvReportData";
            this.dgvReportData.ReadOnly = true;
            this.dgvReportData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportData.Size = new System.Drawing.Size(1215, 670);
            this.dgvReportData.TabIndex = 0;
            // 
            // tabPageAnalytics
            // 
            this.tabPageAnalytics.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageAnalytics.Controls.Add(this.panelAnalytics);
            this.tabPageAnalytics.Location = new System.Drawing.Point(4, 25);
            this.tabPageAnalytics.Name = "tabPageAnalytics";
            this.tabPageAnalytics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalytics.Size = new System.Drawing.Size(1381, 821);
            this.tabPageAnalytics.TabIndex = 1;
            this.tabPageAnalytics.Text = "Analytics Dashboard";
            // 
            // panelAnalytics
            // 
            this.panelAnalytics.BackColor = System.Drawing.Color.White;
            this.panelAnalytics.BackColor2 = System.Drawing.Color.White;
            this.panelAnalytics.BorderColor = System.Drawing.Color.LightGray;
            borderRadius4.BottomLeft = 10;
            borderRadius4.BottomRight = 10;
            borderRadius4.TopLeft = 10;
            borderRadius4.TopRight = 10;
            this.panelAnalytics.BorderRadius = borderRadius4;
            this.panelAnalytics.BorderThickness = 1;
            this.panelAnalytics.Controls.Add(this.panelCharts);
            this.panelAnalytics.Controls.Add(this.panelStatsCards);
            this.panelAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalytics.Location = new System.Drawing.Point(3, 3);
            this.panelAnalytics.Name = "panelAnalytics";
            this.panelAnalytics.Size = new System.Drawing.Size(1375, 815);
            this.panelAnalytics.TabIndex = 0;
            // 
            // panelCharts
            // 
            this.panelCharts.BackColor = System.Drawing.Color.White;
            this.panelCharts.BackColor2 = System.Drawing.Color.White;
            this.panelCharts.BorderColor = System.Drawing.Color.LightGray;
            borderRadius5.BottomLeft = 10;
            borderRadius5.BottomRight = 10;
            borderRadius5.TopLeft = 10;
            borderRadius5.TopRight = 10;
            this.panelCharts.BorderRadius = borderRadius5;
            this.panelCharts.BorderThickness = 1;
            this.panelCharts.Controls.Add(this.btnRefreshAnalytics);
            this.panelCharts.Controls.Add(this.labelCharts);
            this.panelCharts.Controls.Add(this.panelChartPayments);
            this.panelCharts.Controls.Add(this.panelChartCourse);
            this.panelCharts.Controls.Add(this.panelChartScholarship);
            this.panelCharts.Location = new System.Drawing.Point(25, 205);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.Size = new System.Drawing.Size(1324, 580);
            this.panelCharts.TabIndex = 1;
            // 
            // btnRefreshAnalytics
            // 
            this.btnRefreshAnalytics.ButtonText = "Refresh";
            this.btnRefreshAnalytics.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnRefreshAnalytics.CheckedForeColor = System.Drawing.Color.White;
            this.btnRefreshAnalytics.CheckedImageTint = System.Drawing.Color.White;
            this.btnRefreshAnalytics.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnRefreshAnalytics.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefreshAnalytics.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshAnalytics.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.btnRefreshAnalytics.HoverForeColor = System.Drawing.Color.White;
            this.btnRefreshAnalytics.HoverImage = null;
            this.btnRefreshAnalytics.HoverImageTint = System.Drawing.Color.White;
            this.btnRefreshAnalytics.HoverOutline = System.Drawing.Color.Empty;
            this.btnRefreshAnalytics.Image = null;
            this.btnRefreshAnalytics.ImageAutoCenter = true;
            this.btnRefreshAnalytics.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnRefreshAnalytics.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnRefreshAnalytics.ImageTint = System.Drawing.Color.White;
            this.btnRefreshAnalytics.IsToggleButton = false;
            this.btnRefreshAnalytics.IsToggled = false;
            this.btnRefreshAnalytics.Location = new System.Drawing.Point(1100, 15);
            this.btnRefreshAnalytics.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnRefreshAnalytics.Name = "btnRefreshAnalytics";
            this.btnRefreshAnalytics.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnRefreshAnalytics.NormalForeColor = System.Drawing.Color.White;
            this.btnRefreshAnalytics.NormalOutline = System.Drawing.Color.Empty;
            this.btnRefreshAnalytics.OutlineThickness = 2F;
            this.btnRefreshAnalytics.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnRefreshAnalytics.PressedForeColor = System.Drawing.Color.White;
            this.btnRefreshAnalytics.PressedImageTint = System.Drawing.Color.White;
            this.btnRefreshAnalytics.PressedOutline = System.Drawing.Color.Empty;
            this.btnRefreshAnalytics.Rounding = new System.Windows.Forms.Padding(5);
            this.btnRefreshAnalytics.Size = new System.Drawing.Size(90, 35);
            this.btnRefreshAnalytics.TabIndex = 1;
            this.btnRefreshAnalytics.TextAutoCenter = true;
            this.btnRefreshAnalytics.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // labelCharts
            // 
            this.labelCharts.AutoSize = true;
            this.labelCharts.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.labelCharts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.labelCharts.Location = new System.Drawing.Point(25, 20);
            this.labelCharts.Name = "labelCharts";
            this.labelCharts.Size = new System.Drawing.Size(185, 26);
            this.labelCharts.TabIndex = 0;
            this.labelCharts.Text = "Analytics Charts";
            // 
            // panelChartPayments
            // 
            this.panelChartPayments.BackColor = System.Drawing.Color.White;
            this.panelChartPayments.BackColor2 = System.Drawing.Color.White;
            this.panelChartPayments.BorderColor = System.Drawing.Color.LightGray;
            borderRadius6.BottomLeft = 10;
            borderRadius6.BottomRight = 10;
            borderRadius6.TopLeft = 10;
            borderRadius6.TopRight = 10;
            this.panelChartPayments.BorderRadius = borderRadius6;
            this.panelChartPayments.BorderThickness = 1;
            this.panelChartPayments.Controls.Add(this.labelChart3Title);
            this.panelChartPayments.Controls.Add(this.pictureBoxChart3);
            this.panelChartPayments.Location = new System.Drawing.Point(902, 80);
            this.panelChartPayments.Name = "panelChartPayments";
            this.panelChartPayments.Size = new System.Drawing.Size(370, 490);
            this.panelChartPayments.TabIndex = 3;
            // 
            // labelChart3Title
            // 
            this.labelChart3Title.AutoSize = true;
            this.labelChart3Title.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.labelChart3Title.ForeColor = System.Drawing.Color.Black;
            this.labelChart3Title.Location = new System.Drawing.Point(20, 20);
            this.labelChart3Title.Name = "labelChart3Title";
            this.labelChart3Title.Size = new System.Drawing.Size(183, 19);
            this.labelChart3Title.TabIndex = 1;
            this.labelChart3Title.Text = "Monthly Disbursements";
            // 
            // panelChartCourse
            // 
            this.panelChartCourse.BackColor = System.Drawing.Color.White;
            this.panelChartCourse.BackColor2 = System.Drawing.Color.White;
            this.panelChartCourse.BorderColor = System.Drawing.Color.LightGray;
            borderRadius7.BottomLeft = 10;
            borderRadius7.BottomRight = 10;
            borderRadius7.TopLeft = 10;
            borderRadius7.TopRight = 10;
            this.panelChartCourse.BorderRadius = borderRadius7;
            this.panelChartCourse.BorderThickness = 1;
            this.panelChartCourse.Controls.Add(this.labelChart2Title);
            this.panelChartCourse.Controls.Add(this.pictureBoxChart2);
            this.panelChartCourse.Location = new System.Drawing.Point(469, 80);
            this.panelChartCourse.Name = "panelChartCourse";
            this.panelChartCourse.Size = new System.Drawing.Size(370, 490);
            this.panelChartCourse.TabIndex = 2;
            // 
            // labelChart2Title
            // 
            this.labelChart2Title.AutoSize = true;
            this.labelChart2Title.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.labelChart2Title.ForeColor = System.Drawing.Color.Black;
            this.labelChart2Title.Location = new System.Drawing.Point(20, 20);
            this.labelChart2Title.Name = "labelChart2Title";
            this.labelChart2Title.Size = new System.Drawing.Size(154, 19);
            this.labelChart2Title.TabIndex = 1;
            this.labelChart2Title.Text = "Scholars by Course";
            // 
            // panelChartScholarship
            // 
            this.panelChartScholarship.BackColor = System.Drawing.Color.White;
            this.panelChartScholarship.BackColor2 = System.Drawing.Color.White;
            this.panelChartScholarship.BorderColor = System.Drawing.Color.LightGray;
            borderRadius8.BottomLeft = 10;
            borderRadius8.BottomRight = 10;
            borderRadius8.TopLeft = 10;
            borderRadius8.TopRight = 10;
            this.panelChartScholarship.BorderRadius = borderRadius8;
            this.panelChartScholarship.BorderThickness = 1;
            this.panelChartScholarship.Controls.Add(this.labelChart1Title);
            this.panelChartScholarship.Controls.Add(this.pictureBoxChart1);
            this.panelChartScholarship.Location = new System.Drawing.Point(30, 80);
            this.panelChartScholarship.Name = "panelChartScholarship";
            this.panelChartScholarship.Size = new System.Drawing.Size(370, 490);
            this.panelChartScholarship.TabIndex = 1;
            // 
            // labelChart1Title
            // 
            this.labelChart1Title.AutoSize = true;
            this.labelChart1Title.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.labelChart1Title.ForeColor = System.Drawing.Color.Black;
            this.labelChart1Title.Location = new System.Drawing.Point(20, 20);
            this.labelChart1Title.Name = "labelChart1Title";
            this.labelChart1Title.Size = new System.Drawing.Size(231, 19);
            this.labelChart1Title.TabIndex = 1;
            this.labelChart1Title.Text = "Scholars by Scholarship Type";
            // 
            // panelStatsCards
            // 
            this.panelStatsCards.BackColor = System.Drawing.Color.White;
            this.panelStatsCards.BackColor2 = System.Drawing.Color.White;
            this.panelStatsCards.BorderColor = System.Drawing.Color.LightGray;
            borderRadius9.BottomLeft = 10;
            borderRadius9.BottomRight = 10;
            borderRadius9.TopLeft = 10;
            borderRadius9.TopRight = 10;
            this.panelStatsCards.BorderRadius = borderRadius9;
            this.panelStatsCards.BorderThickness = 1;
            this.panelStatsCards.Controls.Add(this.panelPendingPayments);
            this.panelStatsCards.Controls.Add(this.panelTotalDisbursed);
            this.panelStatsCards.Controls.Add(this.panelActiveScholars);
            this.panelStatsCards.Controls.Add(this.panelTotalScholars);
            this.panelStatsCards.Location = new System.Drawing.Point(25, 25);
            this.panelStatsCards.Name = "panelStatsCards";
            this.panelStatsCards.Size = new System.Drawing.Size(1314, 160);
            this.panelStatsCards.TabIndex = 0;
            // 
            // panelPendingPayments
            // 
            this.panelPendingPayments.BackColor = System.Drawing.Color.White;
            this.panelPendingPayments.BackColor2 = System.Drawing.Color.White;
            this.panelPendingPayments.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            borderRadius10.BottomLeft = 10;
            borderRadius10.BottomRight = 10;
            borderRadius10.TopLeft = 10;
            borderRadius10.TopRight = 10;
            this.panelPendingPayments.BorderRadius = borderRadius10;
            this.panelPendingPayments.BorderThickness = 2;
            this.panelPendingPayments.Controls.Add(this.pictureBoxPending);
            this.panelPendingPayments.Controls.Add(this.lblPendingPaymentsTitle);
            this.panelPendingPayments.Controls.Add(this.lblPendingPaymentsValue);
            this.panelPendingPayments.Location = new System.Drawing.Point(1007, 22);
            this.panelPendingPayments.Name = "panelPendingPayments";
            this.panelPendingPayments.Size = new System.Drawing.Size(265, 120);
            this.panelPendingPayments.TabIndex = 3;
            // 
            // lblPendingPaymentsTitle
            // 
            this.lblPendingPaymentsTitle.AutoSize = true;
            this.lblPendingPaymentsTitle.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblPendingPaymentsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblPendingPaymentsTitle.Location = new System.Drawing.Point(85, 85);
            this.lblPendingPaymentsTitle.Name = "lblPendingPaymentsTitle";
            this.lblPendingPaymentsTitle.Size = new System.Drawing.Size(132, 17);
            this.lblPendingPaymentsTitle.TabIndex = 1;
            this.lblPendingPaymentsTitle.Text = "Pending Payments";
            // 
            // lblPendingPaymentsValue
            // 
            this.lblPendingPaymentsValue.AutoSize = true;
            this.lblPendingPaymentsValue.Font = new System.Drawing.Font("Century Gothic", 28F, System.Drawing.FontStyle.Bold);
            this.lblPendingPaymentsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblPendingPaymentsValue.Location = new System.Drawing.Point(85, 40);
            this.lblPendingPaymentsValue.Name = "lblPendingPaymentsValue";
            this.lblPendingPaymentsValue.Size = new System.Drawing.Size(40, 44);
            this.lblPendingPaymentsValue.TabIndex = 0;
            this.lblPendingPaymentsValue.Text = "0";
            // 
            // panelTotalDisbursed
            // 
            this.panelTotalDisbursed.BackColor = System.Drawing.Color.White;
            this.panelTotalDisbursed.BackColor2 = System.Drawing.Color.White;
            this.panelTotalDisbursed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            borderRadius11.BottomLeft = 10;
            borderRadius11.BottomRight = 10;
            borderRadius11.TopLeft = 10;
            borderRadius11.TopRight = 10;
            this.panelTotalDisbursed.BorderRadius = borderRadius11;
            this.panelTotalDisbursed.BorderThickness = 2;
            this.panelTotalDisbursed.Controls.Add(this.pictureBoxDisbursed);
            this.panelTotalDisbursed.Controls.Add(this.lblTotalDisbursedTitle);
            this.panelTotalDisbursed.Controls.Add(this.lblTotalDisbursedValue);
            this.panelTotalDisbursed.Location = new System.Drawing.Point(677, 22);
            this.panelTotalDisbursed.Name = "panelTotalDisbursed";
            this.panelTotalDisbursed.Size = new System.Drawing.Size(280, 120);
            this.panelTotalDisbursed.TabIndex = 2;
            // 
            // lblTotalDisbursedTitle
            // 
            this.lblTotalDisbursedTitle.AutoSize = true;
            this.lblTotalDisbursedTitle.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalDisbursedTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalDisbursedTitle.Location = new System.Drawing.Point(80, 85);
            this.lblTotalDisbursedTitle.Name = "lblTotalDisbursedTitle";
            this.lblTotalDisbursedTitle.Size = new System.Drawing.Size(109, 17);
            this.lblTotalDisbursedTitle.TabIndex = 1;
            this.lblTotalDisbursedTitle.Text = "Total Disbursed";
            // 
            // lblTotalDisbursedValue
            // 
            this.lblTotalDisbursedValue.AutoSize = true;
            this.lblTotalDisbursedValue.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalDisbursedValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblTotalDisbursedValue.Location = new System.Drawing.Point(80, 42);
            this.lblTotalDisbursedValue.Name = "lblTotalDisbursedValue";
            this.lblTotalDisbursedValue.Size = new System.Drawing.Size(55, 38);
            this.lblTotalDisbursedValue.TabIndex = 0;
            this.lblTotalDisbursedValue.Text = "₱0";
            // 
            // panelActiveScholars
            // 
            this.panelActiveScholars.BackColor = System.Drawing.Color.White;
            this.panelActiveScholars.BackColor2 = System.Drawing.Color.White;
            this.panelActiveScholars.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            borderRadius12.BottomLeft = 10;
            borderRadius12.BottomRight = 10;
            borderRadius12.TopLeft = 10;
            borderRadius12.TopRight = 10;
            this.panelActiveScholars.BorderRadius = borderRadius12;
            this.panelActiveScholars.BorderThickness = 2;
            this.panelActiveScholars.Controls.Add(this.pictureBoxActive);
            this.panelActiveScholars.Controls.Add(this.lblActiveScholarsTitle);
            this.panelActiveScholars.Controls.Add(this.lblActiveScholarsValue);
            this.panelActiveScholars.Location = new System.Drawing.Point(350, 22);
            this.panelActiveScholars.Name = "panelActiveScholars";
            this.panelActiveScholars.Size = new System.Drawing.Size(280, 120);
            this.panelActiveScholars.TabIndex = 1;
            // 
            // lblActiveScholarsTitle
            // 
            this.lblActiveScholarsTitle.AutoSize = true;
            this.lblActiveScholarsTitle.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblActiveScholarsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblActiveScholarsTitle.Location = new System.Drawing.Point(90, 85);
            this.lblActiveScholarsTitle.Name = "lblActiveScholarsTitle";
            this.lblActiveScholarsTitle.Size = new System.Drawing.Size(111, 17);
            this.lblActiveScholarsTitle.TabIndex = 1;
            this.lblActiveScholarsTitle.Text = "Active Scholars";
            // 
            // lblActiveScholarsValue
            // 
            this.lblActiveScholarsValue.AutoSize = true;
            this.lblActiveScholarsValue.Font = new System.Drawing.Font("Century Gothic", 28F, System.Drawing.FontStyle.Bold);
            this.lblActiveScholarsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblActiveScholarsValue.Location = new System.Drawing.Point(90, 40);
            this.lblActiveScholarsValue.Name = "lblActiveScholarsValue";
            this.lblActiveScholarsValue.Size = new System.Drawing.Size(40, 44);
            this.lblActiveScholarsValue.TabIndex = 0;
            this.lblActiveScholarsValue.Text = "0";
            // 
            // panelTotalScholars
            // 
            this.panelTotalScholars.BackColor = System.Drawing.Color.White;
            this.panelTotalScholars.BackColor2 = System.Drawing.Color.White;
            this.panelTotalScholars.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            borderRadius13.BottomLeft = 10;
            borderRadius13.BottomRight = 10;
            borderRadius13.TopLeft = 10;
            borderRadius13.TopRight = 10;
            this.panelTotalScholars.BorderRadius = borderRadius13;
            this.panelTotalScholars.BorderThickness = 2;
            this.panelTotalScholars.Controls.Add(this.pictureBoxScholars);
            this.panelTotalScholars.Controls.Add(this.lblTotalScholarsTitle);
            this.panelTotalScholars.Controls.Add(this.lblTotalScholarsValue);
            this.panelTotalScholars.Location = new System.Drawing.Point(25, 20);
            this.panelTotalScholars.Name = "panelTotalScholars";
            this.panelTotalScholars.Size = new System.Drawing.Size(280, 120);
            this.panelTotalScholars.TabIndex = 0;
            // 
            // lblTotalScholarsTitle
            // 
            this.lblTotalScholarsTitle.AutoSize = true;
            this.lblTotalScholarsTitle.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalScholarsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalScholarsTitle.Location = new System.Drawing.Point(90, 85);
            this.lblTotalScholarsTitle.Name = "lblTotalScholarsTitle";
            this.lblTotalScholarsTitle.Size = new System.Drawing.Size(100, 17);
            this.lblTotalScholarsTitle.TabIndex = 1;
            this.lblTotalScholarsTitle.Text = "Total Scholars";
            // 
            // lblTotalScholarsValue
            // 
            this.lblTotalScholarsValue.AutoSize = true;
            this.lblTotalScholarsValue.Font = new System.Drawing.Font("Century Gothic", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalScholarsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblTotalScholarsValue.Location = new System.Drawing.Point(90, 40);
            this.lblTotalScholarsValue.Name = "lblTotalScholarsValue";
            this.lblTotalScholarsValue.Size = new System.Drawing.Size(40, 44);
            this.lblTotalScholarsValue.TabIndex = 0;
            this.lblTotalScholarsValue.Text = "0";
            // 
            // pictureBoxChart3
            // 
            this.pictureBoxChart3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxChart3.Location = new System.Drawing.Point(20, 50);
            this.pictureBoxChart3.Name = "pictureBoxChart3";
            this.pictureBoxChart3.Size = new System.Drawing.Size(330, 420);
            this.pictureBoxChart3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxChart3.TabIndex = 0;
            this.pictureBoxChart3.TabStop = false;
            // 
            // pictureBoxChart2
            // 
            this.pictureBoxChart2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxChart2.Location = new System.Drawing.Point(20, 50);
            this.pictureBoxChart2.Name = "pictureBoxChart2";
            this.pictureBoxChart2.Size = new System.Drawing.Size(330, 420);
            this.pictureBoxChart2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxChart2.TabIndex = 0;
            this.pictureBoxChart2.TabStop = false;
            // 
            // pictureBoxChart1
            // 
            this.pictureBoxChart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxChart1.Location = new System.Drawing.Point(20, 50);
            this.pictureBoxChart1.Name = "pictureBoxChart1";
            this.pictureBoxChart1.Size = new System.Drawing.Size(330, 420);
            this.pictureBoxChart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxChart1.TabIndex = 0;
            this.pictureBoxChart1.TabStop = false;
            // 
            // pictureBoxPending
            // 
            this.pictureBoxPending.Image = global::SkolarAid.Properties.Resources.bell__1_;
            this.pictureBoxPending.Location = new System.Drawing.Point(25, 35);
            this.pictureBoxPending.Name = "pictureBoxPending";
            this.pictureBoxPending.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxPending.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPending.TabIndex = 2;
            this.pictureBoxPending.TabStop = false;
            // 
            // pictureBoxDisbursed
            // 
            this.pictureBoxDisbursed.Image = global::SkolarAid.Properties.Resources.dollar;
            this.pictureBoxDisbursed.Location = new System.Drawing.Point(25, 35);
            this.pictureBoxDisbursed.Name = "pictureBoxDisbursed";
            this.pictureBoxDisbursed.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxDisbursed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDisbursed.TabIndex = 2;
            this.pictureBoxDisbursed.TabStop = false;
            // 
            // pictureBoxActive
            // 
            this.pictureBoxActive.Image = global::SkolarAid.Properties.Resources.user__3_;
            this.pictureBoxActive.Location = new System.Drawing.Point(25, 35);
            this.pictureBoxActive.Name = "pictureBoxActive";
            this.pictureBoxActive.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxActive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxActive.TabIndex = 2;
            this.pictureBoxActive.TabStop = false;
            // 
            // pictureBoxScholars
            // 
            this.pictureBoxScholars.Image = global::SkolarAid.Properties.Resources.scholar;
            this.pictureBoxScholars.Location = new System.Drawing.Point(25, 35);
            this.pictureBoxScholars.Name = "pictureBoxScholars";
            this.pictureBoxScholars.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxScholars.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxScholars.TabIndex = 2;
            this.pictureBoxScholars.TabStop = false;
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
            this.panelSidebar.TabIndex = 2;
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
            borderRadius1.BottomLeft = 1;
            borderRadius1.BottomRight = 1;
            borderRadius1.TopLeft = 1;
            borderRadius1.TopRight = 1;
            this.panelHeader.BorderRadius = borderRadius1;
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
            this.panelHeader.TabIndex = 3;
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
            // FrmReportsAnalytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1700, 1050);
            this.Controls.Add(this.panelContent);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReportsAnalytics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports & Analytics";
            this.panelContent.ResumeLayout(false);
            this.tabControlReports.ResumeLayout(false);
            this.tabPageReports.ResumeLayout(false);
            this.panelReports.ResumeLayout(false);
            this.panelReports.PerformLayout();
            this.panelReportPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportData)).EndInit();
            this.tabPageAnalytics.ResumeLayout(false);
            this.panelAnalytics.ResumeLayout(false);
            this.panelCharts.ResumeLayout(false);
            this.panelCharts.PerformLayout();
            this.panelChartPayments.ResumeLayout(false);
            this.panelChartPayments.PerformLayout();
            this.panelChartCourse.ResumeLayout(false);
            this.panelChartCourse.PerformLayout();
            this.panelChartScholarship.ResumeLayout(false);
            this.panelChartScholarship.PerformLayout();
            this.panelStatsCards.ResumeLayout(false);
            this.panelPendingPayments.ResumeLayout(false);
            this.panelPendingPayments.PerformLayout();
            this.panelTotalDisbursed.ResumeLayout(false);
            this.panelTotalDisbursed.PerformLayout();
            this.panelActiveScholars.ResumeLayout(false);
            this.panelActiveScholars.PerformLayout();
            this.panelTotalScholars.ResumeLayout(false);
            this.panelTotalScholars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisbursed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScholars)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.TabControl tabControlReports;
        private System.Windows.Forms.TabPage tabPageReports;
        private SATAUiFramework.SATAPanel panelReports;
        private System.Windows.Forms.TabPage tabPageAnalytics;
        private SATAUiFramework.SATAPanel panelAnalytics;
        private System.Windows.Forms.Label labelReportType;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label labelDateRange;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label labelFilterOptions;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterScholarship;
        private System.Windows.Forms.ComboBox cmbFilterCourse;
        private FrameworkTest.SATAButton btnPrint;
        private FrameworkTest.SATAButton btnExportExcel;
        private FrameworkTest.SATAButton btnExportPDF;
        private FrameworkTest.SATAButton btnGenerateReport;
        private SATAUiFramework.SATAPanel panelReportPreview;
        private System.Windows.Forms.DataGridView dgvReportData;
        private SATAUiFramework.SATAPanel panelStatsCards;
        private SATAUiFramework.SATAPanel panelTotalScholars;
        private System.Windows.Forms.PictureBox pictureBoxScholars;
        private System.Windows.Forms.Label lblTotalScholarsTitle;
        private System.Windows.Forms.Label lblTotalScholarsValue;
        private SATAUiFramework.SATAPanel panelPendingPayments;
        private System.Windows.Forms.PictureBox pictureBoxPending;
        private System.Windows.Forms.Label lblPendingPaymentsTitle;
        private System.Windows.Forms.Label lblPendingPaymentsValue;
        private SATAUiFramework.SATAPanel panelTotalDisbursed;
        private System.Windows.Forms.PictureBox pictureBoxDisbursed;
        private System.Windows.Forms.Label lblTotalDisbursedTitle;
        private System.Windows.Forms.Label lblTotalDisbursedValue;
        private SATAUiFramework.SATAPanel panelActiveScholars;
        private System.Windows.Forms.PictureBox pictureBoxActive;
        private System.Windows.Forms.Label lblActiveScholarsTitle;
        private System.Windows.Forms.Label lblActiveScholarsValue;
        private SATAUiFramework.SATAPanel panelCharts;
        private System.Windows.Forms.Label labelCharts;
        private SATAUiFramework.SATAPanel panelChartPayments;
        private System.Windows.Forms.Label labelChart3Title;
        private System.Windows.Forms.PictureBox pictureBoxChart3;
        private SATAUiFramework.SATAPanel panelChartCourse;
        private System.Windows.Forms.Label labelChart2Title;
        private System.Windows.Forms.PictureBox pictureBoxChart2;
        private SATAUiFramework.SATAPanel panelChartScholarship;
        private System.Windows.Forms.Label labelChart1Title;
        private System.Windows.Forms.PictureBox pictureBoxChart1;
        private FrameworkTest.SATAButton btnRefreshAnalytics;
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