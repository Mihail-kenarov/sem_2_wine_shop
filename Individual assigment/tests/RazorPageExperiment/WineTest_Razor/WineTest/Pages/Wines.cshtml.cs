using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WineTest.Pages
{
    public class WinesModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public WinesModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
