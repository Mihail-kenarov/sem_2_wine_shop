using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class WineCeller
    {
        public WineCeller(int id, string name, int yearCreated, string wineStyle, string email, string region, string country)
        {
            Id = id;
            Name = name;
            YearCreated = yearCreated;
            WineStyle = wineStyle;
            Email = email;
            Region = region;
            Country = country;
        }

        public WineCeller(string name, int yearCreated, string wineStyle, string email, string region, string country)
        {
            Name = name;
            YearCreated = yearCreated;
            WineStyle = wineStyle;
            Email = email;
            Region = region;
            Country = country;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int YearCreated { get; set; }
        public string WineStyle { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
