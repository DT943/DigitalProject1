using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.ComponentMetadataAppService.Dto;

namespace CMS.Application.CustomFormAppService.Dto
{
    public class CustomFormMapperProfile : Profile
    {
        public CustomFormMapperProfile()
        {
            CreateMap<Domain.Models.CustomForm, CustomFormGetDto>();
            CreateMap<CustomFormCreateDto, Domain.Models.CustomForm>();
            CreateMap<CustomFormUpdateDto, Domain.Models.CustomForm>();
        }
    }
}
