using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISP_Manager
{
    public partial class BusinessForm : Form
    {
        LoadingData loadingData = new LoadingData();
        public BusinessForm()
        {
            InitializeComponent();
        }

        private void empBtn_Click(object sender, EventArgs e)
        {
            loadingData.LoadEmployees(dataGridView1);
        }

        private void equipBtn_Click(object sender, EventArgs e)
        {
            loadingData.LoadEquipment(dataGridView1);
        }

        private void plansBtn_Click(object sender, EventArgs e)
        {
            loadingData.LoadPlans(dataGridView1);
        }
    }
}
