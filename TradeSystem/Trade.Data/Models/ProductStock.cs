using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade.Data.Models.Base;

namespace Trade.Data.Models
{
    public class ProductStock : BaseEntity
    {
        public double UnitPrice { get; set; }

        public double Quantity { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int? OrderItemId { get; set; }

        [ForeignKey("OrderItemId")]
        public OrderItem OrderItem { get; set; }
    }
}
