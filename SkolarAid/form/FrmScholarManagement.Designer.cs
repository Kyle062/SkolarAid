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
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius3 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius4 = new SATAUiFramework.BorderRadius();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScholarManagement));
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSearchBar = new SATAUiFramework.SATAPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.cmbFilterCourse = new System.Windows.Forms.ComboBox();
            this.cmbFilterScholarship = new System.Windows.Forms.ComboBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.btnAddScholar = new FrameworkTest.SATAButton();
            this.panelScholarList = new SATAUiFramework.SATAPanel();
            this.dgvScholars = new System.Windows.Forms.DataGridView();
            this.panelForm = new SATAUiFramework.SATAPanel();
            this.btnCancel = new FrameworkTest.SATAButton();
            this.btnDelete = new FrameworkTest.SATAButton();
            this.btnUpdate = new FrameworkTest.SATAButton();
            this.btnSave = new FrameworkTest.SATAButton();
            this.labelScholarNumber = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelExpectedGrad = new System.Windows.Forms.Label();
            this.labelEnrollmentDate = new System.Windows.Forms.Label();
            this.labelScholarship = new System.Windows.Forms.Label();
            this.labelYearLevel = new System.Windows.Forms.Label();
            this.labelCourse = new System.Windows.Forms.Label();
            this.labelContact = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelMiddleName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.txtScholarNumber = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.dtpExpectedGraduation = new System.Windows.Forms.DateTimePicker();
            this.dtpEnrollmentDate = new System.Windows.Forms.DateTimePicker();
            this.cmbScholarshipType = new System.Windows.Forms.ComboBox();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelHeaderTitle = new System.Windows.Forms.Label();
            this.sataButtonLogout = new FrameworkTest.SATAButton();
            this.panelHeader = new SATAUiFramework.SATAPanel();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.sataButton6 = new FrameworkTest.SATAButton();
            this.sataButton5 = new FrameworkTest.SATAButton();
            this.sataButton4 = new FrameworkTest.SATAButton();
            this.sataButton3 = new FrameworkTest.SATAButton();
            this.sataButton2 = new FrameworkTest.SATAButton();
            this.label1 = new System.Windows.Forms.Label();
            this.sataButton1 = new FrameworkTest.SATAButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ScholarAid = new System.Windows.Forms.Label();
            this.panelContent.SuspendLayout();
            this.panelSearchBar.SuspendLayout();
            this.panelScholarList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScholars)).BeginInit();
            this.panelForm.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.panelSearchBar);
            this.panelContent.Controls.Add(this.panelScholarList);
            this.panelContent.Controls.Add(this.panelForm);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(288, 72);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1312, 878);
            this.panelContent.TabIndex = 4;
            // 
            // panelSearchBar
            // 
            this.panelSearchBar.BackColor = System.Drawing.Color.White;
            this.panelSearchBar.BackColor2 = System.Drawing.Color.White;
            this.panelSearchBar.BorderColor = System.Drawing.Color.LightGray;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.panelSearchBar.BorderRadius = borderRadius1;
            this.panelSearchBar.BorderThickness = 1;
            this.panelSearchBar.Controls.Add(this.txtSearch);
            this.panelSearchBar.Controls.Add(this.cmbFilterStatus);
            this.panelSearchBar.Controls.Add(this.cmbFilterCourse);
            this.panelSearchBar.Controls.Add(this.cmbFilterScholarship);
            this.panelSearchBar.Controls.Add(this.labelFilter);
            this.panelSearchBar.Controls.Add(this.btnAddScholar);
            this.panelSearchBar.Location = new System.Drawing.Point(25, 20);
            this.panelSearchBar.Name = "panelSearchBar";
            this.panelSearchBar.Size = new System.Drawing.Size(1260, 70);
            this.panelSearchBar.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtSearch.Location = new System.Drawing.Point(195, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 27);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Text = "Search scholar...";
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
            this.cmbFilterStatus.Location = new System.Drawing.Point(880, 20);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbFilterStatus.TabIndex = 1;
            // 
            // cmbFilterCourse
            // 
            this.cmbFilterCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCourse.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.cmbFilterCourse.FormattingEnabled = true;
            this.cmbFilterCourse.Items.AddRange(new object[] {
            "All Courses",
            "BSIT",
            "BSCS",
            "BSIS",
            "BSBA",
            "BSEd"});
            this.cmbFilterCourse.Location = new System.Drawing.Point(1040, 20);
            this.cmbFilterCourse.Name = "cmbFilterCourse";
            this.cmbFilterCourse.Size = new System.Drawing.Size(120, 25);
            this.cmbFilterCourse.TabIndex = 1;
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
            this.cmbFilterScholarship.Location = new System.Drawing.Point(720, 20);
            this.cmbFilterScholarship.Name = "cmbFilterScholarship";
            this.cmbFilterScholarship.Size = new System.Drawing.Size(150, 25);
            this.cmbFilterScholarship.TabIndex = 1;
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.labelFilter.ForeColor = System.Drawing.Color.Black;
            this.labelFilter.Location = new System.Drawing.Point(670, 23);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(44, 17);
            this.labelFilter.TabIndex = 0;
            this.labelFilter.Text = "Filter:";
            // 
            // btnAddScholar
            // 
            this.btnAddScholar.ButtonText = "+ Add New Scholar";
            this.btnAddScholar.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnAddScholar.CheckedForeColor = System.Drawing.Color.White;
            this.btnAddScholar.CheckedImageTint = System.Drawing.Color.White;
            this.btnAddScholar.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddScholar.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddScholar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddScholar.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
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
            this.btnAddScholar.Location = new System.Drawing.Point(24, 20);
            this.btnAddScholar.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnAddScholar.Name = "btnAddScholar";
            this.btnAddScholar.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnAddScholar.NormalForeColor = System.Drawing.Color.White;
            this.btnAddScholar.NormalOutline = System.Drawing.Color.Empty;
            this.btnAddScholar.OutlineThickness = 2F;
            this.btnAddScholar.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnAddScholar.PressedForeColor = System.Drawing.Color.White;
            this.btnAddScholar.PressedImageTint = System.Drawing.Color.White;
            this.btnAddScholar.PressedOutline = System.Drawing.Color.Empty;
            this.btnAddScholar.Rounding = new System.Windows.Forms.Padding(5);
            this.btnAddScholar.Size = new System.Drawing.Size(150, 35);
            this.btnAddScholar.TabIndex = 0;
            this.btnAddScholar.TextAutoCenter = true;
            this.btnAddScholar.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // panelScholarList
            // 
            this.panelScholarList.BackColor = System.Drawing.Color.White;
            this.panelScholarList.BackColor2 = System.Drawing.Color.White;
            this.panelScholarList.BorderColor = System.Drawing.Color.LightGray;
            borderRadius2.BottomLeft = 10;
            borderRadius2.BottomRight = 10;
            borderRadius2.TopLeft = 10;
            borderRadius2.TopRight = 10;
            this.panelScholarList.BorderRadius = borderRadius2;
            this.panelScholarList.BorderThickness = 1;
            this.panelScholarList.Controls.Add(this.dgvScholars);
            this.panelScholarList.Location = new System.Drawing.Point(25, 105);
            this.panelScholarList.Name = "panelScholarList";
            this.panelScholarList.Size = new System.Drawing.Size(780, 740);
            this.panelScholarList.TabIndex = 1;
            // 
            // dgvScholars
            // 
            this.dgvScholars.AllowUserToAddRows = false;
            this.dgvScholars.AllowUserToDeleteRows = false;
            this.dgvScholars.BackgroundColor = System.Drawing.Color.White;
            this.dgvScholars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvScholars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScholars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScholars.Location = new System.Drawing.Point(0, 0);
            this.dgvScholars.Name = "dgvScholars";
            this.dgvScholars.ReadOnly = true;
            this.dgvScholars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScholars.Size = new System.Drawing.Size(780, 740);
            this.dgvScholars.TabIndex = 0;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.BackColor2 = System.Drawing.Color.White;
            this.panelForm.BorderColor = System.Drawing.Color.LightGray;
            borderRadius3.BottomLeft = 10;
            borderRadius3.BottomRight = 10;
            borderRadius3.TopLeft = 10;
            borderRadius3.TopRight = 10;
            this.panelForm.BorderRadius = borderRadius3;
            this.panelForm.BorderThickness = 1;
            this.panelForm.Controls.Add(this.btnCancel);
            this.panelForm.Controls.Add(this.btnDelete);
            this.panelForm.Controls.Add(this.btnUpdate);
            this.panelForm.Controls.Add(this.btnSave);
            this.panelForm.Controls.Add(this.labelScholarNumber);
            this.panelForm.Controls.Add(this.labelStatus);
            this.panelForm.Controls.Add(this.labelExpectedGrad);
            this.panelForm.Controls.Add(this.labelEnrollmentDate);
            this.panelForm.Controls.Add(this.labelScholarship);
            this.panelForm.Controls.Add(this.labelYearLevel);
            this.panelForm.Controls.Add(this.labelCourse);
            this.panelForm.Controls.Add(this.labelContact);
            this.panelForm.Controls.Add(this.labelEmail);
            this.panelForm.Controls.Add(this.labelMiddleName);
            this.panelForm.Controls.Add(this.labelLastName);
            this.panelForm.Controls.Add(this.labelFirstName);
            this.panelForm.Controls.Add(this.txtScholarNumber);
            this.panelForm.Controls.Add(this.cmbStatus);
            this.panelForm.Controls.Add(this.dtpExpectedGraduation);
            this.panelForm.Controls.Add(this.dtpEnrollmentDate);
            this.panelForm.Controls.Add(this.cmbScholarshipType);
            this.panelForm.Controls.Add(this.cmbYearLevel);
            this.panelForm.Controls.Add(this.cmbCourse);
            this.panelForm.Controls.Add(this.txtContactNumber);
            this.panelForm.Controls.Add(this.txtEmail);
            this.panelForm.Controls.Add(this.txtMiddleName);
            this.panelForm.Controls.Add(this.txtLastName);
            this.panelForm.Controls.Add(this.txtFirstName);
            this.panelForm.Controls.Add(this.labelFormTitle);
            this.panelForm.Location = new System.Drawing.Point(820, 105);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(465, 740);
            this.panelForm.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnCancel.CheckedForeColor = System.Drawing.Color.White;
            this.btnCancel.CheckedImageTint = System.Drawing.Color.White;
            this.btnCancel.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
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
            this.btnCancel.Location = new System.Drawing.Point(370, 620);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnCancel.NormalForeColor = System.Drawing.Color.White;
            this.btnCancel.NormalOutline = System.Drawing.Color.Empty;
            this.btnCancel.OutlineThickness = 2F;
            this.btnCancel.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnCancel.PressedForeColor = System.Drawing.Color.White;
            this.btnCancel.PressedImageTint = System.Drawing.Color.White;
            this.btnCancel.PressedOutline = System.Drawing.Color.Empty;
            this.btnCancel.Rounding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(70, 40);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.TextAutoCenter = true;
            this.btnCancel.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonText = "Delete";
            this.btnDelete.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnDelete.CheckedForeColor = System.Drawing.Color.White;
            this.btnDelete.CheckedImageTint = System.Drawing.Color.White;
            this.btnDelete.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDelete.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
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
            this.btnDelete.Location = new System.Drawing.Point(255, 620);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.NormalForeColor = System.Drawing.Color.White;
            this.btnDelete.NormalOutline = System.Drawing.Color.Empty;
            this.btnDelete.OutlineThickness = 2F;
            this.btnDelete.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnDelete.PressedForeColor = System.Drawing.Color.White;
            this.btnDelete.PressedImageTint = System.Drawing.Color.White;
            this.btnDelete.PressedOutline = System.Drawing.Color.Empty;
            this.btnDelete.Rounding = new System.Windows.Forms.Padding(5);
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.TextAutoCenter = true;
            this.btnDelete.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ButtonText = "Update";
            this.btnUpdate.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnUpdate.CheckedForeColor = System.Drawing.Color.White;
            this.btnUpdate.CheckedImageTint = System.Drawing.Color.White;
            this.btnUpdate.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnUpdate.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
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
            this.btnUpdate.Location = new System.Drawing.Point(140, 620);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnUpdate.NormalForeColor = System.Drawing.Color.White;
            this.btnUpdate.NormalOutline = System.Drawing.Color.Empty;
            this.btnUpdate.OutlineThickness = 2F;
            this.btnUpdate.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnUpdate.PressedForeColor = System.Drawing.Color.White;
            this.btnUpdate.PressedImageTint = System.Drawing.Color.White;
            this.btnUpdate.PressedOutline = System.Drawing.Color.Empty;
            this.btnUpdate.Rounding = new System.Windows.Forms.Padding(5);
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.TextAutoCenter = true;
            this.btnUpdate.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnSave
            // 
            this.btnSave.ButtonText = "Save";
            this.btnSave.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnSave.CheckedForeColor = System.Drawing.Color.White;
            this.btnSave.CheckedImageTint = System.Drawing.Color.White;
            this.btnSave.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
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
            this.btnSave.Location = new System.Drawing.Point(25, 620);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btnSave.NormalForeColor = System.Drawing.Color.White;
            this.btnSave.NormalOutline = System.Drawing.Color.Empty;
            this.btnSave.OutlineThickness = 2F;
            this.btnSave.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnSave.PressedForeColor = System.Drawing.Color.White;
            this.btnSave.PressedImageTint = System.Drawing.Color.White;
            this.btnSave.PressedOutline = System.Drawing.Color.Empty;
            this.btnSave.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 25;
            this.btnSave.TextAutoCenter = true;
            this.btnSave.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // labelScholarNumber
            // 
            this.labelScholarNumber.AutoSize = true;
            this.labelScholarNumber.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelScholarNumber.ForeColor = System.Drawing.Color.Gray;
            this.labelScholarNumber.Location = new System.Drawing.Point(240, 540);
            this.labelScholarNumber.Name = "labelScholarNumber";
            this.labelScholarNumber.Size = new System.Drawing.Size(119, 19);
            this.labelScholarNumber.TabIndex = 24;
            this.labelScholarNumber.Text = "Scholar Number";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelStatus.ForeColor = System.Drawing.Color.Gray;
            this.labelStatus.Location = new System.Drawing.Point(25, 540);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(50, 19);
            this.labelStatus.TabIndex = 23;
            this.labelStatus.Text = "Status";
            // 
            // labelExpectedGrad
            // 
            this.labelExpectedGrad.AutoSize = true;
            this.labelExpectedGrad.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelExpectedGrad.ForeColor = System.Drawing.Color.Gray;
            this.labelExpectedGrad.Location = new System.Drawing.Point(240, 475);
            this.labelExpectedGrad.Name = "labelExpectedGrad";
            this.labelExpectedGrad.Size = new System.Drawing.Size(161, 19);
            this.labelExpectedGrad.TabIndex = 22;
            this.labelExpectedGrad.Text = "Expected Graduation";
            // 
            // labelEnrollmentDate
            // 
            this.labelEnrollmentDate.AutoSize = true;
            this.labelEnrollmentDate.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelEnrollmentDate.ForeColor = System.Drawing.Color.Gray;
            this.labelEnrollmentDate.Location = new System.Drawing.Point(25, 475);
            this.labelEnrollmentDate.Name = "labelEnrollmentDate";
            this.labelEnrollmentDate.Size = new System.Drawing.Size(119, 19);
            this.labelEnrollmentDate.TabIndex = 21;
            this.labelEnrollmentDate.Text = "Enrollment Date";
            // 
            // labelScholarship
            // 
            this.labelScholarship.AutoSize = true;
            this.labelScholarship.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelScholarship.ForeColor = System.Drawing.Color.Gray;
            this.labelScholarship.Location = new System.Drawing.Point(25, 405);
            this.labelScholarship.Name = "labelScholarship";
            this.labelScholarship.Size = new System.Drawing.Size(123, 19);
            this.labelScholarship.TabIndex = 20;
            this.labelScholarship.Text = "Scholarship Type";
            // 
            // labelYearLevel
            // 
            this.labelYearLevel.AutoSize = true;
            this.labelYearLevel.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelYearLevel.ForeColor = System.Drawing.Color.Gray;
            this.labelYearLevel.Location = new System.Drawing.Point(240, 340);
            this.labelYearLevel.Name = "labelYearLevel";
            this.labelYearLevel.Size = new System.Drawing.Size(78, 19);
            this.labelYearLevel.TabIndex = 19;
            this.labelYearLevel.Text = "Year Level";
            // 
            // labelCourse
            // 
            this.labelCourse.AutoSize = true;
            this.labelCourse.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelCourse.ForeColor = System.Drawing.Color.Gray;
            this.labelCourse.Location = new System.Drawing.Point(25, 340);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(56, 19);
            this.labelCourse.TabIndex = 18;
            this.labelCourse.Text = "Course";
            // 
            // labelContact
            // 
            this.labelContact.AutoSize = true;
            this.labelContact.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelContact.ForeColor = System.Drawing.Color.Gray;
            this.labelContact.Location = new System.Drawing.Point(25, 275);
            this.labelContact.Name = "labelContact";
            this.labelContact.Size = new System.Drawing.Size(126, 19);
            this.labelContact.TabIndex = 17;
            this.labelContact.Text = "Contact Number";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelEmail.ForeColor = System.Drawing.Color.Gray;
            this.labelEmail.Location = new System.Drawing.Point(25, 210);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(46, 19);
            this.labelEmail.TabIndex = 16;
            this.labelEmail.Text = "Email";
            // 
            // labelMiddleName
            // 
            this.labelMiddleName.AutoSize = true;
            this.labelMiddleName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelMiddleName.ForeColor = System.Drawing.Color.Gray;
            this.labelMiddleName.Location = new System.Drawing.Point(25, 145);
            this.labelMiddleName.Name = "labelMiddleName";
            this.labelMiddleName.Size = new System.Drawing.Size(103, 19);
            this.labelMiddleName.TabIndex = 15;
            this.labelMiddleName.Text = "Middle Name";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelLastName.ForeColor = System.Drawing.Color.Gray;
            this.labelLastName.Location = new System.Drawing.Point(240, 80);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(81, 19);
            this.labelLastName.TabIndex = 14;
            this.labelLastName.Text = "Last Name";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelFirstName.ForeColor = System.Drawing.Color.Gray;
            this.labelFirstName.Location = new System.Drawing.Point(25, 80);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(79, 19);
            this.labelFirstName.TabIndex = 13;
            this.labelFirstName.Text = "First Name";
            // 
            // txtScholarNumber
            // 
            this.txtScholarNumber.Enabled = false;
            this.txtScholarNumber.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtScholarNumber.Location = new System.Drawing.Point(240, 560);
            this.txtScholarNumber.Name = "txtScholarNumber";
            this.txtScholarNumber.Size = new System.Drawing.Size(200, 25);
            this.txtScholarNumber.TabIndex = 12;
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
            this.cmbStatus.Location = new System.Drawing.Point(25, 560);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 28);
            this.cmbStatus.TabIndex = 11;
            // 
            // dtpExpectedGraduation
            // 
            this.dtpExpectedGraduation.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.dtpExpectedGraduation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpectedGraduation.Location = new System.Drawing.Point(240, 495);
            this.dtpExpectedGraduation.Name = "dtpExpectedGraduation";
            this.dtpExpectedGraduation.Size = new System.Drawing.Size(200, 25);
            this.dtpExpectedGraduation.TabIndex = 10;
            // 
            // dtpEnrollmentDate
            // 
            this.dtpEnrollmentDate.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.dtpEnrollmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnrollmentDate.Location = new System.Drawing.Point(25, 495);
            this.dtpEnrollmentDate.Name = "dtpEnrollmentDate";
            this.dtpEnrollmentDate.Size = new System.Drawing.Size(200, 25);
            this.dtpEnrollmentDate.TabIndex = 9;
            // 
            // cmbScholarshipType
            // 
            this.cmbScholarshipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScholarshipType.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbScholarshipType.FormattingEnabled = true;
            this.cmbScholarshipType.Items.AddRange(new object[] {
            "Academic Excellence Scholarship",
            "Athletic Scholarship",
            "Financial Need Scholarship",
            "President\'s List Scholarship"});
            this.cmbScholarshipType.Location = new System.Drawing.Point(25, 425);
            this.cmbScholarshipType.Name = "cmbScholarshipType";
            this.cmbScholarshipType.Size = new System.Drawing.Size(415, 28);
            this.cmbScholarshipType.TabIndex = 8;
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
            this.cmbYearLevel.Location = new System.Drawing.Point(240, 360);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(200, 28);
            this.cmbYearLevel.TabIndex = 7;
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Items.AddRange(new object[] {
            "BS Information Technology",
            "BS Computer Science",
            "BS Information Systems",
            "BS Business Administration",
            "BS Education"});
            this.cmbCourse.Location = new System.Drawing.Point(25, 360);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(200, 28);
            this.cmbCourse.TabIndex = 6;
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtContactNumber.Location = new System.Drawing.Point(25, 295);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(200, 25);
            this.txtContactNumber.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtEmail.Location = new System.Drawing.Point(25, 230);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(415, 25);
            this.txtEmail.TabIndex = 4;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtMiddleName.Location = new System.Drawing.Point(25, 165);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(200, 25);
            this.txtMiddleName.TabIndex = 3;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtLastName.Location = new System.Drawing.Point(240, 100);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 25);
            this.txtLastName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtFirstName.Location = new System.Drawing.Point(25, 100);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 25);
            this.txtFirstName.TabIndex = 1;
            // 
            // labelFormTitle
            // 
            this.labelFormTitle.AutoSize = true;
            this.labelFormTitle.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.labelFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.labelFormTitle.Location = new System.Drawing.Point(20, 20);
            this.labelFormTitle.Name = "labelFormTitle";
            this.labelFormTitle.Size = new System.Drawing.Size(218, 26);
            this.labelFormTitle.TabIndex = 0;
            this.labelFormTitle.Text = "Scholar Information";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.labelUserName.ForeColor = System.Drawing.Color.Black;
            this.labelUserName.Location = new System.Drawing.Point(1015, 32);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(111, 19);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Administrator";
            // 
            // labelHeaderTitle
            // 
            this.labelHeaderTitle.AutoSize = true;
            this.labelHeaderTitle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.labelHeaderTitle.ForeColor = System.Drawing.Color.Black;
            this.labelHeaderTitle.Location = new System.Drawing.Point(28, 22);
            this.labelHeaderTitle.Name = "labelHeaderTitle";
            this.labelHeaderTitle.Size = new System.Drawing.Size(263, 28);
            this.labelHeaderTitle.TabIndex = 0;
            this.labelHeaderTitle.Text = "Scholar Management";
            // 
            // sataButtonLogout
            // 
            this.sataButtonLogout.ButtonText = "Logout";
            this.sataButtonLogout.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.sataButtonLogout.CheckedForeColor = System.Drawing.Color.White;
            this.sataButtonLogout.CheckedImageTint = System.Drawing.Color.White;
            this.sataButtonLogout.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.sataButtonLogout.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButtonLogout.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.sataButtonLogout.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.sataButtonLogout.HoverForeColor = System.Drawing.Color.White;
            this.sataButtonLogout.HoverImage = null;
            this.sataButtonLogout.HoverImageTint = System.Drawing.Color.White;
            this.sataButtonLogout.HoverOutline = System.Drawing.Color.Empty;
            this.sataButtonLogout.Image = null;
            this.sataButtonLogout.ImageAutoCenter = true;
            this.sataButtonLogout.ImageExpand = new System.Drawing.Point(0, 0);
            this.sataButtonLogout.ImageOffset = new System.Drawing.Point(0, 0);
            this.sataButtonLogout.ImageTint = System.Drawing.Color.White;
            this.sataButtonLogout.IsToggleButton = false;
            this.sataButtonLogout.IsToggled = false;
            this.sataButtonLogout.Location = new System.Drawing.Point(1177, 19);
            this.sataButtonLogout.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.sataButtonLogout.Name = "sataButtonLogout";
            this.sataButtonLogout.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.sataButtonLogout.NormalForeColor = System.Drawing.Color.White;
            this.sataButtonLogout.NormalOutline = System.Drawing.Color.Empty;
            this.sataButtonLogout.OutlineThickness = 2F;
            this.sataButtonLogout.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.sataButtonLogout.PressedForeColor = System.Drawing.Color.White;
            this.sataButtonLogout.PressedImageTint = System.Drawing.Color.White;
            this.sataButtonLogout.PressedOutline = System.Drawing.Color.Empty;
            this.sataButtonLogout.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButtonLogout.Size = new System.Drawing.Size(101, 40);
            this.sataButtonLogout.TabIndex = 1;
            this.sataButtonLogout.TextAutoCenter = true;
            this.sataButtonLogout.TextOffset = new System.Drawing.Point(0, 0);
            this.sataButtonLogout.Click += new System.EventHandler(this.sataButtonLogout_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.BackColor2 = System.Drawing.Color.White;
            this.panelHeader.BorderColor = System.Drawing.Color.Black;
            borderRadius4.BottomLeft = 10;
            borderRadius4.BottomRight = 10;
            borderRadius4.TopLeft = 10;
            borderRadius4.TopRight = 10;
            this.panelHeader.BorderRadius = borderRadius4;
            this.panelHeader.BorderThickness = 0;
            this.panelHeader.Controls.Add(this.sataButtonLogout);
            this.panelHeader.Controls.Add(this.labelHeaderTitle);
            this.panelHeader.Controls.Add(this.pictureBoxUser);
            this.panelHeader.Controls.Add(this.labelUserName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(288, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1312, 72);
            this.panelHeader.TabIndex = 3;
            // 
            // pictureBoxUser
            // 
            this.pictureBoxUser.Image = global::SkolarAid.Properties.Resources.user__3_;
            this.pictureBoxUser.Location = new System.Drawing.Point(968, 23);
            this.pictureBoxUser.Name = "pictureBoxUser";
            this.pictureBoxUser.Size = new System.Drawing.Size(36, 35);
            this.pictureBoxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUser.TabIndex = 2;
            this.pictureBoxUser.TabStop = false;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.panelSidebar.Controls.Add(this.sataButton6);
            this.panelSidebar.Controls.Add(this.sataButton5);
            this.panelSidebar.Controls.Add(this.sataButton4);
            this.panelSidebar.Controls.Add(this.sataButton3);
            this.panelSidebar.Controls.Add(this.sataButton2);
            this.panelSidebar.Controls.Add(this.label1);
            this.panelSidebar.Controls.Add(this.sataButton1);
            this.panelSidebar.Controls.Add(this.pictureBox1);
            this.panelSidebar.Controls.Add(this.ScholarAid);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(288, 950);
            this.panelSidebar.TabIndex = 0;
            // 
            // sataButton6
            // 
            this.sataButton6.ButtonText = "Reminder & Notifacation";
            this.sataButton6.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton6.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton6.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton6.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.sataButton6.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sataButton6.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.sataButton6.HoverForeColor = System.Drawing.Color.White;
            this.sataButton6.HoverImage = null;
            this.sataButton6.HoverImageTint = System.Drawing.Color.White;
            this.sataButton6.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton6.Image = global::SkolarAid.Properties.Resources.bell__1_;
            this.sataButton6.ImageAutoCenter = true;
            this.sataButton6.ImageExpand = new System.Drawing.Point(10, 10);
            this.sataButton6.ImageOffset = new System.Drawing.Point(5, 0);
            this.sataButton6.ImageTint = System.Drawing.Color.White;
            this.sataButton6.IsToggleButton = false;
            this.sataButton6.IsToggled = false;
            this.sataButton6.Location = new System.Drawing.Point(3, 682);
            this.sataButton6.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.sataButton6.Name = "sataButton6";
            this.sataButton6.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.sataButton6.NormalForeColor = System.Drawing.Color.White;
            this.sataButton6.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton6.OutlineThickness = 2F;
            this.sataButton6.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton6.PressedForeColor = System.Drawing.Color.White;
            this.sataButton6.PressedImageTint = System.Drawing.Color.White;
            this.sataButton6.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton6.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton6.Size = new System.Drawing.Size(283, 55);
            this.sataButton6.TabIndex = 17;
            this.sataButton6.TextAutoCenter = true;
            this.sataButton6.TextOffset = new System.Drawing.Point(10, 0);
            this.sataButton6.Click += new System.EventHandler(this.sataButton6_Click);
            // 
            // sataButton5
            // 
            this.sataButton5.ButtonText = "Activity Log";
            this.sataButton5.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton5.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton5.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton5.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.sataButton5.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sataButton5.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.sataButton5.HoverForeColor = System.Drawing.Color.White;
            this.sataButton5.HoverImage = null;
            this.sataButton5.HoverImageTint = System.Drawing.Color.White;
            this.sataButton5.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton5.Image = global::SkolarAid.Properties.Resources.file;
            this.sataButton5.ImageAutoCenter = true;
            this.sataButton5.ImageExpand = new System.Drawing.Point(10, 10);
            this.sataButton5.ImageOffset = new System.Drawing.Point(-40, 0);
            this.sataButton5.ImageTint = System.Drawing.Color.White;
            this.sataButton5.IsToggleButton = false;
            this.sataButton5.IsToggled = false;
            this.sataButton5.Location = new System.Drawing.Point(1, 588);
            this.sataButton5.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.sataButton5.Name = "sataButton5";
            this.sataButton5.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.sataButton5.NormalForeColor = System.Drawing.Color.White;
            this.sataButton5.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton5.OutlineThickness = 2F;
            this.sataButton5.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton5.PressedForeColor = System.Drawing.Color.White;
            this.sataButton5.PressedImageTint = System.Drawing.Color.White;
            this.sataButton5.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton5.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton5.Size = new System.Drawing.Size(283, 55);
            this.sataButton5.TabIndex = 16;
            this.sataButton5.TextAutoCenter = true;
            this.sataButton5.TextOffset = new System.Drawing.Point(-30, 0);
            this.sataButton5.Click += new System.EventHandler(this.sataButton5_Click);
            // 
            // sataButton4
            // 
            this.sataButton4.ButtonText = "Reports & Analytics";
            this.sataButton4.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton4.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton4.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton4.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.sataButton4.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sataButton4.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.sataButton4.HoverForeColor = System.Drawing.Color.White;
            this.sataButton4.HoverImage = null;
            this.sataButton4.HoverImageTint = System.Drawing.Color.White;
            this.sataButton4.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton4.Image = global::SkolarAid.Properties.Resources.analysis;
            this.sataButton4.ImageAutoCenter = true;
            this.sataButton4.ImageExpand = new System.Drawing.Point(10, 10);
            this.sataButton4.ImageOffset = new System.Drawing.Point(-15, 0);
            this.sataButton4.ImageTint = System.Drawing.Color.White;
            this.sataButton4.IsToggleButton = false;
            this.sataButton4.IsToggled = false;
            this.sataButton4.Location = new System.Drawing.Point(0, 488);
            this.sataButton4.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.sataButton4.Name = "sataButton4";
            this.sataButton4.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.sataButton4.NormalForeColor = System.Drawing.Color.White;
            this.sataButton4.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton4.OutlineThickness = 2F;
            this.sataButton4.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton4.PressedForeColor = System.Drawing.Color.White;
            this.sataButton4.PressedImageTint = System.Drawing.Color.White;
            this.sataButton4.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton4.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton4.Size = new System.Drawing.Size(283, 55);
            this.sataButton4.TabIndex = 15;
            this.sataButton4.TextAutoCenter = true;
            this.sataButton4.TextOffset = new System.Drawing.Point(-10, 0);
            this.sataButton4.Click += new System.EventHandler(this.sataButton4_Click);
            // 
            // sataButton3
            // 
            this.sataButton3.ButtonText = "Payroll Processing";
            this.sataButton3.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton3.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton3.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton3.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.sataButton3.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sataButton3.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.sataButton3.HoverForeColor = System.Drawing.Color.White;
            this.sataButton3.HoverImage = null;
            this.sataButton3.HoverImageTint = System.Drawing.Color.White;
            this.sataButton3.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton3.Image = global::SkolarAid.Properties.Resources.dollar;
            this.sataButton3.ImageAutoCenter = true;
            this.sataButton3.ImageExpand = new System.Drawing.Point(10, 10);
            this.sataButton3.ImageOffset = new System.Drawing.Point(-25, 0);
            this.sataButton3.ImageTint = System.Drawing.Color.White;
            this.sataButton3.IsToggleButton = false;
            this.sataButton3.IsToggled = false;
            this.sataButton3.Location = new System.Drawing.Point(-1, 391);
            this.sataButton3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.sataButton3.Name = "sataButton3";
            this.sataButton3.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.sataButton3.NormalForeColor = System.Drawing.Color.White;
            this.sataButton3.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton3.OutlineThickness = 2F;
            this.sataButton3.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton3.PressedForeColor = System.Drawing.Color.White;
            this.sataButton3.PressedImageTint = System.Drawing.Color.White;
            this.sataButton3.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton3.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton3.Size = new System.Drawing.Size(283, 55);
            this.sataButton3.TabIndex = 14;
            this.sataButton3.TextAutoCenter = true;
            this.sataButton3.TextOffset = new System.Drawing.Point(-15, 0);
            this.sataButton3.Click += new System.EventHandler(this.sataButton3_Click);
            // 
            // sataButton2
            // 
            this.sataButton2.ButtonText = "Scholar Management";
            this.sataButton2.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton2.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton2.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton2.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.sataButton2.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sataButton2.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.sataButton2.HoverForeColor = System.Drawing.Color.White;
            this.sataButton2.HoverImage = null;
            this.sataButton2.HoverImageTint = System.Drawing.Color.White;
            this.sataButton2.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton2.Image = global::SkolarAid.Properties.Resources.scholar;
            this.sataButton2.ImageAutoCenter = true;
            this.sataButton2.ImageExpand = new System.Drawing.Point(10, 10);
            this.sataButton2.ImageOffset = new System.Drawing.Point(-10, 0);
            this.sataButton2.ImageTint = System.Drawing.Color.White;
            this.sataButton2.IsToggleButton = false;
            this.sataButton2.IsToggled = false;
            this.sataButton2.Location = new System.Drawing.Point(-2, 296);
            this.sataButton2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.sataButton2.Name = "sataButton2";
            this.sataButton2.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.sataButton2.NormalForeColor = System.Drawing.Color.White;
            this.sataButton2.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton2.OutlineThickness = 2F;
            this.sataButton2.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton2.PressedForeColor = System.Drawing.Color.White;
            this.sataButton2.PressedImageTint = System.Drawing.Color.White;
            this.sataButton2.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton2.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton2.Size = new System.Drawing.Size(283, 55);
            this.sataButton2.TabIndex = 13;
            this.sataButton2.TextAutoCenter = true;
            this.sataButton2.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "_____________________________";
            // 
            // sataButton1
            // 
            this.sataButton1.ButtonText = "Dashboard";
            this.sataButton1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton1.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton1.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton1.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.sataButton1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sataButton1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.sataButton1.HoverForeColor = System.Drawing.Color.White;
            this.sataButton1.HoverImage = null;
            this.sataButton1.HoverImageTint = System.Drawing.Color.White;
            this.sataButton1.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton1.Image = ((System.Drawing.Image)(resources.GetObject("sataButton1.Image")));
            this.sataButton1.ImageAutoCenter = true;
            this.sataButton1.ImageExpand = new System.Drawing.Point(10, 10);
            this.sataButton1.ImageOffset = new System.Drawing.Point(-45, 0);
            this.sataButton1.ImageTint = System.Drawing.Color.White;
            this.sataButton1.IsToggleButton = false;
            this.sataButton1.IsToggled = false;
            this.sataButton1.Location = new System.Drawing.Point(-3, 190);
            this.sataButton1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.sataButton1.Name = "sataButton1";
            this.sataButton1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.sataButton1.NormalForeColor = System.Drawing.Color.White;
            this.sataButton1.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton1.OutlineThickness = 2F;
            this.sataButton1.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.sataButton1.PressedForeColor = System.Drawing.Color.White;
            this.sataButton1.PressedImageTint = System.Drawing.Color.White;
            this.sataButton1.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton1.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton1.Size = new System.Drawing.Size(288, 68);
            this.sataButton1.TabIndex = 11;
            this.sataButton1.TextAutoCenter = true;
            this.sataButton1.TextOffset = new System.Drawing.Point(-35, 0);
            this.sataButton1.Click += new System.EventHandler(this.sataButton1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SkolarAid.Properties.Resources.scholar;
            this.pictureBox1.Location = new System.Drawing.Point(21, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // ScholarAid
            // 
            this.ScholarAid.AutoSize = true;
            this.ScholarAid.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScholarAid.ForeColor = System.Drawing.Color.White;
            this.ScholarAid.Location = new System.Drawing.Point(91, 25);
            this.ScholarAid.Name = "ScholarAid";
            this.ScholarAid.Size = new System.Drawing.Size(173, 22);
            this.ScholarAid.TabIndex = 9;
            this.ScholarAid.Text = "ScholarAid Admin";
            // 
            // FrmScholarManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1600, 950);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScholarManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scholar Management";
            this.panelContent.ResumeLayout(false);
            this.panelSearchBar.ResumeLayout(false);
            this.panelSearchBar.PerformLayout();
            this.panelScholarList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScholars)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContent;
        private SATAUiFramework.SATAPanel panelSearchBar;
        private FrameworkTest.SATAButton btnAddScholar;
        private SATAUiFramework.SATAPanel panelScholarList;
        private System.Windows.Forms.DataGridView dgvScholars;
        private SATAUiFramework.SATAPanel panelForm;
        private System.Windows.Forms.Label labelFormTitle;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.ComboBox cmbScholarshipType;
        private System.Windows.Forms.DateTimePicker dtpEnrollmentDate;
        private System.Windows.Forms.DateTimePicker dtpExpectedGraduation;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtScholarNumber;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelMiddleName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.Label labelYearLevel;
        private System.Windows.Forms.Label labelScholarship;
        private System.Windows.Forms.Label labelEnrollmentDate;
        private System.Windows.Forms.Label labelExpectedGrad;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelScholarNumber;
        private FrameworkTest.SATAButton btnSave;
        private FrameworkTest.SATAButton btnUpdate;
        private FrameworkTest.SATAButton btnDelete;
        private FrameworkTest.SATAButton btnCancel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterCourse;
        private System.Windows.Forms.ComboBox cmbFilterScholarship;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.Label labelHeaderTitle;
        private FrameworkTest.SATAButton sataButtonLogout;
        private SATAUiFramework.SATAPanel panelHeader;
        private System.Windows.Forms.Panel panelSidebar;
        private FrameworkTest.SATAButton sataButton6;
        private FrameworkTest.SATAButton sataButton5;
        private FrameworkTest.SATAButton sataButton4;
        private FrameworkTest.SATAButton sataButton3;
        private FrameworkTest.SATAButton sataButton2;
        private System.Windows.Forms.Label label1;
        private FrameworkTest.SATAButton sataButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ScholarAid;
    }
}