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
    public class DirectorController : CustomBaseController
    {
        private readonly IService<Director> _service;
        private readonly IMapper _mapper; 
        public DirectorController(IService<Director> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var directors=await _service.GetAllAsync();
            var directorsDto=_mapper.Map<List<DirectorDto>>(directors.ToList());
            return CreateActionResult(CustomResponseDto<List<DirectorDto>>.Success(200,directorsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var director= await _service.GetByIdAsync(id);
            var directorDto = _mapper.Map<DirectorDto>(director);
            return CreateActionResult(CustomResponseDto<DirectorDto>.Success(200, directorDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add(DirectorDto directorDto)
        {
            var director = await _service.AddAsync(_mapper.Map<Director>(directorDto));
            var directorsDto = _mapper.Map<DirectorDto>(director);
            return CreateActionResult(CustomResponseDto<DirectorDto>.Success(201, directorDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(DirectorDto directorDto)
        {
            await _service.UpdateAsync(_mapper.Map<Director>(directorDto));
            return CreateActionResult(CustomResponseDto<DirectorDto>.Success(204));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var director = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(director);
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(204));
        }
    }
}
