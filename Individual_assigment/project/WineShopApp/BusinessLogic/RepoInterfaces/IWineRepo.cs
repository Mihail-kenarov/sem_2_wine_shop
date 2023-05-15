using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IWineRepo

    {
        void Create(Wine wine,WineCeller wineCeller);
        
        List<Wine> GetAll();

        void Update(Wine wine);

        void Delete(int id);

        Wine GetById(int wine_id);

      

    }
}
