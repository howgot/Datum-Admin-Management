using Datum.Stock.Application.Authorization.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Application.Authorization.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            //FirstName
            RuleFor(user => user.FirstName).NotEmpty().Must(n => n.Length < 50).WithMessage("FirstName must be less than 50 characters.");

            //LastName
            RuleFor(user => user.LastName).NotEmpty().Must(n => n.Length < 50).WithMessage("LastName must be less than 50 characters.");

            //Email
            RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("Check email address right format.");

            //Password
            RuleFor(user => user.Password).NotEmpty().Must(p => p.Length >= 8 && p.Length <= 16).WithMessage("Password must be at least 8 and at most 16 characters");
        }
    }
}
