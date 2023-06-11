using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WineShopApp.Pages
{
    public class ThankYouOrderModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            return RedirectToPage("/Index");
        }



    }
}
