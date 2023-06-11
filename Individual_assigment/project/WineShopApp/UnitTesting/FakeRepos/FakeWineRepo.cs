using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace DataAccessLayer.Repositories.FakeRepos
{
    public class FakeWineRepo : IWineRepo
    {
        public List<Wine> _wines { get; set; }

        public FakeWineRepo()
        {
            WineCeller wc1 = new WineCeller(1, "Bob", 1955, "Modern", "bob@gmail.com", "North", "Framce");
            WineCeller wc2 = new WineCeller(2, "Tom", 1955, "Classic", "Tom@gmail.com", "North", "Macedoni");
            WineCeller wc3 = new WineCeller(3, "Dan", 1955, "Unique", "Dan@gmail.com", "North", "Germany");
            _wines = new List<Wine>()
            {
            new Wine(1, 15,"Chardone",50.50,"France","Red Wine", "Malbec",12.50,14.50,750,wc1,"photo.png","Excellent for desserts"),
            new Wine(2, 10, "Cabernet Sauvignon", 30.50, "France", "Red Wine", "Malbec", 12.50, 14.50, 750, wc2, "photo.png", "Excellent for desserts"),
            new Wine(3, 20, "Pinot Noir", 25.50, "France", "Red Wine", "Malbec", 12.50, 14.50, 750, wc3, "photo.png", "Excellent for desserts")

        };
        }




        public void Create(Wine wine, WineCeller wineCeller)
        {
            _wines.Add(wine);
        }

        public void Delete(int id)
        {
            var wine = GetById(id);
            if (wine != null)
            {
                _wines.Remove(wine);
            }
        }

        public List<Wine> GetAll()
        {
            return _wines;
        }

        public Wine GetById(int id)
        {
            return _wines.FirstOrDefault(w => w.Id == id);
        }

        public void Update(Wine wine)
        {
            var wineToUpdate = GetById(wine.Id);
            if (wineToUpdate != null)
            {
                wineToUpdate.Amount = wine.Amount;
                wineToUpdate.Name = wine.Name;
                wineToUpdate.Price = wine.Price;
                wineToUpdate.Region = wine.Region;
                wineToUpdate.Classification = wine.Classification;
                wineToUpdate.SortGrape = wine.SortGrape;
                wineToUpdate.Alcohol = wine.Alcohol;
                wineToUpdate.EnjoyableTemp = wine.EnjoyableTemp;
                wineToUpdate.BottleSize = wine.BottleSize;
                wineToUpdate.WineCeller = wine.WineCeller;
                wineToUpdate.PhotoPath = wine.PhotoPath;
                wineToUpdate.Description = wine.Description;

            }
        }

       
    }
}
