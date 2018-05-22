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
    public class ExpenseService : IExpenseService
    {
        private static readonly Func<ExpenseViewModel, Expense, Expense> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new Expense();
            }
            y.Id = x.Id;
            y.EmployeeId = x.EmployeeId;
            y.Amount = x.Amount;

            return y;
        };

        private static Func<Expense, ExpenseViewModel> ToViewModel
        {
            get
            {
                return x => new ExpenseViewModel
                {
                    Id = x.Id,
                    EmployeeId = x.EmployeeId,
                    Amount = x.Amount
                };
            }
        }

        public IRepository<Expense> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<Expense>();
            }
        }

        public IList<ExpenseViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int CreateOrUpdate(ExpenseViewModel t)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateByRange(IList<ExpenseViewModel> t)
        {
            throw new NotImplementedException();
        }

        public ExpenseViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ExpenseViewModel Get(Expression<Func<Expense, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<ExpenseViewModel> GetAll(Expression<Func<Expense, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Max(Func<Expense, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
