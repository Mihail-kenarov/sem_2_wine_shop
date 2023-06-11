using BusinessLogic.Entities;

namespace WineShopApp.Entities
{
    public class WineDTO
    {
        private int id;
        private string name;
        private double price;
        private string PhotoPath;


        public WineDTO(Wine wine)
        {
            id = wine.Id;
            name = wine.Name;
            price = wine.Price;
            PhotoPath = wine.PhotoPath;
        }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public string Photopath { get => PhotoPath; set => PhotoPath = value; }
    }
}
