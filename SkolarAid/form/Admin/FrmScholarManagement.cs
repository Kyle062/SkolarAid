using MySql.Data.MySqlClient;
using SkolarAid.Classes;
using SkolarAid.Data;
using SkolarAid.form;
using SkolarAid.form.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class FrmScholarManagement : Form
    {
        private int _currentScholarId = 0;
        private TabControl tabControlMain;
        private TabPage tabScholarList;
        private TabPage tabCompliance;
        private DataGridView dgvCompliance;
        private Panel panelComplianceHeader;
        private Label lblComplianceTitle;
        private Label lblComplianceScholar;
        private Label lblComplianceDetails;
        private Label lblComplianceOverall;
        private SATAUiFramework.SATAPanel panelComplianceForm;
        private Panel panelScholarshipSummary;
        private FrameworkTest.SATAButton btnUpdateStatus;
        private FrameworkTest.SATAButton btnUploadFile;
        private FrameworkTest.SATAButton btnMarkMissing;
        private FrameworkTest.SATAButton btnRemindCompliance;
        private FrameworkTest.SATAButton btnDeleteFile;
        private ComboBox cmbComplianceScholar;
        private OpenFileDialog complianceOpenFileDialog;

        // File attachment combo boxes
        private ComboBox cmbFilePSA;
        private ComboBox cmbFileCOE;
        private ComboBox cmbFileCOR;
        private ComboBox cmbFileGrades;
        private ComboBox cmbFileContract;
        private TextBox txtFilePSAPath;
        private TextBox txtFileCOEPath;
        private TextBox txtFileCORPath;
        private TextBox txtFileGradesPath;
        private TextBox txtFileContractPath;

        private Dictionary<string, byte[]> _loadedFileData = new Dictionary<string, byte[]>();
        private Dictionary<string, string> _loadedFileNames = new Dictionary<string, string>();
        private bool _filesModified = false;

        // CORRECT MAPPING: DB enum value -> Display name -> Description -> Doc Key
        // DB enum values: 'PSA Birth Certificate', 'Enrollment Form', 'COR', 'Grades', 'Scholarship Contract'
        private readonly string[] _dbTypes = {
            "PSA Birth Certificate",
            "Enrollment Form",
            "COR",
            "Grades",
            "Scholarship Contract"
        };

        private readonly string[] _displayNames = {
            "PSA Birth Certificate",
            "COE (Current Sem)",
            "COR",
            "Latest Grades",
            "Scholarship Contract"
        };

        private readonly string[] _descriptions = {
            "Submit PSA Birth Certificate",
            "Certificate of Enrollment (current semester)",
            "Certificate of Registration",
            "Latest grades and transcript of records",
            "Signed and notarized scholarship contract"
        };

        private readonly string[] _docKeys = { "PSA", "COE", "COR", "Grades", "Contract" };

        public FrmScholarManagement()
        {
            InitializeComponent();
            InitializeFileAttachmentControls();
            InitializeTabControl();
            this.Load += FrmScholarManagement_Load;
            this.Resize += FrmScholarManagement_Resize;
            sataButton1.Click += sataButton1_Click;
        }

        private void InitializeFileAttachmentControls()
        {
            cmbFilePSA = comboBox1;
            cmbFileCOE = comboBox2;
            cmbFileCOR = comboBox3;
            cmbFileGrades = comboBox4;
            cmbFileContract = comboBox5;

            txtFilePSAPath = new TextBox { Visible = false };
            txtFileCOEPath = new TextBox { Visible = false };
            txtFileCORPath = new TextBox { Visible = false };
            txtFileGradesPath = new TextBox { Visible = false };
            txtFileContractPath = new TextBox { Visible = false };

            panelForm.Controls.Add(txtFilePSAPath);
            panelForm.Controls.Add(txtFileCOEPath);
            panelForm.Controls.Add(txtFileCORPath);
            panelForm.Controls.Add(txtFileGradesPath);
            panelForm.Controls.Add(txtFileContractPath);

            complianceOpenFileDialog = new OpenFileDialog
            {
                Title = "Select Document",
                Filter = "All Supported Files|*.pdf;*.jpg;*.jpeg;*.png;*.doc;*.docx|PDF Files|*.pdf|Image Files|*.jpg;*.jpeg;*.png|Word Documents|*.doc;*.docx|All Files|*.*",
                FilterIndex = 1
            };

            void HandleFileSelection(ComboBox cmb, TextBox txtPath, string docKey)
            {
                if (cmb.SelectedIndex == 1)
                {
                    if (complianceOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtPath.Text = complianceOpenFileDialog.FileName;
                        string fileName = complianceOpenFileDialog.SafeFileName;
                        long fileSizeKB = new FileInfo(complianceOpenFileDialog.FileName).Length / 1024;

                        byte[] fileData = File.ReadAllBytes(complianceOpenFileDialog.FileName);
                        _loadedFileData[docKey] = fileData;
                        _loadedFileNames[docKey] = fileName;
                        _filesModified = true;

                        cmb.Items.Clear();
                        cmb.Items.Add("TBA (To be Arranged)");
                        cmb.Items.Add($"✅ {fileName} ({fileSizeKB} KB) - Attached");
                        cmb.Items.Add("Change File...");
                        cmb.Items.Add("Remove File");
                        cmb.SelectedIndex = 1;
                        cmb.BackColor = Color.FromArgb(220, 255, 220);
                        cmb.ForeColor = Color.FromArgb(0, 100, 0);
                        cmb.Tag = "attached";
                    }
                    else
                    {
                        cmb.SelectedIndex = 0;
                    }
                }
                else if (cmb.SelectedIndex == 2)
                {
                    if (complianceOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtPath.Text = complianceOpenFileDialog.FileName;
                        string fileName = complianceOpenFileDialog.SafeFileName;
                        long fileSizeKB = new FileInfo(complianceOpenFileDialog.FileName).Length / 1024;

                        byte[] fileData = File.ReadAllBytes(complianceOpenFileDialog.FileName);
                        _loadedFileData[docKey] = fileData;
                        _loadedFileNames[docKey] = fileName;
                        _filesModified = true;

                        cmb.Items.Clear();
                        cmb.Items.Add("TBA (To be Arranged)");
                        cmb.Items.Add($"✅ {fileName} ({fileSizeKB} KB) - Attached");
                        cmb.Items.Add("Change File...");
                        cmb.Items.Add("Remove File");
                        cmb.SelectedIndex = 1;
                        cmb.BackColor = Color.FromArgb(220, 255, 220);
                        cmb.ForeColor = Color.FromArgb(0, 100, 0);
                        cmb.Tag = "attached";
                    }
                    else
                    {
                        cmb.SelectedIndex = 1;
                    }
                }
                else if (cmb.SelectedIndex == 3)
                {
                    txtPath.Text = "";
                    _loadedFileData.Remove(docKey);
                    _loadedFileNames.Remove(docKey);
                    _filesModified = true;
                    cmb.Tag = null;
                    cmb.BackColor = Color.White;
                    cmb.ForeColor = Color.Black;
                    cmb.Items.Clear();
                    cmb.Items.Add("TBA (To be Arranged)");
                    cmb.Items.Add("Attach File");
                    cmb.SelectedIndex = 0;
                }
                else if (cmb.SelectedIndex == 0)
                {
                    txtPath.Text = "";
                    _loadedFileData.Remove(docKey);
                    _loadedFileNames.Remove(docKey);
                    _filesModified = true;
                    cmb.Tag = null;
                    cmb.BackColor = Color.White;
                    cmb.ForeColor = Color.Black;
                    cmb.Items.Clear();
                    cmb.Items.Add("TBA (To be Arranged)");
                    cmb.Items.Add("Attach File");
                }
            }

            cmbFilePSA.SelectedIndexChanged += (s, e) =>
            {
                if (cmbFilePSA.Tag?.ToString() == "updating") return;
                cmbFilePSA.Tag = "updating";
                HandleFileSelection(cmbFilePSA, txtFilePSAPath, "PSA");
                if (cmbFilePSA.Tag?.ToString() == "updating") cmbFilePSA.Tag = null;
            };

            cmbFileCOE.SelectedIndexChanged += (s, e) =>
            {
                if (cmbFileCOE.Tag?.ToString() == "updating") return;
                cmbFileCOE.Tag = "updating";
                HandleFileSelection(cmbFileCOE, txtFileCOEPath, "COE");
                if (cmbFileCOE.Tag?.ToString() == "updating") cmbFileCOE.Tag = null;
            };

            cmbFileCOR.SelectedIndexChanged += (s, e) =>
            {
                if (cmbFileCOR.Tag?.ToString() == "updating") return;
                cmbFileCOR.Tag = "updating";
                HandleFileSelection(cmbFileCOR, txtFileCORPath, "COR");
                if (cmbFileCOR.Tag?.ToString() == "updating") cmbFileCOR.Tag = null;
            };

            cmbFileGrades.SelectedIndexChanged += (s, e) =>
            {
                if (cmbFileGrades.Tag?.ToString() == "updating") return;
                cmbFileGrades.Tag = "updating";
                HandleFileSelection(cmbFileGrades, txtFileGradesPath, "Grades");
                if (cmbFileGrades.Tag?.ToString() == "updating") cmbFileGrades.Tag = null;
            };

            cmbFileContract.SelectedIndexChanged += (s, e) =>
            {
                if (cmbFileContract.Tag?.ToString() == "updating") return;
                cmbFileContract.Tag = "updating";
                HandleFileSelection(cmbFileContract, txtFileContractPath, "Contract");
                if (cmbFileContract.Tag?.ToString() == "updating") cmbFileContract.Tag = null;
            };
        }

        private ComboBox GetComboBoxForDbType(string dbType)
        {
            switch (dbType)
            {
                case "PSA Birth Certificate": return cmbFilePSA;
                case "Enrollment Form": return cmbFileCOE;
                case "COR": return cmbFileCOR;
                case "Grades": return cmbFileGrades;
                case "Scholarship Contract": return cmbFileContract;
                default: return null;
            }
        }

        private string GetDisplayNameForDbType(string dbType)
        {
            for (int i = 0; i < _dbTypes.Length; i++)
            {
                if (_dbTypes[i] == dbType) return _displayNames[i];
            }
            return dbType;
        }

        private string GetDocKeyForDbType(string dbType)
        {
            for (int i = 0; i < _dbTypes.Length; i++)
            {
                if (_dbTypes[i] == dbType) return _docKeys[i];
            }
            return "";
        }

        private void InitializeTabControl()
        {
            tabControlMain = new TabControl();
            tabControlMain.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            tabControlMain.Location = new Point(301, 255);
            tabControlMain.Size = new Size(1596, 800);
            tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;

            tabScholarList = new TabPage();
            tabScholarList.Text = "Scholar Management";
            tabScholarList.BackColor = Color.FromArgb(243, 244, 246);
            tabScholarList.AutoScroll = true;
            panelForm.AutoScroll = true;
            panelForm.HorizontalScroll.Enabled = false;
            tabScholarList.Controls.Add(panelScholarList);
            tabScholarList.Controls.Add(panelForm);

            tabCompliance = new TabPage();
            tabCompliance.Text = "Compliance Tracking";
            tabCompliance.BackColor = Color.FromArgb(243, 244, 246);
            InitializeComplianceTab();

            tabControlMain.TabPages.Add(tabScholarList);
            tabControlMain.TabPages.Add(tabCompliance);
            this.panelContent.Controls.Add(tabControlMain);

            panelForm.Enabled = true;
            panelForm.Visible = true;
            foreach (Control ctrl in panelForm.Controls)
            {
                ctrl.Enabled = true;
                ctrl.Visible = true;
            }

            btnSave.Visible = true;
            btnSave.Size = new Size(152, 35);
            btnSave.ButtonText = "Add new Scholar";
            btnSave.Enabled = true;
        }

        private void InitializeComplianceTab()
        {
            panelComplianceHeader = new Panel();
            panelComplianceHeader.BackColor = Color.White;
            panelComplianceHeader.Location = new Point(20, 20);
            panelComplianceHeader.Size = new Size(1550, 130);
            panelComplianceHeader.BorderStyle = BorderStyle.FixedSingle;

            lblComplianceTitle = new Label();
            lblComplianceTitle.Text = "Compliance Tracking";
            lblComplianceTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblComplianceTitle.ForeColor = Color.FromArgb(0, 68, 79);
            lblComplianceTitle.Location = new Point(20, 10);
            lblComplianceTitle.Size = new Size(300, 30);

            lblComplianceScholar = new Label();
            lblComplianceScholar.Text = "Please select a scholar";
            lblComplianceScholar.Font = new Font("Century Gothic", 12F, FontStyle.Regular);
            lblComplianceScholar.ForeColor = Color.FromArgb(80, 80, 80);
            lblComplianceScholar.Location = new Point(20, 45);
            lblComplianceScholar.Size = new Size(700, 25);

            lblComplianceDetails = new Label();
            lblComplianceDetails.Text = "";
            lblComplianceDetails.Font = new Font("Century Gothic", 10F, FontStyle.Regular);
            lblComplianceDetails.ForeColor = Color.FromArgb(100, 100, 100);
            lblComplianceDetails.Location = new Point(20, 70);
            lblComplianceDetails.Size = new Size(700, 20);

            lblComplianceOverall = new Label();
            lblComplianceOverall.Text = "";
            lblComplianceOverall.Font = new Font("Century Gothic", 13F, FontStyle.Bold);
            lblComplianceOverall.ForeColor = Color.FromArgb(40, 167, 69);
            lblComplianceOverall.Location = new Point(20, 95);
            lblComplianceOverall.Size = new Size(700, 25);
            lblComplianceOverall.TextAlign = ContentAlignment.MiddleLeft;

            Label lblSelectScholar = new Label();
            lblSelectScholar.Text = "Select Scholar:";
            lblSelectScholar.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            lblSelectScholar.ForeColor = Color.FromArgb(0, 68, 79);
            lblSelectScholar.Location = new Point(800, 25);
            lblSelectScholar.Size = new Size(130, 25);

            cmbComplianceScholar = new ComboBox();
            cmbComplianceScholar.Font = new Font("Century Gothic", 11F);
            cmbComplianceScholar.Location = new Point(850, 50);
            cmbComplianceScholar.Size = new Size(350, 30);
            cmbComplianceScholar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbComplianceScholar.SelectedIndexChanged += CmbComplianceScholar_SelectedIndexChanged;

            panelComplianceHeader.Controls.Add(lblComplianceTitle);
            panelComplianceHeader.Controls.Add(lblComplianceScholar);
            panelComplianceHeader.Controls.Add(lblComplianceDetails);
            panelComplianceHeader.Controls.Add(lblComplianceOverall);
            panelComplianceHeader.Controls.Add(lblSelectScholar);
            panelComplianceHeader.Controls.Add(cmbComplianceScholar);

            dgvCompliance = new DataGridView();
            dgvCompliance.AllowUserToAddRows = false;
            dgvCompliance.AllowUserToDeleteRows = false;
            dgvCompliance.AllowUserToResizeRows = false;
            dgvCompliance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompliance.BackgroundColor = Color.White;
            dgvCompliance.BorderStyle = BorderStyle.None;
            dgvCompliance.ColumnHeadersHeight = 40;
            dgvCompliance.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 68, 79);
            dgvCompliance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCompliance.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            dgvCompliance.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCompliance.EnableHeadersVisualStyles = false;
            dgvCompliance.GridColor = Color.FromArgb(230, 230, 230);
            dgvCompliance.Location = new Point(20, 170);
            dgvCompliance.Size = new Size(1550, 370);
            dgvCompliance.MultiSelect = false;
            dgvCompliance.ReadOnly = true;
            dgvCompliance.RowHeadersVisible = false;
            dgvCompliance.RowTemplate.Height = 38;
            dgvCompliance.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10F);
            dgvCompliance.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgvCompliance.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 245, 245);
            dgvCompliance.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCompliance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompliance.CellDoubleClick += DgvCompliance_CellDoubleClick;

            dgvCompliance.Columns.Add("colReqType", "Requirement");
            dgvCompliance.Columns.Add("colDescription", "Description");
            dgvCompliance.Columns.Add("colStatus", "Status");
            dgvCompliance.Columns.Add("colDueDate", "Due Date");
            dgvCompliance.Columns.Add("colSubmitted", "Submitted");
            dgvCompliance.Columns.Add("colRemarks", "Remarks");
            dgvCompliance.Columns.Add("colFile", "File");
            dgvCompliance.Columns.Add("colComplianceID", "ID");
            dgvCompliance.Columns["colComplianceID"].Visible = false;

            dgvCompliance.Columns["colReqType"].FillWeight = 15;
            dgvCompliance.Columns["colDescription"].FillWeight = 25;
            dgvCompliance.Columns["colStatus"].FillWeight = 10;
            dgvCompliance.Columns["colDueDate"].FillWeight = 12;
            dgvCompliance.Columns["colSubmitted"].FillWeight = 12;
            dgvCompliance.Columns["colRemarks"].FillWeight = 20;
            dgvCompliance.Columns["colFile"].FillWeight = 6;

            panelComplianceForm = new SATAUiFramework.SATAPanel();
            panelComplianceForm.BackColor = Color.White;
            panelComplianceForm.BackColor2 = Color.White;
            panelComplianceForm.BorderRadius = new SATAUiFramework.BorderRadius
            {
                TopLeft = 10,
                TopRight = 10,
                BottomLeft = 10,
                BottomRight = 10
            };
            panelComplianceForm.Location = new Point(20, 560);
            panelComplianceForm.Size = new Size(1550, 50);

            btnUpdateStatus = CreateSATAButton("Update Status", Color.FromArgb(0, 123, 255), new Point(10, 8));
            btnUpdateStatus.Click += BtnUpdateStatus_Click;

            btnUploadFile = CreateSATAButton("Upload File", Color.FromArgb(40, 167, 69), new Point(175, 8));
            btnUploadFile.Click += BtnUploadFile_Click;

            btnDeleteFile = CreateSATAButton("Delete File", Color.FromArgb(200, 50, 50), new Point(340, 8));
            btnDeleteFile.Click += BtnDeleteFile_Click;

            btnMarkMissing = CreateSATAButton("Mark Missing", Color.FromArgb(255, 170, 0), new Point(505, 8));
            btnMarkMissing.Click += BtnMarkMissing_Click;

            btnRemindCompliance = CreateSATAButton("Remind", Color.FromArgb(220, 53, 69), new Point(670, 8));
            btnRemindCompliance.Click += BtnRemindCompliance_Click;

            FrameworkTest.SATAButton btnAddRequirement = CreateSATAButton("+ Add Requirement", Color.FromArgb(0, 68, 79), new Point(835, 8));
            btnAddRequirement.Click += BtnAddRequirement_Click;

            FrameworkTest.SATAButton btnDeleteRequirement = CreateSATAButton("Delete Requirement", Color.FromArgb(180, 30, 30), new Point(1000, 8));
            btnDeleteRequirement.Size = new Size(175, 35);
            btnDeleteRequirement.Click += BtnDeleteRequirement_Click;

            panelComplianceForm.Controls.Add(btnUpdateStatus);
            panelComplianceForm.Controls.Add(btnUploadFile);
            panelComplianceForm.Controls.Add(btnDeleteFile);
            panelComplianceForm.Controls.Add(btnMarkMissing);
            panelComplianceForm.Controls.Add(btnRemindCompliance);
            panelComplianceForm.Controls.Add(btnAddRequirement);
            panelComplianceForm.Controls.Add(btnDeleteRequirement);

            panelScholarshipSummary = new Panel();
            panelScholarshipSummary.BackColor = Color.White;
            panelScholarshipSummary.Location = new Point(20, 630);
            panelScholarshipSummary.Size = new Size(1550, 110);
            panelScholarshipSummary.BorderStyle = BorderStyle.FixedSingle;

            tabCompliance.Controls.Add(panelComplianceHeader);
            tabCompliance.Controls.Add(dgvCompliance);
            tabCompliance.Controls.Add(panelComplianceForm);
            tabCompliance.Controls.Add(panelScholarshipSummary);
        }

        private FrameworkTest.SATAButton CreateSATAButton(string text, Color backColor, Point location)
        {
            FrameworkTest.SATAButton btn = new FrameworkTest.SATAButton();
            btn.ButtonText = text;
            btn.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btn.Location = location;
            btn.Size = new Size(155, 35);
            btn.NormalBackground = backColor;
            btn.HoverBackground = Color.FromArgb(
                Math.Max(0, backColor.R - 30),
                Math.Max(0, backColor.G - 30),
                Math.Max(0, backColor.B - 30));
            btn.NormalForeColor = Color.White;
            btn.HoverForeColor = Color.White;
            btn.Rounding = new Padding(8);
            btn.TextAutoCenter = true;
            return btn;
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabCompliance)
            {
                LoadComplianceScholars();
                SetupScholarshipSummaryPanel();
                if (_currentScholarId > 0 && _filesModified)
                {
                    SyncFilesToCompliance(_currentScholarId);
                }
                if (_currentScholarId > 0 && cmbComplianceScholar.Items.Count > 0)
                {
                    for (int i = 1; i < cmbComplianceScholar.Items.Count; i++)
                    {
                        ComboBoxItem item = cmbComplianceScholar.Items[i] as ComboBoxItem;
                        if (item != null && item.Id == _currentScholarId)
                        {
                            cmbComplianceScholar.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else if (tabControlMain.SelectedTab == tabScholarList)
            {
                if (_currentScholarId > 0)
                {
                    LoadScholarDetails(_currentScholarId);
                }
            }
        }

        private void LoadComplianceScholars()
        {
            try
            {
                cmbComplianceScholar.Items.Clear();
                cmbComplianceScholar.Items.Add(new ComboBoxItem { Id = 0, Name = "-- Select Scholar --" });
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT id, CONCAT(first_name, ' ', last_name, ' (', scholar_number, ')') as full_name
FROM scholars WHERE status = 'Active' ORDER BY last_name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbComplianceScholar.Items.Add(new ComboBoxItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["full_name"].ToString()
                            });
                        }
                    }
                }
                if (cmbComplianceScholar.Items.Count > 0)
                    cmbComplianceScholar.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading scholars: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbComplianceScholar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbComplianceScholar.SelectedIndex <= 0)
            {
                dgvCompliance.Rows.Clear();
                lblComplianceScholar.Text = "Please select a scholar";
                lblComplianceDetails.Text = "";
                lblComplianceOverall.Text = "";
                return;
            }
            ComboBoxItem selected = cmbComplianceScholar.SelectedItem as ComboBoxItem;
            if (selected != null)
            {
                EnsureComplianceRecordsExist(selected.Id);
                if (_currentScholarId == selected.Id && _filesModified)
                {
                    SyncFilesToCompliance(selected.Id);
                }
                LoadComplianceRecords(selected.Id);
                LoadScholarInfoForCompliance(selected.Id);
            }
        }

        private void EnsureComplianceRecordsExist(int scholarId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Check if records already exist
                    string checkQuery = "SELECT COUNT(*) FROM compliance_records WHERE scholar_id = @sid";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@sid", scholarId);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count == 0)
                        {
                            // Insert exactly 5 records with CORRECT enum values
                            for (int i = 0; i < 5; i++)
                            {
                                string insQ = @"INSERT INTO compliance_records 
(scholar_id, requirement_type, description, due_date, status) 
VALUES (@sid, @type, @desc, @due, 'Pending')";
                                using (MySqlCommand insCmd = new MySqlCommand(insQ, conn))
                                {
                                    insCmd.Parameters.AddWithValue("@sid", scholarId);
                                    insCmd.Parameters.AddWithValue("@type", _dbTypes[i]);  // Uses correct enum value
                                    insCmd.Parameters.AddWithValue("@desc", _descriptions[i]);
                                    insCmd.Parameters.AddWithValue("@due", DateTime.Now.AddMonths(1));
                                    insCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error ensuring compliance records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SyncFilesToCompliance(int scholarId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    for (int i = 0; i < 5; i++)
                    {
                        string dbType = _dbTypes[i];
                        string docKey = _docKeys[i];

                        // Find the compliance record for this requirement
                        string findQuery = "SELECT id FROM compliance_records WHERE scholar_id = @sid AND requirement_type = @type LIMIT 1";
                        MySqlCommand findCmd = new MySqlCommand(findQuery, conn);
                        findCmd.Parameters.AddWithValue("@sid", scholarId);
                        findCmd.Parameters.AddWithValue("@type", dbType);

                        object result = findCmd.ExecuteScalar();
                        if (result != null)
                        {
                            int complianceId = Convert.ToInt32(result);

                            // Delete old file first (regardless of whether we're adding or removing)
                            string deleteFile = "DELETE FROM file_attachments WHERE compliance_id = @cid";
                            MySqlCommand delCmd = new MySqlCommand(deleteFile, conn);
                            delCmd.Parameters.AddWithValue("@cid", complianceId);
                            delCmd.ExecuteNonQuery();

                            if (_loadedFileData.ContainsKey(docKey))
                            {
                                // Insert new file
                                byte[] fileData = _loadedFileData[docKey];
                                string fileName = _loadedFileNames[docKey];

                                string insertFile = @"INSERT INTO file_attachments
(scholar_id, compliance_id, file_name, original_name, file_type, file_size, file_data, uploaded_by, uploaded_at)
VALUES (@sid, @cid, @fn, @on, @ft, @sz, @data, @uploadedBy, NOW())";
                                MySqlCommand insCmd = new MySqlCommand(insertFile, conn);
                                insCmd.Parameters.AddWithValue("@sid", scholarId);
                                insCmd.Parameters.AddWithValue("@cid", complianceId);
                                insCmd.Parameters.AddWithValue("@fn", fileName);
                                insCmd.Parameters.AddWithValue("@on", fileName);
                                insCmd.Parameters.AddWithValue("@ft", Path.GetExtension(fileName).ToLower());
                                insCmd.Parameters.AddWithValue("@sz", fileData.Length);
                                insCmd.Parameters.AddWithValue("@data", fileData);
                                insCmd.Parameters.AddWithValue("@uploadedBy", SessionManager.CurrentUser?.Id ?? 1);
                                insCmd.ExecuteNonQuery();

                                // Update compliance status to Submitted
                                string updateStatus = "UPDATE compliance_records SET date_submitted = CURDATE(), status = 'Submitted', file_path = @fn WHERE id = @cid";
                                MySqlCommand updCmd = new MySqlCommand(updateStatus, conn);
                                updCmd.Parameters.AddWithValue("@fn", fileName);
                                updCmd.Parameters.AddWithValue("@cid", complianceId);
                                updCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                // File was removed - reset status to Pending
                                string resetStatus = "UPDATE compliance_records SET status = 'Pending', file_path = NULL, date_submitted = NULL WHERE id = @cid";
                                MySqlCommand rstCmd = new MySqlCommand(resetStatus, conn);
                                rstCmd.Parameters.AddWithValue("@cid", complianceId);
                                rstCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    _filesModified = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error syncing files: {ex.Message}");
            }
        }

        private void LoadScholarInfoForCompliance(int scholarId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT s.first_name, s.last_name, s.scholar_number, s.course,
s.year_level, st.name as scholarship_name,
COALESCE(s.stipend_amount, st.stipend_amount) as stipend_amount
FROM scholars s
LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id
WHERE s.id = @scholarId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", scholarId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblComplianceScholar.Text = $"Scholar: {reader["first_name"]} {reader["last_name"]} ({reader["scholar_number"]})";
                            lblComplianceDetails.Text = $"Course: {reader["course"]} | Year: {reader["year_level"]} | Scholarship: {reader["scholarship_name"]} | Stipend: ₱{reader["stipend_amount"]}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading scholar info: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComplianceRecords(int scholarId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Order by the exact enum values
                    string query = @"SELECT cr.id, cr.requirement_type, cr.description, cr.status,
cr.due_date, cr.date_submitted, cr.remarks,
(SELECT COUNT(*) FROM file_attachments fa WHERE fa.compliance_id = cr.id) as file_count
FROM compliance_records cr
WHERE cr.scholar_id = @scholarId
ORDER BY FIELD(cr.requirement_type, 
    'PSA Birth Certificate', 
    'Enrollment Form', 
    'COR', 
    'Grades', 
    'Scholarship Contract'
), cr.requirement_type";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", scholarId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvCompliance.Rows.Clear();
                        int total = 0;
                        int completed = 0;
                        while (reader.Read())
                        {
                            total++;
                            string status = reader["status"].ToString();
                            if (status == "Approved" || status == "Submitted") completed++;

                            string dbType = reader["requirement_type"].ToString();
                            string displayName = GetDisplayNameForDbType(dbType);

                            int rowIndex = dgvCompliance.Rows.Add();
                            dgvCompliance.Rows[rowIndex].Cells["colReqType"].Value = displayName;
                            dgvCompliance.Rows[rowIndex].Cells["colDescription"].Value = reader["description"]?.ToString() ?? "";
                            dgvCompliance.Rows[rowIndex].Cells["colStatus"].Value = status;
                            dgvCompliance.Rows[rowIndex].Cells["colDueDate"].Value = reader["due_date"] != DBNull.Value ?
                                Convert.ToDateTime(reader["due_date"]).ToString("yyyy-MM-dd") : "N/A";
                            dgvCompliance.Rows[rowIndex].Cells["colSubmitted"].Value = reader["date_submitted"] != DBNull.Value ?
                                Convert.ToDateTime(reader["date_submitted"]).ToString("yyyy-MM-dd") : "";
                            dgvCompliance.Rows[rowIndex].Cells["colRemarks"].Value = reader["remarks"]?.ToString() ?? "";
                            dgvCompliance.Rows[rowIndex].Cells["colFile"].Value = Convert.ToInt32(reader["file_count"]) > 0 ? "📎 View" : "";
                            dgvCompliance.Rows[rowIndex].Cells["colComplianceID"].Value = reader["id"];

                            var statusCell = dgvCompliance.Rows[rowIndex].Cells["colStatus"];
                            switch (status)
                            {
                                case "Approved": statusCell.Style.ForeColor = Color.FromArgb(40, 167, 69); break;
                                case "Submitted": statusCell.Style.ForeColor = Color.FromArgb(0, 123, 255); break;
                                case "Pending": statusCell.Style.ForeColor = Color.FromArgb(255, 170, 0); break;
                                case "Overdue": statusCell.Style.ForeColor = Color.FromArgb(239, 68, 68); break;
                                case "Rejected": statusCell.Style.ForeColor = Color.FromArgb(220, 50, 50); break;
                            }
                            statusCell.Style.Font = new Font(dgvCompliance.Font, FontStyle.Bold);

                            if (Convert.ToInt32(reader["file_count"]) > 0)
                            {
                                dgvCompliance.Rows[rowIndex].Cells["colFile"].Style.ForeColor = Color.FromArgb(0, 100, 200);
                                dgvCompliance.Rows[rowIndex].Cells["colFile"].Style.Font = new Font(dgvCompliance.Font, FontStyle.Underline);
                            }
                        }

                        if (total > 0)
                        {
                            bool allComplete = completed == 5;
                            lblComplianceOverall.Text = $"Overall: {(allComplete ? "Complete" : "In Progress")} " +
                                $"({completed}/{total} completed)";
                            lblComplianceOverall.ForeColor = allComplete ? Color.FromArgb(40, 167, 69) : Color.FromArgb(255, 170, 0);
                        }
                        else
                        {
                            lblComplianceOverall.Text = "No compliance records found (0/5)";
                            lblComplianceOverall.ForeColor = Color.Gray;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading compliance records: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Compliance Actions
        private void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvCompliance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a compliance record first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int complianceId = Convert.ToInt32(dgvCompliance.SelectedRows[0].Cells["colComplianceID"].Value);
            string currentStatus = dgvCompliance.SelectedRows[0].Cells["colStatus"].Value.ToString();

            Form statusForm = new Form();
            statusForm.Text = "Update Compliance Status";
            statusForm.Size = new Size(420, 320);
            statusForm.StartPosition = FormStartPosition.CenterParent;
            statusForm.BackColor = Color.White;
            statusForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            statusForm.MaximizeBox = false;
            statusForm.MinimizeBox = false;

            Label lblTitle = new Label();
            lblTitle.Text = "Update Status";
            lblTitle.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 68, 79);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(200, 30);

            Label lblStatus = new Label();
            lblStatus.Text = "New Status:";
            lblStatus.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(30, 60);
            lblStatus.Size = new Size(100, 20);

            ComboBox cmbNewStatus = new ComboBox();
            cmbNewStatus.Items.AddRange(new string[] { "Pending", "Submitted", "Approved", "Rejected", "Overdue" });
            cmbNewStatus.SelectedItem = currentStatus;
            cmbNewStatus.Font = new Font("Century Gothic", 11F);
            cmbNewStatus.Location = new Point(30, 85);
            cmbNewStatus.Size = new Size(340, 28);
            cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            Label lblRemarks = new Label();
            lblRemarks.Text = "Remarks:";
            lblRemarks.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblRemarks.Location = new Point(30, 125);
            lblRemarks.Size = new Size(100, 20);

            TextBox txtRemarks = new TextBox();
            txtRemarks.Multiline = true;
            txtRemarks.Location = new Point(30, 150);
            txtRemarks.Size = new Size(340, 60);
            txtRemarks.Font = new Font("Century Gothic", 10F);

            FrameworkTest.SATAButton btnOK = new FrameworkTest.SATAButton();
            btnOK.ButtonText = "Update Status";
            btnOK.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnOK.Location = new Point(150, 225);
            btnOK.Size = new Size(120, 40);
            btnOK.NormalBackground = Color.FromArgb(0, 68, 79);
            btnOK.NormalForeColor = Color.White;
            btnOK.HoverBackground = Color.FromArgb(0, 90, 105);
            btnOK.HoverForeColor = Color.White;
            btnOK.Rounding = new Padding(8);
            btnOK.TextAutoCenter = true;
            btnOK.Click += (s, ev) =>
            {
                if (cmbNewStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please select a status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UpdateComplianceStatus(complianceId, cmbNewStatus.SelectedItem.ToString(), txtRemarks.Text);
                statusForm.Close();
            };

            statusForm.Controls.Add(lblTitle);
            statusForm.Controls.Add(lblStatus);
            statusForm.Controls.Add(cmbNewStatus);
            statusForm.Controls.Add(lblRemarks);
            statusForm.Controls.Add(txtRemarks);
            statusForm.Controls.Add(btnOK);
            statusForm.ShowDialog();
        }

        private void UpdateComplianceStatus(int complianceId, string newStatus, string remarks)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE compliance_records
SET status = @status, remarks = @remarks,
date_submitted = CASE WHEN @status IN ('Submitted', 'Approved') THEN CURDATE() ELSE date_submitted END,
updated_at = NOW()
WHERE id = @complianceId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@remarks", remarks);
                    cmd.Parameters.AddWithValue("@complianceId", complianceId);
                    cmd.ExecuteNonQuery();

                    ActivityLogger.LogUpdate("compliance_records", complianceId, $"Status updated to {newStatus}");
                    MessageBox.Show("Compliance status updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (cmbComplianceScholar.SelectedIndex > 0)
                    {
                        ComboBoxItem selected = cmbComplianceScholar.SelectedItem as ComboBoxItem;
                        if (selected != null)
                            LoadComplianceRecords(selected.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUploadFile_Click(object sender, EventArgs e)
        {
            if (cmbComplianceScholar.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a scholar first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvCompliance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a compliance record to attach file to.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int complianceId = Convert.ToInt32(dgvCompliance.SelectedRows[0].Cells["colComplianceID"].Value);
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Document to Upload";
                openFileDialog.Filter = "All Supported Files|*.pdf;*.jpg;*.jpeg;*.png;*.doc;*.docx;*.xls;*.xlsx|PDF Files|*.pdf|Image Files|*.jpg;*.jpeg;*.png|Word Documents|*.doc;*.docx|All Files|*.*";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ComboBoxItem selected = cmbComplianceScholar.SelectedItem as ComboBoxItem;
                    if (selected != null)
                    {
                        UploadFile(selected.Id, complianceId, openFileDialog.FileName);

                        // Also sync to scholar info form combo boxes
                        string displayName = dgvCompliance.SelectedRows[0].Cells["colReqType"].Value.ToString();
                        byte[] fileData = File.ReadAllBytes(openFileDialog.FileName);
                        string fileName = openFileDialog.SafeFileName;

                        // Find which doc key this is
                        for (int i = 0; i < 5; i++)
                        {
                            if (_displayNames[i] == displayName)
                            {
                                string docKey = _docKeys[i];
                                _loadedFileData[docKey] = fileData;
                                _loadedFileNames[docKey] = fileName;
                                _filesModified = true;

                                // Update the combo box
                                ComboBox cmb = GetComboBoxForDbType(_dbTypes[i]);
                                if (cmb != null)
                                {
                                    long fileSizeKB = fileData.Length / 1024;
                                    if (fileSizeKB == 0) fileSizeKB = 1;

                                    cmb.Tag = "updating";
                                    cmb.Items.Clear();
                                    cmb.Items.Add("TBA (To be Arranged)");
                                    cmb.Items.Add($"✅ {fileName} ({fileSizeKB} KB) - Attached");
                                    cmb.Items.Add("Change File...");
                                    cmb.Items.Add("Remove File");
                                    cmb.SelectedIndex = 1;
                                    cmb.BackColor = Color.FromArgb(220, 255, 220);
                                    cmb.ForeColor = Color.FromArgb(0, 100, 0);
                                    cmb.Tag = "attached";
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void BtnDeleteFile_Click(object sender, EventArgs e)
        {
            if (cmbComplianceScholar.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a scholar first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvCompliance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a compliance record first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int complianceId = Convert.ToInt32(dgvCompliance.SelectedRows[0].Cells["colComplianceID"].Value);
            string displayName = dgvCompliance.SelectedRows[0].Cells["colReqType"].Value.ToString();
            string fileIndicator = dgvCompliance.SelectedRows[0].Cells["colFile"].Value?.ToString() ?? "";

            if (string.IsNullOrEmpty(fileIndicator))
            {
                MessageBox.Show("No file attached to this record.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the file for:\n{displayName}?",
                "Confirm Delete File",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ComboBoxItem selected = cmbComplianceScholar.SelectedItem as ComboBoxItem;
                    if (selected == null) return;

                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();

                        // Delete the file from database
                        string deleteQuery = "DELETE FROM file_attachments WHERE compliance_id = @complianceId";
                        MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@complianceId", complianceId);
                        int deleted = deleteCmd.ExecuteNonQuery();

                        // Update compliance record status back to Pending
                        string updateQuery = "UPDATE compliance_records SET status = 'Pending', file_path = NULL WHERE id = @complianceId";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@complianceId", complianceId);
                        updateCmd.ExecuteNonQuery();

                        ActivityLogger.LogDelete("file_attachments", complianceId, $"Deleted file for compliance record {complianceId}");

                        // Also clear from loaded data
                        for (int i = 0; i < 5; i++)
                        {
                            if (_displayNames[i] == displayName)
                            {
                                string docKey = _docKeys[i];
                                _loadedFileData.Remove(docKey);
                                _loadedFileNames.Remove(docKey);
                                _filesModified = true;

                                ComboBox cmb = GetComboBoxForDbType(_dbTypes[i]);
                                if (cmb != null)
                                {
                                    cmb.Tag = "updating";
                                    cmb.Items.Clear();
                                    cmb.Items.Add("TBA (To be Arranged)");
                                    cmb.Items.Add("Attach File");
                                    cmb.SelectedIndex = 0;
                                    cmb.BackColor = Color.White;
                                    cmb.ForeColor = Color.Black;
                                    cmb.Tag = null;
                                }
                                break;
                            }
                        }

                        LoadComplianceRecords(selected.Id);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting file: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UploadFile(int scholarId, int complianceId, string filePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length > 10 * 1024 * 1024)
                {
                    MessageBox.Show("File size must be less than 10MB.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string fileName = Path.GetFileName(filePath);
                byte[] fileData = File.ReadAllBytes(filePath);
                string fileType = Path.GetExtension(filePath).ToLower();
                long fileSize = fileInfo.Length;

                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Delete existing files for this compliance record
                    string deleteQuery = "DELETE FROM file_attachments WHERE compliance_id = @complianceId";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@complianceId", complianceId);
                    deleteCmd.ExecuteNonQuery();

                    // Insert new file
                    string query = @"INSERT INTO file_attachments
(scholar_id, compliance_id, file_name, original_name, file_type, file_size, file_data, uploaded_by, uploaded_at)
VALUES (@scholarId, @complianceId, @fileName, @originalName, @fileType, @fileSize, @fileData, @uploadedBy, NOW())";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", scholarId);
                    cmd.Parameters.AddWithValue("@complianceId", complianceId);
                    cmd.Parameters.AddWithValue("@fileName", fileName);
                    cmd.Parameters.AddWithValue("@originalName", fileName);
                    cmd.Parameters.AddWithValue("@fileType", fileType);
                    cmd.Parameters.AddWithValue("@fileSize", fileSize);
                    cmd.Parameters.AddWithValue("@fileData", fileData);
                    cmd.Parameters.AddWithValue("@uploadedBy", SessionManager.CurrentUser?.Id ?? 1);
                    cmd.ExecuteNonQuery();

                    // Update compliance record status
                    string updateQuery = "UPDATE compliance_records SET date_submitted = CURDATE(), status = 'Submitted', file_path = @fn WHERE id = @complianceId";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@fn", fileName);
                    updateCmd.Parameters.AddWithValue("@complianceId", complianceId);
                    updateCmd.ExecuteNonQuery();

                    ActivityLogger.LogCreate("file_attachments", complianceId, $"File uploaded: {fileName}");
                    MessageBox.Show("File uploaded and saved permanently!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadComplianceRecords(scholarId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCompliance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvCompliance.Columns["colFile"].Index)
                {
                    string fileIndicator = dgvCompliance.Rows[e.RowIndex].Cells["colFile"].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(fileIndicator))
                    {
                        int complianceId = Convert.ToInt32(dgvCompliance.Rows[e.RowIndex].Cells["colComplianceID"].Value);
                        DownloadAndOpenFile(complianceId);
                    }
                }
            }
        }

        private void DownloadAndOpenFile(int complianceId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT fa.file_name, fa.file_data, fa.file_type
FROM file_attachments fa
WHERE fa.compliance_id = @complianceId
ORDER BY fa.uploaded_at DESC LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@complianceId", complianceId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fileName = reader["file_name"].ToString();
                            byte[] fileData = (byte[])reader["file_data"];
                            string fileType = reader["file_type"].ToString();
                            string tempPath = Path.Combine(Path.GetTempPath(), "ScholarAid", fileName);
                            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
                            File.WriteAllBytes(tempPath, fileData);
                            try
                            {
                                System.Diagnostics.Process.Start(tempPath);
                            }
                            catch
                            {
                                using (SaveFileDialog saveDialog = new SaveFileDialog())
                                {
                                    saveDialog.FileName = fileName;
                                    saveDialog.Filter = $"Files (*{fileType})|*{fileType}|All Files (*.*)|*.*";
                                    if (saveDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        File.WriteAllBytes(saveDialog.FileName, fileData);
                                        MessageBox.Show("File saved successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMarkMissing_Click(object sender, EventArgs e)
        {
            if (cmbComplianceScholar.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a scholar first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvCompliance.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to mark this requirement as missing?\nThis will set the status to 'Overdue'.",
                    "Confirm Mark as Missing",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int complianceId = Convert.ToInt32(dgvCompliance.SelectedRows[0].Cells["colComplianceID"].Value);
                    UpdateComplianceStatus(complianceId, "Overdue", "Marked as missing by admin");
                }
            }
            else
            {
                MessageBox.Show("Please select a compliance record first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRemindCompliance_Click(object sender, EventArgs e)
        {
            if (cmbComplianceScholar.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a scholar first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComboBoxItem selected = cmbComplianceScholar.SelectedItem as ComboBoxItem;
            if (selected == null) return;
            DialogResult result = MessageBox.Show(
                "Send reminder to this scholar for pending compliance requirements?",
                "Send Reminder",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string query = @"INSERT INTO notifications (sender_id, recipient_id, title, message, notification_type, date_created)
VALUES (@senderId, @recipientId, @title, @message, 'Reminder', NOW())";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@senderId", SessionManager.CurrentUser?.Id ?? 1);
                        cmd.Parameters.AddWithValue("@recipientId", selected.Id);
                        cmd.Parameters.AddWithValue("@title", "Compliance Reminder - ScholarAid");
                        cmd.Parameters.AddWithValue("@message", "Dear scholar, you have pending compliance requirements that need your attention. Please submit them as soon as possible to avoid scholarship suspension. Log in to your ScholarAid account to view details.");
                        cmd.ExecuteNonQuery();
                        ActivityLogger.LogCreate("notifications", selected.Id, "Compliance reminder sent");
                        MessageBox.Show("Reminder sent successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending reminder: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAddRequirement_Click(object sender, EventArgs e)
        {
            if (cmbComplianceScholar.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a scholar first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComboBoxItem selected = cmbComplianceScholar.SelectedItem as ComboBoxItem;
            if (selected == null) return;

            Form addForm = new Form();
            addForm.Text = "Add Compliance Requirement";
            addForm.Size = new Size(480, 420);
            addForm.StartPosition = FormStartPosition.CenterParent;
            addForm.BackColor = Color.White;
            addForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            addForm.MaximizeBox = false;
            addForm.MinimizeBox = false;

            Label lblTitle = new Label();
            lblTitle.Text = "Add New Requirement";
            lblTitle.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 68, 79);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(300, 30);

            Label lblType = new Label();
            lblType.Text = "Requirement Type:";
            lblType.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblType.Location = new Point(30, 55);
            lblType.Size = new Size(200, 20);

            ComboBox cmbType = new ComboBox();
            cmbType.Items.AddRange(new string[] {
        "PSA Birth Certificate",
        "Enrollment Form",
        "COR",
        "Grades",
        "Scholarship Contract",
        "Good Moral Certificate",
        "Others"
    });
            cmbType.Font = new Font("Century Gothic", 11F);
            cmbType.Location = new Point(30, 80);
            cmbType.Size = new Size(400, 28);
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.SelectedIndex = 0;

            // Custom requirement text field (hidden by default)
            Label lblCustomType = new Label();
            lblCustomType.Text = "Specify Requirement Name:";
            lblCustomType.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblCustomType.Location = new Point(30, 115);
            lblCustomType.Size = new Size(250, 20);
            lblCustomType.Visible = false;

            TextBox txtCustomType = new TextBox();
            txtCustomType.Font = new Font("Century Gothic", 10F);
            txtCustomType.Location = new Point(30, 140);
            txtCustomType.Size = new Size(400, 24);
            txtCustomType.Visible = false;
            // Set initial text as placeholder-like hint
            txtCustomType.Text = "e.g., 2x2 Picture, Medical Certificate, etc.";
            txtCustomType.ForeColor = Color.Gray;
            txtCustomType.Enter += (s, ev) =>
            {
                if (txtCustomType.Text == "e.g., 2x2 Picture, Medical Certificate, etc.")
                {
                    txtCustomType.Text = "";
                    txtCustomType.ForeColor = Color.Black;
                }
            };
            txtCustomType.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCustomType.Text))
                {
                    txtCustomType.Text = "e.g., 2x2 Picture, Medical Certificate, etc.";
                    txtCustomType.ForeColor = Color.Gray;
                }
            };

            // Declare all controls BEFORE the SelectedIndexChanged event
            Label lblDesc = new Label();
            lblDesc.Text = "Description:";
            lblDesc.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblDesc.Location = new Point(30, 120);
            lblDesc.Size = new Size(200, 20);

            TextBox txtDesc = new TextBox();
            txtDesc.Font = new Font("Century Gothic", 10F);
            txtDesc.Location = new Point(30, 145);
            txtDesc.Size = new Size(400, 24);
            txtDesc.Text = "Enter description for this requirement";
            txtDesc.ForeColor = Color.Gray;
            txtDesc.Enter += (s, ev) =>
            {
                if (txtDesc.Text == "Enter description for this requirement")
                {
                    txtDesc.Text = "";
                    txtDesc.ForeColor = Color.Black;
                }
            };
            txtDesc.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtDesc.Text))
                {
                    txtDesc.Text = "Enter description for this requirement";
                    txtDesc.ForeColor = Color.Gray;
                }
            };

            Label lblDueDate = new Label();
            lblDueDate.Text = "Due Date:";
            lblDueDate.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblDueDate.Location = new Point(30, 180);
            lblDueDate.Size = new Size(200, 20);

            DateTimePicker dtpDueDate = new DateTimePicker();
            dtpDueDate.Font = new Font("Century Gothic", 10F);
            dtpDueDate.Location = new Point(30, 205);
            dtpDueDate.Size = new Size(250, 24);
            dtpDueDate.Value = DateTime.Now.AddMonths(1);

            FrameworkTest.SATAButton btnAddReq = new FrameworkTest.SATAButton();
            btnAddReq.ButtonText = "Add Requirement";
            btnAddReq.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnAddReq.Location = new Point(140, 250);
            btnAddReq.Size = new Size(200, 40);
            btnAddReq.NormalBackground = Color.FromArgb(0, 68, 79);
            btnAddReq.NormalForeColor = Color.White;
            btnAddReq.HoverBackground = Color.FromArgb(0, 90, 105);
            btnAddReq.HoverForeColor = Color.White;
            btnAddReq.Rounding = new Padding(8);
            btnAddReq.TextAutoCenter = true;

            // NOW wire up the SelectedIndexChanged event (all controls exist now)
            cmbType.SelectedIndexChanged += (s, ev) =>
            {
                bool isOthers = cmbType.SelectedItem?.ToString() == "Others";
                lblCustomType.Visible = isOthers;
                txtCustomType.Visible = isOthers;

                int offset = isOthers ? 55 : 0;
                lblDesc.Location = new Point(30, 120 + offset);
                txtDesc.Location = new Point(30, 145 + offset);
                lblDueDate.Location = new Point(30, 180 + offset);
                dtpDueDate.Location = new Point(30, 205 + offset);
                btnAddReq.Location = new Point(140, 250 + offset);
                addForm.Height = isOthers ? 470 : 420;
            };

            btnAddReq.Click += (s, ev) =>
            {
                // Check if "Others" is selected and the custom text is still the placeholder
                bool isOtherSelected = cmbType.SelectedItem?.ToString() == "Others";
                string customText = txtCustomType.Text;
                if (customText == "e.g., 2x2 Picture, Medical Certificate, etc.")
                    customText = "";

                if (isOtherSelected && string.IsNullOrWhiteSpace(customText))
                {
                    MessageBox.Show("Please specify the requirement name.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomType.Focus();
                    return;
                }

                string descText = txtDesc.Text;
                if (descText == "Enter description for this requirement")
                    descText = "";

                if (string.IsNullOrWhiteSpace(descText))
                {
                    MessageBox.Show("Please enter a description.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDesc.Focus();
                    return;
                }

                try
                {
                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();

                        string requirementType;
                        if (isOtherSelected)
                        {
                            requirementType = customText;
                        }
                        else
                        {
                            requirementType = cmbType.SelectedItem?.ToString() ?? "";
                        }

                        string query = @"INSERT INTO compliance_records
(scholar_id, requirement_type, description, due_date, status, created_at)
VALUES (@scholarId, @type, @desc, @dueDate, 'Pending', NOW())";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@scholarId", selected.Id);
                        cmd.Parameters.AddWithValue("@type", requirementType);
                        cmd.Parameters.AddWithValue("@desc", descText);
                        cmd.Parameters.AddWithValue("@dueDate", dtpDueDate.Value);
                        cmd.ExecuteNonQuery();

                        ActivityLogger.LogCreate("compliance_records", selected.Id,
                            $"Added requirement: {requirementType}");
                        MessageBox.Show($"Requirement '{requirementType}' added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadComplianceRecords(selected.Id);
                        addForm.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            addForm.Controls.Add(lblTitle);
            addForm.Controls.Add(lblType);
            addForm.Controls.Add(cmbType);
            addForm.Controls.Add(lblCustomType);
            addForm.Controls.Add(txtCustomType);
            addForm.Controls.Add(lblDesc);
            addForm.Controls.Add(txtDesc);
            addForm.Controls.Add(lblDueDate);
            addForm.Controls.Add(dtpDueDate);
            addForm.Controls.Add(btnAddReq);
            addForm.ShowDialog();
        }

        private void BtnDeleteRequirement_Click(object sender, EventArgs e)
        {
            if (cmbComplianceScholar.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a scholar first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCompliance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a compliance record to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int complianceId = Convert.ToInt32(dgvCompliance.SelectedRows[0].Cells["colComplianceID"].Value);
            string requirementType = dgvCompliance.SelectedRows[0].Cells["colReqType"].Value.ToString();
            string description = dgvCompliance.SelectedRows[0].Cells["colDescription"].Value?.ToString() ?? "";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete this requirement?\n\n" +
                $"Requirement: {requirementType}\n" +
                $"Description: {description}\n\n" +
                $"This will also delete any attached files.",
                "Confirm Delete Requirement",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ComboBoxItem selected = cmbComplianceScholar.SelectedItem as ComboBoxItem;
                    if (selected == null) return;

                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();

                        // Delete associated files first
                        string deleteFiles = "DELETE FROM file_attachments WHERE compliance_id = @complianceId";
                        MySqlCommand delFilesCmd = new MySqlCommand(deleteFiles, conn);
                        delFilesCmd.Parameters.AddWithValue("@complianceId", complianceId);
                        delFilesCmd.ExecuteNonQuery();

                        // Delete the compliance record
                        string deleteRecord = "DELETE FROM compliance_records WHERE id = @complianceId";
                        MySqlCommand delRecordCmd = new MySqlCommand(deleteRecord, conn);
                        delRecordCmd.Parameters.AddWithValue("@complianceId", complianceId);
                        int rowsAffected = delRecordCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ActivityLogger.LogDelete("compliance_records", complianceId,
                                $"Deleted requirement: {requirementType} - {description}");
                            MessageBox.Show("Requirement deleted successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh compliance records
                            LoadComplianceRecords(selected.Id);
                        }
                        else
                        {
                            MessageBox.Show("No record was deleted.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting requirement: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Scholarships Management Dialog
        private void ShowScholarshipManagementDialog()
        {
            Form dlg = new Form
            {
                Text = "Scholarships Management",
                Size = new Size(850, 630),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                AutoScroll = true
            };

            Panel headerPanel = new Panel
            {
                BackColor = Color.FromArgb(0, 68, 79),
                Location = new Point(0, 0),
                Size = new Size(dlg.ClientSize.Width, 60)
            };
            Label lblHeader = new Label
            {
                Text = "Manage Scholarship Types",
                Font = new Font("Century Gothic", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            };
            headerPanel.Controls.Add(lblHeader);

            DataGridView dgv = new DataGridView
            {
                Location = new Point(20, 80),
                Size = new Size(740, 330),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 68, 79),
                    ForeColor = Color.White,
                    Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                EnableHeadersVisualStyles = false,
                RowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Century Gothic", 10F),
                    Padding = new Padding(5)
                },
                RowTemplate = { Height = 35 },
                GridColor = Color.FromArgb(230, 230, 230)
            };
            dgv.Columns.Add("id", "ID");
            dgv.Columns.Add("name", "Name");
            dgv.Columns.Add("amount", "Stipend");
            dgv.Columns.Add("freq", "Frequency");
            dgv.Columns.Add("status", "Status");
            dgv.Columns["id"].FillWeight = 10;
            dgv.Columns["name"].FillWeight = 35;
            dgv.Columns["amount"].FillWeight = 20;
            dgv.Columns["freq"].FillWeight = 15;
            dgv.Columns["status"].FillWeight = 20;

            Panel buttonPanel = new Panel
            {
                BackColor = Color.FromArgb(245, 245, 245),
                Location = new Point(0, 480),
                Size = new Size(dlg.ClientSize.Width, 100)
            };

            FrameworkTest.SATAButton btnAdd = new FrameworkTest.SATAButton
            {
                ButtonText = "Add New Scholarship",
                NormalBackground = Color.FromArgb(0, 68, 79),
                NormalForeColor = Color.White,
                HoverBackground = Color.FromArgb(0, 90, 105),
                HoverForeColor = Color.White,
                Location = new Point(15, 30),
                Size = new Size(180, 40),
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                Rounding = new Padding(8),
                TextAutoCenter = true
            };

            FrameworkTest.SATAButton btnActivate = new FrameworkTest.SATAButton
            {
                ButtonText = "Active Selected",
                NormalBackground = Color.FromArgb(40, 167, 69),
                NormalForeColor = Color.White,
                HoverBackground = Color.FromArgb(30, 140, 55),
                HoverForeColor = Color.White,
                Location = new Point(210, 30),
                Size = new Size(180, 40),
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                Rounding = new Padding(8),
                TextAutoCenter = true
            };

            FrameworkTest.SATAButton btnInactive = new FrameworkTest.SATAButton
            {
                ButtonText = "Inactive Selected",
                NormalBackground = Color.FromArgb(220, 53, 69),
                NormalForeColor = Color.White,
                HoverBackground = Color.FromArgb(200, 40, 50),
                HoverForeColor = Color.White,
                Location = new Point(405, 30),
                Size = new Size(180, 40),
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                Rounding = new Padding(8),
                TextAutoCenter = true
            };

            FrameworkTest.SATAButton btnClose = new FrameworkTest.SATAButton
            {
                ButtonText = "Close",
                NormalBackground = Color.FromArgb(108, 117, 125),
                NormalForeColor = Color.White,
                HoverBackground = Color.FromArgb(80, 87, 95),
                HoverForeColor = Color.White,
                Location = new Point(600, 30),
                Size = new Size(150, 40),
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                Rounding = new Padding(8),
                TextAutoCenter = true
            };

            buttonPanel.Controls.Add(btnAdd);
            buttonPanel.Controls.Add(btnActivate);
            buttonPanel.Controls.Add(btnInactive);
            buttonPanel.Controls.Add(btnClose);

            void LoadData()
            {
                dgv.Rows.Clear();
                try
                {
                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand("SELECT id, name, stipend_amount, payment_frequency, is_active FROM scholarship_types ORDER BY name", conn))
                        using (MySqlDataReader r = cmd.ExecuteReader())
                            while (r.Read())
                            {
                                int rowIndex = dgv.Rows.Add(r["id"], r["name"], $"₱{Convert.ToDecimal(r["stipend_amount"]):N0}", r["payment_frequency"], Convert.ToBoolean(r["is_active"]) ? "Active" : "Inactive");
                                dgv.Rows[rowIndex].Cells["status"].Style.ForeColor = Convert.ToBoolean(r["is_active"]) ? Color.FromArgb(40, 167, 69) : Color.Gray;
                            }
                    }
                }
                catch (Exception ex) { MessageBox.Show($"Load Error: {ex.Message}", "Error"); }
            }
            LoadData();

            btnAdd.Click += (s, e) =>
            {
                Form f = new Form
                {
                    Text = "Add Scholarship",
                    Size = new Size(380, 350),
                    StartPosition = FormStartPosition.CenterParent,
                    BackColor = Color.White,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false
                };

                Label lblN = new Label { Text = "Scholarship Name:", Font = new Font("Century Gothic", 10F, FontStyle.Bold), Location = new Point(25, 20) };
                TextBox txtN = new TextBox { Location = new Point(25, 45), Size = new Size(320, 25), Font = new Font("Century Gothic", 11F) };
                Label lblA = new Label { Text = "Stipend Amount (₱):", Font = new Font("Century Gothic", 10F, FontStyle.Bold), Location = new Point(25, 85) };
                TextBox txtA = new TextBox { Location = new Point(25, 110), Size = new Size(200, 25), Font = new Font("Century Gothic", 11F) };
                Label lblF = new Label { Text = "Payment Frequency:", Font = new Font("Century Gothic", 10F, FontStyle.Bold), Location = new Point(25, 150) };
                ComboBox cmbF = new ComboBox { Location = new Point(25, 175), Size = new Size(320, 28), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Century Gothic", 11F) };
                cmbF.Items.AddRange(new[] { "Monthly", "Quarterly", "Semi-Annual", "Annual" });
                cmbF.SelectedIndex = 0;

                FrameworkTest.SATAButton btnSaveSch = new FrameworkTest.SATAButton
                {
                    ButtonText = "Save Scholarship",
                    NormalBackground = Color.FromArgb(0, 68, 79),
                    NormalForeColor = Color.White,
                    HoverBackground = Color.FromArgb(0, 90, 105),
                    HoverForeColor = Color.White,
                    Location = new Point(100, 240),
                    Size = new Size(160, 40),
                    Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                    Rounding = new Padding(8),
                    TextAutoCenter = true
                };

                btnSaveSch.Click += (s2, e2) =>
                {
                    if (string.IsNullOrWhiteSpace(txtN.Text) || !decimal.TryParse(txtA.Text, out decimal amt))
                    {
                        MessageBox.Show("Invalid inputs", "Warning");
                        return;
                    }
                    try
                    {
                        using (MySqlConnection conn = DatabaseHelper.GetConnection())
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand("INSERT INTO scholarship_types (name, stipend_amount, payment_frequency, is_active) VALUES (@n, @a, @f, 1)", conn);
                            cmd.Parameters.AddWithValue("@n", txtN.Text);
                            cmd.Parameters.AddWithValue("@a", amt);
                            cmd.Parameters.AddWithValue("@f", cmbF.SelectedItem);
                            cmd.ExecuteNonQuery();
                        }
                        f.Close();
                        LoadData();
                        LoadScholarshipTypes();
                        MessageBox.Show("Added successfully!", "Success");
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                };

                f.Controls.AddRange(new Control[] { lblN, txtN, lblA, txtA, lblF, cmbF, btnSaveSch });
                f.ShowDialog();
            };

            btnActivate.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Select a scholarship to activate.", "Warning"); return; }
                if (dgv.SelectedRows[0].Cells["status"].Value.ToString() == "Active") { MessageBox.Show("Already active.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (MessageBox.Show("Activate this scholarship?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                        using (MySqlConnection conn = DatabaseHelper.GetConnection())
                        {
                            conn.Open();
                            new MySqlCommand("UPDATE scholarship_types SET is_active = 1 WHERE id = " + id, conn).ExecuteNonQuery();
                        }
                        LoadData(); LoadScholarshipTypes();
                        MessageBox.Show("Activated!", "Success");
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            };

            btnInactive.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Select a scholarship to deactivate.", "Warning"); return; }
                if (dgv.SelectedRows[0].Cells["status"].Value.ToString() == "Inactive") { MessageBox.Show("Already inactive.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (MessageBox.Show("Deactivate this scholarship?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                        using (MySqlConnection conn = DatabaseHelper.GetConnection())
                        {
                            conn.Open();
                            new MySqlCommand("UPDATE scholarship_types SET is_active = 0 WHERE id = " + id, conn).ExecuteNonQuery();
                        }
                        LoadData(); LoadScholarshipTypes();
                        MessageBox.Show("Deactivated!", "Success");
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            };

            btnClose.Click += (s, e) => dlg.Close();
            dlg.Controls.Add(headerPanel);
            dlg.Controls.Add(dgv);
            dlg.Controls.Add(buttonPanel);
            dlg.ShowDialog();
        }
        #endregion

        private void SetupScholarshipSummaryPanel()
        {
            panelScholarshipSummary.Controls.Clear();
            Panel innerScrollPanel = new Panel();
            innerScrollPanel.Location = new Point(0, 0);
            innerScrollPanel.Size = new Size(panelScholarshipSummary.Width - 20, panelScholarshipSummary.Height);
            innerScrollPanel.AutoScroll = false;
            innerScrollPanel.HorizontalScroll.Enabled = true;
            innerScrollPanel.HorizontalScroll.Visible = true;

            Label lblTitle = new Label();
            lblTitle.Text = " Scholarship Summary";
            lblTitle.Font = new Font("Century Gothic", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 68, 79);
            lblTitle.Location = new Point(15, 8);
            lblTitle.Size = new Size(250, 30);
            innerScrollPanel.Controls.Add(lblTitle);

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT st.id, st.name, st.stipend_amount, st.payment_frequency,
COUNT(s.id) as total_scholars
FROM scholarship_types st
LEFT JOIN scholars s ON st.id = s.scholarship_type_id
WHERE st.is_active = TRUE
GROUP BY st.id, st.name, st.stipend_amount, st.payment_frequency
ORDER BY st.name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int xPos = 20;
                    int boxWidth = 230;
                    int spacing = 15;
                    int totalWidth = 0;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            int total = Convert.ToInt32(reader["total_scholars"]);
                            decimal amount = Convert.ToDecimal(reader["stipend_amount"]);
                            string frequency = reader["payment_frequency"].ToString();

                            Panel card = new Panel();
                            card.BackColor = Color.FromArgb(245, 250, 250);
                            card.BorderStyle = BorderStyle.FixedSingle;
                            card.Location = new Point(xPos, 45);
                            card.Size = new Size(boxWidth, 55);
                            card.Cursor = Cursors.Hand;
                            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(200, 230, 230);
                            card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(245, 250, 250);

                            Label lblName = new Label();
                            lblName.Text = name;
                            lblName.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
                            lblName.ForeColor = Color.FromArgb(0, 68, 79);
                            lblName.Location = new Point(10, 5);
                            lblName.Size = new Size(boxWidth - 20, 20);

                            Label lblCount = new Label();
                            lblCount.Text = $"👤 {total} scholars";
                            lblCount.Font = new Font("Century Gothic", 9F);
                            lblCount.ForeColor = Color.FromArgb(80, 80, 80);
                            lblCount.Location = new Point(10, 25);
                            lblCount.Size = new Size(boxWidth - 120, 20);

                            Label lblAmount = new Label();
                            lblAmount.Text = $"₱{amount:N0}/{frequency}";
                            lblAmount.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
                            lblAmount.ForeColor = Color.FromArgb(0, 100, 100);
                            lblAmount.Location = new Point(boxWidth - 115, 25);
                            lblAmount.Size = new Size(105, 20);
                            lblAmount.TextAlign = ContentAlignment.MiddleRight;

                            card.Controls.Add(lblName);
                            card.Controls.Add(lblCount);
                            card.Controls.Add(lblAmount);
                            innerScrollPanel.Controls.Add(card);

                            xPos += boxWidth + spacing;
                            totalWidth = xPos;
                        }
                    }

                    Label lblTotal = new Label();
                    lblTotal.Text = $"Total Active Scholars: {GetTotalActiveScholars()}";
                    lblTotal.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
                    lblTotal.ForeColor = Color.FromArgb(0, 68, 79);
                    lblTotal.Location = new Point(xPos + 30, 15);
                    lblTotal.Size = new Size(250, 25);
                    innerScrollPanel.Controls.Add(lblTotal);
                    totalWidth = xPos + 280;
                    innerScrollPanel.AutoScrollMinSize = new Size(totalWidth + 20, 0);
                }
            }
            catch (Exception ex)
            {
                Label lblError = new Label();
                lblError.Text = $"Error loading summary: {ex.Message}";
                lblError.ForeColor = Color.Red;
                lblError.Location = new Point(20, 45);
                lblError.AutoSize = true;
                innerScrollPanel.Controls.Add(lblError);
            }

            panelScholarshipSummary.Controls.Add(innerScrollPanel);
        }

        private int GetTotalActiveScholars()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    return Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM scholars WHERE status = 'Active'", conn).ExecuteScalar());
                }
            }
            catch { return 0; }
        }

        private void FrmScholarManagement_Resize(object sender, EventArgs e) { AdjustLayoutForFullscreen(); }

        private void AdjustLayoutForFullscreen()
        {
            int screenWidth = this.ClientSize.Width;
            int screenHeight = this.ClientSize.Height;
            if (panelSearchBar != null)
            {
                panelSearchBar.Location = new Point(301, 160);
                panelSearchBar.Size = new Size(screenWidth - 321, 75);
                if (txtSearch != null)
                    txtSearch.Size = new Size(Math.Max(200, screenWidth - 321 - 750), 27);
            }
            if (tabControlMain != null)
            {
                tabControlMain.Location = new Point(301, 255);
                tabControlMain.Size = new Size(screenWidth - 321, screenHeight - 285);
            }
            if (tabScholarList != null)
            {
                int gridWidth = (int)((screenWidth - 361) * 0.62);
                int formWidth = screenWidth - 361 - gridWidth - 20;
                if (panelScholarList != null)
                {
                    panelScholarList.Location = new Point(10, 10);
                    panelScholarList.Size = new Size(gridWidth, tabControlMain.Height - 40);
                }
                if (panelForm != null)
                {
                    panelForm.Location = new Point(gridWidth + 25, 10);
                    panelForm.Size = new Size(formWidth, tabControlMain.Height - 40);
                }
            }
            if (tabCompliance != null && panelComplianceHeader != null)
            {
                int tabWidth = tabControlMain.Width - 40;
                panelComplianceHeader.Size = new Size(tabWidth, 130);
                dgvCompliance.Size = new Size(tabWidth, 380);
                dgvCompliance.Location = new Point(20, 170);
                panelComplianceForm.Location = new Point(20, 570);
                panelScholarshipSummary.Size = new Size(tabWidth, 110);
                panelScholarshipSummary.Location = new Point(20, 640);
                lblComplianceOverall.Location = new Point(tabWidth - 800, 20);
            }
        }

        private void FrmScholarManagement_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            string adminName = SessionManager.CurrentUser?.Name ?? "Administrator";
            lblGreeting.Text = $"Scholar Management - {adminName}";
            LoadFilterOptions();
            LoadScholarsGrid();
            LoadScholarshipTypes();
            LoadCourses();
            ClearForm();
            dtpEnrollmentDate.Value = DateTime.Now;
            dtpExpectedGraduation.Value = DateTime.Now.AddYears(4);
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);
            txtSearch.Text = "Search scholar...";
            txtSearch.ForeColor = Color.Gray;
            cmbStatus.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;
            AdjustLayoutForFullscreen();
        }

        private void LoadFilterOptions()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    cmbFilterStatus.Items.Clear();
                    cmbFilterStatus.Items.Add("All Status");
                    cmbFilterStatus.Items.AddRange(new[] { "Active", "Inactive", "Probation", "Suspended", "Graduated", "Terminated", "Withdrawn", "Expelled", "Completed", "Dropped" });

                    cmbFilterScholarship.Items.Clear();
                    cmbFilterScholarship.Items.Add("All Scholarships");
                    string query = "SELECT name FROM scholarship_types WHERE is_active = TRUE ORDER BY name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read())
                            cmbFilterScholarship.Items.Add(reader["name"].ToString());
                }
                if (cmbFilterStatus.Items.Count > 0) cmbFilterStatus.SelectedIndex = 0;
                if (cmbFilterScholarship.Items.Count > 0) cmbFilterScholarship.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show($"Error loading filter options: {ex.Message}", "Error"); }
        }

        private void LoadScholarsGrid()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT s.id, s.scholar_number, s.student_id,
CONCAT(s.first_name, ' ', COALESCE(s.middle_name, ''), ' ', s.last_name) AS full_name,
s.first_name, s.middle_name, s.last_name, s.course, s.year_level, 
st.name AS scholarship_name, s.status, s.email, s.contact_number, 
s.enrollment_date, s.expected_graduation, s.hei, s.degree_program, 
s.gender, s.date_of_birth, s.address,
COALESCE(s.stipend_amount, st.stipend_amount) as stipend_amount,
s.stipend_frequency, s.scholarship_fund_source,
s.renewal_conditions, s.bank_name, s.bank_account_number, s.scholarship_type_id
FROM scholars s
LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id WHERE 1=1";
                    if (cmbFilterStatus.SelectedIndex > 0 && cmbFilterStatus.SelectedItem != null)
                        query += " AND s.status = @status";
                    if (cmbFilterScholarship.SelectedIndex > 0 && cmbFilterScholarship.SelectedItem != null)
                        query += " AND st.name = @scholarship";
                    if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "Search scholar...")
                        query += " AND (s.scholar_number LIKE @search OR s.first_name LIKE @search OR s.last_name LIKE @search OR s.student_id LIKE @search)";
                    query += " ORDER BY s.id DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (cmbFilterStatus.SelectedIndex > 0 && cmbFilterStatus.SelectedItem != null)
                        cmd.Parameters.AddWithValue("@status", cmbFilterStatus.SelectedItem.ToString());
                    if (cmbFilterScholarship.SelectedIndex > 0 && cmbFilterScholarship.SelectedItem != null)
                        cmd.Parameters.AddWithValue("@scholarship", cmbFilterScholarship.SelectedItem.ToString());
                    if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "Search scholar...")
                        cmd.Parameters.AddWithValue("@search", $"%{txtSearch.Text}%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvScholars.Rows.Clear();
                        while (reader.Read())
                        {
                            int rowIndex = dgvScholars.Rows.Add();
                            dgvScholars.Rows[rowIndex].Cells["colScholarID"].Value = reader["id"];
                            dgvScholars.Rows[rowIndex].Cells["colScholarNumber"].Value = reader["scholar_number"];
                            dgvScholars.Rows[rowIndex].Cells["colStudentID"].Value = reader["student_id"];
                            dgvScholars.Rows[rowIndex].Cells["colName"].Value = reader["full_name"];
                            dgvScholars.Rows[rowIndex].Cells["colCourse"].Value = reader["course"];
                            dgvScholars.Rows[rowIndex].Cells["colYearLevel"].Value = reader["year_level"];
                            dgvScholars.Rows[rowIndex].Cells["colScholarship"].Value = reader["scholarship_name"];
                            dgvScholars.Rows[rowIndex].Cells["colStatus"].Value = reader["status"];

                            dgvScholars.Rows[rowIndex].Tag = new ScholarDetailData
                            {
                                ScholarId = Convert.ToInt32(reader["id"]),
                                ScholarNumber = reader["scholar_number"]?.ToString(),
                                StudentId = reader["student_id"]?.ToString(),
                                FirstName = reader["first_name"]?.ToString(),
                                MiddleName = reader["middle_name"]?.ToString(),
                                LastName = reader["last_name"]?.ToString(),
                                Email = reader["email"]?.ToString(),
                                ContactNumber = reader["contact_number"]?.ToString(),
                                Gender = reader["gender"]?.ToString(),
                                DateOfBirth = reader["date_of_birth"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_birth"]) : (DateTime?)null,
                                Address = reader["address"]?.ToString(),
                                Course = reader["course"]?.ToString(),
                                YearLevel = reader["year_level"]?.ToString(),
                                ScholarshipName = reader["scholarship_name"]?.ToString(),
                                Status = reader["status"]?.ToString(),
                                StipendAmount = reader["stipend_amount"] != DBNull.Value ? Convert.ToDecimal(reader["stipend_amount"]) : 0,
                                StipendFrequency = reader["stipend_frequency"]?.ToString(),
                                FundSource = reader["scholarship_fund_source"]?.ToString(),
                                RenewalConditions = reader["renewal_conditions"]?.ToString(),
                                BankName = reader["bank_name"]?.ToString(),
                                BankAccountNumber = reader["bank_account_number"]?.ToString(),
                                EnrollmentDate = reader["enrollment_date"] != DBNull.Value ? Convert.ToDateTime(reader["enrollment_date"]) : (DateTime?)null,
                                ExpectedGraduation = reader["expected_graduation"] != DBNull.Value ? Convert.ToDateTime(reader["expected_graduation"]) : (DateTime?)null,
                                HEI = reader["hei"]?.ToString(),
                                DegreeProgram = reader["degree_program"]?.ToString()
                            };

                            string status = reader["status"].ToString();
                            Color sc; switch (status) { case "Active": sc = Color.FromArgb(40, 167, 69); break; case "Inactive": sc = Color.Gray; break; case "Graduated": sc = Color.FromArgb(0, 123, 255); break; default: sc = Color.FromArgb(255, 170, 0); break; }
                            dgvScholars.Rows[rowIndex].Cells["colStatus"].Style.ForeColor = sc;
                            dgvScholars.Rows[rowIndex].Cells["colStatus"].Style.Font = new Font(dgvScholars.Font, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error loading scholars: {ex.Message}", "Error"); }
        }

        private void LoadScholarshipTypes()
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    cmbScholarshipType.Items.Clear();
                    using (MySqlDataReader reader = new MySqlCommand("SELECT id, name FROM scholarship_types WHERE is_active = TRUE ORDER BY name", conn).ExecuteReader())
                        while (reader.Read())
                            cmbScholarshipType.Items.Add(new ComboBoxItem { Id = Convert.ToInt32(reader["id"]), Name = reader["name"].ToString() });
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error loading scholarship types: {ex.Message}", "Error"); }
        }

        private void LoadCourses()
        {
            cmbCourse.Items.Clear();
            cmbCourse.Items.AddRange(new object[] {
                "Bachelor of Science in Business Administration (Major in Financial Management)",
                "Bachelor of Science in Business Administration (Major in Marketing Management)",
                "Bachelor of Science in Business Administration (Major in Human Resource Management)",
                "Bachelor of Science in Criminology",
                "Bachelor of Elementary Education (Generalist)",
                "Bachelor of Secondary Education (Major in English)",
                "Bachelor of Secondary Education (Major in Social Studies)",
                "Bachelor of Secondary Education (Major in Values Education)",
                "Bachelor of Science in Information Technology",
                "Bachelor of Science in Tourism Management"
            });
        }

        private void LoadScholarDetails(int scholarId)
        {
            try
            {
                _loadedFileData.Clear();
                _loadedFileNames.Clear();
                _filesModified = false;

                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT s.*, st.id as scholarship_type_id, st.name as scholarship_name
FROM scholars s LEFT JOIN scholarship_types st ON s.scholarship_type_id = st.id WHERE s.id = @scholarId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@scholarId", scholarId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _currentScholarId = scholarId;
                            txtScholarNumber.Text = reader["scholar_number"]?.ToString() ?? "";
                            txtStudentId.Text = reader["student_id"]?.ToString() ?? "";
                            txtFirstName.Text = reader["first_name"]?.ToString() ?? "";
                            txtMiddleName.Text = reader["middle_name"]?.ToString() ?? "";
                            txtLastName.Text = reader["last_name"]?.ToString() ?? "";
                            txtEmail.Text = reader["email"]?.ToString() ?? "";
                            txtContactNumber.Text = reader["contact_number"]?.ToString() ?? "";
                            txtAddress.Text = reader["address"]?.ToString() ?? "";
                            if (reader["date_of_birth"] != DBNull.Value) dtpDateOfBirth.Value = Convert.ToDateTime(reader["date_of_birth"]);
                            string gender = reader["gender"]?.ToString() ?? "Male";
                            if (cmbGender.Items.Contains(gender)) cmbGender.SelectedItem = gender;
                            string course = reader["course"]?.ToString() ?? "";
                            if (cmbCourse.Items.Contains(course)) cmbCourse.SelectedItem = course;
                            string yearLevel = reader["year_level"]?.ToString() ?? "";
                            if (cmbYearLevel.Items.Contains(yearLevel)) cmbYearLevel.SelectedItem = yearLevel;
                            int scholarshipTypeId = reader["scholarship_type_id"] != DBNull.Value ? Convert.ToInt32(reader["scholarship_type_id"]) : 0;
                            cmbScholarshipType.SelectedIndex = -1;
                            for (int i = 0; i < cmbScholarshipType.Items.Count; i++)
                            {
                                ComboBoxItem item = cmbScholarshipType.Items[i] as ComboBoxItem;
                                if (item != null && item.Id == scholarshipTypeId) { cmbScholarshipType.SelectedIndex = i; break; }
                            }
                            txtStipendAmount.Text = reader["stipend_amount"] != DBNull.Value ? reader["stipend_amount"].ToString() : "0";
                            string stipendFreq = reader["stipend_frequency"]?.ToString() ?? "Monthly";
                            if (cmbStipendFrequency.Items.Contains(stipendFreq)) cmbStipendFrequency.SelectedItem = stipendFreq;
                            string fundSource = reader["scholarship_fund_source"]?.ToString() ?? "";
                            if (cmbFundSource.Items.Contains(fundSource)) cmbFundSource.SelectedItem = fundSource;
                            txtRenewalConditions.Text = reader["renewal_conditions"]?.ToString() ?? "";
                            txtBankName.Text = reader["bank_name"]?.ToString() ?? "";
                            txtBankAccountNumber.Text = reader["bank_account_number"]?.ToString() ?? "";
                            if (reader["enrollment_date"] != DBNull.Value) dtpEnrollmentDate.Value = Convert.ToDateTime(reader["enrollment_date"]);
                            if (reader["expected_graduation"] != DBNull.Value) dtpExpectedGraduation.Value = Convert.ToDateTime(reader["expected_graduation"]);
                            string status = reader["status"]?.ToString() ?? "Active";
                            if (cmbStatus.Items.Contains(status)) cmbStatus.SelectedItem = status;
                            UpdateDeactivateButton(status);
                        }
                    }
                    LoadFileAttachments(scholarId, conn);
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error loading scholar details: {ex.Message}", "Error"); }
        }

        private void LoadFileAttachments(int scholarId, MySqlConnection conn)
        {
            try
            {
                // Reset all combo boxes
                ComboBox[] allCmbs = { cmbFilePSA, cmbFileCOE, cmbFileCOR, cmbFileGrades, cmbFileContract };
                foreach (var cmb in allCmbs)
                {
                    cmb.Tag = "updating";
                    cmb.Items.Clear();
                    cmb.Items.Add("TBA (To be Arranged)");
                    cmb.Items.Add("Attach File");
                    cmb.SelectedIndex = 0;
                    cmb.BackColor = Color.White;
                    cmb.ForeColor = Color.Black;
                    cmb.Tag = null;
                }

                // Load files from database
                string query = @"SELECT cr.requirement_type, fa.file_name, fa.file_data
FROM compliance_records cr
LEFT JOIN file_attachments fa ON cr.id = fa.compliance_id
WHERE cr.scholar_id = @scholarId AND fa.file_name IS NOT NULL
ORDER BY fa.uploaded_at DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@scholarId", scholarId);

                var processedTypes = new HashSet<string>();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string dbType = reader["requirement_type"].ToString();
                        if (processedTypes.Contains(dbType)) continue;
                        processedTypes.Add(dbType);

                        ComboBox cmb = GetComboBoxForDbType(dbType);
                        if (cmb == null) continue;

                        string fileName = reader["file_name"].ToString();
                        byte[] fileData = (byte[])reader["file_data"];
                        long fileSizeKB = fileData.Length / 1024;
                        if (fileSizeKB == 0) fileSizeKB = 1;

                        string docKey = GetDocKeyForDbType(dbType);
                        _loadedFileData[docKey] = fileData;
                        _loadedFileNames[docKey] = fileName;

                        cmb.Tag = "updating";
                        cmb.Items.Clear();
                        cmb.Items.Add("TBA (To be Arranged)");
                        cmb.Items.Add($"✅ {fileName} ({fileSizeKB} KB) - Attached");
                        cmb.Items.Add("Change File...");
                        cmb.Items.Add("Remove File");
                        cmb.SelectedIndex = 1;
                        cmb.BackColor = Color.FromArgb(220, 255, 220);
                        cmb.ForeColor = Color.FromArgb(0, 100, 0);
                        cmb.Tag = "attached";
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"Error loading files: {ex.Message}"); }
        }

        private void UpdateDeactivateButton(string status)
        {
            if (btnDeactivate != null)
            {
                btnDeactivate.Enabled = true;
                switch (status)
                {
                    case "Active":
                        btnDeactivate.ButtonText = "Deactivate";
                        btnDeactivate.NormalBackground = Color.FromArgb(255, 170, 0);
                        break;
                    case "Inactive":
                        btnDeactivate.ButtonText = "Activate";
                        btnDeactivate.NormalBackground = Color.FromArgb(40, 167, 69);
                        break;
                    default:
                        btnDeactivate.ButtonText = "Change";
                        btnDeactivate.NormalBackground = Color.FromArgb(180, 180, 180);
                        break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentScholarId == 0) AddNewScholarWithFiles();
            else btnUpdate_Click(sender, e);
        }

        private void AddNewScholarWithFiles()
        {
            if (!ValidateForm()) return;
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction tr = conn.BeginTransaction())
                    {
                        string year = DateTime.Now.Year.ToString();
                        int count = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM scholars WHERE scholar_number LIKE 'SCH-" + year + "-%'", conn, tr).ExecuteScalar()) + 1;
                        string schNum = $"SCH-{year}-{count:D3}";
                        string studentId = string.IsNullOrWhiteSpace(txtStudentId.Text) ? $"{year}-00{count:D3}" : txtStudentId.Text.Trim();
                        int scholarshipTypeId = 0;
                        ComboBoxItem selected = cmbScholarshipType.SelectedItem as ComboBoxItem;
                        if (selected != null) scholarshipTypeId = selected.Id;
                        decimal stipendAmount = 0;
                        decimal.TryParse(txtStipendAmount.Text, out stipendAmount);

                        MySqlCommand insScholar = new MySqlCommand(
                            "INSERT INTO scholars (scholar_number, student_id, first_name, middle_name, last_name, email, contact_number, date_of_birth, gender, address, course, year_level, scholarship_type_id, stipend_amount, stipend_frequency, scholarship_fund_source, renewal_conditions, bank_name, bank_account_number, enrollment_date, expected_graduation, status, hei, degree_program, program, created_at) " +
                            "VALUES (@sn, @sid, @fn, @mn, @ln, @em, @cn, @dob, @gen, @addr, @course, @yl, @stid, @sa, @sf, @fs, @rc, @bn, @ban, @ed, @eg, 'Active', 'Legacy College of Compostela', @course, 'Undergraduate', NOW())", conn, tr);
                        insScholar.Parameters.AddWithValue("@sn", schNum);
                        insScholar.Parameters.AddWithValue("@sid", studentId);
                        insScholar.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                        insScholar.Parameters.AddWithValue("@mn", txtMiddleName.Text.Trim());
                        insScholar.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());
                        insScholar.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
                        insScholar.Parameters.AddWithValue("@cn", txtContactNumber.Text.Trim());
                        insScholar.Parameters.AddWithValue("@dob", dtpDateOfBirth.Value);
                        insScholar.Parameters.AddWithValue("@gen", cmbGender.SelectedItem?.ToString() ?? "Male");
                        insScholar.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                        insScholar.Parameters.AddWithValue("@course", cmbCourse.SelectedItem?.ToString() ?? "");
                        insScholar.Parameters.AddWithValue("@yl", cmbYearLevel.SelectedItem?.ToString() ?? "");
                        insScholar.Parameters.AddWithValue("@stid", scholarshipTypeId);
                        insScholar.Parameters.AddWithValue("@sa", stipendAmount);
                        insScholar.Parameters.AddWithValue("@sf", cmbStipendFrequency.SelectedItem?.ToString() ?? "Monthly");
                        insScholar.Parameters.AddWithValue("@fs", cmbFundSource.SelectedItem?.ToString() ?? "");
                        insScholar.Parameters.AddWithValue("@rc", txtRenewalConditions.Text.Trim());
                        insScholar.Parameters.AddWithValue("@bn", txtBankName.Text.Trim());
                        insScholar.Parameters.AddWithValue("@ban", txtBankAccountNumber.Text.Trim());
                        insScholar.Parameters.AddWithValue("@ed", dtpEnrollmentDate.Value);
                        insScholar.Parameters.AddWithValue("@eg", dtpExpectedGraduation.Value);
                        insScholar.ExecuteNonQuery();

                        int newScholarId = Convert.ToInt32(new MySqlCommand("SELECT LAST_INSERT_ID()", conn, tr).ExecuteScalar());

                        // Create compliance records with correct enum values
                        for (int i = 0; i < 5; i++)
                        {
                            bool isAttached = _loadedFileData.ContainsKey(_docKeys[i]);
                            string status = isAttached ? "Submitted" : "Pending";

                            MySqlCommand insComp = new MySqlCommand(
                                "INSERT INTO compliance_records (scholar_id, requirement_type, description, due_date, status) VALUES (@sid, @type, @desc, @due, @status); SELECT LAST_INSERT_ID();", conn, tr);
                            insComp.Parameters.AddWithValue("@sid", newScholarId);
                            insComp.Parameters.AddWithValue("@type", _dbTypes[i]);  // Uses correct DB enum value!
                            insComp.Parameters.AddWithValue("@desc", _descriptions[i]);
                            insComp.Parameters.AddWithValue("@due", DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"));
                            insComp.Parameters.AddWithValue("@status", status);
                            int compId = Convert.ToInt32(insComp.ExecuteScalar());

                            if (isAttached)
                            {
                                byte[] data = _loadedFileData[_docKeys[i]];
                                string fileName = _loadedFileNames[_docKeys[i]];
                                MySqlCommand insFile = new MySqlCommand(
                                    "INSERT INTO file_attachments (scholar_id, compliance_id, file_name, original_name, file_type, file_size, file_data, uploaded_by) VALUES (@sid, @cid, @fn, @on, @ft, @sz, @data, 1)", conn, tr);
                                insFile.Parameters.AddWithValue("@sid", newScholarId);
                                insFile.Parameters.AddWithValue("@cid", compId);
                                insFile.Parameters.AddWithValue("@fn", fileName);
                                insFile.Parameters.AddWithValue("@on", fileName);
                                insFile.Parameters.AddWithValue("@ft", Path.GetExtension(fileName).ToLower());
                                insFile.Parameters.AddWithValue("@sz", data.Length);
                                insFile.Parameters.AddWithValue("@data", data);
                                insFile.ExecuteNonQuery();
                            }
                        }

                        tr.Commit();
                        ActivityLogger.LogCreate("scholars", newScholarId, $"Created new scholar: {txtFirstName.Text} {txtLastName.Text}");
                        MessageBox.Show("Scholar added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadScholarsGrid();
                        ClearForm();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error saving scholar: {ex.Message}", "Error"); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentScholarId == 0) { MessageBox.Show("Please select a scholar to update.", "Warning"); return; }
            if (!ValidateForm()) return;
            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    int scholarshipTypeId = 0;
                    ComboBoxItem selected = cmbScholarshipType.SelectedItem as ComboBoxItem;
                    if (selected != null) scholarshipTypeId = selected.Id;
                    decimal stipendAmount = 0;
                    decimal.TryParse(txtStipendAmount.Text, out stipendAmount);

                    string query = @"UPDATE scholars SET student_id=@studentId, first_name=@firstName, middle_name=@middleName, last_name=@lastName,
email=@email, contact_number=@contactNumber, date_of_birth=@dateOfBirth, gender=@gender, address=@address,
course=@course, year_level=@yearLevel, scholarship_type_id=@scholarshipTypeId, stipend_amount=@stipendAmount,
stipend_frequency=@stipendFrequency, scholarship_fund_source=@fundSource, renewal_conditions=@renewalConditions,
bank_name=@bankName, bank_account_number=@bankAccountNumber, enrollment_date=@enrollmentDate,
expected_graduation=@expectedGraduation, status=@status, degree_program=@course WHERE id=@scholarId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@studentId", txtStudentId.Text.Trim());
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@middleName", txtMiddleName.Text.Trim());
                    cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@contactNumber", txtContactNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateOfBirth", dtpDateOfBirth.Value);
                    cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem?.ToString() ?? "Male");
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@course", cmbCourse.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@yearLevel", cmbYearLevel.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@scholarshipTypeId", scholarshipTypeId);
                    cmd.Parameters.AddWithValue("@stipendAmount", stipendAmount);
                    cmd.Parameters.AddWithValue("@stipendFrequency", cmbStipendFrequency.SelectedItem?.ToString() ?? "Monthly");
                    cmd.Parameters.AddWithValue("@fundSource", cmbFundSource.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@renewalConditions", txtRenewalConditions.Text.Trim());
                    cmd.Parameters.AddWithValue("@bankName", txtBankName.Text.Trim());
                    cmd.Parameters.AddWithValue("@bankAccountNumber", txtBankAccountNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@enrollmentDate", dtpEnrollmentDate.Value);
                    cmd.Parameters.AddWithValue("@expectedGraduation", dtpExpectedGraduation.Value);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem?.ToString() ?? "Active");
                    cmd.Parameters.AddWithValue("@scholarId", _currentScholarId);
                    cmd.ExecuteNonQuery();

                    SyncFilesToCompliance(_currentScholarId);
                    ActivityLogger.LogUpdate("scholars", _currentScholarId, $"Updated scholar: {txtFirstName.Text} {txtLastName.Text}");
                    MessageBox.Show("Scholar updated successfully!", "Success");
                    LoadScholarsGrid();
                    LoadScholarDetails(_currentScholarId);
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error updating scholar: {ex.Message}", "Error"); }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (_currentScholarId == 0) { MessageBox.Show("Please select a scholar first.", "Warning"); return; }
            string currentStatus = cmbStatus.SelectedItem?.ToString() ?? "";
            string newStatus = currentStatus == "Active" ? "Inactive" : "Active";
            string action = currentStatus == "Active" ? "deactivate" : "reactivate";
            if (MessageBox.Show($"Are you sure you want to {action} this scholar?", $"Confirm {action}", MessageBoxButtons.YesNo, currentStatus == "Active" ? MessageBoxIcon.Warning : MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        new MySqlCommand($"UPDATE scholars SET status = '{newStatus}' WHERE id = {_currentScholarId}", conn).ExecuteNonQuery();
                    }
                    ActivityLogger.LogUpdate("scholars", _currentScholarId, $"{(currentStatus == "Active" ? "Deactivated" : "Reactivated")} scholar");
                    MessageBox.Show($"Scholar {action}d successfully!", "Success");
                    LoadScholarsGrid();
                    LoadScholarDetails(_currentScholarId);
                }
                catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error"); }
            }
        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            if (_currentScholarId == 0) { MessageBox.Show("Please select a scholar to view details.", "Warning"); return; }
            new FrmScholarDetailsView(_currentScholarId).ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e) { ClearForm(); }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text)) { MessageBox.Show("First Name is required."); txtFirstName.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtLastName.Text)) { MessageBox.Show("Last Name is required."); txtLastName.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { MessageBox.Show("Email is required."); txtEmail.Focus(); return false; }
            if (cmbCourse.SelectedIndex == -1) { MessageBox.Show("Please select a course."); cmbCourse.Focus(); return false; }
            if (cmbYearLevel.SelectedIndex == -1) { MessageBox.Show("Please select a year level."); cmbYearLevel.Focus(); return false; }
            if (cmbScholarshipType.SelectedIndex == -1) { MessageBox.Show("Please select a scholarship type."); cmbScholarshipType.Focus(); return false; }
            return true;
        }

        private void ClearForm()
        {
            _currentScholarId = 0;
            _loadedFileData.Clear();
            _loadedFileNames.Clear();
            _filesModified = false;

            txtScholarNumber.Text = "";
            txtStudentId.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtContactNumber.Text = "";
            txtAddress.Text = "";
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);
            cmbGender.SelectedIndex = 0;
            cmbCourse.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;
            cmbScholarshipType.SelectedIndex = -1;
            txtStipendAmount.Text = "0";
            cmbStipendFrequency.SelectedIndex = 0;
            cmbFundSource.SelectedIndex = -1;
            txtRenewalConditions.Text = "";
            txtBankName.Text = "";
            txtBankAccountNumber.Text = "";
            dtpEnrollmentDate.Value = DateTime.Now;
            dtpExpectedGraduation.Value = DateTime.Now.AddYears(4);
            cmbStatus.SelectedIndex = 0;

            ComboBox[] allCmbs = { cmbFilePSA, cmbFileCOE, cmbFileCOR, cmbFileGrades, cmbFileContract };
            foreach (var cmb in allCmbs)
            {
                cmb.Tag = "updating";
                cmb.Items.Clear();
                cmb.Items.Add("TBA (To be Arranged)");
                cmb.Items.Add("Attach File");
                cmb.SelectedIndex = 0;
                cmb.BackColor = Color.White;
                cmb.ForeColor = Color.Black;
                cmb.Tag = null;
            }

            if (txtFilePSAPath != null) txtFilePSAPath.Text = "";
            if (txtFileCOEPath != null) txtFileCOEPath.Text = "";
            if (txtFileCORPath != null) txtFileCORPath.Text = "";
            if (txtFileGradesPath != null) txtFileGradesPath.Text = "";
            if (txtFileContractPath != null) txtFileContractPath.Text = "";

            if (btnDeactivate != null) { btnDeactivate.ButtonText = "Deactivate"; btnDeactivate.NormalBackground = Color.FromArgb(255, 170, 0); btnDeactivate.Enabled = true; }
        }

        private void dgvScholars_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvScholars.SelectedRows.Count > 0 && dgvScholars.SelectedRows[0].Cells["colScholarID"].Value != null)
                LoadScholarDetails(Convert.ToInt32(dgvScholars.SelectedRows[0].Cells["colScholarID"].Value));
        }

        private void dgvScholars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                new FrmScholarDetailsView(Convert.ToInt32(dgvScholars.Rows[e.RowIndex].Cells["colScholarID"].Value)).ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { LoadScholarsGrid(); }
        private void txtSearch_Enter(object sender, EventArgs e) { if (txtSearch.Text == "Search scholar...") { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } }
        private void txtSearch_Leave(object sender, EventArgs e) { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "Search scholar..."; txtSearch.ForeColor = Color.Gray; } }
        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e) { LoadScholarsGrid(); }
        private void cmbFilterScholarship_SelectedIndexChanged(object sender, EventArgs e) { LoadScholarsGrid(); }

        private void btnDashboard1_Click(object sender, EventArgs e) { new FrmAdminDashboard().Show(); this.Hide(); }
        private void btnPayroll1_Click(object sender, EventArgs e) { new FrmPayrollProcessing().Show(); this.Hide(); }
        private void btnReports1_Click(object sender, EventArgs e) { new FrmReportsAnalytics().Show(); this.Hide(); }
        private void btnActivityLog1_Click(object sender, EventArgs e) { new FrmActivityLogs().Show(); this.Hide(); }
        private void btnReminder1_Click(object sender, EventArgs e) { new FrmNotifications().Show(); this.Hide(); }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            ActivityLogger.LogLogout(SessionManager.CurrentUser?.Id ?? 0, SessionManager.CurrentUser?.Name ?? "");
            SessionManager.ClearSession();
            new Login().Show();
            this.Close();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e) { }
        private void panelContent_Paint_1(object sender, PaintEventArgs e) { }
        private void panelContent_Paint_2(object sender, PaintEventArgs e) { }
        private void panelContent_Paint_3(object sender, PaintEventArgs e) { }
        private void dgvScholars_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtBankAccountNumber_TextChanged(object sender, EventArgs e) { }
        private void lblBankAccountNumber_Click(object sender, EventArgs e) { }
        private void txtScholarNumber_TextChanged(object sender, EventArgs e) { }
        private void lblScholarNumber_Click(object sender, EventArgs e) { }
        private void cmbFundSource_SelectedIndexChanged(object sender, EventArgs e) { }
    }

    public class ComboBoxItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() { return Name; }
    }

    public class ScholarDetailData
    {
        public int ScholarId { get; set; }
        public string ScholarNumber { get; set; }
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string ScholarshipName { get; set; }
        public string Status { get; set; }
        public decimal StipendAmount { get; set; }
        public string StipendFrequency { get; set; }
        public string FundSource { get; set; }
        public string RenewalConditions { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime? ExpectedGraduation { get; set; }
        public string HEI { get; set; }
        public string DegreeProgram { get; set; }
    }
}