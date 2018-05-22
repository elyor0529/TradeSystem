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
    public class RemainderService : IRemainderService
    {
        private static readonly Func<RemainderViewModel, Remainder, Remainder> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new Remainder();
            }
            y.Id = x.Id;
            y.Title = x.Title;
            y.Comment = x.Comment;
            y.Date = x.Date;
            y.OrderId = x.OrderId;

            return y;
        };

        private static Func<Remainder, RemainderViewModel> ToViewModel
        {
            get
            {
                return x => new RemainderViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Comment = x.Comment,
                    Date = x.Date,
                    OrderId = x.OrderId
                };
            }
        }

        public IRepository<Remainder> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<Remainder>();
            }
        }

        public IList<RemainderViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int CreateOrUpdate(RemainderViewModel t)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateByRange(IList<RemainderViewModel> t)
        {
            throw new NotImplementedException();
        }

        public RemainderViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RemainderViewModel Get(Expression<Func<Remainder, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<RemainderViewModel> GetAll(Expression<Func<Remainder, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Max(Func<Remainder, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
