using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineLibrary
{
    public class WineManagment
    {
        private static WineManagment? instance;

        public static WineManagment Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WineManagment();
                }
                return instance;
            }


        }


        private List<Wine> wines = new List<Wine>();

        private WineManagment()
        {
            WineCeller wc = new WineCeller("Chateu Burgozone","Danube River Valley","Elegant and Complex",1995);
            wines.Add(new Wine(1,"Eva",47.50,"Rosé",14,"750ml"));

            //wc = new WineCeller("Bessa Valley Winery", "Danube River Valley", "Elegant and Complex", 1995);
            wines.Add(new Wine(2,"Deva", 47.50, "Rosé", 14, "750ml"));

            //wc = new WineCeller("Chateu Burgozone", "Danube River Valley", "Elegant and Complex", 1995);
            wines.Add(new Wine(3,"Zeva", 47.50, "Rosé", 14, "750ml"));
        }

        public List<Wine> Songs
        {
            get { return this.wines; }
        }




    }

 }


