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
            Customers custom = new Customers() { TopLevel = false, TopMost = true };
            custom.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(custom);
            custom.Show();
            
        }
     

        private void empBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
