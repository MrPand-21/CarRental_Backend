using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=> c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ModelYear).Must(StartsWith2).WithMessage("Cars models must not older than 2000.");
        }

        private bool StartsWith2(string arg)
        {
            return arg.StartsWith("2");
        }
    }
}
