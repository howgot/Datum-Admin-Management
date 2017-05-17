using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datum.Stock.Application.Authorization.Dto
{
    public class UserDto : BaseDto
    {

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
