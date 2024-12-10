using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;
using System.Data;
using ITS245Project.Data;
using FinalProjectV2;


namespace ITS245Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormClosed += LoginForm_FormClosed; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool isAuthenticated = LoginFormData.AuthenticateUser(userName, password);

                if (isAuthenticated)
                {
                    GlobalData.UserName = userName;
                    SelectionForm mainForm = new SelectionForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password or user is already logged in.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(GlobalData.UserName))
                {
                    MessageBox.Show("Logging out user...", "Debug", MessageBoxButtons.OK); // Debug message
                    LoginFormData.LogoutUser(GlobalData.UserName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging out user: {ex.Message}", "Logout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
