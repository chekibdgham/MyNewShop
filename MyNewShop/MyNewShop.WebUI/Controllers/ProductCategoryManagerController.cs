using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNewShop.Core;
using MyNewShop.DataAcess.InMemory;
using MyNewShop.Core.Models;
using MyNewShop.Core.Contracts;

namespace MyNewShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        IRepository<ProductCategory> context;

        public ProductCategoryManagerController(IRepository<ProductCategory> productCategoryContext)
        {
            this.context = productCategoryContext;
        }   
        
        // GET: ProductCategory
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productcategory = new ProductCategory();
            return View(productcategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory pc)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            else
            {
                context.Insert(pc);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            ProductCategory productcategory = context.Find(id);
            if (productcategory==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productcategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productcategory,string id)
        {
            ProductCategory ProductCategoryToEdit = context.Find(id);
            if (ProductCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productcategory);
                }
                else
                {
                    ProductCategoryToEdit.CategoryName = productcategory.CategoryName;
                    context.Update(ProductCategoryToEdit);
                    context.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(string id)
        {
            ProductCategory ProductCategoryToDelete = new ProductCategory();
            ProductCategoryToDelete = context.Find(id);
            if (ProductCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
                return View(ProductCategoryToDelete);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            ProductCategory pc = new ProductCategory();
            pc = context.Find(id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}