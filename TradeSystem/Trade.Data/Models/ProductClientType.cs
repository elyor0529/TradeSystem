using Trade.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Data.Models
{
    public class ProductClientType : BaseEntity
    {
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int? ClientTypeId { get; set; }

        [ForeignKey("ClientTypeId")]
        public ClientType ClientType { get; set; }

        public double SellingPrice { get; set; }
    }
}
