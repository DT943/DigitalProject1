﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace Authentication.Application.Dtos
{
    public class AuthenticationMapperProfile : Profile
    {
        public AuthenticationMapperProfile()
        {
            CreateMap<Domain.Models.ApplicationUser, AuthenticationGetDto>();
        }
    }
}
