using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.RepoInterfaces
{
    public interface IPCRepo
    {

            
        void Create(ProductsCollection productsCollection,List<Accessory> accessories,List<Wine> wines);
        
        List<ProductsCollection> GetAll();

        void Update(ProductsCollection productsCollection);

        void Delete(int id);
        ProductsCollection GetById(int id);

      

    }

    
}
