using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trade.Services.Interface;
using Trade.Data;
using Trade.Data.Models;
using Trade.ViewModels.DAL;
using Trade.Core;

namespace Trade.Services
{
    public class ManagerService : IManagerService
    {
        private static readonly Func<ManagerViewModel, Manager, Manager> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new Manager();
            }

            y.Id = x.Id;
            y.FirstName = x.FirstName;
            y.LastName = x.LastName;
            y.Login = x.Login;
            y.Password = x.Password;

            return y;
        };

        private static Func<Manager, ManagerViewModel> ToViewModel
        {
            get
            {
                return x => new ManagerViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Login = x.Login,
                    Password = x.Password
                };
            }
        }

        public IRepository<Manager> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<Manager>();
            }
        }


        public IList<ManagerViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int CreateOrUpdate(ManagerViewModel t)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateByRange(IList<ManagerViewModel> t)
        {
            throw new NotImplementedException();
        }

        public ManagerViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ManagerViewModel Get(Expression<Func<Manager, bool>> predicate)
        {
            var result = Repository.FirstOrDefault(predicate);

            return result == null ? null : ToViewModel(result);
        }

        public IList<ManagerViewModel> GetAll(Expression<Func<Manager, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Max(Func<Manager, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
