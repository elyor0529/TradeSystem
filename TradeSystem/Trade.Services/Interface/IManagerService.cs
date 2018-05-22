using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade.Data.Models;
using Trade.ViewModels.DAL;

namespace Trade.Services.Interface
{
    public interface IManagerService : IService<ManagerViewModel, Manager>
    {
    }
}
