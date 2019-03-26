using MyNewShop.Core.Contracts;
using MyNewShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MyNewShop.Core.ViewModels;

namespace MyNewShop.services
{
    public class BasketService : IBasketService
    {
        IRepository<Product> productContext;
        IRepository<Basket> basketContext;

        public const string BasketSessionName = "eCommerceBasket";
        public BasketService(IRepository<Product> ProductContext,IRepository<Basket> BasketContext)
        {
            this.productContext = ProductContext;
            this.basketContext = BasketContext;
        }

        private Basket GetBasket(HttpContextBase httpContext,bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);
            Basket basket = new Basket();

            if (cookie !=null)
            {
                string basketId = cookie.Value;
                if (!string.IsNullOrEmpty(basketId))
                {
                    basket = basketContext.Find(basketId);
                }
                else
                {
                    if (createIfNull)
                    {
                        basket = CreateNewBasket(httpContext);
                    }
                }
            }
            else
            {
                if (createIfNull)
                {
                    basket = CreateNewBasket(httpContext);
                }
            }
            return basket;
        }

        private Basket CreateNewBasket(HttpContextBase httpContext)
        {
            Basket basket = new Basket();
            basketContext.Insert(basket);
            basketContext.Commit();

            HttpCookie cookie = new HttpCookie(BasketSessionName);
            cookie.Value = basket.Id;
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;
        }

        public void AddToBasket(HttpContextBase httpContext,string productId)
        {
            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                BasketItem newItem = new BasketItem()
                {
                    ProductId = productId,
                    BasketId = basket.Id,
                    Quantity = 1
                };
                basket.BasketItems.Add(newItem);
            }
            else
            {
                item.Quantity = item.Quantity + 1;
            }

            basketContext.Commit();
        }

        public void removeFromBasket(HttpContextBase httpContext, string itemId)
        {
            Basket basket = GetBasket(httpContext, true);
            if (basket!=null)
            {
                BasketItem item = basket.BasketItems.FirstOrDefault(i => i.Id == itemId);
                basket.BasketItems.Remove(item);
                basketContext.Commit();
            }

        }

        public List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext)
        {
            Basket basket= GetBasket(httpContext, false);
            if (basket !=null)
            {
                var results = (from b in basket.BasketItems
                               join p in productContext.Collection()
                               on b.ProductId equals p.Id
                               select new BasketItemViewModel()
                               {
                                   Id = b.Id,
                                   Quantity = b.Quantity,
                                   ProductName = p.Name,
                                   Price = p.Price,
                                   Image = p.Image
                               }
                               ).ToList();
                return results;
            }
            else
            {
                return new List<BasketItemViewModel>();
            }

            
        }

        public BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext)
        {
            BasketSummaryViewModel basketSummary = new BasketSummaryViewModel(0,0);
            List<BasketItemViewModel> basketItems = GetBasketItems(httpContext);
            if (basketItems!=null)
            {
                int? totalCout = (from b in basketItems select b.Quantity).Sum();

                decimal? totalPrice=(from b in basketItems select b.Price*b.Quantity).Sum();

                basketSummary.TotalCount = totalCout?? 0 ;
                basketSummary.TotalPrice = totalPrice?? decimal.Zero ;

                return basketSummary;
            }
            else
            {
                return basketSummary;
            }
        }
    }
}
