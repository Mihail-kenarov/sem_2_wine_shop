using BusinessLogic.Entities;
using BusinessLogic.RepoInterfaces;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.FakeRepos
{
    public class FakeOrderRepo : IOrderRepo
    {

        public List<Order> _orders { get; set; }
        public FakeOrderRepo()
        {
            byte[] salt1 = Encryption.GenerateSalt();
            byte[] salt2 = Encryption.GenerateSalt();


            Product p1 = new Product(1, 15, "Wine Glasses", "New", 12.50);
            Product p2 = new Product(2, 15, "Vihno Verdy", "Fruity", 20.50);
            Product p3 = new Product(3, 15, "Wine Red", "Red", 25.50);

            double tp = p1.Price + p2.Price;
            double tp2 = p3.Price + p2.Price;
            double tp3 = p1.Price + p3.Price;

            string location1 = "sofia";
            string location2 = "varna";

            List<Product> products1 = new List<Product>() { p1, p2 };
            List<Product> products2 = new List<Product>() { p3, p2 };
            List<Product> products3 = new List<Product>() { p1, p3 };

            Client client = new Client(1, "username", "email", "premium", Encryption.HashPassword("john", salt1), salt1);
            Client client2 = new Client(2, "username", "email", "normal", Encryption.HashPassword("bob", salt2), salt2);

            _orders = new List<Order>()
            {
                new Order(1, client2, products1, DateTime.UtcNow, tp, location1),
                new Order(2, client, products2, DateTime.UtcNow, tp2, location2),
                new Order(3, client2, products3, DateTime.UtcNow, tp3, location1)
            };



        }


        public void Create(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return _orders;
        }

        public void UpdateAsFulFilled(Order order)
        {
            var orderToUpdate = GetById(order.Id);
            if (orderToUpdate != null)
            {
                orderToUpdate.Status = "fulfilled";
            }
        }

        public void Delete(int id)
        {
            Order deleteOrder = _orders.FirstOrDefault(u => u.Id == id);
            if (deleteOrder != null)
            {
                _orders.Remove(deleteOrder);
            }
        }

        public Order GetById(int order_id)
        {
            return _orders.FirstOrDefault(u => u.Id == order_id);
        }

        public List<Product> GetProductsForOrder(int orderId)
        {
            Order order = GetById(orderId);
            return order.Products;
            
        }

        public void PutProductToOrder(int product_id, int order_id)
        {
            Product pr = new Product(product_id, 15, "Wine Stopper", "New", 12.50);
            Order SelectedOrder = _orders.FirstOrDefault(o => o.Id == order_id);
            if (SelectedOrder != null)
            {
                SelectedOrder.Products.Add(pr);
            }


        }

        public Order GetOrderByClientID(int client_id)
        {
            Order OrderByClientID = _orders.FirstOrDefault(o => o.Client.Id == client_id);
            if (OrderByClientID != null)
            {
               return OrderByClientID;
            }
            return OrderByClientID;
        }

        public void FinishOrder(Order order)
        {
            order.Status = "finished";

        }
    }
}
