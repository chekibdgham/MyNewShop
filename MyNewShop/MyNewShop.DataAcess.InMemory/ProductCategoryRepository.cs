using MyNewShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;


namespace MyNewShop.DataAcess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories = new List<ProductCategory>();
        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }
        public void Insert(ProductCategory PC)
        {
            productCategories.Add(PC);
        }
        public void Update(ProductCategory productcategory)
        {
            ProductCategory ProductCategoryToUpdate = productCategories.Find(t => t.Id == productcategory.Id);
            if (ProductCategoryToUpdate != null)
            {
                ProductCategoryToUpdate = productcategory;
            }
            else
            {
                throw new Exception("Product category no found.");
            }
        }
        public ProductCategory Find(string id)
        {
            ProductCategory productCategory = productCategories.Find(f => f.Id == id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product no find");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string id)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(d => d.Id == id);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product category no found.");
            }
        }
    }
}
