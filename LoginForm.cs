using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISP_Manager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void forgotBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Username: admin " + "Password: admin");
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            passwordBox.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        public bool emptyFields()
        {
            if (usernameBox.Text == "" || passwordBox.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("All fields are required to be filled.", "Error Message", MessageBoxButtons.OK);
            }
            else
            {
                if (usernameBox.Text == "admin" && passwordBox.Text == "admin")
                {
                    this.Hide();
                    Form1 form = new Form1();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error Message", MessageBoxButtons.OK);
                }
            }
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn.PerformClick();
                e.Handled = true; 
                e.SuppressKeyPress = true;
            }
        }

    }
}
