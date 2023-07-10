using FluentValidation;
using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Service.Validations
{
    public class CustomerDtoValidator:AbstractValidator<Customer>
    {
        public CustomerDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is Required")
                .NotEmpty().WithMessage("{PropertyName} is Required");

            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is Required")
                .NotEmpty().WithMessage("{PropertyName} is Required");
        }
    }
}
