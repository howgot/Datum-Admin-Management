using Datum.Stock.Application.Authorization.Dto;
using Datum.Stock.Core.Domain.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datum.Stock.Application.Authorization
{
    public interface IAccountService
    {
        Task<bool> Create(UserDto user);

        Task<bool> Update(UserDto user);

        Task<bool> IsExist(UserDto user);

        Task<bool> IsValid(string email, string password);

        Task<bool> Remove(UserDto user);

        Task<UserDto> GetUserByEmail(string email);

        Task<UserDto> GetUserById(string Id);
    }
}
