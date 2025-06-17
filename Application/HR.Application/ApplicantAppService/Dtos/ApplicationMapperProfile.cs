using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.JobPostAppService.Dtos;
using HR.Domain.Models;

namespace HR.Application.ApplicationAppService.Dtos
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<ApplicationCreateDto, Domain.Models.Application>();

            CreateMap<ApplicationUpdateDto, Domain.Models.Application>();

            CreateMap< Domain.Models.Application, ApplicationGetDto >();

            CreateMap<Domain.Models.Application, ApplicationGetAllDto>();
        }

    }
}
