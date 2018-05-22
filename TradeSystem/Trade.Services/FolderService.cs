using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trade.Data;
using Trade.Data.Models;
using Trade.ViewModels.DAL;
using Trade.Core;
using Trade.Services.Interface;
using Trade.Core.Helpers;

namespace Trade.Services
{
    public class FolderService : IFolderService
    {
        private static readonly Func<FolderViewModel, Folder, Folder> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new Folder();
            }
            y.Id = x.Id;
            y.Name = x.Name;
            y.Color = x.Color;

            return y;
        };

        private static Func<Folder, FolderViewModel> ToViewModel
        {
            get
            {
                return x => new FolderViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Color = x.Color
                };
            }
        }

        public IRepository<Folder> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<Folder>();
            }
        }

        public IList<FolderViewModel> GetAll()
        {
            var result = Repository.GetAll()
                .AsEnumerable()
                .Select(x => ToViewModel(x))
                .ToList();

            return result;
        }

        public int CreateOrUpdate(FolderViewModel item)
        {
            var data = (Folder)null;

            if (item.Id > 0)
            {
                data = Repository.FirstOrDefault(x => x.Id == item.Id);
            }

            data = ToDomain(item, data);
            Repository.Store(data);
            Repository.SaveChanges();

            return data.Id;
        }

        public void CreateOrUpdateByRange(IList<FolderViewModel> t)
        {
            throw new NotImplementedException();
        }

        public FolderViewModel GetById(int id)
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

        public FolderViewModel Get(Expression<Func<Folder, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<FolderViewModel> GetAll(Expression<Func<Folder, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Max(Func<Folder, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
