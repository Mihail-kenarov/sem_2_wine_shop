using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ManagerInterfaces
{
    public interface IAccessoryManager
    {
        void AddAccessory(Accessory accessory);
        void UpdateAccessory(Accessory accessory);
        void DeleteAccessory(int accessory_id);
        List<Accessory> GetAll();
        string AccessoryInfo(Accessory accessory);
        Accessory GetByID(int accessory_id);


    }
}
