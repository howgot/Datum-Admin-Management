using AutoMapper;
using Datum.Stock.Application.Authorization;
using Datum.Stock.Application.Authorization.Validators;
using Datum.Stock.Core;
using Datum.Stock.Core.Data;
using Datum.Stock.Core.Domain.Authorization;
using Datum.Stock.Core.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datum.Stock.Application.Authorization
{
    public class AccountService : IAccountService
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly UserValidator _userValidator;
        #endregion

        #region Ctor
        public AccountService(UserManager<User> userManager,
                              UserValidator userValidator)
        {
            _userManager = userManager;
            _userValidator = userValidator;
        }

        #endregion

        #region Methods

        public async Task<bool> Create(string email, string password)
        {
            var result = false;

            try
            {
                var user = new User(email, email);

                result = (await _userManager.CreateAsync(user, password)).Succeeded;
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
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentNullException(email);

                user = await _userManager.FindByEmailAsync(email);
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
                if (string.IsNullOrWhiteSpace(Id))
                    throw new ArgumentNullException(Id);

                user =  await _userManager.FindByIdAsync(Id);
            }
            catch (Exception ex)
            {
               //TODO:Log
            }
            return user;
            
        }

        public async Task<bool> Remove(string email)
        {
            var result = false;
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentNullException(nameof(email));

                var user = await _userManager.FindByEmailAsync(email);

                result = (await _userManager.DeleteAsync(user)).Succeeded;
            }
            catch (Exception ex)
            {
                //TODO:Log
            }

            return result;

        }

        #endregion
    }
}
