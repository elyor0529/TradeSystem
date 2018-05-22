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
    public class Employee : BaseEntity
    {

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Employee()
        {
            Expenses = new HashSet<Expense>();
            Orders = new HashSet<Order>();
        }
    }
}
