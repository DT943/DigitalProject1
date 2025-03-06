using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.PageAppService.Dtos;

namespace CMS.Application.ComponentAppService.Dto
{
    public class ComponentMapperProfile : Profile
    {
        public ComponentMapperProfile()
        {
            CreateMap<Domain.Models.Component, ComponentGetDto>();
            CreateMap<ComponentCreateDto, Domain.Models.Component>();
            CreateMap<ComponentUpdateDto, Domain.Models.Component>();
        }
    }
}
