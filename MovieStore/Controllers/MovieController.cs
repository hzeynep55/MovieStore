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
    public class MovieController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Movie> _service;

        public MovieController(IMapper mapper,IService<Movie> service)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await _service.GetAllAsync();
            var moviesDto = _mapper.Map<List<MovieDto>>(movies.ToList());
            return CreateActionResult(CustomResponseDto<List<MovieDto>>.Success(200, moviesDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            var movieDto = _mapper.Map<MovieDto>(movie);
            return CreateActionResult(CustomResponseDto<MovieDto>.Success(200, movieDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieDto movieDto)
        {
            var movie = await _service.AddAsync(_mapper.Map<Movie>(movieDto));
            var moviesDto = _mapper.Map<MovieDto>(movie);
            return CreateActionResult(CustomResponseDto<MovieDto>.Success(201, moviesDto));

        }

        [HttpPut]
        public async Task<IActionResult> Update(MovieDto movieDto)
        {
            await _service.UpdateAsync(_mapper.Map<Movie>(movieDto));
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(movie);
            return CreateActionResult(CustomResponseDto<MovieDto>.Success(204));
        }


    }
}

