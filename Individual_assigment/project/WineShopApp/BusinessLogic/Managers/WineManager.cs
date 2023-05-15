using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.ManagerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
    public class WineManager : IWineManager
    {

        IWineRepo wineInterface;

        public WineManager(IWineRepo wineInterface)
        {
            this.wineInterface = wineInterface;
        }

        public void AddWine(Wine wine,WineCeller wineCeller)
        {
            wineInterface.Create(wine, wineCeller);
        }


        public void DeleteWine(int wine_id)
        {
            wineInterface.Delete(wine_id);
        }

        public void UpdateWine(Wine wine)
        {
            wineInterface.Update(wine);
        }

        public List<Wine> GetAll()
        {
            return wineInterface.GetAll();
        }

        public Wine GetWineById(int id)
        {
            return wineInterface.GetById(id);
        }

        public string WineInfo(Wine wine)
        {
            return  $"ID: {wine.Id}, Name: {wine.Name}";
        }
    }
}
