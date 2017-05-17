using Datum.Stock.Application.Authorization.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Application.Authorization.Validators
{
    public class RoleValidator : AbstractValidator<RoleDto>
    {
        public RoleValidator()
        {
            //Name
            RuleFor(role => role.Name).NotEmpty().Must(name => name.Length <= 50).WithMessage("Role Name must be less than 50 characters.");

            //Description
            RuleFor(role => role.Description).NotEmpty().Must(desc => desc.Length <= 250).WithMessage("Role Description must be less than 250 characters.");

        }
    }
}
