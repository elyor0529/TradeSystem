using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.ViewModels.DAL
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? ClientTypeId { get; set; }
        public IList<OrderViewModel> Orders { get; set; }
        public ClientViewModel()
        {
            Orders = new List<OrderViewModel>();
        }

        //additional
        public string ClientTypeName { get; set; }

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
