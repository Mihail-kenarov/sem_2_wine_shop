using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.RepoInterfaces
{
    public interface IProductRepo
    {
        void Create(Product product);

        List<Product> GetAll();

        void Update(Product product);

        void Delete(int id);

        Product GetById(int product_id);
        List<Product> GetAllProductsAndWines();
    }
}
