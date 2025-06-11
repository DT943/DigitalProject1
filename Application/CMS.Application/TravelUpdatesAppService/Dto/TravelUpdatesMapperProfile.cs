using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.StaticComponentAppService.Dto;

namespace CMS.Application.TravelUpdatesAppService.Dto
{
    public class TravelUpdatesMapperProfile : Profile
    {
        public TravelUpdatesMapperProfile()
        {
            CreateMap<Domain.Models.TravelUpdates, TravelUpdatesGetDto>();
            CreateMap<TravelUpdatesCreateDto, Domain.Models.TravelUpdates>();
            CreateMap<TravelUpdatesUpdateDto, Domain.Models.TravelUpdates>();
        }
    }
}

