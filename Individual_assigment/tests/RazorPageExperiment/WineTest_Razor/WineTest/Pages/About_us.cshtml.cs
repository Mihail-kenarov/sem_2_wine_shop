using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WineTest.Pages.DTO;

namespace WineTest.Pages
{
    public class About_usModel : PageModel
    {
        private readonly ILogger<About_usModel> _logger;

        public About_usModel(ILogger<About_usModel> logger)
        {
            _logger = logger;
        }







        public void OnGet()
        {
        }
        public void OnPost()
        {
            string CustomerName = Request.Form["cName"];
            string WineName = Request.Form["wName"];

            int pause = 1;
        }
    }
}
