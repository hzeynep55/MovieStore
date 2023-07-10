using AutoMapper;
using MovieStore.Core.DTOs;
using MovieStore.Core.Entities;
using MovieStore.Core.IUnitOfWorks;
using MovieStore.Core.Repesitories;
using MovieStore.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerrepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, ICustomerRepository customerrepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _customerrepository = customerrepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CustomerWithOrderDto>> GetOrder(int customerId)
        {
            var customer = await _customerrepository.GetOrder(customerId);
            var customerDto = _mapper.Map<CustomerWithOrderDto>(customer);
            return CustomResponseDto<CustomerWithOrderDto>.Success(200, customerDto);
        }
    }
}
