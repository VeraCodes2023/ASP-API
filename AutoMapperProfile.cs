using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace API
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile(){
            CreateMap<User,GetUserDto>();
            CreateMap<AddUserDto,User>();
            CreateMap<UpdateUserDto,User>();
        }
    }
}