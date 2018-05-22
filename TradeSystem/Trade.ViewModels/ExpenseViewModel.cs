using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.ViewModels.DAL
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public double Amount { get; set; }
    }
}
