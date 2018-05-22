using Trade.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Data.Models
{
    public class Remainder : BaseEntity
    {
        public string Title { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
