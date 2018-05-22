using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.ViewModels.DAL
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<ExpenseViewModel> Expenses { get; set; }
        public IList<OrderViewModel> Orders { get; set; }
        public EmployeeViewModel()
        {
            Expenses = new List<ExpenseViewModel>();
            Orders = new List<OrderViewModel>();
        }

        #region Overrides of Object

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }

        #endregion
    }
}
