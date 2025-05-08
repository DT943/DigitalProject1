using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel.Application.ContactInfoAppService.Dtos;

namespace Hotel.Application.ContractAppService.Dtos
{
    public class ContractMapperProfile : Profile
    {
        public ContractMapperProfile()
        {

            CreateMap<Domain.Models.Contract, ContractGetDto>();

            CreateMap<ContractCreateDto, Domain.Models.Contract>();

            CreateMap<ContractUpdateDto, Domain.Models.Contract>();
        }

    }
}
