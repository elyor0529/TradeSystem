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
    public class ProductService : IProductService
    {
        private static readonly Func<ProductViewModel, Product, Product> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new Product();
            }
            y.Id = x.Id;
            y.Name = x.Name;
            y.CategoryId = x.CategoryId;

            return y;
        };

        private static Func<Product, ProductViewModel> ToViewModel
        {
            get
            {
                return x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category == null ? null : x.Category.Name
                };
            }
        }

        public IRepository<Product> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<Product>();
            }
        }

        public IList<ProductViewModel> GetAll()
        {
            var result = Repository.GetAll()
                .AsEnumerable()
                .Select(x => ToViewModel(x))
                .ToList();

            return result;
        }

        public int CreateOrUpdate(ProductViewModel item)
        {
            var data = (Product)null;

            if (item.Id > 0)
            {
                data = Repository.FirstOrDefault(x => x.Id == item.Id);
            }

            data = ToDomain(item, data);
            Repository.Store(data);
            Repository.SaveChanges();

            return data.Id;
        }

        public void CreateOrUpdateByRange(IList<ProductViewModel> t)
        {
            throw new NotImplementedException();
        }

        public ProductViewModel GetById(int id)
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

        public ProductViewModel Get(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<ProductViewModel> GetAll(Expression<Func<Product, bool>> predicate)
        {
            var query = Repository.Where(predicate).AsEnumerable();

            return query == null ? new List<ProductViewModel>() : query.Select(s => ToViewModel(s)).ToList();
        }

        public int Max(Func<Product, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
