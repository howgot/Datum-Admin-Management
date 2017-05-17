using AutoMapper;
using Datum.Stock.Application.Authorization.Dto;
using Datum.Stock.Application.Authorization.Validators;
using Datum.Stock.Core;
using Datum.Stock.Core.Data;
using Datum.Stock.Core.Domain.Authorization;
using Datum.Stock.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datum.Stock.Application.Authorization
{
    public class AccountService : IAccountService
    {
        #region Fields
        private readonly IRepository<User> _userRepository;
        private readonly UserManager _userManager;
        private readonly UserValidator _userValidator;
        #endregion

        #region Ctor
        public AccountService(IRepository<User> userRepository,
                              UserManager userManager,
                              UserValidator userValidator)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _userValidator = userValidator;
        }
        #endregion

        #region Methods
        public async Task<bool> Create(UserDto userDto)
        {
            //Validate
            var result = await _userValidator.ValidateAsync(userDto);

            if (!result.IsValid)
                throw new ArgumentException(string.Join(",", result.Errors));

            //Mapping
            var user = Mapper.Map<User>(userDto);

            //Password
            user.Salt = PasswordHelper.CreateRandomSalt();
            user.Password = PasswordHelper.GetHashedPassword(userDto.Password, user.Salt);
            user.IsActive = true;
            return await _userManager.RegisterAsync(user);
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            if (!await _userManager.IsExistByEmailAsync(email))
                throw new ArgumentException("There isn't any user by this email");

            var user = await _userManager.GetUserByEmailAsync(email);

            return Mapper.Map<UserDto>(user);

        }

        public async Task<UserDto> GetUserById(string userId)
        {
            if (!await _userManager.IsExistAsync(userId))
                throw new ArgumentException("There isn't any user by this userId");

            var user = await _userManager.GetUserByIdAsync(userId);

            return Mapper.Map<UserDto>(user);
        }

        public async Task<bool> IsExist(UserDto userDto)
        {
            //Validate
            var result = await _userValidator.ValidateAsync(userDto);

            if (!result.IsValid)
                throw new ArgumentException(string.Join(",", result.Errors));

            //Mapping
            var user = Mapper.Map<User>(userDto);

            return await _userManager.IsExistByEmailAsync(user.Email);
        }

        public async Task<bool> IsValid(string email, string password)
        {
            return await _userManager.ValidateUser(email, password);
        }

        public async Task<bool> Remove(UserDto userDto)
        {
            //Validate
            var result = await _userValidator.ValidateAsync(userDto);

            if (!result.IsValid)
                throw new ArgumentException(string.Join(",", result.Errors));

            //Mapping
            var user = Mapper.Map<User>(userDto);

            return await _userManager.Delete(user);
        }

        public Task<bool> Update(UserDto user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
