using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WineShopApp.Entities;

namespace WineShopApp.Pages
{
    public class OrderModel : PageModel
    {
        private IOrderManager orderManager;
        private IClientManager clientManager; 

        public OrderModel(IOrderManager orderManager, IClientManager clientManager)
        {
            this.orderManager = orderManager;
            this.clientManager = clientManager;
        }

        
        [BindProperty]
        public string EnteredLocation { get; set; }
        public OrderDTO order { get; set; }

        public void OnGet()
        {
            
            int clientId = Convert.ToInt32(User.FindFirst("ClientID").Value);
            Client cliet = clientManager.GetUserById(clientId);
            Order OngoingOrder = orderManager.GetOrderByClient(cliet);
            order = new OrderDTO(OngoingOrder);
            if (OngoingOrder.Products == null)
            {
                order.TotalPrice = 0;
            }
            else
            {
               
                order.TotalPrice = orderManager.CalculateTotalPrice(OngoingOrder);
            }

        }

        public IActionResult OnPost(int id) 
        {
            int clientId = Convert.ToInt32(User.FindFirst("ClientID").Value);
            Order CurrentOrder = orderManager.GetByID(id);
            order = new OrderDTO(CurrentOrder);
            CurrentOrder.Location = EnteredLocation;
            CurrentOrder.TotalPrice = orderManager.CalculateTotalPrice(CurrentOrder);
            orderManager.FinishOrder(CurrentOrder);
            
            Order newOrder = new Order();

            newOrder.Client = clientManager.GetUserById(clientId);
            orderManager.Create(newOrder);

            return RedirectToPage("/ThankYouOrder");
        }

    }
}
