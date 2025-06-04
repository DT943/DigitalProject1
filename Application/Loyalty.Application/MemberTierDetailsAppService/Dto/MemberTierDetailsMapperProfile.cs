using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;

namespace Loyalty.Application.MemberTierDetailsAppService.Dto
{
    public class MemberTierDetailsMapperProfile : Profile
    {
        public MemberTierDetailsMapperProfile()
        {
            CreateMap<MemberTierDetailsCreateDto, Domain.Models.MemberTierDetails>();
            CreateMap<MemberTierDetailsUpdateDto, Domain.Models.MemberTierDetails>();
            CreateMap<Domain.Models.MemberTierDetails, MemberTierDetailsGetDto>();
            CreateMap<Domain.Models.MemberTierDetails, MemberTierDetailsGetDto>();

        }
    }
}
