using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Offer.Application.FlightOfferAppService.Dtos;

namespace Offer.Application.HolidayAppService.Dtos
{
    public class HolidayMapperProfile : Profile
    {

        public HolidayMapperProfile()
        {
            CreateMap<Domain.Models.HolidayOffer, HolidayGetDto>();
            CreateMap<HolidayCreateDto, Domain.Models.HolidayOffer>();
            CreateMap<HolidayUpdateDto, Domain.Models.HolidayOffer>();
        }
    }
}
