using MyNewShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNewShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;
        public BasketController(IBasketService BS)
        {
            this.basketService = BS;
        }

        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View();
        }

        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(HttpContext, Id);
            return View();
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.removeFromBasket(HttpContext, Id);
            return View();
        }

        public PartialViewResult BasketSummary()
        {
            basketService.GetBasketSummary(HttpContext);
            return PartialView();
        }
    }
}