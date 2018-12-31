using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyNewShop.Core.Models;

namespace MyNewShop.DataAcess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products==null)
            {
                products = new List<Product>();
            }
        }
        public void Commit()
        {
            cache["products"] = products;
        }
        public void Insert(Product P)
        {
            products.Add(P);
        }
        public void Update(Product product)
        {
            Product ProductToUpdate = products.Find(t => t.Id == product.Id);
            if (ProductToUpdate!=null)
            {
                ProductToUpdate = product;
            }
            else
            {
                throw new Exception("Product no found.");
            }
        }
        public Product Find(string id)
        {
            Product product = products.Find(f => f.Id == id);
            if (product!=null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product no find");
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string id)
        {
            Product productToDelete = products.Find(d => d.Id == id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product no found.");
            }
        }
    }
}
