using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace ISP_Manager
{

    public partial class BusinessForm : Form
    {
        private string connectionString = "Server=DESKTOP-E9IP40M\\MSSQLSERVER01;Database=ISP_Management;Integrated Security=True;TrustServerCertificate=True;";
        LoadingData loadingData = new LoadingData();
        public BusinessForm()
        {
            InitializeComponent();
        }

        private void empBtn_Click(object sender, EventArgs e)
        {
            assignBtn.Hide();
            returnedBtn.Hide();
            loadingData.LoadEmployees(dataGridView1);
            activeBtn.Show();
            disableBtn.Show();
        }

        private void equipBtn_Click(object sender, EventArgs e)
        {
            activeBtn.Hide();
            disableBtn.Hide();
            loadingData.LoadEquipment(dataGridView1);
            assignBtn.Show();
            returnedBtn.Show();
        }

        private void plansBtn_Click(object sender, EventArgs e)
        {
            assignBtn.Hide();
            returnedBtn.Hide();
            activeBtn.Hide();
            disableBtn.Hide();
            loadingData.LoadPlans(dataGridView1);
        }

        private void activeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Employees SET status = 'Active' WHERE employee_id = @employee_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@employee_id", dataGridView1.SelectedRows[0].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee set to active successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            empBtn_Click(sender, e);


        }

        private void disableBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Employees SET status = 'Inactive' WHERE employee_id = @employee_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@employee_id", dataGridView1.SelectedRows[0].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee set to inactive successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            empBtn_Click(sender, e); 


        }

        private void returnedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Equipment SET status = 'Returned', return_date = GETDATE() WHERE equipment_id = @equipment_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@equipment_id", dataGridView1.SelectedRows[0].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Equipment returned successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            equipBtn_Click(sender, e); 


        }

        private void assignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Equipment SET status = 'Assigned', return_date = NULL, assigned_date = GETDATE()  WHERE equipment_id = @equipment_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@equipment_id", dataGridView1.SelectedRows[0].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Equipment assigned successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            equipBtn_Click(sender, e);
        }
    }
}
