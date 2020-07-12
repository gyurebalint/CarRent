using CarRent.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRent.Models
{
    class SalesPersonHandler : DbHandler
    {
        public void CheckErrors(SalesPerson salesPerson)
        {
            string errors = "";

            if (salesPerson.firstName.Length < 3)
            {
                errors += "The first name has to be longer than three characters. \n";
            }
            if (salesPerson.lastName.Length < 3)
            {
                errors += "The last name has to be longer than three characters. \n";
            }
            if (salesPerson.birthday.Year < 18)
            {
                errors += "The sales person has to be older than 18 years old. \n";
            }
            //if (!Regex.IsMatch()
            //{

            //}
            //if (salesPerson.phone)
            //{

            //}
            if (errors.Length > 0)
            {
                throw new ArgumentException(errors);
            }
        }
        public void SetSalesPersonWithCheck(SalesPerson salesPerson)
        {
            CheckErrors(salesPerson);
            SetSalesPerson(salesPerson);
        }
        public void UpdateSalesPersonWithCheck(SalesPerson salesPerson)
        {
            CheckErrors(salesPerson);
            UpdateSalesPerson(salesPerson);
        }

    }
}
