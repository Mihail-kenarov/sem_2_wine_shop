using BusinessLogic.Entities;

namespace WineShopApp.Entities
{
    public class AccessoryDTO
    {
        private int id;
        private string name;
        private double price;

       
        public AccessoryDTO(Accessory accessory)
        {
            id = accessory.Id;
            name = accessory.Name;
            price = accessory.Price;
        }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
    }
}
