using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ManagEmployeeRecords
{
    public partial class Form1 : Form
    {
        string connectionString;
        SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["ManagEmployeeRecords.Properties.Settings.EmployeeRecordsConnectionString"].ConnectionString;
        }

        private bool IsAllTextboxFilled()
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtContact.Text == "" || txtEmail.Text == "")
            {
                return false;
            }

            return true;
        }

        private string GetEmployeeID()
        {
            string query = "SELECT EmployeeID FROM Employee WHERE Contact = " + txtContact.Text;

            using (connection = new SqlConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                return adapter.ToString();
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (IsAllTextboxFilled() != true)
            {
                MessageBox.Show("Fill all the employee details", "Some Details Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string query = "INSERT INTO Employee VALUES(@FirstName, @LastName, @DateOfBirth, @Email, @Contact)";

                using (connection = new SqlConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirthPicker.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Contact", txtContact.Text);
                    command.ExecuteNonQuery();
                }

                txtEmployeeId.Text = GetEmployeeID();

                MessageBox.Show("New employee added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtEmployeeId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            dateOfBirthPicker.ResetText();
            txtEmail.Clear();
            txtContact.Clear();
        }
    }
}
