using System;
using System.Windows.Forms;
using SkolarAid.form.Admin;

namespace SkolarAid.form.Admin
{
    public partial class FrmAdminDashboard : Form
    {
        public FrmAdminDashboard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sataButton2_Click(object sender, EventArgs e)
        {
            FrmScholarManagement scholar = new FrmScholarManagement();
            scholar.Show();
            this.Hide();
        }

        private void sataButton6_Click(object sender, EventArgs e)
        {
            FrmNotifications notifications = new FrmNotifications();
            notifications.Show();
            this.Hide();
        }

        private void sataButton5_Click(object sender, EventArgs e)
        {
            FrmActivityLogs activityLogs = new FrmActivityLogs();
            activityLogs.Show();
            this.Hide();
        }

        private void sataButton4_Click(object sender, EventArgs e)
        {
            FrmReportsAnalytics reportsAnalytics = new FrmReportsAnalytics();
            reportsAnalytics.Show();
            this.Hide();
        }

        private void sataButton3_Click(object sender, EventArgs e)
        {
            FrmPayrollProcessing payrollProcessing = new FrmPayrollProcessing();
            payrollProcessing.Show();
            this.Hide();
        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            // Already on dashboard
        }

        private void sataButton7_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        // Keep all other event handlers
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void sataPanel1_Paint(object sender, PaintEventArgs e) { }
        private void sataPanel2_Paint(object sender, PaintEventArgs e) { }
        private void sataPanel3_Paint(object sender, PaintEventArgs e) { }
        private void sataPanel4_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e) { }
    }
}