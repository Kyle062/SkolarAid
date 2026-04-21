using SkolarAid.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkolarAid
{
    public partial class FrmReportsAnalytics : Form
    {
        public FrmReportsAnalytics()
        {
            InitializeComponent();
        }

        private void FrmReports_Load(object sender, EventArgs e)
        {

        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            FrmAdminDashboard frmAdminDashboard = new FrmAdminDashboard();
            frmAdminDashboard.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sataButton3_Click(object sender, EventArgs e)
        {
            FrmPayrollProcessing payrollProcessing = new FrmPayrollProcessing();
            payrollProcessing.Show();

            this.Hide();
        }

        private void sataButton2_Click(object sender, EventArgs e)
        {
            // Create an instance of the Login form
            FrmScholarManagement scholar = new FrmScholarManagement();

            // Show the Login form
            scholar.Show();

            // Hide or close the current Register form
            this.Hide();
        }

        private void ScholarAid_Click(object sender, EventArgs e)
        {

        }

        private void sataButton4_Click(object sender, EventArgs e)
        {

        }

        private void sataButton5_Click(object sender, EventArgs e)
        {
            FrmActivityLogs activityLogs = new FrmActivityLogs();
            activityLogs.Show();
            this.Hide();
        }

        private void sataButton6_Click(object sender, EventArgs e)
        {
            FrmNotifications notifications = new FrmNotifications();
            notifications.Show();
            this.Hide();
        }

        private void sataButtonLogout_Click(object sender, EventArgs e)
        {
            // Create an instance of the Login form
            Login loginForm = new Login();

            // Show the Login form
            loginForm.Show();

            // Hide or close the current Register form
            this.Hide();
        }
    }
}
