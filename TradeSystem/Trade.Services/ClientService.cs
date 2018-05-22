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
using Trade.Core.Helpers;

namespace Trade.Services
{
    public class ClientService : IClientService
    {
        private static readonly Func<ClientViewModel, Client, Client> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new Client();
            }
            y.Id = x.Id;
            y.FirstName = x.FirstName;
            y.LastName = x.LastName;
            y.Address = x.Address;
            y.Phone = x.Phone;
            y.ClientTypeId = x.ClientTypeId;

            return y;
        };

        private static Func<Client, ClientViewModel> ToViewModel
        {
            get
            {
                return x => new ClientViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    Phone = x.Phone,
                    ClientTypeId = x.ClientTypeId,
                    ClientTypeName = x.ClientType == null ? null : x.ClientType.Name
                };
            }
        }

        public IRepository<Client> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<Client>();
            }
        }

        public IList<ClientViewModel> GetAll()
        {
            var result = Repository.GetAll()
                        .AsEnumerable()
                        .Select(x => ToViewModel(x))
                        .ToList();

            return result;
        }

        public int CreateOrUpdate(ClientViewModel item)
        {
            var data = (Client)null;

            if (item.Id > 0)
            {
                data = Repository.FirstOrDefault(x => x.Id == item.Id);
            }

            data = ToDomain(item, data);
            Repository.Store(data);
            Repository.SaveChanges();

            return data.Id;

        }

        public void CreateOrUpdateByRange(IList<ClientViewModel> t)
        {
            throw new NotImplementedException();
        }

        public ClientViewModel GetById(int id)
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

        public ClientViewModel Get(Expression<Func<Client, bool>> predicate)
        {
            var result = Repository.FirstOrDefault(predicate);

            return result == null ? null : ToViewModel(result);
        }

        public IList<ClientViewModel> GetAll(Expression<Func<Client, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Max(Func<Client, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
