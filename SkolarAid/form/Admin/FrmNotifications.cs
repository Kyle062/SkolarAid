using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkolarAid.form.Admin;

namespace SkolarAid.form
{
    public partial class FrmNotifications : Form
    {
        public FrmNotifications()
        {
            InitializeComponent();
        }

        private void FrmNotifications_Load(object sender, EventArgs e)
        {

        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            FrmAdminDashboard frmAdminDashboard = new FrmAdminDashboard();
            frmAdminDashboard.Show();
            this.Hide();
        }

        private void sataButton2_Click_1(object sender, EventArgs e)
        {
            // Create an instance of the Login form
            FrmScholarManagement scholar = new FrmScholarManagement();

            // Show the Login form
            scholar.Show();

            // Hide or close the current Register form
            this.Hide();
        }

        private void sataButton3_Click(object sender, EventArgs e)
        {
            FrmPayrollProcessing payrollProcessing = new FrmPayrollProcessing();
            payrollProcessing.Show();

            this.Hide();
        }

        private void sataButton4_Click(object sender, EventArgs e)
        {
            FrmPayrollProcessing payrollProcessing = new FrmPayrollProcessing();
            payrollProcessing.Show();

            this.Hide();
        }

        private void btnActivityLog_Click(object sender, EventArgs e)
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

        private void sataButton1_Click_1(object sender, EventArgs e)
        {
            FrmAdminDashboard frmAdminDashboard = new FrmAdminDashboard();
            frmAdminDashboard.Show();
            this.Hide();
        }

        private void sataButton2_Click_2(object sender, EventArgs e)
        {
            // Create an instance of the Login form
            FrmScholarManagement scholar = new FrmScholarManagement();

            // Show the Login form
            scholar.Show();

            // Hide or close the current Register form
            this.Hide();
        }

        private void sataButton3_Click_1(object sender, EventArgs e)
        {
            FrmPayrollProcessing payrollProcessing = new FrmPayrollProcessing();
            payrollProcessing.Show();

            this.Hide();
        }

        private void sataButton4_Click_1(object sender, EventArgs e)
        {
            FrmReportsAnalytics reportsAnalytics = new FrmReportsAnalytics();
            reportsAnalytics.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
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
