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
    public class ActorController :CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Actor> _service;

        public ActorController(IMapper mapper, IService<Actor> service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var actors=await _service.GetAllAsync();
            var actorsDto= _mapper.Map<List<ActorDto>>(actors.ToList());
            return CreateActionResult(CustomResponseDto<List<ActorDto>>.Success(200,actorsDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var actors = await _service.GetByIdAsync(id);
            var actorsDto=_mapper.Map<ActorDto>(actors);
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(200,actorsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActorDto actorDto )
        {
            var actors = await _service.AddAsync(_mapper.Map<Actor>(actorDto));
            var actorsDto=_mapper.Map<ActorDto>(actors);
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(201, actorsDto));

        }

        [HttpPut]
        public async Task<IActionResult> Update(ActorDto actorDto)
        {
            await _service.UpdateAsync(_mapper.Map<Actor>(actorDto));
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var actor=await _service.GetByIdAsync(id);
            await _service.RemoveAsync(actor);
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(204));
        }


    }
}
