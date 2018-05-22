using Trade.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade.Data.Models.Enums;

namespace Trade.Data.Models
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public int? ClientTypeId { get; set; }

        [ForeignKey("ClientTypeId")]
        public ClientType ClientType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Client()
        {
            Orders = new HashSet<Order>();
        }
    }
}
