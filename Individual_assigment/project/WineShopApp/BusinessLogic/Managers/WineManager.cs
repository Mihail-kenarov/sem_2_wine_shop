using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.ManagerInterfaces;

namespace BusinessLogic.Managers
{
    public class WineManager : IWineManager
    {

        IWineRepo wineRepo;

        public WineManager(IWineRepo wineInterface)
        {
            this.wineRepo = wineInterface;
        }

        public void AddWine(Wine wine, WineCeller wineCeller)
        {
            wineRepo.Create(wine, wineCeller);
        }


        public void DeleteWine(int wine_id)
        {
            wineRepo.Delete(wine_id);
        }

        public void UpdateWine(Wine wine)
        {
            wineRepo.Update(wine);
        }

        public List<Wine> GetAll()
        {
            return wineRepo.GetAll();
        }

        public Wine GetWineById(int id)
        {
            return wineRepo.GetById(id);
        }

        public string WineInfo(Wine wine)
        {
            return $"ID: {wine.Id}, Name: {wine.Name}, Price: {wine.Price}";
        }

        public List<Wine> GetAllByFilters(string? keyword, string price, int bottleSize)
        {

            List<Wine> filteredWines = new List<Wine>();
            if (keyword == null)
            {
                keyword = "";
            }
            keyword = keyword.ToLower();

            foreach (Wine wine in wineRepo.GetAll())
            {
                if (wine.Name.ToLower().Contains(keyword))
                {
                    if (price == "Any" || IsPriceInRange(Convert.ToDecimal(wine.Price), price))
                    {
                        if (IsBottleSizeMatch(wine.BottleSize, bottleSize))
                        {
                            filteredWines.Add(wine);
                        }
                    }
                }
            }

            return filteredWines;
        }

        public bool IsPriceInRange(decimal price, string range)
        {
            switch (range)
            {
                case "Any":
                    return true;  // Any bottle size is acceptable
                case "0-10":
                    return price >= 0 && price <= 10;
                case "10-20":
                    return price >= 10 && price <= 20;
                case "20-30":
                    return price >= 20 && price <= 30;
                case "30+":
                    return price >= 30;
                default:
                    return false;
            }
        }

        public bool IsBottleSizeMatch(int wineBottleSize, int desiredBottleSize)
        {
            switch (desiredBottleSize)
            {
                case 0:
                    return true;  // Any bottle size is acceptable
                case 500:
                    return wineBottleSize == 500;
                case 750:
                    return wineBottleSize == 750;
                case 1000:
                    return wineBottleSize == 1000;
                default:
                    return false;
            }
        }






    }
}
