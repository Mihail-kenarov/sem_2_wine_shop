using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WineTest.Pages.DTO;

namespace WineTest.Pages
{
    public class Contact_usModel : PageModel
    {
        private readonly ILogger<Contact_usModel> _logger;

     


        [BindProperty]
        public ContactDTO Contact { get; set; }


        public void OnGet()
        {
        }

        public void OnPost()
        {

        }
    
    }
}
