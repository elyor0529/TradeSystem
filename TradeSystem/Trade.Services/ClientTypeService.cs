using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trade.Core;
using Trade.Core.Helpers;
using Trade.Data;
using Trade.Data.Models;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.Services
{
    public class ClientTypeService : IClientTypeService
    {
        private static readonly Func<ClientTypeViewModel, ClientType, ClientType> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new ClientType();
            }
            y.Id = x.Id;
            y.Name = x.Name;

            return y;
        };

        private static Func<ClientType, ClientTypeViewModel> ToViewModel
        {
            get
            {
                return x => new ClientTypeViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                };
            }
        }

        public IRepository<ClientType> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<ClientType>();
            }
        }

        public int CreateOrUpdate(ClientTypeViewModel item)
        {
            var data = (ClientType)null;

            if (item.Id > 0)
            {
                data = Repository.FirstOrDefault(x => x.Id == item.Id);
            }

            data = ToDomain(item, data);
            Repository.Store(data);
            Repository.SaveChanges();

            return data.Id;
        }

        public void CreateOrUpdateByRange(IList<ClientTypeViewModel> t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var data = Repository.FirstOrDefault(x => x.Id == id);

            if (data == null)
            {
                ErrorHelper.NotFound("Not found");
            }
            Repository.Delete(data);

            return Repository.SaveChanges() > 0;
        }

        public ClientTypeViewModel Get(Expression<Func<ClientType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<ClientTypeViewModel> GetAll()
        {
            var result = Repository.GetAll()
                        .AsEnumerable()
                        .Select(x => ToViewModel(x))
                        .ToList();

            return result;
        }

        public IList<ClientTypeViewModel> GetAll(Expression<Func<ClientType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ClientTypeViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Max(Func<ClientType, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
