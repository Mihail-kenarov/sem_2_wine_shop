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
    public class WineCellerManagment : IWineCellerManager
    {

        IWineCellerRepo wineCellerRepoInterface;

        public WineCellerManagment(IWineCellerRepo wineCellerRepo)
        {
            this.wineCellerRepoInterface = wineCellerRepo;
        }

        public void AddWineCeller(WineCeller wineCeller)    
        {
            wineCellerRepoInterface.Create(wineCeller);
        }

        public void DeleteWineCeller(int wc_id)
        {
            wineCellerRepoInterface.Delete(wc_id);
        }

        public List<WineCeller> GetAll()
        {
            return wineCellerRepoInterface.GetAll();
        }

        public WineCeller GetWineCellerById(int id)
        {
            return wineCellerRepoInterface.GetByIdWineCeller(id);
        }

        public WineCeller GetWineCellerByName(string Name)
        {
            return wineCellerRepoInterface.GetName(Name);
        }

        public void UpdateWineCeller(WineCeller wineCeller)
        {
            wineCellerRepoInterface.Update(wineCeller);
        }

        public string WineCellerInfo(WineCeller wineCeller)
        {
            return $"ID: {wineCeller.Id}, Name: {wineCeller.Name}, Country: {wineCeller.Country}";
        }



    }
}
