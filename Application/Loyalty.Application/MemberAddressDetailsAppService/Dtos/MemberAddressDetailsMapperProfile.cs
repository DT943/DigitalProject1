using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Loyalty.Application.MemberAddressDetailsAppService.Dtos
{
    public class MemberAddressDetailsMapperProfile : Profile
    {
        public MemberAddressDetailsMapperProfile()
        {
            CreateMap<MemberAddressDetailsCreateDto, Domain.Models.MemberAddressDetails>();
            CreateMap<MemberAddressDetailsUpdateDto, Domain.Models.MemberAddressDetails>();
            CreateMap<Domain.Models.MemberAddressDetails, MemberAddressDetailsGetDto>();
            CreateMap<Domain.Models.MemberAddressDetails, MemberAddressDetailsGetAllDto>();

        }
    }
}