using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Infrastructure.Application.Validations;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Loyalty.Data.DbContext;

namespace Loyalty.Application.MemberTelephoneDetailsAppService.Dto
{
    public class MemberTelephoneDetailsMapperProfile : Profile
    {
        public MemberTelephoneDetailsMapperProfile()
        {
            CreateMap<MemberTelephoneDetailsCreateDto, Domain.Models.MemberTelephoneDetails>();
            CreateMap<MemberTelephoneDetailsUpdateDto, Domain.Models.MemberTelephoneDetails>();
            CreateMap<Domain.Models.MemberTelephoneDetails, MemberTelephoneDetailsGetDto>();
            CreateMap<Domain.Models.MemberTelephoneDetails, MemberTelephoneDetailsGetAllDto>();

        }
    }
}
