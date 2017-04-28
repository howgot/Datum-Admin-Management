using Datum.Stock.Core.Domain.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datum.Stock.Application.Authorization
{
    public interface IAccountService
    {
        Task<bool> CreateOrUpdate(User user);

        Task<bool> IsExist(User user);

        Task<bool> IsValid(string username, string password);

        Task<bool> Remove(User user);
    }
}
