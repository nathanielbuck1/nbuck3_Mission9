using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterProject.Models;



namespace WaterProject.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private  Basket basket;
        public CartSummaryViewComponent(Basket b)
        {
            basket = b;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
