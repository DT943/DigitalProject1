using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace B2B.Application.TravelAgentOffice.Dto
{
    public class TravelAgentOfficeMapperProfile : Profile
    {
        public TravelAgentOfficeMapperProfile()
        {
            CreateMap<Domain.Models.TravelAgentOffice, TravelAgentOfficeGetDto>();
            CreateMap<Domain.Models.TravelAgentOffice, TravelAgentOfficeGetAllDto>();
            CreateMap<TravelAgentOfficeCreateDto, Domain.Models.TravelAgentOffice>();
            CreateMap<TravelAgentOfficeUpdateDto, Domain.Models.TravelAgentOffice>();

            CreateMap<TravelAgentPOSCreateDto, Domain.Models.TravelAgentPOS>();
            CreateMap<Domain.Models.TravelAgentPOS, TravelAgentPOSGetDto>();

        }
    }
}
