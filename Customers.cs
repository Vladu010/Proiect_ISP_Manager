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

        private void processPayBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row first.");
                return;
            }


            int billId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["bill_id"].Value);
            decimal amountDue = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["amount_due"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();


                SqlCommand checkCmd = new SqlCommand("SELECT status FROM Billing WHERE bill_id = @bill_id", conn);
                checkCmd.Parameters.AddWithValue("@bill_id", billId);

                string status = checkCmd.ExecuteScalar()?.ToString();

                if (status == "Paid")
                {
                    MessageBox.Show("This bill has already been paid.");
                    return;
                }

                SqlCommand payCmd = new SqlCommand("ProcessPayment", conn);
                payCmd.CommandType = CommandType.StoredProcedure;
                payCmd.Parameters.AddWithValue("@bill_id", billId);
                payCmd.Parameters.AddWithValue("@amount_paid", amountDue);
                payCmd.Parameters.AddWithValue("@payment_method", "Credit Card");

                try
                {
                    payCmd.ExecuteNonQuery();
                    MessageBox.Show("Payment processed successfully!");

                    loadingData.LoadBilling(dataGridView1);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Payment failed: " + ex.Message);
                }
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dataTable && dataTable.TableName == "Customers")
            {
                return;
            }

            DataTable customersTable = new DataTable("Customers");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT customer_id, first_name, last_name, email, phone, address, signup_date, status FROM Customers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(customersTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading customers: " + ex.Message);
                    return;
                }
            }

            dataGridView1.DataSource = customersTable;
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Customer add_Customer = new Add_Customer();
            add_Customer.TopLevel = false;
            add_Customer.FormBorderStyle = FormBorderStyle.None;
            add_Customer.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(add_Customer);
            add_Customer.Show();
          //  loadingData.LoadCustomers(dataGridView1);
        }

        private void suspendToolStripMenuItem_Click(object sender, EventArgs e)
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
            LoadCustomers();
        }

        private void historyUsageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            loadingData.LoadUsage(dataGridView1);

        }

        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            loadingData.LoadBilling(dataGridView1);
            panel1.Controls.Add(processPayBtn);
            processPayBtn.Visible = true;
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            loadingData.LoadPayments(dataGridView1);
        }

        private void subscriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            loadingData.LoadSubscriptions(dataGridView1);
        }
    }
}
