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
    public partial class FrmScholarManagement : Form
    {
        public FrmScholarManagement()
        {
            InitializeComponent();
        }

       

        private void sataButton1_Click(object sender, EventArgs e)
        {
            // Create an instance of the Login form
            FrmAdminDashboard dashboard = new FrmAdminDashboard();

            // Show the Login form
            dashboard.Show();

            // Hide or close the current Register form
            this.Hide();
        }

      

        private void sataButton1_Click_1(object sender, EventArgs e)
        {
            FrmAdminDashboard adminDashboard = new FrmAdminDashboard();
            adminDashboard.Show();
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
            FrmReportsAnalytics reportsAnalytics = new FrmReportsAnalytics();
            reportsAnalytics.Show();
            this.Hide();
        }

        private void sataButton5_Click(object sender, EventArgs e)
        {
            FrmActivityLogs activityLogs = new FrmActivityLogs();
            activityLogs.Show();
            this.Hide();
        }

        private void sataButton6_Click(object sender, EventArgs e)
        {
            FrmNotifications frmNotifications = new FrmNotifications();
            frmNotifications.Show();
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

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dgvScholars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelContent_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void btnScholarMgmt_Click(object sender, EventArgs e)
        {

        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {

        }
    }
}
