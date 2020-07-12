using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DataStructures
{
    class RentedCar
    {
        public int rentedCarID;
        public Car car;
        public Deal deal;
        public DateTime startDate;
        public DateTime endDate;
        public bool IsInsured;

        public RentedCar(int rentedCarID, Car car, Deal deal, DateTime startDate, DateTime endDate, bool IsInsured)
        {
            this.rentedCarID = rentedCarID;
            this.car = car;
            this.deal = deal;
            this.startDate = startDate;
            this.endDate = endDate;
            this.IsInsured = IsInsured;
        }

        public RentedCar(Car car, Deal deal, DateTime startDate, DateTime endDate, bool IsInsured)
        {
            this.car = car;
            this.deal = deal;
            this.startDate = startDate;
            this.endDate = endDate;
            this.IsInsured = IsInsured;
        }
    }
}
