using System;
using System.Data;
using Microsoft.Data.SqlClient;  // Use this instead of System.Data.SqlClient
using System.Windows.Forms;

namespace ISP_Manager
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=DESKTOP-E9IP40M\\MSSQLSERVER01;Database=ISP_Management;Integrated Security=True;TrustServerCertificate=True;";
        /// <summary>
        /// ///////////////////--------Change server name and database name as per your SQL Server configuration--------///////////////////////
        /// </summary>
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
        public Form1()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, World!");
            //Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
