using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;

namespace Loyalty.Application.MemberTravelAgentDetailsAppService.Dto
{
    public class MemberTravelAgentDetailsMapperProfile : Profile
    {
        public MemberTravelAgentDetailsMapperProfile()
        {
            CreateMap<MemberTravelAgentDetailsCreateDto, Domain.Models.MemberTravelAgentDetails>();
            CreateMap<MemberTravelAgentDetailsUpdateDto, Domain.Models.MemberTravelAgentDetails>();
            CreateMap<Domain.Models.MemberTravelAgentDetails, MemberTravelAgentDetailsGetDto>();
            CreateMap<Domain.Models.MemberTravelAgentDetails, MemberTravelAgentDetailsGetAllDto>();

        }
    }
}
