using Microsoft.EntityFrameworkCore;
using MovieStore.Core.Entities;
using MovieStore.Core.Repesitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Repository.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(AppDbContext context):base(context)
        {

        }

        public async Task<Customer> GetOrder(int customerId)
        {
            return await _appDbContext.Customers.Include(x=>x.Orders).Where(x=>x.CustomerId== customerId).SingleOrDefaultAsync();
        }
    }
}
