using Datum.Stock.Application.Authorization.Dto;
using Datum.Stock.Core;
using Datum.Stock.Core.Domain.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datum.Stock.Application.Authorization
{
    public class AccountService : BaseService<User>, IAccountService
    {
        private readonly IRepository<User> _userRepository;

        public AccountService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateOrUpdate(UserDto user)
        {
            var user = 


           bool isExist =  await _userRepository.ExistsAsync(user);
            try
            {
                if (isExist)
                {
                    await _userRepository.InsertAsync(user);
                }
                else
                {
                    await _userRepository.UpdateOneById(user.Id,)
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public Task<bool> IsExist(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValid(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(User user)
        {
            throw new NotImplementedException();
        }
    }
}
