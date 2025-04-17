using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.ComponentAppService.Dto;

namespace CMS.Application.ComponentMetadataAppService.Dto
{
    public class ComponentMetadataMapperProfile : Profile
    {
        public ComponentMetadataMapperProfile()
        {
            CreateMap<Domain.Models.ComponentMetadata, ComponentMetadataGetDto>();
            CreateMap<ComponentMetadataCreateDto, Domain.Models.ComponentMetadata>();
            CreateMap<ComponentMetadataUpdateDto, Domain.Models.ComponentMetadata>();
        }
    }
}
