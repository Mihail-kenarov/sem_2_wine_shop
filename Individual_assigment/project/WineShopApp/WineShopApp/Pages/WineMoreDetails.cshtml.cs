using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.ManagerInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WineShopApp.Pages
{
    public class WineMoreDetailsModel : PageModel
    {
        private readonly IWineManager wineManager;
    

        public WineMoreDetailsModel(IWineManager wineManager)
        {
            this.wineManager = wineManager;
        }

        public Wine Wine { get; private set; }

        public void OnGet(int id)
        {
           Wine = wineManager.GetWineById(id); 
        }
    }
}
