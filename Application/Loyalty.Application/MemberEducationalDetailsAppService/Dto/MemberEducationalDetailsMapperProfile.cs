using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberHobbiesDetailsAppService.Dto;

namespace Loyalty.Application.MemberEducationalDetailsAppService.Dto
{
    public class MemberEducationalDetailsMapperProfile : Profile
    {
        public MemberEducationalDetailsMapperProfile()
        {
            CreateMap<MemberEducationalDetailsCreateDto, Domain.Models.MemberEducationalDetails>();
            CreateMap<MemberEducationalDetailsUpdateDto, Domain.Models.MemberEducationalDetails>();
            CreateMap<Domain.Models.MemberEducationalDetails, MemberEducationalDetailsGetDto>();
            CreateMap<Domain.Models.MemberEducationalDetails, MemberEducationalDetailsGetAllDto>();

        }
    }
}