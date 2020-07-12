using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRent.Models;
using CarRent.DataStructures;

namespace CarRent.Views
{
    public partial class CustomersForm : Form
    {
        int customerID = 0;
        CustomerHandler ch = new CustomerHandler();
        
        public CustomersForm()
        {
            InitializeComponent();
        }
        private void GetCustomers()
        {
            List<Customer> customers = ch.GetCustomerList();

            listViewCustomers.Items.Clear();

            foreach (Customer customer in customers)
            {
                ListViewItem lwi = new ListViewItem(customer.customerID.ToString());
                lwi.SubItems.Add(customer.surName.ToString());
                lwi.SubItems.Add(customer.firstName.ToString());
                lwi.SubItems.Add(customer.sex.ToString());
                lwi.SubItems.Add(customer.birth.ToString());
                lwi.SubItems.Add(customer.driverLicenseDate.ToString());
                lwi.SubItems.Add(customer.driverLicenseNumber.ToString());
                lwi.SubItems.Add(customer.IDNumber.ToString());
                lwi.SubItems.Add(customer.address.ToString());

                listViewCustomers.Items.Add(lwi);
            }
        }


        private void CustomersForm_Load(object sender, EventArgs e)
        {
            GetCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewCustomers.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lwi in listViewCustomers.SelectedItems)
                {
                    int id = int.Parse(lwi.SubItems[0].Text);
                    ch.DeleteCustomer(id);
                }
            }
            else
            {
                MessageBox.Show("You must select at least one element in the list");
            }
            GetCustomers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string surName = txtSurName.Text;
            string firstName = txtFirstName.Text;
            string sex = comboSex.Text;
            DateTime birth = dateTimePickBirthDay.Value;
            DateTime DriverLicenseDate = dateTimePickDriverLicenseDate.Value;
            string driverLicenseNumber = txtDriverLicenseNumber.Text;
            string IDNumber = txtIDNumber.Text;
            string address = txtAddress.Text;

            Customer customer = new Customer(surName, firstName, sex, birth,
                DriverLicenseDate, driverLicenseNumber, IDNumber, address);

            if (customerID == 0)
            {
                try
                {
                    ch.SetCustomerWithCheck(customer);
                    GetCustomers();
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
                    customer.customerID = customerID;
                    ch.UpdateCustomer(customer);
                    GetCustomers();
                }
                catch (ArgumentException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void listViewCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCustomers.SelectedItems.Count > 0)
            {
                customerID = int.Parse(listViewCustomers.SelectedItems[0].SubItems[0].Text);
                Customer customer = ch.GetCustomer(customerID);
                btnAdd.Text = "Modify";

                txtSurName.Text = customer.surName.ToString();
                txtFirstName.Text = customer.firstName.ToString();
                comboSex.Text = customer.sex.ToString();
                dateTimePickBirthDay.Value = customer.birth;
                dateTimePickDriverLicenseDate.Value = customer.driverLicenseDate;
                txtDriverLicenseNumber.Text = customer.driverLicenseNumber.ToString();
                txtIDNumber.Text = customer.IDNumber.ToString();
                txtAddress.Text = customer.address.ToString();
            }
            else
            {
                btnAdd.Text = "Add";
                customerID = 0;
            }
        }
    }
}
