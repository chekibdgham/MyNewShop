using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewShop.Core.ViewModels
{
    public class BasketSummaryViewModel
    {
        public int? TotalCount { get; set; }
        public decimal? TotalPrice { get; set; }

        public BasketSummaryViewModel()
        {
                
        }
        public BasketSummaryViewModel(int? totalcount,decimal? totalprice)
        {
            TotalCount = totalcount;
            TotalPrice = TotalPrice;
        }
    }
}
