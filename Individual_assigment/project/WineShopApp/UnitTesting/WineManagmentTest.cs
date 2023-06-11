using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using DataAccessLayer.Repositories.FakeRepos;


namespace UnitTesting
{
    [TestClass]
    public class WineManagmentTest
    {
        private FakeWineRepo _wineRepo;
        private WineManager _wineManager;
    


    [TestInitialize]
    public void SetUp()
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
        public void DeleteWineTest()
        {
            // Arrange
            int wineIdToDelete = 1;

            // Act
            _wineManager.DeleteWine(wineIdToDelete);

            // Assert
            Assert.IsNull(_wineRepo.GetById(wineIdToDelete));
        }

        [TestMethod]
        public void GetAllWinesTest()
        {
            // Arrange
            List<Wine> expectedWines = _wineRepo.GetAll();

            // Act
            List<Wine> allWines = _wineManager.GetAll();

            // Assert
            CollectionAssert.AreEqual(expectedWines, allWines);
        }

        [TestMethod]
        public void GetWineByIdTest()
        {
            // Arrange
            int wineIdToGet = 1;
            Wine expectedWine = _wineManager.GetWineById(wineIdToGet);

            // Act
            Wine wine = _wineManager.GetWineById(wineIdToGet);

            // Assert
            Assert.IsNotNull(wine);
            Assert.AreEqual(expectedWine, wine);
        }

        [TestMethod]
        public void UpdateWineTest()
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
            Assert.AreEqual(wineToUpdate.Description, updatedWine.Description);
        }

        [TestMethod]
        public void WineInfo()
        {
            // Arrange
            Wine wine = new Wine(1, 15, "Chardonnay", 50.50, "France", "Red Wine", "Malbec", 12.50, 14.50, 750, null, "photo.png", "Excellent for desserts");
            string expectedWineInfo = $"ID: {wine.Id}, Name: {wine.Name}, Price: {wine.Price}";

            // Act
            string wineInfo = _wineManager.WineInfo(wine);

            // Assert    
            Assert.AreEqual(expectedWineInfo, wineInfo);
        }



        [TestMethod]
        public void IsPriceInRangeIn()
        {
            // Arrange
            Wine wine = new Wine { Price = 15 };
            string range = "10-20";

            // Act
            bool result = _wineManager.IsPriceInRange(Convert.ToDecimal(wine.Price), range);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPriceInRangOut()
        {
            // Arrange
            decimal price = 25;
            string range = "0-10";

            // Act
            bool result = _wineManager.IsPriceInRange(price, range);

            // Assert
            Assert.IsFalse(result);
        }



        [TestMethod]
        public void GetAllByFilters_ReturnsFilteredWines_WhenFiltersMatch()
        {
            // Arrange
            var wines = new List<Wine>
        {
            new Wine { Id = 1, Name = "Chardonnay", Price = 15, BottleSize = 750 },
            new Wine { Id = 2, Name = "Merlot", Price = 25, BottleSize = 750 },
            new Wine { Id = 3, Name = "Cabernet Sauvignon", Price = 40, BottleSize = 500 }
        };
            var expectedFilteredWines = new List<Wine>
        {
            wines[0] 
           
        };
            _wineRepo._wines = wines;
            // Act
            var filteredWines = _wineManager.GetAllByFilters("Chardonnay", "10-20", 750);

            // Assert
            CollectionAssert.AreEqual(expectedFilteredWines, filteredWines);
        }




        [TestMethod]
        public void GetAllByFiltersReturnWhenNoFilters()
        {
            // Arrange
            var wines = new List<Wine>
            {
        new Wine { Id = 1, Name = "Chardonnay", Price = 15, BottleSize = 750 },
        new Wine { Id = 2, Name = "Merlot", Price = 25, BottleSize = 750 },
        new Wine { Id = 3, Name = "Cabernet Sauvignon", Price = 40, BottleSize = 500 }
            };
            _wineRepo._wines = wines;

            // Act
            var filteredWines = _wineManager.GetAllByFilters(null, "Any", 0);

            // Assert
            Assert.AreEqual(3, filteredWines.Count);
        }


        [TestMethod]
        public void GetAllByFiltersWhenSizeIsChanged()
        {
            // Arrange
            var wines = new List<Wine>
            {
            new Wine { Id = 1, Name = "Chardonnay", Price = 15, BottleSize = 750 },
            new Wine { Id = 2, Name = "Merlot", Price = 25, BottleSize = 750 },
            new Wine { Id = 3, Name = "Cabernet Sauvignon", Price = 40, BottleSize = 500 }

            };
            _wineRepo._wines = wines;

            // Act
            var filteredWines = _wineManager.GetAllByFilters(null, "Any", 750);

            // Assert
            Assert.AreEqual(2, filteredWines.Count);
        }


        [TestMethod]
        public void GetAllByFilters_ReturnsFilteredWines_WhenPriceFilterMatches()
        {
            // Arrange
            var wines = new List<Wine>
            {
        new Wine { Id = 1, Name = "Chardonnay", Price = 15, BottleSize = 750 },
        new Wine { Id = 2, Name = "Merlot", Price = 25, BottleSize = 750 },
        new Wine { Id = 3, Name = "Cabernet Sauvignon", Price = 40, BottleSize = 500 }
            };
            var expectedFilteredWines = new List<Wine>
            {
        wines[1]
            };
            _wineRepo._wines = wines;

            // Act
            var filteredWines = _wineManager.GetAllByFilters(null, "20-30", 750);

            // Assert
            CollectionAssert.AreEqual(expectedFilteredWines, filteredWines);
        }






        [TestMethod]
        public void IsBottleSizeMatchTrue()
        {
            // Arrange
            int wineBottleSize = 750;
            int desiredBottleSize = 750;

            // Act
            bool result = _wineManager.IsBottleSizeMatch(wineBottleSize, desiredBottleSize);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBottleSizeMatchFalse()
        {
            // Arrange
            int wineBottleSize = 500;
            int desiredBottleSize = 750;

            // Act
            bool result = _wineManager.IsBottleSizeMatch(wineBottleSize, desiredBottleSize);

            // Assert
            Assert.IsFalse(result);
        }

    }
}
