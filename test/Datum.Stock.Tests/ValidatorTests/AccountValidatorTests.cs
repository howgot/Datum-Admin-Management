using Datum.Stock.Application.Authorization.Dto;
using Datum.Stock.Application.Authorization.Validators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datum.Stock.Tests.ValidatorTests
{
    public class AccountValidatorTests
    {
        ValidationResult result;

        [Fact]
        public void Should_Be_Right_Role()
        {
            var validator = new RoleValidator();

            var role = new RoleDto()
            {
                Name = string.Empty,
                Description = string.Empty,
            };

            result = validator.Validate(role);
            Assert.True(!result.IsValid);

            role.Name = "Admin";
            role.Description = "System Administrator";
            result = validator.Validate(role);

            Assert.True(result.IsValid);
        }
    }
}
