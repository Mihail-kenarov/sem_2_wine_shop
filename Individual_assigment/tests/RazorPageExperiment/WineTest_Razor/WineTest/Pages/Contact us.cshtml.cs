using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WineTest.Pages
{
    public class Contact_usModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public Contact_usModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }


    
    }
}
