using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.Date).NotNull().WithMessage("It can't be null");
            RuleFor(c => c.Id).GreaterThanOrEqualTo(1).NotNull();
            RuleFor(c => c.Date).NotEmpty();
            RuleFor(c => c.CarId).NotEmpty();
        }
    }
}
