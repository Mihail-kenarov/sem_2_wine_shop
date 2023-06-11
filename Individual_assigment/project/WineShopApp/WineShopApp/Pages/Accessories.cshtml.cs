using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WineShopApp.Entities;

namespace WineShopApp.Pages
{
    public class AccessoriesModel : PageModel
    {
		private readonly IAccessoryManager accessoryManager;
        private readonly IOrderManager orderManager;
        private readonly IClientManager clientManager;
        private readonly IProductManager productManager;
        public List<AccessoryDTO> Accessories;

        public AccessoriesModel(IAccessoryManager accessoryManager, IOrderManager orderManager, IClientManager clientManager, IProductManager productManager)
        {
            this.accessoryManager = accessoryManager;
            this.orderManager = orderManager;
            this.clientManager = clientManager;
            this.productManager = productManager;
            Accessories = new List<AccessoryDTO>();
        }

        public void OnGet()
		{
			foreach (Accessory accessory in accessoryManager.GetAll())
			{
				this.Accessories.Add(new AccessoryDTO(accessory));
			}
		}

        public IActionResult OnGetAddToCart(int ID)
        {

            if (User.Identity.IsAuthenticated)
            {

                int clientId = Convert.ToInt32(User.FindFirst("ClientID").Value);
                Client cliet = clientManager.GetUserById(clientId);
                Order order = orderManager.GetOrderByClient(cliet);
                Product product = productManager.GetByID(ID);
                orderManager.PutProductToOrder(product, order);
                return RedirectToPage("/Order");


            }
            else
            {
                return RedirectToPage("/Register");
            }
        }
    }
}
