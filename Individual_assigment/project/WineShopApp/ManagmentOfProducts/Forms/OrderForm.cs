using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using BusinessLogic.RepoInterfaces;
using DataAccessLayer.Repositories;
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
    public partial class OrderForm : Form
    {
        IOrderManager OrderManager;


        public OrderForm()
        {
            InitializeComponent();
            IClientRepo clientRepo = new ClientRepo();
            OrderManager = new OrderManager(new OrderRepo(clientRepo));
            ShowOrders(OrderManager.GetAll(), lbOrders);
        }

        private void btnFulfillOrder_Click(object sender, EventArgs e)
        {
            if (lbOrders.SelectedIndex == -1)
            {
                MessageBox.Show("You have not selected an order to fulfill!");
            }
            else
            {
                Order order = lbOrders.SelectedItem as Order;
                OrderManager.UpdateAsFulFilled(order);
                MessageBox.Show("Order has been fulfilled!");
                ShowOrders(OrderManager.GetAll(), lbOrders);
            }
        }

        public void ShowOrders(List<Order> orders, ListBox lbOrders)
        {

            lbOrders.Items.Clear();
            foreach (Order order in orders)
            {
                if (order.Status == "finished")
                {
                    lbOrders.Items.Add(order);
                }

            }
        }

        private void lbOrders_DoubleClick(object sender, EventArgs e)
        {
            Order order = lbOrders.SelectedItem as Order;
            MessageBox.Show(order.GetProductsAsString());
        }
    }
}
