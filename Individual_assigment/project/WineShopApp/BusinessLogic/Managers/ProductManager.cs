using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
    public class ProductManager : IProductManager
    {

        private IProductRepo productRepo;


        public ProductManager(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        
        public void Add(Product product)
        {
            productRepo.Create(product);
        }

        public void Delete(int product_id)
        {
            productRepo.Delete(product_id);
        }

        public List<Product> GetAll()
        {
            return productRepo.GetAll();
        }

        public Product GetByID(int product_id)
        {
            return productRepo.GetById(product_id);
        }
        public void Update(Product product)
        {
            productRepo.Update(product);
        }

        public string ProductInfo(Product product)
        {
           return $"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}";
        }

        public List<Product> GetAllProductsAndWines()
        {
            return productRepo.GetAllProductsAndWines();
        }

    }
}
