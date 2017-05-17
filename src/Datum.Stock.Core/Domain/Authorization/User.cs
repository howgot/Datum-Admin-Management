using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Datum.Stock.Core.Domain.Authorization
{
    public class User : Entity
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        [BsonIgnore]
        public virtual string FullName => $"{FirstName} {LastName}";
    }

}
