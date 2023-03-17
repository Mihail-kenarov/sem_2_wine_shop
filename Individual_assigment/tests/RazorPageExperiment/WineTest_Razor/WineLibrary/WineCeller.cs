using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class WineCeller
    {

        private string name;
        private string location;
        private string wineStyle;
        private int dateCreated;


        public WineCeller() { }

        public WineCeller(string name, string location,string wineStyle ,int dateCreated)
        {

            this.name = name;
            this.location = location;
            this.wineStyle = wineStyle;
            this.dateCreated = dateCreated;


        }

        public string Name { get => name; }
        public string Location { get => location; }
        public string WineStyle { get => wineStyle; }
        public int DateCreated { get => dateCreated; }














    }

