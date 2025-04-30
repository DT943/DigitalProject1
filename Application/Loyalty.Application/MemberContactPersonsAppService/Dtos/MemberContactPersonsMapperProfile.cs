using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;

namespace Loyalty.Application.MemberContactPersonsAppService.Dtos
{
    public class MemberContactPersonsMapperProfile : Profile
    {
        public MemberContactPersonsMapperProfile()
        {
            CreateMap<MemberContactPersonsCreateDto, Domain.Models.MemberContactPersons>();
            CreateMap<MemberContactPersonsUpdateDto, Domain.Models.MemberContactPersons>();
            CreateMap<Domain.Models.MemberContactPersons, MemberContactPersonsGetDto>();
            CreateMap<Domain.Models.MemberContactPersons, MemberContactPersonsGetAllDto>();

        }
    }
}