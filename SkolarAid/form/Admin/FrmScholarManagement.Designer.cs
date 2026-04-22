namespace SkolarAid
{
    partial class FrmScholarManagement
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
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius3 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius4 = new SATAUiFramework.BorderRadius();
            this.panelScholarList = new SATAUiFramework.SATAPanel();
            this.dgvScholars = new System.Windows.Forms.DataGridView();
            this.colScholarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScholarNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYearLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScholarship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnReminder1 = new FrameworkTest.SATAButton();
            this.btnActivityLog1 = new FrameworkTest.SATAButton();
            this.btnReports1 = new FrameworkTest.SATAButton();
            this.btnPayroll1 = new FrameworkTest.SATAButton();
            this.btnScholarMgmt1 = new FrameworkTest.SATAButton();
            this.btnDashboard1 = new FrameworkTest.SATAButton();
            this.panelSearchBar = new SATAUiFramework.SATAPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.cmbFilterScholarship = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnAddScholar = new FrameworkTest.SATAButton();
            this.panelHeader = new SATAUiFramework.SATAPanel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnLogout = new FrameworkTest.SATAButton();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.panelForm = new SATAUiFramework.SATAPanel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblSectionBasic = new System.Windows.Forms.Label();
            this.lblSectionAcademic = new System.Windows.Forms.Label();
            this.lblSectionScholarship = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.lblYearLevel = new System.Windows.Forms.Label();
            this.cmbScholarshipType = new System.Windows.Forms.ComboBox();
            this.lblScholarship = new System.Windows.Forms.Label();
            this.dtpEnrollmentDate = new System.Windows.Forms.DateTimePicker();
            this.lblEnrollmentDate = new System.Windows.Forms.Label();
            this.dtpExpectedGraduation = new System.Windows.Forms.DateTimePicker();
            this.lblExpectedGrad = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtScholarNumber = new System.Windows.Forms.TextBox();
            this.lblScholarNumber = new System.Windows.Forms.Label();
            this.btnCancel = new FrameworkTest.SATAButton();
            this.btnDelete = new FrameworkTest.SATAButton();
            this.btnUpdate = new FrameworkTest.SATAButton();
            this.btnSave = new FrameworkTest.SATAButton();
            this.panelScholarList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScholars)).BeginInit();
            this.panelContent.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelSearchBar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelScholarList
            // 
            this.panelScholarList.BackColor = System.Drawing.Color.White;
            this.panelScholarList.BackColor2 = System.Drawing.Color.White;
            this.panelScholarList.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 15;
            borderRadius1.BottomRight = 15;
            borderRadius1.TopLeft = 15;
            borderRadius1.TopRight = 15;
            this.panelScholarList.BorderRadius = borderRadius1;
            this.panelScholarList.BorderThickness = 0;
            this.panelScholarList.Controls.Add(this.dgvScholars);
            this.panelScholarList.Location = new System.Drawing.Point(301, 275);
            this.panelScholarList.Name = "panelScholarList";
            this.panelScholarList.Size = new System.Drawing.Size(972, 721);
            this.panelScholarList.TabIndex = 1;
            // 
            // dgvScholars
            // 
            this.dgvScholars.AllowUserToAddRows = false;
            this.dgvScholars.AllowUserToDeleteRows = false;
            this.dgvScholars.AllowUserToResizeRows = false;
            this.dgvScholars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScholars.BackgroundColor = System.Drawing.Color.White;
            this.dgvScholars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvScholars.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScholars.ColumnHeadersHeight = 45;
            this.dgvScholars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScholarID,
            this.colScholarNumber,
            this.colName,
            this.colCourse,
            this.colYearLevel,
            this.colScholarship,
            this.colStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScholars.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScholars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScholars.EnableHeadersVisualStyles = false;
            this.dgvScholars.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvScholars.Location = new System.Drawing.Point(0, 0);
            this.dgvScholars.MultiSelect = false;
            this.dgvScholars.Name = "dgvScholars";
            this.dgvScholars.ReadOnly = true;
            this.dgvScholars.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvScholars.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvScholars.RowTemplate.Height = 40;
            this.dgvScholars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScholars.Size = new System.Drawing.Size(972, 721);
            this.dgvScholars.TabIndex = 3;
            this.dgvScholars.SelectionChanged += new System.EventHandler(this.dgvScholars_SelectionChanged);
            // 
            // colScholarID
            // 
            this.colScholarID.FillWeight = 40F;
            this.colScholarID.HeaderText = "ID";
            this.colScholarID.Name = "colScholarID";
            this.colScholarID.ReadOnly = true;
            // 
            // colScholarNumber
            // 
            this.colScholarNumber.HeaderText = "Scholar #";
            this.colScholarNumber.Name = "colScholarNumber";
            this.colScholarNumber.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.FillWeight = 120F;
            this.colName.HeaderText = "Full Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colCourse
            // 
            this.colCourse.HeaderText = "Course";
            this.colCourse.Name = "colCourse";
            this.colCourse.ReadOnly = true;
            // 
            // colYearLevel
            // 
            this.colYearLevel.FillWeight = 50F;
            this.colYearLevel.HeaderText = "Year";
            this.colYearLevel.Name = "colYearLevel";
            this.colYearLevel.ReadOnly = true;
            // 
            // colScholarship
            // 
            this.colScholarship.HeaderText = "Scholarship";
            this.colScholarship.Name = "colScholarship";
            this.colScholarship.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 60F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panelContent.Controls.Add(this.lblGreeting);
            this.panelContent.Controls.Add(this.panelSidebar);
            this.panelContent.Controls.Add(this.panelSearchBar);
            this.panelContent.Controls.Add(this.panelHeader);
            this.panelContent.Controls.Add(this.panelForm);
            this.panelContent.Controls.Add(this.panelScholarList);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1700, 1050);
            this.panelContent.TabIndex = 2;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint_3);
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblGreeting.Location = new System.Drawing.Point(306, 111);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(296, 32);
            this.lblGreeting.TabIndex = 8;
            this.lblGreeting.Text = "Scholar Management";
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.panelSidebar.Controls.Add(this.btnReminder1);
            this.panelSidebar.Controls.Add(this.btnActivityLog1);
            this.panelSidebar.Controls.Add(this.btnReports1);
            this.panelSidebar.Controls.Add(this.btnPayroll1);
            this.panelSidebar.Controls.Add(this.btnScholarMgmt1);
            this.panelSidebar.Controls.Add(this.btnDashboard1);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 80);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(280, 970);
            this.panelSidebar.TabIndex = 6;
            // 
            // btnReminder1
            // 
            this.btnReminder1.ButtonText = "Reminder & Notification";
            this.btnReminder1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnReminder1.CheckedForeColor = System.Drawing.Color.White;
            this.btnReminder1.CheckedImageTint = System.Drawing.Color.White;
            this.btnReminder1.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnReminder1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReminder1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnReminder1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnReminder1.HoverForeColor = System.Drawing.Color.White;
            this.btnReminder1.HoverImage = null;
            this.btnReminder1.HoverImageTint = System.Drawing.Color.White;
            this.btnReminder1.HoverOutline = System.Drawing.Color.Empty;
            this.btnReminder1.Image = global::SkolarAid.Properties.Resources.bell__1_;
            this.btnReminder1.ImageAutoCenter = true;
            this.btnReminder1.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnReminder1.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnReminder1.ImageTint = System.Drawing.Color.White;
            this.btnReminder1.IsToggleButton = false;
            this.btnReminder1.IsToggled = false;
            this.btnReminder1.Location = new System.Drawing.Point(0, 420);
            this.btnReminder1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnReminder1.Name = "btnReminder1";
            this.btnReminder1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnReminder1.NormalForeColor = System.Drawing.Color.White;
            this.btnReminder1.NormalOutline = System.Drawing.Color.Empty;
            this.btnReminder1.OutlineThickness = 2F;
            this.btnReminder1.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnReminder1.PressedForeColor = System.Drawing.Color.White;
            this.btnReminder1.PressedImageTint = System.Drawing.Color.White;
            this.btnReminder1.PressedOutline = System.Drawing.Color.Empty;
            this.btnReminder1.Rounding = new System.Windows.Forms.Padding(0);
            this.btnReminder1.Size = new System.Drawing.Size(280, 55);
            this.btnReminder1.TabIndex = 5;
            this.btnReminder1.TextAutoCenter = true;
            this.btnReminder1.TextOffset = new System.Drawing.Point(10, 0);
            this.btnReminder1.Click += new System.EventHandler(this.btnReminder_Click);
            // 
            // btnActivityLog1
            // 
            this.btnActivityLog1.ButtonText = "Activity Log";
            this.btnActivityLog1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnActivityLog1.CheckedForeColor = System.Drawing.Color.White;
            this.btnActivityLog1.CheckedImageTint = System.Drawing.Color.White;
            this.btnActivityLog1.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnActivityLog1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnActivityLog1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnActivityLog1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnActivityLog1.HoverForeColor = System.Drawing.Color.White;
            this.btnActivityLog1.HoverImage = null;
            this.btnActivityLog1.HoverImageTint = System.Drawing.Color.White;
            this.btnActivityLog1.HoverOutline = System.Drawing.Color.Empty;
            this.btnActivityLog1.Image = global::SkolarAid.Properties.Resources.file;
            this.btnActivityLog1.ImageAutoCenter = true;
            this.btnActivityLog1.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnActivityLog1.ImageOffset = new System.Drawing.Point(-35, 0);
            this.btnActivityLog1.ImageTint = System.Drawing.Color.White;
            this.btnActivityLog1.IsToggleButton = false;
            this.btnActivityLog1.IsToggled = false;
            this.btnActivityLog1.Location = new System.Drawing.Point(0, 345);
            this.btnActivityLog1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnActivityLog1.Name = "btnActivityLog1";
            this.btnActivityLog1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnActivityLog1.NormalForeColor = System.Drawing.Color.White;
            this.btnActivityLog1.NormalOutline = System.Drawing.Color.Empty;
            this.btnActivityLog1.OutlineThickness = 2F;
            this.btnActivityLog1.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnActivityLog1.PressedForeColor = System.Drawing.Color.White;
            this.btnActivityLog1.PressedImageTint = System.Drawing.Color.White;
            this.btnActivityLog1.PressedOutline = System.Drawing.Color.Empty;
            this.btnActivityLog1.Rounding = new System.Windows.Forms.Padding(0);
            this.btnActivityLog1.Size = new System.Drawing.Size(280, 55);
            this.btnActivityLog1.TabIndex = 4;
            this.btnActivityLog1.TextAutoCenter = true;
            this.btnActivityLog1.TextOffset = new System.Drawing.Point(-25, 0);
            this.btnActivityLog1.Click += new System.EventHandler(this.btnActivityLog_Click);
            // 
            // btnReports1
            // 
            this.btnReports1.ButtonText = "Reports & Analytics";
            this.btnReports1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnReports1.CheckedForeColor = System.Drawing.Color.White;
            this.btnReports1.CheckedImageTint = System.Drawing.Color.White;
            this.btnReports1.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnReports1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReports1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnReports1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnReports1.HoverForeColor = System.Drawing.Color.White;
            this.btnReports1.HoverImage = null;
            this.btnReports1.HoverImageTint = System.Drawing.Color.White;
            this.btnReports1.HoverOutline = System.Drawing.Color.Empty;
            this.btnReports1.Image = global::SkolarAid.Properties.Resources.analysis;
            this.btnReports1.ImageAutoCenter = true;
            this.btnReports1.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnReports1.ImageOffset = new System.Drawing.Point(-15, 0);
            this.btnReports1.ImageTint = System.Drawing.Color.White;
            this.btnReports1.IsToggleButton = false;
            this.btnReports1.IsToggled = false;
            this.btnReports1.Location = new System.Drawing.Point(0, 270);
            this.btnReports1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnReports1.Name = "btnReports1";
            this.btnReports1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnReports1.NormalForeColor = System.Drawing.Color.White;
            this.btnReports1.NormalOutline = System.Drawing.Color.Empty;
            this.btnReports1.OutlineThickness = 2F;
            this.btnReports1.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnReports1.PressedForeColor = System.Drawing.Color.White;
            this.btnReports1.PressedImageTint = System.Drawing.Color.White;
            this.btnReports1.PressedOutline = System.Drawing.Color.Empty;
            this.btnReports1.Rounding = new System.Windows.Forms.Padding(0);
            this.btnReports1.Size = new System.Drawing.Size(280, 55);
            this.btnReports1.TabIndex = 3;
            this.btnReports1.TextAutoCenter = true;
            this.btnReports1.TextOffset = new System.Drawing.Point(-5, 0);
            this.btnReports1.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnPayroll1
            // 
            this.btnPayroll1.ButtonText = "Payroll Processing";
            this.btnPayroll1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnPayroll1.CheckedForeColor = System.Drawing.Color.White;
            this.btnPayroll1.CheckedImageTint = System.Drawing.Color.White;
            this.btnPayroll1.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnPayroll1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPayroll1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnPayroll1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnPayroll1.HoverForeColor = System.Drawing.Color.White;
            this.btnPayroll1.HoverImage = null;
            this.btnPayroll1.HoverImageTint = System.Drawing.Color.White;
            this.btnPayroll1.HoverOutline = System.Drawing.Color.Empty;
            this.btnPayroll1.Image = global::SkolarAid.Properties.Resources.dollar;
            this.btnPayroll1.ImageAutoCenter = true;
            this.btnPayroll1.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnPayroll1.ImageOffset = new System.Drawing.Point(-25, 0);
            this.btnPayroll1.ImageTint = System.Drawing.Color.White;
            this.btnPayroll1.IsToggleButton = false;
            this.btnPayroll1.IsToggled = false;
            this.btnPayroll1.Location = new System.Drawing.Point(0, 195);
            this.btnPayroll1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPayroll1.Name = "btnPayroll1";
            this.btnPayroll1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnPayroll1.NormalForeColor = System.Drawing.Color.White;
            this.btnPayroll1.NormalOutline = System.Drawing.Color.Empty;
            this.btnPayroll1.OutlineThickness = 2F;
            this.btnPayroll1.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnPayroll1.PressedForeColor = System.Drawing.Color.White;
            this.btnPayroll1.PressedImageTint = System.Drawing.Color.White;
            this.btnPayroll1.PressedOutline = System.Drawing.Color.Empty;
            this.btnPayroll1.Rounding = new System.Windows.Forms.Padding(0);
            this.btnPayroll1.Size = new System.Drawing.Size(280, 55);
            this.btnPayroll1.TabIndex = 2;
            this.btnPayroll1.TextAutoCenter = true;
            this.btnPayroll1.TextOffset = new System.Drawing.Point(-15, 0);
            this.btnPayroll1.Click += new System.EventHandler(this.btnPayroll_Click);
            // 
            // btnScholarMgmt1
            // 
            this.btnScholarMgmt1.ButtonText = "Scholar Management";
            this.btnScholarMgmt1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnScholarMgmt1.CheckedForeColor = System.Drawing.Color.White;
            this.btnScholarMgmt1.CheckedImageTint = System.Drawing.Color.White;
            this.btnScholarMgmt1.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnScholarMgmt1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnScholarMgmt1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btnScholarMgmt1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnScholarMgmt1.HoverForeColor = System.Drawing.Color.White;
            this.btnScholarMgmt1.HoverImage = null;
            this.btnScholarMgmt1.HoverImageTint = System.Drawing.Color.White;
            this.btnScholarMgmt1.HoverOutline = System.Drawing.Color.Empty;
            this.btnScholarMgmt1.Image = global::SkolarAid.Properties.Resources.scholar;
            this.btnScholarMgmt1.ImageAutoCenter = true;
            this.btnScholarMgmt1.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnScholarMgmt1.ImageOffset = new System.Drawing.Point(-10, 0);
            this.btnScholarMgmt1.ImageTint = System.Drawing.Color.White;
            this.btnScholarMgmt1.IsToggleButton = false;
            this.btnScholarMgmt1.IsToggled = true;
            this.btnScholarMgmt1.Location = new System.Drawing.Point(0, 120);
            this.btnScholarMgmt1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnScholarMgmt1.Name = "btnScholarMgmt1";
            this.btnScholarMgmt1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnScholarMgmt1.NormalForeColor = System.Drawing.Color.White;
            this.btnScholarMgmt1.NormalOutline = System.Drawing.Color.Empty;
            this.btnScholarMgmt1.OutlineThickness = 2F;
            this.btnScholarMgmt1.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnScholarMgmt1.PressedForeColor = System.Drawing.Color.White;
            this.btnScholarMgmt1.PressedImageTint = System.Drawing.Color.White;
            this.btnScholarMgmt1.PressedOutline = System.Drawing.Color.Empty;
            this.btnScholarMgmt1.Rounding = new System.Windows.Forms.Padding(0);
            this.btnScholarMgmt1.Size = new System.Drawing.Size(280, 55);
            this.btnScholarMgmt1.TabIndex = 1;
            this.btnScholarMgmt1.TextAutoCenter = true;
            this.btnScholarMgmt1.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnDashboard1
            // 
            this.btnDashboard1.ButtonText = "Dashboard";
            this.btnDashboard1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnDashboard1.CheckedForeColor = System.Drawing.Color.White;
            this.btnDashboard1.CheckedImageTint = System.Drawing.Color.White;
            this.btnDashboard1.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnDashboard1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDashboard1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnDashboard1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnDashboard1.HoverForeColor = System.Drawing.Color.White;
            this.btnDashboard1.HoverImage = null;
            this.btnDashboard1.HoverImageTint = System.Drawing.Color.White;
            this.btnDashboard1.HoverOutline = System.Drawing.Color.Empty;
            this.btnDashboard1.Image = global::SkolarAid.Properties.Resources.dashboard__3_;
            this.btnDashboard1.ImageAutoCenter = true;
            this.btnDashboard1.ImageExpand = new System.Drawing.Point(10, 10);
            this.btnDashboard1.ImageOffset = new System.Drawing.Point(-40, 0);
            this.btnDashboard1.ImageTint = System.Drawing.Color.White;
            this.btnDashboard1.IsToggleButton = false;
            this.btnDashboard1.IsToggled = false;
            this.btnDashboard1.Location = new System.Drawing.Point(0, 45);
            this.btnDashboard1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDashboard1.Name = "btnDashboard1";
            this.btnDashboard1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnDashboard1.NormalForeColor = System.Drawing.Color.White;
            this.btnDashboard1.NormalOutline = System.Drawing.Color.Empty;
            this.btnDashboard1.OutlineThickness = 2F;
            this.btnDashboard1.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnDashboard1.PressedForeColor = System.Drawing.Color.White;
            this.btnDashboard1.PressedImageTint = System.Drawing.Color.White;
            this.btnDashboard1.PressedOutline = System.Drawing.Color.Empty;
            this.btnDashboard1.Rounding = new System.Windows.Forms.Padding(0);
            this.btnDashboard1.Size = new System.Drawing.Size(280, 55);
            this.btnDashboard1.TabIndex = 0;
            this.btnDashboard1.TextAutoCenter = true;
            this.btnDashboard1.TextOffset = new System.Drawing.Point(-30, 0);
            this.btnDashboard1.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelSearchBar
            // 
            this.panelSearchBar.BackColor = System.Drawing.Color.White;
            this.panelSearchBar.BackColor2 = System.Drawing.Color.White;
            this.panelSearchBar.BorderColor = System.Drawing.Color.Black;
            borderRadius2.BottomLeft = 15;
            borderRadius2.BottomRight = 15;
            borderRadius2.TopLeft = 15;
            borderRadius2.TopRight = 15;
            this.panelSearchBar.BorderRadius = borderRadius2;
            this.panelSearchBar.BorderThickness = 0;
            this.panelSearchBar.Controls.Add(this.txtSearch);
            this.panelSearchBar.Controls.Add(this.lblSearchIcon);
            this.panelSearchBar.Controls.Add(this.cmbFilterStatus);
            this.panelSearchBar.Controls.Add(this.cmbFilterScholarship);
            this.panelSearchBar.Controls.Add(this.lblFilter);
            this.panelSearchBar.Controls.Add(this.btnAddScholar);
            this.panelSearchBar.Location = new System.Drawing.Point(301, 180);
            this.panelSearchBar.Name = "panelSearchBar";
            this.panelSearchBar.Size = new System.Drawing.Size(1376, 75);
            this.panelSearchBar.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(283, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(658, 27);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Text = "Search scholar...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSearchIcon.ForeColor = System.Drawing.Color.Gray;
            this.lblSearchIcon.Location = new System.Drawing.Point(256, 28);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(32, 21);
            this.lblSearchIcon.TabIndex = 4;
            this.lblSearchIcon.Text = "🔍";
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Items.AddRange(new object[] {
            "All Status",
            "Active",
            "Inactive",
            "Graduated",
            "Terminated"});
            this.cmbFilterStatus.Location = new System.Drawing.Point(1218, 26);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(130, 28);
            this.cmbFilterStatus.TabIndex = 1;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);
            // 
            // cmbFilterScholarship
            // 
            this.cmbFilterScholarship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterScholarship.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbFilterScholarship.FormattingEnabled = true;
            this.cmbFilterScholarship.Location = new System.Drawing.Point(1028, 26);
            this.cmbFilterScholarship.Name = "cmbFilterScholarship";
            this.cmbFilterScholarship.Size = new System.Drawing.Size(170, 28);
            this.cmbFilterScholarship.TabIndex = 1;
            this.cmbFilterScholarship.SelectedIndexChanged += new System.EventHandler(this.cmbFilterScholarship_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblFilter.Location = new System.Drawing.Point(973, 30);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(46, 18);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter:";
            // 
            // btnAddScholar
            // 
            this.btnAddScholar.ButtonText = "+ Add New Scholar";
            this.btnAddScholar.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnAddScholar.CheckedForeColor = System.Drawing.Color.White;
            this.btnAddScholar.CheckedImageTint = System.Drawing.Color.White;
            this.btnAddScholar.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnAddScholar.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddScholar.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddScholar.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.btnAddScholar.HoverForeColor = System.Drawing.Color.White;
            this.btnAddScholar.HoverImage = null;
            this.btnAddScholar.HoverImageTint = System.Drawing.Color.White;
            this.btnAddScholar.HoverOutline = System.Drawing.Color.Empty;
            this.btnAddScholar.Image = null;
            this.btnAddScholar.ImageAutoCenter = true;
            this.btnAddScholar.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnAddScholar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAddScholar.ImageTint = System.Drawing.Color.White;
            this.btnAddScholar.IsToggleButton = false;
            this.btnAddScholar.IsToggled = false;
            this.btnAddScholar.Location = new System.Drawing.Point(24, 21);
            this.btnAddScholar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAddScholar.Name = "btnAddScholar";
            this.btnAddScholar.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnAddScholar.NormalForeColor = System.Drawing.Color.White;
            this.btnAddScholar.NormalOutline = System.Drawing.Color.Empty;
            this.btnAddScholar.OutlineThickness = 2F;
            this.btnAddScholar.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnAddScholar.PressedForeColor = System.Drawing.Color.White;
            this.btnAddScholar.PressedImageTint = System.Drawing.Color.White;
            this.btnAddScholar.PressedOutline = System.Drawing.Color.Empty;
            this.btnAddScholar.Rounding = new System.Windows.Forms.Padding(8);
            this.btnAddScholar.Size = new System.Drawing.Size(207, 35);
            this.btnAddScholar.TabIndex = 0;
            this.btnAddScholar.TextAutoCenter = true;
            this.btnAddScholar.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAddScholar.Click += new System.EventHandler(this.btnAddScholar_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.panelHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.panelHeader.BorderColor = System.Drawing.Color.Black;
            borderRadius3.BottomLeft = 1;
            borderRadius3.BottomRight = 1;
            borderRadius3.TopLeft = 1;
            borderRadius3.TopRight = 1;
            this.panelHeader.BorderRadius = borderRadius3;
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
            this.panelHeader.TabIndex = 7;
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
            this.btnLogout.Location = new System.Drawing.Point(1567, 18);
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
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.BackColor2 = System.Drawing.Color.White;
            this.panelForm.BorderColor = System.Drawing.Color.Black;
            borderRadius4.BottomLeft = 15;
            borderRadius4.BottomRight = 15;
            borderRadius4.TopLeft = 15;
            borderRadius4.TopRight = 15;
            this.panelForm.BorderRadius = borderRadius4;
            this.panelForm.BorderThickness = 0;
            this.panelForm.Controls.Add(this.lblFormTitle);
            this.panelForm.Controls.Add(this.lblSectionBasic);
            this.panelForm.Controls.Add(this.lblSectionAcademic);
            this.panelForm.Controls.Add(this.lblSectionScholarship);
            this.panelForm.Controls.Add(this.txtFirstName);
            this.panelForm.Controls.Add(this.lblFirstName);
            this.panelForm.Controls.Add(this.txtLastName);
            this.panelForm.Controls.Add(this.lblLastName);
            this.panelForm.Controls.Add(this.txtMiddleName);
            this.panelForm.Controls.Add(this.lblMiddleName);
            this.panelForm.Controls.Add(this.txtEmail);
            this.panelForm.Controls.Add(this.lblEmail);
            this.panelForm.Controls.Add(this.txtContactNumber);
            this.panelForm.Controls.Add(this.lblContact);
            this.panelForm.Controls.Add(this.cmbCourse);
            this.panelForm.Controls.Add(this.lblCourse);
            this.panelForm.Controls.Add(this.cmbYearLevel);
            this.panelForm.Controls.Add(this.lblYearLevel);
            this.panelForm.Controls.Add(this.cmbScholarshipType);
            this.panelForm.Controls.Add(this.lblScholarship);
            this.panelForm.Controls.Add(this.dtpEnrollmentDate);
            this.panelForm.Controls.Add(this.lblEnrollmentDate);
            this.panelForm.Controls.Add(this.dtpExpectedGraduation);
            this.panelForm.Controls.Add(this.lblExpectedGrad);
            this.panelForm.Controls.Add(this.cmbStatus);
            this.panelForm.Controls.Add(this.lblStatus);
            this.panelForm.Controls.Add(this.txtScholarNumber);
            this.panelForm.Controls.Add(this.lblScholarNumber);
            this.panelForm.Controls.Add(this.btnCancel);
            this.panelForm.Controls.Add(this.btnDelete);
            this.panelForm.Controls.Add(this.btnUpdate);
            this.panelForm.Controls.Add(this.btnSave);
            this.panelForm.Location = new System.Drawing.Point(1292, 275);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(385, 721);
            this.panelForm.TabIndex = 5;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblFormTitle.Location = new System.Drawing.Point(20, 20);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(218, 26);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Scholar Information";
            // 
            // lblSectionBasic
            // 
            this.lblSectionBasic.AutoSize = true;
            this.lblSectionBasic.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblSectionBasic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblSectionBasic.Location = new System.Drawing.Point(20, 60);
            this.lblSectionBasic.Name = "lblSectionBasic";
            this.lblSectionBasic.Size = new System.Drawing.Size(134, 18);
            this.lblSectionBasic.TabIndex = 1;
            this.lblSectionBasic.Text = "Basic Information";
            // 
            // lblSectionAcademic
            // 
            this.lblSectionAcademic.AutoSize = true;
            this.lblSectionAcademic.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblSectionAcademic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblSectionAcademic.Location = new System.Drawing.Point(20, 310);
            this.lblSectionAcademic.Name = "lblSectionAcademic";
            this.lblSectionAcademic.Size = new System.Drawing.Size(140, 18);
            this.lblSectionAcademic.TabIndex = 1;
            this.lblSectionAcademic.Text = "Academic Details";
            // 
            // lblSectionScholarship
            // 
            this.lblSectionScholarship.AutoSize = true;
            this.lblSectionScholarship.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblSectionScholarship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblSectionScholarship.Location = new System.Drawing.Point(20, 462);
            this.lblSectionScholarship.Name = "lblSectionScholarship";
            this.lblSectionScholarship.Size = new System.Drawing.Size(146, 18);
            this.lblSectionScholarship.TabIndex = 1;
            this.lblSectionScholarship.Text = "Scholarship Details";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtFirstName.Location = new System.Drawing.Point(25, 110);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(160, 25);
            this.txtFirstName.TabIndex = 2;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblFirstName.Location = new System.Drawing.Point(22, 90);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(79, 19);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "First Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtLastName.Location = new System.Drawing.Point(200, 110);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(160, 25);
            this.txtLastName.TabIndex = 2;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblLastName.Location = new System.Drawing.Point(197, 90);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(81, 19);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtMiddleName.Location = new System.Drawing.Point(25, 160);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(160, 25);
            this.txtMiddleName.TabIndex = 2;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblMiddleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblMiddleName.Location = new System.Drawing.Point(22, 140);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(103, 19);
            this.lblMiddleName.TabIndex = 3;
            this.lblMiddleName.Text = "Middle Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtEmail.Location = new System.Drawing.Point(25, 210);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(335, 25);
            this.txtEmail.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblEmail.Location = new System.Drawing.Point(22, 190);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 19);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtContactNumber.Location = new System.Drawing.Point(25, 260);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(200, 25);
            this.txtContactNumber.TabIndex = 2;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblContact.Location = new System.Drawing.Point(22, 240);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(126, 19);
            this.lblContact.TabIndex = 3;
            this.lblContact.Text = "Contact Number";
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(25, 360);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(335, 28);
            this.cmbCourse.TabIndex = 4;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblCourse.Location = new System.Drawing.Point(22, 340);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(56, 19);
            this.lblCourse.TabIndex = 3;
            this.lblCourse.Text = "Course";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearLevel.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Items.AddRange(new object[] {
            "1st Year",
            "2nd Year",
            "3rd Year",
            "4th Year"});
            this.cmbYearLevel.Location = new System.Drawing.Point(25, 420);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(160, 28);
            this.cmbYearLevel.TabIndex = 4;
            // 
            // lblYearLevel
            // 
            this.lblYearLevel.AutoSize = true;
            this.lblYearLevel.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblYearLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblYearLevel.Location = new System.Drawing.Point(22, 400);
            this.lblYearLevel.Name = "lblYearLevel";
            this.lblYearLevel.Size = new System.Drawing.Size(78, 19);
            this.lblYearLevel.TabIndex = 3;
            this.lblYearLevel.Text = "Year Level";
            // 
            // cmbScholarshipType
            // 
            this.cmbScholarshipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScholarshipType.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbScholarshipType.FormattingEnabled = true;
            this.cmbScholarshipType.Location = new System.Drawing.Point(25, 507);
            this.cmbScholarshipType.Name = "cmbScholarshipType";
            this.cmbScholarshipType.Size = new System.Drawing.Size(335, 28);
            this.cmbScholarshipType.TabIndex = 4;
            // 
            // lblScholarship
            // 
            this.lblScholarship.AutoSize = true;
            this.lblScholarship.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblScholarship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblScholarship.Location = new System.Drawing.Point(22, 487);
            this.lblScholarship.Name = "lblScholarship";
            this.lblScholarship.Size = new System.Drawing.Size(123, 19);
            this.lblScholarship.TabIndex = 3;
            this.lblScholarship.Text = "Scholarship Type";
            // 
            // dtpEnrollmentDate
            // 
            this.dtpEnrollmentDate.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.dtpEnrollmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnrollmentDate.Location = new System.Drawing.Point(25, 567);
            this.dtpEnrollmentDate.Name = "dtpEnrollmentDate";
            this.dtpEnrollmentDate.Size = new System.Drawing.Size(160, 25);
            this.dtpEnrollmentDate.TabIndex = 5;
            // 
            // lblEnrollmentDate
            // 
            this.lblEnrollmentDate.AutoSize = true;
            this.lblEnrollmentDate.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblEnrollmentDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblEnrollmentDate.Location = new System.Drawing.Point(22, 547);
            this.lblEnrollmentDate.Name = "lblEnrollmentDate";
            this.lblEnrollmentDate.Size = new System.Drawing.Size(119, 19);
            this.lblEnrollmentDate.TabIndex = 3;
            this.lblEnrollmentDate.Text = "Enrollment Date";
            // 
            // dtpExpectedGraduation
            // 
            this.dtpExpectedGraduation.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.dtpExpectedGraduation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpectedGraduation.Location = new System.Drawing.Point(200, 567);
            this.dtpExpectedGraduation.Name = "dtpExpectedGraduation";
            this.dtpExpectedGraduation.Size = new System.Drawing.Size(160, 25);
            this.dtpExpectedGraduation.TabIndex = 5;
            // 
            // lblExpectedGrad
            // 
            this.lblExpectedGrad.AutoSize = true;
            this.lblExpectedGrad.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblExpectedGrad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblExpectedGrad.Location = new System.Drawing.Point(197, 547);
            this.lblExpectedGrad.Name = "lblExpectedGrad";
            this.lblExpectedGrad.Size = new System.Drawing.Size(161, 19);
            this.lblExpectedGrad.TabIndex = 3;
            this.lblExpectedGrad.Text = "Expected Graduation";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            "Graduated",
            "Terminated"});
            this.cmbStatus.Location = new System.Drawing.Point(25, 627);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(160, 28);
            this.cmbStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblStatus.Location = new System.Drawing.Point(22, 607);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 19);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status";
            // 
            // txtScholarNumber
            // 
            this.txtScholarNumber.Enabled = false;
            this.txtScholarNumber.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtScholarNumber.Location = new System.Drawing.Point(200, 627);
            this.txtScholarNumber.Name = "txtScholarNumber";
            this.txtScholarNumber.Size = new System.Drawing.Size(160, 25);
            this.txtScholarNumber.TabIndex = 2;
            // 
            // lblScholarNumber
            // 
            this.lblScholarNumber.AutoSize = true;
            this.lblScholarNumber.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblScholarNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblScholarNumber.Location = new System.Drawing.Point(197, 607);
            this.lblScholarNumber.Name = "lblScholarNumber";
            this.lblScholarNumber.Size = new System.Drawing.Size(119, 19);
            this.lblScholarNumber.TabIndex = 3;
            this.lblScholarNumber.Text = "Scholar Number";
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnCancel.CheckedForeColor = System.Drawing.Color.White;
            this.btnCancel.CheckedImageTint = System.Drawing.Color.White;
            this.btnCancel.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnCancel.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnCancel.HoverForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverImage = null;
            this.btnCancel.HoverImageTint = System.Drawing.Color.White;
            this.btnCancel.HoverOutline = System.Drawing.Color.Empty;
            this.btnCancel.Image = null;
            this.btnCancel.ImageAutoCenter = true;
            this.btnCancel.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnCancel.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnCancel.ImageTint = System.Drawing.Color.White;
            this.btnCancel.IsToggleButton = false;
            this.btnCancel.IsToggled = false;
            this.btnCancel.Location = new System.Drawing.Point(290, 668);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnCancel.NormalForeColor = System.Drawing.Color.White;
            this.btnCancel.NormalOutline = System.Drawing.Color.Empty;
            this.btnCancel.OutlineThickness = 2F;
            this.btnCancel.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnCancel.PressedForeColor = System.Drawing.Color.White;
            this.btnCancel.PressedImageTint = System.Drawing.Color.White;
            this.btnCancel.PressedOutline = System.Drawing.Color.Empty;
            this.btnCancel.Rounding = new System.Windows.Forms.Padding(8);
            this.btnCancel.Size = new System.Drawing.Size(70, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TextAutoCenter = true;
            this.btnCancel.TextOffset = new System.Drawing.Point(0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonText = "Delete";
            this.btnDelete.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDelete.CheckedForeColor = System.Drawing.Color.White;
            this.btnDelete.CheckedImageTint = System.Drawing.Color.White;
            this.btnDelete.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnDelete.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnDelete.HoverForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverImage = null;
            this.btnDelete.HoverImageTint = System.Drawing.Color.White;
            this.btnDelete.HoverOutline = System.Drawing.Color.Empty;
            this.btnDelete.Image = null;
            this.btnDelete.ImageAutoCenter = true;
            this.btnDelete.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnDelete.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnDelete.ImageTint = System.Drawing.Color.White;
            this.btnDelete.IsToggleButton = false;
            this.btnDelete.IsToggled = false;
            this.btnDelete.Location = new System.Drawing.Point(180, 668);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDelete.NormalForeColor = System.Drawing.Color.White;
            this.btnDelete.NormalOutline = System.Drawing.Color.Empty;
            this.btnDelete.OutlineThickness = 2F;
            this.btnDelete.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnDelete.PressedForeColor = System.Drawing.Color.White;
            this.btnDelete.PressedImageTint = System.Drawing.Color.White;
            this.btnDelete.PressedOutline = System.Drawing.Color.Empty;
            this.btnDelete.Rounding = new System.Windows.Forms.Padding(8);
            this.btnDelete.Size = new System.Drawing.Size(95, 40);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.TextAutoCenter = true;
            this.btnDelete.TextOffset = new System.Drawing.Point(0, 0);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ButtonText = "Update";
            this.btnUpdate.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnUpdate.CheckedForeColor = System.Drawing.Color.White;
            this.btnUpdate.CheckedImageTint = System.Drawing.Color.White;
            this.btnUpdate.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnUpdate.HoverForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverImage = null;
            this.btnUpdate.HoverImageTint = System.Drawing.Color.White;
            this.btnUpdate.HoverOutline = System.Drawing.Color.Empty;
            this.btnUpdate.Image = null;
            this.btnUpdate.ImageAutoCenter = true;
            this.btnUpdate.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnUpdate.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnUpdate.ImageTint = System.Drawing.Color.White;
            this.btnUpdate.IsToggleButton = false;
            this.btnUpdate.IsToggled = false;
            this.btnUpdate.Location = new System.Drawing.Point(95, 668);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnUpdate.NormalForeColor = System.Drawing.Color.White;
            this.btnUpdate.NormalOutline = System.Drawing.Color.Empty;
            this.btnUpdate.OutlineThickness = 2F;
            this.btnUpdate.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnUpdate.PressedForeColor = System.Drawing.Color.White;
            this.btnUpdate.PressedImageTint = System.Drawing.Color.White;
            this.btnUpdate.PressedOutline = System.Drawing.Color.Empty;
            this.btnUpdate.Rounding = new System.Windows.Forms.Padding(8);
            this.btnUpdate.Size = new System.Drawing.Size(75, 40);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.TextAutoCenter = true;
            this.btnUpdate.TextOffset = new System.Drawing.Point(0, 0);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.ButtonText = "Save";
            this.btnSave.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.btnSave.CheckedForeColor = System.Drawing.Color.White;
            this.btnSave.CheckedImageTint = System.Drawing.Color.White;
            this.btnSave.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnSave.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.btnSave.HoverForeColor = System.Drawing.Color.White;
            this.btnSave.HoverImage = null;
            this.btnSave.HoverImageTint = System.Drawing.Color.White;
            this.btnSave.HoverOutline = System.Drawing.Color.Empty;
            this.btnSave.Image = null;
            this.btnSave.ImageAutoCenter = true;
            this.btnSave.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSave.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSave.ImageTint = System.Drawing.Color.White;
            this.btnSave.IsToggleButton = false;
            this.btnSave.IsToggled = false;
            this.btnSave.Location = new System.Drawing.Point(25, 668);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnSave.NormalForeColor = System.Drawing.Color.White;
            this.btnSave.NormalOutline = System.Drawing.Color.Empty;
            this.btnSave.OutlineThickness = 2F;
            this.btnSave.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnSave.PressedForeColor = System.Drawing.Color.White;
            this.btnSave.PressedImageTint = System.Drawing.Color.White;
            this.btnSave.PressedOutline = System.Drawing.Color.Empty;
            this.btnSave.Rounding = new System.Windows.Forms.Padding(8);
            this.btnSave.Size = new System.Drawing.Size(60, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.TextAutoCenter = true;
            this.btnSave.TextOffset = new System.Drawing.Point(0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmScholarManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1700, 1050);
            this.Controls.Add(this.panelContent);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScholarManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scholar Management - ScholarAid";
            this.panelScholarList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScholars)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelSearchBar.ResumeLayout(false);
            this.panelSearchBar.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SATAUiFramework.SATAPanel panelScholarList;
        private System.Windows.Forms.DataGridView dgvScholars;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScholarID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScholarNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYearLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScholarship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private SATAUiFramework.SATAPanel panelSearchBar;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterScholarship;
        private System.Windows.Forms.Label lblFilter;
        private FrameworkTest.SATAButton btnAddScholar;
        private System.Windows.Forms.Panel panelContent;
        private SATAUiFramework.SATAPanel panelForm;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblSectionBasic;
        private System.Windows.Forms.Label lblSectionAcademic;
        private System.Windows.Forms.Label lblSectionScholarship;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.Label lblYearLevel;
        private System.Windows.Forms.ComboBox cmbScholarshipType;
        private System.Windows.Forms.Label lblScholarship;
        private System.Windows.Forms.DateTimePicker dtpEnrollmentDate;
        private System.Windows.Forms.Label lblEnrollmentDate;
        private System.Windows.Forms.DateTimePicker dtpExpectedGraduation;
        private System.Windows.Forms.Label lblExpectedGrad;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtScholarNumber;
        private System.Windows.Forms.Label lblScholarNumber;
        private FrameworkTest.SATAButton btnCancel;
        private FrameworkTest.SATAButton btnDelete;
        private FrameworkTest.SATAButton btnUpdate;
        private FrameworkTest.SATAButton btnSave;
        private System.Windows.Forms.Panel panelSidebar;
        private FrameworkTest.SATAButton btnReminder1;
        private FrameworkTest.SATAButton btnActivityLog1;
        private FrameworkTest.SATAButton btnReports1;
        private FrameworkTest.SATAButton btnPayroll1;
        private FrameworkTest.SATAButton btnScholarMgmt1;
        private FrameworkTest.SATAButton btnDashboard1;
        private SATAUiFramework.SATAPanel panelHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblBrand;
        private FrameworkTest.SATAButton btnLogout;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblGreeting;
    }
}