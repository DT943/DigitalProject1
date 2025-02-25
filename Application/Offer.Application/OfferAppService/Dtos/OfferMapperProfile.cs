using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Offer.Application.OfferAppService.Dtos
{
    public class OfferMapperProfile : Profile
    {
        public OfferMapperProfile()
        {
            CreateMap<Domain.Models.Offer, OfferGetDto>();
            CreateMap<OfferCreateDto, Domain.Models.Offer>();
            CreateMap<OfferUpdateDto, Domain.Models.Offer>();
        }
    }
}
