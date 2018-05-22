using Trade.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Data.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual ICollection<ProductClientType> ProductClientTypes { get; set; }

        public virtual ICollection<ProductStock> ProductStocks { get; set; }

        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            ProductClientTypes = new HashSet<ProductClientType>();
            ProductStocks = new HashSet<ProductStock>();
        }
    }
}
