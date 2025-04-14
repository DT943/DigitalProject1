using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using B2B.Application.TravelAgentEmployeeAppService.Dto;

namespace B2B.Application.TravelAgentApplicationAppService.Dto
{
    public class TravelAgentApplicationMapperProfile : Profile
    {
        public TravelAgentApplicationMapperProfile()
        {
            CreateMap<Domain.Models.TravelAgentApplication, TravelAgentApplicationGetDto>();
            CreateMap<Domain.Models.TravelAgentApplication, TravelAgentApplicationGetAllDto>();
            CreateMap<Domain.Models.EmployeeApplication, EmployeeApplicationGetDto>();

            CreateMap<TravelAgentApplicationCreateDto, Domain.Models.TravelAgentApplication>();
            CreateMap<TravelAgentApplicationUpdateDto, Domain.Models.TravelAgentApplication>();
            CreateMap<EmployeeApplicationCreateDto, Domain.Models.EmployeeApplication>();
            CreateMap<EmployeeApplicationUpdateDto, Domain.Models.EmployeeApplication>();
        }
    }
}
