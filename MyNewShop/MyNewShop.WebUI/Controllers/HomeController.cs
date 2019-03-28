using MyNewShop.Core.Contracts;
using MyNewShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNewShop.Core.ViewModels;

namespace MyNewShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<ProductCategory> productCategories;

        IRepository<Product> context;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoriesContext)
        {
            context = productContext;
            productCategories = productCategoriesContext;
        }

        public ActionResult Index(string category)
        {
            List<Product> Products;
            List<ProductCategory> categories = productCategories.Collection().ToList();
            if (category==null)
            {
                Products = context.Collection().ToList();
            }
            else
            {
                Products = context.Collection().Where(p => p.Category == category).ToList();
            }

            ProductListViewModel model = new ProductListViewModel();
            model.Products = Products;
            model.ProductCategories = categories;
            return View(model);
        }

        public ActionResult Details(string id)
        {
            Product p = context.Find(id);
            if (p==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(p);
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}