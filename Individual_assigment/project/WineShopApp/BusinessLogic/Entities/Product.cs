namespace BusinessLogic.Entities
{
    public class Product
    {
        private int id;
        private int amount;
        private string name;
        private string description;
        private double price;
        public Product() { }
        public Product(int id, int amount, string name, string description, double price)
        {
            Id = id;
            Amount = amount;
            Name = name;
            Description = description;
            Price = price;
        }

        public Product(int amount, string name, string description, double price)
        {
            Amount = amount;
            Name = name;
            Description = description;
            Price = price;
        }


        public int Id { get => id; set => id = value; }
        public int Amount { get => amount; set => amount = value; }
        public string Name { get => name; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); name = value; } }
        public string Description { get => description; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); description = value; } }
        public double Price { get => price; set => price = value; }

        public override string? ToString()
        {
            return Name;
        }
    }
}
