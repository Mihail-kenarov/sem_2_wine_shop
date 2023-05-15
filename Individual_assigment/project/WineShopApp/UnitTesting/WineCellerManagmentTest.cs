using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using DataAccessLayer.Repositories.FakeRepos;

namespace UnitTesting
{
    [TestClass]
    public class WineCellerManagmentTest
    {
        private FakeWineCellerRepo _wcRepo;
        private WineCellerManagment _wcManagment;


        [TestMethod]
        public void Initialize()
        {
            _wcRepo = new FakeWineCellerRepo();
            _wcManagment = new WineCellerManagment(_wcRepo);
        }

        [TestMethod]
        public void GetAllWC()
        {
            // Arrange
            int expectedCount = 3;

            // Act
            List<WineCeller> result = _wcManagment.GetAll();

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestMethod]
        public void CreateWC()
        {
            // Arrange
            int initialCount = _wcRepo.GetAll().Count;
            WineCeller newWineCeller = new WineCeller(4, "Alex", 1980, "Elegant", "alex@gmail.com", "South", "Italy");

            // Act
            _wcManagment.AddWineCeller(newWineCeller);

            // Assert
            List<WineCeller> wineCellers = _wcRepo.GetAll();
            Assert.AreEqual(initialCount + 1, wineCellers.Count);
            Assert.IsTrue(wineCellers.Contains(newWineCeller));
        }


        [TestMethod]
        public void GetWCByID()
        {
            // Arrange
            int idToGet = 1;

            // Act
            WineCeller result = _wcManagment.GetWineCellerById(idToGet);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(idToGet, result.Id);
        }

        [TestMethod]
        public void GetWCByName()
        {
            // Arrange
            string nameToGet = "Bob";

            // Act
            WineCeller result = _wcManagment.GetWineCellerByName(nameToGet);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(nameToGet, result.Name);
        }

        public void UpdateWC()
        {
            // Arrange
            WineCeller wineCellerToUpdate = _wcRepo.GetByIdWineCeller(1);
            wineCellerToUpdate.Name = "Updated Name";
            wineCellerToUpdate.YearCreated = 2000;
            wineCellerToUpdate.WineStyle = "Updated Style";
            wineCellerToUpdate.Email = "updated@email.com";
            wineCellerToUpdate.Region = "Updated Region";
            wineCellerToUpdate.Country = "Updated Country";

            // Act
            _wcManagment.UpdateWineCeller(wineCellerToUpdate);

            // Assert
            WineCeller updatedWineCeller = _wcRepo.GetByIdWineCeller(1);
            Assert.AreEqual(wineCellerToUpdate.Name, updatedWineCeller.Name);
            Assert.AreEqual(wineCellerToUpdate.YearCreated, updatedWineCeller.YearCreated);
            Assert.AreEqual(wineCellerToUpdate.WineStyle, updatedWineCeller.WineStyle);
            Assert.AreEqual(wineCellerToUpdate.Email, updatedWineCeller.Email);
            Assert.AreEqual(wineCellerToUpdate.Region, updatedWineCeller.Region);
            Assert.AreEqual(wineCellerToUpdate.Country, updatedWineCeller.Country);
        }


        [TestMethod]
        public void DeleteWC()
        {
            // Arrange
            int idToDelete = 2;
            WineCeller wineCellerToDelete = _wcRepo.GetByIdWineCeller(idToDelete);

            // Act
            _wcManagment.DeleteWineCeller(idToDelete);

            // Assert
            Assert.IsNull(_wcRepo.GetByIdWineCeller(idToDelete));
            CollectionAssert.DoesNotContain(_wcRepo.GetAll(), wineCellerToDelete);
        }








    }
}