using System.Security.AccessControl;

namespace BusinessLogic.Entities
{
    public class Collection : Product
    {


        public Collection(int id, int amount, string name, string desctiption, double price,List<Accessory> accessories, List<Wine> wines,string events)
        : base(id, amount, name, desctiption, price)
        {
            Events = events;
            Accessories = accessories;
            Wines = wines;
        }
       
        public string Events { get; set; }
        public List<Accessory> Accessories { get; }
        public List<Wine> Wines { get; }



        //Add both lists Accessories and Wines

        //decide these things and what should be in them and afterwords have an idea of how it should be in the database
        //data for a desktop user
        //data for a client 





    }
}
