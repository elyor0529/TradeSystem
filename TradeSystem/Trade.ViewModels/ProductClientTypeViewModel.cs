using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.ViewModels.DAL
{
    public class ProductClientTypeViewModel
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? ClientTypeId { get; set; }
        public double SellingPrice { get; set; }
    }
}
