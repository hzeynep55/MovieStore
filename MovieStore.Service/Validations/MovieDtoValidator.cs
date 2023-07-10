using FluentValidation;
using MovieStore.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Service.Validations
{
    public class MovieDtoValidator:AbstractValidator<MovieDto>
    {
        public MovieDtoValidator()
        {
            RuleFor(x => x.MovieName).NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{Property} is required");

            RuleFor(x => x.MovieGenre).NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{Property} is required");

            RuleFor(x => x.Price).InclusiveBetween(1, decimal.MaxValue)
                .WithMessage("{PropertyName} must grather than 0");
        }
    }
}
