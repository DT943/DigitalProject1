using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.PassengerInfo.Dtos;

namespace BookingEngine.Application.PaymantAppService.Dtos
{
    public class StripeResultMapperProfile : Profile
    {

        public StripeResultMapperProfile()
        {
            CreateMap<StripeResultCreateDto, Domain.Models.StripeResult>();

            CreateMap<Domain.Models.StripeResult, StripeResultGetDto>();

            CreateMap<StripeResultUpdateDto, Domain.Models.StripeResult>();

        }
    }
}
