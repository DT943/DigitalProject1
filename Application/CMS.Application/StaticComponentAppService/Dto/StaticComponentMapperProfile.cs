using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.ComponentAppService.Dto;

namespace CMS.Application.StaticComponentAppService.Dto
{
    public class StaticComponentMapperProfile : Profile
    {
        public StaticComponentMapperProfile()
        {
            CreateMap<Domain.Models.StaticComponent, StaticComponentGetDto>();
            CreateMap<StaticComponentCreateDto, Domain.Models.StaticComponent>();
            CreateMap<StaticComponentUpdateDto, Domain.Models.StaticComponent>();
        }
    }
}

