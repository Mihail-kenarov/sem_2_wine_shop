using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagmentOfProducts.Forms
{
    public partial class Login : Form
    {

        IUserManager userManagment;

        public Login()
        {
            InitializeComponent();
            userManagment = new UserManager(new UserRepo());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            User user = userManagment.ValidateUser(txtUsername.Text, txtPassword.Text);

            if (user != null)
            {
                MainForm mainForm = new MainForm();
                if (user.Role == "CEO")
                {
                    // For the CEO role
                    mainForm.OpenChildForm(new UserForm(), sender);

                }
                else if (user.Role == "Employee")
                {
                    //For the Employee role
                    mainForm.PrepareForEmployeeLogin();
                    mainForm.OpenChildForm(new WinesForm(), sender);

                }

                this.Hide();
                mainForm.Show();

            }
            else
            {
                MessageBox.Show("Authentication failed");
            }


        }







    }
}
