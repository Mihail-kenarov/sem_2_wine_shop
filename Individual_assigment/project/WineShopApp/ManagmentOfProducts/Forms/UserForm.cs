using BusinessLogic;
using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using DataAccessLayer;

namespace ManagmentOfProducts.Forms
{
    public partial class UserForm : Form
    {
        IUserManager userManager;


        public UserForm()
        {
            InitializeComponent();
            userManager = new UserManager(new UserRepo());
            ShowUsers(userManager.GetAll(), lbUsers);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            User user;
            if (string.IsNullOrWhiteSpace(txtUserFN.Text)
             || string.IsNullOrWhiteSpace(txtUserPassword.Text) || string.IsNullOrWhiteSpace(txtUserUsername.Text)
             || string.IsNullOrWhiteSpace(cbUserRole.Text))
            {
                MessageBox.Show("Please fill in all fields to add a new user.");
                return;
            }

            else
            {
                byte[] salt = Encryption.GenerateSalt();
                byte[] HashedPassword = Encryption.HashPassword(txtUserPassword.Text, salt);

                user = new User(txtUserFN.Text, txtUserUsername.Text, HashedPassword, salt, cbUserRole.Text);

                try
                {
                    userManager.Add(user);
                    ShowUsers(userManager.GetAll(), lbUsers);
                    MessageBox.Show("User was added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbUsers.SelectedItem != null)
                {
                    foreach (User user in userManager.GetAll())
                    {
                        if (userManager.Info(user) == lbUsers.SelectedItem.ToString())
                        {
                            userManager.Delete(Convert.ToInt32(txtUserID.Text));
                            ShowUsers(userManager.GetAll(), lbUsers);
                            MessageBox.Show("Employee removed successfully");
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an employee to remove");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnUpdateUser_Click(object sender, EventArgs e)
        {

            User user = new User(Convert.ToInt32(txtUserID.Text),txtUserFN.Text, txtUserUsername.Text, cbUserRole.Text);
            try
            {
                userManager.Update(user);
                MessageBox.Show("User was updated successfully");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowUsers(List<User> users, ListBox lbOfUsers)
        {
            lbOfUsers.Items.Clear();
            foreach (User user in users)
            {
                lbUsers.Items.Add(userManager.Info(user));
            }
            txtUserFN.Text = "";
            txtUserID.Text = "";
            txtUserPassword.Text = "";
            txtUserUsername.Text = "";
            cbUserRole.Text="";
        }

        private void lbUsers_DoubleClick(object sender, EventArgs e)
        {
            foreach (User user in userManager.GetAll())
            {
                if (userManager.Info(user) == lbUsers.Text)
                {
                    txtUserFN.Text = user.UserName;
                    txtUserID.Text = user.Id.ToString();
                    txtUserUsername.Text = user.UserName;
                    cbUserRole.Text = user.Role;
                    return;
                }
            }
        }
    }
}

