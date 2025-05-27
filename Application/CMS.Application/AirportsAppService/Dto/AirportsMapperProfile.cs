using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.ComponentAppService.Dto;

namespace CMS.Application.AirportsAppService.Dto
{
    public class AirportsMapperProfile : Profile
    {
        public AirportsMapperProfile()
        {
            CreateMap<Domain.Models.Airports, AirportsGetDto>();
            CreateMap<AirportsCreateDto, Domain.Models.Airports>();
            CreateMap<AirportsUpdateDto, Domain.Models.Airports>();
        }
    }
}
