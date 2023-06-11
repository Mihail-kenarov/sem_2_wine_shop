using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.RepoInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WineShopApp.Pages
{
    [Authorize]
    public class ProfilePageModel : PageModel
    {
        private IClientManager clientManager;

        [BindProperty]
        public Client client { get; set; }

        public ProfilePageModel(IClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        public IActionResult OnGet(int id)
        {
            // Get the username of the currently logged-in user
            string username = HttpContext.User.Identity.Name;

            // Retrieve the employee with the matching username
            client = clientManager.GetUserByUsername(username);

            if (client == null)
            {
                return NotFound();
            }

            return Page();
        }


        public IActionResult OnPost()
        {           

            // Retrieve the authenticated user's username
            string username = HttpContext.User.FindFirstValue(ClaimTypes.Name);
           
            // Retrieve the corresponding employee record
            Client selectedClient = clientManager.GetUserByUsername(username);

            // Update the employee record with the new information
            selectedClient.Email = client.Email;
            selectedClient.Username = client.Username;
            
            // Save the changes to the database
            clientManager.Update(selectedClient);

            return RedirectToPage("/ProfilePage", new { id = selectedClient.Id });
        }










    }
}
