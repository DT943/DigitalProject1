using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberTierDetailsAppService.Dto;

namespace Loyalty.Application.MemberTierPurchaseValidationAppService.Dto
{
    public class MemberTierPurchaseValidationMapperProfile : Profile
    {
        public MemberTierPurchaseValidationMapperProfile()
        {
            CreateMap<MemberTierPurchaseValidationCreateDto, Domain.Models.MemberTierPurchaseValidation>();
            CreateMap<MemberTierPurchaseValidationUpdateDto, Domain.Models.MemberTierPurchaseValidation>();
            CreateMap<Domain.Models.MemberTierPurchaseValidation, MemberTierPurchaseValidationGetDto>();
            CreateMap<Domain.Models.MemberTierPurchaseValidation, MemberTierPurchaseValidationGetDto>();

        }
    }
}
