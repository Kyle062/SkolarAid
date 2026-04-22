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
using SkolarAid.form.Admin;

namespace SkolarAid
{
    public partial class FrmPayrollProcessing : Form
    {
        public FrmPayrollProcessing()
        {
            InitializeComponent();
        }

        private void FrmPayrollProcessing_Load(object sender, EventArgs e)
        {

        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            FrmAdminDashboard frmAdminDashboard = new FrmAdminDashboard();
            frmAdminDashboard.Show();
            this.Hide();
        }

        private void sataButton2_Click(object sender, EventArgs e)
        {
            FrmScholarManagement frmScholarManagement = new FrmScholarManagement();
            frmScholarManagement.Show();
            this.Hide();
        }

        private void sataButton3_Click(object sender, EventArgs e)
        {

        }

        private void sataButton4_Click(object sender, EventArgs e)
        {
            FrmReportsAnalytics frmReportsAnalytics = new FrmReportsAnalytics();
            frmReportsAnalytics.Show();
            this.Hide();
        }

        private void sataButton5_Click(object sender, EventArgs e)
        {
            FrmActivityLogs frmActivityLogs = new FrmActivityLogs();
            frmActivityLogs.Show();
            this.Hide();
        }

        private void sataButton6_Click(object sender, EventArgs e)
        {
            FrmNotifications frmNotifications = new FrmNotifications();
            frmNotifications.Show();
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

        private void FrmPayrollProcessing_Load_1(object sender, EventArgs e)
        {

        }
    }
}
