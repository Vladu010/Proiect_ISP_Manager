using System;
using System.Data;
using Microsoft.Data.SqlClient; 
using System.Windows.Forms;

namespace ISP_Manager
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }



        private void Clients_Click(object sender, EventArgs e)
        {
            Customers custom = new Customers();
            custom.TopLevel = false;
            custom.FormBorderStyle = FormBorderStyle.None;
            custom.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(custom);
            custom.Show();

        }


        private void empBtn_Click(object sender, EventArgs e)
        {
            BusinessForm bus = new BusinessForm();
            bus.TopLevel = false;
            bus.FormBorderStyle = FormBorderStyle.None;
            bus.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(bus);
            bus.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            LoginForm login = new LoginForm();
            login.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.TopLevel = false;
            dash.FormBorderStyle = FormBorderStyle.None;
            dash.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(dash);
            dash.Show();
        }
    }
}
