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
    public partial class Add_Customer : Form
    {
        private string connectionString = "Server=DESKTOP-E9IP40M\\MSSQLSERVER01;Database=ISP_Management;Integrated Security=True;TrustServerCertificate=True;";

        public Add_Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (subBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a plan.");
                    return;
                }

                int newCustomerId;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("AddCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@first_name", nameBox.Text);
                    cmd.Parameters.AddWithValue("@last_name", lastBox.Text);
                    cmd.Parameters.AddWithValue("@email", emailBox.Text);
                    cmd.Parameters.AddWithValue("@phone", phoneBox.Text);
                    cmd.Parameters.AddWithValue("@address", addressBox.Text);
                    cmd.Parameters.AddWithValue("@signup_date", DateTime.Today);


                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        MessageBox.Show("Customer was not added successfully.");
                        return;
                    }

                    newCustomerId = Convert.ToInt32(result);


                    int selectedPlanId = subBox.SelectedIndex + 1; 

                    SqlCommand subscribeCmd = new SqlCommand("SubscribeCustomerToPlan", conn);
                    subscribeCmd.CommandType = CommandType.StoredProcedure;
                    subscribeCmd.Parameters.AddWithValue("@customer_id", newCustomerId);
                    subscribeCmd.Parameters.AddWithValue("@plan_id", selectedPlanId);
                    subscribeCmd.Parameters.AddWithValue("@start_date", DateTime.Today);
                    subscribeCmd.Parameters.AddWithValue("@end_date", DateTime.Today.AddMonths(1));
                    subscribeCmd.ExecuteNonQuery();

                    MessageBox.Show("Customer added and subscribed to plan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }            
    }
}
