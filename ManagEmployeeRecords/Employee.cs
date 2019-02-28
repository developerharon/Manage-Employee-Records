using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagEmployeeRecords
{
    class Employee
    {
        private static int id = 0;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string email;
        private string contact;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set { this.dateOfBirth = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Contact
        {
            get { return this.contact; }
            set { this.contact = value; }
        }

        public static int NextID()
        {
            return ++id;
        }
    }
}
