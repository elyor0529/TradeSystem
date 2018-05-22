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
    public class PaymentService : IPaymentService
    {
        private static readonly Func<PaymentViewModel, Payment, Payment> ToDomain = (x, y) =>
        {
            if (y == null)
            {
                y = new Payment();
            }
            y.Id = x.Id;
            y.OrderId = x.OrderId;
            y.Amount = x.Amount;

            return y;
        };

        private static Func<Payment, PaymentViewModel> ToViewModel
        {
            get
            {
                return x => new PaymentViewModel
                    {
                        Id = x.Id,
                        OrderId = x.OrderId,
                        Amount = x.Amount
                    }; 
            }
        }

        public IRepository<Payment> Repository
        {
            get
            {
                var dbContext = DiConfig.Resolve<RepositoryContextBase>();

                return dbContext.GetRepository<Payment>();
            }
        }

        public IList<PaymentViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int CreateOrUpdate(PaymentViewModel t)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateByRange(IList<PaymentViewModel> t)
        {
            throw new NotImplementedException();
        }

        public PaymentViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PaymentViewModel Get(Expression<Func<Payment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<PaymentViewModel> GetAll(Expression<Func<Payment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Max(Func<Payment, int> selector)
        {
            throw new NotImplementedException();
        }
    }
}
