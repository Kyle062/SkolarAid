using SkolarAid.form;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class FrmScholarProfile : Form
    {
        private int _scholarId;
        private string _scholarName;
        private string _scholarNumber;
        private bool _isEditMode = false;

        public FrmScholarProfile(int scholarId, string scholarName, string scholarNumber)
        {
            InitializeComponent();
            _scholarId = scholarId;
            _scholarName = scholarName;
            _scholarNumber = scholarNumber;

            LoadProfileData();
        }

        private void FrmScholarProfile_Load(object sender, EventArgs e)
        {
            lblScholarInfo.Text = $"{_scholarName} | Scholar #: {_scholarNumber}";
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            SetEditMode(false);
        }

        private void LoadProfileData()
        {
            // TODO: Load actual data from database
            // These are placeholder values

            // Personal Information
            txtFirstName.Text = "Juan";
            txtMiddleName.Text = "Santos";
            txtLastName.Text = "Dela Cruz";
            txtEmail.Text = "juan.delacruz@student.legacy.edu.ph";
            txtContactNumber.Text = "0912 345 6789";
            txtAddress.Text = "123 Main Street, Compostela, Davao de Oro";
            dtpBirthDate.Value = new DateTime(2002, 5, 15);
            cmbGender.SelectedIndex = 0; // Male
            txtGuardianName.Text = "Maria Dela Cruz";
            txtGuardianContact.Text = "0918 765 4321";

            // Academic Information
            txtStudentID.Text = "2024-001234";
            cmbCourse.SelectedIndex = 0; // BS Information Technology
            cmbYearLevel.SelectedIndex = 1; // 2nd Year
            txtSection.Text = "IT-2A";
            txtCurrentGPA.Text = "1.75";

            // Scholarship Information
            txtScholarNumber.Text = _scholarNumber;
            cmbScholarshipType.SelectedIndex = 0; // Academic Excellence
            dtpEnrollmentDate.Value = new DateTime(2024, 8, 1);
            dtpExpectedGraduation.Value = new DateTime(2028, 6, 30);
            cmbStatus.SelectedIndex = 0; // Active
            txtStipendAmount.Text = "₱5,000.00 / Month";
        }

        private void SetEditMode(bool isEdit)
        {
            _isEditMode = isEdit;

            // Toggle read-only state for all input fields
            txtFirstName.ReadOnly = !isEdit;
            txtMiddleName.ReadOnly = !isEdit;
            txtLastName.ReadOnly = !isEdit;
            txtEmail.ReadOnly = !isEdit;
            txtContactNumber.ReadOnly = !isEdit;
            txtAddress.ReadOnly = !isEdit;
            dtpBirthDate.Enabled = isEdit;
            cmbGender.Enabled = isEdit;
            txtGuardianName.ReadOnly = !isEdit;
            txtGuardianContact.ReadOnly = !isEdit;

            // Academic fields (read-only for scholars)
            txtStudentID.ReadOnly = true;
            cmbCourse.Enabled = false;
            cmbYearLevel.Enabled = false;
            txtSection.ReadOnly = true;
            txtCurrentGPA.ReadOnly = true;

            // Scholarship fields (read-only for scholars)
            txtScholarNumber.ReadOnly = true;
            cmbScholarshipType.Enabled = false;
            dtpEnrollmentDate.Enabled = false;
            dtpExpectedGraduation.Enabled = false;
            cmbStatus.Enabled = false;

            // Toggle buttons
            btnEdit.Visible = !isEdit;
            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;
            btnChangePassword.Enabled = !isEdit;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmScholarDashboard dashboard = new FrmScholarDashboard(_scholarId, _scholarName, _scholarNumber);
            dashboard.Show();
            this.Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Already on profile
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            // Navigate to payment history
            // FrmPaymentHistory payments = new FrmPaymentHistory(_scholarId);
            // payments.Show();
            // this.Hide();
        }

        private void btnCompliance_Click(object sender, EventArgs e)
        {
            // Navigate to compliance
            // FrmCompliance compliance = new FrmCompliance(_scholarId);
            // compliance.Show();
            // this.Hide();
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            // Navigate to notifications
            // FrmScholarNotifications notifications = new FrmScholarNotifications(_scholarId);
            // notifications.Show();
            // this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // TODO: Save changes to database
            MessageBox.Show("Profile updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetEditMode(false);
            LoadProfileData(); // Refresh data
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetEditMode(false);
            LoadProfileData(); // Revert changes
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Open change password dialog
            using (var dialog = new FrmChangePassword(_scholarId))
            {
                dialog.ShowDialog();
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select Profile Photo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picProfilePhoto.Image = Image.FromFile(openFileDialog.FileName);
                        // TODO: Save image to database
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

// Simple change password dialog form
public partial class FrmChangePassword : Form
{
    private int _scholarId;

    public FrmChangePassword(int scholarId)
    {
        _scholarId = scholarId;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "Change Password";
        this.Size = new Size(450, 300);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.BackColor = Color.White;

        Label lblCurrent = new Label()
        {
            Text = "Current Password:",
            Location = new Point(30, 30),
            Size = new Size(150, 25),
            Font = new Font("Century Gothic", 11)
        };

        TextBox txtCurrent = new TextBox()
        {
            Location = new Point(30, 60),
            Size = new Size(370, 30),
            Font = new Font("Century Gothic", 11),
            UseSystemPasswordChar = true
        };

        Label lblNew = new Label()
        {
            Text = "New Password:",
            Location = new Point(30, 100),
            Size = new Size(150, 25),
            Font = new Font("Century Gothic", 11)
        };

        TextBox txtNew = new TextBox()
        {
            Location = new Point(30, 130),
            Size = new Size(370, 30),
            Font = new Font("Century Gothic", 11),
            UseSystemPasswordChar = true
        };

        Label lblConfirm = new Label()
        {
            Text = "Confirm New Password:",
            Location = new Point(30, 170),
            Size = new Size(200, 25),
            Font = new Font("Century Gothic", 11)
        };

        TextBox txtConfirm = new TextBox()
        {
            Location = new Point(30, 200),
            Size = new Size(370, 30),
            Font = new Font("Century Gothic", 11),
            UseSystemPasswordChar = true
        };

        Button btnSave = new Button()
        {
            Text = "Save",
            Location = new Point(220, 250),
            Size = new Size(85, 35),
            BackColor = Color.FromArgb(0, 68, 79),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Century Gothic", 11, FontStyle.Bold)
        };
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Click += (s, e) =>
        {
            if (string.IsNullOrEmpty(txtCurrent.Text) ||
                string.IsNullOrEmpty(txtNew.Text) ||
                string.IsNullOrEmpty(txtConfirm.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNew.Text != txtConfirm.Text)
            {
                MessageBox.Show("New passwords do not match.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Verify current password and update in database
            MessageBox.Show("Password changed successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        };

        Button btnCancel = new Button()
        {
            Text = "Cancel",
            Location = new Point(315, 250),
            Size = new Size(85, 35),
            BackColor = Color.FromArgb(180, 180, 180),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Century Gothic", 11, FontStyle.Bold)
        };
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.Click += (s, e) => this.Close();

        this.Controls.AddRange(new Control[]
        {
            lblCurrent, txtCurrent,
            lblNew, txtNew,
            lblConfirm, txtConfirm,
            btnSave, btnCancel
        });
    }
}