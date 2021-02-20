using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotNull().MinimumLength(8).Must(IncludesNumber).WithMessage("Your password must includes numbers and its length must be higher than 8 letters!");
        }

        private bool IncludesNumber(string arg)
        {
            return arg.Contains("1") || arg.Contains("2") || arg.Contains("3") || arg.Contains("4") || arg.Contains("5") || arg.Contains("6") || arg.Contains("7") || arg.Contains("8") || arg.Contains("9") || arg.Contains("0");
        }
    }
}
