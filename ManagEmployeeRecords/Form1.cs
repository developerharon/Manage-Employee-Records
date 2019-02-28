using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagEmployeeRecords
{
    public partial class Form1 : Form
    {
        List<Employee> employees = new List<Employee>(); 
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsAllTextboxFilled()
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtContact.Text == "" || txtEmail.Text == "")
            {
                return false;
            }

            return true;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee newEmployee = new Employee();

            if (IsAllTextboxFilled() != true)
            {
                MessageBox.Show("Fill all the employee details." + MessageBoxButtons.OK + MessageBoxIcon.Information);
            }

            newEmployee.FirstName = txtFirstName.Text;
            newEmployee.LastName = txtLastName.Text;
            newEmployee.DateOfBirth = dateOfBirthPicker.Value;
            newEmployee.Email = txtEmail.Text;
            newEmployee.Contact = txtContact.Text;

            txtEmployeeId.Text = Employee.NextID().ToString();
            newEmployee.ID = int.Parse(txtEmployeeId.Text);
            employees.Add(newEmployee);

            MessageBox.Show("New employee added successfully" + MessageBoxButtons.OK + MessageBoxIcon.Information);
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
