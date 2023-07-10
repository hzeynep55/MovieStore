using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Core.DTOs;
using MovieStore.Core.Entities;
using MovieStore.Core.Services;

namespace MovieStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Customer> _service;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper, IService<Customer> service)
        {
            _mapper = mapper;
            _service = service; 
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customers = await _service.GetAllAsync();
            var customersDto = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customersDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            var customerDto = _mapper.Map<ActorDto>(customer);
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(200, customerDto));
        }

        [HttpGet("[action]/(customerid)")]
        public async Task<IActionResult> GetOrder(int custometId)
        {
            return CreateActionResult(await _customerService.GetOrder(custometId));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerDto customerDto)
        {
            var customer = await _service.AddAsync(_mapper.Map<Customer>(customerDto));
            var customersDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, customersDto));

        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            await _service.UpdateAsync(_mapper.Map<Customer>(customerDto));
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(204));
        }
    }
}
