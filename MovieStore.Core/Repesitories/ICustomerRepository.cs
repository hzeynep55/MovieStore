using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Repesitories
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Task<Customer> GetOrder(int customerId);
    }
}
