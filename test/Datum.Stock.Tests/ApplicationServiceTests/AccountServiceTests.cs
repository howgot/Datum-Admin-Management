using Autofac;
using Datum.Stock.Application.Authorization;
using Datum.Stock.Application.Authorization.Dto;
using Datum.Stock.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datum.Stock.Tests.ApplicationServiceTests
{
    public class AccountServiceTests : BaseTest
    {
        private readonly IAccountService _accountService;

        public AccountServiceTests()
        {
            _accountService = container.Resolve<IAccountService>();
        }

        UserDto user = new UserDto()
        {
            FirstName = "Test",
            LastName = "User",
            Email = "tuser@datum-apps.com",
            Password = "123456789"
        };


        [Fact]
        public async void Create_User()
        {

            var result = await _accountService.Create(user);

            Assert.True(result);

        }

        [Fact]
        public async void Check_Exist_User()
        {
           
            //Create
            await _accountService.Create(user);

            //Check if Exist
            Assert.True(await _accountService.IsExist(user));
        }

        [Fact]
        public async void Validate_User()
        {
            Assert.True(await _accountService.IsValid(user.Email, user.Password)); //Valid

            Assert.False(await _accountService.IsValid(user.Email, "31242342"));
        }
    }
}
