
using Datum.Stock.Core.Domain.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datum.Stock.Application.Authorization
{
    public interface IAccountService
    {
        Task<bool> Create(CreateUserInput createUserInput);

        Task<bool> Remove(UserInput userInput);

        Task<User> GetUserByEmail(string email);

        Task<User> GetUserById(string Id);

        Task<User> VerifyAndGetUser(LoginUserInput loginUserInput);
    }
}
