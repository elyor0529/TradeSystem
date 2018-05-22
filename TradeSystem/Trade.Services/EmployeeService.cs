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
    public class EmployeeService : IEmployeeService
    {
        private static readonly Func<EmployeeViewModel, Employee, Employee> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new Employee();
            }

            y.Id = x.Id;
            y.FirstName = x.FirstName;
            y.LastName = x.LastName;
            y.Code = x.Code;

            return y;
        };

        private static Func<Employee, EmployeeViewModel> ToViewModel
        {
            get
            {
                return x => new EmployeeViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Code = x.Code
                };
            }
        }

        public IRepository<Employee> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<Employee>();
            }
        }
         
        public IList<EmployeeViewModel> GetAll()
        {
            var result = Repository.GetAll()
                        .AsEnumerable()
                        .Select(x => ToViewModel(x))
                        .ToList();

            return result;
        }

        public int CreateOrUpdate(EmployeeViewModel item)
        {
            var data = (Employee)null;

            if (item.Id > 0)
            {
                data = Repository.FirstOrDefault(x => x.Id == item.Id);
            }

            data = ToDomain(item, data);
            Repository.Store(data);
            Repository.SaveChanges();

            return data.Id;
        }

        public void CreateOrUpdateByRange(IList<EmployeeViewModel> t)
        {
            throw new NotImplementedException();
        }

        public EmployeeViewModel GetById(int id)
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

        public EmployeeViewModel Get(Expression<Func<Employee, bool>> predicate)
        {
            var result = Repository.FirstOrDefault(predicate);

            return result == null ? null : ToViewModel(result);
        }

        public IList<EmployeeViewModel> GetAll(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Max(Func<Employee, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
