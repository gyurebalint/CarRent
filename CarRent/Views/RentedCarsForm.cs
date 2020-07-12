using CarRent.DataStructures;
using CarRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent.Views
{
    public partial class RentedCarsForm : Form
    {
        int rentedCarID = 0;
        RentedCarHandler rh = new RentedCarHandler();
        public RentedCarsForm()
        {
            InitializeComponent();
        }

        private void RentedCarsForm_Load(object sender, EventArgs e)
        {
            LoadDataBindings();
            GetDeals();
        }
        private void LoadDataBindings()
        {
            BindingSource carsSource = new BindingSource();
            List<Car> cars = rh.GetCarList();

            carsSource.DataSource = cars;

            comboCar.DataSource = carsSource;
            comboCar.DisplayMember = "Name";
            comboCar.ValueMember = "Name";
        }

        private void GetRentedCars()
        {
            listViewRentedCars.Items.Clear();
            int dealID = Convert.ToInt32(listViewDeals.SelectedItems[0].SubItems[0].Text);
            List<RentedCar> rentedCars = rh.GetRentedCarListByDealID(dealID);

            foreach (RentedCar rentedCar in rentedCars)
            {
                ListViewItem lwi = new ListViewItem(rentedCar.rentedCarID.ToString());
                lwi.SubItems.Add(rentedCar.car.ToString());
                lwi.SubItems.Add(rentedCar.deal.ToString());
                lwi.SubItems.Add(rentedCar.startDate.ToString());
                lwi.SubItems.Add(rentedCar.endDate.ToString());
                lwi.SubItems.Add(rentedCar.IsInsured.ToString());
                listViewRentedCars.Items.Add(lwi);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int dealID = Convert.ToInt32(listViewDeals.SelectedItems[0].SubItems[0].Text);
            Deal deal = rh.GetDeal(dealID);

            Car car = (Car)comboCar.SelectedItem;
            DateTime startDate = dateTimePickerStartDay.Value;
            DateTime endDate = dateTimePickerEndDay.Value;
            bool isInsured = checkBoxInsurance.Checked;

            RentedCar rentedCar = new RentedCar(car, deal, startDate, endDate, isInsured);

            if (rentedCarID == 0)
            {
                try
                {
                    rh.SetRentedCarWithCheck(rentedCar);
                    GetRentedCars();
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
                    rentedCar.rentedCarID = rentedCarID;
                    rh.UpdateRentedCarWithCheck(rentedCar);
                    GetRentedCars();
                }
                catch (ArgumentException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewRentedCars.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lwi in listViewRentedCars.SelectedItems)
                {
                    int rentedCarID = Convert.ToInt32(lwi.SubItems[0].Text);
                    rh.DeleteRentedCar(rentedCarID);
                }
            }
            else
            {
                MessageBox.Show("At least one item has to be selected");
            }
            GetRentedCars();
        }

        private void listViewRentedCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRentedCars.SelectedItems.Count > 0)
            {
                rentedCarID = Convert.ToInt32(listViewRentedCars.SelectedItems[0].SubItems[0].Text);
                btnAdd.Text = "Modify";
                RentedCar rentedCar = rh.GetRentedCar(rentedCarID);

                comboCar.SelectedItem = rentedCar.car;
                dateTimePickerStartDay.Value = rentedCar.startDate;
                dateTimePickerEndDay.Value = rentedCar.endDate;
                checkBoxInsurance.Checked = rentedCar.IsInsured;
            }
            else
            {
                rentedCarID = 0;
                btnAdd.Text = "Add";
            }
        }

        private void GetDeals()
        {
            List<Deal> dealList = rh.GetDealList();

            listViewDeals.Items.Clear();

            foreach (Deal deal in dealList)
            {
                ListViewItem lwi = new ListViewItem(deal.dealID.ToString());
                lwi.SubItems.Add(deal.created.ToString());
                lwi.SubItems.Add(deal.customer.Name.ToString());
                lwi.SubItems.Add(deal.customer.IDNumber.ToString());
                lwi.SubItems.Add($"{deal.salesPerson.lastName.ToString()} {deal.salesPerson.firstName.ToString()}");

                listViewDeals.Items.Add(lwi);
            }

        }
        private void listViewDeals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDeals.SelectedItems.Count > 0)
            {
                GetRentedCars();
            }
            else
            {
                rentedCarID = 0;
                btnAdd.Text = "Add";
            }
        }
    }
}
