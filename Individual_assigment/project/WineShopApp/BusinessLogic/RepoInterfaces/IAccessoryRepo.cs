using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.RepoInterfaces
{   
    public interface IAccessoryRepo
    {
        void Create(Accessory accessory);

        List<Accessory> GetAll();

        void Update(Accessory accessory);

        void Delete(int id);

        Accessory GetById(int accessory_id);

        Accessory GetByName(string Name);

    }
}
