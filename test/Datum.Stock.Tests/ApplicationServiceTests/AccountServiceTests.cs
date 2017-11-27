using Autofac;
using Datum.Stock.Application.Authorization;
using Datum.Stock.Core.Domain.Authorization;
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

        User user = new User("user@howgot.com", "user@howgot.com");



        [Fact]
        public async void Create_User()
        {

            var result = await _accountService.Create(user.Email.Value, "123456");

            Assert.True(result);

        }
     
    }
}
