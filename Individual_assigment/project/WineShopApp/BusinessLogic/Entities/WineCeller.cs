using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class WineCeller
    {
        private int id;
        private string name;
        private int yearCreated;
        private string wineStyle;
        private string email;
        private string region;
        private string country;

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

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); name = value; } }
        public int YearCreated { get => yearCreated; set => yearCreated = value; }
        public string WineStyle { get => wineStyle; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); wineStyle = value; } }
        public string Email { get => email; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); email = value; } }
        public string Region { get => region; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); region = value; } }
        public string Country { get => country; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); country = value; } }
    }
}
