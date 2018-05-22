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
    public class Order : BaseEntity
    {
        public int? EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int? ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public OrderStatus Status { get; set; }

        public double DiscountAsPercent { get; set; }

        public double DiscountAsSom { get; set; }

        public double Discount { get; set; }

        public double TotalAmount { get; set; }

        public double PaidAmount { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<Remainder> Remainders { get; set; }

        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            Payments = new HashSet<Payment>();
            Remainders = new HashSet<Remainder>();
        }
    }
}
