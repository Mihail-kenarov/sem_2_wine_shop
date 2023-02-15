using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WineTest.Pages
{
    public class About_usModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public About_usModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
