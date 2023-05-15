using BusinessLogic;
using Glimpse.AspNet;
using Glimpse.AspNet.Tab;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WineShopApp.Pages
{
    public class LoginModel : PageModel
    {


        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        //public IActionResult OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UserService us = new UserService(new  DataAccessLayer.UserRepo());
        //        if(us.isValidUser(UserName, Password))
        //        {
        //            List<Claim> claims = new List<Claim>();
        //            claims.Add(new Claim(ClaimTypes.Name, UserName));


        //            ClaimsIdentity cid = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //            AuthenticationHttpContextExtensions.SignInAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(cid));

        //            return RedirectToPage("/Wines");
                    
        //        }

        //    }

        //    return RedirectToPage("/Abouts_us");
        //}
        

    }
}
