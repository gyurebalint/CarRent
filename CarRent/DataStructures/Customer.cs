using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DataStructures
{
    public class Customer
    {
        public int customerID;
        public string surName;
        public string firstName;
        public string sex;
        public DateTime birth;
        public DateTime driverLicenseDate;
        public string driverLicenseNumber;
        public string IDNumber;
        public string address;

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
        public Customer(int customerID, string SurName, string FirstName, string Sex, DateTime birth, DateTime driverLicenseDate, string driverLicenseNumber, string IDNumber, string address)
        {
            this.customerID = customerID;
            this.surName = SurName;
            this.firstName = FirstName;
            this.sex = Sex;
            this.birth = birth;
            this.driverLicenseDate = driverLicenseDate;
            this.driverLicenseNumber = driverLicenseNumber;
            this.IDNumber = IDNumber;
            this.address = address;
        }
        public Customer(string SurName, string FirstName, string Sex, DateTime birth, DateTime driverLicenseDate, string driverLicenseNumber, string IDNumber, string address)
        {
            this.surName = SurName;
            this.firstName = FirstName;
            this.sex = Sex;
            this.birth = birth;
            this.driverLicenseDate = driverLicenseDate;
            this.driverLicenseNumber = driverLicenseNumber;
            this.IDNumber = IDNumber;
            this.address = address;
        }
        public override string ToString()
        {
            return $"{firstName} {surName} {birth.Year} {IDNumber} {customerID}";
        }
    }
}