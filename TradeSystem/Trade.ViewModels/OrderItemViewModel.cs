using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.ViewModels.DAL
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public double SellingPrice { get; set; }
        public int? Quantity { get; set; }
        public double DiscountAsSom { get; set; }
        public double Discount { get; set; }
        public IList<ProductStockViewModel> ProductStocks { get; set; }
        public OrderItemViewModel()
        {
            ProductStocks = new List<ProductStockViewModel>();
        }
    }
}
