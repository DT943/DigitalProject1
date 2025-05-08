using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberContactPersonsAppService.Dtos;

namespace Loyalty.Application.MemberHobbiesDetailsAppService.Dto
{
    public class MemberHobbiesDetailsMapperProfile : Profile
    {
        public MemberHobbiesDetailsMapperProfile()
        {
            CreateMap<MemberHobbiesDetailsCreateDto, Domain.Models.MemberHobbiesDetails>();
            CreateMap<MemberHobbiesDetailsUpdateDto, Domain.Models.MemberHobbiesDetails>();
            CreateMap<Domain.Models.MemberHobbiesDetails, MemberHobbiesDetailsGetDto>();
            CreateMap<Domain.Models.MemberHobbiesDetails, MemberHobbiesDetailsGetAllDto>();

        }
    }
}