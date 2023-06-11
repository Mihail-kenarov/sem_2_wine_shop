using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
    public class OrderManager :IOrderManager
    {

        IOrderRepo orderRepo;

        public OrderManager(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public void Create(Order order)
        {
            order.TotalPrice = CalculateTotalPrice(order); 
            orderRepo.Create(order);
        }

        public void Delete(int order_id)
        {
            orderRepo.Delete(order_id);
        }

        public List<Order> GetAll()
        {
            return orderRepo.GetAll();
        }

        public Order GetByID(int order_id)
        {
            return orderRepo.GetById(order_id);
        }

        public void UpdateAsFulFilled(Order order)
        {
            orderRepo.UpdateAsFulFilled(order);
        }

       

        public double CalculateTotalPrice(Order order)
        {
            double totalPrice = 0;
            if (order.Products != null)
            {
                foreach (Product product in order.Products)
                {
                    totalPrice += product.Price;
                }
                if(order.Client.Subscribtion == "premium")
                {
                    totalPrice = totalPrice - totalPrice * 0.15;
                }
            }
       
            return totalPrice;

        }

        public void PutProductToOrder(Product product, Order order)
        {
            orderRepo.PutProductToOrder(product.Id,order.Id);
        }

        public Order GetOrderByClient(Client client)
        {
            return orderRepo.GetOrderByClientID(client.Id);
        }

       

        public void FinishOrder(Order order)
        {
            orderRepo.FinishOrder(order);
        }

        public List<string> PrintProductsForProduct(Order order)
        {
            List<string> products = new List<string>();
            foreach(Product product in order.Products)
            {
                products.Add(product.Name);
            }
            return products;
        }


    }
}
