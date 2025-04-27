using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;

namespace Loyalty.Application.MemberDemographicsAndProfileAppService.Dto
{
    public class MemberDemographicsAndProfileMapperProfile : Profile
    {
        public MemberDemographicsAndProfileMapperProfile()
        {
            CreateMap<MemberDemographicsAndProfileCreateDto, Domain.Models.MemberDemographicsAndProfile>();
            CreateMap<MemberDemographicsAndProfileUpdateDto, Domain.Models.MemberDemographicsAndProfile>();
            CreateMap<Domain.Models.MemberDemographicsAndProfile, MemberDemographicsAndProfileGetDto>();
            CreateMap<Domain.Models.MemberDemographicsAndProfile, MemberDemographicsAndProfileGetAllDto>();

        }
    }
}