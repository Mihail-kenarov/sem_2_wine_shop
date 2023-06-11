using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using WineShopApp.Entities;
using System.ComponentModel.DataAnnotations;

namespace WineShopApp.Pages
{
    public class WinesModel : PageModel
	{

        private readonly IWineManager wineManager;
		private readonly IOrderManager orderManager;
		private readonly IClientManager clientManager;
		private readonly IProductManager productManager;
		public List<WineDTO> Wines;

        public WinesModel(IWineManager wineManager, IOrderManager orderManager, IClientManager clientManager, IProductManager productManager)
        {
            Wines = new List<WineDTO>();
            this.wineManager = wineManager;
            this.orderManager = orderManager;
            this.clientManager = clientManager;
            this.productManager = productManager;
        }

        [BindProperty]
        public string Keyword { get; set; }
     
        [BindProperty]
        public string priceRange { get; set; }
     
        [BindProperty]
        public string selectedBottleSize { get; set; }

        public void OnGet()
		{
            foreach(Wine wine in wineManager.GetAll())
			{
                this.Wines.Add(new WineDTO(wine));
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

        public IActionResult OnPost()
        {
            
            string keyword = Keyword;
            string price = priceRange;
            int bottleSize = Convert.ToInt32(selectedBottleSize);
            
            
            foreach(Wine wine in wineManager.GetAllByFilters(keyword, price, bottleSize))
            {
                Wines.Add(new WineDTO(wine));
            }

            return Page();
        }
    }







    
}
