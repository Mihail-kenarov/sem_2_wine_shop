using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.RepoInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WineShopApp.Pages
{
    public class AccessoryMoreDetailsModel : PageModel
    {
        private readonly IAccessoryManager accessoryManager;


        public AccessoryMoreDetailsModel(IAccessoryManager accessoryManager)
        {
            this.accessoryManager = accessoryManager;
        }

        public Accessory Accessory { get; private set; }

        public void OnGet(int id)
        {
            Accessory = accessoryManager.GetByID(id);
        }

    }
}
