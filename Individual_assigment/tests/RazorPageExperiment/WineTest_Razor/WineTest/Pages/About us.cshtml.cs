using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WineTest.Pages.DTO;

namespace WineTest.Pages
{
    public class About_usModel : PageModel
    {
        //private readonly ILogger<PrivacyModel> _logger;

        //public About_usModel(ILogger<PrivacyModel> logger)
        //{
        //    _logger = logger;
        //}


        //[BindProperty]
        public WineDTO? AboutUs;








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
