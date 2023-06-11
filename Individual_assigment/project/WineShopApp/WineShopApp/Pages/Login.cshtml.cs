using BusinessLogic;
using Glimpse.AspNet;
using Glimpse.AspNet.Tab;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using BusinessLogic.Managers;
using BusinessLogic.RepoInterfaces;
using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;

namespace WineShopApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IClientManager clientManager;
        public LoginModel(IClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Invalid data";
                return Page();
            }

            if (clientManager.ValidateUser(UserName, Password) == null)
            {
                ViewData["ErrorMessage"] = "Invalid username and/or password";
                return Page();
            }

            Client client = clientManager.GetUserByUsername(UserName);
            int Id = client.Id;
            string subscibtion = client.Subscribtion;
            
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, UserName));
            claims.Add(new Claim("ClientID", Id.ToString()));      

            ClaimsIdentity cid = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationHttpContextExtensions.SignInAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(cid));


            return RedirectToPage("ProfilePage");

        }


    }
}
