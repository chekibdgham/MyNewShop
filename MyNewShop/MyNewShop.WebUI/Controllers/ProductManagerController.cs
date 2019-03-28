using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNewShop.Core.Models;
using MyNewShop.DataAcess.InMemory;
using MyNewShop.Core.ViewModels;
using MyNewShop.Core.Contracts;
using System.IO;

namespace MyNewShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
         // declaration of the context for both product and category

        IRepository<ProductCategory> productCategories;
        IRepository<Product> context;

        public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoriesContext)
        {
            context = productContext;
            productCategories = productCategoriesContext;
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products=context.Collection().ToList();
            List<ProductCategory> categries = productCategories.Collection().ToList();
            
            return View(products);
        }

        public ActionResult Create()
        {
            ProductCategoryManagerViewModel viewmodel = new ProductCategoryManagerViewModel();
            viewmodel.Product = new Product();
            viewmodel.ProductCategories = productCategories.Collection();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                if (file !=null)
                {
                    product.Image = product.Id +file.FileName +Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                }
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            Product product = new Product();
            product = context.Find(id);
            if (product==null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductCategoryManagerViewModel viewmodel = new ProductCategoryManagerViewModel();
                viewmodel.Product = product;
                viewmodel.ProductCategories = productCategories.Collection();
                return View(viewmodel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string id,HttpPostedFileBase file)
        {
            Product productToEdit = context.Find(id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {
                    if (file!=null)
                    {
                        productToEdit.Image = product.Id + file.FileName + Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
                    }
                    productToEdit.Category = product.Category;
                    productToEdit.Description = product.Description;
                    productToEdit.Name = product.Name;
                    productToEdit.Price = product.Price;
                    context.Update(productToEdit);
                    context.Commit();
                    return RedirectToAction("Index");
                }
              
            }
            
           
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Product productToDelete = context.Find(id);
            if (productToDelete==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            Product ProductToDelte = context.Find(id);
            if (ProductToDelte==null)
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