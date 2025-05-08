using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using B2B.Application.TravelAgentOffice.Dto;

namespace B2B.Application.TravelAgentEmployeeAppService.Dto
{
    public class TravelAgentEmployeeMapperProfile : Profile
    {
        public TravelAgentEmployeeMapperProfile()
        {
            CreateMap<Domain.Models.TravelAgentEmployee, TravelAgentEmployeeGetDto>();
            CreateMap<Domain.Models.TravelAgentEmployee, TravelAgentEmployeeGetAllDto>();
            CreateMap<TravelAgentEmployeeCreateDto, Domain.Models.TravelAgentEmployee>();
            CreateMap<TravelAgentEmployeeUpdateDto, Domain.Models.TravelAgentEmployee>();
        }
    }
}
