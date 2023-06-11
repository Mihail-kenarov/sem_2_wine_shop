using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Order
    {
        private int id;
        private Client client;
        private List<Product> products;
        private double totalPrice;
        private string status;
        private DateTime dateTime;
        private string location;

        public Order() { }

        public Order(int order_id, Client Order_client, List<Product> Products, DateTime DateTime, double totalPrice, string Location)
        {
            id = order_id;
            client = Order_client;
            products = Products;
            TotalPrice = totalPrice;
            dateTime = DateTime;
            location = Location;   
        }


        public Order(Client Order_client, List<Product> Products, DateTime DateTime, double totalPrice, string Location)
        {

            client = Order_client;
            products = Products;
            TotalPrice = totalPrice;
            dateTime = DateTime;
            location = Location;


        }

        public int Id { get => id; set => id = value; }
        public Client Client { get => client; set => client = value; }
        public List<Product> Products { get => products; set => products = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Status { get => status; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); status = value; } }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string Location { get => location; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); location = value; } }

        public override string? ToString()
        {
            return " Id:" + this.Id + "    DateTime:"  + this.DateTime+ "     Total Price: " + this.TotalPrice + "     Location:" + this.Location ;
        }

        public string GetProductsAsString()
        {
            string result = string.Empty;
            foreach (Product product in products)
            {
                result += product.Name + "\n";
            }
            return result;
        }
    }
}
