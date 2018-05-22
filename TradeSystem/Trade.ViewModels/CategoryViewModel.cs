using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.ViewModels.DAL
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FolderId { get; set; }
        public IList<ProductViewModel> Products { get; set; }
        public CategoryViewModel()
        {
            Products = new List<ProductViewModel>();
        }
        //additional
        public string FolderName { get; set; }
    }
}
