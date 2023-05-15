using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using DataAccessLayer.Repositories;

namespace ManagmentOfProducts.Forms
{
    public partial class WineCellersForm : Form
    {
        IWineCellerManager wineCellerManager;

        public WineCellersForm()
        {
            InitializeComponent();
            wineCellerManager = new WineCellerManagment(new WineCellerRepo());
            ShowWineCellar(wineCellerManager.GetAll(), lbWineCeller);

        }

        private void btnAddWineCeller_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWineCellerName.Text) || string.IsNullOrWhiteSpace(txtWineCellerYC.Text)
                 || string.IsNullOrWhiteSpace(txtWineCellerWS.Text) || string.IsNullOrWhiteSpace(txtWineCellerEmail.Text)
                 || string.IsNullOrWhiteSpace(txtWineCellerRegion.Text) || string.IsNullOrWhiteSpace(txtWineCellerCountry.Text))
            {
                MessageBox.Show("Please fill in all fields to add a new wine cellar.");
                return;
            }

            WineCeller wineCeller = new WineCeller(txtWineCellerName.Text, Convert.ToInt32(txtWineCellerYC.Text),
                txtWineCellerWS.Text, txtWineCellerEmail.Text, txtWineCellerRegion.Text, txtWineCellerCountry.Text);
            try
            {
                wineCellerManager.AddWineCeller(wineCeller);
                ShowWineCellar(wineCellerManager.GetAll(), lbWineCeller);
                MessageBox.Show("Wine Celler was added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteWineCeller_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbWineCeller.SelectedItem != null)
                {
                    foreach (WineCeller wineCeller in wineCellerManager.GetAll())
                    {
                        if (wineCellerManager.WineCellerInfo(wineCeller) == lbWineCeller.SelectedItem.ToString())
                        {


                            wineCellerManager.DeleteWineCeller(Convert.ToInt32(txtWineCellerIdPicker.Text));
                            MessageBox.Show("Wine Cellar removed successfully");
                            ShowWineCellar(wineCellerManager.GetAll(), lbWineCeller);
                        }

                    }
                   
                }
                else
                {
                    MessageBox.Show("please select a wine cellar you would like to remove from the list box");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdateWineCeller_Click(object sender, EventArgs e)
        {

            WineCeller wineCeller = new WineCeller(Convert.ToInt32(txtWineCellerIdPicker.Text), txtWineCellerName.Text, Convert.ToInt32(txtWineCellerYC.Text), txtWineCellerWS.Text, txtWineCellerEmail.Text, txtWineCellerRegion.Text, txtWineCellerCountry.Text);
            try
            {
                wineCellerManager.UpdateWineCeller(wineCeller);
                ShowWineCellar(wineCellerManager.GetAll(), lbWineCeller);
                MessageBox.Show("Wine cellar was updated successfully");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnLoadWineCeller_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (WineCeller wineCeller in wineCellerManager.GetAll())
                {
                    if (wineCeller.Id == Convert.ToInt32(txtWineCellerIdPicker.Text))
                    {
                        txtWineCellerName.Text = wineCeller.Name;
                        txtWineCellerEmail.Text = wineCeller.Email;
                        txtWineCellerCountry.Text = wineCeller.Country;
                        txtWineCellerRegion.Text = wineCeller.Region;
                        txtWineCellerWS.Text = wineCeller.WineStyle;
                        txtWineCellerYC.Text = wineCeller.YearCreated.ToString();
                        return;
                    }
                }
                MessageBox.Show("There are no wine cellars with the given ID!");
            }
            catch (Exception)
            {
                MessageBox.Show("Enter ID first");
            }
        }

        private void txtWineCellerIdPicker_TextChanged(object sender, EventArgs e)
        {
            getFilteredWC(txtWineCellerIdPicker.Text);
        }


        //#Extra metthods 
        public void getFilteredWC(string filter)
        {
            List<WineCeller> filteredWineCellar = new List<WineCeller>();
            foreach (WineCeller wineCeller in wineCellerManager.GetAll())
            {
                if (wineCeller.Name.Contains(filter))
                {
                    filteredWineCellar.Add(wineCeller);
                }
                else if (wineCeller.Id.ToString().Contains(filter))
                {
                    filteredWineCellar.Add(wineCeller);
                }
            }
            ShowWineCellar(filteredWineCellar, lbWineCeller);
        }



        public void ShowWineCellar(List<WineCeller> wineCellers, ListBox listBoxWineCeller)
        {
            listBoxWineCeller.Items.Clear();
            foreach (WineCeller wineCeller in wineCellers)
            {
                listBoxWineCeller.Items.Add(wineCellerManager.WineCellerInfo(wineCeller));
                txtWineCellerName.Text = "";
                txtWineCellerRegion.Text = "";
                txtWineCellerCountry.Text = "";
                txtWineCellerEmail.Text = "";
                txtWineCellerWS.Text = "";
                txtWineCellerYC.Text = "";


            }
        }


    }


}
