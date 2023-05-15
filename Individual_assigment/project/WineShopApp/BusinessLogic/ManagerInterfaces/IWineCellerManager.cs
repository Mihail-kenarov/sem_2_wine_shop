using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ManagerInterfaces
{
    public interface IWineCellerManager
    {

        void AddWineCeller(WineCeller wineCeller);
        void UpdateWineCeller(WineCeller wineCeller);
        void DeleteWineCeller(int wc_id);
        List<WineCeller> GetAll();
        string WineCellerInfo(WineCeller wineCeller);
        WineCeller GetWineCellerById(int id);
        WineCeller GetWineCellerByName(string Name);


    }
}
