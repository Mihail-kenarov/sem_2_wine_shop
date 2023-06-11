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
    public class ProductCollectionManager : IPCManager
    {
        IPCRepo pCRepo;

        public ProductCollectionManager(IPCRepo pCRepo) 
        {
            this.pCRepo = pCRepo;
        }

        public void Add(ProductsCollection productsCollection, List<Accessory> accessories, List<Wine> wines)
        {
            pCRepo.Create(productsCollection, accessories, wines);
        }

        public void Delete(int pc_id)
        {
            pCRepo.Delete(pc_id);
        }

        public List<ProductsCollection> GetAll()
        {
            return pCRepo.GetAll();
        }

        public ProductsCollection GetByID(int pc_id)
        {
            return pCRepo.GetById(pc_id);
        }

        public string ProductInfo(ProductsCollection productsCollection)
        {
            return $"ID: {productsCollection.Id}, Name: {productsCollection.Name}";
        }

        public void Update(ProductsCollection productsCollection)
        {
            pCRepo.Update(productsCollection);

        }

       




    }
}
