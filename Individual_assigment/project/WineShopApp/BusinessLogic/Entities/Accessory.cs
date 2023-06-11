using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Accessory : Product
    {
        private string type;

        public Accessory(int id, int amount, string name, string description, double price, string type)
        : base(id, amount, name, description, price)
        {
            Type = type;
        }

        public Accessory(int amount, string name, string description, double price, string type)
        : base(amount, name, description, price)
        {
            Type = type;
        }

        public string Type { get => type; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); type = value; } }

        public override string? ToString()
        {
            return " Name: " + this.Name + " Price: " + this.Price;
        }
    }
}
