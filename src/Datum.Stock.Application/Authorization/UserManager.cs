using Datum.Stock.Core;
using Datum.Stock.Core.Domain.Authorization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datum.Stock.Application.Authorization
{
    public class UserManager
    {
        private readonly IRepository<User> _userRepository;

        public UserManager(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsExistAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(nameof(userId));

            return await _userRepository.ExistsAsync(new FilterDefinitionBuilder<User>().Eq("Id", userId));
        }

        public async Task<bool> RegisterAsync(User user)
        {
            var result = false;

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            try
            {
                if (string.IsNullOrWhiteSpace(user.Id)) //Insert
                {
                    await _userRepository.InsertAsync(user);
                    result = true;
                }
                else 
                {

                }
            }
            catch (Exception)
            {

              //TODO:Log
            }

            return result;
        }
    }
}
