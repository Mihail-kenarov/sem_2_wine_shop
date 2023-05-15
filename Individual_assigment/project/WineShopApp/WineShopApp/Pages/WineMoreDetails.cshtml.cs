using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WineShopApp.Pages
{
    public class WineMoreDetailsModel : PageModel
    {
        private readonly IWineRepo wineRepository;
    

        public WineMoreDetailsModel(IWineRepo wineRepository)
        {
            this.wineRepository = wineRepository;
        }

        public Wine Wine { get; private set; }

        public void OnGet(int id)
        {
           Wine =  wineRepository.GetById(id); 
        }
    }
}
