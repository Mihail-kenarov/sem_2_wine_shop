using BusinessLogic.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WineShopApp.Entities
{
    public class OrderDTO
    {
        private int iD;
        private double totalPrice;
        private List<Product> products;
        private Client client;
        private string location;

        public OrderDTO(Order order)
        {
            iD = order.Id;
            totalPrice = order.TotalPrice;
            products = order.Products;
            client = order.Client;
            location = order.Location;

        }

        public int ID { get => iD; set => iD = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public List<Product> Products { get => products; set => products = value; }
        public Client Client { get => client; set => client = value; }
        public string Location { get => location; set => location = value; }


    }
}
