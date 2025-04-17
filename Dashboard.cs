using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;


namespace ISP_Manager
{
    public partial class Dashboard : Form
    {
        private string connectionString = "Server=DESKTOP-E9IP40M\\MSSQLSERVER01;Database=ISP_Management;Integrated Security=True;TrustServerCertificate=True;";
        public GMapControl gomap = new GMapControl();

        public Dashboard()
        {
            InitializeComponent();
            displayTotalEmployees();
            displayTotalCustomers();
            displayTotalEquipments();
            displayTotalIncome();
            InitializeMap();
        }

        private void InitializeMap()
        {
            gomap.Dock = DockStyle.Fill;
            gmap.Controls.Add(gomap);  

            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gomap.MapProvider = GMapProviders.GoogleMap; // or OpenStreetMap
            gomap.Position = new PointLatLng(0, 0); // Center of map (can update later)
            gomap.MinZoom = 2;
            gomap.MaxZoom = 18;
            gomap.Zoom = 5;
            gomap.ShowCenter = false;
        }


        public void displayTotalEmployees()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(employee_id) FROM Employees WHERE status = @status";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", "Active");

                        object result = cmd.ExecuteScalar();
                        int count = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                        label5.Text = count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void displayTotalCustomers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(customer_id) FROM Customers";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        int count = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                        label6.Text = count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void displayTotalEquipments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(equipment_id) FROM Equipment WHERE status = @status";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", "Returned");

                        object result = cmd.ExecuteScalar();
                        int count = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                        label7.Text = count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void displayTotalIncome()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT SUM(amount_paid) FROM Payments";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal total = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                        label8.Text = "$" + total.ToString("0.00");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
