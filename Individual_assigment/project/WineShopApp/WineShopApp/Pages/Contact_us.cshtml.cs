using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace WineShopApp.Pages
{
    public class Contact_usModel : PageModel
    {
        [BindProperty]
        public ContactFeedback ContactFeedback { get; set; }

        public string ResultMessage { get; set; }

        public void OnGet()
        {

        }




        public IActionResult OnPost()
        {
			TempData["ContactMessage"] = $"Hello {ContactFeedback.Name}, thank you for contacting us! We will respond within 2 working days to {ContactFeedback.Email}";

            return RedirectToPage("/ThankYou");
		}
    }
}
