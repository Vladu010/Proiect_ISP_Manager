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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddCustomer", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@first_name", nameBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@last_name", lastBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@email", emailBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@phone", phoneBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@address", addressBox.Text.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer added successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
