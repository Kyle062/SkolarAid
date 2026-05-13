using System.Windows.Forms;

namespace SkolarAid
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.panelAutoFilledInfo = new System.Windows.Forms.Panel();
            this.lblAutoRenewalConditions = new System.Windows.Forms.Label();
            this.lblAutoFundSource = new System.Windows.Forms.Label();
            this.lblAutoStipendFrequency = new System.Windows.Forms.Label();
            this.lblAutoStipendAmount = new System.Windows.Forms.Label();
            this.labelAutoRenewal = new System.Windows.Forms.Label();
            this.labelAutoFundSource = new System.Windows.Forms.Label();
            this.labelAutoStipendFreq = new System.Windows.Forms.Label();
            this.labelAutoStipendAmt = new System.Windows.Forms.Label();
            this.labelAutoFillTitle = new System.Windows.Forms.Label();
            this.panelFiles = new System.Windows.Forms.Panel();
            this.lblContractFile = new System.Windows.Forms.Label();
            this.btnUploadContract = new System.Windows.Forms.Button();
            this.lblGradesFile = new System.Windows.Forms.Label();
            this.btnUploadGrades = new System.Windows.Forms.Button();
            this.lblCORFile = new System.Windows.Forms.Label();
            this.btnUploadCOR = new System.Windows.Forms.Button();
            this.lblCOEFile = new System.Windows.Forms.Label();
            this.btnUploadCOE = new System.Windows.Forms.Button();
            this.lblPSAFile = new System.Windows.Forms.Label();
            this.btnUploadPSA = new System.Windows.Forms.Button();
            this.labelFiles = new System.Windows.Forms.Label();
            this.txtNotes = new SATATextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.dtpExpectedGraduation = new System.Windows.Forms.DateTimePicker();
            this.labelExpGrad = new System.Windows.Forms.Label();
            this.dtpEnrollmentDate = new System.Windows.Forms.DateTimePicker();
            this.labelEnrollDate = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.labelYearLevel = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.labelDOB = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.labelProgram = new System.Windows.Forms.Label();
            this.cmbScholarshipType = new System.Windows.Forms.ComboBox();
            this.labelScholarship = new System.Windows.Forms.Label();
            this.txtBankAccountNumber = new SATATextBox();
            this.labelBankAccount = new System.Windows.Forms.Label();
            this.txtBankName = new SATATextBox();
            this.labelBankName = new System.Windows.Forms.Label();
            this.txtSuffix = new SATATextBox();
            this.labelSuffix = new System.Windows.Forms.Label();
            this.sataComboBox1 = new SATAComboBox();
            this.sataButton1 = new FrameworkTest.SATAButton();
            this.txtAddress = new SATATextBox();
            this.txtContactNumber = new SATATextBox();
            this.txtEmail = new SATATextBox();
            this.txtHEI = new SATATextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMiddleName = new SATATextBox();
            this.txtLastName = new SATATextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFirstName = new SATATextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStudentID = new SATATextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ExitBtn2 = new System.Windows.Forms.PictureBox();
            this.sataPanel1.SuspendLayout();
            this.panelAutoFilledInfo.SuspendLayout();
            this.panelFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBtn2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(739, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hello there,";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(640, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome to IskolarAid";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(623, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(352, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Register to apply for scholarship program";
            // 
            // sataPanel1
            // 
            this.sataPanel1.AutoScroll = true;
            this.sataPanel1.BackColor2 = System.Drawing.Color.White;
            this.sataPanel1.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius1;
            this.sataPanel1.BorderThickness = 0;
            this.sataPanel1.Controls.Add(this.panelAutoFilledInfo);
            this.sataPanel1.Controls.Add(this.panelFiles);
            this.sataPanel1.Controls.Add(this.txtNotes);
            this.sataPanel1.Controls.Add(this.labelNotes);
            this.sataPanel1.Controls.Add(this.dtpExpectedGraduation);
            this.sataPanel1.Controls.Add(this.labelExpGrad);
            this.sataPanel1.Controls.Add(this.dtpEnrollmentDate);
            this.sataPanel1.Controls.Add(this.labelEnrollDate);
            this.sataPanel1.Controls.Add(this.cmbYearLevel);
            this.sataPanel1.Controls.Add(this.labelYearLevel);
            this.sataPanel1.Controls.Add(this.cmbGender);
            this.sataPanel1.Controls.Add(this.labelGender);
            this.sataPanel1.Controls.Add(this.dtpDateOfBirth);
            this.sataPanel1.Controls.Add(this.labelDOB);
            this.sataPanel1.Controls.Add(this.cmbProgram);
            this.sataPanel1.Controls.Add(this.labelProgram);
            this.sataPanel1.Controls.Add(this.cmbScholarshipType);
            this.sataPanel1.Controls.Add(this.labelScholarship);
            this.sataPanel1.Controls.Add(this.txtBankAccountNumber);
            this.sataPanel1.Controls.Add(this.labelBankAccount);
            this.sataPanel1.Controls.Add(this.txtBankName);
            this.sataPanel1.Controls.Add(this.labelBankName);
            this.sataPanel1.Controls.Add(this.txtSuffix);
            this.sataPanel1.Controls.Add(this.labelSuffix);
            this.sataPanel1.Controls.Add(this.sataComboBox1);
            this.sataPanel1.Controls.Add(this.sataButton1);
            this.sataPanel1.Controls.Add(this.txtAddress);
            this.sataPanel1.Controls.Add(this.txtContactNumber);
            this.sataPanel1.Controls.Add(this.txtEmail);
            this.sataPanel1.Controls.Add(this.txtHEI);
            this.sataPanel1.Controls.Add(this.label15);
            this.sataPanel1.Controls.Add(this.label14);
            this.sataPanel1.Controls.Add(this.label12);
            this.sataPanel1.Controls.Add(this.txtMiddleName);
            this.sataPanel1.Controls.Add(this.txtLastName);
            this.sataPanel1.Controls.Add(this.label9);
            this.sataPanel1.Controls.Add(this.txtFirstName);
            this.sataPanel1.Controls.Add(this.label10);
            this.sataPanel1.Controls.Add(this.label11);
            this.sataPanel1.Controls.Add(this.label7);
            this.sataPanel1.Controls.Add(this.label8);
            this.sataPanel1.Controls.Add(this.txtStudentID);
            this.sataPanel1.Controls.Add(this.label6);
            this.sataPanel1.Controls.Add(this.label4);
            this.sataPanel1.Controls.Add(this.label5);
            this.sataPanel1.Location = new System.Drawing.Point(104, 242);
            this.sataPanel1.Name = "sataPanel1";
            this.sataPanel1.Size = new System.Drawing.Size(1358, 609);
            this.sataPanel1.TabIndex = 2;
            // 
            // panelAutoFilledInfo
            // 
            this.panelAutoFilledInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelAutoFilledInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAutoFilledInfo.Controls.Add(this.lblAutoRenewalConditions);
            this.panelAutoFilledInfo.Controls.Add(this.lblAutoFundSource);
            this.panelAutoFilledInfo.Controls.Add(this.lblAutoStipendFrequency);
            this.panelAutoFilledInfo.Controls.Add(this.lblAutoStipendAmount);
            this.panelAutoFilledInfo.Controls.Add(this.labelAutoRenewal);
            this.panelAutoFilledInfo.Controls.Add(this.labelAutoFundSource);
            this.panelAutoFilledInfo.Controls.Add(this.labelAutoStipendFreq);
            this.panelAutoFilledInfo.Controls.Add(this.labelAutoStipendAmt);
            this.panelAutoFilledInfo.Controls.Add(this.labelAutoFillTitle);
            this.panelAutoFilledInfo.Location = new System.Drawing.Point(601, 214);
            this.panelAutoFilledInfo.Name = "panelAutoFilledInfo";
            this.panelAutoFilledInfo.Size = new System.Drawing.Size(243, 160);
            this.panelAutoFilledInfo.TabIndex = 6;
            this.panelAutoFilledInfo.Visible = false;
            // 
            // lblAutoRenewalConditions
            // 
            this.lblAutoRenewalConditions.AutoSize = true;
            this.lblAutoRenewalConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAutoRenewalConditions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblAutoRenewalConditions.Location = new System.Drawing.Point(155, 130);
            this.lblAutoRenewalConditions.Name = "lblAutoRenewalConditions";
            this.lblAutoRenewalConditions.Size = new System.Drawing.Size(0, 15);
            this.lblAutoRenewalConditions.TabIndex = 1;
            // 
            // lblAutoFundSource
            // 
            this.lblAutoFundSource.AutoSize = true;
            this.lblAutoFundSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAutoFundSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblAutoFundSource.Location = new System.Drawing.Point(155, 100);
            this.lblAutoFundSource.Name = "lblAutoFundSource";
            this.lblAutoFundSource.Size = new System.Drawing.Size(0, 15);
            this.lblAutoFundSource.TabIndex = 1;
            // 
            // lblAutoStipendFrequency
            // 
            this.lblAutoStipendFrequency.AutoSize = true;
            this.lblAutoStipendFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAutoStipendFrequency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblAutoStipendFrequency.Location = new System.Drawing.Point(155, 70);
            this.lblAutoStipendFrequency.Name = "lblAutoStipendFrequency";
            this.lblAutoStipendFrequency.Size = new System.Drawing.Size(0, 15);
            this.lblAutoStipendFrequency.TabIndex = 1;
            // 
            // lblAutoStipendAmount
            // 
            this.lblAutoStipendAmount.AutoSize = true;
            this.lblAutoStipendAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAutoStipendAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.lblAutoStipendAmount.Location = new System.Drawing.Point(155, 40);
            this.lblAutoStipendAmount.Name = "lblAutoStipendAmount";
            this.lblAutoStipendAmount.Size = new System.Drawing.Size(0, 15);
            this.lblAutoStipendAmount.TabIndex = 1;
            // 
            // labelAutoRenewal
            // 
            this.labelAutoRenewal.AutoSize = true;
            this.labelAutoRenewal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelAutoRenewal.ForeColor = System.Drawing.Color.Black;
            this.labelAutoRenewal.Location = new System.Drawing.Point(10, 130);
            this.labelAutoRenewal.Name = "labelAutoRenewal";
            this.labelAutoRenewal.Size = new System.Drawing.Size(120, 15);
            this.labelAutoRenewal.TabIndex = 0;
            this.labelAutoRenewal.Text = "Renewal Conditions:";
            // 
            // labelAutoFundSource
            // 
            this.labelAutoFundSource.AutoSize = true;
            this.labelAutoFundSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelAutoFundSource.ForeColor = System.Drawing.Color.Black;
            this.labelAutoFundSource.Location = new System.Drawing.Point(10, 100);
            this.labelAutoFundSource.Name = "labelAutoFundSource";
            this.labelAutoFundSource.Size = new System.Drawing.Size(80, 15);
            this.labelAutoFundSource.TabIndex = 0;
            this.labelAutoFundSource.Text = "Fund Source:";
            // 
            // labelAutoStipendFreq
            // 
            this.labelAutoStipendFreq.AutoSize = true;
            this.labelAutoStipendFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelAutoStipendFreq.ForeColor = System.Drawing.Color.Black;
            this.labelAutoStipendFreq.Location = new System.Drawing.Point(10, 70);
            this.labelAutoStipendFreq.Name = "labelAutoStipendFreq";
            this.labelAutoStipendFreq.Size = new System.Drawing.Size(112, 15);
            this.labelAutoStipendFreq.TabIndex = 0;
            this.labelAutoStipendFreq.Text = "Stipend Frequency:";
            // 
            // labelAutoStipendAmt
            // 
            this.labelAutoStipendAmt.AutoSize = true;
            this.labelAutoStipendAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelAutoStipendAmt.ForeColor = System.Drawing.Color.Black;
            this.labelAutoStipendAmt.Location = new System.Drawing.Point(10, 40);
            this.labelAutoStipendAmt.Name = "labelAutoStipendAmt";
            this.labelAutoStipendAmt.Size = new System.Drawing.Size(97, 15);
            this.labelAutoStipendAmt.TabIndex = 0;
            this.labelAutoStipendAmt.Text = "Stipend Amount:";
            // 
            // labelAutoFillTitle
            // 
            this.labelAutoFillTitle.AutoSize = true;
            this.labelAutoFillTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutoFillTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.labelAutoFillTitle.Location = new System.Drawing.Point(10, 10);
            this.labelAutoFillTitle.Name = "labelAutoFillTitle";
            this.labelAutoFillTitle.Size = new System.Drawing.Size(205, 13);
            this.labelAutoFillTitle.TabIndex = 0;
            this.labelAutoFillTitle.Text = "📋 Scholarship Details (Auto-Filled)";
            // 
            // panelFiles
            // 
            this.panelFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiles.Controls.Add(this.lblContractFile);
            this.panelFiles.Controls.Add(this.btnUploadContract);
            this.panelFiles.Controls.Add(this.lblGradesFile);
            this.panelFiles.Controls.Add(this.btnUploadGrades);
            this.panelFiles.Controls.Add(this.lblCORFile);
            this.panelFiles.Controls.Add(this.btnUploadCOR);
            this.panelFiles.Controls.Add(this.lblCOEFile);
            this.panelFiles.Controls.Add(this.btnUploadCOE);
            this.panelFiles.Controls.Add(this.lblPSAFile);
            this.panelFiles.Controls.Add(this.btnUploadPSA);
            this.panelFiles.Controls.Add(this.labelFiles);
            this.panelFiles.Location = new System.Drawing.Point(861, 49);
            this.panelFiles.Name = "panelFiles";
            this.panelFiles.Size = new System.Drawing.Size(460, 210);
            this.panelFiles.TabIndex = 5;
            // 
            // lblContractFile
            // 
            this.lblContractFile.AutoSize = true;
            this.lblContractFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblContractFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblContractFile.Location = new System.Drawing.Point(240, 175);
            this.lblContractFile.Name = "lblContractFile";
            this.lblContractFile.Size = new System.Drawing.Size(0, 13);
            this.lblContractFile.TabIndex = 2;
            this.lblContractFile.Visible = false;
            // 
            // btnUploadContract
            // 
            this.btnUploadContract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnUploadContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadContract.ForeColor = System.Drawing.Color.White;
            this.btnUploadContract.Location = new System.Drawing.Point(240, 142);
            this.btnUploadContract.Name = "btnUploadContract";
            this.btnUploadContract.Size = new System.Drawing.Size(200, 30);
            this.btnUploadContract.TabIndex = 1;
            this.btnUploadContract.Text = "📄 Upload Scholarship Contract";
            this.btnUploadContract.UseVisualStyleBackColor = false;
            // 
            // lblGradesFile
            // 
            this.lblGradesFile.AutoSize = true;
            this.lblGradesFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblGradesFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblGradesFile.Location = new System.Drawing.Point(240, 115);
            this.lblGradesFile.Name = "lblGradesFile";
            this.lblGradesFile.Size = new System.Drawing.Size(0, 13);
            this.lblGradesFile.TabIndex = 2;
            this.lblGradesFile.Visible = false;
            // 
            // btnUploadGrades
            // 
            this.btnUploadGrades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnUploadGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadGrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadGrades.ForeColor = System.Drawing.Color.White;
            this.btnUploadGrades.Location = new System.Drawing.Point(240, 82);
            this.btnUploadGrades.Name = "btnUploadGrades";
            this.btnUploadGrades.Size = new System.Drawing.Size(200, 30);
            this.btnUploadGrades.TabIndex = 1;
            this.btnUploadGrades.Text = "📊 Upload Latest Grades/TOR";
            this.btnUploadGrades.UseVisualStyleBackColor = false;
            // 
            // lblCORFile
            // 
            this.lblCORFile.AutoSize = true;
            this.lblCORFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblCORFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblCORFile.Location = new System.Drawing.Point(18, 175);
            this.lblCORFile.Name = "lblCORFile";
            this.lblCORFile.Size = new System.Drawing.Size(0, 13);
            this.lblCORFile.TabIndex = 2;
            this.lblCORFile.Visible = false;
            // 
            // btnUploadCOR
            // 
            this.btnUploadCOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnUploadCOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadCOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadCOR.ForeColor = System.Drawing.Color.White;
            this.btnUploadCOR.Location = new System.Drawing.Point(21, 140);
            this.btnUploadCOR.Name = "btnUploadCOR";
            this.btnUploadCOR.Size = new System.Drawing.Size(200, 30);
            this.btnUploadCOR.TabIndex = 1;
            this.btnUploadCOR.Text = "📋 Upload Certificate of Registration";
            this.btnUploadCOR.UseVisualStyleBackColor = false;
            // 
            // lblCOEFile
            // 
            this.lblCOEFile.AutoSize = true;
            this.lblCOEFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblCOEFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblCOEFile.Location = new System.Drawing.Point(18, 115);
            this.lblCOEFile.Name = "lblCOEFile";
            this.lblCOEFile.Size = new System.Drawing.Size(0, 13);
            this.lblCOEFile.TabIndex = 2;
            this.lblCOEFile.Visible = false;
            // 
            // btnUploadCOE
            // 
            this.btnUploadCOE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnUploadCOE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadCOE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadCOE.ForeColor = System.Drawing.Color.White;
            this.btnUploadCOE.Location = new System.Drawing.Point(21, 80);
            this.btnUploadCOE.Name = "btnUploadCOE";
            this.btnUploadCOE.Size = new System.Drawing.Size(200, 30);
            this.btnUploadCOE.TabIndex = 1;
            this.btnUploadCOE.Text = "📝 Upload Certificate of Enrollment";
            this.btnUploadCOE.UseVisualStyleBackColor = false;
            // 
            // lblPSAFile
            // 
            this.lblPSAFile.AutoSize = true;
            this.lblPSAFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblPSAFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblPSAFile.Location = new System.Drawing.Point(18, 55);
            this.lblPSAFile.Name = "lblPSAFile";
            this.lblPSAFile.Size = new System.Drawing.Size(0, 13);
            this.lblPSAFile.TabIndex = 2;
            this.lblPSAFile.Visible = false;
            // 
            // btnUploadPSA
            // 
            this.btnUploadPSA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.btnUploadPSA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadPSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadPSA.ForeColor = System.Drawing.Color.White;
            this.btnUploadPSA.Location = new System.Drawing.Point(21, 20);
            this.btnUploadPSA.Name = "btnUploadPSA";
            this.btnUploadPSA.Size = new System.Drawing.Size(200, 30);
            this.btnUploadPSA.TabIndex = 1;
            this.btnUploadPSA.Text = "📎 Upload PSA Birth Certificate";
            this.btnUploadPSA.UseVisualStyleBackColor = false;
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
            this.labelFiles.Location = new System.Drawing.Point(3, 0);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(170, 17);
            this.labelFiles.TabIndex = 0;
            this.labelFiles.Text = "Required Documents:*";
            // 
            // txtNotes
            // 
            this.txtNotes.BorderColor = System.Drawing.Color.Black;
            this.txtNotes.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtNotes.BorderRadius = 5;
            this.txtNotes.BorderSize = 2;
            this.txtNotes.Icon = null;
            this.txtNotes.IconSize = new System.Drawing.Size(20, 20);
            this.txtNotes.Location = new System.Drawing.Point(868, 290);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PasswordChar = false;
            this.txtNotes.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNotes.PlaceholderText = "Any additional information...";
            this.txtNotes.Size = new System.Drawing.Size(453, 60);
            this.txtNotes.TabIndex = 1;
            this.txtNotes.Texts = "";
            this.txtNotes.UnderlinedStyle = false;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNotes.ForeColor = System.Drawing.Color.Black;
            this.labelNotes.Location = new System.Drawing.Point(865, 270);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(49, 17);
            this.labelNotes.TabIndex = 0;
            this.labelNotes.Text = "Notes:";
            // 
            // dtpExpectedGraduation
            // 
            this.dtpExpectedGraduation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpExpectedGraduation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpectedGraduation.Location = new System.Drawing.Point(300, 97);
            this.dtpExpectedGraduation.Name = "dtpExpectedGraduation";
            this.dtpExpectedGraduation.Size = new System.Drawing.Size(243, 21);
            this.dtpExpectedGraduation.TabIndex = 3;
            // 
            // labelExpGrad
            // 
            this.labelExpGrad.AutoSize = true;
            this.labelExpGrad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelExpGrad.ForeColor = System.Drawing.Color.Black;
            this.labelExpGrad.Location = new System.Drawing.Point(300, 78);
            this.labelExpGrad.Name = "labelExpGrad";
            this.labelExpGrad.Size = new System.Drawing.Size(179, 17);
            this.labelExpGrad.TabIndex = 0;
            this.labelExpGrad.Text = "Expected Graduation Date:";
            // 
            // dtpEnrollmentDate
            // 
            this.dtpEnrollmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpEnrollmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnrollmentDate.Location = new System.Drawing.Point(302, 49);
            this.dtpEnrollmentDate.Name = "dtpEnrollmentDate";
            this.dtpEnrollmentDate.Size = new System.Drawing.Size(243, 21);
            this.dtpEnrollmentDate.TabIndex = 3;
            // 
            // labelEnrollDate
            // 
            this.labelEnrollDate.AutoSize = true;
            this.labelEnrollDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelEnrollDate.ForeColor = System.Drawing.Color.Black;
            this.labelEnrollDate.Location = new System.Drawing.Point(299, 29);
            this.labelEnrollDate.Name = "labelEnrollDate";
            this.labelEnrollDate.Size = new System.Drawing.Size(113, 17);
            this.labelEnrollDate.TabIndex = 0;
            this.labelEnrollDate.Text = "Enrollment Date:";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Items.AddRange(new object[] {
            "1st Year",
            "2nd Year",
            "3rd Year",
            "4th Year",
            "5th Year"});
            this.cmbYearLevel.Location = new System.Drawing.Point(300, 231);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(243, 23);
            this.cmbYearLevel.TabIndex = 4;
            // 
            // labelYearLevel
            // 
            this.labelYearLevel.AutoSize = true;
            this.labelYearLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelYearLevel.ForeColor = System.Drawing.Color.Black;
            this.labelYearLevel.Location = new System.Drawing.Point(304, 211);
            this.labelYearLevel.Name = "labelYearLevel";
            this.labelYearLevel.Size = new System.Drawing.Size(80, 17);
            this.labelYearLevel.TabIndex = 0;
            this.labelYearLevel.Text = "Year Level:";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbGender.Location = new System.Drawing.Point(299, 186);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(243, 23);
            this.cmbGender.TabIndex = 4;
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelGender.ForeColor = System.Drawing.Color.Black;
            this.labelGender.Location = new System.Drawing.Point(304, 168);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(60, 17);
            this.labelGender.TabIndex = 0;
            this.labelGender.Text = "Gender:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(301, 143);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(243, 21);
            this.dtpDateOfBirth.TabIndex = 3;
            // 
            // labelDOB
            // 
            this.labelDOB.AutoSize = true;
            this.labelDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDOB.ForeColor = System.Drawing.Color.Black;
            this.labelDOB.Location = new System.Drawing.Point(304, 124);
            this.labelDOB.Name = "labelDOB";
            this.labelDOB.Size = new System.Drawing.Size(91, 17);
            this.labelDOB.TabIndex = 0;
            this.labelDOB.Text = "Date of Birth:";
            // 
            // cmbProgram
            // 
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Items.AddRange(new object[] {
            "Undergraduate",
            "Graduate",
            "Post-Graduate",
            "Doctorate"});
            this.cmbProgram.Location = new System.Drawing.Point(301, 277);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(243, 23);
            this.cmbProgram.TabIndex = 4;
            // 
            // labelProgram
            // 
            this.labelProgram.AutoSize = true;
            this.labelProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelProgram.ForeColor = System.Drawing.Color.Black;
            this.labelProgram.Location = new System.Drawing.Point(304, 257);
            this.labelProgram.Name = "labelProgram";
            this.labelProgram.Size = new System.Drawing.Size(66, 17);
            this.labelProgram.TabIndex = 0;
            this.labelProgram.Text = "Program:";
            // 
            // cmbScholarshipType
            // 
            this.cmbScholarshipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScholarshipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbScholarshipType.FormattingEnabled = true;
            this.cmbScholarshipType.Location = new System.Drawing.Point(307, 406);
            this.cmbScholarshipType.Name = "cmbScholarshipType";
            this.cmbScholarshipType.Size = new System.Drawing.Size(235, 23);
            this.cmbScholarshipType.TabIndex = 4;
            // 
            // labelScholarship
            // 
            this.labelScholarship.AutoSize = true;
            this.labelScholarship.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelScholarship.ForeColor = System.Drawing.Color.Black;
            this.labelScholarship.Location = new System.Drawing.Point(304, 386);
            this.labelScholarship.Name = "labelScholarship";
            this.labelScholarship.Size = new System.Drawing.Size(122, 17);
            this.labelScholarship.TabIndex = 0;
            this.labelScholarship.Text = "Scholarship Type:";
            // 
            // txtBankAccountNumber
            // 
            this.txtBankAccountNumber.BorderColor = System.Drawing.Color.Black;
            this.txtBankAccountNumber.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtBankAccountNumber.BorderRadius = 5;
            this.txtBankAccountNumber.BorderSize = 2;
            this.txtBankAccountNumber.Icon = null;
            this.txtBankAccountNumber.IconSize = new System.Drawing.Size(20, 20);
            this.txtBankAccountNumber.Location = new System.Drawing.Point(599, 109);
            this.txtBankAccountNumber.Multiline = false;
            this.txtBankAccountNumber.Name = "txtBankAccountNumber";
            this.txtBankAccountNumber.PasswordChar = false;
            this.txtBankAccountNumber.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtBankAccountNumber.PlaceholderText = "Account Number";
            this.txtBankAccountNumber.Size = new System.Drawing.Size(243, 33);
            this.txtBankAccountNumber.TabIndex = 1;
            this.txtBankAccountNumber.Texts = "";
            this.txtBankAccountNumber.UnderlinedStyle = false;
            // 
            // labelBankAccount
            // 
            this.labelBankAccount.AutoSize = true;
            this.labelBankAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelBankAccount.ForeColor = System.Drawing.Color.Black;
            this.labelBankAccount.Location = new System.Drawing.Point(596, 89);
            this.labelBankAccount.Name = "labelBankAccount";
            this.labelBankAccount.Size = new System.Drawing.Size(153, 17);
            this.labelBankAccount.TabIndex = 0;
            this.labelBankAccount.Text = "Bank Account Number:";
            // 
            // txtBankName
            // 
            this.txtBankName.BorderColor = System.Drawing.Color.Black;
            this.txtBankName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtBankName.BorderRadius = 5;
            this.txtBankName.BorderSize = 2;
            this.txtBankName.Icon = null;
            this.txtBankName.IconSize = new System.Drawing.Size(20, 20);
            this.txtBankName.Location = new System.Drawing.Point(599, 49);
            this.txtBankName.Multiline = false;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.PasswordChar = false;
            this.txtBankName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtBankName.PlaceholderText = "Bank Name";
            this.txtBankName.Size = new System.Drawing.Size(243, 33);
            this.txtBankName.TabIndex = 1;
            this.txtBankName.Texts = "";
            this.txtBankName.UnderlinedStyle = false;
            // 
            // labelBankName
            // 
            this.labelBankName.AutoSize = true;
            this.labelBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelBankName.ForeColor = System.Drawing.Color.Black;
            this.labelBankName.Location = new System.Drawing.Point(596, 29);
            this.labelBankName.Name = "labelBankName";
            this.labelBankName.Size = new System.Drawing.Size(85, 17);
            this.labelBankName.TabIndex = 0;
            this.labelBankName.Text = "Bank Name:";
            // 
            // txtSuffix
            // 
            this.txtSuffix.BorderColor = System.Drawing.Color.Black;
            this.txtSuffix.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtSuffix.BorderRadius = 5;
            this.txtSuffix.BorderSize = 2;
            this.txtSuffix.Icon = null;
            this.txtSuffix.IconSize = new System.Drawing.Size(20, 20);
            this.txtSuffix.Location = new System.Drawing.Point(26, 290);
            this.txtSuffix.Multiline = false;
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.PasswordChar = false;
            this.txtSuffix.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSuffix.PlaceholderText = "Jr., Sr., III, etc.";
            this.txtSuffix.Size = new System.Drawing.Size(243, 33);
            this.txtSuffix.TabIndex = 1;
            this.txtSuffix.Texts = "";
            this.txtSuffix.UnderlinedStyle = false;
            // 
            // labelSuffix
            // 
            this.labelSuffix.AutoSize = true;
            this.labelSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSuffix.ForeColor = System.Drawing.Color.Black;
            this.labelSuffix.Location = new System.Drawing.Point(23, 270);
            this.labelSuffix.Name = "labelSuffix";
            this.labelSuffix.Size = new System.Drawing.Size(46, 17);
            this.labelSuffix.TabIndex = 0;
            this.labelSuffix.Text = "Suffix:";
            // 
            // sataComboBox1
            // 
            this.sataComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.sataComboBox1.BackgroundColor = System.Drawing.Color.White;
            this.sataComboBox1.BorderColor = System.Drawing.Color.Black;
            this.sataComboBox1.BorderThickness = 1;
            this.sataComboBox1.CornerRadius = 5;
            this.sataComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sataComboBox1.Items = new string[] {
        "BS in Business Administration - Financial Management",
        "BS in Business Administration - Marketing Management",
        "BS in Business Administration - Human Resource Management",
        "Bachelor of Science in Criminology",
        "Bachelor of Elementary Education - Generalist",
        "Bachelor of Secondary Education - English",
        "Bachelor of Secondary Education - Social Studies",
        "Bachelor of Secondary Education - Values Education",
        "Bachelor of Science in Information Technology",
        "Bachelor of Science in Tourism Management"};
            this.sataComboBox1.Keys = null;
            this.sataComboBox1.Location = new System.Drawing.Point(300, 324);
            this.sataComboBox1.Name = "sataComboBox1";
            this.sataComboBox1.SelectedIndex = -1;
            this.sataComboBox1.Size = new System.Drawing.Size(242, 43);
            this.sataComboBox1.TabIndex = 4;
            this.sataComboBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.sataComboBox1.TextOffset = new System.Windows.Forms.Padding(0);
            // 
            // sataButton1
            // 
            this.sataButton1.BackColor = System.Drawing.Color.Transparent;
            this.sataButton1.ButtonText = "SUBMIT APPLICATION";
            this.sataButton1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(85)))), ((int)(((byte)(80)))));
            this.sataButton1.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton1.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton1.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.sataButton1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.sataButton1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(109)))), ((int)(((byte)(104)))));
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
            this.sataButton1.Location = new System.Drawing.Point(405, 512);
            this.sataButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sataButton1.Name = "sataButton1";
            this.sataButton1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(85)))), ((int)(((byte)(80)))));
            this.sataButton1.NormalForeColor = System.Drawing.Color.White;
            this.sataButton1.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton1.OutlineThickness = 2F;
            this.sataButton1.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(64)))), ((int)(((byte)(61)))));
            this.sataButton1.PressedForeColor = System.Drawing.Color.White;
            this.sataButton1.PressedImageTint = System.Drawing.Color.White;
            this.sataButton1.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton1.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton1.Size = new System.Drawing.Size(630, 48);
            this.sataButton1.TabIndex = 3;
            this.sataButton1.TextAutoCenter = true;
            this.sataButton1.TextOffset = new System.Drawing.Point(0, 0);
            this.sataButton1.Click += new System.EventHandler(this.sataButton1_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderColor = System.Drawing.Color.Black;
            this.txtAddress.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtAddress.BorderRadius = 5;
            this.txtAddress.BorderSize = 2;
            this.txtAddress.Icon = null;
            this.txtAddress.IconSize = new System.Drawing.Size(20, 20);
            this.txtAddress.Location = new System.Drawing.Point(30, 462);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = false;
            this.txtAddress.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAddress.PlaceholderText = "Complete Address";
            this.txtAddress.Size = new System.Drawing.Size(239, 61);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Texts = "";
            this.txtAddress.UnderlinedStyle = false;
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.BorderColor = System.Drawing.Color.Black;
            this.txtContactNumber.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtContactNumber.BorderRadius = 5;
            this.txtContactNumber.BorderSize = 2;
            this.txtContactNumber.Icon = null;
            this.txtContactNumber.IconSize = new System.Drawing.Size(20, 20);
            this.txtContactNumber.Location = new System.Drawing.Point(26, 406);
            this.txtContactNumber.Multiline = false;
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.PasswordChar = false;
            this.txtContactNumber.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtContactNumber.PlaceholderText = "Contact Number";
            this.txtContactNumber.Size = new System.Drawing.Size(243, 33);
            this.txtContactNumber.TabIndex = 1;
            this.txtContactNumber.Texts = "";
            this.txtContactNumber.UnderlinedStyle = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderColor = System.Drawing.Color.Black;
            this.txtEmail.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.BorderSize = 2;
            this.txtEmail.Icon = null;
            this.txtEmail.IconSize = new System.Drawing.Size(20, 20);
            this.txtEmail.Location = new System.Drawing.Point(26, 346);
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = false;
            this.txtEmail.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmail.PlaceholderText = "Email Address";
            this.txtEmail.Size = new System.Drawing.Size(243, 33);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Texts = "";
            this.txtEmail.UnderlinedStyle = false;
            // 
            // txtHEI
            // 
            this.txtHEI.BorderColor = System.Drawing.Color.Black;
            this.txtHEI.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtHEI.BorderRadius = 5;
            this.txtHEI.BorderSize = 2;
            this.txtHEI.Icon = null;
            this.txtHEI.IconSize = new System.Drawing.Size(20, 20);
            this.txtHEI.Location = new System.Drawing.Point(601, 170);
            this.txtHEI.Multiline = false;
            this.txtHEI.Name = "txtHEI";
            this.txtHEI.PasswordChar = false;
            this.txtHEI.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtHEI.PlaceholderText = "Legacy College of Compostela";
            this.txtHEI.Size = new System.Drawing.Size(243, 33);
            this.txtHEI.TabIndex = 1;
            this.txtHEI.Texts = "";
            this.txtHEI.UnderlinedStyle = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline);
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(778, 575);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "Log In";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(606, 575);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(173, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Already have an account?";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(27, 442);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Address:";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BorderColor = System.Drawing.Color.Black;
            this.txtMiddleName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtMiddleName.BorderRadius = 5;
            this.txtMiddleName.BorderSize = 2;
            this.txtMiddleName.Icon = null;
            this.txtMiddleName.IconSize = new System.Drawing.Size(20, 20);
            this.txtMiddleName.Location = new System.Drawing.Point(26, 234);
            this.txtMiddleName.Multiline = false;
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.PasswordChar = false;
            this.txtMiddleName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtMiddleName.PlaceholderText = "";
            this.txtMiddleName.Size = new System.Drawing.Size(243, 33);
            this.txtMiddleName.TabIndex = 1;
            this.txtMiddleName.Texts = "";
            this.txtMiddleName.UnderlinedStyle = false;
            // 
            // txtLastName
            // 
            this.txtLastName.BorderColor = System.Drawing.Color.Black;
            this.txtLastName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtLastName.BorderRadius = 5;
            this.txtLastName.BorderSize = 2;
            this.txtLastName.Icon = null;
            this.txtLastName.IconSize = new System.Drawing.Size(20, 20);
            this.txtLastName.Location = new System.Drawing.Point(26, 169);
            this.txtLastName.Multiline = false;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PasswordChar = false;
            this.txtLastName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtLastName.PlaceholderText = "";
            this.txtLastName.Size = new System.Drawing.Size(243, 33);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.Texts = "";
            this.txtLastName.UnderlinedStyle = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(23, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Contact Number:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderColor = System.Drawing.Color.Black;
            this.txtFirstName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtFirstName.BorderRadius = 5;
            this.txtFirstName.BorderSize = 2;
            this.txtFirstName.Icon = null;
            this.txtFirstName.IconSize = new System.Drawing.Size(20, 20);
            this.txtFirstName.Location = new System.Drawing.Point(26, 104);
            this.txtFirstName.Multiline = false;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PasswordChar = false;
            this.txtFirstName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFirstName.PlaceholderText = "";
            this.txtFirstName.Size = new System.Drawing.Size(243, 33);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Texts = "";
            this.txtFirstName.UnderlinedStyle = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(598, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(221, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "HEI (Higher Education Institution):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(304, 306);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Degree Program:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(23, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Middle Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(23, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Last Name:";
            // 
            // txtStudentID
            // 
            this.txtStudentID.BorderColor = System.Drawing.Color.Black;
            this.txtStudentID.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(72)))), ((int)(((byte)(73)))));
            this.txtStudentID.BorderRadius = 5;
            this.txtStudentID.BorderSize = 2;
            this.txtStudentID.Icon = null;
            this.txtStudentID.IconSize = new System.Drawing.Size(20, 20);
            this.txtStudentID.Location = new System.Drawing.Point(26, 49);
            this.txtStudentID.Multiline = false;
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.PasswordChar = false;
            this.txtStudentID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtStudentID.PlaceholderText = "";
            this.txtStudentID.Size = new System.Drawing.Size(243, 33);
            this.txtStudentID.TabIndex = 1;
            this.txtStudentID.Texts = "";
            this.txtStudentID.UnderlinedStyle = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "First Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(23, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Student ID: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label13.ForeColor = System.Drawing.Color.Snow;
            this.label13.Location = new System.Drawing.Point(561, 854);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(481, 48);
            this.label13.TabIndex = 0;
            this.label13.Text = "\"Take control of your scholarship records and track your \r\ndisbursements and payr" +
    "oll for easy access\"";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitBtn2
            // 
            this.ExitBtn2.BackColor = System.Drawing.Color.Transparent;
            this.ExitBtn2.Image = global::SkolarAid.Properties.Resources.reject;
            this.ExitBtn2.Location = new System.Drawing.Point(1514, 12);
            this.ExitBtn2.Name = "ExitBtn2";
            this.ExitBtn2.Size = new System.Drawing.Size(58, 33);
            this.ExitBtn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ExitBtn2.TabIndex = 9;
            this.ExitBtn2.TabStop = false;
            this.ExitBtn2.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SkolarAid.Properties.Resources.BackgroundImage2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 911);
            this.ControlBox = false;
            this.Controls.Add(this.ExitBtn2);
            this.Controls.Add(this.sataPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scholar Registration";
            this.Load += new System.EventHandler(this.Login_Load);
            this.sataPanel1.ResumeLayout(false);
            this.sataPanel1.PerformLayout();
            this.panelAutoFilledInfo.ResumeLayout(false);
            this.panelAutoFilledInfo.PerformLayout();
            this.panelFiles.ResumeLayout(false);
            this.panelFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBtn2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private SATAUiFramework.SATAPanel sataPanel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox ExitBtn2;

        // Updated control declarations
        private SATATextBox txtStudentID;
        private SATATextBox txtFirstName;
        private SATATextBox txtMiddleName;
        private SATATextBox txtLastName;
        private SATATextBox txtSuffix;
        private SATATextBox txtEmail;
        private SATATextBox txtContactNumber;
        private SATATextBox txtHEI;
        private SATATextBox txtAddress;
        private SATATextBox txtBankName;
        private SATATextBox txtBankAccountNumber;
        private SATATextBox txtNotes;

        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.ComboBox cmbScholarshipType;

        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpEnrollmentDate;
        private System.Windows.Forms.DateTimePicker dtpExpectedGraduation;

        private SATAComboBox sataComboBox1;
        private FrameworkTest.SATAButton sataButton1;

        // Auto-filled info panel
        private System.Windows.Forms.Panel panelAutoFilledInfo;
        private System.Windows.Forms.Label labelAutoFillTitle;
        private System.Windows.Forms.Label labelAutoStipendAmt;
        private System.Windows.Forms.Label labelAutoStipendFreq;
        private System.Windows.Forms.Label labelAutoFundSource;
        private System.Windows.Forms.Label labelAutoRenewal;
        private System.Windows.Forms.Label lblAutoStipendAmount;
        private System.Windows.Forms.Label lblAutoStipendFrequency;
        private System.Windows.Forms.Label lblAutoFundSource;
        private System.Windows.Forms.Label lblAutoRenewalConditions;

        // File upload controls
        private System.Windows.Forms.Panel panelFiles;
        private System.Windows.Forms.Button btnUploadPSA;
        private System.Windows.Forms.Button btnUploadCOE;
        private System.Windows.Forms.Button btnUploadCOR;
        private System.Windows.Forms.Button btnUploadGrades;
        private System.Windows.Forms.Button btnUploadContract;
        private System.Windows.Forms.Label lblPSAFile;
        private System.Windows.Forms.Label lblCOEFile;
        private System.Windows.Forms.Label lblCORFile;
        private System.Windows.Forms.Label lblGradesFile;
        private System.Windows.Forms.Label lblContractFile;
        private System.Windows.Forms.Label labelFiles;

        // Labels
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelProgram;
        private System.Windows.Forms.Label labelDOB;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelYearLevel;
        private System.Windows.Forms.Label labelEnrollDate;
        private System.Windows.Forms.Label labelExpGrad;
        private System.Windows.Forms.Label labelScholarship;
        private System.Windows.Forms.Label labelBankName;
        private System.Windows.Forms.Label labelBankAccount;
        private System.Windows.Forms.Label labelSuffix;
        private System.Windows.Forms.Label labelNotes;
    }
}