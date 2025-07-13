using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.PassengerInfo.Dtos;

namespace BookingEngine.Application.ReservationInfo.Dtos
{
    public class ReservationInfoMapperProfile : Profile
    {

        public ReservationInfoMapperProfile()
        {
            // For Update
            CreateMap<ReservationCreateDto, Domain.Models.Reservation>();
            CreateMap<PassengerInfoCreateDto, Domain.Models.PassengerInfo>();
            CreateMap<TelephoneCreateDto, Domain.Models.Telephone>();
            CreateMap<PassportCreateDto, Domain.Models.Passport>();
            CreateMap<ContactInfoCreateDto, Domain.Models.Contact>();



            // For Get (Optional for now)
            CreateMap<Domain.Models.Reservation,ReservationGetDto>();
            CreateMap<Domain.Models.PassengerInfo, PassengerInfoGetDto>();
            CreateMap<Domain.Models.Telephone, TelephoneGetDto>();
            CreateMap<Domain.Models.Passport, PassportGetDto>();
            CreateMap<Domain.Models.Contact,ContactInfoGetDto>();



            //For Create 
            CreateMap<PassengerInfoUpdateDto, Domain.Models.PassengerInfo>();
            CreateMap<TelephoneUpdateDto, Domain.Models.Telephone>();
            CreateMap<PassportUpdateDto, Domain.Models.Passport>();
            CreateMap<ContactInfoUpdateDto, Domain.Models.Contact>();


        }
    }
}
