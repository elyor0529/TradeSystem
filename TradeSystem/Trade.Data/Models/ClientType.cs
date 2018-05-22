using Trade.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Data.Models
{
    public class ClientType : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<ProductClientType> ProductClientTypes { get; set; }

        public ClientType()
        {
            Clients = new HashSet<Client>();
            ProductClientTypes = new HashSet<ProductClientType>();
        }
    }
}
