using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.OTAUserAppService.Dtos;

namespace BookingEngine.Application.PassengerInfo.Dtos
{
    public class PassengerInfoMapperProfile : Profile
    {

        public PassengerInfoMapperProfile()
        {
            // For Update
            CreateMap<PassengerInfoCreateDto, Domain.Models.PassengerInfo>();
            CreateMap<TelephoneCreateDto, Domain.Models.Telephone>();
            CreateMap<PassportCreateDto, Domain.Models.Passport>();


            // For Get (Optional for now)
            CreateMap<Domain.Models.PassengerInfo, PassengerInfoGetDto>();
            CreateMap<Domain.Models.Telephone, TelephoneGetDto>();
            CreateMap<Domain.Models.Passport, PassportGetDto>();


            //For Create 
            CreateMap<PassengerInfoUpdateDto, Domain.Models.PassengerInfo>();
            CreateMap<TelephoneUpdateDto, Domain.Models.Telephone>();
            CreateMap<PassportUpdateDto, Domain.Models.Passport>();



        }
    }
}
