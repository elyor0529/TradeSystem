using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade.Data.Models.Enums;

namespace Trade.ViewModels.DAL
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? ClientId { get; set; }
        public OrderStatus Status { get; set; }
        public double DiscountAsPercent { get; set; }
        public double DiscountAsSom { get; set; }
        public double Discount { get; set; }
        public double TotalAmount { get; set; }
        public double PaidAmount { get; set; }
        public IList<OrderItemViewModel> OrderItems { get; set; }
        public IList<PaymentViewModel> Payments { get; set; }
        public IList<RemainderViewModel> Remainders { get; set; }
        public OrderViewModel()
        {
            OrderItems = new List<OrderItemViewModel>();
            Payments = new List<PaymentViewModel>();
            Remainders = new List<RemainderViewModel>();
        }
    }
}
