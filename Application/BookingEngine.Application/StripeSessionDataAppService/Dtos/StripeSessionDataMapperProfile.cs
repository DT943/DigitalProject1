using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.PassengerInfo.Dtos;

namespace BookingEngine.Application.StripeSessionDataAppService.Dtos
{
    public class StripeSessionDataMapperProfile : Profile
    {

        public StripeSessionDataMapperProfile()
        {

            CreateMap<StripeSessionDataCreateDto, Domain.Models.StripeSessionData>();

            CreateMap<Domain.Models.StripeSessionData, StripeSessionDataGetDto>();

        }
    }
}
