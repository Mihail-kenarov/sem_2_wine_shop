using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class WineManagment
    {
        
        private IWineCellerRepo _wineCellerRepo;
        private List<Wine> wines = new List<Wine>();

        public WineManagment()
        {

        }

        public IEnumerable<Wine> GetAllWines()
        {
            return wines;
        }

        public Wine GetWine(int id)
        {
            return wines.FirstOrDefault(w => w.Id == id);
        }
    }


}