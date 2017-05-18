using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Datum.Stock.Core.Domain.Authorization;

namespace Datum.Stock.Application.Mapping
{
    public class DatumMapperModule
    {
        public static void Load()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Role, RoleDto>().ReverseMap());
            //Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>().ReverseMap());
        }
    }
}
