using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.ViewModels.DAL
{
    public class RemainderViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int? OrderId { get; set; }
    }
}
