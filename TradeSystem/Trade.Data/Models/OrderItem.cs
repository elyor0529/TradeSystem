using Trade.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Data.Models
{
    public class OrderItem : BaseEntity
    {
        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public double SellingPrice { get; set; }

        public int? Quantity { get; set; }

        public double DiscountAsSom { get; set; }

        public double Discount { get; set; }

        public virtual ICollection<ProductStock> ProductStocks { get; set; }

        public OrderItem()
        {
            ProductStocks = new HashSet<ProductStock>();
        }
    }
}
