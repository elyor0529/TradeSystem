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
using Trade.Core.Extensions;
using Trade.Core.Helpers;

namespace Trade.Services
{
    public class CategoryService : ICategoryService
    {
        private static readonly Func<CategoryViewModel, Category, Category> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new Category();
            }
            y.Id = x.Id;
            y.Name = x.Name;
            y.FolderId = x.FolderId;

            return y;
        };

        private static Func<Category, CategoryViewModel> ToViewModel
        {
            get
            {
                return x =>
                {
                    return x == null ? new CategoryViewModel() : new CategoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        FolderId = x.FolderId,
                        FolderName = x.Folder == null ? null : x.Folder.Name
                    };
                };
            }
        }

        public IRepository<Category> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<Category>();
            }
        }

        public IList<CategoryViewModel> GetAll()
        {
            var result = Repository.GetAll()
                .AsEnumerable()
                .Select(x => ToViewModel(x))
                .ToList();

            return result;
        }

        public int CreateOrUpdate(CategoryViewModel item)
        {
            var data = (Category)null;

            if (item.Id > 0)
            {
                data = Repository.FirstOrDefault(x => x.Id == item.Id);
            }

            data = ToDomain(item, data);
            Repository.Store(data);
            Repository.SaveChanges();

            return data.Id;
        }

        public void CreateOrUpdateByRange(IList<CategoryViewModel> t)
        {
            throw new NotImplementedException();
        }

        public CategoryViewModel GetById(int id)
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

        public CategoryViewModel Get(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<CategoryViewModel> GetAll(Expression<Func<Category, bool>> predicate)
        {
            var query = Repository.Where(predicate).AsEnumerable();

            return query == null ? new List<CategoryViewModel>() : query.Select(s => ToViewModel(s)).ToList();
        }

        public int Max(Func<Category, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
