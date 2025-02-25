using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Offer.Application.OfferAppService.Dtos;

namespace Offer.Application.FlightOfferAppService.Dtos
{
    public class FlightOfferMapperProfile : Profile
    {
            
        public FlightOfferMapperProfile()
        {
            CreateMap<Domain.Models.FlightOffer, FlightOfferGetDto>();
            CreateMap<FlightOfferCreateDto, Domain.Models.FlightOffer>();
            CreateMap<FlightOfferUpdateDto, Domain.Models.FlightOffer>();
        }
    }
}
