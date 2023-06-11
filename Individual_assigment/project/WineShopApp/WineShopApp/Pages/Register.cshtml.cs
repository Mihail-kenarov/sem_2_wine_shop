using Glimpse.AspNet.Tab;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Entities;
using DataAccessLayer;
using System.ComponentModel.DataAnnotations;

namespace WineShopApp.Pages
{
    public class RegisterModel : PageModel
    {

        private IClientManager clientManager;
        private IOrderManager orderManager;

        public RegisterModel(IClientManager clientManager, IOrderManager orderManager)
        {
            this.clientManager = clientManager;
            this.orderManager = orderManager;
        }

        [Required]
        [BindProperty]
        public string UserName { get; set; }
        [Required]
        [BindProperty]
        public string Email { get; set; }
        [Required]
        [BindProperty]
        public string Password { get; set; }
        [Required]
        [BindProperty]
        public string Subscribtion { get; set; }


        public IActionResult OnPost()
        {
            if (Subscribtion == "normal")
            {
                byte[] salt = Encryption.GenerateSalt();
                byte[] HashedPassword = Encryption.HashPassword(Password, salt);

                var client = new Client(UserName, Email, Subscribtion, HashedPassword, salt);

                clientManager.Add(client);
                
                return RedirectToAction("/Login");

            }

            else if (Subscribtion == "premium")
            {
                byte[] salt = Encryption.GenerateSalt();
                byte[] HashedPassword = Encryption.HashPassword(Password, salt);

                var client = new Client(UserName, Email, Subscribtion, HashedPassword, salt);

                clientManager.Add(client);
            
                return RedirectToAction("/Login");

            }

            return Page();

        }

    }
}
