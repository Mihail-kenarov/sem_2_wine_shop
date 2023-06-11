namespace BusinessLogic.Entities
{
    public class Wine : Product
    {
        private string region;
        private string classification;
        private string sortGrape;
        private double alcohol;
        private double enjoyableTemp;
        private int bottleSize;
        private WineCeller wineCeller;
        private string photoPath;

        public Wine() { }

        public Wine(int id, int amount, string name, double price, string region, string classification, string sort_grape,
            double alcohol, double enjoyable_temp, int bottleSize, WineCeller wineceller, string photoPath, string description)
            : base(id, amount, name, description, price)
        {
            Region = region;
            Classification = classification;
            SortGrape = sort_grape;
            Alcohol = alcohol;
            EnjoyableTemp = enjoyable_temp;
            BottleSize = bottleSize;
            WineCeller = wineceller;
            PhotoPath = photoPath;
        }

        public Wine(int amount, string name, double price, string region, string classification, string sort_grape,
            double alcohol, double enjoyable_temp, int bottleSize, WineCeller wineceller, string photoPath, string description)
            : base(amount, name, description, price)
        {
            Region = region;
            Classification = classification;
            SortGrape = sort_grape;
            Alcohol = alcohol;
            EnjoyableTemp = enjoyable_temp;
            BottleSize = bottleSize;
            WineCeller = wineceller;
            PhotoPath = photoPath;
        }

        public Wine(int amount, string name, double price, string region, string classification, string sort_grape,
           double alcohol, double enjoyable_temp, int bottleSize, string photoPath, string description)
           : base(amount, name, description, price)
        {
            Region = region;
            Classification = classification;
            SortGrape = sort_grape;
            Alcohol = alcohol;
            EnjoyableTemp = enjoyable_temp;
            BottleSize = bottleSize;
            PhotoPath = photoPath;
        }

        public string Region { get => region; set => region = value; }
        public string Classification { get => classification; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); classification = value; } }
        public string SortGrape { get => sortGrape; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); sortGrape = value; } }
        public double Alcohol { get => alcohol; set => alcohol = value; }
        public double EnjoyableTemp { get => enjoyableTemp; set => enjoyableTemp = value; }
        public int BottleSize { get => bottleSize; set => bottleSize = value; }
        public WineCeller WineCeller { get => wineCeller; set => wineCeller = value; }
        public string PhotoPath { get => photoPath; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); photoPath = value; } }

        public override string? ToString()
        {
            return " Name: " + this.Name + " Price: " + this.Price;
        }
    }

}
