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

        private void sataButton7_Click(object sender, EventArgs e)
        {

        }
    }
}
