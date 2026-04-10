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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = true;
        }

        private void sataPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void sataTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Create an instance of the Register form
            Register registerForm = new Register();

            // Show the Register form
            registerForm.Show();

            // Hide the current Login form
            this.Hide();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // Change .Text to .Texts
            string user = txtStudentID.Texts.Trim();
            string pass = txtPassword.Texts.Trim();

            if (user == "admin" && pass == "admin123")
            {
                Dashboard dashboardForm = new Dashboard();
                dashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Student ID or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
        