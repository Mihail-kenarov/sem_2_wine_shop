namespace BusinessLogic.Entities
{
    public class Wine : Product
    {
        

        public Wine(int id, int amount, string name, double price, string region, string classification, string sort_grape,
            double alcohol, double enjoyable_temp, int bottleSize, WineCeller wineceller, string photoPath, string description)
            :base(id, amount, name, description, price)
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
           double alcohol, double enjoyable_temp, int bottleSize,string photoPath, string description)
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

        public string Region { get; set; }
        public string Classification { get; set; }
        public string SortGrape { get; set; }
        public double Alcohol { get; set; }
        public double EnjoyableTemp { get; set; }
        public int BottleSize { get; set; }
        public WineCeller WineCeller { get; set; }
        public string PhotoPath { get; set; }








   
    }

}
