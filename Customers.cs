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
using System.Xml.Serialization;

namespace ISP_Manager
{
    public partial class Customers : Form
    {
        private string connectionString = "Server=DESKTOP-E9IP40M\\MSSQLSERVER01;Database=ISP_Management;Integrated Security=True;TrustServerCertificate=True;";
        LoadingData loadingData = new LoadingData();
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

    

private void button3_Click(object sender, EventArgs e)
        {
            Add_Customer add_Customer = new Add_Customer();
            add_Customer.TopLevel = false;
            add_Customer.FormBorderStyle = FormBorderStyle.None; 
            add_Customer.Dock = DockStyle.Fill; 
            panel1.Controls.Clear();
            panel1.Controls.Add(add_Customer);
            add_Customer.Show();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void usageBtn_Click(object sender, EventArgs e)
        {
            loadingData.LoadUsage(dataGridView1);
        }

        private void suspendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Customers SET status = 'Suspended' WHERE customer_id = @customer_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customer_id", dataGridView1.SelectedRows[0].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer suspended successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void paymentBtn_Click(object sender, EventArgs e)
        {
            loadingData.LoadPayments(dataGridView1);

        }

        private void billingBtn_Click(object sender, EventArgs e)
        {
            loadingData.LoadBilling(dataGridView1);

        }
    }
}
