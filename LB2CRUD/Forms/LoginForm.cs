using LB2CRUD.Forms;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Width, 64);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginCustomer = loginField.Text;
            String passCustomer = passField.Text;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                string hashedLoginPassword = HashUtility.HashPassword(passCustomer);

                Customer customer = db.Customers
                    .SingleOrDefault(c => c.Email == loginCustomer && c.password == hashedLoginPassword);

                if (customer != null) {
                    CurrentSession.UserId = customer.Id;
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                } 
                else
                {
                    MessageBox.Show("Nooo");
                }
            }
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void registerLabel_MouseEnter(object sender, EventArgs e)
        {
            registerLabel.ForeColor = Color.GreenYellow;
        }

        private void registerLabel_MouseLeave(object sender, EventArgs e)
        {
            registerLabel.ForeColor = Color.White;
        }
    }
}
