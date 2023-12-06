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
    public partial class AddTiresForm : Form
    {
        public TireShop tireShop { get; set; }
        public Tire newTire { get; set; }
        public AddTiresForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                tireShop = db.TireShops.Find(CurrentTireShop.TireShopId);
                tireShop.Tires = db.Tires.Where(ts => ts.TireShopId == tireShop.Id).ToList();
            }
            
            LoadTips();
        }

        private void LoadTips()
        {
            brandField.Text = "Brand";
            brandField.ForeColor = Color.Gray;
            modelField.Text = "Model";
            modelField.ForeColor = Color.Gray;
            sizeField.Text = "Size";
            sizeField.ForeColor = Color.Gray;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (db.Tires.Any(c => c.Brand == brandField.Text) &&
                    db.Tires.Any(c => c.Model == modelField.Text) &&
                    db.Tires.Any(c => c.Size == sizeField.Text))
                {
                    MessageBox.Show("Tire already exists. Please choose another tire.");
                    return;
                }

                db.Attach(tireShop);
                newTire = new Tire
                {
                    TireShop = tireShop,
                    Brand = brandField.Text,
                    Model = modelField.Text,
                    Size = sizeField.Text,
                };
                db.Tires.Add(newTire);
                db.SaveChanges();

                tireShop.Tires.Add(newTire);
                db.SaveChanges();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsValidInput(out string validationMessage)
        {
            validationMessage = "";

            if (string.IsNullOrWhiteSpace(brandField.Text) || brandField.Text.Equals("Brand"))
                validationMessage += "Brand is required.\n";

            if (string.IsNullOrWhiteSpace(modelField.Text) || modelField.Text.Equals("Model"))
                validationMessage += "Model is required.\n";

            if (string.IsNullOrWhiteSpace(sizeField.Text) || sizeField.Text.Equals("Size"))
                validationMessage += "Model is required.\n";

            return string.IsNullOrWhiteSpace(validationMessage);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void brandField_Enter(object sender, EventArgs e)
        {
            if (brandField.Text == "Brand")
            {
                brandField.Text = "";
                brandField.ForeColor = Color.Black;
            }
        }

        private void brandField_Leave(object sender, EventArgs e)
        {
            if (brandField.Text == "")
            {
                brandField.Text = "Brand";
                brandField.ForeColor = Color.Gray;
            }
        }

        private void modelField_Enter(object sender, EventArgs e)
        {
            if (modelField.Text == "Model")
            {
                modelField.Text = "";
                modelField.ForeColor = Color.Black;
            }
        }

        private void modelField_Leave(object sender, EventArgs e)
        {
            if (modelField.Text == "")
            {
                modelField.Text = "Model";
                modelField.ForeColor = Color.Gray;
            }
        }

        private void sizeField_Enter(object sender, EventArgs e)
        {
            if (sizeField.Text == "Size")
            {
                sizeField.Text = "";
                sizeField.ForeColor = Color.Black;
            }
        }

        private void sizeField_Leave(object sender, EventArgs e)
        {
            if (sizeField.Text == "")
            {
                sizeField.Text = "Size";
                sizeField.ForeColor = Color.Gray;
            }
        }
    }
}
