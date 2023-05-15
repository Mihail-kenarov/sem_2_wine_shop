using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using DataAccessLayer.Repositories;
using System.Diagnostics;
using System.Drawing;

namespace ManagmentOfProducts.Forms
{

    public partial class WinesForm : Form
    {
        IWineCellerManager WineCellerManager;
        IWineManager WineManagment;
        public WinesForm()
        {
            InitializeComponent();
            WineManagment = new WineManager(new WineRepo());
            WineCellerManager = new WineCellerManagment(new WineCellerRepo());
            ShowWine(WineManagment.GetAll(), lbAddWine);
            ShowWine(WineManagment.GetAll(), lbWineUpdate);
            ShowWineCellar(WineCellerManager.GetAll(), lbWineCellerChoice);
        }

        private void btnAddWine_Click(object sender, EventArgs e)
        {


            Wine wine;
            if (string.IsNullOrWhiteSpace(txtAddWineAmount.Text) || string.IsNullOrWhiteSpace(txtAddWineBottleSize.Text)
             || string.IsNullOrWhiteSpace(txtAddWineClassification.Text) || string.IsNullOrWhiteSpace(txtAddWineDescription.Text)
             || string.IsNullOrWhiteSpace(txtAddWineName.Text) || string.IsNullOrWhiteSpace(txtAddWinePhotoPath.Text)
             || string.IsNullOrWhiteSpace(txtAddWineRegion.Text) || string.IsNullOrWhiteSpace(txtAddWineSortGrape.Text))
            {
                MessageBox.Show("Please fill in all fields to add a new wine.");
                return;
            }

            if (lbWineCellerChoice.SelectedIndex == -1)
            {
                MessageBox.Show("You have not selected a wine cellar");
            }
            else
            {

                WineCeller wineCeller = GetSelectedWineCeller(WineCellerManager.GetAll(), lbWineCellerChoice);
                wine = new Wine(Convert.ToInt32(txtAddWineAmount.Text), txtAddWineName.Text, Convert.ToDouble(nudAddWinePrice.Text),
                txtAddWineRegion.Text, txtAddWineClassification.Text, txtAddWineSortGrape.Text,
                Convert.ToDouble(nudAddWineAlcohol.Text), Convert.ToDouble(nudAddWineET.Text), Convert.ToInt32(txtAddWineBottleSize.Text), wineCeller,
                txtAddWinePhotoPath.Text,
                txtAddWineDescription.Text);

                try
                {
                    WineManagment.AddWine(wine, wineCeller);
                    ShowWineCellar(WineCellerManager.GetAll(), lbWineCellerChoice);
                    ShowWine(WineManagment.GetAll(), lbAddWine);
                    ShowWine(WineManagment.GetAll(), lbWineUpdate);
                    MessageBox.Show("Wine was added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public void ShowWine(List<Wine> wines, ListBox lbWinesBox)
        {
            lbWinesBox.Items.Clear();
            foreach (Wine wine in wines)
            {
                lbWinesBox.Items.Add(WineManagment.WineInfo(wine));
            }
            txtAddWineAmount.Text = "";
            txtAddWineBottleSize.Text = "";
            txtAddWineClassification.Text = "";
            txtAddWineDescription.Text = "";
            txtAddWineName.Text = "";
            txtAddWinePhotoPath.Text = "";
            txtAddWineRegion.Text = "";
            txtAddWineSortGrape.Text = "";
            nudAddWineAlcohol.Text = "";
            nudAddWineET.Text = "";
            nudAddWinePrice.Text = "";
            txtUpdateWineAmount.Text = "";
            txtUpdateWineBottleSize.Text = "";
            txtUpdateWineClassification.Text = "";
            txtUpdateWineDescription.Text = "";
            txtUpdateWineName.Text = "";
            txtUpdateWineRegion.Text = "";
            txtUpdateWineSortGrape.Text = "";
            nudUpdateWineAlcohol.Text = "";
            nudUpdateWineET.Text = "";
            nudUpdateWinePrice.Text = "";
        }

        public void ShowWineCellar(List<WineCeller> wineCellers, ListBox listBoxWineCeller)
        {
            listBoxWineCeller.Items.Clear();
            foreach (WineCeller wineCeller in wineCellers)
            {
                listBoxWineCeller.Items.Add(WineCellerManager.WineCellerInfo(wineCeller));
            }

        }

        private WineCeller GetSelectedWineCeller(List<WineCeller> wineCellers, ListBox listBoxWineCeller)
        {
            WineCeller selectedWC = null;
            foreach (WineCeller wineCeller in wineCellers)
            {
                if (WineCellerManager.WineCellerInfo(wineCeller) == listBoxWineCeller.SelectedItem.ToString())
                {
                    selectedWC = wineCeller;
                    break;
                }
            }
            return selectedWC;
        }

        private void lbWineUpdate_DoubleClick(object sender, EventArgs e)
        {

            foreach (Wine wine in WineManagment.GetAll())
            {
                if (WineManagment.WineInfo(wine) == lbWineUpdate.Text)
                {
                    txtUpdateWineAmount.Text = (wine.Amount).ToString();
                    txtUpdateWineBottleSize.Text = wine.Name;
                    txtUpdateWineID.Text = wine.Id.ToString();
                    txtUpdateWineClassification.Text = wine.Classification;
                    txtUpdateWineDescription.Text = wine.Description;
                    txtUpdateWineName.Text = wine.Name;
                    txtUpdateWineRegion.Text = wine.Region;
                    txtUpdateWineSortGrape.Text = wine.SortGrape;
                    nudUpdateWineAlcohol.Text = (wine.Alcohol).ToString();
                    nudUpdateWineET.Text = (wine.EnjoyableTemp).ToString();
                    nudUpdateWinePrice.Text = (wine.Price).ToString();
                    return;
                }
            }
        }

        private void btnUpdateWine_Click(object sender, EventArgs e)
        {
            Wine wine = new Wine(Convert.ToInt32(txtUpdateWineAmount), txtUpdateWineName.Text, Convert.ToDouble(nudUpdateWinePrice.Text), txtUpdateWineRegion.Text, txtUpdateWineClassification.Text, txtUpdateWineSortGrape.Text,
            Convert.ToDouble(nudUpdateWineAlcohol.Text), Convert.ToDouble(nudUpdateWineET.Text), Convert.ToInt32(txtUpdateWineBottleSize.Text), txtUpdateWinePhotoPath.Text, txtUpdateWineDescription.Text);
            try
            {
                WineManagment.UpdateWine(wine);
                MessageBox.Show("Wine was updated successfully");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteWine_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbWineUpdate.SelectedItem != null)
                {
                    foreach (Wine wine in WineManagment.GetAll())
                    {
                        if (WineManagment.WineInfo(wine) == lbWineUpdate.SelectedItem.ToString())
                        {
                            WineManagment.DeleteWine(Convert.ToInt32(txtUpdateWineID.Text));
                            ShowWine(WineManagment.GetAll(), lbWineUpdate);
                            ShowWine(WineManagment.GetAll(), lbAddWine);
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
    }
}

