namespace WineLibrary
{
    public class Wine
    {
        private int id;
        private string name;
        private double price;
        private string region;
        private string classification;
        private string sortGrape;
        private double alcohol;
        private double enojoyableTemp;
        private string bottleSize;
        private WineCeller celler;
      

        public Wine() { }

        public Wine(int id, string name, double price, string region, string classification, string sort_grape, double alcohol, int enjoyable_temp , string bottleSize , WineCeller celler)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.region = region;
            this.classification = classification;
            this.sortGrape = sort_grape;
            this.alcohol = alcohol;
            this.enojoyableTemp = enjoyable_temp;
            this.bottleSize = bottleSize;
            this.celler = celler;
        }


        public Wine(int id, string name, double price, string classification, double enjoyable_temp, string bottleSize)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.classification = classification;
            this.enojoyableTemp = enjoyable_temp;
            this.bottleSize = bottleSize;
        }


        public int Id { get => id; }
        public string Name { get => name; }
        public double Price { get => price; }
        public string Region { get => region; }
        public string Classification { get => classification; }
        public string SortGrape { get  => sortGrape; }
        public double Alcohol { get => alcohol; }
        public double EnjoyableTemp { get => enojoyableTemp; }
        public string BottleSize { get => bottleSize; }
        public WineCeller WineCeller { get => celler; }
        public string URL { get { return "/mp3" + name + ".mp3"; } }


    }
}
