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
    public partial class TireShopDetailsForm : Form
    {
        private TireShop _TireShop { get; set; }
        public TireShopDetailsForm()
        {
            InitializeComponent();
            InitializeListView();
            LoadTiresData();
            fullName.Text = $"{_TireShop.Name}";
            UpdateTiresList();
            searchField.Text = "Search";
            searchField.ForeColor = Color.Gray;
        }
        private void LoadTiresData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                _TireShop = db.TireShops.Find(CurrentTireShop.TireShopId);
                _TireShop.Tires = db.Tires.Where(ts => ts.TireShopId == CurrentTireShop.TireShopId).ToList();
            }
        }

        private void InitializeListView()
        {
            tiresList.View = View.Details;
            tiresList.Columns.Add("Brand");
            tiresList.Columns.Add("Model");
            tiresList.Columns.Add("Size");
        }

        private void UpdateTiresList()
        {
            tiresList.Items.Clear();

            foreach (var tire in _TireShop.Tires)
            {
                var listViewItem = new ListViewItem(tire.Brand);
                listViewItem.SubItems.Add(tire.Model);
                listViewItem.SubItems.Add(tire.Size);
                listViewItem.Tag = tire;

                tiresList.Items.Add(listViewItem);
            }
            for (int i = 0; i < tiresList.Columns.Count; i++)
            {
                tiresList.Columns[i].Width = -2;
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        private void addTire_Click(object sender, EventArgs e)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                AddTiresForm addTiresForm = new AddTiresForm();
                if (addTiresForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTiresData();
                    UpdateTiresList();
                }
            }
        }

        private void searchField_TextChanged(object sender, EventArgs e)
        {
            SearchTires();
        }

        private void SearchTires()
        {
            string query = searchField.Text.ToLower();
            if (query.Equals("search"))
            {
                UpdateTiresList();
                return;
            }
            tiresList.Items.Clear();

            foreach (var tire in _TireShop.Tires)
            {
                if (string.IsNullOrEmpty(query) || tire.Brand.ToLower().Contains(query) ||
                    tire.Model.ToLower().Contains(query))
                {
                    var listViewItem = new ListViewItem(tire.Brand);
                    listViewItem.SubItems.Add(tire.Model);
                    listViewItem.SubItems.Add(tire.Size);
                    listViewItem.Tag = tire;

                    tiresList.Items.Add(listViewItem);
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
