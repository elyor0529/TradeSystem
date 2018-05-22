using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.ViewModels.DAL
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public IList<OrderItemViewModel> OrderItems { get; set; }
        public IList<ProductClientTypeViewModel> ProductClientTypes { get; set; }
        public IList<ProductStockViewModel> ProductStocks { get; set; }
        public ProductViewModel()
        {
            OrderItems = new List<OrderItemViewModel>();
            ProductClientTypes = new List<ProductClientTypeViewModel>();
            ProductStocks = new List<ProductStockViewModel>();
        }
        //additional
        public string CategoryName { get; set; }
    }
}
