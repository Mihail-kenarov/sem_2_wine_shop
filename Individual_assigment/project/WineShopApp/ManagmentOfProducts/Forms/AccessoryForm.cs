using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using DataAccessLayer.Repositories;

namespace ManagmentOfProducts.Forms
{
    public partial class AccessoryForm : Form
    {
        IAccessoryManager AccessoryManager;
        public AccessoryForm()
        {
            InitializeComponent();
            AccessoryManager = new AccessoryManager(new AccessoryRepo());
            ShowAccessory(AccessoryManager.GetAll(), lbAccessory);
        }

        private void btnAddAccessory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccessoryName.Text) || string.IsNullOrWhiteSpace(txtAcessoryType.Text)
              || string.IsNullOrWhiteSpace(txtAccessoryDescription.Text) || string.IsNullOrWhiteSpace(txtAccessoryAmount.Text)
              || string.IsNullOrWhiteSpace(nudAcessoryPrice.Text))
            {
                MessageBox.Show("Please fill in all fields to add a new accessory.");
                return;
            }

            Accessory accessory = new Accessory(Convert.ToInt32(txtAccessoryAmount.Text), txtAccessoryName.Text,
                txtAccessoryDescription.Text, Convert.ToDouble(nudAcessoryPrice.Text), txtAcessoryType.Text);
            try
            {
                AccessoryManager.AddAccessory(accessory);
                ShowAccessory(AccessoryManager.GetAll(), lbAccessory);
                MessageBox.Show("Accessory was added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateAccessory_Click(object sender, EventArgs e)
        {

            int accessoryIdPick;
            int accessoryAmount;
            double accessoryPrice;

            if (int.TryParse(txtAccessoryIdPick.Text, out accessoryIdPick) &&
                int.TryParse(txtAccessoryAmount.Text, out accessoryAmount) &&
                double.TryParse(nudAcessoryPrice.Text, out accessoryPrice))
            {
                Accessory accessory = new Accessory(accessoryIdPick, accessoryAmount, txtAccessoryName.Text,
                                                     txtAccessoryDescription.Text, accessoryPrice, txtAcessoryType.Text);
                try
                {
                    AccessoryManager.UpdateAccessory(accessory);
                    ShowAccessory(AccessoryManager.GetAll(), lbAccessory);
                    MessageBox.Show("Accessory was updated successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLoadAccessory_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Accessory accessory in AccessoryManager.GetAll())
                {
                    if (accessory.Id == Convert.ToInt32(txtAccessoryIdPick.Text))
                    {
                        txtAccessoryName.Text = accessory.Name;
                        txtAcessoryType.Text = accessory.Type;
                        txtAccessoryAmount.Text = accessory.Amount.ToString();
                        txtAccessoryDescription.Text = accessory.Description;
                        nudAcessoryPrice.Text = accessory.Price.ToString();
                        return;
                    }
                }
                MessageBox.Show("There are no accessories with the given ID!");
            }
            catch (Exception)
            {
                MessageBox.Show("Enter ID first");
            }




        }

        private void btnDeleteAccessory_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbAccessory.SelectedItem != null)
                {
                    foreach (Accessory accessory in AccessoryManager.GetAll())
                    {
                        if (AccessoryManager.AccessoryInfo(accessory) == lbAccessory.SelectedItem.ToString())
                        {
                            AccessoryManager.DeleteAccessory(Convert.ToInt32(txtAccessoryIdPick.Text));
                            MessageBox.Show("Accessory removed successfully");
                            ShowAccessory(AccessoryManager.GetAll(), lbAccessory);
                        }

                    }

                }
                else
                {
                    MessageBox.Show("please select an accessory you would like to remove from the list box");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void ShowAccessory(List<Accessory> accessories, ListBox lbAccessories)
        {
            lbAccessories.Items.Clear();
            foreach (Accessory accessory in accessories)
            {
                lbAccessories.Items.Add(AccessoryManager.AccessoryInfo(accessory));
                txtAccessoryName.Text = "";
                txtAccessoryDescription.Text = "";
                txtAcessoryType.Text = "";
                txtAccessoryAmount.Text = "";
                nudAcessoryPrice.Text = "";

            }
        }

     
    }
}
