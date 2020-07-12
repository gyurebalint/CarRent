using CarRent.DataStructures;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Models
{
    class DbHandler
    {
        #region DataBase Connection
        private MySqlConnection conn;
        private MySqlConnectionStringBuilder connStr;

        public DbHandler()
        {
            connStr = new MySqlConnectionStringBuilder();
            connStr.Server = "127.0.0.1";
            connStr.UserID = "root";
            connStr.Password = "";
            connStr.Database = "carrent";

            try
            {
                conn = new MySqlConnection(connStr.ConnectionString);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                DateTime now = DateTime.Now;
                string errorLog = $"hiba: {ex.Message} \n";
                errorLog += $"time of error: {now.ToString("yyyy-mm-dd hh:mm:ss")} \n";
                File.AppendAllText("mysql_error.log", errorLog);
            }
        }
        #endregion

        #region Cars
        protected void SetCar(Car car)
        {
            string sql = "INSERT INTO cars(Brand, Type, ProductionYear, SeatCount, FuelConsumption, CarShop, Price, LicensePlate)" +
                "VALUES(@Brand, @Type, @ProductionYear, @SeatCount, @FuelConsumption, @CarShop, @Price, @LicensePlate)";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Brand", car.brand);
                cmd.Parameters.AddWithValue("@Type", car.type);
                cmd.Parameters.AddWithValue("@ProductionYear", car.productionYear);
                cmd.Parameters.AddWithValue("@SeatCount", car.seatCount);
                cmd.Parameters.AddWithValue("@FuelConsumption", car.fuelConsumption);
                cmd.Parameters.AddWithValue("@CarShop", car.carShop);
                cmd.Parameters.AddWithValue("@Price", car.price);
                cmd.Parameters.AddWithValue("@LicensePlate", car.licensePlate);

                cmd.ExecuteNonQuery();
            }
        }
        public List<Car> GetCarList()
        {
            string sql = "SELECT * FROM cars";
            List<Car> cars = new List<Car>();

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int carID = Convert.ToInt32(reader["CarID"]);
                        string brand = reader["Brand"].ToString();
                        string type = reader["Type"].ToString();
                        int productionYear = Convert.ToInt32(reader["ProductionYear"]);
                        int seatCount = Convert.ToInt32(reader["SeatCount"]);
                        float fuelConsumption = (float)Convert.ToDouble(reader["FuelConsumption"]);
                        string carShop = reader["CarShop"].ToString();
                        double price = Convert.ToDouble(reader["Price"]);
                        string licensePlate = reader["LicensePlate"].ToString();

                        Car car = new Car(carID, brand, type, productionYear, seatCount, fuelConsumption, carShop, price, licensePlate);
                        cars.Add(car);
                    }
                }
            }
            return cars;
        }

        public void DeleteCar(int carID)
        {
            string sql = "DELETE FROM cars WHERE CarID = @CarID";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CarID", carID);
                cmd.ExecuteNonQuery();
            }
        }
        public Car GetCar(int carID)
        {
            Car car = new Car(0, "", "", 0, 0, 0, "", 0, "");
            string sql = "SELECT * FROM cars WHERE CarID = @CarID";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CarID", carID);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["CarID"]);
                        string brand = reader["Brand"].ToString();
                        string type = reader["Type"].ToString();
                        int productionYear = Convert.ToInt32(reader["ProductionYear"]);
                        int seatCount = Convert.ToInt32(reader["SeatCount"]);
                        float fuelConsumption = (float)Convert.ToDouble(reader["FuelConsumption"]);
                        string carShop = reader["CarShop"].ToString();
                        double price = Convert.ToDouble(reader["Price"]);
                        string licensePlate = reader["LicensePlate"].ToString();

                        car = new Car(ID, brand, type, productionYear, seatCount, fuelConsumption, carShop, price, licensePlate);
                    }
                }
            }
            return car;
        }
        public void UpdateCar(Car car)
        {
            string sql = "UPDATE cars " +
                "SET Brand = @Brand, " +
                "Type = @Type, " +
                "ProductionYear = @ProductionYear, " +
                "SeatCount = @SeatCount, " +
                "FuelConsumption = @FuelConsumption, " +
                "CarShop = @CarShop, " +
                "Price = @Price, " +
                "LicensePlate = @LicensePlate " +
                "WHERE CarID = @CarID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {

                cmd.Parameters.AddWithValue("Brand", car.brand);
                cmd.Parameters.AddWithValue("Type", car.type);
                cmd.Parameters.AddWithValue("ProductionYear", car.productionYear);
                cmd.Parameters.AddWithValue("SeatCount", car.seatCount);
                cmd.Parameters.AddWithValue("FuelConsumption", car.fuelConsumption);
                cmd.Parameters.AddWithValue("CarShop", car.carShop);
                cmd.Parameters.AddWithValue("Price", car.price);
                cmd.Parameters.AddWithValue("LicensePlate", car.licensePlate);
                cmd.Parameters.AddWithValue("CarID", car.carID);

                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Customers
        protected void SetCustomer(Customer customer)
        {
            string sql = "INSERT INTO customers(surName, firstName, sex, Birth, DriverLicenseDate, DriverLicenseNumber, IDNumber, Address) " +
                "VALUES(@surName, @firstName, @sex, @Birth, @DriverLicenseDate, @DriverLicenseNumber, @IDNumber, @Address)";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@surName", customer.surName);
                cmd.Parameters.AddWithValue("@firstName", customer.firstName);
                cmd.Parameters.AddWithValue("@sex", customer.sex);
                cmd.Parameters.AddWithValue("@Birth", customer.birth);
                cmd.Parameters.AddWithValue("@DriverLicenseDate", customer.driverLicenseDate);
                cmd.Parameters.AddWithValue("@DriverLicenseNumber", customer.driverLicenseNumber);
                cmd.Parameters.AddWithValue("@IDNumber", customer.IDNumber);
                cmd.Parameters.AddWithValue("@Address", customer.address);

                cmd.ExecuteNonQuery();
            }
        }
        public List<Customer> GetCustomerList()
        {
            List<Customer> customers = new List<Customer>();
            string sql = "SELECT * FROM customers";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int customerID = Convert.ToInt32(reader["CustomerID"]);
                        string surName = reader["surName"].ToString();
                        string firstName = reader["firstName"].ToString();
                        string sex = reader["sex"].ToString();
                        DateTime birth = (DateTime)reader["Birth"];
                        DateTime driveLicenseDate = (DateTime)reader["DriverLicensedate"];
                        string driverLicenseNumber = reader["DriverLicenseNumber"].ToString();
                        string idNumber = reader["IDNumber"].ToString();
                        string address = reader["Address"].ToString();

                        Customer customer = new Customer(customerID, surName, firstName, sex, birth, driveLicenseDate, driverLicenseNumber, idNumber, address);
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }
        public void DeleteCustomer(int customerID)
        {
            string sql = "DELETE FROM customers WHERE CustomerID = @CustomerID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.ExecuteNonQuery();
            }
        }
        public Customer GetCustomer(int customerID)
        {
            Customer customer = new Customer("", "", "", default, default, "", "", "");
            string sql = "SELECT * FROM customers WHERE CustomerID = @CustomerID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["CustomerID"]);
                        string surName = reader["SurName"].ToString();
                        string firstName = reader["FirstName"].ToString();
                        string sex = reader["Sex"].ToString();
                        DateTime birth = (DateTime)reader["Birth"];
                        DateTime driverLicenseDate = (DateTime)reader["DriverLicenseDate"];
                        string driverLicenseNumber = reader["DriverLicenseNumber"].ToString();
                        string idNumber = reader["IDNumber"].ToString();
                        string address = reader["Address"].ToString();

                        customer = new Customer(id, surName, firstName, sex, birth, driverLicenseDate, driverLicenseNumber, idNumber, address);
                    }
                }
            }


            return customer;
        }
        public void UpdateCustomer(Customer customer)
        {
            string sql = "UPDATE customers " +
                "SET SurName = @SurName, " +
                "FirstName = @FirstName, " +
                "Sex = @Sex, " +
                "Birth = @Birth, " +
                "DriverLicenseDate = @DriverLicenseDate, " +
                "DriverLicenseNumber = @DriverLicenseNumber, " +
                "IDNumber = @IDNumber, " +
                "Address = @Address " +
                "WHERE CustomerID = @CustomerID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("SurName", customer.surName);
                cmd.Parameters.AddWithValue("FirstName", customer.firstName);
                cmd.Parameters.AddWithValue("Sex", customer.sex);
                cmd.Parameters.AddWithValue("Birth", customer.birth);
                cmd.Parameters.AddWithValue("DriverLicenseDate", customer.driverLicenseDate);
                cmd.Parameters.AddWithValue("DriverLicenseNumber", customer.driverLicenseNumber);
                cmd.Parameters.AddWithValue("IDNumber", customer.IDNumber);
                cmd.Parameters.AddWithValue("Address", customer.address);

                cmd.Parameters.AddWithValue("CustomerID", customer.customerID);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region SalesPerson
        protected void SetSalesPerson(SalesPerson salesPerson)
        {
            string sql = "INSERT INTO salespersons(FirstName, LastName, Birthday, Email, Phone) " +
                "VALUES(@FirstName, @LastName, @Birthday, @Email, @Phone)";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", salesPerson.firstName);
                cmd.Parameters.AddWithValue("@LastName", salesPerson.lastName);
                cmd.Parameters.AddWithValue("@Birthday", salesPerson.birthday);
                cmd.Parameters.AddWithValue("@Email", salesPerson.email);
                cmd.Parameters.AddWithValue("@Phone", salesPerson.phone);
                cmd.ExecuteNonQuery();
            }
        }
        public List<SalesPerson> GetSalesPersonList()
        {
            List<SalesPerson> salespersons = new List<SalesPerson>();

            string sql = "SELECT * FROM salespersons";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int salesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                        string firstName = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        DateTime birthday = (DateTime)reader["Birthday"];
                        string email = reader["Email"].ToString();
                        string phone = reader["Phone"].ToString();

                        SalesPerson salesPerson = new SalesPerson(salesPersonID, firstName, lastName, birthday, email, phone);
                        salespersons.Add(salesPerson);
                    }
                }
            }
            return salespersons;
        }
        public void DeleteSalesPerson(int salesPersonID)
        {
            string sql = "DELETE FROM salespersons WHERE SalesPersonID = @SalesPersonID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@SalesPersonID", salesPersonID);
                cmd.ExecuteNonQuery();
            }
        }
        public SalesPerson GetSalesPerson(int salesPersonID)
        {
            SalesPerson salesPerson = new SalesPerson("", "", default, "", "");
            string sql = "SELECT * FROM salespersons WHERE SalesPersonID = @SalesPersonID";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@SalesPersonID", salesPersonID);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        DateTime birthday = (DateTime)reader["Birthday"];
                        string email = reader["Email"].ToString();
                        string phone = reader["Phone"].ToString();

                        salesPerson = new SalesPerson(firstName, lastName, birthday, email, phone);
                    }
                }
            }


            return salesPerson;
        }

        public void UpdateSalesPerson(SalesPerson salesPerson)
        {
            string sql = "UPDATE salespersons " +
                "SET FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "Birthday = @Birthday, " +
                "Email = @Email, " +
                "Phone = @Phone " +
                "WHERE SalesPersonID = SalesPersonID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", salesPerson.firstName);
                cmd.Parameters.AddWithValue("@LastName", salesPerson.lastName);
                cmd.Parameters.AddWithValue("@Birthday", salesPerson.birthday);
                cmd.Parameters.AddWithValue("@Email", salesPerson.email);
                cmd.Parameters.AddWithValue("@Phone", salesPerson.phone);
                cmd.ExecuteNonQuery();

            }

        }
        #endregion

        #region Deals
        protected void SetDeal(Deal deal)
        {
            string sql = "INSERT INTO deals(CustomerID, SalesPersonID) " +
                "VALUES(@CustomerID, @SalesPersonID)";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", deal.customer.customerID);
                cmd.Parameters.AddWithValue("@SalesPersonID", deal.salesPerson.salesPersonID);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDeal(int dealID)
        {
            string sql = "DELETE FROM deals WHERE DealID = @DealID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DealID", dealID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Deal> GetDealList()
        {
            List<Deal> deals = new List<Deal>();
            string sql = "SELECT deals.*, customers.*, salespersons.* " +
                "FROM deals " +
                "INNER JOIN customers " +
                    "ON deals.CustomerID = customers.CustomerID " +
                 "INNER JOIN salespersons " +
                    "ON deals.SalesPersonID = salespersons.SalesPersonID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int dealID = Convert.ToInt32(reader["DealID"]);
                        DateTime created = (DateTime)(reader["Created"]);

                        int customerID = Convert.ToInt32(reader["CustomerID"]);
                        string surName = reader["SurName"].ToString();
                        string firstName = reader["FirstName"].ToString();
                        string sex = reader["Sex"].ToString();
                        DateTime birth = (DateTime)reader["Birth"];
                        DateTime driverLicenseDate = (DateTime)reader["DriverLicenseDate"];
                        string driverLicenseNumber = reader["DriverLicenseNumber"].ToString();
                        string idNumber = reader["IDNumber"].ToString();

                        string address = reader["Address"].ToString();

                        Customer customer = new Customer(customerID, surName, firstName, sex, birth, driverLicenseDate, driverLicenseNumber, idNumber, address);

                        int salesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                        string firstNameSales = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        DateTime birthday = (DateTime)reader["Birthday"];
                        string email = reader["Email"].ToString();
                        string phone = reader["Phone"].ToString();

                        SalesPerson salesPerson = new SalesPerson(salesPersonID, firstNameSales, lastName, birthday, email, phone);

                        Deal deal = new Deal(dealID, customer, salesPerson, created);
                        deals.Add(deal);
                    }
                }
            }
            return deals;
        }

        public Deal GetDeal(int dealID)
        {
            Deal deal = new Deal(0, default, default, default);
            string sql = "SELECT deals.*, customers.*, salespersons.* " +
                "FROM deals " +
                "INNER JOIN customers " +
                    "ON deals.CustomerID = customers.CustomerID " +
                 "INNER JOIN salespersons " +
                    "ON deals.SalesPersonID = salespersons.SalesPersonID " +
                 "WHERE deals.DealID = @DealID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DealID", dealID);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int customerID = Convert.ToInt32(reader["CustomerID"]);
                        string surName = reader["SurName"].ToString();
                        string firstName = reader["FirstName"].ToString();
                        string sex = reader["Sex"].ToString();
                        DateTime birth = (DateTime)reader["Birth"];
                        DateTime driverLicenseDate = (DateTime)reader["DriverLicenseDate"];
                        string driverLicenseNumber = reader["DriverLicenseNumber"].ToString();
                        string idNumber = reader["IDNumber"].ToString();
                        string address = reader["Address"].ToString();

                        Customer customer = new Customer(customerID, surName, firstName, sex, birth, driverLicenseDate, driverLicenseNumber, idNumber, address);

                        int salesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                        string firstNameSales = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        DateTime birthday = (DateTime)reader["Birthday"];
                        string email = reader["Email"].ToString();
                        string phone = reader["Phone"].ToString();

                        SalesPerson salesPerson = new SalesPerson(salesPersonID, firstNameSales, lastName, birthday, email, phone);

                        int dealIDNew = Convert.ToInt32(reader["DealID"]);
                        DateTime created = (DateTime)(reader["Created"]);

                        deal = new Deal(dealIDNew, customer, salesPerson, created);
                    }
                }
            }
            return deal;
        }

        public void UpdateDeal(Deal deal)
        {
            string sql = "UPDATE deals " +
                "SET CustomerID = @CustomerID, " +
                "SalesPersonID = @SalesPersonID " +
                "WHERE DealID = @DealID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DealID", deal.dealID);

                cmd.Parameters.AddWithValue("@CustomerID", deal.customer.customerID);
                cmd.Parameters.AddWithValue("@SalesPersonID", deal.salesPerson.salesPersonID);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion


        #region RentedCar
        protected void SetRentedCar(RentedCar rentedCar)
        {
            string sql = "INSERT INTO rentedcars(CarID, DealID, StartDate, EndDate, IsInsured) " +
                "VALUES(@CarID, @DealID, @StartDate, @EndDate, @IsInsured)";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CarID", rentedCar.car.carID);
                cmd.Parameters.AddWithValue("@DealID", rentedCar.deal.dealID);
                cmd.Parameters.AddWithValue("@StartDate", rentedCar.startDate);
                cmd.Parameters.AddWithValue("@EndDate", rentedCar.endDate);
                cmd.Parameters.AddWithValue("@IsInsured", rentedCar.IsInsured);

                cmd.ExecuteNonQuery();
            }
        }
        public List<RentedCar> GetRentedCarList()
        {
            List<RentedCar> rentedCars = new List<RentedCar>();

            string sql = "SELECT rentedcars.*, cars.*, deals.*, customers.*, salespersons.* " +
                "FROM rentedcars " +
                "INNER JOIN cars " +
                    "ON cars.CarID = rentedcars.CarID " +
                 "INNER JOIN deals " +
                    "ON deals.DealID = rentedcars.DealID " +
                 "INNER JOIN customers " +
                     "ON customers.CustomerID = deals.CustomerID " +
                 "INNER JOIN salespersons " +
                      "ON salespersons.SalesPersonID = deals.SalesPersonID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        #region Arguments for the CAR object
                        int carID = Convert.ToInt32(reader["CarID"]);
                        string brand = reader["Brand"].ToString();
                        string type = reader["type"].ToString();
                        int productionYear = Convert.ToInt32(reader["ProductionYear"]);
                        int seatCount = Convert.ToInt32(reader["SeatCount"]);
                        float fuelConsumption = (float)reader["FuelConsumption"];
                        string carShop = reader["CarShop"].ToString();
                        float price = (float)reader["Price"];
                        string licensePlate = reader["LicensePlate"].ToString();

                        Car car = new Car(carID, brand, type, productionYear, seatCount, fuelConsumption, carShop, price, licensePlate);
                        #endregion

                        #region Arguments for the DEAL object
                        int dealID = Convert.ToInt32(reader["DealID"]);
                        DateTime created = (DateTime)(reader["Created"]);

                        int customerID = Convert.ToInt32(reader["CustomerID"]);
                        string surName = reader["SurName"].ToString();
                        string firstName = reader["FirstName"].ToString();
                        string sex = reader["Sex"].ToString();
                        DateTime birth = (DateTime)reader["Birth"];
                        DateTime driverLicenseDate = (DateTime)reader["DriverLicenseDate"];
                        string driverLicenseNumber = reader["DriverLicenseNumber"].ToString();
                        string idNumber = reader["IDNumber"].ToString();
                        string address = reader["Address"].ToString();

                        Customer customer = new Customer(customerID, surName, firstName, sex, birth, driverLicenseDate, driverLicenseNumber, idNumber, address);


                        #endregion

                        int rentedCarID = Convert.ToInt32(reader["RentedCarID"]);
                        DateTime startDate = (DateTime)reader["StartDate"];
                        DateTime endDate = (DateTime)reader["EndDate"];
                        bool isInsured = (bool)reader["IsInsured"];

                        int salesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                        string firstNameSales = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        DateTime birthday = (DateTime)reader["Birthday"];
                        string email = reader["Email"].ToString();
                        string phone = reader["Phone"].ToString();
                        SalesPerson salesPerson = new SalesPerson(salesPersonID, firstNameSales, lastName, birthday, email, phone);

                        Deal deal = new Deal(dealID, customer, salesPerson, created);

                        RentedCar rentedCar = new RentedCar(rentedCarID, car, deal, startDate, endDate, isInsured);

                        rentedCars.Add(rentedCar);
                    }
                }
            }

            return rentedCars;
        }

        public List<RentedCar> GetRentedCarListByDealID(int dealID)
        {
            List<RentedCar> rentedCars = new List<RentedCar>();

            string sql = "SELECT rentedcars.*, cars.*, deals.*, customers.*, salespersons.* " +
                "FROM rentedcars " +
                "INNER JOIN cars " +
                    "ON cars.CarID = rentedcars.CarID " +
                 "INNER JOIN deals " +
                    "ON deals.DealID = rentedcars.DealID " +
                 "INNER JOIN customers " +
                     "ON customers.CustomerID = deals.CustomerID " +
                 "INNER JOIN salespersons " +
                      "ON salespersons.SalesPersonID = deals.SalesPersonID " +
                 "WHERE rentedcars.DealID = @DealID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DealID", dealID);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        #region Arguments for the CAR object
                        int carID = Convert.ToInt32(reader["CarID"]);
                        string brand = reader["Brand"].ToString();
                        string type = reader["type"].ToString();
                        int productionYear = Convert.ToInt32(reader["ProductionYear"]);
                        int seatCount = Convert.ToInt32(reader["SeatCount"]);
                        float fuelConsumption = (float)reader["FuelConsumption"];
                        string carShop = reader["CarShop"].ToString();
                        float price = (float)reader["Price"];
                        string licensePlate = reader["LicensePlate"].ToString();

                        Car car = new Car(carID, brand, type, productionYear, seatCount, fuelConsumption, carShop, price, licensePlate);
                        #endregion

                        #region Arguments for the DEAL object
                        int ID = Convert.ToInt32(reader["DealID"]);
                        DateTime created = (DateTime)(reader["Created"]);

                        int customerID = Convert.ToInt32(reader["CustomerID"]);
                        string surName = reader["SurName"].ToString();
                        string firstName = reader["FirstName"].ToString();
                        string sex = reader["Sex"].ToString();
                        DateTime birth = (DateTime)reader["Birth"];
                        DateTime driverLicenseDate = (DateTime)reader["DriverLicenseDate"];
                        string driverLicenseNumber = reader["DriverLicenseNumber"].ToString();
                        string idNumber = reader["IDNumber"].ToString();
                        string address = reader["Address"].ToString();

                        Customer customer = new Customer(customerID, surName, firstName, sex, birth, driverLicenseDate, driverLicenseNumber, idNumber, address);


                        #endregion

                        int rentedCarID = Convert.ToInt32(reader["RentedCarID"]);
                        DateTime startDate = (DateTime)reader["StartDate"];
                        DateTime endDate = (DateTime)reader["EndDate"];
                        bool isInsured = (bool)reader["IsInsured"];

                        int salesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                        string firstNameSales = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        DateTime birthday = (DateTime)reader["Birthday"];
                        string email = reader["Email"].ToString();
                        string phone = reader["Phone"].ToString();
                        SalesPerson salesPerson = new SalesPerson(salesPersonID, firstNameSales, lastName, birthday, email, phone);

                        Deal deal = new Deal(ID, customer, salesPerson, created);

                        RentedCar rentedCar = new RentedCar(rentedCarID, car, deal, startDate, endDate, isInsured);

                        rentedCars.Add(rentedCar);
                    }
                }
            }

            return rentedCars;
        }
        public void DeleteRentedCar(int rentedCarID)
        {
            string sql = "DELETE FROM rentedcars WHERE RentedCarID = @RentedCarID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@RentedCarID", rentedCarID);
                cmd.ExecuteNonQuery();
            }
        }

        public RentedCar GetRentedCar(int rentedCarID)
        {
            RentedCar rentedCar = new RentedCar(null, null, default, default, false);
            //string sql = "SELECT rentedcars.*, cars.*, deals.*, customers.*, salespersons.* " +
            //    "FROM rentedcars " +
            //    "INNER JOIN cars ON rentedcars.CarID = cars.CarID " +
            //    "INNER JOIN deals ON rentedcars.DealID = customers.DealID " +
            //    "INNER JOIN customers ON customers.CustomerID = deals.CustomerID " +
            //    "INNER JOIN salespersons ON salespersons.SalesPersonID = deals.SalesPersonID " +
            //    "WHERE RentedCarID = @RentedCarID";

            string sql = "SELECT rentedcars.*, cars.*, deals.*, customers.*, salespersons.* " +
                "FROM rentedcars " +
                "INNER JOIN cars " +
                    "ON cars.CarID = rentedcars.CarID " +
                 "INNER JOIN deals " +
                    "ON deals.DealID = rentedcars.DealID " +
                 "INNER JOIN customers " +
                     "ON customers.CustomerID = deals.CustomerID " +
                 "INNER JOIN salespersons " +
                      "ON salespersons.SalesPersonID = deals.SalesPersonID " +
                 "WHERE rentedcars.RentedCarID = @RentedCarID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@RentedCarID", rentedCarID);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        #region Arguments for the CAR object
                        int carID = Convert.ToInt32(reader["CarID"]);
                        string brand = reader["Brand"].ToString();
                        string type = reader["type"].ToString();
                        int productionYear = Convert.ToInt32(reader["ProductionYear"]);
                        int seatCount = Convert.ToInt32(reader["SeatCount"]);
                        float fuelConsumption = (float)reader["FuelConsumption"];
                        string carShop = reader["CarShop"].ToString();
                        float price = (float)reader["Price"];
                        string licensePlate = reader["LicensePlate"].ToString();

                        Car car = new Car(carID, brand, type, productionYear, seatCount, fuelConsumption, carShop, price, licensePlate);
                        #endregion

                        #region Arguments for the DEAL object
                        int dealID = Convert.ToInt32(reader["DealID"]);
                        DateTime created = (DateTime)(reader["Created"]);

                        int customerID = Convert.ToInt32(reader["CustomerID"]);
                        string surName = reader["SurName"].ToString();
                        string firstName = reader["FirstName"].ToString();
                        string sex = reader["Sex"].ToString();
                        DateTime birth = (DateTime)reader["Birth"];
                        DateTime driverLicenseDate = (DateTime)reader["DriverLicenseDate"];
                        string driverLicenseNumber = reader["DriverLicenseNumber"].ToString();
                        string idNumber = reader["IDNumber"].ToString();
                        string address = reader["Address"].ToString();

                        Customer customer = new Customer(customerID, surName, firstName, sex, birth, driverLicenseDate, driverLicenseNumber, idNumber, address);

                        #endregion

                        int ID = Convert.ToInt32(reader["RentedCarID"]);
                        DateTime startDate = (DateTime)reader["StartDate"];
                        DateTime endDate = (DateTime)reader["EndDate"];
                        bool isInsured = (bool)reader["IsInsured"];

                        int salesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                        string firstNameSales = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        DateTime birthday = (DateTime)reader["Birthday"];
                        string email = reader["Email"].ToString();
                        string phone = reader["Phone"].ToString();
                        SalesPerson salesPerson = new SalesPerson(salesPersonID, firstNameSales, lastName, birthday, email, phone);

                        Deal deal = new Deal(dealID, customer, salesPerson, created);

                        rentedCar = new RentedCar(ID, car, deal, startDate, endDate, isInsured);
                    }
                }
            }
            return rentedCar;
        }
        public void UpdateRentedCar(RentedCar rentedCar)
        {
            string sql = "UPDATE rentedcars " +
                "SET CarID = @CarID, " +
                "DealID = @DealID, " +
                "StartDate = @StartDate, " +
                "EndDate = @EndDate, " +
                "IsInsured = @IsInsured " +
                "WHERE RentedCarID = @RentedCarID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@RentedCarID", rentedCar.rentedCarID);
                cmd.Parameters.AddWithValue("@CarID", rentedCar.car.carID);
                cmd.Parameters.AddWithValue("@DealID", rentedCar.deal.dealID);
                cmd.Parameters.AddWithValue("@StartDate", rentedCar.startDate);
                cmd.Parameters.AddWithValue("@EndDate", rentedCar.endDate);
                cmd.Parameters.AddWithValue("@IsInsured", rentedCar.IsInsured);

                cmd.ExecuteNonQuery();

            }
        }
        #endregion

        public bool IsCarAlreadyRented(RentedCar rentedCar)
        {
            string sql = "SELECT * FROM rentedcars WHERE rentedcars.CarID = @CarID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CarID", rentedCar.car.carID);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime startDate = (DateTime)reader["StartDate"];
                        DateTime endDate = (DateTime)reader["EndDate"];

                        if (rentedCar.startDate >= startDate && rentedCar.startDate <= endDate)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}

