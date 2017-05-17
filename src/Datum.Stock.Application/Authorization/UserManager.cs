using Datum.Stock.Core;
using Datum.Stock.Core.Data;
using Datum.Stock.Core.Domain.Authorization;
using Datum.Stock.Core.Helpers;
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

        public async Task<bool> IsExistByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            return await _userRepository.ExistsAsync(new FilterDefinitionBuilder<User>().Eq(u => u.Email, email));
        }

        public async Task<bool> IsExistAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(nameof(userId));

            return await _userRepository.ExistsAsync(new FilterDefinitionBuilder<User>().Eq(u => u.Id, userId));
        }

        public async Task<bool> RegisterAsync(User user)
        {
            var result = false;

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            try
            {
                //Check user if exist
                if (await IsExistByEmailAsync(user.Email))
                    throw new ArgumentException("This user is already exist.");
                
                //Create
                await _userRepository.InsertAsync(user);

                result = true;
            }
            catch (Exception ex)
            {

                //TODO:Log
            }

            return result;
        }


        public async Task<bool> UpdateAsync(User user)
        {
            var result = false;

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            try
            {
                if (!await IsExistByEmailAsync(user.Email))
                    throw new ArgumentException("This user is not exist.");


                var update = Builders<User>.Update
                             .Set(u => u.IsActive, user.IsActive)
                             .Set(u => u.IsAdmin, user.IsAdmin)
                             .Set(u => u.LastName, user.LastName)
                             .Set(u => u.FirstName, user.FirstName);

                await _userRepository.UpdateOneByIdAsync(user.Id, update);


                result = true;
            }
            catch (Exception ex)
            {

                //TODO:Log
            }

            return result;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            return await _userRepository.GetOneAsync(new FilterDefinitionBuilder<User>().Eq("Email", email));
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(nameof(userId));

            return await _userRepository.GetOneByIdAsync(userId);
        }

        public async Task<bool> ValidateUser(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            if (!await IsExistByEmailAsync(email))
                return false;

            var user = await GetUserByEmailAsync(email);

            return PasswordHelper.VerifyPassword(password, user.Salt, user.Password) && user.IsActive;

        }

        public async Task<bool> Delete(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            try
            {
                var update = Builders<User>.Update.Set(u => u.IsActive, false);
                await _userRepository.UpdateOneByIdAsync(user.Id, update);
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log

            }

            return false;

        }
    }
}
