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

        public ActionResult Index(string category=null)
        {
            List<Product> Products ;
            List<ProductCategory> Categories = productCategories.Collection().ToList();

            if (category==null)
            {
                Products = context.Collection().ToList();
            }
            else
            {
                Products = context.Collection().Where(x => x.Category == category).ToList();
            }
            ProductListViewModel data = new ProductListViewModel();
            data.Products = Products;
            data.ProductCategories = Categories;
            return View(data);
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