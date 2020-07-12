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
    public partial class SalesPersonsForm : Form
    {
        int salesPersonID = 0;
        SalesPersonHandler sh = new SalesPersonHandler();

        public SalesPersonsForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            DateTime birthday = dateTimeBirthday.Value;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            SalesPerson salesPerson = new SalesPerson(firstName, lastName, birthday, email, phone);

            if (salesPersonID == 0)
            {
                try
                {
                    sh.SetSalesPersonWithCheck(salesPerson);
                    GetSalesPersons();
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
                    sh.UpdateSalesPersonWithCheck(salesPerson);
                    GetSalesPersons();
                }
                catch (ArgumentException ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void GetSalesPersons()
        {
            listViewSalesPerson.Items.Clear();
            List<SalesPerson> salesPeople = sh.GetSalesPersonList();

            foreach (SalesPerson salesPerson in salesPeople)
            {
                ListViewItem lwi = new ListViewItem(salesPerson.salesPersonID.ToString());
                lwi.SubItems.Add(salesPerson.firstName.ToString());
                lwi.SubItems.Add(salesPerson.lastName.ToString());
                lwi.SubItems.Add(salesPerson.birthday.ToString());
                lwi.SubItems.Add(salesPerson.email.ToString());
                lwi.SubItems.Add(salesPerson.phone.ToString());
                listViewSalesPerson.Items.Add(lwi);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewSalesPerson.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listViewSalesPerson.SelectedItems)
                {
                    int id = Convert.ToInt32(item.SubItems[0].Text);
                    sh.DeleteSalesPerson(id);
                }
            }
            else
            {
                MessageBox.Show("You have to select at least one item");
            }
            GetSalesPersons();
        }

        private void listViewSalesPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSalesPerson.SelectedItems.Count > 0)
            {
                salesPersonID = Convert.ToInt32(listViewSalesPerson.SelectedItems[0].SubItems[0].Text);
                btnAdd.Text = "Modify";
                SalesPerson salesPerson = sh.GetSalesPerson(salesPersonID);

                txtFirstName.Text = salesPerson.firstName;
                txtLastName.Text = salesPerson.lastName;
                dateTimeBirthday.Value = salesPerson.birthday;
                txtEmail.Text = salesPerson.email;
                txtPhone.Text = salesPerson.phone;
            }
            else
            {
                btnAdd.Text = "Add";
                salesPersonID = 0;
            }
        }

        private void SalesPersonsForm_Load(object sender, EventArgs e)
        {
            GetSalesPersons();
        }
    }
}
