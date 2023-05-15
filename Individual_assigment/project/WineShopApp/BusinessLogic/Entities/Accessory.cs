using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Accessory : Product
    {
       
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

        public string Type { get; set; }

    }
}
