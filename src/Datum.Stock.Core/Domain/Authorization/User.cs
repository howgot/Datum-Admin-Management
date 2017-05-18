using AspNetCore.Identity.MongoDB;
using Datum.Stock.Core.Data;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System;
using AspNetCore.Identity.MongoDB.Models;

namespace Datum.Stock.Core.Domain.Authorization
{
    public class User : MongoIdentityUser
    {
        public User(string userName) : base(userName)
        {
        }

        public User(string userName, string email) : base(userName, email)
        {
        }

        public User(string userName, MongoUserEmail email) : base(userName, email)
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IsAdmin { get; set; }

   
    }

}
