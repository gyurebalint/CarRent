using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.DataStructures
{
    public class Car
    {
        public int carID;
        public string brand;
        public string type;
        public int productionYear;
        public int seatCount;
        public float fuelConsumption;
        public string carShop;
        public double price;
        public string licensePlate;

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
        
        public Car(string brand, string type, int productionYear, int seatCount, float fuelConsumption, string carShop, double price, string licensePlate)
        {
            this.brand = brand;
            this.type = type;
            this.productionYear = productionYear;
            this.seatCount = seatCount;
            this.fuelConsumption = fuelConsumption;
            this.carShop = carShop;
            this.price = price;
            this.licensePlate = licensePlate;
        }
        public Car(int carID, string brand, string type, int productionYear, int seatCount, float fuelConsumption, string carShop, double price, string licensePlate)
        {
            this.carID = carID;
            this.brand = brand;
            this.type = type;
            this.productionYear = productionYear;
            this.seatCount = seatCount;
            this.fuelConsumption = fuelConsumption;
            this.carShop = carShop;
            this.price = price;
            this.licensePlate = licensePlate;
        }

        public override string ToString()
        {
            return $"{brand} {type} {productionYear} {price} {carID}$";
        }
    }
}
