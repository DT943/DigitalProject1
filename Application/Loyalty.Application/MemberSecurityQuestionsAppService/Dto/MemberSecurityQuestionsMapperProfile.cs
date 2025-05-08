using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberPreferenceDetailsAppService.Dto;

namespace Loyalty.Application.MemberSecurityQuestionsAppService.Dto
{
    public class MemberSecurityQuestionsMapperProfile : Profile
    {
        public MemberSecurityQuestionsMapperProfile()
        {
            CreateMap<MemberSecurityQuestionsCreateDto, Domain.Models.MemberSecurityQuestions>();
            CreateMap<MemberSecurityQuestionsUpdateDto, Domain.Models.MemberSecurityQuestions>();
            CreateMap<Domain.Models.MemberSecurityQuestions, MemberSecurityQuestionsGetDto>();
            CreateMap<Domain.Models.MemberSecurityQuestions, MemberSecurityQuestionsGetAllDto>();

        }
    }
}
