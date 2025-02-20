namespace ISP_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, World!");
            //Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Close();
            MessageBox.Show("Goodbye, World!");
        }
    }
}
