
using Datum.Stock.Core.Domain.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datum.Stock.Application.Authorization
{
    public interface IAccountService
    {
        Task<bool> Create(string email, string password);

        Task<bool> Remove(string email);

        Task<User> GetUserByEmail(string email);

        Task<User> GetUserById(string Id);
    }
}
