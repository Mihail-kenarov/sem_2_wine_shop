namespace BusinessLogic.Entities
{
    public class Product
    {
     
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


        public int Id { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
