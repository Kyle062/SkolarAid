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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotifications));
            SATAUiFramework.BorderRadius borderRadius25 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius26 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius27 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius28 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius29 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius30 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius31 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius32 = new SATAUiFramework.BorderRadius();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.panelTop = new SATAUiFramework.SATAPanel();
            this.btnLogout = new FrameworkTest.SATAButton();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.panelStats1 = new SATAUiFramework.SATAPanel();
            this.lblTotalSent = new System.Windows.Forms.Label();
            this.lblTotalSentLabel = new System.Windows.Forms.Label();
            this.picTotalSent = new System.Windows.Forms.PictureBox();
            this.panelStats2 = new SATAUiFramework.SATAPanel();
            this.lblPendingSMS = new System.Windows.Forms.Label();
            this.lblPendingSMSLabel = new System.Windows.Forms.Label();
            this.picPendingSMS = new System.Windows.Forms.PictureBox();
            this.panelStats3 = new SATAUiFramework.SATAPanel();
            this.lblDelivered = new System.Windows.Forms.Label();
            this.lblDeliveredLabel = new System.Windows.Forms.Label();
            this.picDelivered = new System.Windows.Forms.PictureBox();
            this.panelStats4 = new SATAUiFramework.SATAPanel();
            this.lblFailedSMS = new System.Windows.Forms.Label();
            this.lblFailedSMSLabel = new System.Windows.Forms.Label();
            this.picFailedSMS = new System.Windows.Forms.PictureBox();
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
            this.btnSendNotification = new FrameworkTest.SATAButton();
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
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.panelStats1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalSent)).BeginInit();
            this.panelStats2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPendingSMS)).BeginInit();
            this.panelStats3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDelivered)).BeginInit();
            this.panelStats4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFailedSMS)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.panelCompose.SuspendLayout();
            this.panelDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).BeginInit();
            this.panelDetailView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.panelSidebar.Controls.Add(this.sataButton1);
            this.panelSidebar.Controls.Add(this.sataButton2);
            this.panelSidebar.Controls.Add(this.sataButton3);
            this.panelSidebar.Controls.Add(this.sataButton4);
            this.panelSidebar.Controls.Add(this.sataButton5);
            this.panelSidebar.Controls.Add(this.sataButton6);
            this.panelSidebar.Controls.Add(this.label1);
            this.panelSidebar.Controls.Add(this.pictureBox1);
            this.panelSidebar.Controls.Add(this.ScholarAid);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(296, 911);
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
            this.sataButton6.Location = new System.Drawing.Point(4, 693);
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
            this.sataButton5.Location = new System.Drawing.Point(2, 599);
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
            this.sataButton4.Location = new System.Drawing.Point(1, 499);
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
            this.sataButton4.Click += new System.EventHandler(this.sataButton4_Click_1);
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
            this.sataButton3.Location = new System.Drawing.Point(0, 402);
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
            this.sataButton3.Click += new System.EventHandler(this.sataButton3_Click_1);
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
            this.sataButton2.Location = new System.Drawing.Point(1, 307);
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
            this.sataButton2.Click += new System.EventHandler(this.sataButton2_Click_2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-5, 71);
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
            this.sataButton1.Location = new System.Drawing.Point(3, 201);
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
            this.pictureBox1.Location = new System.Drawing.Point(22, 23);
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
            this.ScholarAid.Location = new System.Drawing.Point(92, 36);
            this.ScholarAid.Name = "ScholarAid";
            this.ScholarAid.Size = new System.Drawing.Size(173, 22);
            this.ScholarAid.TabIndex = 9;
            this.ScholarAid.Text = "ScholarAid Admin";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.BackColor2 = System.Drawing.Color.White;
            this.panelTop.BorderColor = System.Drawing.Color.Black;
            borderRadius25.BottomLeft = 10;
            borderRadius25.BottomRight = 10;
            borderRadius25.TopLeft = 10;
            borderRadius25.TopRight = 10;
            this.panelTop.BorderRadius = borderRadius25;
            this.panelTop.BorderThickness = 0;
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Controls.Add(this.lblPageTitle);
            this.panelTop.Controls.Add(this.picUser);
            this.panelTop.Controls.Add(this.lblRole);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(296, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1288, 72);
            this.panelTop.TabIndex = 3;
            // 
            // btnLogout
            // 
            this.btnLogout.ButtonText = "Logout";
            this.btnLogout.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLogout.CheckedForeColor = System.Drawing.Color.White;
            this.btnLogout.CheckedImageTint = System.Drawing.Color.White;
            this.btnLogout.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLogout.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnLogout.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
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
            this.btnLogout.Location = new System.Drawing.Point(1161, 19);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.btnLogout.NormalForeColor = System.Drawing.Color.White;
            this.btnLogout.NormalOutline = System.Drawing.Color.Empty;
            this.btnLogout.OutlineThickness = 2F;
            this.btnLogout.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnLogout.PressedForeColor = System.Drawing.Color.White;
            this.btnLogout.PressedImageTint = System.Drawing.Color.White;
            this.btnLogout.PressedOutline = System.Drawing.Color.Empty;
            this.btnLogout.Rounding = new System.Windows.Forms.Padding(5);
            this.btnLogout.Size = new System.Drawing.Size(101, 40);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.TextAutoCenter = true;
            this.btnLogout.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.Black;
            this.lblPageTitle.Location = new System.Drawing.Point(28, 22);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(291, 28);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Notifications & Reminders";
            // 
            // picUser
            // 
            this.picUser.Image = global::SkolarAid.Properties.Resources.user__3_;
            this.picUser.Location = new System.Drawing.Point(952, 23);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(36, 35);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 2;
            this.picUser.TabStop = false;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.Black;
            this.lblRole.Location = new System.Drawing.Point(999, 32);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(111, 19);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Administrator";
            // 
            // panelStats1
            // 
            this.panelStats1.BackColor = System.Drawing.Color.White;
            this.panelStats1.BackColor2 = System.Drawing.Color.White;
            this.panelStats1.BorderColor = System.Drawing.Color.Black;
            borderRadius26.BottomLeft = 10;
            borderRadius26.BottomRight = 10;
            borderRadius26.TopLeft = 10;
            borderRadius26.TopRight = 10;
            this.panelStats1.BorderRadius = borderRadius26;
            this.panelStats1.BorderThickness = 0;
            this.panelStats1.Controls.Add(this.lblTotalSent);
            this.panelStats1.Controls.Add(this.lblTotalSentLabel);
            this.panelStats1.Controls.Add(this.picTotalSent);
            this.panelStats1.Location = new System.Drawing.Point(321, 100);
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
            // panelStats2
            // 
            this.panelStats2.BackColor = System.Drawing.Color.White;
            this.panelStats2.BackColor2 = System.Drawing.Color.White;
            this.panelStats2.BorderColor = System.Drawing.Color.Black;
            borderRadius27.BottomLeft = 10;
            borderRadius27.BottomRight = 10;
            borderRadius27.TopLeft = 10;
            borderRadius27.TopRight = 10;
            this.panelStats2.BorderRadius = borderRadius27;
            this.panelStats2.BorderThickness = 0;
            this.panelStats2.Controls.Add(this.lblPendingSMS);
            this.panelStats2.Controls.Add(this.lblPendingSMSLabel);
            this.panelStats2.Controls.Add(this.picPendingSMS);
            this.panelStats2.Location = new System.Drawing.Point(571, 100);
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
            // picPendingSMS
            // 
            this.picPendingSMS.Location = new System.Drawing.Point(15, 40);
            this.picPendingSMS.Name = "picPendingSMS";
            this.picPendingSMS.Size = new System.Drawing.Size(45, 48);
            this.picPendingSMS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPendingSMS.TabIndex = 2;
            this.picPendingSMS.TabStop = false;
            // 
            // panelStats3
            // 
            this.panelStats3.BackColor = System.Drawing.Color.White;
            this.panelStats3.BackColor2 = System.Drawing.Color.White;
            this.panelStats3.BorderColor = System.Drawing.Color.Black;
            borderRadius28.BottomLeft = 10;
            borderRadius28.BottomRight = 10;
            borderRadius28.TopLeft = 10;
            borderRadius28.TopRight = 10;
            this.panelStats3.BorderRadius = borderRadius28;
            this.panelStats3.BorderThickness = 0;
            this.panelStats3.Controls.Add(this.lblDelivered);
            this.panelStats3.Controls.Add(this.lblDeliveredLabel);
            this.panelStats3.Controls.Add(this.picDelivered);
            this.panelStats3.Location = new System.Drawing.Point(821, 100);
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
            // picDelivered
            // 
            this.picDelivered.Location = new System.Drawing.Point(15, 40);
            this.picDelivered.Name = "picDelivered";
            this.picDelivered.Size = new System.Drawing.Size(45, 48);
            this.picDelivered.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDelivered.TabIndex = 2;
            this.picDelivered.TabStop = false;
            // 
            // panelStats4
            // 
            this.panelStats4.BackColor = System.Drawing.Color.White;
            this.panelStats4.BackColor2 = System.Drawing.Color.White;
            this.panelStats4.BorderColor = System.Drawing.Color.Black;
            borderRadius29.BottomLeft = 10;
            borderRadius29.BottomRight = 10;
            borderRadius29.TopLeft = 10;
            borderRadius29.TopRight = 10;
            this.panelStats4.BorderRadius = borderRadius29;
            this.panelStats4.BorderThickness = 0;
            this.panelStats4.Controls.Add(this.lblFailedSMS);
            this.panelStats4.Controls.Add(this.lblFailedSMSLabel);
            this.panelStats4.Controls.Add(this.picFailedSMS);
            this.panelStats4.Location = new System.Drawing.Point(1071, 100);
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
            // picFailedSMS
            // 
            this.picFailedSMS.Location = new System.Drawing.Point(15, 40);
            this.picFailedSMS.Name = "picFailedSMS";
            this.picFailedSMS.Size = new System.Drawing.Size(45, 48);
            this.picFailedSMS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFailedSMS.TabIndex = 2;
            this.picFailedSMS.TabStop = false;
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.BackColor2 = System.Drawing.Color.White;
            this.panelFilters.BorderColor = System.Drawing.Color.Black;
            borderRadius30.BottomLeft = 10;
            borderRadius30.BottomRight = 10;
            borderRadius30.TopLeft = 10;
            borderRadius30.TopRight = 10;
            this.panelFilters.BorderRadius = borderRadius30;
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
            this.panelFilters.Location = new System.Drawing.Point(321, 230);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(980, 75);
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
            this.cmbNotificationType.Location = new System.Drawing.Point(320, 28);
            this.cmbNotificationType.Name = "cmbNotificationType";
            this.cmbNotificationType.Size = new System.Drawing.Size(140, 28);
            this.cmbNotificationType.TabIndex = 3;
            // 
            // lblNotificationType
            // 
            this.lblNotificationType.AutoSize = true;
            this.lblNotificationType.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblNotificationType.Location = new System.Drawing.Point(317, 8);
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
            this.cmbDeliveryMethod.Location = new System.Drawing.Point(480, 28);
            this.cmbDeliveryMethod.Name = "cmbDeliveryMethod";
            this.cmbDeliveryMethod.Size = new System.Drawing.Size(120, 28);
            this.cmbDeliveryMethod.TabIndex = 3;
            // 
            // lblDeliveryMethod
            // 
            this.lblDeliveryMethod.AutoSize = true;
            this.lblDeliveryMethod.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblDeliveryMethod.Location = new System.Drawing.Point(477, 8);
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
            this.cmbRecipient.Location = new System.Drawing.Point(160, 28);
            this.cmbRecipient.Name = "cmbRecipient";
            this.cmbRecipient.Size = new System.Drawing.Size(140, 28);
            this.cmbRecipient.TabIndex = 3;
            // 
            // lblRecipient
            // 
            this.lblRecipient.AutoSize = true;
            this.lblRecipient.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecipient.Location = new System.Drawing.Point(157, 8);
            this.lblRecipient.Name = "lblRecipient";
            this.lblRecipient.Size = new System.Drawing.Size(72, 17);
            this.lblRecipient.TabIndex = 2;
            this.lblRecipient.Text = "Recipient";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtSearch.Location = new System.Drawing.Point(20, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(17, 8);
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
            this.btnClearFilters.Location = new System.Drawing.Point(740, 24);
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
            this.btnRefresh.Location = new System.Drawing.Point(620, 24);
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
            borderRadius31.BottomLeft = 10;
            borderRadius31.BottomRight = 10;
            borderRadius31.TopLeft = 10;
            borderRadius31.TopRight = 10;
            this.panelCompose.BorderRadius = borderRadius31;
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
            this.panelCompose.Location = new System.Drawing.Point(321, 320);
            this.panelCompose.Name = "panelCompose";
            this.panelCompose.Size = new System.Drawing.Size(580, 560);
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
            borderRadius32.BottomLeft = 10;
            borderRadius32.BottomRight = 10;
            borderRadius32.TopLeft = 10;
            borderRadius32.TopRight = 10;
            this.panelDataGrid.BorderRadius = borderRadius32;
            this.panelDataGrid.BorderThickness = 0;
            this.panelDataGrid.Controls.Add(this.dgvNotifications);
            this.panelDataGrid.Location = new System.Drawing.Point(921, 320);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(380, 560);
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotifications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvNotifications.ColumnHeadersHeight = 40;
            this.dgvNotifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNotificationID,
            this.colDateSent,
            this.colRecipient,
            this.colTitle,
            this.colType,
            this.colDeliveryMethod,
            this.colSMSStatus});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNotifications.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotifications.EnableHeadersVisualStyles = false;
            this.dgvNotifications.GridColor = System.Drawing.Color.LightGray;
            this.dgvNotifications.Location = new System.Drawing.Point(0, 0);
            this.dgvNotifications.MultiSelect = false;
            this.dgvNotifications.Name = "dgvNotifications";
            this.dgvNotifications.ReadOnly = true;
            this.dgvNotifications.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvNotifications.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvNotifications.RowTemplate.Height = 35;
            this.dgvNotifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotifications.Size = new System.Drawing.Size(380, 560);
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
            this.panelDetailView.Location = new System.Drawing.Point(1321, 320);
            this.panelDetailView.Name = "panelDetailView";
            this.panelDetailView.Size = new System.Drawing.Size(263, 560);
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
            this.txtDetailMessage.Location = new System.Drawing.Point(20, 225);
            this.txtDetailMessage.Name = "txtDetailMessage";
            this.txtDetailMessage.ReadOnly = true;
            this.txtDetailMessage.Size = new System.Drawing.Size(226, 250);
            this.txtDetailMessage.TabIndex = 5;
            this.txtDetailMessage.Text = "";
            // 
            // lblDetailMessage
            // 
            this.lblDetailMessage.AutoSize = true;
            this.lblDetailMessage.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailMessage.ForeColor = System.Drawing.Color.Black;
            this.lblDetailMessage.Location = new System.Drawing.Point(16, 205);
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
            this.btnResend.Location = new System.Drawing.Point(20, 500);
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
            // FrmNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1584, 911);
            this.Controls.Add(this.panelDetailView);
            this.Controls.Add(this.panelDataGrid);
            this.Controls.Add(this.panelCompose);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelStats4);
            this.Controls.Add(this.panelStats3);
            this.Controls.Add(this.panelStats2);
            this.Controls.Add(this.panelStats1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotifications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifications & Reminders - ScholarAid";
            this.Load += new System.EventHandler(this.FrmNotifications_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.panelStats1.ResumeLayout(false);
            this.panelStats1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalSent)).EndInit();
            this.panelStats2.ResumeLayout(false);
            this.panelStats2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPendingSMS)).EndInit();
            this.panelStats3.ResumeLayout(false);
            this.panelStats3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDelivered)).EndInit();
            this.panelStats4.ResumeLayout(false);
            this.panelStats4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFailedSMS)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelCompose.ResumeLayout(false);
            this.panelCompose.PerformLayout();
            this.panelDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).EndInit();
            this.panelDetailView.ResumeLayout(false);
            this.panelDetailView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Sidebar
        private System.Windows.Forms.Panel panelSidebar;

        // Top Panel
        private SATAUiFramework.SATAPanel panelTop;
        private FrameworkTest.SATAButton btnLogout;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblRole;

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
        private FrameworkTest.SATAButton sataButton6;
        private FrameworkTest.SATAButton sataButton5;
        private FrameworkTest.SATAButton sataButton4;
        private FrameworkTest.SATAButton sataButton3;
        private FrameworkTest.SATAButton sataButton2;
        private System.Windows.Forms.Label label1;
        private FrameworkTest.SATAButton sataButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ScholarAid;
        //private BorderRadius borderRadius8;
    }
}
