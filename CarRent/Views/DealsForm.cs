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
    public partial class DealsForm : Form
    {
        int dealID = 0;
        DealHandler dh = new DealHandler();
        public DealsForm()
        {
            InitializeComponent();
        }
        private void DealsForm_Load(object sender, EventArgs e)
        {
            GetDeals();
            LoadDataBindings();
        }
        private void LoadDataBindings()
        {
            BindingSource salesPersonSource = new BindingSource();
            BindingSource customersSource = new BindingSource();
            List<SalesPerson> salesPersons = dh.GetSalesPersonList();
            List<Customer> customers = dh.GetCustomerList();

            salesPersonSource.DataSource = salesPersons;
            customersSource.DataSource = customers;

            comboSalesPerson.DataSource = salesPersonSource;
            comboSalesPerson.DisplayMember = "Name";
            comboSalesPerson.ValueMember = "Name";

            comboCustomer.DataSource = customersSource;
            comboCustomer.DisplayMember = "Name";
            comboCustomer.ValueMember = "Name";
        }
        private void GetDeals()
        {
            List<Deal> dealList = dh.GetDealList();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)comboCustomer.SelectedItem;
            SalesPerson salesPerson = (SalesPerson)comboSalesPerson.SelectedItem;

            Deal deal = new Deal(customer, salesPerson);

            if (dealID == 0)
            {
                try
                {
                    dh.SetDealWithCkeck(deal);
                    GetDeals();
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
                    deal.dealID = dealID;
                    dh.UpdateWithCheck(deal);
                    GetDeals();
                }
                catch (ArgumentException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewDeals.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lwi in listViewDeals.SelectedItems)
                {
                    int dealID = int.Parse(lwi.SubItems[0].Text);
                    dh.DeleteDeal(dealID);
                }
                GetDeals();

            }
            else
            {
                MessageBox.Show("You have to select at least one item");
            }
        }

        private void listViewDeals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDeals.SelectedItems.Count > 0)
            {
                dealID = Convert.ToInt32(listViewDeals.Items[0].SubItems[0].Text);
                Deal deal = dh.GetDeal(dealID);
                btnAdd.Text = "Modify";

                comboCustomer.SelectedItem = deal.customer.Name;
                comboSalesPerson.SelectedItem = deal.salesPerson.Name;
            }
            else
            {
                dealID = 0;
                btnAdd.Text = "Add";
            }
        }
    }
}
