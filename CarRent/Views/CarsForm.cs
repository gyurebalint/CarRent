using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRent.DataStructures;
using CarRent.Models;
using CarRent.Views;

namespace CarRent.Views
{
    public partial class CarsForm : Form
    {
        int carID = 0;
        CarHandler ch = new CarHandler();

        public CarsForm()
        {
            InitializeComponent();
        }
        private void GetCars()
        {
            List<Car> cars = ch.GetCarList();

            listViewCars.Items.Clear();

            foreach (Car car in cars)
            {
                ListViewItem lwi = new ListViewItem(car.carID.ToString());
                lwi.SubItems.Add(car.brand.ToString());
                lwi.SubItems.Add(car.type.ToString());
                lwi.SubItems.Add(car.productionYear.ToString());
                lwi.SubItems.Add(car.seatCount.ToString());
                lwi.SubItems.Add(car.fuelConsumption.ToString());
                lwi.SubItems.Add(car.carShop.ToString());
                lwi.SubItems.Add(car.price.ToString());
                lwi.SubItems.Add(car.licensePlate.ToString());

                listViewCars.Items.Add(lwi);
            }

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string brand = txtBrand.Text;
            string type = txtType.Text;
            int productionYear = (int)numProductionYear.Value;
            int seatCount = (int)numSeatCount.Value;
            float fuelConsumption = (float)numFuelConsumption.Value;
            string carShop = txtCarShop.Text;
            double price = (double)numPrice.Value;
            string licensePlate = txtLicensePlate.Text;

            Car car = new Car(brand, type, productionYear, seatCount, fuelConsumption, carShop, price, licensePlate);

            if (carID == 0)
            {
                try
                {
                    ch.SetCarWithCheck(car);
                    GetCars();
                }
                catch (ArgumentException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    car.carID = carID;
                    ch.UpdateCarWithCheck(car);
                    GetCars();
                }
                catch (ArgumentException ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void CarsForm_Load(object sender, EventArgs e)
        {
            GetCars();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewCars.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lwi in listViewCars.SelectedItems)
                {
                    int carID = int.Parse(lwi.SubItems[0].Text);
                    ch.DeleteCar(carID);
                }
                GetCars();
            }
            else
            {
                MessageBox.Show("You must select at least one element in the list");
            }
        }

        private void listViewCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCars.SelectedItems.Count > 0)
            {
                carID = int.Parse(listViewCars.SelectedItems[0].SubItems[0].Text);
                btnOK.Text = "Modify";

                Car car = ch.GetCar(carID);

                txtBrand.Text = car.brand.ToString();
                txtType.Text = car.type.ToString();
                numProductionYear.Value = car.productionYear;
                numSeatCount.Value = car.seatCount;
                numFuelConsumption.Value = (decimal)car.fuelConsumption;
                txtCarShop.Text = car.carShop.ToString();
                numPrice.Value = (decimal)car.price;
                txtLicensePlate.Text = car.licensePlate.ToString();
            }
            else
            {
                btnOK.Text = "OK";
                carID = 0;
            }
        }
    }
}
