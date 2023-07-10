using FluentValidation;
using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Service.Validations
{
    public class OrderDtoValidator:AbstractValidator<Order>
    {
        public OrderDtoValidator()
        {
            RuleFor(x => x.CustomerId).InclusiveBetween(1, int.MaxValue)
               .WithMessage("{PropertyName} must grather than 0");

            RuleFor(x => x.MovieId).InclusiveBetween(1, int.MaxValue)
              .WithMessage("{PropertyName} must grather than 0");
        }
    }
}
