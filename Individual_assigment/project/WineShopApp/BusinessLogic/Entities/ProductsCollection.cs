using System.Security.AccessControl;

namespace BusinessLogic.Entities
{
    public class ProductsCollection : Product
    {
        private string @event;
        private readonly List<Accessory> accessoriesList;
        private readonly List<Wine> winesList;

        public ProductsCollection(int id, int amount, string name, string desctiption, double price, List<Accessory> accessories, List<Wine> wines, string events)
        : base(id, amount, name, desctiption, price)
        {
            Event = events;
            accessoriesList = accessories;
            winesList = wines;
        }

        public ProductsCollection(int amount, string name, string desctiption, double price, List<Accessory> accessories, List<Wine> wines, string events)
       : base(amount, name, desctiption, price)
        {
            Event = events;
            accessoriesList = accessories;
            winesList = wines;
        }


        public string Event { get => @event; set => @event = value; }
        public List<Accessory> Accessories => accessoriesList;
        public List<Wine> Wines => winesList;
        public override string? ToString()
        {
            return " Name: " + this.Event + " Price: " + this.Price;
        }
    }
}
