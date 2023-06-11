using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.RepoInterfaces
{
    public interface IOrderRepo
    {
        void Create(Order order);
        List<Order> GetAll();
        void UpdateAsFulFilled(Order order);
        void Delete(int id);
        Order GetById(int order_id);
        List<Product> GetProductsForOrder(int orderId);
        void PutProductToOrder(int product_id, int order_id);
        Order GetOrderByClientID(int client_id);
        void FinishOrder(Order order);
    }
}
