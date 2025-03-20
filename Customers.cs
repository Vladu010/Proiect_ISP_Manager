using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using Microsoft.Data.SqlClient; 
using System.Windows.Forms;
namespace ISP_Manager
{
    public partial class Customers : Form
    {
        private string connectionString = "Server=DESKTOP-E9IP40M\\MSSQLSERVER01;Database=ISP_Management;Integrated Security=True;TrustServerCertificate=True;";

        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT customer_id, first_name, last_name, email, phone, address, signup_date, status FROM Customers";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public Customers()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            Add_Customer add_Customer = new Add_Customer();
            add_Customer.Show();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }
    }
}
