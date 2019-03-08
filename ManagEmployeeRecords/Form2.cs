using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ManagEmployeeRecords
{
    public partial class Form2 : Form
    {
        private string connectionString;
        private SqlConnection connection;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["ManagEmployeeRecords.Properties.Settings.EmployeeRecordsConnectionString"].ConnectionString;
        }

        private void PopulateEmployeeRecords()
        {
            using (connection = new SqlConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees", connection))
            {
                connection.Open();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
