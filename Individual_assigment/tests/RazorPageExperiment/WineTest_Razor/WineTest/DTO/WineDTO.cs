using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineLibrary;


namespace WineTest.Pages.DTO

{
    public class WineDTO
    {

       public WineDTO() { }


       public WineDTO(Wine wine) 
       {
            this.Name = wine.Name;
            this.Price = wine.Price;
            this.URL = wine.URL;

       }

       public string Name { get; set; }
       public double Price { get; set; }
       public string URL { get; set; }




    }

    
}
