using AspNetCore.Identity.MongoDB;
using AutoMapper;
using Datum.Stock.Application.Authorization;
using Datum.Stock.Application.Authorization.Validators;
using Datum.Stock.Core;
using Datum.Stock.Core.Data;
using Datum.Stock.Core.Domain.Authorization;
using Datum.Stock.Core.Helpers;
using Datum.Stock.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Datum.Stock.Application.Authorization
{
    public class AccountService : IAccountService
    {
        #region Fields
        private readonly MongoUserStore<User> _userManager;
        private readonly UserValidator _userValidator;

        #endregion

        #region Ctor
        public AccountService(UserValidator userValidator, MongoUserStore<User> userManager)
        {
            _userManager = userManager;
            _userValidator = userValidator;

        }

        #endregion

        #region Methods

        public async Task<bool> Create(CreateUserInput createUserInput)
        {
            var result = false;

            try
            {
                var user = new User(createUserInput.Email, createUserInput.Password);
                user.SetPasswordHash(SecurityHelper.CalculateHash(createUserInput.Password));
                result = (await _userManager.CreateAsync(user, CancellationToken.None)).Succeeded;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User user = null;
            try
            {
                email.ArgumentNullCheck();

                user = await _userManager.FindByNameAsync(email, CancellationToken.None);
            }
            catch (Exception ex)
            {
                //TODO:Log
            }
            return user;
        }

        public async Task<User> GetUserById(string Id)
        {
            User user = null;
            try
            {
                Id.ArgumentNullCheck();

                user = await _userManager.FindByIdAsync(Id, CancellationToken.None);
            }
            catch (Exception ex)
            {
                //TODO:Log
            }
            return user;

        }

        public async Task<bool> Remove(UserInput userInput)
        {
            var result = false;
            try
            {
                userInput.ArgumentNullCheck();

                var user = await _userManager.FindByNameAsync(userInput.Email, CancellationToken.None);

                result = (await _userManager.DeleteAsync(user, CancellationToken.None)).Succeeded;
            }
            catch (Exception ex)
            {
                //TODO:Log
            }

            return result;

        }

        public async Task<User> VerifyAndGetUser(LoginUserInput loginUserInput)
        {
            User user = null;
            try
            {
                var existingUser = await GetUserByEmail(loginUserInput.Email);

                existingUser.ArgumentNullCheck();

                if (SecurityHelper.CheckMatch(existingUser.PasswordHash, loginUserInput.Password))
                    user = existingUser;
            }
            catch (Exception ex)
            {
                //TODO:Log
            }
            return user;
        }

        #endregion
    }
}
