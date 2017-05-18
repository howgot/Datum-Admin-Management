using Datum.Stock.Core.Domain.Authorization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Application.Authorization.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            
            //Email
            RuleFor(user => user.Email.Value).NotEmpty().EmailAddress().WithMessage("Check email address right format.");


        }
    }
}
