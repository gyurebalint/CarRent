using CarRent.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Models
{
    class RentedCarHandler : DbHandler
    {
        public void CheckErrors(RentedCar rentedCar)
        {
            string errors = "";

            if (rentedCar.startDate < DateTime.Now)
            {
                errors += "The start date cannot is in the past, please revise your input data regarding this rented car. \n";
            }
            if (rentedCar.endDate.Month - DateTime.Now.Month > 18)
            {
                errors += "The car is rented for more than 18 months. It is customer policy we don't give out cars for more than 18 months.\n";
            }
            if (this.IsCarAlreadyRented(rentedCar))
            {
                errors += "The car you chose is already rented for that day.";
            }
            if (errors.Length > 0)
            {
                throw new ArgumentException(errors);
            }
        }
        public void SetRentedCarWithCheck(RentedCar rentedCar)
        {
            CheckErrors(rentedCar);
            this.SetRentedCar(rentedCar);
        }
        public void UpdateRentedCarWithCheck(RentedCar rentedCar)
        {
            CheckErrors(rentedCar);
            this.UpdateRentedCar(rentedCar);
        }
    }
}
