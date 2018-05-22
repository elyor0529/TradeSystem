using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.ViewModels.DAL
{
    public class ProductStockViewModel
    {
        public int Id { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public int? ProductId { get; set; }
        public int? OrderItemId { get; set; }
    }
}
