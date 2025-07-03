using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Domain.Models;

namespace BookingEngine.Application.OTAUserAppService.Dtos
{
    public class OTAUserMapperProfile: Profile
    {
        public OTAUserMapperProfile()
        {

            // For Update
            CreateMap<OTAUserUpdateDto, OTAUser>();

            // For Get (Optional for now)
            CreateMap<OTAUser, OTAUserGetDto>();

            //For Create 
            CreateMap<OTAUserCreateDto, OTAUser>();

        }

    }
}
