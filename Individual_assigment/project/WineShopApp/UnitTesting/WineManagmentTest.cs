using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
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
    public class WineManagmentTest
    {
        private FakeWineRepo _wineRepo;
        private WineManager _wineManager;

        [TestInitialize]
        public void Initialise()
        {
            _wineRepo = new FakeWineRepo();
            _wineManager = new WineManager(_wineRepo);
        }


        [TestMethod]
        public void CreateWine()
        {
            // Arrange
            Wine wine = new Wine(4, 18, "Sauvignon Blanc", 25.50, "Chile", "White Wine", "Sauvignon Blanc", 11.50, 13.50, 750, null, "photo.png", "Excellent for fish dishes");

            // Act
            _wineManager.AddWine(wine, null);

            // Assert
            CollectionAssert.Contains(_wineRepo.GetAll(), wine);
        }



        [TestMethod]
        public void DeleteWine()
        {
            // Arrange
            int wineIdToDelete = 1;

            // Act
            _wineManager.DeleteWine(wineIdToDelete);

            // Assert
            Assert.IsNull(_wineRepo.GetById(wineIdToDelete));
        }

        [TestMethod]
        public void GetAllWines()
        {
            // Act
            List<Wine> allWines = _wineManager.GetAll();

            // Assert
            Assert.AreEqual(3, allWines.Count);
            CollectionAssert.AllItemsAreNotNull(allWines);
        }

        [TestMethod]
        public void GetWineById()
        {
            // Arrange
            int wineIdToGet = 1;

            // Act
            Wine wine = _wineManager.GetWineById(wineIdToGet);

            // Assert
            Assert.IsNotNull(wine);
            Assert.AreEqual(wineIdToGet, wine.Id);
        }


        [TestMethod]
        public void UpdateWine()
        {
            // Arrange
            Wine wineToUpdate = new Wine(1, 15, "Chardonnay", 50.50, "France", "Red Wine", "Malbec", 12.50, 14.50, 750, null, "photo.png", "Excellent for desserts");

            // Act
            _wineManager.UpdateWine(wineToUpdate);

            // Assert
            Wine updatedWine = _wineRepo.GetById(wineToUpdate.Id);
            Assert.IsNotNull(updatedWine);
            Assert.AreEqual(wineToUpdate.Amount, updatedWine.Amount);
            Assert.AreEqual(wineToUpdate.Name, updatedWine.Name);
            Assert.AreEqual(wineToUpdate.Price, updatedWine.Price);
            Assert.AreEqual(wineToUpdate.Region, updatedWine.Region);
            Assert.AreEqual(wineToUpdate.Classification, updatedWine.Classification);
            Assert.AreEqual(wineToUpdate.SortGrape, updatedWine.SortGrape);
            Assert.AreEqual(wineToUpdate.Alcohol, updatedWine.Alcohol);
            Assert.AreEqual(wineToUpdate.EnjoyableTemp, updatedWine.EnjoyableTemp);
            Assert.AreEqual(wineToUpdate.BottleSize, updatedWine.BottleSize);
            Assert.AreEqual(wineToUpdate.WineCeller, updatedWine.WineCeller);
            Assert.AreEqual(wineToUpdate.PhotoPath, updatedWine.PhotoPath);
            Assert.AreEqual(wineToUpdate.Description, updatedWine);

        }

        [TestMethod]
        public void WineInfo()
        {
            // Arrange
            Wine wine = new Wine(1, 15, "Chardonnay", 50.50, "France", "Red Wine", "Malbec", 12.50, 14.50, 750, null, "photo.png", "Excellent for desserts");

            // Act
            string wineInfo = _wineManager.WineInfo(wine);

            // Assert
            string expectedWineInfo = "ID: 1, Name: Chardonnay";
            Assert.AreEqual(expectedWineInfo, wineInfo);
        }


    }
}
