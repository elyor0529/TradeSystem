using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.ViewModels.DAL
{
    public class ClientTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ClientViewModel> Clients { get; set; }
        public IList<ProductClientTypeViewModel> ProductClientTypes { get; set; }
        public ClientTypeViewModel()
        {
            Clients = new List<ClientViewModel>();
            ProductClientTypes = new List<ProductClientTypeViewModel>();
        }
    }
}
