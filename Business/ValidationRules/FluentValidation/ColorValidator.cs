using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.Colorid).NotEmpty();
            RuleFor(c => c.Name).Must(EndsWithColor);
        }

        private bool EndsWithColor(string arg)
        {
            return arg.EndsWith("Color");
        }
    }
}
