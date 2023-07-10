using FluentValidation;
using MovieStore.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Service.Validations
{
    public class ActorDtoValidator:AbstractValidator<ActorDto>
    {
        public ActorDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is Required")
                .NotEmpty().WithMessage("{PropertyName} is Required");

            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is Required")
                .NotEmpty().WithMessage("{PropertyName} is Required");
            
         
        }
    }
}
