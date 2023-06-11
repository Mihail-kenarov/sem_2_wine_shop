using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ManagerInterfaces
{
    public interface IProductManager
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int product_id);
        List<Product> GetAll();
        string ProductInfo(Product product);
        Product GetByID(int product_id);
        
    }
}
