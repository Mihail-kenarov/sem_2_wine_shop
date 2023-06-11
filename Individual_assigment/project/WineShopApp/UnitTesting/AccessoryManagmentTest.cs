using BusinessLogic.Entities;
using BusinessLogic.Managers;
using DataAccessLayer.Repositories.FakeRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class AccessoryManagmentTest
    {
        private FakeAccessoryRepo _accessoryRepo;
        private AccessoryManager _accessoryManager;

        [TestInitialize]
        public void Initialize()
        {
            _accessoryRepo = new FakeAccessoryRepo();
            _accessoryManager = new AccessoryManager(_accessoryRepo);
        }

        [TestMethod]
        public void AddAccessory()
        {
            // Arrange
            Accessory accessory = new Accessory(4, 5, "Decanter", "Beautifully designed", 49.99, "Clear");

            // Act
            _accessoryManager.AddAccessory(accessory);

            // Assert
            CollectionAssert.Contains(_accessoryRepo.GetAll(), accessory);
        }

        [TestMethod]
        public void DeleteAccessory()
        {
            // Arrange
            int accessoryIdToDelete = 1;

            // Act
            _accessoryManager.DeleteAccessory(accessoryIdToDelete);

            // Assert
            Assert.IsNull(_accessoryRepo.GetById(accessoryIdToDelete));
        }

        [TestMethod]
        public void GetAllAccessories()
        {
            // Act
            List<Accessory> allAccessories = _accessoryManager.GetAll();

            // Assert
            Assert.AreEqual(3, allAccessories.Count);
            CollectionAssert.AllItemsAreNotNull(allAccessories);
        }

        [TestMethod]
        public void UpdateAccessory()
        {
            // Arrange
            Accessory accessoryToUpdate = new Accessory(1, 10, "Wine Glass", "Romantic and new edition", 29.99, "Clear");

            // Act
            _accessoryManager.UpdateAccessory(accessoryToUpdate);

            // Assert
            Accessory updatedAccessory = _accessoryRepo.GetById(accessoryToUpdate.Id);
            Assert.IsNotNull(updatedAccessory);
            Assert.AreEqual(accessoryToUpdate.Amount, updatedAccessory.Amount);
            Assert.AreEqual(accessoryToUpdate.Name, updatedAccessory.Name);
            Assert.AreEqual(accessoryToUpdate.Description, updatedAccessory.Description);
            Assert.AreEqual(accessoryToUpdate.Price, updatedAccessory.Price);
            Assert.AreEqual(accessoryToUpdate.Type, updatedAccessory.Type);
        }















    }
}
