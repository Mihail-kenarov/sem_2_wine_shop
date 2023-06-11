using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ManagerInterfaces
{
    public interface IPCManager
    {
        void Add(ProductsCollection productsCollection,List<Accessory> accessories,List<Wine> wines);
        void Update(ProductsCollection productsCollection);
        void Delete(int pc_id);
        List<ProductsCollection> GetAll();
        string ProductInfo(ProductsCollection productsCollection);
        ProductsCollection GetByID(int pc_id);







    }
}
