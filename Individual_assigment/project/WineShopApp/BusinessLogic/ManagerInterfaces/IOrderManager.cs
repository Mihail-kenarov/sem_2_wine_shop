using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ManagerInterfaces
{
    public interface IOrderManager
    {

        void Create(Order order);
        void UpdateAsFulFilled(Order order);
        List<Order> GetAll();
        Order GetByID(int order_id);
        double CalculateTotalPrice(Order order);
        void PutProductToOrder(Product product,Order order);
        List<string> PrintProductsForProduct(Order order);
        Order GetOrderByClient(Client client);
        void FinishOrder(Order order);

    }
}
