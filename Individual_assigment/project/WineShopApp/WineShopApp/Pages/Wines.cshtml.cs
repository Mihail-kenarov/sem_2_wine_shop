using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace WineShopApp.Pages
{
    public class WinesModel : PageModel
	{
        private readonly IWineRepo wineRepository;

        public IEnumerable<Wine> Wines { get; set; }


		public WinesModel(IWineRepo wineRepository)
		{
			this.wineRepository = wineRepository;
		}

		public void OnGet()
		{
            Wines = wineRepository.GetAll();
		}
	}
}
