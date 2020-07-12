using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CarRent.DataStructures;

namespace CarRent.Models
{
    class CustomerHandler : DbHandler
    {

        private void CheckErrors(Customer customer)
        {
            string errors = "";
            if (customer.surName.Length <= 3)
            {
                errors += "The surname has to be more than 3 character. \n";
            }
            if (customer.firstName.Length <= 3)
            {
                errors += "The firstname has to be more than 3 character. \n";
            }
            if (customer.sex.Length < 1)
            {
                errors += "The sex needs to be one or more characters \n";
            }
            if (18 > DateTime.Now.Year - customer.birth.Year)
            {
                errors += "You have to be 18 years old to have a driving license \n";
            }
            if (customer.driverLicenseDate.Year - customer.birth.Year <= 1)
            {
                errors += "You need to have a license that is at least one year old \n";
            }
            if (!Regex.IsMatch(customer.driverLicenseNumber, @"[A-Z]{2,2}[0-9]{7,7}"))
            {
                errors += "The license plate is either misspelled or in a wrong format. \n";
            }
            if (!Regex.IsMatch(customer.IDNumber, @"[0-9{6,6}][A-Z]{2,2}"))
            {
                errors += "The ID number is misspelled or not hungarian. \n";
            }
            if (customer.address.Length <= 10)
            {
                errors += "The address needs to be more than 10 character. \n";
            }

            if (errors.Length > 0)
            {
                throw new ArgumentException(errors);
            }
        }

        public void SetCustomerWithCheck(Customer customer)
        {
            CheckErrors(customer);
            this.SetCustomer(customer);
        }

    }
}
