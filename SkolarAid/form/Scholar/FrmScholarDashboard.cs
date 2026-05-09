using System;
using System.Windows.Forms;

namespace SkolarAid.form.Scholar
{
    public partial class FrmScholarDashboard : Form
    {
        private int _scholarId;
        private string _scholarName;
        private string _scholarNumber;

        // Constructor that accepts parameters
        public FrmScholarDashboard(int scholarId, string scholarName, string scholarNumber)
        {
            InitializeComponent();
            _scholarId = scholarId;
            _scholarName = scholarName;
            _scholarNumber = scholarNumber;
        }

        private void FrmScholarDashboard_Load(object sender, EventArgs e)
        {
            // Display scholar info
            lblWelcome.Text = $"Welcome back, {_scholarName}!";
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}