using BusinessLogic.Entities;
using BusinessLogic.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.FakeRepos
{
    public class FakeAccessoryRepo : IAccessoryRepo
    {
        private readonly List<Accessory> _accessories;

        public FakeAccessoryRepo()
        {
            _accessories = new List<Accessory>
        {
            new Accessory(1, 10, "Wine Glass", "Romantic and new", 19.99, "Clear"),
            new Accessory(2, 5,  "Wine Bottle", "Perfect for longer storage of previous wines", 149.99, "Clear"),
            new Accessory(3, 20, "Wine opener", "A must in this shop", 19.99, "Essential"),   
        };
        }

        public Accessory GetById(int id)
        {
            return _accessories.FirstOrDefault(a => a.Id == id);
        }

        public void Create(Accessory accessory)
        {
            _accessories.Add(accessory);
        }

        public List<Accessory> GetAll()
        {
            return _accessories;
        }

        public void Update(Accessory accessory)
        {
            var existingAccessory = _accessories.FirstOrDefault(a => a.Id == accessory.Id);
            if (existingAccessory != null)
            {
                existingAccessory.Amount = accessory.Amount;
                existingAccessory.Name = accessory.Name;
                existingAccessory.Description = accessory.Description;
                existingAccessory.Price = accessory.Price;
                existingAccessory.Type = accessory.Type;
            }
        }

        public void Delete(int id)
        {
            var accessoryToRemove = _accessories.FirstOrDefault(a => a.Id == id);
            if (accessoryToRemove != null)
            {
                _accessories.Remove(accessoryToRemove);
            }
        }

        public Accessory GetByName(string Name)
        {
            return _accessories.FirstOrDefault(u => u.Name == Name);
           
        }
    }
}
