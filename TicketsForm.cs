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
    public partial class TicketsForm : Form
    {
        private string connectionString = "Server=DESKTOP-E9IP40M\\MSSQLSERVER01;Database=ISP_Management;Integrated Security=True;TrustServerCertificate=True;";
        LoadingData loadingData = new LoadingData();

        public TicketsForm()
        {
            InitializeComponent();
            loadingData.LoadSupportTickets(dataGridView1);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ticketId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ticket_id"].Value);

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("CloseSupportTicket", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ticket_id", ticketId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Ticket closed successfully!");

                        loadingData.LoadSupportTickets(dataGridView1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a ticket to close.");
            }
        }

    }
}
