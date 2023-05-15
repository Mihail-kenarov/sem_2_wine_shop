using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
    public class AccessoryManager : IAccessoryManager
    {
        IAccessoryRepo accessoryRepoInterface;

        public AccessoryManager(IAccessoryRepo accessoryRepoInterface)
        {
            this.accessoryRepoInterface = accessoryRepoInterface;
        }


  
        public void AddAccessory(Accessory accessory)
        {
            accessoryRepoInterface.Create(accessory);
        }

        public void DeleteAccessory(int accessory_id)
        {
            accessoryRepoInterface.Delete(accessory_id);
        }

        public List<Accessory> GetAll()
        {
            return accessoryRepoInterface.GetAll();
        }

        public void UpdateAccessory(Accessory accessory)
        {
            accessoryRepoInterface.Update(accessory);
        }

        public string AccessoryInfo(Accessory accessory)
        {
            return $"ID: {accessory.Id}, Name: {accessory.Name}, Type: {accessory.Type}";
        }
    }
}
