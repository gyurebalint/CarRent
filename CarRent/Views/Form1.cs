using CarRent.Views;
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

namespace CarRent.Views
{
    public partial class Form1 : Form
    {
        RentedCarHandler rh = new RentedCarHandler();
        public Form1()
        {
            InitializeComponent();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarsForm form = new CarsForm();
            form.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersForm form = new CustomersForm();
            form.Show();
        }

        private void salesPersonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesPersonsForm form = new SalesPersonsForm();
            form.Show();
        }

        private void rentedCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentedCarsForm form = new RentedCarsForm();
            form.Show();
        }

        private void dealsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DealsForm form = new DealsForm();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetRentedCars();
        }

        private void GetRentedCars()
        {
            listViewRentedCars.Items.Clear();
            //int dealID = Convert.ToInt32(listViewRentedCars.SelectedItems[0].SubItems[0].Text);
            List<RentedCar> rentedCars = rh.GetRentedCarList();

            foreach (RentedCar rentedCar in rentedCars)
            {
                ListViewItem lwi = new ListViewItem(rentedCar.rentedCarID.ToString());
                lwi.SubItems.Add(rentedCar.car.ToString());
                lwi.SubItems.Add(rentedCar.deal.salesPerson.Name.ToString());
                lwi.SubItems.Add(rentedCar.startDate.ToString());
                lwi.SubItems.Add(rentedCar.endDate.ToString());
                lwi.SubItems.Add(rentedCar.IsInsured.ToString());
                listViewRentedCars.Items.Add(lwi);
            }
        }

        private void listViewRentedCars_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewRentedCars_DoubleClick(object sender, EventArgs e)
        {
            GetRentedCars();
        }
    }
}