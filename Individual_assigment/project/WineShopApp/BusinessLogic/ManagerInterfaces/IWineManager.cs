using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ManagerInterfaces
{
    public interface IWineManager
    {

        void AddWine(Wine wine, WineCeller wineCeller);
        void UpdateWine(Wine wine);
        void DeleteWine(int wine_id);
        List<Wine> GetAll();
        string WineInfo (Wine wine);
        Wine GetWineById(int wine_id);

    }
}
