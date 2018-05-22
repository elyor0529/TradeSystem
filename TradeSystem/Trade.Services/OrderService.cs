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

namespace Trade.Services
{
    public class OrderService : IOrderService
    {
        private static readonly Func<OrderViewModel, Order, Order> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new Order();
            }
            y.Id = x.Id;
            y.EmployeeId = x.EmployeeId;
            y.ClientId = x.ClientId;
            y.Status = x.Status;
            y.DiscountAsPercent = x.DiscountAsPercent;
            y.DiscountAsSom = x.DiscountAsSom;
            y.Discount = x.Discount;
            y.TotalAmount = x.TotalAmount;
            y.PaidAmount = x.PaidAmount;

            return y;
        };

        private static Func<Order, OrderViewModel> ToViewModel
        {
            get
            {
                return x => new OrderViewModel
                {
                    Id = x.Id,
                    EmployeeId = x.EmployeeId,
                    ClientId = x.ClientId,
                    Status = x.Status,
                    DiscountAsPercent = x.DiscountAsPercent,
                    DiscountAsSom = x.DiscountAsSom,
                    Discount = x.Discount,
                    TotalAmount = x.TotalAmount,
                    PaidAmount = x.PaidAmount
                };
            }
        }

        public IRepository<Order> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<Order>();
            }
        }


        public IList<OrderViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int CreateOrUpdate(OrderViewModel t)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateByRange(IList<OrderViewModel> t)
        {
            throw new NotImplementedException();
        }

        public OrderViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OrderViewModel Get(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<OrderViewModel> GetAll(Expression<Func<Order, bool>> predicate)
        {
            var query = Repository.Where(predicate).AsEnumerable();

            return query == null ? new List<OrderViewModel>() : query.Select(s => ToViewModel(s)).ToList();
        }

        public int Max(Func<Order, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
