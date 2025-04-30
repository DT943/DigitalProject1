using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;

namespace Loyalty.Application.MemberPreferenceDetailsAppService.Dto
{
    public class MemberPreferenceDetailsMapperProfile : Profile
    {
        public MemberPreferenceDetailsMapperProfile()
        {
            CreateMap<MemberPreferenceDetailsCreateDto, Domain.Models.MemberPreferenceDetails>();
            CreateMap<MemberPreferenceDetailsUpdateDto, Domain.Models.MemberPreferenceDetails>();
            CreateMap<Domain.Models.MemberPreferenceDetails, MemberPreferenceDetailsGetDto>();
            CreateMap<Domain.Models.MemberPreferenceDetails, MemberPreferenceDetailsGetAllDto>();

        }
    }
}
