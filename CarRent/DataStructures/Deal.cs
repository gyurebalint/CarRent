using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DataStructures
{
    class Deal
    {
        public int dealID;
        public DateTime created;
        public Customer customer;
        public SalesPerson salesPerson;

        public Deal(int dealID, Customer customer, SalesPerson salesPerson, DateTime created)
        {
            this.dealID = dealID;
            this.customer = customer;
            this.salesPerson = salesPerson;
            this.created = created;
        }

        public Deal(Customer customer, SalesPerson salesPerson)
        {
            this.customer = customer;
            this.salesPerson = salesPerson;
        }

        public override string ToString()
        {
            return $"{customer} {salesPerson} {created}";
        }
    }
}