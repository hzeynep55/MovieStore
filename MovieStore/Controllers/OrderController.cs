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
    public class OrderController : CustomBaseController
    {
        private readonly IService<Order> _service;
        private readonly IMapper _mapper;

        public OrderController(IService<Order> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var orders = await _service.GetAllAsync();
            var ordersDto = _mapper.Map<List<OrderDto>>(orders.ToList());
            return CreateActionResult(CustomResponseDto<List<OrderDto>>.Success(200, ordersDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetByIdAsync(id);
            var orderDto = _mapper.Map<MovieDto>(order);
            return CreateActionResult(CustomResponseDto<MovieDto>.Success(200, orderDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderDto orderDto)
        {
            var order = await _service.AddAsync(_mapper.Map<Order>(orderDto));
            var ordersDto = _mapper.Map<OrderDto>(order);
            return CreateActionResult(CustomResponseDto<OrderDto>.Success(201, ordersDto));

        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderDto orderDto)
        {
            await _service.UpdateAsync(_mapper.Map<Order>(orderDto));
            return CreateActionResult(CustomResponseDto<OrderDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var order = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(order);
            return CreateActionResult(CustomResponseDto<OrderDto>.Success(204));
        }

    }
}
