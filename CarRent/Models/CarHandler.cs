using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CarRent.DataStructures;

namespace CarRent.Models
{
    class CarHandler : DbHandler
    {
        private void CheckErrors(Car car)
        {
            string errors = "";

            if (car.brand.Length <= 2)
            {
                errors += "You have to specify the brand of the car, it needs to be more than 2 characters \n";
            }
            if (car.type.Length < 3)
            {
                errors += "You have to specify the type of the car, it needs to be more than 2 characters \n";
            }
            if (car.productionYear < 2005)
            {
                errors += "The production year must not be correct, because all of our cars are newer than 2007. It is company policy \n";
            }
            if (car.seatCount < 2)
            {
                errors += "The minimum seats in the car have to be bigger than 1 \n";
            }
            if (car.fuelConsumption < 3)
            {
                errors += "Check the fuel consumption because it has to be larger than 3 liters. \n";
            }
            if (car.carShop.Length < 3)
            {
                errors += "you have to specify which dealership the car is located at \n";
            }
            if (car.price < 0)
            {
                errors += "A price of a car has to be bigger than zero. \n";
            }
            if (!Regex.IsMatch(car.licensePlate, @"[A-Z]{3,3}-[0-9]{3,3}"))
            {
                errors += "The license plate is misspelled, or either it is NOT hungarian. Please correct it accordingly. We do NOT lend foreign cars out. \n";
            }
            if (errors.Length > 0)
            {
                throw new ArgumentException(errors);
            }
        }
        
        public void SetCarWithCheck(Car car)
        {
            CheckErrors(car);
            SetCar(car);
        }

        public void UpdateCarWithCheck(Car car)
        {
            CheckErrors(car);
            UpdateCar(car);
        }
    }
}
