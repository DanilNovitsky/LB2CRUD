using LB2CRUD.models;
using LB2CRUD.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB2CRUD
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            firstNameField.Text = "First name";
            firstNameField.ForeColor = Color.Gray;
            lastNameField.Text = "Last name";
            lastNameField.ForeColor = Color.Gray;
            phoneNumberField.Text = "Phone number";
            phoneNumberField.ForeColor = Color.Gray;
            loginField.Text = "Email";
            loginField.ForeColor = Color.Gray;
            passField.Text = "password";
            passField.ForeColor = Color.Gray;

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        private void firstNameField_Enter(object sender, EventArgs e)
        {
            if (firstNameField.Text == "First name")
            {
                firstNameField.Text = "";
                firstNameField.ForeColor = Color.Black;
            }
        }

        private void firstNameField_Leave(object sender, EventArgs e)
        {
            if (firstNameField.Text == "")
            {
                firstNameField.Text = "First name";
                firstNameField.ForeColor = Color.Gray;
            }
        }

        private void lastNameField_Enter(object sender, EventArgs e)
        {
            if (lastNameField.Text == "Last name")
            {
                lastNameField.Text = "";
                lastNameField.ForeColor = Color.Black;
            }
        }

        private void lastNameField_Leave(object sender, EventArgs e)
        {
            if (lastNameField.Text == "")
            {
                lastNameField.Text = "Last name";
                lastNameField.ForeColor = Color.Gray;
            }
        }

        private void phoneNumberField_Enter(object sender, EventArgs e)
        {
            if (phoneNumberField.Text == "Phone number")
            {
                phoneNumberField.Text = "";
                phoneNumberField.ForeColor = Color.Black;
            }
        }

        private void phoneNumberField_Leave(object sender, EventArgs e)
        {
            if (phoneNumberField.Text == "")
            {
                phoneNumberField.Text = "Phone number";
                phoneNumberField.ForeColor = Color.Gray;
            }
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Email")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Email";
                loginField.ForeColor = Color.Gray;
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "password")
            {
                passField.Text = "";
                passField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.Text = "password";
                passField.ForeColor = Color.Gray;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string validationMessage;

            if (!IsValidInput(out validationMessage))
            {
                MessageBox.Show($"Invalid data: {validationMessage}");
                return;
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (db.Customers.Any(c => c.Email == loginField.Text))
                {
                    MessageBox.Show("User with this email already exists. Please choose another email.");
                    return;
                }

                if (db.Customers.Any(c => c.PhoneNumber == phoneNumberField.Text))
                {
                    MessageBox.Show("User with this phone number already exists. Please choose another phone number.");
                    return;
                }

                Customer newCustomer = new Customer
                {
                    FirstName = firstNameField.Text,
                    LastName = lastNameField.Text,
                    Email = loginField.Text,
                    PhoneNumber = phoneNumberField.Text
                };

                string hashedPass = HashUtility.HashPassword(passField.Text);
                newCustomer.password = hashedPass;

                db.Customers.Add(newCustomer);
                db.SaveChanges();

                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private bool IsValidInput(out string validationMessage)
        {
            validationMessage = "";

            if (string.IsNullOrWhiteSpace(firstNameField.Text) || firstNameField.Text.Equals("First name"))
                validationMessage += "First name is required.\n";

            if (string.IsNullOrWhiteSpace(lastNameField.Text) || lastNameField.Text.Equals("Last name"))
                validationMessage += "Last name is required.\n";

            if (string.IsNullOrWhiteSpace(loginField.Text) || loginField.Text.Equals("Email"))
                validationMessage += "Email is required.\n";
            else if (!IsValidEmail(loginField.Text))
                validationMessage += "Invalid email format.\n";

            if (string.IsNullOrWhiteSpace(phoneNumberField.Text) || phoneNumberField.Text.Equals("Phone number"))
                validationMessage += "Phone number is required.\n";

            if (string.IsNullOrWhiteSpace(passField.Text) || passField.Text.Equals("password"))
                validationMessage += "Password is required.\n";

            return string.IsNullOrWhiteSpace(validationMessage);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void loginLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void loginLabel_MouseEnter(object sender, EventArgs e)
        {
            loginLabel.ForeColor = Color.GreenYellow;
        }

        private void loginLabel_MouseLeave(object sender, EventArgs e)
        {
            loginLabel.ForeColor = Color.White;
        }
    }
}
