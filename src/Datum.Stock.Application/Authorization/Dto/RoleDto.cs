using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datum.Stock.Application.Authorization.Dto
{
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Locked { get; set; }
    }
}
