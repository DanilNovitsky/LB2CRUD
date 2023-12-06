using LB2CRUD.models;
using LB2CRUD.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB2CRUD.Forms
{
    public partial class MainForm : Form
    {
        public Customer CurrentCustomer { get; set; }

        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeListView();
            LoadUserData();

            fullName.Text = $"{CurrentCustomer.FirstName} {CurrentCustomer.LastName}";
            UpdateTireShopsList();

            searchField.Text = "Search";
            searchField.ForeColor = Color.Gray;
        }

        private void LoadUserData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CurrentCustomer = db.Customers.Find(CurrentSession.UserId);
                CurrentCustomer.TireShops = db.TireShops.Where(ts => ts.CustomerId == CurrentCustomer.Id).ToList();
            }
        }

        private void InitializeListView()
        {
            tireShopList.View = View.Details;
            tireShopList.Columns.Add("Name");
            tireShopList.Columns.Add("Address");
        }

            private void UpdateTireShopsList()
        {
            tireShopList.Items.Clear();

            foreach (var tireShop in CurrentCustomer.TireShops)
            {
                var listViewItem = new ListViewItem(tireShop.Name);
                listViewItem.SubItems.Add(tireShop.Address);
                listViewItem.Tag = tireShop;

                tireShopList.Items.Add(listViewItem);
            }
            for (int i = 0; i < tireShopList.Columns.Count; i++)
            {
                tireShopList.Columns[i].Width = -2;
            }

        }

        Point lastPoint;
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        private void addTireShop_Click(object sender, EventArgs e)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                AddTireShopForm addTireShopForm = new AddTireShopForm();
                if (addTireShopForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUserData();
                    UpdateTireShopsList();
                }
            }
        }

        private void tireShopsList_ItemActivate(object sender, EventArgs e)
        {
            var selectedItem = tireShopList.SelectedItems[0];
            var tireShop = (TireShop)selectedItem.Tag;
            CurrentTireShop.TireShopId = tireShop.Id;
            var detailsForm = new TireShopDetailsForm();
            detailsForm.Show();
        }

        private void searchField_TextChanged(object sender, EventArgs e)
        {
            SearchTireShops();
        }

        private void SearchTireShops()
        {
            string query = searchField.Text.ToLower();
            if (query.Equals("search"))
            {
                UpdateTireShopsList();
                return;
            }
            tireShopList.Items.Clear();

            foreach (var tireShop in CurrentCustomer.TireShops)
            {
                if (string.IsNullOrEmpty(query) || tireShop.Name.ToLower().Contains(query))
                {
                    var listViewItem = new ListViewItem(tireShop.Name);
                    listViewItem.SubItems.Add(tireShop.Address);
                    listViewItem.Tag = tireShop;

                    tireShopList.Items.Add(listViewItem);
                }
            }
        }

        private void searchField_Enter(object sender, EventArgs e)
        {
            if (searchField.Text == "Search")
            {
                searchField.Text = "";
                searchField.ForeColor = Color.Black;
            }
        }

        private void searchField_Leave(object sender, EventArgs e)
        {
            if (searchField.Text == "")
            {
                searchField.Text = "Search";
                searchField.ForeColor = Color.Gray;
            }
        }
    }
}
