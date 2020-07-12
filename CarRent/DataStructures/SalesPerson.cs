using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DataStructures
{
    class SalesPerson
    {
        public int salesPersonID;
        public string firstName;
        public string lastName;
        public DateTime birthday;
        public string email;
        public string phone;
        public string Name
        {
            get
            {
                return this.ToString();
            }
            set
            {
                this.Name = value;
            }
        }
        public SalesPerson(int salesPersonID, string firstName, string lastName, DateTime birthday, string email, string phone)
        {
            this.salesPersonID = salesPersonID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.email = email;
            this.phone = phone;
        }

        public SalesPerson(string firstName, string lastName, DateTime birthday, string email, string phone)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.email = email;
            this.phone = phone;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} {email}";
        }
    }
}
