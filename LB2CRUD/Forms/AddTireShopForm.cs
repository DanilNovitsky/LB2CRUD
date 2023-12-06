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
    public partial class AddTireShopForm : Form
    {
        public Customer customer { get; set; }
        public TireShop NewTireShop { get; set; }
        public AddTireShopForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                customer = db.Customers.Find(CurrentSession.UserId);

                customer.TireShops = db.TireShops.Where(ts => ts.CustomerId == customer.Id).ToList();
            }

            nameField.Text = "Name";
            nameField.ForeColor = Color.Gray;
            addressField.Text = "Address";
            addressField.ForeColor = Color.Gray;
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string validationMessage;
            if (!IsValidInput(out validationMessage))
            {
                MessageBox.Show($"Invalid data:\n {validationMessage}");
                return;
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (db.TireShops.Any(c => c.Name == nameField.Text))
                {
                    MessageBox.Show("Tire shop with this name already exists. Please choose another name.");
                    return;
                }

                db.Attach(customer);
                NewTireShop = new TireShop
                {
                    Customer = customer,
                    Name = nameField.Text,
                    Address = addressField.Text
                };
                db.TireShops.Add(NewTireShop);
                db.SaveChanges();

                customer.TireShops.Add(NewTireShop);
                db.SaveChanges();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsValidInput(out string validationMessage)
        {
            validationMessage = "";

            if (string.IsNullOrWhiteSpace(nameField.Text) || nameField.Text.Equals("Name"))
                validationMessage += "Name is required.\n";

            if (string.IsNullOrWhiteSpace(addressField.Text) || addressField.Text.Equals("Address"))
                validationMessage += "Address is required.\n";

            return string.IsNullOrWhiteSpace(validationMessage);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void nameField_Enter(object sender, EventArgs e)
        {
            if (nameField.Text == "Name")
            {
                nameField.Text = "";
                nameField.ForeColor = Color.Black;
            }
        }

        private void nameField_Leave(object sender, EventArgs e)
        {
            if (nameField.Text == "")
            {
                nameField.Text = "Name";
                nameField.ForeColor = Color.Gray;
            }
        }

        private void addressField_Enter(object sender, EventArgs e)
        {
            if (addressField.Text == "Address")
            {
                addressField.Text = "";
                addressField.ForeColor = Color.Black;
            }
        }

        private void addressField_Leave(object sender, EventArgs e)
        {
            if (addressField.Text == "")
            {
                addressField.Text = "Address";
                addressField.ForeColor = Color.Gray;
            }
        }
    }
}
