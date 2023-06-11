using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using DataAccessLayer.Repositories;

namespace ManagmentOfProducts.Forms
{
    public partial class ProductsCollectionForm : Form
    {
        IWineManager wineManager;
        IAccessoryManager accessoryManager;
        IPCManager pCManager;
        int WineCount = 0;
        int AccCount = 0;


        public ProductsCollectionForm()
        {
            InitializeComponent();
            wineManager = new WineManager(new WineRepo());
            accessoryManager = new AccessoryManager(new AccessoryRepo());
            pCManager = new ProductCollectionManager(new ProductCollectionRepo());
            ShowAll(wineManager.GetAll(), accessoryManager.GetAll(), pCManager.GetAll(), lbWineChoicePC, lbAccessoryChoicePC, lbProductCollections);


        }

        private void btnAddWineToPC_Click(object sender, EventArgs e)
        {
            if (WineCount < 2)
            {
                if (lbWineChoicePC.SelectedIndex == -1)
                {
                    MessageBox.Show("You have not selected a wine to add");
                }
                else
                {

                    lbChosenProducts.Items.Add(lbWineChoicePC.SelectedItem);
                    WineCount++;
                }
            }
            else
            {
                MessageBox.Show("Some other problem occured");
            }

        }

        private void btnAddAccToPC_Click(object sender, EventArgs e)
        {
            if (AccCount < 2)
            {
                if (lbAccessoryChoicePC.SelectedIndex == -1)
                {
                    MessageBox.Show("You have not selected an accessory to add");
                }
                else
                {

                    lbChosenProducts.Items.Add(lbAccessoryChoicePC.SelectedItem);
                    AccCount++;
                }
            }
            else
            {
                MessageBox.Show("Some other problem occured");
            }
        }


        public void ShowAll(List<Wine> wines, List<Accessory> accessories, List<ProductsCollection> collections, ListBox lbWinesBox, ListBox lbAccessories, ListBox lbCollections)
        {
            lbWinesBox.Items.Clear();
            foreach (Wine wine in wines)
            {
                lbWinesBox.Items.Add(wine);


                lbAccessories.Items.Clear();
                foreach (Accessory accessory in accessories)
                {
                    lbAccessories.Items.Add(accessory);
                }

                lbCollections.Items.Clear();
                foreach (ProductsCollection productsCollection in collections)
                {
                    lbCollections.Items.Add(productsCollection);
                }

                txtAddCollectionAmount.Text = "";
                txtAddCollectionName.Text = "";
                txtCollectionDescription.Text = "";
                txtCollectionEvent.Text = "";
                txtCollectionType.Text = "";
                nudCollectionPrice.Text = "";
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (lbChosenProducts.SelectedIndex == -1)
            {
                MessageBox.Show("You have not selected an item to remove");
            }
            else
            {
                Product selectedItem = lbChosenProducts.SelectedItem as Product;
                if (selectedItem is Wine)
                {
                    lbChosenProducts.Items.Remove(lbChosenProducts.SelectedItem);
                    WineCount--;
                }
                if (selectedItem is Accessory)
                {
                    lbChosenProducts.Items.Remove(lbChosenProducts.SelectedItem);
                    AccCount--;
                }

            }
        }


        private void btnAddPC_Click(object sender, EventArgs e)
        {
            ProductsCollection productsCollection;
            if (string.IsNullOrEmpty(txtAddCollectionName.Text) || string.IsNullOrEmpty(txtAddCollectionAmount.Text)
                || string.IsNullOrEmpty(txtCollectionDescription.Text) || string.IsNullOrEmpty(txtCollectionEvent.Text)
                || string.IsNullOrEmpty(txtCollectionType.Text) || string.IsNullOrEmpty(nudCollectionPrice.Text))
            {
                MessageBox.Show("Please fill in all fields to add a new Collection.");
                return;
            }
            if (lbChosenProducts.Items.Count == 0)
            {
                MessageBox.Show("Please add products for a collection");
                return;
            }

            List<Accessory> accessories = new List<Accessory>();
            List<Wine> wines = new List<Wine>();

            foreach (Product product in lbChosenProducts.Items)
            {
                if (product is Wine)
                {
                    Wine wine = (Wine)product;
                    wines.Add(wine);
                }
                else if (product is Accessory)
                {
                    Accessory accessory = (Accessory)product;
                    accessories.Add(accessory);
                }
            }

            productsCollection = new ProductsCollection(int.Parse(txtAddCollectionAmount.Text), txtAddCollectionName.Text, txtCollectionDescription.Text, Convert.ToDouble(nudCollectionPrice.Text), accessories, wines, txtCollectionEvent.Text);

            try
            {
                pCManager.Add(productsCollection, accessories, wines);
                ShowAll(wineManager.GetAll(), accessoryManager.GetAll(), pCManager.GetAll(), lbWineChoicePC, lbAccessoryChoicePC, lbProductCollections);
                MessageBox.Show("Collection was added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}

