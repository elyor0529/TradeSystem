using Trade.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Data.Models
{
    public class Folder : BaseEntity
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public Folder()
        {
            Categories = new HashSet<Category>();
        }
    }
}
